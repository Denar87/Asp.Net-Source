using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ERPSSL.INV.BLL;
using ERPSSL.Procurement.BLL;
using ERPSSL.INV.DAL;
using ERPSSL.HRM.BLL;
using ERPSSL.HRM.DAL;
using ERPSSL.HRM.DAL.Repository;
using Microsoft.Reporting.WebForms;
using System.Drawing;
using ERPSSL.PAYROLL.BLL;

namespace ERPSSL.PAYROLL
{
    public partial class SalaryHeldUpList : System.Web.UI.Page
    {
        Salary_Proccess_BLL aSalary_Proccess_BLL = new Salary_Proccess_BLL();
        IChallanBLL aChallanBll = new IChallanBLL();
        IChallanBLL ic = new IChallanBLL();
        RequisionBll aRequisionBll = new RequisionBll();
        RChallanBLL rChallanBll = new RChallanBLL();
        Office_BLL officeBll = new Office_BLL();

        private ERPSSLHBEntities _context = new ERPSSLHBEntities();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetEmployeeInfo();
                //txtFromDate.Text = DateTime.Now.ToShortDateString();
            }
        }

        private void GetEmployeeInfo()
        {
            try
            {
                string eid = ((SessionUser)Session["SessionUser"]).EID;
                if (eid != null)
                {
                    EMPOYEE_BLL employeeBll = new EMPOYEE_BLL();
                    string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                    //int eid = Convert.ToInt16(ddlReportingTo.SelectedValue);

                    List<AssignTo> assignTos = new List<AssignTo>();
                    assignTos = employeeBll.GetDesgination(eid, OCODE).ToList();
                    foreach (AssignTo assign in assignTos)
                    {
                        hdnAdminEID.Value = ((SessionUser)Session["SessionUser"]).EID;
                        hdnOfficeID.Value = Convert.ToInt32(assign.OfficeID).ToString();
                    }
                }
            }
            catch
            {
            }
        }

        protected void headerLevelCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                CheckBox headerChkBox = ((CheckBox)GridViewSalaryList.HeaderRow.FindControl("headerLevelCheckBox"));

                if (headerChkBox.Checked == true)
                {
                    foreach (GridViewRow gvRow in GridViewSalaryList.Rows)
                    {
                        CheckBox rowChkBox = ((CheckBox)gvRow.FindControl("rowLevelCheckBox"));
                        rowChkBox.Checked = true;  //for all row checkbox       
                    }
                }
                else
                {
                    foreach (GridViewRow gvRow in GridViewSalaryList.Rows)
                    {
                        CheckBox rowChkBox = ((CheckBox)gvRow.FindControl("rowLevelCheckBox"));
                        rowChkBox.Checked = false;
                    }
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

        protected void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                string OCODE = ((SessionUser)Session["SessionUser"]).OCode;

                List<Salary_Viewer> empSalary = new List<Salary_Viewer>();

                empSalary = aSalary_Proccess_BLL.GetAll_HeldUpList(txtFromDate.Text).ToList();
                if (empSalary.Count > 0)
                {
                    Session["rptDs"] = "HRMRptGetSalaryInfoDS";
                    Session["rptDt"] = empSalary;
                    Session["rptFile"] = "/PAYROLL/reports/HRM_RPT_AllSalaryWithOTSheet.rdlc";
                    Session["rptTitle"] = "All Help Up Salary List";
                    Response.Redirect("Report_Viewer.aspx");
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No data found!')", true);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

        protected void btnReleaseHeldUpSalary_Click(object sender, EventArgs e)
        {
            try
            {
                if (GridViewSalaryList.Rows.Count < 0)
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No Held Up Salary in the list!')", true);
                }

                foreach (GridViewRow gvRow in GridViewSalaryList.Rows)
                {
                    CheckBox rowChkBox = ((CheckBox)gvRow.FindControl("rowLevelCheckBox"));

                    Label lblEID = ((Label)gvRow.FindControl("lblEID"));
                    TextBox txttotalDeductDay = ((TextBox)gvRow.FindControl("txttotalDeductDay"));

                    string eid = lblEID.Text.ToString();
                    DateTime salaryMonth = Convert.ToDateTime(txtFromDate.Text);

                    var helduplist = aSalary_Proccess_BLL.GetAll_HeldUpList(txtFromDate.Text).ToList();

                    if (rowChkBox.Checked == true)
                    {
                        if (helduplist.Count > 0)
                        {
                            HRM_Pay_Salary _HRM_Pay_Salary = new HRM_Pay_Salary();

                            _HRM_Pay_Salary = _context.HRM_Pay_Salary.Where(c => c.EID == eid && c.Salary_Month == salaryMonth).First();

                            _HRM_Pay_Salary.Pay_Status = true;
                            _HRM_Pay_Salary.IsSalaryRelease = true;
                            _HRM_Pay_Salary.OCode = ((SessionUser)Session["SessionUser"]).OCode;
                            _HRM_Pay_Salary.Edit_Date = DateTime.Now;
                            _HRM_Pay_Salary.Edit_User = ((SessionUser)Session["SessionUser"]).UserId;

                            try
                            {
                                _context.SaveChanges();
                                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Data Process Successfully')", true);
                                GridViewSalaryList.DataSource = null;
                                GridViewSalaryList.DataBind();
                            }
                            catch (Exception ex)
                            {
                                throw ex;
                            }
                        }
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No Data Found!')", true);
                    }
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

        void GetHeldUpByDate()
        {
            try
            {
                string OCODE = ((SessionUser)Session["SessionUser"]).OCode;

                List<Salary_Viewer> empSalary = new List<Salary_Viewer>();

                empSalary = aSalary_Proccess_BLL.GetAll_HeldUpList(txtFromDate.Text).ToList();
                if (empSalary.Count > 0)
                {
                    GridViewSalaryList.DataSource = empSalary.ToList();
                    GridViewSalaryList.DataBind();

                    //for (int j = 0; j < GridViewSalaryList.Rows.Count; j++)
                    //{

                    //    GridViewSalaryList.Rows[j].Cells[16].BackColor = System.Drawing.Color.Green;
                    //    CheckBox cb = new System.Web.UI.WebControls.CheckBox();
                    //    cb.ID = "chkChecked_" + j;
                    //    cb.EnableViewState = true;
                    //    cb.Text = "chk" + j;
                    //    GridViewSalaryList.Rows[j].Cells[16].Controls.Add(cb);

                    //}
                }

                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No Data Processed!')", true);
                    GridViewSalaryList.DataSource = null;
                    GridViewSalaryList.DataBind();
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            GetHeldUpByDate();
        }

    }
}
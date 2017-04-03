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
    public partial class SalaryConfirmation : System.Web.UI.Page
    {
        int m = 0;

        Salary_Proccess_BLL aSalary_Proccess_BLL = new Salary_Proccess_BLL();
        IChallanBLL aChallanBll = new IChallanBLL();
        IChallanBLL ic = new IChallanBLL();
        RequisionBll aRequisionBll = new RequisionBll();
        RChallanBLL rChallanBll = new RChallanBLL();
        Office_BLL officeBll = new Office_BLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Session["UserID"] != null) && (Session["OCode"] != null))
            {
                if (!IsPostBack)
                {
                    GetEmployeeInfo();
                    txtFromDate.Text = DateTime.Now.ToShortDateString();
                }
            }
            else
            {
                Response.Redirect("..\\AppGateway\\Login.aspx");
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

        protected void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (GridViewSalaryList.Rows.Count == 0)
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No processed salray in the list!')", true);
                    return;
                }

                List<HRM_Pay_Salary> lstHRM_Pay_Salary = new List<HRM_Pay_Salary>();

                foreach (GridViewRow gvRow in GridViewSalaryList.Rows)
                {
                    //CheckBox rowChkBox = ((CheckBox)gvRow.FindControl("rowLevelCheckBox"));

                    HRM_Pay_Salary _HRM_Pay_Salary = new HRM_Pay_Salary();

                    //if (rowChkBox.Checked == true)
                    //{
                    CheckBox rowheldupCheckBox = ((CheckBox)gvRow.FindControl("rowheldupCheckBox"));
                    Label lblSalaryId = (Label)gvRow.FindControl("lblSalaryId");

                    _HRM_Pay_Salary.PaySalary_ID = Convert.ToInt32(lblSalaryId.Text);

                    if (rowheldupCheckBox.Checked == true)
                    {
                        _HRM_Pay_Salary.IsSalaryHeldup = true;
                        _HRM_Pay_Salary.Pay_Status = false;
                    }
                    else
                    {
                        _HRM_Pay_Salary.IsSalaryHeldup = false;
                        _HRM_Pay_Salary.Pay_Status = true;
                    }
                    _HRM_Pay_Salary.OCode = ((SessionUser)Session["SessionUser"]).OCode;
                    _HRM_Pay_Salary.Edit_User = ((SessionUser)Session["SessionUser"]).UserId;
                    _HRM_Pay_Salary.Edit_Date = DateTime.Now;

                    lstHRM_Pay_Salary.Add(_HRM_Pay_Salary);
                    //}
                }

                int result = aSalary_Proccess_BLL.UpdateHeldupSalary(lstHRM_Pay_Salary);

                if (result == 1)
                {
                    //    // create voucher to temp table

                    //    string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                    //    string Edit_User = ((SessionUser)Session["SessionUser"]).UserId.ToString();
                    //    string Company_Code = "CMP201507251";
                    //    string ModuleName = "Payroll";
                    //    string ModuleType = "Salary";
                    //    string VoucherType = "JOURNAL";

                    //    var row1 = aSalary_Proccess_BLL.GetTotalNetPayableByDate(Convert.ToDateTime(txtFromDate.Text)).ToList();
                    //    var row2 = aSalary_Proccess_BLL.GetTotalHeldUpByDate(Convert.ToDateTime(txtFromDate.Text)).ToList();
                    //    var row3 = aSalary_Proccess_BLL.GetTotalPayableByDate(Convert.ToDateTime(txtFromDate.Text)).ToList();
                    //    var row4 = aSalary_Proccess_BLL.GetTotalTDSByDate(Convert.ToDateTime(txtFromDate.Text)).ToList();
                    //    var row5 = aSalary_Proccess_BLL.GetTotalAdvanceByDate(Convert.ToDateTime(txtFromDate.Text)).ToList();
                    //    var row6 = aSalary_Proccess_BLL.GetTotalStampByDate(Convert.ToDateTime(txtFromDate.Text)).ToList();

                    //    if (row3.Count > 0)
                    //    {
                    //        var TotalPayable = row3.First();
                    //        var netPayable = row1.First();
                    //        var TDSPayable = row4.First();
                    //        var HeldPayable = (row2.Count > 0 ? row2.First() : null);
                    //        var AdvancePayable = row5.First();
                    //        var StampPayable = row6.First();
                    //        aSalary_Proccess_BLL.Enter_VoucherDetailsForTotalSalary(OCODE, Company_Code, Edit_User, ModuleName, ModuleType, VoucherType, Convert.ToDecimal(TotalPayable.Net_Payable), Convert.ToDecimal(netPayable.Net_Payable)
                    //            , (HeldPayable == null ? 0 : Convert.ToDecimal(HeldPayable.Net_Payable))
                    //            , Convert.ToDecimal(TDSPayable.TotalTax), Convert.ToDecimal(AdvancePayable.AdvanceDeduction), Convert.ToDecimal(StampPayable.Stamp), "n/a");
                    //}

                    /////

                    GridViewSalaryList.DataSource = null;
                    GridViewSalaryList.DataBind();
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Data Processed Successfully')", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Data Processing Faliure!')", true);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

        void GetSalaryByDate()
        {
            try
            {
                string OCODE = ((SessionUser)Session["SessionUser"]).OCode;

                List<Salary_Viewer> empSalary = new List<Salary_Viewer>();

                empSalary = aSalary_Proccess_BLL.Get_PendingSalaryByDate(Convert.ToDateTime(txtFromDate.Text)).ToList();
                if (empSalary.Count > 0)
                {
                    GridViewSalaryList.DataSource = empSalary.ToList();
                    GridViewSalaryList.DataBind();
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
            GetSalaryByDate();
        }

        protected void bthHeldup_Click(object sender, EventArgs e)
        {
            try
            {
                if (GridViewSalaryList.Rows.Count == 0)
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No generated salary in the list!')", true);
                    return;
                }

                List<HRM_Pay_Salary> lstHRM_Pay_Salary = new List<HRM_Pay_Salary>();

                foreach (GridViewRow gvRow in GridViewSalaryList.Rows)
                {
                    //CheckBox rowChkBox = ((CheckBox)gvRow.FindControl("rowLevelCheckBox"));

                    HRM_Pay_Salary _HRM_Pay_Salary = new HRM_Pay_Salary();

                    //if (rowChkBox.Checked == true)
                    //{
                    CheckBox rowheldupCheckBox = ((CheckBox)gvRow.FindControl("rowheldupCheckBox"));
                    Label lblSalaryId = (Label)gvRow.FindControl("lblSalaryId");

                    _HRM_Pay_Salary.PaySalary_ID = Convert.ToInt16(lblSalaryId.Text);

                    if (rowheldupCheckBox.Checked == true)
                    {
                        _HRM_Pay_Salary.IsSalaryHeldup = true;
                    }
                    else
                    {
                        _HRM_Pay_Salary.IsSalaryHeldup = false;
                    }

                    _HRM_Pay_Salary.Pay_Status = false;
                    _HRM_Pay_Salary.OCode = ((SessionUser)Session["SessionUser"]).OCode;
                    _HRM_Pay_Salary.Edit_User = ((SessionUser)Session["SessionUser"]).UserId;
                    _HRM_Pay_Salary.Edit_Date = DateTime.Now;

                    lstHRM_Pay_Salary.Add(_HRM_Pay_Salary);
                    //}
                }

                int result = aSalary_Proccess_BLL.UpdateHeldupSalary(lstHRM_Pay_Salary);

                if (result == 1)
                {
                    //GridViewSalaryList.DataSource = null;
                    //GridViewSalaryList.DataBind();
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Data Processed Successfully')", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Data Processing Faliure!')", true);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }
    }
}
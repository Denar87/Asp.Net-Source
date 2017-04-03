using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ERPSSL.HRM.BLL;
using ERPSSL.HRM.DAL;

namespace ERPSSL.HRM
{
    public partial class Increment : System.Web.UI.Page
    {
        Increment_BLL objIncrementBll = new Increment_BLL();
        //string eid;
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Session["UserID"] != null) && (Session["OCode"] != null))
            {
                if (!IsPostBack)
                {
                    LoadIncrementDetails();
                    FillRegion();
                    btnSave.Visible = false;
                    btnConformation.Visible = false;
                }
            }
            else
            {
                Response.Redirect("..\\AppGateway\\Login.aspx");
            }
        }

        private void FillRegion()
        {

            string OCODE = Convert.ToString(((SessionUser)Session["SessionUser"]).OCode);
            var row = objIncrementBll.GetAllRegion(OCODE).ToList();
            if (row.Count > 0)
            {
                ddlRegion.DataSource = row.ToList();
                ddlRegion.DataTextField = "RegionName";
                ddlRegion.DataValueField = "RegionID";
                ddlRegion.DataBind();
                ddlRegion.Items.Insert(0, new ListItem("--Select--"));
            }
        }

        protected void ddlRegion_SelectedIndexChanged(object sender, EventArgs e)
        {
            int RegionId = Convert.ToInt32(ddlRegion.SelectedValue);
            FillOffice(RegionId);
        }

        private void FillOffice(int RegionId)
        {
            try
            {
                divGradeViewEmployee.Visible = true;
                divGridviewTemployeeData.Visible = false;
                var row = objIncrementBll.GetOfficeByResionId(RegionId).ToList();
                if (row.Count > 0)
                {
                    ddlOffice.DataSource = row.ToList();
                    ddlOffice.DataTextField = "OfficeName";
                    ddlOffice.DataValueField = "OfficeID";
                    ddlOffice.DataBind();
                    ddlOffice.Items.Insert(0, new ListItem("--Select--"));
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

        protected void ddlOffice_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadEmpGrid();
            LoadDepartment();
            btnSave.Visible = true;
            btnConformation.Visible = true;
        }

        private void LoadDepartment()
        {
            try
            {
                int officeID = Convert.ToInt16(ddlOffice.SelectedValue);
                var row = objIncrementBll.GetDepartmentByOfficeId(officeID).ToList();
                if (row.Count > 0)
                {
                    drpDepartment.DataSource = row.ToList();
                    drpDepartment.DataTextField = "DPT_NAME";
                    drpDepartment.DataValueField = "DPT_ID";
                    drpDepartment.DataBind();
                    drpDepartment.Items.Insert(0, new ListItem("--Select--"));
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

        private void LoadEmpGrid()
        {
            try
            {
                //string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                int officeId = Convert.ToInt32(ddlOffice.SelectedValue);
                //List<REmployee> employees = new List<REmployee>();
                var employees = objIncrementBll.GetEmployees(officeId).ToList();
                if (employees.Count > 0)
                {
                    grdemployees.DataSource = employees;
                    grdemployees.DataBind();
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

        protected void headerLevelCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox headerChkBox = ((CheckBox)grdemployees.HeaderRow.FindControl("headerLevelCheckBox"));

            if (headerChkBox.Checked == true)
            {
                foreach (GridViewRow gvRow in grdemployees.Rows)
                {
                    CheckBox rowChkBox = ((CheckBox)gvRow.FindControl("rowLevelCheckBox"));

                    rowChkBox.Checked = true;//((CheckBox)sender).Checked;//for all row checkbox       
                }
            }
            else
            {
                foreach (GridViewRow gvRow in grdemployees.Rows)
                {
                    CheckBox rowChkBox = ((CheckBox)gvRow.FindControl("rowLevelCheckBox"));
                    rowChkBox.Checked = false;
                }
            }

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {

            try
            {
                if (txtGross.Text == "" && txtbxGrossAmount.Text == "")
                {
                    //lblStatus.Text = "Input Gross % or Gross Amount";
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Input Gross % or Gross Amount')", true);
                }
                else
                {

                    decimal updatedSalary;
                    decimal grossPercent;
                    List<HRM_TemporySalaryIncrement> EMP_LIST = new List<HRM_TemporySalaryIncrement>();

                    //CheckBox headerChkBox = ((CheckBox)grdemployees.HeaderRow.FindControl("headerLevelCheckBox"));
                    //if (headerChkBox.Checked == true)
                    //{
                    //    foreach (GridViewRow gvRow in grdemployees.Rows)
                    //    {
                    //        HRM_TemporySalaryIncrement objEmp = new HRM_TemporySalaryIncrement();

                    //        CheckBox rowChkBox = ((CheckBox)gvRow.FindControl("rowLevelCheckBox"));


                    //        Label lblEID = ((Label)gvRow.FindControl("lblEID"));
                    //        //eid = lblEID.Text;                        

                    //        Label currentSalary = ((Label)gvRow.FindControl("lblSalary"));

                    //            if (txtGross.Text != "")
                    //            {
                    //                grossPercent = Convert.ToDecimal(txtGross.Text);
                    //                decimal calculateSalary = (Convert.ToDecimal(currentSalary.Text) * grossPercent) / 100;
                    //                grossPercent = calculateSalary;
                    //                updatedSalary = grossPercent + Convert.ToDecimal(currentSalary.Text);

                    //            }
                    //            else
                    //            {
                    //                grossPercent = Convert.ToDecimal(txtbxGrossAmount.Text);
                    //                updatedSalary = grossPercent + Convert.ToDecimal(currentSalary.Text);
                    //            }


                    //        objEmp.EID = lblEID.Text;
                    //        objEmp.CurrentSalary = updatedSalary;
                    //        objEmp.IncrementDate = DateTime.Now;
                    //        objEmp.IncrementRate = Convert.ToDecimal(grossPercent);
                    //        objEmp.OldSalary = Convert.ToDecimal(currentSalary.Text);
                    //        objEmp.UpdateBy = Convert.ToString(((SessionUser)Session["SessionUser"]).EID);
                    //        objEmp.EDIT_USER = ((SessionUser)Session["SessionUser"]).UserId;
                    //        objEmp.EDIT_DATE = DateTime.Now;
                    //        objEmp.OCODE = ((SessionUser)Session["SessionUser"]).OCode;

                    //        EMP_LIST.Add(objEmp);
                    //        rowChkBox.Checked = true;//((CheckBox)sender).Checked;       
                    //    }
                    //}

                    //else
                    //{
                    foreach (GridViewRow gvRow in grdemployees.Rows)
                    {
                        CheckBox rowChkBox = ((CheckBox)gvRow.FindControl("rowLevelCheckBox"));

                        if (rowChkBox.Checked == true)
                        {
                            HRM_TemporySalaryIncrement objEmp = new HRM_TemporySalaryIncrement();
                            Label lblEID = ((Label)gvRow.FindControl("lblEID"));
                            //eid = lblEID.Text; 
                            Label currentSalary = ((Label)gvRow.FindControl("lblSalary"));
                            if (txtGross.Text != "")
                            {
                                grossPercent = Convert.ToDecimal(txtGross.Text);
                                decimal calculateSalary = (Convert.ToDecimal(currentSalary.Text) * grossPercent) / 100;
                                grossPercent = calculateSalary;
                                updatedSalary = grossPercent + Convert.ToDecimal(currentSalary.Text);
                            }
                            else
                            {
                                grossPercent = Convert.ToDecimal(txtbxGrossAmount.Text);
                                updatedSalary = grossPercent + Convert.ToDecimal(currentSalary.Text);
                            }

                            objEmp.EID = lblEID.Text;
                            objEmp.CurrentSalary = updatedSalary;
                            objEmp.IncrementDate = DateTime.Now;
                            objEmp.IncrementRate = Convert.ToDecimal(grossPercent);
                            objEmp.OldSalary = Convert.ToDecimal(currentSalary.Text);
                            objEmp.UpdateBy = Convert.ToString(((SessionUser)Session["SessionUser"]).EID);
                            objEmp.EDIT_USER = ((SessionUser)Session["SessionUser"]).UserId;
                            objEmp.EDIT_DATE = DateTime.Now;
                            objEmp.OCODE = ((SessionUser)Session["SessionUser"]).OCode;

                            EMP_LIST.Add(objEmp);
                        }
                    }



                    int result = objIncrementBll.SaveIncremntTemp(EMP_LIST);
                    if (result == 1)
                    {
                        //lblStatus.Text = "Data Update Successfully.";
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Data Update Successfully')", true);
                        //LoadEmpGrid();
                        LoadIncrementDetails();
                    }
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }

        }

        private void LoadIncrementDetails()
        {
            try
            {
                divGradeViewEmployee.Visible = false;
                divGridviewTemployeeData.Visible = true;
                var employees = objIncrementBll.GetEmployeesInfoFromTemporyEmoloyeeTable().ToList();
                if (employees.Count > 0)
                {
                    gridviewTemployeData.DataSource = employees;
                    gridviewTemployeData.DataBind();
                    //btnConformationId.Visible = true;
                }
                else
                {
                    gridviewTemployeData.DataSource = null;
                    gridviewTemployeData.DataBind();
                    //btnConformationId.Visible = true;
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }
        protected void drpDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int DepartmentId = Convert.ToInt32(drpDepartment.SelectedValue);
                var employees = objIncrementBll.GetEmployeesByDepartmentId(DepartmentId).ToList();
                if (employees.Count > 0)
                {
                    grdemployees.DataSource = employees;
                    grdemployees.DataBind();
                }

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

        protected void imgDeletePagePermission_Click(object sender, EventArgs e)
        {
            List<HRM_DESIGNATIONS> designations = new List<HRM_DESIGNATIONS>();
            ImageButton imgbtn = (ImageButton)sender;
            GridViewRow row = (GridViewRow)imgbtn.NamingContainer;

            try
            {
                string eid = "";
                Label lblEId = (Label)gridviewTemployeData.Rows[row.RowIndex].FindControl("lblEID");
                if (lblEId != null)
                {
                    string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                    eid = lblEId.Text;

                    int result = objIncrementBll.DeleteSlaryIncrementTemporyInfoByEmployeId(eid, OCODE);
                    if (result == 1)
                    {
                        //lblStatus.Text = "Data Delete Successfully.";
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Data Delete Successfully.')", true);
                        //LoadEmpGrid();
                        LoadIncrementDetails();
                    }
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

        protected void btnConformation_Click(object sender, EventArgs e)
        {
            try
            {
                List<HRM_SalaryIncrement> EMP_LIST = new List<HRM_SalaryIncrement>();

                foreach (GridViewRow gvRow in gridviewTemployeData.Rows)
                {
                    HRM_SalaryIncrement objEmp = new HRM_SalaryIncrement();
                    Label lblEID = ((Label)gvRow.FindControl("lblEID"));
                    //eid = lblEID.Text;                        

                    Label oldSalary = ((Label)gvRow.FindControl("lblOldSalary"));
                    Label currentSalary = ((Label)gvRow.FindControl("CurrentSalary"));
                    Label IncrementAmount = ((Label)gvRow.FindControl("IncrementAmount"));


                    objEmp.EID = lblEID.Text;
                    // objEmp.CurrentSalary = Convert.ToDecimal(currentSalary.Text);
                    objEmp.IncrementDate = DateTime.Now;
                    // objEmp.IncrementRate = Convert.ToDecimal(IncrementAmount.Text);
                    //  objEmp.OldSalary = Convert.ToDecimal(oldSalary.Text);
                    //  objEmp.UpdateBy = Convert.ToString(((SessionUser)Session["SessionUser"]).EID);
                    objEmp.EDIT_USER = ((SessionUser)Session["SessionUser"]).UserId;
                    objEmp.EDIT_DATE = DateTime.Now;
                    objEmp.OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                    EMP_LIST.Add(objEmp);

                }

                int result = 0;//objIncrementBll.SaveSalaryEmployeeInfoinHRM_SalaryIncrement(EMP_LIST);
                if (result == 1)
                {
                    int result1 = objIncrementBll.DeleteTemporyTableInfo(EMP_LIST);

                    //lblStatus.Text = "Data Save Successfully.";
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Data Save Successfully')", true);
                    //LoadEmpGrid();
                    LoadIncrementDetails();
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

        protected void imgbtnEdit_Click(object sender, EventArgs e)
        {
            ImageButton imgbtn = (ImageButton)sender;
            GridViewRow row = (GridViewRow)imgbtn.NamingContainer;

            try
            {
                Label lblEID = ((Label)gridviewTemployeData.Rows[row.RowIndex].FindControl("lblEID"));
                Label oldSalary = ((Label)gridviewTemployeData.Rows[row.RowIndex].FindControl("lblOldSalary"));
                TextBox txtbxIncrementAmount = (TextBox)gridviewTemployeData.Rows[row.RowIndex].FindControl("txtbxIncrementAmount");

                HRM_SalaryIncrement objEmp = new HRM_SalaryIncrement();
                if (txtbxIncrementAmount != null)
                {
                    decimal incrementAmount = Convert.ToDecimal(txtbxIncrementAmount.Text);
                    decimal olSalary = Convert.ToDecimal(oldSalary.Text);
                    decimal CurrentSalary = incrementAmount + olSalary;

                    objEmp.EID = lblEID.Text;
                    //objEmp.CurrentSalary = CurrentSalary;
                    objEmp.IncrementDate = DateTime.Now;
                    //  objEmp.IncrementRate = incrementAmount;
                    //  objEmp.OldSalary = olSalary;
                    //  objEmp.UpdateBy = Convert.ToString(((SessionUser)Session["SessionUser"]).EID);
                    objEmp.EDIT_USER = ((SessionUser)Session["SessionUser"]).UserId;
                    objEmp.EDIT_DATE = DateTime.Now;
                    objEmp.OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                    int result = objIncrementBll.UpdateIncrementSalary(objEmp);

                    if (result == 1)
                    {
                        //lblStatus.Text = "Data Update Successfully.";
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Data Update Successfully')", true);
                        objIncrementBll.DeleteSlaryIncrementTemporyInfoByEmployeId(objEmp.EID, objEmp.OCODE);
                        //LoadEmpGrid();
                        LoadIncrementDetails();
                    }
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

        protected void grdemployees_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdemployees.PageIndex = e.NewPageIndex;
            LoadEmpGrid();
        }

        protected void gridviewTemployeData_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridviewTemployeData.PageIndex = e.NewPageIndex;
            LoadIncrementDetails();
        }

    }
}
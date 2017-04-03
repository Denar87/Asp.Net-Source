using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ERPSSL.HRM.BLL;
using ERPSSL.HRM.DAL.Repository;
using ERPSSL.HRM;
using ERPSSL.HRM.DAL;

namespace ERPSSL.HRM
{
    public partial class EmployeeExtraBill_Entry : System.Web.UI.Page
    {
        EmployeeSetup_BLL objEmp_BLL = new EmployeeSetup_BLL();
        DEPARTMENT_BLL DepartmentBll = new DEPARTMENT_BLL();
        EmployeeSetup_BLL employeeBll = new EmployeeSetup_BLL();
        Office_BLL objOfficeBLL = new Office_BLL();
        EMPOYEE_BLL employeeBllObj = new EMPOYEE_BLL();
        SECTION_BLL SectionBll = new SECTION_BLL();
        SUB_SECTION_BLL subSectionBll = new SUB_SECTION_BLL();
        SUB_SECTION_DAL subSectionDal = new SUB_SECTION_DAL();
        Attendance_RPT_Bll aAttendance_RPT_Bll = new Attendance_RPT_Bll();
        TIME_SCHEDULE_BLL timeScheduleBll = new TIME_SCHEDULE_BLL();
        EmployeeBenefitBLL employeeBenefitbll = new EmployeeBenefitBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Session["UserID"] != null) && (Session["OCode"] != null))
            {
                if (!IsPostBack)
                {
                    GetBeneFitType();
                    GerRegion1List();
                }
            }
            else
            {
                Response.Redirect("..\\AppGateway\\Login.aspx");
            }
        }

        private void GetBeneFitType()
        {
            try
            {
                string OCODE = Convert.ToString(((SessionUser)Session["SessionUser"]).OCode);
                var row = employeeBenefitbll.GetBeneFitType(OCODE).ToList();
                if (row.Count > 0)
                {
                    drpBenefitType.DataSource = row.ToList();
                    drpBenefitType.DataTextField = "Benefittype";
                    drpBenefitType.DataValueField = "BenefittypeId";
                    drpBenefitType.DataBind();
                    drpBenefitType.Items.Insert(0, new ListItem("--Select--", "0"));
                }
            }
            catch (Exception)
            {
                throw;
            }

        }
        private void GerRegion1List()
        {
            try
            {
                string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                var row = objOfficeBLL.GetAllResion(OCODE).ToList();
                if (row.Count > 0)
                {
                    ddlRegion1.DataSource = row.ToList();
                    ddlRegion1.DataTextField = "RegionName";
                    ddlRegion1.DataValueField = "RegionID";
                    ddlRegion1.DataBind();
                    ddlRegion1.Items.Insert(0, new ListItem("--Select--"));
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        protected void drpdwnResion1ForDepartmentSelecttedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int ResionId = Convert.ToInt32(ddlRegion1.SelectedValue);
                BridOfficeByResion1(ResionId);
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

        private void BridOfficeByResion1(int ResionId)
        {
            try
            {
                var row = objOfficeBLL.GetOfficeByResionId(ResionId).ToList();
                if (row.Count > 0)
                {
                    ddlOffice1.DataSource = row.ToList();
                    ddlOffice1.DataTextField = "OfficeName";
                    ddlOffice1.DataValueField = "OfficeID";
                    ddlOffice1.DataBind();
                    ddlOffice1.Items.Insert(0, new ListItem("--Select--"));
                }
                else
                {
                    ddlOffice1.DataSource = null;
                    ddlOffice1.DataTextField = "OfficeName";
                    ddlOffice1.DataValueField = "OfficeID";
                    ddlOffice1.DataBind();
                    ddlOffice1.Items.Insert(0, new ListItem("--Select--"));
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

        protected void onSelectedIndedexChangeOffice1(object sender, EventArgs e)
        {
            try
            {
                string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                int ResionId = Convert.ToInt32(ddlRegion1.SelectedValue);
                int OfficeId = Convert.ToInt32(ddlOffice1.SelectedValue);

                var row = objOfficeBLL.GetDeptByOfficeId(ResionId, OfficeId, OCODE).ToList();
                if (row.Count > 0)
                {
                    ddlDept1.DataSource = row.ToList();
                    ddlDept1.DataTextField = "DPT_NAME";
                    ddlDept1.DataValueField = "DPT_ID";
                    ddlDept1.DataBind();
                    ddlDept1.Items.Insert(0, new ListItem("--Select--"));
                }
                else
                {
                    ddlDept1.DataSource = null;
                    ddlDept1.DataTextField = "DPT_NAME";
                    ddlDept1.DataValueField = "DPT_ID";
                    ddlDept1.DataBind();
                    ddlDept1.Items.Insert(0, new ListItem("--Select--"));
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

        protected void drpdwnDepartment1SelectedIndexChange(object sender, EventArgs e)
        {
            try
            {
                string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                int departmentId = Convert.ToInt16(ddlDept1.SelectedValue);
                var row = SectionBll.GetSectionsByDepartmentIdAndOCode(departmentId, OCODE).ToList();
                if (row.Count > 0)
                {
                    ddlSection.DataSource = row;
                    ddlSection.DataTextField = "SEC_NAME";
                    ddlSection.DataValueField = "SEC_ID";
                    ddlSection.DataBind();
                    ddlSection.Items.Insert(0, new ListItem("--Select--", "0"));
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

        protected void ddlSection_SelecttedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                int sectionId = Convert.ToInt16(ddlSection.SelectedValue);
                var row = subSectionBll.GetSubSectionsBySectionIdAndOCode(sectionId, OCODE).ToList();
                if (row.Count > 0)
                {
                    ddlSubSections.DataSource = row;
                    ddlSubSections.DataTextField = "SUB_SEC_NAME";
                    ddlSubSections.DataValueField = "SUB_SEC_ID";
                    ddlSubSections.DataBind();
                    ddlSubSections.Items.Insert(0, new ListItem("--Select--", "0"));
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

        protected void headerLevelCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                CheckBox headerChkBox = ((CheckBox)grdview.HeaderRow.FindControl("headerLevelCheckBox"));

                if (headerChkBox.Checked == true)
                {
                    foreach (GridViewRow gvRow in grdview.Rows)
                    {
                        CheckBox rowChkBox = ((CheckBox)gvRow.FindControl("rowLevelCheckBox"));
                        rowChkBox.Checked = true;//((CheckBox)sender).Checked;//for all row checkbox       
                    }
                }
                else
                {
                    foreach (GridViewRow gvRow in grdview.Rows)
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

        protected void btnProcess_Click(object sender, EventArgs e)
        {
            try
            {
                if (ddlRegion1.SelectedItem.ToString() == "--Select--")
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Please Select Region')", true);
                }
                else if (txtDate.Text == "")
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Please Input Date')", true);
                }
                else if (drpBenefitType.SelectedItem.ToString() == "--Select--")
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Please Select Benefit Type')", true);
                }
                else
                {
                    try
                    {
                        Attendance_BLL _attendancebll = new Attendance_BLL();
                        if (ddlSubSections.SelectedValue.ToString() == "" || ddlSubSections.SelectedValue.ToString() == "0" || ddlSection.SelectedValue.ToString() == "" || ddlSection.SelectedValue.ToString() == "0")
                        {
                            int DeptId = Convert.ToInt32(ddlDept1.SelectedValue);

                            List<HRM_EMPLOYEES_VIEWER> employess = _attendancebll.GetEmployeeByOfficeID(DeptId, Convert.ToDateTime(txtDate.Text));
                            List<HRM_EMPLOYEES_VIEWER> newemployess = new List<HRM_EMPLOYEES_VIEWER>();

                            foreach (HRM_EMPLOYEES_VIEWER aitem in employess)
                            {
                                HRM_EMPLOYEES_VIEWER aemployee = new HRM_EMPLOYEES_VIEWER();
                                aemployee.EID = aitem.EID;

                                aemployee.EmployeeFullName = aitem.FirstName + " " + aitem.LastName;
                                aemployee.DEG_NAME = aitem.DEG_NAME;
                                //aemployee.EMP_ID = Convert.ToInt32(aitem.EID);
                                //aemployee.Is_Holiday = aitem.Is_Holiday;
                                aemployee.DATE_JOINED = Convert.ToDateTime(txtDate.Text);
                                aemployee.BenefitType = drpBenefitType.SelectedItem.Text;
                                aemployee.Amount = Convert.ToDecimal(txtbxAmount.Text);
                                // TimeSpan in_time = TimeSpan.Parse(string.Format("{0}:{1}:{2}", txtAttInTime.Hour, txtAttInTime.Minute, txtAttInTime.Second));
                                //aemployee.Shift_TotalHour = in_time;
                                newemployess.Add(aemployee);
                            }

                            List<HRM_EMPLOYEES_VIEWER> ascendingnewemployees = newemployess.OrderBy(x => x.EID).ToList();

                            if (ascendingnewemployees.Count > 0)
                            {
                                grdview.DataSource = ascendingnewemployees;
                                grdview.DataBind();
                            }
                        }
                        else
                        {
                            int ResionId = Convert.ToInt32(ddlRegion1.SelectedValue);
                            int OfficeId = Convert.ToInt32(ddlOffice1.SelectedValue);
                            int DeptId = Convert.ToInt32(ddlDept1.SelectedValue);
                            int sction = Convert.ToInt32(ddlSection.SelectedValue);
                            int subsction = Convert.ToInt32(ddlSubSections.SelectedValue);

                            List<HRM_EMPLOYEES_VIEWER> employess = _attendancebll.GetEmployeeByRODSSUID(ResionId, OfficeId, DeptId, sction, subsction, Convert.ToDateTime(txtDate.Text));
                            List<HRM_EMPLOYEES_VIEWER> newemployess = new List<HRM_EMPLOYEES_VIEWER>();

                            foreach (HRM_EMPLOYEES_VIEWER aitem in employess)
                            {
                                HRM_EMPLOYEES_VIEWER aemployee = new HRM_EMPLOYEES_VIEWER();
                                aemployee.EID = aitem.EID;
                                //aemployee.EMP_ID = Convert.ToInt32(aitem.EID);
                                aemployee.EmployeeFullName = aitem.FirstName + " " + aitem.LastName;
                                aemployee.DEG_NAME = aitem.DEG_NAME;
                                aemployee.DATE_JOINED = Convert.ToDateTime(txtDate.Text);
                                aemployee.BenefitType = drpBenefitType.SelectedItem.Text;
                                aemployee.Amount = Convert.ToDecimal(txtbxAmount.Text);

                                //aemployee.Is_Holiday = aitem.Is_Holiday;
                                // TimeSpan in_time = TimeSpan.Parse(string.Format("{0}:{1}:{2}", txtAttInTime.Hour, txtAttInTime.Minute, txtAttInTime.Second));
                                //aemployee.Shift_TotalHour = in_time;
                                newemployess.Add(aemployee);
                            }
                            List<HRM_EMPLOYEES_VIEWER> assendingnewemployess = newemployess.OrderBy(x => x.EID).ToList();

                            if (assendingnewemployess.Count > 0)
                            {
                                grdview.DataSource = assendingnewemployess;
                                grdview.DataBind();
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
                    }
                }

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

        protected void btn_Confirm_Clcik(object sender, EventArgs e)
        {
            try
            {
                List<HRM_EmployeeWiseBenefit> attendances = new List<HRM_EmployeeWiseBenefit>();

                foreach (GridViewRow gvRow in grdview.Rows)
                {
                    CheckBox rowChkBox = ((CheckBox)gvRow.FindControl("rowLevelCheckBox"));
                    HRM_EmployeeWiseBenefit aHRM_EmployeeWiseBenefit = new HRM_EmployeeWiseBenefit();

                    if (rowChkBox.Checked == true)
                    {
                        Label lblEID = ((Label)gvRow.FindControl("lblEID"));
                        TextBox txtbx = ((TextBox)gvRow.FindControl("txtbx"));

                        aHRM_EmployeeWiseBenefit.EID = lblEID.Text;
                        aHRM_EmployeeWiseBenefit.BenefitTypeId = Convert.ToInt32(drpBenefitType.SelectedValue);
                        aHRM_EmployeeWiseBenefit.ResionId = Convert.ToInt32(ddlRegion1.SelectedValue);
                        aHRM_EmployeeWiseBenefit.OfficeId = Convert.ToInt32(ddlOffice1.SelectedValue);
                        if (ddlDept1.SelectedItem.Text == "--Select--")
                        {
                            aHRM_EmployeeWiseBenefit.DepartmentId = 0;
                        }
                        else
                        {
                            aHRM_EmployeeWiseBenefit.DepartmentId = Convert.ToInt32(ddlDept1.SelectedValue);
                        }
                        //aHRM_EmployeeWiseBenefit.DepartmentId = Convert.ToInt32(ddlDept1.SelectedValue);

                        aHRM_EmployeeWiseBenefit.EffectiveDate = Convert.ToDateTime(txtDate.Text);
                        aHRM_EmployeeWiseBenefit.Amount = Convert.ToDecimal(txtbx.Text);
                        aHRM_EmployeeWiseBenefit.OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                        aHRM_EmployeeWiseBenefit.EDIT_DATE = DateTime.Now;
                        aHRM_EmployeeWiseBenefit.EDIT_USER = ((SessionUser)Session["SessionUser"]).UserId;

                        DateTime ExistEffictiveDate = Convert.ToDateTime(txtDate.Text);
                        int Benefitid = Convert.ToInt32(drpBenefitType.SelectedValue);

                        attendances = employeeBenefitbll.Get_BenifitAmountByEID_Date(lblEID.Text, Benefitid, ExistEffictiveDate);
                        //HRM_EmployeeWiseBenefit E_ID_EDate = employeeBenefitbll.GetAmountByEID();
                        if (attendances.Count > 0)
                        {
                            string E_ID = lblEID.Text;

                            int result = employeeBenefitbll.UpdateUserWiseBebefits(aHRM_EmployeeWiseBenefit, E_ID, ExistEffictiveDate);
                            if (result == 1)
                            {
                                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Data Updated Successfully')", true);
                                grdview.DataSource = null;
                                grdview.DataBind();
                            }
                        }
                        else
                        {

                            int result = employeeBenefitbll.SaveUserWiseBebefit(aHRM_EmployeeWiseBenefit);
                            if (result == 1)
                            {
                                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Data Save Successfully')", true);
                                grdview.DataSource = null;
                                grdview.DataBind();
                            }
                        }
                    }
                }    
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No Employee selected in the list!')", true);   
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

        private void ClearUI()
        {
            ddlSection.ClearSelection();
            ddlSubSections.ClearSelection();
            txtbxremark.Text = "";
            txtDate.Text = "";
            drpBenefitType.ClearSelection();
            grdview.DataSource = null;
            grdview.DataBind();
        }

        protected void grdview_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (!string.IsNullOrEmpty(e.Row.Cells[6].Text))
            {
                if (e.Row.Cells[6].Text == "Hoilday")
                {
                    e.Row.Cells[6].ForeColor = System.Drawing.Color.Red;
                    e.Row.Cells[6].BackColor = System.Drawing.Color.Wheat;
                }
            }
        }
    }
}

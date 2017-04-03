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
using ERPSSL.AppGateway.DAL;
using ERPSSL.Adminpanel.DAL;

namespace ERPSSL.HRM
{
    public partial class ManualOT : System.Web.UI.Page
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

        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Session["UserID"] != null) && (Session["OCode"] != null))
            {
                if (!IsPostBack)
                {
                    GerRegion1List();
                }
            }
            else
            {
                Response.Redirect("..\\AppGateway\\Login.aspx");
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

        protected void ddlSubSections_SelectedIndexChanged(object sender, EventArgs e)
        {
            //int RegionId = Convert.ToInt32(ddlRegion1.SelectedValue);
            //int OfficeId = Convert.ToInt32(ddlOffice1.SelectedValue);
            //int departmentId = Convert.ToInt32(ddlDept1.SelectedValue);
            //BindShiftCodeByDepartment(RegionId, OfficeId, departmentId);
        }

        protected void btnProcess_Click(object sender, EventArgs e)
        {
            try
            {
                Attendance_BLL _attendancebll = new Attendance_BLL();

                int ResionId = Convert.ToInt32(ddlRegion1.SelectedValue);
                int OfficeId = Convert.ToInt32(ddlOffice1.SelectedValue);
                int DeptId = Convert.ToInt32(ddlDept1.SelectedValue);
                int sction = Convert.ToInt32(ddlSection.SelectedValue);
                int subsction = Convert.ToInt32(ddlSubSections.SelectedValue);
                List<HRM_EMPLOYEES_VIEWER> employess = _attendancebll.GetEmployeeByRODSSUID(ResionId, OfficeId, DeptId, sction, subsction);
                List<HRM_EMPLOYEES_VIEWER> newemployess = new List<HRM_EMPLOYEES_VIEWER>();

                foreach (HRM_EMPLOYEES_VIEWER aitem in employess)
                {
                    HRM_EMPLOYEES_VIEWER aemployee = new HRM_EMPLOYEES_VIEWER();
                    aemployee.EID = aitem.EID;
                    aemployee.EmployeeFullName = aitem.FirstName + " " + aitem.LastName;
                    aemployee.DEG_NAME = aitem.DEG_NAME;
                    aemployee.TOHour = txtbxOtHour.Text.Trim();
                    aemployee.DATE_JOINED = Convert.ToDateTime(txtDate.Text);


                    newemployess.Add(aemployee);
                }

                if (newemployess.Count > 0)
                {
                    grdview.DataSource = newemployess;
                    grdview.DataBind();
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
                UserDAL userDAl = new UserDAL();
                Attendance_BLL _attendancebll = new Attendance_BLL();
                List<HRM_ATTENDANCE> attendances = new List<HRM_ATTENDANCE>();

                //string[] plussign = txtbxOtHour.Text.Split('+');
                //string[] Minsign = txtbxOtHour.Text.Split('-');

                //string psign = plussign[0].ToString();
                //string misign = Minsign[0].ToString();


                //string plussign = txtbxOtHour.Text.ToString();
                //string[] values = plussign.Split('+');
                //string psign = values[1].ToString();

                //string Minsign = txtbxOtHour.Text.ToString();
                //string[] values1 = Minsign.Split('-');
                //string misign = values1[1].ToString();


                //string sign = txtbxOtHour.Text.ToString();
                string sign = txtbxOtHour.Text.Substring(0, 1);
                if (sign == "+" || sign == "-")
                {

                    //CheckBox headerChkBox = ((CheckBox)grdview.HeaderRow.FindControl("headerLevelCheckBox"));
                    //if (headerChkBox.Checked == true)
                    //{
                    //    foreach (GridViewRow gvRow in grdview.Rows)
                    //    {

                    //        HRM_ATTENDANCE _attendance = new HRM_ATTENDANCE();
                    //        CheckBox rowChkBox = ((CheckBox)gvRow.FindControl("rowLevelCheckBox"));

                    //        Label lblEID = ((Label)gvRow.FindControl("lblEID"));

                    //        TextBox txtbx = ((TextBox)gvRow.FindControl("txtbx"));


                    //        _attendance.EID = lblEID.Text;
                    //        _attendance.Remarks = txtbxremark.Text;
                    //        _attendance.Attendance_Date = Convert.ToDateTime(txtDate.Text);
                    //        attendances.Add(_attendance);
                    //    }
                    //}

                    //else
                    //{
                    foreach (GridViewRow gvRow in grdview.Rows)
                    {
                        CheckBox rowChkBox = ((CheckBox)gvRow.FindControl("rowLevelCheckBox"));

                        HRM_ATTENDANCE _attendance = new HRM_ATTENDANCE();

                        if (rowChkBox.Checked == true)
                        {

                            Label lblEID = ((Label)gvRow.FindControl("lblEID"));
                            TextBox txtbx = ((TextBox)gvRow.FindControl("txtbx"));


                            _attendance.EID = lblEID.Text;
                            _attendance.Attendance_Date = Convert.ToDateTime(txtDate.Text);
                            _attendance.Remarks = txtbxremark.Text;
                            attendances.Add(_attendance);
                        }
                    }

                    //}
                    string OThour = Convert.ToString(txtbxOtHour.Text.Trim());
                    Guid UserID = ((SessionUser)Session["SessionUser"]).UserId;
                    string apprvedBy = userDAl.getEIDbyUserGuidID(UserID);
                    int result = _attendancebll.ManualOTUpdate(attendances, apprvedBy, OThour);
                    if (result == 1)
                    {
                        ClearUI();
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Data Update Successfully.')", true);
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Please Use + or - Sign Before Number')", true);
                }


            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

        private void ClearUI()
        {

            ddlRegion1.ClearSelection();
            ddlOffice1.ClearSelection();
            ddlDept1.ClearSelection();
            ddlSection.ClearSelection();
            ddlSubSections.ClearSelection();
            txtbxremark.Text = "";
            txtDate.Text = "";
            txtbxOtHour.Text = "";
            grdview.DataSource = null;
            grdview.DataBind();

        }
    }
}

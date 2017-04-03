using ERPSSL.HRM.BLL;
using ERPSSL.HRM.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ERPSSL.HRM
{
    public partial class ApplicableConfig : System.Web.UI.Page
    {
        ApplicableBLL _applicablebll = new ApplicableBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtbxSalarySearch.Visible = false;
                txtbxSalryFrom.Visible = false;
                GerRegion1List();
            }
        }

        private void GerRegion1List()
        {
            try
            {
                Office_BLL objOfficeBLL = new Office_BLL();
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
            
            Office_BLL objOfficeBLL = new Office_BLL();
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

        protected void onSelectedIndedexChangeOffice1(object sender, EventArgs e)
        {
            Office_BLL objOfficeBLL = new Office_BLL();
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

        protected void drpdwnDepartment1SelectedIndexChange(object sender, EventArgs e)
        {
            try
            {
                SECTION_BLL SectionBll = new SECTION_BLL();
                Attendance_BLL _attendancebll = new Attendance_BLL();
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
                SUB_SECTION_BLL subSectionBll = new SUB_SECTION_BLL();
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

        protected void btnProcess_Click(object sender, EventArgs e)
        {
            try
            {
                Attendance_BLL _attendancebll = new Attendance_BLL();

                if (chSalaryCheck.Checked)
                {
                    if (txtbxEid.Text != "")
                    {
                        if (txtbxSalarySearch.Text == null || txtbxSalarySearch.Text == "")
                        {
                            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Please Input From Salary!')", true);
                        }
                        else if (txtbxSalryFrom.Text == null || txtbxSalryFrom.Text == "")
                        {
                            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Please Input To Salary!')", true);
                        }
                        else
                        {
                            Decimal Salary = Convert.ToDecimal(txtbxSalarySearch.Text);
                            Decimal ToSalary = Convert.ToDecimal(txtbxSalryFrom.Text);

                            string eid = Convert.ToString(txtbxEid.Text);

                            List<HRM_EMPLOYEES_VIEWER> employess = _attendancebll.GetEmployeeByIDWithSalary(eid, Salary, ToSalary);
                            if (employess.Count > 0)
                            {
                                grdview.DataSource = employess; 
                                grdview.DataBind();
                            }
                            else
                            {
                                grdview.DataSource = null;
                                grdview.DataBind();
                            }
                        }
                    }
                    else
                    {
                        if (ddlRegion1.SelectedValue == "--Select--")
                        {
                            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Please Seletct Region!')", true);

                        }
                        else if (ddlOffice1.SelectedValue == "--Select--")
                        {
                            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Please Seletct Office!')", true);
                        }
                        else if (ddlDept1.SelectedValue == "--Select--")
                        {
                            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Please Seletct Department!')", true);
                        }
                        else
                        {
                            if (txtbxSalarySearch.Text == null || txtbxSalarySearch.Text == "")
                            {
                                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Please Input Salary!')", true);
                            }
                            else if (txtbxSalryFrom.Text == null || txtbxSalryFrom.Text == "")
                            {
                                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Please Input To Salary!')", true);
                            }
                            else
                            {
                                Decimal ToSalary = Convert.ToDecimal(txtbxSalryFrom.Text);
                                Decimal Salary = Convert.ToDecimal(txtbxSalarySearch.Text);
                                if (ddlSubSections.SelectedValue.ToString() == "" || ddlSubSections.SelectedValue.ToString() == "0" || ddlSection.SelectedValue.ToString() == "" || ddlSection.SelectedValue.ToString() == "0")
                                {
                                    int DeptId = Convert.ToInt32(ddlDept1.SelectedValue);
                                    List<HRM_EMPLOYEES_VIEWER> employess = _attendancebll.GetEmployeeByOfficeIDWithSalary(DeptId, Salary, ToSalary);
                                    if (employess.Count > 0)
                                    {
                                        grdview.DataSource = employess;
                                        grdview.DataBind();
                                    }
                                    else
                                    {
                                        grdview.DataSource = null;
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
                                    List<HRM_EMPLOYEES_VIEWER> employess = _attendancebll.GetEmployeeByRODSSUIDWithSalry(ResionId, OfficeId, DeptId, sction, subsction, Salary, ToSalary);
                                    if (employess.Count > 0)
                                    {
                                        grdview.DataSource = employess;
                                        grdview.DataBind();
                                    }
                                    else
                                    {
                                        grdview.DataSource = null;
                                        grdview.DataBind();
                                    }
                                }
                            }
                        }
                    }
                }
                else
                {
                    if (txtbxEid.Text != "")
                    {
                        string eid = Convert.ToString(txtbxEid.Text);
                        List<HRM_EMPLOYEES_VIEWER> employess = _attendancebll.GetEmployeeByID(eid);
                        if (employess.Count > 0)
                        {
                            grdview.DataSource = employess;
                            grdview.DataBind();
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No data found')", true);
                        }
                    }
                    else
                    {
                        if (ddlRegion1.SelectedValue == "--Select--")
                        {
                            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Please Seletct Region!')", true);
                        }
                        else if (ddlOffice1.SelectedValue == "--Select--")
                        {
                            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Please Seletct Office!')", true);
                        }
                        else if (ddlDept1.SelectedValue == "--Select--")
                        {
                            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Please Seletct Department!')", true);
                        }
                        else
                        {
                            if (ddlSubSections.SelectedValue.ToString() == "" || ddlSubSections.SelectedValue.ToString() == "0" || ddlSection.SelectedValue.ToString() == "" || ddlSection.SelectedValue.ToString() == "0")
                            {

                                int DeptId = Convert.ToInt32(ddlDept1.SelectedValue);
                                List<HRM_EMPLOYEES_VIEWER> employess = _attendancebll.GetEmployeeByOfficeID(DeptId);
                                if (employess.Count > 0)
                                {
                                    grdview.DataSource = employess;
                                    grdview.DataBind();
                                }
                                else
                                {
                                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No data found')", true);
                                }
                            }
                            else
                            {
                                int ResionId = Convert.ToInt32(ddlRegion1.SelectedValue);
                                int OfficeId = Convert.ToInt32(ddlOffice1.SelectedValue);
                                int DeptId = Convert.ToInt32(ddlDept1.SelectedValue);
                                int sction = Convert.ToInt32(ddlSection.SelectedValue);
                                int subsction = Convert.ToInt32(ddlSubSections.SelectedValue);
                                List<HRM_EMPLOYEES_VIEWER> employess = _attendancebll.GetEmployeeByRODSSUID(ResionId, OfficeId, DeptId, sction, subsction);
                                if (employess.Count > 0)
                                {
                                    grdview.DataSource = employess;
                                    grdview.DataBind();
                                }

                                else 
                                {
                                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No data found')", true);
                                }
                            }
                        }
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
                List<HRM_Applicable_PersonalStatus> _applicable = new List<HRM_Applicable_PersonalStatus>();
                CheckBox headerChkBox = ((CheckBox)grdview.HeaderRow.FindControl("headerLevelCheckBox"));
                if (headerChkBox.Checked == true)
                {
                    foreach (GridViewRow gvRow in grdview.Rows)
                    {
                        HRM_Applicable_PersonalStatus _applicablePersonalStatus = new HRM_Applicable_PersonalStatus();

                        Label lbleid = ((Label)gvRow.FindControl("lblEID"));
                        CheckBox rowAttendanceBouns = ((CheckBox)gvRow.FindControl("roqAttendanceBouns"));
                        CheckBox rowLateApplicable = ((CheckBox)gvRow.FindControl("rowAlateApplicable"));
                        CheckBox rowAbsenceApplicable = ((CheckBox)gvRow.FindControl("rowAbsenceApplic"));
                        CheckBox rowTaxApplic = ((CheckBox)gvRow.FindControl("rowTaxApplic"));
                        CheckBox rowPfApplic = ((CheckBox)gvRow.FindControl("rowPfApplic"));
                        CheckBox rowAmount = ((CheckBox)gvRow.FindControl("rowonAmount"));
                        CheckBox rowOtApplicable = ((CheckBox)gvRow.FindControl("roqOTApplicable"));

                        _applicablePersonalStatus.EID = lbleid.Text;
                        _applicablePersonalStatus.Attendance_Bouns = rowAttendanceBouns.Checked;
                        _applicablePersonalStatus.Late_Applicable = rowLateApplicable.Checked;
                        _applicablePersonalStatus.Absence_Applicable = rowAbsenceApplicable.Checked;
                        _applicablePersonalStatus.Tax_Applicable = rowTaxApplic.Checked;
                        _applicablePersonalStatus.PF_Applicable = rowPfApplic.Checked;
                        _applicablePersonalStatus.OT_Applicable = rowOtApplicable.Checked;
                        // _applicablePersonalStatus.On_Amount = rowAmount.Checked;
                        _applicablePersonalStatus.Approved_Attendance_Bouns_Date = DateTime.Now;
                        _applicablePersonalStatus.Approved_Late_Applicable_Date = DateTime.Now;
                        _applicablePersonalStatus.Approved_Absence_Applicable_Date = DateTime.Now;
                        _applicablePersonalStatus.Approved_Tax_Applicable_Date = DateTime.Now;
                        _applicablePersonalStatus.Approved_PF_Applicable_Date = DateTime.Now;
                        _applicablePersonalStatus.Approved_OnAmount_Date = DateTime.Now;
                        _applicablePersonalStatus.EDIT_USER = ((SessionUser)Session["SessionUser"]).UserId;
                        _applicablePersonalStatus.EDIT_DATE = DateTime.Now;
                        _applicablePersonalStatus.OCODE = ((SessionUser)Session["SessionUser"]).OCode;

                        _applicable.Add(_applicablePersonalStatus);
                    }
                    int reslult = _applicablebll.SaveApplicable(_applicable);
                    if (reslult == 1)
                    {
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Data Save Successfully')", true);
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No Employee Selected')", true);
                    }
                }
                else
                {
                    foreach (GridViewRow gvRow in grdview.Rows)
                    {
                        CheckBox rowLeabveCheck = ((CheckBox)gvRow.FindControl("rowLevelCheckBox"));
                        if (rowLeabveCheck.Checked == true)
                        {
                            HRM_Applicable_PersonalStatus _applicablePersonalStatus = new HRM_Applicable_PersonalStatus();

                            Label lbleid = ((Label)gvRow.FindControl("lblEID"));
                            CheckBox rowAttendanceBouns = ((CheckBox)gvRow.FindControl("roqAttendanceBouns"));
                            CheckBox rowLateApplicable = ((CheckBox)gvRow.FindControl("rowAlateApplicable"));
                            CheckBox rowAbsenceApplicable = ((CheckBox)gvRow.FindControl("rowAbsenceApplic"));
                            CheckBox rowTaxApplic = ((CheckBox)gvRow.FindControl("rowTaxApplic"));
                            CheckBox rowPfApplic = ((CheckBox)gvRow.FindControl("rowPfApplic"));
                            CheckBox rowAmount = ((CheckBox)gvRow.FindControl("rowonAmount"));
                            CheckBox rowOtApplicable = ((CheckBox)gvRow.FindControl("roqOTApplicable"));
                            _applicablePersonalStatus.EID = lbleid.Text;
                            _applicablePersonalStatus.Attendance_Bouns = rowAttendanceBouns.Checked;
                            _applicablePersonalStatus.Late_Applicable = rowLateApplicable.Checked;
                            _applicablePersonalStatus.Absence_Applicable = rowAbsenceApplicable.Checked;
                            _applicablePersonalStatus.Tax_Applicable = rowTaxApplic.Checked;
                            _applicablePersonalStatus.PF_Applicable = rowPfApplic.Checked;
                            //  _applicablePersonalStatus.On_Amount = rowAmount.Checked;
                            _applicablePersonalStatus.OT_Applicable = rowOtApplicable.Checked;
                            _applicablePersonalStatus.Approved_Attendance_Bouns_Date = DateTime.Now;
                            _applicablePersonalStatus.Approved_Late_Applicable_Date = DateTime.Now;
                            _applicablePersonalStatus.Approved_Absence_Applicable_Date = DateTime.Now;
                            _applicablePersonalStatus.Approved_Tax_Applicable_Date = DateTime.Now;
                            _applicablePersonalStatus.Approved_PF_Applicable_Date = DateTime.Now;
                            _applicablePersonalStatus.Approved_OnAmount_Date = DateTime.Now;
                            _applicablePersonalStatus.EDIT_USER = ((SessionUser)Session["SessionUser"]).UserId;
                            _applicablePersonalStatus.EDIT_DATE = DateTime.Now;
                            _applicablePersonalStatus.OCODE = ((SessionUser)Session["SessionUser"]).OCode;

                            _applicable.Add(_applicablePersonalStatus);
                        }
                    }
                    int reslult = _applicablebll.SaveApplicable(_applicable);
                    if (reslult == 1)
                    {
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Data Save Successfully')", true);
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No Employee Selected')", true);
                    }
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

        protected void headONAmount_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                CheckBox headerChkBox = ((CheckBox)grdview.HeaderRow.FindControl("headONAmount"));

                if (headerChkBox.Checked == true)
                {
                    foreach (GridViewRow gvRow in grdview.Rows)
                    {
                        CheckBox rowChkBox = ((CheckBox)gvRow.FindControl("rowonAmount"));

                        rowChkBox.Checked = true;//((CheckBox)sender).Checked;//for all row checkbox       
                    }
                }
                else
                {
                    foreach (GridViewRow gvRow in grdview.Rows)
                    {
                        CheckBox rowChkBox = ((CheckBox)gvRow.FindControl("rowonAmount"));
                        rowChkBox.Checked = false;
                    }
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

        protected void headAttendanceBouns_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                CheckBox headerChkBox = ((CheckBox)grdview.HeaderRow.FindControl("headAttendanceBouns"));

                if (headerChkBox.Checked == true)
                {
                    foreach (GridViewRow gvRow in grdview.Rows)
                    {
                        CheckBox rowChkBox = ((CheckBox)gvRow.FindControl("roqAttendanceBouns"));

                        rowChkBox.Checked = true;//((CheckBox)sender).Checked;//for all row checkbox       
                    }
                }
                else
                {
                    foreach (GridViewRow gvRow in grdview.Rows)
                    {
                        CheckBox rowChkBox = ((CheckBox)gvRow.FindControl("roqAttendanceBouns"));
                        rowChkBox.Checked = false;
                    }
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

        protected void headlateApplicable_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                CheckBox headerChkBox = ((CheckBox)grdview.HeaderRow.FindControl("headlateApplicable"));

                if (headerChkBox.Checked == true)
                {
                    foreach (GridViewRow gvRow in grdview.Rows)
                    {
                        CheckBox rowChkBox = ((CheckBox)gvRow.FindControl("rowAlateApplicable"));

                        rowChkBox.Checked = true;//((CheckBox)sender).Checked;//for all row checkbox       
                    }
                }
                else
                {
                    foreach (GridViewRow gvRow in grdview.Rows)
                    {
                        CheckBox rowChkBox = ((CheckBox)gvRow.FindControl("rowAlateApplicable"));
                        rowChkBox.Checked = false;
                    }
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

        protected void headAbsenceApplic_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                CheckBox headerChkBox = ((CheckBox)grdview.HeaderRow.FindControl("headAbsenceApplic"));

                if (headerChkBox.Checked == true)
                {
                    foreach (GridViewRow gvRow in grdview.Rows)
                    {
                        CheckBox rowChkBox = ((CheckBox)gvRow.FindControl("rowAbsenceApplic"));

                        rowChkBox.Checked = true;//((CheckBox)sender).Checked;//for all row checkbox       
                    }
                }
                else
                {
                    foreach (GridViewRow gvRow in grdview.Rows)
                    {
                        CheckBox rowChkBox = ((CheckBox)gvRow.FindControl("rowAbsenceApplic"));
                        rowChkBox.Checked = false;
                    }
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

        protected void headTaxApplic_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                CheckBox headerChkBox = ((CheckBox)grdview.HeaderRow.FindControl("headTaxApplic"));

                if (headerChkBox.Checked == true)
                {
                    foreach (GridViewRow gvRow in grdview.Rows)
                    {
                        CheckBox rowChkBox = ((CheckBox)gvRow.FindControl("rowTaxApplic"));

                        rowChkBox.Checked = true;//((CheckBox)sender).Checked;//for all row checkbox       
                    }
                }
                else
                {
                    foreach (GridViewRow gvRow in grdview.Rows)
                    {
                        CheckBox rowChkBox = ((CheckBox)gvRow.FindControl("rowTaxApplic"));
                        rowChkBox.Checked = false;
                    }
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

        protected void headpfApplic_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                CheckBox headerChkBox = ((CheckBox)grdview.HeaderRow.FindControl("headpfApplic"));

                if (headerChkBox.Checked == true)
                {
                    foreach (GridViewRow gvRow in grdview.Rows)
                    {
                        CheckBox rowChkBox = ((CheckBox)gvRow.FindControl("rowPfApplic"));

                        rowChkBox.Checked = true;//((CheckBox)sender).Checked;//for all row checkbox       
                    }
                }
                else
                {
                    foreach (GridViewRow gvRow in grdview.Rows)
                    {
                        CheckBox rowChkBox = ((CheckBox)gvRow.FindControl("rowPfApplic"));
                        rowChkBox.Checked = false;
                    }
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

        protected void chSalaryCheck_buttonClick(object sender, EventArgs e)
        {
            try
            {
                if (chSalaryCheck.Checked)
                {
                    txtbxSalarySearch.Visible = true;
                    txtbxSalryFrom.Visible = true;
                }
                else
                {
                    txtbxSalryFrom.Visible = false;
                    txtbxSalarySearch.Visible = false;
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }
        protected void headOtApplicable_CheckedChanged(object sender, EventArgs e)
        {
            try
            {

                CheckBox headerChkBox = ((CheckBox)grdview.HeaderRow.FindControl("headOtApplicable"));

                if (headerChkBox.Checked == true)
                {
                    foreach (GridViewRow gvRow in grdview.Rows)
                    {
                        CheckBox rowChkBox = ((CheckBox)gvRow.FindControl("roqOTApplicable"));

                        rowChkBox.Checked = true;//((CheckBox)sender).Checked;//for all row checkbox       
                    }
                }
                else
                {
                    foreach (GridViewRow gvRow in grdview.Rows)
                    {
                        CheckBox rowChkBox = ((CheckBox)gvRow.FindControl("roqOTApplicable"));
                        rowChkBox.Checked = false;
                    }
                }
            }
            catch (Exception ex)
            {

                //string EID = Convert.ToString(((SessionUser)Session["SessionUser"]).EID);
                //LogController<ApplicableConfig>.SetLog(ex, EID);
                //ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }
    }
}
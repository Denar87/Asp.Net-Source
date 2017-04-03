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
    public partial class SalaryIncrement : System.Web.UI.Page
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
            if (!IsPostBack)
            {
                divEid.Visible = false;
                divDesgination.Visible = false;
                divName.Visible = false;
                divIndiDepartment.Visible = false;
                GerRegion1List();
            }
        }
        protected void txtbx_OntectChanged(object sender, EventArgs e)
        {
            try
            {
                TextBox txtbx = (TextBox)sender;
                GridViewRow row = (GridViewRow)txtbx.NamingContainer;
                TextBox txtIncrementAmount = (TextBox)row.FindControl("txtbx");
                Label lblPreviousSalary = (Label)row.FindControl("lblPreviousSalary");
                Label lblIncrement = (Label)row.FindControl("lblIncrementSalary");
                lblIncrement.Text = (Convert.ToDecimal(lblPreviousSalary.Text) + Convert.ToDecimal(txtIncrementAmount.Text)).ToString();
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }
        protected void txtbxEID_TextChangeEvent(object sender, EventArgs e)
        {
            try
            {
                string eid = txtbxEID.Text.Trim();
                HRM_PersonalInformations _personalInfo = employeeBll.GetPersonalInfoByEID(eid);
                txtbxName.Text = _personalInfo.FirstName + " " + _personalInfo.LastName;
                txtbxDesgination.Text = employeeBll.GetDesginationName(_personalInfo.DesginationId);
                txtbxDepartment.Text = employeeBll.GetDepartmentName(_personalInfo.DepartmentId);
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
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
            catch (Exception ex)
            {
                throw ex;
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
                if (chSalaryIncrementStatus.Checked)
                {
                    Attendance_BLL _attendancebll = new Attendance_BLL();
                    string eid = txtbxEID.Text.Trim();
                    List<HRM_EMPLOYEES_VIEWER> employess = _attendancebll.GetEmployeesByEid(eid);
                    List<HRM_EMPLOYEES_VIEWER> newemployess = new List<HRM_EMPLOYEES_VIEWER>();

                    foreach (HRM_EMPLOYEES_VIEWER aitem in employess)
                    {
                        HRM_EMPLOYEES_VIEWER aemployee = new HRM_EMPLOYEES_VIEWER();
                        aemployee.EID = aitem.EID;
                        //aemployee.EMP_ID = Convert.ToInt32(aitem.EID);
                        aemployee.EmployeeFullName = aitem.FirstName + " " + aitem.LastName;
                        aemployee.DEG_NAME = aitem.DEG_NAME;
                        aemployee.DATE_JOINED = Convert.ToDateTime(aitem.DATE_JOINED);
                        aemployee.Type = drpEntryType.SelectedValue.ToString();
                        aemployee.IncrementDate = Convert.ToDateTime(txtDate.Text);
                        aemployee.EffectiveDate = Convert.ToDateTime(txtbxEffectiveDate.Text);
                        aemployee.PreviousSalary = aitem.PreviousSalary;
                        aemployee.BasicSalary = aitem.BasicSalary;

                        if (drpEntryType.SelectedValue.ToString() == "Percentage")
                        {

                            decimal calculateSalary = (Convert.ToDecimal(aitem.BasicSalary) * Convert.ToDecimal(txtbxAmountParcentence.Text)) / 100;
                            aemployee.IncrementAmount = calculateSalary;
                            aemployee.AfterIncrementSalry = aitem.PreviousSalary + calculateSalary;
                        }
                        else
                        {
                            decimal calculateSalary = Convert.ToDecimal(txtbxAmountParcentence.Text);
                            aemployee.IncrementAmount = calculateSalary;
                            aemployee.AfterIncrementSalry = aitem.PreviousSalary + calculateSalary;
                        }
                        newemployess.Add(aemployee);
                    }
                    List<HRM_EMPLOYEES_VIEWER> assendingnewemployess = newemployess.ToList();

                    if (assendingnewemployess.Count > 0)
                    {
                        if (chSalaryIncrementStatus.Checked)
                        {
                            grdviewIndivitual.DataSource = assendingnewemployess;
                            grdviewIndivitual.DataBind();
                        }
                        else
                        {
                            grdview.DataSource = assendingnewemployess;
                            grdview.DataBind();
                        }
                    }

                }
                else
                {
                    //if (Convert.ToDateTime(txtDate.Text) > DateTime.Now)
                    //{
                    //    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Attendance Date can not be greater than current date!')", true);
                    //    return;
                    //}
                    if (ddlRegion1.SelectedItem.ToString() == "--Select--")
                    {
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Please Select Region')", true);
                    }
                    else if (txtDate.Text == "")
                    {
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Please Input Date')", true);
                    }
                    else if (drpEntryType.SelectedItem.ToString() == "Select Entry Type")
                    {
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Please Select Entry Type')", true);
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
                                   // aemployee.EMP_ID = Convert.ToInt32(aitem.EID);
                                    aemployee.EmployeeFullName = aitem.FirstName + " " + aitem.LastName;
                                    aemployee.DEG_NAME = aitem.DEG_NAME;
                                    aemployee.DATE_JOINED = Convert.ToDateTime(aitem.DATE_JOINED);
                                    aemployee.Type = drpEntryType.SelectedValue.ToString();
                                    aemployee.IncrementDate = Convert.ToDateTime(txtDate.Text);
                                    aemployee.EffectiveDate = Convert.ToDateTime(txtbxEffectiveDate.Text);
                                    aemployee.PreviousSalary = aitem.PreviousSalary;
                                    aemployee.BasicSalary = aitem.BasicSalary;

                                    if (drpEntryType.SelectedValue.ToString() == "Percentage")
                                    {

                                        decimal calculateSalary = (Convert.ToDecimal(aitem.BasicSalary) * Convert.ToDecimal(txtbxAmountParcentence.Text)) / 100;
                                        aemployee.IncrementAmount = calculateSalary;
                                        aemployee.AfterIncrementSalry = aitem.PreviousSalary + calculateSalary;
                                    }
                                    else
                                    {
                                        decimal calculateSalary = Convert.ToDecimal(txtbxAmountParcentence.Text);
                                        aemployee.IncrementAmount = calculateSalary;
                                        aemployee.AfterIncrementSalry = aitem.PreviousSalary + calculateSalary;
                                    }
                                    newemployess.Add(aemployee);
                                }

                                List<HRM_EMPLOYEES_VIEWER> ascendingnewemployees = newemployess.ToList();

                                if (ascendingnewemployees.Count > 0)
                                {
                                    if (chSalaryIncrementStatus.Checked)
                                    {
                                        grdviewIndivitual.DataSource = ascendingnewemployees;
                                        grdviewIndivitual.DataBind();
                                    }
                                    else
                                    {
                                        grdview.DataSource = ascendingnewemployees;
                                        grdview.DataBind();
                                    }
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
                                   // aemployee.EMP_ID = Convert.ToInt32(aitem.EID);
                                    aemployee.EmployeeFullName = aitem.FirstName + " " + aitem.LastName;
                                    aemployee.DEG_NAME = aitem.DEG_NAME;
                                    aemployee.DATE_JOINED = Convert.ToDateTime(aitem.DATE_JOINED);
                                    aemployee.Type = drpEntryType.SelectedValue.ToString();
                                    aemployee.IncrementDate = Convert.ToDateTime(txtDate.Text);
                                    aemployee.EffectiveDate = Convert.ToDateTime(txtbxEffectiveDate.Text);
                                    aemployee.PreviousSalary = aitem.PreviousSalary;
                                    aemployee.BasicSalary = aitem.BasicSalary;
                                    if (drpEntryType.SelectedValue.ToString() == "Percentage")
                                    {

                                        decimal calculateSalary = (Convert.ToDecimal(aitem.BasicSalary) * Convert.ToDecimal(txtbxAmountParcentence.Text)) / 100;
                                        aemployee.IncrementAmount = calculateSalary;
                                        aemployee.AfterIncrementSalry = aitem.PreviousSalary + calculateSalary;
                                    }
                                    else
                                    {
                                        decimal calculateSalary = Convert.ToDecimal(txtbxAmountParcentence.Text);
                                        aemployee.IncrementAmount = calculateSalary;
                                        aemployee.AfterIncrementSalry = aitem.PreviousSalary + calculateSalary;
                                    }
                                    newemployess.Add(aemployee);
                                }
                                List<HRM_EMPLOYEES_VIEWER> assendingnewemployess = newemployess.ToList();

                                if (assendingnewemployess.Count > 0)
                                {
                                    if (chSalaryIncrementStatus.Checked)
                                    {
                                        grdviewIndivitual.DataSource = assendingnewemployess;
                                        grdviewIndivitual.DataBind();
                                    }
                                    else
                                    {
                                        grdview.DataSource = assendingnewemployess;
                                        grdview.DataBind();
                                    }


                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
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
                SalaryIncrementBLL _SalryIncrementBll = new SalaryIncrementBLL();
                List<HRM_SalaryIncrement> SalaryIncrements = new List<HRM_SalaryIncrement>();
                List<HRM_SalaryIncrement> SalaryIncrementList = new List<HRM_SalaryIncrement>(); //For Getting Date

                string E_ID = "";

                if (chSalaryIncrementStatus.Checked == false)
                {
                    foreach (GridViewRow gvRow in grdview.Rows)
                    {
                        CheckBox rowChkBox = ((CheckBox)gvRow.FindControl("rowLevelCheckBox"));
                        HRM_SalaryIncrement _salaryincrement = new HRM_SalaryIncrement();
                        if (rowChkBox.Checked == true)
                        {
                            Label lblEID = ((Label)gvRow.FindControl("lblEID"));
                            Label lblPreviusSalary = ((Label)gvRow.FindControl("lblPreviusSalry"));
                            Label lblIncrementSlary = ((Label)gvRow.FindControl("lblIncrementSalary"));
                            Label lblIncrementDate = ((Label)gvRow.FindControl("lblIncrementDate"));
                            Label lblEffectiveDate = ((Label)gvRow.FindControl("lblEffectiveDate"));

                            E_ID = lblEID.Text;

                            _salaryincrement.EID = lblEID.Text;
                            _salaryincrement.previousSalary = Convert.ToDecimal(lblPreviusSalary.Text);
                            _salaryincrement.IncrementSalary = Convert.ToDecimal(lblIncrementSlary.Text);
                            _salaryincrement.IncrementDate = Convert.ToDateTime(lblIncrementDate.Text);
                            _salaryincrement.EffectiveDate = Convert.ToDateTime(lblEffectiveDate.Text);
                            _salaryincrement.ApprovedStatus = false;
                            _salaryincrement.OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                            _salaryincrement.EDIT_DATE = DateTime.Now;
                            _salaryincrement.EDIT_USER = ((SessionUser)Session["SessionUser"]).UserId;
                            SalaryIncrements.Add(_salaryincrement);
                        }
                    }
                    #region MyRegion
                    if (SalaryIncrements.Count > 0)
                    {
                        DateTime ExistEffictiveDate = Convert.ToDateTime(txtbxEffectiveDate.Text);

                        SalaryIncrementList = _SalryIncrementBll.Get_SalryIncrementByEID_Date(E_ID, ExistEffictiveDate);

                        if (SalaryIncrementList.Count > 0)
                        {
                            int result = _SalryIncrementBll.UpDateSalryIncrementLog(SalaryIncrements, E_ID, ExistEffictiveDate);
                            if (result == 1)
                            {
                                GetSalaryIncrementLog();
                                ClearUI();
                                drpEntryType.SelectedValue = drpEntryType.SelectedValue.ToString();
                                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Data Update Successfully')", true);
                            }
                        }
                        else
                        {
                            int result = _SalryIncrementBll.InsertSalryIncrementLog(SalaryIncrements);
                            if (result == 1)
                            {
                                GetSalaryIncrementLog();
                                ClearUI();
                                drpEntryType.SelectedValue = drpEntryType.SelectedValue.ToString();
                                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Data Process Successfully')", true);
                                txtbxEID.Focus();
                            }
                        }
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No Employee selected in the list!')", true);
                    }
                    #endregion
                }
                else
                {

                    foreach (GridViewRow gvRow in grdviewIndivitual.Rows)
                    {
                            HRM_SalaryIncrement _salaryincrement = new HRM_SalaryIncrement();                       
                            Label lblEID = ((Label)gvRow.FindControl("lblEID"));
                            Label lblPreviusSalary = ((Label)gvRow.FindControl("lblPreviusSalry"));
                            Label lblIncrementSlary = ((Label)gvRow.FindControl("lblIncrementSalary"));
                            Label lblIncrementDate = ((Label)gvRow.FindControl("lblIncrementDate"));
                            Label lblEffectiveDate = ((Label)gvRow.FindControl("lblEffectiveDate"));
                            E_ID = lblEID.Text;

                            _salaryincrement.EID = lblEID.Text;
                            _salaryincrement.previousSalary = Convert.ToDecimal(lblPreviusSalary.Text);
                            _salaryincrement.IncrementSalary = Convert.ToDecimal(lblIncrementSlary.Text);
                            _salaryincrement.IncrementDate = Convert.ToDateTime(lblIncrementDate.Text);
                            _salaryincrement.EffectiveDate = Convert.ToDateTime(lblEffectiveDate.Text);
                            _salaryincrement.ApprovedStatus = false;
                            _salaryincrement.OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                            _salaryincrement.EDIT_DATE = DateTime.Now;
                            _salaryincrement.EDIT_USER = ((SessionUser)Session["SessionUser"]).UserId;
                            SalaryIncrements.Add(_salaryincrement);

                            #region MyRegion
                            if (SalaryIncrements.Count > 0)
                            {
                                DateTime ExistEffictiveDate = Convert.ToDateTime(txtbxEffectiveDate.Text);

                                SalaryIncrementList = _SalryIncrementBll.Get_SalryIncrementByEID_Date(E_ID, ExistEffictiveDate);

                                if (SalaryIncrementList.Count > 0)
                                {
                                    int result = _SalryIncrementBll.UpDateSalryIncrementLog(SalaryIncrements, E_ID, ExistEffictiveDate);
                                    if (result == 1)
                                    {
                                        GetSalaryIncrementLog();
                                        ClearUI();
                                        drpEntryType.SelectedValue = drpEntryType.SelectedValue.ToString();
                                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Data Update Successfully')", true);
                                        //txtbxEID.Focus();
                                    }
                                }
                                else
                                {
                                    int result = _SalryIncrementBll.InsertSalryIncrementLog(SalaryIncrements);
                                    if (result == 1)
                                    {
                                        GetSalaryIncrementLog();
                                        ClearUI();
                                        drpEntryType.SelectedValue = drpEntryType.SelectedValue.ToString();
                                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Data Process Successfully')", true);
                                        txtbxEID.Focus();
                                    }
                                }
                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No Employee selected in the list!')", true);
                            }
                            #endregion
                    }
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

        private void GetSalaryIncrementLog()
        {
            DESIGNATION_BLL objDeg_BLL = new DESIGNATION_BLL();
            SalaryIncrementBLL _salaryIncrementBll = new SalaryIncrementBLL();
            try
            {
                string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                List<HRM_SalaryIncrement> salaryIncrements = _salaryIncrementBll.GetSalaryIncrementLog(OCODE);
                DateTime serverDate = _salaryIncrementBll.GetServerDate();
                List<HRM_PersonalInformations> personalInfoes = _salaryIncrementBll.GetAllEmployess(OCODE);
                List<HRM_DESIGNATIONS> designationes = _salaryIncrementBll.GetAllDesgination(OCODE);
                List<SalaryIncrementR> slaryIncrementRes = new List<SalaryIncrementR>();
                foreach (HRM_SalaryIncrement aitem in salaryIncrements)
                {
                    if (aitem.EffectiveDate <= serverDate)
                    {

                        SalaryIncrementR _salaryIncrementR = new SalaryIncrementR();
                        int? desId = personalInfoes.Where(x => x.EID == aitem.EID).FirstOrDefault().DesginationId;
                        string desName = designationes.Where(x => x.DEG_ID == desId).FirstOrDefault().DEG_NAME;
                        string grade = designationes.Where(x => x.DEG_ID == desId).FirstOrDefault().GRADE;
                        decimal? Gosssalary = aitem.IncrementSalary; //designationes.Where(x => x.DEG_ID == desId).FirstOrDefault().GROSS_SAL;
                        bool Status = CheckDesignation(desName, grade, Gosssalary);
                        if (Status == false)
                        {
                            InsertDesgination(desName, grade, Gosssalary);
                        }
                        HRM_DESIGNATIONS _Desobj = objDeg_BLL.GetDesignationIdByDesNameGradAndGoss(desName, grade, Gosssalary);
                        if (_Desobj != null)
                        {
                            _salaryIncrementR.Eid = aitem.EID;
                            _salaryIncrementR.IncrementDate = aitem.IncrementDate;
                            _salaryIncrementR.Grade = grade;
                            _salaryIncrementR.EffectiveDate = aitem.EffectiveDate;
                            _salaryIncrementR.previousSalary = aitem.previousSalary;
                            _salaryIncrementR.Slary = Convert.ToDecimal(aitem.IncrementSalary);
                            _salaryIncrementR.DesId = _Desobj.DEG_ID;
                            _salaryIncrementR.Ocode = ((SessionUser)Session["SessionUser"]).OCode;
                            _salaryIncrementR.EDIT_USER = ((SessionUser)Session["SessionUser"]).UserId;
                            _salaryIncrementR.EDIT_DATE = DateTime.Now;
                            slaryIncrementRes.Add(_salaryIncrementR);
                        }
                    }
                }
                if (slaryIncrementRes.Count > 0)
                {
                    int result = _salaryIncrementBll.AutomaticSalaryUpdate(slaryIncrementRes);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }
        private void InsertDesgination(string desName, string grade, decimal? Gosssalary)
        {
            try
            {
                DESIGNATION_BLL objDeg_BLL = new DESIGNATION_BLL();

                //decimal gross_Salary = Convert.ToDecimal(Gosssalary);

                //Logic Change Provide By Masum Vai ---------------------------------Kamruzzaman(30/3/16)
                double gross_Salary = Convert.ToDouble(Gosssalary);
                double medical = 250;
                double taransport = 200;
                double food = 650;
                double withoutMedical = (gross_Salary - (medical + taransport + food));
                double Basic = (withoutMedical) / 1.4;
                double houseRent = (Basic * 40) / 100;


                HRM_DESIGNATIONS designationObj = new HRM_DESIGNATIONS();
                designationObj.DEG_NAME = desName;
                designationObj.GRADE = grade;
                designationObj.GROSS_SAL = Convert.ToDecimal(gross_Salary);
                designationObj.HOUSE_RENT = Convert.ToDecimal(houseRent);
                designationObj.BASIC = Convert.ToDecimal(Basic);
                designationObj.MEDICAL = Convert.ToDecimal(medical);
                designationObj.CONVEYANCE = Convert.ToDecimal(taransport);
                designationObj.FOOD_ALLOW = Convert.ToDecimal(food);
                designationObj.EDIT_USER = ((SessionUser)Session["SessionUser"]).UserId;
                designationObj.EDIT_DATE = DateTime.Now;
                designationObj.OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                int result = objDeg_BLL.InsertDeignation(designationObj);
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }

        }

        private bool CheckDesignation(string Desgination, string Grad, decimal? Gosssalary)
        {
            bool Status = false;
            try
            {
                SalaryIncrementBLL _salaryIncrementBll = new SalaryIncrementBLL();
                Status = _salaryIncrementBll.CheckDesignation(Desgination, Grad, Gosssalary);
                return Status;
            }
            catch (Exception ex)
            {

               
            }
            return Status;

        }
        private void ClearUI()
        {
            txtbxEID.Text = "";
            ddlSection.ClearSelection();
            ddlSubSections.ClearSelection();
           txtbxAmountParcentence.Text = "";
           // txtDate.Text = "";
            txtbxDepartment.Text = "";
          //  drpEntryType.ClearSelection();
            grdview.DataSource = null;
            grdview.DataBind();
            grdviewIndivitual.DataSource = null;
            grdviewIndivitual.DataBind();
           // txtbxEffectiveDate.Text = "";
            txtbxName.Text = "";
            txtbxDesgination.Text = "";
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
        protected void indivitualEmployee(object sender, EventArgs e)
        {
            try
            {
                if (chSalaryIncrementStatus.Checked)
                {
                    txtbxEID.Text = "";
                    divRegion.Visible = false;
                    divOffice.Visible = false;
                    divDepartment.Visible = false;
                    divSection.Visible = false;
                    divSubSection.Visible = false;
                    divEid.Visible = true;
                    divDesgination.Visible = true;
                    divName.Visible = true;
                    divIndiDepartment.Visible = true;
                }
                else
                {
                    txtbxEID.Text = "";
                    divRegion.Visible = true;
                    divOffice.Visible = true;
                    divDepartment.Visible = true;
                    divSection.Visible = true;
                    divSubSection.Visible = true;
                    divEid.Visible = false;
                    divDesgination.Visible = false;
                    divName.Visible = false;
                    divIndiDepartment.Visible = false;
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

    }
}

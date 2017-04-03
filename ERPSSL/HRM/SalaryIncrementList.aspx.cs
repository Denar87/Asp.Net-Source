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
    public partial class SalaryIncrementList : System.Web.UI.Page
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
                    divEid.Visible = false;
                    divDesgination.Visible = false;
                    divName.Visible = false;
                    divIndiDepartment.Visible = false;
                    GerRegion1List();
                }
            }
            else
            {
                Response.Redirect("..\\AppGateway\\Login.aspx");
            }
        }

        protected void txtbxEID_TextChangeEvent(object sender, EventArgs e)
        {
            try
            {
                string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                string employeeID = Convert.ToString(txtbxEID.Text);

                var result = objEmp_BLL.GetEmployeeDetailsForAttendece(employeeID, OCODE).ToList();
                if (result.Count > 0)
                {
                    var objNewEmp = result.First();
                    txtbxEID.Text = Convert.ToString(objNewEmp.EID);
                    txtbxName.Text = Convert.ToString(objNewEmp.EMP_FIRSTNAME + " " + objNewEmp.EMP_LASTNAME);
                    //lblHiddenId.Text = Convert.ToString(objNewEmp.EMP_ID);
                    txtbxDesgination.Text = objNewEmp.DPT_NAME;
                    txtbxDepartment.Text = objNewEmp.DEG_NAME;
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Employee Not Available!')", true);
                    txtbxName.Text = "";
                    //lblHiddenId.Text = Convert.ToString(objNewEmp.EMP_ID);
                    txtbxDesgination.Text = "";
                    txtbxDepartment.Text = "";
                }
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
                string EID = Convert.ToString(((SessionUser)Session["SessionUser"]).EID);
                //LogController<SalaryIncrementList>.SetLog(ex, EID);
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
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
                string EID = Convert.ToString(((SessionUser)Session["SessionUser"]).EID);
                //LogController<SalaryIncrementList>.SetLog(ex, EID);
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
                string EID = Convert.ToString(((SessionUser)Session["SessionUser"]).EID);
                //LogController<SalaryIncrementList>.SetLog(ex, EID);
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
                string EID = Convert.ToString(((SessionUser)Session["SessionUser"]).EID);
                //LogController<SalaryIncrementList>.SetLog(ex, EID);
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
                string EID = Convert.ToString(((SessionUser)Session["SessionUser"]).EID);
                //LogController<SalaryIncrementList>.SetLog(ex, EID);
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
                string EID = Convert.ToString(((SessionUser)Session["SessionUser"]).EID);
                //LogController<SalaryIncrementList>.SetLog(ex, EID);
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

        //protected void btnProcess_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        if (chSalaryIncrementStatus.Checked)   // individual process
        //        {
        //            Attendance_BLL _attendancebll = new Attendance_BLL();
        //            string eid = txtbxEID.Text.Trim();
        //            List<HRM_EMPLOYEES_VIEWER> employess = _attendancebll.GetEmployeesByE_id(eid, Convert.ToDateTime(txtbxEffectiveDate.Text));

        //            if (employess.Count > 0)
        //            {
        //                if (chSalaryIncrementStatus.Checked)
        //                {
        //                    grdviewIndivitual.DataSource = employess;
        //                    grdviewIndivitual.DataBind();
        //                }
        //                else
        //                {
        //                    grdview.DataSource = employess;
        //                    grdview.DataBind();
        //                }
        //            }
        //        }
        //        else    //dept/section/subsection wise process
        //        {
        //            if (ddlRegion1.SelectedItem.ToString() == "--Select--")
        //            {
        //                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Select Region!')", true);
        //                return;
        //            }
        //            else if (ddlOffice1.SelectedItem.ToString() == "--Select--")
        //            {
        //                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Select Office!')", true);
        //                return;
        //            }
        //            else if (ddlDept1.SelectedItem.ToString() == "--Select--")
        //            {
        //                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Select Department!')", true);
        //                return;
        //            }

        //            else if (txtbxEffectiveDate.Text == "")
        //            {
        //                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Select Effective Date!')", true);
        //                return;
        //            }
        //            else
        //            {
        //                try
        //                {
        //                    Attendance_BLL _attendancebll = new Attendance_BLL();
        //                    if (ddlSubSections.SelectedValue.ToString() == "" || ddlSubSections.SelectedValue.ToString() == "0" || ddlSection.SelectedValue.ToString() == "" || ddlSection.SelectedValue.ToString() == "0")
        //                    {
        //                        int RegionId = Convert.ToInt32(ddlRegion1.SelectedValue);
        //                        int OfficeId = Convert.ToInt32(ddlOffice1.SelectedValue);
        //                        int DeptId = Convert.ToInt32(ddlDept1.SelectedValue);

        //                        List<HRM_EMPLOYEES_VIEWER> employess = _attendancebll.GetEmployeeByDepartment(RegionId, OfficeId, DeptId, Convert.ToDateTime(txtbxEffectiveDate.Text));

        //                        if (employess.Count > 0)
        //                        {
        //                            if (chSalaryIncrementStatus.Checked)
        //                            {
        //                                grdviewIndivitual.DataSource = employess;
        //                                grdviewIndivitual.DataBind();
        //                            }
        //                            else
        //                            {
        //                                grdview.DataSource = employess;
        //                                grdview.DataBind();
        //                            }
        //                        }
        //                    }
        //                    else
        //                    {
        //                        int ResionId = Convert.ToInt32(ddlRegion1.SelectedValue);
        //                        int OfficeId = Convert.ToInt32(ddlOffice1.SelectedValue);
        //                        int DeptId = Convert.ToInt32(ddlDept1.SelectedValue);
        //                        int sction = Convert.ToInt32(ddlSection.SelectedValue);
        //                        int subsction = Convert.ToInt32(ddlSubSections.SelectedValue);

        //                        List<HRM_EMPLOYEES_VIEWER> employess = _attendancebll.GetEmployeeBySubsectionWise(ResionId, OfficeId, DeptId, sction, subsction, Convert.ToDateTime(txtbxEffectiveDate.Text));

        //                        if (employess.Count > 0)
        //                        {
        //                            if (chSalaryIncrementStatus.Checked)
        //                            {
        //                                grdviewIndivitual.DataSource = employess;
        //                                grdviewIndivitual.DataBind();
        //                            }
        //                            else
        //                            {
        //                                grdview.DataSource = employess;
        //                                grdview.DataBind();
        //                            }
        //                        }
        //                    }
        //                }
        //                catch (Exception ex)
        //                {
        //                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        string EID = Convert.ToString(((SessionUser)Session["SessionUser"]).EID);
        //        LogController<SalaryIncrementList>.SetLog(ex, EID);
        //        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
        //    }
        //}

        protected void btnConfirm_Click(object sender, EventArgs e)
        {
            try
            {
                SalaryIncrementBLL _SalryIncrementBll = new SalaryIncrementBLL();
                List<HRM_SalaryIncrement> SalaryIncrements = new List<HRM_SalaryIncrement>();
                List<HRM_SalaryIncrement> SalaryIncrementList = new List<HRM_SalaryIncrement>(); //For Getting Date

                string E_ID = "";
                //string EID = "";
                int I_D = 0;
                if (chSalaryIncrementStatus.Checked == false)   //individual 
                {
                    foreach (GridViewRow gvRow in grdview.Rows)
                    {
                        //string E_ID = "";
                        CheckBox rowChkBox = ((CheckBox)gvRow.FindControl("rowLevelCheckBox"));
                        HRM_SalaryIncrement _salaryincrement = new HRM_SalaryIncrement();
                        if (rowChkBox.Checked == true)
                        {
                            Label lblEID = ((Label)gvRow.FindControl("lblEID"));
                            //Label lblID = ((Label)gvRow.FindControl("lblID"));
                            //Label lblPreviusSalary = ((Label)gvRow.FindControl("lblPreviusSalry"));
                            //Label lblIncrementSlary = ((Label)gvRow.FindControl("lblIncrementSalary"));
                            //Label lblIncrementDate = ((Label)gvRow.FindControl("lblIncrementDate"));
                            //Label lblEffectiveDate = ((Label)gvRow.FindControl("lblEffectiveDate"));
                            //I_D = Convert.ToInt32(lblID);
                            E_ID = lblEID.Text;
                            ////_salaryincrement.ID = Convert.ToInt32(lblID);
                            _salaryincrement.EID = lblEID.Text;

                            //_salaryincrement.previousSalary = Convert.ToDecimal(lblPreviusSalary.Text);
                            //_salaryincrement.IncrementSalary = Convert.ToDecimal(lblIncrementSlary.Text);
                            //_salaryincrement.IncrementDate = Convert.ToDateTime(lblIncrementDate.Text);
                            //_salaryincrement.EffectiveDate = Convert.ToDateTime(lblEffectiveDate.Text);
                            //_salaryincrement.ApprovedStatus = false;
                            //_salaryincrement.OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                            //_salaryincrement.EDIT_DATE = DateTime.Now;
                            //_salaryincrement.EDIT_USER = ((SessionUser)Session["SessionUser"]).UserId;
                            SalaryIncrements.Add(_salaryincrement);
                        }
                        #region MyRegion
                        if (SalaryIncrements.Count > 0)
                        {
                            //int result = _SalryIncrementBll.DeleteSalryIncrementLog(SalaryIncrements, E_ID);
                            int result = _SalryIncrementBll.DeleteSalryIncrementLog( E_ID);
                            if (result == 1)
                            {
                                GetSalaryIncrementLog();
                                ClearUI();
                                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Data Process Successfully')", true);
                                txtbxEID.Focus();
                            }
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Data Delete Successfully!')", true);
                        }
                        #endregion
                    }

                }
                else   // dpt/section/subsection wise process
                {
                    foreach (GridViewRow gvRow in grdviewIndivitual.Rows)
                    {
                        //string E_ID = "";
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
                            int result = _SalryIncrementBll.DeleteSalryIncrementLog(E_ID);
                            if (result == 1)
                            {
                                GetSalaryIncrementLog();
                                ClearUI();
                                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Data Process Successfully')", true);
                                txtbxEID.Focus();
                            }
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Data Delete Successfully!')", true);
                        }
                        #endregion
                    }
                }
                btnConfirm.Visible = false;
            }
            catch (Exception ex)
            {
                string EID = Convert.ToString(((SessionUser)Session["SessionUser"]).EID);
                //LogController<SalaryIncrementList>.SetLog(ex, EID);
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

        //protected void btn_Confirm_Clcik(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        SalaryIncrementBLL _SalryIncrementBll = new SalaryIncrementBLL();
        //        List<HRM_SalaryIncrement> SalaryIncrements = new List<HRM_SalaryIncrement>();
        //        List<HRM_SalaryIncrement> SalaryIncrementList = new List<HRM_SalaryIncrement>(); //For Getting Date

        //        string E_ID = "";
        //        //string EID = "";
        //        if (chSalaryIncrementStatus.Checked == false)   //individual 
        //        {
        //            foreach (GridViewRow gvRow in grdview.Rows)
        //            {
        //                //string E_ID = "";
        //                CheckBox rowChkBox = ((CheckBox)gvRow.FindControl("rowLevelCheckBox"));
        //                HRM_SalaryIncrement _salaryincrement = new HRM_SalaryIncrement();
        //                if (rowChkBox.Checked == true)
        //                {
        //                    Label lblEID = ((Label)gvRow.FindControl("lblEID"));
        //                    Label lblPreviusSalary = ((Label)gvRow.FindControl("lblPreviusSalry"));
        //                    Label lblIncrementSlary = ((Label)gvRow.FindControl("lblIncrementSalary"));
        //                    Label lblIncrementDate = ((Label)gvRow.FindControl("lblIncrementDate"));
        //                    Label lblEffectiveDate = ((Label)gvRow.FindControl("lblEffectiveDate"));
        //                    E_ID = lblEID.Text;

        //                    _salaryincrement.EID = lblEID.Text;

        //                    _salaryincrement.previousSalary = Convert.ToDecimal(lblPreviusSalary.Text);
        //                    _salaryincrement.IncrementSalary = Convert.ToDecimal(lblIncrementSlary.Text);
        //                    _salaryincrement.IncrementDate = Convert.ToDateTime(lblIncrementDate.Text);
        //                    _salaryincrement.EffectiveDate = Convert.ToDateTime(lblEffectiveDate.Text);
        //                    _salaryincrement.ApprovedStatus = false;
        //                    _salaryincrement.OCODE = ((SessionUser)Session["SessionUser"]).OCode;
        //                    _salaryincrement.EDIT_DATE = DateTime.Now;
        //                    _salaryincrement.EDIT_USER = ((SessionUser)Session["SessionUser"]).UserId;
        //                    SalaryIncrements.Add(_salaryincrement);
        //                }
        //            }
        //            #region MyRegion
        //            if (SalaryIncrements.Count > 0)
        //            {
        //                int result = _SalryIncrementBll.DeleteSalryIncrementLog(SalaryIncrements);
        //                if (result == 1)
        //                {
        //                    GetSalaryIncrementLog();
        //                    ClearUI();
        //                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Data Process Successfully')", true);
        //                    txtbxEID.Focus();
        //                }
        //            }
        //            else
        //            {
        //                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No Employee selected in the list!')", true);
        //            }
        //            #endregion
        //        }
        //        else   // dpt/section/subsection wise process
        //        {
        //            foreach (GridViewRow gvRow in grdviewIndivitual.Rows)
        //            {
        //                //string E_ID = "";
        //                HRM_SalaryIncrement _salaryincrement = new HRM_SalaryIncrement();
        //                Label lblEID = ((Label)gvRow.FindControl("lblEID"));
        //                Label lblPreviusSalary = ((Label)gvRow.FindControl("lblPreviusSalry"));
        //                Label lblIncrementSlary = ((Label)gvRow.FindControl("lblIncrementSalary"));
        //                Label lblIncrementDate = ((Label)gvRow.FindControl("lblIncrementDate"));
        //                Label lblEffectiveDate = ((Label)gvRow.FindControl("lblEffectiveDate"));

        //                E_ID = lblEID.Text;

        //                _salaryincrement.EID = lblEID.Text;

        //                _salaryincrement.previousSalary = Convert.ToDecimal(lblPreviusSalary.Text);
        //                _salaryincrement.IncrementSalary = Convert.ToDecimal(lblIncrementSlary.Text);
        //                _salaryincrement.IncrementDate = Convert.ToDateTime(lblIncrementDate.Text);
        //                _salaryincrement.EffectiveDate = Convert.ToDateTime(lblEffectiveDate.Text);
        //                _salaryincrement.ApprovedStatus = false;
        //                _salaryincrement.OCODE = ((SessionUser)Session["SessionUser"]).OCode;
        //                _salaryincrement.EDIT_DATE = DateTime.Now;
        //                _salaryincrement.EDIT_USER = ((SessionUser)Session["SessionUser"]).UserId;

        //                SalaryIncrements.Add(_salaryincrement);

        //                #region MyRegion
        //                if (SalaryIncrements.Count > 0)
        //                {
        //                    int result = _SalryIncrementBll.DeleteSalryIncrementLog(SalaryIncrements);
        //                    if (result == 1)
        //                    {
        //                        GetSalaryIncrementLog();
        //                        ClearUI();
        //                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Data Process Successfully')", true);
        //                        txtbxEID.Focus();
        //                    }
        //                }
        //                else
        //                {
        //                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No Employee selected in the list!')", true);
        //                }
        //                #endregion
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        string EID = Convert.ToString(((SessionUser)Session["SessionUser"]).EID);
        //        LogController<Attendance_InOut_Update>.SetLog(ex, EID);
        //        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
        //    }
        //}

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
                decimal gross_Salary = Convert.ToDecimal(Gosssalary);

                decimal medical = 200;

                decimal withoutMedical = (gross_Salary - medical);

                decimal houseRent = (withoutMedical * 44) / 100;

                decimal Basic = (withoutMedical * 56) / 100;
                HRM_DESIGNATIONS designationObj = new HRM_DESIGNATIONS();
                designationObj.DEG_NAME = desName.ToString();
                designationObj.GRADE = grade;
                designationObj.GROSS_SAL = gross_Salary;
                designationObj.HOUSE_RENT = houseRent;
                designationObj.BASIC = Basic;
                designationObj.MEDICAL = medical;
                designationObj.FOOD_ALLOW = Convert.ToDecimal(0.00);
                designationObj.CONVEYANCE = Convert.ToDecimal(0.00);
                designationObj.EDIT_USER = ((SessionUser)Session["SessionUser"]).UserId;
                designationObj.EDIT_DATE = DateTime.Now;
                designationObj.OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                int result = objDeg_BLL.InsertDeignation(designationObj);



            }
            catch (Exception)
            {

                throw;
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

                string EID = Convert.ToString(((SessionUser)Session["SessionUser"]).EID);
                //LogController<Salary_Update>.SetLog(ex, EID);
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
            return Status;

        }

        private void ClearUI()
        {
            txtbxEID.Text = "";
            ddlSection.ClearSelection();
            ddlSubSections.ClearSelection();
            //txtbxAmountParcentence.Text = "";
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
            //if (!string.IsNullOrEmpty(e.Row.Cells[6].Text))
            //{
            //    if (e.Row.Cells[6].Text == "Hoilday")
            //    {
            //        e.Row.Cells[6].ForeColor = System.Drawing.Color.Red;
            //        e.Row.Cells[6].BackColor = System.Drawing.Color.Wheat;
            //    }
            //}
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
            catch (Exception)
            {
                throw;
            }
        }

        protected void btnShow_Click(object sender, EventArgs e)
        {
            try
            {
                if (chSalaryIncrementStatus.Checked)   // individual process
                {
                    Attendance_BLL _attendancebll = new Attendance_BLL();
                    string eid = txtbxEID.Text.Trim();
                    List<HRM_EMPLOYEES_VIEWER> employess = _attendancebll.GetEmployeesByE_id(eid, Convert.ToDateTime(txtbxEffectiveDate.Text));

                    if (employess.Count > 0)
                    {
                        if (chSalaryIncrementStatus.Checked)
                        {
                            grdviewIndivitual.DataSource = employess;
                            grdviewIndivitual.DataBind();
                        }
                        else
                        {
                            grdview.DataSource = employess;
                            grdview.DataBind();
                        }
                    }
                }
                else    //dept/section/subsection wise process
                {
                    if (ddlRegion1.SelectedItem.ToString() == "--Select--")
                    {
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Select Region!')", true);
                        return;
                    }
                    else if (ddlOffice1.SelectedItem.ToString() == "--Select--")
                    {
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Select Office!')", true);
                        return;
                    }
                    else if (ddlDept1.SelectedItem.ToString() == "--Select--")
                    {
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Select Department!')", true);
                        return;
                    }

                    else if (txtbxEffectiveDate.Text == "")
                    {
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Select Effective Date!')", true);
                        return;
                    }
                    else
                    {
                        try
                        {
                            Attendance_BLL _attendancebll = new Attendance_BLL();
                            if (ddlSubSections.SelectedValue.ToString() == "" || ddlSubSections.SelectedValue.ToString() == "0" || ddlSection.SelectedValue.ToString() == "" || ddlSection.SelectedValue.ToString() == "0")
                            {
                                int RegionId = Convert.ToInt32(ddlRegion1.SelectedValue);
                                int OfficeId = Convert.ToInt32(ddlOffice1.SelectedValue);
                                int DeptId = Convert.ToInt32(ddlDept1.SelectedValue);

                                List<HRM_EMPLOYEES_VIEWER> employess = _attendancebll.GetEmployeeByDepartment(RegionId, OfficeId, DeptId, Convert.ToDateTime(txtbxEffectiveDate.Text));

                                if (employess.Count > 0)
                                {
                                    if (chSalaryIncrementStatus.Checked)
                                    {
                                        grdviewIndivitual.DataSource = employess;
                                        grdviewIndivitual.DataBind();
                                    }
                                    else
                                    {
                                        grdview.DataSource = employess;
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

                                List<HRM_EMPLOYEES_VIEWER> employess = _attendancebll.GetEmployeeBySubsectionWise(ResionId, OfficeId, DeptId, sction, subsction, Convert.ToDateTime(txtbxEffectiveDate.Text));

                                if (employess.Count > 0)
                                {
                                    if (chSalaryIncrementStatus.Checked)
                                    {
                                        grdviewIndivitual.DataSource = employess;
                                        grdviewIndivitual.DataBind();
                                    }
                                    else
                                    {
                                        grdview.DataSource = employess;
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
                btnConfirm.Visible = true;
            }
            catch (Exception ex)
            {
                string EID = Convert.ToString(((SessionUser)Session["SessionUser"]).EID);
                //LogController<SalaryIncrementList>.SetLog(ex, EID);
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

    }
}

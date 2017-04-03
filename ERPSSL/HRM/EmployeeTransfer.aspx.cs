using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ERPSSL;
using ERPSSL.HRM.BLL;
using ERPSSL.HRM.BLL;
using ERPSSL.HRM.DAL;
using ERPSSL.HRM.DAL.Repository;

namespace ERPSSL.HRM
{
    public partial class EmployeeTransfer : System.Web.UI.Page
    {


        Office_BLL objOffice_BLL = new Office_BLL();
        DEPARTMENT_BLL objDept_BLL = new DEPARTMENT_BLL();
        SECTION_BLL objSec_BLL = new SECTION_BLL();
        SUB_SECTION_BLL objSubSec_BLL = new SUB_SECTION_BLL();
        DESIGNATION_BLL objDeg_BLL = new DESIGNATION_BLL();
        GRADE_BLL objGrd_BLL = new GRADE_BLL();
        ADMINISTRATION_BLL objAdm_BLL = new ADMINISTRATION_BLL();
        EmployeeSetup_BLL objEmp_BLL = new EmployeeSetup_BLL();
        ERPSSLHBEntities context = new ERPSSLHBEntities();
        DESIGNATION_DAL designationDal = new DESIGNATION_DAL();
        GRADE_BLL gradeBll = new GRADE_BLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Session["UserID"] != null) && (Session["OCode"] != null))
            {
                if (!IsPostBack)
                {
                    PopulateRegion();
                    GetAllDesignation();
                    //  BindGridEmployeeTransfer();

                }
            }
            else
            {
                Response.Redirect("..\\AppGateway\\Login.aspx");
            }
        }


        protected void GetAllDesignation()
        {
            try
            {

                string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                var row = designationDal.GetDesignationList(OCODE);
                if (row.Count > 0)
                {
                    drpdwnDesigantion.DataSource = row.ToList();
                    drpdwnDesigantion.DataTextField = "DeginationName";
                    drpdwnDesigantion.DataValueField = "DeginationName";
                    drpdwnDesigantion.DataBind();
                    drpdwnDesigantion.AppendDataBoundItems = false;
                    drpdwnDesigantion.Items.Insert(0, new ListItem("--Select--", "0"));
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        protected void ddlGrade_SelecttedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string Designatin = drpdwnDesigantion.SelectedItem.ToString();
                string Grade = ddlGrade.SelectedItem.ToString();
                txtbxGarde.Text = Grade.ToString();
                string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                List<HRM_DESIGNATIONS> designations = designationDal.GetGrossSalaryByDesigionIdAndGrade(Designatin, Grade, OCODE);
                if (designations.Count > 0)
                {

                    drpGrossSalary.DataSource = designations.ToList();
                    drpGrossSalary.DataTextField = "GROSS_SAL";
                    drpGrossSalary.DataValueField = "GROSS_SAL";
                    drpGrossSalary.DataBind();
                    drpGrossSalary.Items.Insert(0, new ListItem("--Select--", "0"));
                }

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }
        protected void drpStep_SelecttedIndexChanged(object sender, EventArgs e)
        {

            //try
            //{
            //    string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
            //    string De = drpdwnDesigantion.SelectedItem.ToString();
            //    var row = gradeBll.GetGrateByStepAndOCode(De, OCODE).ToList();
            //    if (row.Count > 0)
            //    {
            //        ddlGrade.DataSource = row;
            //        ddlGrade.DataTextField = "GRADE";
            //        ddlGrade.DataValueField = "DEG_ID";
            //        ddlGrade.DataBind();
            //        ddlGrade.Items.Insert(0, new ListItem("--Select--", "0"));
            //    }
            //}
            //catch (Exception ex)
            //{

            //    string EID = Convert.ToString(((SessionUser)Session["SessionUser"]).EID);
            //    LogController<EmployeeTransfer>.SetLog(ex, EID);
            //    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            //}

            try
            {
                string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                string De = drpdwnDesigantion.SelectedItem.ToString();
                var row = gradeBll.GetGrateByDesginationName(De, OCODE).ToList();
                if (row.Count > 0)
                {
                    ddlGrade.DataSource = row;
                    ddlGrade.DataTextField = "Grade";
                    ddlGrade.DataValueField = "Grade";
                    ddlGrade.DataBind();
                    ddlGrade.Items.Insert(0, new ListItem("--Select--", "0"));
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

        private void PopulateRegion()
        {
            try
            {
                string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                var row = objAdm_BLL.GetAllRegions(OCODE);
                if (row.Count > 0)
                {
                    ddlRegion_TR.DataSource = row;
                    ddlRegion_TR.DataTextField = "RegionName";
                    ddlRegion_TR.DataValueField = "RegionID";
                    ddlRegion_TR.DataBind();
                    //        ddlRegion_TR.AppendDataBoundItems = false;
                }

            }
            catch (Exception ex)
            {

            }
        }

        private void PopulateOffice()
        {
            try
            {
                int regionId = Convert.ToInt32(ddlRegion_TR.SelectedValue.ToString());
                string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                List<HRM_Office> Offices = objEmp_BLL.GetofficesByRegionId(regionId, OCODE);

                ddlOffice_TR.Items.Clear();
                ddlOffice_TR.DataSource = Offices;
                ddlOffice_TR.DataValueField = "OfficeID";
                ddlOffice_TR.DataTextField = "OfficeName";
                ddlOffice_TR.DataBind();
                ddlOffice_TR.Items.Insert(0, new ListItem("---- Select One ----", "0"));
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

        protected void ddlRegion_TR_SelectedIndexChanged(object sender, EventArgs e)
        {
            PopulateOffice();
        }

        protected void GetAllDepartment()
        {
            try
            {
                string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                int officeId = Convert.ToInt16(ddlOffice_TR.SelectedValue);
                var row = objDept_BLL.GetDepartmentByOfficeIdAndOCode(officeId, OCODE).ToList();
                if (row.Count > 0)
                {
                    ddlDepartment_TR.DataSource = row.ToList();
                    ddlDepartment_TR.DataTextField = "DPT_NAME";
                    ddlDepartment_TR.DataValueField = "DPT_ID";
                    ddlDepartment_TR.DataBind();
                    ddlDepartment_TR.Items.Insert(0, new ListItem("--Select--"));
                }

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

        protected void ddlOffice_TR_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetAllDepartment();

        }

        protected void GetAllSection()
        {
            try
            {
                string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                int departmentId = Convert.ToInt16(ddlDepartment_TR.SelectedValue);
                var row = objSec_BLL.GetSectionsByDepartmentIdAndOCode(departmentId, OCODE).ToList();
                if (row.Count > 0)
                {
                    ddlSection_TR.DataSource = row;
                    ddlSection_TR.DataTextField = "SEC_NAME";
                    ddlSection_TR.DataValueField = "SEC_ID";
                    ddlSection_TR.DataBind();
                    ddlSection_TR.Items.Insert(0, new ListItem("--Select--"));
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }

        }

        protected void ddlDepartment_TR_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetAllSection();
        }

        protected void GetAllSubSection()
        {
            try
            {
                string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                int sectionId = Convert.ToInt16(ddlSection_TR.SelectedValue);

                var row = objSubSec_BLL.GetSubSectionsBySectionIdAndOCode(sectionId, OCODE).ToList();
                if (row.Count > 0)
                {
                    ddlSubSec_TR.DataSource = row;
                    ddlSubSec_TR.DataTextField = "SUB_SEC_NAME";
                    ddlSubSec_TR.DataValueField = "SUB_SEC_ID";
                    ddlSubSec_TR.DataBind();
                    ddlSubSec_TR.Items.Insert(0, new ListItem("--Select--"));
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

        protected void ddlSection_TR_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetAllSubSection();
        }

        //protected void GetAllDesignation()
        //{
        //    try
        //    {
        //        //       string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
        //        string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
        //        var row = objDeg_BLL.GetAllDesignation(OCODE);
        //        if (row.Count > 0)
        //        {
        //            ddlDesignation_TR.DataSource = row.ToList();
        //            ddlDesignation_TR.DataTextField = "DEG_NAME";
        //            ddlDesignation_TR.DataValueField = "DEG_ID";
        //            ddlDesignation_TR.DataBind();
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }

        //}

        //protected void GetAllGrade()
        //{
        //    try
        //    {
        //        string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
        //        string step = ddlStep_TR.SelectedValue;

        //        var row = objGrd_BLL.GetGrateByStepAndOCode(step, OCODE).ToList();
        //        if (row.Count > 0)
        //        {
        //            ddlGrade_TR.DataSource = row;
        //            ddlGrade_TR.DataTextField = "GRADE";
        //            ddlGrade_TR.DataValueField = "GRADE_ID";
        //            ddlGrade_TR.DataBind();
        //            ddlGrade_TR.Items.Insert(0, new ListItem("--Select--"));
        //        }
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }

        //}

        protected void ddlStep_TR_SelectedIndexChanged(object sender, EventArgs e)
        {
            //GetAllGrade();
        }



        void BindGridEmployeeTransfer()
        {
            try
            {
                string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                string EId = txtEid_TRNS.Text;
                int eidMax = objEmp_BLL.GetMaxEid(OCODE, EId);
                List<TransferR> transfer = objEmp_BLL.GetEmployeeTransfer(eidMax);
                if (transfer.Count > 0)
                {
                    GridViewEMP_TRNS.DataSource = transfer;
                    GridViewEMP_TRNS.DataBind();
                }

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

        protected void txtEid_TRNS_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                string employeeID = txtEid_TRNS.Text;

                var result = objEmp_BLL.GetEmployeeDetailsID(employeeID, OCODE).ToList();
                if (result.Count > 0)
                {
                    if (chTransferWithIncrement.Checked)
                    {
                        hidTransferStatus.Value = "TWSI";
                    }
                    else if (chePromotionWithSalaryIncrement.Checked)
                    {
                        hidTransferStatus.Value = "PWSI";
                    }
                    else if (cheTransferWithoutSalaryIncrement.Checked)
                    {
                        hidTransferStatus.Value = "TWOSI";
                    }
                    else if (ChPromotionWithoutIncrement.Checked)
                    {
                        hidTransferStatus.Value = "PWOSI";
                    }

                    if (hidTransferStatus.Value.ToString() != "")
                    {
                        Emp_IMG_TRNS.Visible = true;
                        Emp_IMG_TRNS.ImageUrl = "EmployeeIMG.ashx?eId=" + employeeID + "&oCode=" + OCODE;

                        var objNewEmp = result.First();
                        txtEid_TRNS.Text = Convert.ToString(objNewEmp.EID);
                        txtRegion_TRNS.Text = Convert.ToString(objNewEmp.REG_NAME);
                        txtOffice_TRNS.Text = Convert.ToString(objNewEmp.OFC_NAME);
                        txtDepartment_TRNS.Text = Convert.ToString(objNewEmp.DPT_NAME);
                        txtSection_TRNS.Text = Convert.ToString(objNewEmp.SEC_NAME);
                        txtSubSection_TRNS.Text = Convert.ToString(objNewEmp.SUB_SEC_NAME);
                        txtDesignation_TRNS.Text = Convert.ToString(objNewEmp.DEG_NAME);
                        txtEmpName.Text = Convert.ToString(objNewEmp.EMP_FIRSTNAME + " " + objNewEmp.EMP_LASTNAME);
                        //txtStep_TRNS.Text = Convert.ToString(objNewEmp.STEP);
                        txtGrade_TRNS.Text = Convert.ToString(objNewEmp.GRADE);
                        txtbxGossSalary.Text = Convert.ToString(objNewEmp.GorssSalary);
                        //-------------------------------------------------------------
                        lblRegion_TRNS.Text = Convert.ToString(objNewEmp.REG_ID);
                        lblOffice_TRNS.Text = Convert.ToString(objNewEmp.OFC_ID);
                        lblDepartment_TRNS.Text = Convert.ToString(objNewEmp.DPT_ID);
                        lblSection_TRNS.Text = Convert.ToString(objNewEmp.SEC_ID);
                        lblSubSection_TRNS.Text = Convert.ToString(objNewEmp.SUB_SEC_ID);
                        lblDesignation_TRNS.Text = Convert.ToString(objNewEmp.DEG_ID);
                        lblStepGrossSalary.Text = Convert.ToString(objNewEmp.GorssSalary);
                        //         ddlShowStep.SelectedValue = Convert.ToString(objNewEmp.STEP);
                        // lblStep_TRNS.Text = Convert.ToString(objNewEmp.STEP);
                        lblGrade_TRNS.Text = Convert.ToString(objNewEmp.GRADE);
                        LoadTransferToAlldrp(txtEid_TRNS.Text);

                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Please Select Transfer Or Promotion Type!')", true);
                    }

                }
                else
                {

                    txtRegion_TRNS.Text = "";
                    txtOffice_TRNS.Text = "";
                    txtDepartment_TRNS.Text = "";
                    txtSection_TRNS.Text = "";
                    txtSubSection_TRNS.Text = "";
                    txtDesignation_TRNS.Text = "";
                    txtGrade_TRNS.Text = "";
                    txtbxGossSalary.Text = "";

                    txtEmpName.Text = "";
                    Emp_IMG_TRNS.Visible = false;
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('This Employee is Inactive!')", true);
                }

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }


        private void GetSalary(string Grade, string DesignationName)
        {
            try
            {
                string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                List<HRM_DESIGNATIONS> designations = designationDal.GetGrossSalaryByDesigionIdAndGrade(DesignationName, Grade, OCODE);
                if (designations.Count > 0)
                {

                    drpGrossSalary.DataSource = designations.ToList();
                    drpGrossSalary.DataTextField = "GROSS_SAL";
                    drpGrossSalary.DataValueField = "GROSS_SAL";
                    drpGrossSalary.DataBind();
                    drpGrossSalary.Items.Insert(0, new ListItem("--Select--", "0"));
                }
                //string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                //var row = gradeBll.GetSalaryByGrade(Grade, OCODE).ToList();
                //if (row.Count > 0)
                //{
                //    drpGrossSalary.DataSource = row;
                //    drpGrossSalary.DataTextField = "GROSS_SAL";
                //    drpGrossSalary.DataValueField = "GROSS_SAL";
                //    drpGrossSalary.DataBind();
                //    drpGrossSalary.Items.Insert(0, new ListItem("--Select--", "0"));
                //}
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

        private void LoadTransferToAlldrp(string Eid)
        {
            try
            {
                HRM_PersonalInformations _personalInformation = objEmp_BLL.GetPersonalInfoByEID(Eid);
                if (_personalInformation != null)
                {
                    ddlRegion_TR.SelectedValue = _personalInformation.RegionsId.ToString();
                    PopulateOffice(_personalInformation.RegionsId);
                    ddlOffice_TR.SelectedValue = _personalInformation.OfficeId.ToString();
                    GetAllDepartment(_personalInformation.OfficeId);
                    ddlDepartment_TR.SelectedValue = _personalInformation.DepartmentId.ToString();
                    GetAllSection(_personalInformation.DepartmentId);
                    ddlSection_TR.SelectedValue = _personalInformation.SectionId.ToString();
                    GetAllSubSection(_personalInformation.SectionId);
                    ddlSubSec_TR.SelectedValue = _personalInformation.SubSectionId.ToString();

                    string DesignationName = GetDesignationNameById(Convert.ToInt32(_personalInformation.DesginationId));
                    drpdwnDesigantion.SelectedValue = DesignationName;
                    GetGrade(DesignationName);
                    ddlGrade.SelectedValue = _personalInformation.Grade.ToString();
                    txtbxGarde.Text = _personalInformation.Grade.ToString();
                    string Grade = _personalInformation.Grade.ToString();
                    GetSalary(Grade, DesignationName);
                    drpGrossSalary.SelectedValue = _personalInformation.Salary.ToString();
                    txtbxGrossSalary.Text = _personalInformation.Salary.ToString();
                    //  BindGridEmployeeTransfer();
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }
        private string GetDesignationNameById(int desginationId)
        {
            return gradeBll.GetDesignationNameById(desginationId);
        }
        private void GetGrade(string DesignationName)
        {
            try
            {
                string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                var row = gradeBll.GetGrateByDesginationName(DesignationName, OCODE).ToList();
                if (row.Count > 0)
                {
                    ddlGrade.DataSource = row;
                    ddlGrade.DataTextField = "Grade";
                    ddlGrade.DataValueField = "Grade";
                    ddlGrade.DataBind();
                    ddlGrade.Items.Insert(0, new ListItem("--Select--", "0"));
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }
        private void GetAllSubSection(int? sectionId)
        {

            try
            {
                string OCODE = ((SessionUser)Session["SessionUser"]).OCode;

                var row = objSubSec_BLL.GetSubSectionsBySectionIdAndOCode(sectionId, OCODE).ToList();
                if (row.Count > 0)
                {
                    ddlSubSec_TR.DataSource = row;
                    ddlSubSec_TR.DataTextField = "SUB_SEC_NAME";
                    ddlSubSec_TR.DataValueField = "SUB_SEC_ID";
                    ddlSubSec_TR.DataBind();
                    ddlSubSec_TR.Items.Insert(0, new ListItem("--Select--"));
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

        private void GetAllSection(int? departmentId)
        {

            try
            {
                string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                var row = objSec_BLL.GetSectionsByDepartmentIdAndOCode(departmentId, OCODE).ToList();
                if (row.Count > 0)
                {
                    ddlSection_TR.DataSource = row;
                    ddlSection_TR.DataTextField = "SEC_NAME";
                    ddlSection_TR.DataValueField = "SEC_ID";
                    ddlSection_TR.DataBind();
                    ddlSection_TR.Items.Insert(0, new ListItem("--Select--"));
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

        private void GetAllDepartment(int? officeId)
        {
            try
            {
                string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                var row = objDept_BLL.GetDepartmentByOfficeIdAndOCode(officeId, OCODE).ToList();
                if (row.Count > 0)
                {
                    ddlDepartment_TR.DataSource = row.ToList();
                    ddlDepartment_TR.DataTextField = "DPT_NAME";
                    ddlDepartment_TR.DataValueField = "DPT_ID";
                    ddlDepartment_TR.DataBind();
                    ddlDepartment_TR.Items.Insert(0, new ListItem("--Select--"));
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

        private void PopulateOffice(int? RegionId)
        {
            try
            {
                string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                List<HRM_Office> Offices = objEmp_BLL.GetofficesByRegionId(RegionId, OCODE);

                ddlOffice_TR.Items.Clear();
                ddlOffice_TR.DataSource = Offices;
                ddlOffice_TR.DataValueField = "OfficeID";
                ddlOffice_TR.DataTextField = "OfficeName";
                ddlOffice_TR.DataBind();
                ddlOffice_TR.Items.Insert(0, new ListItem("---- Select One ----", "0"));
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

        protected void btnTrStaffSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                HRM_EMP_TRANSFER objTrns = new HRM_EMP_TRANSFER();
                string employeeID = Convert.ToString(txtEid_TRNS.Text);
                string desName = drpdwnDesigantion.SelectedItem.ToString();
                string grade = txtbxGarde.Text;
                decimal? Gosssalary = Convert.ToDecimal(txtbxGrossSalary.Text);
                bool Status = CheckDesignation(desName, grade, Gosssalary);
                if (Status == false)
                {
                    InsertDesgination(desName, grade, Gosssalary);

                }
                decimal PreviousGrossSalary = 0;
                HRM_DESIGNATIONS _Desobj = objDeg_BLL.GetDesignationIdByDesNameGradAndGoss(desName, grade, Gosssalary);
                if (_Desobj != null)
                {
                    int regID_TO = Convert.ToInt32(ddlRegion_TR.SelectedValue);
                    int ofcID_TO = Convert.ToInt32(ddlOffice_TR.SelectedValue);
                    int deptID_TO = Convert.ToInt32(ddlDepartment_TR.SelectedValue);
                    int sectionID_TO = Convert.ToInt32(ddlSection_TR.SelectedValue);
                    int subSecID_TO = Convert.ToInt32(ddlSubSec_TR.SelectedValue);
                    //-------------------From-------------------------------
                    objTrns.Regions_ID_FROM = Convert.ToInt32(lblRegion_TRNS.Text);
                    objTrns.Office_ID_FROM = Convert.ToInt32(lblOffice_TRNS.Text);
                    objTrns.DPT_ID_FROM = Convert.ToInt32(lblDepartment_TRNS.Text);
                    objTrns.SEC_ID_FROM = Convert.ToInt32(lblSection_TRNS.Text);
                    objTrns.SUB_SEC_ID_FROM = Convert.ToInt32(lblSubSection_TRNS.Text);
                    objTrns.DEG_ID_FROM = Convert.ToInt32(lblDesignation_TRNS.Text);
                    objTrns.GrossSalaryFrom = Convert.ToDecimal(lblStepGrossSalary.Text);
                    objTrns.GradeFrom = lblGrade_TRNS.Text;
                    PreviousGrossSalary = Convert.ToDecimal(objTrns.GrossSalaryFrom);
                    //-------------------to-------------------------------
                    objTrns.Regions_ID_TO = regID_TO;
                    objTrns.Office_ID_TO = ofcID_TO;
                    objTrns.DPT_ID_TO = deptID_TO;
                    objTrns.SEC_ID_TO = sectionID_TO;
                    objTrns.SUB_SEC_ID_TO = subSecID_TO;
                    objTrns.DEG_ID_TO = _Desobj.DEG_ID;
                    objTrns.GradeTo = _Desobj.GRADE;
                    objTrns.GorssSalaryTo = _Desobj.GROSS_SAL;
                    objTrns.Status = hidTransferStatus.Value.ToString();
                    objTrns.EID = employeeID;

                    objTrns.TRANSFER_DATE = DateTime.Now.Date;
                    objTrns.EDIT_USER = ((SessionUser)Session["SessionUser"]).UserId;
                    objTrns.EDIT_DATE = DateTime.Now;
                    objTrns.OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                }

                int result = objAdm_BLL.SaveEmployee_Transfer(objTrns, employeeID, PreviousGrossSalary);
                if (result == 1)
                {
                    BindGridEmployeeTransfer();
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Data Save Successfully')", true);
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
                //decimal medical = 200;
                //decimal withoutMedical = (gross_Salary - medical);
                //decimal houseRent = (withoutMedical * 44) / 100;
                //decimal Basic = (withoutMedical * 56) / 100;
                //HRM_DESIGNATIONS designationObj = new HRM_DESIGNATIONS();
                //designationObj.DEG_NAME = desName.ToString();
                //designationObj.GRADE = grade;
                //designationObj.GROSS_SAL = gross_Salary;
                //designationObj.HOUSE_RENT = houseRent;
                //designationObj.BASIC = Basic;
                //designationObj.MEDICAL = medical;
                //designationObj.FOOD_ALLOW = Convert.ToDecimal(0.00);
                //designationObj.CONVEYANCE = Convert.ToDecimal(0.00);
                //designationObj.EDIT_USER = ((SessionUser)Session["SessionUser"]).UserId;
                //designationObj.EDIT_DATE = DateTime.Now;
                //designationObj.OCODE = ((SessionUser)Session["SessionUser"]).OCode;

                //decimal gross_Salary = Convert.ToDecimal(Gosssalary);

                //decimal medical = 250;
                //decimal taransport = 200;
                //decimal food = 650;
                //decimal withoutMedical = (gross_Salary - (medical + taransport + food));
                //decimal houseRent = (withoutMedical * 40) / 100;
                //decimal Basic = (withoutMedical * 60) / 100;

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

        protected void drpGrossSalary_SelecttedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                txtbxGrossSalary.Text = drpGrossSalary.SelectedValue.ToString();
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }
    }
}



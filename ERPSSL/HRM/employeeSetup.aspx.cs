using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ERPSSL.HRM.DAL;
using System.Globalization;
using ERPSSL.HRM.DAL.Repository;
using ERPSSL.HRM.BLL;
using ERPSSL;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Drawing.Drawing2D;

namespace ERPSSL.HRM
{
    public partial class employeeSetup : System.Web.UI.Page
    {
        #region -------------- Object ---------------
        DESIGNATION_BLL objDeg_BLL = new DESIGNATION_BLL();
        Region_DAL regionDal = new Region_DAL();
        Office_DAL officeDal = new Office_DAL();
        Office_BLL officeBll = new Office_BLL();
        DEPARTMENT_DAL departmentDal = new DEPARTMENT_DAL();
        DEPARTMENT_BLL departmentBll = new DEPARTMENT_BLL();
        SECTION_BLL SectionBll = new SECTION_BLL();
        SECTION_DAL sectionDal = new SECTION_DAL();
        SUB_SECTION_DAL subSectionDal = new SUB_SECTION_DAL();
        SUB_SECTION_BLL subSectionBll = new SUB_SECTION_BLL();
        GRADE_DAL gradeDal = new GRADE_DAL();
        GRADE_BLL gradeBll = new GRADE_BLL();
        DESIGNATION_DAL designationDal = new DESIGNATION_DAL();
        TIME_SCHEDULE_DAL timeScheduleDal = new TIME_SCHEDULE_DAL();
        EMPOYEE_BLL objEmp_BLL = new EMPOYEE_BLL();
        EmployeeSetup_DAL empSetupDal = new EmployeeSetup_DAL();
        EmployeeSetup_BLL employeeSetUpBll = new EmployeeSetup_BLL();
        EmployeeCategoryBLL emplobyeeCategoryBll = new EmployeeCategoryBLL();
        ERPSSLHBEntities context = new ERPSSLHBEntities();

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Session["UserID"] != null) && (Session["OCode"] != null))
            {

                if (!IsPostBack)
                {
                    txtxEffectiveSlary.Text = "0";

                    divAge.Visible = false;
                    BindNationality();
                    FillRegion();
                    //FillDepartment();
                    //FillSection();
                    //FillSubSection();
                    //FillOffices();
                    //GetAllGrade();
                    GetAllDesignation();
                    GetEmployeeType();
                    getEmployeeCategoryes();
                    GetAllSchedule();
                    FillReportingBossName();
                    GetFirstReportingBossDepartment();
                    gridviewChildrenInfo.DataSource = null;
                    gridviewChildrenInfo.DataBind();
                    //TabContainer1.ActiveTabIndex = 0;
                    //TabContainer1.Tabs[1].Enabled = false;
                    //TabContainer1.Tabs[2].Enabled = false;
                    //TabContainer1.Tabs[3].Enabled = false;
                    //TabContainer1.Tabs[4].Enabled = false;
                }
            }
            else
            {
                Response.Redirect("..\\AppGateway\\Login.aspx");
            }
        }

        private void getEmployeeCategoryes()
        {
            try
            {
                string Ocode = ((SessionUser)Session["SessionUser"]).OCode;
                List<HRM_EmployeeCategory> EmployeeCategoryes = emplobyeeCategoryBll.getEmployeeCategoryes(Ocode);
                if (EmployeeCategoryes.Count > 0)
                {

                    drpEmployeeCate.DataSource = EmployeeCategoryes.ToList();
                    drpEmployeeCate.DataTextField = "EmployeeTypeName";
                    drpEmployeeCate.DataValueField = "EmployeeCategory";
                    drpEmployeeCate.DataBind();
                    drpEmployeeCate.Items.Insert(0, new ListItem("---- Select One ----", "0"));
                }


            }
            catch (Exception)
            {

                throw;
            }

        }

        private void GetEmployeeType()
        {

            try
            {

                string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                //----------GetAllGrade-------------
                var row = gradeDal.GetAllEmployeeType(OCODE);
                if (row.Count > 0)
                {
                    drpEmployeeType.DataSource = row.ToList();
                    drpEmployeeType.DataTextField = "EmployeeTypeName";
                    drpEmployeeType.DataValueField = "EmployeeTypeId";
                    drpEmployeeType.DataBind();
                    drpEmployeeType.Items.Insert(0, new ListItem("---- Select One ----", "0"));
                    drpEmployeeType.AppendDataBoundItems = false;
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        private void GetFirstReportingBossDepartment()
        {
            try
            {
                string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                var row = departmentBll.GetAllDepartment(OCODE);
                if (row.Count > 0)
                {
                    drpFirstReportingDepartment.DataSource = row.ToList();
                    drpFirstReportingDepartment.DataTextField = "DPT_NAME";
                    drpFirstReportingDepartment.DataValueField = "DPT_ID";
                    drpFirstReportingDepartment.DataBind();
                    drpFirstReportingDepartment.Items.Insert(0, new ListItem("--Select--"));

                    drpwownSecondDepartmetn.DataSource = row.ToList();
                    drpwownSecondDepartmetn.DataTextField = "DPT_NAME";
                    drpwownSecondDepartmetn.DataValueField = "DPT_ID";
                    drpwownSecondDepartmetn.DataBind();
                    drpwownSecondDepartmetn.Items.Insert(0, new ListItem("--Select--"));

                    drpdwnThridDepartment.DataSource = row.ToList();
                    drpdwnThridDepartment.DataTextField = "DPT_NAME";
                    drpdwnThridDepartment.DataValueField = "DPT_ID";
                    drpdwnThridDepartment.DataBind();
                    drpdwnThridDepartment.Items.Insert(0, new ListItem("--Select--"));
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        #region ------------------ Populate Dropdown=List ------------------

        private void FillReportingBossName()
        {
            try
            {
                //     string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                // Frist Reportion Boss
                //ddlReportingTo.DataSource = empSetupDal.GetPersonInfo().ToList();
                //ddlReportingTo.DataTextField = "FirstName";
                //ddlReportingTo.DataValueField = "EID";
                //ddlReportingTo.DataBind();
                //ddlReportingTo.Items.Insert(0, new ListItem("--Select--", "0"));


                // Second Reporting Boss
                //drpSecondReportingTo.DataSource = empSetupDal.GetPersonInfo().ToList();
                //drpSecondReportingTo.DataTextField = "FirstName";
                //drpSecondReportingTo.DataValueField = "EID";
                //drpSecondReportingTo.DataBind();
                //drpSecondReportingTo.Items.Insert(0, new ListItem("--Select--", "0"));
                // Third Reporting Boss
                //drpdwnThirdReportingBoss.DataSource = empSetupDal.GetPersonInfo().ToList();
                //drpdwnThirdReportingBoss.DataTextField = "FirstName";
                //drpdwnThirdReportingBoss.DataValueField = "EID";
                //drpdwnThirdReportingBoss.DataBind();
                //drpdwnThirdReportingBoss.Items.Insert(0, new ListItem("--Select--", "0"));


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void FillRegion()
        {
            try
            {
                //        string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                drpRegion.DataSource = regionDal.GetAllRegions(OCODE).ToList();
                drpRegion.DataTextField = "RegionName";
                drpRegion.DataValueField = "RegionID";
                drpRegion.DataBind();
                drpRegion.Items.Insert(0, new ListItem("--Select--", "0"));


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void FillOffices()
        {
            try
            {
                string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                ddlOffice.DataSource = officeDal.GetOffices(OCODE).ToList();
                ddlOffice.Items.Clear();
                ddlOffice.DataValueField = "OfficeID";
                ddlOffice.DataTextField = "OfficeName";
                ddlOffice.DataBind();
                ddlOffice.Items.Insert(0, new ListItem("---- Select One ----", "0"));
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

        private void FillDepartment()
        {
            try
            {

                string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                ddlDepartment.DataSource = departmentDal.GetAllDepartment(OCODE).ToList();
                ddlDepartment.Items.Clear();

                ddlDepartment.DataTextField = "DPT_NAME";
                ddlDepartment.DataValueField = "DPT_ID";
                ddlDepartment.DataBind();
                ddlDepartment.Items.Insert(0, new ListItem("---- Select One ----", "0"));
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

        private void FillSection()
        {
            try
            {

                string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                ddlSection.DataSource = sectionDal.GetAllSection(OCODE).ToList();

                ddlSection.Items.Clear();
                ddlSection.DataTextField = "SEC_NAME";
                ddlSection.DataValueField = "SEC_ID";
                ddlSection.DataBind();
                ddlSection.Items.Insert(0, new ListItem("---- Select One ----", "0"));
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

        private void FillSubSection()
        {
            try
            {

                string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                ddlSubSections.DataSource = subSectionDal.GetAllSub_Section(OCODE).ToList();
                ddlSubSections.Items.Clear();
                ddlSubSections.DataTextField = "SUB_SEC_NAME";
                ddlSubSections.DataValueField = "SUB_SEC_ID";
                ddlSubSections.DataBind();
                ddlSubSections.Items.Insert(0, new ListItem("---- Select One ----", "0"));
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

        protected void GetAllGrade()
        {
            try
            {
                string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                //----------GetAllGrade-------------
                var row = gradeDal.GetAllGrade(OCODE);
                if (row.Count > 0)
                {
                    ddlGrade.DataSource = row.ToList();
                    ddlGrade.DataTextField = "GRADE";
                    ddlGrade.DataValueField = "GRADE_ID";
                    ddlGrade.DataBind();
                    ddlGrade.Items.Insert(0, new ListItem("---- Select One ----", "0"));
                    ddlGrade.AppendDataBoundItems = false;
                }

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
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
                    drpdwnDesigantion.DataValueField = "DeginationID";
                    drpdwnDesigantion.DataBind();
                    drpdwnDesigantion.AppendDataBoundItems = false;
                    drpdwnDesigantion.Items.Insert(0, new ListItem("--Select--", "0"));
                    //drpStep.DataSource = row.ToList();
                    //drpStep.DataTextField = "DEG_NAME";
                    //drpStep.DataValueField = "DEG_ID";
                    //drpStep.DataBind();
                    //drpStep.AppendDataBoundItems = false;
                    //drpStep.Items.Insert(0, new ListItem("--Select--", "0"));

                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        protected void GetAllSchedule()
        {
            try
            {

                string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                var row = timeScheduleDal.GetDistinctSchedule();
                if (row.Count > 0)
                {
                    ddlShift.DataSource = row.ToList();
                    ddlShift.DataTextField = "ShiftName";
                    ddlShift.DataValueField = "ShiftCode";
                    ddlShift.DataBind();
                    ddlShift.AppendDataBoundItems = false;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        protected void ddlReportingTo_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int empId = Convert.ToInt32(ddlReportingTo.SelectedValue);

                List<RptBossDSG> rptBoss = empSetupDal.GetRptBossDSG(empId);

                if (rptBoss.Count > 0)
                {
                    foreach (var item in rptBoss)
                    {
                        txtRptBossDsg.Text = item.Deg_Name;
                    }
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

        //protected void ddlGrade_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
        //        int gradeID = Convert.ToInt32(ddlGrade.SelectedValue);
        //        var row = gradeDal.SelectByID(gradeID, OCODE);
        //        if (row.Count > 0)
        //        {
        //            var grd = row.Single();
        //            //txtGrsSal.Text = Convert.ToString(obj.GROSS_SAL) != null ? "?" + (String.Format("{##0.00}", Convert.ToString(obj.GROSS_SAL))) : string.Empty;
        //            txtGrossSalary.Text = String.Format("{0:#,##0.00;(#,##0.00);Nothing}", grd.GROSS_SAL);
        //            txtHouseRent.Text = String.Format("{0:#,##0.00;(#,##0.00);Nothing}", grd.HOUSE_RENT);
        //            txtBasic.Text = String.Format("{0:#,##0.00;(#,##0.00);Nothing}", grd.BASIC);
        //            txtMedical.Text = String.Format("{0:#,##0.00;(#,##0.00);Nothing}", grd.MEDICAL);
        //            txtConveyance.Text = String.Format("{0:#,##0.00;(#,##0.00);Nothing}", grd.CONVEYANCE);
        //            txtFoodAlloance.Text = String.Format("{0:#,##0.00;(#,##0.00);Nothing}", grd.FOOD_ALLOW);
        //            txtOthers.Text = String.Format("{0:#,##0.00;(-#,##0.00);Nothing}", grd.OTHERS);

        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        #endregion


        private void AllReportingBossUseThridReportingBoss()
        {
            try
            {
                string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                drpdwnThirdReportingBoss.DataSource = empSetupDal.GetPersonInfo().ToList();
                drpdwnThirdReportingBoss.DataTextField = "FirstName";
                drpdwnThirdReportingBoss.DataValueField = "EID";
                drpdwnThirdReportingBoss.DataBind();
                drpdwnThirdReportingBoss.Items.Insert(0, new ListItem("--Select--", "0"));
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }


        private void AllReportingBossUseSecondReportingBoss()
        {
            try
            {
                string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                drpSecondReportingTo.DataSource = empSetupDal.GetPersonInfo().ToList();
                drpSecondReportingTo.DataTextField = "FirstName";
                drpSecondReportingTo.DataValueField = "EID";
                drpSecondReportingTo.DataBind();
                drpSecondReportingTo.Items.Insert(0, new ListItem("--Select--", "0"));
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

        private void allReportingBoss()
        {
            try
            {
                string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                ddlReportingTo.DataSource = empSetupDal.GetPersonInfo().ToList();
                ddlReportingTo.DataTextField = "FirstName";
                ddlReportingTo.DataValueField = "EID";
                ddlReportingTo.DataBind();
                ddlReportingTo.Items.Insert(0, new ListItem("--Select--", "0"));
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

        private void AllDepartmentForThridReportingBoss()
        {
            try
            {
                string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                var row = departmentBll.GetAllDepartment(OCODE);
                if (row.Count > 0)
                {
                    drpdwnThridDepartment.DataSource = row.ToList();
                    drpdwnThridDepartment.DataTextField = "DPT_NAME";
                    drpdwnThridDepartment.DataValueField = "DPT_ID";
                    drpdwnThridDepartment.DataBind();
                    drpdwnThridDepartment.Items.Insert(0, new ListItem("--Select--"));
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

        private void AllDepartmentForSecondReportingBoss()
        {
            try
            {
                string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                var row = departmentBll.GetAllDepartment(OCODE);
                if (row.Count > 0)
                {
                    drpwownSecondDepartmetn.DataSource = row.ToList();
                    drpwownSecondDepartmetn.DataTextField = "DPT_NAME";
                    drpwownSecondDepartmetn.DataValueField = "DPT_ID";
                    drpwownSecondDepartmetn.DataBind();
                    drpwownSecondDepartmetn.Items.Insert(0, new ListItem("--Select--"));
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

        private void allDepartment()
        {
            try
            {
                string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                var row = departmentBll.GetAllDepartment(OCODE);
                if (row.Count > 0)
                {
                    drpFirstReportingDepartment.DataSource = row.ToList();
                    drpFirstReportingDepartment.DataTextField = "DPT_NAME";
                    drpFirstReportingDepartment.DataValueField = "DPT_ID";
                    drpFirstReportingDepartment.DataBind();
                    drpFirstReportingDepartment.Items.Insert(0, new ListItem("--Select--"));
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }


        //protected void txtbxThirdEditPerson_TextChanged(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        EMPOYEE_BLL employeeBll = new EMPOYEE_BLL();
        //        string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
        //        string eid = txtbxThirdEditPerson.Text;
        //        List<AssignTo> assignTos = new List<AssignTo>();
        //        assignTos = employeeBll.GetDesgination(eid, OCODE).ToList();
        //        foreach (AssignTo assign in assignTos)
        //        {
        //            txtbxThirdDesignation.Text = assign.DeginationName.ToString();
        //            drpdwnThridDepartment.SelectedValue = assign.DepartmentName.ToString();
        //            ddlReportingTo.SelectedValue = assign.EID;
        //        }

        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}
        protected void btnSavePersonalInfo_Click(object sender, EventArgs e)
        {
            try
            {

                if (lblStatusB.Text == "Machine-ID Conflict!")
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Machine-ID Conflict!')", true);

                }
                else if (lblStatus.Text == "E-ID Conflict!")
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('E-ID Conflict!')", true);
                }
                else
                {
                    HRM_PersonalInformations personalInfo = new HRM_PersonalInformations();

                    Session["EID"] = txtEID.Text.Trim();
                    personalInfo.EID = txtEID.Text.Trim();
                    personalInfo.BIO_MATRIX_ID = txtBioID.Text.Trim();
                    personalInfo.FirstName = txtFirstName.Text.Trim();
                    personalInfo.LastName = txtLastName.Text.Trim();
                    personalInfo.BanFullName = txtbxBangalFullName.Text.Trim();
                    personalInfo.Gender = ddlGender.Text.Trim();
                    personalInfo.DateOfBrith = Convert.ToDateTime(txtDOB.Text);
                    personalInfo.BloodGroup = ddlBloodGrp.Text.Trim();
                    personalInfo.FatherName = txtFatherName.Text.Trim();
                    personalInfo.MotherName = txtMotherName.Text.Trim();
                    personalInfo.MaritalStatus = ddlMariedSts.Text;
                    personalInfo.Religion = ddlReligion.Text;
                    personalInfo.Nationality = ddlNationality.Text;
                    personalInfo.EMP_TERMIN_STATUS = false;
                    personalInfo.EMP_TRANSFER_STATUS = false;
                    personalInfo.EMP_Retired_Status = false;
                    personalInfo.EMP_Resignation_Status = false;
                    personalInfo.EMP_Dismissal_Status = false;
                    personalInfo.EMP_Died_Status = false;
                    personalInfo.EMP_Other = false;
                    personalInfo.EMP_Dis_Continution_Status = false;
                    personalInfo.ConfiramtionDateStatus = false;
                    personalInfo.ContactNumber = txtContactNo.Text;
                    personalInfo.EmergencyContactNo = txtEmergencyContact.Text;
                    personalInfo.Email = txtEmailD.Text;
                    personalInfo.EmergencyContactPerson = txtbxEmergencyContactPerson.Text;
                    personalInfo.EmergencyAddress = txtbxEmergencyAddress.Text;
                    personalInfo.FatherAge = txtbxFatherAge.Text;
                    personalInfo.FatherProfession = txtbxFatherProfession.Text;
                    personalInfo.MotherAge = txtbxMotherAge.Text;
                    personalInfo.MotherProfession = txtbxMotherProfession.Text;
                    personalInfo.SpouseName = txtbxSpouseName.Text;
                    personalInfo.SpouseAge = txtbxSpouseAge.Text;
                    personalInfo.SpouseProfession = txtbxSpouseProfession.Text;
                    personalInfo.NumberOfChildren = txtbxNumberOfChildren.Text;
                    personalInfo.ChildrenNameRemark = txtbxChildrenNameRemark.Text;
                    personalInfo.AlternativEmailAddress = txtbxAlternative.Text;
                    personalInfo.NomineeName = txtNomineeName.Text;
                    personalInfo.NomineeAge = txtNomineeAge.Text;
                    personalInfo.NomineeRelation = txtNomineeRelation.Text;
                    personalInfo.PresentAddress = txtPresentAddr.Text;
                    personalInfo.PermanenAddress = txtPermanentAddress.Text;
                    personalInfo.NationalID = txtbxNId.Text;
                    personalInfo.ContactPersonRelationName = txtbxConactPersonRelationName.Text;
                    personalInfo.ShiftCode="01";
                    personalInfo.EDIT_DATE = DateTime.Now;
                    personalInfo.EDIT_USER = ((SessionUser)Session["SessionUser"]).UserId;
                    personalInfo.OCODE = ((SessionUser)Session["SessionUser"]).OCode;

                    if (btnSavePersonalInfo.Text == "Save")
                    {
                        int result = employeeSetUpBll.InsertPersonalInfo(personalInfo);
                        if (result == 1)
                        {
                            //lblMessage.Text = "Data Save Successfully.";
                            TabContainer1.ActiveTabIndex = 1;
                            TabContainer1.Tabs[2].Enabled = false;
                            TabContainer1.Tabs[3].Enabled = false;
                            TabContainer1.Tabs[4].Enabled = false;
                            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Data Save successfully!')", true);
                        }
                        else
                        {

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

        protected void txtDOB_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DateTime dateOfBirth = Convert.ToDateTime(txtDOB.Text);
                var now = float.Parse(DateTime.Now.ToString("yyyy.MMdd"));
                var dob = float.Parse(dateOfBirth.ToString("yyyy.MMdd"));
                var age = (int)(now - dob);
                txtbxTotalAge.Text = age.ToString();

                if (age < 18)
                {
                    string dates = age.ToString();
                    lblage.Text = dates;
                    divAge.Visible = true;
                }
                else
                {
                    divAge.Visible = false;
                }


            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

        protected void btnSaveBankInfo_Click(object sender, EventArgs e)
        {
            BankBLL BankBllObj = new BankBLL();
            try
            {
                HRM_BankInfo bankObj = new HRM_BankInfo();
                string EmployeeId = Convert.ToString(Session["EID"]);
                if (EmployeeId !="")
                {
                    bankObj.EID = EmployeeId;
                    bankObj.BankName = txtbxBankName.Text;
                    bankObj.Address = txtbxAddress.Text;
                    bankObj.MobileBankName = txtbxMobileBankName.Text;
                    bankObj.MobileNo = txtbxMobileNo.Text;
                    bankObj.AccountNo = txtbxAcNo.Text;
                    bankObj.Branch = txtbxBranch.Text;
                    bankObj.EDIT_DATE = DateTime.Now;
                    bankObj.EDIT_USER = ((SessionUser)Session["SessionUser"]).UserId;
                    bankObj.OCODE = ((SessionUser)Session["SessionUser"]).OCode;

                    int result = BankBllObj.BankInfoSave(bankObj);
                    if (result == 1)
                    {
                        //lblBankMg.Text = "Data Save Successfully";
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Data Save successfully!')", true);

                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Please Enter Employee Details First.')", true);
                }
            }
           catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }
        private bool CheckDesignation(string Desgination, string Grad, decimal Gosssalary)
        {
            SalaryUpdate_BLL salaryupdateBll = new SalaryUpdate_BLL();
            try
            {
                bool Status = salaryupdateBll.CheckDesignation(Desgination, Grad, Gosssalary);
                return Status;
            }
            catch (Exception)
            {

                throw;
            }

        }

        protected void btnSaveEmploymentInfo_Click(object sender, EventArgs e)
        {
            try
            {
                HRM_PersonalInformations personalInfo = new HRM_PersonalInformations();
                string grossSalary;
                personalInfo.Grade = txtbxGarde.Text;
                grossSalary = txtbxGrossSalary.Text.ToString();
                personalInfo.Salary = Convert.ToDecimal(grossSalary);

                string DesginationName = drpdwnDesigantion.SelectedItem.ToString();
                bool Status = CheckDesignation(DesginationName, Convert.ToString(personalInfo.Grade), Convert.ToDecimal(personalInfo.Salary));
                if (Status == false)
                {

                    //decimal medical = 200;
                    //decimal withoutMedical = (GrossSalary - medical);
                    //decimal houseRent = (withoutMedical * 44) / 100;
                    //decimal Basic = (withoutMedical * 56) / 100;

                    //Change Logic Provide By MasumVai ----- Edited------- Kamruzzaman.
                    double gross_Salary = Convert.ToDouble(personalInfo.Salary);
                    double medical = 250;
                    double taransport = 200;
                    double food = 650;
                    double withoutMedical = (gross_Salary - (medical + taransport + food));
                    double Basic = (withoutMedical) / 1.4;
                    double houseRent = (Basic * 40) / 100;

                    HRM_DESIGNATIONS designationObj = new HRM_DESIGNATIONS();
                    designationObj.DEG_NAME = drpdwnDesigantion.SelectedItem.ToString();
                    designationObj.GRADE = personalInfo.Grade;
                    designationObj.GROSS_SAL = Convert.ToDecimal(gross_Salary);
                    designationObj.HOUSE_RENT = Convert.ToDecimal(houseRent);
                    designationObj.BASIC = Convert.ToDecimal(Basic);
                    designationObj.MEDICAL = Convert.ToDecimal(medical);
                    designationObj.CONVEYANCE = Convert.ToDecimal(taransport);
                    designationObj.FOOD_ALLOW = Convert.ToDecimal(food);

                    designationObj.EDIT_USER = ((SessionUser)Session["SessionUser"]).UserId;
                    designationObj.EDIT_DATE = DateTime.Now;
                    designationObj.OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                    int resultforDesgination = objDeg_BLL.InsertDeignation(designationObj);

                }

                HRM_DESIGNATIONS _Desobj = objDeg_BLL.GetDesignationId(DesginationName, Convert.ToString(personalInfo.Grade), Convert.ToDecimal(personalInfo.Salary));
                if (_Desobj != null)
                {

                    string EmployeeId = Convert.ToString(Session["EID"]);
                    personalInfo.JoiningDate = Convert.ToDateTime(txtbxJoiningDate.Text);
                    personalInfo.RegionsId = Convert.ToInt32(drpRegion.SelectedValue);
                    personalInfo.OfficeId = Convert.ToInt32(ddlOffice.SelectedValue);
                    personalInfo.DepartmentId = Convert.ToInt32(ddlDepartment.SelectedValue);
                    personalInfo.SectionId = Convert.ToInt32(ddlSection.SelectedValue);
                    personalInfo.SubSectionId = Convert.ToInt32(ddlSubSections.SelectedValue);
                    personalInfo.DesginationId = _Desobj.DEG_ID;
                    personalInfo.Salary = _Desobj.GROSS_SAL;
                    personalInfo.ProbationPeriodFrom = Convert.ToDateTime(txtboxProbationPeriodFrom.Text);
                    personalInfo.ProbationPeriodTo = Convert.ToDateTime(txtbxProbationPeriodTo.Text);
                    personalInfo.ConfiramtionDate = Convert.ToDateTime(txtbxConfirmationDate.Text);
                    if (drpdwnOTApplicable.SelectedValue == "0")
                    {
                        personalInfo.OTApplicable = false;
                    }
                    else
                    {
                        personalInfo.OTApplicable = Convert.ToBoolean(drpdwnOTApplicable.SelectedValue);
                    }

                    if (drpAttendanceBounsApplicable.SelectedValue == "0")
                    {
                        personalInfo.Attendance_Bouns = false;
                    }
                    else
                    {
                        personalInfo.Attendance_Bouns = Convert.ToBoolean(drpAttendanceBounsApplicable.SelectedValue);
                    }

                    if (drpLateAllow.SelectedValue == "0")
                    {
                        personalInfo.Late_Applicable = false;
                    }
                    else
                    {
                        personalInfo.Late_Applicable = Convert.ToBoolean(drpLateAllow.SelectedValue);
                    }
                    if (drpAbsentAllow.SelectedValue == "0")
                    {
                        personalInfo.Absence_Applicable = false;
                    }
                    else
                    {
                        personalInfo.Absence_Applicable = Convert.ToBoolean(drpAbsentAllow.SelectedValue);
                    }

                    if (drpTaxApplicable.SelectedValue == "0")
                    {
                        personalInfo.Tax_Applicable = false;
                    }
                    else
                    {
                        personalInfo.Tax_Applicable = Convert.ToBoolean(drpTaxApplicable.SelectedValue);
                    }

                    if (drpPfApplicable.SelectedValue == "0")
                    {
                        personalInfo.PF_Applicable = false;
                    }
                    else
                    {
                        personalInfo.PF_Applicable = Convert.ToBoolean(drpPfApplicable.SelectedValue);
                    }

                    personalInfo.EffectiveSalaryStatus = false;
                    personalInfo.EffectiveSlary = Convert.ToDecimal(txtxEffectiveSlary.Text);
                    personalInfo.EmployeeType = Convert.ToInt16(drpEmployeeType.SelectedValue);
                    personalInfo.EmpCategoryId = Convert.ToInt16(drpEmployeeCate.SelectedValue);
                    // personalInfo.DEG_ID = Convert.ToInt32(ddlDesignations.SelectedValue);
                    //personalInfo.ShiftId = Convert.ToInt32(ddlShift.SelectedValue);
                    personalInfo.ShiftCode = ddlShift.SelectedValue.ToString();
                    // personalInfo.ReportingBossId = ddlReportingTo.SelectedValue;
                    //personalInfo.DesginationId = Convert.ToInt32(ddlDesignations.SelectedValue);
                    personalInfo.JobResponsibility = txtbxJobResponsibility.Text;
                    personalInfo.EDIT_DATE = DateTime.Now;
                    personalInfo.EDIT_USER = ((SessionUser)Session["SessionUser"]).UserId;
                    personalInfo.OCODE = ((SessionUser)Session["SessionUser"]).OCode;

                    if (EmployeeId != null)
                    {

                        int result = employeeSetUpBll.InsertPersonalInfoemployemetPart(EmployeeId, personalInfo);
                        if (result == 1)
                        {
                            //if (txtbxGarde.Text == null || txtbxGarde.Text == "" || txtbxGrossSalary.Text == null || txtbxGrossSalary.Text == "")
                            //{




                            //    //decimal basic = Convert.ToDecimal(GrossSalary);
                            //    //decimal TotalBaic = (basic * 40) / 100;

                            //    //decimal basicForHouseRent = Convert.ToDecimal(GrossSalary);
                            //    //decimal TotalHouseRent = (basicForHouseRent * 20) / 100;

                            //    //decimal basicFortxtMedical = Convert.ToDecimal(GrossSalary);
                            //    //decimal TotaltxtMedical = (basicFortxtMedical * 5) / 100;

                            //    //decimal basicFortxtConveyance = Convert.ToDecimal(GrossSalary);
                            //    //decimal TotaltxtConveyance = (basicFortxtConveyance * 5) / 100;


                            //    //decimal basicFortxtFixedAllowance = Convert.ToDecimal(GrossSalary);
                            //    //decimal TotaltxttxtfiexAllowance = (basicFortxtFixedAllowance * 30) / 100;





                            //    if (result == 1)
                            //    {
                            //        //Label2.Text = "Data Save successfully!";
                            //        //lblMessage.ForeColor = System.Drawing.Color.Green;
                            //        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Data Save successfully!')", true);

                            //    }
                            //}


                            //Label2.Text = "Data Save Successfully.";
                            TabContainer1.Tabs[1].Enabled = true;
                            TabContainer1.Tabs[3].Enabled = true;
                            TabContainer1.Tabs[4].Enabled = true;
                            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Data Save successfully!')", true);
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }

        }

        #region  ------------------------ Get Nationality List ----------------------

        public List<string> GetCountryList()
        {
            //List<string> cultureList = new List<string>();
            //CultureInfo[] cultures = CultureInfo.GetCultures(CultureTypes.AllCultures & ~CultureTypes.NeutralCultures);

            //cultureList.Add("-- Select Country --");

            //foreach (CultureInfo culture in cultures)
            //{
            //    CultureTypes ct = culture.CultureTypes;
            //    String s = ct.ToString();
            //    if (!s.Contains("NeutralCultures"))
            //    {
            //        // check if it's not a invariant culture
            //        if (culture.LCID != 127)
            //        {

            //            RegionInfo region = new RegionInfo(culture.LCID);
            //            // add countries that are not in the list
            //            if (!(cultureList.Contains(region.EnglishName)))
            //            {
            //                cultureList.Add(region.EnglishName);
            //            }
            //        }
            //    }
            //}
            //cultureList.Sort(); // sort alphabetically
            ERPSSLHBEntities _con = new ERPSSLHBEntities();
            var query = (from hl in _con.HRM_CounteryNationality
                         select hl.ConteryNationality);

            var list = query.ToList();
            return list;



        }

        public void BindNationality()
        {
            ddlNationality.DataSource = GetCountryList();
            ddlNationality.DataBind();
            ddlNationality.Items.Insert(0, new ListItem("Bangladeshi", "13"));
        }

        #endregion

        #region ------------------ Check Unique EID/Bio-Matrix-ID -----------------

        protected void txtEID_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string Requested_Eid = txtEID.Text;
                string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                GlobalClass.IsEidValid = employeeSetUpBll.CheckEidExitance(OCODE, Requested_Eid);
                if (GlobalClass.IsEidValid > 0)
                {
                    Checkusername.Visible = true;
                    imgstatus.ImageUrl = "resources/ico/cross.png";
                    lblStatus.Text = "E-ID Conflict!";
                    lblStatus.ForeColor = System.Drawing.Color.Red;
                    System.Threading.Thread.Sleep(2000);
                }
                else
                {
                    Checkusername.Visible = true;
                    imgstatus.ImageUrl = "resources/ico/tick.png";
                    lblStatus.Text = "E-ID Accepted!";
                    lblStatus.ForeColor = System.Drawing.Color.Green;
                    System.Threading.Thread.Sleep(2000);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

        #endregion

        #region ------------------ Check Unique EID/Bio-Matrix-ID -----------------

        protected void txtBioID_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string Requested_Eid = txtBioID.Text;
                string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                GlobalClass.IsEidValid = employeeSetUpBll.CheckBioIDExitance(OCODE, Requested_Eid);
                if (GlobalClass.IsEidValid > 0)
                {
                    CheckusernameB.Visible = true;
                    imgstatusB.ImageUrl = "resources/ico/cross.png";
                    lblStatusB.Text = "Machine-ID Conflict!";
                    lblStatusB.ForeColor = System.Drawing.Color.Red;
                    System.Threading.Thread.Sleep(2000);
                }
                else
                {
                    CheckusernameB.Visible = true;
                    imgstatusB.ImageUrl = "resources/ico/tick.png";
                    lblStatusB.Text = "Machine-ID Accepted!";
                    lblStatusB.ForeColor = System.Drawing.Color.Green;
                    System.Threading.Thread.Sleep(2000);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

        #endregion

        protected void drpRegion_SelecttedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                int RegionId = Convert.ToInt16(drpRegion.SelectedValue);
                var row = officeBll.GetOfficeByResionIdAndCode(RegionId, OCODE).ToList();
                if (row.Count > 0)
                {
                    ddlOffice.DataSource = row.ToList();
                    ddlOffice.DataTextField = "OfficeName";
                    ddlOffice.DataValueField = "OfficeID";
                    ddlOffice.DataBind();
                    ddlOffice.Items.Insert(0, new ListItem("--Select--", "0"));
                }

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

        protected void ddlGrade_SelecttedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string Designatin = drpdwnDesigantion.SelectedItem.ToString();
                string Grade = ddlGrade.SelectedItem.ToString();
                txtbxGarde.Text = Grade;
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

        protected void ddlOffice_SelecttedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                int officeId = Convert.ToInt16(ddlOffice.SelectedValue);
                var row = departmentBll.GetDepartmentByOfficeIdAndOCode(officeId, OCODE).ToList();
                if (row.Count > 0)
                {
                    ddlDepartment.DataSource = row.ToList();
                    ddlDepartment.DataTextField = "DPT_NAME";
                    ddlDepartment.DataValueField = "DPT_ID";
                    ddlDepartment.DataBind();
                    ddlDepartment.Items.Insert(0, new ListItem("--Select--", "0"));
                }

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

        protected void ddlDepartment_SelecttedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                int departmentId = Convert.ToInt16(ddlDepartment.SelectedValue);
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

        protected void drpStep_SelecttedIndexChanged(object sender, EventArgs e)
        {

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

        //protected void ddlGrade_SelecttedIndexChanged(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
        //        int gradeId = Convert.ToInt16(ddlGrade.SelectedValue);

        //        List<HRM_GRADE> grades = gradeBll.GetGradeInformationBygradeIdAndOcode(gradeId, OCODE).ToList();
        //        if (grades.Count > 0)
        //        {
        //            foreach (HRM_GRADE grade in grades)
        //            {
        //                txtGrossSalary.Text = grade.GROSS_SAL.ToString();
        //                txtConveyance.Text = grade.CONVEYANCE.ToString();
        //                txtMedical.Text = grade.MEDICAL.ToString();
        //                txtOthers.Text = grade.OTHERS.ToString();
        //                txtHouseRent.Text = grade.HOUSE_RENT.ToString();
        //                txtBasic.Text = grade.BASIC.ToString();
        //                txtFoodAlloance.Text = grade.FOOD_ALLOW.ToString();
        //            }
        //        }

        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}

        protected void ddlReportingTo_SelecttedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                EMPOYEE_BLL employeeBll = new EMPOYEE_BLL();
                string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                //int eid = Convert.ToInt16(ddlReportingTo.SelectedValue);
                string eid = ddlReportingTo.SelectedValue.ToString();
                List<AssignTo> assignTos = new List<AssignTo>();
                assignTos = employeeBll.GetDesgination(eid, OCODE).ToList();
                foreach (AssignTo assign in assignTos)
                {
                    txtRptBossDsg.Text = assign.DeginationName.ToString();
                    txtbxAssignToId.Text = assign.EID.ToString();
                }

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

        protected void btnSignatureUpload_Click(object sender, EventArgs e)
        {

            try
            {
                HRM_PersonalInformations personalInfo = new HRM_PersonalInformations();
                using (ERPSSLHBEntities _context = new ERPSSLHBEntities())
                {
                    HttpPostedFile file = (HttpPostedFile)(FileUpload2.PostedFile);

                    byte[] pic = null;
                    int len = FileUpload2.PostedFile.ContentLength;
                    if (len > 0)
                    {
                        pic = new byte[len];
                        FileUpload2.PostedFile.InputStream.Read(pic, 0, len);
                    }

                    if (FileUpload2.HasFile)
                    {
                        pic = ResizeImageFile(pic, 300);
                        // personalInfo.EID = Convert.ToString(Session["EID"]);
                        GlobalClass.employeeID = personalInfo.EID = Convert.ToString(Session["EID"]);
                        string OCODE = personalInfo.OCODE = ((SessionUser)Session["SessionUser"]).OCode;

                        HRM_PersonalInformations obj = _context.HRM_PersonalInformations.First(x => x.EID == personalInfo.EID);
                        obj.EMP_Singnature = personalInfo.EMP_Singnature = pic;
                        _context.SaveChanges();
                        Image1.ImageUrl = "EmployeeSignature.ashx?eId=" + GlobalClass.employeeID + "&oCode=" + OCODE;
                        //lblImagemessage.Text = "Image Save Successfully";

                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Image Save Successfully!')", true);
                    }
                }
            }

            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }//SOHEL
        protected void btnimageUpload_Click(object sender, EventArgs e)
        {
            try
            {
                Page.Form.Attributes.Add("enctype", "multipart/form-data");
                HRM_PersonalInformations personalInfo = new HRM_PersonalInformations();
                using (ERPSSLHBEntities _context = new ERPSSLHBEntities())
                {
                    HttpPostedFile file = (HttpPostedFile)(FileUpload1.PostedFile);

                    byte[] pic = null;
                    int len = FileUpload1.PostedFile.ContentLength;
                    if (len > 0)
                    {
                        pic = new byte[len];
                        FileUpload1.PostedFile.InputStream.Read(pic, 0, len);
                    }

                    if (FileUpload1.HasFile)
                    {
                        pic = ResizeImageFile(pic, 300);

                        // personalInfo.EID = Convert.ToString(Session["EID"]);
                        GlobalClass.employeeID = personalInfo.EID = Convert.ToString(Session["EID"]);
                        string OCODE = personalInfo.OCODE = ((SessionUser)Session["SessionUser"]).OCode;

                        HRM_PersonalInformations obj = _context.HRM_PersonalInformations.First(x => x.EID == personalInfo.EID);
                        obj.EMP_PHOTO = personalInfo.EMP_PHOTO = pic;
                        _context.SaveChanges();
                        Emp_IMG_TRNS.ImageUrl = "EmployeeIMG.ashx?eId=" + GlobalClass.employeeID + "&oCode=" + OCODE;
                        //lblImagemessage.Text = "Image Save Successfully";
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Image Save Successfully!')", true);
                    }
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }// SOHEL
        public static byte[] ResizeImageFile(byte[] imageFile, int targetSize)
        {
            try
            {
                using (System.Drawing.Image oldImage = System.Drawing.Image.FromStream(new MemoryStream(imageFile)))
                {
                    Size newSize = CalculateDimensions(oldImage.Size, targetSize);
                    using (Bitmap newImage = new Bitmap(newSize.Width, newSize.Height, PixelFormat.Format16bppRgb555))
                    {
                        using (Graphics canvas = Graphics.FromImage(newImage))
                        {
                            canvas.SmoothingMode = SmoothingMode.AntiAlias;
                            canvas.InterpolationMode = InterpolationMode.HighQualityBicubic;
                            canvas.PixelOffsetMode = PixelOffsetMode.HighQuality;
                            canvas.DrawImage(oldImage, new Rectangle(new Point(0, 0), newSize));
                            MemoryStream m = new MemoryStream();
                            newImage.Save(m, ImageFormat.Jpeg);
                            return m.GetBuffer();
                        }
                    }
                }
            }
            catch
            {
                return null;
            }


        }//SOHEL
        public static Size CalculateDimensions(Size oldSize, int targetSize)
        {
            Size newSize = new Size();
            if (oldSize.Height > oldSize.Width)
            {
                newSize.Width = (int)(oldSize.Width * ((float)targetSize / (float)oldSize.Height));
                newSize.Height = targetSize;
            }
            else
            {
                newSize.Width = targetSize;
                newSize.Height = (int)(oldSize.Height * ((float)targetSize / (float)oldSize.Width));
            }
            return newSize;
        }//SOHEL
        protected void btnNominee_Click(object sender, EventArgs e)
        {
            try
            {
                HRM_PersonalInformations personalInfo = new HRM_PersonalInformations();
                using (ERPSSLHBEntities _context = new ERPSSLHBEntities())
                {
                    HttpPostedFile file = (HttpPostedFile)(FileUpload3.PostedFile);

                    byte[] pic = null;
                    int len = FileUpload3.PostedFile.ContentLength;
                    if (len > 0)
                    {
                        pic = new byte[len];
                        FileUpload3.PostedFile.InputStream.Read(pic, 0, len);
                    }

                    if (FileUpload3.HasFile)
                    {
                        pic = ResizeImageFile(pic, 300);
                        // personalInfo.EID = Convert.ToString(Session["EID"]);
                        GlobalClass.employeeID = personalInfo.EID = Convert.ToString(Session["EID"]);
                        string OCODE = personalInfo.OCODE = ((SessionUser)Session["SessionUser"]).OCode;

                        HRM_PersonalInformations obj = _context.HRM_PersonalInformations.First(x => x.EID == personalInfo.EID);
                        obj.Nomine_Photo = personalInfo.Nomine_Photo = pic;
                        _context.SaveChanges();
                        Image2.ImageUrl = "NomineeImageHandaler.ashx?eId=" + GlobalClass.employeeID + "&oCode=" + OCODE;
                        //lblImagemessage.Text = "Image Save Successfully";
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Image Save Successfully!')", true);
                    }
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }//SOHEL

        protected void btnAssignTo_Click(object sender, EventArgs e)
        {
            try
            {
                HRM_PersonalInformations personalInfo = new HRM_PersonalInformations();
                string EmployeeId = Convert.ToString(Session["EID"]);

                if (ddlReportingTo.Text != "--Select--")
                {
                    personalInfo.ReportingBossId = drpdwnThridDepartment.SelectedValue.ToString();
                }
                else
                {
                    personalInfo.ReportingBossId = null;
                }


                if (drpSecondReportingTo.Text != "--Select--")
                {
                    personalInfo.SecondReportingBossId = drpdwnThridDepartment.SelectedValue.ToString();
                }
                else
                {
                    personalInfo.SecondReportingBossId = null;
                }

                if (drpdwnThridDepartment.Text != "--Select--")
                {
                    personalInfo.ThirdReportingBossId = drpdwnThridDepartment.SelectedValue.ToString();
                }
                else
                {
                    personalInfo.ThirdReportingBossId = null;
                }


                if (EmployeeId != null)
                {
                    int result = employeeSetUpBll.InsertPersonalInfoAssignTo(EmployeeId, personalInfo);
                    if (result == 1)
                    {
                        //lblAssignTo.Text = "Data Save Successfully.";

                        TabContainer1.Tabs[1].Enabled = true;
                        TabContainer1.Tabs[3].Enabled = true;
                        TabContainer1.Tabs[4].Enabled = true;
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Data Save successfully!')", true);
                    }
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }
        protected void drpSecondReportingTo_SelecttedIndexChanged(object sender, EventArgs e)
        {

            try
            {
                EMPOYEE_BLL employeeBll = new EMPOYEE_BLL();
                string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                //int eid = Convert.ToInt16(ddlReportingTo.SelectedValue);
                string eid = drpSecondReportingTo.SelectedValue.ToString();
                List<AssignTo> assignTos = new List<AssignTo>();
                assignTos = employeeBll.GetDesgination(eid, OCODE).ToList();
                foreach (AssignTo assign in assignTos)
                {
                    txtbxSecondDesignation.Text = assign.DeginationName.ToString();
                    drpwownSecondDepartmetn.SelectedValue = assign.DepartmentId.ToString();
                    txtbxSecondEdit.Text = assign.EID.ToString();
                }

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

        protected void drpFirstReportingDepartment_SelecttedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (drpFirstReportingDepartment.Text != "--Select--")
                {

                    int departmentId = Convert.ToInt16(drpFirstReportingDepartment.SelectedValue);
                    string Ocode = ((SessionUser)Session["SessionUser"]).OCode;
                    List<ReportingBoss> personalInfos = objEmp_BLL.GetPersonalInfoes(Ocode, departmentId);
                    if (personalInfos.Count > 0)
                    {
                        ddlReportingTo.DataSource = personalInfos;
                        ddlReportingTo.DataTextField = "FulllName";
                        ddlReportingTo.DataValueField = "EID";
                        ddlReportingTo.DataBind();
                        ddlReportingTo.Items.Insert(0, new ListItem("--Select--", "0"));
                    }
                }

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }


        protected void txtbxSecondEdit_TextChanged(object sender, EventArgs e)
        {
            try
            {
                EMPOYEE_BLL employeeBll = new EMPOYEE_BLL();
                string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                string eid = txtbxSecondEdit.Text;
                List<AssignTo> assignTos = new List<AssignTo>();
                assignTos = employeeBll.GetDesgination(eid, OCODE).ToList();
                foreach (AssignTo assign in assignTos)
                {
                    AllDepartmentForSecondReportingBoss();
                    AllReportingBossUseSecondReportingBoss();
                    txtbxSecondDesignation.Text = assign.DeginationName.ToString();
                    drpwownSecondDepartmetn.SelectedValue = assign.DepartmentId.ToString();
                    drpSecondReportingTo.SelectedValue = assign.EID;
                }

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }
        protected void drpwownSecondDepartmetn_SelecttedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (drpwownSecondDepartmetn.Text != "--Select--")
                {
                    int departmentId = Convert.ToInt16(drpwownSecondDepartmetn.SelectedValue);
                    string Ocode = ((SessionUser)Session["SessionUser"]).OCode;
                    List<ReportingBoss> personalInfos = objEmp_BLL.GetPersonalInfoes(Ocode, departmentId);
                    if (personalInfos.Count > 0)
                    {
                        drpSecondReportingTo.DataSource = personalInfos;
                        drpSecondReportingTo.DataTextField = "FulllName";
                        drpSecondReportingTo.DataValueField = "EID";
                        drpSecondReportingTo.DataBind();
                        drpSecondReportingTo.Items.Insert(0, new ListItem("--Select--", "0"));
                    }
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }
        protected void txtbxAssignToId_TextChanged(object sender, EventArgs e)
        {
            try
            {
                EMPOYEE_BLL employeeBll = new EMPOYEE_BLL();
                string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                string eid = txtbxAssignToId.Text;
                List<AssignTo> assignTos = new List<AssignTo>();
                assignTos = employeeBll.GetDesgination(eid, OCODE).ToList();
                foreach (AssignTo assign in assignTos)
                {
                    allDepartment();
                    allReportingBoss();
                    txtRptBossDsg.Text = assign.DeginationName.ToString();
                    drpFirstReportingDepartment.SelectedValue = assign.DepartmentId.ToString();
                    ddlReportingTo.SelectedValue = assign.EID;
                }

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

        protected void drpdwnThridDepartment_SelecttedIndexChanged(object sender, EventArgs e)
        {

            try
            {
                if (drpdwnThridDepartment.Text != "--Select--")
                {
                    int departmentId = Convert.ToInt16(drpdwnThridDepartment.SelectedValue);
                    string Ocode = ((SessionUser)Session["SessionUser"]).OCode;
                    List<ReportingBoss> personalInfos = objEmp_BLL.GetPersonalInfoes(Ocode, departmentId);
                    if (personalInfos.Count > 0)
                    {
                        drpdwnThirdReportingBoss.DataSource = personalInfos;
                        drpdwnThirdReportingBoss.DataTextField = "FulllName";
                        drpdwnThirdReportingBoss.DataValueField = "EID";
                        drpdwnThirdReportingBoss.DataBind();
                        drpdwnThirdReportingBoss.Items.Insert(0, new ListItem("--Select--", "0"));
                    }
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

        protected void txtbxThirdEditPerson_TextChanged(object sender, EventArgs e)
        {
            try
            {
                EMPOYEE_BLL employeeBll = new EMPOYEE_BLL();
                string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                string eid = txtbxThirdEditPerson.Text;
                List<AssignTo> assignTos = new List<AssignTo>();
                assignTos = employeeBll.GetDesgination(eid, OCODE).ToList();
                foreach (AssignTo assign in assignTos)
                {
                    AllDepartmentForThridReportingBoss();
                    AllReportingBossUseThridReportingBoss();

                    txtbxThirdDesignation.Text = assign.DeginationName.ToString();
                    drpdwnThridDepartment.SelectedValue = assign.DepartmentId.ToString();
                    drpdwnThirdReportingBoss.SelectedValue = assign.EID;
                }

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

        protected void drpdwnThirdReportingBoss_SelecttedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                EMPOYEE_BLL employeeBll = new EMPOYEE_BLL();
                string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                //int eid = Convert.ToInt16(ddlReportingTo.SelectedValue);
                string eid = drpdwnThirdReportingBoss.SelectedValue.ToString();
                List<AssignTo> assignTos = new List<AssignTo>();
                assignTos = employeeBll.GetDesgination(eid, OCODE).ToList();
                foreach (AssignTo assign in assignTos)
                {
                    txtbxThirdDesignation.Text = assign.DeginationName.ToString();
                    drpdwnThridDepartment.SelectedValue = assign.DepartmentId.ToString();
                    txtbxThirdEditPerson.Text = assign.EID.ToString();
                }

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

        protected void txtDob_TextChanged1(object sender, EventArgs e)
        {
            try
            {
                DateTime dateOfBirth = Convert.ToDateTime(txtChildrenDOB.Text);
                var now = float.Parse(DateTime.Now.ToString("yyyy.MMdd"));
                var dob = float.Parse(dateOfBirth.ToString("yyyy.MMdd"));
                var age = (int)(now - dob);
                txtbxChildrenAge.Text = age.ToString();

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                HRM_ChildInfo childInfo = new HRM_ChildInfo();
                childInfo.EID = Convert.ToString(Session["EID"]);
                childInfo.Age = Convert.ToInt16(txtbxChildrenAge.Text);
                childInfo.Name = txtbxChildrenName.Text;
                childInfo.DOB = Convert.ToDateTime(txtChildrenDOB.Text);
                childInfo.Gender = drpChildrenGender.SelectedItem.ToString();
                childInfo.EDIT_DATE = DateTime.Now;
                childInfo.EDIT_USER = ((SessionUser)Session["SessionUser"]).UserId;
                childInfo.OCODE = ((SessionUser)Session["SessionUser"]).OCode;

                if (btnSave.Text == "Update")
                {
                    int childrenId = Convert.ToInt32(hidchildren.Value);

                    int result = empSetupDal.UpdateChildrenInfo(childInfo, childrenId);
                    if (result == 1)
                    {
                        clearController();
                        string Eid = Convert.ToString(childInfo.EID);
                        childreansByEmployeeEID(Eid);
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Data Update successfully!')", true);
                    }
                }
                else
                {

                    int result = empSetupDal.SaveChildrenInfo(childInfo);
                    if (result == 1)
                    {
                        clearController();
                        string Eid = Convert.ToString(childInfo.EID);
                        childreansByEmployeeEID(Eid);
                        //childreInfomessage.Text = "Data Save Successfully";
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Data Save successfully!')", true);
                    }
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }
        private void clearController()
        {

            txtbxChildrenAge.Text = "";
            txtbxChildrenName.Text = "";
            txtChildrenDOB.Text = "";
            drpChildrenGender.ClearSelection();
            btnSave.Text = "Submit";
        }

        private void childreansByEmployeeEID(string Eid)
        {
            try
            {
                List<HRM_ChildInfo> childdreans = empSetupDal.GeChildreansByEID(Eid);
                if (childdreans.Count > 0)
                {
                    gridviewChildrenInfo.DataSource = childdreans;
                    gridviewChildrenInfo.DataBind();
                }
                else
                {
                    gridviewChildrenInfo.DataSource = null;
                    gridviewChildrenInfo.DataBind();
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

        protected void lblChildrenInfo_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            GridViewRow row = (GridViewRow)btn.NamingContainer;

            try
            {

                Label lblchildrenId = (Label)gridviewChildrenInfo.Rows[row.RowIndex].FindControl("lblChildrenID");
                if (lblchildrenId.Text != null)
                {
                    int childreanId = Convert.ToInt32(lblchildrenId.Text);

                    HRM_ChildInfo hrm_childinfo = empSetupDal.getChildrenById(childreanId);
                    if (hrm_childinfo != null)
                    {
                        txtbxChildrenName.Text = hrm_childinfo.Name;
                        txtChildrenDOB.Text = hrm_childinfo.DOB.ToString();
                        drpChildrenGender.Text = hrm_childinfo.Gender.ToString();
                        txtbxChildrenAge.Text = hrm_childinfo.Age.ToString();
                        hidchildren.Value = hrm_childinfo.ChildId.ToString();
                        btnSave.Text = "Update";
                    }
                }

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

        protected void txtbxProbationPeriodTo_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DateTime probationf = Convert.ToDateTime(txtboxProbationPeriodFrom.Text);
                DateTime probationT = Convert.ToDateTime(txtbxProbationPeriodTo.Text);
                txtbxTotalMonth.Text = Math.Abs((probationT.Month - probationf.Month) + 12 * (probationT.Year - probationf.Year)).ToString();
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }
        protected void GrossSalary_SelectedIndexChanged(object sender, EventArgs e)
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


        protected void txtbxJoiningDate_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DateTime JoiningDate = Convert.ToDateTime(txtbxJoiningDate.Text);
                string jodate = JoiningDate.ToString();
                string[] joindatetime = jodate.Split(' ');
                txtboxProbationPeriodFrom.Text = joindatetime[0].ToString();
                DateTime proTo = JoiningDate.AddMonths(3);
                string datewithTime = proTo.ToString();
                string[] prTo = datewithTime.Split(' ');
                txtbxProbationPeriodTo.Text = prTo[0].ToString();
                txtbxTotalMonth.Text = "3";
                txtbxConfirmationDate.Text = txtbxProbationPeriodTo.Text;
            }
            catch (Exception ex)
            {
                string EID = Convert.ToString(((SessionUser)Session["SessionUser"]).EID);
                //LogController<employeeSetup>.SetLog(ex, EID);
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }


    }
}
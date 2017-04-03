using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ERPSSL.HRM.DAL;
using ERPSSL.HRM.BLL;
using ERPSSL;

namespace ERPSSL.HRM.UserControls
{
    public partial class employementEdit : System.Web.UI.UserControl
    {
        EMPOYEE_BLL employeeBll = new EMPOYEE_BLL();
        EmployeeSetup_DAL empSetupDal = new EmployeeSetup_DAL();
        Region_DAL regionDal = new Region_DAL();
        Office_BLL officeBll = new Office_BLL();
        DEPARTMENT_BLL departmentBll = new DEPARTMENT_BLL();
        SECTION_BLL SectionBll = new SECTION_BLL();
        SUB_SECTION_DAL subSectionDal = new SUB_SECTION_DAL();
        SUB_SECTION_BLL subSectionBll = new SUB_SECTION_BLL();
        GRADE_BLL gradeBll = new GRADE_BLL();
        DESIGNATION_DAL designationDal = new DESIGNATION_DAL();
        TIME_SCHEDULE_DAL timeScheduleDal = new TIME_SCHEDULE_DAL();
        EmployeeSetup_BLL employeeSetUpBll = new EmployeeSetup_BLL();
        BankDAL bankDALObj = new BankDAL();
        GRADE_DAL gradeDal = new GRADE_DAL();
        EmployeeCategoryBLL emplobyeeCategoryBll = new EmployeeCategoryBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                string employeeid = Convert.ToString(Session["EID"]);
                if (employeeid != null)
                {
                    FillRegion();
                    GetEmployemntInfo(employeeid);
                    GetBankInfo(employeeid);
                    GetAllDesignation();
                    GetAllSchedule();
                    GetEmployeeType();
                    getEmployeeCategoryes();
                    //GetEmployeeType();
                    //FillReportingBossName();

                }
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

        private void GetBankInfo(string employeeid)
        {
            string Ocode = ((SessionUser)Session["SessionUser"]).OCode;
            List<HRM_BankInfo> bankInfo = bankDALObj.GetBankInfo(employeeid, Ocode);
            foreach (HRM_BankInfo abank in bankInfo)
            {
                lblBankName.Text = abank.BankName;
                lblAccountNumber.Text = abank.AccountNo;
                lblBranch.Text = abank.Branch;
                lblAddress.Text = abank.Address;
                lblMobileNo.Text = abank.MobileNo;
                lblMoboleBankName.Text = abank.MobileBankName;
                txbxMobileBankName.Text = abank.MobileBankName;
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
        //private void FillReportingBossName()
        //{
        //    try
        //    {
        //        //     string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
        //        ddlReportingTo.DataSource = empSetupDal.GetPersonInfo().ToList();
        //        ddlReportingTo.DataTextField = "FirstName";
        //        ddlReportingTo.DataValueField = "EID";
        //        ddlReportingTo.DataBind();
        //        ddlReportingTo.Items.Insert(0, new ListItem("--Select--", "0"));
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        // Employeement Data
        private void GetEmployemntInfo(string employeeid)
        {
            try
            {
                string Ocode = ((SessionUser)Session["SessionUser"]).OCode;

                HRM_PersonalInformations _personalInfo = employeeBll.getPersonalInfosByID(employeeid);

                if (_personalInfo.RegionsId != null)
                {

                    var employments = employeeBll.GetEmployemntInfo(employeeid, Ocode);
                    foreach (var item in employments)
                    {
                        lblRegion.Text = item.RegionName;
                        lblOffice.Text = item.OfficeName;
                        lblDepartment.Text = item.DepartmentName;
                        lblSection.Text = item.SectionName;
                        lblSubSction.Text = item.SubSectionName;
                        lblGrade.Text = item.GradeName;
                        lblDesignation.Text = item.Desgination;
                        lblCategoryName.Text = item.Category;
                        lblShit.Text = item.TimeShifting + "-" + item.ShiftCode;
                        lblJoiningDate.Text = ConvertDate(item.JoiningDate.ToString());
                        lblJobResposibility.Text = item.JobResponsibility;
                        lblEmployeeType.Text = item.EmployeeTypeName;
                        lblEffectiveSlary.Text = Convert.ToDecimal(item.EffectiveSlary).ToString("#,##0.00");
                        lblGrade.Text = item.Grade;
                        if (item.OTApplicable == true)
                        {
                            lblOtApplicable.Text = "Yes";
                        }
                        else
                        {
                            lblOtApplicable.Text = "No";
                        }

                        if (item.Attendance_Bouns == true)
                        {
                            lblAttendanceApplicable.Text = "Yes";
                        }
                        else
                        {
                            lblAttendanceApplicable.Text = "No";
                        }

                        if (item.Late_Applicable == true)
                        {
                            lblLateApplicable.Text = "Yes";
                        }
                        else
                        {
                            lblLateApplicable.Text = "No";
                        }

                        if (item.Absence_Applicable == true)
                        {
                            lblAbsenceApplicable.Text = "Yes";
                        }
                        else
                        {
                            lblAbsenceApplicable.Text = "No";
                        }

                        if (item.Tax_Applicable == true)
                        {
                            lblTaxApplicable.Text = "Yes";
                        }
                        else
                        {
                            lblTaxApplicable.Text = "No";
                        }

                        if (item.PF_Applicable == true)
                        {
                            lblPFApplicable.Text = "Yes";
                        }
                        else
                        {
                            lblPFApplicable.Text = "No";
                        }
                        // lblOtApplicable.Text = item.OTApplicable.ToString();
                        // lblAttendanceApplicable.Text = item.Attendance_Bouns.ToString();
                        //lblAbsenceApplicable.Text = item.Absence_Applicable.ToString();
                        // lblTaxApplicable.Text = item.Tax_Applicable.ToString();
                        // lblPFApplicable.Text = item.PF_Applicable.ToString();
                        // lblLateApplicable.Text = item.Late_Applicable.ToString();
                        lblProbationPeriodFrom.Text = ConvertDate(item.ProbationPeriodFrom.ToString());
                        lblProbationPeriodTo.Text = ConvertDate(item.ProbationPeriodTo.ToString());
                        lblConfirmationDate.Text = ConvertDate(item.ConfiramtionDate.ToString());
                        lblGossSalary.Text = Convert.ToDecimal(item.Salary).ToString("#,##0.00");

                        //lblReportingBoss.Text = item.ReportinBoss;

                        //Step-1
                        //int? step = item.Step;
                        //if (step == 1)
                        //{
                        //    lblStep.Text = "Step-1";
                        //}
                        //else if (step == 2)
                        //{
                        //    lblStep.Text = "Step-2";
                        //}
                        //else if (step == 3)
                        //{
                        //    lblStep.Text = "Step-3";
                        //}
                        //else if (step == 4)
                        //{
                        //    lblStep.Text = "Step-4";
                        //}
                        //else if (step == 5)
                        //{
                        //    lblStep.Text = "Step-5";
                        //}
                        //else if (step == 6)
                        //{
                        //    lblStep.Text = "Step-6";
                        //}

                        // Bank Info

                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        //
        private string ConvertDate(string DateTime)
        {
            string[] dattime = DateTime.Split(' ');
            return dattime[0];
        }

        protected void drpStep_SelecttedIndexChanged(object sender, EventArgs e)
        {

            try
            {


                string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                string De = ddlDesignations.SelectedItem.ToString();
                var row = gradeBll.GetGrateByDesginationName(De, OCODE).ToList();
                if (row.Count > 0)
                {
                    ddlGrade.DataSource = row;
                    ddlGrade.DataTextField = "Grade";
                    ddlGrade.DataValueField = "Grade";
                    ddlGrade.DataBind();
                    ddlGrade.Items.Insert(0, new ListItem("--Select--", "0"));
                }
                ModalPopupExtender.Show();
            }
            catch (Exception)
            {

                throw;
            }

        }




        protected void BtnEdit_Click(object sender, EventArgs e)
        {


            string employeeid = Convert.ToString(Session["EID"]);
            string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
            HRM_PersonalInformations personalObj = employeeBll.getPersonalInfosByID(employeeid);

            if (personalObj.RegionsId != null)
            {

                drpRegion.SelectedValue = personalObj.RegionsId.ToString();
                SetOfficeForDropdown(Convert.ToInt32(personalObj.RegionsId), OCODE);
                ddlOffice.SelectedValue = personalObj.OfficeId.ToString();
                getDepartmentSetForDropDown(Convert.ToInt32(personalObj.OfficeId), OCODE);
                ddlDepartment.SelectedValue = personalObj.DepartmentId.ToString();
                SetDepartmentForDropdown(Convert.ToInt32(personalObj.DepartmentId), OCODE);
                ddlSection.SelectedValue = personalObj.SectionId.ToString();
                SetSubSctionForDropdown(Convert.ToInt32(personalObj.SectionId), OCODE);
                ddlSubSections.SelectedValue = personalObj.SubSectionId.ToString();


                drpdwnOTApplicable.SelectedValue = personalObj.OTApplicable.ToString();
                drpAttandenceApplicable.SelectedValue = personalObj.Attendance_Bouns.ToString();
                drpAbsenceApplicable.SelectedValue = personalObj.Absence_Applicable.ToString();
                drpLateApplicable.SelectedValue = personalObj.Late_Applicable.ToString();
                drpTaxApplicable.SelectedValue = personalObj.Tax_Applicable.ToString();
                drpPFApplicable.SelectedValue = personalObj.PF_Applicable.ToString();
                string DesignationName = GetDesignationNameById(Convert.ToInt32(personalObj.DesginationId));
                ddlDesignations.SelectedValue = DesignationName.Trim();
                GetGrade(DesignationName);
                ddlGrade.SelectedValue = personalObj.Grade.ToString();
                txtbxGarde.Text = personalObj.Grade.ToString();
                txtbxGrossSalary.Text = personalObj.Salary.ToString();
                txtbxEffectiveSlary.Text = personalObj.EffectiveSlary.ToString();
                string Grade = personalObj.Grade.ToString();
                GetSalary(Grade, DesignationName);

                drpGrossSalary.SelectedValue = personalObj.Salary.ToString();

                if (personalObj.ShiftCode != null)
                {
                    ddlShift.SelectedValue = personalObj.ShiftCode.ToString();
                }


                txtbxJobResponsibility.Text = personalObj.JobResponsibility;
                txtbxJoingDate.Text = personalObj.JoiningDate.ToString();


                if (personalObj.ProbationPeriodFrom != null)
                {
                    txtbxProbationProbationPeriodFrom.Text = personalObj.ProbationPeriodFrom.ToString();
                }

                txtbxProbationPeriodTo.Text = personalObj.ProbationPeriodTo.ToString();
                txtbxConformationDate.Text = personalObj.ConfiramtionDate.ToString();

                if (personalObj.EmployeeType != null)
                {
                    drpEmployeeType.SelectedValue = personalObj.EmployeeType.ToString();
                }

                if (personalObj.EmpCategoryId != null)
                {
                    drpEmployeeCate.SelectedValue = personalObj.EmpCategoryId.ToString();
                }

            }
            btnedit.Visible = true;
            btnUpdate.Visible = true;
            ModalPopupExtender.Show();

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
            catch (Exception)
            {

                throw;
            }
        }

        private string GetDesignationNameById(int desginationId)
        {
            return gradeBll.GetDesignationNameById(desginationId);
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
            catch (Exception)
            {

                throw;
            }
        }

        private void GRADEByDes(string de)
        {
            try
            {
                string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                var row = gradeBll.GetGradeById(de, OCODE).ToList();
                if (row.Count > 0)
                {
                    ddlGrade.DataSource = row;
                    ddlGrade.DataTextField = "GRADE";
                    ddlGrade.DataValueField = "GRADE";
                    ddlGrade.DataBind();
                    ddlGrade.Items.Insert(0, new ListItem("--Select--", "0"));
                }
            }
            catch (Exception)
            {

                throw;
            }


        }
        protected void drpGrossSalary_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                txtbxGrossSalary.Text = drpGrossSalary.SelectedValue.ToString();
                ModalPopupExtender.Show();

            }
            catch (Exception)
            {

                throw;
            }
        }
        protected void ddlGrade_SelecttedIndexChanged(object sender, EventArgs e)
        {
            try
            {


                string Designatin = ddlDesignations.SelectedItem.ToString();
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
                ModalPopupExtender.Show();
            }
            catch (Exception)
            {

                throw;
            }
        }


        private void FillRegion()
        {
            try
            {
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

        protected void drpRegion_SelecttedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                int RegionId = Convert.ToInt16(drpRegion.SelectedValue);
                SetOfficeForDropdown(RegionId, OCODE);
                ModalPopupExtender.Show();
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void SetOfficeForDropdown(int RegionId, string OCODE)
        {
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

        protected void btnBanck_Update(object sender, EventArgs e)
        {
            try
            {
                string eid = "";
                string employeeid = Convert.ToString(Session["EID"]);
                string Ocode = ((SessionUser)Session["SessionUser"]).OCode;
                List<HRM_BankInfo> bankInfo = bankDALObj.GetBankInfo(employeeid, Ocode);
                foreach (HRM_BankInfo abank in bankInfo)
                {
                    eid = abank.EID;
                }

                HRM_BankInfo bankInfoObj = new HRM_BankInfo();
                bankInfoObj.EID = employeeid;
                bankInfoObj.BankName = txtbxBankName.Text;
                bankInfoObj.AccountNo = txtbxAc.Text;
                bankInfoObj.Branch = txtbxBranch.Text;
                bankInfoObj.Address = txtbxAddress.Text;
                bankInfoObj.MobileNo = txtbxMobileNO.Text;
                bankInfoObj.MobileBankName = txbxMobileBankName.Text;

                bankInfoObj.OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                bankInfoObj.EDIT_DATE = DateTime.Now;
                bankInfoObj.EDIT_USER = ((SessionUser)Session["SessionUser"]).UserId;
                if (eid != "")
                {
                    int result = bankDALObj.UpdateBankInfo(employeeid, bankInfoObj);
                    if (result == 1)
                    {
                        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "text", "func('Data Update successfully!')", true);
                        GetBankInfo(employeeid);
                    }
                }
                else
                {
                    int result = bankDALObj.BankInfoSave(bankInfoObj);
                    if (result == 1)
                    {
                        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "text", "func('Data Save successfully!')", true);
                        GetBankInfo(employeeid);
                    }

                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void ddlOffice_SelecttedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                int officeId = Convert.ToInt16(ddlOffice.SelectedValue);
                getDepartmentSetForDropDown(officeId, OCODE);
                ModalPopupExtender.Show();
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void getDepartmentSetForDropDown(int officeId, string OCODE)
        {
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

        protected void BtnBankInfo_Click(object sender, EventArgs e)
        {
            try
            {


                string employeeid = Convert.ToString(Session["EID"]);
                string Ocode = ((SessionUser)Session["SessionUser"]).OCode;
                List<HRM_BankInfo> bankInfo = bankDALObj.GetBankInfo(employeeid, Ocode);
                foreach (HRM_BankInfo abank in bankInfo)
                {
                    txtbxBankName.Text = abank.BankName;
                    txtbxAc.Text = abank.AccountNo;
                    txtbxBranch.Text = abank.Branch;
                    txtbxAddress.Text = abank.Address;
                    txtbxMobileNO.Text = abank.MobileNo;

                }


                btnBankDel.Visible = true;
                btnBankUpdate.Visible = true;
                ModalPopupExtender3.Show();
            }
            catch (Exception)
            {

                throw;
            }
        }


        protected void ddlDepartment_SelecttedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                int departmentId = Convert.ToInt16(ddlDepartment.SelectedValue);
                SetDepartmentForDropdown(departmentId, OCODE);
                ModalPopupExtender.Show();

            }
            catch (Exception)
            {

                throw;
            }
        }

        private void SetDepartmentForDropdown(int departmentId, string OCODE)
        {
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
        protected void ddlSection_SelecttedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                int sectionId = Convert.ToInt16(ddlSection.SelectedValue);
                SetSubSctionForDropdown(sectionId, OCODE);
                ModalPopupExtender.Show();
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void SetSubSctionForDropdown(int sectionId, string OCODE)
        {
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
        //protected void drpStep_SelecttedIndexChanged(object sender, EventArgs e)
        //{

        //    try
        //    {
        //        string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
        //        int step = Convert.ToInt16(drpStep.SelectedValue);
        //        //setGadeForDropdown(step, OCODE);
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }

        //}

        //private void setGadeForDropdown(string step, string OCODE)
        //{

        //    var row = gradeBll.GetGrateByStepAndOCode(step, OCODE).ToList();
        //    if (row.Count > 0)
        //    {
        //        ddlGrade.DataSource = row;
        //        ddlGrade.DataTextField = "GRADE";
        //        ddlGrade.DataValueField = "GRADE_ID";
        //        ddlGrade.DataBind();
        //        ddlGrade.Items.Insert(0, new ListItem("--Select--", "0"));
        //    }


        //}
        protected void GetAllDesignation()
        {
            try
            {
                string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                var row = designationDal.GetDesignationList(OCODE);
                // var row = designationDal.GetAllDesignation(OCODE);
                if (row.Count > 0)
                {
                    ddlDesignations.DataSource = row.ToList();
                    ddlDesignations.DataTextField = "DeginationName";
                    ddlDesignations.DataValueField = "DeginationName";
                    ddlDesignations.DataBind();
                    ddlDesignations.AppendDataBoundItems = false;
                }

            }
            catch (Exception ex)
            {
                throw ex;
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

        protected void txtbxJoiningDate_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DateTime JoiningDate = Convert.ToDateTime(txtbxJoingDate.Text);
                string jodate = JoiningDate.ToString();
                string[] joindatetime = jodate.Split(' ');

                txtbxProbationProbationPeriodFrom.Text = joindatetime[0].ToString();
                DateTime proTo = JoiningDate.AddMonths(3);
                string datewithTime = proTo.ToString();
                string[] prTo = datewithTime.Split(' ');
                txtbxProbationPeriodTo.Text = prTo[0].ToString();
                txtbxConformationDate.Text = txtbxProbationPeriodTo.Text;

                ModalPopupExtender.Show();
            }
            catch (Exception ex)
            {
                string EID = Convert.ToString(((SessionUser)Session["SessionUser"]).EID);
                //LogController<employementEdit>.SetLog(ex, EID);
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

        protected void btnUpdate_click(object sender, EventArgs e)
        {
            try
            {
                DESIGNATION_BLL objDeg_BLL = new DESIGNATION_BLL();
                HRM_PersonalInformations personalInfo = new HRM_PersonalInformations();
                string EmployeeId = Convert.ToString(Session["EID"]);

                string grossSalary;
                personalInfo.Grade = txtbxGarde.Text;
                grossSalary = txtbxGrossSalary.Text.ToString();
                personalInfo.Salary = Convert.ToDecimal(grossSalary);

                string DesginationName = ddlDesignations.SelectedItem.Text.ToString();
                bool Status = CheckDesignation(DesginationName, Convert.ToString(personalInfo.Grade), Convert.ToDecimal(personalInfo.Salary));
                if (Status == false)
                {


                    //Change Logic Provide By MasumVai ----- Edited------- Kamruzzaman.
                    double gross_Salary = Convert.ToDouble(personalInfo.Salary);
                    double medical = 250;
                    double taransport = 200;
                    double food = 650;
                    double withoutMedical = (gross_Salary - (medical + taransport + food));
                    double Basic = (withoutMedical) / 1.4;
                    double houseRent = (Basic * 40) / 100;


                    HRM_DESIGNATIONS designationObj = new HRM_DESIGNATIONS();
                    designationObj.DEG_NAME = ddlDesignations.SelectedItem.ToString();
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

                    personalInfo.DesginationId = _Desobj.DEG_ID;
                    personalInfo.Grade = _Desobj.GRADE;
                    personalInfo.Salary = _Desobj.GROSS_SAL;

                    personalInfo.EmployeeType = Convert.ToInt32(drpEmployeeType.SelectedValue);
                    personalInfo.EmpCategoryId = Convert.ToInt32(drpEmployeeCate.SelectedValue);
                    personalInfo.RegionsId = Convert.ToInt32(drpRegion.SelectedValue);
                    personalInfo.OfficeId = Convert.ToInt32(ddlOffice.SelectedValue);
                    personalInfo.DepartmentId = Convert.ToInt32(ddlDepartment.SelectedValue);
                    personalInfo.SectionId = Convert.ToInt32(ddlSection.SelectedValue);
                    personalInfo.SubSectionId = Convert.ToInt32(ddlSubSections.SelectedValue);
                    //personalInfo.EffectiveSlary = Convert.ToDecimal(txtbxEffectiveSlary.Text);
                    personalInfo.EffectiveSlary = 0;
                    //personalInfo.DesginationId = Convert.ToInt32(ddlDesignations.SelectedValue);
                    personalInfo.ShiftCode = ddlShift.SelectedValue.ToString();
                    
                    personalInfo.OTApplicable = Convert.ToBoolean(drpdwnOTApplicable.SelectedValue);
                    personalInfo.Attendance_Bouns = Convert.ToBoolean(drpAttandenceApplicable.SelectedValue);    

                    if (drpLateApplicable.SelectedValue == "0")
                    {
                        personalInfo.Late_Applicable = false;
                    }
                    else
                    {
                        personalInfo.Late_Applicable = Convert.ToBoolean(drpLateApplicable.SelectedValue);
                    }

                    if (drpAbsenceApplicable.SelectedValue == "0")
                    {
                        personalInfo.Absence_Applicable = false;
                    }
                    else
                    {
                        personalInfo.Absence_Applicable = Convert.ToBoolean(drpAbsenceApplicable.SelectedValue);
                    }

                    if (drpTaxApplicable.SelectedValue == "0")
                    {
                        personalInfo.Tax_Applicable = false;
                    }
                    else
                    {
                        personalInfo.Tax_Applicable = Convert.ToBoolean(drpTaxApplicable.SelectedValue);
                    }

                    if (drpPFApplicable.SelectedValue == "0")
                    {
                        personalInfo.PF_Applicable = false;
                    }
                    else
                    {
                        personalInfo.PF_Applicable = Convert.ToBoolean(drpPFApplicable.SelectedValue);
                    }       
                    
                    personalInfo.JoiningDate = Convert.ToDateTime(txtbxJoingDate.Text);
                    personalInfo.ProbationPeriodFrom = Convert.ToDateTime(txtbxProbationProbationPeriodFrom.Text);
                    personalInfo.ProbationPeriodTo = Convert.ToDateTime(txtbxProbationPeriodTo.Text);
                    personalInfo.ConfiramtionDate = Convert.ToDateTime(txtbxConformationDate.Text);
                    personalInfo.JobResponsibility = txtbxJobResponsibility.Text;
                    
                    if (EmployeeId != null)
                    {
                        int result = employeeSetUpBll.UpdateemployemetPart(EmployeeId, personalInfo);
                        if (result == 1)
                        {



                            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "text", "func('Data Update successfully!')", true);
                            // lblModalMessage.Text = "Data Update Successfully.";
                            GetEmployemntInfo(EmployeeId);
                        }

                    }
                }


            }
            catch (Exception)
            {

                throw;
            }

        }

        protected void btnBankDel_Click(object sender, EventArgs e)
        {
            string employeeid = Convert.ToString(Session["EID"]);
            string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
            List<HRM_BankInfo> bankInfo = bankDALObj.GetBankInfo(employeeid, OCODE);
            if (bankInfo.Count > 0)
            {
                // For Save BankInfo_Delete_Log
                HRM_BankInfo_Delete_Log bankDelObj = new HRM_BankInfo_Delete_Log();
                string employee = Convert.ToString(Session["EID"]);
                bankDelObj.EID = employee;
                bankDelObj.EDIT_DATE = DateTime.Now;
                bankDelObj.EDIT_USER = ((SessionUser)Session["SessionUser"]).UserId;
                bankDelObj.OCODE = OCODE;
                int result = bankDALObj.DeletedEmployeeBankInfoLog(bankDelObj);
                if (result == 1)
                {
                    // For Delete Bankinfo
                    bankDALObj.DeleteEmployeeBankInfo(employee);
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "text", "func('Data Deleted Successfully!')", true);
                }
                ClearBankLbl();
            }
            else
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "text", "func('No Data Found!')", true);
            }

        }

        private void ClearBankLbl()
        {
            lblBankName.Text = "";
            lblAccountNumber.Text = "";
            lblBranch.Text = "";
            lblAddress.Text = "";
            lblMobileNo.Text = "";
            lblMoboleBankName.Text = "";
            txbxMobileBankName.Text = "";
            txtbxBankName.Text = "";
            txtbxAc.Text = "";
            txtbxBranch.Text = "";
            txtbxAddress.Text = "";
            txtbxMobileNO.Text = "";
        }

    }
}
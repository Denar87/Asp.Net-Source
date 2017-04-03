using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ERPSSL.HRM.BLL;
using ERPSSL.HRM.DAL;
using System.Globalization;


namespace ERPSSL.HRM.UserControls
{
    public partial class PersonalEdit : System.Web.UI.UserControl
    {
        EMPOYEE_BLL employeeBll = new EMPOYEE_BLL();
        EmployeeSetup_DAL empSetupDal = new EmployeeSetup_DAL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string employeeid = Convert.ToString(Session["EID"]);
                if (employeeid != null)
                {

                    GetPersonalInfo(employeeid);

                }
            }
        }

        private void GetPersonalInfo(string employeeid)
        {
            try
            {
                HRM_PersonalInformations personalObj = employeeBll.getPersonalInfosByID(employeeid);
                lblFirstName.Text = personalObj.FirstName;
                lblLastName.Text = personalObj.LastName;
                lblBanglaFullName.Text = personalObj.BanFullName;
                lblGender.Text = personalObj.Gender;
                lblReligion.Text = personalObj.Religion;
                lblDateOfBrith.Text = personalObj.DateOfBrith.ToString();
                lblNationality.Text = personalObj.Nationality;
                lblBloodGroup.Text = personalObj.BloodGroup;
                lblMaritalStatus.Text = personalObj.MaritalStatus;
                lblNId.Text = personalObj.NationalID;
                hidMachineId.Value = lblMachineId.Text = personalObj.BIO_MATRIX_ID;

                // Contact Information

                lblContactNo.Text = personalObj.ContactNumber;
                lblPresentAddress.Text = personalObj.PresentAddress;
                lblPermanentAddress.Text = personalObj.PermanenAddress;
                lblEmergenceContactPeson.Text = personalObj.EmergencyContactPerson;
                lblEmergenceContactNo.Text = personalObj.EmergencyContactNo;
                lblEmergenceContractRelation.Text = personalObj.ContactPersonRelationName;
                lblEmergenceContactAddress.Text = personalObj.EmergencyAddress;
                lblEmail.Text = personalObj.Email;
                lblAlternativeEmail.Text = personalObj.AlternativEmailAddress;

                // Immediate Relative Info
                lblFatherName.Text = personalObj.FatherName;
                lblFatherAge.Text = personalObj.FatherAge;
                lblFatherProfession.Text = personalObj.FatherProfession;
                lblMotherName.Text = personalObj.MotherName;
                lblMotherAge.Text = personalObj.MotherAge;
                lblMotherProfession.Text = personalObj.MotherProfession;
                lblSpourseName.Text = personalObj.SpouseName;
                lblSpourseAge.Text = personalObj.SpouseAge;
                lblSpourseProfession.Text = personalObj.SpouseProfession;
                lblNumberOfChildren.Text = personalObj.NumberOfChildren;
                lblChildrenNameRemark.Text = personalObj.ChildrenNameRemark;

                // Nominee Info
                lblName.Text = personalObj.NomineeName;
                lblAge.Text = personalObj.NomineeAge;
                lblRelation.Text = personalObj.NomineeRelation;
                //lblNomineeAdress.Text=personalObj

            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void ImmediateUpdateButton_Click(object sender, EventArgs e)
        {
            HRM_PersonalInformations personalInfo = new HRM_PersonalInformations();
            string employeeId = "";
            try
            {
                employeeId = Convert.ToString(Session["EID"]);

                personalInfo.FatherName = txtbxFatherName.Text.Trim();
                personalInfo.FatherAge = txtbxFatherAge.Text.Trim();
                personalInfo.FatherProfession = txtbxFatherProfession.Text.Trim();
                personalInfo.MotherName = txtbxMotherName.Text.Trim();
                personalInfo.MotherAge = txtbxMotherAge.Text;
                personalInfo.MotherProfession = txtbxMotherProfession.Text;
                personalInfo.SpouseName = txtbxSpourseName.Text;
                personalInfo.SpouseAge = txtbxSpourseAge.Text;
                personalInfo.SpouseProfession = txtbxSpourseProfession.Text;
                personalInfo.NumberOfChildren = txtbxNumberOfChilldren.Text;
                personalInfo.ChildrenNameRemark = txtbxChildrenNameRemark.Text;

                int result = empSetupDal.UpdateImmediateRelativeInfo(personalInfo, employeeId);
                if (result == 1)
                {
                    lblImmediateRelativeInfoMess.Text = "Data Update Successfully.";

                    GetPersonalInfo(employeeId);

                }
                else
                {

                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        protected void btnNomineeUpdate_Click(object sender, EventArgs e)
        {
            HRM_PersonalInformations personalInfo = new HRM_PersonalInformations();
            string employeeId = "";
            try
            {
                employeeId = Convert.ToString(Session["EID"]);
                personalInfo.NomineeName = txtbxNomineeName.Text.Trim();
                personalInfo.NomineeAge = txtbxAge.Text;
                personalInfo.NomineeRelation = txtbxRelation.Text.Trim();
                //Addresss

                int result = empSetupDal.UpdateNomineeInfoPersonalInfo(personalInfo, employeeId);
                if (result == 1)
                {
                    lblNomineeMessage.Text = "Data Update Successfully.";

                    GetPersonalInfo(employeeId);
                    ModalPopupExtender3.Hide();

                }
                else
                {

                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        protected void BtnEdits_Click(object sender, EventArgs e)
        {
            try
            {
                string employeeid = Convert.ToString(Session["EID"]);
                HRM_PersonalInformations personalObj = employeeBll.getPersonalInfosByID(employeeid);
                txtbxNomineeName.Text = personalObj.NomineeName;
                txtbxAge.Text = personalObj.NomineeAge;
                txtbxRelation.Text = personalObj.NomineeRelation;
                //txtbxAddress

                //btnSkilReset.Visible = true;
                btnSkillUpdate.Visible = true;
                ModalPopupExtender3.Show();

            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void btnImmediateRelative_Click(object sender, EventArgs e)
        {
            try
            {
                string employeeid = Convert.ToString(Session["EID"]);
                HRM_PersonalInformations personalObj = employeeBll.getPersonalInfosByID(employeeid);
                txtbxFatherName.Text = personalObj.FatherName;
                txtbxFatherAge.Text = personalObj.FatherAge;
                txtbxFatherProfession.Text = personalObj.FatherProfession;
                txtbxMotherName.Text = personalObj.MotherName;
                txtbxMotherAge.Text = personalObj.MotherAge;
                txtbxMotherProfession.Text = personalObj.MotherProfession;
                txtbxSpourseName.Text = personalObj.SpouseName;
                txtbxSpourseAge.Text = personalObj.SpouseAge;
                txtbxSpourseProfession.Text = personalObj.SpouseProfession;
                txtbxNumberOfChilldren.Text = personalObj.NumberOfChildren;
                txtbxChildrenNameRemark.Text = personalObj.ChildrenNameRemark;

                //Button4.Visible = true;
                btnTraingUpdateAndSumit.Visible = true;
                ModalPopupExtender2.Show();
            }
            catch (Exception)
            {

                throw;
            }
        }
        protected void ContactInfo_Click(object sender, EventArgs e)
        {
            HRM_PersonalInformations personalInfo = new HRM_PersonalInformations();
            string employeeId = "";
            try
            {
                employeeId = Convert.ToString(Session["EID"]);
                personalInfo.ContactNumber = txtbxContactNo.Text.Trim();
                personalInfo.PresentAddress = txtbxPresentAddress.Text.Trim();
                personalInfo.PermanenAddress = txtbxPermanentAddress.Text.Trim();
                personalInfo.EmergencyContactPerson = txtbxEmergenceContactPerson.Text.Trim();
                personalInfo.ContactPersonRelationName = txtbxEmergenceContactRelation.Text.Trim();
                personalInfo.EmergencyContactNo = txtbxEmergenceContact.Text;
                personalInfo.EmergencyAddress = txtbxEmergenceContactAddress.Text;
                personalInfo.AlternativEmailAddress = txtbxAllternativeEmail.Text;
                personalInfo.Email = txtbxEmail.Text;

                int result = empSetupDal.UpdateConactInfoPersonalInfo(personalInfo, employeeId);
                if (result == 1)
                {
                    lblContactMessage.Text = "Data Update Successfully.";

                    GetPersonalInfo(employeeId);

                }
                else
                {

                }
            }
            catch (Exception)
            {
                throw;
            }

        }

        private string ConvertDate(string DateTime)
        {
            string[] dattime = DateTime.Split(' ');
            return dattime[0];
        }

        protected void BtnEdit_Click(object sender, EventArgs e)
        {
            BindNationality();
            string employeeid = Convert.ToString(Session["EID"]);
            HRM_PersonalInformations personalObj = employeeBll.getPersonalInfosByID(employeeid);
            txtbxFirstName.Text = personalObj.FirstName;
            txtbxLastName.Text = personalObj.LastName;
            txtbxBangalFullName.Text = personalObj.BanFullName;
            ddlGender.SelectedValue = personalObj.Gender.ToString();
            ddlReligion.SelectedValue = personalObj.Religion;
            txtbxdateOfBrith.Text = ConvertDate(personalObj.DateOfBrith.ToString());
            ddlNationality.SelectedValue = personalObj.Nationality;
            ddlBloodGrp.SelectedValue = personalObj.BloodGroup;
            ddlMariedSts.SelectedValue = personalObj.MaritalStatus;
            txtbxNId.Text = personalObj.NationalID;
            txtbxMachineID.Text = personalObj.BIO_MATRIX_ID;
            btnedit.Visible = true;
            btnUpdate.Visible = true;
            ModalPopupExtender.Show();

        }



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
            //return cultureList;
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
        }

        protected void btnContactInfo_Click(object sender, EventArgs e)
        {
            try
            {
                string employeeid = Convert.ToString(Session["EID"]);
                HRM_PersonalInformations personalObj = employeeBll.getPersonalInfosByID(employeeid);
                txtbxContactNo.Text = personalObj.ContactNumber;
                txtbxPresentAddress.Text = personalObj.PresentAddress;
                txtbxPermanentAddress.Text = personalObj.PermanenAddress;
                txtbxEmergenceContactPerson.Text = personalObj.EmergencyContactPerson;
                txtbxEmergenceContact.Text = personalObj.EmergencyContactNo;
                txtbxEmergenceContactAddress.Text = personalObj.EmergencyAddress;
                txtbxEmail.Text = personalObj.Email;

                //btnAcademicReset.Visible = true;
                btnSaveandUpdate.Visible = true;
                ModalPopupExtender1.Show();

            }
            catch (Exception)
            {

                throw;
            }
        }


        protected void btnUpdate_click(object sender, EventArgs e)
        {
            HRM_PersonalInformations personalInfo = new HRM_PersonalInformations();
            string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
            EmployeeSetup_BLL employeeSetUpBll = new EmployeeSetup_BLL();
            string Requested_Eid = txtbxMachineID.Text;

            string employeeId = "";

            try
            {
                bool status = true;

                if (hidMachineId.Value != txtbxMachineID.Text.Trim())
                {
                    GlobalClass.IsEidValid = employeeSetUpBll.CheckBioIDExitance(OCODE, Requested_Eid);
                    if (GlobalClass.IsEidValid > 0)
                    {
                        status = false;
                    }
                }

                if (status)
                {
                    employeeId = Convert.ToString(Session["EID"]);
                    personalInfo.FirstName = txtbxFirstName.Text.Trim();
                    personalInfo.LastName = txtbxLastName.Text.Trim();
                    personalInfo.Gender = ddlGender.Text.Trim();
                    personalInfo.DateOfBrith = Convert.ToDateTime(txtbxdateOfBrith.Text);
                    personalInfo.BloodGroup = ddlBloodGrp.Text.Trim();
                    personalInfo.MaritalStatus = ddlMariedSts.Text;
                    personalInfo.Religion = ddlReligion.Text;
                    personalInfo.BIO_MATRIX_ID = txtbxMachineID.Text.Trim();
                    personalInfo.Nationality = ddlNationality.Text;
                    personalInfo.NationalID = txtbxNId.Text;
                    int result = empSetupDal.UpdatePersonalInfo(personalInfo, employeeId);
                    if (result == 1)
                    {
                        lblModalMessage.Text = "Data Update Successfully.";

                        GetPersonalInfo(employeeId);

                    }
                    else
                    {


                    }


                }
                else
                {

                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Machine-ID Conflict!')", true);
                    ModalPopupExtender.Show();


                }




            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //protected void txtBioID_TextChanged(object sender, EventArgs e)
        //{
        //    EmployeeSetup_BLL employeeSetUpBll = new EmployeeSetup_BLL();
        //    string Requested_Eid = txtbxMachineID.Text;
        //    string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
        //    GlobalClass.IsEidValid = employeeSetUpBll.CheckBioIDExitance(OCODE, Requested_Eid);
        //    if (GlobalClass.IsEidValid > 0)
        //    {
        //        CheckusernameB.Visible = true;
        //        imgstatusB.ImageUrl = "resources/ico/cross.png";
        //        lblStatusB.Text = "Machine-ID Conflict!";
        //        lblStatusB.ForeColor = System.Drawing.Color.Red;
        //        System.Threading.Thread.Sleep(2000);
        //    }
        //    else
        //    {
        //        CheckusernameB.Visible = true;
        //        imgstatusB.ImageUrl = "resources/ico/tick.png";
        //        lblStatusB.Text = "Machine-ID Accepted!";
        //        lblStatusB.ForeColor = System.Drawing.Color.Green;
        //        System.Threading.Thread.Sleep(2000);
        //    }
        //}

    }
}
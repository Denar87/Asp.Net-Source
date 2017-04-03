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
    public partial class TraningAcademic : System.Web.UI.UserControl
    {
        EmployeeSetup_DAL employeeSetupDal = new EmployeeSetup_DAL();
        AcademicInfoBll academicInfoBll = new AcademicInfoBll();
        HRM_Academics hrmAcademic = new HRM_Academics();
        TrainingBLL trainingBll = new TrainingBLL();
        DrivingLicenceInfoBLL drivingLicenceBLL = new DrivingLicenceInfoBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                getAcademicsInfo();
                getEducationTypeList();
                getTraininges();
                getDrivingLicence();
            }
        }

        private void getEducationTypeList()
        {
            try
            {
                EducationTypeBLL _eductaionType = new EducationTypeBLL();
                string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                var education = _eductaionType.getEducationTypeList(OCODE).ToList();
                if (education.Count > 0)
                {
                    ddlEducation.DataSource = education;
                    ddlEducation.DataTextField = "EducationTypeName";
                    ddlEducation.DataValueField = "EducationTypeName";
                    ddlEducation.DataBind();
                    ddlEducation.Items.Insert(0, new ListItem("--Select--", "0"));
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void getDrivingLicence()
        {

            try
            {
                string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                string eid = Convert.ToString(Session["EID"]);
                var row = drivingLicenceBLL.GetDrivingLicencesInfo(eid, OCODE);
                if (row.Count > 0)
                {
                    gridViewDrivingLicenceInfo.DataSource = row.ToList();
                    gridViewDrivingLicenceInfo.DataBind();
                }
                else
                {
                    gridViewDrivingLicenceInfo.DataSource = null;
                    gridViewDrivingLicenceInfo.DataBind();
                }
            }
            catch (Exception)
            {

                throw;
            }

        }


        private void getTraininges()
        {
            try
            {
                string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                string eid = Convert.ToString(Session["EID"]);
                var row = trainingBll.GetTrainingListByemployeeIdandOcode(eid, OCODE).ToList();
                if (row.Count > 0)
                {
                    grdiviewTrainings.DataSource = row.ToList();
                    grdiviewTrainings.DataBind();
                }
                else
                {
                    grdiviewTrainings.DataSource = null;
                    grdiviewTrainings.DataBind();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        //grdAcademicInfo
        private void getAcademicsInfo()
        {
            try
            {
                string OCODE = ((SessionUser)Session["SessionUser"]).OCode;                
                string eid = Convert.ToString(Session["EID"]);
                var row = academicInfoBll.GetAllAcdemicInfoByEmployeeId(eid, OCODE).ToList();
                if (row.Count > 0)
                {
                    grdAcademicInfo.DataSource = row.ToList();
                    grdAcademicInfo.DataBind();
                }
                else
                {
                    grdAcademicInfo.DataSource = null;
                    grdAcademicInfo.DataBind();
                }
            }
            catch (Exception)
            {

                throw;
            }

        }
        protected void btnAcademic_Click(object sender, EventArgs e)
        {
            hidAcademicId.Value = "";
            ddlEducation.ClearSelection();
            txtbxMajor.Text = "";
            txtbxInstitute.Text = "";
            txtbxPassingYear.Text = "";
            txtbxDuration.Text = "";
            txtbxResult.Text = "";
            btnSaveandUpdate.Text = "Submit";
            ModalPopupExtender1.Show();

        }
        protected void btnTrt_Click(object sender, EventArgs e)
        {
            hidDivrIngLicenceId.Value = "";
            txtbxLiceNo.Text = "";
            drpdwnDriveType.SelectedValue = "";
            txtbxIssuedDate.Text = "";
            txtbxDexperiredDate.Text = "";
            txtbxLocation.Text = "";

            btnDrivingSumbiandUpdate.Text = "Submit";
            ModalPopupExtender.Show();

        }

        protected void btnAcademicinfoedit_Ckick(object sender, EventArgs e)
        {
            Button imgbtn = (Button)sender;
            GridViewRow row = (GridViewRow)imgbtn.NamingContainer;
            try
            {
                string aId = "";
                Label lblAId = (Label)grdAcademicInfo.Rows[row.RowIndex].FindControl("academicId");
                if (lblAId != null)
                {
                   
                    string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                    aId = lblAId.Text;

                    List<HRM_Academics> Academices = academicInfoBll.getAcademicInfoByIdandOcode(aId, OCODE);
                    foreach (HRM_Academics academic in Academices)
                    {
                        hidAcademicId.Value = academic.AcademicId.ToString();
                        ddlEducation.SelectedValue = academic.LevelOfEducation;
                        txtbxMajor.Text = academic.Major;
                        txtbxInstitute.Text = academic.InstituteName;
                        txtbxPassingYear.Text = academic.PassingYear.ToString();
                        txtbxDuration.Text = academic.Duration;
                        txtbxResult.Text = academic.Result;

                    }
                }


                btnSaveandUpdate.Text = "Update";
                ModalPopupExtender1.Show();
            }
            catch (Exception ex)
            {
                throw;
            }

        }
       
        protected void btnSaveandUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                HRM_Academics academics = new HRM_Academics();

                //academics.EID = Convert.ToString(Session["EID"]);
                //academics.EID = Convert.ToString(Session["EID"]);
                academics.LevelOfEducation = ddlEducation.Text;
                academics.Major = txtbxMajor.Text;
                academics.InstituteName = txtbxInstitute.Text;
                academics.PassingYear = Convert.ToInt32(txtbxPassingYear.Text);
                academics.Duration = txtbxDuration.Text;
                academics.Result = txtbxResult.Text;               

                if (btnSaveandUpdate.Text == "Submit")
                {
                    academics.EID = Convert.ToString(Session["EID"]);
                    academics.EDIT_DATE = DateTime.Now;
                    academics.EDIT_USER = ((SessionUser)Session["SessionUser"]).UserId;
                    academics.OCODE = ((SessionUser)Session["SessionUser"]).OCode;

                    int result = employeeSetupDal.InsertAcademicInfo(academics);
                    if (result == 1)
                    {
                        ClearAcademic();
                        lblAcademicMessage.Text = "Data Save Successfully";
                        getAcademicsInfo();
                    }
                }
                else
                {
                    int AcadimicId = Convert.ToInt32(hidAcademicId.Value);
                    int result = academicInfoBll.updateAcadmicInfo(academics, AcadimicId);
                    if (result == 1)
                    {
                        ClearAcademic();
                        lblAcademicMessage.Text = "Data Save Successfully";
                        getAcademicsInfo();
                    }

                }
            }
            catch (Exception)
            {

                throw;
            }


        }

        private void ClearAcademic()
        {
            ddlEducation.ClearSelection();
            txtbxMajor.Text = "";
             txtbxInstitute.Text="";
        }


        protected void btnDrivingLicence_Click(object sender, EventArgs e)
        {
            Button imgbtn = (Button)sender;
            GridViewRow row = (GridViewRow)imgbtn.NamingContainer;
            try
            {
                string DId = "";
                Label lblDrivId = (Label)gridViewDrivingLicenceInfo.Rows[row.RowIndex].FindControl("lblDrivingLicenceId");
                if (lblDrivId != null)
                {                   
                    string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                    DId = lblDrivId.Text;

                    List<HRM_DrivingLicencs> drivs = drivingLicenceBLL.getDrivingLicenceByDrivingIdandOcode(DId, OCODE);
                    foreach (HRM_DrivingLicencs driv in drivs)
                    {
                        hidDivrIngLicenceId.Value = driv.DrivingId.ToString();
                        txtbxLiceNo.Text = driv.LicenceNo;
                        drpdwnDriveType.SelectedValue = driv.Type;
                        txtbxIssuedDate.Text = driv.IssuedDate.ToString();
                        txtbxDexperiredDate.Text = driv.ExperiredDate.ToString();
                        txtbxLocation.Text = driv.Location;
                        btnDrivingSumbiandUpdate.Text = "Update";
                        ModalPopupExtender.Show();
                    }
                }



            }
            catch (Exception ex)
            {
                throw;
            }
        }

        protected void btnTraning_Click(object sender, EventArgs e)
        {
            hidtraningId.Value = "";
            txtbxTile.Text = "";
            txtbxTopices.Text = "";
            txtbxTInstitute.Text = "";
            txtbxTLocation.Text = "";
            txtbxTTraningYear.Text = "";
            txtbxTDuration.Text = "";
            btnTraingUpdateAndSumit.Text = "Submit";
            try
            {

                ModalPopupExtender2.Show();

            }
            catch (Exception)
            {

                throw;
            }

        }

        protected void btnTrainingEdit_Click(object sender, EventArgs e)
        {

            Button imgbtn = (Button)sender;
            GridViewRow row = (GridViewRow)imgbtn.NamingContainer;
            try
            {
                string TId = "";
                Label lblTraninId = (Label)grdiviewTrainings.Rows[row.RowIndex].FindControl("lbltrainingId");
                if (lblTraninId != null)
                {
                    // string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                    string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                    TId = lblTraninId.Text;

                    List<HRM_Trainings> Tranins = trainingBll.getTraningInfoByTraningIdandOcode(TId, OCODE);
                    foreach (HRM_Trainings Traning in Tranins)
                    {
                        hidtraningId.Value = Traning.TrainingId.ToString();
                        txtbxTile.Text = Traning.TraningTitle;
                        txtbxTopices.Text = Traning.TraningTopicsCovered;
                        txtbxTInstitute.Text = Traning.Institue;
                        txtbxTLocation.Text = Traning.Location;
                        txtbxTTraningYear.Text = Traning.TraningYear.ToString();
                        txtbxTDuration.Text = Traning.Duration;

                        btnTraingUpdateAndSumit.Text = "Update";
                        ModalPopupExtender2.Show();
                    }
                }



            }
            catch (Exception ex)
            {
                throw;
            }
        }

        protected void btnDrivingSumbiandUpdate_Click(object sender, EventArgs e)
        {
            DrivingLicenceInfoBLL drivingLicenceBLL = new DrivingLicenceInfoBLL();
            try
            {
                HRM_DrivingLicencs drivObj = new HRM_DrivingLicencs();
                // drivObj.EID = Convert.ToString(Session["EID"]);

                drivObj.LicenceNo = txtbxLiceNo.Text;
                drivObj.Type = drpdwnDriveType.SelectedItem.ToString();
                drivObj.IssuedDate = Convert.ToDateTime(txtbxIssuedDate.Text);
                drivObj.ExperiredDate = Convert.ToDateTime(txtbxDexperiredDate.Text);
                drivObj.Location = txtbxLocation.Text;

                if (btnDrivingSumbiandUpdate.Text == "Submit")
                {
                    drivObj.EID = Convert.ToString(Session["EID"]);
                    drivObj.EDIT_DATE = DateTime.Now;
                    drivObj.EDIT_USER = ((SessionUser)Session["SessionUser"]).UserId;
                    drivObj.OCODE = ((SessionUser)Session["SessionUser"]).OCode;

                    int result = drivingLicenceBLL.SaveDrivingInfo(drivObj);
                    if (result == 1)
                    {
                        ClearDrivingLicence();
                        lblDrivingLicenMessage.Text = "Data Save Successfully";
                        getDrivingLicence();
                    }
                }
                else
                {
                    int drivingLiceId = Convert.ToInt32(hidDivrIngLicenceId.Value);
                    int result = drivingLicenceBLL.UpdateDrivingInfo(drivingLiceId, drivObj);
                    if (result == 1)
                    {
                        ClearDrivingLicence();
                        lblDrivingLicenMessage.Text = "Data Update Successfully";
                        getDrivingLicence();
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void ClearDrivingLicence()
        {
            txtbxLiceNo.Text="";
            drpdwnDriveType.ClearSelection();
            txtbxIssuedDate.Text="";
            txtbxDexperiredDate.Text = "";
            txtbxLocation.Text = "";
        }



        protected void btnTraingUpdateAndSumit_Click(object sender, EventArgs e)
        {
            HRM_Trainings traningObj = new HRM_Trainings();
            try
            {
                traningObj.TraningTitle = txtbxTile.Text;
                traningObj.TraningTopicsCovered = txtbxTopices.Text;
                traningObj.TraningYear = Convert.ToInt32(txtbxTTraningYear.Text);
                traningObj.Duration = txtbxTDuration.Text;
                traningObj.Institue = txtbxTInstitute.Text;
                traningObj.Location = txtbxTLocation.Text;
                if (btnTraingUpdateAndSumit.Text == "Submit")
                {
                    traningObj.EID = Convert.ToString(Session["EID"]);
                    traningObj.EDIT_DATE = DateTime.Now;
                    traningObj.EDIT_USER = ((SessionUser)Session["SessionUser"]).UserId;
                    traningObj.OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                    int result = employeeSetupDal.InsertTrainingInfo(traningObj);
                    if (result == 1)
                    {
                        ClearTraning();
                        lblTraniningInfoMess.Text = "Data Save Successfully";
                        getTraininges();

                    }
                }
                else
                {
                    ClearTraning();
                    int TraningId = Convert.ToInt32(hidtraningId.Value);
                    int result = trainingBll.UpdateTrainingInfo(TraningId, traningObj);
                    if (result == 1)
                    {
                        lblTraniningInfoMess.Text = "Data Update Successfully";
                        getTraininges();

                    }

                }


            }
            catch (Exception)
            {

                throw;
            }
        }

        private void ClearTraning()
        {
            txtbxTile.Text = "";
            txtbxTopices.Text = "";
            txtbxTTraningYear.Text = "";
            txtbxTDuration.Text = "";
            txtbxTInstitute.Text = "";
            txtbxTLocation.Text = "";
        }
    }
}
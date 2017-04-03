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
    public partial class AcademicInfo : System.Web.UI.UserControl
    {
        EmployeeSetup_DAL employeeSetupDal = new EmployeeSetup_DAL();
        AcademicInfoBll academicInfoBll = new AcademicInfoBll();
        HRM_Academics hrmAcademic=new HRM_Academics();
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

                grdAcademicInfo.DataSource = null;
                grdAcademicInfo.DataBind();

                grdiviewTrainings.DataSource = null;
                grdiviewTrainings.DataBind();

                gridViewDrivingLicenceInfo.DataSource = null;
                gridViewDrivingLicenceInfo.DataBind();
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

        protected void btnSaveTrainingInfo_Click(object sender, EventArgs e)
        {
            try
            {
                HRM_Trainings trainings = new HRM_Trainings();
                // trainings.EID = Convert.ToString(Session["EID"]);
                trainings.EID = Convert.ToString(Session["EID"]);
                trainings.TraningTitle = txtTrainingTitle.Text;
                trainings.TraningTopicsCovered = txtTrainingTopics.Text;
                trainings.TraningYear = Convert.ToInt32(txtTrainingYear.Text);
                trainings.Duration = txtTrainingDuration.Text;
                trainings.Institue = txtTrainingInstituate.Text;
                trainings.Location = txtTrainingLocation.Text;
                trainings.EDIT_DATE = DateTime.Now;
                trainings.EDIT_USER = ((SessionUser)Session["SessionUser"]).UserId;
                trainings.OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                int result= employeeSetupDal.InsertTrainingInfo(trainings);
                if (result == 1)
                {
                    //lblMessage.Text = "Data Save Successfully";
                    ClearTraning();
                    getTraininges();
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Data Save successfully!')", true);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void ClearTraning()
        {
             txtTrainingTitle.Text="";
             txtTrainingTopics.Text = "";
             txtTrainingYear.Text = "";
             txtTrainingDuration.Text = "";
             txtTrainingInstituate.Text = "";
             txtTrainingLocation.Text = "" ;
        }

        protected void btnTraningDelete_Click(object sender, EventArgs e)
        {
            Button imgbtn = (Button)sender;
            GridViewRow row = (GridViewRow)imgbtn.NamingContainer;
            try
            {
                string traningId = "";
                Label lblTraningId = (Label)grdiviewTrainings.Rows[row.RowIndex].FindControl("lbltrainingId");
                if (lblTraningId != null)
                {
                    // string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                    string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                    traningId = lblTraningId.Text;
                    int result = trainingBll.DeleteTraningInfoByTraningIdandOcode(traningId, OCODE);
                    if (result == 1)
                    {
                        lblMessage.Text = "Data Delete Successfully";
                        getTraininges();
                    }



                }

            }
            catch (Exception ex)
            {

                throw;
            }
        }

        protected void btnSaveAcademicInfo_Click(object sender, EventArgs e)
        {
            try
            {
                HRM_Academics academics = new HRM_Academics();

                //academics.EID = Convert.ToString(Session["EID"]);
                academics.EID = Convert.ToString(Session["EID"]);
                academics.LevelOfEducation = ddlEducation.Text;
                academics.Major = txtMajor.Text;
                academics.InstituteName = txtInstituateName.Text;
                academics.PassingYear = Convert.ToInt32(txtPassingYear.Text);
                academics.Duration = txtDuration.Text;
                academics.Result = txtbxResult.Text;
                academics.EDIT_DATE = DateTime.Now;
                academics.EDIT_USER = ((SessionUser)Session["SessionUser"]).UserId;
                academics.OCODE = ((SessionUser)Session["SessionUser"]).OCode;


                int result = employeeSetupDal.InsertAcademicInfo(academics);
                if (result == 1)
                {
                    ClearAllController();
                    //lblMessage.Text = "Data Save Successfully";
                    getAcademicsInfo();
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Data Save successfully!')", true);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void ClearAllController()
        {

            ddlEducation.ClearSelection();
            txtMajor.Text = "";
            txtInstituateName.Text = "";
            txtPassingYear.Text = "";
            txtDuration.Text = "";
            txtbxResult.Text = "";
        }


        protected void btnDeleteDrivingLicence_Click(object sender, EventArgs e)
        {
            Button imgbtn = (Button)sender;
            GridViewRow row = (GridViewRow)imgbtn.NamingContainer;
            try
            {
                string drivingId = "";
                Label lbldrivingId = (Label)gridViewDrivingLicenceInfo.Rows[row.RowIndex].FindControl("lblDrivingId");
                if (lbldrivingId != null)
                {
                    // string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                    string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                    drivingId = lbldrivingId.Text;
                    int result = drivingLicenceBLL.DeleteDrivingLicencebyId(drivingId, OCODE);
                    if (result == 1)
                    {
                        lblDrivingMessage.Text = "Data Delete Successfully";
                        getDrivingLicence();
                    }



                }

            }
            catch (Exception ex)
            {

                throw;
            }
        }

        protected void btnAcademicinfoDelete_Click(object sender, EventArgs e)
        {
            
            Button imgbtn = (Button)sender;
            GridViewRow row = (GridViewRow)imgbtn.NamingContainer;
            try
            {
                string acaademicId = "";
                Label lblAcademicId = (Label)grdAcademicInfo.Rows[row.RowIndex].FindControl("academicId");
                if (lblAcademicId != null)
                {
                    // string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                    string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                    acaademicId = lblAcademicId.Text;
                    int result = academicInfoBll.DeleteAcademicbyAcademicId(acaademicId, OCODE);
                    if (result==1)
                    {
                        lblMessage.Text = "Data Delete Successfully";
                        getAcademicsInfo();
                    }

                    

                }

            }
            catch (Exception ex)
            {

                throw;
            }
        }

        protected void btnDrivingLicence_Click(object sender, EventArgs e)
        {
            DrivingLicenceInfoBLL drivingLicenceBLL = new DrivingLicenceInfoBLL();
            try
            {
                HRM_DrivingLicencs drivObj = new HRM_DrivingLicencs();               
                drivObj.EID = Convert.ToString(Session["EID"]);
                drivObj.LicenceNo = txtbxLicenNo.Text;
                drivObj.Type = drpdwnDriveType.SelectedItem.ToString();
                drivObj.IssuedDate = Convert.ToDateTime(txtbxIssUedDate.Text);
                drivObj.ExperiredDate = Convert.ToDateTime(txtbxExperiredDate.Text);
                drivObj.Location = txtbxLocation.Text;
                drivObj.EDIT_DATE = DateTime.Now;
                drivObj.EDIT_USER = ((SessionUser)Session["SessionUser"]).UserId;
                drivObj.OCODE = ((SessionUser)Session["SessionUser"]).OCode;

                int result = drivingLicenceBLL.SaveDrivingInfo(drivObj);
                if (result == 1)
                {
                    ClearDrivingLicenceText();
                    //lblDrivingMessage.Text = "Data Save Successfully";
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Data Save successfully!')", true);
                    getDrivingLicence();
                }
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        private void ClearDrivingLicenceText()
        {
            txtbxLicenNo.Text = "";
            drpdwnDriveType.ClearSelection();
            txtbxIssUedDate.Text = ""; ;
            txtbxExperiredDate.Text="";
           txtbxLocation.Text="";
        }
    }
}
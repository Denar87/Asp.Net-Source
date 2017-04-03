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
    public partial class EmployeeExperience : System.Web.UI.UserControl
    {
        EmployeeSetup_DAL employeeSetupDal = new EmployeeSetup_DAL();
        ExperienceBLL experienceBll = new ExperienceBLL();
        SkillBLL skillbll = new SkillBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                getExperienceInfo();
                getSkillsInfo();
            }
        }

        private void getExperienceInfo()
        {

            try
            {
                string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                string eid = Convert.ToString(Session["EID"]);
                var row = experienceBll.GetAllExperiencesInfoByEmployeeId(eid, OCODE).ToList();
                if (row.Count > 0)
                {
                    grdExpericencesInfo.DataSource = row.ToList();
                    grdExpericencesInfo.DataBind();
                }
                else
                {
                    grdExpericencesInfo.DataSource = null;
                    grdExpericencesInfo.DataBind();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void getSkillsInfo()
        {
            try
            {
                string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                string eid = Convert.ToString(Session["EID"]);
                var row = skillbll.GetSkillInfobyIdandOcode(eid, OCODE).ToList();
                if (row.Count > 0)
                {
                    gradViewSkills.DataSource = row.ToList();
                    gradViewSkills.DataBind();
                }
                else
                {
                    gradViewSkills.DataSource = null;
                    gradViewSkills.DataBind();
                }
            }
            catch (Exception)
            {

                throw;
            }



        }
        

        protected void btnSaveExperienceInfo_Click(object sender, EventArgs e)
        {
            try
            {
                HRM_Experiences experiences = new HRM_Experiences();

                experiences.EID = Convert.ToString(Session["EID"]);
                experiences.Experience_Company = txtCompanyName.Text;
                experiences.Experience_CompanyLocation = txtCompanyLocation.Text;
                experiences.Experience_CompanyBussiness = txtCompanyBussiness.Text;
                experiences.Experience_CompanyDepartment = txtWorkingDepartment.Text;
                experiences.Experience_Duration = txtDuration.Text.Trim();
                experiences.Experience_PositionHeld = txtPositionHeld.Text.Trim();
                experiences.Experience_AreaOfExperience = txtAreaOfExperience.Text.Trim();
                experiences.EExperience_Responsibilites = txtResponsibilities.Text.Trim();
                experiences.EDIT_DATE = DateTime.Now;
                experiences.EDIT_USER = ((SessionUser)Session["SessionUser"]).UserId;
                experiences.OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                int result = employeeSetupDal.InsertEmpExperiences(experiences);
                if (result == 1)
                {
                    //lblMessage.Text = "Data Save Successfully";
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Data Save successfully!')", true);
                    getExperienceInfo();
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

            ClearExperienceInformationField();
        }

        protected void btnexperienceDelete_Click(object sender, EventArgs e)
        {
            Button imgbtn = (Button)sender;
            GridViewRow row = (GridViewRow)imgbtn.NamingContainer;
            try
            {
                string exId = "";
                Label lblexId = (Label)grdExpericencesInfo.Rows[row.RowIndex].FindControl("lblExpericenceId");
                if (lblexId != null)
                {

                    string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                    exId = lblexId.Text;
                    int result = experienceBll.DeleteexprienceIdandOcode(exId, OCODE);
                    if (result == 1)
                    {
                        lblMessage.Text = "Data Delete Successfully";
                        getExperienceInfo();
                    }



                }

            }
            catch (Exception ex)
            {

                throw;
            }
        }

        protected void btnSaveSkill_Click(object sender, EventArgs e)
        {
            try
            {
                HRM_Skills skills = new HRM_Skills();

                skills.EID = Convert.ToString(Session["EID"]);
                skills.Skill_Specialization = txtSpecialization.Text;
                skills.Skill_Description = txtSkillDescription.Text;
                skills.Skill_ExtraActivities = txtExtratActivities.Text;
                skills.EDIT_DATE = DateTime.Now;
                skills.EDIT_USER = ((SessionUser)Session["SessionUser"]).UserId;
                skills.OCODE = ((SessionUser)Session["SessionUser"]).OCode;

                int result = employeeSetupDal.InsertEmpSkills(skills);
                if (result == 1)
                {
                    //lblMessage.Text = "Data Save Successfully";
                    getSkillsInfo();
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Data Save successfully!')", true);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            ClearSkillInformationField();
        }

        protected void btnSkillceDelete_Click(object sender, EventArgs e)
        {
            Button imgbtn = (Button)sender;
            GridViewRow row = (GridViewRow)imgbtn.NamingContainer;
            try
            {
                string skillId = "";
                Label lblSkillId = (Label)gradViewSkills.Rows[row.RowIndex].FindControl("lblSkillId");
                if (lblSkillId != null)
                {
                    string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                    skillId = lblSkillId.Text;
                    int result = skillbll.DeleteskillInfoIdandOcode(skillId, OCODE);
                    if (result == 1)
                    {
                        lblMessage.Text = "Data Delete Successfully";
                        getSkillsInfo();
                    }



                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        protected void btnSaveStatment_Click(object sender, EventArgs e)
        {
            try
            {
                HRM_EmployeeStatement employeeStatementobj = new HRM_EmployeeStatement();
                employeeStatementobj.EID = Convert.ToString(Session["EID"]);
                employeeStatementobj.NameOfRelative = txtbxNameOfRelative.Text;
                employeeStatementobj.RelativeEID = txtbxEidNumber.Text;
                employeeStatementobj.Relation = txtbxRelation.Text;
                employeeStatementobj.EDIT_DATE = DateTime.Now;
                employeeStatementobj.EDIT_USER = ((SessionUser)Session["SessionUser"]).UserId;
                employeeStatementobj.OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                int result = employeeSetupDal.SaveEmployeeSatement(employeeStatementobj);
                if (result == 1)
                {
                    //lblMgStament.Text = "Data Save Successfully.";
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Data Save successfully!')", true);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            ClearStatmentInformationField();
        }


        protected void ClearExperienceInformationField()
        {
            txtCompanyName.Text = string.Empty;
            txtCompanyBussiness.Text = string.Empty;
            txtCompanyLocation.Text = string.Empty;
            txtWorkingDepartment.Text = string.Empty;
            txtPositionHeld.Text = string.Empty;
            txtAreaOfExperience.Text = string.Empty;
            txtResponsibilities.Text = string.Empty;
            txtDuration.Text = string.Empty;
        }

        protected void ClearSkillInformationField()
        {
            txtSpecialization.Text = string.Empty;
            txtSkillDescription.Text = string.Empty;
            txtExtratActivities.Text = string.Empty;
        }

        protected void ClearStatmentInformationField()
        {
            txtbxNameOfRelative.Text = string.Empty;
            txtbxRelation.Text = string.Empty;
            txtbxEidNumber.Text = string.Empty;
        }
    }
}
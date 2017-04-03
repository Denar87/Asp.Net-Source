using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ERPSSL.HRM.BLL;
using ERPSSL.HRM.DAL;
using ERPSSL;

namespace ERPSSL.HRM.UserControls
{
    public partial class ExperienceEdit : System.Web.UI.UserControl
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
                getStatementInfo();
            }
        }

        private void getStatementInfo()
        {
            try
            {
                string eid = Convert.ToString(Session["EID"]);
                string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                List<HRM_EmployeeStatement> employeeStatments = employeeSetupDal.GetStatementList(eid, OCODE);
                if (employeeStatments.Count > 0)
                {
                    foreach (HRM_EmployeeStatement aitem in employeeStatments)
                    {
                        lblNameOfRelative.Text = aitem.NameOfRelative;
                        lblEid.Text = aitem.RelativeEID;
                        lblRelation.Text = aitem.Relation;
                    }
                }

            }
            catch (Exception)
            {
                
                throw;
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
        protected void btnSkillceedit_Click(object sender, EventArgs e)
        {
            Button imgbtn = (Button)sender;
            GridViewRow row = (GridViewRow)imgbtn.NamingContainer;
            try
            {
                string skId = "";
                Label lblskillId = (Label)gradViewSkills.Rows[row.RowIndex].FindControl("lblSkillId");
                if (lblskillId != null)
                {                    
                    string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                    skId = lblskillId.Text;
                  
                    List<HRM_Skills> skills = skillbll.getSkill(skId, OCODE);
                    foreach (HRM_Skills skill in skills)
                    {
                        hidSkillId.Value = skill.SkillId.ToString();
                    txtbxSpecialization.Text = skill.Skill_Specialization;
                    txtbxExtraCrricular.Text = skill.Skill_ExtraActivities;
                    txtbxDescription.Text = skill.Skill_Description;   
                    }
                }

                btnedit.Visible = true;
                btnAdd.Visible = true;
                btnSkillUpdate.Text = "Update";
                ModalPopupExtender1.Show();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        protected void btnSkillUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                HRM_Skills skill = new HRM_Skills();
                skill.EID = Convert.ToString(Session["EID"]);
                skill.Skill_Specialization = txtbxSpecialization.Text;
                skill.Skill_ExtraActivities = txtbxExtraCrricular.Text;
                skill.Skill_Description = txtbxDescription.Text;
                if (btnSkillUpdate.Text == "Submit")
                {
                    skill.EDIT_USER = ((SessionUser)Session["SessionUser"]).UserId;
                    skill.EDIT_DATE = DateTime.Now;                    
                    skill.OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                    int result = employeeSetupDal.InsertEmpSkills(skill);
                    if (result == 1)
                    {
                        ClearSkills();
                        lblSkillMessage.Text = "Data Save Successfully";
                    }
                }
                else
                {
                    int skillId = Convert.ToInt32(hidSkillId.Value);
                    int result = employeeSetupDal.updateSkillInfo(skill, skillId);
                    if (result == 1)
                    {
                        lblSkillMessage.Text = "Data Update Successfully";
                    }
                    
                }

            }
            catch (Exception)
            {
                
                throw;
            }


        }

        private void ClearSkills()
        {
            txtbxSpecialization.Text = "";
            txtbxExtraCrricular.Text = "";
             txtbxDescription.Text="";
        }

        protected void btnStatement_Click(object sender, EventArgs e)
        {
            try
            {
                string eid = Convert.ToString(Session["EID"]);
                string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                List<HRM_EmployeeStatement> employeeStatments = employeeSetupDal.GetStatementList(eid, OCODE);
                if (employeeStatments.Count > 0)
                {
                    foreach (HRM_EmployeeStatement aitem in employeeStatments)
                    {
                        txtbxNameOfRelative.Text = aitem.NameOfRelative;
                        txtbxEId.Text = aitem.RelativeEID;
                        txtbxRelation.Text = aitem.Relation;
                    }
                }


                //Button2.Visible = true;
                Button3.Visible = true;
                ModalPopupExtender3.Show();
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        protected void statemenUpdate_Click(object sender, EventArgs e)
        {
            try
            {

                string empid = "";
                string eid = Convert.ToString(Session["EID"]);
                string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                List<HRM_EmployeeStatement> employeeStatments = employeeSetupDal.GetStatementList(eid, OCODE);
                if (employeeStatments.Count > 0)
                {
                    foreach (HRM_EmployeeStatement aitem in employeeStatments)
                    {
                        empid = aitem.EID;
                        
                    }
                }

                HRM_EmployeeStatement employeeStatementobj = new HRM_EmployeeStatement();

                employeeStatementobj.EID = Convert.ToString(Session["EID"]);
                employeeStatementobj.NameOfRelative = txtbxNameOfRelative.Text;
                employeeStatementobj.RelativeEID = txtbxEId.Text;
                employeeStatementobj.Relation = txtbxRelation.Text;
                employeeStatementobj.EDIT_DATE = DateTime.Now;
                employeeStatementobj.EDIT_USER = ((SessionUser)Session["SessionUser"]).UserId;
                employeeStatementobj.OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                if (empid != "")
                {
                    int result = employeeSetupDal.UpdateEmployeeSatement(employeeStatementobj, eid);
                    if (result == 1)
                    {
                        ClearStatement();
                        lblStatementMessage.Text = "Data Update Successfully.";
                        getStatementInfo();

                    }
                }
                else
                {
                    int result = employeeSetupDal.SaveEmployeeSatement(employeeStatementobj);
                    if (result == 1)
                    {
                        ClearStatement();
                        lblStatementMessage.Text = "Data Save Successfully.";
                        getStatementInfo();

                    }
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        private void ClearStatement()
        {
             txtbxNameOfRelative.Text="";
             txtbxEId.Text="";
             txtbxRelation.Text="";
        }


        protected void btnexperienceEdit_Click(object sender, EventArgs e)
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
                    //int result = experienceBll.DeleteexprienceIdandOcode(exId, OCODE);
                    HRM_Experiences expericence = experienceBll.GetAExprenceByExpericenceId(exId, OCODE);
                    ExperienceId.Value = exId;
                    txtbxCompanyName.Text = expericence.Experience_Company;
                    txtbxBusiness.Text = expericence.Experience_CompanyBussiness;
                    txtbxCompanyLocation.Text = expericence.Experience_CompanyLocation;
                    txtbxWorkingLoction.Text = expericence.Experience_CompanyDepartment;
                    txtbxPostionHeld.Text = expericence.Experience_PositionHeld;
                    txtbxExpericenceArea.Text = expericence.Experience_AreaOfExperience;
                    txtbxResposibities.Text = expericence.EExperience_Responsibilites;
                    txtbxDuration.Text = expericence.Experience_Duration;
                }

                btnedit.Visible = true;
                btnAdd.Visible = true;
                btnAdd.Text = "Update";
                ModalPopupExtender.Show();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        protected void btnAdd_click(object sender, EventArgs e)
        {
            HRM_Experiences objexpericence = new HRM_Experiences();         
            string employeid = objexpericence.EID = Convert.ToString(Session["EID"]);
            objexpericence.Experience_Company = txtbxCompanyName.Text;
            objexpericence.Experience_CompanyBussiness = txtbxBusiness.Text;
            objexpericence.Experience_CompanyLocation = txtbxCompanyLocation.Text;
            objexpericence.Experience_CompanyDepartment = txtbxWorkingLoction.Text;
            objexpericence.Experience_PositionHeld = txtbxPostionHeld.Text;
            objexpericence.Experience_AreaOfExperience = txtbxExpericenceArea.Text;
            objexpericence.EExperience_Responsibilites = txtbxResposibities.Text;
            objexpericence.Experience_Duration = txtbxDuration.Text;
            if (btnAdd.Text == "Submit")
            {
                ClearExperience();
                objexpericence.EDIT_USER = ((SessionUser)Session["SessionUser"]).UserId;
                objexpericence.EDIT_DATE = DateTime.Now;            
                objexpericence.OCODE = ((SessionUser)Session["SessionUser"]).OCode;

                int result = employeeSetupDal.InsertEmpExperiences(objexpericence);
                if (result == 1)
                {
                    lblModalMessage.Text = "Data Save Successfully";
                    getExperienceInfo();
                }
            }
            else
            {
                int exId = Convert.ToInt32(ExperienceId.Value);
                int result = employeeSetupDal.UpdateExperienceEdit(exId, objexpericence);
                if (result == 1)
                {
                    lblModalMessage.Text = "Data Update Successfully";
                    getExperienceInfo();
                }
            }
        }

        private void ClearExperience()
        {
           txtbxCompanyName.Text="";
             txtbxBusiness.Text="";
             txtbxCompanyLocation.Text = "";
             txtbxWorkingLoction.Text = ""; ;
             txtbxPostionHeld.Text = "";
             txtbxExpericenceArea.Text = "";
             txtbxResposibities.Text = "";
          txtbxDuration.Text="";
        }

        protected void BtnEdit_Click(object sender, EventArgs e)
        {
            btnedit.Visible = true;
            btnAdd.Visible = true;
            ModalPopupExtender.Show();

        }


        protected void BtnEdits_Click(object sender, EventArgs e)
        {
           // btnSkilReset.Visible = true;
            btnSkillUpdate.Visible = true;
            ModalPopupExtender1.Show();
        }
    }
}
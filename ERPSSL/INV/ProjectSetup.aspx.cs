using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ERPSSL.INV.DAL;
using ERPSSL.INV.BLL;

namespace ERPSSL.INV
{
    public partial class ProjectSetup : System.Web.UI.Page
    {
    
        private ERPSSL_INVEntities _context = new ERPSSL_INVEntities();
        ProjectBLL projectBll = new ProjectBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetAllProject();
            }
        }

        private void GetAllProject()
        {
            try
            {
                List<Inv_Project> project = projectBll.GetAllProject();
                if (project.Count > 0)
                {
                    grdProjectValue.DataSource = project;
                    grdProjectValue.DataBind();
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {

                Inv_Project InvProject = new Inv_Project();

                InvProject.Project_Name = txtProjectName.Text;
                InvProject.Project_Code = txtProjectCode.Text;
                InvProject.Description = txtDescription.Text; 
                    if (btnSubmit.Text == "Submit")
                    {
                        int Projectcount = (from Prj in _context.Inv_Project
                                            where Prj.Project_Code == InvProject.Project_Code
                                            select Prj.Project_Id).Count();

                        InvProject.EditDate = DateTime.Now;
                        InvProject.EditUser = ((SessionUser)Session["SessionUser"]).UserId;
                        InvProject.OCode = ((SessionUser)Session["SessionUser"]).OCode;
                       // InvProject.EditDate = DateTime.Now();

                        if (Projectcount == 0)
                        {
                        int result = projectBll.InsertProject(InvProject);
                        if (result == 1)
                        {
                            //lblMessage.Text = "Data Saved Successfully";
                           // lblMessage.ForeColor = System.Drawing.Color.Green;
                            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Data Saved Successfully')", true); 
                            GetAllProject();
                            txtProjectName.Text = "";
                            txtProjectCode.Text = "";
                            txtDescription.Text = "";
                            txtProjectName.Focus();
                         
                        }
                        else
                        {
                            //lblMessage.Text = "Data Saving Failure";
                            //lblMessage.ForeColor = System.Drawing.Color.Red;
                            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Data Saving Failure')", true); 
                        }
                        }
                        else
                        {
                           // lblMessage.Text = "Data Already Exist";
                            //lblMessage.ForeColor = System.Drawing.Color.Red;
                            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Data Already Exist')", true); 
                            txtProjectCode.Text = ""; 
                            txtProjectCode.Focus();
                            btnSubmit.Text = "Submit";
                        }
                    }
                    else
                    {
                        int projectId = Convert.ToInt32(hdfProjectID.Value);

                       int result = projectBll.UpdateProject(InvProject, projectId);
                        if (result == 1)
                        {
                           // lblMessage.Text = "Data Updated Sucessfully";
                            //lblMessage.ForeColor = System.Drawing.Color.Green;
                            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Data Updated Sucessfully')", true);
                            GetAllProject();

                            txtProjectName.Text = "";
                            txtProjectCode.Text = "";
                            txtDescription.Text = "";
                            txtProjectName.Focus();
                            btnSubmit.Text = "Submit";
                        }
                        else
                        {
                            //lblMessage.Text = "Data Updating failure";
                           // lblMessage.ForeColor = System.Drawing.Color.Red;
                            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Data Updating failure')", true);

                        }
                    }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }


        protected void ImgProjectEdit_Click(object sender, EventArgs e)
        {
            lblMessage.Text = "";
            List<Inv_Project> project = new List<Inv_Project>();
            ImageButton imgbtn = (ImageButton)sender;
            GridViewRow row = (GridViewRow)imgbtn.NamingContainer;

            try
            {
                string ProjectId = "";
                Label lblProjectId = (Label)grdProjectValue.Rows[row.RowIndex].FindControl("lblProjectId");
                if (lblProjectId != null)
                {
                    ProjectId = lblProjectId.Text;
                    project = projectBll.GetProjectId(ProjectId);

                    if (project.Count > 0)
                    {
                        foreach (Inv_Project aProject in project)
                        {
                            hdfProjectID.Value = aProject.Project_Id.ToString();
                            txtProjectName.Text = aProject.Project_Name;
                            txtProjectCode.Text = aProject.Project_Code;
                            txtDescription.Text = aProject.Description;

                        }
                        if (btnSubmit.Text == "Submit")
                        {
                            btnSubmit.Text = "Update";
                        }

                    }

                }

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

        protected void grdProjectValue_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdProjectValue.PageIndex = e.NewPageIndex;
            GetAllProject();
        }

    }
}
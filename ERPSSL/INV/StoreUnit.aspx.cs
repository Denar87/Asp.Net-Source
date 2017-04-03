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
    public partial class StoreUnit : System.Web.UI.Page
    {

        private ERPSSL_INVEntities _context = new ERPSSL_INVEntities();

        StoreUnitBLL aStoreUnitBLL = new StoreUnitBLL();
        protected void Page_Load(object sender, EventArgs e)
        { 
                if (!IsPostBack)
                {
                    GetAllStoreUnit();
                }
               
                if (!IsPostBack)
                {
                    LoadStoreUnitType();
                } 
        }

        private void LoadStoreUnitType()
        {
            ddlstoreunit.DataSource = aStoreUnitBLL.GetAllStoreUnitType();
            ddlstoreunit.DataValueField = "Store_UnitType_Id";
            ddlstoreunit.DataTextField = "Store_UnitType_Name";
            ddlstoreunit.DataBind();
            ddlstoreunit.Items.Insert(0, new ListItem("---Select One---", "0"));
        }

        private void GetAllStoreUnit()
        {
            try
            {
                List<Inv_Store_Unit> project = aStoreUnitBLL.GetAllStoreUnit();
                if (project.Count > 0)
                {
                    grdStoreUnitValue.DataSource = project;
                    grdStoreUnitValue.DataBind();
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

                Inv_Store_Unit InvStoreUnit = new Inv_Store_Unit();

                InvStoreUnit.Store_Unit_Name = txtName.Text;
                InvStoreUnit.Unit_Track_No = txtUnitTrackNo.Text;
                InvStoreUnit.Store_Unit_Type_Id = Convert.ToInt32(ddlstoreunit.SelectedValue);
                if (txtDescription.Text == "")
                {
                    InvStoreUnit.Description = "n/a";
                }
                else
                {
                    InvStoreUnit.Description = txtDescription.Text;
                }
                InvStoreUnit.Location = txtLocation.Text;

                if (btnSubmit.Text == "Submit")
                {
                    int Projectcount = (from Prj in _context.Inv_Store_Unit
                                        where Prj.Store_Unit_Name == InvStoreUnit.Store_Unit_Name
                                        select Prj.Store_Unit_Id).Count();

                    InvStoreUnit.EditUser = ((SessionUser)Session["SessionUser"]).UserId;
                    InvStoreUnit.OCode = ((SessionUser)Session["SessionUser"]).OCode;

                    if (Projectcount == 0)
                    {
                        int result = aStoreUnitBLL.InsertProject(InvStoreUnit);
                        if (result == 1)
                        {
                           // lblMessage.Text = "Data Saved Successfully";
                           // lblMessage.ForeColor = System.Drawing.Color.Green;
                            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Data Saved Successfully')", true);
                            GetAllStoreUnit();
                            txtName.Text = "";
                            txtName.Focus();
                            txtUnitTrackNo.Text = "";
                            ddlstoreunit.ClearSelection();
                            txtLocation.Text = "";
                            txtDescription.Text = "";
                           
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
                       // lblMessage.ForeColor = System.Drawing.Color.Red;
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Data Already Exist')", true);
                        txtName.Text = "";
                        txtName.Focus();
                        txtUnitTrackNo.Text = "";
                        ddlstoreunit.ClearSelection();
                        txtLocation.Text = "";
                        txtDescription.Text = "";
                        btnSubmit.Text = "Submit";
                    }
                }
                else
                {
                    int projectId = Convert.ToInt32(hdfID.Value);

                    int result = aStoreUnitBLL.UpdateProject(InvStoreUnit, projectId);
                    if (result == 1)
                    {
                        //lblMessage.Text = "Data Updated Sucessfully";
                       // lblMessage.ForeColor = System.Drawing.Color.Green;
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Data Updated Sucessfully')", true);
                        GetAllStoreUnit();
                        txtName.Text = "";
                        txtName.Focus();
                        txtUnitTrackNo.Text = "";
                        ddlstoreunit.ClearSelection();
                        txtLocation.Text = "";
                        txtDescription.Text = "";
                        btnSubmit.Text = "Submit";
                    }
                    else
                    {
                       // lblMessage.Text = "Data Updating failure";
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
            List<Inv_Store_Unit> project = new List<Inv_Store_Unit>();
            ImageButton imgbtn = (ImageButton)sender;
            GridViewRow row = (GridViewRow)imgbtn.NamingContainer;

            try
            {
                string ProjectId = "";
                Label lblId = (Label)grdStoreUnitValue.Rows[row.RowIndex].FindControl("lblId");
                if (lblId != null)
                {
                    ProjectId = lblId.Text;
                    project = aStoreUnitBLL.GetProjectId(ProjectId);

                    if (project.Count > 0)
                    {
                        foreach (Inv_Store_Unit aProject in project)
                        {
                            hdfID.Value = aProject.Store_Unit_Id.ToString();
                            txtName.Text = aProject.Store_Unit_Name;
                            txtUnitTrackNo.Text = aProject.Unit_Track_No;
                            txtLocation.Text = aProject.Location;
                            txtDescription.Text = aProject.Description;
                            ddlstoreunit.SelectedValue = aProject.Store_Unit_Type_Id.ToString();
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

        protected void grdStoreUnitValue_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdStoreUnitValue.PageIndex = e.NewPageIndex;
            GetAllStoreUnit();
        }

    }
}
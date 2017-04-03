using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ERPSSL.Adminpanel.DAL;

namespace ERPSSL.Adminpanel
{
    public partial class AddRole : System.Web.UI.Page
    {
        RoleDAL roleDal = new RoleDAL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Session["UserID"] != null) && (Session["OCode"] != null))
            {
                if (!IsPostBack)
                {
                    getRoles();
                }
            }
            else
            {
                Response.Redirect("..\\AppGateway\\Login.aspx");
            }
        }

        private void getRoles()
        {
            try
            {

                string Ocode = Convert.ToString(((SessionUser)Session["SessionUser"]).OCode);
                List<tbl_UserRole> roles = roleDal.GetRoles(Ocode);
                if (roles.Count > 0)
                {
                    gridviewRole.DataSource = roles;
                    gridviewRole.DataBind();
                }


            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                tbl_UserRole userRoleObj = new tbl_UserRole();
                userRoleObj.RoleName = txtbxRoleName.Text;
                userRoleObj.EditUser = ((SessionUser)Session["SessionUser"]).UserId;
                userRoleObj.EditDate = DateTime.Now;
                if (BtnSave.Text == "Save Role")
                {
                    int result = roleDal.SaveRole(userRoleObj);
                    if (result == 1)
                    {
                        // lblStatus.Text = "Data Save Successfully";
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Data Saved Successfully')", true);
                    }
                }
                else
                {
                    int roleId = Convert.ToInt32(hidRoleId.Value);
                    int result = roleDal.UpdateRole(userRoleObj, roleId);
                    if (result == 1)
                    {
                        // lblStatus.Text = "Data Update Successfully";
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Data Update Successfully')", true);
                    }
                }
                getRoles();
                txtbxRoleName.Text = "";
                BtnSave.Text = "Save Role";
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void imgbtnRoleEdit_Click(object sender, EventArgs e)
        {
            ImageButton imgbtn = (ImageButton)sender;
            GridViewRow row = (GridViewRow)imgbtn.NamingContainer;
            try
            {
                string roleId = "";
                Label lblRoleId = (Label)gridviewRole.Rows[row.RowIndex].FindControl("lblRoleId");
                if (lblRoleId != null)
                {
                    string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                    roleId = lblRoleId.Text;
                    List<tbl_UserRole> Roles = roleDal.getRoleById(roleId, OCODE);

                    if (Roles.Count > 0)
                    {
                        foreach (tbl_UserRole role in Roles)
                        {
                            hidRoleId.Value = role.RoleID.ToString();
                            txtbxRoleName.Text = role.RoleName;

                        }
                        BtnSave.Text = "Update Role";
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        protected void gridviewRole_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridviewRole.PageIndex = e.NewPageIndex;
            getRoles();
        }
    }
}
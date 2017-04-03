using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ERPSSL.Adminpanel.BLL;
using ERPSSL.Adminpanel.DAL;
using ERPSSL.Adminpanel.DAL.Repository;

namespace ERPSSL.Adminpanel
{
    public partial class UpdateuserAccess : System.Web.UI.Page
    {
        ModulBLL modulBll = new ModulBLL();
        UserAccessBLL UserAccessBllObj = new UserAccessBLL();
        UserAccessBLL UserAccessBLLobj = new UserAccessBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Session["UserID"] != null) && (Session["OCode"] != null))
            {
                if (!IsPostBack)
                {
                    getUserList();
                    GetModules();
                }
            }
            else
            {
                Response.Redirect("..\\AppGateway\\Login.aspx");
            }
        }

        private void GetModules()
        {
            string Ocode = Convert.ToString(((SessionUser)Session["SessionUser"]).OCode);
            List<tbl_Module> modules = modulBll.GetModules(Ocode);
            drpModule.DataSource = modules.ToList();
            drpModule.DataTextField = "ModuleName";
            drpModule.DataValueField = "ModuleID";
            drpModule.DataBind();
            drpModule.Items.Insert(0, new ListItem("---Select---", "0"));
        }
        private void getUserList()
        {
            try
            {
                string Ocode = Convert.ToString(((SessionUser)Session["SessionUser"]).OCode);
                List<tbl_User> useres = UserAccessBllObj.GetUser(Ocode);
                if (useres.Count > 0)
                {
                    drpUserName.DataSource = useres;
                    drpUserName.DataTextField = "UserFullName";
                    drpUserName.DataValueField = "UserID";
                    drpUserName.DataBind();
                    drpUserName.Items.Insert(0, new ListItem("--Select--", "0"));
                }

            }
            catch (Exception)
            {

                throw;
            }
        }
        protected void drpRole_change(object sender, EventArgs e)
        {


            try
            {

                string UserId = drpUserName.SelectedValue.ToString();
                hiduserId.Value = drpUserName.SelectedValue.ToString();
                string Ocode = Convert.ToString(((SessionUser)Session["SessionUser"]).OCode);
                List<RUserAccessRole> userAccesses = UserAccessBLLobj.GetUserAccessInfoForDelete(Ocode, UserId);
                if (userAccesses.Count > 0)
                {
                    gridviewUserAccess.DataSource = userAccesses;
                    gridviewUserAccess.DataBind();
                }



            }
            catch (Exception)
            {

                throw;
            }

        }

        protected void imgDeletePagePermission_Click(object sender, EventArgs e)
        {
            ImageButton imgbtn = (ImageButton)sender;
            GridViewRow row = (GridViewRow)imgbtn.NamingContainer;
            string Ocode = Convert.ToString(((SessionUser)Session["SessionUser"]).OCode);
            try
            {
                string UserAccessId = "";
                Label lblUserAccessId = (Label)gridviewUserAccess.Rows[row.RowIndex].FindControl("lblUserAccessId");
                if (lblUserAccessId != null)
                {
                    UserAccessId = lblUserAccessId.Text;
                    int result = UserAccessBLLobj.DeleteUserAccessById(UserAccessId, Ocode);
                    if (result == 1)
                    {
                        GetUsrAccessList();
                        // lblStatus.Text = "Data Delete Successfully";
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Data Saved Successfully')", true);

                    }



                }

            }
            catch (Exception ex)
            {

                throw;
            }
        }

        private void GetUsrAccessList()
        {
            string userId = hiduserId.Value;
            string Ocode = Convert.ToString(((SessionUser)Session["SessionUser"]).OCode);
            List<RUserAccessRole> userAccesses = UserAccessBLLobj.GetUserAccessInfoForDelete(Ocode, userId);
            if (userAccesses.Count > 0)
            {
                gridviewUserAccess.DataSource = userAccesses;
                gridviewUserAccess.DataBind();
            }

        }

        protected void gridviewUserAccess_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            string UserId = drpUserName.SelectedValue.ToString();
            gridviewUserAccess.PageIndex = e.NewPageIndex;
            string Ocode = Convert.ToString(((SessionUser)Session["SessionUser"]).OCode);
            List<RUserAccessRole> userAccesses = UserAccessBLLobj.GetUserAccessInfoForDelete(Ocode, UserId);
            if (userAccesses.Count > 0)
            {
                gridviewUserAccess.DataSource = userAccesses;
                gridviewUserAccess.DataBind();
            }
        }

        protected void drpModule_change(object sender, EventArgs e)
        {
            try
            {
                string Ocode = Convert.ToString(((SessionUser)Session["SessionUser"]).OCode);
                string UserId = drpUserName.SelectedValue.ToString();
                int moduleId = Convert.ToInt16(drpModule.SelectedValue);
                List<RUserAccessRole> userAccesses = UserAccessBLLobj.GetUserAccessInfobyModuleandUserId(Ocode, UserId, moduleId);
                if (userAccesses.Count > 0)
                {

                    GetCatagoryName();
                    gridviewUserAccess.DataSource = userAccesses;
                    gridviewUserAccess.DataBind();
                }
                else
                {
                    gridviewUserAccess.DataSource = null;
                    gridviewUserAccess.DataBind();
                    drpFeature.DataSource = null;
                    drpFeature.DataTextField = "Name";
                    drpFeature.DataValueField = "categoryId";
                    drpFeature.DataBind();

                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void drpFeature_change(object sender, EventArgs e)
        {

            try
            {
                string Ocode = Convert.ToString(((SessionUser)Session["SessionUser"]).OCode);
                string UserId = drpUserName.SelectedValue.ToString();
                int moduleId = Convert.ToInt16(drpModule.SelectedValue);
                int featureId = Convert.ToInt16(drpFeature.SelectedValue);
                List<RUserAccessRole> userAccesses = UserAccessBLLobj.GetUserAccessInfobyModuleIdUserIdandFeatureId(Ocode, UserId, moduleId, featureId);
                if (userAccesses.Count > 0)
                {

                    // GetCatagoryName();
                    gridviewUserAccess.DataSource = userAccesses;
                    gridviewUserAccess.DataBind();
                }
                else
                {
                    gridviewUserAccess.DataSource = null;
                    gridviewUserAccess.DataBind();


                }

            }
            catch (Exception)
            {

                throw;
            }



        }

        private void GetCatagoryName()
        {

            try
            {
                CategoryBLL categorybll = new CategoryBLL();
                string Ocode = Convert.ToString(((SessionUser)Session["SessionUser"]).OCode);
                int moduleId = Convert.ToInt32(drpModule.SelectedValue);
                List<tbl_Category> categoryes = categorybll.getCategoryByModuleId(moduleId, Ocode);
                if (categoryes.Count > 0)
                {
                    drpFeature.DataSource = categoryes;
                    drpFeature.DataTextField = "Name";
                    drpFeature.DataValueField = "categoryId";
                    drpFeature.DataBind();
                    drpFeature.Items.Insert(0, new ListItem("--Select--", "0"));
                }
                else
                {
                    drpFeature.DataSource = null;
                    drpFeature.DataTextField = "Name";
                    drpFeature.DataValueField = "categoryId";
                    drpFeature.DataBind();
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
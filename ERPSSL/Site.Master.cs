using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ERPSSL.Adminpanel.BLL;
using ERPSSL.Adminpanel.DAL;
using ERPSSL.AppGateway.BOL;

namespace ERPSSL
{
    public partial class Site : System.Web.UI.MasterPage
    {
        ModulBLL modulObj = new ModulBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            lblCurrentDate.Text = DateTime.Now.Year.ToString();
            if ((Session["LoginName"]) == null)
            {
                Response.Redirect("AppGateway/Login.aspx");
            }
            else
            {
                this.lblUser.Text = Convert.ToString(Session["UserFullName"]);
                GetModulS();
            }
        }
        private void GetModulS()
        {
            string Ocode = ((SessionUser)Session["SessionUser"]).OCode;
            string RoleId = ((SessionUser)Session["SessionUser"]).RoleId;
            string UserId = ((SessionUser)Session["SessionUser"]).UserId.ToString();
            string UserType = ((SessionUser)Session["SessionUser"]).User_Level;

            if (UserType == "Administrator" || UserType == "SuperAdmin")
             {
                List<tbl_Module> modules = modulObj.GetModules(Ocode);

                if (modules.Count > 0)
                {
                    reptModuleList.DataSource = modules;
                    reptModuleList.DataBind();
                }
            }
            else
            {
                List<ModulBol> modules = modulObj.GetModulesById(UserId, Ocode).ToList();
                if (modules.Count > 0)
                {
                    reptModuleList.DataSource = modules;
                    reptModuleList.DataBind();
                }


            }


        }
        protected void lButtonModule_Click(object sender, EventArgs e)
        {
            var btnEdit = (LinkButton)sender;
            var item = (RepeaterItem)btnEdit.NamingContainer;
            var btn = (LinkButton)item.FindControl("lButtonModule");
            string FolderLink = btn.CommandArgument;
            string ModuleId = btn.CommandName;
            Response.Redirect(FolderLink);
        }

        //protected void lbtnLogout_Click(object sender, EventArgs e)
        //{
        //    this.lbtnLogout.Text = "Please wait...";
        //    this.lbtnLogout.ForeColor = System.Drawing.Color.White;
        //    Session.Abandon();
        //    Session.Clear();
        //    //Response.Redirect("AppGateway/Login.aspx");
        //    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Logout", "setInterval(function(){location.href='AppGateway/Login.aspx';},3000);", true);
        //}

    }
}
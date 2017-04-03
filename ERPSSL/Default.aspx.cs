using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ERPSSL.Adminpanel.BLL;
using ERPSSL.Adminpanel.DAL;
using ERPSSL.AppGateway.BOL;
using ERPSSL.Dashboard.BLL;
using ERPSSL.Dashboard.Repository;
using ERPSSL.HRM.BLL;
using ERPSSL.HRM.DAL;
using ERPSSL.HRM.DAL.Repository;


namespace ERPSSL
{
    public partial class Default : System.Web.UI.Page
    {
        ModulBLL modulObj = new ModulBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
        }


        //private void GetModulS()
        //{
        //    string Ocode = ((SessionUser)Session["SessionUser"]).OCode;
        //    string RoleId = ((SessionUser)Session["SessionUser"]).RoleId;
        //    string UserId = ((SessionUser)Session["SessionUser"]).UserId.ToString();
        //    string UserType = ((SessionUser)Session["SessionUser"]).User_Level;

        //    if (UserType == "Administrator")
        //    {
        //        List<tbl_Module> modules = modulObj.GetModules(Ocode);

        //        if (modules.Count > 0)
        //        {
        //            reptModuleList.DataSource = modules;
        //            reptModuleList.DataBind();
        //        }
        //    }
        //    else
        //    {
        //        List<ModulBol> modules = modulObj.GetModulesById(UserId, Ocode).ToList();
        //        if (modules.Count > 0)
        //        {
        //            reptModuleList.DataSource = modules;
        //            reptModuleList.DataBind();
        //        }


        //    }







        //}

        //protected void lButtonModule_Click(object sender, EventArgs e)
        //{
        //    var btnEdit = (LinkButton)sender;
        //    var item = (RepeaterItem)btnEdit.NamingContainer;
        //    var btn = (LinkButton)item.FindControl("lButtonModule");
        //    string FolderLink = btn.CommandArgument;
        //    string ModuleId = btn.CommandName;
        //    Response.Redirect(FolderLink);
        //}


    }
}
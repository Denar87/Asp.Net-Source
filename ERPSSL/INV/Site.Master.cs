using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ERPSSL.Adminpanel.BLL;
using ERPSSL.Adminpanel.DAL;
using ERPSSL.Adminpanel.DAL.Repository;
using ERPSSL.HRM.BLL;
using ERPSSL.AppGateway.BOL;

namespace ERPSSL.INV
{
    public partial class Site : System.Web.UI.MasterPage
    {
        ModulBLL modulObj = new ModulBLL();
        PageBLL pageObj = new PageBLL();
        CategoryBLL categorybll = new CategoryBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            lblCurrentDate.Text = DateTime.Now.Year.ToString();
            this.lblUser.Text = Convert.ToString(Session["UserFullName"]);
            int ModuleId = 32;
           GetPageByModulId(ModuleId);
           GetModulS();

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
                    reptModule.DataSource = modules;
                    reptModule.DataBind();

                }
            }
            else
            {
                List<ModulBol> modules = modulObj.GetModulesById(UserId, Ocode).ToList();
                if (modules.Count > 0)
                {
                    reptModule.DataSource = modules;
                    reptModule.DataBind();
                }


            }
        }
        private void GetPageByModulId(int ModuleId)
        {
            string Ocode = ((SessionUser)Session["SessionUser"]).OCode;
            string RoleId = ((SessionUser)Session["SessionUser"]).RoleId;
            string UserType = ((SessionUser)Session["SessionUser"]).User_Level;
            string usrerId = Convert.ToString(((SessionUser)Session["SessionUser"]).UserId);
            Guid use = Guid.Parse(usrerId);

            if (UserType == "Administrator" || UserType == "SuperAdmin")
            {
                List<Category> categorys = pageObj.GetCategoryByModulId(ModuleId, Ocode).ToList();
                if (categorys.Count > 0)
                {

                    reptManuList.DataSource = categorys;
                    reptManuList.DataBind();


                    foreach (RepeaterItem repeaterItem in reptManuList.Items)
                    {
                        string cateGoryId = ((HiddenField)repeaterItem.FindControl("hiddenCategoryID")).Value;

                        List<tbl_Page> pages = pageObj.getPagesByCategoryForSupperAdmin(cateGoryId, Ocode);

                        ((Repeater)(repeaterItem.FindControl("reptPageList"))).DataSource = pages;
                        ((Repeater)(repeaterItem.FindControl("reptPageList"))).DataBind();
                    }
                }
            }
            else
            {

                List<Category> categorys = pageObj.GetCategoryForUserByModulId(ModuleId, Ocode, use).ToList();
                if (categorys.Count > 0)
                {

                    reptManuList.DataSource = categorys;
                    reptManuList.DataBind();


                    foreach (RepeaterItem repeaterItem in reptManuList.Items)
                    {
                        string cateGoryId = ((HiddenField)repeaterItem.FindControl("hiddenCategoryID")).Value;

                        List<RPage> pages = pageObj.getPagesByCategoryForUser(cateGoryId, Ocode, use);

                        ((Repeater)(repeaterItem.FindControl("reptPageList"))).DataSource = pages;
                        ((Repeater)(repeaterItem.FindControl("reptPageList"))).DataBind();
                    }
                }

            }

            //string Ocode = ((SessionUser)Session["SessionUser"]).OCode;
            //List<tbl_Page> pages = pageObj.GetPageByModulId(ModuleId, Ocode);
            //if (pages.Count > 0)
            //{
            //    reptPageList.DataSource = pages;
            //    reptPageList.DataBind();
            //}
        }         


        protected void lbtnLogout_Click(object sender, EventArgs e)
        {
            this.lbtnLogout.Text = "Please wait...";
            this.lbtnLogout.ForeColor = System.Drawing.Color.White;
            Session.Abandon();
            Session.Clear();
            //Response.Redirect("AppGateway/Login.aspx");
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Logout", "setInterval(function(){location.href='../../AppGateway/Login.aspx';},3000);", true);

        }
    }
}

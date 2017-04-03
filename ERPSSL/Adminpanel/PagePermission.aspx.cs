using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ERPSSL.Adminpanel.BLL;
using ERPSSL.AppGateway.DAL;
using ERPSSL.Adminpanel.DAL;
using ERPSSL.Adminpanel.DAL.Repository;

namespace ERPSSL.Adminpanel
{
    public partial class PagePermission : System.Web.UI.Page
    {
        RoleBLL roleBll = new RoleBLL();
        PageBLL pageBll = new PageBLL();
        CategoryBLL categorybll = new CategoryBLL();
        ModulBLL modulBll = new ModulBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Session["UserID"] != null) && (Session["OCode"] != null))
            {
                if (!IsPostBack)
                {
                    GetRoles();
                    //GetPages();
                    // GetCategory();
                    // GetPagePermissionList();
                    GetModule();

                }
            }
            else
            {
                Response.Redirect("..\\AppGateway\\Login.aspx");
            }
        }

        private void GetModule()
        {


            string Ocode = Convert.ToString(((SessionUser)Session["SessionUser"]).OCode);
            List<tbl_Module> modules = modulBll.GetModules(Ocode);
            drpModulName.DataSource = modules.ToList();
            drpModulName.DataTextField = "ModuleName";
            drpModulName.DataValueField = "ModuleID";
            drpModulName.DataBind();
            drpModulName.Items.Insert(0, new ListItem("--Select--", "0"));

        }

        private void GetPagePermissionList()
        {
            try
            {
                string Ocode = Convert.ToString(((SessionUser)Session["SessionUser"]).OCode);
                List<RPagePermission> pagesPermissiones = pageBll.GetPagePermissionList(Ocode);
                if (pagesPermissiones.Count > 0)
                {
                    gridviewPagePermissiones.DataSource = pagesPermissiones;
                    gridviewPagePermissiones.DataBind();




                }


            }
            catch (Exception)
            {

                throw;
            }
        }

        private void CheckIsPermission()
        {
            try
            {
                int Role = Convert.ToInt16(drpRole.SelectedValue);
                int ModuleId = Convert.ToInt16(drpModulName.SelectedValue);
                int categoryId = Convert.ToInt32(drpCategory.SelectedValue);

                List<tbl_PagePermission> pagePermission = pageBll.GetPagePermissionListByRoleModuleCategoryWise(Role, ModuleId, categoryId);
                if (pagePermission.Count > 0)
                {

                    foreach (GridViewRow gvRow in gridviewPagePermissiones.Rows)
                    {

                        Label lblPagePermissionId = ((Label)gvRow.FindControl("lblPagePermissionId"));
                        CheckBox Checkbox = ((CheckBox)gvRow.FindControl("rowLevelCheckBox"));
                        int pageId = Convert.ToInt16(lblPagePermissionId.Text);
                        var ispage = pagePermission.FirstOrDefault(x => x.PageID == pageId);
                        if (ispage != null)
                        {
                            Checkbox.Checked = true;
                        }
                        else
                        {
                            Checkbox.Checked = false;

                        }



                    }

                }

            }
            catch (Exception)
            {

                throw;
            }
        }
        protected void drpCategory_Change(object sender, EventArgs e)
        {
            try
            {
                string Ocode = Convert.ToString(((SessionUser)Session["SessionUser"]).OCode);
                int categoryId = Convert.ToInt32(drpCategory.SelectedValue);
                List<tbl_Page> pages = pageBll.getPagesByCategory(categoryId, Ocode);
                if (pages.Count > 0)
                {
                    gridviewPagePermissiones.DataSource = pages;
                    gridviewPagePermissiones.DataBind();
                    CheckIsPermission();
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void headerLevelCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox headerChkBox = ((CheckBox)gridviewPagePermissiones.HeaderRow.FindControl("headerLevelCheckBox"));

            if (headerChkBox.Checked == true)
            {
                foreach (GridViewRow gvRow in gridviewPagePermissiones.Rows)
                {
                    CheckBox rowChkBox = ((CheckBox)gvRow.FindControl("rowLevelCheckBox"));

                    rowChkBox.Checked = true;//((CheckBox)sender).Checked;       
                }
            }
            else
            {
                foreach (GridViewRow gvRow in gridviewPagePermissiones.Rows)
                {
                    CheckBox rowChkBox = ((CheckBox)gvRow.FindControl("rowLevelCheckBox"));
                    rowChkBox.Checked = false;
                }
            }
        }

        //private void GetCategory()
        //{
        //    try
        //    {
        //        string Ocode = Convert.ToString(((SessionUser)Session["SessionUser"]).OCode);
        //        List<tbl_Category> categoryes = categorybll.GetAllCategoryes(Ocode);
        //        if (categoryes.Count > 0)
        //        {
        //            drpCategory.DataSource = categoryes;
        //            drpCategory.DataTextField = "Name";
        //            drpCategory.DataValueField = "categoryId";
        //            drpCategory.DataBind();
        //            drpCategory.Items.Insert(0, new ListItem("--Select--", "0"));
        //        }

        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}

        private void GetPages()
        {
            try
            {
                string Ocode = Convert.ToString(((SessionUser)Session["SessionUser"]).OCode);
                var Pages = pageBll.GetPagesforPagePermission(Ocode).ToList();
                if (Pages.Count > 0)
                {
                    //drpPageName.DataSource = Pages.ToList();
                    //drpPageName.DataTextField = "PageName";
                    //drpPageName.DataValueField = "PageID";
                    //drpPageName.DataBind();
                    //drpPageName.Items.Insert(0, new ListItem("--Select--", "0"));
                }

            }
            catch (Exception)
            {

                throw;
            }

        }

        private void GetRoles()
        {
            try
            {
                string Ocode = Convert.ToString(((SessionUser)Session["SessionUser"]).OCode);
                var roles = roleBll.GetRoles(Ocode).ToList();
                if (roles.Count > 0)
                {
                    drpRole.DataSource = roles.ToList();
                    drpRole.DataTextField = "RoleName";
                    drpRole.DataValueField = "RoleID";
                    drpRole.DataBind();
                    drpRole.Items.Insert(0, new ListItem("--Select--", "0"));
                }

            }
            catch (Exception)
            {

                throw;
            }

        }
        protected void drpModulName_change(object sender, EventArgs e)
        {
            try
            {
                string Ocode = Convert.ToString(((SessionUser)Session["SessionUser"]).OCode);
                int moduleId = Convert.ToInt32(drpModulName.SelectedValue);
                List<tbl_Category> categoryes = categorybll.getCategoryByModuleId(moduleId, Ocode);
                if (categoryes.Count > 0)
                {
                    drpCategory.DataSource = categoryes;
                    drpCategory.DataTextField = "Name";
                    drpCategory.DataValueField = "categoryId";
                    drpCategory.DataBind();
                    drpCategory.Items.Insert(0, new ListItem("--Select--", "0"));
                }
                else
                {
                    drpCategory.DataSource = null;
                    drpCategory.DataTextField = "Name";
                    drpCategory.DataValueField = "categoryId";
                    drpCategory.DataBind();
                }

            }
            catch (Exception)
            {

                throw;
            }
        }
        protected void BtnSave_Clcik(object sender, EventArgs e)
        {
            try
            {
                List<tbl_PagePermission> pagesPermissiones = new List<tbl_PagePermission>();

                CheckBox headerChkBox = ((CheckBox)gridviewPagePermissiones.HeaderRow.FindControl("headerLevelCheckBox"));
                if (headerChkBox.Checked == true)
                {
                    foreach (GridViewRow gvRow in gridviewPagePermissiones.Rows)
                    {
                        tbl_PagePermission pagePermissionobj = new tbl_PagePermission();
                        pagePermissionobj.RoleID = Convert.ToInt32(drpRole.SelectedValue);
                        //pagePermissionobj.PageID = Convert.ToInt32(drpPageName.SelectedValue);
                        pagePermissionobj.CategoryId = Convert.ToInt32(drpCategory.SelectedValue);
                        pagePermissionobj.ModuleId = Convert.ToInt32(drpModulName.SelectedValue);

                        pagePermissionobj.OCODE = Convert.ToString(((SessionUser)Session["SessionUser"]).OCode);
                        pagePermissionobj.EDIT_USER = ((SessionUser)Session["SessionUser"]).UserId;
                        pagePermissionobj.EDIT_DATE = DateTime.Now;

                        CheckBox rowChkBox = ((CheckBox)gvRow.FindControl("rowLevelCheckBox"));
                        Label lblPagePermissionId = ((Label)gvRow.FindControl("lblPagePermissionId"));
                        CheckBox rowCanVisit = ((CheckBox)gvRow.FindControl("chCanVisit"));
                        CheckBox rowCanEdit = ((CheckBox)gvRow.FindControl("ChCanEdit"));
                        CheckBox rowCanDelete = ((CheckBox)gvRow.FindControl("ChCanDelete"));
                        CheckBox rowcanExecute = ((CheckBox)gvRow.FindControl("ChCanExecute"));

                        pagePermissionobj.PageID = Convert.ToInt32(lblPagePermissionId.Text);
                        pagePermissionobj.CanVisit = Convert.ToBoolean(rowCanVisit.Checked);
                        pagePermissionobj.CanExecute = Convert.ToBoolean(rowcanExecute.Checked);
                        pagePermissionobj.CanEdit = Convert.ToBoolean(rowCanEdit.Checked);
                        pagePermissionobj.CanDelete = Convert.ToBoolean(rowCanDelete.Checked);
                        pagesPermissiones.Add(pagePermissionobj);
                        rowChkBox.Checked = true;//((CheckBox)sender).Checked;       
                    }
                }

                else
                {
                    foreach (GridViewRow gvRow in gridviewPagePermissiones.Rows)
                    {
                        CheckBox rowChkBox = ((CheckBox)gvRow.FindControl("rowLevelCheckBox"));

                        if (rowChkBox.Checked == true)
                        {
                            tbl_PagePermission pagePermissionobj = new tbl_PagePermission();
                            pagePermissionobj.RoleID = Convert.ToInt32(drpRole.SelectedValue);
                            //pagePermissionobj.PageID = Convert.ToInt32(drpPageName.SelectedValue);
                            pagePermissionobj.CategoryId = Convert.ToInt32(drpCategory.SelectedValue);
                            pagePermissionobj.ModuleId = Convert.ToInt32(drpModulName.SelectedValue);

                            pagePermissionobj.OCODE = Convert.ToString(((SessionUser)Session["SessionUser"]).OCode);
                            pagePermissionobj.EDIT_USER = ((SessionUser)Session["SessionUser"]).UserId;
                            pagePermissionobj.EDIT_DATE = DateTime.Now;

                            Label lblPagePermissionId = ((Label)gvRow.FindControl("lblPagePermissionId"));
                            CheckBox rowCanVisit = ((CheckBox)gvRow.FindControl("chCanVisit"));
                            CheckBox rowCanEdit = ((CheckBox)gvRow.FindControl("ChCanEdit"));
                            CheckBox rowCanDelete = ((CheckBox)gvRow.FindControl("ChCanDelete"));
                            CheckBox rowcanExecute = ((CheckBox)gvRow.FindControl("ChCanExecute"));

                            pagePermissionobj.PageID = Convert.ToInt32(lblPagePermissionId.Text);
                            pagePermissionobj.CanVisit = Convert.ToBoolean(rowCanVisit.Checked);
                            pagePermissionobj.CanExecute = Convert.ToBoolean(rowcanExecute.Checked);
                            pagePermissionobj.CanEdit = Convert.ToBoolean(rowCanEdit.Checked);
                            pagePermissionobj.CanDelete = Convert.ToBoolean(rowCanDelete.Checked);
                            pagesPermissiones.Add(pagePermissionobj);
                        }
                    }

                }

                int result = pageBll.SavePagePermission(pagesPermissiones);
                if (result == 1)
                {
                    //lblStatus.Text = "Data Save Successfully.";
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Data Saved Successfully')", true);
                }
            }


            catch (Exception)
            {

                throw;
            }
        }

        protected void gridviewPagePermissiones_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridviewPagePermissiones.PageIndex = e.NewPageIndex;
            GetPagePermissionList();
        }

        //protected void imgbtnModulEdit_Click(object sender, EventArgs e)
        //{
        //    ImageButton imgbtn = (ImageButton)sender;
        //    GridViewRow row = (GridViewRow)imgbtn.NamingContainer;

        //    try
        //    {
        //        GetPages();
        //        string pagePermissionId = "";
        //        Label lblPagePermissionId = (Label)gridviewPagePermissiones.Rows[row.RowIndex].FindControl("lblPagePermissionId");
        //        if (lblPagePermissionId != null)
        //        {
        //            string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
        //            pagePermissionId = lblPagePermissionId.Text;
        //            List<tbl_PagePermission> pagesPermissions = pageBll.GetPagePermissionByPagePermissionId(pagePermissionId, OCODE);

        //            if (pagesPermissions.Count > 0)
        //            {
        //                foreach (tbl_PagePermission pagePermisssion in pagesPermissions)
        //                {
        //                    hidPagePermissionID.Value = pagePermisssion.PermissionID.ToString();
        //                    drpRole.SelectedValue = pagePermisssion.RoleID.ToString();
        //                    drpCategory.SelectedValue = pagePermisssion.CategoryId.ToString();
        //                    drpPageName.SelectedValue = pagePermisssion.PageID.ToString();
        //                    drpModulName.SelectedValue = pagePermisssion.ModuleId.ToString();
        //                    //if (pagePermisssion.CanVisit == true)
        //                    //{

        //                    //    drpdownVisistStatus.Text = "True";
        //                    //}
        //                    //else
        //                    //{
        //                    //    drpdownVisistStatus.Text = "False";
        //                    //}

        //                    //if (pagePermisssion.CanEdit == true)
        //                    //{

        //                    //    drpdwnEditStatus.Text = "True";
        //                    //}
        //                    //else
        //                    //{
        //                    //    drpdownVisistStatus.Text = "False";
        //                    //}

        //                    //if (pagePermisssion.CanDelete == true)
        //                    //{

        //                    //    drpdwnDeleteStatus.Text = "True";
        //                    //}
        //                    //else
        //                    //{
        //                    //    drpdwnDeleteStatus.Text = "False";
        //                    //}

        //                    //if (pagePermisssion.CanExecute == true)
        //                    //{

        //                    //    drpExecuteStatus.Text = "True";
        //                    //}
        //                    //else
        //                    //{
        //                    //    drpExecuteStatus.Text = "False";
        //                    //}
        //                }

        //            }
        //            BtnSave.Text = "Update Page Permission";




        //        }
        //    }

        //    catch (Exception ex)
        //    {

        //        throw;
        //    }
        //}
    }
}
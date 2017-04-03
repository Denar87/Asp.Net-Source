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
    public partial class AddPage : System.Web.UI.Page
    {
        ModulBLL modulBll = new ModulBLL();
        PageBLL pageBll = new PageBLL();
        CategoryBLL categorybll = new CategoryBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Session["UserID"] != null) && (Session["OCode"] != null))
            {
                if (!IsPostBack)
                {
                    GetModules();
                    GetPages();
                }
            }
            else
            {
                Response.Redirect("..\\AppGateway\\Login.aspx");
            }
        }

        private void GetPages()
        {
            try
            {
                string Ocode = Convert.ToString(((SessionUser)Session["SessionUser"]).OCode);
                List<RPage> pages = pageBll.GetPages(Ocode).ToList();
                if (pages.Count > 0)
                {
                    gridviewPage.DataSource = pages;
                    gridviewPage.DataBind();
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
                GetCatagoryName();
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void GetIndividualModuleFeature()
        {
            try
            {
                string Ocode = Convert.ToString(((SessionUser)Session["SessionUser"]).OCode);
                int catagoryValue = Convert.ToInt16(drpwonCategoryName.SelectedValue);

                List<RPage> pages = pageBll.CategoryesForgridValue(Ocode, catagoryValue).ToList();
                if (pages.Count > 0)
                {
                    gridviewPage.DataSource = pages;
                    gridviewPage.DataBind();
                }
                else
                {
                    var obj = new List<RPage>();
                    obj.Add(new RPage());

                    // Bind the DataTable which contain a blank row to the GridView
                    gridviewPage.DataSource = obj;
                    gridviewPage.DataBind();

                    int columnsCount = gridviewPage.Columns.Count;
                    gridviewPage.Rows[0].Cells.Clear();// clear all the cells in the row
                    gridviewPage.Rows[0].Cells.Add(new TableCell()); //add a new blank cell
                    gridviewPage.Rows[0].Cells[0].ColumnSpan = columnsCount; //set the column span to the new added cell

                    gridviewPage.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Center;
                    gridviewPage.Rows[0].Cells[0].ForeColor = System.Drawing.Color.Red;
                    gridviewPage.Rows[0].Cells[0].Font.Bold = true;

                    //set No Results found to the new added cell
                    gridviewPage.Rows[0].Cells[0].Text = "No Page Found!";
                }

            }
            catch (Exception)
            {
                throw;
            }
        }

        private void GetCatagoryName()
        {
            string Ocode = Convert.ToString(((SessionUser)Session["SessionUser"]).OCode);
            int moduleId = Convert.ToInt32(drpModulName.SelectedValue);
            List<tbl_Category> categoryes = categorybll.getCategoryByModuleId(moduleId, Ocode);
            if (categoryes.Count > 0)
            {
                drpwonCategoryName.DataSource = categoryes;
                drpwonCategoryName.DataTextField = "Name";
                drpwonCategoryName.DataValueField = "categoryId";
                drpwonCategoryName.DataBind();
                drpwonCategoryName.Items.Insert(0, new ListItem("--Select--", "0"));
            }
            else
            {
                drpwonCategoryName.DataSource = null;
                drpwonCategoryName.DataTextField = "Name";
                drpwonCategoryName.DataValueField = "categoryId";
                drpwonCategoryName.DataBind();
            }
        }


        private void GetModules()
        {
            string Ocode = Convert.ToString(((SessionUser)Session["SessionUser"]).OCode);
            List<tbl_Module> modules = modulBll.GetModules(Ocode);
            drpModulName.DataSource = modules.ToList();
            drpModulName.DataTextField = "ModuleName";
            drpModulName.DataValueField = "ModuleID";
            drpModulName.DataBind();
            drpModulName.Items.Insert(0, new ListItem("--Select--", "0"));
        }

        protected void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                tbl_Page pageobj = new tbl_Page();
                string[] pageName = txtbxPageName.Text.Split('.');
                if (pageName.Length > 1)
                {
                    pageobj.PageName = pageName[0];
                }
                else
                {
                    pageobj.PageName = txtbxPageName.Text;
                }
                pageobj.PageUrl = txtbxPageUrl.Text;
                pageobj.ModuleID = Convert.ToInt32(drpModulName.SelectedValue);
                pageobj.categoryId = Convert.ToInt32(drpwonCategoryName.SelectedValue);
                pageobj.PageOrder = Convert.ToInt16(txtbxOrder.Text);
                if (drpdownStatus.SelectedItem.ToString() == "True")
                {
                    pageobj.Status = true;
                }
                else
                {
                    pageobj.Status = false;
                }

                pageobj.OCODE = Convert.ToString(((SessionUser)Session["SessionUser"]).OCode);
                pageobj.EDIT_USER = ((SessionUser)Session["SessionUser"]).UserId;
                pageobj.EDIT_DATE = DateTime.Now;


                if (BtnSave.Text == "Save Page")
                {
                    int result = pageBll.SavePage(pageobj);
                    if (result == 1)
                    {
                        //lblStatus.Text = "Page Save Successfully.";
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Page saved successfully')", true);
                        //GetPages();
                        GetIndividualModuleFeature();
                        ClearAllControll();
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Page saving error!')", true);
                    }
                }
                else
                {
                    int PageId = Convert.ToInt16(hidPageId.Value);
                    int result = pageBll.UpdatePage(pageobj, PageId);
                    if (result == 1)
                    {
                        //lblStatus.Text = "Page Update Successfully";
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Page updated successfully')", true);
                        GetIndividualModuleFeature();
                        //GetPages();
                        ClearAllControll();
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Page updating error!')", true);
                    }

                }


            }
            catch (Exception)
            {

                throw;
            }
        }

        private void ClearAllControll()
        {
            txtbxPageName.Text = "";
            txtbxPageUrl.Text = "";
            txtbxOrder.Text = "";
            BtnSave.Text = "Save Page";
            drpdownStatus.SelectedValue = "0";
            //GetModules();

        }

        protected void imgbtnModulEdit_Click(object sender, EventArgs e)
        {
            List<tbl_Page> pageobj = new List<tbl_Page>();
            ImageButton imgbtn = (ImageButton)sender;
            GridViewRow row = (GridViewRow)imgbtn.NamingContainer;

            try
            {
                string PageId = "";
                Label lblModulId = (Label)gridviewPage.Rows[row.RowIndex].FindControl("lblPageId");
                if (lblModulId != null)
                {
                    string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                    PageId = lblModulId.Text;
                    List<tbl_Page> pages = pageBll.getPage(PageId, OCODE);

                    if (pages.Count > 0)
                    {
                        foreach (tbl_Page page in pages)
                        {
                            hidPageId.Value = page.PageID.ToString();
                            drpdownStatus.SelectedValue = page.Status.ToString();
                            string moduleId = drpModulName.SelectedValue = page.ModuleID.ToString();
                            SetCategoryByModule(moduleId);
                            drpwonCategoryName.SelectedValue = page.categoryId.ToString();
                            txtbxPageName.Text = page.PageName;
                            txtbxPageUrl.Text = page.PageUrl;
                            txtbxOrder.Text = page.PageOrder.ToString();
                            BtnSave.Text = "Update Page";

                        }
                    }
                }
            }

            catch (Exception ex)
            {

                throw;
            }

        }

        private void SetCategoryByModule(string moduleId)
        {
            int modId = Convert.ToInt32(moduleId);
            string Ocode = Convert.ToString(((SessionUser)Session["SessionUser"]).OCode);
            List<tbl_Category> categoryes = categorybll.getCategoryByModuleId(modId, Ocode);
            if (categoryes.Count > 0)
            {
                drpwonCategoryName.DataSource = categoryes;
                drpwonCategoryName.DataTextField = "Name";
                drpwonCategoryName.DataValueField = "categoryId";
                drpwonCategoryName.DataBind();
                drpwonCategoryName.Items.Insert(0, new ListItem("--Select--", "0"));
            }

        }

        protected void gridviewPage_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridviewPage.PageIndex = e.NewPageIndex;
            GetPages();

        }

        protected void drpwonCategoryName_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                GetIndividualModuleFeature();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
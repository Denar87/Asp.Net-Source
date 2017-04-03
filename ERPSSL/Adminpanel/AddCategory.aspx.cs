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
    public partial class AddCategory : System.Web.UI.Page
    {
        ModulBLL modulBll = new ModulBLL();
        CategoryBLL categoryBll = new CategoryBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Session["UserID"] != null) && (Session["OCode"] != null))
            {
                if (!IsPostBack)
                {
                    GetModules();
                    GetCategoryes();
                }
            }
            else
            {
                Response.Redirect("..\\AppGateway\\Login.aspx");
            }
        }

        private void GetCategoryes()
        {
            try
            {
                string Ocode = Convert.ToString(((SessionUser)Session["SessionUser"]).OCode);
                List<RCategory> categoryes = categoryBll.CategoryesForgridview(Ocode).ToList();
                if (categoryes.Count > 0)
                {
                    gridviewCategory.DataSource = categoryes;
                    gridviewCategory.DataBind();

                }
            }
            catch (Exception)
            {

                throw;
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
            drpModulName.Items.Insert(0, new ListItem("---Select---", "0"));
        }
        protected void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {

                tbl_Category categoryObj = new tbl_Category();
                categoryObj.ModuleId = Convert.ToInt32(drpModulName.SelectedValue);
                categoryObj.Name = txtbxCateGoryName.Text;
                categoryObj.CategoryOrder = Convert.ToInt16(txtbxMenuOrder.Text);
                categoryObj.OCODE = Convert.ToString(((SessionUser)Session["SessionUser"]).OCode);
                categoryObj.EDIT_USER = ((SessionUser)Session["SessionUser"]).UserId;
                categoryObj.EDIT_DATE = DateTime.Now;

                if (drpdownStatus.SelectedItem.ToString() == "True")
                {
                    categoryObj.Status = true;
                }
                else
                {
                    categoryObj.Status = false;
                }


                if (BtnSave.Text == "Save Feature")
                {
                    int id = Convert.ToInt16(drpModulName.SelectedValue);
                    string ocode = Convert.ToString(((SessionUser)Session["SessionUser"]).OCode);

                    List<tbl_Category> categoryList = new List<tbl_Category>();
                    categoryList = categoryBll.categoryListForOrderCheck(id, ocode);

                    //if (IsExist(categoryList))
                    //{
                    //    System.Text.StringBuilder sb = new System.Text.StringBuilder();

                    //    sb.Append("<script type = 'text/javascript'>");
                    //    sb.Append("window.onload=function(){");

                    //    sb.Append("alert('");

                    //    sb.Append("This Menu Order is Already Existing");

                    //    sb.Append("')};");

                    //    sb.Append("</script>");

                    //    ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", sb.ToString());


                    //}
                    //else
                    //{
                    int result = categoryBll.SaveCategory(categoryObj);
                    if (result == 1)
                    {
                        // lblStatus.Text = "Data Saved Successfully.";
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Data Saved Successfully')", true);
                        clearControl();
                        GetCategoryes();
                    }

                    //}

                }
                else
                {
                    int categoryId = Convert.ToInt32(hidcategoryId.Value);
                    int result = categoryBll.UpdateCategoryById(categoryId, categoryObj);
                    if (result == 1)
                    {
                        // lblStatus.Text = "Data Updated Successfully.";
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Data Updated Successfully')", true);
                        clearControl();
                        GetCategoryes();
                    }
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        private bool IsExist(List<tbl_Category> categoryList)
        {
            try
            {
                bool status = false;
                int orderBy = Convert.ToInt16(txtbxMenuOrder.Text);
                foreach (tbl_Category aitem in categoryList)
                {
                    if (aitem.CategoryOrder == orderBy)
                    {
                        status = true;
                    }

                }
                return status;

            }
            catch (Exception)
            {

                throw;
            }
        }

        private void clearControl()
        {
            //GetModules();
            txtbxCateGoryName.Text = "";
            txtbxMenuOrder.Text = "";
            BtnSave.Text = "Save Feature";

        }
        protected void imgbtCategoryEdit_Click(object sender, EventArgs e)
        {

            ImageButton imgbtn = (ImageButton)sender;
            GridViewRow row = (GridViewRow)imgbtn.NamingContainer;
            try
            {
                string categorId = "";
                Label lblcategoryId = (Label)gridviewCategory.Rows[row.RowIndex].FindControl("lblCatgoryId");
                if (lblcategoryId != null)
                {
                    string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                    categorId = lblcategoryId.Text;
                    List<tbl_Category> categoryes = categoryBll.getcCategoryesById(categorId, OCODE);

                    if (categoryes.Count > 0)
                    {
                        foreach (tbl_Category cate in categoryes)
                        {
                            hidcategoryId.Value = cate.categoryId.ToString();
                            drpModulName.SelectedValue = cate.ModuleId.ToString();
                            txtbxCateGoryName.Text = cate.Name;
                            txtbxMenuOrder.Text = cate.CategoryOrder.ToString();
                            drpdownStatus.SelectedValue = cate.Status.ToString();
                            BtnSave.Text = "Update Feature";

                        }
                    }
                }
            }

            catch
            {


            }

        }

        protected void gridviewCategory_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {

                gridviewCategory.PageIndex = e.NewPageIndex;
                GetCategoryes();


            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void drpModulName_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string Ocode = Convert.ToString(((SessionUser)Session["SessionUser"]).OCode);
                int moduleId = Convert.ToInt16(drpModulName.SelectedValue);
                List<RCategory> categoryes = categoryBll.CategoryesForgrid(Ocode, moduleId).ToList();
                if (categoryes.Count > 0)
                {
                    gridviewCategory.DataSource = categoryes;
                    gridviewCategory.DataBind();

                }
            }
            catch (Exception)
            {

                throw;
            }

        }

    }
}
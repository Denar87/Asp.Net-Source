using ERPSSL.HMS.BLL;
using ERPSSL.HMS.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ERPSSL.HMS
{
    public partial class BillCategory : System.Web.UI.Page
    {
        BillCategory_BLL objCategory_BLL = new BillCategory_BLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Session["UserID"] != null) && (Session["OCode"] != null))
            {
                if (!IsPostBack)
                {
                    GetBillCategory();
                }
            }
            else
            {
                Response.Redirect("..\\AppGateway\\Login.aspx");
            }
        }

        protected void btnBillCateGorySubmit_Click(object sender, EventArgs e)
        {
            try
            {

                if (txtCategory.Text == "")
                {

                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Please Input Bill Category !!')", true);

                }
                else
                {
                    HMS_BillCategory objCatgory = new HMS_BillCategory();
                    
                    objCatgory.OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                    objCatgory.CategoryName = txtCategory.Text;

                    if (btnBillCateGorySubmit.Text == "Submit")
                    {

                        if (IsExist(objCatgory.CategoryName))
                        {
                            objCatgory.Create_User = ((SessionUser)Session["SessionUser"]).UserId;
                            objCatgory.Create_Date = DateTime.Now;
                            int result = objCategory_BLL.InsertBillCategory(objCatgory);
                            if (result == 1)
                            {

                                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Data Save successfully!')", true);
                            }
                        }
                        else
                        {

                            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Data Already Exists!')", true);
                        }
                    }
                    else
                    {
                        if (hidCategoryName.Value != txtCategory.Text)
                        {
                            if (IsExist(objCatgory.CategoryName))
                            {
                                objCatgory.Edit_User = ((SessionUser)Session["SessionUser"]).UserId;
                                objCatgory.Edit_Date = DateTime.Now;

                                int catId = Convert.ToInt32(hidCategoryId.Value);
                                int result = objCategory_BLL.UpdateBillCategory(objCatgory, catId);
                                if (result == 1)
                                {

                                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Data Update successfully!')", true);
                                }
                            }
                            else
                            {

                                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Data Already Exists!')", true);
                            }

                        }
                        else
                        {
                            objCatgory.Edit_User = ((SessionUser)Session["SessionUser"]).UserId;
                            objCatgory.Edit_Date = DateTime.Now;

                            int catId = Convert.ToInt32(hidCategoryId.Value);
                            int result = objCategory_BLL.UpdateBillCategory(objCatgory, catId);
                            if (result == 1)
                            {

                                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Data Update successfully!')", true);
                            }
                        }




                    }
                    GetBillCategory();
                    ClearBillCategoryUi();

                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

        private void GetBillCategory()
        {
            try
            {
                string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                var ctg = objCategory_BLL.GetAllBillCategory(OCODE).ToList();
                if (ctg.Count > 0)
                {

                    gridviewBillCateGory.DataSource = ctg.ToList();
                    gridviewBillCateGory.DataBind();
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void ClearBillCategoryUi()
        {
            try
            {
                txtCategory.Text = "";
                btnBillCateGorySubmit.Text = "Submit";
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

        private bool IsExist(string catName)
        {
            try
            {
                ERPSSL_HMSEntities _context = new ERPSSL_HMSEntities();
             
                bool status = false;
                int count = (from ctg in _context.HMS_BillCategory
                             where ctg.CategoryName == catName
                             select ctg.HMS_CategoryId).Count();
                if (count == 0)
                {
                    status = true;
                }

                return status;
            }
            catch (Exception)
            {

                throw;
            }
        }


        protected void imgbtnBillCategoryEdit_Click(object sender, ImageClickEventArgs e)
        {
            List<HMS_BillCategory> objCatg = new List<HMS_BillCategory>();
            ImageButton imgbtn = (ImageButton)sender;
            GridViewRow row = (GridViewRow)imgbtn.NamingContainer;

            try
            {
                string cateGoryId = "";
                Label lblSectionId = (Label)gridviewBillCateGory.Rows[row.RowIndex].FindControl("lblCategoryId");
                if (lblSectionId != null)
                {
                    string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                    cateGoryId = lblSectionId.Text.ToString();
                    objCatg = objCategory_BLL.GetBillCategoryoByCategoryId(cateGoryId, OCODE);

                    if (objCatg.Count > 0)
                    {
                        var bill = objCatg.FirstOrDefault();
                        hidCategoryId.Value = bill.HMS_CategoryId.ToString();
                        hidCategoryName.Value = txtCategory.Text = bill.CategoryName;

                        if (btnBillCateGorySubmit.Text == "Submit")
                        {
                            btnBillCateGorySubmit.Text = "Update";
                        }
                        
                    }
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

        protected void gridviewBillCateGory_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridviewBillCateGory.PageIndex = e.NewPageIndex;
            GetBillCategory();
            
        }
    }
}
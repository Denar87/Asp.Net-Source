using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ERPSSL.INV.DAL;
using ERPSSL.INV.BLL;
using ERPSSL.INV.DAL.Repository;

namespace ERPSSL.INV
{
    public partial class ItemSetup : System.Web.UI.Page
    {
        ProductBLL productBll = new ProductBLL();
        GroupBLL groupBll = new GroupBLL();
        UnitBLL unitBll = new UnitBLL();
        private ERPSSL_INVEntities _context = new ERPSSL_INVEntities();
        //ProjectBLL projectBll = new ProjectBLL();
        StoreUnitBLL aStoreUnitBLL = new StoreUnitBLL();
        StoreBLL aStoreBll = new StoreBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetProductInfo();
                GetAllGroup();
                GetAllUnit();
                //GetAllProject();
                //GetAllStore();
                //GetAllStoreUnit();
            }
        }
        //protected void GetAllProject()
        //{
        //    try
        //    {
        //        var row = projectBll.GetAllProject();
        //        if (row.Count > 0)
        //        {
        //            ddlProject.DataSource = row.ToList();
        //            ddlProject.DataTextField = "Project_Name";
        //            ddlProject.DataValueField = "Project_Id";
        //            ddlProject.DataBind();
        //            ddlProject.Items.Insert(0, new ListItem("---Select One---", "0"));
        //        }
        //    }
        //    catch
        //    {

        //    }
        //}

        //protected void ddlProject_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        var row = aStoreBll.GetStoreByProjectID(ddlProject.SelectedItem.Text);
        //        if (row.Count > 0)
        //        {
        //            ddlStoreName.DataSource = row.ToList();
        //            ddlStoreName.DataTextField = "StoreName";
        //            ddlStoreName.DataValueField = "Store_Id";
        //            ddlStoreName.DataBind();
        //            ddlStoreName.Items.Insert(0, new ListItem("---Select One---", "0"));
        //        }
        //    }
        //    catch
        //    {

        //    }
        //}

        //private void GetAllStore()
        //{
        //    try
        //    {
        //        var row = aStoreBll.GetStore();
        //        if (row.Count > 0)
        //        {
        //            ddlStoreName.DataSource = row.ToList();
        //            ddlStoreName.DataTextField = "StoreName";
        //            ddlStoreName.DataValueField = "Store_Id";
        //            ddlStoreName.DataBind();
        //            ddlStoreName.Items.Insert(0, new ListItem("---Select One---", "0"));
        //        }
        //    }
        //    catch
        //    {

        //    }
        //}

        //private void GetAllStoreUnit()
        //{
        //    try
        //    {
        //        var row = aStoreUnitBLL.GetAllStoreUnit();
        //        if (row.Count > 0)
        //        {
        //            ddlStoreUnit.DataSource = row.ToList();
        //            ddlStoreUnit.DataTextField = "Store_Unit_Name";
        //            ddlStoreUnit.DataValueField = "Store_Unit_Id";
        //            ddlStoreUnit.DataBind();
        //            ddlStoreUnit.Items.Insert(0, new ListItem("---Select One---", "0"));
        //        }
        //    }
        //    catch
        //    {

        //    }
        //}
        protected void GetAllGroup()
        {
            try
            {
                var row = groupBll.GetAllGroup();
                if (row.Count > 0)
                {
                    ddlGroupName.DataSource = row.ToList();
                    ddlGroupName.DataTextField = "GroupName";
                    ddlGroupName.DataValueField = "GroupId";
                    ddlGroupName.DataBind();
                    ddlGroupName.AppendDataBoundItems = false;
                    ddlGroupName.Items.Insert(0, new ListItem("---Select One---", "0"));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void GetAllUnit()
        {
            try
            {
                var row = unitBll.GetAllUnit();
                if (row.Count > 0)
                {
                    ddlUnit.DataSource = row.ToList();
                    ddlUnit.DataTextField = "UnitName";
                    ddlUnit.DataValueField = "UnitId";
                    ddlUnit.DataBind();
                    ddlUnit.AppendDataBoundItems = false;
                    ddlUnit.Items.Insert(0, new ListItem("---Select One---", "0"));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void ClearAllControl()
        {
            txtProductName.Text = "";
            txtStyleSize.Text = "";
            txtBrand.Text = "";
            txtReorder.Text = "";
            ddlGroupName.SelectedValue = "0";
            btnSubmit.Text = "Submit";
            ddlUnit.SelectedValue = "0";
            ddlGroupName.Focus();
            //ddlProject.ClearSelection();
            //ddlStoreName.ClearSelection();
            //ddlStoreUnit.ClearSelection();
        }

        private void GetProductInfo()
        {
            try
            {
                string OCODE = ((SessionUser)Session["SessionUser"]).OCode.ToString();
                //string OCODE = "8989";
                List<InvProductR> products = productBll.GetProduct(OCODE);
                if (products.Count > 0)
                {
                    grdProductInfo.DataSource = products;
                    grdProductInfo.DataBind();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        protected void grdProductInfo_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdProductInfo.PageIndex = e.NewPageIndex;
            GetProductInfo();
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                lblMessage.Text = "";
                Inv_Product productObj = new Inv_Product();
                productObj.ProductName = txtProductName.Text;
                productObj.StyleAndSize = txtStyleSize.Text;
                productObj.ReOrderQty = Convert.ToInt32(txtReorder.Text);
                productObj.Brand = "HB";
                productObj.GroupId = Convert.ToInt32(ddlGroupName.SelectedValue);
                productObj.UnitId = Convert.ToInt32(ddlUnit.SelectedValue);
                productObj.UnitName = ddlUnit.SelectedItem.Text;
                //productObj.ProductType = ddlAssetType.SelectedItem.Text.Trim();
                productObj.ProductType = "Consumable Product";
                //productObj.ProjectCode = ddlProject.SelectedValue;
                //productObj.StoreID = Convert.ToInt32(ddlStoreName.SelectedValue);
                //productObj.StoreUnitID = Convert.ToInt32(ddlStoreUnit.SelectedValue);

                int Productcount = (from prod in _context.Inv_Product
                                    where prod.ProductName == productObj.ProductName && prod.GroupId == productObj.GroupId && prod.Brand == productObj.Brand
                                    select prod.ProductId).Count();

                if (btnSubmit.Text == "Submit")
                {
                    if (Productcount == 0)
                    {
                        productObj.EditDate = DateTime.Now;
                        //productObj.EditUser = Guid.Parse("a376708d-757f-4777-bd05-bfc89b6971ce");
                        productObj.EditUser = ((SessionUser)Session["SessionUser"]).UserId;
                        productObj.OCode = ((SessionUser)Session["SessionUser"]).OCode.ToString();
                        //productObj.OCode = "8989";

                        int result = productBll.InsertProduct(productObj);
                        if (result == 1)
                        {
                            //lblMessage.Text = "Data Saved Successfully";
                            //lblMessage.ForeColor = System.Drawing.Color.Green;
                            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Data Saved Successfully')", true);

                        }
                        else
                        {
                          //  lblMessage.Text = "Data Saving Failure";
                          //  lblMessage.ForeColor = System.Drawing.Color.Red;
                            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Data Saving Failure')", true);
                        }
                    }
                    else
                    {
                        //lblMessage.Text = "Data Already Exist";
                        //lblMessage.ForeColor = System.Drawing.Color.Red;
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Data Already Exist')", true);
                        txtProductName.Text = "";
                        txtProductName.Focus();
                    }
                }
                else
                {
                    int productId = Convert.ToInt16(hdfProductID.Value);
                    int result = productBll.UpdateProduct(productObj, productId);
                    if (result == 1)
                    {
                       // lblMessage.Text = "Data Updated Sucessfully";
                       // lblMessage.ForeColor = System.Drawing.Color.Green;
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Data Updated Sucessfully')", true);
                    }
                    else
                    {
                       // lblMessage.Text = "Data Updating failure";
                       // lblMessage.ForeColor = System.Drawing.Color.Red;
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Data Updating failure')", true);
                    }
                }

                GetProductInfo();
                ClearAllControl();
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

        protected void imgbtnProductEdit_Click(object sender, EventArgs e)
        {
            try
            {
                lblMessage.Text = "";
                List<Inv_Product> products = new List<Inv_Product>();
                ImageButton imgbtn = (ImageButton)sender;
                GridViewRow row = (GridViewRow)imgbtn.NamingContainer;

                string productId = "";
                Label lblProductId = (Label)grdProductInfo.Rows[row.RowIndex].FindControl("lblProductId");
                if (lblProductId != null)
                {
                    string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                    //string OCODE = "8989";
                    productId = lblProductId.Text;
                    products = productBll.GetProductByIdandOcode(productId, OCODE);

                    if (products.Count > 0)
                    {
                        foreach (Inv_Product aproduct in products)
                        {
                            hdfProductID.Value = aproduct.ProductId.ToString();
                            txtProductName.Text = aproduct.ProductName;
                            txtBrand.Text = aproduct.Brand;
                            txtStyleSize.Text = aproduct.StyleAndSize;
                            txtReorder.Text = Convert.ToInt32(aproduct.ReOrderQty).ToString();
                            //ddlAssetType.SelectedValue = aproduct.ProductType;
                            ddlUnit.SelectedValue = Convert.ToString(aproduct.UnitId);
                            ddlGroupName.SelectedValue = Convert.ToString(aproduct.GroupId);
                            //ddlProject.SelectedValue = aproduct.ProjectCode;
                            //GetAllStore();
                            //ddlStoreName.SelectedValue = Convert.ToString(aproduct.StoreID);
                            //ddlStoreUnit.SelectedValue = Convert.ToString(aproduct.StoreUnitID);
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

        private void GetProductByGroup()
        {
            try
            {
                string OCODE = ((SessionUser)Session["SessionUser"]).OCode.ToString();
                //string OCODE = "8989";
                List<InvProductR> products = productBll.GetProductByGroupID(OCODE, Convert.ToInt16(ddlGroupName.SelectedValue));
                if (products.Count > 0)
                {
                    grdProductInfo.DataSource = products;
                    grdProductInfo.DataBind();
                }
                else
                {
                    //lblMessage.Text = "Data Updating failure";
                    //lblMessage.ForeColor = System.Drawing.Color.Red;
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No Item Found!')", true);
                    grdProductInfo.DataSource = null;
                    grdProductInfo.DataBind();
                }

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }
        protected void ddlGroupName_SelectedIndexChanged(object sender, EventArgs e)
        {
            //var products = productBll.GetProductByGroup(Convert.ToInt16(ddlGroupName.SelectedValue));
            //if (products.Count > 0)
            //{
            //    grdProductInfo.DataSource = products;
            //    grdProductInfo.DataBind();
            //}
            GetProductByGroup();
        }
    }
}
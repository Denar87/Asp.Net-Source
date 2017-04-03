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
    public partial class ItemPrice : System.Web.UI.Page
    {
        ProductBLL productBll = new ProductBLL();
        GroupBLL groupBll = new GroupBLL();
        UnitBLL unitBll = new UnitBLL();
        private ERPSSL_INVEntities _context = new ERPSSL_INVEntities();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetAllGroup();
                LoadGrid();
            }
        }

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
                    ddlGroupName.Items.Insert(0, new ListItem("Select One", "0"));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void ClearAllControl()
        {
            //txtProductName.Text = "";
            //txtStyleSize.Text = ""; 
            ddlGroupName.SelectedValue = "0";
            //btnSubmit.Text = "Submit";
            //ddlUnit.SelectedValue = "0";
            ddlGroupName.Focus();
        }

        protected void ddlProductGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int GroupID = Convert.ToInt16(ddlGroupName.SelectedValue);
                FillProductName(GroupID);
                LoadGridByGroupId(GroupID);
                lblMessage.Text = "";
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

        protected void ddlProductName_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //int ProductId = Convert.ToInt16(ddlGroupName.SelectedValue);
                int ProductId = Convert.ToInt16(ddlProductName.SelectedValue);
                FillBrandSize(ProductId);
                lblMessage.Text = "";
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

        private void FillBrandSize(int ProductId)
        {
            try
            {
                var result = productBll.FillBrandSize(ProductId).ToList();

                if (result.Count > 0)
                {
                    var objNew = result.First();
                    txtBrand.Text = objNew.Brand;
                    txtStyleSize.Text = objNew.StyleAndSize;
                    txtPrice.Text = Convert.ToString(objNew.Price);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

        private void LoadGridByGroupId(int GroupID)
        {
            try
            {
                string OCODE = ((SessionUser)Session["SessionUser"]).OCode.ToString();
                //string OCODE = "8989";
                List<InvProductR> products = productBll.GetProductByGroupID(OCODE, GroupID);
                if (products.Count > 0)
                {
                    grdProductInfo.DataSource = products;
                    grdProductInfo.DataBind();
                }

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

        private void FillProductName(int GroupID)
        {
            var row = groupBll.GetAllProduct(GroupID);
            if (row.Count > 0)
            {
                ddlProductName.DataSource = row.ToList();
                ddlProductName.DataTextField = "ProductName";
                ddlProductName.DataValueField = "ProductId";
                ddlProductName.DataBind();
                ddlProductName.AppendDataBoundItems = false;
                ddlProductName.Items.Insert(0, new ListItem("Select One", "0"));
            }
        }


        protected void grdProductInfo_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdProductInfo.PageIndex = e.NewPageIndex;
            LoadGrid();
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                Inv_Product invProduct = new Inv_Product();

                int ProductId = Convert.ToInt16(ddlProductName.SelectedValue);
                int GroupId = Convert.ToInt16(ddlGroupName.SelectedValue);

                invProduct.Price = Convert.ToDecimal(txtPrice.Text);
                int result = groupBll.UpdatePrice(invProduct, ProductId, GroupId);
                if (result == 1)
                {
                    //  lblMessage.Text = "Data Update successfully";
                    // lblMessage.ForeColor = System.Drawing.Color.Green;
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Data Updated Sucessfully')", true);
                    reset();
                    LoadGrid();
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

        private void LoadGrid()
        {
            try
            {
                string OCODE = ((SessionUser)Session["SessionUser"]).OCode.ToString();
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

        private void reset()
        {
            txtPrice.Text = "";
        }

        protected void imgbtnProductEdit_Click(object sender, EventArgs e)
        {
            lblMessage.Text = "";
            List<Inv_Product> products = new List<Inv_Product>();
            ImageButton imgbtn = (ImageButton)sender;
            GridViewRow row = (GridViewRow)imgbtn.NamingContainer;

            try
            {
                string productId = "";
                Label lblProductId = (Label)grdProductInfo.Rows[row.RowIndex].FindControl("lblProductId");
                Label lblGroupId = (Label)grdProductInfo.Rows[row.RowIndex].FindControl("lblGroupId");
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
                            lblProductId.Text = aproduct.ProductId.ToString();
                            lblGroupId.Text = aproduct.GroupId.ToString();
                            ddlGroupName.SelectedValue = aproduct.GroupId.ToString();
                            int GroupID = Convert.ToInt16(ddlGroupName.SelectedValue);
                            FillProductName(GroupID);
                            ddlProductName.SelectedValue = aproduct.ProductId.ToString();
                            ddlProductName.SelectedItem.Text = aproduct.ProductName;
                            txtBrand.Text = aproduct.Brand;
                            txtStyleSize.Text = aproduct.StyleAndSize;
                            txtPrice.Text = aproduct.Price.ToString();

                        }
                    }

                }

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }


    }
}
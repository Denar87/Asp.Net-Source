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
    public partial class Product : System.Web.UI.Page
    {
        ProductBLL productBll = new ProductBLL();
        GroupBLL groupBll = new GroupBLL();
        UnitBLL unitBll = new UnitBLL();
        private ERPSSL_INVEntities _context = new ERPSSL_INVEntities();

        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Session["UserID"] != null) && (Session["OCode"] != null))
            {
                if (!IsPostBack)
                {
                    GetProductInfo();
                    GetAllGroup();
                    GetAllUnit();
                    GetAllProductType();
                    //GetAllUnit();
                    //GetAllItemName();
                    //GetAllColorBrand();
                    //GetAllStyleSize();
                }
            }
            else
            {
                Response.Redirect("..\\AppGateway\\Login.aspx");
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
                    ddlGroupName.Items.Insert(0, new ListItem("--Select One--", "0"));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void GetAllItemName()
        {
            try
            {
                int gId = Convert.ToInt32(ddlGroupName.SelectedValue.ToString());
                var row = productBll.GetItemName(gId);
                if (row.Count > 0)
                {
                    ddlItemName.DataSource = row.ToList();
                    ddlItemName.DataTextField = "ProductName";
                    ddlItemName.DataValueField = "ProductName";
                    ddlItemName.DataBind();
                    //ddlItemName.AppendDataBoundItems = false;
                    ddlItemName.Items.Insert(0, new ListItem("--Select One--", "0"));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void GetAllColorBrand()
        {
            try
            {
                string  iId = ddlItemName.SelectedItem.Text;
                var row = productBll.GetIColorBrand(iId);
                if (row.Count > 0)
                {
                    ddlColorBrand.DataSource = row.ToList();
                    ddlColorBrand.DataTextField = "Brand";
                    ddlColorBrand.DataValueField = "Brand";
                    ddlColorBrand.DataBind();
                    ddlColorBrand.AppendDataBoundItems = false;
                    ddlColorBrand.Items.Insert(0, new ListItem("--Select One--", "0"));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void GetAllStyleSize()
        {
            try
            {
                string cbId = ddlColorBrand.SelectedItem.Text;
                var row = productBll.GetStyleSize(cbId);
                if (row.Count > 0)
                {
                    ddlStyleSize.DataSource = row.ToList();
                    ddlStyleSize.DataTextField = "StyleAndSize";
                    ddlStyleSize.DataValueField = "StyleAndSize";
                    ddlStyleSize.DataBind();
                    ddlStyleSize.AppendDataBoundItems = false;
                    ddlStyleSize.Items.Insert(0, new ListItem("--Select One--", "0"));
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
                var row = productBll.GetAllUnit();
                if (row.Count > 0)
                {
                    ddlUnit.DataSource = row.ToList();
                    ddlUnit.DataTextField = "UnitName";
                    ddlUnit.DataValueField = "UnitId";
                    ddlUnit.DataBind();
                    ddlUnit.AppendDataBoundItems = false;
                    ddlUnit.Items.Insert(0, new ListItem("--Select One--", "0"));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void GetAllProductType()
        {
            try
            {
                var row = productBll.LoadProductType();
                if (row.Count > 0)
                {
                    ddlItemType.DataSource = row.ToList();
                    ddlItemType.DataTextField = "ProductType";
                    ddlItemType.DataValueField = "ProductTypeId";
                    ddlItemType.DataBind();
                    ddlItemType.AppendDataBoundItems = false;
                    ddlItemType.Items.Insert(0, new ListItem("--Select One--", "0"));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
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

        protected void grdProductInfo_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdProductInfo.PageIndex = e.NewPageIndex;
            GetProductInfo();
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {

                Inv_ProductGroup groupObj = new Inv_ProductGroup();
                Inv_Product productObj = new Inv_Product();
                Inv_Unit _unitObj = new Inv_Unit();
                Inv_ProductType _ProductType = new Inv_ProductType();

                lblMessage.Text = "";
                #region //temGroup

                int grpID = 0;
                if (chkItemGroup.Checked == true)
                {
                    groupObj.GroupName = txtItemGroup.Text;
                    groupObj.EditUser = ((SessionUser)Session["SessionUser"]).UserId;

                    int Count = (from gplq in _context.Inv_ProductGroup
                                 join pn in _context.Inv_Product on gplq.GroupId equals pn.GroupId
                                 where gplq.GroupName == txtItemGroup.Text
                                 select gplq.GroupId).Count();
                    if (Count != 0)
                    {
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Item Group Already Exists!')", true);
                        return;
                    }
                    else
                    {
                        int result = productBll.InsertGroup(groupObj);
                        grpID = result;
                    }
                    productObj.GroupId = Convert.ToInt32(grpID.ToString());
                }
                else
                {
                    productObj.GroupId = Convert.ToInt32(ddlGroupName.SelectedValue);
                }
                #endregion

                if (chkItemName.Checked == true)
                {
                    productObj.ProductName = txtProductName.Text;
                }
                else
                {
                    productObj.ProductName = ddlItemName.SelectedItem.Text;
                }
                if (chkColorBrand.Checked == true)
                {
                    productObj.Brand = txtBrand.Text;
                }
                else
                {
                    productObj.Brand = ddlColorBrand.SelectedItem.Text;
                }
                if (chkStyleSize.Checked == true)
                {
                    productObj.StyleAndSize = txtStyleSize.Text;
                }
                else
                {
                    productObj.StyleAndSize = ddlStyleSize.SelectedItem.Text;
                }

                #region  Unit

                int unID = 0;
                if (chkUnit.Checked == true)
                {
                    _unitObj.UnitName = txtUnit.Text;
                    _unitObj.EditUser = ((SessionUser)Session["SessionUser"]).UserId;

                    int Count = (from un in _context.Inv_Unit
                                 join pn in _context.Inv_Product on un.UnitId equals pn.UnitId
                                 where un.UnitName == txtUnit.Text
                                 select un.UnitId).Count();
                    if (Count != 0)
                    {
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Unit Already Exists!')", true);
                        return;
                    }
                    else
                    {
                        int result = productBll.InsertUnit(_unitObj);
                        unID = result;
                    }
                    productObj.UnitId = Convert.ToInt32(unID.ToString());
                }
                else
                {
                    productObj.UnitId = Convert.ToInt32(ddlUnit.SelectedValue);
                }


                #endregion

                #region   Product Type

                int ptId = 0;

                if (chktemType.Checked == true)
                {
                    _ProductType.ProductType = txtItemType.Text;
                    _ProductType.OCode = ((SessionUser)Session["SessionUser"]).OCode.ToString();
                    _ProductType.EditUser = ((SessionUser)Session["SessionUser"]).UserId;
                    _ProductType.EditDate = DateTime.Now;

                    int Count = (from un in _context.Inv_ProductType
                                 join pn in _context.Inv_Product on un.ProductTypeId equals pn.ProductTypeId
                                 where un.ProductType == txtItemType.Text
                                 select un.ProductTypeId).Count();
                    if (Count != 0)
                    {
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Item Type Already Exists!')", true);
                        return;
                    }
                    else
                    {
                        int result = productBll.InsertProductType(_ProductType);
                        ptId = result;
                    }
                    productObj.ProductTypeId = Convert.ToInt32(ptId.ToString());
                }
                else
                {
                    productObj.ProductTypeId = Convert.ToInt32(ddlItemType.SelectedValue);
                }


                #endregion

                productObj.ReOrderQty = Convert.ToDouble(txtReorder.Text);

                //productObj.ProductType = ddlAssetType.SelectedItem.Text.Trim();
                
                if (btnSubmit.Text == "Submit")
                {
                    int Productcount = (from prod in _context.Inv_Product
                                        where prod.ProductName == productObj.ProductName && prod.Brand == productObj.Brand && prod.StyleAndSize == productObj.StyleAndSize
                                        select prod.ProductId).Count();
                    if (Productcount != 0)
                    {
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Item Name Already Exists!')", true);
                        return;
                    }

                    if (Productcount == 0)
                    {
                        productObj.EditDate = DateTime.Now;
                        productObj.EditUser = ((SessionUser)Session["SessionUser"]).UserId;
                        productObj.OCode = ((SessionUser)Session["SessionUser"]).OCode.ToString();

                        int result = productBll.InsertProduct(productObj);
                        if (result == 1)
                        {
                            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Data Saved Successfully')", true);
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Data Saving Failure')", true);
                        }
                    }
                    else
                    {
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
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Data Updated Successfully')", true);
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Data Updating failure')", true);
                    }
                }
                GetProductInfo();
                GetAllGroup();
                ClearAllControl();
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

        private void ClearAllControl()
        {
            txtProductName.Text = "";
            txtStyleSize.Text = "";
            txtBrand.Text = "";
            txtItemGroup.Text = "";
            txtReorder.Text = "0";
            txtItemType.Text = "";

            ddlGroupName.ClearSelection();
            ddlColorBrand.ClearSelection();
            ddlItemName.ClearSelection();
            ddlStyleSize.ClearSelection();
            ddlUnit.ClearSelection();
            ddlItemType.ClearSelection();

            chkColorBrand.Checked = false;
            chkItemGroup.Checked = false;
            chkItemName.Checked = false;
            chkStyleSize.Checked = false;
            chkUnit.Checked = false;
            chktemType.Checked = false;

            ddlGroupName.Visible = true;
            ddlColorBrand.Visible = true;
            ddlItemName.Visible = true;
            ddlStyleSize.Visible = true;
            ddlUnit.Visible = true;
            ddlItemType.Visible = true;

            txtProductName.Visible = false;
            txtStyleSize.Visible = false;
            txtBrand.Visible = false;
            txtItemGroup.Visible = false;
            txtUnit.Visible = false;
            txtItemType.Visible = false;


            btnSubmit.Text = "Submit";
            ddlGroupName.Focus();
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

                            ddlGroupName.SelectedValue = Convert.ToString(aproduct.GroupId);
                            GetAllItemName();
                            ddlItemName.SelectedValue = aproduct.ProductName;
                            GetAllColorBrand();
                            ddlColorBrand.SelectedValue = aproduct.Brand;
                            GetAllStyleSize();
                            ddlStyleSize.SelectedValue = aproduct.StyleAndSize;
                            GetAllUnit();
                            ddlUnit.SelectedValue = Convert.ToString(aproduct.UnitId);
                            ddlItemType.SelectedValue = Convert.ToString(aproduct.ProductTypeId);
                            txtReorder.Text = Convert.ToInt32(aproduct.ReOrderQty).ToString();
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

        protected void ddlGroupName_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetProductByGroup();
            GetAllItemName();
        }

        protected void ddlItemName_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetAllColorBrand();
        }

        protected void ddlColorBrand_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetAllStyleSize();
        }

        #region All Cheack Function

        protected void chkItemGroup_CheckedChanged(object sender, EventArgs e)
        {
            if (chkItemGroup.Checked == true)
            {
                txtItemGroup.Visible = true;
                ddlGroupName.Visible = false;
            }
            else
            {
                txtItemGroup.Visible = false;
                ddlGroupName.Visible = true;
            }
        }

        protected void chkItemName_CheckedChanged(object sender, EventArgs e)
        {
            if (chkItemName.Checked == true)
            {
                txtProductName.Visible = true;
                ddlItemName.Visible = false;
            }
            else
            {
                txtProductName.Visible = false;
                ddlItemName.Visible = true;
            }
        }

        protected void chkColorBrand_CheckedChanged(object sender, EventArgs e)
        {
            if (chkColorBrand.Checked == true)
            {
                txtBrand.Visible = true;
                ddlColorBrand.Visible = false;
            }
            else
            {
                txtBrand.Visible = false;
                ddlColorBrand.Visible = true;
            }
        }

        protected void chkStyleSize_CheckedChanged(object sender, EventArgs e)
        {
            if (chkStyleSize.Checked == true)
            {
                txtStyleSize.Visible = true;
                ddlStyleSize.Visible = false;
            }
            else
            {
                txtStyleSize.Visible = false;
                ddlStyleSize.Visible = true;
            }
        }

        protected void chkUnit_CheckedChanged(object sender, EventArgs e)
        {
            if (chkUnit.Checked == true)
            {
                txtUnit.Visible = true;
                ddlUnit.Visible = false;
            }
            else
            {
                txtUnit.Visible = false;
                ddlUnit.Visible = true;
            }
        }

        protected void chktemType_CheckedChanged(object sender, EventArgs e)
        {
            if (chktemType.Checked == true)
            {
                txtItemType.Visible = true;
                ddlItemType.Visible = false;
            }
            else
            {
                txtItemType.Visible = false;
                ddlItemType.Visible = true;
            }
        }
        #endregion
    }
}
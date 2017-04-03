using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ERPSSL.INV.DAL;
using ERPSSL.INV.BLL;
using ERPSSL.LC.DAL.Repository;
using ERPSSL.LC.BLL;
using ERPSSL.LC.DAL;
using System.Data;


namespace ERPSSL.LC
{
    public partial class Estimating : System.Web.UI.Page
    {
        ERPSSL.LC.BLL.OrderSheetBLL _orderSheetbll = new ERPSSL.LC.BLL.OrderSheetBLL();
        //ProductBLL productBll = new ProductBLL();
        //GroupBLL groupBll = new GroupBLL();
        //UnitBLL unitBll = new UnitBLL();
        MasterLCBLL _masterlcBLL = new MasterLCBLL();
        GroupBLL groupBll = new GroupBLL();
        EstimatingBLL estimatingBLL = new EstimatingBLL();
        LC_ReportBLL aLC_ReportBLL = new LC_ReportBLL();
        LC_RequisitionBLL aLC_RequisitionBLL = new LC_RequisitionBLL();
        //        private ERPSSL_INVEntities _INVcontext = new ERPSSL_INVEntities();

        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Session["UserID"] != null) && (Session["OCode"] != null))
            {
                if (!IsPostBack)
                {
                    // FillItemName();
                    FillFabric();
                    FillAccessories();
                    //FillStyle();
                    FillPoOrder();
                    FillBuyer();
                    Fillunit();
                    FillFinishGood();
                }
            }
            else
            {
                Response.Redirect("..\\AppGateway\\Login.aspx");
            }
        }
        //private void FillStyle()
        //{
        //    try
        //    {
        //        string ocode = ((SessionUser)Session["SessionUser"]).OCode;
        //        var row = _orderSheetbll.GetOrderStyle(ocode);
        //        if (row.Count > 0)
        //        {
        //            ddlStyle.DataSource = row.ToList();
        //            //ddlStyle.DataTextField = "Style";
        //            //ddlStyle.DataValueField = "Style";
        //            ddlStyle.DataBind();
        //            ddlStyle.AppendDataBoundItems = false;
        //            ddlStyle.Items.Insert(0, new ListItem("--Select Item Category--", "0"));
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        private void FillPoOrder()
        {
            try
            {
                string ocode = ((SessionUser)Session["SessionUser"]).OCode;
                var row = _orderSheetbll.GetOrderNo(ocode);
                if (row.Count > 0)
                {
                    ddlOrder.DataSource = row.ToList();
                    // ddlPoOrder.DataTextField = "OrderNo";
                    // ddlPoOrder.DataValueField = "OrderNo";
                    ddlOrder.DataBind();
                    ddlOrder.AppendDataBoundItems = false;
                    ddlOrder.Items.Insert(0, new ListItem("--Select Item Category--", "0"));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void FillFinishGood()
        {
            try
            {
                string ocode = ((SessionUser)Session["SessionUser"]).OCode;
                var row = estimatingBLL.GetLC_FinishGoods(ocode);
                if (row.Count > 0)
                {
                    ddlFinishGoods.DataSource = row.ToList();
                    ddlFinishGoods.DataTextField = "FinishGoods_Name";
                    ddlFinishGoods.DataValueField = "FinishGoods_Id";
                    ddlFinishGoods.DataBind();
                    ddlFinishGoods.AppendDataBoundItems = false;
                    ddlFinishGoods.Items.Insert(0, new ListItem("--Select Finish Goods--", "0"));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void Fillunit()
        {
            try
            {
                string ocode = ((SessionUser)Session["SessionUser"]).OCode;
                var row = _orderSheetbll.GetUnitForMarchandising();
                if (row.Count > 0)
                {
                    ddlunit.DataSource = row.ToList();
                    ddlunit.DataTextField = "UnitName";
                    ddlunit.DataValueField = "UnitId";
                    ddlunit.DataBind();
                    ddlunit.AppendDataBoundItems = false;
                    ddlunit.Items.Insert(0, new ListItem("--Select Item Category--", "0"));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void CreateAutoNumber()
        {
            string ocode = ((SessionUser)Session["SessionUser"]).OCode;
            DateTime date = DateTime.Today;
            txtMarchandisingNo.Text = _orderSheetbll.GetMarchandisingNo(ocode, date);

        }

        private void FillBuyer()
        {
            string ocode = ((SessionUser)Session["SessionUser"]).OCode;
            BuyerBLL _BuyerBll = new BuyerBLL();
            List<Com_Buyer_Setup> _buyerlist = _BuyerBll.GetBuyerName(ocode);

            if (_buyerlist.Count > 0)
            {
                ddlBuyerName.DataSource = _buyerlist.ToList();
                ddlBuyerName.DataTextField = "Buyer_Name";
                ddlBuyerName.DataValueField = "Buyer_ID";
                ddlBuyerName.DataBind();
                ddlBuyerName.Items.Insert(0, new ListItem("---Select One---"));
            }
        }

        //private void FillItemName()
        //{
        //    try
        //    {
        //        var row = groupBll.GetAllGroup();
        //        if (row.Count > 0)
        //        {
        //            ddlItemCategory.DataSource = row.ToList();
        //            ddlItemCategory.DataTextField = "GroupName";
        //            ddlItemCategory.DataValueField = "GroupId";
        //            ddlItemCategory.DataBind();
        //            ddlItemCategory.AppendDataBoundItems = false;
        //            ddlItemCategory.Items.Insert(0, new ListItem("--Select Item Category--", "0"));
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        protected void ddlItemCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            // FillProductName();
        }
        public void FillFabric()
        {
            //if (Convert.ToInt32(ddlItemCategory.SelectedValue) > 0)
            //{
            List<ERPSSL.LC.DAL.Inv_Product> ItemList = _orderSheetbll.GetItemListInv_Product(2);
            if (ItemList.Count > 0)
            {
                grvOrderSheetEntry.DataSource = ItemList;
                grvOrderSheetEntry.DataBind();
            }
            //}
        }

        public void FillAccessories()
        {
            //if (Convert.ToInt32(ddlItemCategory.SelectedValue) > 0)
            //{
            List<ERPSSL.LC.DAL.Inv_Product> ItemList = _orderSheetbll.GetItemListInv_Product(1);
            if (ItemList.Count > 0)
            {
                gridAccessories.DataSource = ItemList;
                gridAccessories.DataBind();
            }
            //}
        }
        protected void headerLevelCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                CheckBox headerChkBox = ((CheckBox)grvOrderSheetEntry.HeaderRow.FindControl("headerLevelCheckBox"));

                if (headerChkBox.Checked == true)
                {
                    foreach (GridViewRow gvRow in grvOrderSheetEntry.Rows)
                    {
                        CheckBox rowChkBox = ((CheckBox)gvRow.FindControl("rowLevelCheckBox"));
                        rowChkBox.Checked = true;//((CheckBox)sender).Checked;//for all row checkbox       
                    }
                }
                else
                {
                    foreach (GridViewRow gvRow in grvOrderSheetEntry.Rows)
                    {
                        CheckBox rowChkBox = ((CheckBox)gvRow.FindControl("rowLevelCheckBox"));
                        rowChkBox.Checked = false;
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }

        }
        protected void headerLevelCheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                CheckBox headerChkBox = ((CheckBox)gridAccessories.HeaderRow.FindControl("headerLevelCheckBox1"));

                if (headerChkBox.Checked == true)
                {
                    foreach (GridViewRow gvRow in gridAccessories.Rows)
                    {
                        CheckBox rowChkBox = ((CheckBox)gvRow.FindControl("rowLevelCheckBox1"));
                        rowChkBox.Checked = true;//((CheckBox)sender).Checked;//for all row checkbox       
                    }
                }
                else
                {
                    foreach (GridViewRow gvRow in gridAccessories.Rows)
                    {
                        CheckBox rowChkBox = ((CheckBox)gvRow.FindControl("rowLevelCheckBox1"));
                        rowChkBox.Checked = false;
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        double total = 0;

        protected void txtUSDRate_TextChanged(object sender, EventArgs e)
        {
            TextBox txt = (TextBox)sender;
            GridViewRow gvRow = (GridViewRow)txt.Parent.Parent;
            TextBox textqty = (TextBox)gvRow.FindControl("txtConsumption");
            TextBox txtQtyDzn = (TextBox)gvRow.FindControl("txtQtyDzn");
            if (textqty.Text == "" && txtQtyDzn.Text == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Please Input Request Qty')", true);
                return;
            }
            Label lblTotalRs = (Label)gvRow.FindControl("lblValue");
            try
            {
                int amni = 0;
                lblTotalRs.Text = ((Convert.ToDecimal(txt.Text)) * (Convert.ToDecimal(textqty.Text)) * (Convert.ToDecimal(txtQtyDzn.Text))).ToString();
                int label = Convert.ToInt32(lblTotalRs.Text);
                //foreach (GridViewRow gvRows in grvOrderSheetEntry.Rows)
                //{
                //    Label lblTotal = (Label)gvRow.FindControl("lblValue");
                //    amni = Convert.ToInt32(lblTotal.Text.ToString());
                //}

                for (int i = 0; i < grvOrderSheetEntry.Rows.Count; i++)
                {
                    Label lblTotal = (Label)grvOrderSheetEntry.Rows[i].FindControl("lblValue");
                    if (lblTotal.Text != "")
                    {
                        total += Convert.ToDouble(lblTotal.Text);
                    }
                }
                lblGrandTotal.Text = total.ToString();
                txtTotalFabricCost.Text = (total).ToString();
           }
            catch { lblTotalRs.Text = "0"; txt.Text = "0"; }
        }

        protected void grvOrderSheetEntry_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    string ocode = ((SessionUser)Session["SessionUser"]).OCode;

                    var result = _orderSheetbll.GetInv_Supplier(ocode);
                    if (result.Count > 0)
                    {
                        DropDownList ddlCountries = (e.Row.FindControl("ddlSupplier") as DropDownList);
                        ddlCountries.DataSource = result.ToList();
                        ddlCountries.DataTextField = "SupplierName";
                        ddlCountries.DataValueField = "SupplierCode";
                        ddlCountries.DataBind();
                        ddlCountries.AppendDataBoundItems = false;
                        ddlCountries.Items.Insert(0, new ListItem("--Select--", "0"));
                    }
                }
            }
            catch
            {
            }
        }
        protected void gridAccessories_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    string ocode = ((SessionUser)Session["SessionUser"]).OCode;

                    var result = _orderSheetbll.GetInv_Supplier(ocode);
                    if (result.Count > 0)
                    {
                        DropDownList ddlCountries = (e.Row.FindControl("ddlSupplier2") as DropDownList);
                        ddlCountries.DataSource = result.ToList();
                        ddlCountries.DataTextField = "SupplierName";
                        ddlCountries.DataValueField = "SupplierCode";
                        ddlCountries.DataBind();
                        ddlCountries.AppendDataBoundItems = false;
                        ddlCountries.Items.Insert(0, new ListItem("--Select--", "0"));
                    }
                }
            }
            catch
            {
            }
        }
        double grandtotal = 0;
        protected void txtUnit_TextChanged(object sender, EventArgs e)
        {
            TextBox txt = (TextBox)sender;
            GridViewRow gvRow = (GridViewRow)txt.Parent.Parent;
            TextBox textqty = (TextBox)gvRow.FindControl("txtQtyPc");
            TextBox txtQtyDzn2 = (TextBox)gvRow.FindControl("txtQtyDzn2");
            if (textqty.Text == "" && txtQtyDzn2.Text == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Please Input Request Qty')", true);
                return;
            }
            Label lblTotalRs = (Label)gvRow.FindControl("lblAmount");
            try
            {
                lblTotalRs.Text = ((Convert.ToDecimal(txt.Text)) * (Convert.ToDecimal(textqty.Text)) * (Convert.ToDecimal(txtQtyDzn2.Text))).ToString();

                for (int i = 0; i < gridAccessories.Rows.Count; i++)
                {
                    Label lblTotal = (Label)gridAccessories.Rows[i].FindControl("lblAmount");
                    if (lblTotal.Text != "")
                    {
                        grandtotal += Convert.ToDouble(lblTotal.Text);
                    }
                }
                lblGrandTotalAccessories.Text = grandtotal.ToString();

                double parcentage = (grandtotal * 5) / 100;
                lblParsentageCost.Text = (grandtotal + parcentage).ToString();
                txtTotalAccessoryCost.Text = (grandtotal + parcentage).ToString();
            }
            catch { lblTotalRs.Text = "0"; txt.Text = "0"; }
        }

        protected void txtWashingCost_TextChanged(object sender, EventArgs e)
        {
            double txtTotalFabric = 0;
            double txtTotalAccessory = 0;
            if (txtTotalFabricCost.Text != "")
            {
                txtTotalFabric = Convert.ToDouble(txtTotalFabricCost.Text);
            }
            if (txtTotalAccessoryCost.Text != "")
            {
                txtTotalAccessory = Convert.ToDouble(txtTotalAccessoryCost.Text);
            }

            double txtWashing = Convert.ToDouble(txtWashingCost.Text);
            txtTotalPrice.Text = (txtTotalFabric + txtTotalAccessory + txtWashing).ToString();
        }

        protected void txtLabTest_TextChanged(object sender, EventArgs e)
        {
            double txtTotalFabric = 0;
            double txtTotalAccessory = 0;
            double txtWashing = 0;
            if (txtTotalFabricCost.Text != "")
            {
                txtTotalFabric = Convert.ToDouble(txtTotalFabricCost.Text);
            }
            if (txtTotalAccessoryCost.Text != "")
            {
                txtTotalAccessory = Convert.ToDouble(txtTotalAccessoryCost.Text);
            }
            if (txtWashingCost.Text != "")
            {
                txtWashing = Convert.ToDouble(txtWashingCost.Text);
            }

            double labtest = Convert.ToDouble(txtLabTest.Text);

            txtTotalPrice.Text = (txtTotalFabric + txtTotalAccessory + txtWashing + labtest).ToString();
        }

        protected void txtPrintCost_TextChanged(object sender, EventArgs e)
        {
            double txtTotalFabric = 0;
            double txtTotalAccessory = 0;
            double txtWashing = 0;
            double labtest = 0;
            if (txtTotalFabricCost.Text != "")
            {
                txtTotalFabric = Convert.ToDouble(txtTotalFabricCost.Text);
            }
            if (txtTotalAccessoryCost.Text != "")
            {
                txtTotalAccessory = Convert.ToDouble(txtTotalAccessoryCost.Text);
            }
            if (txtWashingCost.Text != "")
            {
                txtWashing = Convert.ToDouble(txtWashingCost.Text);
            }
            if (txtLabTest.Text != "")
            {
                labtest = Convert.ToDouble(txtLabTest.Text);
            }

            double printCost = Convert.ToDouble(txtPrintCost.Text);

            txtTotalPrice.Text = (txtTotalFabric + txtTotalAccessory + txtWashing + labtest + printCost).ToString();
        }

        protected void txtCM_TextChanged(object sender, EventArgs e)
        {
            double txtTotalFabric = 0;
            double txtTotalAccessory = 0;
            double txtWashing = 0;
            double labtest = 0;
            double printCost = 0;
            if (txtTotalFabricCost.Text != "")
            {
                txtTotalFabric = Convert.ToDouble(txtTotalFabricCost.Text);
            }
            if (txtTotalAccessoryCost.Text != "")
            {
                txtTotalAccessory = Convert.ToDouble(txtTotalAccessoryCost.Text);
            }
            if (txtWashingCost.Text != "")
            {
                txtWashing = Convert.ToDouble(txtWashingCost.Text);
            }
            if (txtLabTest.Text != "")
            {
                labtest = Convert.ToDouble(txtLabTest.Text);
            }
            if (txtPrintCost.Text != "")
            {
                printCost = Convert.ToDouble(txtPrintCost.Text);
            }

            double cm = Convert.ToDouble(txtCM.Text);

            txtTotalPrice.Text = (txtTotalFabric + txtTotalAccessory + txtWashing + labtest + printCost + cm).ToString();
        }
        protected void txtCommission_TextChanged(object sender, EventArgs e)
        {
            double total = Convert.ToDouble(txtTotalPrice.Text);
            double commission = 0;

            if (txtCommission.Text != "")
            {
                commission = Convert.ToDouble(txtCommission.Text);
            }
            double totalwithcommission = ((total * commission) / 100);
            txtFinalPrice.Text = (total - totalwithcommission).ToString();
        }


        protected void btnFabric_Click(object sender, EventArgs e)
        {
            List<LC_CostEstimateDetails> _costDetails = new List<LC_CostEstimateDetails>();

            if (ddlBuyerName.SelectedValue == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Select Buyer Name')", true);
            }
            if (ddlOrder.SelectedValue == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Select Order')", true);
            }
            if (ddlStyle.SelectedValue == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Select Style')", true);
            }
            if (txtQuantity.Text == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Input Quantity')", true);
            }

            //foreach (GridViewRow gvRows in grvOrderSheetEntry.Rows)
            //{

            foreach (GridViewRow gvRow in grvOrderSheetEntry.Rows)
            {
                CheckBox rowChkBox = ((CheckBox)gvRow.FindControl("rowLevelCheckBox"));
                if (rowChkBox.Checked == true)
                {
                    Label lblGroupId = ((Label)gvRow.FindControl("lblGroupId"));
                    Label lblProductId = ((Label)gvRow.FindControl("lblProductId"));

                    Label lblUnitId = ((Label)gvRow.FindControl("lblUnitId"));
                    DropDownList ddlSupplier = ((DropDownList)gvRow.FindControl("ddlSupplier"));
                    Label lblTotalunitQty = ((Label)gvRow.FindControl("lblTotalunitQty"));
                    TextBox txtQtyPC = ((TextBox)gvRow.FindControl("txtConsumption"));
                    TextBox txtQtyDzn = ((TextBox)gvRow.FindControl("txtQtyDzn"));
                    TextBox txtUnitPrice = ((TextBox)gvRow.FindControl("txtUSDRate"));
                    Label lblAmount = ((Label)gvRow.FindControl("lblValue"));

                    LC_CostEstimateDetails costDetails = new LC_CostEstimateDetails();
                    costDetails.CostEstimate_Id = txtMarchandisingNo.Text;
                    costDetails.ProductId = Convert.ToInt32(lblProductId.Text);
                    costDetails.GroupId = Convert.ToInt32(lblGroupId.Text);
                    costDetails.UnitId = Convert.ToInt32(lblUnitId.Text);
                    if (ddlSupplier.SelectedValue == "")
                    {
                        costDetails.SupplierCode = "n/a";
                    }
                    else
                    {
                        costDetails.SupplierCode = ddlSupplier.SelectedValue.ToString();
                    }
                    costDetails.Qty_Dzn = Convert.ToDouble(txtQtyDzn.Text);
                    costDetails.Qty_PC = Convert.ToDouble(txtQtyPC.Text);
                    costDetails.UnitPrice = Convert.ToDouble(txtUnitPrice.Text);
                    costDetails.TotalUnitQty = Convert.ToDouble(lblTotalunitQty.Text);
                    costDetails.Amount = Convert.ToDouble(lblAmount.Text);
                    costDetails.OCode = Convert.ToString(((SessionUser)Session["SessionUser"]).OCode);
                    costDetails.CreateUser = ((SessionUser)Session["SessionUser"]).UserId;
                    costDetails.CreateDate = DateTime.Today;
                    _costDetails.Add(costDetails);
                }
            }
            // }
            var result = estimatingBLL.Save(_costDetails);
            if (result == 1)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Data Added Successfully')", true);
            }

        }

        protected void btnAccessories_Click(object sender, EventArgs e)
        {

            List<LC_CostEstimateDetails> _costDetails = new List<LC_CostEstimateDetails>();

            if (ddlBuyerName.SelectedValue == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Select Buyer Name')", true);
            }
            if (ddlOrder.SelectedValue == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Select Order')", true);
            }
            if (ddlStyle.SelectedValue == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Select Style')", true);
            }
            if (txtQuantity.Text == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Input Quantity')", true);
            }

            //foreach (GridViewRow gvRows in grvOrderSheetEntry.Rows)
            //{

            foreach (GridViewRow gvRow in gridAccessories.Rows)
            {
                CheckBox rowChkBox = ((CheckBox)gvRow.FindControl("rowLevelCheckBox1"));
                if (rowChkBox.Checked == true)
                {
                    Label lblGroupId = ((Label)gvRow.FindControl("lblGroupId1"));
                    Label lblProductId = ((Label)gvRow.FindControl("lblProductId1"));
                    Label lblUnitId = ((Label)gvRow.FindControl("lblUnitId1"));
                    DropDownList ddlSupplier = ((DropDownList)gvRow.FindControl("ddlSupplier2"));
                    Label lblTotalunitQty = ((Label)gvRow.FindControl("lblTotalunitQty1"));
                    TextBox txtQtyPC = ((TextBox)gvRow.FindControl("txtQtyPc"));
                    TextBox txtQtyDzn = ((TextBox)gvRow.FindControl("txtQtyDzn2"));
                    TextBox txtUnitPrice = ((TextBox)gvRow.FindControl("txtUnit"));
                    Label lblAmount = ((Label)gvRow.FindControl("lblAmount"));

                    LC_CostEstimateDetails costDetails = new LC_CostEstimateDetails();
                    costDetails.CostEstimate_Id = txtMarchandisingNo.Text;
                    costDetails.GroupId = Convert.ToInt32(lblGroupId.Text);
                    costDetails.ProductId = Convert.ToInt32(lblProductId.Text);
                    costDetails.UnitId = Convert.ToInt32(lblUnitId.Text);

                    if (ddlSupplier.SelectedValue == "")
                    {
                        costDetails.SupplierCode = "n/a";
                    }
                    else
                    {
                        costDetails.SupplierCode = ddlSupplier.SelectedValue.ToString();
                    }
                    costDetails.Qty_Dzn = Convert.ToDouble(txtQtyDzn.Text);
                    costDetails.Qty_PC = Convert.ToDouble(txtQtyPC.Text);
                    costDetails.UnitPrice = Convert.ToDouble(txtUnitPrice.Text);
                    costDetails.TotalUnitQty = Convert.ToDouble(lblTotalunitQty.Text);
                    costDetails.Amount = Convert.ToDouble(lblAmount.Text);
                    costDetails.OCode = Convert.ToString(((SessionUser)Session["SessionUser"]).OCode);
                    costDetails.CreateUser = ((SessionUser)Session["SessionUser"]).UserId;
                    costDetails.CreateDate = DateTime.Today;
                    _costDetails.Add(costDetails);
                }
            }
            // }
            var result = estimatingBLL.Save(_costDetails);
            if (result == 1)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Data Added Successfully')", true);

            }
        }

        protected void txtQtyPc_TextChanged(object sender, EventArgs e)
        {
            TextBox txt = (TextBox)sender;
            GridViewRow gvRow = (GridViewRow)txt.Parent.Parent;
            TextBox textqty = (TextBox)gvRow.FindControl("txtQtyPc");
            if (txtQuantity.Text != "")
            {
                double qty = Convert.ToDouble(txtQuantity.Text);
                double QtyPc = Convert.ToDouble(textqty.Text);
                Label lblTotalunitQty1 = (Label)gvRow.FindControl("lblTotalunitQty1");
                try
                {
                    lblTotalunitQty1.Text = (qty * QtyPc).ToString();
                }
                catch (Exception ex)
                {

                }
            }
            else
            {

            }
        }

        protected void txtConsumption_TextChanged(object sender, EventArgs e)
        {
            TextBox txt = (TextBox)sender;
            GridViewRow gvRow = (GridViewRow)txt.Parent.Parent;
            TextBox textqty = (TextBox)gvRow.FindControl("txtConsumption");
            if (txtQuantity.Text != "")
            {
                double qty = Convert.ToDouble(txtQuantity.Text);
                double QtyPc = Convert.ToDouble(textqty.Text);
                Label lblTotalunitQty = (Label)gvRow.FindControl("lblTotalunitQty");
                try
                {
                    lblTotalunitQty.Text = (qty * QtyPc).ToString();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else
            {

            }
        }

        protected void ddlOrder_SelectedIndexChanged(object sender, EventArgs e)
        {
            CreateAutoNumber();
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {

            if (ddlBuyerName.SelectedValue == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Select Buyer Name')", true);
            }
            if (ddlOrder.SelectedValue == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Select Order')", true);
            }
            if (ddlStyle.SelectedValue == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Select Style')", true);
            }
            if (txtQuantity.Text == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Input Quantity')", true);
            }
            if (txtTotalFabricCost.Text == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Input Quantity')", true);
            }
            if (txtTotalAccessoryCost.Text == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Input Quantity')", true);
            }

            LC_CostEstimateSummary costSummary = new LC_CostEstimateSummary();
            costSummary.Buyer_ID = Convert.ToInt32(ddlBuyerName.SelectedValue.ToString());
            costSummary.Lc_Style = ddlStyle.SelectedItem.Text;
            costSummary.Lc_Order = ddlOrder.SelectedItem.Text;
            costSummary.Cost_Estimate_ID = txtMarchandisingNo.Text;
            hidEstimatingCostID.Value = costSummary.Cost_Estimate_ID;
            costSummary.PO_No = txtPO.Text;
            costSummary.Ref_No = txtRef.Text;
            costSummary.Delivery = txtDelivery.Text;
            costSummary.S_Range = txtRange.Text;
            costSummary.Unit_Price = Convert.ToDouble(txtUnitPrice.Text);
            costSummary.Amount_LC = Convert.ToDouble(txtAmountLc.Text);
            costSummary.LC_Terms = txtTerm.Text;
            costSummary.OrderDate = Convert.ToDateTime(txtDate.Text);
            costSummary.Merchandiser_Name = txtMerchandiser.Text;
            costSummary.FinishedGoods_ID = Convert.ToInt32(ddlFinishGoods.SelectedValue.ToString());
            costSummary.FinishedGoods_Qty = Convert.ToDouble(txtQuantity.Text);
            costSummary.ProductUnit = Convert.ToInt32(ddlunit.SelectedValue.ToString());
            costSummary.Target_Cost = Convert.ToDouble(txtTergate.Text);
            costSummary.Total_Cost = Convert.ToDouble(txtCost.Text);
            costSummary.TotalFabricCost = Convert.ToDouble(txtTotalFabricCost.Text);
            costSummary.TotalAccessoriesCost = Convert.ToDouble(txtTotalAccessoryCost.Text);
            if (txtWashingCost.Text == "")
            {
                costSummary.WashingCost = 0;
            }
            else
            {
                costSummary.WashingCost = Convert.ToDouble(txtWashingCost.Text);
            }
            if (txtLabTest.Text == "")
            {
                costSummary.LabTest = 0;
            }
            else
            {
                costSummary.LabTest = Convert.ToDouble(txtLabTest.Text);
            }
            if (txtPrintCost.Text == "")
            {
                costSummary.PrintCost = 0;
            }
            else
            {
                costSummary.PrintCost = Convert.ToDouble(txtPrintCost.Text);
            }
            if (txtCM.Text == "")
            {
                costSummary.CM = 0;
            }
            else
            {
                costSummary.CM = Convert.ToDouble(txtCM.Text);
            }
            if (txtTotalPrice.Text == "")
            {
                costSummary.TotalPrice = 0;
            }
            else
            {
                costSummary.TotalPrice = Convert.ToDouble(txtTotalPrice.Text);
            }
            if (txtCommission.Text == "")
            {
                costSummary.Commission = 0;
            }
            else
            {
                costSummary.Commission = Convert.ToDouble(txtCommission.Text);
            }
            if (txtFinalPrice.Text == "")
            {
                costSummary.FinalPrice = 0;
            }
            else
            {
                costSummary.FinalPrice = Convert.ToDouble(txtFinalPrice.Text);
            }
            costSummary.OCode = Convert.ToString(((SessionUser)Session["SessionUser"]).OCode);
            costSummary.CreateUser = ((SessionUser)Session["SessionUser"]).UserId;
            costSummary.CreateDate = DateTime.Today;
            costSummary.Estimation_Approval = false;


            var result = estimatingBLL.EstimatingSave(costSummary);
            if (result == 1)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Data Submit Successfully')", true);
                Clear();
            }


        }

        public void Clear()
        {
            txtAmountLc.Text = "";
            txtCM.Text = "";
            txtCommission.Text = "";
            txtCost.Text = "";
            txtDate.Text = "";
            txtDelivery.Text = "";
            txtFinalPrice.Text = "";
            txtLabTest.Text = "";
            txtMarchandisingNo.Text = "";
            txtMerchandiser.Text = "";
            txtPO.Text = "";
            txtPrintCost.Text = "";
            txtQuantity.Text = "";
            txtRange.Text = "";
            txtRef.Text = "";
            txtTergate.Text = "";
            txtTerm.Text = "";
            txtTotalAccessoryCost.Text = "";
            txtTotalFabricCost.Text = "";
            txtTotalPrice.Text = "";
            txtUnitPrice.Text = "";
            txtWashingCost.Text = "";
            ddlBuyerName.ClearSelection();
            ddlFinishGoods.ClearSelection();
            ddlOrder.ClearSelection();
            ddlStyle.ClearSelection();
            ddlunit.ClearSelection();
            FillFabric();
            FillAccessories();


        }

        protected void btnPrint_Click(object sender, EventArgs e)
        {
            string EstimatingCostID = hidEstimatingCostID.Value;
            string OCODE = Convert.ToString(((SessionUser)Session["SessionUser"]).OCode);


            List<Rep_Estimate> EstimatingCost = aLC_ReportBLL.Get_RPT_Cost_Estimating(EstimatingCostID, OCODE);
            var Fabric = aLC_RequisitionBLL.Get_AllEstimateDetailsList(EstimatingCostID).Where(x => x.GroupId == 1);
            var Accessories = aLC_RequisitionBLL.Get_AllEstimateDetailsList(EstimatingCostID).Where(x => x.GroupId == 2);


            if (EstimatingCost.Count > 0)
            {
                Session["rptDs"] = "Cost_Estimating";
                Session["rptDs1"] = "FabricDetails";
                Session["rptDs2"] = "AccessoriesDetails";
                Session["rptDt"] = EstimatingCost;
                Session["rptDt1"] = Fabric;
                Session["rptDt2"] = Accessories;
                Session["rptFile"] = "/LC/Reports/LC_RPT_Cost_Estimating.rdlc";
                Session["rptTitle"] = "Employee Wise Leave Info";
                Response.Redirect("ReportViewer.aspx");
            }

        }

    }
}
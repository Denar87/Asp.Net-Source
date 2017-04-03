using ERPSSL.Merchandising.BLL;
using ERPSSL.Merchandising.DAL;
using ERPSSL.Merchandising.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ERPSSL.Merchandising
{
    public partial class Pre_Costing : System.Web.UI.Page
    {
        PreCostingBLL aPreCostingBLL = new PreCostingBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Session["UserID"] != null) && (Session["OCode"] != null))
            {
                if (!IsPostBack)
                {
                    FillItemType();
                }
            }
            else
            {
                Response.Redirect("..\\AppGateway\\Login.aspx");
            }
        }

        [System.Web.Script.Services.ScriptMethod()]
        [System.Web.Services.WebMethod]
        public static List<string> SearchOrderNo(string prefixText, int count)
        {
            using (var _context = new ERPSSL_MerchandisingEntities())
            {
                var allOrder = from m in _context.LC_OrderEntry
                               where ((m.OrderNo.Contains(prefixText)))
                               select m;
                List<String> orderList = new List<String>();
                foreach (var orders in allOrder)
                {
                    orderList.Add(orders.OrderNo);
                }
                return orderList;
            }
        }


        //Show Data When Insert Order No
        protected void txtPOrder2_TextChanged(object sender, EventArgs e)
        {
            string ocode = ((SessionUser)Session["SessionUser"]).OCode;
            Guid User = ((SessionUser)Session["SessionUser"]).UserId;
            string orderNo = txtPOrder.Text;

            List<OrderEntryViewRepo> orderEntryViewRepoList = aPreCostingBLL.LoadSingalInfo(ocode, orderNo);

            //OrderEntryViewRepo aOrderEntryViewRepo = new OrderEntryViewRepo();

            if (orderEntryViewRepoList.Count > 0)
            {
                foreach (OrderEntryViewRepo aOrderEntryViewRepo in orderEntryViewRepoList)
                {
                    orderReceiveDateTextBox.Text = aOrderEntryViewRepo.OrderReceivedDate.ToString("dd/MM/yyyy");
                    styleTextBox.Text = aOrderEntryViewRepo.Style;
                    seasonTextBox.Text = aOrderEntryViewRepo.Season;
                    BuyerTextBox.Text = aOrderEntryViewRepo.Buyer;
                    buyerDepartmentTextBox.Text = aOrderEntryViewRepo.BuyerDepartment;
                    categoryTextBox.Text = aOrderEntryViewRepo.Category;
                    itemDescriptionTextBox.Text = aOrderEntryViewRepo.ItemDescription;
                    quantityTextBox.Text = aOrderEntryViewRepo.Quantity.ToString();
                    unitTextBox.Text = aOrderEntryViewRepo.Unit;
                    ddlCurrency.SelectedValue = aOrderEntryViewRepo.Currency;
                    fOBPortTextBox.Text = aOrderEntryViewRepo.FOBPort;
                    ddlShipmentMode.Text = aOrderEntryViewRepo.ShipmentMode;
                    shipmentDateTextBox.Text = aOrderEntryViewRepo.ShipmentDate.ToString("dd/MM/yyyy");
                    merchandiserNameTextBox.Text = aOrderEntryViewRepo.Merchendiser;
                    officeTextBox.Text = aOrderEntryViewRepo.Office;

                }
            }

        }


        //Add Two More filed from here----------------------------------------------------------------------------------------------------------------------------
        protected void addButton_Click(object sender, EventArgs e)
        {
            LC_OrderEntry aLC_OrderEntry = new LC_OrderEntry();

            if (txtPOrder.Text == "")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "CommonRequiredFiledError('Please Insert Order No')", true);
            }
            else
            {
                aLC_OrderEntry.SMV = sMVTextBox.Text;
                aLC_OrderEntry.Efficiency = efficiencyTextBox.Text;

                int result = aPreCostingBLL.UpdateTwoInfo(aLC_OrderEntry, txtPOrder.Text);

                if (result == 1)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "SuccessAlert('Added Successfully!!')", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "CommonRequiredFiledError('Failed To Add. Try Again!!')", true);
                }
            }
        }

        //Fill with All Item Type
        protected void FillItemType()
        {
            try
            {
                var row = aPreCostingBLL.FillItemType();
                if (row.Count > 0)
                {
                    itemTypeDropDownList.DataSource = row.ToList();
                    itemTypeDropDownList.DataTextField = "ProductType";
                    itemTypeDropDownList.DataValueField = "ProductTypeId";
                    itemTypeDropDownList.DataBind();
                    itemTypeDropDownList.AppendDataBoundItems = false;
                    itemTypeDropDownList.Items.Insert(0, new ListItem("--Select One--", "0"));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void itemTypeDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            int typeId = Convert.ToInt32(itemTypeDropDownList.SelectedValue.ToString());

            FillGroupType(typeId);

        }

        //Fill with All Item Group Type Using Item Type
        public void FillGroupType(int typeId)
        {
            try
            {
                var row = aPreCostingBLL.GetAllGroup(typeId);
                if (row.Count > 0)
                {
                    itemGroupDropDownList.DataSource = row.ToList();
                    itemGroupDropDownList.DataTextField = "GroupName";
                    itemGroupDropDownList.DataValueField = "GroupId";
                    itemGroupDropDownList.DataBind();
                    itemGroupDropDownList.AppendDataBoundItems = false;
                    itemGroupDropDownList.Items.Insert(0, new ListItem("--Select One--", "0"));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //Fill With GSM using cnstruction
        public void FillGsm(int ItemGroup)
        {
            //using (var _context = new ERPSSL_MerchandisingEntities())
            //{
            //    var allClient = from m in _context.LC_YarnDetermination
            //                    where ((m.GSM.Contains(prefixText)))
            //                    select m;
            //    List<String> clientList = new List<String>();
            //    foreach (var clientName in allClient)
            //    {
            //        clientList.Add(clientName.GSM);
            //    }
            //    return clientList;
            //}

            try
            {
                List<string> row = aPreCostingBLL.GetAllGSMByGroup(ItemGroup);
                if (row.Count > 0)
                {
                    gsmGroupDropDownList.DataSource = row.ToList();
                    //gsmGroupDropDownList.DataTextField = "GSM";
                    //itemGroupDropDownList.DataValueField = "GroupId";
                    gsmGroupDropDownList.DataBind();
                    gsmGroupDropDownList.AppendDataBoundItems = false;
                    gsmGroupDropDownList.Items.Insert(0, new ListItem("--Select One--", "0"));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        // Fill with data in grid view
        private void GetProductInfo(int itemType, int itemGroup)
        {
            try
            {
                string OCODE = ((SessionUser)Session["SessionUser"]).OCode.ToString();
                List<InvProductR> products = aPreCostingBLL.GetProduct(OCODE, itemType, itemGroup);
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

        protected void itemGroupDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            int itemType = Convert.ToInt32(itemTypeDropDownList.SelectedValue.ToString());

            int itemGroup = Convert.ToInt32(itemGroupDropDownList.SelectedValue.ToString());

            GetProductInfo(itemType, itemGroup);

            FillGsm(itemGroup);

        }

        protected void requiredQuantityTextBox_TextChanged(object sender, EventArgs e)
        {
            GridViewRow row = ((GridViewRow)((TextBox)sender).NamingContainer);
            //GridViewRow row1 = ((GridViewRow)((Label)sender).NamingContainer);

            TextBox requiredQuantityTextBox = ((TextBox)row.FindControl("requiredQuantityTextBox"));
            Label lblPrice = ((Label)row.FindControl("lblPrice"));

            decimal? price = Convert.ToDecimal(lblPrice.Text);
            int quantity = Convert.ToInt32(requiredQuantityTextBox.Text);

            decimal? DailyProd = price * quantity;

            Label totalAmountLabel = ((Label)row.FindControl("totalAmountLabel"));
            totalAmountLabel.Text = DailyProd.ToString();


        }

        protected void grdProductInfo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
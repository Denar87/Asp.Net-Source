using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ERPSSL.INV.DAL;
using ERPSSL.INV.BLL;
using ERPSSL.INV.DAL.Repository;
using ERPSSL.LC.BLL;

namespace ERPSSL.INV
{
    public partial class UnallocatedList : System.Web.UI.Page
    {
        UnitBLL unitBll = new UnitBLL();
        RChallanBLL aRchallan = new RChallanBLL();
        BuyCentralBLL _buyCentralbll = new BuyCentralBLL();
        OrderSheetBLL _orderSheetbll = new OrderSheetBLL();
        CompanyBLL companyBll = new CompanyBLL();
        SupplierBLL supplierBll = new SupplierBLL();
        RChallanBLL rChallanBll = new RChallanBLL();


        private ERPSSL_INVEntities _context = new ERPSSL_INVEntities();

        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Session["UserID"] != null) && (Session["OCode"] != null))
            {
                if (!IsPostBack)
                {
                    GetMRRforUnallocatedList();
                    //FillSeason();
                    GetAllStore();
                    FillSupplier();
                }
            }
            else
            {
                Response.Redirect("..\\AppGateway\\Login.aspx");
            }
        }

        [System.Web.Script.Services.ScriptMethod()]
        [System.Web.Services.WebMethod]
        public static List<string> SearchChallanNo(string prefixText, int count)
        {
            using (var _context = new ERPSSL_INVEntities())
            {
                var BuyCen = from By in _context.Inv_BuyCentral
                             where (By.RefNo_ChallanNo.Contains(prefixText))
                             select By;
                List<String> refList = new List<String>();
                foreach (var RefNos in BuyCen)
                {
                    refList.Add(RefNos.RefNo_ChallanNo);
                }
                return refList;
            }
        }

        protected void GetAllStore()
        {
            try
            {
                string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                //string OCODE = "8989";
                var row = companyBll.GetStore(OCODE);
                if (row.Count > 0)
                {
                    ddlStore.DataSource = row.ToList();
                    ddlStore.DataTextField = "StoreName";
                    ddlStore.DataValueField = "Store_Code";
                    ddlStore.DataBind();
                    ddlStore.AppendDataBoundItems = false;
                    ddlStore.Items.Insert(0, new ListItem("--Select Store & Company--", "0"));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //protected void GetAllStore()
        //{
        //    try
        //    {
        //        string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
        //        //string OCODE = "8989";
        //        var row = companyBll.GetStore(OCODE);
        //        if (row.Count > 0)
        //        {
        //            ddlStore.DataSource = row.ToList();
        //            ddlStore.DataTextField = "StoreName";
        //            ddlStore.DataValueField = "Store_Id";
        //            ddlStore.DataBind();
        //            ddlStore.AppendDataBoundItems = false;
        //            ddlStore.Items.Insert(0, new ListItem("--Select Store & Company--", "0"));
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        public void FillSupplier()
        {
            try
            {
                string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                var row = supplierBll.GetSupplierEnlistedTrue(OCODE);
                if (row.Count > 0)
                {
                    ddlSupplier.DataSource = row.ToList();
                    ddlSupplier.DataValueField = "SupplierCode";
                    ddlSupplier.DataTextField = "SupplierName";
                    ddlSupplier.DataBind();
                    ddlSupplier.Items.Insert(0, new ListItem("---Select One---", "0"));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //private void FillSeason()
        //{
        //    try
        //    {
        //        string OCode = ((SessionUser)Session["SessionUser"]).OCode;
        //        var row = _orderSheetbll.GetSeasonById(OCode);
        //        if (row.Count > 0)
        //        {
        //            ddlSeason.DataSource = row.ToList();
        //            ddlSeason.DataTextField = "Season";
        //            ddlSeason.DataValueField = "OrderEntryID";
        //            ddlSeason.DataBind();
        //            ddlSeason.AppendDataBoundItems = false;
        //            ddlSeason.Items.Insert(0, new ListItem("--Select Season--", "0"));
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        private void GetMRRforUnallocatedList()
        {
            try
            {
                string OCode = ((SessionUser)Session["SessionUser"]).OCode;
                List<productsDetails> result = new List<productsDetails>();
                result = _buyCentralbll.GetINV_MRRList(OCode);
                if (result.Count > 0)
                {
                    grdUnit.DataSource = result;
                    grdUnit.DataBind();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void LoadOrderNumber()
        {
            try
            {
                string ocode = ((SessionUser)Session["SessionUser"]).OCode;
                //string sesson = ddlSeason.SelectedItem.Text;

                var row = _orderSheetbll.GetOrderBySeasonId(ocode);
                if (row != null)
                {
                    ddlOrder.DataSource = row.ToList();
                    ddlOrder.DataValueField = "OrderEntryID";
                    ddlOrder.DataTextField = "OrderNo";
                    ddlOrder.DataBind();
                    ddlOrder.AppendDataBoundItems = false;
                    ddlOrder.Items.Insert(0, new ListItem("--Select Order No.--", "0"));
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

        protected void grdUnit_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdUnit.PageIndex = e.NewPageIndex;
            GetMRRforUnallocatedList();
        }

        protected void ImgUnitEdit_Click(object sender, EventArgs e)
        {
            lblMessage.Text = "";
            ImageButton imgbtn = (ImageButton)sender;
            GridViewRow row = (GridViewRow)imgbtn.NamingContainer;
            ShowDiv.Visible = true;

            try
            {
                Label lblBuyCentralId = (Label)grdUnit.Rows[row.RowIndex].FindControl("lblId");

                int fID = Convert.ToInt16(lblBuyCentralId.Text);

                Inv_BuyCentral _BuyCID = _buyCentralbll.GeBuyCentralListbyId(fID);
                if (_BuyCID != null)
                {
                    HidBuyCentralID.Value = _BuyCID.Id.ToString();
                    GetAllStore();
                    ddlStore.SelectedValue = _BuyCID.Store_Code;
                    FillSupplier();
                    ddlSupplier.SelectedValue = _BuyCID.SupplierCode;
                    txtRefNo.Text = _BuyCID.RefNo_ChallanNo;
                    txtDate.Text = _BuyCID.PurchaseDate.ToString();
                    txtPINo.Text = _BuyCID.PI_No;
                    txtMRRNo.Text = _BuyCID.ChallanNo;
                    txtMasterLCNo.Text = _BuyCID.MasterLCNo;
                    txtB2BLCNo.Text = _BuyCID.B2BLCNo;
                    txtReceiverEID.Text = _BuyCID.ReceiverEID;

                    LoadOrderNumber();
                    ddlOrder.SelectedValue = _BuyCID.OrderEId.ToString();
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

        protected void ddlSeason_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadOrderNumber();
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                Inv_BuyCentral purchase = new Inv_BuyCentral();

                //purchase.Store_Id = Convert.ToInt32(ddlStore.SelectedValue.ToString());

                purchase.SupplierCode = ddlSupplier.SelectedItem.Text;
                purchase.RefNo_ChallanNo = txtRefNo.Text;
                //purchase.SeasonID = Convert.ToInt32(ddlSeason.SelectedValue.ToString());
                purchase.OrderEId = Convert.ToInt32(ddlOrder.SelectedValue.ToString());

                purchase.Store_Code = ddlStore.SelectedValue;

                purchase.PurchaseDate = DateTime.Parse(txtDate.Text);
                purchase.ChallanNo = txtMRRNo.Text.Trim();
                purchase.MasterLCNo = txtMasterLCNo.Text;
                purchase.B2BLCNo = txtB2BLCNo.Text;
                purchase.PI_No = txtPINo.Text;
                purchase.EditDate = DateTime.Now;
                purchase.EditUser = ((SessionUser)Session["SessionUser"]).UserId;

                int pId = Convert.ToInt16(HidBuyCentralID.Value);
                int result = rChallanBll.UpdateBuyCentral(purchase, pId);
                if (result == 1)
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Data Updated Successfully')", true);
                }
                ShowDiv.Visible = false;

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

        protected void txtChallanRefNo_TextChanged(object sender, EventArgs e)
        {
            GetMRRforUnallocatedList();
        }
    }
}
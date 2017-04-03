using ERPSSL.BuyingHouse.BLL;
using ERPSSL.BuyingHouse.DAL.Repository;
using ERPSSL.INV.BLL;
using ERPSSL.LC.BLL;
using ERPSSL.LC.DAL;
using ERPSSL.LC.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ERPSSL.BuyingHouse
{
    public partial class ShipmentDetails : System.Web.UI.Page
    {
        OrderSheetBLL _orderSheetbll = new OrderSheetBLL();
        GroupBLL groupBll = new GroupBLL();
        ProductBLL productBll = new ProductBLL();
        MasterLCBLL masterBLL = new MasterLCBLL();
        BuyerBLL _Buyerbll = new BuyerBLL();
        SampleDetailsBLL _SampleDetailsBLL = new SampleDetailsBLL();

        private ERPSSL.LC.DAL.ERPSSL_LCEntities _Context = new ERPSSL.LC.DAL.ERPSSL_LCEntities();

        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Session["UserID"] != null) && (Session["OCode"] != null))
            {
                if (!IsPostBack)
                {
                    GetShipmentDetails();
                    LoadLCOrderGrid();
                }
            }
            else
            {
                Response.Redirect("..\\AppGateway\\Login.aspx");
            }
        }

        private void LoadLCOrderGrid()
        {
            string ocode = ((SessionUser)Session["SessionUser"]).OCode;
            var result = masterBLL.LoadLCOrderGrid(ocode);
            if (result.Count > 0)
            {
                grdorder.DataSource = result.ToList();
                grdorder.DataBind();
            }
            else
            {
                grdorder.DataSource = null;
                grdorder.DataBind();
            }
        }

        private void GetShipmentDetails()
        {
            string ocode = ((SessionUser)Session["SessionUser"]).OCode;
            var result = masterBLL.GetShipmentDetails(ocode);
            if (result.Count > 0)
            {
                gridShipment.DataSource = result.ToList();
                gridShipment.DataBind();
            }
            else
            {
                gridShipment.DataSource = null;
                gridShipment.DataBind();
            }
        }

        [System.Web.Script.Services.ScriptMethod()]
        [System.Web.Services.WebMethod]
        public static List<string> SearchPONo(string prefixText, int count)
        {
            using (var _context = new ERPSSL_LCEntities())
            {
                var AllOrder = from lcN in _context.LC_OrderEntry
                               where lcN.CompShipmentDate == null && ((lcN.OrderNo.Contains(prefixText)))
                               select lcN;
                List<String> OrderList = new List<String>();
                foreach (var Order_No in AllOrder)
                {
                    OrderList.Add(Order_No.OrderNo);
                }
                return OrderList;
            }
        }

        protected void btnShipment_Click(object sender, EventArgs e)
        {
            try
            {
                LC_Shipment sLC_Shipment = new LC_Shipment();

                sLC_Shipment.PO_No = lblOrderNo.Text;
                sLC_Shipment.LC_No = txtLCNumber.Text;
                sLC_Shipment.LC_ReceiveDate = Convert.ToDateTime(txtLCReceiveDate.Text);
                sLC_Shipment.Feeder_Vessel = txtFeederVessel.Text;
                sLC_Shipment.FETD = Convert.ToDateTime(txtETD.Text);
                sLC_Shipment.FETA = Convert.ToDateTime(txtETA.Text);
                sLC_Shipment.Actual_Ship_Qty = Convert.ToDouble(txtActualShipQuantity.Text);
                sLC_Shipment.Airway_Bill = txtAirwayBill.Text;
                sLC_Shipment.Export_License_No = txtExportLicenseNumber.Text;
                sLC_Shipment.GSP_Form = txtGSPForm.Text;
                sLC_Shipment.Courier_No = txtCourierNumber.Text;
                sLC_Shipment.Debit_Note_No = txtDebitNoteNo.Text;
                sLC_Shipment.Document_Receive_Date = Convert.ToDateTime(txtDocumentReceiveDate.Text);
                sLC_Shipment.Actual_FCR_Date = Convert.ToDateTime(txtActualFCRDate.Text);
                sLC_Shipment.LC_Date = Convert.ToDateTime(txtLCDate.Text);
                sLC_Shipment.LC_Expiry_Date = Convert.ToDateTime(txtLCExpiryDate.Text);
                sLC_Shipment.Mother_Vessel = txtMotherVessel.Text;
                sLC_Shipment.METD = Convert.ToDateTime(txtETD1.Text);
                sLC_Shipment.META = Convert.ToDateTime(txtETA1.Text);
                sLC_Shipment.Invoice_No = txtInvoiceNumber.Text;
                sLC_Shipment.Container_No = txtContainerNumber.Text;
                sLC_Shipment.Certificate_Of_Origin = txtCertificateOfOrigin.Text;
                sLC_Shipment.Commission_Rate = Convert.ToDouble(txtCommissionRate.Text);
                sLC_Shipment.Courier_Date = Convert.ToDateTime(txtCourierDate.Text);
                sLC_Shipment.Inspection_Certificate_No = txtInspectionCertificationNo.Text;

                sLC_Shipment.Packing_List_No = txtPackingListNumber.Text;
                sLC_Shipment.Others = txtOther.Text;
                sLC_Shipment.Create_Date = DateTime.Today;
                sLC_Shipment.Create_User = ((SessionUser)Session["SessionUser"]).UserId;
                sLC_Shipment.OCODE = ((SessionUser)Session["SessionUser"]).OCode;

                if (btnShipment.Text == "Save")
                {
                    var result = masterBLL.InsertShipment(sLC_Shipment);
                    if (result == 1)
                    {
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Data Saved Successfully')", true);
                    }
                }

                else
                {
                    int id = Convert.ToInt32(hidshipmentid.Value);
                    var result = masterBLL.UpdateShipment(sLC_Shipment, id);
                    if (result == 1)
                    {
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Data Updated Successfully')", true);
                        if (btnShipment.Text == "Update")
                        {
                            btnShipment.Text = "Save";
                        }
                    }
                }
                GetShipmentDetails();
                ShipmentClear();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void ShipmentClear()
        {
            txtLCNumber.Text = "";
            txtLCReceiveDate.Text = "";
            txtFeederVessel.Text = "";
            txtETD.Text = "";
            txtETA.Text = "";
            txtActualShipQuantity.Text = "";
            txtAirwayBill.Text = "";
            txtExportLicenseNumber.Text = "";
            txtGSPForm.Text = "";
            txtCourierNumber.Text = "";
            txtDebitNoteNo.Text = "";
            txtDocumentReceiveDate.Text = "";
            txtActualFCRDate.Text = "";
            txtLCDate.Text = "";
            txtLCExpiryDate.Text = "";
            txtMotherVessel.Text = "";
            txtETD1.Text = "";
            txtETA1.Text = "";
            txtInvoiceNumber.Text = "";
            txtContainerNumber.Text = "";
            txtCertificateOfOrigin.Text = "";
            lblOrderNoLoad.Text = "";
            ShowOrderDiv.Visible = false;
            txtCommissionRate.Text = "";
            txtCourierDate.Text = "";
            txtInspectionCertificationNo.Text = "";
            txtPackingListNumber.Text = "";
            txtOther.Text = "";
        }

        private string ConvertDate(string DateTime)
        {
            string[] dattime = DateTime.Split(' ');
            return dattime[0];
        }

        protected void imgbtnShipmentEdit_Click(object sender, ImageClickEventArgs e)
        {
            List<LC_Shipment> Shipment = new List<LC_Shipment>();
            ImageButton imgbtn = (ImageButton)sender;
            GridViewRow row = (GridViewRow)imgbtn.NamingContainer;

            try
            {
                string ShipmentId = "";
                Label lblShipment_Id = (Label)gridShipment.Rows[row.RowIndex].FindControl("lblShipment_Id");
                if (lblShipment_Id != null)
                {
                    string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                    ShipmentId = lblShipment_Id.Text;

                    Shipment = masterBLL.GetShipmentDetailsByIdandOcode(ShipmentId, OCODE);

                    if (Shipment.Count > 0)
                    {
                        foreach (LC_Shipment ship in Shipment)
                        {
                            hidshipmentid.Value = ship.Shipment_Id.ToString();
                            txtLCNumber.Text = ship.LC_No;
                            txtLCReceiveDate.Text = ConvertDate(ship.LC_ReceiveDate.ToString());
                            txtFeederVessel.Text = ship.Feeder_Vessel;
                            txtETD.Text = ConvertDate(ship.FETA.ToString());
                            txtETA.Text = ConvertDate(ship.FETD.ToString());
                            txtActualShipQuantity.Text = Convert.ToString(ship.Actual_Ship_Qty);
                            txtAirwayBill.Text = ship.Airway_Bill;
                            txtExportLicenseNumber.Text = ship.Export_License_No;
                            txtGSPForm.Text = ship.GSP_Form;
                            txtCourierNumber.Text = ship.Courier_No;
                            txtDebitNoteNo.Text = ship.Debit_Note_No;
                            txtDocumentReceiveDate.Text = ConvertDate(ship.Document_Receive_Date.ToString());
                            txtActualFCRDate.Text = ConvertDate(ship.Actual_FCR_Date.ToString());
                            txtLCDate.Text = ConvertDate(ship.LC_Date.ToString());
                            txtLCExpiryDate.Text = ConvertDate(ship.LC_Expiry_Date.ToString());
                            txtMotherVessel.Text = ship.Mother_Vessel;
                            txtETD1.Text = ConvertDate(ship.METD.ToString());
                            txtETA1.Text = ConvertDate(ship.META.ToString());
                            txtInvoiceNumber.Text = ship.Invoice_No;
                            txtContainerNumber.Text = ship.Container_No;
                            txtCertificateOfOrigin.Text = ship.Certificate_Of_Origin;
                            txtCommissionRate.Text = Convert.ToString(ship.Commission_Rate);
                            txtCourierDate.Text = ConvertDate(ship.Courier_Date.ToString());
                            txtInspectionCertificationNo.Text = ship.Inspection_Certificate_No;
                            txtPackingListNumber.Text = ship.Packing_List_No;
                            txtOther.Text = ship.Others;

                            if (btnShipment.Text == "Save")
                            {
                                btnShipment.Text = "Update";
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void imgbtnOrderSheetView_Click(object sender, ImageClickEventArgs e)
        {
            List<BuyingHouseReport> orders = new List<BuyingHouseReport>();
            ImageButton imgbtn = (ImageButton)sender;
            GridViewRow row = (GridViewRow)imgbtn.NamingContainer;

            try
            {
                //string orderId = "";
                Label lblOrderEntryID = (Label)grdorder.Rows[row.RowIndex].FindControl("lblOrderEntryID");
                if (lblOrderEntryID != null)
                {
                    string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                    int orderId = Convert.ToInt32(lblOrderEntryID.Text);

                    orders = masterBLL.GetLCOrderGridByOrderNo(orderId, OCODE);

                    if (orders.Count > 0)
                    {
                        var order = orders.FirstOrDefault();
                        hidorderid.Value = order.OrderEntryID.ToString();
                        lblOrderNo.Text = order.Order_No;
                        lblStyle.Text = order.Style_Description;
                        lblPrincipal.Text = order.PrincipalName;
                        lblBuyer.Text = order.Buyer_Name;
                        lblOrderQty.Text = order.OrderQuantity.ToString();
                        DateTime ShipmentDate_ = Convert.ToDateTime(order.ShipmentDate);
                        lblShipmentDate.Text = ShipmentDate_.ToString("MM/dd/yyyy");
                        lblTotal_Amount.Text = order.Total_Amount.ToString();
                        lblFobQty.Text = order.FobQty.ToString();
                        lblSeasonName.Text = order.SeasonName;
                        lblShipment_Mode.Text = order.Shipment_Mode;
                        lblFactoryName.Text = order.FactoryName;
                        lblGender.Text = order.Gender;
                        lblBuyer_Department.Text = order.Buyer_Department;
                        lblYarn_Fabrication.Text = order.Yarn_Fabrication;
                        lblFOB_Port.Text = order.FOB_Port;
                        lblCountryof_Production.Text = order.Countryof_Production;
                        lblStyle_Category.Text = order.Style_Category;
                        lblFullName.Text = order.FullName;
                    }
                    showInfo.Visible = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btnNext_Click(object sender, EventArgs e)
        {
            ShowOrderDiv.Visible = true;
            lblOrderNoLoad.Text = lblOrderNo.Text;
            TabContainer1.ActiveTabIndex = 1;
        }
    }
}
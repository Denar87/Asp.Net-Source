using ERPSSL.LC.BLL;
using ERPSSL.LC.DAL;
using ERPSSL.Production.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ERPSSL.Production
{
    public partial class DailyProductionDetails : System.Web.UI.Page
    {

        DailyProductionDetailsBLL _bailyProductionDetailsBLL = new DailyProductionDetailsBLL();
        OrderSheetBLL _orderSheetbll = new OrderSheetBLL();

        ERPSSL_LCEntities _Content = new ERPSSL_LCEntities();

        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Session["UserID"] != null) && (Session["OCode"] != null))
            {
                if (!IsPostBack)
                {
                    FillStyle();
                    GetOrder();
                }
            }
            else
            {
                Response.Redirect("..\\AppGateway\\Login.aspx");
            }
        }

        private void GetOrder()
        {
            try
            {
                string ocode = ((SessionUser)Session["SessionUser"]).OCode;
                List<LC_OrderEntry> row = _bailyProductionDetailsBLL.GetOrderlist(ocode);
                if (row != null)
                {
                    ddlOrder.DataSource = row.ToList();
                    ddlOrder.DataTextField = "OrderNo";
                    ddlOrder.DataValueField = "OrderEntryID";
                    ddlOrder.DataBind();
                    ddlOrder.AppendDataBoundItems = false;
                    ddlOrder.Items.Insert(0, new ListItem("--Select Season--", "0"));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void FillStyle()
        {
            try
            {
                string ocode = ((SessionUser)Session["SessionUser"]).OCode;
                List<LC_Style> row = _orderSheetbll.GetLC_Style(ocode);
                if (row != null)
                {
                    ddlStyle.DataSource = row.ToList();
                    ddlStyle.DataTextField = "StyleName";
                    ddlStyle.DataValueField = "StyleId";
                    ddlStyle.DataBind();
                    ddlStyle.AppendDataBoundItems = false;
                    ddlStyle.Items.Insert(0, new ListItem("--Select Season--", "0"));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        protected void txtSewingAchieve_TextChanged(object sender, EventArgs e)
        {
            int hun = 100;
            double Achieved = Convert.ToDouble(txtSewingAchieve.Text);
            double Target = Convert.ToDouble(txtSewingTarget.Text);
            double Divission = Convert.ToDouble(Achieved / Target);
            double lbltxtPersentiges = Divission * hun;
            Session["lbltxtPersentiges"] = lbltxtPersentiges;
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                Prod_ProductionStatusDetails _objProductionStatusDetails = new Prod_ProductionStatusDetails();

                _objProductionStatusDetails.Date = Convert.ToDateTime(txtOrderDate.Text);
                _objProductionStatusDetails.OrderNo = ddlOrder.SelectedIndex.ToString();
                _objProductionStatusDetails.StyleNo = ddlStyle.SelectedIndex.ToString();
                _objProductionStatusDetails.DayCutting = Convert.ToDouble(txtDayCutting.Text);
                _objProductionStatusDetails.DayInputSupply = Convert.ToDouble(txtCuttingInput.Text);
                _objProductionStatusDetails.DayInput = Convert.ToDouble(txtSewingInput.Text);
                _objProductionStatusDetails.DayTarget = Convert.ToDouble(txtSewingTarget.Text);
                _objProductionStatusDetails.DayAcheive = Convert.ToDouble(txtSewingAchieve.Text);
                _objProductionStatusDetails.Received = Convert.ToDouble(txtFinishingReceived.Text);
                _objProductionStatusDetails.Iron = Convert.ToDouble(txtFinishingIron.Text);
                _objProductionStatusDetails.DayPoly = Convert.ToDouble(txtDayPoly.Text);
                _objProductionStatusDetails.DayPacking = Convert.ToDouble(txtDayPacking.Text);
                _objProductionStatusDetails.DayShipment = Convert.ToDouble(txtDayShipment.Text);
                _objProductionStatusDetails.ShipmentFOB = Convert.ToDouble(txtShipmentFOB.Text);
                _objProductionStatusDetails.StorDayShipment = Convert.ToDouble(txtStoreShipment.Text);
                _objProductionStatusDetails.StorShipmentFOB = Convert.ToDouble(txtStoreShipmentFOB.Text);
                _objProductionStatusDetails.AcheivePercentage = Convert.ToDouble(Session["lbltxtPersentiges"]);
                _objProductionStatusDetails.Remarks = txtRemarks.Text;
                _objProductionStatusDetails.Create_Date = DateTime.Today;
                _objProductionStatusDetails.Create_User = ((SessionUser)Session["SessionUser"]).UserId;
                _objProductionStatusDetails.OCode = ((SessionUser)Session["SessionUser"]).OCode;
                

                int result = _bailyProductionDetailsBLL.InsertProductionDetails(_objProductionStatusDetails);
                if (result == 1)
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Data Saved Successfully')", true);                  
                } 
                ClearUi();
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void ClearUi()
        {
            txtOrderDate.Text = "";
            ddlOrder.ClearSelection();
            ddlStyle.ClearSelection();
            txtDayCutting.Text = "";
            txtCuttingInput.Text = "";
            txtSewingInput.Text = "";
            txtSewingTarget.Text = "";
            txtSewingAchieve.Text = "";
            txtFinishingReceived.Text = "";
            txtFinishingIron.Text = "";
            txtDayPoly.Text = "";
            txtDayPacking.Text = "";
            txtDayShipment.Text = "";
            txtShipmentFOB.Text = "";
            txtStoreShipment.Text = "";
            txtStoreShipmentFOB.Text = "";
            txtRemarks.Text = "";
            lbltxtPersentiges.Text = "";
        }

        
    }
}
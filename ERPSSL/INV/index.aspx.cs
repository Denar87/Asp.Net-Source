using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using ERPSSL.Dashboard.Repository;
using ERPSSL.Dashboard.BLL;
using System.Web.Services;
using Microsoft.Reporting.WebForms;
using ERPSSL.INV.BLL;
using ERPSSL.INV.DAL.Repository;
using ERPSSL.INV.DAL;

namespace ERPSSL.INV
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Session["UserID"] != null) && (Session["OCode"] != null))
            {
                if (!IsPostBack)
                {
                    GetTodayStockDetails();
                    GetTodayReqDetails();
                    GetLastMonthDetails();
                    GetProductStatus();
                    GetTodayDetails1();
                    GetTodayRequisitionDetails1();
                    GetMonthlyDetails1();
                }
            }
            else
            {
                Response.Redirect("..\\AppGateway\\Login.aspx");
            }
        }

        ProductStatusBLL _productStatus = new ProductStatusBLL();
        ProductBLL aProductBLL = new ProductBLL();
        ReportsBll rpt = new ReportsBll();
        private void GetProductStatus()
        {
            try
            {
                string status = "";
                string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                string EID = ((SessionUser)Session["SessionUser"]).EID;

                //List<Inv_Product> product1 = _productStatus.GetProductStatus(OCODE);
                List<productsDetails> product = aProductBLL.GetAllGroupProductByEID(EID, OCODE);

                foreach (productsDetails aitem in product)
                {
                    Inv_BuyCentral _buyCentral = _productStatus.GetProductQtyformBuyCentral(aitem);
                    //productsDetails _buyCentral = _productStatus.GetAllStockProductByEID(EID, OCODE);
                    //var _buyCentral = lstproductsDetails.FirstOrDefault();

                    if (_buyCentral != null)
                    {
                        if (aitem.ReOrderQty == _buyCentral.BalanceQuanity)
                        {
                            status += "<b style='color:Black'><img src='img/tkupdown.gif' /> " + aitem.ProductName + "-" + _buyCentral.BalanceQuanity;
                        }
                        else if (aitem.ReOrderQty > _buyCentral.BalanceQuanity)
                        {
                            status += "<b style='color:Black'><img src='img/tkdown.gif' /> " + aitem.ProductName + "-" + _buyCentral.BalanceQuanity;
                        }
                        else if (aitem.ReOrderQty < _buyCentral.BalanceQuanity)
                        {
                            status += "<b style='color:Black'><img src='img/tkup.gif' /> " + aitem.ProductName + "-" + _buyCentral.BalanceQuanity;
                        }
                    }
                }

                lblitem.Text = status;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void GetInventoryDetails()
        {
            try
            {
                InventoryDetailsR _inventory = aProductBLL.GetInventoryDetails();
                if (_inventory != null)
                {
                    // lblTotalStock.Text = _inventory.TotalStock.ToString();
                    // lblTotalPurchase.Text = _inventory.TotalPurchase.ToString();
                    // lblTotalIssue.Text = _inventory.TotalIssue.ToString();
                    // lblTotalDamage.Text = _inventory.TotalDamage.ToString();
                    // lblTotalReturn.Text = _inventory.TotalReturn.ToString();
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }
        private void GetTodayStockDetails()
        {
            try
            {
                InventoryDetailsR _inventory = aProductBLL.GetTodayStockDetails();
                if (_inventory != null)
                {
                    lblMRRToday.Text = _inventory.TotalMRR.ToString();
                    lblGINToday.Text = _inventory.TotalGIN.ToString();
                    lblTotalDamageToday.Text = _inventory.TotalTodayDamage.ToString();
                    lblReturnToday.Text = _inventory.TotalTodayReturn.ToString();
                }


            }
            catch (Exception)
            {

                throw;
            }
        }

        private void GetTodayReqDetails()
        {
            try
            {
                InventoryDetailsR _inventory = aProductBLL.GetTodayReqDetails();
                if (_inventory != null)
                {
                    lblStoreRequisition.Text = _inventory.TotalStoreReq.ToString();
                    lblApproveStore.Text = _inventory.ApproveStoreReq.ToString();
                    lblPurchaseReq.Text = _inventory.TotalPurchaseReq.ToString();
                    lblApprovePurchaseReq.Text = _inventory.ApprovePurchaseReq.ToString();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        private void GetLastMonthDetails()
        {
            try
            {
                InventoryDetailsR _inventory = aProductBLL.GetLastMonthDetails();
                if (_inventory != null)
                {
                    lblLastStore.Text = _inventory.LastMonthStoreReq.ToString();
                    lblLastPurchase.Text = _inventory.LastMonthPurchaseReq.ToString();
                    lblLastMRR.Text = _inventory.LastMonthMRR.ToString();
                    lblLastGIN.Text = _inventory.LastMonthGIN.ToString();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public class InventoryDetailsi
        {
            public string totalStock { get; set; }
            public int totalIssue { get; set; }
        }
        public class TodayStockDetails
        {
            public string totalStock { get; set; }
            public int totalIssue { get; set; }
        }
        public class TodayreqDetails
        {
            public string totalStock { get; set; }
            public int totalIssue { get; set; }
        }
        public class MonthlyDetails
        {
            public string totalStock { get; set; }
            public int totalIssue { get; set; }
        }

        [WebMethod]
        public static List<InventoryDetailsi> GetInventoryDatai()
        {

            ProductBLL aProductBLL = new ProductBLL();

            InventoryDetailsR _InventoryDetailsR = aProductBLL.GetInventoryDetails();

            int TotalStock = Convert.ToInt32(_InventoryDetailsR.TotalStock.ToString());
            int TotalPurchase = Convert.ToInt32(_InventoryDetailsR.TotalPurchase.ToString());
            int TotalIssue = Convert.ToInt32(_InventoryDetailsR.TotalIssue.ToString());
            int TotalDamage = Convert.ToInt32(_InventoryDetailsR.TotalDamage.ToString());
            int TotalReturn = Convert.ToInt32(_InventoryDetailsR.TotalReturn.ToString());


            List<InventoryDetailsi> dataAtti = new List<InventoryDetailsi>() { 
                new InventoryDetailsi{totalStock="Total Stock",totalIssue=TotalStock },
                   new InventoryDetailsi{totalStock="Total Purchase",totalIssue=TotalPurchase },
                   new InventoryDetailsi{totalStock="Total Issue",totalIssue=TotalIssue },
                   new InventoryDetailsi{totalStock="Total Damage",totalIssue=TotalDamage },
                    new InventoryDetailsi{totalStock="Total Return",totalIssue=TotalReturn }
                
                };


            return dataAtti;
        }




        public void GetTodayDetails1()
        {

            InventoryDetailsR _InventoryDetailsR = aProductBLL.GetTodayStockDetails();

            int TotalMRR = Convert.ToInt32(_InventoryDetailsR.TotalMRR.ToString());
            int TotalGIN = Convert.ToInt32(_InventoryDetailsR.TotalGIN.ToString());
            int TotalDamage = Convert.ToInt32(_InventoryDetailsR.TotalTodayDamage.ToString());
            int TotalReturn = Convert.ToInt32(_InventoryDetailsR.TotalTodayReturn.ToString());



            List<TodayStockDetails> dataAtti = new List<TodayStockDetails>() { 
                new TodayStockDetails{totalStock="Total MRR",totalIssue=TotalMRR },
                   new TodayStockDetails{totalStock="Total GIN",totalIssue=TotalGIN },
                   new TodayStockDetails{totalStock="Total Damage",totalIssue=TotalDamage },
                   new TodayStockDetails{totalStock="Total Return",totalIssue=TotalReturn }
                    
                
                };

            string[] color = new string[] { "Green", "Yellow", "Red", "Orchid" };
            foreach (var item in dataAtti)
            {
                Chart1.Series["Series1"].Points.AddXY(item.totalStock, item.totalIssue);

            }
            for (int pointIndex = 0; pointIndex < 4; pointIndex++)
            {
                Chart1.Series["Series1"].Points[pointIndex].Color = System.Drawing.Color.FromName(color[pointIndex]);
            }
            // Chart2.Series["Series1"].YValueMembers = "Value,intvalueforcolor";
            Chart1.Series["Series1"]["PieLabelStyle"] = "Disabled";

        }


        public void GetTodayRequisitionDetails1()
        {

            InventoryDetailsR _InventoryDetailsR = aProductBLL.GetTodayReqDetails();

            int TotalStore = Convert.ToInt32(_InventoryDetailsR.TotalStoreReq.ToString());
            int TotalApproveStore = Convert.ToInt32(_InventoryDetailsR.ApproveStoreReq.ToString());
            int TotalPurchase = Convert.ToInt32(_InventoryDetailsR.TotalPurchaseReq.ToString());
            int TotalApprovePurchase = Convert.ToInt32(_InventoryDetailsR.ApprovePurchaseReq.ToString());



            List<TodayreqDetails> dataAtti = new List<TodayreqDetails>() { 
                new TodayreqDetails{totalStock="Store Requisition ",totalIssue=TotalStore },
                   new TodayreqDetails{totalStock="Approved Store Requisition ",totalIssue=TotalApproveStore },
                   new TodayreqDetails{totalStock="Purchase Requisition ",totalIssue=TotalPurchase },
                   new TodayreqDetails{totalStock="App.Purchase Requisition",totalIssue=TotalApprovePurchase }
                    };

            //Chart1.DataSource = dataList;
            string[] color = new string[] { "Orange", "Green", "Red", "Blue" };
            foreach (var item in dataAtti)
            {
                Chart2.Series["Series1"].Points.AddXY(item.totalStock, item.totalIssue);

            }
            for (int pointIndex = 0; pointIndex < 4; pointIndex++)
            {
                Chart2.Series["Series1"].Points[pointIndex].Color = System.Drawing.Color.FromName(color[pointIndex]);
            }
            Chart2.Series["Series1"].YValueMembers = "Value,intvalueforcolor";

        }


        public void GetMonthlyDetails1()
        {

            InventoryDetailsR _InventoryDetailsR = aProductBLL.GetLastMonthDetails();

            int TotalStore = Convert.ToInt32(_InventoryDetailsR.LastMonthStoreReq.ToString());
            int TotalPurchase = Convert.ToInt32(_InventoryDetailsR.LastMonthPurchaseReq.ToString());
            int TotalMRR = Convert.ToInt32(_InventoryDetailsR.LastMonthMRR.ToString());
            int TotalGIN = Convert.ToInt32(_InventoryDetailsR.LastMonthGIN.ToString());



            List<MonthlyDetails> dataAtti = new List<MonthlyDetails>() { 
                new MonthlyDetails{totalStock="Store Req",totalIssue=TotalStore },
                   new MonthlyDetails{totalStock="Purchase Req",totalIssue=TotalPurchase },
                   new MonthlyDetails{totalStock="MRR",totalIssue=TotalMRR },
                   new MonthlyDetails{totalStock="GIN",totalIssue=TotalGIN }
                };

            //Chart1.DataSource = dataList;
            string[] color = new string[] { "Orange", "Red", "Green", "Blue" };
            foreach (var item in dataAtti)
            {
                Chart3.Series["Series1"].Points.AddXY(item.totalStock, item.totalIssue);

            }
            for (int pointIndex = 0; pointIndex < 4; pointIndex++)
            {
                Chart3.Series["Series1"].Points[pointIndex].Color = System.Drawing.Color.FromName(color[pointIndex]);
            }
            Chart3.Series["Series1"].YValueMembers = "Value,intvalueforcolor";

        }

        protected void lblitem_Click(object sender, EventArgs e)
        {
            try
            {
                List<productsDetails> Details = new List<productsDetails>();
                Details = rpt.Rpt_GetStockBy_ReOrderQty();

                if (Details.Count > 0)
                {
                    ReportViewer1.LocalReport.DataSources.Clear();
                    ReportDataSource reportDataset = new ReportDataSource("AllStockReport_RPT_DS", Details);
                    ReportViewer1.LocalReport.DataSources.Add(reportDataset);
                    ReportViewer1.LocalReport.ReportPath = Server.MapPath("Reports/RPT_AllCentralStockReportBy_LessThenQty.rdlc");
                    ReportViewer1.LocalReport.Refresh();
                    ModalPopupExtender.Show();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No data found!')", true);
                    //ReportViewer1.Reset();
                    //ReportViewer1.LocalReport.Refresh();
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }
    }
}
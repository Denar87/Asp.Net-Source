using ERPSSL.Marketing.BLL;
using ERPSSL.Marketing.DAL;
using ERPSSL.Marketing.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ERPSSL.Marketing
{
    public partial class ViewCurrentMonthCollection : System.Web.UI.Page
    {

        WorkOrderTransactionBLL aWorkOrderTransactionBLL = new WorkOrderTransactionBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if ((Session["UserID"] != null) && (Session["OCode"] != null))
                {
                    ShowDataInGrid();
                }
                else
                {
                    Response.Redirect("..\\AppGateway\\Login.aspx");
                }
            }
        }


        public void ShowDataInGrid()
        {

            decimal preMonthCollectionAmount = 0;
            int nowMonth = DateTime.Now.Month;
            int nowYear = DateTime.Now.Year;

            

            try
            {
                string OCode = Convert.ToString(((SessionUser)Session["SessionUser"]).OCode);

                List<MarketingWorkOrderTransaction> aMarketingWorkOrderTransaction = aWorkOrderTransactionBLL.GetAllCurrentMonthTransactionDetails(nowMonth, nowYear, OCode);

                if (aMarketingWorkOrderTransaction.Count > 0)
                {
                    TransactionGridView.DataSource = aMarketingWorkOrderTransaction;
                    TransactionGridView.DataBind();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
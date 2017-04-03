using ERPSSL.Marketing.BLL;
using ERPSSL.Marketing.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ERPSSL.Marketing
{
    public partial class ViewLastMonthCollection : System.Web.UI.Page
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

            // Find previous year and month

            var today = DateTime.Today;
            var month = new DateTime(today.Year, today.Month, 1);
            var first = month.AddMonths(-1);
            var last = month.AddDays(-1);
            int preMonth = first.Month;
            int preYear = first.Year;



            try
            {
                string OCode = Convert.ToString(((SessionUser)Session["SessionUser"]).OCode);

                List<MarketingWorkOrderTransaction> aMarketingWorkOrderTransaction = aWorkOrderTransactionBLL.GetAllCurrentMonthTransactionDetails(preMonth, preYear, OCode);

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
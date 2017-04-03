using ERPSSL.Marketing.BLL;
using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ERPSSL.Marketing
{
    public partial class CollectionReport : System.Web.UI.Page
    {
        WorkOrderTransactionBLL aWorkOrderTransactionBLL = new WorkOrderTransactionBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if ((Session["UserID"] != null) && (Session["OCode"] != null))
                {
                    //GetWorkOrderDetailsForGridView();
                    //ShowMarketingInfoInGridView();
                }
                else
                {
                    Response.Redirect("..\\AppGateway\\Login.aspx");
                }
            }
        }

        protected void btnProcess_Click(object sender, EventArgs e)
        {
            try
            {
                string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                DateTime FromDate = Convert.ToDateTime(txtFromDate.Text);
                DateTime ToDate = Convert.ToDateTime(txtToDate.Text);

                var reportResult = aWorkOrderTransactionBLL.GetCollectionInformationByDate(OCODE, FromDate, ToDate);

                if (reportResult.Count > 0)
                {
                    //collectionReportViewer.LocalReport.DataSources.Clear();

                    ReportDataSource reportDataset = new ReportDataSource("DataSet1", reportResult);
                    collectionByClientReportViewer.LocalReport.DataSources.Add(reportDataset);
                    collectionByClientReportViewer.LocalReport.ReportPath = Server.MapPath("Reports/CollectionByDate.rdlc");
                    collectionByClientReportViewer.LocalReport.Refresh();

                }
            }
            catch (Exception ec)
            {
                throw ec;
            }

        }
    }
}
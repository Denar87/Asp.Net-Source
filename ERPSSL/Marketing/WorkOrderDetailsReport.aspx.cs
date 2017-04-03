using ERPSSL.Marketing.BLL;
using ERPSSL.Marketing.DAL.Repository;
using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ERPSSL.Marketing
{
    public partial class WorkOrderDetailsReport : System.Web.UI.Page
    {
        WorkOrderDetailsReportBLL aWorkOrderDetailsReportBLL = new WorkOrderDetailsReportBLL();
        MarketingWorkOrder aMarketingWorkOrder = new MarketingWorkOrder();

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

            string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
            DateTime FromDate = Convert.ToDateTime(txtFromDate.Text);
            DateTime ToDate = Convert.ToDateTime(txtToDate.Text);

            var reportResult = aWorkOrderDetailsReportBLL.GetAllInformationOfWorkOrder(OCODE, FromDate, ToDate);

            if (reportResult.Count > 0)
            {
                WorkOrderDetailsReportViewer.LocalReport.DataSources.Clear();

                ReportDataSource reportDataset = new ReportDataSource("DataSet1", reportResult);
                WorkOrderDetailsReportViewer.LocalReport.DataSources.Add(reportDataset);
                WorkOrderDetailsReportViewer.LocalReport.ReportPath = Server.MapPath("Reports/ReportWorkOrderDetails.rdlc");
                WorkOrderDetailsReportViewer.LocalReport.Refresh();

            }
        }
    }
}
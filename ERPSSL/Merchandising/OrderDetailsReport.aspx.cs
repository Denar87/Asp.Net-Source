using ERPSSL.Marketing.BLL;
using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ERPSSL.Merchandising
{
    public partial class OrderDetailsReport : System.Web.UI.Page
    {

        OrderDetailsReportBLL aOrderDetailsReportBLL = new OrderDetailsReportBLL(); 

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if ((Session["UserID"] != null) && (Session["OCode"] != null))
                {
                    ShowOrderReport();
                }
                else
                {
                    Response.Redirect("..\\AppGateway\\Login.aspx");
                }
            }
        }

        public void ShowOrderReport()
        {
            string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
          
            var reportResult = aOrderDetailsReportBLL.GetAllInformationOfOrder(OCODE);

            if (reportResult.Count > 0)
            {
                ReportViewerOrderDetails.LocalReport.DataSources.Clear();

                ReportDataSource reportDataset = new ReportDataSource("DataSet1", reportResult);
                ReportViewerOrderDetails.LocalReport.DataSources.Add(reportDataset);
                ReportViewerOrderDetails.LocalReport.ReportPath = Server.MapPath("Reports/ReportOrderDetails.rdlc");
                ReportViewerOrderDetails.LocalReport.Refresh();

            }
        }
    }
}
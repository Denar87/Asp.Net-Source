using ERPSSL.Merchandising.BLL;
using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ERPSSL.Merchandising
{
    public partial class YarnDeterminationReport : System.Web.UI.Page
    {

        YarnCountDeterminationBLL aYarnCountDeterminationBLL = new YarnCountDeterminationBLL(); 

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if ((Session["UserID"] != null) && (Session["OCode"] != null))
                {
                    ShowYarnDeterminationReport();
                }
                else
                {
                    Response.Redirect("..\\AppGateway\\Login.aspx");
                }
            }
        }

        public void ShowYarnDeterminationReport()
        {
            string OCODE = ((SessionUser)Session["SessionUser"]).OCode;

            Guid userIdEccess = ((SessionUser)Session["SessionUser"]).UserId;

            var reportResult = aYarnCountDeterminationBLL.GetAllInformationOfYD(OCODE, userIdEccess);

            if (reportResult.Count > 0)
            {
                ReportViewerYarnDetermination.LocalReport.DataSources.Clear();

                ReportDataSource reportDataset = new ReportDataSource("DataSet1", reportResult);
                ReportViewerYarnDetermination.LocalReport.DataSources.Add(reportDataset);
                ReportViewerYarnDetermination.LocalReport.ReportPath = Server.MapPath("Reports/ReportYarnDetermination.rdlc");
                ReportViewerYarnDetermination.LocalReport.Refresh();

            }
        }
    }
}
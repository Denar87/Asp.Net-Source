using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Reporting.WebForms;
using System.IO;
using System.Text;
using System.Drawing.Imaging;
using System.Drawing.Printing;

namespace ERPSSL.LC
{
    public partial class Report_Viewer : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Session["UserID"] != null) && (Session["OCode"] != null))
            {
                try
                {
                    if (!IsPostBack)
                    {
                        string rptDs = Convert.ToString(Session["rptDs"]);
                        var reportDataSource = new ReportDataSource
                        {
                            Name = rptDs,
                            Value = Session["rptDt"]
                        };
                        ReportViewer1.LocalReport.DataSources.Clear();
                        ReportViewer1.LocalReport.DataSources.Add(reportDataSource);
                        ReportViewer1.LocalReport.ReportPath = Server.MapPath(Convert.ToString(Session["rptFile"]));
                        ReportParameter prm_1 = new ReportParameter("datePrint", Convert.ToString(DateTime.Now.Date));
                       //// ReportParameter prm_2 = new ReportParameter("rptTitle", Convert.ToString(Session["rptTitle"]));
                        ReportParameter prm_3 = new ReportParameter("FromBank", Convert.ToString(Session["FromBank"]));
                        ReportParameter prm_4 = new ReportParameter("ToBank", Convert.ToString(Session["ToBank"]));
                        ReportParameter prm_5 = new ReportParameter("LCNumber", Convert.ToString(Session["LCNumber"]));
                        ReportViewer1.LocalReport.SetParameters(new ReportParameter[] { prm_1, prm_3, prm_4, prm_5 });
                        ReportViewer1.LocalReport.Refresh();
                    }
                }
                catch(Exception ex)
                {
                    throw;
                }
            }
            else
            {
                Response.Redirect("..\\AppGateway\\Login.aspx");
            }
        }

        protected void btnDload_Click(object sender, EventArgs e)
        {
            string FileType = "PDF";
            Warning[] warnings;
            string[] streamids;
            string mimeType;
            string encoding;
            string filenameExtension;
            string FileName = "File_" + Session["rptTitle"].ToString() + "_" + DateTime.Now.ToString("ddMMyyyyhhmmss");
            if (rdbPdf.Checked) { FileType = "PDF"; }
            //if (rdbDoc.Checked) { FileType = "WORD"; }
            if (rdbExcel.Checked) { FileType = "EXCEL"; }
            byte[] bytes = ReportViewer1.LocalReport.Render(FileType, null, out mimeType, out encoding, out filenameExtension, out streamids, out warnings);
            Response.Buffer = true;
            Response.Clear();
            Response.ContentType = mimeType;
            Response.AddHeader("content-disposition", "attachment; filename= " + FileName + "." + filenameExtension);
            Response.OutputStream.Write(bytes, 0, bytes.Length);
            Response.Flush();
            Response.End();
        }

    }
}
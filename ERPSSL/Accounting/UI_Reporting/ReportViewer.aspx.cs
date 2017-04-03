using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Reporting.WebForms;
using System.Drawing;
using Financial_MgtSystem_BLL;
using Financial_MgtSystem_BLL.CommonUtilities;
//using iTextSharp.text.pdf;
//using iTextSharp.text;
using System.IO;
using System.Text;
using System.Drawing.Imaging;
using System.Drawing.Printing;

namespace ERPSSL.Accounting.UI_Reporting
{
    public partial class ReportViewer : System.Web.UI.Page
    {
        cmp_CompanysUser_BLL objUser = new cmp_CompanysUser_BLL();
        Common_BLL objCommon = new Common_BLL();

        String[] GetPermission = new String[4];
        string RoleID, PageID, Edit_User, CompanyCode, OCode, FileType = "PDF";
        private int m_currentPageIndex;
        private IList<Stream> m_streams;

        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Session["CompanyCode"] != null) && (Session["OCode"] != null))
            {
                RoleID = Session["RoleID"].ToString();
                PageID = "15";
                Edit_User = Session["UserID"].ToString();
                CompanyCode = Session["CompanyCode"].ToString();
                OCode = Session["OCode"].ToString();

                 //GetPermission = objCommon.Permission(RoleID, PageID, OCode);
                //[0]CanVisit//[1]CanEdit//[2]CanDelete//[3]CanExecute
                //if (GetPermission[0].ToString() == "True")
                //{
                if (!IsPostBack)
                {
                    LoadReport();
                    lblTitle.Text = "Printing Report: " + Convert.ToString(Session["ReportTitle"]);

                }
                //}
                //else
                //{
                //    ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "User Permission", "alert('You don't have permission to access this page!!)');", true);
                //    HttpContext.Current.Response.Redirect("..\\UI_Utilities\\DeniedPage.aspx");
                //}
            }
            else
            {
                Response.Redirect("..\\..\\Default.aspx");
            }
        }

        private void LoadReport()
        {
            try
            {
                string rptDs = Convert.ToString(Session["rptDs"]);
                var reportDataSource = new ReportDataSource
                {
                    Name = rptDs,
                    Value = Session["rptDt"]
                };

                ReportViewerAc.LocalReport.DataSources.Clear();
                ReportViewerAc.LocalReport.DataSources.Add(reportDataSource);
                ReportViewerAc.LocalReport.ReportPath = Server.MapPath(Convert.ToString(Session["rptFile"]));

                ReportParameter rp1 = new ReportParameter("ReportTitle", Convert.ToString(Session["ReportTitle"]));
                ReportParameter rp2 = new ReportParameter("ReportCriteria", Convert.ToString(Session["ReportCriteria"]));
                ReportParameter rp3 = new ReportParameter("OrganizationDetails", Convert.ToString(Session["OrganizationDetails"]));
                ReportParameter rp4 = new ReportParameter("OrganizationAddress", Convert.ToString(Session["OrganizationAddress"]));
                ReportParameter rp5 = new ReportParameter("OrganizationContact", Convert.ToString(Session["OrganizationContact"]));
                ReportParameter rp6 = new ReportParameter("DatePrint", Convert.ToString(Session["DatePrint"]));
                ReportViewerAc.LocalReport.SetParameters(new ReportParameter[] { rp1, rp2, rp3, rp4, rp5, rp6 });
                ReportViewerAc.LocalReport.Refresh();
                Export(ReportViewerAc.LocalReport);
                Print();
                Dispose();
            }
            catch (Exception ex)
            {
                this.lblMessage.Text = ex.Message.ToString();
                this.lblMessage.ForeColor = Color.White;
            }
        }

        #region [ Export & Print ]
        private void Export(LocalReport report)
        {
            string deviceInfo =
              @"<DeviceInfo>
                <OutputFormat>EMF</OutputFormat>
                <PageWidth>8.5in</PageWidth>
                <PageHeight>11.69in</PageHeight>
                <MarginTop>0.5in</MarginTop>
                <MarginLeft>0.1in</MarginLeft>
                <MarginRight>0in</MarginRight>
                <MarginBottom>0.05in</MarginBottom>
            </DeviceInfo>";
            Warning[] warnings;
            m_streams = new List<Stream>();
            report.Render("Image", deviceInfo, CreateStream, out warnings);
            foreach (Stream stream in m_streams)
            {
                stream.Position = 0;
            }
        }
        private Stream CreateStream(string name, string fileNameExtension, Encoding encoding, string mimeType, bool willSeek)
        {
            Stream stream = new MemoryStream();
            m_streams.Add(stream);
            return stream;
        }
        private void PrintPage(object sender, PrintPageEventArgs ev)
        {
            Metafile pageImage = new Metafile(m_streams[m_currentPageIndex]);
            Rectangle adjustedRect = new Rectangle(
                ev.PageBounds.Left - (int)ev.PageSettings.HardMarginX,
                ev.PageBounds.Top - (int)ev.PageSettings.HardMarginY,
                ev.PageBounds.Width,
                ev.PageBounds.Height);

            ev.Graphics.FillRectangle(Brushes.White, adjustedRect);
            ev.Graphics.DrawImage(pageImage, adjustedRect);
            m_currentPageIndex++;
            ev.HasMorePages = (m_currentPageIndex < m_streams.Count);
        }
        private void Print()
        {
            if (m_streams == null || m_streams.Count == 0) throw new Exception("Error: no stream to print.");
            PrintDocument printDoc = new PrintDocument();

            if (!printDoc.PrinterSettings.IsValid)
            {
                Exception ex = new Exception("Error: cannot find the default printer.");
                this.lblMessage.Text = ex.Message.ToString();
                this.lblMessage.ForeColor = Color.White;
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('" + ex.Message.ToString() + "');", true);
                //Download();
                //return;
            }
            else
            {
                printDoc.PrintPage += new PrintPageEventHandler(PrintPage);
                m_currentPageIndex = 0;
                printDoc.Print();
            }
        }

        public void Dispose()
        {
            if (m_streams != null)
            {
                foreach (Stream stream in m_streams)
                {
                    stream.Close();
                }
                m_streams = null;
            }
        }

        protected void btnPrint_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                Export(ReportViewerAc.LocalReport);
                Print();
            }
            catch (Exception ex)
            {
                this.lblMessage.Text = ex.Message.ToString();
                this.lblMessage.ForeColor = Color.White;
            }
        }
        #endregion
        protected void btnBack_Click(object sender, ImageClickEventArgs e)
        {
            //Response.Redirect("..\\UI_Gateway\\CompanyList.aspx");
            if (Request.QueryString["ReturnURL"] != null)
            {
                Response.Redirect(HttpUtility.UrlDecode(Request.QueryString["ReturnURL"]));
            }
            else
            {
                Response.Redirect("..\\UI_Gateway\\CompanyList.aspx");
            }
        }

        #region [ Download ]
        protected void btnDownload_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                Download();
            }
            catch (Exception ex)
            {
                this.lblMessage.Text = ex.Message.ToString();
                this.lblMessage.ForeColor = Color.White;
            }
        }
        public void Download()
        {
            Warning[] warnings;
            string[] streamids;
            string mimeType;
            string encoding;
            string filenameExtension;
            string FileName = "File_" + Session["ReportTitle"].ToString() + "_" + DateTime.Now.ToString("ddMMyyyyhhmmss");
            if (rdbPdf.Checked) { FileType = "PDF"; }
            if (rdbDoc.Checked) { FileType = "WORD"; }
            if (rdbExcel.Checked) { FileType = "EXCEL"; }

            byte[] bytes = ReportViewerAc.LocalReport.Render(FileType, null, out mimeType, out encoding, out filenameExtension, out streamids, out warnings);
            Response.Buffer = true;
            Response.Clear();
            Response.ContentType = mimeType;
            Response.AddHeader("content-disposition", "attachment; filename= " + FileName + "." + filenameExtension);
            //Response.AddHeader("content-disposition", "attachment; filename= " + Session["ReportTitle"].ToString() + "_" + DateTime.Today.TimeOfDay + "." + filenameExtension);
            Response.OutputStream.Write(bytes, 0, bytes.Length); // create the file  
            Response.Flush(); // send it to the client to download  
            Response.End();
            if (Request.QueryString["ReturnURL"] != null)
            {
                Response.Redirect(Request.QueryString["ReturnURL"]);
            }
            else
            {
                Response.Redirect("..\\UI_Gateway\\CompanyList.aspx");
            }
        }
        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ERPSSL.Visitor.BLL;
using ERPSSL.Visitor.DAL.Repository;
using Microsoft.Reporting.WebForms;

namespace ERPSSL.Visitor
{
    public partial class Visitor_Report : System.Web.UI.Page
    {
        
        Visitor_RPT_BLL sVisitor_RPT_BLL = new Visitor_RPT_BLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
              
            }
        }     

        protected void btnReport_Click(object sender, EventArgs e)
        {

            if (rdAllVisitor.Checked)
            {
                if (txtvisitfrom.Text != "" && txtvisitTo.Text != "")
                {
                    DateTime fromdate = Convert.ToDateTime(txtvisitfrom.Text);
                    DateTime todate = Convert.ToDateTime(txtvisitTo.Text);
                    List<Visitor_Details> visitorList = sVisitor_RPT_BLL.GetAllVisitorRptByDate(fromdate, todate);
                    if (visitorList.Count > 0)
                    {
                        ReportViewer.LocalReport.DataSources.Clear();
                        ReportDataSource reportDataset = new ReportDataSource("VisitorInformation", visitorList);
                        ReportViewer.LocalReport.DataSources.Add(reportDataset);
                        ReportViewer.LocalReport.ReportPath = Server.MapPath("/Visitor/Reports/AllVisitors.rdlc");
                        ReportViewer.LocalReport.Refresh();
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No data found!')", true);
                    }
                }
                else
                {
                    string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                    List<Visitor_Details> allVisitor = sVisitor_RPT_BLL.GetAllVisitorRpt(OCODE);
                    if (allVisitor.Count > 0)
                    {                                      
                        ReportViewer.LocalReport.DataSources.Clear();
                        ReportDataSource reportDataset = new ReportDataSource("VisitorInformation", allVisitor);
                        ReportViewer.LocalReport.DataSources.Add(reportDataset);
                        ReportViewer.LocalReport.ReportPath = Server.MapPath("/Visitor/Reports/AllVisitors.rdlc");
                        ReportViewer.LocalReport.Refresh();
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No data found!')", true);
                    }
                }
              
            }          
          
        }   

    }
}
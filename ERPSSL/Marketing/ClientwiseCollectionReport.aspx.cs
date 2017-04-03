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
    public partial class ClientwiseCollectionReport : System.Web.UI.Page
    {
        public ClientWiseCollectionBLL aClientWiseCollectionBLL = new ClientWiseCollectionBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if ((Session["UserID"] != null) && (Session["OCode"] != null))
                {
                    LoadClientInDropDownList();
                }
                else
                {
                    Response.Redirect("..\\AppGateway\\Login.aspx");
                }
            }
        }

        public void LoadClientInDropDownList()
        {
            try
            {
                string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                List<string> allClientList= new List<string>();
                string clientName = clientNameDropDownList.Text;
                allClientList = aClientWiseCollectionBLL.Get_ClientWiseList(OCODE);

                if (allClientList.Count > 0)
                {
                    clientNameDropDownList.DataSource = allClientList;
                    //clientNameDropDownList.DataTextField = "Client";
                    //clientNameDropDownList.DataValueField = "Client";
                    clientNameDropDownList.DataBind();
                    clientNameDropDownList.Items.Insert(0, new ListItem("--Select--", "0"));
                }
            }
            catch (Exception ex)
            {
                string EID = Convert.ToString(((SessionUser)Session["SessionUser"]).EID);
                //LogController<employeeSetup>.SetLog(ex, EID);
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            } 
        }

        protected void btnProcess_Click(object sender, EventArgs e)
        {
            string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
            string clientName = clientNameDropDownList.Text;

            var reportResult = aClientWiseCollectionBLL.GetClientWiseTransaction(OCODE, clientName);

            if (reportResult.Count > 0)
            {
                clientwiseTransactioonReportViewer.LocalReport.DataSources.Clear();

                ReportDataSource reportDataset = new ReportDataSource("DataSet1", reportResult);
                clientwiseTransactioonReportViewer.LocalReport.DataSources.Add(reportDataset);
                clientwiseTransactioonReportViewer.LocalReport.ReportPath = Server.MapPath("Reports/ReportCollectionByClient.rdlc");
                clientwiseTransactioonReportViewer.LocalReport.Refresh();

            }
        }

    }
}
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
    public partial class TaskDetailsReport : System.Web.UI.Page
    {
        TaskDetailsBLL aTaskDetailsBLL = new TaskDetailsBLL();
        ClientWiseCollectionBLL aClientWiseCollectionBLL = new ClientWiseCollectionBLL();
 
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

            if (clientNameRadioButton.Checked == true)
            {
                string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                string clientName = clientDropDownList.Text;
                var reportResult = aTaskDetailsBLL.GetIndividualInformationOfTask(OCODE, clientName);

                if (reportResult != null)
                {
                    taskDetailsReportViewer.LocalReport.DataSources.Clear();

                    ReportDataSource reportDataset = new ReportDataSource("DataSet1", reportResult);
                    taskDetailsReportViewer.LocalReport.DataSources.Add(reportDataset);
                    taskDetailsReportViewer.LocalReport.ReportPath = Server.MapPath("Reports/ReportIndividualTaskDetails.rdlc");
                    taskDetailsReportViewer.LocalReport.Refresh();

                }
            }
            else
            {
                string OCODE = ((SessionUser)Session["SessionUser"]).OCode;

                var reportResult = aTaskDetailsBLL.GetAllInformationOfTask(OCODE);

                if (reportResult.Count > 0)
                {
                    taskDetailsReportViewer.LocalReport.DataSources.Clear();

                    ReportDataSource reportDataset = new ReportDataSource("DataSet1", reportResult);
                    taskDetailsReportViewer.LocalReport.DataSources.Add(reportDataset);
                    taskDetailsReportViewer.LocalReport.ReportPath = Server.MapPath("Reports/ReportAllTaskDetails.rdlc");
                    taskDetailsReportViewer.LocalReport.Refresh();

                }
            }

        }

        protected void clientNameRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            LoadClientInDropDownList();
        }

        public void LoadClientInDropDownList()
        {
            try
            {
                string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                List<string> allClientList = new List<string>();
                //string clientName = clientNameDropDownList.Text;
                allClientList = aClientWiseCollectionBLL.Get_ClientWiseList(OCODE);

                if (allClientList.Count > 0)
                {
                    clientDropDownList.DataSource = allClientList;
                    clientDropDownList.DataBind();
                    clientDropDownList.Items.Insert(0, new ListItem("--Select--", "0"));
                }
            }
            catch (Exception ex)
            {
                string EID = Convert.ToString(((SessionUser)Session["SessionUser"]).EID);
                //LogController<employeeSetup>.SetLog(ex, EID);
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

        protected void searchRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            clientDropDownList.Items.Clear();
        }
    }
}
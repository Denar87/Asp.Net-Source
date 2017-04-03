using ERPSSL.Marketing.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ERPSSL.Marketing.BLL;
using ERPSSL.Marketing.DAL;
using Microsoft.Reporting.WebForms;
using ERPSSL.Marketing.DAL.Repository;



namespace ERPSSL.Marketing
{
    public partial class ClientVisitReport : System.Web.UI.Page
    {
        ClientVisitReportBLL aClientVisitReportBLL = new ClientVisitReportBLL();
        StageBLL aStageBLL = new StageBLL();
        MarketingInfoBLL aMarketingInfoBLL = new MarketingInfoBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if ((Session["UserID"] != null) && (Session["OCode"] != null))
                {
                    lblMarketingPersonOrStage.Visible = false;
                    mpsDropDownList.Visible = false;
                }
                else
                {
                    Response.Redirect("..\\AppGateway\\Login.aspx");
                }
            }
        }

        protected void stageRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            lblMarketingPersonOrStage.Visible = true;
            mpsDropDownList.Visible = true;
            mpsDropDownList.Items.Clear();

            try
            {
                string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                List<MRK_Stage> MRK_StageList = new List<MRK_Stage>();

                MRK_StageList = aStageBLL.GetAllStagesList(OCODE);

                

                if (MRK_StageList.Count > 0)
                {
                    mpsDropDownList.DataSource = MRK_StageList;
                    mpsDropDownList.DataTextField = "StageName";
                    mpsDropDownList.DataValueField = "StageId";
                    mpsDropDownList.DataBind();
                    mpsDropDownList.Items.Insert(0, new ListItem("--Select--", "0"));
                }
            }
            catch (Exception ex)
            {
                string EID = Convert.ToString(((SessionUser)Session["SessionUser"]).EID);
                //LogController<employeeSetup>.SetLog(ex, EID);
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

        protected void MarketingPersonRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            mpsDropDownList.Visible = true;
            lblMarketingPersonOrStage.Visible = true;
            mpsDropDownList.Items.Clear();

            try
            {
                string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                List<MarketingProjectStage> aMarketingProjectStage = new List<MarketingProjectStage>();

                aMarketingProjectStage = aMarketingInfoBLL.Get_AllPersonList(OCODE);

                if (aMarketingProjectStage.Count > 0)
                {
                    mpsDropDownList.DataSource = aMarketingProjectStage;
                    mpsDropDownList.DataTextField = "MArketingPersonName";
                    mpsDropDownList.DataValueField = "MarketingPersonId";
                    mpsDropDownList.DataBind();
                    mpsDropDownList.Items.Insert(0, new ListItem("--Select--", "0"));
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
            DateTime FromDate = Convert.ToDateTime(txtFromDate.Text);
            DateTime ToDate = Convert.ToDateTime(txtToDate.Text);
            
            if(clientRadioButton.Checked == true)
            {
                var reportResult = aClientVisitReportBLL.GetAllInformationOfClientVisit(OCODE, FromDate, ToDate);

                if (reportResult.Count > 0)
                {
                    ClientVisitReportViewer.LocalReport.DataSources.Clear();

                    ReportDataSource reportDataset = new ReportDataSource("DataSet1", reportResult);
                    ClientVisitReportViewer.LocalReport.DataSources.Add(reportDataset);
                    ClientVisitReportViewer.LocalReport.ReportPath = Server.MapPath("Reports/ReportClientVisit.rdlc");
                    ClientVisitReportViewer.LocalReport.Refresh();

                }
            }
            else if (MarketingPersonRadioButton.Checked == true)
            {
                string marketingPersonId = mpsDropDownList.SelectedValue.ToString();
                var reportResult = aClientVisitReportBLL.GetAllInformationOfClientVisitbyDateAndMarketingPerson(OCODE, FromDate, ToDate, marketingPersonId);

                if (reportResult.Count > 0)
                {
                    ClientVisitReportViewer.LocalReport.DataSources.Clear();

                    ReportDataSource reportDataset = new ReportDataSource("DataSet1", reportResult);
                    ClientVisitReportViewer.LocalReport.DataSources.Add(reportDataset);
                    ClientVisitReportViewer.LocalReport.ReportPath = Server.MapPath("Reports/ReportClientVisit.rdlc");
                    ClientVisitReportViewer.LocalReport.Refresh();

                }
            }
            else if (stageRadioButton.Checked == true)
            {
                int stageId = Convert.ToInt32(mpsDropDownList.SelectedValue.ToString());
                var reportResult = aClientVisitReportBLL.GetAllInformationOfClientVisitbyDateAndStage(OCODE, FromDate, ToDate, stageId);

                if (reportResult.Count > 0)
                {
                    ClientVisitReportViewer.LocalReport.DataSources.Clear();

                    ReportDataSource reportDataset = new ReportDataSource("DataSet1", reportResult);
                    ClientVisitReportViewer.LocalReport.DataSources.Add(reportDataset);
                    ClientVisitReportViewer.LocalReport.ReportPath = Server.MapPath("Reports/ReportClientVisit.rdlc");
                    ClientVisitReportViewer.LocalReport.Refresh();

                }
            }
            
        }

        protected void clientRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            mpsDropDownList.Visible = false;
            lblMarketingPersonOrStage.Visible = false;
        }
    }
}
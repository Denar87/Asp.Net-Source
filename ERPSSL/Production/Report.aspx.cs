using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ERPSSL.Production.BLL;
using ERPSSL.Production.DAL.Repository;


namespace ERPSSL.Production
{
    public partial class Report : System.Web.UI.Page
    {

        PlanningBLL _PlanningBLL = new PlanningBLL();
        ReportBLL _reportbll = new ReportBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Session["UserID"] != null) && (Session["OCode"] != null))
            {
                if (!IsPostBack)
                {

                    //  GetDept();
                }
            }
            else
            {
                Response.Redirect("..\\AppGateway\\Login.aspx");
            }
        }
        protected void btnProcess_Click(object sender, EventArgs e)
        {
            if (rdDailyfactoryProduction.Checked)
            {
                var result = _PlanningBLL.GetDailyProductionStatus();
                if (result.Count > 0)
                {
                    Session["rptDs"] = "DataSet1";
                    Session["rptDt"] = result;
                    Session["rptFile"] = "/Production/Reports/RPT_Prod_DailyProductionReport.rdlc";
                    Session["rptTitle"] = "RPT_Prod_DailyProductionReport";
                    Response.Redirect("Report_Viewer.aspx");
                }
            }
            else if (rdbDailyProductionDetails.Checked)
            {
                string OCode = Convert.ToString(((SessionUser)Session["SessionUser"]).OCode);

                List<ReportR> _rptDPDetails = new List<ReportR>();
                _rptDPDetails = _reportbll.GetDailyProductionDetails(OCode);
                if (_rptDPDetails.Count > 0)
                {
                    Session["rptDs"] = "DS_Rpt_Production";
                    Session["rptDt"] = _rptDPDetails;
                    Session["rptFile"] = "/Production/Reports/RPT_Prod_DailyProductionDetails.rdlc";
                    Session["rptTitle"] = "Daily Production Details";
                    Response.Redirect("Report_Viewer.aspx");
                }
            }
            else if (rdbTna.Checked)
            {
                string OCode = Convert.ToString(((SessionUser)Session["SessionUser"]).OCode);

                List<ProductionR> _rptTna = new List<ProductionR>();
                _rptTna = _reportbll.GetTnaReport(OCode);
                if (_rptTna.Count > 0)
                {
                    Session["rptDs"] = "DS_Rpt_Production";
                    Session["rptDt"] = _rptTna;
                    Session["rptFile"] = "/Production/Reports/RPT_Prod_TNAReport.rdlc";
                    Session["rptTitle"] = "Daily Production Details";
                    Response.Redirect("Report_Viewer.aspx");
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Please Select Report Item')", true);
            }
        }
    }
}


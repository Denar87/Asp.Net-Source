using ERPSSL.LC.BLL;
using ERPSSL.LC.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ERPSSL.LC
{
    public partial class LC_Report : System.Web.UI.Page
    {
        ReportBLL _ReportBLL = new ReportBLL();

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
            try
            {
                string OCode = ((SessionUser)Session["SessionUser"]).OCode;
                List<ReportLC> _Result = new List<ReportLC>();
               
                if (txtFrom.Text != "" && txtTo.Text != "")
                {
                    DateTime FromDate = Convert.ToDateTime(txtFrom.Text);
                    DateTime Todate = Convert.ToDateTime(txtTo.Text);
                    if (rdbLCOpenReport.Checked)
                    {
                        _Result = _ReportBLL.GetLCOpenReportByDate(FromDate, Todate, OCode);
                        if (_Result.Count > 0)
                        {
                            Session["rptDs"] = "LC_DS";
                            Session["rptDt"] = _Result;
                            Session["rptFile"] = "/LC/Reports/LC_RPT_AllOpenLCReport.rdlc";
                            Session["rptTitle"] = "LC Report";
                            Response.Redirect("ReportViewer.aspx");
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No Data Found!')", true);
                        }
                    }
                    else if (rdbContractLC.Checked)
                    {
                        _Result = _ReportBLL.GetContractReportByDate(FromDate, Todate, OCode);
                        if (_Result.Count > 0)
                        {
                            Session["rptDs"] = "LC_DS";
                            Session["rptDt"] = _Result;
                            Session["rptFile"] = "/LC/Reports/LC_RPT_ContractLCReportByDate.rdlc";
                            Session["rptTitle"] = "LC Report";
                            Response.Redirect("ReportViewer.aspx");
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No Data Found!')", true);
                        }
                    }
                    else if (rdbAmend.Checked)
                    {
                        _Result = _ReportBLL.GetLCAmendReportByDate(FromDate, Todate, OCode);
                        if (_Result.Count > 0)
                        {
                            Session["rptDs"] = "LC_DS";
                            Session["rptDt"] = _Result;
                            Session["rptFile"] = "/LC/Reports/LC_RPT_AmendLCReportByDate.rdlc";
                            Session["rptTitle"] = "LC Report";
                            Response.Redirect("ReportViewer.aspx");
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No Data Found!')", true);
                        }
                    }

                }
                else if (rdbOrderDetailsReport.Checked)
                {
                    _Result = _ReportBLL.GetLCOrderDetailsReport(OCode);
                    if (_Result.Count > 0)
                    {
                        Session["rptDs"] = "LC_DS";
                        Session["rptDt"] = _Result;
                        Session["rptFile"] = "/LC/Reports/LC_RPT_OrderDetailsReport.rdlc";
                        Session["rptTitle"] = "LC Order Details Report";
                        Response.Redirect("ReportViewer.aspx");
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No Data Found!')", true);
                    }
                }
                else if (rdbStyle.Checked)
                {
                    _Result = _ReportBLL.GetLCStyleReport(OCode);
                    if (_Result.Count > 0)
                    {
                        Session["rptDs"] = "LC_DS";
                        Session["rptDt"] = _Result;
                        Session["rptFile"] = "/LC/Reports/LC_RPT_LCStyleReport.rdlc";
                        Session["rptTitle"] = "LC Order Details Report";
                        Response.Redirect("ReportViewer.aspx");
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No Data Found!')", true);
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Input Date!!')", true);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}


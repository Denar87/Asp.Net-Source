using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Financial_MgtSystem_BLL;
using System.Collections;
using System.Data;
using System.Drawing;
using Financial_MgtSystem_BOL;
using Financial_MgtSystem_BLL.CommonUtilities;
using System.Text;

namespace ERPSSL.Accounting.UI_Reporting
{
    public partial class LedgerBookDetails : System.Web.UI.Page
    {
        ac_Chart_BLL objChart_DAL = new ac_Chart_BLL();
        rpt_LedgerBookDetails_BLL objLed_BLL = new rpt_LedgerBookDetails_BLL();
        cmp_CompanysUser_BLL objUser = new cmp_CompanysUser_BLL();
        Common_BLL objCommon = new Common_BLL();

        String[] GetPermission = new String[4];
        string RoleID, PageID, Edit_User, CompanyCode, OCode;
        string dateFrom, dateTo, GetType;
        StringBuilder str = new StringBuilder();
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Session["CompanyCode"] != null) && (Session["OCode"] != null) && (Session["LedgerCode"] != null))
            {
                dateFrom = String.Format("{0:MM/dd/yyyy}", DateTime.Now);
                dateTo = String.Format("{0:MM/dd/yyyy}", DateTime.Now);
                GetType = "A";
                //-------------------------------------------------
                RoleID = Session["RoleID"].ToString();
                PageID = "12";
                Edit_User = Session["UserID"].ToString();
                CompanyCode = Session["CompanyCode"].ToString();
                OCode = Session["OCode"].ToString();

                 //GetPermission = objCommon.Permission(RoleID, PageID, OCode);
                //[0]CanVisit//[1]CanEdit//[2]CanDelete//[3]CanExecute
                //if (GetPermission[0].ToString() == "True")
                //{
                //    this.dtpLedgerCode.Text = Session["LedgerCode"].ToString();
                //    this.lblLedgerName.Text = Session["LedgerName"].ToString();
                if (!IsPostBack)
                {
                    GetLedgerDetails(dateFrom, dateTo, GetType);
                    BindChart(dateFrom, dateTo, GetType);
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

        private void GetLedgerDetails(string dateFrom, string dateTo, string GetType)
        {
            //if (GetPermission[3].ToString() == "True")
            //{
            Hashtable ht = new Hashtable();
            ht.Add("GetType", GetType);
            ht.Add("DateFrom", dateFrom);
            ht.Add("DateTo", dateTo);
            ht.Add("Ledger_Code", Session["LedgerCode"]);
            ht.Add("Company_Code", Session["CompanyCode"]);
            ht.Add("OCode", Session["OCode"]);

            DataTable dt = objLed_BLL.GetLedgerDetails(ht);
            if (dt.Rows.Count > 0)
            {
                dtg_list.DataSource = dt;
                dtg_list.DataBind();
            }
            //}
            //else
            //{
            //    ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "User Permission", "alert('You don't have permission to access this page!!)');", true);
            //    HttpContext.Current.Response.Redirect("..\\UI_Utilities\\DeniedPage.aspx");
            //}
        }

        protected void btnSearch_Click(object sender, ImageClickEventArgs e)
        {
            //if (GetPermission[3].ToString() == "True")
            //{
            if (Convert.ToDateTime(dateFrom) <= Convert.ToDateTime(dateTo))
            {
                if (rdbViewAll.Checked)
                {
                    dateFrom = String.Format("{0:MM/dd/yyyy}", DateTime.Now);
                    dateTo = String.Format("{0:MM/dd/yyyy}", DateTime.Now);
                    GetType = "A";
                }
                else
                {
                    dateFrom = String.Format("{0:MM/dd/yyyy}", dtpFrom.Text);
                    dateTo = String.Format("{0:MM/dd/yyyy}", dtpTo.Text);
                    GetType = "P";
                }

                GetLedgerDetails(dateFrom, dateTo, GetType);
                BindChart(dateFrom, dateTo, GetType);
            }
            else
            {
                this.lblMessage.Text = "To Date should be greater than From Date.";
                this.lblMessage.ForeColor = Color.White;
                messagePanel.BackColor = Color.Red;
            }
            //}
            //else
            //{
            //    ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "User Permission", "alert('You don't have permission to access this page!!)');", true);
            //    HttpContext.Current.Response.Redirect("..\\UI_Utilities\\DeniedPage.aspx");
            //}
        }

        private void PrintLedgerBookDetails(string dateFrom, string dateTo, string GetType, string rptCriteria)
        {
            Hashtable ht = new Hashtable();
            ht.Add("GetType", GetType);
            ht.Add("DateFrom", dateFrom);
            ht.Add("DateTo", dateTo);
            ht.Add("Ledger_Code", Session["LedgerCode"]);
            ht.Add("Company_Code", Session["CompanyCode"]);
            ht.Add("OCode", Session["OCode"]);

            DataTable dt = objLed_BLL.Rpt_GetLedgerDetails(ht);
            if (dt.Rows.Count != 0)
            {
                Session["ReportTitle"] = "Ledger Details-" + Session["LedgerCode"].ToString();
                Session["ReportCriteria"] = rptCriteria;
                Session["OrganizationDetails"] = GlobalClass_BOL.Company_Name;
                Session["OrganizationAddress"] = GlobalClass_BOL.Street_1;
                Session["OrganizationContact"] = GlobalClass_BOL.Phone;
                Session["DatePrint"] = String.Format("{0:MMMM dd, yyyy}", DateTime.Now.Date);

                Session["rptDs"] = "ds_LedgerBookDetails";
                Session["rptDt"] = dt;
                Session["rptFile"] = "..\\UI_ReportsFile\\LedgerBookDetails.rdlc";
                //Response.Redirect("..\\UI_Reporting\\ReportViewer.aspx");
                if (!Request.IsAuthenticated)
                {
                    Response.Redirect("..\\UI_Reporting\\ReportViewer.aspx?ReturnURL=" + HttpUtility.UrlEncode(HttpContext.Current.Request.Url.AbsoluteUri)); // dont forget to use urlencode
                }
            }
            else
            {
                ht.Clear();
                this.lblMessage.Text = "Nothing Found!!";
                messagePanel.BackColor = Color.Red;
                this.lblMessage.ForeColor = Color.White;
            }
        }

        protected void btnPrint_Click(object sender, ImageClickEventArgs e)
        {
            //if (GetPermission[3].ToString() == "True")
            //{
            string rptCriteria = string.Empty;
            if (Convert.ToDateTime(dateFrom) <= Convert.ToDateTime(dateTo))
            {
                if (rdbViewAll.Checked)
                {
                    dateFrom = String.Format("{0:MM/dd/yyyy}", DateTime.Now);
                    dateTo = String.Format("{0:MM/dd/yyyy}", DateTime.Now);
                    GetType = "A";
                    rptCriteria = "All Records.";
                }
                else
                {
                    dateFrom = String.Format("{0:MM/dd/yyyy}", dtpFrom.Text);
                    dateTo = String.Format("{0:MM/dd/yyyy}", dtpTo.Text);
                    GetType = "p";
                    rptCriteria = "All Records of " + dateFrom + " to " + dateTo;
                }

                PrintLedgerBookDetails(dateFrom, dateTo, GetType, rptCriteria);
            }
            else
            {
                this.lblMessage.Text = "To Date should be greater than From Date.";
                this.lblMessage.ForeColor = Color.White;
                messagePanel.BackColor = Color.Red;
            }
            //}
            //else
            //{
            //    ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "User Permission", "alert('You don't have permission to access this page!!)');", true);
            //    HttpContext.Current.Response.Redirect("..\\UI_Utilities\\DeniedPage.aspx");
            //}
        }

        protected void rdbViewdtod_CheckedChanged(object sender, EventArgs e)
        {
            dtpFrom.Text = String.Format("{0:MM/dd/yyyy}", DateTime.Now);
            dtpTo.Text = String.Format("{0:MM/dd/yyyy}", DateTime.Now);
        }

        private void BindChart(string dateFrom_, string dateTo_, string GetType_)
        {
            try
            {
                Hashtable ht = new Hashtable();

                ht.Add("GetType", GetType_);
                ht.Add("DateFrom", dateFrom_);
                ht.Add("DateTo", dateTo_);
                ht.Add("Ledger_Code", Session["LedgerCode"]);
                ht.Add("Company_Code", Session["CompanyCode"]);
                ht.Add("OCode", Session["OCode"]);
                DataTable dt;
                dt = null;
                dt = objChart_DAL.GetLedgerChart(ht);
                if (dt.Rows.Count > 0)
                {
                    str.Append(@"<script type=text/javascript> google.load( 'visualization', '1', {packages:['columnchart']});
                       google.setOnLoadCallback(drawChart);
                       function drawChart()
                       {
                        var data = new google.visualization.DataTable();
                        data.addColumn('string', 'Year-Month');
                        data.addColumn('number', 'Dr.');
                        data.addColumn('number', 'Cr.');       
                        data.addRows(" + dt.Rows.Count + ");");
                    for (int i = 0; i <= dt.Rows.Count - 1; i++)
                    {
                        str.Append("data.setValue( " + i + "," + 0 + "," + "'" + dt.Rows[i]["TrDate"].ToString() + "');");
                        str.Append("data.setValue(" + i + "," + 1 + "," + dt.Rows[i]["TotalDr"].ToString() + ") ;");
                        str.Append("data.setValue(" + i + "," + 2 + "," + dt.Rows[i]["TotalCr"].ToString() + ") ;");
                    }

                    str.Append(@" var options = { 
                                  legend: { position: 'top' }, 
                                  height: 250,
                                  width: 980,
                                  isStacked: true,is3D: true,
                                  vAxis: {title: 'Total', titleTextStyle: {color: 'green'},fontName: 'Candara'},
                                  hAxis: {title: '',titleTextStyle: {color: 'green',fontName: 'Candara'},minValue: 0, maxValue: 50},

                                  colors:['Purple', 'Orange'],
                                  animation: {duration: 1000,easing: 'out'},
                                  title : 'Chart view of " + Session["LedgerName"].ToString() + "'};");

                    str.Append(" var chart = new google.visualization.ColumnChart(document.getElementById('chart_div'));");
                    str.Append(" chart.draw(data, options);");

                    str.Append(" }");
                    str.Append("</script>");
                    lt.Text = str.ToString().TrimEnd(',').Replace('*', '"');
                }
            }
            catch (Exception)
            {
            }
        }
    }
}
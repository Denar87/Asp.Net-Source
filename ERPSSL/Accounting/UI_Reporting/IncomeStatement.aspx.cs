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

namespace ERPSSL.Accounting.UI_Reporting
{
    public partial class IncomeStatement : System.Web.UI.Page
    {
        rpt_IncomeStatement_BLL objIs_BL = new rpt_IncomeStatement_BLL();
        cmp_CompanysUser_BLL objUser = new cmp_CompanysUser_BLL();
        Common_BLL objCommon = new Common_BLL();

        String[] GetPermission = new String[4];
        string RoleID, PageID, Edit_User, CompanyCode, OCode;
        string dateFrom, dateTo, GetType;

        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Session["CompanyCode"] != null) && (Session["OCode"] != null))
            {
                dateFrom = String.Format("{0:MM/dd/yyyy}", DateTime.Now);
                dateTo = String.Format("{0:MM/dd/yyyy}", DateTime.Now);
                GetType = "A";
                //-----------------------------------------------------
                RoleID = Session["RoleID"].ToString();
                PageID = "10";
                Edit_User = Session["UserID"].ToString();
                CompanyCode = Session["CompanyCode"].ToString();
                OCode = Session["OCode"].ToString();

                 //GetPermission = objCommon.Permission(RoleID, PageID, OCode);
                //[0]CanVisit//[1]CanEdit//[2]CanDelete//[3]CanExecute
                //if (GetPermission[0].ToString() == "True")
                //{
                if (!IsPostBack)
                {
                    GetIncomeStatement(dateFrom, dateTo, GetType);
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
                HttpContext.Current.Response.Redirect("..\\..\\Default.aspx");
            }
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
                    GetType = "p";
                }

                GetIncomeStatement(dateFrom, dateTo, GetType);
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

        private void GetIncomeStatement(string dateFrom, string dateTo, string GetType)
        {
            Hashtable ht = new Hashtable();
            ht.Add("GetType", GetType);
            ht.Add("DateFrom", dateFrom);
            ht.Add("DateTo", dateTo);
            ht.Add("Company_Code", Session["CompanyCode"]);
            ht.Add("OCode", Session["OCode"]);

            DataTable dt = objIs_BL.Get_AC_IncomeStatement(ht);
            if (dt.Rows.Count > 0)
            {
                dtg_list.DataSource = dt;
                dtg_list.DataBind();
            }
        }

        protected void dtg_list_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string CellFormat = e.Row.Cells[0].Text;
                decimal TotalIncome, TotalExpense, TotalEarning;

                if (CellFormat == "Total Income")
                {
                    e.Row.BackColor = System.Drawing.Color.Purple;
                    e.Row.ForeColor = System.Drawing.Color.White;
                    e.Row.Font.Bold = true;
                    TotalIncome = Convert.ToDecimal(e.Row.Cells[1].Text.ToString());
                    lblTotalIncome.Text = "Income: " + string.Format("{0:0.00}", TotalIncome);
                    lblTotalIncome.ForeColor = Color.Green;
                }
                if (CellFormat == "Total Expense")
                {
                    e.Row.BackColor = System.Drawing.Color.Purple;
                    e.Row.ForeColor = System.Drawing.Color.White;
                    e.Row.Font.Bold = true;
                    TotalExpense = Convert.ToDecimal(e.Row.Cells[1].Text.ToString());
                    lblTotalExpense.Text = "Expense: " + string.Format("{0:0.00}", TotalExpense);
                    lblTotalExpense.ForeColor = Color.Red;
                }
                if (CellFormat == "Total Earning")
                {
                    e.Row.BackColor = System.Drawing.Color.Purple;
                    e.Row.ForeColor = System.Drawing.Color.White;
                    e.Row.Font.Bold = true;
                    this.lblProfit.Text = e.Row.Cells[1].Text.ToString();
                    TotalEarning = Convert.ToDecimal(e.Row.Cells[1].Text.ToString());
                    lblProfit.Text = "Earning: " + string.Format("{0:0.00}", TotalEarning);
                    if (TotalEarning > 0) { lblProfit.ForeColor = Color.Green; }
                    else { lblProfit.ForeColor = Color.OrangeRed; }
                }
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

                PrintIncomeStatement(dateFrom, dateTo, GetType, rptCriteria);
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

        private void PrintIncomeStatement(string dateFrom, string dateTo, string GetType, string rptCriteria)
        {
            Hashtable ht = new Hashtable();
            ht.Add("GetType", GetType);
            ht.Add("DateFrom", dateFrom);
            ht.Add("DateTo", dateTo);
            ht.Add("Company_Code", Session["CompanyCode"]);
            ht.Add("OCode", Session["OCode"]);

            DataTable dt = objIs_BL.Rpt_Get_AC_IncomeStatement(ht);
            if (dt.Rows.Count != 0)
            {
                Session["ReportTitle"] = "Income Statement";
                Session["ReportCriteria"] = rptCriteria;
                Session["OrganizationDetails"] = GlobalClass_BOL.Company_Name;
                Session["OrganizationAddress"] = GlobalClass_BOL.Street_1;
                Session["OrganizationContact"] = GlobalClass_BOL.Phone;
                Session["DatePrint"] = String.Format("{0:MMMM dd, yyyy}", DateTime.Now.Date);

                Session["rptDs"] = "ds_IncomeStatement";
                Session["rptDt"] = dt;
                Session["rptFile"] = "..\\UI_ReportsFile\\IncomeStatement.rdlc";
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

        protected void rdbViewdtod_CheckedChanged(object sender, EventArgs e)
        {
            dtpFrom.Text = String.Format("{0:MM/dd/yyyy}", DateTime.Now);
            dtpTo.Text = String.Format("{0:MM/dd/yyyy}", DateTime.Now);
        }

    }
}
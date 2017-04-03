using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Financial_MgtSystem_BOL;
using Financial_MgtSystem_BLL;
using System.Collections;
using System.Data;
using System.Globalization;
using System.Drawing;
using Financial_MgtSystem_BLL.CommonUtilities;
using System.Text;

namespace ERPSSL.Accounting.UI_Gateway
{
    public partial class Index : System.Web.UI.Page
    {
        ac_Chart_BLL objChart_DAL = new ac_Chart_BLL();
        cmp_CompanyProject_BLL objCm_BL = new cmp_CompanyProject_BLL();
        cmp_CompanysUser_BLL objUser = new cmp_CompanysUser_BLL();
        Common_BLL objCommon = new Common_BLL();

        Hashtable ht = new Hashtable();
        string RoleID, PageID, CompanyCode, OCode;
        StringBuilder str = new StringBuilder();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserID"] == null)
            {
                Response.Redirect("..\\..\\Default.aspx");
            }
            else
            {
                if (Session["CompanyCode"] == null)
                {
                    Response.Redirect("..\\UI_Gateway\\CompanyList.aspx");
                }
                else
                {
                    lblUser.Text = Convert.ToString(Session["UserFullName"]);
                    RoleID = Session["RoleID"].ToString();
                    PageID = "1";
                    OCode = Session["OCode"].ToString();

                    String[] GetPermission = new String[4];
                     //GetPermission = objCommon.Permission(RoleID, PageID, OCode);
                    //[0]CanVisit//[1]CanEdit//[2]CanDelete//[3]CanExecute
                    //if (GetPermission[0].ToString() == "True")
                    //{
                    if (!IsPostBack)
                    {
                        GetCompanyDetails();
                        BindChart_();
                    }
                    //}
                    //else
                    //{

                    //    ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "User Permission", "alert('You don't have permission to access this page!!)');", true);
                    //    HttpContext.Current.Response.Redirect("..\\UI_Utilities\\DeniedPage.aspx");
                    //}
                }
            }
        }
        private void BindChart_()
        {
            try
            {
                Hashtable ht = new Hashtable();

                ht.Add("ChartType", "Monthly");
                ht.Add("Company_Code", Session["CompanyCode"]);
                ht.Add("OCode", Session["OCode"]);

                DataTable dt = objChart_DAL.GetProfitChart(ht);
                if (dt.Rows.Count > 0)
                {
                    str.Append(@"<script type=text/javascript> google.load( 'visualization', '1.1', {packages:['corechart']});
                       google.setOnLoadCallback(drawChart);
                       function drawChart()
                       {

                        var data = new google.visualization.DataTable();
                        data.addColumn('string', 'Year-Month');
                        data.addColumn('number', 'Income');
                        data.addColumn('number', 'Expense');       
                        data.addRows(" + dt.Rows.Count + ");");
                    for (int i = 0; i <= dt.Rows.Count - 1; i++)
                    {
                        str.Append("data.setValue( " + i + "," + 0 + "," + "'" + dt.Rows[i]["Year"].ToString() + "');");
                        str.Append("data.setValue(" + i + "," + 1 + "," + dt.Rows[i]["TotalIncome"].ToString() + ") ;");
                        str.Append("data.setValue(" + i + "," + 2 + "," + dt.Rows[i]["TotalExpense"].ToString() + ") ;");
                    }

                    str.Append(" var options = {curveType: 'function',pointSize: 20,legend: { position: 'bottom' },width: 950, height: 250, title: 'Income Statement of " + Session["Company_Name"].ToString() + "',subtitle: 'Income, Expense, and Profit',vAxis: {title: 'Amount', titleTextStyle: {color: 'green'}},hAxis: {title: 'Year', titleTextStyle: {color: 'green'}}};");
                    str.Append(" var chart = new google.visualization.LineChart(document.getElementById('chart_div'));");
                    str.Append(" chart.draw(data, options);");

                    str.Append(" }");
                    str.Append("</script>");
                    lt.Text = str.ToString().TrimEnd(',').Replace('*', '"');
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.Message.ToString();
                messagePanel.BackColor = Color.Red;
                this.lblMessage.ForeColor = Color.White;
            }
        }
        private void BindChart()
        {
            try
            {
                Hashtable ht = new Hashtable();

                ht.Add("ChartType", "Monthly");
                ht.Add("Company_Code", Session["CompanyCode"]);
                ht.Add("OCode", Session["OCode"]);

                DataTable dt = objChart_DAL.GetProfitChart(ht);
                if (dt.Rows.Count > 0)
                {
                    str.Append(@"<script type=text/javascript> google.load( 'visualization', '1.1', {packages:['bar']});
                       google.setOnLoadCallback(drawChart);
                       function drawChart()
                       {

                         var data = new google.visualization.DataTable();
                        data.addColumn('string', 'Year-Month');
                        data.addColumn('number', 'Income');
                        data.addColumn('number', 'Expense');       
                        data.addRows(" + dt.Rows.Count + ");");
                    for (int i = 0; i <= dt.Rows.Count - 1; i++)
                    {
                        str.Append("data.setValue( " + i + "," + 0 + "," + "'" + dt.Rows[i]["Year"].ToString() + "');");
                        str.Append("data.setValue(" + i + "," + 1 + "," + dt.Rows[i]["TotalIncome"].ToString() + ") ;");
                        str.Append("data.setValue(" + i + "," + 2 + "," + dt.Rows[i]["TotalExpense"].ToString() + ") ;");
                    }

                    str.Append(" var options = {" +
                      "width: 1000," +
                      "chart: {" +
                      "  title : 'Overview of " + Session["Company_Name"].ToString() + "'," +
                      "  subtitle: 'Income, Expense, and Profit'" +
                      "}," +
                      "series: {" +
                      "  0: { axis: 'Particulars' }, " +
                      "  1: { axis: 'Total' }" +
                      "}," +
                      "axes: {" +
                      "  y: {" +
                      "    distance: {label: 'Particulars'}," +
                      "    brightness: {side: 'right', label: 'Total'} " +
                       " }" +
                     " }" +
                    "};");

                    str.Append(" var chart = new google.charts.Bar(document.getElementById('chart_div'));");
                    str.Append(" chart.draw(data, options);");

                    //str.Append(" var options = { legend: { position: 'bottom' }, height: 350,title : 'Yearly Budget Chart of " + Session["Company_Name"].ToString() + "',subtitle: 'BudgetTotal, Actual, and Varience',vAxis: {title: 'Particulars', titleTextStyle: {color: 'green'}},isStacked: true,hAxis: {title: 'Amount',titleTextStyle: {color: 'green'},minValue: 0, maxValue: 50},curveType: 'function',pointSize: 20, };");
                    //str.Append(" var chart = new google.visualization.BarChart(document.getElementById('chart_div'));");
                    //str.Append(" chart.draw(data, options);");

                    str.Append(" }");
                    str.Append("</script>");
                    lt.Text = str.ToString().TrimEnd(',').Replace('*', '"');
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.Message.ToString();
                messagePanel.BackColor = Color.Red;
                this.lblMessage.ForeColor = Color.White;
            }
        }
        private void GetCompanyDetails()
        {
            try
            {
                Hashtable ht = new Hashtable();
                ht.Add("CompanyCode", Session["CompanyCode"]);
                ht.Add("OCode", Session["OCode"]);

                DataTable dt = objCm_BL.CompanyProjectDetails(ht);
                if (dt.Rows.Count > 0)
                {
                    GlobalClass_BOL.Company_Name = dt.Rows[0]["Company_Name"].ToString();
                    GlobalClass_BOL.Street_1 = dt.Rows[0]["Street_1"].ToString();
                    GlobalClass_BOL.City = dt.Rows[0]["City"].ToString();
                    GlobalClass_BOL.Zip_Code = dt.Rows[0]["Zip_Code"].ToString();
                    GlobalClass_BOL.Country = dt.Rows[0]["Country"].ToString();
                    GlobalClass_BOL.Phone = dt.Rows[0]["Phone"].ToString();
                    GlobalClass_BOL.E_mail = dt.Rows[0]["E_mail"].ToString();
                    GlobalClass_BOL.Web_Site = dt.Rows[0]["Web_Site"].ToString();

                    lblFinancialYear.Text = "Financial Year:- " + String.Format("{0:MMMM dd, yyyy}", dt.Rows[0]["Financial_Year"]);
                    lblBookYear.Text = "Book Year:- " + String.Format("{0:MMMM dd, yyyy}", dt.Rows[0]["Book_Begning"]);
                    Session["FinancialYear"] = dt.Rows[0]["Financial_Year"];

                    GlobalClass_BOL.Book_Begning = dt.Rows[0]["Book_Begning"].ToString();
                    GlobalClass_BOL.Financial_Year = dt.Rows[0]["Financial_Year"].ToString();
                    GlobalClass_BOL.Currency_Name = dt.Rows[0]["Currency_Name"].ToString();
                    GlobalClass_BOL.Currency_Symbol = dt.Rows[0]["Currency_Symbol"].ToString();
                    GlobalClass_BOL.Sub_Currency = dt.Rows[0]["Sub_Currency"].ToString();
                    GlobalClass_BOL.Decimal_Place = Convert.ToInt16(dt.Rows[0]["Decimal_Place"].ToString());

                    Session["Company_Name"] = dt.Rows[0]["Company_Name"].ToString();
                    lblCompany.Text = Session["Company_Name"].ToString();
                    Session["UserID"] = new Guid(dt.Rows[0]["UserID"].ToString());
                    Session["UserFullName"] = dt.Rows[0]["UserFullName"].ToString();
                    Session["User_Level"] = dt.Rows[0]["User_Level"].ToString();
                    Session["LoginName"] = dt.Rows[0]["LoginName"].ToString();
                    Session["RoleID"] = Convert.ToInt16(dt.Rows[0]["RoleID"]);
                    Session["OCode"] = dt.Rows[0]["OCode"].ToString();
                }
                else
                {
                    ht.Clear();
                    this.lblMessage.Text = "Data retrival failed!!";
                    this.lblMessage.ForeColor = Color.White;
                    messagePanel.BackColor = Color.Red;
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.Message.ToString();
                messagePanel.BackColor = Color.Red;
                this.lblMessage.ForeColor = Color.White;
            }
        }
    }
}
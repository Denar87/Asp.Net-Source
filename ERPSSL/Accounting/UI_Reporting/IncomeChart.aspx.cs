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
using System.Web.UI.DataVisualization.Charting;
using Financial_MgtSystem_BLL.CommonUtilities;
using System.Text;

namespace ERPSSL.Accounting.UI_Reporting
{
    public partial class IncomeChart : System.Web.UI.Page
    {
        ac_Chart_BLL objChart_DAL = new ac_Chart_BLL();
        rpt_IncomeStatement_BLL objIs_BL = new rpt_IncomeStatement_BLL();
        cmp_CompanysUser_BLL objUser = new cmp_CompanysUser_BLL();
        Common_BLL objCommon = new Common_BLL();

        String[] GetPermission = new String[4];
        string RoleID, PageID, Edit_User, CompanyCode, OCode;
        string dateFrom, dateTo, GetType;
        StringBuilder str = new StringBuilder();
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Session["CompanyCode"] != null) && (Session["OCode"] != null))
            {
                GetType = "Yearly";
                if (!IsPostBack)
                {
                    BindChart();
                }
            }
            else
            {
                HttpContext.Current.Response.Redirect("..\\..\\Default.aspx");
            }
        }

        private void BindChart()
        {
            try
            {
                Hashtable ht = new Hashtable();

                ht.Add("ChartType", GetType);
                ht.Add("Company_Code", Session["CompanyCode"]);
                ht.Add("OCode", Session["OCode"]);

                DataTable dt = objChart_DAL.GetProfitChart(ht);
                if (dt.Rows.Count > 0)
                {
                    str.Append(@"<script type=text/javascript> google.load( 'visualization', '1', {packages:['columnchart']});
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

                    str.Append(@" var options = { 
                                  legend: { position: 'top' }, 
                                  height: 350,
                                  isStacked: true,is3D: true,
                                  vAxis: {title: 'Total', titleTextStyle: {color: 'green'},fontName: 'Candara'},
                                  hAxis: {title: '',titleTextStyle: {color: 'green',fontName: 'Candara'},minValue: 0, maxValue: 50},

                                  curveType: 'function',
                                  pointSize: 20, 
                                  colors:['Green', 'Orangered'],
                                  animation: {duration: 1000,easing: 'out'},
                                  title : 'Income Chart of " + Session["Company_Name"].ToString() + "'};");

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
        private void BindChart_()
        {
            try
            {
                Hashtable ht = new Hashtable();

                ht.Add("ChartType", GetType);
                ht.Add("Company_Code", Session["CompanyCode"]);
                ht.Add("OCode", Session["OCode"]);

                DataTable dt = objChart_DAL.GetProfitChart(ht);
                if (dt.Rows.Count > 0)
                {
                    str.Append(@"<script type=text/javascript> google.load( 'visualization', '1', {packages:['corechart', 'bar']});
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

                    str.Append(" var options = { legend: { position: 'bottom' }, height: 350,title : 'Income Statement of " + Session["Company_Name"].ToString() + "',vAxis: {title: 'Year-Month', titleTextStyle: {color: 'green'}},isStacked: true,hAxis: {title: 'Amount',titleTextStyle: {color: 'green'},minValue: 0, maxValue: 50},curveType: 'function',pointSize: 20, };");
                    //str.Append(" var options0 = {title : 'Company Performance',vAxis: {title: 'Amount', titleTextStyle: {color: 'green'}},hAxis: {title: 'Year-Month',titleTextStyle: {color: 'green'}},seriesType: 'bars', series: {2: {type: 'line'}}};");
                    //str.Append(" var options1 = { legend: 'none', hAxis: { minValue: 0, maxValue: 10 },curveType: 'function',pointSize: 20, };");
                    //str.Append(" var options2 = {curveType: 'function',legend: { position: 'bottom' },width: 950, height: 300, title: 'Company Performance', hAxis: {title: 'Year', titleTextStyle: {color: 'green'}}};");
                    str.Append(" var chart = new google.visualization.BarChart(document.getElementById('chart_div'));");
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

        protected void btnSearch_Click(object sender, ImageClickEventArgs e)
        { }

        protected void btnPrint_Click(object sender, ImageClickEventArgs e)
        { }
        protected void rdbViewdMonthly_CheckedChanged(object sender, EventArgs e)
        {
            GetType = "Monthly";
            BindChart();
            dtpFrom.Text = String.Format("{0:MM/dd/yyyy}", Session["FinancialYear"]);
            dtpTo.Text = String.Format("{0:MM/dd/yyyy}", DateTime.Now);
        }
        protected void rdbViewYearly_CheckedChanged(object sender, EventArgs e)
        {
            GetType = "Yearly";
            BindChart();
        }
    }
}
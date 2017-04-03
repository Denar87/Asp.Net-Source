using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using System.Data;
using Financial_MgtSystem_BLL;
using Financial_MgtSystem_BLL.CommonUtilities;
using System.Drawing;
using Financial_MgtSystem_BOL;
using System.Text;
using System.Web.Services;

namespace ERPSSL.Accounting.UI_Reporting
{
    public partial class BudgetChart : System.Web.UI.Page
    {
        leg_Budget_BLL objBud_BLL = new leg_Budget_BLL();
        rpt_Budget_BLL objBdg_BLL = new rpt_Budget_BLL();
        cmp_CompanysUser_BLL objUser = new cmp_CompanysUser_BLL();
        Common_BLL objCommon = new Common_BLL();

        String[] GetPermission = new String[4];
        string RoleID, PageID, Edit_User, CompanyCode, OCode;
        string dateFrom, GetType;
        StringBuilder str = new StringBuilder();
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Session["CompanyCode"] != null) && (Session["OCode"] != null))
            {
                dateFrom = String.Format("{0:MM/dd/yyyy}", DateTime.Now);
                GetType = "A";
                //--------------------------------------
                RoleID = Session["RoleID"].ToString();
                PageID = "33";
                Edit_User = Session["UserID"].ToString();
                CompanyCode = Session["CompanyCode"].ToString();
                OCode = Session["OCode"].ToString();

                 //GetPermission = objCommon.Permission(RoleID, PageID, OCode);
                //[0]CanVisit//[1]CanEdit//[2]CanDelete//[3]CanExecute
                //if (GetPermission[0].ToString() == "True")
                //{
                if (!IsPostBack)
                {
                    BindChart(dateFrom, GetType);
                    //BindPieChart(dateFrom, GetType);
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

        private void BindChart(string dateFrom, string GetType)
        {
            try
            {
                Hashtable ht = new Hashtable();
                ht.Add("GetType", GetType);
                ht.Add("DateFrom", dateFrom);
                ht.Add("Company_Code", Session["CompanyCode"]);
                ht.Add("OCode", Session["OCode"]);

                DataTable dt = objBud_BLL.Get_BudgetVarience(ht);
                if (dt.Rows.Count > 0)
                {
                    str.Append(@"<script type=text/javascript> google.load( 'visualization', '1', {packages:['columnchart']});
                       google.setOnLoadCallback(drawChart);
                       function drawChart()
                       {
                        var data = new google.visualization.DataTable();
                        data.addColumn('string', 'Particulars');
                        data.addColumn('number', 'BudgetTotal');
                        data.addColumn('number', 'Actual');   
                        data.addColumn('number', 'Varience'); 

                        data.addRows(" + dt.Rows.Count + ");");
                    for (int i = 0; i <= dt.Rows.Count - 1; i++)
                    {
                        str.Append("data.setValue(" + i + "," + 0 + "," + "'" + dt.Rows[i]["Ledger_Name"].ToString() + "');");
                        str.Append("data.setValue(" + i + "," + 1 + "," + dt.Rows[i]["BudgetTotal"].ToString() + ") ;");
                        str.Append("data.setValue(" + i + "," + 2 + "," + dt.Rows[i]["Actual"].ToString() + ") ;");
                        str.Append("data.setValue(" + i + "," + 3 + "," + dt.Rows[i]["Varience"].ToString() + ");");
                    }

                    str.Append(@" var options = { 
                                  legend: { position: 'top' }, 
                                  height: 350,
                                  isStacked: true,is3D: true,
                                  vAxis: {title: 'Total', titleTextStyle: {color: 'green'},fontName: 'Candara'},
                                  hAxis: {title: '',titleTextStyle: {color: 'green',fontName: 'Candara'},minValue: 0, maxValue: 50},

                                  curveType: 'function',
                                  pointSize: 20, 
                                  colors:['Green', 'Purple', 'Orange', 'Red'],
                                  animation: {duration: 1000,easing: 'out'},
                                  title : 'Budget Chart of " + Session["Company_Name"].ToString() + " - " + dateFrom + "'};");

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
        private void BindPieChart(string dateFrom, string GetType)
        {
            try
            {
                Hashtable ht = new Hashtable();
                ht.Add("GetType", GetType);
                ht.Add("DateFrom", dateFrom);
                ht.Add("Company_Code", Session["CompanyCode"]);
                ht.Add("OCode", Session["OCode"]);

                DataTable dt = objBud_BLL.Get_BudgetVarience(ht);
                if (dt.Rows.Count > 0)
                {
                    str.Append(@"<script type=text/javascript> google.load( 'visualization', '1', {packages:['corechart']});
                       google.setOnLoadCallback(drawChart);
                       function drawChart()
                       {
                        var data = new google.visualization.DataTable();
                        data.addColumn('string', 'Particulars');  
                        data.addColumn('string', 'Varience'); 

                        data.addRows(" + dt.Rows.Count + ");");
                    for (int i = 0; i <= dt.Rows.Count - 1; i++)
                    {
                        str.Append("data.setValue(" + i + "," + 0 + "," + "'" + dt.Rows[i]["Ledger_Name"].ToString() + "');");
                        str.Append("data.setValue(" + i + "," + 1 + "," + dt.Rows[i]["BudgetPercent"].ToString() + ");");
                    }

                    str.Append(@" var options = {title : 'Budget Chart of " + Session["Company_Name"].ToString() + " - " + dateFrom + "'};");

                    str.Append(" var chart = new google.visualization.PieChart(document.getElementById('chart_div'));");
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
        protected void btnBack_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void btnSearch_Click(object sender, ImageClickEventArgs e)
        {
            //if (GetPermission[3].ToString() == "True")
            //{
            dateFrom = String.Format("{0:MM/dd/yyyy}", dtpTo.Text);
            GetType = "A";
            if (IsPostBack)
                BindChart(dateFrom, GetType);

            //}
            //else
            //{
            //    ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "User Permission", "alert('You don't have permission to access this page!!)');", true);
            //    HttpContext.Current.Response.Redirect("..\\UI_Utilities\\DeniedPage.aspx");
            //}
        }
    }
}
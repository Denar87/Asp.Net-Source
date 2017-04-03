using Financial_MgtSystem_BLL;
using Financial_MgtSystem_BLL.CommonUtilities;
using Financial_MgtSystem_BOL;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ERPSSL.Procurement
{
    public partial class BudgetVarience : System.Web.UI.Page
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
            if(Session["OCode"] != null)
            {
                dateFrom = String.Format("{0:MM/dd/yyyy}", DateTime.Now);
                GetType = "A";
                //--------------------------------------
                RoleID = Session["RoleID"].ToString();
                PageID = "33";
                Edit_User = Session["UserID"].ToString();
                CompanyCode = "n/a";
                OCode = Session["OCode"].ToString();

                //GetPermission = objCommon.Permission(RoleID, PageID, OCode);
                //[0]CanVisit//[1]CanEdit//[2]CanDelete//[3]CanExecute
                //if (GetPermission[0].ToString() == "True")
                //{
                if (!IsPostBack)
                {
                    Get_BudgetList(dateFrom, GetType);
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

        private void Get_BudgetList(string dateFrom, string GetType)
        {
            //if (GetPermission[3].ToString() == "True")
            //{
            Hashtable ht = new Hashtable();

            ht.Add("GetType", GetType);
            ht.Add("DateFrom", dateFrom);
            ht.Add("Company_Code", "n/a");
            ht.Add("OCode", Session["OCode"]);

            DataTable dt = objBud_BLL.Get_BudgetVarience(ht);
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

        protected void btnPrint_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                //if (GetPermission[3].ToString() == "True")
                //{
                string rptCriteria = string.Empty;
                dateFrom = String.Format("{0:MM/dd/yyyy}", dtpTo.Text);
                GetType = "A";
                rptCriteria = "All Records.";
                PrintBudget(dateFrom, GetType, rptCriteria);
                //}
                //else
                //{
                //    ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "User Permission", "alert('You don't have permission to access this page!!)');", true);
                //    HttpContext.Current.Response.Redirect("..\\UI_Utilities\\DeniedPage.aspx");
                //}
            }
            catch (Exception ex)
            {
                this.lblMessage.Text = ex.Message.ToString();
                this.lblMessage.ForeColor = Color.White;
            }
        }

        private void PrintBudget(string dateFrom, string GetType, string rptCriteria)
        {
            Hashtable ht = new Hashtable();
            ht.Add("GetType", GetType);
            ht.Add("DateFrom", dateFrom);
            ht.Add("Company_Code", CompanyCode);
            ht.Add("OCode", OCode);

            DataTable dt = objBdg_BLL.Rpt_Get_AC_BudgetVarience(ht);
            if (dt.Rows.Count > 0)
            {
                Session["ReportTitle"] = "Budget Varience";
                Session["ReportCriteria"] = rptCriteria;
                Session["OrganizationDetails"] = GlobalClass_BOL.Company_Name;
                Session["OrganizationAddress"] = GlobalClass_BOL.Street_1;
                Session["OrganizationContact"] = GlobalClass_BOL.Phone;
                Session["DatePrint"] = String.Format("{0:MMMM dd, yyyy}", DateTime.Now.Date);

                Session["rptDs"] = "ds_BudgetVarience";
                Session["rptDt"] = dt;
                Session["rptFile"] = "..\\UI_ReportsFile\\BudgetVarience.rdlc";
                //Response.Redirect("..\\UI_Reporting\\ReportViewer.aspx");
                if (!Request.IsAuthenticated)
                {
                    Response.Redirect("..\\UI_Reporting\\ReportViewer.aspx?ReturnURL=" + HttpUtility.UrlEncode(HttpContext.Current.Request.Url.AbsoluteUri)); // dont forget to use urlencode
                }
            }
            else
            {
                ht.Clear();
                this.lblMessage.Text = "No record Found!!";
                messagePanel.BackColor = Color.Red;
                this.lblMessage.ForeColor = Color.White;
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
            Get_BudgetList(dateFrom, GetType);
            //}
            //else
            //{
            //    ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "User Permission", "alert('You don't have permission to access this page!!)');", true);
            //    HttpContext.Current.Response.Redirect("..\\UI_Utilities\\DeniedPage.aspx");
            //}
        }
    }
}
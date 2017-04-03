using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using System.Data;
using System.Collections;
using Financial_MgtSystem_BLL;
using Financial_MgtSystem_BOL;
using Financial_MgtSystem_BLL.CommonUtilities;

namespace ERPSSL.Accounting.UI_Reporting
{
    public partial class ChartAccount : System.Web.UI.Page
    {
        leg_Ledgers_BLL objLedBLL = new leg_Ledgers_BLL();
        rpt_Ledgers_BLL objLed_BLL = new rpt_Ledgers_BLL();
        cmp_CompanysUser_BLL objUser = new cmp_CompanysUser_BLL();
        Common_BLL objCommon = new Common_BLL();

        String[] GetPermission = new String[4];
        string RoleID, PageID, Edit_User, CompanyCode, OCode;
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Session["CompanyCode"] != null) && (Session["OCode"] != null))
            {
                RoleID = Session["RoleID"].ToString();
                PageID = "9";
                Edit_User = Session["UserID"].ToString();
                CompanyCode = Session["CompanyCode"].ToString();
                OCode = Session["OCode"].ToString();

                 //GetPermission = objCommon.Permission(RoleID, PageID, OCode);
                //[0]CanVisit//[1]CanEdit//[2]CanDelete//[3]CanExecute
                //if (GetPermission[0].ToString() == "True")
                //{
                if (!IsPostBack)
                {
                    GetChartAccount();
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

        private void GetChartAccount()
        {
            //if (GetPermission[3].ToString() == "True")
            //{
            Hashtable ht = new Hashtable();
            ht.Add("Company_Code", CompanyCode);
            ht.Add("OCode", OCode);

            DataTable dt = objLed_BLL.Get_AC_ChartAccount(ht);
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
                PrintChartAccount();
                //}
                //else
                //{
                //    ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "User Permission", "alert('You don't have permission to access this page!!)');", true);
                //    HttpContext.Current.Response.Redirect("..\\UI_Utilities\\DeniedPage.aspx");
                //}
                
            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.Message.ToString();
                lblMessage.ForeColor = Color.White;
            }
        }

        private void PrintChartAccount()
        {
            Hashtable ht = new Hashtable();
            ht.Add("Company_Code", CompanyCode);
            ht.Add("OCode", OCode);

            DataTable dt = objLed_BLL.Rpt_GetChartAccount(ht);
            if (dt.Rows.Count != 0)
            {
                Session["ReportTitle"] = "Chart of Account";
                Session["ReportCriteria"] = "All Records";
                Session["OrganizationDetails"] = GlobalClass_BOL.Company_Name;
                Session["OrganizationAddress"] = GlobalClass_BOL.Street_1;
                Session["OrganizationContact"] = GlobalClass_BOL.Phone;
                Session["DatePrint"] = String.Format("{0:MMMM dd, yyyy}", DateTime.Now.Date);

                Session["rptDs"] = "ds_ChartOfAccount";
                Session["rptDt"] = dt;
                Session["rptFile"] = "..\\UI_ReportsFile\\ChartOfAccount.rdlc";
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


        protected void dtg_list_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                dtg_list.PageIndex = e.NewPageIndex;
                GetChartAccount();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void dtg_list_RowEditing(object sender, GridViewEditEventArgs e)
        {
            //if (GetPermission[3].ToString() == "True")
            //{
            dtg_list.EditIndex = e.NewEditIndex;
            this.GetChartAccount();
            //}
            //else
            //{
            //    ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "User Permission", "alert('You don't have permission to access this page!!)');", true);
            //    HttpContext.Current.Response.Redirect("..\\UI_Utilities\\DeniedPage.aspx");
            //}
        }

        protected void dtg_list_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            Hashtable ht = new Hashtable();

            Label IndexID = (Label)dtg_list.Rows[e.RowIndex].FindControl("lblLedger_Code");
            string LedgerCode = Convert.ToString(IndexID.Text);

            TextBox Ledger_Name = (TextBox)dtg_list.Rows[e.RowIndex].FindControl("txtLedger_Name");
            string LedgerName = Convert.ToString(Ledger_Name.Text);

            ht.Add("Ledger_Code", LedgerCode);
            ht.Add("Ledger_Name", LedgerName);
            ht.Add("CompanyCode", CompanyCode);
            ht.Add("OCode", OCode);
            objLedBLL.UpdateLedger(ht);

            dtg_list.EditIndex = -1;
            this.GetChartAccount();

        }

        protected void dtg_list_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            dtg_list.EditIndex = -1;
            this.GetChartAccount();
        }
        protected void dtg_list_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        protected void dtg_list_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }

        protected void dtg_list_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

    }
}
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

namespace ERPSSL.Accounting.UI_Account
{
    public partial class AccountLedgerList : System.Web.UI.Page
    {
        leg_Ledgers_BLL objLed_BLL = new leg_Ledgers_BLL();
        rpt_Ledgers_BLL objLedr_BLL = new rpt_Ledgers_BLL();
        cmp_CompanysUser_BLL objUser = new cmp_CompanysUser_BLL();
        Common_BLL objCommon = new Common_BLL();

        String[] GetPermission = new String[4];
        string RoleID, PageID, Edit_User, CompanyCode, OCode;
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Session["CompanyCode"] != null) && (Session["OCode"] != null))
            {
                RoleID = Session["RoleID"].ToString();
                PageID = "6";
                Edit_User = Session["UserID"].ToString();
                CompanyCode = Session["CompanyCode"].ToString();
                OCode = Session["OCode"].ToString();

                GetPermission = objCommon.Permission(RoleID, PageID, OCode);
                //[0]CanVisit//[1]CanEdit//[2]CanDelete//[3]CanExecute
                if (GetPermission[0].ToString() == "True")
                {
                    if (!IsPostBack)
                    {
                        GetLedgerList();
                    }
                }
                else
                {

                    ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "User Permission", "alert('You don't have permission to access this page!!)');", true);
                    HttpContext.Current.Response.Redirect("..\\UI_Utilities\\DeniedPage.aspx");
                }
            }
            else
            {
                Response.Redirect("..\\..\\Default.aspx");
            }
        }

        private void GetLedgerList()
        {
            Hashtable ht = new Hashtable();

            ht.Add("Company_Code", CompanyCode);
            ht.Add("OCode", OCode);

            DataTable dt = objLed_BLL.GetLedgerList(ht);
            if (dt.Rows.Count > 0)
            {
                dtg_list.DataSource = dt;
                dtg_list.DataBind(); dtg_list.DataSource = dt;
            }
        }

        protected void dtg_list_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                dtg_list.PageIndex = e.NewPageIndex;
                GetLedgerList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void dtg_list_RowEditing(object sender, GridViewEditEventArgs e)
        {
            if (GetPermission[1].ToString() == "True")
            {
                dtg_list.EditIndex = e.NewEditIndex;
                this.GetLedgerList();
            }
            else
            {
                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "User Permission", "alert('You don't have permission to access this page!!)');", true);
                HttpContext.Current.Response.Redirect("..\\UI_Utilities\\DeniedPage.aspx");
            }  
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
            objLed_BLL.UpdateLedger(ht);

            dtg_list.EditIndex = -1;
            this.GetLedgerList();

        }

        protected void dtg_list_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            dtg_list.EditIndex = -1;
            this.GetLedgerList();
        }
        protected void dtg_list_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            if (GetPermission[2].ToString() == "True")
            {

            }
            else
            {
                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "User Permission", "alert('You don't have permission to access this page!!)');", true);
                HttpContext.Current.Response.Redirect("..\\UI_Utilities\\DeniedPage.aspx");
            }
        }

        protected void dtg_list_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }

        protected void dtg_list_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

        protected void btnBack_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("..\\UI_Account\\AccountLedger.aspx");
        }

        protected void btnPrint_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                if (GetPermission[3].ToString() == "True")
                {
                    PrintChartAccount();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "User Permission", "alert('You don't have permission to access this page!!)');", true);
                    HttpContext.Current.Response.Redirect("..\\UI_Utilities\\DeniedPage.aspx");
                }
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

            DataTable dt = objLedr_BLL.Rpt_GetChartAccount(ht);
            if (dt.Rows.Count != 0)
            {
                Session["ReportTitle"] = "Accounting Ledger";
                Session["ReportCriteria"] = "All Records";
                Session["OrganizationDetails"] = GlobalClass_BOL.Company_Name;
                Session["OrganizationAddress"] = GlobalClass_BOL.Street_1;
                Session["OrganizationContact"] = GlobalClass_BOL.Phone;
                Session["DatePrint"] = String.Format("{0:MMMM dd, yyyy}", DateTime.Now.Date);

                Session["rptDs"] = "ds_ChartOfAccount";
                Session["rptDt"] = dt;
                Session["rptFile"] = "..\\UI_ReportsFile\\ChartOfAccount.rdlc";
                Response.Redirect("..\\UI_Reporting\\ReportViewer.aspx");
            }
            else
            {
                ht.Clear();
                this.lblMessage.Text = "Nothing Found!!";
                messagePanel.BackColor = Color.Red;
                this.lblMessage.ForeColor = Color.White;
            }
        }
        protected void LedgerSearch_TextChanged(object sender, EventArgs e)
        {
            if (LedgerSearch.Text != null)
            {
                GetLedgerList(LedgerSearch.Text.Trim());
            }
            else
            {
                GetLedgerList();
            }
        }

        protected void btnSearch_Click(object sender, ImageClickEventArgs e)
        {
            if (LedgerSearch.Text != null)
            {
                GetLedgerList(LedgerSearch.Text.Trim());
            }
            else
            {
                GetLedgerList();
            }
        }

        private void GetLedgerList(string SearchKey)
        {
            Hashtable ht = new Hashtable();
            ht.Add("Search_Key", SearchKey);
            ht.Add("Company_Code", CompanyCode);
            ht.Add("OCode", OCode);

            DataTable dt = objLed_BLL.SearchLedger(ht);
            if (dt.Rows.Count > 0)
            {
                dtg_list.DataSource = dt;
                dtg_list.DataBind();

            }
        }
        
    }
}
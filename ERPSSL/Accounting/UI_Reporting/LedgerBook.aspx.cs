using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using System.Data;
using Financial_MgtSystem_BLL;
using System.Drawing;
using Financial_MgtSystem_BOL;
using Financial_MgtSystem_BLL.CommonUtilities;

namespace ERPSSL.Accounting.UI_Reporting
{
    public partial class LedgerBook : System.Web.UI.Page
    {
        rpt_LedgerBookDetails_BLL objLed_BLL = new rpt_LedgerBookDetails_BLL();
        leg_Ledgers_BLL objLedBLL = new leg_Ledgers_BLL();
        cmp_CompanysUser_BLL objUser = new cmp_CompanysUser_BLL();
        Common_BLL objCommon = new Common_BLL();

        String[] GetPermission = new String[4];
        string RoleID, PageID, Edit_User, CompanyCode, OCode;
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Session["CompanyCode"] != null) && (Session["OCode"] != null))
            {
                RoleID = Session["RoleID"].ToString();
                PageID = "11";
                Edit_User = Session["UserID"].ToString();
                CompanyCode = Session["CompanyCode"].ToString();
                OCode = Session["OCode"].ToString();

                 //GetPermission = objCommon.Permission(RoleID, PageID, OCode);
                //[0]CanVisit//[1]CanEdit//[2]CanDelete//[3]CanExecute
                //if (GetPermission[0].ToString() == "True")
                //{
                if (!IsPostBack)
                {
                    GetLedgerBook();
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

        private void GetLedgerBook()
        {
            //if (GetPermission[3].ToString() == "True")
            //{
            Hashtable ht = new Hashtable();
            ht.Add("Company_Code", Session["CompanyCode"]);
            ht.Add("OCode", Session["OCode"]);

            DataTable dt = objLed_BLL.GetLedgerBook(ht);
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

        private void GetLedgerBook(string SearchKey)
        {
            Hashtable ht = new Hashtable();
            ht.Add("Search_Key", SearchKey);
            ht.Add("Company_Code", Session["CompanyCode"]);
            ht.Add("OCode", Session["OCode"]);

            DataTable dt = objLedBLL.SearchLedgerBook(ht);
            if (dt.Rows.Count > 0)
            {
                dtg_list.DataSource = dt;
                dtg_list.DataBind();
            }
        }

        protected void dtg_list_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

        protected void btnPrint_Click(object sender, ImageClickEventArgs e)
        {
            //if (GetPermission[3].ToString() == "True")
            //{
            PrintLedgerBook();
            //}
            //else
            //{
            //    ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "User Permission", "alert('You don't have permission to access this page!!)');", true);
            //    HttpContext.Current.Response.Redirect("..\\UI_Utilities\\DeniedPage.aspx");
            //}
            
        }

        private void PrintLedgerBook()
        {
            Hashtable ht = new Hashtable();
            string rptCriteria = "All Ledger Records";

            ht.Add("Company_Code", Session["CompanyCode"]);
            ht.Add("OCode", Session["OCode"]);

            DataTable dt = objLed_BLL.Rpt_GetLedgerBook(ht);
            if (dt.Rows.Count != 0)
            {
                Session["ReportTitle"] = "Ledger Book";
                Session["ReportCriteria"] = rptCriteria;
                Session["OrganizationDetails"] = GlobalClass_BOL.Company_Name;
                Session["OrganizationAddress"] = GlobalClass_BOL.Street_1;
                Session["OrganizationContact"] = GlobalClass_BOL.Phone;
                Session["DatePrint"] = String.Format("{0:MMMM dd, yyyy}", DateTime.Now.Date);

                Session["rptDs"] = "ds_LedgerBook";
                Session["rptDt"] = dt;
                Session["rptFile"] = "..\\UI_ReportsFile\\LedgerBook.rdlc";
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

        protected void OnRowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';this.style.textDecoration='underline';";
                e.Row.Attributes["onmouseout"] = "this.style.textDecoration='none';";
                e.Row.ToolTip = "Click to select row";
                e.Row.Attributes["onclick"] = this.Page.ClientScript.GetPostBackClientHyperlink(this.dtg_list, "Select$" + e.Row.RowIndex);
            }
        }

        protected void dtg_list_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dtg_list.Rows.Count > 0)
            {
                foreach (GridViewRow row in dtg_list.Rows)
                {
                    if (row.RowIndex == dtg_list.SelectedIndex)
                    {
                        row.BackColor = ColorTranslator.FromHtml("#A1DCF2");
                        row.ToolTip = string.Empty;
                        LedgerSearch.Text = dtg_list.SelectedRow.Cells[0].Text;
                    }
                    else
                    {
                        row.BackColor = ColorTranslator.FromHtml("#FFFFFF");
                        row.ToolTip = "Click to select this row.";
                    }
                }
            }
            else
            {
                this.lblMessage.Text = "No Company Found!";
                this.lblMessage.ForeColor = Color.Maroon;
            }
        }

        protected void btnSearch_Click(object sender, ImageClickEventArgs e)
        {
            //if (GetPermission[3].ToString() == "True")
            //{
            if (LedgerSearch.Text != null)
            {
                GetLedgerBook(LedgerSearch.Text.Trim());
            }
            else
            {
                GetLedgerBook();
            }
            //}
            //else
            //{
            //    ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "User Permission", "alert('You don't have permission to access this page!!)');", true);
            //    HttpContext.Current.Response.Redirect("..\\UI_Utilities\\DeniedPage.aspx");
            //}
        }

        protected void dtg_list_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "View")
                {
                    ImageButton btnView = (ImageButton)e.CommandSource;
                    GridViewRow gvr = (GridViewRow)btnView.Parent.Parent;
                    Session["LedgerCode"] = null; Session["LedgerName"] = null;
                    Session["LedgerCode"] = dtg_list.DataKeys[gvr.RowIndex].Values["Ledger_Code"].ToString();
                    Session["LedgerName"] = dtg_list.DataKeys[gvr.RowIndex].Values["Ledger_Name"].ToString();

                    if (Session["LedgerCode"].ToString() != "No Record Found!")
                    {
                        Response.Redirect("LedgerBookDetails.aspx");

                    }
                }
            }
            catch (Exception ex)
            {
                this.lblMessage.Text = ex.Message.ToString();
                messagePanel.BackColor = Color.Red;
                this.lblMessage.ForeColor = Color.White;
            }

            lblMessage.Text = "Voucher Number " + GlobalClass_BOL.VoucherNo + " Selected!";

        }

        protected void LedgerSearch_TextChanged(object sender, EventArgs e)
        {
            if (LedgerSearch.Text != null)
            {
                GetLedgerBook(LedgerSearch.Text.Trim());
            }
            else
            {
                GetLedgerBook();
            }
        }
    }
}
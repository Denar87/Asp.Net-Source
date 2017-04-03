using Financial_MgtSystem_BLL;
using Financial_MgtSystem_BLL.CommonUtilities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ERPSSL.Procurement
{
    public partial class BudgetEntryList : System.Web.UI.Page
    {
        leg_Budget_BLL objBud_BLL = new leg_Budget_BLL();
        Common_BLL objCommon = new Common_BLL();

        String[] GetPermission = new String[4];
        string RoleID, PageID, Edit_User, CompanyCode, OCode;
        string dateFrom, GetType;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["OCode"] != null)
            {
                dateFrom = String.Format("{0:MM/dd/yyyy}", DateTime.Now);
                GetType = "A";
                //--------------------------------------
                RoleID = Session["RoleID"].ToString();
                PageID = "32";
                Edit_User = Session["UserID"].ToString();
                CompanyCode ="n/a";
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

                DataTable dt = objBud_BLL.Get_BudgetList(ht);
                if (dt.Rows.Count > 0)
                {
                    dtg_list.DataSource = dt;
                    dtg_list.DataBind();
                }
           // }
            //else
            //{
            //    ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "User Permission", "alert('You don't have permission to access this page!!)');", true);
            //    HttpContext.Current.Response.Redirect("..\\UI_Utilities\\DeniedPage.aspx");
            //}
        }

        protected void LedgerSearch_TextChanged(object sender, EventArgs e)
        {

        }

        protected void btnPrint_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void btnBack_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void btnSearch_Click(object sender, ImageClickEventArgs e)
        {
            if (GetPermission[3].ToString() == "True")
            {
                if (rdbViewAll.Checked)
                {
                    dateFrom = String.Format("{0:MM/dd/yyyy}", DateTime.Now);
                    GetType = "A";
                }
                else
                {
                    dateFrom = String.Format("{0:MM/dd/yyyy}", dtpFrom.Text);
                    GetType = "p";
                }

                Get_BudgetList(dateFrom, GetType);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "User Permission", "alert('You don't have permission to access this page!!)');", true);
                HttpContext.Current.Response.Redirect("..\\UI_Utilities\\DeniedPage.aspx");
            }

        }

        protected void rdbViewdtod_CheckedChanged(object sender, EventArgs e)
        {
            dtpFrom.Text = String.Format("{0:MM/dd/yyyy}", DateTime.Now);
        }
    }
}
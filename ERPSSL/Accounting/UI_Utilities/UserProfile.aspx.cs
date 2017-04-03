using Financial_MgtSystem_BLL;
using Financial_MgtSystem_BLL.CommonUtilities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ERPSSL.Accounting.UI_Utilities
{
    public partial class UserProfile : System.Web.UI.Page
    {
        cmp_CompanysUser_BLL obj_User = new cmp_CompanysUser_BLL();
        cmp_CompanysUser_BLL objUser = new cmp_CompanysUser_BLL();
        Common_BLL objCommon = new Common_BLL();

        String[] GetPermission = new String[4];
        string RoleID, PageID, Edit_User, CompanyCode, OCode;
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Session["CompanyCode"] != null) && (Session["OCode"] != null))
            {
                RoleID = Session["RoleID"].ToString();
                PageID = "22";
                Edit_User = Session["UserID"].ToString();
                CompanyCode = Session["CompanyCode"].ToString();
                OCode = Session["OCode"].ToString();

                 //GetPermission = objCommon.Permission(RoleID, PageID, OCode);
                //[0]CanVisit//[1]CanEdit//[2]CanDelete//[3]CanExecute
                //if (GetPermission[0].ToString() == "True")
                //{
                if (!IsPostBack)
                {
                    GetUserDetails();
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

        private void GetUserDetails()
        {
            try
            {
                Hashtable ht = new Hashtable();
                ht.Add("UserID", Session["UserID"]);
                ht.Add("OCode", Session["OCode"]);

                DataTable dt = obj_User.Get_UserDetails(ht);
                if (dt.Rows.Count > 0)
                {
                    ht.Clear();
                    LblUserID.Text = dt.Rows[0]["UserID"].ToString();
                    lblUsername.Text = dt.Rows[0]["UserFullName"].ToString();
                    LblUserEmail.Text = "Email: " + dt.Rows[0]["Use_Email"].ToString();
                    lblLastLoginTime.Text = "Last Login: " + String.Format("{0:dddd, dd MMMM yyyy hh:mm tt}", dt.Rows[0]["LoginTime"]);
                    lblIP_Address.Text = "Last Login IP: " + dt.Rows[0]["IP_Address"].ToString();
                    lblStatus.Text = "Status: " + dt.Rows[0]["Status"].ToString();
                }
            }
            catch (Exception ex)
            {
                this.messagePanel.Visible = true;
                //this.lblMessage.Text = ex.Message.ToString();
                this.messagePanel.BackColor = Color.Red;
                //this.lblMessage.ForeColor = Color.White;
            }
        }

    }
}
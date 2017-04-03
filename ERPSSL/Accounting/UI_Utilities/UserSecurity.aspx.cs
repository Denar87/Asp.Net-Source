using Financial_MgtSystem_BLL;
using Financial_MgtSystem_BLL.CommonUtilities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ERPSSL.Accounting.UI_Utilities
{
    public partial class UserSecurity : System.Web.UI.Page
    {
        cmp_CompanysUser_BLL objUser_BLL = new cmp_CompanysUser_BLL();
        cmp_CompanysUser_BLL objUser = new cmp_CompanysUser_BLL();
        Common_BLL objCommon = new Common_BLL();

        String[] GetPermission = new String[4];
        string RoleID, PageID, Edit_User, CompanyCode, OCode;
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Session["CompanyCode"] != null) && (Session["OCode"] != null))
            {
                RoleID = Session["RoleID"].ToString();
                PageID = "21";
                Edit_User = Session["UserID"].ToString();
                CompanyCode = Session["CompanyCode"].ToString();
                OCode = Session["OCode"].ToString();

                 //GetPermission = objCommon.Permission(RoleID, PageID, OCode);
                //[0]CanVisit//[1]CanEdit//[2]CanDelete//[3]CanExecute
                //if (GetPermission[0].ToString() == "True")
                //{

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

        private bool IsValid()
        {
            if (txtCurPassword.Text == string.Empty)
            {
                lblMessage.Text = "Enter Currrent Password!!";
                messagePanel.BackColor = Color.Red;
                this.lblMessage.ForeColor = Color.White;
                txtCurPassword.Focus();
                txtCurPassword.BackColor = Color.Khaki;
                return false;
            }

            return true;
        }

        protected void btnSubmit_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                //if (GetPermission[3].ToString() == "True")
                //{
                    Hashtable ht = new Hashtable();
                    if (IsValid())
                    {
                        ht.Add("CurPassword", txtCurPassword.Text.Trim());
                        ht.Add("NewPassword", txtNewPassword.Text.Trim());
                        ht.Add("UserID", Session["UserID"]);
                        ht.Add("OCode", Session["OCode"]);
                        ht.Add("PublicIP", Session["PublicIP"]);

                        int status = objUser_BLL.Get_UserSecurityUpdate(ht);
                        if (status == 1)
                        {
                            ht.Clear();
                            messagePanel.Visible = true;
                            messagePanel.BackColor = Color.Green;
                            this.lblMessage.ForeColor = Color.White;
                            this.lblMessage.Text = "Security Updated Successfully.";
                            return;
                        }
                        else if (status == 2)
                        {
                            ht.Clear();
                            messagePanel.Visible = true;
                            messagePanel.BackColor = Color.Green;
                            this.lblMessage.ForeColor = Color.White;
                            this.lblMessage.Text = "Incorect Current Password!!";
                            return;
                        }
                        else
                        {
                            ht.Clear();
                            messagePanel.Visible = true;
                            this.lblMessage.Text = "Security Update Failed!!";
                            messagePanel.BackColor = Color.Red;
                            this.lblMessage.ForeColor = Color.White;
                        }

                 }
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
                messagePanel.BackColor = Color.Red;
                messagePanel.Visible = true;
                this.lblMessage.ForeColor = Color.White;
            }
        }

        protected void btnBack_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("..\\UI_Gateway\\CompanyList.aspx");
        }

        protected void btnPrint_Click(object sender, ImageClickEventArgs e)
        {

        }
    }
}
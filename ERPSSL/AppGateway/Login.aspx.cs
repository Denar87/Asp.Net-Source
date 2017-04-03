using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ERPSSL.AppGateway.BOL;
using ERPSSL.AppGateway.DAL;

namespace ERPSSL.AppGateway
{
    public partial class Login : System.Web.UI.Page
    {
        BLL.LoginBll objLoginBll = new BLL.LoginBll();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.Cookies["UserName"] != null && Request.Cookies["Password"] != null)
                {
                    txtLoginName.Text = Request.Cookies["UserName"].Value;
                    txtLoginPassword.Attributes["value"] = Request.Cookies["Password"].Value;
                    chkRememberMe.Checked = true;
                }
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                if (IsValid())
                {
                    UserLogin();
                }
            }
            catch (Exception)
            {
                this.lblStatus.Text = "Login Error !!";
                this.lblStatus.ForeColor = System.Drawing.Color.Red;
                this.imgstatus.ImageUrl = "images/Cancel.png";
                this.imgstatus.Visible = true;
            }
        }

        private void UserLogin()
        {
            List<LoginBol> objResult = new List<LoginBol>();

            string UserName = txtLoginName.Text.Trim();
            string UserPass = txtLoginPassword.Text.Trim();

            objResult = objLoginBll.GetUser_Login(UserName, UserPass);


            var rowCount = objResult.Count;

            if (rowCount > 0)
            {
                var obj = objResult.FirstOrDefault();
                SessionUser objSessionUser = new SessionUser();
                objSessionUser.UserId = obj.UserID;
                objSessionUser.EID = obj.EID;
                objSessionUser.UserFullName = obj.UserFullName;
                objSessionUser.User_Level = obj.User_Level;
                objSessionUser.LoginName = obj.LoginName;
                objSessionUser.BranchID = obj.BranchID;
                objSessionUser.OCode = obj.OCode;
                objSessionUser.RoleId = obj.RoleID.ToString();
                objSessionUser.Company_Code = obj.Company_Code;
                Session["RoleId"] = obj.RoleID.ToString();
                Session["SessionUser"] = objSessionUser;
                Session["Company_Code"] = obj.Company_Code;

                Session["CompanyCode"] = obj.Company_Code;
                Session["UserID"] = obj.UserID;
                Session["OCode"] = obj.OCode;
                Session["UserFullName"] = obj.UserFullName;

                //---------------Optional----------------------------
                Session["UserID"] = objSessionUser.UserId;
                Session["UserFullName"] = objSessionUser.UserFullName;
                Session["User_Level"] = objSessionUser.User_Level;
                Session["LoginName"] = objSessionUser.LoginName;
                Session["BranchID"] = objSessionUser.BranchID;
                Session["OCode"] = objSessionUser.OCode;
                
                imgstatusloading.Visible = true;
                imgstatusloading.ImageUrl = "images/loading.gif";
                this.lblStatus.Text = "Please wait...";
                this.lblStatus.ForeColor = System.Drawing.Color.Orange;

                rememberMe();
                if (Convert.ToString(Session["User_Level"]) == "superadmin")
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "success", "setInterval(function(){location.href='../../Adminpanel/Default.aspx';},3000);", true);
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "success", "setInterval(function(){location.href='../Default.aspx';},3000);", true);
                }
            }
            else
            {
                imgstatusloading.Visible = false;
                this.lblStatus.Text = "Login Failed! Please try again later!!";
                this.lblStatus.ForeColor = System.Drawing.Color.Red;
                this.imgstatus.Visible = true;
                this.imgstatus.ImageUrl = "images/Cancel.png";
            }
        }

        private bool IsValid()
        {
            if (txtLoginName.Text == string.Empty)
            {
                this.lblStatus.Text = "Enter User name!";
                this.lblStatus.ForeColor = Color.Yellow;
                this.txtLoginName.Focus();
                this.txtLoginName.BackColor = Color.Khaki;
                return false;
            }

            if (txtLoginPassword.Text == string.Empty)
            {
                this.lblStatus.Text = "Enter User Password!";
                this.lblStatus.ForeColor = Color.Yellow;
                this.txtLoginName.Focus();
                this.txtLoginName.BackColor = Color.Khaki;
                return false;
            }

            return true;
        }

        private void rememberMe()
        {
            if (chkRememberMe.Checked)
            {
                Response.Cookies["UserName"].Expires = DateTime.Now.AddDays(30);
                Response.Cookies["Password"].Expires = DateTime.Now.AddDays(30);
            }
            else
            {
                Response.Cookies["UserName"].Expires = DateTime.Now.AddDays(-1);
                Response.Cookies["Password"].Expires = DateTime.Now.AddDays(-1);
            }

            Response.Cookies["UserName"].Value = txtLoginName.Text.Trim();
            Response.Cookies["Password"].Value = txtLoginPassword.Text.Trim();
        }

    }
}
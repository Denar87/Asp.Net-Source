using ERPSSL.Adminpanel.BLL;
using ERPSSL.Adminpanel.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ERPSSL.Adminpanel
{
    public partial class ChangePassword : System.Web.UI.Page
    {
        UserAccessBLL UserAccessBllObj = new UserAccessBLL();
        RoleBLL roleBll = new RoleBLL();
        PageBLL pageBll = new PageBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Session["UserID"] != null) && (Session["OCode"] != null))
            {
                if (!IsPostBack)
                {
                    getUserList();
                }
            }
            else
            {
                Response.Redirect("..\\AppGateway\\Login.aspx");
            }
        }

        private void getUserList()
        {
            try
            {
                string Ocode = Convert.ToString(((SessionUser)Session["SessionUser"]).OCode);
                List<tbl_User> useres = UserAccessBllObj.GetUser(Ocode);
                if (useres.Count > 0)
                {
                    drpUserName.DataSource = useres;
                    drpUserName.DataTextField = "UserFullName";
                    drpUserName.DataValueField = "UserID";
                    drpUserName.DataBind();
                    drpUserName.Items.Insert(0, new ListItem("--Select--", "0"));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void BtnChange_Clik(object sender, EventArgs e)
        {
            try
            {
                UserBLL _userBll = new UserBLL();

                //int status = _userBll.getCurrentStatusBy(((SessionUser)Session["SessionUser"]).UserId, txtCurrentPass.Text);
                if (txtCurrentPass.Text == "")
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Password Not Found')", true);
                    return;
                }
                else
                {
                    //string UserID = ((SessionUser)Session["SessionUser"]).UserId.ToString();
                    //string NewPassword = txtNewPass.Text.ToString();
                    string ConfPassword = txtConfirmPass.Text.ToString();
                    //if (NewPassword != ConfPassword)
                    //{
                    //    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('These passwords don't match. Try again?')", true);
                    //}

                    tbl_UserPassword _userPassword = new tbl_UserPassword();
                    _userPassword.UserID = Guid.Parse(drpUserName.SelectedValue);
                    _userPassword.Password = ConfPassword;
                    int result = _userBll.ChangePassword(_userPassword);
                    if (result == 1)
                    {
                        drpUserName.ClearSelection();
                        txtCurrentPass.Text = "";
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Password Change Successfully.')", true);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void drpUserName_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                LoadUserPassword();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void LoadUserPassword()
        {
            try
            {
                Guid UserId = Guid.Parse(drpUserName.SelectedValue);
                string OCode = ((SessionUser)Session["SessionUser"]).OCode;

                var useres = UserAccessBllObj.GetUserPassword(UserId, OCode);
                if (useres.Count > 0)
                {
                    var CurrentP = useres.FirstOrDefault();
                    txtCurrentPass.Text = CurrentP.Password;
                }
                else
                {
                    txtCurrentPass.Text = "";
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
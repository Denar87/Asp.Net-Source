using ERPSSL.Adminpanel.BLL;
using ERPSSL.Adminpanel.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ERPSSL
{
    public partial class ChangePassword : System.Web.UI.Page
	{
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnChange_Clik(object sender, EventArgs e)
        {
            try
            {
                UserBLL _userBll = new UserBLL();

                int status = _userBll.getCurrentStatusBy(((SessionUser)Session["SessionUser"]).UserId, txtCurrentPass.Text);
                if (status == 1)
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('your Current Password is not Match.')", true);
                }
                else
                {
                    string UserID = ((SessionUser)Session["SessionUser"]).UserId.ToString();
                    string NewPassword = txtNewPass.Text.ToString();
                    string ConfPassword = txtConfirmPass.Text.ToString();
                    if (NewPassword != ConfPassword)
                    {
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('These passwords don't match. Try again?')", true);
                    }
                    else
                    {
                        tbl_UserPassword _userPassword = new tbl_UserPassword();
                        _userPassword.UserID = ((SessionUser)Session["SessionUser"]).UserId;
                        _userPassword.Password = ConfPassword;
                        int result = _userBll.ChangePassword(_userPassword);
                        if (result == 1)
                        {
                            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Password Change Successfully.')", true);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
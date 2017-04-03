using Financial_MgtSystem_BLL;
using Financial_MgtSystem_BLL.CommonUtilities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ERPSSL.Accounting.UI_Setup
{
    public partial class UserSetup : System.Web.UI.Page
    {
        Conf_NewCompany_BLL objCom_BLL = new Conf_NewCompany_BLL();
        cmp_CompanysUser_BLL objUser_BLL = new cmp_CompanysUser_BLL();
        cmp_CompanysUser_BLL objUser = new cmp_CompanysUser_BLL();
        Common_BLL objCommon = new Common_BLL();

        String[] GetPermission = new String[4];
        string RoleID, PageID, Edit_User, CompanyCode, OCode;
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Session["CompanyCode"] != null) && (Session["OCode"] != null))
            {
                this.Form.DefaultButton = this.btnAdd.UniqueID;
                RoleID = Session["RoleID"].ToString();
                PageID = "19";
                Edit_User = Session["UserID"].ToString();
                CompanyCode = Session["CompanyCode"].ToString();
                OCode = Session["OCode"].ToString();

                 //GetPermission = objCommon.Permission(RoleID, PageID, OCode);
                //[0]CanVisit//[1]CanEdit//[2]CanDelete//[3]CanExecute
                //if (GetPermission[0].ToString() == "True")
                //{
                if (!IsPostBack)
                {
                    GetCompanyUser();
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

        private void GetCompanyUser()
        {
            Hashtable ht = new Hashtable();
            ht.Add("OCode", Session["OCode"]);

            DataTable dt = objCom_BLL.Conf_Get_UserList(ht);
            if (dt.Rows.Count > 0)
            {
                dtg_list.DataSource = dt;
                dtg_list.DataBind();
            }
        }

        private void Get_UserRoleList()
        {
            //if (GetPermission[3].ToString() == "True")
            //{
                Hashtable ht = new Hashtable();
                ht.Add("OCode", Session["OCode"]);

                DataTable dt = objCom_BLL.Conf_Get_UserRoleList(ht);
                if (dt.Rows.Count > 0)
                {
                    cmbUSerRole.DataSource = dt;
                    cmbUSerRole.DataValueField = "RoleID";
                    cmbUSerRole.DataTextField = "RoleName";
                    cmbUSerRole.DataBind();
                }
            //}
            //else
            //{
            //    ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "User Permission", "alert('You don't have permission to access this page!!)');", true);
            //    HttpContext.Current.Response.Redirect("..\\UI_Utilities\\DeniedPage.aspx");
            //}
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (hfPopupID.Value == "0")
                {
                    //if (GetPermission[3].ToString() == "True")
                    //{
                        Hashtable ht = new Hashtable();
                        if (IsValid())
                        {
                            ht.Add("UserName", txtUserName.Text.Trim());
                            ht.Add("UserFullName", txtUserFullName.Text.Trim());
                            ht.Add("UserEmail", txtEmail.Text.Trim());
                            ht.Add("UserPass", txtUserPass.Text.Trim());
                            ht.Add("USerRole", cmbUSerRole.SelectedValue);
                            ht.Add("UserLevel", cmbUSerRole.SelectedItem.Text);
                            ht.Add("UserID", Session["UserID"]);
                            ht.Add("OCode", Session["OCode"]);
                            ht.Add("PublicIP", Session["PublicIP"]);

                            int status = objUser_BLL.Create_User(ht);
                            if (status == 1)
                            {
                                ht.Clear();
                                messagePanel.Visible = true;
                                messagePanel.BackColor = Color.Green;
                                this.lblMessage.ForeColor = Color.White;
                                this.lblMessage.Text = "New User Created Successfully.";
                                GetCompanyUser();
                                return;
                            }
                            else if (status == 0)
                            {
                                ht.Clear();
                                messagePanel.Visible = true;
                                messagePanel.BackColor = Color.Green;
                                this.lblMessage.ForeColor = Color.White;
                                this.lblMessage.Text = "User Already Exist!!";
                                return;
                            }
                            else if (status == 2)
                            {
                                ht.Clear();
                                messagePanel.Visible = true;
                                messagePanel.BackColor = Color.Green;
                                this.lblMessage.ForeColor = Color.White;
                                this.lblMessage.Text = "You are not Permitted to Create New User!!";
                                return;
                            }

                            else
                            {
                                ht.Clear();
                                messagePanel.Visible = true;
                                this.lblMessage.Text = "New User Create Failed!!";
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
                else
                {

                }


            }
            catch (Exception ex)
            {
                this.lblMessage.Text = ex.Message.ToString();
                messagePanel.BackColor = Color.Red;
                messagePanel.Visible = true;
                this.lblMessage.ForeColor = Color.White;
            }
        }
        private bool IsValid()
        {
            if (txtUserName.Text == string.Empty)
            {
                lblMessage.Text = "Enter User name!!";
                messagePanel.BackColor = Color.Red;
                this.lblMessage.ForeColor = Color.White;
                txtUserName.Focus();
                txtUserName.BackColor = Color.Khaki;
                return false;
            }
            if (txtEmail.Text == string.Empty)
            {
                lblMessage.Text = "Enter a Valid Email Id!";
                messagePanel.BackColor = Color.Red;
                this.lblMessage.ForeColor = Color.White;
                txtEmail.Focus();
                txtEmail.BackColor = Color.Khaki;
                txtEmail.BackColor = Color.Khaki;
                return false;
            }

            if (Regex.IsMatch(txtEmail.Text, @"^(?("")("".+?""@)|(([0-9a-zA-Z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-zA-Z])@))" + @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,6}))$"))
            {
                //----------do Someting--------------
            }
            else
            {
                lblMessage.Text = "Not a Valid Email Id!";
                messagePanel.BackColor = Color.Red;
                this.lblMessage.ForeColor = Color.White;
                txtEmail.Focus();
                txtEmail.BackColor = Color.Khaki;
                txtEmail.BackColor = Color.Khaki;
                return false;
            }

            return true;
        }

        protected void Clear()
        {
            txtUserName.Text = string.Empty;
            txtUserFullName.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtUserPass.Text = string.Empty;
        }

        protected void btnPrint_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void btnBack_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("..\\UI_Gateway\\CompanyList.aspx");
        }

        protected void btnAdd_Click(object sender, ImageClickEventArgs e)
        {
            Clear();
            Get_UserRoleList();
            mpeAjax.Show();
        }

        protected void btnNewRole_Click(object sender, EventArgs e)
        {
            if (!Request.IsAuthenticated)
            {
                Response.Redirect("..\\UI_Setup\\UserRole.aspx?ReturnURL=" + HttpUtility.UrlEncode(HttpContext.Current.Request.Url.AbsoluteUri)); // dont forget to use urlencode
            }
        }
        protected void ibtnEdit_Click(object sender, ImageClickEventArgs e)
        {
            Get_UserRoleList();
            ImageButton btnEdit = (ImageButton)sender;
            GridViewRow gvRow = (GridViewRow)btnEdit.NamingContainer;
            string UserID = Convert.ToString(dtg_list.DataKeys[gvRow.RowIndex].Value);
            // Now set value to modal popup
            hfPopupID.Value = "0";
            hfPopupID.Value = UserID.ToString();
            //ddlStatus.Visible = true;
            txtUserName.ReadOnly = true;
            txtEmail.ReadOnly = true;
            txtUserPass.ReadOnly = true;
            panelPass.Visible = false;
            btnSave.Text = "Update";
            mpeAjax.Show();

        }
        protected void dtg_list_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            //if (GetPermission[2].ToString() == "True")
            //{
            Hashtable ht = new Hashtable();

            Label IndexUserID = (Label)dtg_list.Rows[e.RowIndex].FindControl("lblUserID");
            string UserID = Convert.ToString(IndexUserID.Text);

            ht.Add("UserID", UserID);
            ht.Add("OCode", OCode);
            objUser_BLL.Delete_User(ht);

            dtg_list.EditIndex = -1;
            this.GetCompanyUser();
            //}
            //else
            //{
            //    ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "User Permission", "alert('You don't have permission to access this page!!)');", true);
            //    HttpContext.Current.Response.Redirect("..\\UI_Utilities\\DeniedPage.aspx");
            //}
        }
        protected void dtg_list_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Edit")
            {

            }
        }
    }
}
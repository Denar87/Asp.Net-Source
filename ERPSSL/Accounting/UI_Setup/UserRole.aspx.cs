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

namespace ERPSSL.Accounting.UI_Setup
{
    public partial class UserRole : System.Web.UI.Page
    {
        Conf_NewCompany_BLL objCom_BLL = new Conf_NewCompany_BLL();
        cmp_CompanysUser_BLL objUser_BLL = new cmp_CompanysUser_BLL();
        Common_BLL objCommon = new Common_BLL();

        String[] GetPermission = new String[4];
        string RoleID, PageID, Edit_User, CompanyCode, OCode;
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Session["CompanyCode"] != null) && (Session["OCode"] != null))
            {
                if (!IsPostBack)
                {
                    Get_UserRoleList();
                }
            }
            else
            {
                HttpContext.Current.Response.Redirect("..\\..\\Default.aspx");
            }
        }

        private void Get_UserRoleList()
        {
            Hashtable ht = new Hashtable();
            ht.Add("OCode", Session["OCode"]);

            DataTable dt = objCom_BLL.Conf_Get_UserRoleList(ht);
            if (dt.Rows.Count > 0)
            {
                dtg_list.DataSource = dt;
                dtg_list.DataBind();
            }
        }

        protected void btnBack_Click(object sender, ImageClickEventArgs e)
        {
            if (Request.QueryString["ReturnURL"] != null)
            {
                Response.Redirect(HttpUtility.UrlDecode(Request.QueryString["ReturnURL"]));
            }
            else
            {
                Response.Redirect("..\\UI_Gateway\\CompanyList.aspx");
            }
        }

        protected void btnPrint_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void dtg_list_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                Label RoleID = (Label)dtg_list.Rows[e.RowIndex].FindControl("lblRoleID");
                TextBox RoleName = (TextBox)dtg_list.Rows[e.RowIndex].FindControl("txtRoleUpdate");

                Hashtable ht = new Hashtable();
                ht.Add("RoleID", Convert.ToInt32(RoleID.Text));
                ht.Add("RoleName", RoleName.Text.Trim());
                ht.Add("EditUser", Session["UserID"]);
                ht.Add("OCode", Session["OCode"]);

                int status = objUser_BLL.Update_UserRole(ht);
                if (status == 1)
                {
                    ht.Clear();
                    messagePanel.Visible = true;
                    messagePanel.BackColor = Color.Green;
                    this.lblMessage.ForeColor = Color.White;
                    this.lblMessage.Text = "User Role Update Successfully.";
                    dtg_list.EditIndex = -1;
                    Get_UserRoleList();
                    return;
                }
                else
                {
                    ht.Clear();
                    messagePanel.Visible = true;
                    this.lblMessage.Text = "New User Role update Failed!!";
                    messagePanel.BackColor = Color.Red;
                    this.lblMessage.ForeColor = Color.White;
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

        protected void dtg_list_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            Label RoleID = (Label)dtg_list.Rows[e.RowIndex].FindControl("lblRoleID");
            dtg_list.EditIndex = -1;
            Get_UserRoleList();
        }

        protected void dtg_list_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            dtg_list.EditIndex = -1;
            Get_UserRoleList();
        }

        protected void dtg_list_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                //if (GetPermission[3].ToString() == "True")
                //{
                if (e.CommandName.Equals("Insert"))
                {
                    TextBox RoleName = (TextBox)dtg_list.FooterRow.FindControl("txtRole");
                    Hashtable ht = new Hashtable();

                    ht.Add("RoleName", RoleName.Text.Trim());
                    ht.Add("EditUser", Session["UserID"]);
                    ht.Add("OCode", Session["OCode"]);

                    int status = objUser_BLL.Save_UserRole(ht);
                    if (status == 1)
                    {
                        ht.Clear();
                        messagePanel.Visible = true;
                        messagePanel.BackColor = Color.Green;
                        this.lblMessage.ForeColor = Color.White;
                        this.lblMessage.Text = "New User Role Created Successfully.";
                        dtg_list.EditIndex = -1;
                        Get_UserRoleList();
                        return;
                    }
                    else if (status == 0)
                    {
                        ht.Clear();
                        messagePanel.Visible = true;
                        messagePanel.BackColor = Color.Red;
                        this.lblMessage.ForeColor = Color.White;
                        this.lblMessage.Text = "User Role Already Exist!!";
                        return;
                    }

                    else
                    {
                        ht.Clear();
                        messagePanel.Visible = true;
                        this.lblMessage.Text = "New User Role Create Failed!!";
                        messagePanel.BackColor = Color.Red;
                        this.lblMessage.ForeColor = Color.White;
                    }
                    //}
                    //else
                    //{
                    //    ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "User Permission", "alert('You don't have permission to access this page!!)');", true);
                    //    HttpContext.Current.Response.Redirect("..\\UI_Utilities\\DeniedPage.aspx");
                    //}

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

        protected void dtg_list_RowEditing(object sender, GridViewEditEventArgs e)
        {
            dtg_list.EditIndex = e.NewEditIndex;
            Get_UserRoleList();
        }
    }
}
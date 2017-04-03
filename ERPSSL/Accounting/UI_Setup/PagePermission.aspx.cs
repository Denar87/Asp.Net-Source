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
    public partial class PagePermission : System.Web.UI.Page
    {
        Conf_NewCompany_BLL objCom_BLL = new Conf_NewCompany_BLL();
        cmp_CompanysUser_BLL objUser = new cmp_CompanysUser_BLL();
        Common_BLL objCommon = new Common_BLL();

        String[] GetPermission = new String[4];
        string RoleID, PageID, Edit_User, CompanyCode, OCode;
        Int32 SelectedRoleID = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Session["CompanyCode"] != null) && (Session["OCode"] != null))
            {
                RoleID = Session["RoleID"].ToString();
                PageID = "20";
                Edit_User = Session["UserID"].ToString();
                CompanyCode = Session["CompanyCode"].ToString();
                OCode = Session["OCode"].ToString();

                 //GetPermission = objCommon.Permission(RoleID, PageID, OCode);
                //[0]CanVisit//[1]CanEdit//[2]CanDelete//[3]CanExecute
                if ((GetPermission[0].ToString() == "True") && (GetPermission[1].ToString() == "True") && (GetPermission[2].ToString() == "True") && (GetPermission[3].ToString() == "True"))
                {
                    if (!IsPostBack)
                    {
                        Get_UserRoleList();
                        //GetUserPermission();
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
                drpUserRole.DataSource = dt;
                drpUserRole.DataTextField = "RoleName";
                drpUserRole.DataValueField = "RoleID";
                drpUserRole.DataBind();
            }
        }
        private void GetUserPermission()
        {
            try
            {
                Hashtable ht = new Hashtable();
                ht.Add("RoleID", Convert.ToInt32(SelectedRoleID));
                ht.Add("OCode", OCode);
                DataTable dt = objUser.Get_PagePermission(ht);
                if (dt.Rows.Count > 0)
                {
                    gvPermission.DataSource = dt;
                    gvPermission.DataBind();
                }
                else
                { gvPermission.DataSource = null; }
            }
            catch (Exception ex)
            {
                this.messagePanel.Visible = true;
                this.lblMessage.Text = ex.Message.ToString();
                this.messagePanel.BackColor = Color.Red;
                this.lblMessage.ForeColor = Color.White;
            }
        }

        protected void chkbxEditAll__CheckedChanged(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {

            }
        }
        protected void chkbxUpdateAll__CheckedChanged(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {

            }
        }
        protected void chkbxDeleteAll__CheckedChanged(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {

            }
        }
        protected void chkbxExecuteAll__CheckedChanged(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {

            }
        }

        protected void btnPrint_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void btnBack_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, ImageClickEventArgs e)
        {
            if ((GetPermission[0].ToString() == "True") && (GetPermission[1].ToString() == "True") && (GetPermission[2].ToString() == "True") && (GetPermission[3].ToString() == "True"))
            {
                SelectedRoleID = Convert.ToInt32(drpUserRole.SelectedItem.Value);
                int result = 0;
                bool Visit, Edit, Delete, Execute;
                Visit = Edit = Delete = Execute = false;
                int numRows = gvPermission.Rows.Count;

                for (int i = 0; i < numRows; i++)
                {
                    Hashtable ht = new Hashtable();

                    GridViewRow dr = gvPermission.Rows[i];
                    Label lbl_PageID = (Label)dr.Cells[0].FindControl("lblID_");
                    CheckBox chkbx_Edit = (CheckBox)dr.Cells[2].FindControl("chkbxEditItem_");
                    CheckBox chkbx_Update = (CheckBox)dr.Cells[3].FindControl("chkbxUpdateItem_");
                    CheckBox chkbx_Delete = (CheckBox)dr.Cells[4].FindControl("chkbxDeleteItem_");
                    CheckBox chkbx_Execute = (CheckBox)dr.Cells[5].FindControl("chkbxExecuteItem_");

                    if (chkbx_Edit.Checked)
                    {
                        Visit = true;
                    }
                    if (chkbx_Update.Checked)
                    {
                        Edit = true;
                    }
                    if (chkbx_Delete.Checked)
                    {
                        Delete = true;
                    }
                    if (chkbx_Execute.Checked)
                    {
                        Execute = true;
                    }

                    ht.Add("PageID", Convert.ToInt16(lbl_PageID.Text));
                    ht.Add("RoleID", Convert.ToInt16(SelectedRoleID));
                    ht.Add("Visit", Visit);
                    ht.Add("Edit", Edit);
                    ht.Add("Delete", Delete);
                    ht.Add("Execute", Execute);
                    ht.Add("Edit_User", Edit_User);
                    ht.Add("Company_Code", CompanyCode);
                    ht.Add("OCode", OCode);
                    result = objUser.Update_PagePermission(ht);
                    Visit = Edit = Delete = Execute = false;
                }
                if (result == 1)
                {
                    messagePanel.Visible = true;
                    lblMessage.Text = "Setting Saved Successfully!!";
                    messagePanel.BackColor = Color.Green;
                    this.lblMessage.ForeColor = Color.White;
                }
                else
                {
                    messagePanel.Visible = true;
                    this.lblMessage.Text = "Setting Update Failed!!";
                    messagePanel.BackColor = Color.Red;
                    this.lblMessage.ForeColor = Color.White;
                }
            }
        }

        protected void drpUserRole_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectedRoleID = Convert.ToInt32(drpUserRole.SelectedItem.Value);
            GetUserPermission();
        }

        protected void drpUserRole_DataBound(object sender, EventArgs e)
        {
            SelectedRoleID = Convert.ToInt32(drpUserRole.SelectedItem.Value);
            GetUserPermission();
        }
    }
}
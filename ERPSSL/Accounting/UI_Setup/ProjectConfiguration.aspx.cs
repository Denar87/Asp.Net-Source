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

namespace ERPSSL.Accounting.UI_Setup
{
    public partial class ProjectConfiguration : System.Web.UI.Page
    {
        cmp_CompanyProject_BLL objCom_BLL = new cmp_CompanyProject_BLL();
        cmp_CompanysUser_BLL objUser = new cmp_CompanysUser_BLL();
        Common_BLL objCommon = new Common_BLL();

        String[] GetPermission = new String[4];
        string RoleID, PageID, Edit_User, CompanyCode, OCode;
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Session["CompanyCode"] != null) && (Session["OCode"] != null))
            {
                RoleID = Session["RoleID"].ToString();
                PageID = "17";
                Edit_User = Session["UserID"].ToString();
                CompanyCode = Session["CompanyCode"].ToString();
                OCode = Session["OCode"].ToString();

                 //GetPermission = objCommon.Permission(RoleID, PageID, OCode);
                //[0]CanVisit//[1]CanEdit//[2]CanDelete//[3]CanExecute
                //if (GetPermission[0].ToString() == "True")
                //{
                if (!IsPostBack)
                {
                    Get_StatementSetting();
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

        private void Get_StatementSetting()
        {
            //if (GetPermission[3].ToString() == "True")
            //{
            Hashtable ht = new Hashtable();
            ht.Add("Company_Code", Session["CompanyCode"]);
            ht.Add("OCode", Session["OCode"]);

            DataTable dt = objCom_BLL.Get_StatementSetting(ht);
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

        protected void dtg_list_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                dtg_list.PageIndex = e.NewPageIndex;
                Get_StatementSetting();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        protected void dtg_list_RowEditing(object sender, GridViewEditEventArgs e)
        {
            //if (GetPermission[1].ToString() == "True")
            //{
            dtg_list.EditIndex = e.NewEditIndex;
            this.Get_StatementSetting();
            //}
            //else
            //{
            //    ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "User Permission", "alert('You don't have permission to access this page!!)');", true);
            //    HttpContext.Current.Response.Redirect("..\\UI_Utilities\\DeniedPage.aspx");
            //}
            
        }

        protected void dtg_list_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            //Hashtable ht = new Hashtable();

            //Label IndexID = (Label)dtg_list.Rows[e.RowIndex].FindControl("lblGroup_ID");
            //string GroupID = Convert.ToString(IndexID.Text);

            //TextBox Group_Name = (TextBox)dtg_list.Rows[e.RowIndex].FindControl("txtGroup_Name");
            //string GroupName = Convert.ToString(Group_Name.Text);

            //ht.Add("Group_ID", GroupID);
            //ht.Add("Group_Name", GroupName);
            //ht.Add("CompanyCode", Session["CompanyCode"]);
            //ht.Add("OCode", Session["OCode"]);
            //objGrp_BL.Update_GroupHead(ht);

            dtg_list.EditIndex = -1;
            this.Get_StatementSetting();

        }

        protected void dtg_list_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            dtg_list.EditIndex = -1;
            this.Get_StatementSetting();
        }
        protected void dtg_list_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        protected void dtg_list_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }

        protected void dtg_list_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

    }
}
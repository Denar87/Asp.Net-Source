using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Financial_MgtSystem_BLL;
using System.Collections;
using System.Data;
using System.Drawing;
using Microsoft.Reporting.WebForms;
using Financial_MgtSystem_BOL;
using Financial_MgtSystem_BLL.CommonUtilities;

namespace ERPSSL.Accounting.UI_Account
{
    public partial class AccountGroupList : System.Web.UI.Page
    {
        grp_GroupHead_BLL objGrp_BL = new grp_GroupHead_BLL();
        cmp_CompanysUser_BLL objUser = new cmp_CompanysUser_BLL();
        Common_BLL objCommon = new Common_BLL();

        String[] GetPermission = new String[4];
        string RoleID, PageID, Edit_User, CompanyCode, OCode;
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Session["CompanyCode"] != null) && (Session["OCode"] != null))
            {
                RoleID = Session["RoleID"].ToString();
                PageID = "4";
                Edit_User = Session["UserID"].ToString();
                CompanyCode = Session["CompanyCode"].ToString();
                OCode = Session["OCode"].ToString();

                GetPermission = objCommon.Permission(RoleID, PageID, OCode);
                //[0]CanVisit//[1]CanEdit//[2]CanDelete//[3]CanExecute
                if (GetPermission[0].ToString() == "True")
                {
                    if (!IsPostBack)
                    {
                        GetParentGroup();
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

        private void GetParentGroup()
        {
            Hashtable ht = new Hashtable();

            ht.Add("Company_Code", Session["CompanyCode"]);
            ht.Add("OCode", Session["OCode"]);

            DataTable dt = objGrp_BL.GetGroupheadList(ht);
            if (dt.Rows.Count > 0)
            {
                dtg_list.DataSource = dt;
                dtg_list.DataBind();

            }
        }

        protected void dtg_list_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                dtg_list.PageIndex = e.NewPageIndex;
                GetParentGroup();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        protected void dtg_list_RowEditing(object sender, GridViewEditEventArgs e)
        {
            if (GetPermission[1].ToString() == "True")
            {
                dtg_list.EditIndex = e.NewEditIndex;
                this.GetParentGroup();
            }
            else
            {
                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "User Permission", "alert('You don't have permission to access this page!!)');", true);
                HttpContext.Current.Response.Redirect("..\\UI_Utilities\\DeniedPage.aspx");
            }
        }

        protected void dtg_list_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                Hashtable ht = new Hashtable();

                Label IndexID = (Label)dtg_list.Rows[e.RowIndex].FindControl("lblGroup_ID");
                string GroupID = Convert.ToString(IndexID.Text);

                TextBox Group_Name = (TextBox)dtg_list.Rows[e.RowIndex].FindControl("txtGroup_Name");
                string GroupName = Convert.ToString(Group_Name.Text);

                ht.Add("Group_ID", GroupID);
                ht.Add("Group_Name", GroupName);
                ht.Add("CompanyCode", Session["CompanyCode"]);
                ht.Add("OCode", Session["OCode"]);
                objGrp_BL.Update_GroupHead(ht);

                dtg_list.EditIndex = -1;
                this.GetParentGroup();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        protected void dtg_list_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            dtg_list.EditIndex = -1;
            this.GetParentGroup();
        }
        protected void dtg_list_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            if (GetPermission[2].ToString() == "True")
            {

            }
            else
            {
                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "User Permission", "alert('You don't have permission to access this page!!)');", true);
                HttpContext.Current.Response.Redirect("..\\UI_Utilities\\DeniedPage.aspx");
            }
        }

        protected void dtg_list_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }

        protected void dtg_list_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

        protected void btnBack_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("..\\UI_Account\\AccountGroup.aspx");
        }

        protected void btnPrint_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                if (GetPermission[3].ToString() == "True")
                {
                    Hashtable ht = new Hashtable();
                    ht.Add("Company_Code", Session["CompanyCode"]);
                    ht.Add("OCode", Session["OCode"]);

                    DataTable dt = objGrp_BL.Get_RptGrouphead(ht);
                    if (dt.Rows.Count != 0)
                    {
                        Session["ReportTitle"] = "Accounting Group";
                        Session["ReportCriteria"] = "All Records";
                        Session["OrganizationDetails"] = GlobalClass_BOL.Company_Name;
                        Session["OrganizationAddress"] = GlobalClass_BOL.Street_1;
                        Session["OrganizationContact"] = GlobalClass_BOL.Phone;
                        Session["DatePrint"] = String.Format("{0:MMMM dd, yyyy}", DateTime.Now.Date);

                        Session["rptDs"] = "DataSet_Reporting_GRP";
                        Session["rptDt"] = dt;
                        Session["rptFile"] = "..\\UI_ReportsFile\\GroupHead.rdlc";
                        Response.Redirect("..\\UI_Reporting\\ReportViewer.aspx");
                    }
                    else
                    {
                        ht.Clear();
                        this.lblMessage.Text = "Nothing Found!!";
                        messagePanel.BackColor = Color.Red;
                        this.lblMessage.ForeColor = Color.White;
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "User Permission", "alert('You don't have permission to access this page!!)');", true);
                    HttpContext.Current.Response.Redirect("..\\UI_Utilities\\DeniedPage.aspx");
                } 
            }
            catch (Exception ex)
            {
                this.lblMessage.Text = ex.Message.ToString();
                this.lblMessage.ForeColor = Color.White;
            }
        }

        protected void dtg_list_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void LedgerSearch_TextChanged(object sender, EventArgs e)
        {
            
        }

        protected void btnSearch_Click(object sender, ImageClickEventArgs e)
        {

        }
    }
}
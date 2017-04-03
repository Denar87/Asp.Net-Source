using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Collections;
using Financial_MgtSystem_BLL;
using System.Drawing;
using Financial_MgtSystem_BOL;
using Financial_MgtSystem_BLL.CommonUtilities;

namespace ERPSSL.Accounting.UI_Account
{
    public partial class AccountGroup : System.Web.UI.Page
    {
        grp_GroupHead_BLL objGrp_BL = new grp_GroupHead_BLL();
        cmp_CompanysUser_BLL objUser = new cmp_CompanysUser_BLL();
        Common_BLL objCommon = new Common_BLL();

        String[] GetPermission = new String[4];
        string RoleID, PageID, Edit_User,CompanyCode, OCode;
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Session["CompanyCode"] != null) && (Session["OCode"] != null))
            {
                this.Form.DefaultButton = this.btnAdd.UniqueID;
                RoleID = Session["RoleID"].ToString();
                PageID = "3";
                Edit_User = Session["UserID"].ToString();
                CompanyCode = Session["CompanyCode"].ToString();
                OCode = Session["OCode"].ToString();

                 //GetPermission = objCommon.Permission(RoleID, PageID, OCode);
                //[0]CanVisit//[1]CanEdit//[2]CanDelete//[3]CanExecute
                //if (GetPermission[0].ToString() == "True")
                //{
                if (!IsPostBack)
                {
                    GetParentGroupList();
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

        private void GetParentGroupList()
        {
            try
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
            catch (Exception ex)
            {
                this.lblMessage.Text = ex.Message.ToString();
                this.lblMessage.ForeColor = Color.White;
            }
        }

        protected void dtg_list_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                dtg_list.PageIndex = e.NewPageIndex;
                GetParentGroupList();
            }
            catch (Exception ex)
            {
                this.lblMessage.Text = ex.Message.ToString();
                this.lblMessage.ForeColor = Color.White;
            }
        }
        protected void dtg_list_RowEditing(object sender, GridViewEditEventArgs e)
        {
            //if (GetPermission[1].ToString() == "True")
            //{
            dtg_list.EditIndex = e.NewEditIndex;
            this.GetParentGroupList();
            //}
            //else
            //{
            //    ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "User Permission", "alert('You don't have permission to access this page!!)');", true);
            //    HttpContext.Current.Response.Redirect("..\\UI_Utilities\\DeniedPage.aspx");
            //}
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
                this.GetParentGroupList();
            }
            catch (Exception ex)
            {
                this.lblMessage.Text = ex.Message.ToString();
                this.lblMessage.ForeColor = Color.White;
            }

        }

        protected void dtg_list_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            dtg_list.EditIndex = -1;
            this.GetParentGroupList();
        }
        protected void dtg_list_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            //if (GetPermission[2].ToString() == "True")
            //{

            //}
            //else
            //{
            //    ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "User Permission", "alert('You don't have permission to access this page!!)');", true);
            //    HttpContext.Current.Response.Redirect("..\\UI_Utilities\\DeniedPage.aspx");
            //}
        }

        protected void dtg_list_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }

        protected void dtg_list_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

        private void GetParentGroup()
        {
            try
            {
                Hashtable ht = new Hashtable();

                ht.Add("Company_Code", CompanyCode);
                ht.Add("OCode", OCode);
 
                DataTable dt = objGrp_BL.GetGroupheadList(ht);
                if (dt.Rows.Count > 0)
                {
                    cmbCategoryGroup_Parent.DataSource = dt;
                    cmbCategoryGroup_Parent.DataValueField = "Group_ID";
                    cmbCategoryGroup_Parent.DataTextField = "Group_Name";
                    cmbCategoryGroup_Parent.DataBind();
                }
            }
            catch (Exception ex)
            {
                this.lblMessage.Text = ex.Message.ToString();
                this.lblMessage.ForeColor = Color.White;
            }
 
        }

        private bool IsValid()
        {
            if (txtGroupName.Text == string.Empty)
            {
                lblMessage.Text = "Enter Group name!!";
                messagePanel.BackColor = Color.Red;
                this.lblMessage.ForeColor = Color.White;
                txtGroupName.Focus();
                txtGroupName.BackColor = Color.Khaki;
                return false;
            }

            return true;
        }

        protected void chkGrpNature_CheckedChanged(object sender, EventArgs e)
        {
            mpeAjax.Show();
            cmbCategoryGroup_Parent.Enabled = false;
            cmbNature.Visible = true;
        }
        protected void chkGrpNatureHide_CheckedChanged(object sender, EventArgs e)
        {
            mpeAjax.Show();
            cmbCategoryGroup_Parent.Enabled = true;
            cmbNature.Visible = false;
        }

        protected void btnGrpList_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("..\\UI_Account\\AccountGroupList.aspx");
        }

        protected void btnPrint_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                //if (GetPermission[3].ToString() == "True")
                //{
                Hashtable ht = new Hashtable();

                ht.Add("Company_Code", CompanyCode);
                ht.Add("OCode", OCode);

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
                    //Response.Redirect("..\\UI_Reporting\\ReportViewer.aspx");
                    if (!Request.IsAuthenticated)
                    {
                        Response.Redirect("..\\UI_Reporting\\ReportViewer.aspx?ReturnURL=" + HttpUtility.UrlEncode(HttpContext.Current.Request.Url.AbsoluteUri)); // dont forget to use urlencode
                    }
                }
                else
                {
                    ht.Clear();
                    this.lblMessage.Text = "Nothing Found!!";
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
            catch (Exception ex)
            {
                this.lblMessage.Text = ex.Message.ToString();
                this.lblMessage.ForeColor = Color.White;
            }
        }

        protected void btnBack_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("..\\UI_Gateway\\CompanyList.aspx");
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                //if (GetPermission[3].ToString() == "True")
                //{
                Hashtable ht = new Hashtable();
                if (IsValid())
                {
                    Int32 typePrimary;
                    Int32 UnderGroup;
                    string typeGroup;

                    if (chkGrpNature.Checked)
                    {
                        typePrimary = 1;
                        UnderGroup = 0;
                        typeGroup = cmbNature.Text;
                    }
                    else
                    {
                        typePrimary = 0;
                        UnderGroup = Convert.ToInt32(cmbCategoryGroup_Parent.SelectedValue);
                        typeGroup = "0";
                    }
                    //Group Setup-------------------------------
                    ht.Add("Group_Name", txtGroupName.Text);
                    ht.Add("Under_ID", UnderGroup);
                    ht.Add("Primary", typePrimary);
                    ht.Add("Group_Type", typeGroup);
                    ht.Add("Edit_User", Edit_User);
                    ht.Add("Company_Code", CompanyCode);
                    ht.Add("OCode", OCode);

                    bool status = objGrp_BL.Save_GroupHead(ht);
                    if (status == true)
                    {
                        ht.Clear();
                        GetParentGroupList();
                        messagePanel.Visible = true;
                        messagePanel.BackColor = Color.Green;
                        this.lblMessage.ForeColor = Color.White;
                        this.lblMessage.Text = "Group Created Successfully.";
                        txtGroupName.Text = string.Empty;
                    }
                    else
                    {
                        ht.Clear();
                        messagePanel.Visible = true;
                        this.lblMessage.Text = "Group Creation Failed!!";
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

        protected void btnAdd_Click(object sender, ImageClickEventArgs e)
        {
            GetParentGroup();
            mpeAjax.Show();
        }
    }
}
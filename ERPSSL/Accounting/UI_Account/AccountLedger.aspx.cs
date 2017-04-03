using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using System.Collections;
using System.Data;
using Financial_MgtSystem_BLL;
using Financial_MgtSystem_BOL;
using Financial_MgtSystem_BLL.CommonUtilities;

namespace ERPSSL.Accounting.UI_Account
{
    public partial class AccountLedger : System.Web.UI.Page
    {
        leg_Ledgers_BLL objLed_BLL = new leg_Ledgers_BLL();
        grp_GroupHead_BLL objGrp_BL = new grp_GroupHead_BLL();
        cmp_CompanyProject_BLL objCmp_DAL = new cmp_CompanyProject_BLL();
        leg_Ledgers_BLL objLeg_BLL = new leg_Ledgers_BLL();
        rpt_Ledgers_BLL objLedr_BLL = new rpt_Ledgers_BLL();
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
                PageID = "5";
                Edit_User = Session["UserID"].ToString();
                CompanyCode = Session["CompanyCode"].ToString();
                OCode = Session["OCode"].ToString();

                 //GetPermission = objCommon.Permission(RoleID, PageID, OCode);
                //[0]CanVisit//[1]CanEdit//[2]CanDelete//[3]CanExecute
                //if (GetPermission[0].ToString() == "True")
                //{
                if (!IsPostBack)
                {
                    GetLedgerList();
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
                Response.Redirect("..\\..\\Default.aspx");
            }
        }

        protected void btnSearch_Click(object sender, ImageClickEventArgs e)
        {
            //if (GetPermission[3].ToString() == "True")
            //{
            if (LedgerSearch.Text != null)
            {
                GetLedgerList(LedgerSearch.Text.Trim());
            }
            else
            {
                GetLedgerList();
            }
            //}
            //else
            //{
            //    ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "User Permission", "alert('You don't have permission to access this page!!)');", true);
            //    HttpContext.Current.Response.Redirect("..\\UI_Utilities\\DeniedPage.aspx");
            //}
        }
        private void GetLedgerList(string SearchKey)
        {
            Hashtable ht = new Hashtable();
            ht.Add("Search_Key", SearchKey);
            ht.Add("Company_Code", CompanyCode);
            ht.Add("OCode", OCode);

            DataTable dt = objLed_BLL.SearchLedger(ht);
            if (dt.Rows.Count > 0)
            {
                dtg_list.DataSource = dt;
                dtg_list.DataBind();
            }
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
        private void GetLedgerList()
        {
            Hashtable ht = new Hashtable();

            ht.Add("Company_Code", CompanyCode);
            ht.Add("OCode", OCode);

            DataTable dt = objLed_BLL.GetLedgerList(ht);
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
                GetLedgerList();
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
            this.GetLedgerList();
            //}
            //else
            //{
            //    ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "User Permission", "alert('You don't have permission to access this page!!)');", true);
            //    HttpContext.Current.Response.Redirect("..\\UI_Utilities\\DeniedPage.aspx");
            //}
        }

        protected void dtg_list_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            Hashtable ht = new Hashtable();

            Label IndexID = (Label)dtg_list.Rows[e.RowIndex].FindControl("lblLedger_Code");
            string LedgerCode = Convert.ToString(IndexID.Text);

            TextBox Ledger_Name = (TextBox)dtg_list.Rows[e.RowIndex].FindControl("txtLedger_Name");
            string LedgerName = Convert.ToString(Ledger_Name.Text);

            DropDownList ddlGroup = (DropDownList)dtg_list.Rows[e.RowIndex].FindControl("cmbCategoryGroup");
            string Group_Name = Convert.ToString(ddlGroup.SelectedItem.Text);
            Int32 Under_ID = Convert.ToInt32(ddlGroup.SelectedValue);


            ht.Add("Ledger_Code", LedgerCode);
            ht.Add("Ledger_Name", LedgerName);
            ht.Add("Under_ID", Under_ID);
            ht.Add("Group_Name", Group_Name);
            ht.Add("CompanyCode", CompanyCode);
            ht.Add("OCode", OCode);
            objLed_BLL.UpdateLedger(ht);

            dtg_list.EditIndex = -1;
            this.GetLedgerList();

        }

        protected void dtg_list_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            dtg_list.EditIndex = -1;
            this.GetLedgerList();
        }
        protected void dtg_list_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            //if (GetPermission[2].ToString() == "True")
            //{
            Hashtable ht = new Hashtable();

            Label IndexID = (Label)dtg_list.Rows[e.RowIndex].FindControl("lblLedger_Code");
            string LedgerCode = Convert.ToString(IndexID.Text);

            ht.Add("Ledger_Code", LedgerCode);
            ht.Add("CompanyCode", CompanyCode);
            ht.Add("OCode", OCode);
            objLed_BLL.DeleteLedger(ht);

            dtg_list.EditIndex = -1;
            this.GetLedgerList();
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
            DropDownList ddl = null;
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                ddl = e.Row.FindControl("cmbCategoryGroup") as DropDownList;
            }
            if (ddl != null)
            {
                Hashtable ht = new Hashtable();

                ht.Add("Company_Code", CompanyCode);
                ht.Add("OCode", OCode);

                DataTable dt = objGrp_BL.GetGroupheadList(ht);
                if (dt.Rows.Count > 0)
                {
                    ddl.DataSource = dt;
                    ddl.DataValueField = "Group_ID";
                    ddl.DataTextField = "Group_Name";
                    ddl.DataBind();
                }
            }
        }
        protected void cmbCategoryGroup_Parent_DataBound(object sender, EventArgs e)
        {
            GetGroupheadType();
            txtLedgerName.Focus();
        }

        protected void cmbCategoryGroup_Parent_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetGroupheadType();
            txtLedgerName.Focus();
            mpeAjax.Show();
        }

        private void GetGroupheadType()
        {
            try
            {
                Hashtable ht = new Hashtable();
                ht.Add("Group_Name", cmbCategoryGroup_Parent.SelectedItem.Text);
                ht.Add("Company_Code", CompanyCode);
                ht.Add("OCode", OCode);
                DataTable dt = objGrp_BL.GetGroupheadType(ht);
                if (dt.Rows.Count > 0)
                {
                    cmbBalanceNature.DataSource = dt;
                    cmbBalanceNature.DataValueField = "Group_ID";
                    cmbBalanceNature.DataTextField = "Group_Type";
                    cmbBalanceNature.DataBind();
                }
            }
            catch (Exception ex)
            {
                this.lblMessage.Text = ex.Message.ToString();
                messagePanel.BackColor = Color.Red;
                this.lblMessage.ForeColor = Color.White;
            }
        }

        private void GetCompanyProjectCurrency()
        {
            try
            {
                Hashtable ht = new Hashtable();
                ht.Add("Company_Code", CompanyCode);
                ht.Add("OCode", OCode);
                DataTable dt = objCmp_DAL.CompanyProjectCurrency(ht);
                if (dt.Rows.Count > 0)
                {
                    //cmbCurrency.DataSource = dt;
                    //cmbCurrency.DataValueField = "Currency_ID";
                    //cmbCurrency.DataTextField = "Currency_Name";
                    //cmbCurrency.DataBind();
                }
            }
            catch (Exception ex)
            {
                this.lblMessage.Text = ex.Message.ToString();
                messagePanel.BackColor = Color.Red;
                this.lblMessage.ForeColor = Color.White;
            }
        }

        private void GetLedgerNumber()
        {
            try
            {
                Hashtable ht = new Hashtable();
                ht.Add("Company_Code", CompanyCode);
                ht.Add("OCode", OCode);
                DataTable dt = objLeg_BLL.GetLedgerNumber(ht);
                if (dt.Rows.Count > 0)
                {
                    txtLedgerNumber.Text = dt.Rows[0]["Ledger_Code"].ToString(); ;
                }
            }
            catch (Exception ex)
            {
                this.lblMessage.Text = ex.Message.ToString();
                messagePanel.BackColor = Color.Red;
                this.lblMessage.ForeColor = Color.White;
            }
        }


        private void clear()
        {
            txtLedgerName.Text = "";
            txtLedgerNumber.Text = "";
            txtLedgerOpeningBal.Text = "0";
        }
        private bool IsValid()
        {
            if (txtLedgerName.Text == string.Empty)
            {
                lblMessage.Text = "Enter Ledger name!!";
                messagePanel.BackColor = Color.Red;
                this.lblMessage.ForeColor = Color.White;
                txtLedgerName.Focus();
                txtLedgerName.BackColor = Color.Khaki;

                return false;
            }

            if (txtLedgerNumber.Text == string.Empty)
            {

                lblMessage.Text = "Enter Ledger Number!!";
                messagePanel.BackColor = Color.Red;
                this.lblMessage.ForeColor = Color.White;
                txtLedgerNumber.Focus();
                txtLedgerNumber.BackColor = Color.Khaki;

                return false;
            }

            if (txtLedgerOpeningBal.Text == string.Empty)
            {
                lblMessage.Text = "Enter Ledger Opening Balance!!";
                messagePanel.BackColor = Color.Red;
                this.lblMessage.ForeColor = Color.White;
                txtLedgerOpeningBal.Focus();
                txtLedgerOpeningBal.BackColor = Color.Khaki;

                return false;
            }

            return true;
        }

        protected void btnClose_Click(object sender, EventArgs e)
        {
            Response.Redirect("..\\UI_Gateway\\CompanyList.aspx");
        }

        protected void btnGrpList_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("..\\UI_Account\\AccountLedgerList.aspx");
        }

        protected void btnPrint_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                PrintChartAccount();
            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.Message.ToString();
                lblMessage.ForeColor = Color.White;
            }
        }

        private void PrintChartAccount()
        {
            try
            {
                Hashtable ht = new Hashtable();
                string rptCriteria = "All Records";
                ht.Add("Company_Code", CompanyCode);
                ht.Add("OCode", OCode);

                DataTable dt = objLedr_BLL.Rpt_GetChartAccount(ht);
                if (dt.Rows.Count != 0)
                {
                    Session["ReportTitle"] = "Accounting Ledger";
                    Session["ReportCriteria"] = rptCriteria;
                    Session["OrganizationDetails"] = GlobalClass_BOL.Company_Name;
                    Session["OrganizationAddress"] = GlobalClass_BOL.Street_1;
                    Session["OrganizationContact"] = GlobalClass_BOL.Phone;
                    Session["DatePrint"] = String.Format("{0:MMMM dd, yyyy}", DateTime.Now.Date);

                    Session["rptDs"] = "ds_ChartOfAccount";
                    Session["rptDt"] = dt;
                    Session["rptFile"] = "..\\UI_ReportsFile\\ChartOfAccount.rdlc";
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
            }
            catch (Exception ex)
            {
                this.lblMessage.Text = ex.Message.ToString();
                messagePanel.BackColor = Color.Red;
                this.lblMessage.ForeColor = Color.White;
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                Hashtable ht = new Hashtable();
                if (IsValid())
                {
                    ht.Add("Ledger_Code", txtLedgerNumber.Text);
                    ht.Add("Ledger_Name", txtLedgerName.Text);
                    ht.Add("Opening_Balance", Convert.ToDouble(txtLedgerOpeningBal.Text));
                    ht.Add("Opening_Nature", cmbBalanceNature.SelectedItem.Text);
                    ht.Add("Under_ID", Convert.ToInt64(cmbCategoryGroup_Parent.SelectedValue));
                    ht.Add("Group_Name", cmbCategoryGroup_Parent.SelectedItem.Text);

                    ht.Add("Edit_User", Edit_User);
                    ht.Add("Company_Code", CompanyCode);
                    ht.Add("OCode", OCode);

                    int status = objLeg_BLL.Save_Ledger(ht);
                    if (status == 1)
                    {
                        ht.Clear();
                        GetLedgerList();
                        clear();
                        messagePanel.Visible = true;
                        lblMessage.Text = "Ledger Created Successfully.";
                        messagePanel.BackColor = Color.Green;
                        this.lblMessage.ForeColor = Color.White;
                    }
                    else if (status == 5)
                    {
                        ht.Clear();
                        messagePanel.Visible = true;
                        this.lblMessage.Text = "Ledger Name and Code both Conflict!!";
                        messagePanel.BackColor = Color.Red;
                        this.lblMessage.ForeColor = Color.White;
                    }
                    else if (status == 4)
                    {
                        ht.Clear();
                        messagePanel.Visible = true;
                        this.lblMessage.Text = "Ledger Name Conflict!!";
                        messagePanel.BackColor = Color.Red;
                        this.lblMessage.ForeColor = Color.White;
                    }
                    else if (status == 3)
                    {
                        ht.Clear();
                        messagePanel.Visible = true;
                        this.lblMessage.Text = "Ledger Code Conflict!!";
                        messagePanel.BackColor = Color.Red;
                        this.lblMessage.ForeColor = Color.White;
                    }
                    else
                    {
                        ht.Clear();
                        messagePanel.Visible = true;
                        this.lblMessage.Text = "Ledger Creation Failed!!";
                        messagePanel.BackColor = Color.Red;
                        this.lblMessage.ForeColor = Color.White;
                    }
                }
            }
            catch (Exception ex)
            {
                this.lblMessage.Text = ex.Message.ToString();
                messagePanel.BackColor = Color.Red;
                this.lblMessage.ForeColor = Color.White;
            }
        }

        protected void btnAdd_Click(object sender, ImageClickEventArgs e)
        {
            GetParentGroup();
            //GetCompanyProjectCurrency();
            GetLedgerNumber();
            mpeAjax.Show();
        }

        protected void btnBack_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("..\\UI_Account\\AccountGroupList.aspx");
        }

        protected void LedgerSearch_TextChanged(object sender, EventArgs e)
        {
            if (LedgerSearch.Text != null)
            {
                GetLedgerList(LedgerSearch.Text.Trim());
            }
            else
            {
                GetLedgerList();
            }
        }
    }
}
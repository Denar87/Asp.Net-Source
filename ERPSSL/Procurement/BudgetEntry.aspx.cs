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

namespace ERPSSL.Procurement
{
    public partial class BudgetEntry : System.Web.UI.Page
    { 
        leg_Budget_BLL objBdg_BLL = new leg_Budget_BLL();
        cmp_CompanysUser_BLL objUser = new cmp_CompanysUser_BLL();
        Common_BLL objCommon = new Common_BLL();

        string Budgetdate = string.Empty;
        String[] GetPermission = new String[4];
        string RoleID, PageID, Edit_User, CompanyCode, OCode;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["OCode"] != null)
            {
                RoleID = Session["RoleID"].ToString();
                PageID = "31";
                Edit_User = Session["UserID"].ToString();
                CompanyCode = "n/a";
                OCode = Session["OCode"].ToString();

                Budgetdate = String.Format("{0:MM/dd/yyyy}", DateTime.Now);

                //GetPermission = objCommon.Permission(RoleID, PageID, OCode);
                //[0]CanVisit//[1]CanEdit//[2]CanDelete//[3]CanExecute
                //if (GetPermission[0].ToString() == "True")
                //{
                if (!IsPostBack)
                {
                    this.messagePanel.Visible = true;
                    this.lblMessage.Text = "Choose a Year to Create/View Budget!!";
                    this.lblMessage.ForeColor = Color.White;
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


        protected void btnAdd_Click(object sender, ImageClickEventArgs e)
        {
            //if (GetPermission[3].ToString() == "True")
            //{
            CreateBudget();
            //}
            //else
            //{
            //    ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "User Permission", "alert('You don't have permission to access this page!!)');", true);
            //    HttpContext.Current.Response.Redirect("..\\UI_Utilities\\DeniedPage.aspx");
            //}
        }

        private void CreateBudget()
        {
            try
            {
                Hashtable ht = new Hashtable();
                ht.Add("Budget_Year", dtpTo.Text.ToString());
                ht.Add("Edit_User", Session["UserID"].ToString());
                ht.Add("Company_Code", CompanyCode);
                ht.Add("OCode", OCode);
                DataTable dt = objBdg_BLL.Create_Budget(ht);
                if (dt.Rows.Count > 0)
                {
                    dtg_list.DataSource = dt;
                    dtg_list.DataBind();
                }
                this.lblMessage.Text = dtpTo.Text + " Budget Created!! Update Ledger to Save Changes!!";
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

        protected void btnPrint_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                //if (GetPermission[3].ToString() == "True")
                //{

                //}
                //else
                //{

                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "User Permission", "alert('You don't have permission to access this page!!)');", true);
                HttpContext.Current.Response.Redirect("..\\UI_Utilities\\DeniedPage.aspx");
                //}
            }
            catch (Exception ex)
            {
                this.lblMessage.Text = ex.Message.ToString();
                this.lblMessage.ForeColor = Color.White;
            }
        }

        protected void dtg_list_RowEditing(object sender, GridViewEditEventArgs e)
        {
            try
            {
                //if (GetPermission[3].ToString() == "True")
                //{
                dtg_list.EditIndex = e.NewEditIndex;
                this.CreateBudget();
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

        protected void dtg_list_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                //if (GetPermission[1].ToString() == "True")
                //{
                string Budget_Year = dtpTo.Text.ToString();

                Label IndexID = (Label)dtg_list.Rows[e.RowIndex].FindControl("lblLedger_Code");
                string Ledger_Code = Convert.ToString(IndexID.Text);
                Label IndexBudget = (Label)dtg_list.Rows[e.RowIndex].FindControl("lblBudget_Code");
                string Budget_Code = Convert.ToString(IndexBudget.Text);
                TextBox txtMonth_Jan = (TextBox)dtg_list.Rows[e.RowIndex].FindControl("txtMonth_Jan");
                string Jan = Convert.ToString(txtMonth_Jan.Text);
                TextBox txtMonth_Feb = (TextBox)dtg_list.Rows[e.RowIndex].FindControl("txtMonth_Feb");
                string Feb = Convert.ToString(txtMonth_Feb.Text);
                TextBox txtMonth_Mar = (TextBox)dtg_list.Rows[e.RowIndex].FindControl("txtMonth_Mar");
                string Mar = Convert.ToString(txtMonth_Mar.Text);
                TextBox txtMonth_Apr = (TextBox)dtg_list.Rows[e.RowIndex].FindControl("txtMonth_Apr");
                string Apr = Convert.ToString(txtMonth_Apr.Text);
                TextBox txtMonth_May = (TextBox)dtg_list.Rows[e.RowIndex].FindControl("txtMonth_May");
                string May = Convert.ToString(txtMonth_May.Text);
                TextBox txtMonth_Jun = (TextBox)dtg_list.Rows[e.RowIndex].FindControl("txtMonth_Jun");
                string Jun = Convert.ToString(txtMonth_Jun.Text);
                TextBox txtMonth_Jul = (TextBox)dtg_list.Rows[e.RowIndex].FindControl("txtMonth_Jul");
                string Jul = Convert.ToString(txtMonth_Jul.Text);
                TextBox txtMonth_Aug = (TextBox)dtg_list.Rows[e.RowIndex].FindControl("txtMonth_Aug");
                string Aug = Convert.ToString(txtMonth_Aug.Text);
                TextBox txtMonth_Sep = (TextBox)dtg_list.Rows[e.RowIndex].FindControl("txtMonth_Sep");
                string Sep = Convert.ToString(txtMonth_Sep.Text);
                TextBox txtMonth_Oct = (TextBox)dtg_list.Rows[e.RowIndex].FindControl("txtMonth_Oct");
                string Oct = Convert.ToString(txtMonth_Oct.Text);
                TextBox txtMonth_Nov = (TextBox)dtg_list.Rows[e.RowIndex].FindControl("txtMonth_Nov");
                string Nov = Convert.ToString(txtMonth_Nov.Text);
                TextBox txtMonth_Dec = (TextBox)dtg_list.Rows[e.RowIndex].FindControl("txtMonth_Dec");
                string Dec = Convert.ToString(txtMonth_Dec.Text);

                Hashtable ht = new Hashtable();
                ht.Add("Ledger_Code", Ledger_Code);
                ht.Add("Budget_Code", Budget_Code);
                ht.Add("Budget_Year", Budget_Year);
                ht.Add("Jan", Jan);
                ht.Add("Feb", Feb);
                ht.Add("Mar", Mar);
                ht.Add("Apr", Apr);
                ht.Add("May", May);
                ht.Add("Jun", Jun);
                ht.Add("Jul", Jul);
                ht.Add("Aug", Aug);
                ht.Add("Sep", Sep);
                ht.Add("Oct", Oct);
                ht.Add("Nov", Nov);
                ht.Add("Dec", Dec);
                ht.Add("Edit_User", Edit_User);
                ht.Add("Company_Code", CompanyCode);
                ht.Add("OCode", OCode);

                int result = objBdg_BLL.Update_Budget(ht);
                if (result == 1)
                {
                    dtg_list.EditIndex = -1;
                    this.CreateBudget();
                    this.lblMessage.Text = dtpTo.Text + " Budget Updated!!";
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

        protected void dtg_list_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            try
            {
                dtg_list.EditIndex = -1;
                this.CreateBudget();
            }
            catch (Exception ex)
            {
                this.lblMessage.Text = ex.Message.ToString();
                this.lblMessage.ForeColor = Color.White;
            }
        }
    }
}
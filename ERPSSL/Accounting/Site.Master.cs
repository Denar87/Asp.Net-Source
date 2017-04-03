using Financial_MgtSystem_BLL;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ERPSSL.Accounting
{
    public partial class Site : System.Web.UI.MasterPage
    {
        vch_Voucher_BLL objVch = new vch_Voucher_BLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["PageAction"] = "";
            if ((Session["UserID"] == null) && (Session["CompanyCode"] == null))
            {
                Response.Redirect("Default.aspx");
            }
            else
            {
                if (!IsPostBack)
                {
                    GetVoucherNotification();
                }
                if (Session["PageAction"].ToString() == "New")
                {
                    menuPanel.Visible = false;
                }
                this.lblUser.Text = Convert.ToString(Session["UserFullName"]);
            } 
        }

        private void GetVoucherNotification()
        {
            try
            {
                Hashtable ht = new Hashtable();
                ht.Add("CompanyCode", Session["CompanyCode"]);
                ht.Add("OCode", Session["OCode"]);

                DataTable dt = objVch.GetVoucherNotification(ht);
                if (dt.Rows.Count > 0)
                {
                    LabelNotify.Text = dt.Rows[0]["NoVoucher"].ToString();
                }
                else
                {
                    ht.Clear();
                    
                }
            }
            catch (Exception ex)
            {
               
            }
        }
        protected void lbtnLogout_Click(object sender, EventArgs e)
        {
            this.lbtnLogout.Text = "Please wait...";
            this.lbtnLogout.ForeColor = System.Drawing.Color.Red;
            Session.Abandon();
            Session.Clear();
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Logout", "setInterval(function(){location.href='../../Default.aspx';},3000);", true);
        }
    }
}
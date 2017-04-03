using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ERPSSL.INV.BLL;
using ERPSSL.INV.DAL;

namespace ERPSSL.INV
{
    public partial class DamageFromStoreList : System.Web.UI.Page
    {
        PriceAndDamage damage = new PriceAndDamage();
        IChallanBLL ic = new IChallanBLL();
        StoreBLL aStoreBll = new StoreBLL();
        public static DataTable stCompany = new DataTable();
        public static string CentralCode = "";
        public static string CompanyType = "";
        Inv_StoreBLL companyBll = new Inv_StoreBLL();
        BuyCentralBLL _BuyCentral = new BuyCentralBLL();
        private ERPSSL_INVEntities _context = new ERPSSL_INVEntities();
        RChallanBLL rChallanBll = new RChallanBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Session["UserID"] != null) && (Session["OCode"] != null))
            {
                if (!Page.IsPostBack)
                {

                    stCompany = companyBll.GetCentralCompany();
                    foreach (DataRow dr in stCompany.Rows)
                    {
                        CentralCode = dr["CompanyCode"].ToString();
                        CompanyType = dr["CompanyType"].ToString();
                    }
                    GetReturn();
                    txtDate.Text = DateTime.Today.ToShortDateString();
                }
            }
            else
            {
                Response.Redirect("..\\AppGateway\\Login.aspx");
            }
        }
        public void GetReturn()
        {
            string OCode = ((SessionUser)Session["SessionUser"]).OCode;
            var result = ic.GetDataInv_Damage(OCode);
            if (result.Count > 0)
            {
                grdDamage.DataSource = result.ToList();
                grdDamage.DataBind();
            }
            else
            {
                grdDamage.DataSource = null;
                grdDamage.DataBind();
            }

        }

        protected void btnConfirm_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtDate.Text == "")
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Insert Form Date')", true);
                    return;
                }
                if (txtTodate.Text == "")
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Insert To Date')", true);
                    return;
                }
                string OCode = ((SessionUser)Session["SessionUser"]).OCode;
                var result = ic.GetDataInv_DamageDateWise(txtDate.Text.ToString(), txtTodate.Text.ToString());
                if (result.Count > 0)
                {
                    grdDamage.DataSource = result.ToList();
                    grdDamage.DataBind();
                }
                else
                {
                    grdDamage.DataSource = null;
                    grdDamage.DataBind();
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }
    }
}
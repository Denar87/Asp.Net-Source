using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using Financial_MgtSystem_BLL;
using System.Data;
using System.Drawing;
using Financial_MgtSystem_BOL;
using Financial_MgtSystem_BLL.CommonUtilities;
using System.Text.RegularExpressions;
using System.Globalization;
using System.Threading;

namespace ERPSSL.Accounting.UI_Gateway
{
    public partial class CompanyList : System.Web.UI.Page
    {
        cmp_CompanyProject_BLL objCmp_BL = new cmp_CompanyProject_BLL();
        cmp_CompanysUser_BLL objUser = new cmp_CompanysUser_BLL();
        Common_BLL objCommon = new Common_BLL();

        String[] GetPermission = new String[4];
        string RoleID, PageID, Edit_User, OCode;
        string actionFrm, rootPage;

        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Session["UserID"] != null) && (Session["OCode"] != null))
            {
                actionFrm = Request.QueryString["action"];
                Session["CompanyCode"] = null;

                if (actionFrm == "close")
                {
                    GlobalClass_BOL.CompanyCode = null;
                    Session["CompanyCode"] = null;
                    HttpContext.Current.Response.Redirect("CompanyList.aspx");
                }

                if (!IsPostBack)
                {
                    GetCompany();
                    BindCountry();
                    this.lblUser.Text = Convert.ToString(Session["UserFullName"]);

                    if (Session["CompanyCode"] != null)
                    {
                        HttpContext.Current.Response.Redirect("Index.aspx");
                    }
                }
            }
            else
            {
                HttpContext.Current.Response.Redirect("..\\..\\Default.aspx");
            }
        }
        private void BindCountry()
        {
            try
            {
                cmbCountry.DataSource = CountryList();
                cmbCountry.DataBind();
            }
            catch (Exception ex)
            {
                this.lblMessage.Text = ex.Message.ToString();
                this.messagePanel.BackColor = Color.Red;
            }
        }
        protected void txtCurrencyName_TextChanged(object sender, EventArgs e)
        {
            try
            {
                CultureInfo cultureInfo = Thread.CurrentThread.CurrentCulture;
                TextInfo textInfo = cultureInfo.TextInfo;
                string CurrencyCode = textInfo.ToUpper(txtCurrencyName.Text);
                txtCurrencySymbol.Text = getCurrencySymbol(CurrencyCode);
                mpeAjax.Show();
            }
            catch (Exception ex)
            {
                this.lblMessage.Text = ex.Message.ToString();
                this.messagePanel.BackColor = Color.Red;
            }
        }

        public string getCurrencySymbol(string CurrencyCode)
        {
            string symbol = string.Empty;
            CultureInfo[] cultures = CultureInfo.GetCultures(CultureTypes.SpecificCultures);
            IList Result = new ArrayList();
            foreach (CultureInfo ci in cultures)
            {
                RegionInfo ri = new RegionInfo(ci.LCID);
                if (ri.ISOCurrencySymbol == CurrencyCode)
                {
                    symbol = ri.CurrencySymbol;
                    return symbol;
                }
            }
            return symbol;
        }

        public static List<string> CountryList()
        {
            List<string> CultureList = new List<string>();
            CultureInfo[] getCultureInfo = CultureInfo.GetCultures(CultureTypes.SpecificCultures);

            foreach (CultureInfo getCulture in getCultureInfo)
            {
                RegionInfo GetRegionInfo = new RegionInfo(getCulture.LCID);
                if (!(CultureList.Contains(GetRegionInfo.EnglishName)))
                {
                    CultureList.Add(GetRegionInfo.EnglishName);
                }
            }

            CultureList.Sort();
            return CultureList;
        }

        private void GetCompany()
        {
            try
            {
                Hashtable ht = new Hashtable();
                ht.Add("OCode", Session["OCode"]);
                DataTable dt = objCmp_BL.GetCompanyList(ht);

                if (dt.Rows.Count > 0)
                {
                    RepterDetails.DataSource = dt;
                    RepterDetails.DataBind();
                }
                else
                {
                    mpeAjax.Show();
                    //HttpContext.Current.Response.Redirect("..\\UI_Setup\\ProjectSetup.aspx?action=new");
                }

            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.Message.ToString();
                lblMessage.ForeColor = Color.Maroon;
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

        protected void btnSave_Click(object sender, EventArgs e)
        {
            Hashtable ht = new Hashtable();
            if (IsValid())
            {
                //Company Setup-------------------------------
                ht.Add("Company_Name", txtCompanyName.Text);
                ht.Add("Street_1", txtAddress.Text);
                ht.Add("Street_2", txtAddress.Text);
                ht.Add("City", txtCity.Text);
                ht.Add("Zip_Code", txtZip.Text);
                ht.Add("Country", cmbCountry.SelectedItem.Text);
                ht.Add("Phone", txtPhone.Text);
                ht.Add("E_mail", txtEmail.Text);
                ht.Add("Web_Site", txtWebsite.Text);
                ht.Add("Financial_Year", Convert.ToDateTime(dtpFinancialYearFrom.Text));
                ht.Add("Book_Begning", Convert.ToDateTime(dtpBookYear.Text));
                ht.Add("Create_Date", Convert.ToDateTime(DateTime.Now));
                //Currency Setup-------------------------------
                ht.Add("Currency_Symbol", txtCurrencySymbol.Text);
                ht.Add("Currency_Name", txtCurrencyName.Text);
                ht.Add("Abbreviation", "");
                ht.Add("Sub_Currency", txtSubCurrency.Text);
                ht.Add("Decimal_Place", nudDecimalPlace.Text);
                //----------------------------------------------
                ht.Add("Edit_User", Session["UserID"]);
                ht.Add("OCode", Session["OCode"]);

                bool status = objCmp_BL.CreateCompanyProject(ht);
                if (status == true)
                {
                    ht.Clear();
                    GetCompany();
                }
                else
                {
                    ht.Clear();
                    messagePanel.BackColor = Color.Red;
                    this.lblMessage.ForeColor = Color.White;
                    this.lblMessage.Text = "Company Creation Failed!!";
                    mpeAjax.Show();
                }
            }
        }
        private bool IsValid()
        {
            if (txtCompanyName.Text == string.Empty)
            {
                lblMessage.Text = "Enter Company name!!";
                messagePanel.BackColor = Color.Red;
                this.lblMessage.ForeColor = Color.White;
                txtCompanyName.Focus();
                txtCompanyName.BackColor = Color.Khaki;
                mpeAjax.Show();
                return false;
            }

            if (txtAddress.Text == string.Empty)
            {
                lblMessage.Text = "Enter Company Address!!";
                messagePanel.BackColor = Color.Red;
                this.lblMessage.ForeColor = Color.White;
                txtAddress.Focus();
                txtAddress.BackColor = Color.Khaki;
                mpeAjax.Show();
                return false;
            }

            if (txtPhone.Text == string.Empty)
            {
                lblMessage.Text = "Enter Company Phone!!";
                messagePanel.BackColor = Color.Red;
                this.lblMessage.ForeColor = Color.White;
                txtPhone.Focus();
                txtPhone.BackColor = Color.Khaki;
                mpeAjax.Show();
                return false;
            }

            if (txtEmail.Text == string.Empty)
            {
                lblMessage.Text = "Enter a Valid Email Id!";
                messagePanel.BackColor = Color.Red;
                this.lblMessage.ForeColor = Color.White;
                txtEmail.Focus();
                txtEmail.BackColor = Color.Khaki;
                mpeAjax.Show();
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
                mpeAjax.Show();
                return false;
            }

            if (txtCurrencySymbol.Text == string.Empty)
            {
                lblMessage.Text = "Enter Currency Symbol!";
                messagePanel.BackColor = Color.Red;
                this.lblMessage.ForeColor = Color.White;
                txtCurrencySymbol.Focus();
                txtCurrencySymbol.BackColor = Color.Khaki;
                mpeAjax.Show();
                return false;
            }

            if (txtCurrencyName.Text == string.Empty)
            {
                lblMessage.Text = "Enter Currency Name!";
                messagePanel.BackColor = Color.Red;
                this.lblMessage.ForeColor = Color.White;
                txtCurrencyName.Focus();
                txtCurrencyName.BackColor = Color.Khaki;
                mpeAjax.Show();
                return false;
            }

            return true;
        }

        protected void RepterDetails_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "ClickCompany")
                {
                    Session["CompanyCode"] = e.CommandArgument.ToString();
                    if (Session["CompanyCode"] != null)
                    {
                        Response.Redirect("Index.aspx");
                    }
                }

                if (e.CommandName == "EditProject")
                {
                    Session["CompanyCode"] = e.CommandArgument.ToString();
                    if (Session["CompanyCode"] != null)
                    {
                        mpeAjax.Show();
                    }
                }

                if (e.CommandName == "BkpProject")
                {
                    Session["CompanyCode"] = e.CommandArgument.ToString();
                    if (Session["CompanyCode"] != null)
                    {

                    }
                }

                if (e.CommandName == "DeleteProject")
                {
                    Session["CompanyCode"] = e.CommandArgument.ToString();
                    if (Session["CompanyCode"] != null)
                    {
                        Hashtable ht = new Hashtable();
                        ht.Add("OCode", Session["OCode"].ToString());
                        ht.Add("CompanyCode", Session["CompanyCode"].ToString());
                        ht.Add("Edit_User", Session["UserID"].ToString());
                        objCmp_BL.DeleteProject(ht);
                        GetCompany();
                    }
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.Message.ToString();
                lblMessage.ForeColor = Color.Maroon;
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            mpeAjax.Show();
        }
    }
}
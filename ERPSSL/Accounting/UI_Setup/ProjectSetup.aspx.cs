using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using System.Globalization;
using Financial_MgtSystem_BLL;
using System.Collections;
using System.Data;
using Financial_MgtSystem_BOL;
using System.Text.RegularExpressions;
using System.Threading;
using Financial_MgtSystem_BLL.CommonUtilities;

namespace ERPSSL.Accounting.UI_Setup
{
    public partial class ProjectSetup : System.Web.UI.Page
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
                RoleID = Session["RoleID"].ToString();
                PageID = "18";
                Edit_User = Session["UserID"].ToString();
                OCode = Session["OCode"].ToString();

                 //GetPermission = objCommon.Permission(RoleID, PageID, OCode);
                //[0]CanVisit//[1]CanEdit//[2]CanDelete//[3]CanExecute
                //if (GetPermission[0].ToString() == "True")
                //{

                //}
                //else
                //{
                //    ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "User Permission", "alert('You don't have permission to access this page!!)');", true);
                //    HttpContext.Current.Response.Redirect("..\\UI_Utilities\\DeniedPage.aspx");
                //}

                if (!IsPostBack)
                {
                    BindCountry();
                    GetCompanyDetails();
                }
            }
            else
            {
                Response.Redirect("..\\..\\Default.aspx");
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

        private bool IsValid()
        {
            if (txtCompanyName.Text == string.Empty)
            {
                lblMessage.Text = "Enter Company name!!";
                messagePanel.BackColor = Color.Red;
                this.lblMessage.ForeColor = Color.White;
                txtCompanyName.Focus();
                txtCompanyName.BackColor = Color.Khaki;
                return false;
            }

            if (txtAddress.Text == string.Empty)
            {
                lblMessage.Text = "Enter Company Address!!";
                messagePanel.BackColor = Color.Red;
                this.lblMessage.ForeColor = Color.White;
                txtAddress.Focus();
                txtAddress.BackColor = Color.Khaki;
                txtAddress.BackColor = Color.Khaki;
                return false;
            }

            if (txtPhone.Text == string.Empty)
            {
                lblMessage.Text = "Enter Company Phone!!";
                messagePanel.BackColor = Color.Red;
                this.lblMessage.ForeColor = Color.White;
                txtPhone.Focus();
                txtPhone.BackColor = Color.Khaki;
                txtPhone.BackColor = Color.Khaki;
                return false;
            }

            if (txtEmail.Text == string.Empty)
            {
                lblMessage.Text = "Enter a Valid Email Id!";
                messagePanel.BackColor = Color.Red;
                this.lblMessage.ForeColor = Color.White;
                txtEmail.Focus();
                txtEmail.BackColor = Color.Khaki;
                txtEmail.BackColor = Color.Khaki;
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
                txtEmail.BackColor = Color.Khaki;
                return false;
            }

            if (txtCurrencySymbol.Text == string.Empty)
            {
                lblMessage.Text = "Enter Currency Symbol!";
                messagePanel.BackColor = Color.Red;
                this.lblMessage.ForeColor = Color.White;
                txtCurrencySymbol.Focus();
                txtCurrencySymbol.BackColor = Color.Khaki;
                return false;
            }

            if (txtCurrencyName.Text == string.Empty)
            {
                lblMessage.Text = "Enter Currency Name!";
                messagePanel.BackColor = Color.Red;
                this.lblMessage.ForeColor = Color.White;
                txtCurrencyName.Focus();
                txtCurrencyName.BackColor = Color.Khaki;
                return false;
            }

            return true;
        }

        private void GetCompanyDetails()
        {
            try
            {
                Hashtable ht = new Hashtable();
                if ((actionFrm == "details") || (actionFrm == "update"))
                {
                    btnSubmit.Enabled = true;

                    ht.Add("CompanyCode", Session["CompanyCode"]);
                    ht.Add("OCode", Session["OCode"]);

                    DataTable dt = objCmp_BL.CompanyProjectDetails(ht);
                    if (dt.Rows.Count > 0)
                    {
                        txtCompanyName.Text = dt.Rows[0]["Company_Name"].ToString();
                        txtAddress.Text = dt.Rows[0]["Street_1"].ToString();
                        txtCity.Text = dt.Rows[0]["City"].ToString();
                        txtZip.Text = dt.Rows[0]["Zip_Code"].ToString();
                        cmbCountry.Text = dt.Rows[0]["Country"].ToString();
                        txtPhone.Text = dt.Rows[0]["Phone"].ToString();
                        txtEmail.Text = dt.Rows[0]["E_mail"].ToString();
                        txtWebsite.Text = dt.Rows[0]["Web_Site"].ToString();
                        dtpFinancialYearFrom.Text = String.Format("{0:MM/dd/yyyy}", dt.Rows[0]["Financial_Year"]);
                        dtpBookYear.Text = String.Format("{0:MM/dd/yyyy}", dt.Rows[0]["Book_Begning"]);

                        txtCurrencyName.Text = dt.Rows[0]["Currency_Name"].ToString();
                        txtCurrencySymbol.Text = dt.Rows[0]["Currency_Symbol"].ToString();
                        txtSubCurrency.Text = dt.Rows[0]["Sub_Currency"].ToString();
                        nudDecimalPlace.Text = dt.Rows[0]["Decimal_Place"].ToString();
                    }
                    else
                    {
                        ht.Clear();
                        this.lblMessage.Text = "Data retrival failed!!";
                        this.lblMessage.ForeColor = Color.White;
                        messagePanel.BackColor = Color.Red;
                    }
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.Message.ToString();
                messagePanel.BackColor = Color.Red;
                this.lblMessage.ForeColor = Color.White;
            }
        }

        protected void btnPrint_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void btnBack_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("..\\UI_Gateway\\CompanyList.aspx");
        }

        protected void btnSubmit_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                //if (GetPermission[3].ToString() == "True")
                //{
                Hashtable ht = new Hashtable();
                if (actionFrm == "new")
                {
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
                            Response.Redirect("..\\UI_Gateway\\CompanyList.aspx");
                        }
                        else
                        {
                            ht.Clear();
                            messagePanel.BackColor = Color.Red;
                            this.lblMessage.ForeColor = Color.White;
                            this.lblMessage.Text = "Company Creation Failed!!";
                        }
                    }
                }
                //------------update------------------
                if (actionFrm == "details")
                {
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
                        //Currency Setup-------------------------------
                        ht.Add("Currency_Symbol", txtCurrencySymbol.Text);
                        ht.Add("Currency_Name", txtCurrencyName.Text);
                        ht.Add("Sub_Currency", txtSubCurrency.Text);
                        ht.Add("Decimal_Place", nudDecimalPlace.Text);
                        //----------------------------------------------
                        ht.Add("Edit_User", Session["UserID"]);
                        ht.Add("OCode", Session["OCode"]);
                        ht.Add("CompanyCode", Session["CompanyCode"]);
                        ht.Add("UserID", Session["UserID"]);
                        ht.Add("PublicIP", Session["PublicIP"]);

                        int status = objCmp_BL.UpdateCompanyProjectDetails(ht);
                        if (status == 1)
                        {
                            ht.Clear();
                            this.messagePanel.Visible = true;
                            this.messagePanel.BackColor = Color.Green;
                            this.lblMessage.ForeColor = Color.White;
                            this.lblMessage.Text = "Company Updated Successfully.";
                        }
                        else
                        {
                            ht.Clear();
                            this.messagePanel.Visible = true;
                            this.messagePanel.BackColor = Color.Red;
                            this.lblMessage.ForeColor = Color.White;
                            this.lblMessage.Text = "Company Update Failed!!";
                        }

                        GetCompanyDetails();
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
                this.messagePanel.Visible = true;
                this.lblMessage.Text = ex.Message.ToString();
                messagePanel.BackColor = Color.Red;
                this.lblMessage.ForeColor = Color.White;
            }
        }
    }
}
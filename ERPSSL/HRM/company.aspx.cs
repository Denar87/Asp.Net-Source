using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ERPSSL.HRM.DAL;
using ERPSSL.HRM.BLL;
using ERPSSL.HRM.BLL;

namespace ERPSSL.HRM
{
    public partial class company : System.Web.UI.Page
    {
        CompanyBLL companyBll = new CompanyBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Session["UserID"] != null) && (Session["OCode"] != null))
            {
                if (!IsPostBack)
                {
                    getCompanyInfo();
                }
            }
            else
            {
                Response.Redirect("..\\AppGateway\\Login.aspx");
            }
        }
        private void getCompanyInfo()
        {
            try
            {
                string OCODE = Convert.ToString(((SessionUser)Session["SessionUser"]).OCode);
                List<HRM_Company> companys = companyBll.GetCompnay(OCODE);
                if (companys.Count > 0)
                {
                    gridviewCompany.DataSource = companys;
                    gridviewCompany.DataBind();
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void btnCompany_Click(object sender, EventArgs e)
        {
            try
            {
                HttpPostedFile file = (HttpPostedFile)(FileUpload1.PostedFile);
                int iFileSize = file.ContentLength;
                if ((FileUpload1.HasFile) && (iFileSize > 200000))  // 1MB approx (actually less though)
                {
                    //  string myStringAlert = " File is too big!! Max file size 100kb!!! Please Resize !!!!";
                    //   lblMessage.Text = myStringAlert;
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('File is too big!! Max file size 100kb!!! Please Resize !!!!')", true);
                    return;
                }
                else
                {
                    HRM_Company companyObj = new HRM_Company();
                    companyObj.Name = txtbxName.Text;
                    companyObj.Mobile = txtbxMobileNo.Text;
                    companyObj.Phone = txtbxPhoneNo.Text;
                    companyObj.Email = txtbxEmail.Text;
                    companyObj.Fax = txtbxFax.Text;
                    companyObj.Address = txtbxAddress.Text;
                    companyObj.Web = txtbxWebSite.Text;
                    companyObj.AreaCode = txtAreaCode.Text;
                    companyObj.REGDate = Convert.ToDateTime( txtRegDate.Text);
                    companyObj.REGNo = txtRegNo.Text;
                    companyObj.ERCDate = Convert.ToDateTime( txtERCDate.Text);
                    companyObj.ERCNo = txtErcNo.Text;
                    companyObj.Logo = FileUpload1.FileBytes;

                    if (btnCompany.Text == "Submit")
                    {
                        companyObj.EDIT_DATE = DateTime.Now;
                        companyObj.EDIT_USER = ((SessionUser)Session["SessionUser"]).UserId;
                        companyObj.OCODE = Convert.ToString(((SessionUser)Session["SessionUser"]).OCode);

                        int result = companyBll.InsertCompany(companyObj);
                        if (result == 1)
                        {
                            //  lblMessage.Text = "Data Save Successfully";
                            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Data Save Successfully')", true);
                            getCompanyInfo();
                        }
                    }
                    else
                    {
                        int comapnyId = Convert.ToInt16(hidCompanyId.Value);
                        int result = companyBll.UpdateCompany(companyObj, comapnyId);
                        if (result == 1)
                        {
                            // lblMessage.Text = "Update Save Successfully";
                            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Data Update Successfully')", true);
                            getCompanyInfo();
                            string OCODE = Convert.ToString(((SessionUser)Session["SessionUser"]).OCode);
                            GlobalClass.CompanyId = hidCompanyId.Value;
                            Emp_IMG_TRNS.ImageUrl = "CompanyLogo.ashx?pId=" + GlobalClass.CompanyId + "&oCode=" + OCODE;
                        }
                    }
                    ClearAllControl();
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

        private void ClearAllControl()
        {

            txtbxName.Text = "";
            txtbxMobileNo.Text = "";
            txtbxPhoneNo.Text = "";
            txtbxEmail.Text = "";
            txtbxFax.Text = "";
            txtbxAddress.Text = "";
            txtbxWebSite.Text = "";
            btnCompany.Text = "Submit";

        }

        protected void imgbtnCompanyEdit_Click(object sender, EventArgs e)
        {
            List<HRM_Company> comapnys = new List<HRM_Company>();
            ImageButton imgbtn = (ImageButton)sender;
            GridViewRow row = (GridViewRow)imgbtn.NamingContainer;

            try
            {
                string companyId = "";
                Label lblCompanyId = (Label)gridviewCompany.Rows[row.RowIndex].FindControl("lblCompanyId");
                if (lblCompanyId != null)
                {
                    // string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                    string OCODE = Convert.ToString(((SessionUser)Session["SessionUser"]).OCode);
                    companyId = lblCompanyId.Text;
                    comapnys = companyBll.GetcompanyInfoIdandOcode(companyId, OCODE);

                    if (comapnys.Count > 0)
                    {
                        foreach (HRM_Company acompany in comapnys)
                        {
                            hidCompanyId.Value = acompany.CompanyId.ToString();
                            txtbxName.Text = acompany.Name;
                            txtbxEmail.Text = acompany.Email;
                            txtbxMobileNo.Text = acompany.Mobile;
                            txtbxFax.Text = acompany.Fax;
                            txtbxPhoneNo.Text = acompany.Phone;
                            txtbxAddress.Text = acompany.Address;
                            txtbxWebSite.Text = acompany.Web;
                            txtErcNo.Text = acompany.ERCNo;
                            txtERCDate.Text = acompany.ERCDate.ToString();
                            txtRegDate.Text = acompany.REGDate.ToString();
                            txtRegNo.Text = acompany.REGNo;
                            txtAreaCode.Text = acompany.AreaCode;

                        }
                        if (btnCompany.Text == "Submit")
                        {
                            btnCompany.Text = "Update";
                        }
                        GlobalClass.CompanyId = hidCompanyId.Value;
                        Emp_IMG_TRNS.ImageUrl = "CompanyLogo.ashx?pId=" + GlobalClass.CompanyId + "&oCode=" + OCODE;
                    }

                }

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

        protected void gridviewCompany_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridviewCompany.PageIndex = e.NewPageIndex;
            getCompanyInfo();
        }
    }
}
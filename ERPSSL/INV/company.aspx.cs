using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ERPSSL.INV.DAL;
using ERPSSL.INV.BLL;

namespace ERPSSL.INV
{
    public partial class company : System.Web.UI.Page
    {
        CompanyBLL companyBll = new CompanyBLL();
        DistrictBll districtBll = new DistrictBll();
        private ERPSSL_INVEntities _context = new ERPSSL_INVEntities();

        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Session["UserID"] != null) && (Session["OCode"] != null))
            {
                if (!IsPostBack)
                {
                    getCompanyInfo();
                    GetAllDistrict();
                    //ddlCompanyType.Enabled = true;
                    txtStoreCode.ReadOnly = false;
                }
            }
            else
            {
                Response.Redirect("..\\AppGateway\\Login.aspx");
            }
        }

        protected void GetAllDistrict()
        {
            try
            {


                var row = districtBll.GetAllDistrict();
                if (row.Count > 0)
                {
                    ddlDistrict.DataSource = row.ToList();
                    ddlDistrict.DataTextField = "DistrictName";
                    ddlDistrict.DataValueField = "Id";
                    ddlDistrict.DataBind();
                    ddlDistrict.AppendDataBoundItems = false;
                    ddlDistrict.Items.Insert(0, new ListItem("Select One", "0"));
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void getCompanyInfo()
        {
            try
            {
                //string OCODE = "8989";
                string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                List<Inv_Company> companys = companyBll.GetCompnay(OCODE);
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
                string OCODE = ((SessionUser)Session["SessionUser"]).OCode;

                HttpPostedFile file = (HttpPostedFile)(FileUpload1.PostedFile);

                int iFileSize = file.ContentLength;
                if ((FileUpload1.HasFile) && (iFileSize > 20000000))  // 1MB approx (actually less though)
                {
                    //string myStringAlert = " File is too big!! Max file size 100kb!!! Please Resize !!!!";
                    //lblMessage.Text = myStringAlert;
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('File is too big!! Max file size 100kb!!! Please Resize !!!!')", true);
                    return;
                }

                else
                {
                    Inv_Company companyObj = new Inv_Company();
                    companyObj.CompanyCode = txtStoreCode.Text;
                    companyObj.CompanyName = txtbxName.Text;
                    companyObj.ContactPerson = txtContactPerson.Text;
                    //companyObj.CompanyType = ddlCompanyType.SelectedItem.Text.Trim();
                    companyObj.CompanyType = "CENTRAL";
                    companyObj.Address = txtbxAddress.Text;
                    companyObj.DistrictId = Convert.ToInt32(ddlDistrict.SelectedValue);
                    companyObj.Phone = txtbxPhoneNo.Text;
                    companyObj.Mobile = txtbxMobileNo.Text;
                    companyObj.Fax = txtbxFax.Text;
                    companyObj.Email = txtbxEmail.Text;
                    companyObj.Web = txtbxWebSite.Text;
                    companyObj.Logo = FileUpload1.FileBytes;

                    if (btnCompany.Text == "Submit")
                    {
                        //if (ddlCompanyType.SelectedItem.ToString() == "CENTRAL")
                        //{
                        //    companyObj.OCODE = OCODE;
                        //}
                        //else
                        //{
                        //    companyObj.OCODE = companyBll.GetCountOcodeNo(ddlCompanyType.SelectedItem.ToString());
                        //}

                        //if (ddlCompanyType.SelectedItem.ToString() == "CENTRAL")
                        //{
                        //    var checkcentral = companyBll.GetCheckCentralStore(OCODE, "CENTRAL");
                        //    if (checkcentral.Count > 0)
                        //    {
                        //        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Central Store Already Exist!')", true);
                        //        return;
                        //    }
                        //}

                        companyObj.EDIT_DATE = DateTime.Now;
                        //companyObj.EDIT_USER = Guid.Parse("a376708d-757f-4777-bd05-bfc89b6971ce");
                        companyObj.OCODE = OCODE;
                        companyObj.EDIT_USER = ((SessionUser)Session["SessionUser"]).UserId;

                        int Storecount = (from store in _context.Inv_Company
                                          where store.CompanyCode == companyObj.CompanyCode
                                          select store.CompanyId).Count();
                        if (Storecount == 0)
                        {
                            int result = companyBll.InsertCompany(companyObj);
                            if (result == 1)
                            {
                                //lblMessage.Text = "Data Saved Successfully";
                                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Data Saved Successfully')", true);
                                getCompanyInfo();
                                ClearAllControl();
                            }
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Store Code Can Not Be Same!')", true);
                            txtStoreCode.Text = "";
                            txtStoreCode.Focus();
                        }
                    }
                    else
                    {
                        int comapnyId = Convert.ToInt16(hidCompanyId.Value);

                        int result = companyBll.UpdateCompany(companyObj, comapnyId);
                        if (result == 1)
                        {
                            //lblMessage.Text = "Data Updated Successfully";
                            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Data Updated Successfully')", true);
                            getCompanyInfo();

                            GlobalClass.CompanyId = hidCompanyId.Value;
                            Emp_IMG_TRNS.ImageUrl = "CompanyLogo.ashx?pId=" + GlobalClass.CompanyId + "&oCode=" + OCODE;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

        private void ClearAllControl()
        {
            txtStoreCode.Text = "";
            txtbxName.Text = "";
            txtContactPerson.Text = "";
            txtbxMobileNo.Text = "";
            txtbxPhoneNo.Text = "";
            txtbxEmail.Text = "";
            txtbxFax.Text = "";
            txtbxAddress.Text = "";
            ddlDistrict.SelectedValue = "0";
            txtbxWebSite.Text = "";
            btnCompany.Text = "Submit";
            //ddlCompanyType.Enabled = true;
            txtStoreCode.ReadOnly = false;
        }

        protected void imgbtnCompanyEdit_Click(object sender, EventArgs e)
        {
            lblMessage.Text = "";
            List<Inv_Company> comapnys = new List<Inv_Company>();
            ImageButton imgbtn = (ImageButton)sender;
            GridViewRow row = (GridViewRow)imgbtn.NamingContainer;

            try
            {
                string companyId = "";
                Label lblCompanyId = (Label)gridviewCompany.Rows[row.RowIndex].FindControl("lblCompanyId");
                if (lblCompanyId != null)
                {
                    string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                    //string OCODE = "8989";
                    companyId = lblCompanyId.Text;
                    comapnys = companyBll.GetcompanyInfoIdandOcode(companyId, OCODE);

                    if (comapnys.Count > 0)
                    {
                        foreach (Inv_Company acompany in comapnys)
                        {
                            hidCompanyId.Value = acompany.CompanyId.ToString();
                            txtStoreCode.Text = acompany.CompanyCode;
                            txtbxName.Text = acompany.CompanyName;
                            txtContactPerson.Text = acompany.ContactPerson;
                            txtbxEmail.Text = acompany.Email;
                            txtbxMobileNo.Text = acompany.Mobile;
                            txtbxFax.Text = acompany.Fax;
                            txtbxPhoneNo.Text = acompany.Phone;
                            txtbxAddress.Text = acompany.Address;
                            ddlDistrict.SelectedValue = Convert.ToString(acompany.DistrictId);
                            txtbxWebSite.Text = acompany.Web;
                            //ddlCompanyType.SelectedItem.Text = acompany.CompanyType;
                            //ddlCompanyType.Enabled = false;
                            txtStoreCode.ReadOnly = true;
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
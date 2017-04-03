using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ERPSSL.HRM.DAL;
using ERPSSL.HRM.BLL;
using ERPSSL.HRM.DAL.Repository;
//using ERPSSL.HRM.BLL;

namespace ERPSSL.HRM
{
    public partial class SubCompany : System.Web.UI.Page
    {
        CompanyBLL companyBll = new CompanyBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Session["UserID"] != null) && (Session["OCode"] != null))
            {
                if (!IsPostBack)
                {
                    getSubCompanyInfo();
                    getMainCompany();
                }
            }
            else
            {
                Response.Redirect("..\\AppGateway\\Login.aspx");
            }
        }

        private void getMainCompany()
        {
            string OCODE = Convert.ToString(((SessionUser)Session["SessionUser"]).OCode);
            var row = companyBll.getMainCompany(OCODE);
            if (row.Count > 0)
            {
                ddlCompany.DataSource = row.ToList();
                ddlCompany.DataTextField = "Name";
                ddlCompany.DataValueField = "CompanyId";
                ddlCompany.DataBind();
                ddlCompany.Items.Insert(0, new ListItem("---Select One---"));
            }
        }
      
        
        private void getSubCompanyInfo()
        {
            try
            {
                string OCODE = Convert.ToString(((SessionUser)Session["SessionUser"]).OCode);
                List<Company> suncompanys = new List<Company>();
                suncompanys = companyBll.GetSubCompnay(OCODE).ToList();
                if (suncompanys.Count > 0)
                {
                    gridviewSubCompany.DataSource = suncompanys;
                    gridviewSubCompany.DataBind();
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

                //HttpPostedFile file = (HttpPostedFile)(FileUpload1.PostedFile);
                //int iFileSize = file.ContentLength;
                //if ((FileUpload1.HasFile) && (iFileSize > 200000))  // 1MB approx (actually less though)
                //{
                //    //  string myStringAlert = " File is too big!! Max file size 100kb!!! Please Resize !!!!";
                //    //   lblMessage.Text = myStringAlert;
                //    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('File is too big!! Max file size 100kb!!! Please Resize !!!!')", true);
                //    return;
                //}

                //else
                //{
                HRM_SubCompany subcompanyObj = new HRM_SubCompany();

                subcompanyObj.CompanyId = Convert.ToInt32(ddlCompany.SelectedValue);
                subcompanyObj.SubCompanyName = txtSubCompanyName.Text;
                subcompanyObj.SubCompanyCode = txtSubCompanyCode.Text;
                subcompanyObj.SubCompanyAddress = txtbxAddress.Text;
                subcompanyObj.EDIT_DATE = DateTime.Now;
                subcompanyObj.EDIT_USER = ((SessionUser)Session["SessionUser"]).UserId;
                subcompanyObj.OCODE = Convert.ToString(((SessionUser)Session["SessionUser"]).OCode);

                    if (btnCompany.Text == "Submit")
                    {  
                        int result = companyBll.InsertSubCompany(subcompanyObj);
                        if (result == 1)
                        {
                            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Data Save Successfully')", true);
                           
                        }
                    }
                    else
                    {
                        int scomapnyId = Convert.ToInt16(hidSubCompanyId.Value);
                        int result = companyBll.UpdateSubCompany(subcompanyObj, scomapnyId);
                        if (result == 1)
                        {
                           
                            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Data Update Successfully')", true);
                            
                            //string OCODE = Convert.ToString(((SessionUser)Session["SessionUser"]).OCode);
                            //GlobalClass.CompanyId = hidCompanyId.Value;
                            //Emp_IMG_TRNS.ImageUrl = "CompanyLogo.ashx?pId=" + GlobalClass.CompanyId + "&oCode=" + OCODE;
                        }
                    }
                    getSubCompanyInfo();
                    ClearAllControl();
                //}
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void ClearAllControl()
        {

            txtSubCompanyName.Text = "";
            txtSubCompanyCode.Text = "";
            ddlCompany.ClearSelection();
            txtbxAddress.Text = "";
            btnCompany.Text = "Submit";

        }

        protected void imgbtnSubCompanyEdit_Click(object sender, ImageClickEventArgs e)
        {
            List<HRM_SubCompany> subcompanys = new List<HRM_SubCompany>();
            ImageButton imgbtn = (ImageButton)sender;
            GridViewRow row = (GridViewRow)imgbtn.NamingContainer;

            try
            {
                string subcompanyId = "";
                Label lblSubCompany_Id = (Label)gridviewSubCompany.Rows[row.RowIndex].FindControl("lblSubCompany_Id");
                if (lblSubCompany_Id != null)
                {
                    // string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                    string OCODE = Convert.ToString(((SessionUser)Session["SessionUser"]).OCode);
                    subcompanyId = lblSubCompany_Id.Text;
                    subcompanys = companyBll.GetSubcompanyInfoIdandOcode(subcompanyId, OCODE);

                    if (subcompanys.Count > 0)
                    {
                        foreach (HRM_SubCompany asubcompany in subcompanys)
                        {
                            hidSubCompanyId.Value = asubcompany.CompanyId.ToString();
                            ddlCompany.SelectedValue = Convert.ToString(asubcompany.CompanyId);
                            txtSubCompanyName.Text = asubcompany.SubCompanyName;
                            txtSubCompanyCode.Text = asubcompany.SubCompanyCode;
                            txtbxAddress.Text = asubcompany.SubCompanyAddress;


                        }
                        if (btnCompany.Text == "Submit")
                        {
                            btnCompany.Text = "Update";
                        }
                        //GlobalClass.CompanyId = hidCompanyId.Value;
                        //Emp_IMG_TRNS.ImageUrl = "CompanyLogo.ashx?pId=" + GlobalClass.CompanyId + "&oCode=" + OCODE;
                    }

                }

            }
            catch (Exception ex)
            {

                throw;
            }
        }
        protected void gridviewCompany_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridviewSubCompany.PageIndex = e.NewPageIndex;
            getSubCompanyInfo();
        }
    }
}
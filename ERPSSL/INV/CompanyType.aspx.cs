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
    public partial class CompanyType : System.Web.UI.Page
    {
        
        private ERPSSL_INVEntities _context = new ERPSSL_INVEntities();
        CompanyTypeBLL aCompanyTypeBLL = new CompanyTypeBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetAllCompanyType();
            }
        }

        private void GetAllCompanyType()
        {
            try
            {
                List<Inv_CompanyType> CType = aCompanyTypeBLL.GetAllCompanyType();
                if (CType.Count > 0)
                {
                    grdCompanyType.DataSource = CType;
                    grdCompanyType.DataBind();
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {

                Inv_CompanyType aCompanyType = new Inv_CompanyType();

                aCompanyType.CompanyType = txtCopmayType.Text;  
               
                if (btnSubmit.Text == "Submit")
                {
                    int CompanyTypeCount = (from CType in _context.Inv_CompanyType
                                            where CType.CompanyType == aCompanyType.CompanyType
                                            select CType.CompanyType_Id).Count();

                    aCompanyType.EditUser = ((SessionUser)Session["SessionUser"]).UserId;
                    aCompanyType.OCode = ((SessionUser)Session["SessionUser"]).OCode;
                    aCompanyType.EditDate = DateTime.Now;

                    if (CompanyTypeCount == 0)
                    {
                        int result = aCompanyTypeBLL.InsertCompanyType(aCompanyType);
                        if (result == 1)
                        {
                            //lblMessage.Text = "Data Saved Successfully";
                           // lblMessage.ForeColor = System.Drawing.Color.Green;
                            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Data Saved Successfully')", true); 
                            GetAllCompanyType();
                            txtCopmayType.Text = "";
                           
                        }
                        else
                        {
                           // lblMessage.Text = "Data Saving Failure";
                           // lblMessage.ForeColor = System.Drawing.Color.Red;
                            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Data Saving Failure')", true); 
                        }
                    }
                    else
                    {
                       // lblMessage.Text = "Data Already Exist";
                        //lblMessage.ForeColor = System.Drawing.Color.Red;
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Data Already Exist')", true);
                        txtCopmayType.Focus();
                        txtCopmayType.Text = "";
                        btnSubmit.Text = "Submit";
                    }
                }
                else
                {
                    int ID = Convert.ToInt32(hdfCompanyTypeID.Value);

                    int result = aCompanyTypeBLL.UpdateCompanyType(aCompanyType, ID);
                    if (result == 1)
                    {
                       // lblMessage.Text = "Data Updated Sucessfully";
                       // lblMessage.ForeColor = System.Drawing.Color.Green;
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Data Updated Sucessfully')", true);
                        GetAllCompanyType();
                        txtCopmayType.Text = "";
                        btnSubmit.Text = "Submit";
                    }
                    else
                    {
                        //lblMessage.Text = "Data Updating failure";
                        //lblMessage.ForeColor = System.Drawing.Color.Red;
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Data Updating failure')", true);
                    }
                }
              


            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }


        protected void ImgEdit_Click(object sender, EventArgs e)
        {
            lblMessage.Text = "";
            List<Inv_CompanyType> CType = new List<Inv_CompanyType>();
            ImageButton imgbtn = (ImageButton)sender;
            GridViewRow row = (GridViewRow)imgbtn.NamingContainer;

            try
            {
                string ID = "";
                Label lblId = (Label)grdCompanyType.Rows[row.RowIndex].FindControl("lblId");
                if (lblId != null)
                {
                    ID = lblId.Text;
                    CType = aCompanyTypeBLL.GetCTypeId(ID);

                    if (CType.Count > 0)
                    {
                        foreach (Inv_CompanyType aCType in CType)
                        {
                            hdfCompanyTypeID.Value = aCType.CompanyType_Id.ToString();
                            txtCopmayType.Text = aCType.CompanyType;

                        }
                        if (btnSubmit.Text == "Submit")
                        {
                            btnSubmit.Text = "Update";
                        } 
                    }

                }

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }

        }

        protected void grdCompanyType_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdCompanyType.PageIndex = e.NewPageIndex;
            GetAllCompanyType();
        }

    }
}
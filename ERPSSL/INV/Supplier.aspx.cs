using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ERPSSL.INV.DAL;
using ERPSSL.INV.BLL;
using ERPSSL.INV.DAL.Repository;

namespace ERPSSL.INV
{
    public partial class Supplier : System.Web.UI.Page
    {
        SupplierBLL supplierBll = new SupplierBLL();
        DistrictBll districtBll = new DistrictBll();
        private ERPSSL_INVEntities _context = new ERPSSL_INVEntities();

        protected void Page_Load(object sender, EventArgs e)
        {

            if ((Session["UserID"] != null) && (Session["OCode"] != null))
            {
                if (!IsPostBack)
                {
                    GetSupplierInfo();
                    GetAllDistrict();
                    GetSupplierInfoEnlisted();
                    GetAllLocation();
                    txtLocation.Visible = false;
                }
            }
            else
            {
                Response.Redirect("..\\AppGateway\\Login.aspx");
            }
        }
        protected void GetAllLocation()
        {
            try
            {
                string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                var row = supplierBll.GetSupplierLocation(OCODE);
                if (row != null)
                {
                    ddlLocation.DataSource = row.ToList();
                    ddlLocation.DataTextField = "Location";
                    ddlLocation.DataValueField = "Location";
                    ddlLocation.DataBind();
                    ddlLocation.AppendDataBoundItems = false;
                    ddlLocation.Items.Insert(0, new ListItem("Select One", "0"));
                }
                else
                {
                    ddlLocation.SelectedItem.Text = "--Select one--";
                }

            }
            catch (Exception ex)
            {
                throw ex;
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
        private void GetSupplierInfo()
        {
            try
            {
                string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                //string OCODE = "8989";
                List<Inv_Supplier> suppliers = supplierBll.GetSupplier(OCODE);
                if (suppliers.Count > 0)
                {
                    gridviewSupplier.DataSource = suppliers;
                    gridviewSupplier.DataBind();
                }
                else
                {
                    gridviewSupplier.DataSource = null;
                    gridviewSupplier.DataBind();
                }

            }
            catch (Exception)
            {

                throw;
            }
        }
        private void GetSupplierInfoEnlisted()
        {
            try
            {
                string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                //string OCODE = "8989";
                List<Inv_Supplier> suppliers = supplierBll.GetSupplierEnlistedTrue(OCODE);
                if (suppliers.Count > 0)
                {
                    gridEnlistedTrue.DataSource = suppliers;
                    gridEnlistedTrue.DataBind();
                }
                else
                {
                    gridEnlistedTrue.DataSource = null;
                    gridEnlistedTrue.DataBind();
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        private void ClearAllControl()
        {
            txtSupplierCode.Text = "";
            txtSupplierName.Text = "";
            txtContactPerson.Text = "";
            txtPhone.Text = "";
            txtEmail.Text = "";
            //txtPerformance.Text = "";
            txtbxAddress.Text = "";
            ddlDistrict.SelectedValue = "0";
            //ddlSupplierType.SelectedValue = "0";
            btnSupplier.Text = "Submit";
            //txtEntryDate.Text = string.Empty;
            //txtCreditDays.Text = "";
            ddlStatus.SelectedValue = "0";
            txtSupplierName.Focus();
            txtLocation.Text = "";
            ddlLocation.ClearSelection();

        }

        protected void imgbtnSupplierEdit_Click(object sender, EventArgs e)
        {
            
            ImageButton imgbtn = (ImageButton)sender;
            GridViewRow row = (GridViewRow)imgbtn.NamingContainer;

            try
            {
                
                 Label lblSupplierId = (Label)gridviewSupplier.Rows[row.RowIndex].FindControl("lblSupplierId");
                Label lblSupplierName = (Label)gridviewSupplier.Rows[row.RowIndex].FindControl("lblSupplierName");
                Label lblSupplierCode = (Label)gridviewSupplier.Rows[row.RowIndex].FindControl("lblSupplierCode");
                Label lblAddress = (Label)gridviewSupplier.Rows[row.RowIndex].FindControl("lblAddress");
                Label lblDistrict = (Label)gridviewSupplier.Rows[row.RowIndex].FindControl("lblDistrict");
                Label lblLocation = (Label)gridviewSupplier.Rows[row.RowIndex].FindControl("lblLocation");
                Label lblContactPerson = (Label)gridviewSupplier.Rows[row.RowIndex].FindControl("lblContactPerson");
                Label lblContactNo = (Label)gridviewSupplier.Rows[row.RowIndex].FindControl("lblContactNo");
                Label lblEmail = (Label)gridviewSupplier.Rows[row.RowIndex].FindControl("lblEmail");
                Label lblStatus = (Label)gridviewSupplier.Rows[row.RowIndex].FindControl("lblStatus");
                hidSupplierId.Value = lblSupplierId.Text;
                txtSupplierName.Text=lblSupplierName.Text;
                txtSupplierCode.Text=lblSupplierCode.Text;
                txtbxAddress.Text=lblAddress.Text;
                ddlDistrict.SelectedValue=lblDistrict.Text;
                ddlLocation.SelectedValue=lblLocation.Text;
                txtLocation.Text=lblLocation.Text;
                txtContactPerson.Text=lblContactPerson.Text;
                txtPhone.Text=lblContactNo.Text;
                txtEmail.Text=lblEmail.Text;
                ddlStatus.SelectedIndex=2;
                //if (ddlStatus.SelectedValue=="true")
                //{
                //    ddlStatus.SelectedValue = "By Enlisted";
                //}
                //else
                //{
                //    ddlStatus.SelectedValue = ;
                //}
                      
                            btnSupplier.Text = "Update";
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

        protected void btnSupplier_Click(object sender, EventArgs e)
        {
            try
            {

                Inv_Supplier supplierObj = new Inv_Supplier();
                supplierObj.SupplierCode = txtSupplierCode.Text;
                supplierObj.SupplierName = txtSupplierName.Text;
                supplierObj.ContactPerson = txtContactPerson.Text;
                //supplierObj.SupplierType = ddlSupplierType.SelectedItem.Text.Trim();
                supplierObj.Address = txtbxAddress.Text;
                supplierObj.DistrictId = Convert.ToInt32(ddlDistrict.SelectedValue);
                supplierObj.Phone = txtPhone.Text;
                supplierObj.EmailAddress = txtEmail.Text;
                supplierObj.EntryDate = DateTime.Now;
                if (chklocation.Checked == true)
                {
                    supplierObj.Location = txtLocation.Text;
                }
                else
                {
                    supplierObj.Location = ddlLocation.SelectedItem.Text.Trim();
                }
                //supplierObj.CreditDays = txtCreditDays.Text;
                //supplierObj.Performance = txtPerformance.Text;
                if (ddlStatus.SelectedItem.Text.Trim() == "By Enlisted")
                {
                    supplierObj.Enlisted = true;
                }
                else
                {
                    supplierObj.Enlisted = false;
                }
                supplierObj.Fired = ddlStatus.SelectedItem.Text.Trim();

                int Suppliercount = (from supl in _context.Inv_Supplier
                                     where supl.SupplierCode == supplierObj.SupplierCode
                                     select supl.Id).Count();

                if (btnSupplier.Text == "Submit")
                {
                    if (Suppliercount == 0)
                    {
                        supplierObj.EditDate = DateTime.Now;
                        //supplierObj.EditUser = Guid.Parse("a376708d-757f-4777-bd05-bfc89b6971ce");
                        supplierObj.EditUser = ((SessionUser)Session["SessionUser"]).UserId;
                        supplierObj.OCode = ((SessionUser)Session["SessionUser"]).OCode;
                        //supplierObj.OCode = "8989";

                        int result = supplierBll.InsertSupplier(supplierObj);
                        if (result == 1)
                        {
                            //lblMessage.Text = "Data Saved Successfully";
                            // lblMessage.ForeColor = System.Drawing.Color.Green;
                            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Data Saved Successfully')", true);

                        }
                        else
                        {
                            //lblMessage.Text = "Data Saving Failure";
                            // lblMessage.ForeColor = System.Drawing.Color.Red;
                            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Data Saving Failure')", true);
                        }
                    }
                    else
                    {
                        //lblMessage.Text = "Data Already Exist";
                        // lblMessage.ForeColor = System.Drawing.Color.Red;
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Data Already Exist')", true);
                        txtSupplierCode.Text = "";
                        txtSupplierCode.Focus();
                    }

                }

                else
                {
                    int supplierId = Convert.ToInt16(hidSupplierId.Value);
                    int result = supplierBll.UpdateSupplier(supplierObj, supplierId);
                    if (result == 1)
                    {
                        //  lblMessage.Text = "Data Updated Sucessfully";
                        //  lblMessage.ForeColor = System.Drawing.Color.Green;
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Data Updated Sucessfully')", true);
                    }
                    else
                    {
                        // lblMessage.Text = "Data Updating failure";
                        //  lblMessage.ForeColor = System.Drawing.Color.Red;
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Data Updating failure')", true);
                    }
                    btnSupplier.Text = "Submit";
                }
                GetSupplierInfoEnlisted();
                GetSupplierInfo();
                ClearAllControl();

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

        protected void gridviewSupplier_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridviewSupplier.PageIndex = e.NewPageIndex;
            GetSupplierInfo();
        }

        protected void txtSupplierName_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string clsName = txtSupplierName.Text.Trim();
                string Ocode = ((SessionUser)Session["SessionUser"]).OCode;
                List<Inv_Supplier> suppliers = supplierBll.GetSupplierForSearch(Ocode, clsName);
                if (suppliers.Count > 0)
                {
                    gridviewSupplier.DataSource = suppliers;
                    gridviewSupplier.DataBind();
                }
                //List<DisbursementR> DisbursementList = objdisbursementBLL.GetDisbursementSearch(Ocode, clsName);
                //if (DisbursementList.Count > 0)
                //{
                //    gridviewLoanAgrement.DataSource = DisbursementList;
                //    gridviewLoanAgrement.DataBind();
                //}
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }
        [System.Web.Script.Services.ScriptMethod()]
        [System.Web.Services.WebMethod]
        public static List<string> SearchSupplier(string prefixText, int count)
        {
            using (var _context = new ERPSSL_INVEntities())
            {
                var InsList = from la in _context.Inv_Supplier
                              where la.SupplierName.Contains(prefixText)
                              select la;
                List<String> clsList = new List<String>();
                foreach (var clsName in InsList)
                {
                    clsList.Add(clsName.SupplierName);
                }
                return clsList;
            }
        }

        protected void imgbtnEnlistedEdit_Click(object sender, ImageClickEventArgs e)
        {
            lblMessage.Text = "";
           
            ImageButton imgbtn = (ImageButton)sender;
            GridViewRow row = (GridViewRow)imgbtn.NamingContainer;

            try
            {

                Label lblSupplierId = (Label)gridEnlistedTrue.Rows[row.RowIndex].FindControl("lblSupplierId");
                Label lblSupplierName = (Label)gridEnlistedTrue.Rows[row.RowIndex].FindControl("lblSupplierName");
                Label lblSupplierCode = (Label)gridEnlistedTrue.Rows[row.RowIndex].FindControl("lblSupplierCode");
                Label lblAddress = (Label)gridEnlistedTrue.Rows[row.RowIndex].FindControl("lblAddress");
                Label lblDistrict = (Label)gridEnlistedTrue.Rows[row.RowIndex].FindControl("lblDistrict");
                Label lblLocation = (Label)gridEnlistedTrue.Rows[row.RowIndex].FindControl("lblLocation");
                Label lblContactPerson = (Label)gridEnlistedTrue.Rows[row.RowIndex].FindControl("lblContactPerson");
                Label lblContactNo = (Label)gridEnlistedTrue.Rows[row.RowIndex].FindControl("lblContactNo");
                Label lblEmail = (Label)gridEnlistedTrue.Rows[row.RowIndex].FindControl("lblEmail");
                Label lblStatus = (Label)gridEnlistedTrue.Rows[row.RowIndex].FindControl("lblStatus");
                hidSupplierId.Value = lblSupplierId.Text;
                txtSupplierName.Text = lblSupplierName.Text;
                txtSupplierCode.Text = lblSupplierCode.Text;
                txtbxAddress.Text = lblAddress.Text;
                ddlDistrict.SelectedValue = lblDistrict.Text;
                ddlLocation.SelectedValue = lblLocation.Text;
                txtLocation.Text = lblLocation.Text;
                txtContactPerson.Text = lblContactPerson.Text;
                txtPhone.Text = lblContactNo.Text;
                txtEmail.Text = lblEmail.Text;
                ddlStatus.SelectedIndex = 1;
               

                btnSupplier.Text = "Update";

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }
        protected void chklocation_CheckedChanged(object sender, EventArgs e)
        {
            if (chklocation.Checked == true)
            {
                txtLocation.Visible = true;
                ddlLocation.Visible = false;
            }
            else
            {
                txtLocation.Visible = false;
                ddlLocation.Visible = true;
            }
        }
    }

}
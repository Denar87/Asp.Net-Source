using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ERPSSL.INV.DAL;
using ERPSSL.INV.BLL;

namespace ERPSSL.Procurement
{
    public partial class SupplierEnlishment : System.Web.UI.Page
    {
        SupplierBLL supplierBll = new SupplierBLL();
        DistrictBll districtBll = new DistrictBll();
        private ERPSSL_INVEntities _context = new ERPSSL_INVEntities();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetSupplierInfo();
                GetAllDistrict();
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
                string OCODE = "8989";
                List<Inv_Supplier> suppliers = supplierBll.GetSupplier(OCODE);
                if (suppliers.Count > 0)
                {
                    gridviewSupplier.DataSource = suppliers;
                    gridviewSupplier.DataBind();
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
        }

        protected void imgbtnSupplierEdit_Click(object sender, EventArgs e)
        {
            lblMessage.Text = "";
            List<Inv_Supplier> suppliers = new List<Inv_Supplier>();
            ImageButton imgbtn = (ImageButton)sender;
            GridViewRow row = (GridViewRow)imgbtn.NamingContainer;

            try
            {
                string supplierId = "";
                Label lblSupplierId = (Label)gridviewSupplier.Rows[row.RowIndex].FindControl("lblSupplierId");
                if (lblSupplierId != null)
                {
                    // string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                    string OCODE = "8989";
                    supplierId = lblSupplierId.Text;
                    suppliers = supplierBll.GetSuppierInfoByIdandOcode(supplierId, OCODE);

                    if (suppliers.Count > 0)
                    {
                        foreach (Inv_Supplier asupplier in suppliers)
                        {
                            hidSupplierId.Value = asupplier.Id.ToString();
                            txtSupplierCode.Text = asupplier.SupplierCode;
                            txtSupplierName.Text = asupplier.SupplierName;
                            txtContactPerson.Text = asupplier.ContactPerson;
                            //txtPerformance.Text = asupplier.Performance;
                            //txtCreditDays.Text = asupplier.CreditDays;
                            txtPhone.Text = asupplier.Phone;
                            txtEmail.Text = asupplier.EmailAddress;
                            txtbxAddress.Text = asupplier.Address;
                            ddlDistrict.SelectedValue = Convert.ToString(asupplier.DistrictId);
                            ddlStatus.SelectedValue = asupplier.Fired;
                            //if (asupplier.Enlisted == true)
                            //{
                            //    ddlStatus.SelectedItem.Text = "Yes";
                            //}
                            //else
                            //{
                            //    ddlStatus.SelectedItem.Text = "No";
                            //}

                            //ddlSupplierType.Text = asupplier.SupplierType;
                            //txtEntryDate.Text = Convert.ToString(asupplier.EntryDate);
                        }
                        if (btnSupplier.Text == "Submit")
                        {
                            btnSupplier.Text = "Update";
                        }

                    }

                }

            }
            catch (Exception ex)
            {

                throw ex;
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
                //supplierObj.CreditDays = txtCreditDays.Text;
                //supplierObj.Performance = txtPerformance.Text;
                if (ddlStatus.SelectedItem.Text.Trim() == "Yes")
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
                        supplierObj.EditUser = Guid.Parse("a376708d-757f-4777-bd05-bfc89b6971ce");
                        //supplierObj.EditUser = ((SessionUser)Session["SessionUser"]);
                        supplierObj.OCode = "8989";

                        int result = supplierBll.InsertSupplier(supplierObj);
                        if (result == 1)
                        {
                            lblMessage.Text = "Data Saved Successfully";
                            lblMessage.ForeColor = System.Drawing.Color.Green;

                        }
                        else
                        {
                            lblMessage.Text = "Data Saving Failure";
                            lblMessage.ForeColor = System.Drawing.Color.Red;
                        }
                    }
                    else
                    {
                        lblMessage.Text = "Data Already Exist";
                        lblMessage.ForeColor = System.Drawing.Color.Red;
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
                        lblMessage.Text = "Data Updated Sucessfully";
                        lblMessage.ForeColor = System.Drawing.Color.Green;
                    }
                    else
                    {
                        lblMessage.Text = "Data Updating failure";
                        lblMessage.ForeColor = System.Drawing.Color.Red;
                    }
                }
                GetSupplierInfo();
                ClearAllControl();

            }

            catch (Exception)
            {
                throw;
            }
        }

        protected void gridviewSupplier_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridviewSupplier.PageIndex = e.NewPageIndex;
            GetSupplierInfo();
        }

        protected void txtSupplierName_TextChanged(object sender, EventArgs e)
        {
            lblMessage.Text = "";
        }
    }
}
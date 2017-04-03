using ERPSSL.INV.BLL;
using ERPSSL.INV.DAL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ERPSSL.INV
{
    public partial class Supplierdetails : System.Web.UI.Page
    {
        SupplierBLL supplierBll = new SupplierBLL();
        DistrictBll districtBll = new DistrictBll();
        GroupBLL groupBll = new GroupBLL();
        ProductBLL productBll = new ProductBLL();
        private ERPSSL_INVEntities _context = new ERPSSL_INVEntities();

        string FILE_NAME;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetAllDistrict();
                GetSupplierInfo();
                GetAllGroup();
                GetAllBusinessType();
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
            catch  
            {
               
            }
        }

        protected void GetAllBusinessType()
        {
            try
            {
                var row = districtBll.GetAllBusinessType();
                if (row.Count > 0)
                {
                    ddlBusinessType.DataSource = row.ToList();
                    ddlBusinessType.DataTextField = "CompanyType";
                    ddlBusinessType.DataValueField = "CompanyType_Id";
                    ddlBusinessType.DataBind();
                    ddlBusinessType.AppendDataBoundItems = false;
                    ddlBusinessType.Items.Insert(0, new ListItem("Select One", "0"));
                }
            }
            catch
            {

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

            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void btnSupplier_Click(object sender, EventArgs e)
        {
            try
            {

                Inv_Supplier supplierObj = new Inv_Supplier();
                supplierObj.SupplierCode = txtSupplierCode.Text;
                supplierObj.SupplierName = txtSupplierName.Text;
                //supplierObj.ContactPerson = txtContactPerson.Text;
                //supplierObj.SupplierType = ddlSupplierType.SelectedItem.Text.Trim();
                supplierObj.Address = txtbxAddress.Text;
                supplierObj.DistrictId = Convert.ToInt32(ddlDistrict.SelectedValue);
                supplierObj.Phone = txtPhone.Text;
                supplierObj.EmailAddress = txtEmail.Text;
                supplierObj.EntryDate = DateTime.Now;
                //supplierObj.CreditDays = txtCreditDays.Text;
                //supplierObj.Performance = txtPerformance.Text;
                supplierObj.BusinessType = ddlBusinessType.SelectedValue;
                supplierObj.Supplier_Fax = txtFax.Text;
                supplierObj.Supplier_Mobile = txtMobile.Text;
                supplierObj.Supplier_Remarks = txtSupremarks.Text;

                supplierObj.ContactPerson = txtPerson.Text;
                supplierObj.ContactPerson_Designation = txtdesignation.Text;
                supplierObj.ContactPerson_Email = txtEmailAddress.Text;
                supplierObj.ContactPerson_Fax = txtFax.Text;
                supplierObj.ContactPerson_Mobile = txtmobileNo.Text;
                supplierObj.ContactPerson_Phone = txtPhoneNo.Text;

                supplierObj.Trade_License_No = txtTradelicense.Text;
                supplierObj.Certificate_Incorp = txtCertificateIncorp.Text;
                supplierObj.Tin_No = txtTin.Text;
                supplierObj.Validity = txtValidity.Text;

                supplierObj.Vat = txtVat.Text;
                supplierObj.Incorp_Date = Convert.ToDateTime(txtIncorpDate.Text);
                supplierObj.Business_Capital = txtBusinessCapital.Text;
                supplierObj.Bank_Name = txtBankName.Text;


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
                        //supplierObj.EditUser = Guid.Parse("a376708d-757f-4777-bd05-bfc89b6971ce");
                        supplierObj.EditUser = ((SessionUser)Session["SessionUser"]).UserId;
                        supplierObj.OCode = ((SessionUser)Session["SessionUser"]).OCode;
                        //supplierObj.OCode = "8989";

                        int result = supplierBll.InsertSupplier(supplierObj);
                        if (result == 1)
                        {
                            Session["SupplierCode"] = txtSupplierCode.Text;
                          //  lblMessage.Text = "Data Saved Successfully";
                          //  lblMessage.ForeColor = System.Drawing.Color.Green;
                            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Data Saved Successfully')", true);

                        }
                        else
                        {
                            //lblMessage.Text = "Data Saving Failure";
                            //lblMessage.ForeColor = System.Drawing.Color.Red;
                            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Data Saving Failure')", true);
                        }
                    }
                    else
                    {
                        //lblMessage.Text = "Data Already Exist";
                      //  lblMessage.ForeColor = System.Drawing.Color.Red;
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
                        //lblMessage.Text = "Data Updated Sucessfully";
                        //lblMessage.ForeColor = System.Drawing.Color.Green;
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Data Updated Sucessfully')", true);
                    }
                    else
                    {
                        //lblMessage.Text = "Data Updating failure";
                       // lblMessage.ForeColor = System.Drawing.Color.Red;
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Data Updating failure')", true);
                    }
                }
                GetSupplierInfo();
                ClearAllControl();
                ClearBusinessInfo();
                ClearContactPersoninfo();
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }
        protected void imgbtnSupplierEdit_Click(object sender, EventArgs e)
        {
            //lblMessage.Text = "";
            List<Inv_Supplier> suppliers = new List<Inv_Supplier>();
            ImageButton imgbtn = (ImageButton)sender;
            GridViewRow row = (GridViewRow)imgbtn.NamingContainer;

            try
            {
                string supplierId = "";
                Label lblSupplierId = (Label)gridviewSupplier.Rows[row.RowIndex].FindControl("lblSupplierId");
                if (lblSupplierId != null)
                {
                    string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                    //string OCODE = "8989";
                    supplierId = lblSupplierId.Text;
                    suppliers = supplierBll.GetSuppierInfoByIdandOcode(supplierId, OCODE);

                    if (suppliers.Count > 0)
                    {
                        foreach (Inv_Supplier asupplier in suppliers)
                        {
                            hidSupplierId.Value = asupplier.Id.ToString();
                            txtSupplierCode.Text = asupplier.SupplierCode;
                            txtSupplierName.Text = asupplier.SupplierName;
                            //txtContactPerson.Text = asupplier.ContactPerson;
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
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

        private void ClearAllControl()
        {
            txtSupplierCode.Text = "";
            txtSupplierName.Text = "";
           // txtContactPerson.Text = "";
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
            txtMobile.Text = "";
            txtFax.Text = "";
            txtRemarks.Text = "";
        }
      
        protected void gridviewSupplier_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridviewSupplier.PageIndex = e.NewPageIndex;
            GetSupplierInfo();
        }

        //Business Page Work...........................................

       protected void GetAllGroup()
        {
            try
            {

                var row = groupBll.GetAllGroup();
                if (row.Count > 0)
                {


                    ddlItemgroup.DataSource = row.ToList();
                    ddlItemgroup.DataTextField = "GroupName";
                    ddlItemgroup.DataValueField = "GroupId";
                    ddlItemgroup.DataBind();
                    ddlItemgroup.AppendDataBoundItems = false;
                    ddlItemgroup.Items.Insert(0, new ListItem("Select One", "0"));
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

       public void FillProductName()
       {
           try{
           if (Convert.ToInt32(ddlItemgroup.SelectedValue) > 0)
           {

               ddlItemName.DataSource = productBll.GetProductListByGroup(Convert.ToInt32(ddlItemgroup.SelectedValue));
               //ddlProductName.DataSource = productBll.GetProductByGroup(Convert.ToInt32(ddlProductGroup.SelectedValue));
               ddlItemName.DataValueField = "ProductId";
               ddlItemName.DataTextField = "ProductName";
               ddlItemName.DataBind();
               ddlItemName.Items.Insert(0, new ListItem("Select One", "0"));
           }
           }
           catch (Exception ex)
           {
               ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
           }
       }

       protected void ddlItemgroup_SelectedIndexChanged(object sender, EventArgs e)
       {
           FillProductName();
       }

       protected void txtSupplierName_TextChanged(object sender, EventArgs e)
       {

       }


        //Business Information.........................
      
       //protected void btn_BusinessInfo_Click1(object sender, EventArgs e)
       //{
       //    try
       //    {

       //        Inv_Supplier supplierObj = new Inv_Supplier();
       //        string SupCode = Session["SupplierCode"].ToString();
       //        //supplierObj.SupplierCode = txtSupplierCode.Text;
       //        supplierObj.Trade_License_No = txtTradelicense.Text;
       //        supplierObj.Certificate_Incorp = txtCertificateIncorp.Text;
       //        supplierObj.Tin_No = txtTin.Text;
       //        supplierObj.Validity = txtValidity.Text;
               
       //        supplierObj.Vat = txtVat.Text;
       //        supplierObj.Incorp_Date = Convert.ToDateTime(txtIncorpDate.Text);
       //        supplierObj.Business_Capital = txtBusinessCapital.Text;
       //        supplierObj.Bank_Name = txtBankName.Text;


       //        if (btn_BusinessInfo.Text == "Submit")
       //        {
       //            int result = supplierBll.UpdateBusinessInformation(supplierObj, SupCode);
       //            if (result == 1)
       //            {
       //                lblBusinessmsg.Text = "Data Saved Sucessfully";
       //                lblBusinessmsg.ForeColor = System.Drawing.Color.Green;
       //                //GetBusinessInfo();
       //            }
       //        }
       //        else
       //        { 
       //            int subID =Convert.ToInt32(Session["SupplierID"]);
       //            int result = supplierBll.UpdateBusinessInF(supplierObj, subID);
       //            if (result == 1)
       //            {
       //                lblBusinessmsg.Text = "Data Saved Sucessfully";
       //                lblBusinessmsg.ForeColor = System.Drawing.Color.Green;
       //                //GetBusinessInfo();
       //                ClearBusinessInfo();
       //                btn_BusinessInfo.Text = "Submit";
       //                ClearBusinessInfo();
       //            }
       //        }

       //    }
       //    catch (Exception)
       //    {
       //        throw;
       //    }

       //}
       private void ClearBusinessInfo()
       {
           txtTin.Text = "";
           txtVat.Text = "";
           txtValidity.Text = "";
           txtTradelicense.Text = "";
           txtIncorpDate.Text = "";
           txtBankName.Text = "";
           txtBusinessCapital.Text = "";
           ddlBusinessType.SelectedValue = "0";

       }
       //private void GetBusinessInfo()
       //{
       //    try
       //    {
       //        string SupCode = Session["SupplierCode"].ToString();
       //        string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
       //        //string OCODE = "8989";
       //        List<Inv_Supplier> suppliers = supplierBll.GetBusinessInfromation(SupCode);
       //        if (suppliers.Count > 0)
       //        {
       //            grdBusinessInfo.DataSource = suppliers;
       //            grdBusinessInfo.DataBind();
       //        }

       //    }
       //    catch (Exception)
       //    {

       //        throw;
       //    }
       //}

   


       //protected void imgbtnSupBusinessEdit_Click(object sender, EventArgs e)
       // {
       //     //lblMessage.Text = "";
       //     List<Inv_Supplier> suppliers = new List<Inv_Supplier>();
       //     ImageButton imgbtn = (ImageButton)sender;
       //     GridViewRow row = (GridViewRow)imgbtn.NamingContainer;

       //     try
       //     {
       //         string supplierId = "";
       //         Label lblSupplierId = (Label)grdBusinessInfo.Rows[row.RowIndex].FindControl("lblSubBusinessInfo");
       //         if (lblSupplierId != null)
       //         {
       //             string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
       //             //string OCODE = "8989";
       //             supplierId = lblSupplierId.Text;
       //             Session["SupplierID"] = supplierId;
       //             suppliers = supplierBll.GetBusinessInfobyid(supplierId, OCODE);

       //             if (suppliers.Count > 0)
       //             {
       //                 foreach (Inv_Supplier asupplier in suppliers)
       //                 {
       //                     hidSupplierId.Value = asupplier.Id.ToString();
       //                     txtTradelicense.Text = asupplier.Trade_License_No;
       //                     txtTin.Text = asupplier.Tin_No;
       //                     txtVat.Text = asupplier.Vat;
       //                     txtValidity.Text = asupplier.Validity;
       //                     txtCertificateIncorp.Text = asupplier.Certificate_Incorp;
       //                     txtIncorpDate.Text = asupplier.Incorp_Date.ToString();
       //                     txtBankName.Text = asupplier.Bank_Name;
       //                     txtBusinessCapital.Text = asupplier.Business_Capital;
                            
                            
       //                 }
       //                 if (btn_BusinessInfo.Text == "Submit")
       //                 {
       //                     btn_BusinessInfo.Text = "Update";
       //                 }
       //             }
       //         }
       //     }
       //     catch (Exception ex)
       //     {

       //         throw ex;
       //     }
       // }

       //Contcat person Information Work.......................................................................

       //protected void btnContactPersonSave_Click(object sender, EventArgs e)
       //{
       //    Inv_Supplier supplierObj = new Inv_Supplier();
       //    string SupCode = Session["SupplierCode"].ToString();
       //    supplierObj.ContactPerson = txtPerson.Text;
       //    supplierObj.ContactPerson_Designation = txtdesignation.Text;
       //    supplierObj.ContactPerson_Email = txtEmailAddress.Text;
       //    supplierObj.ContactPerson_Fax = txtFax.Text;
       //    supplierObj.ContactPerson_Mobile = txtmobileNo.Text;
       //    supplierObj.ContactPerson_Phone = txtPhoneNo.Text;

       //    if (btnContactPersonSave.Text == "Submit")
       //    {
       //        int result = supplierBll.UpdateContactpersoninformation(supplierObj, SupCode);
       //        if (result == 1)
       //        {
       //            lblBusinessmsg.Text = "Data Saved Sucessfully";
       //            lblBusinessmsg.ForeColor = System.Drawing.Color.Green;
       //            //GetContactPersonInfo();
       //            ClearContactPersoninfo();
       //        }
       //    }
       //    else
       //    {
       //        int subID = Convert.ToInt32(Session["ConPer_SupplierID"]);
       //        int result = supplierBll.UpdateContactPer(supplierObj,subID);
       //        if (result == 1)
       //        {
       //            lblBusinessmsg.Text = "Data Update Sucessfully";
       //            lblBusinessmsg.ForeColor = System.Drawing.Color.Green;
       //            ClearContactPersoninfo();
       //            btnContactPersonSave.Text = "Submit";
       //        }
       //    }

       //}

       private void ClearContactPersoninfo()
       {
           txtPerson.Text = "";
           txtFax.Text = "";
           txtPhoneNo.Text = "";
           txtmobileNo.Text = "";
           txtdesignation.Text = "";
           txtEmailAddress.Text = "";    
       }

       //private void GetContactPersonInfo()
       //{
       //    try
       //    {
       //        string SupCode = Session["SupplierCode"].ToString();
       //        //string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
       //        //string OCODE = "8989";
       //        List<Inv_Supplier> suppliers = supplierBll.GetContactPerson(SupCode);
       //        if (suppliers.Count > 0)
       //        {

       //            grdContactPerson.DataSource = suppliers;
       //            grdContactPerson.DataBind();
       //        }

       //    }
       //    catch (Exception)
       //    {

       //        throw;
       //    }
       //}

       //protected void imgbtnSupContactPersondit_Click(object sender, EventArgs e)
       // {
       //     //lblMessage.Text = "";
       //     List<Inv_Supplier> suppliers = new List<Inv_Supplier>();
       //     ImageButton imgbtn = (ImageButton)sender;
       //     GridViewRow row = (GridViewRow)imgbtn.NamingContainer;

       //     try
       //     {
                
       //         string supplierId = "";
       //         Label lblSupplierId = (Label)grdContactPerson.Rows[row.RowIndex].FindControl("lblContactperson");
       //         if (lblSupplierId != null)
       //         {
       //             string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
       //             //string OCODE = "8989";
       //             supplierId = lblSupplierId.Text;
       //             Session["ConPer_SupplierID"] = supplierId;
       //             suppliers = supplierBll.GetBusinessInfobyid(supplierId, OCODE);

       //             if (suppliers.Count > 0)
       //             {
       //                 foreach (Inv_Supplier asupplier in suppliers)
       //                 {
       //                     hidSupplierId.Value = asupplier.Id.ToString();
       //                     txtPerson.Text = asupplier.ContactPerson;
       //                     txtFax.Text = asupplier.ContactPerson_Fax;
       //                     txtPhoneNo.Text = asupplier.ContactPerson_Phone;
       //                     txtmobileNo.Text = asupplier.ContactPerson_Mobile;
       //                     txtdesignation.Text = asupplier.ContactPerson_Designation;
       //                     txtEmailAddress.Text = asupplier.ContactPerson_Email;
                            
       //                 }
       //                 if ( btnContactPersonSave.Text== "Submit")
       //                 {
       //                     btnContactPersonSave.Text = "Update";
       //                 }
       //             }
       //         }
       //     }
       //     catch (Exception ex)
       //     {

       //         throw ex;
       //     }
       // }
        
        //Item information work..........................................

       protected void btn_ItemInfo_Click(object sender, EventArgs e)
       {
           try
           {
               Inv_Sup_ItemInfo Supitem = new Inv_Sup_ItemInfo();

               Supitem.GroupId = Convert.ToInt32(ddlItemgroup.SelectedValue);
               Supitem.ProductId = Convert.ToInt32(ddlItemName.SelectedValue);
               string SupCode = Session["SupplierCode"].ToString();
               Supitem.SupplierCode = SupCode;
               Supitem.EDIT_DATE = DateTime.Now;
               Supitem.EDIT_USER = ((SessionUser)Session["SessionUser"]).UserId;
               Supitem.OCODE = ((SessionUser)Session["SessionUser"]).OCode;

               if (btn_ItemInfo.Text == "Submit")
               {
                   int result = supplierBll.SaveItemInfo(Supitem);
                   if (result == 1)
                   {

                       lblItemmsg.Text = "Data Saved Sucessfully";
                       lblItemmsg.ForeColor = System.Drawing.Color.Green;
                       GetItemsInfo();
                       Clearitem();
                   }
               }
               else
               {
                   int ItemId = Convert.ToInt32(Session["ItemId"]);
                   int result = supplierBll.UpdateItem(Supitem, ItemId);
                   if (result == 1)
                   {
                       lblItemmsg.Text = "Data Update Sucessfully";
                       lblItemmsg.ForeColor = System.Drawing.Color.Green;
                       GetItemsInfo();
                       Clearitem();
                       btn_ItemInfo.Text = "Submit";
                   }

               }
           }
           catch (Exception ex)
           {
               ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
           }
       }
       private void GetItemsInfo()
       {
           try
           {
               string SupCode = Session["SupplierCode"].ToString();
               //string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
               //string OCODE = "8989";
               //List<Inv_Sup_ItemInfo> suppliers = supplierBll.Getiems(SupCode);
               //if (suppliers.Count > 0)
               //{

               //    grdItemInfos.DataSource = suppliers;
               //    grdItemInfos.DataBind();
                   
               //}

           }
           catch (Exception ex)
           {
               ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
           }
       }
       protected void imgbtnItemEdit_Click(object sender, EventArgs e)
        {
            //lblMessage.Text = "";
            List<Inv_Sup_ItemInfo> suppliers = new List<Inv_Sup_ItemInfo>();
            ImageButton imgbtn = (ImageButton)sender;
            GridViewRow row = (GridViewRow)imgbtn.NamingContainer;

            try
            {
                
                string supplierId = "";
                Label lblSupplierId = (Label)grdItemInfos.Rows[row.RowIndex].FindControl("lblItem");
                if (lblSupplierId != null)
                {
                    string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                    //string OCODE = "8989";
                    supplierId = lblSupplierId.Text;
                    Session["ItemId"] = supplierId;
                    suppliers = supplierBll.GetItemforEdit(supplierId);

                    if (suppliers.Count > 0)
                    {
                        foreach (Inv_Sup_ItemInfo asupplier in suppliers)
                        { 
                            ddlItemgroup.SelectedValue=Convert.ToString(asupplier.GroupId);
                            ddlItemName.SelectedValue =Convert.ToString(asupplier.ProductId);
      
                        }
                        if ( btn_ItemInfo.Text== "Submit")
                        {
                            btn_ItemInfo.Text = "Update";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

       private void Clearitem()
       {
           ddlItemName.ClearSelection();
           ddlItemgroup.ClearSelection();
       }


        //Attacted Documents.................................................................
       protected void btn_Doc_Click(object sender, EventArgs e)
       {
           //string SupplierCode = Session["SupplierCode"].ToString();
           //Inv_Supplier_Documents aDocument = new Inv_Supplier_Documents();
           //if (hidFileName.Value != "")
           //{
           //    string path = HttpContext.Current.Server.MapPath("/INV/DocFiles/Quotaion/");

           //    if (Directory.Exists(path))
           //    {
           //        string completePath = Server.MapPath("/COMMERCIAL/DocFiles/Quotaion/" + hidFileName.Value.ToString());
           //        File.Delete(completePath);
           //    }
           //}

           //String FILE_TYPE = Path.GetExtension(FileUpload1.FileName);

           //string FILE_NAME = Path.GetFileName(FileUpload1.PostedFile.FileName);

           //string quotationDocumnet = "Supplier";
           //EnsureTrackDirectoriesExist(quotationDocumnet);
           //string DB_FILE_PATH = "" + quotationDocumnet.ToString() + "\\" + SupplierCode + FILE_NAME;

           ////sets the image Save to Folder
           //FileUpload1.SaveAs(Server.MapPath("../INV/DocFiles/" + quotationDocumnet.ToString() + "/" + SupplierCode + FILE_NAME));

           //aDocument.File_Name = SupplierCode + FILE_NAME;
           //aDocument.File_Path = DB_FILE_PATH;

           //string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
           //aDocument.OCODE = OCODE;
           //aDocument.EDIT_DATE = DateTime.Now;
           //aDocument.EDIT_USER = ((SessionUser)Session["SessionUser"]).UserId;


           ////aDocuments.QuotationNo = Convert.ToString(Session["QuotationNo"]);
           //aDocument.Description = txtDescription.Text;
           //aDocument.Receive_Date = Convert.ToDateTime(txtReceivedDate.Text);

           //if (btn_Doc.Text == "Submit")
           //{
           //    supplierBll.InsertSupplierDocuments(aDocument);


           //}
       }
                      //else
                      //{
                      //    quotationDocumentsDal.UpdateQuotationDocuments(aDocuments, hdfQuotationDoc.Value);
                      //    lblMessage3.Text = "Data Update Successfully";
                      //    GridQuotationDocuments();
                      //}

       //    string SupplierCode = Session["SupplierCode"].ToString();
       //    string FILE_TYPE = Path.GetExtension(FileUpload1.FileName);
     

       //    string FILE_NAME = Path.GetFileName(FileUpload1.PostedFile.FileName);
      
       //    //string FILE_NAME =Path.GetFileName(FileUpload1.PostedFile.FileName);

       //    EnsureTrackDirectoriesExist();

       //    FileUpload1.SaveAs(Server.MapPath("~/INV/Document/" +"/" + FILE_NAME));
       //    Inv_Supplier_Documents aDocument = new Inv_Supplier_Documents();
       //    aDocument.SupplierCode = SupplierCode;
       //    string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
       //    aDocument.OCODE = OCODE;
       //    aDocument.EDIT_DATE = DateTime.Now;
       //    aDocument.EDIT_USER = ((SessionUser)Session["SessionUser"]).UserId;
       //    aDocument.Description = txtDescription.Text;
       //    aDocument.Receive_Date = Convert.ToDateTime(txtReceivedDate.Text);
       //    aDocument.Remarks = txtRemarks.Text;
       //    aDocument.File_Path =FILE_NAME;
       //    aDocument.File_Name = SupplierCode + FILE_NAME;

       //    if (btn_Doc.Text == "Submit")
       //    {
       //        supplierBll.InsertSupplierDocuments(aDocument);
       //    }    
       //}

        public void EnsureTrackDirectoriesExist(string OCODE)
        {
            if (!System.IO.Directory.Exists(Server.MapPath("../INV/DocFiles/" + OCODE.ToString())))
            {
                System.IO.Directory.CreateDirectory(Server.MapPath("../INV/DocFiles/" + OCODE.ToString()));
            }
        }

        protected void btn_Doc_Click1(object sender, EventArgs e)
        {
            //string SupplierCode = Session["SupplierCode"].ToString();
            //Inv_Supplier_Documents aDocument = new Inv_Supplier_Documents();
            //if (hidFileName.Value != "")
            //{
            //    string path = HttpContext.Current.Server.MapPath("/INV/DocFiles/Quotaion/");

            //    if (Directory.Exists(path))
            //    {
            //        string completePath = Server.MapPath("/COMMERCIAL/DocFiles/Quotaion/" + hidFileName.Value.ToString());
            //        File.Delete(completePath);
            //    }
            //}

            //String FILE_TYPE = Path.GetExtension(FileUpload1.FileName);

            //string FILE_NAME = Path.GetFileName(FileUpload1.PostedFile.FileName);

            //string quotationDocumnet = "Supplier";
            //EnsureTrackDirectoriesExist(quotationDocumnet);
            //string DB_FILE_PATH = "" + quotationDocumnet.ToString() + "\\" + SupplierCode + FILE_NAME;

            ////sets the image Save to Folder
            //FileUpload1.SaveAs(Server.MapPath("../INV/DocFiles/" + quotationDocumnet.ToString() + "/" + SupplierCode + FILE_NAME));

            //aDocument.File_Name = SupplierCode + FILE_NAME;
            //aDocument.File_Path = DB_FILE_PATH;

            //string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
            //aDocument.OCODE = OCODE;
            //aDocument.EDIT_DATE = DateTime.Now;
            //aDocument.EDIT_USER = ((SessionUser)Session["SessionUser"]).UserId;


            ////aDocuments.QuotationNo = Convert.ToString(Session["QuotationNo"]);
            //aDocument.Description = txtDescription.Text;
            //aDocument.Receive_Date = Convert.ToDateTime(txtReceivedDate.Text);

            //if (btn_Doc.Text == "Submit")
            //{
            //    supplierBll.InsertSupplierDocuments(aDocument);


            //}
        }

        protected void btn_Submit_Click(object sender, EventArgs e)
        {
            try
            {
FILE_NAME = Path.GetFileName(FileUpload1.PostedFile.FileName);
            string a = txtDescription.Text;
            string b = txtRemarks.Text;
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }
    }
}
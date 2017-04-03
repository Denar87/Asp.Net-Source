using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ERPSSL.FA.BLL;
using System.Data;
using System.Collections;
using System.Drawing;

namespace ERPSSL.FA
{
    public partial class Documents : System.Web.UI.Page
    {
        Documents_BLL objDocumentsBll = new Documents_BLL();

        private static Int64 CurrentBalance = 0;
        private static DataTable CurrentStatus = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
           
            if (!IsPostBack)
            {
                
                lblMessage.Text = "";             
                FillRegion();
                FindingAsset.Visible = false;
            }
        }

        private void FillRegion()
        {
            ddlRegion.DataSource = Region_BLL1.GetAllRegions();
            ddlRegion.DataValueField = "RegionCode";
            ddlRegion.DataTextField = "RegionName";
            ddlRegion.DataBind();
            ddlRegion.Items.Insert(0, new ListItem("Select One", ""));
        }

        protected void ddlRegion_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillOffice();
        }

        private void FillOffice()
        {
            ddlOffice.DataSource = Region_BLL1.GetOfficesByRegionCode(ddlRegion.SelectedValue);
            ddlOffice.DataValueField = "OfficeCode";
            ddlOffice.DataTextField = "OfficeName";
            ddlOffice.DataBind();
            ddlOffice.Items.Insert(0, new ListItem("Select One", ""));
        }

        protected void ddlOffice_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillDepartments();
        }

        private void FillDepartments()
        {
            ddlDepartment.DataSource = Region_BLL1.GetDepartmentsByOfficeCode(ddlOffice.SelectedValue);
            ddlDepartment.DataValueField = "DepartmentCode";
            ddlDepartment.DataTextField = "DepartmentName";
            ddlDepartment.DataBind();
            ddlDepartment.Items.Insert(0, new ListItem("Select One", ""));
        }

        protected void ddlDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillUsers();
            FillAssetsByDepartment();
        }

        private void FillAssetsByDepartment()
        {
            ddlAsset.DataSource = objDocumentsBll.GetStockAssetsByDepartment(ddlDepartment.SelectedValue);
            ddlAsset.DataValueField = "AssetCode";
            ddlAsset.DataTextField = "AssetName";
            ddlAsset.DataBind();
            ddlAsset.Items.Insert(0, new ListItem("Select One", ""));
        }

        private void FillUsers()
        {
            ddlUser.DataSource = Region_BLL1.GetUsersForDropdownByDepartmentCode(ddlDepartment.SelectedValue);
            ddlUser.DataValueField = "UserId";
            ddlUser.DataTextField = "CustomUserName";
            ddlUser.DataBind();
            ddlUser.Items.Insert(0, new ListItem("Select One", ""));
        }
               

        protected void ddlUser_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillAssetsByUser();
        }

        private void FillAssetsByUser()
        {
            ddlAsset.DataSource = objDocumentsBll.GetStockAssetsByUser(ddlUser.SelectedValue);
            ddlAsset.DataValueField = "AssetCode";
            ddlAsset.DataTextField = "AssetName";
            ddlAsset.DataBind();
            ddlAsset.Items.Insert(0, new ListItem("Select One", ""));
        }

        protected void ddlAsset_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtAssetCode.Text = ddlAsset.SelectedValue;
            FillAssetInfo();
        }

        private void FillAssetInfo()
        {
            FindingAsset.Visible = true;
            string AssetCode = txtAssetCode.Text.Trim();
            DataTable dt = new DataTable();
            dt = objDocumentsBll.GetAssetInforByAssetCode(AssetCode);

            if (dt.Rows.Count == 1)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    lblAssetCode.Text = AssetCode;
                    lblAsset.Text = dr["CustomAssetName"].ToString();
                    lblGroup.Text = dr["GroupName"].ToString();
                    lblDepartment.Text = dr["DepartmentName"].ToString();
                    lblOffice.Text = dr["OfficeName"].ToString();
                    lblRegion.Text = dr["RegionName"].ToString();
                    lblUser.Text = dr["CustomUserName"].ToString();
                }

                if (objDocumentsBll.IsDisposed(AssetCode))
                {
                    lblStatus.Text = "<font color='red'>This asset has already been disposed.</font>";
                    btnUpload.Enabled = false;
                }
                else
                {
                    CurrentBalance = objDocumentsBll.GetCurrentBalanceByAssetCode(AssetCode);

                    CurrentStatus = objDocumentsBll.GetCurrentStatusByAssetCode(AssetCode);
                    foreach (DataRow dr in CurrentStatus.Rows)
                    {
                        lblACClosingBalance.Text = dr["XACClosingBalance"].ToString();
                        lblADClosingBalance.Text = dr["XADClosingBalance"].ToString();
                        lblRRClosingBalance.Text = dr["XRRClosingBalance"].ToString();
                        lblMethod.Text = dr["XACDepMethod"].ToString();

                        lblACClosingBalanceTax.Text = dr["TACClosingBalance"].ToString();
                        lblADClosingBalanceTax.Text = dr["TADClosingBalance"].ToString();
                        lblRRClosingBalanceTax.Text = dr["TRRClosingBalance"].ToString();
                        lblMethodTax.Text = dr["TACDepMethod"].ToString();

                    }
                    btnUpload.Enabled = true;
                    LoadPhotos();
                    LoadDocuments();
                }
                lblStatus.Text = "<font color='green'>Asset found</font>";
            }
            else if (dt.Rows.Count == 0)
            {
                btnUpload.Enabled = false;
                ClearAssetInfo();
                lblStatus.Text = "<font color='red'>Asset not found! Please try a valid Asset Code.</font>";
            }
        }

        private void ClearAssetInfo()
        {
            lblAssetCode.Text = string.Empty;
            lblAsset.Text = string.Empty;
            lblGroup.Text = string.Empty;
            lblDepartment.Text = string.Empty;
            lblOffice.Text = string.Empty;
            lblRegion.Text = string.Empty;
            lblUser.Text = string.Empty;
        }

        private void LoadDocuments()
        {
            try
            {
                string AssetCode = txtAssetCode.Text;
                DataTable dt = objDocumentsBll.GetDocuments(AssetCode);
                string DocLocation = Server.MapPath("~/FA/Documents/");
                grdDocuments.DataSource = dt;
                grdDocuments.DataBind();
            }
            catch { }
        }

        private void LoadPhotos()
        {
            try
            {
                string AssetCode = txtAssetCode.Text;
                DataTable dt = objDocumentsBll.GetPhotos(AssetCode);
                string PhotoLocation = "~/FA/Photos/";
                foreach (DataRow dr in dt.Rows)
                {
                    if (dr["Photo1"].ToString() != "")
                        Image1.ImageUrl = PhotoLocation + dr["Photo1"].ToString();
                    if (dr["Photo2"].ToString() != "")
                        Image2.ImageUrl = PhotoLocation + dr["Photo2"].ToString();
                    if (dr["Photo3"].ToString() != "")
                        Image3.ImageUrl = PhotoLocation + dr["Photo3"].ToString();
                }
            }
            catch { }
        }

        protected void txtAssetCode_TextChanged(object sender, EventArgs e)
        {
            FillAssetInfo();
        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            string AssetCode = txtAssetCode.Text;

            if ((uplAttachment.PostedFile != null) && (uplAttachment.PostedFile.ContentLength > 0))
            {
                string fileExt = System.IO.Path.GetExtension(uplAttachment.FileName).ToUpper();
                if (fileExt == ".JPG" || fileExt == ".JPEG" || fileExt == ".PNG" || fileExt == ".GIF" || fileExt == ".PDF" || fileExt == ".DOC" || fileExt == ".DOCX")
                {
                    if (uplAttachment.PostedFile.ContentLength < 4194304)
                    {
                        string fn = System.IO.Path.GetFileName(uplAttachment.PostedFile.FileName);
                        string FileName = AssetCode + "-" + ddlFileType.SelectedValue + "-" + fn;
                        string PhotoLocation = Server.MapPath("~/FA/Photos/") + FileName;
                        string DocLocation = Server.MapPath("~/FA/Documents/") + FileName;
                        try
                        {
                            if (ddlFileType.SelectedValue == "Document")
                            {
                                uplAttachment.PostedFile.SaveAs(DocLocation);

                            }
                            else
                            {
                                uplAttachment.PostedFile.SaveAs(PhotoLocation);
                            }
                            Hashtable ht = new Hashtable();
                            ht.Add("AssetCode", AssetCode);
                            ht.Add("Type", ddlFileType.SelectedValue);
                            ht.Add("FileName", FileName);
                            ht.Add("Remarks", txtRemarks.Text);
                            ht.Add("OCode", ((SessionUser)Session["SessionUser"]).OCode);
                            //ht.Add("OCode", "8989");
                            if (objDocumentsBll.SaveFileInformation(ht))
                            {
                                lblStatus.Text = "<font color='green'>File has been uploaded successfully!</font>";
                                lblMessage.Text = string.Empty;
                                LoadPhotos();
                                LoadDocuments();
                                ClearForm();
                            }
                            else
                            {
                                lblStatus.Text = "<font color='red'>Error in uploading file. Please try again.</font>";
                            }
                        }
                        catch
                        {
                            lblStatus.Text = "<font color='red'>Error in uploading file. Please try again.</font>";
                        }
                    }
                    else
                    {
                        lblStatus.Text = "<font color='red'>Selected file is too big. It must be less then 4 MB</font>";
                    }
                }
                else
                {
                    lblStatus.Text = "<font color='red'>Please select a valid file.</font>";
                }
            }
            else
            {
                lblStatus.Text = "<font color='red'>Please select a file to upload</font>";
            }
        }

        private void ClearForm()
        {
            txtRemarks.Text = string.Empty;
            ddlFileType.ClearSelection();
        }

        protected void imgbtnDelete_Clik(object Sender, EventArgs e)
        {
            //delete data using image button

            ImageButton imgbtn = (ImageButton)Sender;
            GridViewRow row = (GridViewRow)imgbtn.NamingContainer;


            try
            {
                string docId = "";
                Label lblDocId = (Label)grdDocuments.Rows[row.RowIndex].FindControl("DocId");
                if (lblDocId != null)
                {

                    docId = lblDocId.Text;
                    if (objDocumentsBll.DeleteDocument(docId))
                    {
                        lblMessage.Text = "Row Data Successfully Delete from Record";
                        lblMessage.ForeColor = Color.Maroon;
                        lblStatus.Text = string.Empty;
                        LoadDocuments();
                    }
                    else
                    {
                        lblMessage.Text = "Row Data Could Not Delete";
                        lblMessage.ForeColor = Color.Red;
                    }

                }
            }
            catch
            {
            }
            LoadDocuments();

        }


        protected void grdDocuments_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {

                grdDocuments.PageIndex = e.NewPageIndex;
                LoadDocuments();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
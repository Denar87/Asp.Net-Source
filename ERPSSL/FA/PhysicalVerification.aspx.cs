using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ERPSSL.FA.BLL;
using System.Data;
using System.Collections;

namespace ERPSSL.FA
{
    public partial class PhysicalVerification : System.Web.UI.Page
    {
        PhysicalVerification_BLL PhysicalVerificationBll = new PhysicalVerification_BLL();

         public static bool EnterExtraAsset = false;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                FillRegion();
            }
        }
        private void FillDepartments()
        {
            ddlDepartment.DataSource = Region_BLL1.GetDepartmentsByOfficeCode(ddlOffice.SelectedValue);
            ddlDepartment.DataValueField = "DepartmentCode";
            ddlDepartment.DataTextField = "DepartmentName";
            ddlDepartment.DataBind();
            ddlDepartment.Items.Insert(0, new ListItem("Select One", ""));
        }

        private void FillOffice()
        {
            ddlOffice.DataSource = Region_BLL1.GetOfficesByRegionCode(ddlRegion.SelectedValue);
            ddlOffice.DataValueField = "OfficeCode";
            ddlOffice.DataTextField = "OfficeName";
            ddlOffice.DataBind();
            ddlOffice.Items.Insert(0, new ListItem("Select One", ""));
        }

        private void FillRegion()
        {
            
            ddlRegion.DataSource = Region_BLL1.GetAllRegions();
            ddlRegion.DataValueField = "RegionCode";
            ddlRegion.DataTextField = "RegionName";
            ddlRegion.DataBind();
            ddlRegion.Items.Insert(0, new ListItem("Select One", ""));
        }

        //Grid Show

        private void FillAssetsByDepartment()
        {

            grdAssets.DataSource = PhysicalVerificationBll.GetAllStockAssetsByDepartment(ddlDepartment.SelectedValue);
            grdAssets.DataBind();
        }

        //
        protected void grdAssets_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                if (PhysicalVerificationBll.AssetLost(grdAssets.DataKeys[e.RowIndex].Value.ToString()))
                {
                    FillAssetsByDepartment();
                    lblVerification.Text = "Asset status has been updated successfully.";
                    lblVerification.CssClass = "ActionSuccess";
                }
                else
                {
                    lblVerification.Text = "Error in updating asset status.";
                    lblVerification.CssClass = "ActionError";
                }
            }
            catch (Exception ex)
            {
                //ErrorLog.Log(ex);
            }
        }

        protected void grdAssets_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                GridViewRow row = grdAssets.Rows[grdAssets.SelectedIndex];
                string text = row.Cells[0].Text;
                LoadPhotos(text);
            }
            catch (Exception ex)
            {
                //ErrorLog.Log(ex);
            }
        }
        //.....
        protected void grdAssets_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string text = e.Row.Cells[5].Text;
                if ((text == "0") || (text == "False"))
                {
                    e.Row.Cells[5].Text = "<font color='green'>Available</font>";
                }
                else
                {
                    e.Row.Cells[5].Text = "<font color='red'>Not Available</font>";
                }
            }
        }

        protected void ddlRegion_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillOffice();

        }

        protected void ddlOffice_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillDepartments();
        }

        protected void ddlDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillAssetsByDepartment();
            LoadExtraAssets(ddlDepartment.SelectedValue);

        }

        //Grid Extra Asset....................
        private void LoadExtraAssets(string DepartmentCode)
        {
            grdExtraAssets.DataSource = PhysicalVerificationBll.GetExtraAssets(DepartmentCode);
            grdExtraAssets.DataBind();
        }
        //..........
        protected void grdExtraAssets_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                string selectedValue = ddlDepartment.SelectedValue;
                if (PhysicalVerificationBll.DeleteExtraAsset(grdExtraAssets.DataKeys[e.RowIndex].Value.ToString()))
                {
                    LoadExtraAssets(selectedValue);
                    lblExtraAssetIdentityStatus.Text = "Extra asset has been deleted successfully.";
                    lblExtraAssetIdentityStatus.CssClass = "ActionSuccess";
                }
                else
                {
                    lblExtraAssetIdentityStatus.Text = "Error in deleting extra asset.";
                    lblExtraAssetIdentityStatus.CssClass = "ActionError";
                }
            }
            catch (Exception ex)
            {
              
            }
        }

        //Photo Load....
        private void LoadPhotos(string AssetCode)
        {
            try
            {
                DataTable photos = PhysicalVerificationBll.GetPhotos(AssetCode);
                string str = "~/FA/Photos/";
                foreach (DataRow row in photos.Rows)
                {
                    if (row["Photo1"].ToString() != "")
                    {
                        Image1.ImageUrl = str + row["Photo1"].ToString();
                    }
                    else
                    {
                        Image1.ImageUrl = str + "NoPhoto.jpg";
                    }
                    if (row["Photo2"].ToString() != "")
                    {
                        Image2.ImageUrl = str + row["Photo2"].ToString();
                    }
                    else
                    {
                        Image2.ImageUrl = str + "NoPhoto.jpg";
                    }
                    if (row["Photo3"].ToString() != "")
                    {
                        Image3.ImageUrl = str + row["Photo3"].ToString();
                    }
                    else
                    {
                        Image3.ImageUrl = str + "NoPhoto.jpg";
                    }
                }
            }
            catch (Exception ex)
            {
                
            }
        }

        protected void txtAssetCode_TextChanged(object sender, EventArgs e)
        {
             try
            {
                string text = txtAssetCode.Text;
                DataTable assetInforByAssetCode = new DataTable();
                assetInforByAssetCode = PhysicalVerificationBll.GetAssetInforByAssetCode(text);
                string str2 = "<font color='red'>Asset Owner:- ";
                if (assetInforByAssetCode.Rows.Count == 1)
                {
                    EnterExtraAsset = true;
                    foreach (DataRow row in assetInforByAssetCode.Rows)
                    {
                        string str3 = str2;
                        str2 = str3 + "Asset: " + row["CustomAssetName"].ToString() + "Asset Owner:- Region: " + row["RegionName"].ToString() + ", Office: " + row["OfficeName"].ToString() + ", " + row["DepartmentName"].ToString() + ", User: " + row["CustomUserName"].ToString() + "</font>";
                    }
                    lblExtraAssetIdentityStatus.Text = str2;
                }
                else
                {
                    lblExtraAssetIdentityStatus.Text = "Asset is not found in the organization.";
                    lblExtraAssetIdentityStatus.CssClass = "ActionSuccess";
                    EnterExtraAsset = false;
                }
            }
            catch (Exception ex)
            {
                lblExtraAssetIdentityStatus.Text = "Error in finding the asset.";
                lblExtraAssetIdentityStatus.CssClass = "ActionError";
                EnterExtraAsset = false;
               
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string selectedValue = ddlDepartment.SelectedValue;
            string text = txtAssetCode.Text;
            if (EnterExtraAsset)
            {
                Hashtable ht = new Hashtable();
                ht.Add("AssetCode", text);
                ht.Add("DepartmentCode", selectedValue);
                ht.Add("OCode", ((SessionUser)base.Session["SessionUser"]).OCode);
                //ht.Add("OCode","8989");
                if (PhysicalVerificationBll.AddExtraAsset(ht))
                {
                    LoadExtraAssets(selectedValue);
                    lblExtraAssetIdentityStatus.Text = "Extra asset has been added successfully.";
                    lblExtraAssetIdentityStatus.CssClass = "ActionSuccess";
                }
                else
                {
                    lblExtraAssetIdentityStatus.Text = "Error in adding extra asset.";
                    lblExtraAssetIdentityStatus.CssClass = "ActionError";
                }
            }
        }
        }

        //.............
    }
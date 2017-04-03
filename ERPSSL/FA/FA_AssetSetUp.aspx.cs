using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ERPSSL.FA.BLL;
using System.Collections;
using System.Drawing;
using System.Data;

namespace ERPSSL.FA
{
    public partial class FA_AssetSetUp : System.Web.UI.Page
    {
        AssetConfiguration_BLL AssetConfigBll = new AssetConfiguration_BLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                FillAssetGroups();
                FillUnits();
                LoadAssets();
            }
        }

        private void FillUnits()
        {
            ddlUnit.DataSource = AssetConfigBll.GetUnits();
            ddlUnit.DataValueField = "UnitId";
            ddlUnit.DataTextField = "UnitName";
            ddlUnit.DataBind();
            ddlUnit.Items.Insert(0, new ListItem("Select One", ""));
        }

        private void FillAssetGroups()
        {
            ddlGroup.DataSource = AssetConfigBll.GetAllGroups();
            ddlGroup.DataValueField = "GroupCode";
            ddlGroup.DataTextField = "GroupName";
            ddlGroup.DataBind();
            ddlGroup.Items.Insert(0, new ListItem("Select One", ""));
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {                       
            
            Hashtable ht = new Hashtable();
            ht.Add("AssetId", hdnAssetId.Value);
            ht.Add("GroupCode", ddlGroup.SelectedValue);
            ht.Add("AssetName", txtAssetName.Text);
            ht.Add("Brand", txtBrand.Text);
            ht.Add("StyleAndSize", txtStyleAndSize.Text);
            ht.Add("UnitId", ddlUnit.SelectedValue);
            ht.Add("OCode", ((SessionUser)Session["SessionUser"]).OCode);
            ht.Add("SystemUserId", ((SessionUser)Session["SessionUser"]).UserId);
            //ht.Add("OCode", "8989");
            //ht.Add("SystemUserId", "E077F2DC-9C9B-4C12-B4B4-8578C591CB51");
            if (AssetConfigBll.SaveAsset(ht))
            {
                    LoadAssets();
                    ClearForm();
                    lblMessage.Text = "<font color='green'>Asset has been saved successfully !</font>";
            }
            else
            {
                lblMessage.Text = "<font color='red'>Error in saving asset! Please try again</font>"; ;
            }
        }

        protected void imgbtnDelete_Clik(object Sender, EventArgs e)
        {
            //delete data using image button

            ImageButton imgbtn = (ImageButton)Sender;
            GridViewRow row = (GridViewRow)imgbtn.NamingContainer;


            try
            {
                string assetId = "";
                Label lblAssetId = (Label)grdAssets.Rows[row.RowIndex].FindControl("lblAssetId");
                if (lblAssetId != null)
                {

                    assetId = lblAssetId.Text;
                    if (AssetConfigBll.DeleteAsset(assetId))
                    {
                        lblMessage.Text = "Row Data Successfully Delete from Record";
                        lblMessage.ForeColor = Color.Maroon;
                        LoadAssets();
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
            LoadAssets();

        }

        protected void imgBtnEdit_Click(object Sender, EventArgs e)
        {
            //delete data using image button

            ImageButton imgbtn = (ImageButton)Sender;
            GridViewRow row = (GridViewRow)imgbtn.NamingContainer;


            try
            {
                string assetId = "";
                Label lblAssetId = (Label)grdAssets.Rows[row.RowIndex].FindControl("lblAssetId");
                if (lblAssetId != null)
                {

                    assetId = lblAssetId.Text;
                    DataTable dt = AssetConfigBll.GetAssetById(assetId);
                    foreach (DataRow dr in dt.Rows)
                    {                        
                        hdnAssetId.Value = assetId;
                        txtAssetName.Text = dr["AssetName"].ToString();
                        txtBrand.Text = dr["Brand"].ToString();
                        txtStyleAndSize.Text = dr["StyleAndSize"].ToString();

                        ddlGroup.SelectedValue = dr["GroupCode"].ToString();
                        ddlUnit.SelectedValue = dr["UnitId"].ToString();
                    }

                }
            }
            catch
            {
            }
            LoadAssets();

        }


        private void LoadAssets()
        {
            grdAssets.DataSource = AssetConfigBll.GetAllAssets();
            grdAssets.DataBind();
        }

        private void ClearForm()
        {
            txtAssetName.Text = string.Empty;
            txtBrand.Text = string.Empty;
            txtStyleAndSize.Text = string.Empty;

            ddlGroup.ClearSelection();

            ddlUnit.ClearSelection();

            //grdAssets.SelectedIndex = -1;
        }

        protected void grdAssets_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {

                grdAssets.PageIndex = e.NewPageIndex;
                LoadAssets();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
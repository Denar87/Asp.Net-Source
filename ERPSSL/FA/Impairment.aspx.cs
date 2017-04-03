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
    public partial class Impairment : System.Web.UI.Page
    {
        Impairment_BLL ImpairmentBll = new Impairment_BLL();
        private static Int64 CurrentBalance = 0;
        private static DataTable CurrentStatus = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                FillRegion();
                InfoShow.Visible = false;
                //ShortAssetDetails1.Visible = false;
                txtImpairmentDate.Text = DateTime.Today.ToShortDateString();
            }
            
        }
        private void FillAssetInfo()
        {
            string AssetCode = txtAssetCode.Text.Trim();
            DataTable dt = new DataTable();
            dt = ImpairmentBll.GetAssetInforByAssetCode(AssetCode);
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

                if (ImpairmentBll.IsDisposed(AssetCode))
                {
                    lblStatus.Text = "<font color='red'>This asset has already been disposed.</font>";
                    btnImpair.Enabled = false;
                }
                else
                {
                    CurrentBalance = ImpairmentBll.GetCurrentBalanceByAssetCode(AssetCode);

                    CurrentStatus = ImpairmentBll.GetCurrentStatusByAssetCode(AssetCode);
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
                    btnImpair.Enabled = true;
                }
                lblStatus.Text = "<font color='green'>Asset found</font>";
            }
            else if (dt.Rows.Count == 0)
            {
                //ClearAssetInfor();
                lblStatus.Text = "Asset not found! Please try a valid Asset Code.";
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

        private void FillOffice()
        {
            ddlOffice.DataSource = Region_BLL1.GetOfficesByRegionCode(ddlRegion.SelectedValue);
            ddlOffice.DataValueField = "OfficeCode";
            ddlOffice.DataTextField = "OfficeName";
            ddlOffice.DataBind();
            ddlOffice.Items.Insert(0, new ListItem("Select One", ""));
        }

        private void FillDepartments()
        {
            ddlDepartment.DataSource = Region_BLL1.GetDepartmentsByOfficeCode(ddlOffice.SelectedValue);
            ddlDepartment.DataValueField = "DepartmentCode";
            ddlDepartment.DataTextField = "DepartmentName";
            ddlDepartment.DataBind();
            ddlDepartment.Items.Insert(0, new ListItem("Select One", ""));
        }
        private void FillUsers()
        {

            ddlUser.DataSource = Region_BLL1.GetUsersForDropdownByDepartmentCode(ddlDepartment.SelectedValue);
            ddlUser.DataValueField = "UserId";
            ddlUser.DataTextField = "CustomUserName";
            ddlUser.DataBind();
            ddlUser.Items.Insert(0, new ListItem("Select One", ""));
        }
    

        private void FillAssetsByDepartment()
        {

            ddlAsset.DataSource = ImpairmentBll.GetStockAssetsByDepartment(ddlDepartment.SelectedValue);
            ddlAsset.DataValueField = "AssetCode";
            ddlAsset.DataTextField = "AssetName";
            ddlAsset.DataBind();
            ddlAsset.Items.Insert(0, new ListItem("Select One", ""));
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
            FillUsers();
        }

        protected void ddlUser_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillAssetsByDepartment();
        }

        protected void btnImpair_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtAssetCode.Text.Trim() == "" || txtImpairedAtAmount.Text == "" || int.Parse(txtImpairedAtAmount.Text) < 1 || int.Parse(txtImpairedByAmount.Text) < 1)
                {
                    return;
                }

                Hashtable ht = new Hashtable();
                string ddd = ((SessionUser)Session["SessionUser"]).OCode;

                ht.Add("AssetCode", txtAssetCode.Text);
                ht.Add("ImpairmentAmount", txtImpairedByAmount.Text);
                ht.Add("ImpairmentDate", DateTime.Today.ToShortDateString());
                ht.Add("OCode", ((SessionUser)Session["SessionUser"]).OCode);
                ht.Add("SystemUserId", ((SessionUser)Session["SessionUser"]).UserId);
                //ht.Add("OCode", "8989");
                //ht.Add("SystemUserId", "E077F2DC-9C9B-4C12-B4B4-8578C591CB51");

                if (ImpairmentBll.AddImpairment(ht))
                {

                    lblParentStatus.Text = "<font color='green'>Impairment of amount " + txtImpairedByAmount.Text + " for the asset " + txtAssetCode.Text + " has been added successfully!</font>";
                    ClearForm();
                }
                else
                {
                    lblParentStatus.Text = "<font color='red'>Error in adding impairment. Please try again.</font>";
                }


            }
            catch { }
        }

        // Clear ...
        private void ClearForm()
        {
            txtAssetCode.Text = string.Empty; 
            txtImpairedByAmount.Text = string.Empty;
            txtImpairedAtAmount.Text = string.Empty;
            ddlAsset.ClearSelection();
            ddlDepartment.ClearSelection();
            ddlOffice.ClearSelection();
            ddlRegion.ClearSelection();
            ddlUser.ClearSelection();
        }

        private void ClearAssetInfor()
        {
            lblAssetCode.Text = string.Empty;
            lblAsset.Text = string.Empty;
            lblGroup.Text = string.Empty;
            lblDepartment.Text = string.Empty;
            lblOffice.Text = string.Empty;
            lblRegion.Text = string.Empty;
            lblUser.Text = string.Empty;

        }

        protected void ddlAsset_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtAssetCode.Text = ddlAsset.SelectedValue;
            FillAssetInfo();
            InfoShow.Visible = true;
        }

        protected void txtImpairedByAmount_TextChanged(object sender, EventArgs e)
        {
            try
            {
                txtImpairedAtAmount.Text = (CurrentBalance + Convert.ToInt64(txtImpairedByAmount.Text)).ToString();
            }
            catch { }
        }

        protected void txtImpairedAtAmount_TextChanged(object sender, EventArgs e)
        {
            try
            {
                txtImpairedByAmount.Text = (CurrentBalance + Convert.ToInt64(txtImpairedAtAmount.Text)).ToString();
            }
            catch { }
        }

        protected void txtAssetCode_TextChanged(object sender, EventArgs e)
        {
            FillAssetInfo();
            InfoShow.Visible = true;
        }

    }
}
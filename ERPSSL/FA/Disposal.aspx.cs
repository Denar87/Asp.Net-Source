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
    public partial class Disposal : System.Web.UI.Page
    {
        Disposal_BLL DisposalBll = new Disposal_BLL();
        private static Int64 CurrentBalance = 0;
        private static DataTable CurrentStatus = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                FillRegion();
                ShowInfoDetails.Visible = false;
                txtDisposalDate.Text = DateTime.Today.ToShortDateString();
            }
        }
        private void FillAssetInfo()
        {
            string AssetCode = txtAssetCode.Text.Trim();
            DataTable dt = new DataTable();
            dt = DisposalBll.GetAssetInforByAssetCode(AssetCode);

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

                if (DisposalBll.IsDisposed(AssetCode))
                {
                    lblStatus.Text = "<font color='red'>This asset has already been disposed.</font>";
                    //btnDispose.Enabled = false;
                }
                else
                {
                    CurrentBalance = DisposalBll.GetCurrentBalanceByAssetCode(AssetCode);

                    CurrentStatus = DisposalBll.GetCurrentStatusByAssetCode(AssetCode);
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
                    //btnDispose.Enabled = true;
                }
                lblStatus.Text = "<font color='green'>Asset found</font>";
            }
            else if (dt.Rows.Count == 0)
            {
                ClearAssetInfor();
                lblStatus.Text = "<font color='red'>Asset not found! Please try a valid Asset Code.</font>";
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
        private void FillAssetsByDepartment()
        {

            ddlAsset.DataSource = DisposalBll.GetStockAssetsByDepartment(ddlDepartment.SelectedValue);
            ddlAsset.DataValueField = "AssetCode";
            ddlAsset.DataTextField = "AssetName";
            ddlAsset.DataBind();
            ddlAsset.Items.Insert(0, new ListItem("Select One", ""));
        }
        private void FillAssetsByUser()
        {

            ddlAsset.DataSource = DisposalBll.GetStockAssetsByUser(ddlUser.SelectedValue);
            ddlAsset.DataValueField = "AssetCode";
            ddlAsset.DataTextField = "AssetName";
            ddlAsset.DataBind();
            ddlAsset.Items.Insert(0, new ListItem("Select One", ""));
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
            FillAssetsByUser();
        }
        //clear....
        private void ClearForm()
        {
            txtAssetCode.Text = string.Empty;
           
            txtDisposeAmount.Text = string.Empty;
            txtRemarks.Text = string.Empty;
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

        protected void txtAssetCode_TextChanged(object sender, EventArgs e)
        {
            
            FillAssetInfo();
            ShowInfoDetails.Visible = true;
        }

        protected void ddlAsset_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtAssetCode.Text = ddlAsset.SelectedValue;
            FillAssetInfo();
            ShowInfoDetails.Visible = true;
        }

        protected void btnDispose_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtAssetCode.Text.Trim() == "" || txtDisposeAmount.Text == "" || txtRemarks.Text == "" || int.Parse(txtDisposeAmount.Text) < 1)
                {
                    return;
                }

                Hashtable ht = new Hashtable();

                ht.Add("AssetCode", txtAssetCode.Text);
                ht.Add("DisposalAmount", txtDisposeAmount.Text);
                ht.Add("Remarks", txtRemarks.Text);
                ht.Add("DisposalDate", DateTime.Today.ToShortDateString());
                ht.Add("OCode", ((SessionUser)Session["SessionUser"]).OCode);
                ht.Add("SystemUserId", ((SessionUser)Session["SessionUser"]).UserId);
                //ht.Add("OCode", "8989");
                //ht.Add("SystemUserId", "E077F2DC-9C9B-4C12-B4B4-8578C591CB51");


                if (DisposalBll.AddDisposal(ht))
                {
                    lblParentStatus.Text = "<font color='green'>Disposal of amount " + txtDisposeAmount.Text + " for the asset " + txtAssetCode.Text + " has been added successfully!</font>";
                    ClearForm();
                }
                else
                {
                    lblParentStatus.Text = "<font color='red'>An error occured while disposing. Please try again.</font>";
                }
            }
            catch { }
        }
    }
}
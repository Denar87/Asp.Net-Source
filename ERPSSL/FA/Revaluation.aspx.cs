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
    public partial class Revaluation : System.Web.UI.Page
    {
        Revaluation_BLL RevaluationBll = new Revaluation_BLL();
        private static decimal CurrentBalance = 0;
        private static DataTable CurrentStatus = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                FillRegion();

                ShortAssetInfo1.Visible = false;

                txtRevalueDate.Text = DateTime.Today.ToShortDateString();
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

            ddlAsset.DataSource = RevaluationBll.GetStockAssetsByDepartment(ddlDepartment.SelectedValue);
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

        protected void ddlAsset_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtAssetCode.Text = ddlAsset.SelectedValue;
            ShortAssetInfo1.FillAssetInfo(ddlAsset.SelectedValue);
            ShortAssetInfo1.Visible = true;
            SetCurrentBalance(txtAssetCode.Text);
            CheckDiposalStatus();
        }

        protected void txtAssetCode_TextChanged(object sender, EventArgs e)
        {

            ShortAssetInfo1.FillAssetInfo(txtAssetCode.Text);
            SetCurrentBalance(txtAssetCode.Text);
            ShortAssetInfo1.Visible = true;
            CheckDiposalStatus();

        }

        private void SetCurrentBalance(string AssetCode)
        {
            CurrentBalance = RevaluationBll.GetCurrentBalanceByAssetCode(AssetCode);
        }
        private void CheckDiposalStatus()
        {
            if (RevaluationBll.IsDisposed(txtAssetCode.Text.Trim()))
            {
                lblParentStatus.Text = "This asset has already been disposed.";
                lblParentStatus.CssClass = "ActionError";
                btnRevalue.Enabled = false;
            }
        }

        protected void btnRevalue_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtAssetCode.Text.Trim() == "" || txtRevaluatedAtAmount.Text == "" || decimal.Parse(txtRevaluatedAtAmount.Text) < 1 || decimal.Parse(txtRevaluatedByAmount.Text) < 1)
                {
                    return;
                }

                Hashtable ht = new Hashtable();

                ht.Add("AssetCode", txtAssetCode.Text);
                ht.Add("RevaluationAmount", txtRevaluatedByAmount.Text);
                ht.Add("RevaluationDate", DateTime.Today.ToShortDateString());
                ht.Add("OCode", ((SessionUser)Session["SessionUser"]).OCode);
                ht.Add("SystemUserId", ((SessionUser)Session["SessionUser"]).UserId);
                //ht.Add("OCode", "8989");
                //ht.Add("SystemUserId", "E077F2DC-9C9B-4C12-B4B4-8578C591CB51");


                if (RevaluationBll.AddRevaluation(ht))
                {
                    lblParentStatus.Text = "Revaluation of amount " + txtRevaluatedByAmount.Text + " for the asset " + txtAssetCode.Text + " has been added successfully!";
                    lblParentStatus.CssClass = "ActionSuccess";
                    lblParentStatus.ForeColor = Color.Green;
                    ClearForm();
                }
                else
                {
                    lblParentStatus.Text = "Error in adding revaluation. Please try again.";
                    lblParentStatus.CssClass = "ActionError";
                    lblParentStatus.ForeColor = Color.Red;
                }


            }
            catch (Exception ex)
            {
               
            }
        }

        protected void txtRevaluatedByAmount_TextChanged(object sender, EventArgs e)
        {
            try
            {
                txtRevaluatedAtAmount.Text = (CurrentBalance + Convert.ToInt64(txtRevaluatedByAmount.Text)).ToString();
            }
            catch (Exception ex)
            {
               
            }
        }

        private void ClearForm()
        {
            txtAssetCode.Text = string.Empty;
            txtRevaluatedAtAmount.Text = string.Empty;
            txtRevaluatedByAmount.Text = string.Empty;
            ddlAsset.ClearSelection();
            ddlDepartment.ClearSelection();
            ddlOffice.ClearSelection();
            ddlRegion.ClearSelection();
            ddlUser.ClearSelection();
        }
    }
}
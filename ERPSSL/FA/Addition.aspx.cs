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
    public partial class Addition : System.Web.UI.Page
    {
        Additional_BLL AdditionBll = new Additional_BLL();
        private static Int64 CurrentBalance = 0;
        private static decimal CurrentResidual = 0;
        private static DataTable CurrentStatus = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!base.IsPostBack)
            {
                FillRegion();
                txtAdditionDate.Text = DateTime.Today.ToShortDateString();
                ShortAssetDetails1.Visible = false;
               
                
            }
        }
        //ddl Region
        private void FillRegion()
        {
            ddlRegion.DataSource = Region_BLL1.GetAllRegions();
            ddlRegion.DataValueField = "RegionCode";
            ddlRegion.DataTextField = "RegionName";
            ddlRegion.DataBind();
            ddlRegion.Items.Insert(0, new ListItem("Select One", ""));
        }
        //ddl office
        private void FillOffice()
        {
            ddlOffice.DataSource = Region_BLL1.GetOfficesByRegionCode(ddlRegion.SelectedValue);
            ddlOffice.DataValueField = "OfficeCode";
            ddlOffice.DataTextField = "OfficeName";
            ddlOffice.DataBind();
            ddlOffice.Items.Insert(0, new ListItem("Select One", ""));
        }
        //ddl department
        private void FillDepartments()
        {
            ddlDepartment.DataSource = Region_BLL1.GetDepartmentsByOfficeCode(ddlOffice.SelectedValue);
            ddlDepartment.DataValueField = "DepartmentCode";
            ddlDepartment.DataTextField = "DepartmentName";
            ddlDepartment.DataBind();
            ddlDepartment.Items.Insert(0, new ListItem("Select One", ""));
        }
        //ddl user

        private void FillUsers()
        {
            ddlUser.DataSource = Region_BLL1.GetUsersForDropdownByDepartmentCode(ddlDepartment.SelectedValue);
            ddlUser.DataValueField = "UserId";
            ddlUser.DataTextField = "CustomUserName";
            ddlUser.DataBind();
            ddlUser.Items.Insert(0, new ListItem("Select One", ""));
        }
        //fill asset user
        private void FillAssetsByUser()
        {
            ddlAsset.DataSource = AdditionBll.GetStockAssetsByUser(ddlUser.SelectedValue);
            ddlAsset.DataValueField = "AssetCode";
            ddlAsset.DataTextField = "AssetName";
            ddlAsset.DataBind();
            ddlAsset.Items.Insert(0, new ListItem("Select One", ""));
        }

        private void FillAssetsByDepartment()
        {
            ddlAsset.DataSource = AdditionBll.GetStockAssetsByDepartment(ddlDepartment.SelectedValue);
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
            FillAssetsByUser();
        }

        protected void txtAssetCode_TextChanged(object sender, EventArgs e)
        {
       
            ShortAssetDetails1.FillAssetInfo(txtAssetCode.Text);
            SetCurrentBalance(txtAssetCode.Text);
            ShortAssetDetails1.Visible = true;
            CheckDiposalStatus();
        
        }

        protected void ddlAsset_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtAssetCode.Text = ddlAsset.SelectedValue;
            ShortAssetDetails1.FillAssetInfo(ddlAsset.SelectedValue);
            ShortAssetDetails1.Visible = true;
            SetCurrentBalance(txtAssetCode.Text);
            txtCurrentValue.Text = CurrentBalance.ToString();
            SetCurrentResidual(txtAssetCode.Text);
            txtCurrentResidualCost.Text = CurrentResidual.ToString();
            CheckDiposalStatus();
      
          
        }

        //...
        private void SetCurrentBalance(string AssetCode)
        {

            CurrentBalance = AdditionBll.GetCurrentBalanceByAssetCode(AssetCode);
        }

        private void SetCurrentResidual(string AssetCode)
        {
            CurrentResidual = AdditionBll.GetCurrentResidualCostByAssetCode(AssetCode);
        }

        //check status
        private void CheckDiposalStatus()
        {
            if (AdditionBll.IsDisposed(txtAssetCode.Text.Trim()))
            {
                lblParentStatus.Text = "This asset has already been disposed.";
                lblParentStatus.CssClass = "ActionError";
                btnAddition.Enabled = false;
            }
        }

        protected void btnAddition_Click(object sender, EventArgs e)
        {
            try
            {
                if ((txtAssetCode.Text.Trim() != "") && (decimal.Parse(txtAdditionalCost.Text) >= 1))
                {
                    Hashtable ht = new Hashtable();
                    ht.Add("AssetCode", txtAssetCode.Text);
                    ht.Add("AdditionAmount", txtAdditionalCost.Text);
                    ht.Add("RevisedResidualCost", txtRevisedResidualCost.Text);
                    ht.Add("AdditionDate", txtAdditionDate.Text);
                    ht.Add("OCode", ((SessionUser)base.Session["SessionUser"]).OCode);
                    ht.Add("SystemUserId", ((SessionUser)base.Session["SessionUser"]).UserId);
                    //ht.Add("OCode", "8989");
                    //ht.Add("SystemUserId", "E077F2DC-9C9B-4C12-B4B4-8578C591CB51");
                    if (!AdditionBll.IsBackDate(DateTime.Parse(txtAdditionDate.Text)))
                    {
                        if (AdditionBll.AddAddition(ht))
                        {
                            lblParentStatus.Text = "Addition of amount " + txtAdditionalCost.Text + " for the asset " + txtAssetCode.Text + " has been added successfully!";
                            lblParentStatus.CssClass = "ActionSuccess";
                            ClearForm();
                        }
                        else
                        {
                            lblParentStatus.Text = "Error in adding additional cost. Please try again.";
                            lblParentStatus.CssClass = "ActionError";
                            lblParentStatus.ForeColor = Color.Green;
                        }
                    }
                    else
                    {
                        lblParentStatus.Text = "Depreciation has been calculated for this date already. You are not allowed to add value for this asset on this date. If you would like to do this then delete all depreciations from this date.";
                        lblParentStatus.CssClass = "ActionError";
                        lblParentStatus.ForeColor = Color.Red;
                       

                    }
                }
            }
            catch
            {
            }

        }
        private void ClearForm()
        {
            txtAssetCode.Text = string.Empty;
            txtAdditionalCost.Text = string.Empty;
            txtAdditionDate.Text = DateTime.Today.ToShortDateString();
            txtCurrentResidualCost.Text = string.Empty;
            txtCurrentValue.Text = string.Empty;
            txtRevisedResidualCost.Text = string.Empty;
            ddlAsset.ClearSelection();
            ddlDepartment.ClearSelection();
            ddlOffice.ClearSelection();
            ddlRegion.ClearSelection();
            ddlUser.ClearSelection();
        }

    }
}
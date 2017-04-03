using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ERPSSL.FA.BLL;
using System.Data;
using System.Collections;
using Microsoft.Reporting.WebForms;
using SSL.FA.BLL;

namespace ERPSSL.FA
{
    public partial class AssetTransfer : System.Web.UI.Page
    {
        Transfer_BLL TransferBll = new Transfer_BLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                FillRegionTo();
                FillRegion();
            }

        }

        //reporting 
        private void BindReport(int TotalNumberofAssets, DataTable data, DateTime TransferDate, DataTable dtCompany, string TransferNo, string FromRegion, string ToRegion, string ToOffice, string ToDepartment, string ToUser)
        {
            this.ReportViewer1.LocalReport.DataSources.Clear();
            ReportDataSource item = new ReportDataSource("Transfer_DS", data);
            this.ReportViewer1.LocalReport.DataSources.Add(item);
            this.ReportViewer1.LocalReport.ReportPath = base.Server.MapPath("Reports/FA_SingleTransfer.rdlc");
            this.BindReportHeader(TotalNumberofAssets, dtCompany, TransferDate, TransferNo, FromRegion, ToRegion, ToOffice, ToDepartment, ToUser);
            this.ReportViewer1.LocalReport.Refresh();
        }
        //
        private void BindReportHeader(int TotalNumberofAssets, DataTable dt, DateTime TransferDate, string TransferNo, string FromRegion, string ToRegion, string ToOffice, string ToDepartment, string ToUser)
        {
            if (dt.Rows.Count == 1)
            {
                foreach (DataRow row in dt.Rows)
                {
                    ReportParameter parameter = new ReportParameter("CompanyName", row["CompanyName"].ToString());
                    ReportParameter parameter2 = new ReportParameter("CompanyAddress", row["CompanyAddress"].ToString());
                    ReportParameter parameter3 = new ReportParameter("TransferNo", TransferNo);
                    ReportParameter parameter4 = new ReportParameter("TransferDate", TransferDate.ToShortDateString());
                    ReportParameter parameter5 = new ReportParameter("FromRegion", FromRegion);
                    ReportParameter parameter6 = new ReportParameter("ToRegion", ToRegion);
                    ReportParameter parameter7 = new ReportParameter("ToOffice", (ToOffice == "") ? "N/A" : ToOffice);
                    ReportParameter parameter8 = new ReportParameter("ToDepartment", (ToDepartment == "") ? "NA" : ToDepartment);
                    ReportParameter parameter9 = new ReportParameter("ToUser", (ToUser == "") ? "NA" : ToUser);
                    ReportParameter parameter10 = new ReportParameter("TotalNumberOfAsset", TotalNumberofAssets.ToString());
                    this.ReportViewer1.LocalReport.SetParameters(new ReportParameter[] { parameter, parameter2, parameter3, parameter4, parameter5, parameter6, parameter7, parameter8, parameter9, parameter10 });
                }
            }
        }
       //
        private void GetTransferVoucherReport(int TotalNumberofAssets, string TransferNo, DateTime TransferDate, string FromRegion, string ToRegion, string ToOffice, string ToDepartment, string ToUser)
        {
            ReportsBll ReportBll = new ReportsBll();
            Hashtable ht = new Hashtable();
            ht.Add("TransferNo", TransferNo);
            //ht.Add("OCode", "8989");
            ht.Add("OCode", ((SessionUser)base.Session["SessionUser"]).OCode);
        
            DataSet transferVoucher = new DataSet();
            transferVoucher = ReportBll.GetTransferVoucher(ht);
            DataTable data = transferVoucher.Tables[0];
            DataTable dtCompany = transferVoucher.Tables[1];
            this.BindReport(TotalNumberofAssets, data, TransferDate, dtCompany, TransferNo, FromRegion, ToRegion, ToOffice, ToDepartment, ToUser);
        }


        protected void btnTransfer_Click(object sender, EventArgs e)
        {
            List<string> assetList = new List<string>();
            string systemUserId =Convert.ToString(((SessionUser)base.Session["SessionUser"]).UserId);
            DataTable assetListToTransfer = TransferBll.GetAssetListToTransfer(systemUserId);
            foreach (DataRow row in assetListToTransfer.Rows)
            {
                try
                {
                    assetList.Add(row["AssetCode"].ToString());
                }
                catch (Exception ex)
                {
                    //ErrorLog.Log(ex);
                }
            }
            string newTransferNo = TransferBll.GetNewTransferNo(DateTime.Today);
            Hashtable ht = new Hashtable();
            ht.Add("AssetCode", "");
            ht.Add("TransferNo", newTransferNo);
            ht.Add("ToRegionCode", this.ddlRegionTo.SelectedValue);
            ht.Add("ToOfficeCode", this.ddlOfficeTo.SelectedValue);
            ht.Add("ToDepartmentCode", this.ddlDepartmentTo.SelectedValue);
            ht.Add("ToUserId", this.ddlUserTo.SelectedValue);
            string selectedValue = this.ddlRegionTo.SelectedValue;
            string toOfficeCode = this.ddlOfficeTo.SelectedValue;
            string toDepartmentCode = this.ddlDepartmentTo.SelectedValue;
            string toUserId = this.ddlUserTo.SelectedValue;
            ht.Add("OCode", ((SessionUser)base.Session["SessionUser"]).OCode);
            ht.Add("SystemUserId", ((SessionUser)base.Session["SessionUser"]).UserId);
            //ht.Add("OCode", "8989");
            //ht.Add("SystemUserId", "E077F2DC-9C9B-4C12-B4B4-8578C591CB51");
            DateTime today = DateTime.Today;
            if (TransferBll.Transfer(ht, assetList, today, selectedValue, toOfficeCode, toDepartmentCode, toUserId))
            {
                TransferBll.ClearTemp(systemUserId);
                this.GetTransferVoucherReport(assetList.Count, newTransferNo, today, this.ddlRegion.SelectedItem.Text, this.ddlRegionTo.SelectedItem.Text, this.ddlOffice.Text, this.ddlDepartment.Text, this.ddlUser.Text);
                this.lblStatus.Text = "Transfer information has been added successfully!";
                lblStatus.CssClass = "ActionSuccess";
                this.ClearForm();
            }
            else
            {
                this.lblStatus.Text = "Error in transfering assets. Please try again!";
                lblStatus.CssClass = "ActionError";
            }
        }

        private void ClearForm()
        {
            this.txtTransferNo.Text = string.Empty;
            this.ddlRegion.ClearSelection();
            this.ddlOffice.ClearSelection();
            this.ddlDepartment.ClearSelection();
            this.ddlUser.ClearSelection();
            this.ddlRegionTo.ClearSelection();
            this.ddlOfficeTo.ClearSelection();
            this.ddlDepartmentTo.ClearSelection();
            this.ddlUserTo.ClearSelection();
        }

        protected void ddlDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.FillUsers();
            this.FillAssets(this.ddlDepartment.SelectedValue, "Department");
        }

        protected void ddlDepartmentTo_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.FillUsersTo();
        }

        protected void ddlOffice_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.FillDepartments();
            this.FillAssets(this.ddlOffice.SelectedValue, "Office");
        }

        protected void ddlOfficeTo_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.FillDepartmentsTo();
        }

        protected void ddlRegion_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.FillOffice();
            this.FillAssets(this.ddlRegion.SelectedValue, "Region");
        }

        protected void ddlRegionTo_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.FillOfficeTo();
            this.txtTransferNo.Text = TransferBll.GetNewTransferNo(DateTime.Today);
        }

        protected void ddlUser_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.FillAssets(this.ddlUser.SelectedValue, "UserId");
        }

        private void FillAssetListToTransfer(Hashtable ht)
        {
            try
            {
                TransferBll.SetAssetListToTransfer(ht);
                //string systemUserId = "E077F2DC-9C9B-4C12-B4B4-8578C591CB51";
                string systemUserId = Convert.ToString(((SessionUser)base.Session["SessionUser"]).UserId);
                
                this.grdTransferList.DataSource = TransferBll.GetAssetListToTransfer(systemUserId);
                this.grdTransferList.DataBind();
            }
            catch (Exception ex)
            {
                //ErrorLog.Log(ex);
            }
        }

        private void FillAssets(string Code, string OwnerType)
        {
            DataTable assets = TransferBll.GetAssets(Code,OwnerType);
            try
            {
                this.grdAssets.DataSource = assets;
                this.grdAssets.DataBind();
            }
            catch (Exception ex)
            {
                //ErrorLog.Log(ex);
            }
        }

        private void FillDepartments()
        {
            this.ddlDepartment.DataSource = Region_BLL1.GetDepartmentsByOfficeCode(this.ddlOffice.SelectedValue);
            this.ddlDepartment.DataValueField = "DepartmentCode";
            this.ddlDepartment.DataTextField = "DepartmentName";
            this.ddlDepartment.DataBind();
            this.ddlDepartment.Items.Insert(0, new ListItem("Select One", ""));
        }

        private void FillDepartmentsTo()
        {
            this.ddlDepartmentTo.DataSource = Region_BLL1.GetDepartmentsByOfficeCode(this.ddlOfficeTo.SelectedValue);
            this.ddlDepartmentTo.DataValueField = "DepartmentCode";
            this.ddlDepartmentTo.DataTextField = "DepartmentName";
            this.ddlDepartmentTo.DataBind();
            this.ddlDepartmentTo.Items.Insert(0, new ListItem("Select One", ""));
        }

        private void FillOffice()
        {
            this.ddlOffice.DataSource = Region_BLL1.GetOfficesByRegionCode(this.ddlRegion.SelectedValue);
            this.ddlOffice.DataValueField = "OfficeCode";
            this.ddlOffice.DataTextField = "OfficeName";
            this.ddlOffice.DataBind();
            this.ddlOffice.Items.Insert(0, new ListItem("Select One", ""));
        }

        private void FillOfficeTo()
        {
            this.ddlOfficeTo.DataSource = Region_BLL1.GetOfficesByRegionCode(this.ddlRegionTo.SelectedValue);
            this.ddlOfficeTo.DataValueField = "OfficeCode";
            this.ddlOfficeTo.DataTextField = "OfficeName";
            this.ddlOfficeTo.DataBind();
            this.ddlOfficeTo.Items.Insert(0, new ListItem("Select One", ""));
        }

        private void FillRegion()
        {
            this.ddlRegion.DataSource = Region_BLL1.GetAllRegions();
            this.ddlRegion.DataValueField = "RegionCode";
            this.ddlRegion.DataTextField = "RegionName";
            this.ddlRegion.DataBind();
            this.ddlRegion.Items.Insert(0, new ListItem("Select One", ""));
        }

        private void FillRegionTo()
        {
            this.ddlRegionTo.DataSource = Region_BLL1.GetAllRegions();
            this.ddlRegionTo.DataValueField = "RegionCode";
            this.ddlRegionTo.DataTextField = "RegionName";
            this.ddlRegionTo.DataBind();
            this.ddlRegionTo.Items.Insert(0, new ListItem("Select One", ""));
        }

        private void FillUsers()
        {
            this.ddlUser.DataSource = Region_BLL1.GetUsersForDropdownByDepartmentCode(this.ddlDepartment.SelectedValue);
            this.ddlUser.DataValueField = "UserId";
            this.ddlUser.DataTextField = "CustomUserName";
            this.ddlUser.DataBind();
            this.ddlUser.Items.Insert(0, new ListItem("Select One", ""));
        }

        private void FillUsersTo()
        {
            this.ddlUserTo.DataSource = Region_BLL1.GetUsersForDropdownByDepartmentCode(this.ddlDepartmentTo.SelectedValue);
            this.ddlUserTo.DataValueField = "UserId";
            this.ddlUserTo.DataTextField = "CustomUserName";
            this.ddlUserTo.DataBind();
            this.ddlUserTo.Items.Insert(0, new ListItem("Select One", ""));
        }

        //private void GetTransferVoucherReport(int TotalNumberofAssets, string TransferNo, DateTime TransferDate, string FromRegion, string ToRegion, string ToOffice, string ToDepartment, string ToUser)
        //{
        //    Hashtable ht = new Hashtable();
        //    ht.Add("TransferNo", TransferNo);
        //    ht.Add("OCode", "E077F2DC-9C9B-4C12-B4B4-8578C591CB51");
        //    DataSet transferVoucher = new DataSet();
        //    transferVoucher = ReportsBll.GetTransferVoucher(ht);
        //    DataTable data = transferVoucher.Tables[0];
        //    DataTable dtCompany = transferVoucher.Tables[1];
        //    this.BindReport(TotalNumberofAssets, data, TransferDate, dtCompany, TransferNo, FromRegion, ToRegion, ToOffice, ToDepartment, ToUser);
        //}

        protected void grdAssets_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                GridViewRow row = this.grdAssets.Rows[this.grdAssets.SelectedIndex];
                string text = row.Cells[0].Text;
                Hashtable ht = new Hashtable();
                ht.Add("AssetCode", text);
                ht.Add("SystemUserId", ((SessionUser)base.Session["SessionUser"]).UserId);
                //ht.Add("SystemUserId", "E077F2DC-9C9B-4C12-B4B4-8578C591CB51");
                this.FillAssetListToTransfer(ht);
            }
            catch (Exception ex)
            {
                //ErrorLog.Log(ex);
            }
        }

        protected void grdTransferList_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                GridViewRow row = this.grdTransferList.Rows[this.grdTransferList.SelectedIndex];
                string text = row.Cells[0].Text;
                string systemUserId = Convert.ToString(((SessionUser)base.Session["SessionUser"]).UserId);
                //string systemUserId = "E077F2DC-9C9B-4C12-B4B4-8578C591CB51";
                if (TransferBll.RemoveItemFromAssetListToTransfer(text))
                {
                    this.grdTransferList.DataSource = TransferBll.GetAssetListToTransfer(systemUserId);
                    this.grdTransferList.DataBind();
                }
            }
            catch (Exception ex)
            {
                //ErrorLog.Log(ex);
            }
        }

        protected void ddlUserTo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void ddlUser_SelectedIndexChanged1(object sender, EventArgs e)
        {

        }  
    }
      
}
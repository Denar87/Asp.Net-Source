using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ERPSSL.FA.BLL;
using System.Data;
using System.Drawing;
using System.Collections;
using System.IO;
using BarcodeLib;
using Microsoft.Reporting.WebForms;
using SSL.FA.BLL;
using ERPSSL.HRM.BLL;

namespace ERPSSL.FA
{
    public partial class AssetEntry : System.Web.UI.Page
    {
        public static string ERegionCode = "";
        public static string EOfficeCode = "";
        public static string EDepartmentCode = "";
        public static string EUserId = "";

        Region_BLL objRegion_Bll = new Region_BLL();
        AssetEntry_BLL assetEntryBll = new AssetEntry_BLL();
        Office_BLL objOfficeBLL = new Office_BLL();
        DEPARTMENT_BLL objDept_BLL = new DEPARTMENT_BLL();
        EMPOYEE_BLL aEmployeeBll = new EMPOYEE_BLL();
  
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                FillAssetGroups();
                FillRegion();
                txtTransferDate.Text = DateTime.Today.ToShortDateString();
            }

        }

        private void FillAssetGroups()
        {
            ddlGroup.DataSource = assetEntryBll.GetAllGroups();
            ddlGroup.DataValueField = "GroupCode";
            ddlGroup.DataTextField = "GroupName";
            ddlGroup.DataBind();
            ddlGroup.Items.Insert(0, new ListItem("Select One", ""));
        }

        private void FillRegion()
        {
            string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
            ddlRegion.DataSource = objRegion_Bll.GetAllRegions(OCODE);
            ddlRegion.DataValueField = "RegionCode";
            ddlRegion.DataTextField = "RegionName";
            ddlRegion.DataBind();
            ddlRegion.Items.Insert(0, new ListItem("Select One", ""));
        }

        private void FillAssets()
        {

            ddlAsset.DataSource = assetEntryBll.GetAssetsForDropdownByGroup(ddlGroup.SelectedValue);
            ddlAsset.DataValueField = "AssetId";
            ddlAsset.DataTextField = "CustomAssetName";
            ddlAsset.DataBind();
            ddlAsset.Items.Insert(0, new ListItem("Select One", ""));
        }

        private void FillOffice()
        {
            var row = objOfficeBLL.GetOfficeByRegionCode(ddlRegion.SelectedValue).ToList();
            if (row.Count > 0)
            {
                ddlOffice.DataSource = row.ToList();
                ddlOffice.DataTextField = "OfficeName";
                ddlOffice.DataValueField = "OfficeCode";
                ddlOffice.DataBind();
                ddlOffice.Items.Insert(0, new ListItem("--Select--"));
            }
            else
            {
                ddlOffice.DataSource = null;
                ddlOffice.DataTextField = "OfficeName";
                ddlOffice.DataValueField = "OfficeCode";
                ddlOffice.DataBind();
                ddlOffice.Items.Insert(0, new ListItem("--Select--"));
            }
        }

        protected void ddlGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillAssets();

        }

        private void FillDepartments()
        {
            try
            {
                string OCODE = Convert.ToString(((SessionUser)Session["SessionUser"]).OCode);
                var departments = objDept_BLL.GetDepartmentByOfficeCode(ddlOffice.SelectedValue, OCODE);
                if (departments.Count > 0)
                {

                    ddlDepartment.DataSource = departments;

                    ddlDepartment.DataTextField = "DPT_NAME";
                    ddlDepartment.DataValueField = "DPT_CODE";
                    ddlDepartment.DataBind();
                    ddlDepartment.Items.Insert(0, new ListItem("--Select--"));
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void FillUsers()
        {
            string OCODE = Convert.ToString(((SessionUser)Session["SessionUser"]).OCode);
            ddlUser.DataSource = aEmployeeBll.GetAllEmployeeByDept(OCODE, ddlDepartment.SelectedValue);
            ddlUser.DataValueField = "EID";
            ddlUser.DataTextField = "FullName";
            ddlUser.DataBind();
            ddlUser.Items.Insert(0, new ListItem("Select One", ""));
        }

        protected void ddlRegion_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillOffice();
            ERegionCode = ddlRegion.SelectedValue;
        }

        protected void ddlOffice_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillDepartments();
            EOfficeCode = ddlOffice.SelectedValue;
        }

        protected void ddlDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillUsers();
            EDepartmentCode = ddlDepartment.SelectedValue;
        }

        protected void ddlUser_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = assetEntryBll.GetUserById(ddlUser.SelectedValue);
            foreach (DataRow dr in dt.Rows)
            {
                txtEmployeeId.Text = dr["EmployeeId"].ToString();
            }
            EUserId = ddlUser.SelectedValue;
        }

        protected void txtEmployeeId_TextChanged(object sender, EventArgs e)
        {
         
            if (txtEmployeeId.Text.Trim() == "")
            {
                return;
            }

            DataTable dt = new DataTable();
            dt = assetEntryBll.GetUserLocationByEmployeeId(txtEmployeeId.Text.Trim());
            SetAutoPostBack(false);
            foreach (DataRow dr in dt.Rows)
            {
                //SetAutoPostBack(false);
           
                ddlRegion.SelectedValue = dr["RegionCode"].ToString();
                FillRegion();
                ddlOffice.SelectedValue = dr["OfficeCode"].ToString();
                FillOffice();
                ddlDepartment.SelectedValue = dr["DepartmentCode"].ToString();
                FillDepartments();
                ddlUser.SelectedValue = dr["UserId"].ToString();
                FillUsers();
        
                
            }

            SetAutoPostBack(true);

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    //lblEmployeeStatus.Text = dr["Name"].ToString() + " >> " + dr["DepartmentName"].ToString() + " >> " + dr["OfficeName"].ToString() + " >> " + dr["RegionName"].ToString();
                    lblEmployeeStatus.Text = "<font color='green'> Employee Found :-" + dr["RegionName"].ToString() + " >> " + dr["OfficeName"].ToString() + " >> " + dr["DepartmentName"].ToString() + " >> " + dr["Name"].ToString() + "</font>";
                    
                    EUserId = dr["UserId"].ToString();
                    EDepartmentCode = dr["DepartmentCode"].ToString();
                    EOfficeCode = dr["OfficeCode"].ToString();
                    ERegionCode = dr["RegionCode"].ToString();
               
                    
                }
            }
            else
            {
                lblEmployeeStatus.Text = "<font color='red'>Employee Not Found!</font>";
            }
        }

        //radio operation
        protected void rdoAssetStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rdoAssetStatus.SelectedValue == "NewAsset")
            {
                txtRROBAccounting.ReadOnly = true;
                txtACOBAccounting.ReadOnly = true;
                txtDepOBAccounting.ReadOnly = true;
                txtACOBTax.ReadOnly = true;
                txtDepOBTax.ReadOnly = true;    
                txtDTOBAsset.ReadOnly = true;
                txtDTOBLiability.ReadOnly = true;
                txtRROBTax.ReadOnly = true;

                txtPrice.ReadOnly = false;
               
            }
            else
            {
                txtPrice.ReadOnly = true;

                txtRROBAccounting.ReadOnly = false;
                txtACOBAccounting.ReadOnly = false;
                txtDepOBAccounting.ReadOnly = false;
                txtACOBTax.ReadOnly = false;
                txtDepOBTax.ReadOnly = false;
                txtDTOBAsset.ReadOnly = false;
                txtDTOBLiability.ReadOnly = false;
                txtRROBTax.ReadOnly = false;
            }
        }

        //clear

        private void ClearForm()
        {
            ddlGroup.ClearSelection();
            ddlAsset.ClearSelection();

            ddlRegion.ClearSelection();
            ddlOffice.ClearSelection();
            ddlDepartment.ClearSelection();
            ddlUser.ClearSelection();
            ddlOwnershipType.ClearSelection();

            // txtAcquisitionDate.Text = DateTime.Today.ToString();
            txtTransferDate.Text = DateTime.Today.ToString();

            txtRROBTax.Text = string.Empty;
            txtRROBAccounting.Text = string.Empty;
            txtPrice.Text = string.Empty;
            // txtFloor.Text = string.Empty;
            txtReschedualCost.Text = string.Empty;
            txtEmployeeId.Text = string.Empty;
            txtDTOBLiability.Text = string.Empty;
            txtDTOBAsset.Text = string.Empty;
            txtDepOBTax.Text = string.Empty;
            txtDepOBAccounting.Text = string.Empty;
            txtACOBTax.Text = string.Empty;
            txtACOBAccounting.Text = string.Empty;

            EUserId = string.Empty;
            EDepartmentCode = string.Empty;
            EOfficeCode = string.Empty;
            ERegionCode = string.Empty;
            lblEmployeeStatus.Text = string.Empty;

        }

        protected void btnReceiveAsset_Click(object sender, EventArgs e)
        {
            try
            {
                Hashtable ht = new Hashtable();
                ht.Add("AssetId", ddlAsset.SelectedValue);
                ht.Add("GroupCode", ddlGroup.SelectedValue);
                ht.Add("FloorName", "");
                ht.Add("OwnershipType", ddlOwnershipType.SelectedValue);
                ht.Add("ReschedualCost", (txtReschedualCost.Text.Trim() == "") ? "1" : txtReschedualCost.Text.Trim());
                ht.Add("RegionCode", ERegionCode);
                ht.Add("OfficeCode", EOfficeCode);
                ht.Add("DepartmentCode", EDepartmentCode);
                ht.Add("UserId", EUserId);

                if (rdoAssetStatus.SelectedValue == "NewAsset")
                {
                    ht.Add("ACOBAccounting", txtPrice.Text);
                    ht.Add("ACOBTax", txtPrice.Text);
                    ht.Add("DPOBAccounting", "0");
                    ht.Add("DPOBTax", "0");
                    ht.Add("RROBAccounting", "0");
                    ht.Add("RROBTax", "0");
                    ht.Add("DTOBAsset", "0");
                    ht.Add("DTOBLiability", "0");
                    ht.Add("Price", txtPrice.Text);
                }
                else
                {
                    ht.Add("ACOBAccounting", txtACOBAccounting.Text);
                    ht.Add("ACOBTax", txtACOBTax.Text);
                    ht.Add("DPOBAccounting", txtDepOBAccounting.Text);
                    ht.Add("DPOBTax", txtDepOBTax.Text);
                    ht.Add("RROBAccounting", (txtRROBAccounting.Text == "") ? "0" : txtRROBAccounting.Text);
                    ht.Add("RROBTax", (txtRROBTax.Text == "") ? "0" : txtRROBTax.Text);
                    ht.Add("DTOBAsset", (txtDTOBAsset.Text == "") ? "0" : txtDTOBAsset.Text);
                    ht.Add("DTOBLiability", (txtDTOBLiability.Text == "") ? "0" : txtDTOBLiability.Text);
                    ht.Add("Price", "0");
                }
                ht.Add("AcquisitionDate", txtTransferDate.Text);
                ht.Add("TransferDate", txtTransferDate.Text);
                //ht.Add("CompanyId", ((SessionUser)base.Session["SessionUser"]).OCode);
                ht.Add("CompanyId","1");
                ht.Add("OCode", ((SessionUser)base.Session["SessionUser"]).OCode);
                ht.Add("SystemUserId", ((SessionUser)base.Session["SessionUser"]).UserId);
                //ht.Add("OCode", "8989");
                //ht.Add("SystemUserId", "E077F2DC-9C9B-4C12-B4B4-8578C591CB51");
                string assetCode = assetEntryBll.AddOldAssetToStock(ht);
                if (assetCode != "")
                {
                    GetSticker(assetCode);

                    lblMessage.Text = "<font color='green'>Asset has been added successfully!</font>";
                    ClearForm();
                }
                else
                {
                    lblMessage.Text = "<font color='red'>Error in adding asset to stock. Please try again.</font>";
                }
            }
            catch
            {
            }
        }

        private void GetSticker(string assetCode)
        {
            Hashtable ht = new Hashtable();
            ht.Add("RegionCode", "");
            ht.Add("OfficeCode", "");
            ht.Add("DepartmentCode", "");
            ht.Add("UserId", "");
            ht.Add("GroupCode", "");
            ht.Add("AssetCode", assetCode);
            ht.Add("Type", "ByIndividualItem");
            ht.Add("OCode", "8989");

            DataSet ds = new DataSet();
            ds = ReportsBll.AssetStickers(ht);
            DataTable data = ds.Tables[0];
            DataTable dtCompany = ds.Tables[1];
            List<Sticker> stickers = new List<Sticker>();

            foreach (DataRow dr in data.Rows)
            {
                Sticker s = new Sticker();
                s.AssetCode = dr["AssetCode"].ToString();
                s.AssetName = dr["AssetName"].ToString();
                byte[] bcode = imageToByteArray(GiveBarcode(dr["AssetCode"].ToString()));
                s.Barcode = bcode;
                s.CompanyName = dr["CompanyName"].ToString();
                stickers.Add(s);
            }

            BindReport(stickers, dtCompany);
        }

        private void BindReport(List<Sticker> data, DataTable dtCompany)
        {
            ReportViewer1.LocalReport.DataSources.Clear();
            ReportDataSource reportDataset = new ReportDataSource("Stickers_DS", data);
            ReportViewer1.LocalReport.DataSources.Add(reportDataset);
            ReportViewer1.LocalReport.ReportPath = Server.MapPath("Reports/FA_Stickers.rdlc");
            BindReportHeader(dtCompany);
            ReportViewer1.LocalReport.Refresh();

        }

        private void BindReportHeader(DataTable dt)
        {
            if (dt.Rows.Count == 1)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    ReportParameter prm_1 = new ReportParameter("CompanyName", dr["CompanyName"].ToString());
                    ReportParameter prm_2 = new ReportParameter("CompanyAddress", dr["CompanyAddress"].ToString());
                    ReportViewer1.LocalReport.SetParameters(new ReportParameter[] { prm_1, prm_2 });
                }
            }
        }



        public byte[] imageToByteArray(System.Drawing.Image imageIn)
        {
            MemoryStream ms = new MemoryStream();
            imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
            return ms.ToArray();
        }

        public System.Drawing.Image GiveBarcode(string value)
        {
            BarcodeLib.Barcode barcode = new BarcodeLib.Barcode()
            {
                IncludeLabel = true,
                Alignment = AlignmentPositions.CENTER,
                Width = 250,
                Height = 40,
                RotateFlipType = RotateFlipType.RotateNoneFlipNone,
                BackColor = Color.White,
                ForeColor = Color.Black,

            };

            System.Drawing.Image img = barcode.Encode(TYPE.CODE128B, value);
            return img;

        }


        //..............
        private void SetAutoPostBack(bool b)
        {
            ddlUser.AutoPostBack = b;
            ddlDepartment.AutoPostBack = b;
            ddlOffice.AutoPostBack = b;
            ddlRegion.AutoPostBack = b;
        }

        protected void ddlRegion_DataBound(object sender, EventArgs e)
        {
            //ERegionCode = ddlRegion.SelectedValue;
            EOfficeCode = ddlOffice.SelectedValue;
        }

        protected void ddlOffice_DataBound(object sender, EventArgs e)
        {
            //EOfficeCode = ddlOffice.SelectedValue;
            EDepartmentCode = ddlDepartment.SelectedValue;
        }

        protected void ddlDepartment_DataBound(object sender, EventArgs e)
        {
            //EDepartmentCode = ddlDepartment.SelectedValue;
        }
    }
}
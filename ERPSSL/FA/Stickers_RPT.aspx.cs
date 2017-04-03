using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ERPSSL.FA.BLL;
using Microsoft.Reporting.WebForms;
using System.Data;
using System.IO;
using SSL.FA.BLL;
using System.Drawing;
using System.Collections;
using BarcodeLib;

namespace ERPSSL.FA
{
    public partial class Stickers_RPT : System.Web.UI.Page
    {
        Sticker_Report_BLL StickerBll = new Sticker_Report_BLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                FillRegion();
                FillAssetGroups();
            }
        }
        private void FillAssetGroups()
        {
            ddlGroup.DataSource = StickerBll.GetAllGroups();
            ddlGroup.DataValueField = "GroupCode";
            ddlGroup.DataTextField = "GroupName";
            ddlGroup.DataBind();
            ddlGroup.Items.Insert(0, new ListItem("Select One", ""));
        }
        private void FillRegion()
        {
            ddlRegion.DataSource = Region_BLL1.GetAllRegions();
            ddlRegion.DataValueField = "RegionCode";
            ddlRegion.DataTextField = "RegionName";
            ddlRegion.DataBind();
            ddlRegion.Items.Insert(0, new ListItem("Select One", ""));
        }

        private void FillDepartments()
        {

            ddlDepartment.DataSource = Region_BLL1.GetDepartmentsByOfficeCode(ddlOffice.SelectedValue);
            ddlDepartment.DataValueField = "DepartmentCode";
            ddlDepartment.DataTextField = "DepartmentName";
            ddlDepartment.DataBind();
            ddlDepartment.Items.Insert(0, new ListItem("Select One", ""));
        }
        private void FillAssets()
        {
            ddlAsset.DataSource = StickerBll.GetStockAssetsByDepartment(ddlDepartment.SelectedValue);
            ddlAsset.DataValueField = "AssetCode";
            ddlAsset.DataTextField = "AssetName";
            ddlAsset.DataBind();
            ddlAsset.Items.Insert(0, new ListItem("Select One", ""));
        }

        private void FillOffice()
        {
            ddlOffice.DataSource = StickerBll.GetOfficesByRegionCode(ddlRegion.SelectedValue);
            ddlOffice.DataValueField = "OfficeCode";
            ddlOffice.DataTextField = "OfficeName";
            ddlOffice.DataBind();
            ddlOffice.Items.Insert(0, new ListItem("Select One", ""));
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
           // FillAssets();
        }

        protected void ddlAsset_SelectedIndexChanged(object sender, EventArgs e)
        {
            //txtAssetCode.Text = ddlAsset.SelectedValue;
        }

        protected void btnGenerateReport_Click(object sender, EventArgs e)
        {
            try
            {
                string Category = rdoBy.SelectedValue;
                //if (Category == "ByGroup")
                //{
                Hashtable ht = new Hashtable();
                ht.Add("RegionCode", ddlRegion.SelectedValue);
                ht.Add("OfficeCode", ddlOffice.SelectedValue);
                ht.Add("DepartmentCode", ddlDepartment.SelectedValue);
                ht.Add("UserId", "");
                ht.Add("GroupCode", ddlGroup.SelectedValue);
                ht.Add("AssetCode", txtAssetCode.Text);
                ht.Add("Type", Category);
                ht.Add("OCode", ((SessionUser)base.Session["SessionUser"]).OCode);
                //ht.Add("OCode", "8989");

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
                //}
            }
            catch
            {

            }
        }


        //Reporting......................
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

        private void BindReport(List<Sticker> data, DataTable dtCompany)
        {
            ReportViewer1.LocalReport.DataSources.Clear();

            ReportDataSource reportDataset = new ReportDataSource("Stickers_DS", data);
            ReportViewer1.LocalReport.DataSources.Add(reportDataset);
            ReportViewer1.LocalReport.ReportPath = Server.MapPath("Reports/FA_Stickers.rdlc");
            BindReportHeader(dtCompany);
            ReportViewer1.LocalReport.Refresh();

        }

        
    }
}
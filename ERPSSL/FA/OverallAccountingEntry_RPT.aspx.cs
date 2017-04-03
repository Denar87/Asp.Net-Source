using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ERPSSL.FA.BLL;
using System.Collections;
using System.Data;
using SSL.FA.BLL;
using Microsoft.Reporting.WebForms;

namespace ERPSSL.FA
{
    public partial class OverallAccountingEntry_RPT : System.Web.UI.Page
    {
        OverallAccountingEntry_BLL objOverallAccountingEntry_Bll = new OverallAccountingEntry_BLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!base.IsPostBack)
            {
                this.FillRegion();
            }

        }

        private void FillRegion()
        {
            this.ddlRegion.DataSource = Region_BLL1.GetAllRegions();
            this.ddlRegion.DataValueField = "RegionCode";
            this.ddlRegion.DataTextField = "RegionName";
            this.ddlRegion.DataBind();
            this.ddlRegion.Items.Insert(0, new ListItem("Select One", ""));
        }

        protected void ddlRegion_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.FillOffice();
        }

        private void FillOffice()
        {
            this.ddlOffice.DataSource = Region_BLL1.GetOfficesByRegionCode(this.ddlRegion.SelectedValue);
            this.ddlOffice.DataValueField = "OfficeCode";
            this.ddlOffice.DataTextField = "OfficeName";
            this.ddlOffice.DataBind();
            this.ddlOffice.Items.Insert(0, new ListItem("Select One", ""));
        }

        protected void ddlOffice_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.FillDepartments();
        }

        private void FillDepartments()
        {
            this.ddlDepartment.DataSource = Region_BLL1.GetDepartmentsByOfficeCode(this.ddlOffice.SelectedValue);
            this.ddlDepartment.DataValueField = "DepartmentCode";
            this.ddlDepartment.DataTextField = "DepartmentName";
            this.ddlDepartment.DataBind();
            this.ddlDepartment.Items.Insert(0, new ListItem("Select One", ""));
        }

        protected void ddlDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.FillAssets();
        }

        private void FillAssets()
        {
            this.ddlAsset.DataSource = objOverallAccountingEntry_Bll.GetStockAssetsByDepartment(this.ddlDepartment.SelectedValue);
            this.ddlAsset.DataValueField = "AssetCode";
            this.ddlAsset.DataTextField = "AssetName";
            this.ddlAsset.DataBind();
            this.ddlAsset.Items.Insert(0, new ListItem("Select One", ""));
        }

        protected void ddlAsset_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                this.txtAssetCode.Text = this.ddlAsset.SelectedValue;
            }
            catch
            {
            }
        }

        protected void btnGenerateReport_Click(object sender, EventArgs e)
        {
            try
            {
                string selectedValue = this.rdoBy.SelectedValue;
                Hashtable ht = new Hashtable();
                ht.Add("DateFrom", this.txtDateFrom.Text);
                ht.Add("DateTo", this.txtDateTo.Text);
                ht.Add("Type", selectedValue);
                ht.Add("AssetCode", this.txtAssetCode.Text);
                ht.Add("OCode", ((SessionUser)base.Session["SessionUser"]).OCode);
                //ht.Add("OCode", "8989");
                DataSet set = new DataSet();
                set = ReportsBll.OverallAccountingEntry(ht);
                DataTable data = set.Tables[0];
                DataTable dtCompany = set.Tables[1];
                this.BindReport(data, dtCompany);
            }
            catch
            {
            }
        }

        private void BindReport(DataTable data, DataTable dtCompany)
        {
            this.ReportViewer1.LocalReport.DataSources.Clear();
            ReportDataSource item = new ReportDataSource("OverallAccountingEntries_RPT_DS", data);
            this.ReportViewer1.LocalReport.DataSources.Add(item);
            this.ReportViewer1.LocalReport.ReportPath = base.Server.MapPath("Reports/OverallAccountingEntries_RPT.rdlc");
            this.BindReportHeader(dtCompany);
            this.ReportViewer1.LocalReport.Refresh();
        }

        private void BindReportHeader(DataTable dt)
        {
            if (dt.Rows.Count == 1)
            {
                foreach (DataRow row in dt.Rows)
                {
                    ReportParameter parameter = new ReportParameter("CompanyName", row["CompanyName"].ToString());
                    ReportParameter parameter2 = new ReportParameter("CompanyAddress", row["CompanyAddress"].ToString());
                    ReportParameter parameter3 = new ReportParameter("AssetName", row["AssetName"].ToString());
                    ReportParameter parameter4 = new ReportParameter("DateFrom", row["DateFrom"].ToString());
                    ReportParameter parameter5 = new ReportParameter("DateTo", row["DateTo"].ToString());
                    ReportParameter parameter6 = new ReportParameter("ASOpening", row["ASOpening"].ToString());
                    ReportParameter parameter7 = new ReportParameter("ASClosing", row["ASClosing"].ToString());
                    ReportParameter parameter8 = new ReportParameter("ASChange", row["ASChange"].ToString());
                    ReportParameter parameter9 = new ReportParameter("LBOpening", row["LBOpening"].ToString());
                    ReportParameter parameter10 = new ReportParameter("LBClosing", row["LBClosing"].ToString());
                    ReportParameter parameter11 = new ReportParameter("LBChanges", row["LBChanges"].ToString());
                    ReportParameter parameter12 = new ReportParameter("AssetLocation", row["AssetLocation"].ToString());
                    this.ReportViewer1.LocalReport.SetParameters(new ReportParameter[] { parameter, parameter2, parameter3, parameter4, parameter5, parameter6, parameter7, parameter8, parameter9, parameter10, parameter11, parameter12 });
                }
            }
        }


        /////
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ERPSSL.FA.BLL;
using System.Data;
using Microsoft.Reporting.WebForms;
using System.Collections;
using SSL.FA.BLL;

namespace ERPSSL.FA
{
    public partial class Register_RPT : System.Web.UI.Page
    {
        Register_Report_BLL RegisterBll = new Register_Report_BLL();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                FillRegion();
            }
        }
        //Reporting......................................................................................
        private void BindReportHeader(DataTable dt, string Type)
        {
            if (dt.Rows.Count == 1)
            {
                if (Type == "IndividualItem")
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        ReportParameter prm_1 = new ReportParameter("CompanyName", dr["CompanyName"].ToString());
                        ReportParameter prm_2 = new ReportParameter("CompanyAddress", dr["CompanyAddress"].ToString());
                        ReportParameter prm_3 = new ReportParameter("AssetCode", dr["AssetCode"].ToString());
                        ReportParameter prm_4 = new ReportParameter("CustomAssetName", dr["CustomAssetName"].ToString());
                        ReportParameter prm_5 = new ReportParameter("GroupName", dr["GroupName"].ToString());
                        ReportParameter prm_8 = new ReportParameter("Method", dr["Method"].ToString());
                        ReportParameter prm_6 = new ReportParameter("Rate", dr["Rate"].ToString());
                        ReportParameter prm_7 = new ReportParameter("Duration", dr["Duration"].ToString());

                        ReportViewer1.LocalReport.SetParameters(new ReportParameter[] { prm_1, prm_2, prm_3, prm_4, prm_5, prm_6, prm_7, prm_8 });
                    }
                }
                else if (Type == "Summary")
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        ReportParameter prm_1 = new ReportParameter("CompanyName", dr["CompanyName"].ToString());
                        ReportParameter prm_2 = new ReportParameter("CompanyAddress", dr["CompanyAddress"].ToString());
                        ReportParameter prm_8 = new ReportParameter("Method", dr["Method"].ToString());
                        ReportParameter prm_7 = new ReportParameter("Duration", dr["Duration"].ToString());

                        ReportViewer1.LocalReport.SetParameters(new ReportParameter[] { prm_1, prm_2, prm_7, prm_8 });
                    }
                }
            }
        }
        //................
        private void BindReport(DataTable CompanyData, DataTable data, string AsPer, string Type)
        {
            ReportViewer1.LocalReport.DataSources.Clear();
            if (Type == "Summary") //IndividualItem
            {
                if (AsPer == "Accounting")
                {
                    ReportDataSource reportDataset = new ReportDataSource("RegisterByGroup_DS", data);
                    ReportViewer1.LocalReport.DataSources.Add(reportDataset);
                    ReportViewer1.LocalReport.ReportPath = Server.MapPath("Reports/FA_RegisterByGroupACC.rdlc");
                }
                else if (AsPer == "Tax")
                {
                    ReportDataSource reportDataset = new ReportDataSource("RegisterByGroup_DS", data);
                    ReportViewer1.LocalReport.DataSources.Add(reportDataset);
                    ReportViewer1.LocalReport.ReportPath = Server.MapPath("Reports/FA_RegisterByGroupTax.rdlc");
                }
            }
            else if (Type == "IndividualItem")
            {

                if (AsPer == "Accounting")
                {
                    ReportDataSource reportDataset = new ReportDataSource("RegisterByAssetCode_DS", data);
                    ReportViewer1.LocalReport.DataSources.Add(reportDataset);
                    ReportViewer1.LocalReport.ReportPath = Server.MapPath("Reports/FA_RegisterByAssetCodeACC.rdlc");
                }
                else if (AsPer == "Tax")
                {
                    ReportDataSource reportDataset = new ReportDataSource("RegisterByAssetCode_DS", data);
                    ReportViewer1.LocalReport.DataSources.Add(reportDataset);
                    ReportViewer1.LocalReport.ReportPath = Server.MapPath("Reports/FA_RegisterByAssetCodeTax.rdlc");
                }
            }
            BindReportHeader(CompanyData, Type);
            ReportViewer1.LocalReport.Refresh();

        }

        //.......

        //...............................................................................................
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
            ddlAsset.DataSource = RegisterBll.GetStockAssetsByDepartment(ddlDepartment.SelectedValue);
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
            FillAssets();
        }

        protected void ddlAsset_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtAssetCode.Text = ddlAsset.SelectedValue;
        }

        protected void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string SummaryOrIndivudual = RadioButtonList1.SelectedValue;
                if (SummaryOrIndivudual == "IndividualItem")
                {
                    string AsPer = rdoAsPer.SelectedValue;
                    Hashtable ht = new Hashtable();
                    ht.Add("DateFrom", txtDateFrom.Text);
                    ht.Add("DateTo", txtDateTo.Text);
                    ht.Add("AssetCode", txtAssetCode.Text);
                    ht.Add("AsPer", rdoAsPer.SelectedValue);
                    ht.Add("OCode", ((SessionUser)base.Session["SessionUser"]).OCode);
                    //ht.Add("OCode", "8989");

                    DataTable dt = new DataTable();
                    DataSet ds = new DataSet();
                    ds = ReportsBll.AssetRegister(ht, SummaryOrIndivudual);
                    DataTable data = ds.Tables[0];
                    DataTable dtCompany = ds.Tables[1];
                    BindReport(dtCompany, data, AsPer, RadioButtonList1.SelectedValue);
                }
                else if (SummaryOrIndivudual == "Summary")
                {
                    string AsPer = rdoAsPer.SelectedValue;
                    Hashtable ht = new Hashtable();
                    ht.Add("DateFrom", txtDateFrom.Text);
                    ht.Add("DateTo", txtDateTo.Text);
                    ht.Add("AsPer", rdoAsPer.SelectedValue);
                    ht.Add("OCode", ((SessionUser)base.Session["SessionUser"]).OCode);
                    //ht.Add("OCode", "8989");

                    DataTable dt = new DataTable();
                    DataSet ds = new DataSet();
                    ds = ReportsBll.AssetRegister(ht, SummaryOrIndivudual);
                    DataTable data = ds.Tables[0];
                    DataTable dtCompany = ds.Tables[1];
                    BindReport(dtCompany, data, AsPer, SummaryOrIndivudual);
                }

            }
            catch
            {

            }
        }
    }
}
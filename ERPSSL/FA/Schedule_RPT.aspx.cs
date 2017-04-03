using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Reporting.WebForms;
using System.Data;
using System.Collections;
using SSL.FA.BLL;

namespace ERPSSL.FA
{
    public partial class Schedule_RPT : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnSave_Click(object sender, EventArgs e)
        {
            try
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
                ds = ReportsBll.AssetSchedule(ht);
                DataTable data = ds.Tables[0];
                DataTable dtCompany = ds.Tables[1];
                BindReport(dtCompany, data, AsPer);
            }
            catch
            {

            }
        }
        private void BindReportHeader(DataTable dt)
        {
            if (dt.Rows.Count == 1)
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

        private void BindReport(DataTable CompanyData, DataTable data, string AsPer)
        {
            ReportViewer1.LocalReport.DataSources.Clear();

            if (AsPer == "Accounting")
            {
                ReportDataSource reportDataset = new ReportDataSource("Schedule_DS", data);
                ReportViewer1.LocalReport.DataSources.Add(reportDataset);
                ReportViewer1.LocalReport.ReportPath = Server.MapPath("Reports/FA_ScheduleACC.rdlc");
            }
            else if (AsPer == "Tax")
            {
                ReportDataSource reportDataset = new ReportDataSource("Schedule_DS", data);
                ReportViewer1.LocalReport.DataSources.Add(reportDataset);
                ReportViewer1.LocalReport.ReportPath = Server.MapPath("Reports/FA_ScheduleTax.rdlc");
            }

            BindReportHeader(CompanyData);
            ReportViewer1.LocalReport.Refresh();

        }

    }
}
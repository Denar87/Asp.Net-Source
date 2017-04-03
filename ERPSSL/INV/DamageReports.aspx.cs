using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ERPSSL.INV.BLL;
using Microsoft.Reporting.WebForms;

namespace ERPSSL.INV
{
    public partial class DamageReports : System.Web.UI.Page
    {
        ReportsBll rpt = new ReportsBll();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnGenerateReport_Click(object sender, EventArgs e)
        {
            try
            {
                Hashtable ht = new Hashtable();
                string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                ht.Add("DateFrom", txtFrom.Text);
                ht.Add("DateTo", txtTo.Text);
                ht.Add("Ocode", OCODE);
                //ht.Add("CompanyFromCode", ddlStoreFrom.SelectedValue);
                //ht.Add("ChallanNo", txtGINNo.Text);
                //ht.Add("EID", TxtEmployeeId.Text);
                //ht.Add("ProductGroupId", ddlItemGroup.SelectedValue);
                //ht.Add("ProductId", ddlItemName.SelectedValue);
                DataTable dt = new DataTable();
                dt = rpt.GetDamageReportData(ht);
                if (dt != null)
                {
                    ReportViewer1.LocalReport.DataSources.Clear();
                    ReportDataSource reportDataset = new ReportDataSource("AllDamage_RPT_DS", dt);
                    ReportViewer1.LocalReport.DataSources.Add(reportDataset);
                    ReportViewer1.LocalReport.ReportPath = Server.MapPath("Reports/AllItemDamageReport_RPT.rdlc");
                    ReportViewer1.LocalReport.Refresh();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No Data found!')", true);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

    }
}
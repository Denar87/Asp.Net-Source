using ERPSSL.HMS.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MoreLinq;

namespace ERPSSL.HMS
{
    public partial class Reports : System.Web.UI.Page
    {
        PatientBillEntry_BLL objBll = new PatientBillEntry_BLL();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnProcess_Click(object sender, EventArgs e)
        {
            string OCODE = ((SessionUser)Session["SessionUser"]).OCode;

            if (rdBillDetails.Checked)
            {
                if (txtDateFrom.Text != "" && txtbxToDate.Text != "")
                {

                    var billDetails = objBll.GetAllPatientBillDetailsForReport(txtDateFrom.Text, txtbxToDate.Text, OCODE).ToList();

                    if (billDetails.Count > 0)
                    {
                        Session["rptDs"] = "DS_PatientBillDetails";
                        Session["rptDt"] = billDetails;
                        Session["rptFile"] = "/HMS/Reports/HMS_Rpt_AllPatientBillDetailsByDate.rdlc";
                        Session["rptTitle"] = "Patient Bill Details";
                        Response.Redirect("Report_Viewer.aspx");
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No data found!')", true);
                    }
                }
            }

            else if (rdPatientSummary.Checked)
            {
                if (txtDateFrom.Text != "" && txtbxToDate.Text != "")
                {
                    var billSummary = objBll.GetPatientSummaryBillForReport(txtDateFrom.Text, txtbxToDate.Text, OCODE).ToList();

                    if (billSummary.Count > 0)
                    {
                        Session["rptDs"] = "DS_PatientBillSummary";
                        Session["rptDt"] = billSummary;
                        Session["rptFile"] = "/HMS/Reports/HMS_Rpt_PatientBillSummary.rdlc";
                        Session["rptTitle"] = "Patient Bill Summary";
                        Response.Redirect("Report_Viewer.aspx");
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No data found!')", true);
                    }
                }
            }

            else if (rdbillByPatietId.Checked)
            {
                if (txtId.Text != "")
                {
                   
                    int _patientId = Convert.ToInt32(txtId.Text);

                    var bill = objBll.GetPatientBillInfoForReport(_patientId, OCODE).ToList().DistinctBy(x => x.Bill_Head_Name);

                    if (bill != null)
                    {
                        Session["rptDs"] = "ds_BillInfo";
                        Session["rptDt"] = bill;
                        Session["rptFile"] = "/HMS/reports/HMS_Rpt_PatientBillInfo.rdlc";
                        Session["rptTitle"] = "Patient Bill Receipt";
                        Response.Redirect("Report_Viewer.aspx");
                        
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No data found!')", true);
                    }
                }
            }
            else if (rdCollectionAmt.Checked)
            {
                if (txtDateFrom.Text != "" && txtbxToDate.Text != "")
                {
                    var collectionAmt = objBll.GetTotalCollectionAmountForReport(txtDateFrom.Text, txtbxToDate.Text, OCODE).ToList();

                    if (collectionAmt.Count > 0)
                    {
                        Session["rptDs"] = "DS_CollectionAmt";
                        Session["rptDt"] = collectionAmt;
                        Session["rptFile"] = "/HMS/Reports/HMS_Rpt_CollectionAmtDateWise.rdlc";
                        Session["rptTitle"] = "Collection Amount";
                        Response.Redirect("Report_Viewer.aspx");
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No data found!')", true);
                    }
                }
            }
            else if (rdDischargePatient.Checked)
            {
                if (txtDateFrom.Text != "" && txtbxToDate.Text != "")
                {
                    var disPatient = objBll.GetTotalDischargePatientForReport(txtDateFrom.Text, txtbxToDate.Text, OCODE).ToList();

                    if (disPatient.Count > 0)
                    {
                        Session["rptDs"] = "DS_DischargePatient";
                        Session["rptDt"] = disPatient;
                        Session["rptFile"] = "/HMS/Reports/HMS_Rpt_DischargePatientDateWise.rdlc";
                        Session["rptTitle"] = "Discharge Patient";
                        Response.Redirect("Report_Viewer.aspx");
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No data found!')", true);
                    }
                }
            }
        }
    }
}
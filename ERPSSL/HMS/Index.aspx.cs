
using ERPSSL.HMS.BLL;
using ERPSSL.HMS.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ERPSSL.HMS
{
    public partial class Index : System.Web.UI.Page
    {
        HMSDashboard_BLL objDashboardBll = new HMSDashboard_BLL();
        private ERPSSL_HMSEntities _context = new ERPSSL_HMSEntities();

        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Session["UserID"] != null) && (Session["OCode"] != null))
            {
                GetNumberOfAdmittedPatient();
                GetCurrentMonthAdmittedPatient();
                GetLastMonthAdmittedPatient();
                GetCurrentMonthCollection();
                GetLastMonthCollection ();
                GetCurrentMonthDischagePatient();
                GetLastMonthDischagePatient();
                TotalReceivable();
            }
            else
            {
                Response.Redirect("..\\AppGateway\\Login.aspx");
            }
        }

        public void GetNumberOfAdmittedPatient()
        {
            List<int> patientList = objDashboardBll.GetNumberOfAdmittedPatient();

            int numberOfAdmittedPatient = patientList.Count;
            lblAdmittedPatient.Text = numberOfAdmittedPatient.ToString();
        }
        public void GetCurrentMonthAdmittedPatient()
        {
            int nowMonth = DateTime.Now.Month;
            int nowYear = DateTime.Now.Year;
            
            List<int> patientList = objDashboardBll.GetCurrentMonthAdmittedPatient(nowMonth,nowYear);

            int numberOfCurrentMonthAdmittedPatient = patientList.Count;
            lblCurrMonthAdmitted.Text = numberOfCurrentMonthAdmittedPatient.ToString();
        }
        public void GetLastMonthAdmittedPatient()
        {

            // Find previous year and month

            var today = DateTime.Today;
            var month = new DateTime(today.Year, today.Month, 1);
            var first = month.AddMonths(-1);
            var last = month.AddDays(-1);
            int lastMonth = first.Month;
            int lastYear = first.Year;

            List<int> patientList = objDashboardBll.GetLastMonthAdmittedPatient(lastMonth, lastYear);

            int numberOfLastMonthAdmittedPatient = patientList.Count;
            lblLastMonthAdmitted.Text = numberOfLastMonthAdmittedPatient.ToString();
        }
        public void GetCurrentMonthCollection()
        {
            int nowMonth = DateTime.Now.Month;
            int nowYear = DateTime.Now.Year;

            var totalAmount = (from t in _context.HMS_PatientCollectionSummary
                               where t.CollectionDate.Value.Month == nowMonth && t.CollectionDate.Value.Year == nowYear
                               select t.CollectionAmount).Sum();

            lblCurrMonthCollection.Text = String.Format("{0:0.00}", totalAmount);

            
        }

        public void GetLastMonthCollection()
        {
            var today = DateTime.Today;
            var month = new DateTime(today.Year,today.Month,1);
            var first = month.AddMonths(-1);
            var last = month.AddDays(-1);
            int lastMonth = first.Month;
            int lastYear = first.Year;

            var totalAmount = (from t in _context.HMS_PatientCollectionSummary
                               where t.CollectionDate.Value.Month == lastMonth && t.CollectionDate.Value.Year == lastYear
                               select t.CollectionAmount).Sum();

            lblLastMonthCollection.Text = String.Format("{0:0.00}", totalAmount);


        }
        public void GetCurrentMonthDischagePatient()
        {
            int nowMonth = DateTime.Now.Month;
            int nowYear = DateTime.Now.Year;

            var query = (from t in _context.HMS_PatientCollectionSummary
                         where t.DisChargeDate.Value.Month == nowMonth && t.DisChargeDate.Value.Year == nowYear 
                         select t.PatientID);

            int patient = query.Count();
            lblCurrMonthDischarge.Text = patient.ToString();


        }

        public void GetLastMonthDischagePatient()
        {
            var today = DateTime.Today;
            var month = new DateTime(today.Year, today.Month, 1);
            var first = month.AddMonths(-1);
            var last = month.AddDays(-1);
            int lastMonth = first.Month;
            int lastYear = first.Year;

            var query = (from t in _context.HMS_PatientCollectionSummary
                         where t.DisChargeDate.Value.Month == lastMonth && t.DisChargeDate.Value.Year == lastYear
                         select t.PatientID);
            int patient = query.Count();
            lblLastMonthDischarge.Text = patient.ToString();


        }

        public void TotalReceivable()
        {
            var totalAmt = (from t in _context.HMS_PatientBillInfo
                            select t.TotalAmount).Sum();
            var CollectAmt = (from t in _context.HMS_PatientCollectionSummary
                                  select t.CollectionAmount).Sum();
            var serviceAmt = (from t in _context.HMS_PatientCollectionSummary
                            select t.ServiceCharge_Percent).Sum();
            var discAmt = (from t in _context.HMS_PatientCollectionSummary
                            select t.Discount_Percent).Sum();

            var dueAmt = (totalAmt + serviceAmt - discAmt )- CollectAmt;
            lblTotaReceivable.Text = String.Format("{0:0.00}", dueAmt);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ERPSSL.HRM.BLL;
using ERPSSL.HRM.DAL;

namespace ERPSSL.Dashboard
{
    public partial class EmployeeDashboard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // GetEmployeeDetails();
            //GetEmployeeAttendence();

        }

        private void GetEmployeeDetails()
        {
            EMPOYEE_BLL _employeedetailsbll = new EMPOYEE_BLL();
            try
            {
                string id = ((SessionUser)Session["SessionUser"]).EID;
                HRM_PersonalInformations _employeeDetailsr = _employeedetailsbll.GetEmployeeDetails(id);
                if (_employeeDetailsr != null)
                {
                    lblServiceAge.Text = ServiceDays(_employeeDetailsr);
                    DateTime join = Convert.ToDateTime(_employeeDetailsr.JoiningDate);
                    lblJoinDate.Text = join.ToString("MM/dd/yyyy");

                    DateTime DOB = Convert.ToDateTime(_employeeDetailsr.DateOfBrith);
                    lblDOB.Text = DOB.ToString("MM/dd/yyyy");

                    lblBloodGroup.Text = _employeeDetailsr.BloodGroup.ToString();
                    lblFather.Text = _employeeDetailsr.FatherName.ToString();
                    lblMother.Text = _employeeDetailsr.MotherName.ToString();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private string ServiceDays(HRM_PersonalInformations _employeeDetailsr)
        {

            int years = -1, months = -1, days = -1;
            DateTime birthDate = Convert.ToDateTime(_employeeDetailsr.JoiningDate);
            return TimeSpanToDate(DateTime.Now, birthDate, out years, out months, out days);
        }

        public string TimeSpanToDate(DateTime d1, DateTime d2, out int years, out int months, out int days)
        {
            // compute & return the difference of two dates,
            // returning years, months & days
            // d1 should be the larger (newest) of the two dates
            // we want d1 to be the larger (newest) date
            // flip if we need to
            if (d1 < d2)
            {
                DateTime d3 = d2;
                d2 = d1;
                d1 = d3;
            }

            // compute difference in total months
            months = 12 * (d1.Year - d2.Year) + (d1.Month - d2.Month);

            // based upon the 'days',
            // adjust months & compute actual days difference
            if (d1.Day < d2.Day)
            {
                months--;
                days = DateTime.DaysInMonth(d2.Year, d2.Month) - d2.Day + d1.Day;
            }
            else
            {
                days = d1.Day - d2.Day;
            }
            // compute years & actual months
            years = months / 12;
            months -= years * 12;
            return (years + " Year" + " " + months + " Month").ToString();
        }

        private void GetEmployeeAttendence()
        {
            EMPOYEE_BLL _employeedetailsbll = new EMPOYEE_BLL();

            try
            {
                string id = ((SessionUser)Session["SessionUser"]).EID;
                HRM_PersonalInformations _employeeDetailsr = _employeedetailsbll.GetEmployeeDetails(id);
                string status = "All";
                DateTime Date = DateTime.Now;
                // string StartDate = startdate.ToString("MM/dd/yyyy");
                string StartDate = Date.AddMonths(-1).ToString("MM/dd/yyyy");

                string endDate = Date.AddDays(-1).ToString("MM/dd/yyyy");
                var _employeeAttends = _employeedetailsbll.GetEmployeeAttend(id, status, StartDate, endDate);
                if (_employeeAttends != null)
                {
                    lblTotalPresent.Text = _employeeAttends.TotalPresent.ToString();
                    lblTotalAbsent.Text = _employeeAttends.TotalAbsent.ToString();
                    lblTotalLate.Text = _employeeAttends.TotalLate.ToString();
                    lblTotalLeave.Text = _employeeAttends.TotalLeave.ToString();
                    lblTOtlaOt.Text = _employeeAttends.TotalOT.ToString();

                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
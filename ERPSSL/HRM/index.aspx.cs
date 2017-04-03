using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ERPSSL;
using ERPSSL.Dashboard.Repository;
using ERPSSL.Dashboard.BLL;
using System.Web.Services;

namespace ERPSSL.HRM
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Session["UserID"] != null) && (Session["OCode"] != null))
            {
                if (!IsPostBack)
                {
                    GetEmployeeDetails();
                    GetAttendanceDetails();
                    GetLastMonthEmpDetails();
                }
            }
            else
            {
                Response.Redirect("..\\AppGateway\\Login.aspx");
            }
        }
        private void GetAttendanceDetails()
        {
            EmployeeDetailsBLL _employeedetailsbll = new EmployeeDetailsBLL();

            try
            {
                string status="";
                string startdate = "";
                string endDate = "";
                AttendanceDetailsR _attendanceDetailsR = _employeedetailsbll.GetAttendanceDetails();
                if (_attendanceDetailsR != null)
                {
                    lblTotalPresent.Text = _attendanceDetailsR.TotalPresent.ToString();
                    lblTotalAbsent.Text = _attendanceDetailsR.TotalAbsent.ToString();
                    lblTotalLate.Text = _attendanceDetailsR.TotalLate.ToString();
                    lblTotalLeave.Text = _attendanceDetailsR.TotalLeave.ToString();
                    lblTOtlaOt.Text = _attendanceDetailsR.TotalOT.ToString();
                    lblTotalEmp.Text = _attendanceDetailsR.CurrentEmployee.ToString();
                    //string mn = cTestChart.FindControl("amni").ToString();
                    //mn = _attendanceDetailsR.TotalPresent.ToString();

                }


            }
            catch (Exception)
            {

                throw;
            }


        }

        private void GetEmployeeDetails()
        {
            EmployeeDetailsBLL _employeedetailsbll = new EmployeeDetailsBLL();

            try
            {
                EmployeeDetailsR _employeeDetailsr = _employeedetailsbll.GetEmployeeDetails();
                if (_employeeDetailsr != null)
                {
                    lblTotalEmployee.Text = _employeeDetailsr.TotalEmployee.ToString();
                    lblTotalSepartion.Text = _employeeDetailsr.TotalInactive.ToString();
                    lblCurrentEmp.Text = _employeeDetailsr.CurrentEmp.ToString();
                    lblTotalFemale.Text = _employeeDetailsr.TotalFemale.ToString();
                    lblTotalMale.Text = _employeeDetailsr.TotalMale.ToString();
                    lblNewjoining.Text = _employeeDetailsr.TotalNewJoin.ToString();

                }


            }
            catch (Exception)
            {

                throw;
            }
        }

        private void GetLastMonthEmpDetails()
        {
            EmployeeDetailsBLL _employeedetailsbll = new EmployeeDetailsBLL();

            try
            {
                EmployeeDetailsR _employeeDetailsr = _employeedetailsbll.GetLastMonthEmpDetails();
                if (_employeeDetailsr != null)
                {
                    lblLastTotalEmp.Text = _employeeDetailsr.LastMonthCurrentEmp.ToString();
                    lblLastLeft.Text = _employeeDetailsr.TotalSeperation.ToString();
                    lblLastNewJoining.Text = _employeeDetailsr.LastaMonthTotalNewJoin.ToString();
                    lblLastOTHour.Text = _employeeDetailsr.TotalOverTime.ToString();
                    lblLastOTTaka.Text = _employeeDetailsr.TotalOTTaka.ToString();
                    lblTotalSal.Text = _employeeDetailsr.TotalGrossSalary.ToString();

                }


            }
            catch (Exception)
            {

                throw;
            }
        }

        public class EmployeeDetailsd
        {
            public string TotalActionEmp { get; set; }
            public int TotalNewJoin { get; set; }
        }
        public class AttendanceDetailsd
        {
            public string totalPresent { get; set; }
            public int totalAbsent { get; set; }

        }
        public class LastMonthEmployeeDetails
        {
            public string totalEmp { get; set; }
            public int TotalValue { get; set; }

        }

        [WebMethod]
        public static List<EmployeeDetailsd> GetChartDatad()
        {
            //string sConnString = "Data Source=192.168.0.7;Initial Catalog=ERPSSL_Crescent;User ID=sa;Password=ssl@1234;Connect Timeout=30;";
            //SqlConnection con = new SqlConnection(sConnString);

            //SqlCommand cmd = new SqlCommand("select Top 1 FirstName as TotalActionEmp, count (FirstName) as TotalNewJoin  from HRM_PersonalInformations where EID='00001'", con);
            //   // cmd.CommandType = CommandType.TableDirect;
            //    SqlDataAdapter da = new SqlDataAdapter();
            //    da.SelectCommand = cmd;
            //    DataTable dt = new DataTable();
            //    da.Fill(dt);
            EmployeeDetailsBLL _employeedetailsbll = new EmployeeDetailsBLL();
            EmployeeDetailsR _employeeDetailsr = _employeedetailsbll.GetEmployeeDetails();

            int TotalEmp = Convert.ToInt32(_employeeDetailsr.TotalEmployee.ToString());
            int TotalSeperation = Convert.ToInt32(_employeeDetailsr.TotalInactive.ToString());
            int CurrentEmp = Convert.ToInt32(_employeeDetailsr.CurrentEmp.ToString());
            int NewJoining = Convert.ToInt32(_employeeDetailsr.TotalNewJoin.ToString());
            int TotalMale = Convert.ToInt32(_employeeDetailsr.TotalMale.ToString());
            int TotalFemal = Convert.ToInt32(_employeeDetailsr.TotalFemale.ToString());



            List<EmployeeDetailsd> dataList = new List<EmployeeDetailsd>() { 
                new EmployeeDetailsd{TotalActionEmp="Total Employee",TotalNewJoin=TotalEmp },
                 new EmployeeDetailsd{TotalActionEmp="Total Seperation",TotalNewJoin=TotalSeperation },
                 new EmployeeDetailsd{TotalActionEmp="Current Employee",TotalNewJoin=CurrentEmp },
                   new EmployeeDetailsd{TotalActionEmp="Total Male",TotalNewJoin=TotalMale },
                   new EmployeeDetailsd{TotalActionEmp="Total Female",TotalNewJoin=TotalFemal },
                     new EmployeeDetailsd{TotalActionEmp="New Joining",TotalNewJoin=NewJoining }
                   
                
                };

            //foreach (DataRow dtrow in dt.Rows)
            //{
            //    EmployeeDetails details = new EmployeeDetails();
            //    details.TotalActionEmp = dtrow[0].ToString();
            //    details.TotalNewJoin = (int)dtrow[1];

            //    dataList.Add(details);
            //}
            return dataList;
        }

        [WebMethod]
        public static List<AttendanceDetailsd> GetAttendanceDatad()
        {

            EmployeeDetailsBLL _employeedetailsbll = new EmployeeDetailsBLL();
            AttendanceDetailsR _attendanceDetailsR = _employeedetailsbll.GetAttendanceDetails();

            int TotalPresent = Convert.ToInt32(_attendanceDetailsR.TotalPresent.ToString());
            int TotalAbsent = Convert.ToInt32(_attendanceDetailsR.TotalAbsent.ToString());
            int TotalLate = Convert.ToInt32(_attendanceDetailsR.TotalLate.ToString());
            int TotalLeave = Convert.ToInt32(_attendanceDetailsR.TotalLeave.ToString());
            int TotalOt = Convert.ToInt32(_attendanceDetailsR.TotalOT.ToString());
            int TotalEmp = Convert.ToInt32(_attendanceDetailsR.CurrentEmployee.ToString());

            List<AttendanceDetailsd> dataAttd = new List<AttendanceDetailsd>() { 
                 new AttendanceDetailsd{totalPresent="Total",totalAbsent=TotalEmp },
                new AttendanceDetailsd{totalPresent="Present",totalAbsent=TotalPresent },
                   new AttendanceDetailsd{totalPresent="Absent",totalAbsent=TotalAbsent },
                   new AttendanceDetailsd{totalPresent="Late",totalAbsent=TotalLate },
                   new AttendanceDetailsd{totalPresent="Leave",totalAbsent=TotalLeave },
                    new AttendanceDetailsd{totalPresent="OT",totalAbsent=TotalOt }
                
                };


            return dataAttd;
        }

        [WebMethod]
        public static List<LastMonthEmployeeDetails> GetLastMonthEmp()
        {

            EmployeeDetailsBLL _employeedetailsbll = new EmployeeDetailsBLL();
            EmployeeDetailsR _employeeDetailsr = _employeedetailsbll.GetLastMonthEmpDetails();

            int LastMonthCurrentEmp = Convert.ToInt32(_employeeDetailsr.LastMonthCurrentEmp.ToString());
            int TotalSeperation = Convert.ToInt32(_employeeDetailsr.TotalSeperation.ToString());
            int TotalOverTime = Convert.ToInt32(_employeeDetailsr.TotalOverTime.ToString());
            int TotalOTTaka = Convert.ToInt32(_employeeDetailsr.TotalOTTaka.ToString());
            int LastaMonthTotalNewJoin = Convert.ToInt32(_employeeDetailsr.LastaMonthTotalNewJoin.ToString());
            int TotalGrossSalary = Convert.ToInt32(_employeeDetailsr.TotalGrossSalary.ToString());

            List<LastMonthEmployeeDetails> dataAttd = new List<LastMonthEmployeeDetails>() { 
                 new LastMonthEmployeeDetails{totalEmp="Current Emp",TotalValue=LastMonthCurrentEmp },
                new LastMonthEmployeeDetails{totalEmp="Total Left",TotalValue=TotalSeperation },
                   new LastMonthEmployeeDetails{totalEmp="Total OT",TotalValue=TotalOverTime },
                   new LastMonthEmployeeDetails{totalEmp="Total OT Taka",TotalValue=TotalOTTaka },
                   new LastMonthEmployeeDetails{totalEmp="New Join",TotalValue=LastaMonthTotalNewJoin },
                    new LastMonthEmployeeDetails{totalEmp="Total Salary",TotalValue=TotalGrossSalary }
                
                };


            return dataAttd;
        }
    }
}

using ERPSSL.Dashboard.Repository;
using ERPSSL.Dashboard.BLL;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using System.Data.SqlClient;
using System.Configuration;


namespace ERPSSL.Dashboard
{
    public partial class Deshboard1 : System.Web.UI.Page
    {

        StringBuilder str = new StringBuilder();
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Session["UserID"] != null) && (Session["OCode"] != null))
            {
                if (!IsPostBack)
                {
                    GetEmployeeDetails();
                    GetAttendanceDetails();
                    GetInventoryDetails();
                    GetPosDetails();
                    //GetCommercialDetails();
                    //Employee_Details();
                    //GetChartData();
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
        //private void GetCommercialDetails()
        //{
        //    EmployeeDetailsBLL _employeedetailsbll = new EmployeeDetailsBLL();

        //    try
        //    {
        //        Commercial _Commercial = _employeedetailsbll.GetCommercialDetails();
        //        if (_Commercial != null)
        //        {
        //            lblEnquery.Text = _Commercial.TotalEnquery.ToString();
        //            lblSurvey.Text = _Commercial.TotalSurvey.ToString();
        //            lblQuation.Text = _Commercial.TotalQuotation.ToString();
        //            lblJob.Text = _Commercial.TotalJob.ToString();

        //        }


        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }


        //}
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

        private void GetInventoryDetails()
        {
            EmployeeDetailsBLL _employeedetailsbll = new EmployeeDetailsBLL();

            try
            {
                InventoryDetailsR _inventory = _employeedetailsbll.GetInventoryDetails();
                if (_inventory != null)
                {
                    lblTotalStock.Text = _inventory.TotalStock.ToString();
                    lblTotalPurchase.Text = _inventory.TotalPurchase.ToString();
                    lblTotalIssue.Text = _inventory.TotalIssue.ToString();
                    lblTotalDamage.Text = _inventory.TotalDamage.ToString();
                    lblTotalReturn.Text = _inventory.TotalReturn.ToString();
                }


            }
            catch (Exception)
            {

                throw;
            }
        }

        private void GetPosDetails()
        {
            EmployeeDetailsBLL _employeedetailsbll = new EmployeeDetailsBLL();

            try
            {
                POSDetails _Pos = _employeedetailsbll.GetPosDetails();
                if (_Pos != null)
                {
                    lblTicketSale.Text = _Pos.TicketSale.ToString();
                    lblFoodSale.Text = _Pos.FoodSale.ToString();

                }


            }
            catch (Exception)
            {

                throw;
            }
        }


        //        private void BindChart_()
        //        {
        //            try
        //            {
        //                Hashtable ht = new Hashtable();

        //                ht.Add("ChartType", "Monthly");
        //                ht.Add("Company_Code", Session["CompanyCode"]);
        //                ht.Add("OCode", Session["OCode"]);

        //                //DataTable dt = objChart_DAL.GetEmployeeChart(ht);
        //                //if (dt.Rows.Count > 0)
        //                //{
        //                    str.Append(@"<script type=text/javascript> google.load( 'visualization', '1.1', {packages:['corechart']});
        //                       google.setOnLoadCallback(drawChart);
        //                       function drawChart()
        //                       {
        //
        //                        var data = new google.visualization.DataTable();
        //                        data.addColumn('string', 'Year-Month');
        //                        data.addColumn('number', 'Income');
        //                        data.addColumn('number', 'Expense');       
        //                        data.addRows(" + dt.Rows.Count + ");");
        //                    for (int i = 0; i <= dt.Rows.Count - 1; i++)
        //                    {
        //                        str.Append("data.setValue( " + i + "," + 0 + "," + "'" + dt.Rows[i]["Year"].ToString() + "');");
        //                        str.Append("data.setValue(" + i + "," + 1 + "," + dt.Rows[i]["TotalIncome"].ToString() + ") ;");
        //                        str.Append("data.setValue(" + i + "," + 2 + "," + dt.Rows[i]["TotalExpense"].ToString() + ") ;");
        //                    }

        //                    str.Append(" var options = {curveType: 'function',pointSize: 20,legend: { position: 'bottom' },width: 950, height: 250, title: 'Income Statement of " + Session["Company_Name"].ToString() + "',subtitle: 'Income, Expense, and Profit',vAxis: {title: 'Amount', titleTextStyle: {color: 'green'}},hAxis: {title: 'Year', titleTextStyle: {color: 'green'}}};");
        //                    str.Append(" var chart = new google.visualization.LineChart(document.getElementById('chart_div'));");
        //                    str.Append(" chart.draw(data, options);");

        //                    str.Append(" }");
        //                    str.Append("</script>");
        //                   // lt.Text = str.ToString().TrimEnd(',').Replace('*', '"');
        //                //}
        //            }
        //            catch (Exception ex)
        //            {
        //                //lblMessage.Text = ex.Message.ToString();
        //                //messagePanel.BackColor = Color.Red;
        //                //this.lblMessage.ForeColor = Color.White;
        //            }
        //        }
        public class EmployeeDetails
        {
            public string TotalActionEmp { get; set; }
            public int TotalNewJoin { get; set; }
        }
        public class AttendanceDetails
        {
            public string totalPresent { get; set; }
            public int totalAbsent { get; set; }

        }

        public class InventoryDetails
        {
            public string totalStock { get; set; }
            public int totalIssue { get; set; }
        }

        public class POS_Details
        {
            public string Ticket_Sale { get; set; }
            public int Food_Sale { get; set; }
        }
        public class Commercial_Details
        {
            public string TotalNumber { get; set; }
            public int TotalValue { get; set; }
        }

        //public List<EmployeeDetails> Employee_Details()
        //{
        //    List<EmployeeDetails> lstSales = new List<EmployeeDetails>();

        //    string sConnString = "Data Source=192.168.0.7;Initial Catalog=ERPSSL_Crescent;User ID=sa;Password=ssl@1234;Connect Timeout=30;";

        //    SqlConnection myConn = new SqlConnection(sConnString);
        //    SqlCommand objComm = new SqlCommand(@"select count(EID) as TotalActionEmp,count (JoiningDate) as TotalNewJoin  from HRM_PersonalInformations", myConn);
        //    myConn.Open();

        //    SqlDataReader sdr = objComm.ExecuteReader();

        //    while (sdr.Read())
        //    {
        //        EmployeeDetails objValues = new EmployeeDetails();
        //        objValues.TotalActionEmp =(int) sdr["TotalActionEmp"];
        //        objValues.TotalNewJoin = (int)sdr["TotalNewJoin"];

        //        lstSales.Add(objValues);
        //    }

        //    myConn.Close();
        //    sdr.Close();
        //    return lstSales;

        //}
        //[WebMethod]
        //public static List<Commercial_Details> GetCommercialData()
        //{

        //    EmployeeDetailsBLL _employeedetailsbll = new EmployeeDetailsBLL();
        //    Commercial _Commercial = _employeedetailsbll.GetCommercialDetails();

        //    int TotalEnquery = Convert.ToInt32(_Commercial.TotalEnquery.ToString());
        //    int TotalSurvey = Convert.ToInt32(_Commercial.TotalSurvey.ToString());
        //    int TotalQuation = Convert.ToInt32(_Commercial.TotalQuotation.ToString());
        //    int TotalJobs = Convert.ToInt32(_Commercial.TotalJob.ToString());



        //    List<Commercial_Details> dataAtt = new List<Commercial_Details>() { 
        //        new Commercial_Details{TotalNumber="Total Enquiry",TotalValue=TotalEnquery },
        //           new Commercial_Details{TotalNumber="Total Survey",TotalValue=TotalSurvey },
        //           new Commercial_Details{TotalNumber="Total Quotation",TotalValue=TotalQuation },
        //           new Commercial_Details{TotalNumber="Total Job",TotalValue=TotalJobs }


        //        };


        //    return dataAtt;
        //}

        [WebMethod]
        public static List<EmployeeDetails> GetChartData()
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



            List<EmployeeDetails> dataList = new List<EmployeeDetails>() { 
                new EmployeeDetails{TotalActionEmp="Total Employee",TotalNewJoin=TotalEmp },
                 new EmployeeDetails{TotalActionEmp="Total Seperation",TotalNewJoin=TotalSeperation },
                 new EmployeeDetails{TotalActionEmp="Current Employee",TotalNewJoin=CurrentEmp },
                   new EmployeeDetails{TotalActionEmp="Total Male",TotalNewJoin=TotalMale },
                   new EmployeeDetails{TotalActionEmp="Total Female",TotalNewJoin=TotalFemal },
                     new EmployeeDetails{TotalActionEmp="New Joining",TotalNewJoin=NewJoining }
                   
                
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
        public static List<AttendanceDetails> GetAttendanceData()
        {

            EmployeeDetailsBLL _employeedetailsbll = new EmployeeDetailsBLL();
            AttendanceDetailsR _attendanceDetailsR = _employeedetailsbll.GetAttendanceDetails();

            int TotalPresent = Convert.ToInt32(_attendanceDetailsR.TotalPresent.ToString());
            int TotalAbsent = Convert.ToInt32(_attendanceDetailsR.TotalAbsent.ToString());
            int TotalLate = Convert.ToInt32(_attendanceDetailsR.TotalLate.ToString());
            int TotalLeave = Convert.ToInt32(_attendanceDetailsR.TotalLeave.ToString());
            int TotalOt = Convert.ToInt32(_attendanceDetailsR.TotalOT.ToString());
            int TotalEmp = Convert.ToInt32(_attendanceDetailsR.CurrentEmployee.ToString());

            List<AttendanceDetails> dataAtt = new List<AttendanceDetails>() { 
                   new AttendanceDetails{totalPresent="Total Employee",totalAbsent=TotalEmp },
                   new AttendanceDetails{totalPresent="On-Time Present",totalAbsent=TotalPresent },
                   new AttendanceDetails{totalPresent="Total Absent",totalAbsent=TotalAbsent },
                   new AttendanceDetails{totalPresent="Total Late",totalAbsent=TotalLate },
                   new AttendanceDetails{totalPresent="Total Leave",totalAbsent=TotalLeave },
                   new AttendanceDetails{totalPresent="Total OT",totalAbsent=TotalOt }
                    
                
                };


            return dataAtt;
        }


        [WebMethod]
        public static List<InventoryDetails> GetInventoryData()
        {

            EmployeeDetailsBLL _employeedetailsbll = new EmployeeDetailsBLL();
            InventoryDetailsR _InventoryDetailsR = _employeedetailsbll.GetInventoryDetails();

            int TotalStock = Convert.ToInt32(_InventoryDetailsR.TotalStock.ToString());
            int TotalPurchase = Convert.ToInt32(_InventoryDetailsR.TotalPurchase.ToString());
            int TotalIssue = Convert.ToInt32(_InventoryDetailsR.TotalIssue.ToString());
            int TotalDamage = Convert.ToInt32(_InventoryDetailsR.TotalDamage.ToString());
            int TotalReturn = Convert.ToInt32(_InventoryDetailsR.TotalReturn.ToString());


            List<InventoryDetails> dataAtt = new List<InventoryDetails>() { 
                new InventoryDetails{totalStock="Total Stock",totalIssue=TotalStock },
                   new InventoryDetails{totalStock="Total Purchase",totalIssue=TotalPurchase },
                   new InventoryDetails{totalStock="Total Issue",totalIssue=TotalIssue },
                   new InventoryDetails{totalStock="Total Damage",totalIssue=TotalDamage },
                    new InventoryDetails{totalStock="Total Return",totalIssue=TotalReturn }
                
                };


            return dataAtt;
        }

        [WebMethod]
        public static List<POS_Details> GettPOSData()
        {

            EmployeeDetailsBLL _employeedetailsbll = new EmployeeDetailsBLL();
            POSDetails _POSDetailsR = _employeedetailsbll.GetPosDetails();

            int TicketSales = Convert.ToInt32(_POSDetailsR.TicketSale.ToString());
            int FoodSales = Convert.ToInt32(_POSDetailsR.FoodSale.ToString());


            List<POS_Details> dataAtt = new List<POS_Details>() { 
                new POS_Details{Ticket_Sale="Ticket Sales",Food_Sale=TicketSales },
                   new POS_Details{Ticket_Sale="Food Sales",Food_Sale=FoodSales }
                };


            return dataAtt;
        }



    }
}
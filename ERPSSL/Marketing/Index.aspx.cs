using ERPSSL.Marketing.BLL;
using ERPSSL.Marketing.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ERPSSL.Marketing
{
    public partial class Index1 : System.Web.UI.Page
    {

        DashBoardBLL aDashBoardBLL = new DashBoardBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Session["UserID"] != null) && (Session["OCode"] != null))
            {
                LoadOnGoingOrder();
                LoadUpComingOrder();
                LoadPrimaryClient();
                LoadMidLevelClient();
                LoadcurrentCollectionAmount();
                LoadPreviousMonthAmount();
                LoadCurrentVisitStatus();
                LoadPreviousVisitStatus();
                MonthlyCollectionGraph();
                MonthVisitGraph();
            }
            else
            {
                Response.Redirect("..\\AppGateway\\Login.aspx");
            }
        }

        public void LoadOnGoingOrder()
        {
            List<int> orderIdList = aDashBoardBLL.GetNumberOfOnGoingOrder();

            int numberOfOrder = orderIdList.Count;

            //lblOngoingNumberOfOrder.Text = numberOfOrder.ToString();
            newOnGoingClients.Text = numberOfOrder.ToString();

        }

        public void LoadUpComingOrder()
        {
            List<int> upcomingOrderList = aDashBoardBLL.GetNumberOfUpComingOrder();

            int numberOfUpcoingOrder = upcomingOrderList.Count;

            //lblPendingTask.Text = numberOfUpcoingOrder.ToString();

            newUpComingClientsLabel.Text = numberOfUpcoingOrder.ToString();

        }

        public void LoadPrimaryClient()
        {
            List<int> primaryClientList = aDashBoardBLL.GetPrimaryClient();

            int numberOfPrimaryClient = primaryClientList.Count;

            //lblShipmentDateWith7Days.Text = numberOfPrimaryClient.ToString();
            newPrimaryClientLabel.Text = numberOfPrimaryClient.ToString();

        }


        public void LoadMidLevelClient()
        {
            List<int> midLevelClientList = aDashBoardBLL.GetMidLevelClient();

            int numberOfMidLevelClient = midLevelClientList.Count;

            //lblFailedOrder.Text = numberOfMidLevelClient.ToString();

            newMidLevelClientsLabel.Text = numberOfMidLevelClient.ToString();


        }

        

        public void LoadcurrentCollectionAmount()
        {
            decimal currentMonthCollectionAmount=0;
            int nowMonth = DateTime.Now.Month;
            int nowYear = DateTime.Now.Year;
            List<MRK_Transaction> aMRK_Transaction = aDashBoardBLL.GetTotalCollectionAmount(nowMonth, nowYear);

            foreach (MRK_Transaction aMrk_T in aMRK_Transaction)
            {
                currentMonthCollectionAmount = currentMonthCollectionAmount + Convert.ToDecimal(aMrk_T.CollectionAmount);
            }

            //lblExistingOrderinUSD.Text = currentMonthCollectionAmount.ToString("0.00") + " (Collection)";
            newCurrentMonthCollectionLabel.Text = currentMonthCollectionAmount.ToString("0.00");

        }

        public void LoadPreviousMonthAmount()
        {
            decimal preMonthCollectionAmount = 0;
            int nowMonth = DateTime.Now.Month;
            int nowYear = DateTime.Now.Year;

            // Find previous year and month

            var today = DateTime.Today;
            var month = new DateTime(today.Year, today.Month, 1);
            var first = month.AddMonths(-1);
            var last = month.AddDays(-1);
            int preMonth = first.Month;
            int preYear = first.Year;

            List<MRK_Transaction> aMRK_Transaction = aDashBoardBLL.GetTotalPreCollectionAmount(preMonth, preYear);

            foreach (MRK_Transaction aMrk_T in aMRK_Transaction)
            {
                preMonthCollectionAmount = preMonthCollectionAmount + Convert.ToDecimal(aMrk_T.CollectionAmount);
            }

            //lblExistingBuyer.Text = preMonthCollectionAmount.ToString("0.00") + " (Collection)";

            newLastMonthCollectionLabel.Text = preMonthCollectionAmount.ToString("0.00");
        }


        public void LoadCurrentVisitStatus()
        {
            
            int nowMonth = DateTime.Now.Month;
            int nowYear = DateTime.Now.Year;

            List<MRK_MarketingInfo> aMRK_MarketingInfo = aDashBoardBLL.GetCurrentStatus(nowMonth, nowYear);

            int numberOfCurrentClientVisit = aMRK_MarketingInfo.Count;

            //lblListedNooFactory.Text = numberOfCurrentClientVisit.ToString()+ " (Visit)";

            newCurrentMonthVisitLabel.Text = numberOfCurrentClientVisit.ToString();
        }

        public void LoadPreviousVisitStatus()
        {
            decimal preMonthCollectionAmount = 0;
            int nowMonth = DateTime.Now.Month;
            int nowYear = DateTime.Now.Year;

            // Find prevous year and month

            var today = DateTime.Today;
            var month = new DateTime(today.Year, today.Month, 1);
            var first = month.AddMonths(-1);
            var last = month.AddDays(-1);
            int preMonth = first.Month;
            int preYear = first.Year;

            List<MRK_MarketingInfo> aMRK_MarketingInfo = aDashBoardBLL.GetTotalPreVisit(preMonth, preYear);

            int numberOfPreVisit = aMRK_MarketingInfo.Count;

            //lblOrderStatus.Text = numberOfPreVisit.ToString() + " (Visit)";

            newLastMonthVisitLabel.Text = numberOfPreVisit.ToString();
        }

       

        public class VisitingInfoRepositoryForShow
        {
            public string TotalMonthlyVisit { get; set; }
            public int TotalVisit { get; set; }
        }


        public void MonthVisitGraph()
        {

            //EmployeeDetailsBLL _employeedetailsbll = new EmployeeDetailsBLL();
            //EmployeeDetailsR _employeeDetailsr = _employeedetailsbll.GetEmployeeDetails();

            int janMonth = aDashBoardBLL.GetMonthlyVisitStatus(1);

            int febMonth = aDashBoardBLL.GetMonthlyVisitStatus(2);

            int marMonth = aDashBoardBLL.GetMonthlyVisitStatus(3);

            int aprMonth = aDashBoardBLL.GetMonthlyVisitStatus(4);

            int mayMonth = aDashBoardBLL.GetMonthlyVisitStatus(5);

            int junMonth = aDashBoardBLL.GetMonthlyVisitStatus(6);

            int julMonth = aDashBoardBLL.GetMonthlyVisitStatus(7);

            int augMonth = aDashBoardBLL.GetMonthlyVisitStatus(8);

            int sepMonth = aDashBoardBLL.GetMonthlyVisitStatus(9);

            int octMonth = aDashBoardBLL.GetMonthlyVisitStatus(10);

            int novMonth = aDashBoardBLL.GetMonthlyVisitStatus(11);

            int decMonth = aDashBoardBLL.GetMonthlyVisitStatus(12);

            //int TotalEmp = Convert.ToInt32(_employeeDetailsr.TotalEmployee.ToString());
            //int TotalSeperation = Convert.ToInt32(_employeeDetailsr.TotalInactive.ToString());
            //int CurrentEmp = Convert.ToInt32(_employeeDetailsr.CurrentEmp.ToString());
            //int NewJoining = Convert.ToInt32(_employeeDetailsr.TotalNewJoin.ToString());
            //int TotalMale = Convert.ToInt32(_employeeDetailsr.TotalMale.ToString());
            //int TotalFemal = Convert.ToInt32(_employeeDetailsr.TotalFemale.ToString());


            List<VisitingInfoRepositoryForShow> dataList = new List<VisitingInfoRepositoryForShow>()
            {
                new VisitingInfoRepositoryForShow{TotalMonthlyVisit = "January", TotalVisit = janMonth},
                new VisitingInfoRepositoryForShow{TotalMonthlyVisit = "February", TotalVisit = febMonth},
                new VisitingInfoRepositoryForShow{TotalMonthlyVisit = "March", TotalVisit = marMonth},
                new VisitingInfoRepositoryForShow{TotalMonthlyVisit = "April", TotalVisit = aprMonth},
                new VisitingInfoRepositoryForShow{TotalMonthlyVisit = "May", TotalVisit = mayMonth},
                new VisitingInfoRepositoryForShow{TotalMonthlyVisit = "June", TotalVisit = junMonth},
                new VisitingInfoRepositoryForShow{TotalMonthlyVisit = "July", TotalVisit = julMonth},
                new VisitingInfoRepositoryForShow{TotalMonthlyVisit = "August", TotalVisit = augMonth},
                new VisitingInfoRepositoryForShow{TotalMonthlyVisit = "September", TotalVisit = sepMonth},
                new VisitingInfoRepositoryForShow{TotalMonthlyVisit = "October", TotalVisit = octMonth},
                new VisitingInfoRepositoryForShow{TotalMonthlyVisit = "November", TotalVisit = novMonth},
                new VisitingInfoRepositoryForShow{TotalMonthlyVisit = "December", TotalVisit = decMonth}
            };


            //List<EmployeeDetailsd> dataList = new List<EmployeeDetailsd>() { 
            //    new EmployeeDetailsd{TotalActionEmp="Total Employee",TotalNewJoin=TotalEmp },
            //     new EmployeeDetailsd{TotalActionEmp="Total Seperation",TotalNewJoin=TotalSeperation },
            //     new EmployeeDetailsd{TotalActionEmp="Current Employee",TotalNewJoin=CurrentEmp },
            //       new EmployeeDetailsd{TotalActionEmp="Total Male",TotalNewJoin=TotalMale },
            //       new EmployeeDetailsd{TotalActionEmp="Total Female",TotalNewJoin=TotalFemal },
            //         new EmployeeDetailsd{TotalActionEmp="New Joining",TotalNewJoin=NewJoining }              
            //    };



            Chart1.DataSource = dataList;
            string[] color = new string[] { "Orange", "Red", "Green", "Blue", "Orchid", "Navy", "Orange", "Violet", "Peach", "Sage", "Lavender", "Indigo" };
            foreach (var item in dataList)
            {
                Chart1.Series["Series1"].Points.AddXY(item.TotalMonthlyVisit, item.TotalVisit);

            }
            for (int pointIndex = 0; pointIndex < 12; pointIndex++)
            {
                Chart1.Series["Series1"].Points[pointIndex].Color = System.Drawing.Color.FromName(color[pointIndex]);
            }
            // Chart1.Series["Series1"].YValueMembers = "Value,intvalueforcolor";

        }

        public void MonthlyCollectionGraph()
        {

            //EmployeeDetailsBLL _employeedetailsbll = new EmployeeDetailsBLL();
            //EmployeeDetailsR _employeeDetailsr = _employeedetailsbll.GetEmployeeDetails();

            int janMonth = aDashBoardBLL.GetMonthlyCollectionAmount(1);

            int febMonth = aDashBoardBLL.GetMonthlyCollectionAmount(2);

            int marMonth = aDashBoardBLL.GetMonthlyCollectionAmount(3);

            int aprMonth = aDashBoardBLL.GetMonthlyCollectionAmount(4);

            int mayMonth = aDashBoardBLL.GetMonthlyCollectionAmount(5);

            int junMonth = aDashBoardBLL.GetMonthlyCollectionAmount(6);

            int julMonth = aDashBoardBLL.GetMonthlyCollectionAmount(7);

            int augMonth = aDashBoardBLL.GetMonthlyCollectionAmount(8);

            int sepMonth = aDashBoardBLL.GetMonthlyCollectionAmount(9);

            int octMonth = aDashBoardBLL.GetMonthlyCollectionAmount(10);

            int novMonth = aDashBoardBLL.GetMonthlyCollectionAmount(11);

            int decMonth = aDashBoardBLL.GetMonthlyCollectionAmount(12);

            //int TotalEmp = Convert.ToInt32(_employeeDetailsr.TotalEmployee.ToString());
            //int TotalSeperation = Convert.ToInt32(_employeeDetailsr.TotalInactive.ToString());
            //int CurrentEmp = Convert.ToInt32(_employeeDetailsr.CurrentEmp.ToString());
            //int NewJoining = Convert.ToInt32(_employeeDetailsr.TotalNewJoin.ToString());
            //int TotalMale = Convert.ToInt32(_employeeDetailsr.TotalMale.ToString());
            //int TotalFemal = Convert.ToInt32(_employeeDetailsr.TotalFemale.ToString());


            List<VisitingInfoRepositoryForShow> dataList = new List<VisitingInfoRepositoryForShow>()
            {
                new VisitingInfoRepositoryForShow{TotalMonthlyVisit = "January", TotalVisit = janMonth},
                new VisitingInfoRepositoryForShow{TotalMonthlyVisit = "February", TotalVisit = febMonth},
                new VisitingInfoRepositoryForShow{TotalMonthlyVisit = "March", TotalVisit = marMonth},
                new VisitingInfoRepositoryForShow{TotalMonthlyVisit = "April", TotalVisit = aprMonth},
                new VisitingInfoRepositoryForShow{TotalMonthlyVisit = "May", TotalVisit = mayMonth},
                new VisitingInfoRepositoryForShow{TotalMonthlyVisit = "June", TotalVisit = junMonth},
                new VisitingInfoRepositoryForShow{TotalMonthlyVisit = "July", TotalVisit = julMonth},
                new VisitingInfoRepositoryForShow{TotalMonthlyVisit = "August", TotalVisit = augMonth},
                new VisitingInfoRepositoryForShow{TotalMonthlyVisit = "September", TotalVisit = sepMonth},
                new VisitingInfoRepositoryForShow{TotalMonthlyVisit = "October", TotalVisit = octMonth},
                new VisitingInfoRepositoryForShow{TotalMonthlyVisit = "November", TotalVisit = novMonth},
                new VisitingInfoRepositoryForShow{TotalMonthlyVisit = "December", TotalVisit = decMonth}
            };


            //List<EmployeeDetailsd> dataList = new List<EmployeeDetailsd>() { 
            //    new EmployeeDetailsd{TotalActionEmp="Total Employee",TotalNewJoin=TotalEmp },
            //     new EmployeeDetailsd{TotalActionEmp="Total Seperation",TotalNewJoin=TotalSeperation },
            //     new EmployeeDetailsd{TotalActionEmp="Current Employee",TotalNewJoin=CurrentEmp },
            //       new EmployeeDetailsd{TotalActionEmp="Total Male",TotalNewJoin=TotalMale },
            //       new EmployeeDetailsd{TotalActionEmp="Total Female",TotalNewJoin=TotalFemal },
            //         new EmployeeDetailsd{TotalActionEmp="New Joining",TotalNewJoin=NewJoining }              
            //    };



            Chart2.DataSource = dataList;
            string[] color = new string[] { "Orange", "Red", "Green", "Blue", "Orchid", "Navy", "Orange", "Violet", "Peach", "Sage", "Lavender", "Indigo" };
            foreach (var item in dataList)
            {
                Chart2.Series["Series1"].Points.AddXY(item.TotalMonthlyVisit, item.TotalVisit);

            }
            for (int pointIndex = 0; pointIndex < 12; pointIndex++)
            {
                Chart2.Series["Series1"].Points[pointIndex].Color = System.Drawing.Color.FromName(color[pointIndex]);
            }
            // Chart1.Series["Series1"].YValueMembers = "Value,intvalueforcolor";

        }
    }
}
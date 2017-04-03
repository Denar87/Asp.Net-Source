using ERPSSL.LC.BLL;
using ERPSSL.LC.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using ERPSSL.BuyingHouse.DAL.Repository;

namespace ERPSSL.BuyingHouse
{
    public partial class Index : System.Web.UI.Page
    {
        BuyerBLL _Buyerbll = new BuyerBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Session["UserID"] != null) && (Session["OCode"] != null))
            {
                GetBuyerDetails();
                OrderRetioMonthWise();
            }
            else
            {
                Response.Redirect("..\\AppGateway\\Login.aspx");
            }
        }

        private void GetBuyerDetails()
        {
           

            ItemList _ItemList = _Buyerbll.GetBuyerDetails();
            if (_ItemList != null)
            {
              
                lblExistingBuyer.Text = _ItemList.CurrentBuyer.ToString();
                lblOngoingNumberOfOrder.Text = _ItemList.TotalOrder.ToString();
                lblShipmentDateWith7Days.Text = _ItemList.TotalOrderBefore7days.ToString();
                lblListedNooFactory.Text = _ItemList.TotalListedNooFactory.ToString();
                lblExistingOrderinUSD.Text = _ItemList.TotalExistingOrderAmountinUSD.ToString();
                lblPendingTask.Text = _ItemList.PendingTask.ToString();
                lblOrderStatus.Text = _ItemList.TotalOrder.ToString();
                lblFailedOrder.Text = _ItemList.ScheduleDate.ToString();
            }
        }

        [WebMethod]
        public void OrderRetioMonthWise()
        {

            //Vhl_ReportBLL _aVhl_ReportBLL = new Vhl_ReportBLL();
            Year _year = _Buyerbll.GetServiceScheduleMonthWise();

            int January = Convert.ToInt32(_year.january.ToString());
            int February = Convert.ToInt32(_year.february.ToString());
            int March = Convert.ToInt32(_year.march.ToString());
            int April = Convert.ToInt32(_year.april.ToString());
            int May = Convert.ToInt32(_year.may.ToString());
            int June = Convert.ToInt32(_year.june.ToString());
            int July = Convert.ToInt32(_year.july.ToString());
            int August = Convert.ToInt32(_year.august.ToString());
            int September = Convert.ToInt32(_year.september.ToString());
            int October = Convert.ToInt32(_year.october.ToString());
            int November = Convert.ToInt32(_year.november.ToString());
            int December = Convert.ToInt32(_year.december.ToString());

            List<OrderMonthWise> dataAtti = new List<OrderMonthWise>() { 
                new OrderMonthWise{MonthName="Jan",MonthValue=January },
                 new OrderMonthWise{MonthName="Feb",MonthValue=February },
                          new OrderMonthWise{MonthName="Mar",MonthValue=March },
                   new OrderMonthWise{MonthName="Apr",MonthValue=April },
                          new OrderMonthWise{MonthName="May",MonthValue=May },
                   new OrderMonthWise{MonthName="Jun",MonthValue=June },
                          new OrderMonthWise{MonthName="Jul",MonthValue=July },
                   new OrderMonthWise{MonthName="Aug",MonthValue=August },
                          new OrderMonthWise{MonthName="Sep",MonthValue=September },
                   new OrderMonthWise{MonthName="Oct",MonthValue=October },
                          new OrderMonthWise{MonthName="Nov",MonthValue=November },
                   new OrderMonthWise{MonthName="Dec",MonthValue=December }
                
                };
            string[] color = new string[] { "Orange", "Green", "Red", "Blue", "Yellow", "Orange", "Green", "Red", "Blue", "Yellow", "Orange", "Green" };
            foreach (var item in dataAtti)
            {
                Chart1.Series["Series1"].Points.AddXY(item.MonthName, item.MonthValue);

            }
            //Chart1.Series["Series1"]
            Chart1.ChartAreas[0].AxisX.Interval = 1;
            for (int pointIndex = 0; pointIndex < 12; pointIndex++)
            {
                Chart1.Series["Series1"].Points[pointIndex].Color = System.Drawing.Color.FromName(color[pointIndex]);

            }
            Chart1.Series["Series1"].YValueMembers = "Value,intvalueforcolor";
            //return dataAtti;
        }

        public class OrderMonthWise
        {
            public string MonthName { get; set; }
            public int MonthValue { get; set; }
        }

      

      
    }
}
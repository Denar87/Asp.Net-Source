using System;
using System.Collections.Generic;
using System.Data;
using ERPSSL.Merchandising.DAL;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ERPSSL.Merchandising.BLL;


namespace ERPSSL.Merchandising
{
    public partial class CapacityCalculation : System.Web.UI.Page
    {
        CapacityCalculationBLL _CapacityCalculationBLL = new CapacityCalculationBLL();
        ERPSSL_MerchandisingEntities _Context = new ERPSSL_MerchandisingEntities();
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Session["UserID"] != null) && (Session["OCode"] != null))
            {
                if (!IsPostBack)
                {
                    GetDayList();
                }
            }
            else
            {
                Response.Redirect("..\\AppGateway\\Login.aspx");
            }
        }

        private void GetDayList()
        {
            int YearL = Convert.ToInt32(ddlYear.SelectedValue);
            int MonthL = Convert.ToInt32(ddlMonth.SelectedValue);
            int DaysInDate = DateTime.DaysInMonth(YearL, MonthL);
        }

        public void GetDates(int year, int month)
        {
            List<LC_tbl_DateTemp> _DateAdd = new List<LC_tbl_DateTemp>();

            string OCode = ((SessionUser)Session["SessionUser"]).OCode;

            for (var date = new DateTime(year, month, 1); date.Month == month; date = date.AddDays(1))
            {
                LC_tbl_DateTemp _DD = new LC_tbl_DateTemp();
                _DD.Datetime = date;
                _DD.OCode = OCode;
                _DateAdd.Add(_DD);
            }
            foreach (var item in _DateAdd)
            {
                _Context.LC_tbl_DateTemp.AddObject(item);
            }
            _Context.SaveChanges();
            showDateGrid();
        }

        private void showDateGrid()
        {
            
            try
            {
                string OCode = ((SessionUser)Session["SessionUser"]).OCode;
                var DateL = _CapacityCalculationBLL.GetDates(OCode).ToList();
                if (DateL.Count > 0)
                {
                    gridview.DataSource = DateL.ToList();
                    gridview.DataBind();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void ddlMonth_SelectedIndexChanged(object sender, EventArgs e)
        {

            int YearL = Convert.ToInt32(ddlYear.SelectedValue);
            int MonthL = Convert.ToInt32(ddlMonth.SelectedValue);
            int DaysInDate = DateTime.DaysInMonth(YearL, MonthL);

            GetDates(YearL, MonthL);
        }
    }
}
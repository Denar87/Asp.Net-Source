using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using ERPSSL.HRM.DAL;
using ERPSSL.HRM.BLL;
using ERPSSL.HRM.DAL.Repository;

namespace ERPSSL.HRM
{
    public partial class holiday : Page
    {
        HOLIDAYS_BLL objHoli_BLL = new HOLIDAYS_BLL();
        List<HRM_HOLIDAYS> hrmHolidaysList = new List<HRM_HOLIDAYS>();

        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Session["UserID"] != null) && (Session["OCode"] != null))
            {
                if (!IsPostBack)
                {
                    GetHolidayType();
                    GetHolidays();
                }
            }
            else
            {
                Response.Redirect("..\\AppGateway\\Login.aspx");
            }
        }

        private void GetHolidayType()
        {
            try
            {
                string OCODE = Convert.ToString(((SessionUser)Session["SessionUser"]).OCode);

                List<HRM_HOLIDAY_TYPE> holidayTypeList = objHoli_BLL.GetAllHolidayType(OCODE);
                if (holidayTypeList.Count > 0)
                {
                    ddlHolidayType.DataSource = holidayTypeList.ToList();

                    ddlHolidayType.DataTextField = "HOLIDAY_TYPE_NAME";
                    ddlHolidayType.DataValueField = "HOLIDAY_TYPE_ID";
                    ddlHolidayType.DataBind();
                    ddlHolidayType.Items.Insert(0, new ListItem("--Select--"));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btnHolidays_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime DateTimeFrom = Convert.ToDateTime(txtBxFromDate.Text);
                string HolidayCode = GetHolidayCode();

                if (btnSaveHolidays.Text == "Submit")
                {

                    for (int i = 0; i < Convert.ToInt16(txtBxTotalDay.Text); i++)
                    {
                        HRM_HOLIDAYS objHrmHolidays = new HRM_HOLIDAYS();
                        objHrmHolidays.HOLIDAY_TYPE_ID = Convert.ToInt32(ddlHolidayType.SelectedValue);
                        objHrmHolidays.HolidayCode = HolidayCode;
                        objHrmHolidays.HOLIDAY_NAME = txtbxName.Text;
                        objHrmHolidays.HOLIDAY_DATE = DateTimeFrom.AddDays(i);

                        objHrmHolidays.EDIT_USER = ((SessionUser)Session["SessionUser"]).UserId;
                        objHrmHolidays.EDIT_DATE = DateTime.Now;
                        objHrmHolidays.OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                        hrmHolidaysList.Add(objHrmHolidays);
                    }


                    int result = objHoli_BLL.InsertHoli_Days(hrmHolidaysList);
                    if (result == 1)
                    {
                        //lblMessage.Text = "Data Save successfully!";
                        //lblMessage.ForeColor = System.Drawing.Color.Green;
                        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "text", "func('Data Save successfully!')", true);
                        GetHolidays();
                    }
                }
                else
                {

                    for (int i = 0; i < Convert.ToInt16(txtBxTotalDay.Text); i++)
                    {
                        HRM_HOLIDAYS objHrmHolidays = new HRM_HOLIDAYS();
                        objHrmHolidays.HOLIDAY_TYPE_ID = Convert.ToInt32(ddlHolidayType.SelectedValue);
                        objHrmHolidays.HolidayCode = hidHolidayId.Value;
                        objHrmHolidays.HOLIDAY_NAME = txtbxName.Text;
                        objHrmHolidays.HOLIDAY_DATE = DateTimeFrom.AddDays(i);

                        objHrmHolidays.EDIT_USER = ((SessionUser)Session["SessionUser"]).UserId;
                        objHrmHolidays.EDIT_DATE = DateTime.Now;
                        objHrmHolidays.OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                        hrmHolidaysList.Add(objHrmHolidays);
                    }


                    HRM_HOLIDAYS objHoli = new HRM_HOLIDAYS();
                    string holidayOcode = hidHolidayId.Value;
                    int result = objHoli_BLL.UpdateSub_Holidays(hrmHolidaysList, holidayOcode);
                    if (result == 1)
                    {
                        //lblMessage.Text = "Data Update successfully!";
                        //lblMessage.ForeColor = System.Drawing.Color.Green;
                        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "text", "func('Data Update successfully!')", true);
                        GetHolidays();
                    }
                }
                ClearHolidayUI();
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }


        private void ClearHolidayUI()
        {
            try
            {
                txtbxName.Text = string.Empty;
                ddlHolidayType.ClearSelection();
                txtBxFromDate.Text = string.Empty;
                txtBxToDate.Text = string.Empty;
                txtBxTotalDay.Text = string.Empty;
                btnSaveHolidays.Text = "Submit";
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

        private string GetHolidayCode()
        {
            try
            {
                ERPSSLHBEntities _context = new ERPSSLHBEntities();
                var rowNumber = _context.HRM_HOLIDAYS.Count();
                int rowN = Convert.ToInt16(rowNumber) + 1;
                var holidayCode = "HOD" + rowN;
                return holidayCode;

            }
            catch (Exception)
            {
                throw;
            }
        }
        private void GetHolidays()
        {
            try
            {
                string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                List<HolidayTypeR> holidays = objHoli_BLL.GetAllHolidays(OCODE).ToList();
                if (holidays.Count > 0)
                {
                    gridViewHolidays.DataSource = holidays.ToList();
                    gridViewHolidays.DataBind();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void gridViewHolidays_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridViewHolidays.PageIndex = e.NewPageIndex;
            GetHolidays();
        }

        protected void imgbtnHolidayEdit_Click(object sender, EventArgs e)
        {
            ImageButton imgbtn = (ImageButton)sender;
            GridViewRow row = (GridViewRow)imgbtn.NamingContainer;

            try
            {
                string HodlidayCode = "";
                Label lblHolidayCode = (Label)gridViewHolidays.Rows[row.RowIndex].FindControl("HolidayCode");
                if (lblHolidayCode != null)
                {
                    string oCode = ((SessionUser)Session["SessionUser"]).OCode;
                    HodlidayCode = lblHolidayCode.Text;

                    List<HolidayTypeR> hrmHolidaysList = objHoli_BLL.GetAllHolidaysByHolidayCode(HodlidayCode, oCode);

                    if (hrmHolidaysList.Count > 0)
                    {
                        foreach (HolidayTypeR holidays in hrmHolidaysList)
                        {
                            hidHolidayId.Value = holidays.HolidayCode.ToString();
                            txtbxName.Text = holidays.HolidayName;
                            ddlHolidayType.SelectedValue = holidays.HolidayTypeId.ToString();
                            txtBxFromDate.Text = holidays.HolidayFromDate.ToString();
                            txtBxToDate.Text = holidays.HolidayToDate.ToString();

                            DateTime probationf = Convert.ToDateTime(txtBxFromDate.Text);
                            DateTime probationT = Convert.ToDateTime(txtBxToDate.Text);
                            txtBxTotalDay.Text = (1 + (probationT - probationf).TotalDays).ToString();

                            if (btnSaveHolidays.Text == "Submit")
                            {
                                btnSaveHolidays.Text = "Update";
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

        protected void txtBxToDate_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DateTime probationf = Convert.ToDateTime(txtBxFromDate.Text);
                DateTime probationT = Convert.ToDateTime(txtBxToDate.Text);
                txtBxTotalDay.Text = (1 + (probationT - probationf).TotalDays).ToString();
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ERPSSL.HRM.DAL;
using ERPSSL.HRM.BLL;

namespace ERPSSL.HRM
{
    public partial class HolidayType : System.Web.UI.Page
    {
        HOLIDAYS_BLL HolidayBllObj = new HOLIDAYS_BLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Session["UserID"] != null) && (Session["OCode"] != null))
            {
                if (!IsPostBack)
                {
                    getHolidayType();
                }
            }
            else
            {
                Response.Redirect("..\\AppGateway\\Login.aspx");
            }
        }

        private void getHolidayType()
        {
            try
            {
                string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                var row = HolidayBllObj.GetAllHolidayType(OCODE).ToList();
                if (row.Count > 0)
                {
                    gridviewholiday.DataSource = row.ToList();
                    gridviewholiday.DataBind();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtbxType.Text == "")
                {
                    //      lblMessage.Text = "";
                    //      lblMessage.ForeColor = System.Drawing.Color.Red;
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Please Input Type!')", true);
                }

                else
                {
                    HRM_HOLIDAY_TYPE objDeg = new HRM_HOLIDAY_TYPE();
                    objDeg.EDIT_USER = ((SessionUser)Session["SessionUser"]).UserId;
                    objDeg.EDIT_DATE = DateTime.Now;
                    objDeg.OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                    objDeg.HOLIDAY_TYPE_NAME = txtbxType.Text;


                    if (btnSubmit.Text == "Submit")
                    {
                        int result = HolidayBllObj.InsertHolidayType(objDeg);
                        if (result == 1)
                        {
                            //   lblMessage.Text = "Data Save successfully!";
                            //   lblMessage.ForeColor = System.Drawing.Color.Green;
                            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Data Save Successfully')", true);
                        }
                    }
                    else
                    {
                        int HolidayTypeId = Convert.ToInt32(hidholidayId.Value);
                        int result = HolidayBllObj.UpdateUpdateHolidayType(objDeg, HolidayTypeId);
                        if (result == 1)
                        {
                            //lblMessage.Text = "Data Update successfully!";
                            //lblMessage.ForeColor = System.Drawing.Color.Green;
                            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Data Update Successfully')", true);
                        }
                    }
                    getHolidayType();
                    txtbxType.Text = "";

                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

        protected void imgbtnDepartmentEdit_Click(object sender, EventArgs e)
        {
            List<HRM_HOLIDAY_TYPE> holidayTypes = new List<HRM_HOLIDAY_TYPE>();
            ImageButton imgbtn = (ImageButton)sender;
            GridViewRow row = (GridViewRow)imgbtn.NamingContainer;

            try
            {
                string holidayTypeId = "";
                Label lblHolidayId = (Label)gridviewholiday.Rows[row.RowIndex].FindControl("lblHolidayId");
                if (lblHolidayId != null)
                {
                    string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                    holidayTypeId = lblHolidayId.Text;
                    holidayTypes = HolidayBllObj.GetHolidayTypeIdandOcode(holidayTypeId, OCODE);

                    if (holidayTypes.Count > 0)
                    {
                        foreach (HRM_HOLIDAY_TYPE adesignation in holidayTypes)
                        {
                            hidholidayId.Value = adesignation.HOLIDAY_TYPE_ID.ToString();
                            txtbxType.Text = adesignation.HOLIDAY_TYPE_NAME;

                        }
                        if (btnSubmit.Text == "Submit")
                        {
                            btnSubmit.Text = "Update";
                        }
                    }

                }

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

        protected void gridviewholiday_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridviewholiday.PageIndex = e.NewPageIndex;
            getHolidayType();
        }
    }
}
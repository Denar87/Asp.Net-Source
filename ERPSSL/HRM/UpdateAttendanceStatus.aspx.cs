using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ERPSSL.HRM.BLL;
using AjaxControlToolkit;
using ERPSSL.HRM.DAL;
using ERPSSL;

namespace ERPSSL.HRM
{
    public partial class UpdateAttendanceStatus : System.Web.UI.Page
    {
        ERPSSLHBEntities context = new ERPSSLHBEntities();
        Attendance_BLL objAtt_BLL = new Attendance_BLL();
        DEPARTMENT_BLL DepartmentBll = new DEPARTMENT_BLL();
        Office_BLL objOfficeBLL = new Office_BLL();
        TIME_SCHEDULE_BLL timeScheduleBll = new TIME_SCHEDULE_BLL();
        Attendance_RPT_Bll aAttendance_RPT_Bll = new Attendance_RPT_Bll();

        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Session["UserID"] != null) && (Session["OCode"] != null))
            {
                if (!IsPostBack)
                {
                    GetShiftCodeList();
                    txtDateFrom.Text = DateTime.Today.ToShortDateString();
                    txtDateTo.Text = DateTime.Today.ToShortDateString();
                }
            }
            else
            {
                Response.Redirect("..\\AppGateway\\Login.aspx");
            }
        }

        private void GetShiftCodeList()
        {
            try
            {
                string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                var row = timeScheduleBll.GetDistinctSchedule();
                if (row.Count > 0)
                {
                    ddlShiftCode.DataSource = row.ToList();
                    ddlShiftCode.DataTextField = "ShiftName";
                    ddlShiftCode.DataValueField = "ShiftCode";
                    ddlShiftCode.DataBind();
                    ddlShiftCode.Items.Insert(0, new ListItem("--Select--", "0"));
                }
            }
            catch
            {
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                DateTime EDIT_DATE = DateTime.Now;
                Guid userId = ((SessionUser)Session["SessionUser"]).UserId;

                var result = objAtt_BLL.UpdateAttStatus_ByDate(Convert.ToDateTime(txtDateFrom.Text), Convert.ToDateTime(txtDateTo.Text), ddlShiftCode.Text);
                objAtt_BLL.Update_AbsentLeaveStatus_ByDate(Convert.ToDateTime(txtDateFrom.Text), Convert.ToDateTime(txtDateTo.Text), ddlShiftCode.Text, OCODE, EDIT_DATE, userId);
                if (result == 1)
                {

                    lblMessage.Text = "";
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Employee Attendance Status Updated Successfully')", true);

                    txtDateFrom.Text = DateTime.Today.ToShortDateString();
                    txtDateTo.Text = DateTime.Today.ToShortDateString();
                    ddlShiftCode.ClearSelection();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Status Update Failure!')", true);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

        protected void txtDateFrom_TextChanged(object sender, EventArgs e)
        {
            lblMessage.Text = "";
        }

        protected void txtDateTo_TextChanged(object sender, EventArgs e)
        {
            lblMessage.Text = "";
        }

        protected void ddlShiftCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblMessage.Text = "";
        }


        protected void btnUpdateAll_Click(object sender, EventArgs e)
        {
            try
            {
                string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                DateTime EDIT_DATE = DateTime.Now;
                Guid userId = ((SessionUser)Session["SessionUser"]).UserId;

                var result = aAttendance_RPT_Bll.UpdateAttStatus_ByDate(Convert.ToDateTime(txtDateFrom.Text), Convert.ToDateTime(txtDateTo.Text));

                aAttendance_RPT_Bll.Update_AbsentLeaveStatus_ByDate(Convert.ToDateTime(txtDateFrom.Text), Convert.ToDateTime(txtDateTo.Text), OCODE, EDIT_DATE, userId);
                if (result == 1)
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Employee Attendance Status Updated Successfully')", true);
                    txtDateFrom.Text = DateTime.Today.ToShortDateString();
                    txtDateTo.Text = DateTime.Today.ToShortDateString();
                    ddlShiftCode.ClearSelection();
                }
                else
                {
                    //lblMessage.Text = "Status Update Failure!";
                    //lblMessage.ForeColor = System.Drawing.Color.Red;
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Status Update Failure!')", true);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }


    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ERPSSL.HRM.BLL;
using ERPSSL.HRM.DAL;

namespace ERPSSL.HRM
{
    public partial class MachineReadableProblem : System.Web.UI.Page
    {
        Office_BLL objOfficeBLL = new Office_BLL();
        AttendanceReason_BLL objAttendanceReasonBll = new AttendanceReason_BLL();
        ReasonTypeBLL reasonTypeBll = new ReasonTypeBLL();
        TIME_SCHEDULE_BLL timeScheduleBll = new TIME_SCHEDULE_BLL();
        Attendance_BLL objAttendanceBll = new Attendance_BLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Session["UserID"] != null) && (Session["OCode"] != null))
            {
                if (!IsPostBack)
                {
                    GetShiftCodeList();
                    BindGridAttendance();
                    txtDate.Text = DateTime.Today.ToShortDateString();
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
                var row = timeScheduleBll.GetAllSchedule(OCODE).ToList();
                if (row.Count > 0)
                {
                    ddlShiftCode.DataSource = row.ToList();
                    ddlShiftCode.DataTextField = "ShiftName";
                    ddlShiftCode.DataValueField = "ShiftCode";
                    ddlShiftCode.DataBind();
                    ddlShiftCode.Items.Insert(0, new ListItem("------Select Shift------", "0"));
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void reset()
        {
            ddlShiftCode.ClearSelection();
            ddlWorkingDay.ClearSelection();
            txtRegion.Text = "";
            txtOffice.Text = "";
            //txtShift.Text = "";
            txtRemarks.Text = "";
        }

        protected void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                HRM_MachineReadableProblem objmachineProblem = new HRM_MachineReadableProblem();

                objmachineProblem.RegionId = Convert.ToInt32(lblRegionId.Text);
                objmachineProblem.OfficeId = Convert.ToInt32(lblOfficeId.Text);
                objmachineProblem.ShiftCode = ddlShiftCode.SelectedValue;
                objmachineProblem.ShiftName = ddlShiftCode.SelectedItem.Text;
                objmachineProblem.Att_Date = Convert.ToDateTime(txtDate.Text);
                objmachineProblem.Att_Day = Convert.ToDateTime(txtDate.Text).DayOfWeek.ToString();
                objmachineProblem.Working_Day = ddlWorkingDay.Text;
                objmachineProblem.Remarks = txtRemarks.Text;

                TimeSpan in_time = TimeSpan.Parse(string.Format("{0}:{1}:{2}", txtStartTime.Hour, txtStartTime.Minute, txtStartTime.Second));
                objmachineProblem.InTime = in_time;

                TimeSpan out_time = TimeSpan.Parse(string.Format("{0}:{1}:{2}", txtEndTime.Hour, txtEndTime.Minute, txtEndTime.Second));
                objmachineProblem.OutTime = out_time;

                objmachineProblem.Edit_User = ((SessionUser)Session["SessionUser"]).UserId;
                objmachineProblem.Edit_Date = DateTime.Now;
                objmachineProblem.OCode = ((SessionUser)Session["SessionUser"]).OCode;

                if (in_time > out_time)
                {
                    //lblMessage.Text = "<font color='red'>Out Time can't be less than In Time</font>";
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Out Time can't be less than In Time')", true);
                    return;
                }

                objAttendanceBll.InsertMachineProblem(objmachineProblem);

                HRM_ATTENDANCE objAttendance = new HRM_ATTENDANCE();
                objAttendance.ShiftCode = ddlShiftCode.SelectedValue;
                objAttendance.Attendance_Date = Convert.ToDateTime(txtDate.Text);
                objAttendance.Attendance_Day = Convert.ToDateTime(txtDate.Text).DayOfWeek.ToString();
                objAttendance.Working_Day = ddlWorkingDay.Text;
                objAttendance.Remarks = txtRemarks.Text;
                objAttendance.In_Time = in_time;
                objAttendance.Out_Time = out_time;

                objAttendance.Edit_User = ((SessionUser)Session["SessionUser"]).UserId;
                objAttendance.Edit_Date = DateTime.Now;
                objAttendance.OCode = ((SessionUser)Session["SessionUser"]).OCode;

                var result = objAttendanceBll.InsertAtt_MachineProblem(objAttendance);
                if (result == 1)
                {
                    // lblMessage.Text = "Data Added successfully!";
                    //lblMessage.ForeColor = System.Drawing.Color.Green;
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Data Added successfully!')", true);
                    reset();
                    BindGridAttendance();
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }


        private void BindGridAttendance()
        {
            try
            {
                string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                List<HRM_MachineReadableProblem> aMachineReadableProblem = objAttendanceBll.GetAllMachineProblem(OCODE).ToList();
                if (aMachineReadableProblem.Count > 0)
                {
                    gridviewMachineProblem.DataSource = aMachineReadableProblem;
                    gridviewMachineProblem.DataBind();
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        protected void ddlShiftCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                string shiftCode = Convert.ToString(ddlShiftCode.SelectedItem.Text);

                var result = timeScheduleBll.GetScheduleByCode(OCODE, shiftCode).ToList();
                if (result.Count > 0)
                {
                    var objShift = result.First();
                    //txtShift.Text = objShift.ShiftName;
                    txtRegion.Text = objShift.HRM_Regions.RegionName;
                    txtOffice.Text = objShift.HRM_Office.OfficeName;
                    lblRegionId.Text = objShift.RegionId.ToString();
                    lblOfficeId.Text = objShift.OfficeId.ToString();
                }
                else
                {
                    //lblMessage.Text = "<font color='red'>No record found!</font>";
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No record found!')", true);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

        protected void gridviewMachineProblem_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridviewMachineProblem.PageIndex = e.NewPageIndex;
            BindGridAttendance();
        }

    }
}

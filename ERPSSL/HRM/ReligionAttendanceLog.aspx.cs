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
    public partial class ReligionAttendanceLog : System.Web.UI.Page
    {
        Office_BLL objOfficeBLL = new Office_BLL();
        AttendanceReason_BLL objAttendanceReasonBll = new AttendanceReason_BLL();
        ReasonTypeBLL reasonTypeBll = new ReasonTypeBLL();
        TIME_SCHEDULE_BLL timeScheduleBll = new TIME_SCHEDULE_BLL();
        DEPARTMENT_BLL departmentBll = new DEPARTMENT_BLL();
        private ERPSSLHBEntities _context = new ERPSSLHBEntities();

        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Session["UserID"] != null) && (Session["OCode"] != null))
            {
                if (!IsPostBack)
                {
                    GetReasonList();
                    BindGridAttendance();
                    GetRegionList();
                    txtDate.Text = DateTime.Today.ToShortDateString();
                }
            }
            else
            {
                Response.Redirect("..\\AppGateway\\Login.aspx");
            }
        }

        private void GetReasonList()
        {
            try
            {
                string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                var row = reasonTypeBll.GetReasonType(OCODE).ToList();
                if (row.Count > 0)
                {
                    ddlReasonType.DataSource = row.ToList();
                    ddlReasonType.DataTextField = "ReasonType";
                    ddlReasonType.DataValueField = "ReasonTypeId";
                    ddlReasonType.DataBind();
                    ddlReasonType.Items.Insert(0, new ListItem("------Select Reason------", "0"));
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void GetRegionList()
        {
            try
            {
                string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                var row = objOfficeBLL.GetAllResion(OCODE).ToList();
                if (row.Count > 0)
                {
                    ddlRegion.DataSource = row.ToList();
                    ddlRegion.DataTextField = "RegionName";
                    ddlRegion.DataValueField = "RegionID";
                    ddlRegion.DataBind();
                    ddlRegion.Items.Insert(0, new ListItem("------Select Region------", "0"));
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void BindOfficeByRegion(int RegionId)
        {
            try
            {
                var row = objOfficeBLL.GetOfficeByResionId(RegionId).ToList();
                if (row.Count > 0)
                {
                    ddlOffice.DataSource = row.ToList();
                    ddlOffice.DataTextField = "OfficeName";
                    ddlOffice.DataValueField = "OfficeID";
                    ddlOffice.DataBind();
                    ddlOffice.Items.Insert(0, new ListItem("------Select Office------", "0"));
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

        private void reset()
        {
            ddlRegion.ClearSelection();
            ddlOffice.ClearSelection();
            txtRemarks.Text = "";
            ddlDepartment.ClearSelection();
            ddlReligion.ClearSelection();
            ddlReasonType.ClearSelection();
            txtRemarks.Text = "";
            txtDate.Text = DateTime.Today.ToShortDateString();

            ddlReligion.Enabled = true;
            ddlDepartment.Enabled = true;
            btnSaveByDepartment.Enabled = true;
            btnSaveByReligion.Enabled = true;
        }

        protected void btnSaveByReligion_Click(object sender, EventArgs e)
        {
            try
            {
                HRM_TimeScheduleByReligion objattendanceReason = new HRM_TimeScheduleByReligion();

                objattendanceReason.RegionId = Convert.ToInt32(ddlRegion.SelectedValue);
                objattendanceReason.OfficeId = Convert.ToInt32(ddlOffice.SelectedValue);
                //objattendanceReason.DepartmentId = Convert.ToInt32(ddlDepartment.SelectedValue);
                objattendanceReason.Religion = ddlReligion.Text;
                objattendanceReason.Date = Convert.ToDateTime(txtDate.Text);
                objattendanceReason.ReasonType = ddlReasonType.Text;
                objattendanceReason.Remarks = ddlReasonType.SelectedItem.Text + " : " + txtRemarks.Text;

                TimeSpan in_time = TimeSpan.Parse(string.Format("{0}:{1}:{2}", txtStartTime.Hour, txtStartTime.Minute, txtStartTime.Second));
                objattendanceReason.InTime = in_time;

                TimeSpan out_time = TimeSpan.Parse(string.Format("{0}:{1}:{2}", txtEndTime.Hour, txtEndTime.Minute, txtEndTime.Second));
                objattendanceReason.OutTime = out_time;

                objattendanceReason.Edit_User = ((SessionUser)Session["SessionUser"]).UserId;
                objattendanceReason.Edit_Date = DateTime.Now;
                objattendanceReason.OCode = ((SessionUser)Session["SessionUser"]).OCode;

                if (in_time > out_time)
                {
                    // lblMessage.Text = "<font color='red'>Out Time can't be less than In Time</font>";
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Out Time can't be less than In Time')", true);
                    return;
                }

                int Count = (from shift in _context.HRM_TimeScheduleByReligion
                             where shift.RegionId == objattendanceReason.RegionId && shift.OfficeId == objattendanceReason.OfficeId && shift.Religion == objattendanceReason.Religion && shift.Date == objattendanceReason.Date
                             select shift.ReligionSechedule_Id).Count();

                if (Count != 0)
                {
                    // lblMessage.Text = "Data Already Exists!";
                    //lblMessage.ForeColor = System.Drawing.Color.Red;
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Data Already Exists!')", true);
                    return;
                }

                objAttendanceReasonBll.InsertTimeScheduleByReligion(objattendanceReason);

                HRM_AttendanceReason_Individual attendanceReasonInd = new HRM_AttendanceReason_Individual();
                attendanceReasonInd.RegionId = Convert.ToInt32(ddlRegion.SelectedValue);
                attendanceReasonInd.OfficeId = Convert.ToInt32(ddlOffice.SelectedValue);
                //attendanceReasonInd.DepartmentId = Convert.ToInt32(ddlDepartment.SelectedValue);
                attendanceReasonInd.ReasonDate = Convert.ToDateTime(txtDate.Text);
                attendanceReasonInd.ReasonTypeId = Convert.ToInt32(ddlReasonType.SelectedValue);
                attendanceReasonInd.ReasonType = ddlReasonType.SelectedItem.Text;
                attendanceReasonInd.Remarks = ddlReasonType.SelectedItem.Text + " : " + txtRemarks.Text;
                attendanceReasonInd.InTime = in_time;
                attendanceReasonInd.OutTime = out_time;

                attendanceReasonInd.Edit_User = ((SessionUser)Session["SessionUser"]).UserId;
                attendanceReasonInd.Edit_Date = DateTime.Now;
                attendanceReasonInd.OCode = ((SessionUser)Session["SessionUser"]).OCode;

                var result = objAttendanceReasonBll.InsertAtt_ReasonIndByReligion(Convert.ToInt32(ddlRegion.SelectedValue), Convert.ToInt32(ddlOffice.SelectedValue), Convert.ToInt32(ddlDepartment.SelectedValue), ddlReligion.Text, Convert.ToDateTime(txtDate.Text), in_time, out_time, Convert.ToInt32(ddlReasonType.SelectedValue), ddlReasonType.SelectedItem.Text, ddlReasonType.SelectedItem.Text + " : " + txtRemarks.Text, ((SessionUser)Session["SessionUser"]).UserId, DateTime.Now, ((SessionUser)Session["SessionUser"]).OCode);

                if (result == 1)
                {
                    // lblMessage.Text = "Data Added successfully!";
                    //lblMessage.ForeColor = System.Drawing.Color.Green;
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Data Added successfully!')", true);
                    reset();
                    BindGridAttendance();
                }
                else
                {
                    // lblMessage.Text = "Data Adding failure!";
                    //lblMessage.ForeColor = System.Drawing.Color.Red;
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Data Adding failure!')", true);
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
                List<HRM_TimeScheduleByReligion> attendanceReason = objAttendanceReasonBll.GetAllTimeScheduleByReligion(OCODE).ToList();
                if (attendanceReason.Count > 0)
                {
                    gridviewAttendanceByReligion.DataSource = attendanceReason;
                    gridviewAttendanceByReligion.DataBind();
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        protected void ddlRegions_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int RegionId = Convert.ToInt32(ddlRegion.SelectedValue);
                BindOfficeByRegion(RegionId);
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

        protected void gridviewAttendanceByReligion_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridviewAttendanceByReligion.PageIndex = e.NewPageIndex;
            BindGridAttendance();
        }

        protected void ddlReligion_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnSaveByReligion.Enabled = true;
            btnSaveByDepartment.Enabled = false;
            ddlDepartment.Enabled = false;
        }

        protected void ddlRegion_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblMessage.Text = "";
            try
            {
                int RegionId = Convert.ToInt32(ddlRegion.SelectedValue);
                BindOfficeByRegion(RegionId);
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

        private void getDepartmentByOffice(int officeId, string OCODE)
        {
            try
            {
                var row = departmentBll.GetDepartmentByOfficeIdAndOCode(officeId, OCODE).ToList();
                if (row.Count > 0)
                {
                    ddlDepartment.DataSource = row.ToList();
                    ddlDepartment.DataTextField = "DPT_NAME";
                    ddlDepartment.DataValueField = "DPT_ID";
                    ddlDepartment.DataBind();
                    ddlDepartment.Items.Insert(0, new ListItem("------Select Department------", "0"));
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }

        }

        protected void ddlOffice_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                int officeId = Convert.ToInt16(ddlOffice.SelectedValue);
                getDepartmentByOffice(officeId, OCODE);
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

        protected void ddlDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlReligion.Enabled = false;
            btnSaveByDepartment.Enabled = true;
            btnSaveByReligion.Enabled = false;
        }

        protected void btnSaveByDepartment_Click(object sender, EventArgs e)
        {
            try
            {
                HRM_TimeScheduleByReligion objattendanceReason = new HRM_TimeScheduleByReligion();

                objattendanceReason.RegionId = Convert.ToInt32(ddlRegion.SelectedValue);
                objattendanceReason.OfficeId = Convert.ToInt32(ddlOffice.SelectedValue);
                objattendanceReason.DepartmentId = Convert.ToInt32(ddlDepartment.SelectedValue);
                //objattendanceReason.Religion = ddlReligion.Text;
                objattendanceReason.Date = Convert.ToDateTime(txtDate.Text);
                objattendanceReason.ReasonType = ddlReasonType.Text;
                objattendanceReason.Remarks = ddlReasonType.SelectedItem.Text + " : " + txtRemarks.Text;

                TimeSpan in_time = TimeSpan.Parse(string.Format("{0}:{1}:{2}", txtStartTime.Hour, txtStartTime.Minute, txtStartTime.Second));
                objattendanceReason.InTime = in_time;

                TimeSpan out_time = TimeSpan.Parse(string.Format("{0}:{1}:{2}", txtEndTime.Hour, txtEndTime.Minute, txtEndTime.Second));
                objattendanceReason.OutTime = out_time;

                objattendanceReason.Edit_User = ((SessionUser)Session["SessionUser"]).UserId;
                objattendanceReason.Edit_Date = DateTime.Now;
                objattendanceReason.OCode = ((SessionUser)Session["SessionUser"]).OCode;

                if (in_time > out_time)
                {
                    //lblMessage.Text = "<font color='red'>Out Time can't be less than In Time</font>";
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Out Time can't be less than In Time')", true);

                    return;
                }

                int Count = (from shift in _context.HRM_TimeScheduleByReligion
                             where shift.RegionId == objattendanceReason.RegionId && shift.OfficeId == objattendanceReason.OfficeId && shift.DepartmentId == objattendanceReason.DepartmentId && shift.Date == objattendanceReason.Date
                             select shift.ReligionSechedule_Id).Count();

                if (Count != 0)
                {
                    // lblMessage.Text = "Data Already Exists!";
                    //lblMessage.ForeColor = System.Drawing.Color.Red;
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Data Already Exists!')", true);
                    return;
                }

                objAttendanceReasonBll.InsertTimeScheduleByReligion(objattendanceReason);

                HRM_AttendanceReason_Individual attendanceReasonInd = new HRM_AttendanceReason_Individual();
                attendanceReasonInd.RegionId = Convert.ToInt32(ddlRegion.SelectedValue);
                attendanceReasonInd.OfficeId = Convert.ToInt32(ddlOffice.SelectedValue);
                attendanceReasonInd.DepartmentId = Convert.ToInt32(ddlDepartment.SelectedValue);
                attendanceReasonInd.ReasonDate = Convert.ToDateTime(txtDate.Text);
                attendanceReasonInd.ReasonTypeId = Convert.ToInt32(ddlReasonType.SelectedValue);
                attendanceReasonInd.ReasonType = ddlReasonType.SelectedItem.Text;
                attendanceReasonInd.Remarks = ddlReasonType.SelectedItem.Text + " : " + txtRemarks.Text;
                attendanceReasonInd.InTime = in_time;
                attendanceReasonInd.OutTime = out_time;

                attendanceReasonInd.Edit_User = ((SessionUser)Session["SessionUser"]).UserId;
                attendanceReasonInd.Edit_Date = DateTime.Now;
                attendanceReasonInd.OCode = ((SessionUser)Session["SessionUser"]).OCode;

                if (in_time > out_time)
                {
                    //lblMessage.Text = "<font color='red'>Out Time can't be less than In Time</font>";
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Out Time can't be less than In Time')", true);
                    return;
                }

                var result = objAttendanceReasonBll.InsertAtt_ReasonIndByDepartment(Convert.ToInt32(ddlRegion.SelectedValue), Convert.ToInt32(ddlOffice.SelectedValue), Convert.ToInt32(ddlDepartment.SelectedValue), Convert.ToDateTime(txtDate.Text), in_time, out_time, Convert.ToInt32(ddlReasonType.SelectedValue), ddlReasonType.SelectedItem.Text, ddlReasonType.SelectedItem.Text + " : " + txtRemarks.Text, ((SessionUser)Session["SessionUser"]).UserId, DateTime.Now, ((SessionUser)Session["SessionUser"]).OCode);
                if (result == 1)
                {
                    // lblMessage.Text = "Data Added successfully!";
                    //lblMessage.ForeColor = System.Drawing.Color.Green;
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Data Added successfully!')", true);
                    reset();
                    BindGridAttendance();
                }

                else
                {
                    //lblMessage.Text = "Data Adding failure!";
                    //lblMessage.ForeColor = System.Drawing.Color.Red;
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Data Adding failure!')", true);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

    }
}

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
    public partial class AttendanceUpdate : System.Web.UI.Page
    {
        DEPARTMENT_BLL DepartmentBll = new DEPARTMENT_BLL();
        TIME_SCHEDULE_BLL timeScheduleBll = new TIME_SCHEDULE_BLL();
        ERPSSLHBEntities context = new ERPSSLHBEntities();
        Attendance_BLL objAtt_BLL = new Attendance_BLL();
        EmployeeSetup_BLL objEmp_BLL = new EmployeeSetup_BLL();
        AttendanceReason_BLL objAttendanceReasonBll = new AttendanceReason_BLL();
        TimeSpan? shifted_TotalHour = TimeSpan.Parse("09:00:00");
        Office_BLL objOfficeBLL = new Office_BLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Session["UserID"] != null) && (Session["OCode"] != null))
            {
                if (!IsPostBack)
                {
                    GetRegionList();
                    //BindGridEmployeeAttendance();
                    //txtAttDate.Text = DateTime.Today.ToShortDateString();
                }
            }
            else
            {
                Response.Redirect("..\\AppGateway\\Login.aspx");
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
                    ddlRegion.Items.Insert(0, new ListItem("------Select One------", "0"));
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
                    ddlOffice.Items.Insert(0, new ListItem("------Select One------", "0"));
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

        protected void ddlRegion_SelectedIndexChanged(object sender, EventArgs e)
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

        //protected void txtEid_AT_TextChanged(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
        //        string employeeID = Convert.ToString(txtEid_AT.Text);
        //        Emp_IMG_AT.ImageUrl = "EmployeeIMG.ashx?eId=" + employeeID + "&oCode=" + OCODE;

        //        var result = objAttendanceReasonBll.GetEmployeeDetailsID(employeeID, OCODE).ToList();
        //        if (result.Count > 0)
        //        {
        //            var objNewEmp = result.First();
        //            txtEid_AT.Text = Convert.ToString(objNewEmp.EID);
        //            txtEmpName_AT.Text = Convert.ToString(objNewEmp.EMP_FIRSTNAME + " " + objNewEmp.EMP_LASTNAME);
        //            lblHiddenId.Text = Convert.ToString(objNewEmp.EMP_ID);
        //            txtDepartment_AT.Text = objNewEmp.DPT_NAME;
        //            txtDesignation_AT.Text = objNewEmp.DEG_NAME;
        //            lblShiftCode.Text = objNewEmp.SHIFTCODE;
        //            shifted_TotalHour = objNewEmp.Shift_TotalHour;
        //        }
        //        else
        //        {
        //            //NO RECORDS FOUND.
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        void BindGridEmployeeAttendance()
        {
            try
            {
                string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                using (ERPSSLHBEntities context = new ERPSSLHBEntities())
                {
                    if (context.HRM_ATTENDANCE.Count() > 0)
                    {
                        var row = objAtt_BLL.GetAttendanceByShift_Date(OCODE, ddlShiftCode.SelectedItem.Text).ToList();
                        if (row.Count > 0)
                        {
                            GridViewEMP_AT.DataSource = row.ToList();
                            GridViewEMP_AT.DataBind();
                        }
                    }
                    else
                    {
                        var obj = new List<HRM_ATTENDANCE>();
                        obj.Add(new HRM_ATTENDANCE());

                        // Bind the DataTable which contain a blank row to the GridView
                        GridViewEMP_AT.DataSource = obj;
                        GridViewEMP_AT.DataBind();

                        int columnsCount = GridViewEMP_AT.Columns.Count;
                        GridViewEMP_AT.Rows[0].Cells.Clear();// clear all the cells in the row
                        GridViewEMP_AT.Rows[0].Cells.Add(new TableCell()); //add a new blank cell
                        GridViewEMP_AT.Rows[0].Cells[0].ColumnSpan = columnsCount; //set the column span to the new added cell

                        GridViewEMP_AT.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Center;
                        GridViewEMP_AT.Rows[0].Cells[0].ForeColor = System.Drawing.Color.Red;
                        GridViewEMP_AT.Rows[0].Cells[0].Font.Bold = true;

                        //set No Results found to the new added cell
                        GridViewEMP_AT.Rows[0].Cells[0].Text = "NO RECORDS FOUND!";
                    }
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

        void BindGridAttendanceByEID()
        {
            try
            {
                string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                using (ERPSSLHBEntities context = new ERPSSLHBEntities())
                {
                    if (context.HRM_ATTENDANCE.Count() > 0)
                    {
                        var row = objAtt_BLL.GetAttendanceByEID(OCODE, txtEID.Text).ToList();
                        if (row.Count > 0)
                        {
                            GridViewEMP_AT.DataSource = row.ToList();
                            GridViewEMP_AT.DataBind();
                        }
                    }
                    else
                    {
                        var obj = new List<HRM_ATTENDANCE>();
                        obj.Add(new HRM_ATTENDANCE());

                        // Bind the DataTable which contain a blank row to the GridView
                        GridViewEMP_AT.DataSource = obj;
                        GridViewEMP_AT.DataBind();

                        int columnsCount = GridViewEMP_AT.Columns.Count;
                        GridViewEMP_AT.Rows[0].Cells.Clear();// clear all the cells in the row
                        GridViewEMP_AT.Rows[0].Cells.Add(new TableCell()); //add a new blank cell
                        GridViewEMP_AT.Rows[0].Cells[0].ColumnSpan = columnsCount; //set the column span to the new added cell

                        GridViewEMP_AT.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Center;
                        GridViewEMP_AT.Rows[0].Cells[0].ForeColor = System.Drawing.Color.Red;
                        GridViewEMP_AT.Rows[0].Cells[0].Font.Bold = true;

                        //set No Results found to the new added cell
                        GridViewEMP_AT.Rows[0].Cells[0].Text = "NO RECORDS FOUND!";
                    }
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

        protected void btnAttSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                using (ERPSSLHBEntities _context = new ERPSSLHBEntities())
                {
                    string at_status = "";
                    //bool ot_status;

                    HRM_ATTENDANCE obj = new HRM_ATTENDANCE();
                    //obj.EmpId = Convert.ToInt64(lblHiddenId.Text);
                    //obj.EID = txtEid_AT.Text;
                    //obj.ShiftCode = lblShiftCode.Text;
                    //obj.Attendance_Date = Convert.ToDateTime(txtAttDate.Text);
                    //obj.Attendance_Day = Convert.ToDateTime(txtAttDate.Text).DayOfWeek.ToString();
                    //obj.Working_Day = ddlWorkingDay.Text;
                    //obj.OT_Compliance = 0;

                    TimeSpan in_time = TimeSpan.Parse(string.Format("{0}:{1}:{2}", txtAttInTime.Hour, txtAttInTime.Minute, txtAttInTime.Second));
                    obj.In_Time = in_time;

                    TimeSpan out_time = TimeSpan.Parse(string.Format("{0}:{1}:{2}", txtAttOutTime.Hour, txtAttOutTime.Minute, txtAttOutTime.Second));
                    obj.Out_Time = out_time;

                    //TimeSpan workedTime = Calculations.timeDiff(in_time, out_time);
                    //TimeSpan overTime = TimeSpan.Parse("00:00:00");

                    //if (overTime == TimeSpan.Parse("00:00:00"))
                    //{
                    //    ot_status = false;
                    //}
                    //else
                    //{
                    //    ot_status = true;
                    //}

                    //obj.Worked_Time = workedTime;
                    //obj.Shift_TotalHour = shifted_TotalHour;
                    //obj.Over_Time = overTime;
                    //obj.OT_Hour = 0;
                    //obj.OT_Minute = 0;
                    //obj.OT_Total = 0;
                    //obj.OT_Status = ot_status;

                    if (rdbPresent.Checked == true)
                    {
                        at_status = "P";
                    }
                    if (rdbLate.Checked == true)
                    {
                        at_status = "L";
                    }
                    if (rdbOverLate.Checked == true)
                    {
                        at_status = "OL";
                    }
                    if (rdbAbsent.Checked == true)
                    {
                        at_status = "A";
                    }

                    obj.Status = at_status;
                    //obj.Remarks = "Manual Attendance : "+txtRemarks_AT.Text;

                    obj.Edit_User = ((SessionUser)Session["SessionUser"]).UserId;
                    //obj.EDIT_USER = Guid.Parse("a376708d-757f-4777-bd05-bfc89b6971ce");
                    obj.Edit_Date = DateTime.Now;
                    obj.OCode = ((SessionUser)Session["SessionUser"]).OCode;

                    if (in_time > out_time)
                    {
                        lblMessage.Text = "<font color='red'>Out Time can't be less than In Time</font>";
                        return;
                    }

                    int AttId = Convert.ToInt32(hiddenId.Value);
                    int result = objAtt_BLL.UpdateAttendance(obj, AttId);
                    if (result == 1)
                    {
                        lblMessage.Text = "Data Update successfully";
                        lblMessage.ForeColor = System.Drawing.Color.Green;
                        reset();

                        if (txtEID.Text != "")
                        {
                            BindGridAttendanceByEID();
                        }
                        else
                        {
                            BindGridEmployeeAttendance();
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

        private void reset()
        {
            txtAttDate.Text = "";
            rdbPresent.Checked = true;
            txtRemarks_AT.Text = "";
            txtWorkingDay.Text = "";
            //txtEID.Text = "";
        }

        protected void GridViewEMP_AT_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridViewEMP_AT.PageIndex = e.NewPageIndex;
            BindGridEmployeeAttendance();
        }

        protected void imgbtnAttEdit_Click(object sender, EventArgs e)
        {
            lblMessage.Text = "";
            List<HRM_ATTENDANCE> objAttendance = new List<HRM_ATTENDANCE>();
            ImageButton imgbtn = (ImageButton)sender;
            GridViewRow row = (GridViewRow)imgbtn.NamingContainer;

            try
            {
                string AttendanceId = "";
                Label lblId = (Label)GridViewEMP_AT.Rows[row.RowIndex].FindControl("lblId");
                if (lblId != null)
                {
                    string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                    AttendanceId = lblId.Text;
                    objAttendance = objAtt_BLL.GetAttendanceById(AttendanceId, OCODE);

                    if (objAttendance.Count > 0)
                    {
                        foreach (HRM_ATTENDANCE attendance in objAttendance)
                        {
                            hiddenId.Value = attendance.ATTE_ID.ToString();
                            txtEID.Text = attendance.EID;
                            //txtEmpName_AT.Text = attendance.HRM_PersonalInformations.FirstName + " " + attendance.HRM_PersonalInformations.LastName;
                            //lblHiddenId.Text = Convert.ToString(attendance.EmpId);

                            txtAttDate.Text = Convert.ToDateTime(attendance.Attendance_Date).ToShortDateString();
                            txtRemarks_AT.Text = attendance.Remarks;
                            txtWorkingDay.Text = attendance.Working_Day;

                            if (attendance.Status == "p")
                            {
                                rdbPresent.Checked = true;
                            }
                            if (attendance.Status == "L")
                            {
                                rdbLate.Checked = true;
                            }
                            if (attendance.Status == "OL")
                            {
                                rdbOverLate.Checked = true;
                            }
                            if (attendance.Status == "A")
                            {
                                rdbAbsent.Checked = true;
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

        protected void ddlOffice_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                int RegionId = Convert.ToInt32(ddlRegion.SelectedValue);
                int OfficeId = Convert.ToInt32(ddlOffice.SelectedValue);

                var row = DepartmentBll.GetDepartmentByOffice(RegionId, OfficeId, OCODE).ToList();
                if (row.Count > 0)
                {
                    ddlDepartment.DataSource = row.ToList();
                    ddlDepartment.DataTextField = "DPT_NAME";
                    ddlDepartment.DataValueField = "DPT_ID";
                    ddlDepartment.DataBind();
                    ddlDepartment.Items.Insert(0, new ListItem("------Select One------"));
                }
                else
                {
                    ddlDepartment.DataSource = null;
                    ddlDepartment.DataTextField = "DPT_NAME";
                    ddlDepartment.DataValueField = "DPT_ID";
                    ddlDepartment.DataBind();
                    ddlDepartment.Items.Insert(0, new ListItem("------Select One------"));
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

        protected void ddlDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                int RegionId = Convert.ToInt32(ddlRegion.SelectedValue);
                int OfficeId = Convert.ToInt32(ddlOffice.SelectedValue);
                int DepartmentId = Convert.ToInt32(ddlDepartment.SelectedValue);

                var row = timeScheduleBll.GetShiftByDepartment(RegionId, OfficeId, DepartmentId, OCODE).ToList();
                if (row.Count > 0)
                {
                    ddlShiftCode.DataSource = row.ToList();
                    ddlShiftCode.DataTextField = "ShiftCode";
                    ddlShiftCode.DataValueField = "ScheduleId";
                    ddlShiftCode.DataBind();
                    ddlShiftCode.Items.Insert(0, new ListItem("------Select One------"));
                }
                else
                {
                    ddlDepartment.DataSource = null;
                    ddlDepartment.DataTextField = "ShiftCode";
                    ddlDepartment.DataValueField = "ScheduleId";
                    ddlDepartment.DataBind();
                    ddlDepartment.Items.Insert(0, new ListItem("------Select One------"));
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

        protected void ddlShiftCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindGridEmployeeAttendance();
        }

        protected void txtEID_TextChanged(object sender, EventArgs e)
        {
            BindGridAttendanceByEID();
        }

    }
}
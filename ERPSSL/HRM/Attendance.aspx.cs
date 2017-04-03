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
    public partial class Attendance : System.Web.UI.Page
    {
        private ERPSSLHBEntities _context = new ERPSSLHBEntities();
        //EMPOYEE_BLL objEmp_BLL = new EMPOYEE_BLL();
        ERPSSLHBEntities context = new ERPSSLHBEntities();
        Attendance_BLL objAtt_BLL = new Attendance_BLL();
        EmployeeSetup_BLL objEmp_BLL = new EmployeeSetup_BLL();
        AttendanceReason_BLL objAttendanceReasonBll = new AttendanceReason_BLL();
        TimeSpan? shifted_TotalHour = TimeSpan.Parse("09:00:00");

        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Session["UserID"] != null) && (Session["OCode"] != null))
            {
                if (!IsPostBack)
                {
                    BindGridEmployeeAttendance();
                    txtAttDate.Text = DateTime.Today.ToShortDateString();
                }
            }
            else
            {
                Response.Redirect("..\\AppGateway\\Login.aspx");
            }
        }

        protected void txtEid_AT_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                string employeeID = Convert.ToString(txtEid_AT.Text);

                var result = objAttendanceReasonBll.GetEmployeeDetailsID(employeeID, OCODE).ToList();
                if (result.Count > 0)
                {
                    Emp_IMG_AT.Visible = true;
                    Emp_IMG_AT.ImageUrl = "EmployeeIMG.ashx?eId=" + employeeID + "&oCode=" + OCODE;

                    var objNewEmp = result.First();
                    txtEid_AT.Text = Convert.ToString(objNewEmp.EID);
                    txtEmpName_AT.Text = Convert.ToString(objNewEmp.EMP_FIRSTNAME + " " + objNewEmp.EMP_LASTNAME);
                    lblHiddenId.Text = Convert.ToString(objNewEmp.EMP_ID);
                    txtDepartment_AT.Text = objNewEmp.DPT_NAME;
                    txtDesignation_AT.Text = objNewEmp.DEG_NAME;
                    lblShiftCode.Text = objNewEmp.SHIFTCODE;
                    shifted_TotalHour = objNewEmp.Shift_TotalHour;
                }
                else
                {
                    txtDepartment_AT.Text = "";
                    txtDesignation_AT.Text = "";
                    txtEmpName_AT.Text = "";
                    Emp_IMG_AT.Visible = false;
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('This Employee is Inactive!')", true);
                    //lblMessege.Text = "NO RECORDS FOUND.";
                    //lblMessege.ForeColor = System.Drawing.Color.Green;
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

        void BindGridEmployeeAttendance()
        {
            try
            {
                string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                using (ERPSSLHBEntities context = new ERPSSLHBEntities())
                {
                    if (context.HRM_ATTENDANCE.Count() > 0)
                    {
                        var row = objAtt_BLL.GetAllAttendance(OCODE).ToList();
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
                throw ex;
            }
        }

        protected void btnAttSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                //using (ERPSSLHBEntities _context = new ERPSSLHBEntities())
                //{
                string at_status = "";
                bool ot_status;

                HRM_ATTENDANCE objAttendance = new HRM_ATTENDANCE();
                objAttendance.EmpId = Convert.ToInt64(lblHiddenId.Text);
                objAttendance.EID = txtEid_AT.Text;
                objAttendance.ShiftCode = lblShiftCode.Text;
                objAttendance.Attendance_Date = Convert.ToDateTime(txtAttDate.Text);
                objAttendance.Attendance_Day = Convert.ToDateTime(txtAttDate.Text).DayOfWeek.ToString();
                objAttendance.Working_Day = ddlWorkingDay.Text;
                objAttendance.OT_Compliance = 0;
                objAttendance.Update_Status = 0;
                objAttendance.Attendance_Process_Status = true;

                TimeSpan in_time = TimeSpan.Parse(string.Format("{0}:{1}:{2}", txtAttInTime.Hour, txtAttInTime.Minute, txtAttInTime.Second));
                objAttendance.In_Time = in_time;

                TimeSpan out_time = TimeSpan.Parse(string.Format("{0}:{1}:{2}", txtAttOutTime.Hour, txtAttOutTime.Minute, txtAttOutTime.Second));
                objAttendance.Out_Time = out_time;

                TimeSpan workedTime = Calculations.timeDiff(in_time, out_time);
                TimeSpan overTime = TimeSpan.Parse("00:00:00");

                TimeSpan originalTime = TimeSpan.Parse("09:00:00");

                if (originalTime < in_time)
                {
                    TimeSpan late_time = Calculations.timeDiff(originalTime, in_time);
                    objAttendance.Late_Time = late_time;
                }
                else
                {
                    objAttendance.Late_Time = TimeSpan.Parse("00:00:00");
                }
                //if (workedTime > in_time)
                //{
                //    overTime = (workedTime - in_time);
                //    ot_status = true;
                //}
                //else
                //{
                //    ot_status = false;
                //}

                if (overTime == TimeSpan.Parse("00:00:00"))
                {
                    ot_status = false;
                }
                else
                {
                    ot_status = true;
                }

                objAttendance.Worked_Time = workedTime;
                objAttendance.Shift_TotalHour = shifted_TotalHour;
                objAttendance.Over_Time = overTime;
                objAttendance.OT_Hour = 0;
                objAttendance.OT_Minute = 0;
                objAttendance.OT_Total = 0;
                objAttendance.OT_ExtraAdd = 0;
                objAttendance.OT_Deduction = 0;
                objAttendance.OT_Status = ot_status;

                if (rdbPresent.Checked == true)
                {
                    at_status = "P";
                }
                if (rdbLate.Checked == true)
                {
                    at_status = "L";
                }
                //if (rdbOverLate.Checked == true)
                //{
                //    at_status = "OL";
                //}
                if (rdbAbsent.Checked == true)
                {
                    at_status = "A";
                }

                objAttendance.Status = at_status;
                //objAttendance.A = at_status;
                objAttendance.Remarks = txtRemarks_AT.Text;

                //obj.EDIT_USER = Guid.Parse("a376708d-757f-4777-bd05-bfc89b6971ce");
                objAttendance.Edit_User = ((SessionUser)Session["SessionUser"]).UserId;
                objAttendance.Edit_Date = DateTime.Now;

                string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                objAttendance.OCode = OCODE;

                //if (in_time > out_time)
                //{
                //    lblMessege.Text = "<font color='red'>Out Time can't be less than In Time</font>";
                //    return;
                //}

                int AttendanceCount = (from att in _context.HRM_ATTENDANCE
                                       where att.EID == objAttendance.EID && att.Attendance_Date == objAttendance.Attendance_Date
                                       select att.ATTE_ID).Count();

                //HRM_ATTENDANCE aHRM_ATTENDANCE = objAtt_BLL.GetAllAttendanceData(Convert.ToDateTime(txtAttDate.Text), txtEid_AT.Text);

                //if (aHRM_ATTENDANCE.In_Time == TimeSpan.Parse("00:00:00") || AttendanceCount==0)
                //{
                int result = objAtt_BLL.InsertAttendance(objAttendance);
                if (result == 1)
                {
                    //lblMessege.Text = "Attendance Recorded successfully!";
                    //lblMessege.ForeColor = System.Drawing.Color.Green;
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Attendance Recorded successfully!')", true);
                    reset();
                    BindGridEmployeeAttendance();

                }

                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Attendance Recorded failure!')", true);
                    // lblMessege.Text = "Attendance Recorded failure!";
                    //lblMessege.ForeColor = System.Drawing.Color.Red;
                }
                //}
                //else
                //{
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Attendance Already Recorded in this day for this Employee!')", true);
                //lblMessege.Text = "Attendance Already Recorded in this day for this Employee!";
                //lblMessege.ForeColor = System.Drawing.Color.Red;
                //reset();
                //}
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

        private void reset()
        {
            txtEid_AT.Text = "";
            txtEmpName_AT.Text = "";
            txtDepartment_AT.Text = "";
            txtDesignation_AT.Text = "";
            //Emp_IMG_AT.ImageUrl = Request.RawUrl;
            Emp_IMG_AT.ImageUrl = "resources/no_image.png";
            txtRemarks_AT.Text = "";
            rdbPresent.Checked = true;
            ddlWorkingDay.ClearSelection();
            txtEid_AT.Focus();
        }

        protected void GridViewEMP_AT_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridViewEMP_AT.PageIndex = e.NewPageIndex;
            BindGridEmployeeAttendance();
        }

    }
}
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
    public partial class ShiftSetup : System.Web.UI.Page
    {
        Office_BLL objOfficeBLL = new Office_BLL();
        TIME_SCHEDULE_BLL objtimeScheduleBLL = new TIME_SCHEDULE_BLL();
        DEPARTMENT_BLL departmentBll = new DEPARTMENT_BLL();
        private ERPSSLHBEntities _context = new ERPSSLHBEntities();

        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Session["UserID"] != null) && (Session["OCode"] != null))
            {
                if (!IsPostBack)
                {
                    BindGridTimeSchedule();
                    weekEnd1Duty.Visible = false;
                    weekEnd2Duty.Visible = false;
                    // GetRegionList();
                    // GetOfficeList();
                    // GetDepartmentList();

                }
            }
            else
            {
                Response.Redirect("..\\AppGateway\\Login.aspx");
            }
        }

        //private void GetRegionList()
        //{
        //    try
        //    {
        //        string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
        //        var row = objOfficeBLL.GetAllResion(OCODE).ToList();
        //        if (row.Count > 0)
        //        {
        //            ddlRegion.DataSource = row.ToList();
        //            ddlRegion.DataTextField = "RegionName";
        //            ddlRegion.DataValueField = "RegionID";
        //            ddlRegion.DataBind();
        //            ddlRegion.Items.Insert(0, new ListItem("------Select Region------", "0"));
        //        }


        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}

        //private void GetOfficeList()
        //{
        //    try
        //    {
        //        string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
        //        var row = objOfficeBLL.GetAllOffice(OCODE).ToList();
        //        if (row.Count > 0)
        //        {
        //            ddlOffice.DataSource = row.ToList();
        //            ddlOffice.DataTextField = "OfficeName";
        //            ddlOffice.DataValueField = "OfficeID";
        //            ddlOffice.DataBind();
        //            ddlOffice.Items.Insert(0, new ListItem("------Select Office------", "0"));
        //        }
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}


        //private void GetDepartmentList()
        //{
        //    try
        //    {
        //        string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
        //        var row = departmentBll.DepartmentList(OCODE).ToList();
        //        if (row.Count > 0)
        //        {
        //            ddlDepartment.DataSource = row.ToList();
        //            ddlDepartment.DataTextField = "DPT_NAME";
        //            ddlDepartment.DataValueField = "DPT_ID";
        //            ddlDepartment.DataBind();
        //            ddlDepartment.Items.Insert(0, new ListItem("------Select Department------", "0"));
        //        }
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}

        //private void BindOfficeByRegion(int RegionId)
        //{
        //    var row = objOfficeBLL.GetOfficeByResionId(RegionId).ToList();
        //    if (row.Count > 0)
        //    {
        //        ddlOffice.DataSource = row.ToList();
        //        ddlOffice.DataTextField = "OfficeName";
        //        ddlOffice.DataValueField = "OfficeID";
        //        ddlOffice.DataBind();
        //        ddlOffice.Items.Insert(0, new ListItem("------Select Office------", "0"));
        //    }
        //    else
        //    {
        //        ddlOffice.DataSource = null;
        //        ddlOffice.DataTextField = "OfficeName";
        //        ddlOffice.DataValueField = "OfficeID";
        //        ddlOffice.DataBind();
        //        ddlOffice.Items.Insert(0, new ListItem("------Select Office------", "0"));
        //    }
        //}

        protected void ddlWeekend1Duty_ddlWeekend1Duty(object sender, EventArgs e)
        {
            try
            {
                if (ddlWeekend1Duty.SelectedValue == "True")
                {
                    weekEnd1Duty.Visible = true;
                }
                else
                {
                    weekEnd1Duty.Visible = false;
                    ddlWeekend1Duty.SelectedValue = false.ToString();
                }

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }
        protected void ddlWeekend2Duty_SelectIndex(object sender, EventArgs e)
        {
            try
            {
                if (ddlWeekend2Duty.SelectedValue == "True")
                {
                    weekEnd2Duty.Visible = true;
                }
                else
                {
                    weekEnd2Duty.Visible = false;
                    ddlWeekend2Duty.SelectedValue = false.ToString();
                }

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

        private void reset()
        {
            //ddlRegion.ClearSelection();
            ddlWeekend1.ClearSelection();
            ddlWeekend2.ClearSelection();
            //ddlDepartment.ClearSelection();
            //ddlOffice.ClearSelection();
            ddlShift.ClearSelection();
            txtShiftCode.Text = "";
            txtShiftName.Text = "";
            txtWeekend1DutyHour.Text = "";
            ddlWeekend1Duty.ClearSelection();
            txtWeekend2DutyHour.Text = "";
            ddlWeekend2Duty.ClearSelection();
            BtnSave.Text = "Save";
        }

        protected void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                HRM_TIMESCHEDULE objtimeSchedule = new HRM_TIMESCHEDULE();

                //objtimeSchedule.RegionId = Convert.ToInt32(ddlRegion.SelectedValue);
                //objtimeSchedule.OfficeId = Convert.ToInt32(ddlOffice.SelectedValue);
                //objtimeSchedule.DepartmentId = Convert.ToInt32(ddlDepartment.SelectedValue);
                objtimeSchedule.ShiftCode = txtShiftCode.Text;
                objtimeSchedule.ShiftName = txtShiftName.Text;
                objtimeSchedule.ShiftType = ddlShift.Text;
                objtimeSchedule.Weekend1 = ddlWeekend1.SelectedValue.ToString();

                if (ddlWeekend1Duty.SelectedItem.Text == "------ Select One ------")
                {
                    objtimeSchedule.Weekend1_Duty = false;
                }
                else
                {
                    objtimeSchedule.Weekend1_Duty = Convert.ToBoolean(ddlWeekend1Duty.SelectedValue.ToString());
                }

                if (ddlWeekend2Duty.SelectedItem.Text == "------ Select One ------")
                {
                    objtimeSchedule.Weekend2_Duty = false;
                }
                else
                {
                    objtimeSchedule.Weekend2_Duty = Convert.ToBoolean(ddlWeekend2Duty.SelectedValue.ToString());
                }

                objtimeSchedule.Weekend2 = ddlWeekend2.SelectedValue.ToString();
                objtimeSchedule.Weekend1Duty_Hour = txtWeekend1DutyHour.Text;
                objtimeSchedule.Weekend2Duty_Hour = txtWeekend2DutyHour.Text;

                TimeSpan start_time = TimeSpan.Parse(string.Format("{0}:{1}:{2}", txtStartTime.Hour, txtStartTime.Minute, txtStartTime.Second));
                objtimeSchedule.StartTime = start_time;

                TimeSpan end_time = TimeSpan.Parse(string.Format("{0}:{1}:{2}", txtEndTime.Hour, txtEndTime.Minute, txtEndTime.Second));
                objtimeSchedule.EndTime = end_time;

                //objtimeSchedule.StartTime = (txtStartTime.Hour + ":" + txtStartTime.Minute + ":" + txtStartTime.Second + " " + txtStartTime.AmPm);
                //objtimeSchedule.EndTime = (txtEndTime.Hour + ":" + txtEndTime.Minute + ":" + txtEndTime.Second + " " + txtEndTime.AmPm);

                TimeSpan lateAllowed = TimeSpan.Parse(string.Format("{0}:{1}:{2}", txtLateAllowed.Hour, txtLateAllowed.Minute, txtLateAllowed.Second));
                objtimeSchedule.LateAllowed = lateAllowed;

                TimeSpan totalHour, hour1, hour2;

                if (ddlShift.SelectedItem.Text == "Night")
                {
                    hour1 = TimeSpan.Parse("23:59:59");
                    hour2 = Calculations.timeDiff(start_time, hour1);
                    totalHour = hour2 + end_time;
                    objtimeSchedule.TotalHour = totalHour;
                }
                else
                {
                    totalHour = Calculations.timeDiff(start_time, end_time);
                    objtimeSchedule.TotalHour = totalHour;
                }

                objtimeSchedule.Edit_User = ((SessionUser)Session["SessionUser"]).UserId;
                objtimeSchedule.Edit_Date = DateTime.Now;
                objtimeSchedule.OCode = ((SessionUser)Session["SessionUser"]).OCode;

                //if (end_time < start_time)
                //{
                //    lblMessage.Text = "<font color='red'>Out Time can't be less than In Time</font>";
                //    return;
                //}

                int ShiftCount = (from shift in _context.HRM_TIMESCHEDULE
                                  where shift.ShiftCode == objtimeSchedule.ShiftCode && shift.ShiftName == objtimeSchedule.ShiftName
                                  select shift.ScheduleId).Count();

                if (BtnSave.Text == "Save")
                {
                    if (ShiftCount != 0)
                    {
                        //    lblMessage.Text = "";
                        //    lblMessage.ForeColor = System.Drawing.Color.Red;
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Data Already Exists!')", true);
                        return;
                    }

                    int result = objtimeScheduleBLL.InsertTimeSchedule(objtimeSchedule);
                    if (result == 1)
                    {
                        //  lblMessage.Text = "Record Added successfully!";
                        //  lblMessage.ForeColor = System.Drawing.Color.Green;
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Data Save Successfully')", true);

                    }
                    else
                    {
                        //    lblMessage.Text = "";
                        //    lblMessage.ForeColor = System.Drawing.Color.Green;
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Date Adding failure!')", true);
                    }
                }
                else
                {
                    int scheduleId = Convert.ToInt32(hiddenId.Value);
                    int result = objtimeScheduleBLL.UpdateTimeSchedule(objtimeSchedule, scheduleId);
                    if (result == 1)
                    {
                        //   lblMessage.Text = "Data Update successfully!";
                        //  lblMessage.ForeColor = System.Drawing.Color.Green;
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Data Update Successfully')", true);
                    }
                    else
                    {
                        //   lblMessage.Text = "";
                        //  lblMessage.ForeColor = System.Drawing.Color.Green;
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Date Updating failure!')", true);
                    }
                }
                reset();
                BindGridTimeSchedule();
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }


        private void BindGridTimeSchedule()
        {
            try
            {
                string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                List<HRM_TIMESCHEDULE> timeSchedule = objtimeScheduleBLL.GetAllSchedule(OCODE).ToList();
                if (timeSchedule.Count > 0)
                {
                    gridviewTimeSchedule.DataSource = timeSchedule;
                    gridviewTimeSchedule.DataBind();
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        //protected void ddlRegion_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    lblMessage.Text = "";
        //    try
        //    {
        //        int RegionId = Convert.ToInt32(ddlRegion.SelectedValue);
        //        BindOfficeByRegion(RegionId);

        //        string RegCode = ddlRegion.SelectedItem.Text;
        //        string str = RegCode.Substring(0, 3);
        //        //txtShiftCode.Text = str.ToString() + "-";
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}

        protected void gridviewTimeSchedule_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridviewTimeSchedule.PageIndex = e.NewPageIndex;
            BindGridTimeSchedule();
        }

        //private void getDepartmentByOffice(int officeId, string OCODE)
        //{
        //    var row = departmentBll.GetDepartmentByOfficeIdAndOCode(officeId, OCODE).ToList();
        //    if (row.Count > 0)
        //    {
        //        ddlDepartment.DataSource = row.ToList();
        //        ddlDepartment.DataTextField = "DPT_NAME";
        //        ddlDepartment.DataValueField = "DPT_ID";
        //        ddlDepartment.DataBind();
        //        ddlDepartment.Items.Insert(0, new ListItem("------Select One------", "0"));
        //    }

        //}

        //protected void ddlOffice_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
        //        int officeId = Convert.ToInt16(ddlOffice.SelectedValue);
        //        getDepartmentByOffice(officeId, OCODE);
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}

        protected void imgbtnEdit_Click(object sender, EventArgs e)
        {
            lblMessage.Text = "";
            List<HRM_TIMESCHEDULE> objTimeShift = new List<HRM_TIMESCHEDULE>();
            ImageButton imgbtn = (ImageButton)sender;
            GridViewRow row = (GridViewRow)imgbtn.NamingContainer;

            try
            {
                string ShceduleId = "";
                Label lblId = (Label)gridviewTimeSchedule.Rows[row.RowIndex].FindControl("lblId");
                if (lblId != null)
                {
                    string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                    ShceduleId = lblId.Text;
                    objTimeShift = objtimeScheduleBLL.GetScheduleById(OCODE, ShceduleId);

                    if (objTimeShift.Count > 0)
                    {
                        foreach (HRM_TIMESCHEDULE timeSchedule in objTimeShift)
                        {
                            hiddenId.Value = timeSchedule.ScheduleId.ToString();
                            //ddlRegion.SelectedValue = Convert.ToInt16(timeSchedule.RegionId).ToString();
                            //ddlOffice.SelectedValue = Convert.ToInt16(timeSchedule.OfficeId).ToString();
                            // ddlDepartment.SelectedValue = Convert.ToInt16(timeSchedule.DepartmentId).ToString();
                            txtShiftCode.Text = timeSchedule.ShiftCode;
                            txtShiftName.Text = timeSchedule.ShiftName;
                            ddlShift.Text = timeSchedule.ShiftType;

                            if (timeSchedule.Weekend1_Duty == true)
                            {
                                ddlWeekend1Duty.SelectedValue = "True";
                            }
                            else
                            {
                                ddlWeekend1Duty.SelectedValue = "False";
                            }

                            if (timeSchedule.Weekend2_Duty == true)
                            {
                                ddlWeekend2Duty.SelectedValue = "True";
                            }
                            else
                            {
                                ddlWeekend2Duty.SelectedValue = "False";
                            }
                            ddlWeekend1.Text = timeSchedule.Weekend1;
                            //ddWeekend1Duty.Text = timeSchedule.Weekend1Duty_Hour;
                            ddlWeekend2.Text = timeSchedule.Weekend2;
                            //ddlWeekend2Duty.Text = timeSchedule.Weekend2Duty_Hour;
                        }
                        if (BtnSave.Text == "Save")
                        {
                            BtnSave.Text = "Update";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }


    }
}

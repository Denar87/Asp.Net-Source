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
    public partial class AttendanceReason : System.Web.UI.Page
    {
        Office_BLL objOfficeBLL = new Office_BLL();
        AttendanceReason_BLL objAttendanceReasonBll = new AttendanceReason_BLL();
        ReasonTypeBLL reasonTypeBll = new ReasonTypeBLL();
        TIME_SCHEDULE_BLL timeScheduleBll = new TIME_SCHEDULE_BLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Session["UserID"] != null) && (Session["OCode"] != null))
            {
                if (!IsPostBack)
                {
                    GetShiftCodeList();
                    GetReasonList();
                    BindGridAttendance();
                    //GetRegionList();
                    txtfromDate.Text = DateTime.Today.ToShortDateString();
                    txttoDate.Text = DateTime.Today.ToShortDateString();
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
            catch (Exception ex)
            {
                //string EID = Convert.ToString(((SessionUser)Session["SessionUser"]).EID);
                //LogController<AttendanceReason>.SetLog(ex, EID);
                //ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
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
        //            ddlRegions.DataSource = row.ToList();
        //            ddlRegions.DataTextField = "RegionName";
        //            ddlRegions.DataValueField = "RegionID";
        //            ddlRegions.DataBind();
        //            ddlRegions.Items.Insert(0, new ListItem("------Select One------", "0"));
        //        }


        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}

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
                    ddlReasonType.Items.Insert(0, new ListItem("------Select One------", "0"));
                }
            }
            catch (Exception ex)
            {
                //string EID = Convert.ToString(((SessionUser)Session["SessionUser"]).EID);
                //LogController<AttendanceReason>.SetLog(ex, EID);
                //ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

        //private void BindOfficeByRegion(int RegionId)
        //{
        //    var row = objOfficeBLL.GetOfficeByResionId(RegionId).ToList();
        //    if (row.Count > 0)
        //    {
        //        ddlOffice.DataSource = row.ToList();
        //        ddlOffice.DataTextField = "OfficeName";
        //        ddlOffice.DataValueField = "OfficeID";
        //        ddlOffice.DataBind();
        //        ddlOffice.Items.Insert(0, new ListItem("------Select One------", "0"));
        //    }

        //}

        private void reset()
        {
            //ddlRegions.ClearSelection();
            //ddlOffice.ClearSelection();
            //ddlShift.ClearSelection();
            ddlShiftCode.ClearSelection();
            //txtRegion.Text = "";
            //txtOffice.Text = "";
            //txtShift.Text = "";
            txtRemarks.Text = "";
            ddlReasonType.ClearSelection();
            BtnSave.Text = "Save";
            hdfTotalDay.Value = "";
        }

        protected void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime DateFrom = Convert.ToDateTime(txtfromDate.Text);
                List<HRM_AttendanceReason> lstHRM_AttendanceReason = new List<HRM_AttendanceReason>();

                for (int i = 0; i < Convert.ToInt16(hdfTotalDay.Value); i++)
                {
                    HRM_AttendanceReason objattendanceReason = new HRM_AttendanceReason();

                    //objattendanceReason.RegionId = Convert.ToInt32(lblRegionId.Text);
                    //objattendanceReason.OfficeId = Convert.ToInt32(lblOfficeId.Text);
                    objattendanceReason.ShiftCode = ddlShiftCode.SelectedValue;
                    objattendanceReason.ShiftName = ddlShiftCode.SelectedItem.Text;
                    objattendanceReason.ReasonDate = DateFrom.AddDays(i);
                    objattendanceReason.ReasonTypeId = Convert.ToInt32(ddlReasonType.SelectedValue);
                    objattendanceReason.ReasonType = ddlReasonType.SelectedItem.Text;
                    objattendanceReason.Remarks = txtRemarks.Text;

                    //objattendanceReason.InTime = (txtStartTime.Hour + ":" + txtStartTime.Minute + ":" + txtStartTime.Second + " " + txtStartTime.AmPm);
                    //objattendanceReason.OutTime = (txtEndTime.Hour + ":" + txtEndTime.Minute + ":" + txtEndTime.Second + " " + txtEndTime.AmPm);

                    TimeSpan in_time = TimeSpan.Parse(string.Format("{0}:{1}:{2}", txtStartTime.Hour, txtStartTime.Minute, txtStartTime.Second));
                    objattendanceReason.InTime = in_time;

                    TimeSpan out_time = TimeSpan.Parse(string.Format("{0}:{1}:{2}", txtEndTime.Hour, txtEndTime.Minute, txtEndTime.Second));
                    objattendanceReason.OutTime = out_time;

                    TimeSpan lateAllowed = TimeSpan.Parse(string.Format("{0}:{1}:{2}", txtLateAllowed.Hour, txtLateAllowed.Minute, txtLateAllowed.Second));
                    objattendanceReason.LateAllowed = lateAllowed;

                    objattendanceReason.Edit_User = ((SessionUser)Session["SessionUser"]).UserId;
                    objattendanceReason.Edit_Date = DateTime.Now;
                    objattendanceReason.OCode = ((SessionUser)Session["SessionUser"]).OCode;

                    lstHRM_AttendanceReason.Add(objattendanceReason);
                }

                //if (in_time > out_time)
                //{
                //    lblMessage.Text = "<font color='red'>Out Time can't be less than In Time</font>";
                //    return;
                //}

                if (BtnSave.Text == "Save")
                {
                    int result = objAttendanceReasonBll.InsertAttendanceReason(lstHRM_AttendanceReason);
                    if (result == 1)
                    {
                        //lblMessage.Text = "Record Added successfully!";
                        //lblMessage.ForeColor = System.Drawing.Color.Green;
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Record Added successfully!')", true);
                        reset();
                        BindGridAttendance();
                    }
                    else
                    {
                        //lblMessage.Text = "Record Adding Error!";
                        // lblMessage.ForeColor = System.Drawing.Color.Red;
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Record Adding Error!')", true);
                    }
                }
                else
                {
                    HRM_AttendanceReason objattendanceReason = new HRM_AttendanceReason();

                    //objattendanceReason.RegionId = Convert.ToInt32(lblRegionId.Text);
                    //objattendanceReason.OfficeId = Convert.ToInt32(lblOfficeId.Text);
                    objattendanceReason.ShiftCode = ddlShiftCode.SelectedValue;
                    objattendanceReason.ShiftName = ddlShiftCode.SelectedItem.Text;
                    objattendanceReason.ReasonDate = Convert.ToDateTime(txtfromDate.Text);
                    objattendanceReason.ReasonTypeId = Convert.ToInt32(ddlReasonType.SelectedValue);
                    objattendanceReason.ReasonType = ddlReasonType.SelectedItem.Text;
                    objattendanceReason.Remarks = txtRemarks.Text;

                    //objattendanceReason.InTime = (txtStartTime.Hour + ":" + txtStartTime.Minute + ":" + txtStartTime.Second + " " + txtStartTime.AmPm);
                    //objattendanceReason.OutTime = (txtEndTime.Hour + ":" + txtEndTime.Minute + ":" + txtEndTime.Second + " " + txtEndTime.AmPm);

                    TimeSpan in_time = TimeSpan.Parse(string.Format("{0}:{1}:{2}", txtStartTime.Hour, txtStartTime.Minute, txtStartTime.Second));
                    objattendanceReason.InTime = in_time;

                    TimeSpan out_time = TimeSpan.Parse(string.Format("{0}:{1}:{2}", txtEndTime.Hour, txtEndTime.Minute, txtEndTime.Second));
                    objattendanceReason.OutTime = out_time;

                    TimeSpan lateAllowed = TimeSpan.Parse(string.Format("{0}:{1}:{2}", txtLateAllowed.Hour, txtLateAllowed.Minute, txtLateAllowed.Second));
                    objattendanceReason.LateAllowed = lateAllowed;

                    objattendanceReason.Edit_User = ((SessionUser)Session["SessionUser"]).UserId;
                    objattendanceReason.Edit_Date = DateTime.Now;
                    objattendanceReason.OCode = ((SessionUser)Session["SessionUser"]).OCode;

                    int attReasonId = Convert.ToInt16(hiddenId.Value);
                    int result = objAttendanceReasonBll.UpdateAttReason(objattendanceReason, attReasonId);
                    
                    if (result == 1)
                    {
                        //lblMessage.Text = "Record Updated Successfully";
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Record Updated Successfully')", true);
                        reset();
                        BindGridAttendance();
                    }
                    else
                    {
                        //lblMessage.Text = "Record Updating Error!";
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Record Updating Error!')", true);
                        //lblMessage.ForeColor = System.Drawing.Color.Red;
                    }
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
                List<HRM_AttendanceReason> attendanceReason = objAttendanceReasonBll.GetAllattReason(OCODE).ToList();
                if (attendanceReason.Count > 0)
                {
                    gridviewAttendanceReason.DataSource = attendanceReason;
                    gridviewAttendanceReason.DataBind();
                }
            }
            catch (Exception ex)
            {
                //string EID = Convert.ToString(((SessionUser)Session["SessionUser"]).EID);
                //LogController<AttendanceReason>.SetLog(ex, EID);
                //ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

        //protected void ddlRegions_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        int RegionId = Convert.ToInt32(ddlRegions.SelectedValue);
        //        BindOfficeByRegion(RegionId);
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }

        //}

        //private void BindRegionByShift(string shiftcode)
        //{
        //    var row = timeScheduleBll.GetInfoByShift(shiftcode).ToList();
        //    if (row.Count > 0)
        //    {
        //        ddlRegions.DataSource = row.ToList();
        //        ddlRegions.DataTextField = "REG_NAME";
        //        ddlRegions.DataValueField = "REG_ID";
        //        ddlRegions.DataBind();
        //        ddlRegions.Items.Insert(0, new ListItem("------Select One------", "0"));
        //    }
        //}

        //private void BindOfficeByShift(string shiftcode)
        //{
        //    var row = timeScheduleBll.GetInfoByShift(shiftcode).ToList();
        //    if (row.Count > 0)
        //    {
        //        ddlOffice.DataSource = row.ToList();
        //        ddlOffice.DataTextField = "OFC_NAME";
        //        ddlOffice.DataValueField = "OFC_ID";
        //        ddlOffice.DataBind();
        //        ddlOffice.Items.Insert(0, new ListItem("------Select One------", "0"));
        //    }
        //}

        //protected void ddlShiftCode_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
        //        string shiftCode = Convert.ToString(ddlShiftCode.SelectedItem.Text);

        //        var result = timeScheduleBll.GetScheduleByCode(OCODE, shiftCode).ToList();
        //        if (result.Count > 0)
        //        {
        //            var objShift = result.First();
        //txtShift.Text = objShift.ShiftName;
        //txtRegion.Text = objShift.HRM_Regions.RegionName;
        //txtOffice.Text = objShift.HRM_Office.OfficeName;
        //lblRegionId.Text = objShift.RegionId.ToString();
        //lblOfficeId.Text = objShift.OfficeId.ToString();
        //BindRegionByShift(shiftCode);
        //BindOfficeByShift(shiftCode);
        //TimeSpan in_time= objShift.StartTime;
        //TimeSpan.Parse(string.Format("{0}:{1}:{2}", txtStartTime.Hour, txtStartTime.Minute, txtStartTime.Second)) = objShift.StartTime;
        //        }
        //        else
        //        {
        //            lblMessage.Text = "<font color='red'>No record found!</font>";
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        protected void gridviewAttendanceReason_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridviewAttendanceReason.PageIndex = e.NewPageIndex;
            BindGridAttendance();
        }

        protected void imgbtnEdit_Click(object sender, EventArgs e)
        {
            lblMessage.Text = "";
            List<HRM_AttendanceReason> objAttendanceReason = new List<HRM_AttendanceReason>();
            ImageButton imgbtn = (ImageButton)sender;
            GridViewRow row = (GridViewRow)imgbtn.NamingContainer;

            try
            {
                string AttReasonId = "";
                Label lblId = (Label)gridviewAttendanceReason.Rows[row.RowIndex].FindControl("lblId");
                if (lblId != null)
                {
                    string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                    AttReasonId = lblId.Text;
                    objAttendanceReason = objAttendanceReasonBll.GetAllattReasonByID(AttReasonId, OCODE);

                    if (objAttendanceReason.Count > 0)
                    {
                        foreach (HRM_AttendanceReason attendanceReason in objAttendanceReason)
                        {
                            //lblRegionId.Text = attendanceReason.RegionId.ToString();
                            //lblOfficeId.Text = attendanceReason.OfficeId.ToString();
                            hiddenId.Value = attendanceReason.ReasonId.ToString();
                            //txtRegion.Text = attendanceReason.HRM_Regions.RegionName;
                            //txtOffice.Text = attendanceReason.HRM_Office.OfficeName;
                            //ddlShiftCode.SelectedItem.Text = attendanceReason.ShiftCode;
                            txtfromDate.Text = Convert.ToDateTime(attendanceReason.ReasonDate).ToShortDateString();
                            txtRemarks.Text = attendanceReason.Remarks;
                            //ddlReasonType.SelectedItem.Text = attendanceReason.ReasonType;
                            //txtShift.Text = attendanceReason.ShiftName;
                            ddlReasonType.SelectedValue = Convert.ToInt16(attendanceReason.ReasonTypeId).ToString();
                            ddlShiftCode.SelectedValue = attendanceReason.ShiftCode;
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

        protected void txttoDate_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DateTime fromDate = Convert.ToDateTime(txtfromDate.Text);
                DateTime toDate = Convert.ToDateTime(txttoDate.Text);
                hdfTotalDay.Value = (1 + (toDate - fromDate).TotalDays).ToString();
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

    }
}

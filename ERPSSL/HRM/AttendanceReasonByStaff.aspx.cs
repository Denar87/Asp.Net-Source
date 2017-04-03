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
    public partial class AttendanceReasonByStaff : System.Web.UI.Page
    {
        ERPSSLHBEntities context = new ERPSSLHBEntities();
        Attendance_BLL objAtt_BLL = new Attendance_BLL();
        //EmployeeSetup_BLL objEmp_BLL = new EmployeeSetup_BLL();
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
                    GetReasonList();
                    BindGridAttendance();
                    //GetRegionList();
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
                    ddlReasonType.Items.Insert(0, new ListItem("------Select One------", "0"));
                }
            }
            catch (Exception)
            {

                throw;
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
        //    else
        //    {
        //        ddlOffice.DataSource = null;
        //        ddlOffice.DataTextField = "OfficeName";
        //        ddlOffice.DataValueField = "OfficeID";
        //        ddlOffice.DataBind();
        //        ddlOffice.Items.Insert(0, new ListItem("------Select One------", "0"));
        //    }
        //}

        //protected void ddlRegions_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //        try
        //        {
        //            int ResionId = Convert.ToInt32(ddlRegions.SelectedValue);
        //            BindOfficeByRegion(ResionId);
        //        }
        //        catch (Exception)
        //        {
        //            throw;
        //        }
        //}

        protected void txtEid_AT_TextChanged(object sender, EventArgs e)
        {
            try
            {
                lblMessage.Text = "";
                string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                string employeeID = Convert.ToString(txtEid_AT.Text);

                var result = objAttendanceReasonBll.GetEmployeeDetailsID(employeeID, OCODE).ToList();
                if (result.Count > 0)
                {
                    Emp_IMG_AT.Visible = true;
                    Emp_IMG_AT.ImageUrl = "EmployeeIMG.ashx?eId=" + employeeID + "&oCode=" + OCODE;

                    var objNewEmp = result.First();
                    lblHiddenId.Text = Convert.ToString(objNewEmp.EMP_ID);
                    lblBioId.Text = objNewEmp.BIO_ID;
                    txtEid_AT.Text = objNewEmp.EID;
                    txtEmpName_AT.Text = Convert.ToString(objNewEmp.EMP_FIRSTNAME + " " + objNewEmp.EMP_LASTNAME);
                    txtDepartment_AT.Text = objNewEmp.DPT_NAME;
                    txtDesignation_AT.Text = objNewEmp.DEG_NAME;
                    txtRegion.Text = objNewEmp.REG_NAME;
                    lblRegionId.Text = Convert.ToString(objNewEmp.REG_ID);
                    lblOfficeId.Text = Convert.ToString(objNewEmp.OFC_ID);
                    lblDeparmentId.Text = Convert.ToString(objNewEmp.DPT_ID);
                    txtOffice.Text = objNewEmp.OFC_NAME;
                    txtShiftCode.Text = objNewEmp.SHIFTCODE;
                    txtShift.Text = objNewEmp.SHIFT;
                }
                else
                {
                    txtDepartment_AT.Text = "";
                    txtDesignation_AT.Text = "";
                    txtEmpName_AT.Text = "";
                    Emp_IMG_AT.Visible = false;
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('This Employee is Inactive!')", true);
                    //lblMessage.Text = "<font color='red'>NO RECORDS FOUND!</font>";
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }


        void BindGridAttendance()
        {
            try
            {
                string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                List<HRM_AttendanceReason_Individual> attendanceReasonIndividual = objAttendanceReasonBll.GetAllattReasonIndividual(OCODE).ToList();
                if (attendanceReasonIndividual.Count > 0)
                {
                    gridviewAttendanceReasonStaff.DataSource = attendanceReasonIndividual;
                    gridviewAttendanceReasonStaff.DataBind();
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        protected void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string at_status = "";

                HRM_AttendanceReason_Individual objattendanceReasonIndividual = new HRM_AttendanceReason_Individual();

                objattendanceReasonIndividual.EmpId = Convert.ToInt64(lblHiddenId.Text);
                objattendanceReasonIndividual.EID = txtEid_AT.Text;
                objattendanceReasonIndividual.Bio_MatrixId = lblBioId.Text;
                objattendanceReasonIndividual.RegionId = Convert.ToInt32(lblRegionId.Text);
                objattendanceReasonIndividual.OfficeId = Convert.ToInt32(lblOfficeId.Text);
                objattendanceReasonIndividual.DepartmentId = Convert.ToInt32(lblDeparmentId.Text);
                objattendanceReasonIndividual.ShiftCode = txtShiftCode.Text;
                objattendanceReasonIndividual.ShiftName = txtShift.Text;
                objattendanceReasonIndividual.ReasonDate = Convert.ToDateTime(txtDate.Text);
                objattendanceReasonIndividual.ReasonTypeId = Convert.ToInt32(ddlReasonType.SelectedValue);
                objattendanceReasonIndividual.ReasonType = ddlReasonType.SelectedItem.Text;
                objattendanceReasonIndividual.Remarks = "General : " + txtRemarks.Text;

                //objattendanceReasonIndividual.InTime = (txtStartTime.Hour + ":" + txtStartTime.Minute + ":" + txtStartTime.Second + " " + txtStartTime.AmPm);
                //objattendanceReasonIndividual.OutTime = (txtEndTime.Hour + ":" + txtEndTime.Minute + ":" + txtEndTime.Second + " " + txtEndTime.AmPm);

                TimeSpan in_time = TimeSpan.Parse(string.Format("{0}:{1}:{2}", txtStartTime.Hour, txtStartTime.Minute, txtStartTime.Second));
                objattendanceReasonIndividual.InTime = in_time;

                TimeSpan out_time = TimeSpan.Parse(string.Format("{0}:{1}:{2}", txtEndTime.Hour, txtEndTime.Minute, txtEndTime.Second));
                objattendanceReasonIndividual.OutTime = out_time;

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
                objattendanceReasonIndividual.Status = at_status;

                objattendanceReasonIndividual.Edit_User = ((SessionUser)Session["SessionUser"]).UserId;
                objattendanceReasonIndividual.Edit_Date = DateTime.Now;
                objattendanceReasonIndividual.OCode = ((SessionUser)Session["SessionUser"]).OCode;

                //if (in_time > out_time)
                //{
                //    lblMessage.Text = "<font color='red'>Out Time can't be less than In Time</font>";
                //    return;
                //}

                if (BtnSave.Text == "Save")
                {
                    int result = objAttendanceReasonBll.InsertAttendanceReasonIndividual(objattendanceReasonIndividual);
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
                        //lblMessage.Text = "Record Adding Failure!";
                        //lblMessage.ForeColor = System.Drawing.Color.Red;
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Record Adding Failure!')", true);
                    }
                }
                else
                {
                    int attReasonIndId = Convert.ToInt16(hiddenId.Value);
                    int result = objAttendanceReasonBll.UpdateAttReasonIndividual(objattendanceReasonIndividual, attReasonIndId);

                    //HRM_ATTENDANCE aHRM_ATTENDANCE = objAtt_BLL.GetAllAttendanceData(Convert.ToDateTime(txtDate.Text), txtEid_AT.Text);


                    if (result == 1)
                    {
                        //lblMessage.Text = "Record Updated Successfully";
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Record Updated Successfully')", true);
                        reset();
                        BindGridAttendance();
                    }
                    else
                    {
                        // lblMessage.Text = "Record Updating Failure!";
                        //lblMessage.ForeColor = System.Drawing.Color.Red;
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Record Updating Failure!')", true);
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
            txtEid_AT.Text = "";
            txtEmpName_AT.Text = "";
            txtDepartment_AT.Text = "";
            txtDesignation_AT.Text = "";
            Emp_IMG_AT.ImageUrl = "resources/no_image.png";
            txtRemarks.Text = "";
            txtRegion.Text = "";
            txtOffice.Text = "";
            txtShift.Text = "";
            txtShiftCode.Text = "";
            rdbPresent.Checked = true;
            BtnSave.Text = "Submit";
        }

        protected void gridviewAttendanceReasonStaff_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridviewAttendanceReasonStaff.PageIndex = e.NewPageIndex;
            BindGridAttendance();
        }

        //protected void txtShiftCode_TextChanged(object sender, EventArgs e)
        //{
        //try
        //{
        //    string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
        //    string shiftCode = Convert.ToString(txtShiftCode.Text);

        //    var result = timeScheduleBll.GetScheduleByCode(OCODE, shiftCode).ToList();
        //    if (result.Count > 0)
        //    {
        //        var objShift = result.First();
        //        txtShift.Text = objShift.ShiftName;
        //        //TimeSpan in_time= objShift.StartTime;
        //        //TimeSpan.Parse(string.Format("{0}:{1}:{2}", txtStartTime.Hour, txtStartTime.Minute, txtStartTime.Second)) = objShift.StartTime;
        //    }
        //    else
        //    {
        //        //NO RECORDS FOUND.
        //    }
        //}
        //catch (Exception ex)
        //{
        //    throw ex;
        //}
        //}

        protected void imgbtnEdit_Click(object sender, EventArgs e)
        {
            lblMessage.Text = "";
            List<HRM_AttendanceReason_Individual> objAttendanceReasonInd = new List<HRM_AttendanceReason_Individual>();
            ImageButton imgbtn = (ImageButton)sender;
            GridViewRow row = (GridViewRow)imgbtn.NamingContainer;

            try
            {
                string AttReasonIndId = "";
                Label lblId = (Label)gridviewAttendanceReasonStaff.Rows[row.RowIndex].FindControl("lblId");
                if (lblId != null)
                {
                    string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                    AttReasonIndId = lblId.Text;
                    objAttendanceReasonInd = objAttendanceReasonBll.GetAllattReasonIndividualById(AttReasonIndId, OCODE);

                    if (objAttendanceReasonInd.Count > 0)
                    {
                        foreach (HRM_AttendanceReason_Individual attendanceReasonInd in objAttendanceReasonInd)
                        {
                            txtEid_AT.Text = attendanceReasonInd.EID;
                            //  txtEmpName_AT.Text = Convert.ToString(attendanceReasonInd.HRM_PersonalInformations.FirstName + " " + attendanceReasonInd.HRM_PersonalInformations.LastName);

                            // lblBioId.Text = attendanceReasonInd.HRM_PersonalInformations.BIO_MATRIX_ID;
                            lblHiddenId.Text = Convert.ToString(attendanceReasonInd.EmpId);
                            hiddenId.Value = attendanceReasonInd.Ind_ReasonId.ToString();
                            lblRegionId.Text = attendanceReasonInd.RegionId.ToString();
                            lblOfficeId.Text = attendanceReasonInd.OfficeId.ToString();
                            lblDeparmentId.Text = attendanceReasonInd.DepartmentId.ToString();
                            txtRegion.Text = attendanceReasonInd.HRM_Regions.RegionName;
                            txtOffice.Text = attendanceReasonInd.HRM_Office.OfficeName;
                            txtDepartment_AT.Text = attendanceReasonInd.HRM_DEPARTMENTS.DPT_NAME;
                            txtDate.Text = Convert.ToDateTime(attendanceReasonInd.ReasonDate).ToShortDateString();
                            txtRemarks.Text = attendanceReasonInd.Remarks;
                            ddlReasonType.SelectedValue = Convert.ToInt16(attendanceReasonInd.ReasonTypeId).ToString();
                            txtShift.Text = attendanceReasonInd.ShiftName;
                            txtShiftCode.Text = attendanceReasonInd.ShiftCode;
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
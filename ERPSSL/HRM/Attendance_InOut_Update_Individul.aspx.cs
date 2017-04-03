using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ERPSSL.HRM.BLL;
using ERPSSL.HRM.DAL.Repository;
using ERPSSL.HRM;
using ERPSSL.HRM.DAL;

namespace ERPSSL.HRM
{
    public partial class Attendance_InOut_Update_Individul : System.Web.UI.Page
    {
        EmployeeSetup_BLL objEmp_BLL = new EmployeeSetup_BLL();
        DEPARTMENT_BLL DepartmentBll = new DEPARTMENT_BLL();
        EmployeeSetup_BLL employeeBll = new EmployeeSetup_BLL();
        Office_BLL objOfficeBLL = new Office_BLL();
        EMPOYEE_BLL employeeBllObj = new EMPOYEE_BLL();
        SECTION_BLL SectionBll = new SECTION_BLL();
        SUB_SECTION_BLL subSectionBll = new SUB_SECTION_BLL();
        SUB_SECTION_DAL subSectionDal = new SUB_SECTION_DAL();
        Attendance_RPT_Bll aAttendance_RPT_Bll = new Attendance_RPT_Bll();
        TIME_SCHEDULE_BLL timeScheduleBll = new TIME_SCHEDULE_BLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GerRegion1List();
            }
        }

        private void GerRegion1List()
        {
            //try
            //{
            //    string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
            //    var row = objOfficeBLL.GetAllResion(OCODE).ToList();
            //    if (row.Count > 0)
            //    {
            //        ddlRegion1.DataSource = row.ToList();
            //        ddlRegion1.DataTextField = "RegionName";
            //        ddlRegion1.DataValueField = "RegionID";
            //        ddlRegion1.DataBind();
            //        ddlRegion1.Items.Insert(0, new ListItem("--Select--"));
            //    }
            //}
            //catch (Exception ex)
            //{
            //    string EID = Convert.ToString(((SessionUser)Session["SessionUser"]).EID);
            //    LogController<Attendance_InOut_Update>.SetLog(ex, EID);
            //    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            //}
        }




        protected void txtbxEID_TextChangeEvent(object sender, EventArgs e)
        {
            try
            {
                string eid = txtbxEID.Text.Trim();
                HRM_PersonalInformations _personalInfo = employeeBll.GetPersonalInfoByEID(eid);

                if (_personalInfo.EID == eid)
                {
                    txtbxName.Text = _personalInfo.FirstName + " " + _personalInfo.LastName;
                    txtbxDesgination.Text = employeeBll.GetDesginationName(_personalInfo.DesginationId);
                    txtbxDepartment.Text = employeeBll.GetDepartmentName(_personalInfo.DepartmentId);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No Employee Found!')", true);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }




        protected void headerLevelCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                CheckBox headerChkBox = ((CheckBox)grdview.HeaderRow.FindControl("headerLevelCheckBox"));

                if (headerChkBox.Checked == true)
                {
                    foreach (GridViewRow gvRow in grdview.Rows)
                    {
                        CheckBox rowChkBox = ((CheckBox)gvRow.FindControl("rowLevelCheckBox"));
                        rowChkBox.Checked = true;//((CheckBox)sender).Checked;//for all row checkbox       
                    }
                }
                else
                {
                    foreach (GridViewRow gvRow in grdview.Rows)
                    {
                        CheckBox rowChkBox = ((CheckBox)gvRow.FindControl("rowLevelCheckBox"));
                        rowChkBox.Checked = false;
                    }
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

        protected void btnProcess_Click(object sender, EventArgs e)
        {
            try
            {
                TimeSpan time = TimeSpan.Parse("00:00:00");

                Attendance_BLL _attendancebll = new Attendance_BLL();
                string eid = txtbxEID.Text.Trim();
                DateTime fromDate = Convert.ToDateTime(txtDate.Text);
                DateTime toDate = Convert.ToDateTime(txtToDate.Text);
                List<HRM_EMPLOYEES_VIEWER> employess = _attendancebll.GetEmployeesByEidForAttendance(eid, fromDate, toDate);

                if (employess.Count > 0)
                {
                    List<HRM_EMPLOYEES_VIEWER> newemployess = new List<HRM_EMPLOYEES_VIEWER>();

                    foreach (HRM_EMPLOYEES_VIEWER aitem in employess)
                    {
                        HRM_EMPLOYEES_VIEWER aemployee = new HRM_EMPLOYEES_VIEWER();
                        aemployee.EID = aitem.EID;
                        aemployee.EMP_ID = aitem.EMP_ID;
                        aemployee.EmployeeFullName = aitem.FirstName + " " + aitem.LastName;
                        aemployee.DEG_NAME = aitem.DEG_NAME;
                        aemployee.AttendanceDate = aitem.AttendanceDate;

                        //aemployee.In_Time = aitem.In_Time;
                        //aemployee.Out_Time = aitem.Out_Time;



                        if (aitem.In_Time != null)
                        {
                            aemployee.In_Time = aitem.In_Time;
                        }
                        else
                        {
                            aemployee.In_Time = null;
                        }

                        if (aitem.Out_Time != null)
                        {
                            aemployee.Out_Time = aitem.Out_Time;
                        }
                        else
                        {
                            aemployee.Out_Time = null;
                        }

                        aemployee.Status = aitem.Status;                     
                        newemployess.Add(aemployee);
                    }
                    List<HRM_EMPLOYEES_VIEWER> assendingnewemployess = newemployess.OrderBy(x => x.EMP_ID).ToList();

                    if (assendingnewemployess.Count > 0)
                    {
                        //TextBox txtbxInTime = ((TextBox)grdview.FindControl("txtbxIntime"));
                        //TextBox txtbxOutTIme = ((TextBox)grdview.FindControl("txtbxOuttime"));

                        //if (txtbxInTime.Text == "00:00:00")
                        //{

                        //    txtbxInTime.ForeColor = System.Drawing.Color.Red;
                        //    txtbxInTime.BackColor = System.Drawing.Color.Wheat;
                        //}

                        grdview.DataSource = assendingnewemployess;
                        grdview.DataBind();

                    }

                }

                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No Attendance Data Found!')", true);
                }

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

        protected void btn_Confirm_Clcik(object sender, EventArgs e)
        {
            try
            {
                Attendance_BLL _attendancebll = new Attendance_BLL();
                List<HRM_ATTENDANCE> lstHRM_ATTENDANCE = new List<HRM_ATTENDANCE>();

                foreach (GridViewRow gvRow in grdview.Rows)
                {
                    CheckBox rowChkBox = ((CheckBox)gvRow.FindControl("rowLevelCheckBox"));

                    HRM_ATTENDANCE _attendance = new HRM_ATTENDANCE();

                    if (rowChkBox.Checked == true)
                    {
                        Label lblEID = ((Label)gvRow.FindControl("lblEID"));
                        Label lblWorkingDay = ((Label)gvRow.FindControl("lblWorkingDay"));
                        Label lblAttendanceDate = ((Label)gvRow.FindControl("lblAttendanceDate"));
                        TextBox txtbxInTime = ((TextBox)gvRow.FindControl("txtbxIntime"));
                        TextBox txtbxOutTIme = ((TextBox)gvRow.FindControl("txtbxOuttime"));

                        _attendance.EID = lblEID.Text;
                        _attendance.Attendance_Date = Convert.ToDateTime(lblAttendanceDate.Text);
                        _attendance.In_Time = TimeSpan.Parse(txtbxInTime.Text);
                        _attendance.Out_Time = TimeSpan.Parse(txtbxOutTIme.Text);
                        _attendance.Remarks = txtbxremark.Text;
                        _attendance.Attendance_Process_Status = true;
                        _attendance.OCode = ((SessionUser)Session["SessionUser"]).OCode;
                        _attendance.Edit_Date = DateTime.Now;
                        _attendance.Edit_User = ((SessionUser)Session["SessionUser"]).UserId;

                        lstHRM_ATTENDANCE.Add(_attendance);
                    }
                }

                if (lstHRM_ATTENDANCE.Count > 0)
                {
                    var result = _attendancebll.Update_IndividualAttendance(lstHRM_ATTENDANCE);
                    if (result != null)
                    {
                        ClearUI();
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Data Updated Successfully')", true);
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No Employee selected in the list!')", true);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

        private void ClearUI()
        {           
            txtbxremark.Text = "";
            txtDate.Text = "";
            txtToDate.Text = "";
            grdview.DataSource = null;
            grdview.DataBind();
        }

        

    }
}

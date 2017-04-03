﻿using ERPSSL.HRM.DAL;
using ERPSSL.HRM.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ERPSSL.HRM.BLL;

namespace ERPSSL.HRM
{
    public partial class AttendanceAccessProcess : System.Web.UI.Page
    {
        private ERPSSLHBEntities _context = new ERPSSLHBEntities();
        Attendance_BLL objAtt_BLL = new Attendance_BLL();
        TIME_SCHEDULE_BLL timeScheduleBll = new TIME_SCHEDULE_BLL();
        Attendance_RPT_Bll aAttendance_RPT_Bll = new Attendance_RPT_Bll();

        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Session["UserID"] != null) && (Session["OCode"] != null))
            {
                if (!IsPostBack)
                {
                    GetShiftCodeList();
                    //txtbxFromDate.Text = DateTime.Today.ToShortDateString();
                    //txtbxToDate.Text = DateTime.Today.ToShortDateString();

                    //txtDateFrom.Text = DateTime.Today.ToShortDateString();
                    //txtDateTo.Text = DateTime.Today.ToShortDateString();

                    //txtOTFrom.Text = DateTime.Today.ToShortDateString();
                    //txtOTTo.Text = DateTime.Today.ToShortDateString();
                }
            }
            else
            {
                Response.Redirect("..\\AppGateway\\Login.aspx");
            }

            // //***************************************Cresent********************************************
            // string sourceDir = @"\\192.168.1.8\Access Manager\DB";
            //// string sourceDir = @"\\192.168.1.8\db";
            // string backupDir = @"D:\AttendanceBackup";

            // string fName = "NITGENDBAC.mdb";

            // // Use the Path.Combine method to safely append the file name to the path. 
            // // Will overwrite if the destination file already exists.
            // File.Copy(Path.Combine(sourceDir, fName), Path.Combine(backupDir, fName), true);
            // //*************************************Cresent*************************************************************
        }


        //protected void Button1_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        string sourceDir = @"\\192.168.0.175\cre\DB";               
        //        string backupDir = @"\\192.168.0.175\newAttendance";
        //        string fName = "NITGENDBAC.mdb";               
        //        File.Copy(Path.Combine(sourceDir, fName), Path.Combine(backupDir, fName), true);
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}


        protected void btnAttendanceProcess_Click(object sender, EventArgs e)
        {
            ////For Cresent
            //try
            //{
            //    string ExCurrentDate = txtbxToDate.Text.Trim();
            //    string ExYesterDate = txtbxFromDate.Text.Trim();

            //    DateTime todate = Convert.ToDateTime(txtbxToDate.Text.Trim());
            //    DateTime fromdate = Convert.ToDateTime(txtbxFromDate.Text.Trim());

            //    var dtodate = todate.ToString("dd/MM/yyyy");
            //    var dfromdat = todate.ToString("dd/MM/yyyy");


            //    List<Employee> employess = new List<Employee>();

            //    DataSet ds = new DataSet();
            //    OleDbConnection con;
            //    OleDbCommand cmd;

            //    //string strquery = "SELECT * FROM NGAC_LOG where userid <>'' and [logtime] Between  #" + dfromdat + "# and  #" + dtodate + "#";
            //    string strquery = "SELECT logtime,userid  FROM NGAC_LOG WHERE userid <>'' AND Format(logtime, 'mm/dd/yyyy') BETWEEN  Format(#" + fromdate + "#, 'mm/dd/yyyy')  AND Format(#" + todate + "#, 'mm/dd/yyyy')";

            //    // using (con = new OleDbConnection(@"PROVIDER=Microsoft.ACE.OLEDB.12.0;" + @"DATA SOURCE=F:\Data123\Attendance.accdb"))
            //    // Microsoft.Jet.OLEDB.4.0;
            //    //For Subra Test Data
            //     //using (con = new OleDbConnection(@"PROVIDER= Microsoft.Jet.OLEDB.4.0;" + @"DATA SOURCE=E:\cre\DB\NITGENDBAC.mdb; Jet OLEDB:Database Password=nac3000;"))
            //    using (con = new OleDbConnection(@"PROVIDER= Microsoft.Jet.OLEDB.4.0;" + @"DATA SOURCE=D:\AttendanceBackup\NITGENDBAC.mdb; Jet OLEDB:Database Password=nac3000;"))
            //    {

            //        using (cmd = new OleDbCommand(strquery, con))
            //        {
            //            OleDbDataAdapter Da = new OleDbDataAdapter(cmd);
            //            var itmes = Da.Fill(ds);
            //        }
            //    }

            //    foreach (DataRow aitem in ds.Tables[0].Rows)
            //    {
            //        Employee _employee = new Employee();

            //        _employee.E_Time = aitem["logtime"].ToString();
            //        _employee.EID = aitem["userid"].ToString();
            //        employess.Add(_employee);
            //    }

            //    var employes = employess;

            //    List<HRM_AttendanceTemp> attendancees = new List<HRM_AttendanceTemp>();

            //    foreach (var aitem in employes)
            //    {
            //        HRM_AttendanceTemp _attendace = new HRM_AttendanceTemp();
            //        _attendace.EID = aitem.EID;
            //        DateTime localTime = Convert.ToDateTime(aitem.E_Time);
            //        string timeString24Hour = localTime.ToString("HH:mm:ss", CultureInfo.CurrentCulture);
            //        _attendace.IOTIME = TimeSpan.Parse(timeString24Hour);
            //        string[] date = aitem.E_Time.Split(' ');
            //        _attendace.AttendanceDate = Convert.ToDateTime(date[0]);

            //        attendancees.Add(_attendace);
            //    }

            //    foreach (HRM_AttendanceTemp aitem in attendancees)
            //    {
            //        _context.HRM_AttendanceTemp.AddObject(aitem);
            //        _context.SaveChanges();
            //    }
            //    _context.SaveChanges();
            //    //lblMessage.Text = "Data Process Successfully!";
            //    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Data Process Successfully')", true);

            //}
            //catch (Exception)
            //{
            //    throw;
            //}


            // For Azim
            try
            {
                string ExCurrentDate = txtbxFromDate.Text.Trim();
                string ExYesterDate = txtbxFromDate.Text.Trim();
     
                DateTime fromdate = Convert.ToDateTime(txtbxFromDate.Text.Trim());
                DateTime todate = Convert.ToDateTime(txtbxFromDate.Text.Trim());
                
                var dfromdat = todate.ToString("dd/MM/yyyy");
                var dtodate = todate.ToString("dd/MM/yyyy");

                string sqlquery1 = "HRM_Truncate_AttendanceTemp";
                _context.ExecuteStoreCommand(sqlquery1);

                List<Employee> employess = new List<Employee>();

                DataSet ds = new DataSet();
                OleDbConnection con;
                OleDbCommand cmd;
                //string strquery1 = "TRUNCATE Table  dbo.HRM_AttendanceTemp";
                //string strquery = "SELECT * FROM NGAC_LOG where userid <>'' and [logtime] Between  #" + dfromdat + "# and  #" + dtodate + "#";
                string strquery = "SELECT eventDate,eventTime,eventCard  FROM PubEvent WHERE eventCard <>'' AND Format(eventDate, 'mm/dd/yyyy') BETWEEN  Format(#" + fromdate + "#, 'mm/dd/yyyy')  AND Format(#" + todate + "#, 'mm/dd/yyyy')";

                // using (con = new OleDbConnection(@"PROVIDER=Microsoft.ACE.OLEDB.12.0;" + @"DATA SOURCE=F:\Data123\Attendance.accdb"))
                // Microsoft.Jet.OLEDB.4.0;
                // using (con = new OleDbConnection(@"PROVIDER= Microsoft.Jet.OLEDB.4.0;" + @"DATA SOURCE=F:\attendance\NITGENDBAC.mdb; Jet OLEDB:Database Password=nac3000;"))

                //using (con = new OleDbConnection(@"PROVIDER= Microsoft.Jet.OLEDB.4.0;" + @"DATA SOURCE=G:\Subra Systems\AttendanceBackup\HAMS_2016.mdb"))

                using (con = new OleDbConnection(@"PROVIDER= Microsoft.Jet.OLEDB.4.0;" + @"DATA SOURCE=D:\HTMS-86\HAMS_2017.mdb"))
                {
                    using (cmd = new OleDbCommand(strquery, con))
                    {
                        OleDbDataAdapter Da = new OleDbDataAdapter(cmd);
                        var itmes = Da.Fill(ds);
                    }
                }

                foreach (DataRow aitem in ds.Tables[0].Rows)
                {
                    Employee _employee = new Employee();

                    _employee.E_Time = aitem["eventTime"].ToString();
                    _employee.EID = aitem["eventCard"].ToString();
                    _employee.E_date = aitem["eventDate"].ToString();
                    employess.Add(_employee);
                }

                var employes = employess;

                List<HRM_AttendanceTemp> attendancees = new List<HRM_AttendanceTemp>();

                foreach (var aitem in employes)
                {
                    HRM_AttendanceTemp _attendace = new HRM_AttendanceTemp();
                    _attendace.EID = aitem.EID;
                    DateTime localTime = Convert.ToDateTime(aitem.E_Time);
                    string timeString24Hour = localTime.ToString("HH:mm:ss", CultureInfo.CurrentCulture);
                    _attendace.IOTIME = TimeSpan.Parse(timeString24Hour);
                    //  string[] date = aitem.E_Time.Split(' ');
                    _attendace.AttendanceDate = Convert.ToDateTime(aitem.E_date);

                    attendancees.Add(_attendace);
                }

                HRM_AttendanceTemp _attendace1 = null;

                foreach (HRM_AttendanceTemp aitem in attendancees)
                {
                    _attendace1 = new HRM_AttendanceTemp();
                    _attendace1 = aitem;
                    _context.HRM_AttendanceTemp.AddObject(_attendace1);
                }
                _context.SaveChanges();

                //lblMessage.Text = "Data Process Successfully!";
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Data Proccessed Temporarily')", true);



                //var ParamempID01 = new SqlParameter("@Date_From", fromdate);
                //var ParamempID02 = new SqlParameter("@Date_To", todate);
                //string attTemp = "HRM_SaveAttendanceDataFromAttendanceTemp @Date_From,@Date_To";
                //_context.ExecuteStoreCommand(attTemp, ParamempID01, ParamempID02);

                //var ParamempID1 = new SqlParameter("@Date_From", fromdate);
                //var ParamempID2 = new SqlParameter("@Date_To", todate);
                //string SP_SQL1 = "HRM_UpdateAttendanceDataFromAttendanceTemp @Date_From,@Date_To";
                //_context.ExecuteStoreCommand(SP_SQL1, ParamempID1, ParamempID2);

                //string SP_SQL2 = "Delete_AttendencebyHRM_AttendancePunishmenttable";
                //_context.ExecuteStoreCommand(SP_SQL2);

                //// lblMessage.Text = "Data Confirm Process Successfully!";
                //ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Data Proccessed Successfully')", true);
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

        protected void btnCOnf_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime fromdate = Convert.ToDateTime(txtbxFromDate.Text.Trim());
                DateTime todate = Convert.ToDateTime(txtbxFromDate.Text.Trim());

                var ParamempID01 = new SqlParameter("@Date_From", fromdate);
                var ParamempID02 = new SqlParameter("@Date_To", todate);
                string attTemp = "HRM_SaveAttendanceDataFromAttendanceTemp @Date_From,@Date_To";
                _context.ExecuteStoreCommand(attTemp, ParamempID01, ParamempID02);

                var ParamempID1 = new SqlParameter("@Date_From", fromdate);
                var ParamempID2 = new SqlParameter("@Date_To", todate);
                string SP_SQL1 = "HRM_UpdateAttendanceDataFromAttendanceTemp @Date_From,@Date_To";
                _context.ExecuteStoreCommand(SP_SQL1, ParamempID1, ParamempID2);

                string SP_SQL2 = "Delete_AttendencebyHRM_AttendancePunishmenttable";
                _context.ExecuteStoreCommand(SP_SQL2);

                // lblMessage.Text = "Data Confirm Process Successfully!";
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Data Proccessed Successfully')", true);
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
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
                    ddlShiftCode.Items.Insert(0, new ListItem("All", "0"));
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

        // attendnace status process all/shiftwise

        protected void btnUpdateStatus_Click(object sender, EventArgs e)
        {
            try
            {
                //if (Convert.ToDateTime(txtDateFrom.Text) > DateTime.Now || Convert.ToDateTime(txtDateTo.Text) > DateTime.Now)
                //{
                //    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Date cant be greater than current date!')", true);
                //    return;
                //}

                string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                DateTime EDIT_DATE = DateTime.Now;
                Guid userId = ((SessionUser)Session["SessionUser"]).UserId;

                if (ddlShiftCode.SelectedItem.Text == "All")
                {
                    var result = aAttendance_RPT_Bll.UpdateAll_AttStatus_ByDate(Convert.ToDateTime(txtDateFrom.Text), Convert.ToDateTime(txtDateFrom.Text));

                    aAttendance_RPT_Bll.Insert_AllAbsentLeaveStatus_ByDate(Convert.ToDateTime(txtDateFrom.Text), Convert.ToDateTime(txtDateFrom.Text), OCODE, EDIT_DATE, userId);
                    if (result == 1)
                    {
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Employee Attendance Status Proccessed Successfully')", true);
                        //txtDateFrom.Text = DateTime.Today.ToShortDateString();
                        //txtDateTo.Text = DateTime.Today.ToShortDateString();
                        ddlShiftCode.ClearSelection();
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Status Proccessing Failure!')", true);
                    }
                }

                else
                {
                    var result = objAtt_BLL.UpdateAttStatus_ByShift(Convert.ToDateTime(txtDateFrom.Text), Convert.ToDateTime(txtDateFrom.Text), ddlShiftCode.Text);
                    objAtt_BLL.Insert_AbsentLeaveStatus_ByShift(Convert.ToDateTime(txtDateFrom.Text), Convert.ToDateTime(txtDateFrom.Text), ddlShiftCode.Text, OCODE, EDIT_DATE, userId);
                    if (result == 1)
                    {
                        //lblMessage.Text = "Employee Attendance Status Updated successfully!";
                        //lblMessage.ForeColor = System.Drawing.Color.Green;
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Employee Attendance Status Proccessed Successfully')", true);
                        //BindGridEmployeeAttendance();
                    }
                    else
                    {
                        //lblMessage.Text = "Status Update Failure!";
                        //lblMessage.ForeColor = System.Drawing.Color.Red;
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Status Proccessing Failure!')", true);
                    }
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

        ///OT Proccess
        ///

        protected void btnOTProccess_Click(object sender, EventArgs e)
        {
            try
            {
                string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                List<string> ShiftCodes = objAtt_BLL.GetAllShiftCode(OCODE).ToList();
                foreach (string ashiftcode in ShiftCodes)
                {
                    var result = objAtt_BLL.UpdateOT_ByDateandShift(Convert.ToDateTime(txtOTFrom.Text), Convert.ToDateTime(txtOTTo.Text), ashiftcode);
                    if (result == 1)
                    {
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('OT Proccessed Successfully')", true);
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('OT Proccessing Failure!')", true);
                    }
                }

                //ot process log
                DateTime fromdate = Convert.ToDateTime(txtOTFrom.Text.Trim());
                DateTime todate = Convert.ToDateTime(txtOTTo.Text.Trim());
                Guid USERID = ((SessionUser)Session["SessionUser"]).UserId;

                var ParamempID1 = new SqlParameter("@Date_From", fromdate);
                var ParamempID2 = new SqlParameter("@Date_To", todate);
                var ParamempID3 = new SqlParameter("@Edit_User", USERID);
                var ParamempID4 = new SqlParameter("@Edit_Date", DateTime.Now);
                var ParamempID5 = new SqlParameter("@OCODE", OCODE);
                string SP_SQL = "HRM_Insert_OTProcessLog @Date_From, @Date_To, @Edit_User, @Edit_Date, @OCODE";
                _context.ExecuteStoreCommand(SP_SQL, ParamempID1, ParamempID2, ParamempID3, ParamempID4, ParamempID5);
                //

                //txtOTFrom.Text = "";
                //txtOTTo.Text = "";
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

        protected void txtOTFrom_TextChanged(object sender, EventArgs e)
        {   
            txtOTTo.Text = txtOTFrom.Text;
        }
    }
}
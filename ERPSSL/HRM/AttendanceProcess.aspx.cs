using ERPSSL.HRM.DAL;
using ERPSSL.HRM.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ERPSSL.HRM.BLL;

namespace ERPSSL.HRM
{
    public partial class AttendanceProcess : System.Web.UI.Page
    {
        private ERPSSLHBEntities _context = new ERPSSLHBEntities();
        Attendance_BLL objAtt_BLL = new Attendance_BLL();
        TIME_SCHEDULE_BLL timeScheduleBll = new TIME_SCHEDULE_BLL();
        Attendance_RPT_Bll aAttendance_RPT_Bll = new Attendance_RPT_Bll();

        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Session["UserID"] != null) && (Session["OCode"] != null))
            {

                // //***************************************Cresent********************************************
                // string sourceDir = @"\\192.168.1.8\Access Manager\DB";
                //// string sourceDir = @"\\192.168.1.8\db";
                // string backupDir = @"D:\AttendanceBackup";

                // string fName = "NITGENDBAC.mdb";

                // // Use the Path.Combine method to safely append the file name to the path. 
                // // Will overwrite if the destination file already exists.
                // File.Copy(Path.Combine(sourceDir, fName), Path.Combine(backupDir, fName), true);
                // //*************************************Cresent*************************************************************
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
            try
            {
                //string ExCurrentDate = txtbxToDate.Text.Trim();
                // string ExYesterDate = txtbxFromDate.Text.Trim();

                DateTime todate = Convert.ToDateTime(txtbxToDate.Text.Trim());
                DateTime TO = todate.AddDays(1);
                DateTime fromdate = Convert.ToDateTime(txtbxFromDate.Text.Trim());

                ////var dtodate = todate.ToString("dd/MM/yyyy");
                ////var dfromdat = todate.ToString("dd/MM/yyyy");


                //List<Employee> employess = new List<Employee>();

                //DataSet ds = new DataSet();
                //OleDbConnection con;
                //OleDbCommand cmd;

                ////string strquery = "SELECT * FROM NGAC_LOG where userid <>'' and [logtime] Between  #" + dfromdat + "# and  #" + dtodate + "#";
                //string strquery = "SELECT logtime,userid  FROM NGAC_LOG WHERE userid <>'' AND Format(logtime, 'mm/dd/yyyy') BETWEEN  Format(#" + fromdate + "#, 'mm/dd/yyyy')  AND Format(#" + todate + "#, 'mm/dd/yyyy')";

                //// using (con = new OleDbConnection(@"PROVIDER=Microsoft.ACE.OLEDB.12.0;" + @"DATA SOURCE=F:\Data123\Attendance.accdb"))
                //// Microsoft.Jet.OLEDB.4.0;
                //// using (con = new OleDbConnection(@"PROVIDER= Microsoft.Jet.OLEDB.4.0;" + @"DATA SOURCE=F:\attendance\NITGENDBAC.mdb; Jet OLEDB:Database Password=nac3000;"))
                //using (con = new OleDbConnection(@"PROVIDER= Microsoft.Jet.OLEDB.4.0;" + @"DATA SOURCE=D:\AttendanceBackup\NITGENDBAC.mdb; Jet OLEDB:Database Password=nac3000;"))
                //{

                //    using (cmd = new OleDbCommand(strquery, con))
                //    {
                //        OleDbDataAdapter Da = new OleDbDataAdapter(cmd);
                //        var itmes = Da.Fill(ds);
                //    }
                //}

                //foreach (DataRow aitem in ds.Tables[0].Rows)
                //{
                //    Employee _employee = new Employee();

                //    _employee.E_Time = aitem["logtime"].ToString();
                //    _employee.EID = aitem["userid"].ToString();
                //    employess.Add(_employee);
                //}

                //var employes = employess;

                //List<HRM_AttendanceTemp> attendancees = new List<HRM_AttendanceTemp>();

                //foreach (var aitem in employes)
                //{
                //    HRM_AttendanceTemp _attendace = new HRM_AttendanceTemp();
                //    _attendace.EID = aitem.EID;
                //    DateTime localTime = Convert.ToDateTime(aitem.E_Time);
                //    string timeString24Hour = localTime.ToString("HH:mm:ss", CultureInfo.CurrentCulture);
                //    _attendace.IOTIME = TimeSpan.Parse(timeString24Hour);
                //    string[] date = aitem.E_Time.Split(' ');
                //    _attendace.AttendanceDate = Convert.ToDateTime(date[0]);

                //    attendancees.Add(_attendace);
                //}

                //foreach (HRM_AttendanceTemp aitem in attendancees)
                //{
                //    _context.HRM_AttendanceTemp.AddObject(aitem);
                //    _context.SaveChanges();
                //}
                //_context.SaveChanges();

                //using (var _context = new ERPSSLHBEntities())
                //{

                //    var ParamempID1 = new SqlParameter("@OCODE", OCODE);
                //    var ParamempID2 = new SqlParameter("@FromDate", FromDate);
                //    var ParamempID3 = new SqlParameter("@ToDate", ToDate);
                //    string SP_SQL = "MST_AllEnquiryReportsbyFromAndTodate @OCODE,@FromDate,@ToDate";
                //    return (_context.ExecuteStoreQuery<REnquiry>(SP_SQL, ParamempID1, ParamempID2, ParamempID3)).ToList();
                //}

                Guid USERID = ((SessionUser)Session["SessionUser"]).UserId;
                string OCODE = ((SessionUser)Session["SessionUser"]).OCode;

                var ParamempID1 = new SqlParameter("@Date_From", fromdate);
                var ParamempID2 = new SqlParameter("@Date_To", TO);
                var ParamempID3 = new SqlParameter("@Edit_User", USERID);
                var ParamempID4 = new SqlParameter("@Edit_Date", DateTime.Now);
                var ParamempID5 = new SqlParameter("@OCODE", OCODE);
                string SP_SQL = "HRM_getAttendancesByDatewise @Date_From, @Date_To, @Edit_User, @Edit_Date, @OCODE";
                _context.ExecuteStoreCommand(SP_SQL, ParamempID1, ParamempID2, ParamempID3, ParamempID4, ParamempID5);

                //lblMessage.Text = "Data Process Successfully!";
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Data Processed Temporarily')", true);
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
                DateTime todate = Convert.ToDateTime(txtbxToDate.Text.Trim());

                string attTemp = "HRM_SaveAttendanceDataFromAttendanceTemp";
                _context.ExecuteStoreCommand(attTemp);

                var ParamempID1 = new SqlParameter("@Date_From", fromdate);
                var ParamempID2 = new SqlParameter("@Date_To", todate);
                string SP_SQL1 = "HRM_UpdateAttendanceDataFromAttendanceTemp @Date_From,@Date_To";
                _context.ExecuteStoreCommand(SP_SQL1, ParamempID1, ParamempID2);


                string SP_SQL2 = "Delete_AttendencebyHRM_AttendancePunishmenttable";
                _context.ExecuteStoreCommand(SP_SQL2);

                // lblMessage.Text = "Data Confirm Process Successfully!";
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Data Processed Successfully')", true);
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

        ///Update attendance status

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

        //private void reset()
        //{
        //    txtbxFromDate.Text = DateTime.Today.ToShortDateString();
        //    txtbxToDate.Text = DateTime.Today.ToShortDateString();

        //    txtDateFrom.Text = DateTime.Today.ToShortDateString();
        //    txtDateTo.Text = DateTime.Today.ToShortDateString();
        //    //ddlShiftCode.ClearSelection();
        //    lblMessage.Text = "";
        //    txtOTFrom.Text = DateTime.Today.ToShortDateString();
        //    txtOTTo.Text = DateTime.Today.ToShortDateString();
        //}

        protected void btnUpdateStatus_Click(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToDateTime(txtDateFrom.Text) > DateTime.Now || Convert.ToDateTime(txtDateTo.Text) > DateTime.Now)
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Date can not be greater than current date!')", true);
                    return;
                }
                //lblMessage.Text = "Proccessing data...";
                //ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Proccessing data...Please wait')", true);
                string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                DateTime EDIT_DATE = DateTime.Now;
                Guid userId = ((SessionUser)Session["SessionUser"]).UserId;

                var result = objAtt_BLL.UpdateAttStatus_ByShift(Convert.ToDateTime(txtDateFrom.Text), Convert.ToDateTime(txtDateTo.Text), ddlShiftCode.Text);
                objAtt_BLL.Insert_AbsentLeaveStatus_ByShift(Convert.ToDateTime(txtDateFrom.Text), Convert.ToDateTime(txtDateTo.Text), ddlShiftCode.Text, OCODE, EDIT_DATE, userId);
                if (result == 1)
                {

                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Employee Attendance Status Processed Successfully')", true);

                }
                else
                {

                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Status Processing Failure!')", true);
                }

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

        protected void btnUpdateAll_Click(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToDateTime(txtDateFrom.Text) > DateTime.Now || Convert.ToDateTime(txtDateTo.Text) > DateTime.Now)
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Date can not be greater than current date!')", true);
                    return;
                }
                string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                DateTime EDIT_DATE = DateTime.Now;
                Guid userId = ((SessionUser)Session["SessionUser"]).UserId;

                var result = aAttendance_RPT_Bll.UpdateAll_AttStatus_ByDate(Convert.ToDateTime(txtDateFrom.Text), Convert.ToDateTime(txtDateTo.Text));

                aAttendance_RPT_Bll.Insert_AllAbsentLeaveStatus_ByDate(Convert.ToDateTime(txtDateFrom.Text), Convert.ToDateTime(txtDateTo.Text), OCODE, EDIT_DATE, userId);

                if (result == 1)
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Employee Attendance Status Processed Successfully')", true);
                    txtDateFrom.Text = DateTime.Today.ToShortDateString();
                    txtDateTo.Text = DateTime.Today.ToShortDateString();
                    ddlShiftCode.ClearSelection();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Status Processing Failure!')", true);
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
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('OT Processed Successfully')", true);
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('OT Processing Failure!')", true);
                    }
                }

                //ot process log
                DateTime fromdate = Convert.ToDateTime(txtOTFrom.Text.Trim());
                DateTime todate = Convert.ToDateTime(txtOTTo.Text.Trim());
                Guid USERID = ((SessionUser)Session["SessionUser"]).UserId;

                var ParamempID1 = new SqlParameter("@DateFrom", fromdate);
                var ParamempID2 = new SqlParameter("@DateTo", todate);
                var ParamempID3 = new SqlParameter("@Edit_User", USERID);
                var ParamempID4 = new SqlParameter("@Edit_Date", DateTime.Now);
                var ParamempID5 = new SqlParameter("@OCODE", OCODE);
                string SP_SQL = "HRM_Insert_OTProcessLog @DateFrom, @DateTo, @Edit_User, @Edit_Date, @OCODE";
                _context.ExecuteStoreCommand(SP_SQL, ParamempID1, ParamempID2, ParamempID3, ParamempID4, ParamempID5);
                //

                txtOTFrom.Text = "";
                txtOTTo.Text = "";
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }
    }
}
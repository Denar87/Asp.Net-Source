using ERPSSL.HRM.DAL;
using ERPSSL.HRM.DAL.AttendanceDataModel;
using ERPSSL.HRM.DAL.AttendanceDataModel.Repository;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ERPSSL.HRM
{
    public partial class ManualAttendance : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if ((Session["UserID"] != null) && (Session["OCode"] != null))
            {
                if (!IsPostBack)
                {
                }
            }
            else
            {
                Response.Redirect("..\\AppGateway\\Login.aspx");
            }

        }

        //protected void btnIntime_Click(object sender, EventArgs e)
        //{

        //    List <AttendanceRA> attendances = GetAttendanceList();

        //    if (attendances.Count > 0)
        //    {

        //        foreach (var aitem in attendances)
        //        {

        //            using (var _context = new ERPSSLHBEntities())
        //            {
        //                var shiftId = new SqlParameter("@ShifCode", aitem.PunchShiftCode);
        //                var employeeId = new SqlParameter("@EmpId", aitem.EmpId);
        //                var punchDate = new SqlParameter("@PunchDate", aitem.PunchDate);
        //                var intime = new SqlParameter("@TimeIn", aitem.TimeIn);
        //                var outtime = new SqlParameter("@TimeOut", aitem.TimeOut);
        //               // var sts = new SqlParameter("@Sts", aitem.Sts);
        //                string SP_SQL = "HRM_SaveAttendanceDataFromOtherDatabase @ShifCode,@EmpId,@PunchDate,@TimeIn,@TimeOut";
        //                _context.ExecuteStoreCommand(SP_SQL, shiftId, employeeId, punchDate, intime, outtime);

        //                //  DateTime attendancedate=Convert.ToDateTime(aitem.PunchDate);

        //                //var query = (from ex in _context.HRM_ATTENDANCE
        //                //             where ex.EID == aitem.EmpId && ex.ShiftCode == aitem.PunchShiftCode && ex.Attendance_Date == attendancedate
        //                //       select ex);
        //                //int u = query.Count();

        //            }
        //        }
        //    }

        //}

        //public List<AttendanceRA> GetAttendanceList()
        //{

        //    try
        //    {
        //        using (var _context = new BackUpHRMEntities())
        //        {
        //            var ParamempID = new SqlParameter("@OCODE", "8989");

        //            string SP_SQL = "[GetHrmAttendanceList] @OCODE";
        //            return (_context.ExecuteStoreQuery<AttendanceRA>(SP_SQL, ParamempID)).ToList();
        //        }
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }



        //}

        //protected void btnOutTime_Click(object sender, EventArgs e)
        //{


        //    try
        //    {
        //        List<AttendanceRA> attendances = GetAttendanceList();

        //        if (attendances.Count > 0)
        //        {

        //            foreach (var aitem in attendances)
        //            {

        //                using (var _context = new ERPSSLHBEntities())
        //                {
        //                    var shiftId = new SqlParameter("@ShifCode", aitem.PunchShiftCode);
        //                    var employeeId = new SqlParameter("@EmpId", aitem.EmpId);
        //                    var punchDate = new SqlParameter("@PunchDate", aitem.PunchDate);
        //                    var intime = new SqlParameter("@TimeIn", aitem.TimeIn);
        //                    var outtime = new SqlParameter("@TimeOut", aitem.TimeOut);
        //                   // var sts = new SqlParameter("@Sts", aitem.Sts);
        //                    string SP_SQL = "HRM_SaveAttendanceDataFromOtherDatabase @ShifCode,@EmpId,@PunchDate,@TimeIn,@TimeOut";
        //                    _context.ExecuteStoreCommand(SP_SQL, shiftId, employeeId, punchDate, intime, outtime);

        //                    //  DateTime attendancedate=Convert.ToDateTime(aitem.PunchDate);

        //                    //var query = (from ex in _context.HRM_ATTENDANCE
        //                    //             where ex.EID == aitem.EmpId && ex.ShiftCode == aitem.PunchShiftCode && ex.Attendance_Date == attendancedate
        //                    //       select ex);
        //                    //int u = query.Count();

        //                }

        //            }
        //        }

        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }

        //}
    }
}
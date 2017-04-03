using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using ERPSSL.HRM.DAL.Repository;

namespace ERPSSL.HRM.DAL
{
    public class Attendance_RPT_DAL
    {

        ERPSSLHBEntities _context = new ERPSSLHBEntities();

        internal List<Attendance_Viewer> GetPresentAttendenceReport(int RegionId, string status, string fromDate, string toDate)
        {
            try
            {
                using (var _context = new ERPSSLHBEntities())
                {
                    var RegionID = new SqlParameter("@RegionsId", RegionId);
                    var Status = new SqlParameter("@status", status);
                    var FromDate = new SqlParameter("@startDate", fromDate);
                    var ToDate = new SqlParameter("@endDate", toDate);
                    string SP_SQL = "HRM_AttendanceRegionWiseSP @RegionsId,@status,@startDate,@endDate";
                    return (_context.ExecuteStoreQuery<Attendance_Viewer>(SP_SQL, RegionID, Status, FromDate, ToDate)).ToList();
                }

            }
            catch (Exception)
            {
                throw;
            }
        }
        internal List<Attendance_Viewer> GetOfficeReport(int RegionId, int OfficeId, string status, string fromDate, string toDate)
        {
            try
            {
                using (var _context = new ERPSSLHBEntities())
                {
                    var RegionID = new SqlParameter("@RegionId", RegionId);
                    var Status = new SqlParameter("@status", status);
                    var OfficeID = new SqlParameter("@officeId", OfficeId);
                    var FromDate = new SqlParameter("@startDate", fromDate);
                    var ToDate = new SqlParameter("@endDate", toDate);
                    string SP_SQL = "HRM_AttendanceOfficeWiseSP @RegionId,@officeId,@status,@startDate,@endDate";
                    return (_context.ExecuteStoreQuery<Attendance_Viewer>(SP_SQL, RegionID, Status, OfficeID, FromDate, ToDate)).ToList();
                }

            }
            catch (Exception)
            {
                throw;
            }
        }

        internal List<Attendance_Viewer> GetDepartmentReport(int RegionId, int OfficeId, int DeptId, string status, string fromDate, string toDate)
        {
            try
            {
                using (var _context = new ERPSSLHBEntities())
                {
                    var RegionID = new SqlParameter("@RegionId", RegionId);
                    var Status = new SqlParameter("@status", status);
                    var OfficeID = new SqlParameter("@OfficeId", OfficeId);
                    var DeptID = new SqlParameter("@DepartmentId", DeptId);
                    var FromDate = new SqlParameter("@startDate", fromDate);
                    var ToDate = new SqlParameter("@endDate", toDate);
                    string SP_SQL = "HRM_AttendanceDeptWiseSP @RegionId,@OfficeId,@DepartmentId,@status,@startDate,@endDate";
                    return (_context.ExecuteStoreQuery<Attendance_Viewer>(SP_SQL, RegionID, Status, OfficeID, DeptID, FromDate, ToDate)).ToList();
                }

            }
            catch (Exception)
            {
                throw;
            }
        }

        internal List<Attendance_Viewer> GetShiftCodeReport(int RegionId, int OfficeId, int DeptId, string status, string fromDate, string toDate, string ShiftCode)
        {
            try
            {
                using (var _context = new ERPSSLHBEntities())
                {
                    var RegionID = new SqlParameter("@RegionId", RegionId);
                    var OfficeID = new SqlParameter("@OfficeId", OfficeId);
                    var DeptID = new SqlParameter("@DepartmentId", DeptId);
                    var Shift = new SqlParameter("@Shiftcode", ShiftCode);
                    var Status = new SqlParameter("@status", status);
                    var FromDate = new SqlParameter("@startDate", fromDate);
                    var ToDate = new SqlParameter("@endDate", toDate);
                    string SP_SQL = "HRM_AttendanceShiftWiseSP @RegionId,@OfficeId,@DepartmentId,@Shiftcode,@status,@startDate,@endDate";
                    return (_context.ExecuteStoreQuery<Attendance_Viewer>(SP_SQL, RegionID, OfficeID, DeptID, Shift, Status, FromDate, ToDate)).ToList();
                }

            }
            catch (Exception)
            {
                throw;
            }
        }
        internal List<Attendance_Viewer> GetAllShiftCodeReport(string status, string fromDate, string toDate, int ShiftCode)
        {
            try
            {
                using (var _context = new ERPSSLHBEntities())
                {
                    var Status = new SqlParameter("@status", status);
                    var FromDate = new SqlParameter("@startDate", fromDate);
                    var ToDate = new SqlParameter("@endDate", toDate);
                    var Shift = new SqlParameter("@Shiftcode", ShiftCode);
                    string SP_SQL = "HRM_AttendanceAllShiftWiseSP @status,@startDate,@endDate,@Shiftcode";
                    return (_context.ExecuteStoreQuery<Attendance_Viewer>(SP_SQL, Status, FromDate, ToDate, Shift)).ToList();
                }

            }
            catch (Exception)
            {
                throw;
            }
        }

        internal List<Attendance_Viewer> GetAllRegion(string status, string fromDate, string toDate)
        {
            try
            {
                using (var _context = new ERPSSLHBEntities())
                {
                    var Status = new SqlParameter("@status", status);
                    var FromDate = new SqlParameter("@startDate", fromDate);
                    var ToDate = new SqlParameter("@endDate", toDate);
                    string SP_SQL = "HRM_RPT_AttendanceAllRegion @status,@startDate,@endDate";
                    return (_context.ExecuteStoreQuery<Attendance_Viewer>(SP_SQL, Status, FromDate, ToDate)).ToList();
                }

            }
            catch (Exception)
            {
                throw;
            }
        }
        internal List<Attendance_Viewer> GetEmpIndividualReport(string empId, string status, string fromDate, string toDate)
        {
            try
            {
                using (var _context = new ERPSSLHBEntities())
                {
                    var EmpId = new SqlParameter("@empId", empId);
                    var Status = new SqlParameter("@status", status);
                    var FromDate = new SqlParameter("@startDate", fromDate);
                    var ToDate = new SqlParameter("@endDate", toDate);
                    string SP_SQL = "HRM_RPT_AttendanceIndividualEmp @empId,@status,@startDate,@endDate";
                    return (_context.ExecuteStoreQuery<Attendance_Viewer>(SP_SQL, EmpId, Status, FromDate, ToDate)).ToList();
                }

            }
            catch (Exception)
            {
                throw;
            }
        }

        internal List<Attendance_Viewer> Get_EmpIndividual_Compliance_Report(string empId, string status, string fromDate, string toDate)
        {
            try
            {
                using (var _context = new ERPSSLHBEntities())
                {
                    var EmpId = new SqlParameter("@empId", empId);
                    var Status = new SqlParameter("@status", status);
                    var FromDate = new SqlParameter("@startDate", fromDate);
                    var ToDate = new SqlParameter("@endDate", toDate);
                    string SP_SQL = "HRM_RPT_AttendanceIndividualEmp_Compliance @empId,@status,@startDate,@endDate";
                    _context.CommandTimeout = 100000;
                    return (_context.ExecuteStoreQuery<Attendance_Viewer>(SP_SQL, EmpId, Status, FromDate, ToDate)).ToList();
                }

            }
            catch (Exception)
            {
                throw;
            }
        }

        internal List<Attendance_Viewer> GetAttendanceAllEmp(string status, string fromDate, string toDate)
        {
            try
            {
                using (var _context = new ERPSSLHBEntities())
                {
                    var Status = new SqlParameter("@status", status);
                    var FromDate = new SqlParameter("@startDate", fromDate);
                    var ToDate = new SqlParameter("@endDate", toDate);
                    string SP_SQL = "HRM_RPT_AttendanceAllEmp @status,@startDate,@endDate";
                    return (_context.ExecuteStoreQuery<Attendance_Viewer>(SP_SQL, Status, FromDate, ToDate)).ToList();
                }

            }
            catch (Exception)
            {
                throw;
            }
        }

        internal List<Attendance_Viewer> GetAllOtHourCalculationReport(string fromDate, string toDate)
        {
            try
            {
                using (var _context = new ERPSSLHBEntities())
                {
                    var FromDate = new SqlParameter("@startDate", fromDate);
                    var ToDate = new SqlParameter("@endDate", toDate);
                    string SP_SQL = "HRM_Rpt_AllOTHourCalculation @startDate,@endDate";
                    return (_context.ExecuteStoreQuery<Attendance_Viewer>(SP_SQL, FromDate, ToDate)).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        internal List<Attendance_Viewer> GetEmpWiseOTReport(string empId, string fromDate, string toDate)
        {
            try
            {
                using (var _context = new ERPSSLHBEntities())
                {
                    var EmpId = new SqlParameter("@empId", empId);
                    var FromDate = new SqlParameter("@startDate", fromDate);
                    var ToDate = new SqlParameter("@endDate", toDate);
                    string SP_SQL = "HRM_Rpt_EmpwiseOTCalculation @empId,@startDate,@endDate";
                    return (_context.ExecuteStoreQuery<Attendance_Viewer>(SP_SQL, EmpId, FromDate, ToDate)).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }



        internal List<Salary_Viewer> GetEmployeeIndividualReport(string fromDate)
        {
            try
            {
                using (var _context = new ERPSSLHBEntities())
                {
                    var FromDate = new SqlParameter("@Date_From", fromDate);
                    string SP_SQL = "HRM_RPT_Get_SalaryInfo @Date_From";
                    return (_context.ExecuteStoreQuery<Salary_Viewer>(SP_SQL, FromDate)).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        internal List<Salary_Viewer> GetALLOTReportByOTHour(string fromDate, string overtime)
        {
            try
            {
                using (var _context = new ERPSSLHBEntities())
                {
                    var FromDate = new SqlParameter("@Date_From", fromDate);
                    var OT = new SqlParameter("@OverTime", overtime);
                    string SP_SQL = "HRM_RPT_OT_Sheet_ByOTHour @Date_From,@OverTime";
                    return (_context.ExecuteStoreQuery<Salary_Viewer>(SP_SQL, FromDate, OT)).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        internal List<Attendance_Viewer> GetEmpRegioneWiseOT(int RegionId, string fromDate, string toDate)
        {
            try
            {
                using (var _context = new ERPSSLHBEntities())
                {
                    var REGION = new SqlParameter("@Region", RegionId);
                    var FromDate = new SqlParameter("@startDate", fromDate);
                    var ToDate = new SqlParameter("@endDate", toDate);
                    string SP_SQL = "HRM_Rpt_EmpOfficeWiseOTCalculation @Region,@startDate,@endDate";
                    return (_context.ExecuteStoreQuery<Attendance_Viewer>(SP_SQL, REGION, FromDate, ToDate)).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        internal List<Attendance_Viewer> GetRegionWiseAtteAbsentAllEmp(int ResionId, string status, string fromDate, string toDate)
        {
            try
            {
                using (var _context = new ERPSSLHBEntities())
                {
                    var RegionID = new SqlParameter("@Region", ResionId);
                    var Status = new SqlParameter("@status", status);
                    var FromDate = new SqlParameter("@startDate", fromDate);
                    var ToDate = new SqlParameter("@endDate", toDate);
                    string SP_SQL = "HRM_RPT_RegionWiseLateAbsentAllEmp @Region,@status,@startDate,@endDate";
                    return (_context.ExecuteStoreQuery<Attendance_Viewer>(SP_SQL, RegionID, Status, FromDate, ToDate)).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        internal List<Attendance_Viewer> GetRegionWiseAtteLatetAllEmp(int ResionId, string status, string fromDate, string toDate)
        {
            try
            {
                using (var _context = new ERPSSLHBEntities())
                {
                    var RegionID = new SqlParameter("@Region", ResionId);
                    var Status = new SqlParameter("@status", status);
                    var FromDate = new SqlParameter("@startDate", fromDate);
                    var ToDate = new SqlParameter("@endDate", toDate);
                    string SP_SQL = "HRM_RPT_RegionWiseLateAbsentAllEmp @Region,@status,@startDate,@endDate";
                    return (_context.ExecuteStoreQuery<Attendance_Viewer>(SP_SQL, RegionID, Status, FromDate, ToDate)).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        internal List<Attendance_Viewer> GetAttendanceAllEmpForAll(string fromDate, string toDate)
        {
            try
            {
                using (var _context = new ERPSSLHBEntities())
                {
                    // var Status = new SqlParameter("@status", status);
                    var FromDate = new SqlParameter("@startDate", fromDate);
                    var ToDate = new SqlParameter("@endDate", toDate);
                    string SP_SQL = "HRM_RPT_AttendanceAllEmpDaily @startDate,@endDate";
                    return (_context.ExecuteStoreQuery<Attendance_Viewer>(SP_SQL, FromDate, ToDate)).ToList();
                }

            }
            catch (Exception)
            {
                throw;
            }
        }
        internal List<Attendance_Viewer> GetAllAttendanceForDateToDate(string today)
        {
            try
            {
                using (var _context = new ERPSSLHBEntities())
                {
                    var Today = new SqlParameter("@startDate", today);
                    string SP_SQL = "HRM_Rpt_Date_To_Date @startDate";
                    return (_context.ExecuteStoreQuery<Attendance_Viewer>(SP_SQL, Today)).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        internal List<Attendance_Viewer> GetSinglePunchForAll(string fromDate, string toDate)
        {
            try
            {
                using (var _context = new ERPSSLHBEntities())
                {
                    // var Status = new SqlParameter("@status", status);
                    var FromDate = new SqlParameter("@startDate", fromDate);
                    var ToDate = new SqlParameter("@endDate", toDate);
                    string SP_SQL = "HRM_RPT_SinglePunchAllEmpDaily @startDate,@endDate";
                    return (_context.ExecuteStoreQuery<Attendance_Viewer>(SP_SQL, FromDate, ToDate)).ToList();
                }

            }
            catch (Exception)
            {
                throw;
            }
        }


        internal List<Attendance_Viewer> GetAbsentAllEmpForAll(string status, string fromDate, string toDate)
        {
            try
            {
                using (var _context = new ERPSSLHBEntities())
                {
                    var Status = new SqlParameter("@status", status);
                    var FromDate = new SqlParameter("@startDate", fromDate);
                    var ToDate = new SqlParameter("@endDate", toDate);
                    string SP_SQL = "HRM_RPT_DailyAbsentAll @status,@startDate,@endDate";
                    return (_context.ExecuteStoreQuery<Attendance_Viewer>(SP_SQL, Status, FromDate, ToDate)).ToList();
                }

            }
            catch (Exception)
            {
                throw;
            }
        }

        internal List<Attendance_Viewer> GetAllAttendanceForEmployee(string fromDate, string toDate)
        {
            try
            {
                using (var _context = new ERPSSLHBEntities())
                {
                    var FromDate = new SqlParameter("@startDate", fromDate);
                    var ToDate = new SqlParameter("@endDate", toDate);
                    string SP_SQL = "HRM_RPT_AttendanceAllEmployee @startDate,@endDate";
                    return (_context.ExecuteStoreQuery<Attendance_Viewer>(SP_SQL, FromDate, ToDate)).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        internal List<Attendance_Viewer> GetAllAttendanceForRegionWise(int ResionId, string fromDate, string toDate)
        {
            try
            {
                using (var _context = new ERPSSLHBEntities())
                {
                    var RegionID = new SqlParameter("@Region", ResionId);
                    var FromDate = new SqlParameter("@startDate", fromDate);
                    var ToDate = new SqlParameter("@endDate", toDate);
                    string SP_SQL = "HRM_RPT_AttendanceAllEmpRegionWise @Region,@startDate,@endDate";
                    return (_context.ExecuteStoreQuery<Attendance_Viewer>(SP_SQL, RegionID, FromDate, ToDate)).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        internal List<Attendance_Viewer> GetAttendanceAllEmpForAllByRegion(int ResionId, string fromDate, string toDate)
        {
            try
            {
                using (var _context = new ERPSSLHBEntities())
                {
                    var RegionID = new SqlParameter("@Region", ResionId);
                    //var STATUS = new SqlParameter("@status", status);
                    var FromDate = new SqlParameter("@startDate", fromDate);
                    var ToDate = new SqlParameter("@endDate", toDate);
                    string SP_SQL = "HRM_RPT_AttendanceAllEmpDailyByRegion @Region,@startDate,@endDate";
                    return (_context.ExecuteStoreQuery<Attendance_Viewer>(SP_SQL, RegionID, FromDate, ToDate)).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        internal List<Attendance_Viewer> AttendanceLateAbsentAllEmp(string status, string fromDate, string toDate)
        {
            try
            {
                using (var _context = new ERPSSLHBEntities())
                {
                    var Status = new SqlParameter("@status", status);
                    var FromDate = new SqlParameter("@startDate", fromDate);
                    var ToDate = new SqlParameter("@endDate", toDate);
                    string SP_SQL = "HRM_RPT_AttendanceLateAbsentAllEmp @status,@startDate,@endDate";
                    return (_context.ExecuteStoreQuery<Attendance_Viewer>(SP_SQL, Status, FromDate, ToDate)).ToList();
                }

            }
            catch (Exception)
            {
                throw;
            }
        }

        internal List<Attendance_Viewer> MonthlyAttendanceForLeave(string fromDate, string toDate)
        {
            try
            {
                using (var _context = new ERPSSLHBEntities())
                {
                    var FromDate = new SqlParameter("@startDate", fromDate);
                    var ToDate = new SqlParameter("@endDate", toDate);
                    string SP_SQL = "HRM_Rpt_MonthlyAttendanceForLeave @startDate,@endDate";
                    return (_context.ExecuteStoreQuery<Attendance_Viewer>(SP_SQL, FromDate, ToDate)).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        internal List<Attendance_Viewer> MonthlyAttendanceAll(string fromDate, string toDate)
        {
            try
            {
                using (var _context = new ERPSSLHBEntities())
                {
                    var FromDate = new SqlParameter("@startDate", fromDate);
                    var ToDate = new SqlParameter("@endDate", toDate);
                    string SP_SQL = "HRM_Rpt_MonthlyAttendanceAll @startDate,@endDate";
                    return (_context.ExecuteStoreQuery<Attendance_Viewer>(SP_SQL, FromDate, ToDate)).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        internal List<Attendance_Viewer> MonthlyAttendanceByDept(int DeptId, int OfficeId, int ResionId, string fromDate, string toDate)
        {
            try
            {
                using (var _context = new ERPSSLHBEntities())
                {
                    var DeptID = new SqlParameter("@Dept", DeptId);
                    var OfficeID = new SqlParameter("@Office", OfficeId);
                    var RegionID = new SqlParameter("@Region", ResionId);
                    var FromDate = new SqlParameter("@startDate", fromDate);
                    var ToDate = new SqlParameter("@endDate", toDate);
                    string SP_SQL = "HRM_Rpt_MonthlyAttendanceByDept @Dept,@Office,@Region,@startDate,@endDate";
                    return (_context.ExecuteStoreQuery<Attendance_Viewer>(SP_SQL, DeptID, OfficeID, RegionID, FromDate, ToDate)).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        internal List<Attendance_Viewer> MonthlyAttendanceBySection(int sectionId, int DeptId, int OfficeId, int ResionId, string fromDate, string toDate)
        {
            try
            {
                using (var _context = new ERPSSLHBEntities())
                {
                    var secId = new SqlParameter("@Section", sectionId);
                    var DeptID = new SqlParameter("@Dept", DeptId);
                    var OfficeID = new SqlParameter("@Office", OfficeId);
                    var RegionID = new SqlParameter("@Region", ResionId);
                    var FromDate = new SqlParameter("@startDate", fromDate);
                    var ToDate = new SqlParameter("@endDate", toDate);
                    string SP_SQL = "HRM_Rpt_MonthlyAttendanceBySection @Section,@Dept,@Office,@Region,@startDate,@endDate";
                    return (_context.ExecuteStoreQuery<Attendance_Viewer>(SP_SQL, secId, DeptID, OfficeID, RegionID, FromDate, ToDate)).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        internal List<Attendance_Viewer> MonthlyAttendanceBySubSection(int subSectionid, int sectionId, int DeptId, int OfficeId, int ResionId, string fromDate, string toDate)
        {
            try
            {
                using (var _context = new ERPSSLHBEntities())
                {
                    var subSecId = new SqlParameter("@SubSectionId", subSectionid);
                    var secId = new SqlParameter("@SectionId", sectionId);
                    var DeptID = new SqlParameter("@Dept", DeptId);
                    var OfficeID = new SqlParameter("@Office", OfficeId);
                    var RegionID = new SqlParameter("@Region", ResionId);
                    // var Status = new SqlParameter("@status", status);
                    var FromDate = new SqlParameter("@startDate", fromDate);
                    var ToDate = new SqlParameter("@endDate", toDate);
                    string SP_SQL = "HRM_Rpt_MonthlyAttendanceBySubSection @SubSectionId, @SectionId,@Dept,@Office,@Region,@startDate,@endDate";
                    return (_context.ExecuteStoreQuery<Attendance_Viewer>(SP_SQL, subSecId, secId, DeptID, OfficeID, RegionID, FromDate, ToDate)).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        internal List<Attendance_Viewer> MonthlyAttendanceForLeaveforRegion(int ResionId, string fromDate, string toDate)
        {
            try
            {
                using (var _context = new ERPSSLHBEntities())
                {
                    var RegionID = new SqlParameter("@Region", ResionId);
                    var FromDate = new SqlParameter("@startDate", fromDate);
                    var ToDate = new SqlParameter("@endDate", toDate);
                    string SP_SQL = "HRM_Rpt_MonthlyAttendanceForLeaveForRegion @Region,@startDate,@endDate";
                    return (_context.ExecuteStoreQuery<Attendance_Viewer>(SP_SQL, RegionID, FromDate, ToDate)).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        internal List<Attendance_Viewer> GetAttendanceAllEmpForAllByOffice(int OfficeId, int ResionId, string fromDate, string toDate)
        {
            try
            {
                using (var _context = new ERPSSLHBEntities())
                {
                    var OfficeID = new SqlParameter("@Office", OfficeId);
                    var RegionID = new SqlParameter("@Region", ResionId);
                    //var Status = new SqlParameter("@status", status);
                    var FromDate = new SqlParameter("@startDate", fromDate);
                    var ToDate = new SqlParameter("@endDate", toDate);
                    string SP_SQL = "HRM_RPT_AttendanceAllEmpDailyByOffice @Office,@Region,@startDate,@endDate";
                    return (_context.ExecuteStoreQuery<Attendance_Viewer>(SP_SQL, OfficeID, RegionID, FromDate, ToDate)).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        internal List<Salary_Viewer> GetSalarySheetRegionWise(string fromDate, int RegionId)
        {
            try
            {
                using (var _context = new ERPSSLHBEntities())
                {

                    var FromDate = new SqlParameter("@Date_From", fromDate);
                    var RegionID = new SqlParameter("@Region", RegionId);
                    string SP_SQL = "HRM_RPT_Get_SalaryInfoRegionWise @Date_From , @Region";
                    return (_context.ExecuteStoreQuery<Salary_Viewer>(SP_SQL, FromDate, RegionID)).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        internal List<Salary_Viewer> GetOTSheetRegionWiseByOTHour(string fromDate, int RegionId, string overtime)
        {
            try
            {
                using (var _context = new ERPSSLHBEntities())
                {

                    var FromDate = new SqlParameter("@Date_From", fromDate);
                    var RegionID = new SqlParameter("@Region", RegionId);
                    var OT = new SqlParameter("@OverTime", overtime);
                    string SP_SQL = "HRM_RPT_OT_Sheet_RegionWiseByOTHour @Date_From , @Region,@OverTime";
                    return (_context.ExecuteStoreQuery<Salary_Viewer>(SP_SQL, FromDate, RegionID, OT)).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        internal List<Salary_Viewer> GetSalaryTopSheetRegionWise(string fromDate, int RegionId)
        {
            try
            {
                using (var _context = new ERPSSLHBEntities())
                {

                    var FromDate = new SqlParameter("@Date_From", fromDate);
                    var RegionID = new SqlParameter("@Region", RegionId);
                    string SP_SQL = "HRM_RPT_Get_SalaryTopSheetByRegion @Date_From , @Region";
                    return (_context.ExecuteStoreQuery<Salary_Viewer>(SP_SQL, FromDate, RegionID)).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        internal List<Salary_Viewer> GetSalarySheetOfficeWise(string fromDate, int RegionId, int OfficeId)
        {
            try
            {
                using (var _context = new ERPSSLHBEntities())
                {
                    var FromDate = new SqlParameter("@Date_From", fromDate);
                    var RegionID = new SqlParameter("@Region", RegionId);
                    var OfficeID = new SqlParameter("@Office", OfficeId);
                    string SP_SQL = "HRM_RPT_Get_SalaryInfoOfficeWise @Date_From , @Region, @Office";
                    return (_context.ExecuteStoreQuery<Salary_Viewer>(SP_SQL, FromDate, RegionID, OfficeID)).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        internal List<Salary_Viewer> GetOTSheetOfficeWiseByOTHour(string fromDate, int RegionId, int OfficeId, string overtime)
        {
            try
            {
                using (var _context = new ERPSSLHBEntities())
                {
                    var FromDate = new SqlParameter("@Date_From", fromDate);
                    var RegionID = new SqlParameter("@Region", RegionId);
                    var OfficeID = new SqlParameter("@Office", OfficeId);
                    var OT = new SqlParameter("@OverTime", overtime);
                    string SP_SQL = "HRM_RPT_OT_Sheet_OfficeWiseByOTHour @Date_From , @Region, @Office,@OverTime";
                    return (_context.ExecuteStoreQuery<Salary_Viewer>(SP_SQL, FromDate, RegionID, OfficeID, OT)).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        internal List<Salary_Viewer> GetSalaryTopSheetOfficeWise(string fromDate, int RegionId, int OfficeId, string OCODE)
        {
            try
            {
                using (var _context = new ERPSSLHBEntities())
                {
                    var FromDate = new SqlParameter("@Date_From", fromDate);
                    var RegionID = new SqlParameter("@Region", RegionId);
                    var OfficeID = new SqlParameter("@Office", OfficeId);
                    var OCode = new SqlParameter("@OCODE", OCODE);
                    string SP_SQL = "HRM_RPT_Get_SalaryTopSheetByOffice @Date_From , @Region, @Office,@OCODE";
                    return (_context.ExecuteStoreQuery<Salary_Viewer>(SP_SQL, FromDate, RegionID, OfficeID, OCode)).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        internal List<Salary_Viewer> GetSalaryTopSheetOfficeWise_ByCash(string fromDate, int RegionId, int OfficeId, string OCODE)
        {
            try
            {
                using (var _context = new ERPSSLHBEntities())
                {
                    var FromDate = new SqlParameter("@Date_From", fromDate);
                    var RegionID = new SqlParameter("@Region", RegionId);
                    var OfficeID = new SqlParameter("@Office", OfficeId);
                    var OCode = new SqlParameter("@OCODE", OCODE);
                    string SP_SQL = "HRM_RPT_Get_SalaryTopSheet_ByOffice_ByCash @Date_From , @Region, @Office,@OCODE";
                    return (_context.ExecuteStoreQuery<Salary_Viewer>(SP_SQL, FromDate, RegionID, OfficeID, OCode)).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        internal List<Salary_Viewer> GetSalaryTopSheetOfficeWise_ByBank(string fromDate, int RegionId, int OfficeId, string OCODE)
        {
            try
            {
                using (var _context = new ERPSSLHBEntities())
                {
                    var FromDate = new SqlParameter("@Date_From", fromDate);
                    var RegionID = new SqlParameter("@Region", RegionId);
                    var OfficeID = new SqlParameter("@Office", OfficeId);
                    var OCode = new SqlParameter("@OCODE", OCODE);
                    string SP_SQL = "HRM_RPT_Get_SalaryTopSheet_ByOffice_ByBank @Date_From , @Region, @Office,@OCODE";
                    return (_context.ExecuteStoreQuery<Salary_Viewer>(SP_SQL, FromDate, RegionID, OfficeID, OCode)).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        internal List<Salary_Viewer> GetSalaryTopSheetOfficeWise_ByMobileBank(string fromDate, int RegionId, int OfficeId, string OCODE)
        {
            try
            {
                using (var _context = new ERPSSLHBEntities())
                {
                    var FromDate = new SqlParameter("@Date_From", fromDate);
                    var RegionID = new SqlParameter("@Region", RegionId);
                    var OfficeID = new SqlParameter("@Office", OfficeId);
                    var OCode = new SqlParameter("@OCODE", OCODE);
                    string SP_SQL = "HRM_RPT_Get_SalaryTopSheet_ByOffice_ByMobileBank @Date_From , @Region, @Office,@OCODE";
                    return (_context.ExecuteStoreQuery<Salary_Viewer>(SP_SQL, FromDate, RegionID, OfficeID, OCode)).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        internal List<Salary_Viewer> GetSalaryTopSheetDepartmentWise(string fromDate, int RegionId, int OfficeId, int departmentId, string OCODE)
        {
            try
            {
                using (var _context = new ERPSSLHBEntities())
                {
                    var FromDate = new SqlParameter("@Date_From", fromDate);
                    var RegionID = new SqlParameter("@Region", RegionId);
                    var OfficeID = new SqlParameter("@Office", OfficeId);
                    var DepartmentID = new SqlParameter("@Dpt", departmentId);
                    var oCode = new SqlParameter("@OCODE", OCODE);
                    string SP_SQL = "HRM_RPT_Get_SalaryTopSheetByDepartment @Date_From , @Region, @Office,@Dpt,@OCODE";
                    return (_context.ExecuteStoreQuery<Salary_Viewer>(SP_SQL, FromDate, RegionID, OfficeID, DepartmentID, oCode)).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        internal List<Attendance_Viewer> GetAttendanceAllEmpForAllByDept(int DeptId, int OfficeId, int ResionId, string fromDate, string toDate)
        {
            try
            {
                using (var _context = new ERPSSLHBEntities())
                {
                    var DeptID = new SqlParameter("@Dept", DeptId);
                    var OfficeID = new SqlParameter("@Office", OfficeId);
                    var RegionID = new SqlParameter("@Region", ResionId);
                    //var Status = new SqlParameter("@status", status);
                    var FromDate = new SqlParameter("@startDate", fromDate);
                    var ToDate = new SqlParameter("@endDate", toDate);
                    string SP_SQL = "HRM_RPT_AttendanceAllEmpDailyByDept @Dept,@Office,@Region,@startDate,@endDate";
                    return (_context.ExecuteStoreQuery<Attendance_Viewer>(SP_SQL, DeptID, OfficeID, RegionID, FromDate, ToDate)).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        internal List<Attendance_Viewer> GetSinglePunchByDept(int DeptId, int OfficeId, int ResionId, string fromDate, string toDate)
        {
            try
            {
                using (var _context = new ERPSSLHBEntities())
                {
                    var DeptID = new SqlParameter("@Dept", DeptId);
                    var OfficeID = new SqlParameter("@Office", OfficeId);
                    var RegionID = new SqlParameter("@Region", ResionId);
                    //var Status = new SqlParameter("@status", status);
                    var FromDate = new SqlParameter("@startDate", fromDate);
                    var ToDate = new SqlParameter("@endDate", toDate);
                    string SP_SQL = "HRM_RPT_SinglePunchDailyByDept @Dept,@Office,@Region,@startDate,@endDate";
                    return (_context.ExecuteStoreQuery<Attendance_Viewer>(SP_SQL, DeptID, OfficeID, RegionID, FromDate, ToDate)).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }


        internal List<Attendance_Viewer> GetAbsentAllEmpForAllByDept(int DeptId, int OfficeId, int ResionId, string status, string fromDate, string toDate)
        {
            try
            {
                using (var _context = new ERPSSLHBEntities())
                {
                    var DeptID = new SqlParameter("@Dept", DeptId);
                    var OfficeID = new SqlParameter("@Office", OfficeId);
                    var RegionID = new SqlParameter("@Region", ResionId);
                    var Status = new SqlParameter("@status", status);
                    var FromDate = new SqlParameter("@startDate", fromDate);
                    var ToDate = new SqlParameter("@endDate", toDate);
                    string SP_SQL = "HRM_RPT_DailyAbsentByDept @Dept,@Office,@Region,@status,@startDate,@endDate";
                    return (_context.ExecuteStoreQuery<Attendance_Viewer>(SP_SQL, DeptID, OfficeID, RegionID, Status, FromDate, ToDate)).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        internal List<Attendance_Viewer> GetAttendanceAllEmpForAllBySection(int sectionId, int DeptId, int OfficeId, int ResionId, string fromDate, string toDate)
        {
            try
            {
                using (var _context = new ERPSSLHBEntities())
                {
                    var secId = new SqlParameter("@SectionId", sectionId);
                    var DeptID = new SqlParameter("@Dept", DeptId);
                    var OfficeID = new SqlParameter("@Office", OfficeId);
                    var RegionID = new SqlParameter("@Region", ResionId);
                    //var Status = new SqlParameter("@status", status);
                    var FromDate = new SqlParameter("@startDate", fromDate);
                    var ToDate = new SqlParameter("@endDate", toDate);
                    string SP_SQL = "HRM_RPT_AttendanceAllEmpDailyBySection @SectionId,@Dept,@Office,@Region,@startDate,@endDate";
                    return (_context.ExecuteStoreQuery<Attendance_Viewer>(SP_SQL, secId, DeptID, OfficeID, RegionID, FromDate, ToDate)).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        internal List<Attendance_Viewer> GetSinglePunchBySection(int sectionId, int DeptId, int OfficeId, int ResionId, string fromDate, string toDate)
        {
            try
            {
                using (var _context = new ERPSSLHBEntities())
                {
                    var secId = new SqlParameter("@SectionId", sectionId);
                    var DeptID = new SqlParameter("@Dept", DeptId);
                    var OfficeID = new SqlParameter("@Office", OfficeId);
                    var RegionID = new SqlParameter("@Region", ResionId);
                    //var Status = new SqlParameter("@status", status);
                    var FromDate = new SqlParameter("@startDate", fromDate);
                    var ToDate = new SqlParameter("@endDate", toDate);
                    string SP_SQL = "HRM_RPT_SinglePunchDailyBySection @SectionId,@Dept,@Office,@Region,@startDate,@endDate";
                    return (_context.ExecuteStoreQuery<Attendance_Viewer>(SP_SQL, secId, DeptID, OfficeID, RegionID, FromDate, ToDate)).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        internal List<Attendance_Viewer> GetAbsentAllEmpForAllBySection(int sectionId, int DeptId, int OfficeId, int ResionId, string status, string fromDate, string toDate)
        {
            try
            {
                using (var _context = new ERPSSLHBEntities())
                {
                    var secId = new SqlParameter("@SectionId", sectionId);
                    var DeptID = new SqlParameter("@Dept", DeptId);
                    var OfficeID = new SqlParameter("@Office", OfficeId);
                    var RegionID = new SqlParameter("@Region", ResionId);
                    var Status = new SqlParameter("@status", status);
                    var FromDate = new SqlParameter("@startDate", fromDate);
                    var ToDate = new SqlParameter("@endDate", toDate);
                    string SP_SQL = "HRM_RPT_DailyAbsentBySection @SectionId,@Dept,@Office,@Region,@status,@startDate,@endDate";
                    return (_context.ExecuteStoreQuery<Attendance_Viewer>(SP_SQL, secId, DeptID, OfficeID, RegionID, Status, FromDate, ToDate)).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        internal List<Attendance_Viewer> GetAttendanceAllEmpForAllBySubSection(int subSectionid, int sectionId, int DeptId, int OfficeId, int ResionId, string fromDate, string toDate)
        {
            try
            {
                using (var _context = new ERPSSLHBEntities())
                {
                    var subSecId = new SqlParameter("@SubSectionId", subSectionid);
                    var secId = new SqlParameter("@SectionId", sectionId);
                    var DeptID = new SqlParameter("@Dept", DeptId);
                    var OfficeID = new SqlParameter("@Office", OfficeId);
                    var RegionID = new SqlParameter("@Region", ResionId);
                    var FromDate = new SqlParameter("@startDate", fromDate);
                    var ToDate = new SqlParameter("@endDate", toDate);
                    string SP_SQL = "HRM_RPT_AttendanceAllEmpDailyBySubSection @SubSectionId, @SectionId,@Dept,@Office,@Region,@startDate,@endDate";
                    return (_context.ExecuteStoreQuery<Attendance_Viewer>(SP_SQL, subSecId, secId, DeptID, OfficeID, RegionID, FromDate, ToDate)).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        internal List<Attendance_Viewer> GetSinglePunchListBySubSection(int subSectionid, int sectionId, int DeptId, int OfficeId, int ResionId, string fromDate, string toDate)
        {
            try
            {
                using (var _context = new ERPSSLHBEntities())
                {
                    var subSecId = new SqlParameter("@SubSectionId", subSectionid);
                    var secId = new SqlParameter("@SectionId", sectionId);
                    var DeptID = new SqlParameter("@Dept", DeptId);
                    var OfficeID = new SqlParameter("@Office", OfficeId);
                    var RegionID = new SqlParameter("@Region", ResionId);
                    var FromDate = new SqlParameter("@startDate", fromDate);
                    var ToDate = new SqlParameter("@endDate", toDate);
                    string SP_SQL = "HRM_RPT_SinglePunchDailyBySubSection @SubSectionId, @SectionId,@Dept,@Office,@Region,@startDate,@endDate";
                    return (_context.ExecuteStoreQuery<Attendance_Viewer>(SP_SQL, subSecId, secId, DeptID, OfficeID, RegionID, FromDate, ToDate)).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        internal List<Attendance_Viewer> GetAbsentAllEmpForAllBySubSection(int subSectionid, int sectionId, int DeptId, int OfficeId, int ResionId, string status, string fromDate, string toDate)
        {
            try
            {
                using (var _context = new ERPSSLHBEntities())
                {
                    var subSecId = new SqlParameter("@SubSectionId", subSectionid);
                    var secId = new SqlParameter("@SectionId", sectionId);
                    var DeptID = new SqlParameter("@Dept", DeptId);
                    var OfficeID = new SqlParameter("@Office", OfficeId);
                    var RegionID = new SqlParameter("@Region", ResionId);
                    var Status = new SqlParameter("@status", status);
                    var FromDate = new SqlParameter("@startDate", fromDate);
                    var ToDate = new SqlParameter("@endDate", toDate);
                    string SP_SQL = "HRM_RPT_DailyAbsentBySubSection @SubSectionId, @SectionId,@Dept,@Office,@Region,@status,@startDate,@endDate";
                    return (_context.ExecuteStoreQuery<Attendance_Viewer>(SP_SQL, subSecId, secId, DeptID, OfficeID, RegionID, Status, FromDate, ToDate)).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        internal List<Attendance_Viewer> MonthlyAttendanceForLeaveforOffice(int OfficeId, int ResionId, string fromDate, string toDate)
        {
            try
            {
                using (var _context = new ERPSSLHBEntities())
                {
                    var OfficeID = new SqlParameter("@Office", OfficeId);
                    var RegionID = new SqlParameter("@Region", ResionId);
                    var FromDate = new SqlParameter("@startDate", fromDate);
                    var ToDate = new SqlParameter("@endDate", toDate);
                    string SP_SQL = "HRM_RPT_AttendanceSummaryDailyByOffice @Office,@Region,@startDate,@endDate";
                    return (_context.ExecuteStoreQuery<Attendance_Viewer>(SP_SQL, OfficeID, RegionID, FromDate, ToDate)).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        internal List<Attendance_Viewer> MonthlyAttendanceForLeaveforDept(int DeptId, int OfficeId, int ResionId, string fromDate, string toDate)
        {
            try
            {
                using (var _context = new ERPSSLHBEntities())
                {
                    var DeptID = new SqlParameter("@Dept", DeptId);
                    var OfficeID = new SqlParameter("@Office", OfficeId);
                    var RegionID = new SqlParameter("@Region", ResionId);
                    var FromDate = new SqlParameter("@startDate", fromDate);
                    var ToDate = new SqlParameter("@endDate", toDate);
                    string SP_SQL = "HRM_Rpt_MonthlyAttendanceForLeaveForDept @Dept,@Office,@Region,@startDate,@endDate";
                    return (_context.ExecuteStoreQuery<Attendance_Viewer>(SP_SQL, DeptID, OfficeID, RegionID, FromDate, ToDate)).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        internal List<Attendance_Viewer> DailyAttendanceSummmaryByDept(int DeptId, int OfficeId, int ResionId, string fromDate, string toDate)
        {
            try
            {
                using (var _context = new ERPSSLHBEntities())
                {
                    var DeptID = new SqlParameter("@Dept", DeptId);
                    var OfficeID = new SqlParameter("@Office", OfficeId);
                    var RegionID = new SqlParameter("@Region", ResionId);
                    var FromDate = new SqlParameter("@startDate", fromDate);
                    var ToDate = new SqlParameter("@endDate", toDate);
                    string SP_SQL = "HRM_RPT_AttendanceSummaryDailyByDept @Dept,@Office,@Region,@startDate,@endDate";
                    return (_context.ExecuteStoreQuery<Attendance_Viewer>(SP_SQL, DeptID, OfficeID, RegionID, FromDate, ToDate)).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        internal List<Attendance_Viewer> MonthlyAttendanceSummmaryByDept(int DeptId, int OfficeId, int ResionId, string fromDate, string toDate)
        {
            try
            {
                using (var _context = new ERPSSLHBEntities())
                {
                    var DeptID = new SqlParameter("@Dept", DeptId);
                    var OfficeID = new SqlParameter("@Office", OfficeId);
                    var RegionID = new SqlParameter("@Region", ResionId);
                    var FromDate = new SqlParameter("@startDate", fromDate);
                    var ToDate = new SqlParameter("@endDate", toDate);
                    string SP_SQL = "HRM_RPT_AttendanceSummaryMonthlyByDept @Dept,@Office,@Region,@startDate,@endDate";
                    return (_context.ExecuteStoreQuery<Attendance_Viewer>(SP_SQL, DeptID, OfficeID, RegionID, FromDate, ToDate)).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        internal List<Attendance_Viewer> DailyAttendanceSummmaryByDept_Designationwise(int DeptId, int OfficeId, int ResionId, string fromDate, string toDate)
        {
            try
            {
                using (var _context = new ERPSSLHBEntities())
                {
                    var DeptID = new SqlParameter("@Dept", DeptId);
                    var OfficeID = new SqlParameter("@Office", OfficeId);
                    var RegionID = new SqlParameter("@Region", ResionId);
                    var FromDate = new SqlParameter("@startDate", fromDate);
                    var ToDate = new SqlParameter("@endDate", toDate);
                    string SP_SQL = "HRM_RPT_AttendanceSummaryDailyByDept_Designationwise @Dept,@Office,@Region,@startDate,@endDate";
                    return (_context.ExecuteStoreQuery<Attendance_Viewer>(SP_SQL, DeptID, OfficeID, RegionID, FromDate, ToDate)).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }


        internal List<Attendance_Viewer> DailyAttendanceSummmaryBySection_Designationwise(int sectionId, int DeptId, int OfficeId, int ResionId, string fromDate, string toDate)
        {
            try
            {
                using (var _context = new ERPSSLHBEntities())
                {
                    var secId = new SqlParameter("@Section", sectionId);
                    var DeptID = new SqlParameter("@Dept", DeptId);
                    var OfficeID = new SqlParameter("@Office", OfficeId);
                    var RegionID = new SqlParameter("@Region", ResionId);
                    var FromDate = new SqlParameter("@startDate", fromDate);
                    var ToDate = new SqlParameter("@endDate", toDate);
                    string SP_SQL = "HRM_RPT_AttendanceSummaryDailyBySection_Designationwise @Section,@Dept,@Office,@Region,@startDate,@endDate";
                    return (_context.ExecuteStoreQuery<Attendance_Viewer>(SP_SQL, secId, DeptID, OfficeID, RegionID, FromDate, ToDate)).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }


        internal List<Attendance_Viewer> DailyAttendanceSummmaryBySection(int sectionId, int DeptId, int OfficeId, int ResionId, string fromDate, string toDate)
        {
            try
            {
                using (var _context = new ERPSSLHBEntities())
                {
                    var secId = new SqlParameter("@Section", sectionId);
                    var DeptID = new SqlParameter("@Dept", DeptId);
                    var OfficeID = new SqlParameter("@Office", OfficeId);
                    var RegionID = new SqlParameter("@Region", ResionId);
                    var FromDate = new SqlParameter("@startDate", fromDate);
                    var ToDate = new SqlParameter("@endDate", toDate);
                    string SP_SQL = "HRM_RPT_AttendanceSummaryDailyBySection @Section,@Dept,@Office,@Region,@startDate,@endDate";
                    return (_context.ExecuteStoreQuery<Attendance_Viewer>(SP_SQL, secId, DeptID, OfficeID, RegionID, FromDate, ToDate)).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        internal List<Attendance_Viewer> MonthlyAttendanceSummmaryBySection(int sectionId, int DeptId, int OfficeId, int ResionId, string fromDate, string toDate)
        {
            try
            {
                using (var _context = new ERPSSLHBEntities())
                {
                    var secId = new SqlParameter("@Section", sectionId);
                    var DeptID = new SqlParameter("@Dept", DeptId);
                    var OfficeID = new SqlParameter("@Office", OfficeId);
                    var RegionID = new SqlParameter("@Region", ResionId);
                    var FromDate = new SqlParameter("@startDate", fromDate);
                    var ToDate = new SqlParameter("@endDate", toDate);
                    string SP_SQL = "HRM_RPT_AttendanceSummaryMonthlyBySection @Section,@Dept,@Office,@Region,@startDate,@endDate";
                    return (_context.ExecuteStoreQuery<Attendance_Viewer>(SP_SQL, secId, DeptID, OfficeID, RegionID, FromDate, ToDate)).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        internal List<Attendance_Viewer> MonthlyPresentBySection(int sectionId, int DeptId, int OfficeId, int ResionId, string fromDate, string toDate)
        {
            try
            {
                using (var _context = new ERPSSLHBEntities())
                {
                    var secId = new SqlParameter("@Section", sectionId);
                    var DeptID = new SqlParameter("@Dept", DeptId);
                    var OfficeID = new SqlParameter("@Office", OfficeId);
                    var RegionID = new SqlParameter("@Region", ResionId);
                    var FromDate = new SqlParameter("@startDate", fromDate);
                    var ToDate = new SqlParameter("@endDate", toDate);
                    string SP_SQL = "HRM_Rpt_MonthlyPresentBySection @Section,@Dept,@Office,@Region,@startDate,@endDate";
                    return (_context.ExecuteStoreQuery<Attendance_Viewer>(SP_SQL, secId, DeptID, OfficeID, RegionID, FromDate, ToDate)).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        internal List<Attendance_Viewer> MonthlyPresentBySubSection(int subSectionid, int sectionId, int DeptId, int OfficeId, int ResionId, string fromDate, string toDate)
        {
            try
            {
                using (var _context = new ERPSSLHBEntities())
                {
                    var subSecId = new SqlParameter("@SubSection", subSectionid);
                    var secId = new SqlParameter("@Section", sectionId);
                    var DeptID = new SqlParameter("@Dept", DeptId);
                    var OfficeID = new SqlParameter("@Office", OfficeId);
                    var RegionID = new SqlParameter("@Region", ResionId);
                    // var Status = new SqlParameter("@status", status);
                    var FromDate = new SqlParameter("@startDate", fromDate);
                    var ToDate = new SqlParameter("@endDate", toDate);
                    string SP_SQL = "HRM_Rpt_MonthlyPresentBySubSection @SubSection, @Section,@Dept,@Office,@Region,@startDate,@endDate";
                    return (_context.ExecuteStoreQuery<Attendance_Viewer>(SP_SQL, subSecId, secId, DeptID, OfficeID, RegionID, FromDate, ToDate)).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        internal List<Attendance_Viewer> MonthlyAbsentBySubSection(int subSectionid, int sectionId, int DeptId, int OfficeId, int ResionId, string fromDate, string toDate)
        {
            try
            {
                using (var _context = new ERPSSLHBEntities())
                {
                    var subSecId = new SqlParameter("@SubSection", subSectionid);
                    var secId = new SqlParameter("@Section", sectionId);
                    var DeptID = new SqlParameter("@Dept", DeptId);
                    var OfficeID = new SqlParameter("@Office", OfficeId);
                    var RegionID = new SqlParameter("@Region", ResionId);
                    // var Status = new SqlParameter("@status", status);
                    var FromDate = new SqlParameter("@startDate", fromDate);
                    var ToDate = new SqlParameter("@endDate", toDate);
                    string SP_SQL = "HRM_Rpt_MonthlyAbsentBySubSection @SubSection, @Section,@Dept,@Office,@Region,@startDate,@endDate";
                    return (_context.ExecuteStoreQuery<Attendance_Viewer>(SP_SQL, subSecId, secId, DeptID, OfficeID, RegionID, FromDate, ToDate)).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        internal List<Attendance_Viewer> GetOfficeWiseAtteAbsentAllEmp(int OfficeId, int ResionId, string status, string fromDate, string toDate)
        {
            try
            {
                using (var _context = new ERPSSLHBEntities())
                {

                    var OfficeID = new SqlParameter("@Office", OfficeId);
                    var RegionID = new SqlParameter("@Region", ResionId);
                    var Status = new SqlParameter("@status", status);
                    var FromDate = new SqlParameter("@startDate", fromDate);
                    var ToDate = new SqlParameter("@endDate", toDate);
                    string SP_SQL = "HRM_RPT_OfficeWiseLateAbsentAllEmp @Office,@Region,@status,@startDate,@endDate";
                    return (_context.ExecuteStoreQuery<Attendance_Viewer>(SP_SQL, OfficeID, RegionID, Status, FromDate, ToDate)).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        internal List<Attendance_Viewer> GetOfficeWiseAtteLatetAllEmp(int OfficeId, int ResionId, string status, string fromDate, string toDate)
        {
            try
            {
                using (var _context = new ERPSSLHBEntities())
                {

                    var OfficeID = new SqlParameter("@Office", OfficeId);
                    var RegionID = new SqlParameter("@Region", ResionId);
                    var Status = new SqlParameter("@status", status);
                    var FromDate = new SqlParameter("@startDate", fromDate);
                    var ToDate = new SqlParameter("@endDate", toDate);
                    string SP_SQL = "HRM_RPT_OfficeWiseLateAbsentAllEmp @Office,@Region,@status,@startDate,@endDate";
                    return (_context.ExecuteStoreQuery<Attendance_Viewer>(SP_SQL, OfficeID, RegionID, Status, FromDate, ToDate)).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        internal List<Attendance_Viewer> GetDeptWiseAtteAbsentAllEmp(int DeptId, int OfficeId, int ResionId, string status, string fromDate, string toDate)
        {
            try
            {
                using (var _context = new ERPSSLHBEntities())
                {
                    var DeptID = new SqlParameter("@Dept", DeptId);
                    var OfficeID = new SqlParameter("@Office", OfficeId);
                    var RegionID = new SqlParameter("@Region", ResionId);
                    var Status = new SqlParameter("@status", status);
                    var FromDate = new SqlParameter("@startDate", fromDate);
                    var ToDate = new SqlParameter("@endDate", toDate);
                    string SP_SQL = "HRM_RPT_DeptWiseLateAbsentAllEmp @Dept,@Office,@Region,@status,@startDate,@endDate";
                    return (_context.ExecuteStoreQuery<Attendance_Viewer>(SP_SQL, DeptID, OfficeID, RegionID, Status, FromDate, ToDate)).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        internal List<Attendance_Viewer> GetDeptWiseAtteLatetAllEmp(int DeptId, int OfficeId, int ResionId, string status, string fromDate, string toDate)
        {
            try
            {
                using (var _context = new ERPSSLHBEntities())
                {
                    var DeptID = new SqlParameter("@Dept", DeptId);
                    var OfficeID = new SqlParameter("@Office", OfficeId);
                    var RegionID = new SqlParameter("@Region", ResionId);
                    var Status = new SqlParameter("@status", status);
                    var FromDate = new SqlParameter("@startDate", fromDate);
                    var ToDate = new SqlParameter("@endDate", toDate);
                    string SP_SQL = "HRM_RPT_DeptWiseLateAbsentAllEmp @Dept,@Office,@Region,@status,@startDate,@endDate";
                    return (_context.ExecuteStoreQuery<Attendance_Viewer>(SP_SQL, DeptID, OfficeID, RegionID, Status, FromDate, ToDate)).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        internal List<Salary_Viewer> GetSalarySheetDeptWise(int departmentId, string fromDate, string ToDate, int RegionId, int OfficeId)
        {
            try
            {
                using (var _context = new ERPSSLHBEntities())
                {
                    var DeptID = new SqlParameter("@Dept", departmentId);
                    var FromDate = new SqlParameter("@Date_From", fromDate);
                    var TODate = new SqlParameter("@Date_To", ToDate);
                    var RegionID = new SqlParameter("@Region", RegionId);
                    var OfficeID = new SqlParameter("@Office", OfficeId);
                    string SP_SQL = "HRM_RPT_Get_SalaryInfoDeptWise @Dept, @Date_From ,@Date_To, @Region, @Office";
                    return (_context.ExecuteStoreQuery<Salary_Viewer>(SP_SQL, DeptID, FromDate, TODate, RegionID, OfficeID)).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        internal List<Salary_Viewer> GetOTSheetDeptWiseByOTHour(int departmentId, string fromDate, string ToDate, int RegionId, int OfficeId, string overtime)
        {
            try
            {
                using (var _context = new ERPSSLHBEntities())
                {
                    var DeptID = new SqlParameter("@Dept", departmentId);
                    var FromDate = new SqlParameter("@Date_From", fromDate);
                    var TODate = new SqlParameter("@Date_To", ToDate);
                    var RegionID = new SqlParameter("@Region", RegionId);
                    var OfficeID = new SqlParameter("@Office", OfficeId);
                    var OT = new SqlParameter("@OverTime", overtime);
                    string SP_SQL = "HRM_RPT_OT_Sheet_DeptWiseByOTHour @Dept, @Date_From ,@Date_To, @Region, @Office,@OverTime";
                    return (_context.ExecuteStoreQuery<Salary_Viewer>(SP_SQL, DeptID, FromDate, TODate, RegionID, OfficeID, OT)).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }


        internal List<Salary_Viewer> GetSalarySheetSectionWise(int departmentId, string fromDate, int RegionId, int OfficeId, int SectionId)
        {
            try
            {
                using (var _context = new ERPSSLHBEntities())
                {
                    var DeptID = new SqlParameter("@Dept", departmentId);
                    var FromDate = new SqlParameter("@Date_From", fromDate);
                    var RegionID = new SqlParameter("@Region", RegionId);
                    var OfficeID = new SqlParameter("@Office", OfficeId);
                    var SectionID = new SqlParameter("@SectionId", SectionId);
                    string SP_SQL = "HRM_RPT_Get_SalaryInfoBySection @Dept, @Date_From , @Region, @Office,@SectionId";
                    return (_context.ExecuteStoreQuery<Salary_Viewer>(SP_SQL, DeptID, FromDate, RegionID, OfficeID, SectionID)).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        internal List<Salary_Viewer> GetOTSheetSectionWiseByOTHour(int departmentId, string fromDate, int RegionId, int OfficeId, int SectionId, string overtime)
        {
            try
            {
                using (var _context = new ERPSSLHBEntities())
                {
                    var DeptID = new SqlParameter("@Dept", departmentId);
                    var FromDate = new SqlParameter("@Date_From", fromDate);
                    var RegionID = new SqlParameter("@Region", RegionId);
                    var OfficeID = new SqlParameter("@Office", OfficeId);
                    var SectionID = new SqlParameter("@SectionId", SectionId);
                    var OT = new SqlParameter("@OverTime", overtime);
                    string SP_SQL = "HRM_RPT_OT_Sheet_BySectionByOTHour @Dept, @Date_From , @Region, @Office,@SectionId,@OverTime";
                    return (_context.ExecuteStoreQuery<Salary_Viewer>(SP_SQL, DeptID, FromDate, RegionID, OfficeID, SectionID, OT)).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        internal List<Salary_Viewer> GetSalarySheetSubSectionWise(int departmentId, string fromDate, int RegionId, int OfficeId, int SectionId, int SubsectionId)
        {
            try
            {
                using (var _context = new ERPSSLHBEntities())
                {
                    var DeptID = new SqlParameter("@Dept", departmentId);
                    var FromDate = new SqlParameter("@Date_From", fromDate);
                    var RegionID = new SqlParameter("@Region", RegionId);
                    var OfficeID = new SqlParameter("@Office", OfficeId);
                    var SectionID = new SqlParameter("@SectionId", SectionId);
                    var SubSectionID = new SqlParameter("@SubSection", SubsectionId);
                    string SP_SQL = "HRM_RPT_Get_SalaryInfoBySubSection @Dept, @Date_From , @Region, @Office,@SectionId,@SubSection";
                    return (_context.ExecuteStoreQuery<Salary_Viewer>(SP_SQL, DeptID, FromDate, RegionID, OfficeID, SectionID, SubSectionID)).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        internal List<Salary_Viewer> GetOTSheetSubSectionWiseByOTHour(int departmentId, string fromDate, int RegionId, int OfficeId, int SectionId, int SubsectionId, string overtime)
        {
            try
            {
                using (var _context = new ERPSSLHBEntities())
                {
                    var DeptID = new SqlParameter("@Dept", departmentId);
                    var FromDate = new SqlParameter("@Date_From", fromDate);
                    var RegionID = new SqlParameter("@Region", RegionId);
                    var OfficeID = new SqlParameter("@Office", OfficeId);
                    var SectionID = new SqlParameter("@SectionId", SectionId);
                    var SubSectionID = new SqlParameter("@SubSection", SubsectionId);
                    var OT = new SqlParameter("@OverTime", overtime);
                    string SP_SQL = "HRM_RPT_OT_Sheet_BySubSectionByOTHour @Dept, @Date_From , @Region, @Office,@SectionId,@SubSection,@OverTime";
                    return (_context.ExecuteStoreQuery<Salary_Viewer>(SP_SQL, DeptID, FromDate, RegionID, OfficeID, SectionID, SubSectionID, OT)).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        internal int UpdateAttStatus_ByDate(DateTime fromDate, DateTime toDate)
        {
            try
            {
                using (var _context = new ERPSSLHBEntities())
                {
                    var ParamempID = new SqlParameter("@DateFrom", fromDate);
                    var ParamempID1 = new SqlParameter("@DateTo", toDate);

                    string SP_SQL = "HRM_Rpt_UpdateAttendance_Status @DateFrom,@DateTo";
                    _context.ExecuteStoreCommand(SP_SQL, ParamempID, ParamempID1);

                    return 1;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        internal int Update_AbsentLeaveStatus_ByDate(DateTime fromDate, DateTime toDate, string OCODE, DateTime editdate, Guid userid)
        {

            using (var _context = new ERPSSLHBEntities())
            {
                var ParamempID = new SqlParameter("@DateFrom", fromDate);
                var ParamempID1 = new SqlParameter("@DateTo", toDate);
                var ParamempID2 = new SqlParameter("@OCODE", OCODE);
                var ParamempID3 = new SqlParameter("@EditDate", editdate);
                var ParamempID4 = new SqlParameter("@EditBy", userid);
                string SP_SQL = "HRM_Update_Absent_Leave_Holiday_Status @DateFrom,@DateTo,@OCODE,@EditDate,@EditBy";
                //string SP_SQL = "HRM_Update_Absent_Leave_Holiday_Status @DateFrom,@DateTo,@OCODE,@EditDate,@EditBy";
                _context.ExecuteStoreCommand(SP_SQL, ParamempID, ParamempID1, ParamempID2, ParamempID3, ParamempID4);

                return 1;
            }

        }

        internal List<Attendance_Viewer> GetAllEmployeeLeave(string today)
        {
            try
            {
                using (var _context = new ERPSSLHBEntities())
                {
                    var Today = new SqlParameter("@startDate", today);
                    string SP_SQL = "HRM_Rpt_AllEmployeeLeave @startDate";
                    return (_context.ExecuteStoreQuery<Attendance_Viewer>(SP_SQL, Today)).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }


        internal List<Attendance_Viewer> GetrdAttendanceOTRegisterReport(string fromDate, string toDate)
        {
            try
            {
                using (var _context = new ERPSSLHBEntities())
                {
                    var FromDate = new SqlParameter("@startDate", fromDate);
                    var ToDate = new SqlParameter("@endDate", toDate);
                    string SP_SQL = "HRM_Rpt_AttendanceAndOTCalculation @startDate,@endDate";
                    return (_context.ExecuteStoreQuery<Attendance_Viewer>(SP_SQL, FromDate, ToDate)).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        internal List<Attendance_Viewer> GetrdAttendanceOTRegisterReportBySubSection(int subsection, int secId, int DeptId, int OfficeId, int ResionId, string fromDate, string toDate)
        {
            try
            {
                using (var _context = new ERPSSLHBEntities())
                {
                    var SubsectionidId = new SqlParameter("@SubSectionId", subsection);
                    var sectionId = new SqlParameter("@SectionId", secId);
                    var DeptID = new SqlParameter("@Dept", DeptId);
                    var OfficeID = new SqlParameter("@Office", OfficeId);
                    var RegionID = new SqlParameter("@Region", ResionId);
                    //var Status = new SqlParameter("@status", status);
                    var FromDate = new SqlParameter("@startDate", fromDate);
                    var ToDate = new SqlParameter("@endDate", toDate);
                    string SP_SQL = "HRM_Rpt_AttendanceAndOTCalculationBySubSection @SubSectionId,@SectionId,@Dept,@Office,@Region,@startDate,@endDate";
                    _context.CommandTimeout = 300;
                    return (_context.ExecuteStoreQuery<Attendance_Viewer>(SP_SQL, SubsectionidId, sectionId, DeptID, OfficeID, RegionID, FromDate, ToDate)).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        internal List<Attendance_Viewer> GetrdAttendanceOTRegisterReportBySection(int secId, int DeptId, int OfficeId, int ResionId, string fromDate, string toDate)
        {
            try
            {
                using (var _context = new ERPSSLHBEntities())
                {

                    var sectionId = new SqlParameter("@SectionId", secId);
                    var DeptID = new SqlParameter("@Dept", DeptId);
                    var OfficeID = new SqlParameter("@Office", OfficeId);
                    var RegionID = new SqlParameter("@Region", ResionId);
                    //var Status = new SqlParameter("@status", status);
                    var FromDate = new SqlParameter("@startDate", fromDate);
                    var ToDate = new SqlParameter("@endDate", toDate);
                    string SP_SQL = "HRM_Rpt_AttendanceAndOTCalculationBySection @SectionId,@Dept,@Office,@Region,@startDate,@endDate";
                    return (_context.ExecuteStoreQuery<Attendance_Viewer>(SP_SQL, sectionId, DeptID, OfficeID, RegionID, FromDate, ToDate)).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        internal List<Attendance_Viewer> GetrdAttendanceOTRegisterReportByDepartment(int DeptId, int OfficeId, int ResionId, string fromDate, string toDate)
        {
            try
            {
                using (var _context = new ERPSSLHBEntities())
                {


                    var DeptID = new SqlParameter("@Dept", DeptId);
                    var OfficeID = new SqlParameter("@Office", OfficeId);
                    var RegionID = new SqlParameter("@Region", ResionId);
                    //var Status = new SqlParameter("@status", status);
                    var FromDate = new SqlParameter("@startDate", fromDate);
                    var ToDate = new SqlParameter("@endDate", toDate);
                    string SP_SQL = "HRM_Rpt_AttendanceAndOTCalculationByDepartment @Dept,@Office,@Region,@startDate,@endDate";
                    return (_context.ExecuteStoreQuery<Attendance_Viewer>(SP_SQL, DeptID, OfficeID, RegionID, FromDate, ToDate)).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        internal List<Attendance_Viewer> DailyAttendanceSummmaryByOffice(int OfficeId, int ResionId, string fromDate, string toDate)
        {
            try
            {
                using (var _context = new ERPSSLHBEntities())
                {
                    var OfficeID = new SqlParameter("@Office", OfficeId);
                    var RegionID = new SqlParameter("@Region", ResionId);
                    //var Status = new SqlParameter("@status", status);
                    var FromDate = new SqlParameter("@startDate", fromDate);
                    var ToDate = new SqlParameter("@endDate", toDate);
                    string SP_SQL = "HRM_RPT_AttendanceSummaryDailyByOffice @Office,@Region,@startDate,@endDate";
                    return (_context.ExecuteStoreQuery<Attendance_Viewer>(SP_SQL, OfficeID, RegionID, FromDate, ToDate)).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        //    internal List<Attendance_Viewer> GetAbsentAllEmpForAllByByOffice(int OfficeId, int ResionId, string status, string fromDate, string toDate)
        //    {
        //        try
        //        {
        //            using (var _context = new ERPSSLHBEntities())
        //            {
        //                var OfficeID = new SqlParameter("@Office", OfficeId);
        //                var RegionID = new SqlParameter("@Region", ResionId);
        //                var Status = new SqlParameter("@status", status);
        //                var FromDate = new SqlParameter("@startDate", fromDate);
        //                var ToDate = new SqlParameter("@endDate", toDate);
        //                string SP_SQL = "HRM_RPT_DailyAbsentByOffice @Office,@Region,@startDate,@endDate";
        //                return (_context.ExecuteStoreQuery<Attendance_Viewer>(SP_SQL, OfficeID, RegionID, Status, FromDate, ToDate)).ToList();
        //            }
        //        }
        //        catch (Exception)
        //        {
        //            throw;
        //        }
        //    }
        internal List<Attendance_Viewer> GetAbsentAllEmpForAllByByOffice(int OfficeId, int ResionId, string status, string fromDate, string toDate)
        {
            try
            {
                using (var _context = new ERPSSLHBEntities())
                {

                    var OfficeID = new SqlParameter("@Office", OfficeId);
                    var RegionID = new SqlParameter("@Region", ResionId);
                    var Status = new SqlParameter("@status", status);
                    var FromDate = new SqlParameter("@startDate", fromDate);
                    var ToDate = new SqlParameter("@endDate", toDate);
                    string SP_SQL = "HRM_RPT_DailyAbsentByOffice @Office,@Region,@status,@startDate,@endDate";
                    return (_context.ExecuteStoreQuery<Attendance_Viewer>(SP_SQL, OfficeID, RegionID, Status, FromDate, ToDate)).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }


        internal int Insert_AllAbsentLeaveStatus_ByDate(DateTime fromDate, DateTime toDate, string OCODE, DateTime editdate, Guid userid)
        {

            using (var _context = new ERPSSLHBEntities())
            {
                var ParamempID = new SqlParameter("@DateFrom", fromDate);
                var ParamempID1 = new SqlParameter("@DateTo", toDate);
                var ParamempID2 = new SqlParameter("@OCODE", OCODE);
                var ParamempID3 = new SqlParameter("@EditDate", editdate);
                var ParamempID4 = new SqlParameter("@EditBy", userid);
                string SP_SQL = "HRM_Update_Absent_Leave_Holiday_Status @DateFrom,@DateTo,@OCODE,@EditDate,@EditBy";
                //string SP_SQL = "HRM_Update_Absent_Leave_Holiday_Status @DateFrom,@DateTo,@OCODE,@EditDate,@EditBy";
                _context.ExecuteStoreCommand(SP_SQL, ParamempID, ParamempID1, ParamempID2, ParamempID3, ParamempID4);

                return 1;
            }

        }

        internal int UpdateAll_AttStatus_ByDate(DateTime fromDate, DateTime toDate)
        {
            try
            {
                using (var _context = new ERPSSLHBEntities())
                {
                    var ParamempID = new SqlParameter("@DateFrom", fromDate);
                    var ParamempID1 = new SqlParameter("@DateTo", toDate);

                    //string SP_SQL = "HRM_Rpt_UpdateAttendance_Status @DateFrom,@DateTo";
                    string SP_SQL = "HRM_Update_Attendance_Status @DateFrom,@DateTo";
                    _context.ExecuteStoreCommand(SP_SQL, ParamempID, ParamempID1);

                    return 1;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        internal List<Salary_Viewer> GetAllOTInfo(string fromDate)
        {
            try
            {
                using (var _context = new ERPSSLHBEntities())
                {
                    var FromDate = new SqlParameter("@Date_From", fromDate);
                    string SP_SQL = "HRM_RPT_Get_AllOTInfo @Date_From";
                    return (_context.ExecuteStoreQuery<Salary_Viewer>(SP_SQL, FromDate)).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        internal int Insert_Update_AbsentLeaveStatus_ByDate_EID2(List<HRM_OfficialDay_Individual> attendances, DateTime fromDate, DateTime toDate)
        {
            try
            {
                foreach (HRM_OfficialDay_Individual aitem in attendances)
                {
                    var ParamempID = new SqlParameter("@DateFrom", fromDate);
                    var ParamempID1 = new SqlParameter("@DateTo", toDate);
                    var ParamempID2 = new SqlParameter("@EID", aitem.EID);
                    var ParamempID3 = new SqlParameter("@OCODE", aitem.OCode);
                    var ParamempID4 = new SqlParameter("@EditDate", aitem.Edit_Date);
                    var ParamempID5 = new SqlParameter("@EditBy", aitem.Edit_User);
                    string SP_SQL = "HRM_Update_Absent_Leave_Holiday_Status_ByEID @DateFrom,@DateTo,@EID,@OCODE,@EditDate,@EditBy";

                    _context.ExecuteStoreCommand(SP_SQL, ParamempID, ParamempID1, ParamempID2, ParamempID3, ParamempID4, ParamempID5);
                }
                return 1;
            }
            catch (Exception)
            {
                throw;
            }
        }
        internal int Insert_Update_AbsentLeaveStatus_ByDate_EID1(List<HRM_AttendanceReason_Individual> attendances, DateTime fromDate, DateTime toDate)
        {
            try
            {
                foreach (HRM_AttendanceReason_Individual aitem in attendances)
                {
                    var ParamempID = new SqlParameter("@DateFrom", fromDate);
                    var ParamempID1 = new SqlParameter("@DateTo", toDate);
                    var ParamempID2 = new SqlParameter("@EID", aitem.EID);
                    var ParamempID3 = new SqlParameter("@OCODE", aitem.OCode);
                    var ParamempID4 = new SqlParameter("@EditDate", aitem.Edit_Date);
                    var ParamempID5 = new SqlParameter("@EditBy", aitem.Edit_User);
                    string SP_SQL = "HRM_Update_Absent_Leave_Holiday_Status_ByEID @DateFrom,@DateTo,@EID,@OCODE,@EditDate,@EditBy";

                    _context.ExecuteStoreCommand(SP_SQL, ParamempID, ParamempID1, ParamempID2, ParamempID3, ParamempID4, ParamempID5);
                }
                return 1;
            }
            catch (Exception)
            {
                throw;
            }
        }


        internal List<Salary_Viewer> GetSalarySheetSubSectionByCash(int departmentId, string fromDate, int RegionId, int OfficeId, int SectionId, int SubsectionId)
        {
            try
            {
                using (var _context = new ERPSSLHBEntities())
                {
                    var DeptID = new SqlParameter("@Dept", departmentId);
                    var FromDate = new SqlParameter("@Date_From", fromDate);
                    var RegionID = new SqlParameter("@Region", RegionId);
                    var OfficeID = new SqlParameter("@Office", OfficeId);
                    var SectionID = new SqlParameter("@SectionId", SectionId);
                    var SubSectionID = new SqlParameter("@SubSection", SubsectionId);
                    string SP_SQL = "HRM_RPT_Get_SalaryInfoCashBySubSection @Dept, @Date_From , @Region, @Office,@SectionId,@SubSection";
                    return (_context.ExecuteStoreQuery<Salary_Viewer>(SP_SQL, DeptID, FromDate, RegionID, OfficeID, SectionID, SubSectionID)).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        internal List<Salary_Viewer> GetSalarySheetSectionByCash(int departmentId, string fromDate, int RegionId, int OfficeId, int sectionId)
        {
            try
            {
                using (var _context = new ERPSSLHBEntities())
                {
                    var DeptID = new SqlParameter("@Dept", departmentId);
                    var FromDate = new SqlParameter("@Date_From", fromDate);
                    var RegionID = new SqlParameter("@Region", RegionId);
                    var OfficeID = new SqlParameter("@Office", OfficeId);
                    var SectionID = new SqlParameter("@SectionId", sectionId);
                    string SP_SQL = "HRM_RPT_Get_SalaryInfoCashBySection @Dept, @Date_From , @Region, @Office,@SectionId";
                    return (_context.ExecuteStoreQuery<Salary_Viewer>(SP_SQL, DeptID, FromDate, RegionID, OfficeID, SectionID)).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        internal List<Salary_Viewer> GetSalarySheetDepartmentByCash(int departmentId, string fromDate, int RegionId, int OfficeId)
        {
            try
            {
                using (var _context = new ERPSSLHBEntities())
                {
                    var DeptID = new SqlParameter("@Dept", departmentId);
                    var FromDate = new SqlParameter("@Date_From", fromDate);
                    var RegionID = new SqlParameter("@Region", RegionId);
                    var OfficeID = new SqlParameter("@Office", OfficeId);
                    string SP_SQL = "HRM_RPT_Get_SalaryInfoCashByDepartment @Dept, @Date_From , @Region, @Office";
                    return (_context.ExecuteStoreQuery<Salary_Viewer>(SP_SQL, DeptID, FromDate, RegionID, OfficeID)).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        internal List<Salary_Viewer> GetSalarySheetAllByCash(string fromDate)
        {
            try
            {
                using (var _context = new ERPSSLHBEntities())
                {
                    var FromDate = new SqlParameter("@Date_From", fromDate);
                    string SP_SQL = "HRM_RPT_Get_SalaryInfoCashByAll @Date_From";
                    return (_context.ExecuteStoreQuery<Salary_Viewer>(SP_SQL, FromDate)).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        internal List<Salary_Viewer> GetSalarySheetSubSectionByBank(int departmentId, string fromDate, int RegionId, int OfficeId, int SectionId, int SubsectionId)
        {
            try
            {
                using (var _context = new ERPSSLHBEntities())
                {
                    var DeptID = new SqlParameter("@Dept", departmentId);
                    var FromDate = new SqlParameter("@Date_From", fromDate);
                    var RegionID = new SqlParameter("@Region", RegionId);
                    var OfficeID = new SqlParameter("@Office", OfficeId);
                    var SectionID = new SqlParameter("@SectionId", SectionId);
                    var SubSectionID = new SqlParameter("@SubSection", SubsectionId);
                    string SP_SQL = "HRM_RPT_Get_SalaryInfoBankBySubSection @Dept, @Date_From , @Region, @Office,@SectionId,@SubSection";
                    return (_context.ExecuteStoreQuery<Salary_Viewer>(SP_SQL, DeptID, FromDate, RegionID, OfficeID, SectionID, SubSectionID)).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        internal List<Salary_Viewer> GetSalarySheetSectionByBank(int departmentId, string fromDate, int RegionId, int OfficeId, int sectionId)
        {
            try
            {
                using (var _context = new ERPSSLHBEntities())
                {
                    var DeptID = new SqlParameter("@Dept", departmentId);
                    var FromDate = new SqlParameter("@Date_From", fromDate);
                    var RegionID = new SqlParameter("@Region", RegionId);
                    var OfficeID = new SqlParameter("@Office", OfficeId);
                    var SectionID = new SqlParameter("@SectionId", sectionId);
                    string SP_SQL = "HRM_RPT_Get_SalaryInfoBankBySection @Dept, @Date_From , @Region, @Office,@SectionId";
                    return (_context.ExecuteStoreQuery<Salary_Viewer>(SP_SQL, DeptID, FromDate, RegionID, OfficeID, SectionID)).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        internal List<Salary_Viewer> GetSalarySheetDepartmentByBank(int departmentId, string fromDate, int RegionId, int OfficeId)
        {
            try
            {
                using (var _context = new ERPSSLHBEntities())
                {
                    var DeptID = new SqlParameter("@Dept", departmentId);
                    var FromDate = new SqlParameter("@Date_From", fromDate);
                    var RegionID = new SqlParameter("@Region", RegionId);
                    var OfficeID = new SqlParameter("@Office", OfficeId);
                    string SP_SQL = "HRM_RPT_Get_SalaryInfoBankByDepartment @Dept, @Date_From , @Region, @Office";
                    return (_context.ExecuteStoreQuery<Salary_Viewer>(SP_SQL, DeptID, FromDate, RegionID, OfficeID)).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        internal List<Salary_Viewer> GetSalarySheetAllByBank(string fromDate)
        {
            try
            {
                using (var _context = new ERPSSLHBEntities())
                {
                    var FromDate = new SqlParameter("@Date_From", fromDate);
                    string SP_SQL = "HRM_RPT_Get_SalaryInfoBankByAll @Date_From";
                    return (_context.ExecuteStoreQuery<Salary_Viewer>(SP_SQL, FromDate)).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        internal List<Salary_Viewer> GetSalarySheetSubSectionByMobile(int departmentId, string fromDate, int RegionId, int OfficeId, int SectionId, int SubsectionId)
        {
            try
            {
                using (var _context = new ERPSSLHBEntities())
                {
                    var DeptID = new SqlParameter("@Dept", departmentId);
                    var FromDate = new SqlParameter("@Date_From", fromDate);
                    var RegionID = new SqlParameter("@Region", RegionId);
                    var OfficeID = new SqlParameter("@Office", OfficeId);
                    var SectionID = new SqlParameter("@SectionId", SectionId);
                    var SubSectionID = new SqlParameter("@SubSection", SubsectionId);
                    string SP_SQL = "HRM_RPT_Get_SalaryInfoMobileBankBySubSection @Dept, @Date_From , @Region, @Office,@SectionId,@SubSection";
                    return (_context.ExecuteStoreQuery<Salary_Viewer>(SP_SQL, DeptID, FromDate, RegionID, OfficeID, SectionID, SubSectionID)).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        internal List<Salary_Viewer> GetSalarySheetSectionByMobile(int departmentId, string fromDate, int RegionId, int OfficeId, int sectionId)
        {
            try
            {
                using (var _context = new ERPSSLHBEntities())
                {
                    var DeptID = new SqlParameter("@Dept", departmentId);
                    var FromDate = new SqlParameter("@Date_From", fromDate);
                    var RegionID = new SqlParameter("@Region", RegionId);
                    var OfficeID = new SqlParameter("@Office", OfficeId);
                    var SectionID = new SqlParameter("@SectionId", sectionId);
                    string SP_SQL = "HRM_RPT_Get_SalaryInfoMobileBankBySection @Dept, @Date_From , @Region, @Office,@SectionId";
                    return (_context.ExecuteStoreQuery<Salary_Viewer>(SP_SQL, DeptID, FromDate, RegionID, OfficeID, SectionID)).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        internal List<Salary_Viewer> GetSalarySheetDepartmentByMobile(int departmentId, string fromDate, int RegionId, int OfficeId)
        {
            try
            {
                using (var _context = new ERPSSLHBEntities())
                {
                    var DeptID = new SqlParameter("@Dept", departmentId);
                    var FromDate = new SqlParameter("@Date_From", fromDate);
                    var RegionID = new SqlParameter("@Region", RegionId);
                    var OfficeID = new SqlParameter("@Office", OfficeId);
                    string SP_SQL = "HRM_RPT_Get_SalaryInfoMobileBankByDepartment @Dept, @Date_From , @Region, @Office";
                    return (_context.ExecuteStoreQuery<Salary_Viewer>(SP_SQL, DeptID, FromDate, RegionID, OfficeID)).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        internal List<Salary_Viewer> GetSalarySheetAllByMobile(string fromDate)
        {
            try
            {
                using (var _context = new ERPSSLHBEntities())
                {
                    var FromDate = new SqlParameter("@Date_From", fromDate);
                    string SP_SQL = "HRM_RPT_Get_SalaryInfoMobileBankByAll @Date_From";
                    return (_context.ExecuteStoreQuery<Salary_Viewer>(SP_SQL, FromDate)).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        internal int Insert_Update_AbsentLeaveStatus_ByDate_EID(List<HRM_ATTENDANCE> attendances, DateTime fromDate, DateTime toDate)
        {
            try
            {
                foreach (HRM_ATTENDANCE aitem in attendances)
                {
                    var ParamempID = new SqlParameter("@DateFrom", fromDate);
                    var ParamempID1 = new SqlParameter("@DateTo", toDate);
                    var ParamempID2 = new SqlParameter("@EID", aitem.EID);
                    var ParamempID3 = new SqlParameter("@OCODE", aitem.OCode);
                    var ParamempID4 = new SqlParameter("@EditDate", aitem.Edit_Date);
                    var ParamempID5 = new SqlParameter("@EditBy", aitem.Edit_User);
                    string SP_SQL = "HRM_Update_Absent_Leave_Holiday_Status_ByEID @DateFrom,@DateTo,@EID,@OCODE,@EditDate,@EditBy";

                    _context.ExecuteStoreCommand(SP_SQL, ParamempID, ParamempID1, ParamempID2, ParamempID3, ParamempID4, ParamempID5);
                }
                return 1;
            }
            catch (Exception)
            {
                throw;
            }
        }

        internal List<Attendance_Viewer> MonthlyAbsentbyDay(string fromDate, string toDate, int AbsentDay)
        {
            try
            {
                using (var _context = new ERPSSLHBEntities())
                {
                    //var subSecId = new SqlParameter("@SubSection", subSectionid);
                    //var secId = new SqlParameter("@Section", sectionId);
                    //var DeptID = new SqlParameter("@Dept", DeptId);
                    //var OfficeID = new SqlParameter("@Office", OfficeId);
                    //var RegionID = new SqlParameter("@Region", ResionId);
                    var FromDate = new SqlParameter("@startDate", fromDate);
                    var ToDate = new SqlParameter("@endDate", toDate);
                    var _absentDay = new SqlParameter("@AbsentDay", AbsentDay);
                    string SP_SQL = "HRM_Rpt_AllEmployeeAbsentByDay @startDate,@endDate,@AbsentDay";
                    return (_context.ExecuteStoreQuery<Attendance_Viewer>(SP_SQL, FromDate, ToDate, _absentDay)).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        internal List<Attendance_Viewer> MonthlyAbsentbyDayRegionWise(int ResionId, string fromDate, string toDate, int AbsentDay)
        {
            try
            {
                using (var _context = new ERPSSLHBEntities())
                {
                    //var subSecId = new SqlParameter("@SubSection", subSectionid);
                    //var secId = new SqlParameter("@Section", sectionId);
                    //var DeptID = new SqlParameter("@Dept", DeptId);
                    //var OfficeID = new SqlParameter("@Office", OfficeId);
                    var RegionID = new SqlParameter("@Region", ResionId);
                    var FromDate = new SqlParameter("@startDate", fromDate);
                    var ToDate = new SqlParameter("@endDate", toDate);
                    var _absentDay = new SqlParameter("@AbsentDay", AbsentDay);
                    string SP_SQL = "HRM_Rpt_AllEmployeeAbsentByDayRegionWise @Region, @startDate,@endDate,@AbsentDay";
                    return (_context.ExecuteStoreQuery<Attendance_Viewer>(SP_SQL, RegionID, FromDate, ToDate, _absentDay)).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        internal List<Attendance_Viewer> MonthlyAbsentbyDayOfficeWise(int OfficeId, int ResionId, string fromDate, string toDate, int AbsentDay)
        {
            try
            {
                using (var _context = new ERPSSLHBEntities())
                {
                    //var subSecId = new SqlParameter("@SubSection", subSectionid);
                    //var secId = new SqlParameter("@Section", sectionId);
                    //var DeptID = new SqlParameter("@Dept", DeptId);
                    var OfficeID = new SqlParameter("@Office", OfficeId);
                    var RegionID = new SqlParameter("@Region", ResionId);
                    var FromDate = new SqlParameter("@startDate", fromDate);
                    var ToDate = new SqlParameter("@endDate", toDate);
                    var _absentDay = new SqlParameter("@AbsentDay", AbsentDay);
                    string SP_SQL = "HRM_Rpt_AllEmployeeAbsentByDayOfficeWise @Office, @Region, @startDate,@endDate,@AbsentDay";
                    return (_context.ExecuteStoreQuery<Attendance_Viewer>(SP_SQL, OfficeID, RegionID, FromDate, ToDate, _absentDay)).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        internal List<Attendance_Viewer> MonthlyAbsentbyDayDeptWise(int DeptId, int OfficeId, int ResionId, string fromDate, string toDate, int AbsentDay)
        {
            try
            {
                using (var _context = new ERPSSLHBEntities())
                {
                    //var subSecId = new SqlParameter("@SubSection", subSectionid);
                    //var secId = new SqlParameter("@Section", sectionId);
                    var DeptID = new SqlParameter("@Dept", DeptId);
                    var OfficeID = new SqlParameter("@Office", OfficeId);
                    var RegionID = new SqlParameter("@Region", ResionId);
                    var FromDate = new SqlParameter("@startDate", fromDate);
                    var ToDate = new SqlParameter("@endDate", toDate);
                    var _absentDay = new SqlParameter("@AbsentDay", AbsentDay);
                    string SP_SQL = "HRM_Rpt_AllEmployeeAbsentByDayDeptWise @Dept, @Office, @Region, @startDate,@endDate,@AbsentDay";
                    return (_context.ExecuteStoreQuery<Attendance_Viewer>(SP_SQL, DeptID, OfficeID, RegionID, FromDate, ToDate, _absentDay)).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        internal List<Attendance_Viewer> MonthlyAbsentbyDaySectionWise(int secId, int DeptId, int OfficeId, int ResionId, string fromDate, string toDate, int AbsentDay)
        {
            try
            {
                using (var _context = new ERPSSLHBEntities())
                {
                    //var subSecId = new SqlParameter("@SubSection", subSectionid);
                    var SectionID = new SqlParameter("@Section", secId);
                    var DeptID = new SqlParameter("@Dept", DeptId);
                    var OfficeID = new SqlParameter("@Office", OfficeId);
                    var RegionID = new SqlParameter("@Region", ResionId);
                    var FromDate = new SqlParameter("@startDate", fromDate);
                    var ToDate = new SqlParameter("@endDate", toDate);
                    var _absentDay = new SqlParameter("@AbsentDay", AbsentDay);
                    string SP_SQL = "HRM_Rpt_AllEmployeeAbsentByDaySectionWise @Section, @Dept, @Office, @Region, @startDate,@endDate,@AbsentDay";
                    return (_context.ExecuteStoreQuery<Attendance_Viewer>(SP_SQL, SectionID, DeptID, OfficeID, RegionID, FromDate, ToDate, _absentDay)).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        internal List<Attendance_Viewer> MonthlyAbsentbyDaySubSectionWise(int subSectionid, int secId, int DeptId, int OfficeId, int ResionId, string fromDate, string toDate, int AbsentDay)
        {
            try
            {
                using (var _context = new ERPSSLHBEntities())
                {
                    var subSecId = new SqlParameter("@SubSection", subSectionid);
                    var SectionID = new SqlParameter("@Section", secId);
                    var DeptID = new SqlParameter("@Dept", DeptId);
                    var OfficeID = new SqlParameter("@Office", OfficeId);
                    var RegionID = new SqlParameter("@Region", ResionId);
                    var FromDate = new SqlParameter("@startDate", fromDate);
                    var ToDate = new SqlParameter("@endDate", toDate);
                    var _absentDay = new SqlParameter("@AbsentDay", AbsentDay);
                    string SP_SQL = "HRM_Rpt_AllEmployeeAbsentByDaySubSectionWise @SubSection, @Section, @Dept, @Office, @Region, @startDate,@endDate,@AbsentDay";
                    return (_context.ExecuteStoreQuery<Attendance_Viewer>(SP_SQL, subSecId, SectionID, DeptID, OfficeID, RegionID, FromDate, ToDate, _absentDay)).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }


        internal List<Attendance_Viewer> GetPresentAllEmpForAll(string status, string fromDate, string toDate)
        {
            try
            {
                using (var _context = new ERPSSLHBEntities())
                {
                    var Status = new SqlParameter("@status", status);
                    var FromDate = new SqlParameter("@startDate", fromDate);
                    var ToDate = new SqlParameter("@endDate", toDate);
                    string SP_SQL = "HRM_RPT_DailyPresentAll @status,@startDate,@endDate";
                    return (_context.ExecuteStoreQuery<Attendance_Viewer>(SP_SQL, Status, FromDate, ToDate)).ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal List<Attendance_Viewer> GetPresentAllEmpForAllByByOffice(int OfficeId, int ResionId, string status, string fromDate, string toDate)
        {
            try
            {
                using (var _context = new ERPSSLHBEntities())
                {

                    var OfficeID = new SqlParameter("@Office", OfficeId);
                    var RegionID = new SqlParameter("@Region", ResionId);
                    var Status = new SqlParameter("@status", status);
                    var FromDate = new SqlParameter("@startDate", fromDate);
                    var ToDate = new SqlParameter("@endDate", toDate);
                    string SP_SQL = "HRM_RPT_DailyPresentByOffice @Office,@Region,@status,@startDate,@endDate";
                    return (_context.ExecuteStoreQuery<Attendance_Viewer>(SP_SQL, OfficeID, RegionID, Status, FromDate, ToDate)).ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal List<Attendance_Viewer> GetPresentAllEmpForAllByDept(int DeptId, int OfficeId, int ResionId, string status, string fromDate, string toDate)
        {
            try
            {
                using (var _context = new ERPSSLHBEntities())
                {
                    var DeptID = new SqlParameter("@Dept", DeptId);
                    var OfficeID = new SqlParameter("@Office", OfficeId);
                    var RegionID = new SqlParameter("@Region", ResionId);
                    var Status = new SqlParameter("@status", status);
                    var FromDate = new SqlParameter("@startDate", fromDate);
                    var ToDate = new SqlParameter("@endDate", toDate);
                    string SP_SQL = "HRM_RPT_DailyPresentByDept @Dept,@Office,@Region,@status,@startDate,@endDate";
                    return (_context.ExecuteStoreQuery<Attendance_Viewer>(SP_SQL, DeptID, OfficeID, RegionID, Status, FromDate, ToDate)).ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal List<Attendance_Viewer> GetPresentAllEmpForAllBySection(int secId, int DeptId, int OfficeId, int ResionId, string status, string fromDate, string toDate)
        {
            try
            {
                using (var _context = new ERPSSLHBEntities())
                {
                    var sectionId = new SqlParameter("@SectionId", secId);
                    var DeptID = new SqlParameter("@Dept", DeptId);
                    var OfficeID = new SqlParameter("@Office", OfficeId);
                    var RegionID = new SqlParameter("@Region", ResionId);
                    var Status = new SqlParameter("@status", status);
                    var FromDate = new SqlParameter("@startDate", fromDate);
                    var ToDate = new SqlParameter("@endDate", toDate);
                    string SP_SQL = "HRM_RPT_DailyPresentBySection @SectionId,@Dept,@Office,@Region,@status,@startDate,@endDate";
                    return (_context.ExecuteStoreQuery<Attendance_Viewer>(SP_SQL, sectionId, DeptID, OfficeID, RegionID, Status, FromDate, ToDate)).ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal List<Attendance_Viewer> GetPresentAllEmpForAllBySubSection(int subSectionId, int secId, int DeptId, int OfficeId, int ResionId, string status, string fromDate, string toDate)
        {
            try
            {
                using (var _context = new ERPSSLHBEntities())
                {
                    var subSecId = new SqlParameter("@SubSectionId", subSectionId);
                    var sectionId = new SqlParameter("@SectionId", secId);
                    var DeptID = new SqlParameter("@Dept", DeptId);
                    var OfficeID = new SqlParameter("@Office", OfficeId);
                    var RegionID = new SqlParameter("@Region", ResionId);
                    var Status = new SqlParameter("@status", status);
                    var FromDate = new SqlParameter("@startDate", fromDate);
                    var ToDate = new SqlParameter("@endDate", toDate);
                    string SP_SQL = "HRM_RPT_DailyPresentBySubSection @SubSectionId, @SectionId,@Dept,@Office,@Region,@status,@startDate,@endDate";
                    return (_context.ExecuteStoreQuery<Attendance_Viewer>(SP_SQL, subSecId, sectionId, DeptID, OfficeID, RegionID, Status, FromDate, ToDate)).ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal List<Attendance_Viewer> GetAttendanceAllEmpForAllBySubSection_Comp(int subSectionId, int secId, int DeptId, int OfficeId, int ResionId, string fromDate, string toDate)
        {
            try
            {
                using (var _context = new ERPSSLHBEntities())
                {
                    var subSecId = new SqlParameter("@SubSectionId", subSectionId);
                    var SectionId = new SqlParameter("@SectionId", secId);
                    var DeptID = new SqlParameter("@Dept", DeptId);
                    var OfficeID = new SqlParameter("@Office", OfficeId);
                    var RegionID = new SqlParameter("@Region", ResionId);
                    var FromDate = new SqlParameter("@startDate", fromDate);
                    var ToDate = new SqlParameter("@endDate", toDate);
                    string SP_SQL = "HRM_RPT_AttendanceAllEmpDailyBySubSection_Comp @SubSectionId, @SectionId,@Dept,@Office,@Region,@startDate,@endDate";
                    return (_context.ExecuteStoreQuery<Attendance_Viewer>(SP_SQL, subSecId, SectionId, DeptID, OfficeID, RegionID, FromDate, ToDate)).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        internal List<Attendance_Viewer> GetAttendanceAllEmpForAllBySection_Comp(int secId, int DeptId, int OfficeId, int ResionId, string fromDate, string toDate)
        {
            try
            {
                using (var _context = new ERPSSLHBEntities())
                {
                    var SectionId = new SqlParameter("@SectionId", secId);
                    var DeptID = new SqlParameter("@Dept", DeptId);
                    var OfficeID = new SqlParameter("@Office", OfficeId);
                    var RegionID = new SqlParameter("@Region", ResionId);
                    //var Status = new SqlParameter("@status", status);
                    var FromDate = new SqlParameter("@startDate", fromDate);
                    var ToDate = new SqlParameter("@endDate", toDate);
                    string SP_SQL = "HRM_RPT_AttendanceAllEmpDailyBySection_Comp @SectionId,@Dept,@Office,@Region,@startDate,@endDate";
                    return (_context.ExecuteStoreQuery<Attendance_Viewer>(SP_SQL, SectionId, DeptID, OfficeID, RegionID, FromDate, ToDate)).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        internal List<Attendance_Viewer> GetAttendanceAllEmpForAllByDept_Comp(int DeptId, int OfficeId, int ResionId, string fromDate, string toDate)
        {
            try
            {
                using (var _context = new ERPSSLHBEntities())
                {
                    var DeptID = new SqlParameter("@Dept", DeptId);
                    var OfficeID = new SqlParameter("@Office", OfficeId);
                    var RegionID = new SqlParameter("@Region", ResionId);
                    //var Status = new SqlParameter("@status", status);
                    var FromDate = new SqlParameter("@startDate", fromDate);
                    var ToDate = new SqlParameter("@endDate", toDate);
                    string SP_SQL = "HRM_RPT_AttendanceAllEmpDailyByDept_Comp @Dept,@Office,@Region,@startDate,@endDate";
                    return (_context.ExecuteStoreQuery<Attendance_Viewer>(SP_SQL, DeptID, OfficeID, RegionID, FromDate, ToDate)).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        internal List<Attendance_Viewer> GetAttendanceAllEmpForAll_Comp(string fromDate, string toDate)
        {
            try
            {
                using (var _context = new ERPSSLHBEntities())
                {
                    var FromDate = new SqlParameter("@startDate", fromDate);
                    var ToDate = new SqlParameter("@endDate", toDate);
                    string SP_SQL = "HRM_RPT_AttendanceAllEmpDaily_Comp @startDate,@endDate";
                    return (_context.ExecuteStoreQuery<Attendance_Viewer>(SP_SQL, FromDate, ToDate)).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        internal List<Attendance_Viewer> MonthlyOTSummmaryByDept_Comp(int ResionId, int OfficeId, int DeptId, string fromDate, string toDate, string OCODE)
        {
            try
            {
                using (var _context = new ERPSSLHBEntities())
                {
                    var RegionID = new SqlParameter("@RegionId", ResionId);
                    var OfficeID = new SqlParameter("@OfficeId", OfficeId);
                    var DeptID = new SqlParameter("@DepartmentId", DeptId);
                    var FromDate = new SqlParameter("@startDate", fromDate);
                    var ToDate = new SqlParameter("@endDate", toDate);
                    var OCode = new SqlParameter("@OCODE", OCODE);
                    string SP_SQL = "HRM_RPT_OT_Summary_MonthlyBySection_Comp @RegionId,@OfficeId,@DepartmentId,@startDate,@endDate,@OCODE";
                    return (_context.ExecuteStoreQuery<Attendance_Viewer>(SP_SQL, RegionID, OfficeID, DeptID, FromDate, ToDate, OCode)).ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal List<Attendance_Viewer> MonthlyOTByDept_Com(int DeptId, int OfficeId, int ResionId, string fromDate, string toDate, string OCODE)
        {
            try
            {
                using (var _context = new ERPSSLHBEntities())
                {
                    var RegionID = new SqlParameter("@RegionId", ResionId);
                    var OfficeID = new SqlParameter("@OfficeId", OfficeId);
                    var DeptID = new SqlParameter("@DepartmentId", DeptId);
                    var FromDate = new SqlParameter("@startDate", fromDate);
                    var ToDate = new SqlParameter("@endDate", toDate);
                    var OCode = new SqlParameter("@OCODE", OCODE);
                    string SP_SQL = "HRM_Rpt_MonthlyOT_ByDept_Comp @RegionId,@OfficeId,@DepartmentId,@startDate,@endDate,@OCODE";
                    return (_context.ExecuteStoreQuery<Attendance_Viewer>(SP_SQL, RegionID, OfficeID, DeptID, FromDate, ToDate, OCode)).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        internal List<Attendance_Viewer> MonthlyOTAll_Comp(string fromDate, string toDate)
        {
            try
            {
                using (var _context = new ERPSSLHBEntities())
                {
                    var FromDate = new SqlParameter("@startDate", fromDate);
                    var ToDate = new SqlParameter("@endDate", toDate);
                    string SP_SQL = "HRM_Rpt_MonthlyOT_All_Comp @startDate,@endDate";
                    return (_context.ExecuteStoreQuery<Attendance_Viewer>(SP_SQL, FromDate, ToDate)).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        internal List<Salary_Viewer> GetSalarySheetSubSectionWise_Comp(int departmentId, string fromDate, int RegionId, int OfficeId, int SectionId, int SubsectionId)
        {
            try
            {
                using (var _context = new ERPSSLHBEntities())
                {
                    var DeptID = new SqlParameter("@Dept", departmentId);
                    var FromDate = new SqlParameter("@Date_From", fromDate);
                    var RegionID = new SqlParameter("@Region", RegionId);
                    var OfficeID = new SqlParameter("@Office", OfficeId);
                    var SectionID = new SqlParameter("@SectionId", SectionId);
                    var SubSectionID = new SqlParameter("@SubSection", SubsectionId);
                    string SP_SQL = "HRM_RPT_Get_SalaryInfoBySubSection_Comp @Dept, @Date_From , @Region, @Office,@SectionId,@SubSection";
                    return (_context.ExecuteStoreQuery<Salary_Viewer>(SP_SQL, DeptID, FromDate, RegionID, OfficeID, SectionID, SubSectionID)).ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal List<Salary_Viewer> GetSalarySheetSectionWise_Comp(int departmentId, string fromDate, int RegionId, int OfficeId, int SectionId)
        {
            try
            {
                using (var _context = new ERPSSLHBEntities())
                {
                    var DeptID = new SqlParameter("@Dept", departmentId);
                    var FromDate = new SqlParameter("@Date_From", fromDate);
                    var RegionID = new SqlParameter("@Region", RegionId);
                    var OfficeID = new SqlParameter("@Office", OfficeId);
                    var SectionID = new SqlParameter("@SectionId", SectionId);
                    string SP_SQL = "HRM_RPT_Get_SalaryInfoBySection_Comp @Dept, @Date_From , @Region, @Office,@SectionId";
                    return (_context.ExecuteStoreQuery<Salary_Viewer>(SP_SQL, DeptID, FromDate, RegionID, OfficeID, SectionID)).ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal List<Salary_Viewer> GetSalarySheetDeptWise_Comp(int departmentId, string fromDate, string ToDate, int RegionId, int OfficeId)
        {
            try
            {
                using (var _context = new ERPSSLHBEntities())
                {
                    var DeptID = new SqlParameter("@Dept", departmentId);
                    var FromDate = new SqlParameter("@Date_From", fromDate);
                    var TODate = new SqlParameter("@Date_To", ToDate);
                    var RegionID = new SqlParameter("@Region", RegionId);
                    var OfficeID = new SqlParameter("@Office", OfficeId);
                    string SP_SQL = "HRM_RPT_Get_SalaryInfoDeptWise_Comp @Dept, @Date_From ,@Date_To, @Region, @Office";
                    return (_context.ExecuteStoreQuery<Salary_Viewer>(SP_SQL, DeptID, FromDate, TODate, RegionID, OfficeID)).ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal List<Salary_Viewer> GetSalarySheetOfficeWise_Comp(string fromDate, int RegionId, int OfficeId)
        {
            try
            {
                using (var _context = new ERPSSLHBEntities())
                {
                    var FromDate = new SqlParameter("@Date_From", fromDate);
                    var RegionID = new SqlParameter("@Region", RegionId);
                    var OfficeID = new SqlParameter("@Office", OfficeId);
                    string SP_SQL = "HRM_RPT_Get_SalaryInfoOfficeWise_Comp @Date_From , @Region, @Office";
                    return (_context.ExecuteStoreQuery<Salary_Viewer>(SP_SQL, FromDate, RegionID, OfficeID)).ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal List<Salary_Viewer> GetSalarySheetRegionWise_Comp(string fromDate, int RegionId)
        {
            try
            {
                using (var _context = new ERPSSLHBEntities())
                {
                    var FromDate = new SqlParameter("@Date_From", fromDate);
                    var RegionID = new SqlParameter("@Region", RegionId);
                    string SP_SQL = "HRM_RPT_Get_SalaryInfoRegionWise_Comp @Date_From , @Region";
                    return (_context.ExecuteStoreQuery<Salary_Viewer>(SP_SQL, FromDate, RegionID)).ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal List<Salary_Viewer> GetEmployeeIndividualReport_Comp(string fromDate)
        {
            try
            {
                using (var _context = new ERPSSLHBEntities())
                {
                    var FromDate = new SqlParameter("@Date_From", fromDate);
                    string SP_SQL = "HRM_RPT_Get_SalaryInfo_Comp @Date_From";
                    return (_context.ExecuteStoreQuery<Salary_Viewer>(SP_SQL, FromDate)).ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

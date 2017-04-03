using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ERPSSL.HRM.DAL;
using ERPSSL.HRM.DAL.Repository;

namespace ERPSSL.HRM.BLL
{
    public class Attendance_RPT_Bll
    {
        Attendance_RPT_DAL aAttendance_RPT_DAL = new Attendance_RPT_DAL();

        //internal List<Attendance_Viewer> GetPresentAttendenceReport(int RegionId,int OfficeId, int departmentId,string fromDate, string toDate)
        //{
        //    return aAttendance_RPT_DAL.GetPresentAttendenceReport(RegionId, OfficeId, departmentId, fromDate, toDate);
        //}
        internal List<Attendance_Viewer> GetPresentAttendenceReport(int RegionId, string status, string fromDate, string toDate)
        {
            return aAttendance_RPT_DAL.GetPresentAttendenceReport(RegionId, status, fromDate, toDate);
        }
        internal List<Attendance_Viewer> GetOfficeReport(int RegionId, int OfficeId, string status, string fromDate, string toDate)
        {
            return aAttendance_RPT_DAL.GetOfficeReport(RegionId, OfficeId, status, fromDate, toDate);
        }

        internal List<Attendance_Viewer> GetDepartmentReport(int RegionId, int OfficeId, int DeptId, string status, string fromDate, string toDate)
        {
            return aAttendance_RPT_DAL.GetDepartmentReport(RegionId, OfficeId, DeptId, status, fromDate, toDate);
        }
        internal List<Attendance_Viewer> GetShiftCodeReport(int RegionId, int OfficeId, int DeptId, string status, string fromDate, string toDate, string ShiftCode)
        {
            return aAttendance_RPT_DAL.GetShiftCodeReport(RegionId, OfficeId, DeptId, status, fromDate, toDate, ShiftCode);
        }
        internal List<Attendance_Viewer> GetAllShiftCodeReport(string status, string fromDate, string toDate, int ShiftCode)
        {
            return aAttendance_RPT_DAL.GetAllShiftCodeReport(status, fromDate, toDate, ShiftCode);
        }

        internal List<Attendance_Viewer> GetAllRegion(string status, string fromDate, string toDate)
        {
            return aAttendance_RPT_DAL.GetAllRegion(status, fromDate, toDate);
        }

        internal List<Attendance_Viewer> GetEmpIndividualReport(string empId, string status, string fromDate, string toDate)
        {
            return aAttendance_RPT_DAL.GetEmpIndividualReport(empId, status, fromDate, toDate);
        }

        internal List<Attendance_Viewer> Get_EmpIndividual_Compliance_Report(string empId, string status, string fromDate, string toDate)
        {
            return aAttendance_RPT_DAL.Get_EmpIndividual_Compliance_Report(empId, status, fromDate, toDate);
        }

        internal List<Attendance_Viewer> GetAttendanceAllEmpForAll(string fromDate, string toDate)
        {
            return aAttendance_RPT_DAL.GetAttendanceAllEmpForAll(fromDate, toDate);
        }

        internal List<Attendance_Viewer> GetSinglePunchForAll(string fromDate, string toDate)
        {
            return aAttendance_RPT_DAL.GetSinglePunchForAll(fromDate, toDate);
        }
        internal List<Attendance_Viewer> GetAllAttendanceForDateToDate(string today)
        {
            return aAttendance_RPT_DAL.GetAllAttendanceForDateToDate(today);
        }
        internal List<Attendance_Viewer> GetAbsentAllEmpForAll(string status,string fromDate, string toDate)
        {
            return aAttendance_RPT_DAL.GetAbsentAllEmpForAll(status, fromDate, toDate);
        }

        internal List<Attendance_Viewer> GetAttendanceAllEmp(string status, string fromDate, string toDate)
        {
            return aAttendance_RPT_DAL.GetAttendanceAllEmp(status, fromDate, toDate);
        } 

        internal List<Attendance_Viewer> GetAllOtHourCalculationReport(string fromDate, string toDate)
        {
            return aAttendance_RPT_DAL.GetAllOtHourCalculationReport(fromDate, toDate);
        }

        internal List<Attendance_Viewer> GetEmpWiseOTReport(string empId, string fromDate, string toDate)
        {
            return aAttendance_RPT_DAL.GetEmpWiseOTReport(empId, fromDate, toDate);
        }

        internal List<Salary_Viewer> GetEmployeeIndividualReport(string fromDate)
        {
            return aAttendance_RPT_DAL.GetEmployeeIndividualReport(fromDate);
        }


        internal List<Salary_Viewer> GetALLOTReportByOTHour(string fromDate, string overtime)
        {
            return aAttendance_RPT_DAL.GetALLOTReportByOTHour(fromDate, overtime);
        }

        internal List<Attendance_Viewer> GetEmpRegioneWiseOT(int RegionId, string fromDate, string toDate)
        {
            return aAttendance_RPT_DAL.GetEmpRegioneWiseOT(RegionId, fromDate, toDate);
        }

        internal List<Attendance_Viewer> GetRegionWiseAtteAbsentAllEmp(int ResionId, string status, string fromDate, string toDate)
        {
            return aAttendance_RPT_DAL.GetRegionWiseAtteAbsentAllEmp(ResionId, status, fromDate, toDate);
        }

        internal List<Attendance_Viewer> GetRegionWiseAtteLatetAllEmp(int ResionId, string status, string fromDate, string toDate)
        {
            return aAttendance_RPT_DAL.GetRegionWiseAtteLatetAllEmp(ResionId, status, fromDate, toDate);
        }

        internal List<Attendance_Viewer> GetAllAttendanceForEmployee(string fromDate, string toDate)
        {
            return aAttendance_RPT_DAL.GetAllAttendanceForEmployee(fromDate, toDate);
        }

        internal List<Attendance_Viewer> GetAllAttendanceForRegionWise(int ResionId, string fromDate, string toDate)
        {
            return aAttendance_RPT_DAL.GetAllAttendanceForRegionWise(ResionId,fromDate, toDate); 
        }

        internal List<Attendance_Viewer> GetAttendanceAllEmpForAllByRegion(int ResionId, string fromDate, string toDate)
        {
            return aAttendance_RPT_DAL.GetAttendanceAllEmpForAllByRegion(ResionId, fromDate, toDate); 
        }

        internal List<Attendance_Viewer> AttendanceLateAbsentAllEmp(string status, string fromDate, string toDate)
        {
            return aAttendance_RPT_DAL.AttendanceLateAbsentAllEmp(status, fromDate, toDate);
        }

        internal List<Attendance_Viewer> MonthlyAttendanceForLeave(string fromDate, string toDate)
        {
            return aAttendance_RPT_DAL.MonthlyAttendanceForLeave(fromDate, toDate);
        }

        internal List<Attendance_Viewer> MonthlyAttendanceAll(string fromDate, string toDate)
        {
            return aAttendance_RPT_DAL.MonthlyAttendanceAll(fromDate, toDate);
        }

        internal List<Attendance_Viewer> MonthlyAttendanceByDept(int DeptId, int OfficeId, int ResionId, string fromDate, string toDate)
        {
            return aAttendance_RPT_DAL.MonthlyAttendanceByDept(DeptId, OfficeId, ResionId,fromDate, toDate);
        }

        internal List<Attendance_Viewer> MonthlyAttendanceBySection(int setionId, int DeptId, int OfficeId, int ResionId, string fromDate, string toDate)
        {
            return aAttendance_RPT_DAL.MonthlyAttendanceBySection(setionId, DeptId, OfficeId, ResionId, fromDate, toDate);
        }

        internal List<Attendance_Viewer> MonthlyAttendanceBySubSection(int subSectionid,int setionId, int DeptId, int OfficeId, int ResionId, string fromDate, string toDate)
        {
            return aAttendance_RPT_DAL.MonthlyAttendanceBySubSection(subSectionid,setionId, DeptId, OfficeId, ResionId, fromDate, toDate);
        }

        internal List<Attendance_Viewer> MonthlyAttendanceForLeaveforRegion(int ResionId, string fromDate, string toDate)
        {
            return aAttendance_RPT_DAL.MonthlyAttendanceForLeaveforRegion(ResionId, fromDate, toDate);
        }

        internal List<Attendance_Viewer> GetAttendanceAllEmpForAllByOffice(int OfficeId, int ResionId, string fromDate, string toDate)
        {
            return aAttendance_RPT_DAL.GetAttendanceAllEmpForAllByOffice(OfficeId, ResionId, fromDate, toDate); 
        }

        internal List<Salary_Viewer> GetSalarySheetRegionWise(string fromDate, int RegionId)
        {
            return aAttendance_RPT_DAL.GetSalarySheetRegionWise(fromDate, RegionId);
        }
        internal List<Salary_Viewer> GetOTSheetRegionWiseByOTHour(string fromDate, int RegionId, string overtime)
        {
            return aAttendance_RPT_DAL.GetOTSheetRegionWiseByOTHour(fromDate, RegionId, overtime);
        }

        internal List<Salary_Viewer> GetSalarySheetOfficeWise(string fromDate, int RegionId, int OfficeId)
        {
            return aAttendance_RPT_DAL.GetSalarySheetOfficeWise(fromDate, RegionId, OfficeId);
        }
        internal List<Salary_Viewer> GetOTSheetOfficeWiseByOTHour(string fromDate, int RegionId, int OfficeId,string overtime)
        {
            return aAttendance_RPT_DAL.GetOTSheetOfficeWiseByOTHour(fromDate, RegionId, OfficeId,overtime);
        }

        internal List<Salary_Viewer> GetSalaryTopSheetOfficeWise(string fromDate, int RegionId, int OfficeId, string OCODE)
        {
            return aAttendance_RPT_DAL.GetSalaryTopSheetOfficeWise(fromDate, RegionId, OfficeId,OCODE);
        }
        internal List<Salary_Viewer> GetSalaryTopSheetOfficeWise_ByCash(string fromDate, int RegionId, int OfficeId, string OCODE)
        {
            return aAttendance_RPT_DAL.GetSalaryTopSheetOfficeWise_ByCash(fromDate, RegionId, OfficeId, OCODE);
        }
        internal List<Salary_Viewer> GetSalaryTopSheetOfficeWise_ByBank(string fromDate, int RegionId, int OfficeId, string OCODE)
        {
            return aAttendance_RPT_DAL.GetSalaryTopSheetOfficeWise_ByBank(fromDate, RegionId, OfficeId, OCODE);
        }
        internal List<Salary_Viewer> GetSalaryTopSheetOfficeWise_ByMobileBank(string fromDate, int RegionId, int OfficeId, string OCODE)
        {
            return aAttendance_RPT_DAL.GetSalaryTopSheetOfficeWise_ByMobileBank(fromDate, RegionId, OfficeId, OCODE);
        }

        internal List<Salary_Viewer> GetSalaryTopSheetRegionWise(string fromDate, int RegionId)
        {
            return aAttendance_RPT_DAL.GetSalaryTopSheetRegionWise(fromDate, RegionId);
        }
        
        internal List<Salary_Viewer> GetSalaryTopSheetDepartmentWise(string fromDate, int RegionId, int OfficeId, int departmentId, string OCODE)
        {
            return aAttendance_RPT_DAL.GetSalaryTopSheetDepartmentWise(fromDate, RegionId, OfficeId, departmentId, OCODE);
        }

        internal  List<Attendance_Viewer> GetAttendanceAllEmpForAllByDept(int DeptId, int OfficeId, int ResionId, string fromDate, string toDate)
        {
            return aAttendance_RPT_DAL.GetAttendanceAllEmpForAllByDept(DeptId, OfficeId, ResionId, fromDate, toDate); 
        }

        internal List<Attendance_Viewer> GetSinglePunchByDept(int DeptId, int OfficeId, int ResionId, string fromDate, string toDate)
        {
            return aAttendance_RPT_DAL.GetSinglePunchByDept(DeptId, OfficeId, ResionId, fromDate, toDate);
        }

        internal List<Attendance_Viewer> GetAbsentAllEmpForAllByDept(int DeptId, int OfficeId, int ResionId, string status,string fromDate, string toDate)
        {
            return aAttendance_RPT_DAL.GetAbsentAllEmpForAllByDept(DeptId, OfficeId, ResionId, status, fromDate, toDate);
        }

        internal List<Attendance_Viewer> GetAttendanceAllEmpForAllBySection(int secId,int DeptId, int OfficeId, int ResionId, string fromDate, string toDate)
        {
            return aAttendance_RPT_DAL.GetAttendanceAllEmpForAllBySection(secId,DeptId, OfficeId, ResionId, fromDate, toDate);
        }

        internal List<Attendance_Viewer> GetSinglePunchBySection(int secId, int DeptId, int OfficeId, int ResionId, string fromDate, string toDate)
        {
            return aAttendance_RPT_DAL.GetSinglePunchBySection(secId, DeptId, OfficeId, ResionId, fromDate, toDate);
        }

        internal List<Attendance_Viewer> GetAbsentAllEmpForAllBySection(int secId, int DeptId, int OfficeId, int ResionId,string status, string fromDate, string toDate)
        {
            return aAttendance_RPT_DAL.GetAbsentAllEmpForAllBySection(secId, DeptId, OfficeId, ResionId,status, fromDate, toDate);
        }

        internal List<Attendance_Viewer> GetAttendanceAllEmpForAllBySubSection(int subSectionId,int secId, int DeptId, int OfficeId, int ResionId, string fromDate, string toDate)
        {
            return aAttendance_RPT_DAL.GetAttendanceAllEmpForAllBySubSection(subSectionId,secId, DeptId, OfficeId, ResionId, fromDate, toDate);
        }
        internal int Insert_Update_AbsentLeaveStatus_ByDate_EID1(List<HRM_AttendanceReason_Individual> attendances, DateTime fromDate, DateTime toDate)
        {
            return aAttendance_RPT_DAL.Insert_Update_AbsentLeaveStatus_ByDate_EID1(attendances, fromDate, toDate);
        }

        internal List<Attendance_Viewer> GetSinglePunchListBySubSection(int subSectionId, int secId, int DeptId, int OfficeId, int ResionId, string fromDate, string toDate)
        {
            return aAttendance_RPT_DAL.GetSinglePunchListBySubSection(subSectionId, secId, DeptId, OfficeId, ResionId, fromDate, toDate);
        }

        internal List<Attendance_Viewer> GetAbsentAllEmpForAllBySubSection(int subSectionId, int secId, int DeptId, int OfficeId, int ResionId, string status, string fromDate, string toDate)
        {
            return aAttendance_RPT_DAL.GetAbsentAllEmpForAllBySubSection(subSectionId, secId, DeptId, OfficeId, ResionId,status, fromDate, toDate);
        }

        internal  List<Attendance_Viewer> MonthlyAttendanceForLeaveforOffice(int OfficeId, int ResionId, string fromDate, string toDate)
        {
            return aAttendance_RPT_DAL.MonthlyAttendanceForLeaveforOffice(OfficeId, ResionId, fromDate, toDate); 
        }

        internal List<Attendance_Viewer> MonthlyAttendanceForLeaveforDept(int DeptId, int OfficeId, int ResionId, string fromDate, string toDate)
        {
            return aAttendance_RPT_DAL.MonthlyAttendanceForLeaveforDept(DeptId, OfficeId, ResionId, fromDate, toDate); 
        }

        internal List<Attendance_Viewer> DailyAttendanceSummmaryByDept(int DeptId, int OfficeId, int ResionId, string fromDate, string toDate)
        {
            return aAttendance_RPT_DAL.DailyAttendanceSummmaryByDept(DeptId, OfficeId, ResionId, fromDate, toDate);
        }

        internal List<Attendance_Viewer> MonthlyAttendanceSummmaryByDept(int DeptId, int OfficeId, int ResionId, string fromDate, string toDate)
        {
            return aAttendance_RPT_DAL.MonthlyAttendanceSummmaryByDept(DeptId, OfficeId, ResionId, fromDate, toDate);
        }

        internal List<Attendance_Viewer> DailyAttendanceSummmaryByDept_Designationwise(int DeptId, int OfficeId, int ResionId, string fromDate, string toDate)
        {
            return aAttendance_RPT_DAL.DailyAttendanceSummmaryByDept_Designationwise(DeptId, OfficeId, ResionId, fromDate, toDate);
        }

        internal List<Attendance_Viewer> DailyAttendanceSummmaryBySection(int secId, int DeptId, int OfficeId, int ResionId, string fromDate, string toDate)
        {
            return aAttendance_RPT_DAL.DailyAttendanceSummmaryBySection(secId, DeptId, OfficeId, ResionId, fromDate, toDate);
        }

        internal List<Attendance_Viewer> MonthlyAttendanceSummmaryBySection(int secId, int DeptId, int OfficeId, int ResionId, string fromDate, string toDate)
        {
            return aAttendance_RPT_DAL.MonthlyAttendanceSummmaryBySection(secId, DeptId, OfficeId, ResionId, fromDate, toDate);
        }

        internal List<Attendance_Viewer> DailyAttendanceSummmaryBySection_Designationwise(int secId, int DeptId, int OfficeId, int ResionId, string fromDate, string toDate)
        {
            return aAttendance_RPT_DAL.DailyAttendanceSummmaryBySection_Designationwise(secId, DeptId, OfficeId, ResionId, fromDate, toDate);
        }

        internal List<Attendance_Viewer> MonthlyPresentBySection(int secId, int DeptId, int OfficeId, int ResionId, string fromDate, string toDate)
        {
            return aAttendance_RPT_DAL.MonthlyPresentBySection(secId, DeptId, OfficeId, ResionId, fromDate, toDate);
        }

        internal List<Attendance_Viewer> MonthlyPresentBySubSection(int subSectionId, int secId, int DeptId, int OfficeId, int ResionId, string fromDate, string toDate)
        {
            return aAttendance_RPT_DAL.MonthlyPresentBySubSection(subSectionId, secId, DeptId, OfficeId, ResionId, fromDate, toDate);
        }

        internal List<Attendance_Viewer> MonthlyAbsentBySubSection(int subSectionId, int secId, int DeptId, int OfficeId, int ResionId, string fromDate, string toDate)
        {
            return aAttendance_RPT_DAL.MonthlyAbsentBySubSection(subSectionId, secId, DeptId, OfficeId, ResionId, fromDate, toDate);
        }

        internal  List<Attendance_Viewer> GetOfficeWiseAtteAbsentAllEmp(int OfficeId, int ResionId, string status, string fromDate, string toDate)
        {
            return aAttendance_RPT_DAL.GetOfficeWiseAtteAbsentAllEmp(OfficeId, ResionId, status, fromDate, toDate); 

        }
        internal List<Attendance_Viewer> GetOfficeWiseAtteLatetAllEmp(int OfficeId, int ResionId, string status, string fromDate, string toDate)
        {
            return aAttendance_RPT_DAL.GetOfficeWiseAtteLatetAllEmp(OfficeId, ResionId, status, fromDate, toDate); 
        }

        internal List<Attendance_Viewer> GetDeptWiseAtteAbsentAllEmp(int DeptId, int OfficeId, int ResionId, string status, string fromDate, string toDate)
        {
            return aAttendance_RPT_DAL.GetDeptWiseAtteAbsentAllEmp(DeptId, OfficeId, ResionId, status, fromDate, toDate); 
        }

        internal List<Attendance_Viewer> GetDeptWiseAtteLatetAllEmp(int DeptId, int OfficeId, int ResionId, string status, string fromDate, string toDate)
        {
            return aAttendance_RPT_DAL.GetDeptWiseAtteLatetAllEmp(DeptId, OfficeId, ResionId, status, fromDate, toDate); 

        }

        internal List<Salary_Viewer> GetSalarySheetDeptWise(int departmentId, string fromDate, string ToDate, int RegionId, int OfficeId)
        {
            return aAttendance_RPT_DAL.GetSalarySheetDeptWise(departmentId, fromDate,ToDate, RegionId, OfficeId);
        }
        internal List<Salary_Viewer> GetOTSheetDeptWiseByOTHour(int departmentId, string fromDate, string ToDate, int RegionId, int OfficeId,string overtime)
        {
            return aAttendance_RPT_DAL.GetOTSheetDeptWiseByOTHour(departmentId, fromDate, ToDate, RegionId, OfficeId, overtime);
        }


        internal List<Salary_Viewer> GetSalarySheetSectionWise(int departmentId, string fromDate, int RegionId, int OfficeId, int SectionId)
        {
            return aAttendance_RPT_DAL.GetSalarySheetSectionWise(departmentId, fromDate, RegionId, OfficeId, SectionId);
        }

        internal List<Salary_Viewer> GetOTSheetSectionWiseByOTHour(int departmentId, string fromDate, int RegionId, int OfficeId, int SectionId,string overtime)
        {
            return aAttendance_RPT_DAL.GetOTSheetSectionWiseByOTHour(departmentId, fromDate, RegionId, OfficeId, SectionId, overtime);
        }

        internal List<Salary_Viewer> GetSalarySheetSubSectionWise(int departmentId, string fromDate, int RegionId, int OfficeId, int SectionId,int SubsectionId)
        {
            return aAttendance_RPT_DAL.GetSalarySheetSubSectionWise(departmentId, fromDate, RegionId, OfficeId, SectionId, SubsectionId);
        }

        internal List<Salary_Viewer> GetOTSheetSubSectionWiseByOTHour(int departmentId, string fromDate, int RegionId, int OfficeId, int SectionId, int SubsectionId, string overtime)
        {
            return aAttendance_RPT_DAL.GetOTSheetSubSectionWiseByOTHour(departmentId, fromDate, RegionId, OfficeId, SectionId, SubsectionId, overtime);
        }

        internal int UpdateAttStatus_ByDate(DateTime fromDate, DateTime toDate)
        {
            return aAttendance_RPT_DAL.UpdateAttStatus_ByDate(fromDate, toDate);
        }

        internal int Update_AbsentLeaveStatus_ByDate(DateTime fromDate, DateTime toDate, string OCODE, DateTime editdate, Guid userid)
        {
            return aAttendance_RPT_DAL.Update_AbsentLeaveStatus_ByDate(fromDate, toDate, OCODE, editdate, userid);
        }

        internal List<Attendance_Viewer> GetAllEmployeeLeave(string today)
        {
            return aAttendance_RPT_DAL.GetAllEmployeeLeave(today);
        }


        internal List<Attendance_Viewer> GetrdAttendanceOTRegisterReport(string fromDate, string toDate)
        {
            return aAttendance_RPT_DAL.GetrdAttendanceOTRegisterReport(fromDate, toDate);
        }

        internal List<Attendance_Viewer> GetrdAttendanceOTRegisterReportBySubSection(int subsection,int secId, int DeptId, int OfficeId, int ResionId, string fromDate, string toDate)
        {
            return aAttendance_RPT_DAL.GetrdAttendanceOTRegisterReportBySubSection(subsection,secId, DeptId, OfficeId, ResionId, fromDate, toDate);
        }

        internal List<Attendance_Viewer> GetrdAttendanceOTRegisterReportBySection(int secId, int DeptId, int OfficeId, int ResionId, string fromDate, string toDate)
        {
            return aAttendance_RPT_DAL.GetrdAttendanceOTRegisterReportBySection(secId, DeptId, OfficeId, ResionId, fromDate, toDate);
        }

        internal List<Attendance_Viewer> GetrdAttendanceOTRegisterReportByDepartment( int DeptId, int OfficeId, int ResionId, string fromDate, string toDate)
        {
            return aAttendance_RPT_DAL.GetrdAttendanceOTRegisterReportByDepartment(DeptId, OfficeId, ResionId, fromDate, toDate);
        }

        internal List<Attendance_Viewer> DailyAttendanceSummmaryByOffice(int OfficeId, int ResionId, string fromDate, string toDate)
        {
            return aAttendance_RPT_DAL.DailyAttendanceSummmaryByOffice(OfficeId, ResionId, fromDate, toDate);
        }

        internal List<Attendance_Viewer> GetAbsentAllEmpForAllByByOffice(int OfficeId, int ResionId, string status, string fromDate, string toDate)
        {
            return aAttendance_RPT_DAL.GetAbsentAllEmpForAllByByOffice(OfficeId, ResionId, status, fromDate, toDate);
        }

        internal int Insert_AllAbsentLeaveStatus_ByDate(DateTime fromDate, DateTime toDate, string OCODE, DateTime editdate, Guid userid)
        {
            return aAttendance_RPT_DAL.Insert_AllAbsentLeaveStatus_ByDate(fromDate, toDate, OCODE, editdate, userid);
        }
        internal int UpdateAll_AttStatus_ByDate(DateTime fromDate, DateTime toDate)
        {
            return aAttendance_RPT_DAL.UpdateAll_AttStatus_ByDate(fromDate, toDate);
        }

        internal List<Salary_Viewer> GetAllOTInfo(string fromDate)
        {
            return aAttendance_RPT_DAL.GetAllOTInfo(fromDate);
        }
        internal int Insert_Update_AbsentLeaveStatus_ByDate_EID2(List<HRM_OfficialDay_Individual> attendances, DateTime fromDate, DateTime toDate)
        {
            return aAttendance_RPT_DAL.Insert_Update_AbsentLeaveStatus_ByDate_EID2(attendances, fromDate, toDate);
        }


        internal List<Salary_Viewer> GetSalarySheetSubSectionByCash(int departmentId, string fromDate, int RegionId, int OfficeId, int sectionId, int subSectionId)
        {
            return aAttendance_RPT_DAL.GetSalarySheetSubSectionByCash(departmentId, fromDate, RegionId, OfficeId, sectionId, subSectionId);
        }

        internal List<Salary_Viewer> GetSalarySheetSectionByCash(int departmentId, string fromDate, int RegionId, int OfficeId, int sectionId)
        {
            return aAttendance_RPT_DAL.GetSalarySheetSectionByCash(departmentId, fromDate, RegionId, OfficeId, sectionId);
        }

        internal List<Salary_Viewer> GetSalarySheetDepartmentByCash(int departmentId, string fromDate, string toDate, int RegionId, int OfficeId)
        {
            return aAttendance_RPT_DAL.GetSalarySheetDepartmentByCash(departmentId, fromDate, RegionId, OfficeId);
        }

        internal List<Salary_Viewer> GetSalarySheetAllByCash(string fromDate)
        {
            return aAttendance_RPT_DAL.GetSalarySheetAllByCash(fromDate);
        }

        internal List<Salary_Viewer> GetSalarySheetSubSectionByBank(int departmentId, string fromDate, int RegionId, int OfficeId, int sectionId, int subSectionId)
        {
            return aAttendance_RPT_DAL.GetSalarySheetSubSectionByBank(departmentId, fromDate, RegionId, OfficeId, sectionId, subSectionId);
        }

        internal List<Salary_Viewer> GetSalarySheetSectionByBank(int departmentId, string fromDate, int RegionId, int OfficeId, int sectionId)
        {
            return aAttendance_RPT_DAL.GetSalarySheetSectionByBank(departmentId, fromDate, RegionId, OfficeId, sectionId);
        }

        internal List<Salary_Viewer> GetSalarySheetDepartmentByBank(int departmentId, string fromDate, string toDate, int RegionId, int OfficeId)
        {
            return aAttendance_RPT_DAL.GetSalarySheetDepartmentByBank(departmentId, fromDate, RegionId, OfficeId);
        }

        internal List<Salary_Viewer> GetSalarySheetAllByBank(string fromDate)
        {
            return aAttendance_RPT_DAL.GetSalarySheetAllByBank(fromDate);
        }
        internal List<Salary_Viewer> GetSalarySheetSubSectionByMobile(int departmentId, string fromDate, int RegionId, int OfficeId, int sectionId, int subSectionId)
        {
            return aAttendance_RPT_DAL.GetSalarySheetSubSectionByMobile(departmentId, fromDate, RegionId, OfficeId, sectionId, subSectionId);
        }

        internal List<Salary_Viewer> GetSalarySheetSectionByMobile(int departmentId, string fromDate, int RegionId, int OfficeId, int sectionId)
        {
            return aAttendance_RPT_DAL.GetSalarySheetSectionByMobile(departmentId, fromDate, RegionId, OfficeId, sectionId);
        }

        internal List<Salary_Viewer> GetSalarySheetDepartmentByMobile(int departmentId, string fromDate, string toDate, int RegionId, int OfficeId)
        {
            return aAttendance_RPT_DAL.GetSalarySheetDepartmentByMobile(departmentId, fromDate, RegionId, OfficeId);
        }

        internal List<Salary_Viewer> GetSalarySheetAllByMobile(string fromDate)
        {
            return aAttendance_RPT_DAL.GetSalarySheetAllByMobile(fromDate);
        }

        internal int Insert_Update_AbsentLeaveStatus_ByDate_EID(List<HRM_ATTENDANCE> attendances, DateTime fromDate, DateTime toDate)
        {
            return aAttendance_RPT_DAL.Insert_Update_AbsentLeaveStatus_ByDate_EID(attendances, fromDate, toDate);
        }

        internal List<Attendance_Viewer> MonthlyAbsentbyDay(string fromDate, string toDate, int AbsentDay)
        {
            return aAttendance_RPT_DAL.MonthlyAbsentbyDay(fromDate, toDate, AbsentDay);
        }

        internal List<Attendance_Viewer> MonthlyAbsentbyDayRegionWise(int ResionId, string fromDate, string toDate, int AbsentDay)
        {
            return aAttendance_RPT_DAL.MonthlyAbsentbyDayRegionWise(ResionId, fromDate, toDate, AbsentDay);
        }

        internal List<Attendance_Viewer> MonthlyAbsentbyDayOfficeWise(int OfficeId, int ResionId, string fromDate, string toDate, int AbsentDay)
        {
            return aAttendance_RPT_DAL.MonthlyAbsentbyDayOfficeWise(OfficeId, ResionId, fromDate, toDate, AbsentDay);
        }

        internal List<Attendance_Viewer> MonthlyAbsentbyDayDeptWise(int DeptId, int OfficeId, int ResionId, string fromDate, string toDate, int AbsentDay)
        {
            return aAttendance_RPT_DAL.MonthlyAbsentbyDayDeptWise(DeptId, OfficeId, ResionId, fromDate, toDate, AbsentDay);
        }

        internal List<Attendance_Viewer> MonthlyAbsentbyDaySectionWise(int secId, int DeptId, int OfficeId, int ResionId, string fromDate, string toDate, int AbsentDay)
        {
            return aAttendance_RPT_DAL.MonthlyAbsentbyDaySectionWise(secId, DeptId, OfficeId, ResionId, fromDate, toDate, AbsentDay);
        }

        internal List<Attendance_Viewer> MonthlyAbsentbyDaySubSectionWise(int subSectionid, int secId, int DeptId, int OfficeId, int ResionId, string fromDate, string toDate, int AbsentDay)
        {
            return aAttendance_RPT_DAL.MonthlyAbsentbyDaySubSectionWise(subSectionid, secId, DeptId, OfficeId, ResionId, fromDate, toDate, AbsentDay);
        }
        
        internal List<Attendance_Viewer> GetPresentAllEmpForAll(string status, string fromDate, string toDate)
        {
            return aAttendance_RPT_DAL.GetPresentAllEmpForAll(status, fromDate, toDate);
        }

        internal List<Attendance_Viewer> GetPresentAllEmpForAllByByOffice(int OfficeId, int ResionId, string status, string fromDate, string toDate)
        {
            return aAttendance_RPT_DAL.GetPresentAllEmpForAllByByOffice(OfficeId, ResionId, status, fromDate, toDate);
        }

        internal List<Attendance_Viewer> GetPresentAllEmpForAllByDept(int DeptId, int OfficeId, int ResionId, string status, string fromDate, string toDate)
        {
            return aAttendance_RPT_DAL.GetPresentAllEmpForAllByDept(DeptId, OfficeId, ResionId, status, fromDate, toDate);
        }

        internal List<Attendance_Viewer> GetPresentAllEmpForAllBySection(int secId, int DeptId, int OfficeId, int ResionId, string status, string fromDate, string toDate)
        {
            return aAttendance_RPT_DAL.GetPresentAllEmpForAllBySection(secId, DeptId, OfficeId, ResionId, status, fromDate, toDate);
        }

        internal List<Attendance_Viewer> GetPresentAllEmpForAllBySubSection(int subSectionId, int secId, int DeptId, int OfficeId, int ResionId, string status, string fromDate, string toDate)
        {
            return aAttendance_RPT_DAL.GetPresentAllEmpForAllBySubSection(subSectionId, secId, DeptId, OfficeId, ResionId, status, fromDate, toDate);
        }

        internal List<Attendance_Viewer> GetAttendanceAllEmpForAllBySubSection_Comp(int subSectionId, int secId, int DeptId, int OfficeId, int ResionId, string fromDate, string toDate)
        {
            return aAttendance_RPT_DAL.GetAttendanceAllEmpForAllBySubSection_Comp(subSectionId, secId, DeptId, OfficeId, ResionId, fromDate, toDate);
        }

        internal List<Attendance_Viewer> GetAttendanceAllEmpForAllBySection_Comp(int secId, int DeptId, int OfficeId, int ResionId, string fromDate, string toDate)
        {
            return aAttendance_RPT_DAL.GetAttendanceAllEmpForAllBySection_Comp(secId, DeptId, OfficeId, ResionId, fromDate, toDate);
        }

        internal List<Attendance_Viewer> GetAttendanceAllEmpForAllByDept_Comp(int DeptId, int OfficeId, int ResionId, string fromDate, string toDate)
        {
            return aAttendance_RPT_DAL.GetAttendanceAllEmpForAllByDept_Comp(DeptId, OfficeId, ResionId, fromDate, toDate);
        }

        internal List<Attendance_Viewer> GetAttendanceAllEmpForAll_Comp(string fromDate, string toDate)
        {
            return aAttendance_RPT_DAL.GetAttendanceAllEmpForAll_Comp(fromDate, toDate);
        }

        internal List<Attendance_Viewer> MonthlyOTSummmaryByDept_Comp(int ResionId, int OfficeId, int DeptId, string fromDate, string toDate, string OCODE)
        {
            return aAttendance_RPT_DAL.MonthlyOTSummmaryByDept_Comp(ResionId, OfficeId, DeptId, fromDate, toDate, OCODE);
        }

        internal List<Attendance_Viewer> MonthlyOTAll_Comp(string fromDate, string toDate)
        {
            return aAttendance_RPT_DAL.MonthlyOTAll_Comp(fromDate, toDate);
        }

        internal List<Attendance_Viewer> MonthlyOTByDept_Com(int DeptId, int OfficeId, int ResionId, string fromDate, string toDate, string OCODE)
        {
            return aAttendance_RPT_DAL.MonthlyOTByDept_Com(DeptId, OfficeId, ResionId, fromDate, toDate, OCODE);
        }

        internal List<Salary_Viewer> GetSalarySheetSubSectionWise_Comp(int departmentId, string fromDate, int RegionId, int OfficeId, int SectionId, int SubsectionId)
        {
            return aAttendance_RPT_DAL.GetSalarySheetSubSectionWise_Comp(departmentId, fromDate, RegionId, OfficeId, SectionId, SubsectionId);
        }

        internal List<Salary_Viewer> GetSalarySheetSectionWise_Comp(int departmentId, string fromDate, int RegionId, int OfficeId, int SectionId)
        {
            return aAttendance_RPT_DAL.GetSalarySheetSectionWise_Comp(departmentId, fromDate, RegionId, OfficeId, SectionId);
        }

        internal List<Salary_Viewer> GetSalarySheetDeptWise_Comp(int departmentId, string fromDate, string ToDate, int RegionId, int OfficeId)
        {
            return aAttendance_RPT_DAL.GetSalarySheetDeptWise_Comp(departmentId, fromDate, ToDate, RegionId, OfficeId);
        }

        internal List<Salary_Viewer> GetSalarySheetOfficeWise_Comp(string fromDate, int RegionId, int OfficeId)
        {
            return aAttendance_RPT_DAL.GetSalarySheetOfficeWise_Comp(fromDate, RegionId, OfficeId);
        }

        internal List<Salary_Viewer> GetSalarySheetRegionWise_Comp(string fromDate, int RegionId)
        {
            return aAttendance_RPT_DAL.GetSalarySheetRegionWise_Comp(fromDate, RegionId);
        }

        internal List<Salary_Viewer> GetEmployeeIndividualReport_Comp(string fromDate)
        {
            return aAttendance_RPT_DAL.GetEmployeeIndividualReport_Comp(fromDate);
        }

    } 
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ERPSSL.HRM.DAL;
using ERPSSL.PAYROLL.DAL.Repository;

namespace ERPSSL.HRM.BLL
{
    public class Attendance_BLL
    {
        Attendance_DAL objCtx_DAL = new Attendance_DAL();

        //-------Insert------------------------------------
        public int InsertAttendance(HRM_ATTENDANCE objAtt)
        {
            return objCtx_DAL.InsertAttendance(objAtt);
        }

        public int InsertOTperiodic(HRM_TimeInoutOTCalculation objOTperiodic )
        {
            return objCtx_DAL.InsertOTperiodic(objOTperiodic);
        }

        public int InsertOffialType(HRM_OfficialDay objOfficialDay)
        {
            return objCtx_DAL.InsertOfficeType(objOfficialDay); 
        }

        public int InsertMachineProblem(HRM_MachineReadableProblem aHRM_MachineReadableProblem)
        {
            return objCtx_DAL.InsertMachineProblem(aHRM_MachineReadableProblem);
        }
        internal List<HRM_EMPLOYEES_VIEWER> GetEmployeeByID(string eid)
        {
            return objCtx_DAL.GetEmployeeByID(eid);
        }

        internal int UpdateAtt_WorkingDay(string OCODE, string dateTime, string workingDay)
        {
            return objCtx_DAL.UpdateAtt_WorkingDay(OCODE, dateTime, workingDay);
        }

        internal int UpdateOT_ByDate(DateTime fromDate, DateTime toDate)
        {
            return objCtx_DAL.UpdateOT_ByDate(fromDate, toDate);
        }
        internal List<HRM_EMPLOYEES_VIEWER> GetEmployeesByEidForAttendance(string eid, DateTime fromDate, DateTime toDate)
        {
            return objCtx_DAL.GetEmployeesByEidForAttendance(eid, fromDate, toDate);
        }

        internal int UpdateAttStatus_ByDate(DateTime fromDate, DateTime toDate, string shiftCode)
        {
            return objCtx_DAL.UpdateAttStatus_ByDate(fromDate, toDate, shiftCode);
        }

        internal int Update_AbsentLeaveStatus_ByDate(DateTime fromDate, DateTime toDate, string shiftCode, string OCODE, DateTime editdate, Guid userid)
        {
            return objCtx_DAL.Update_AbsentLeaveStatus_ByDate(fromDate, toDate, shiftCode, OCODE, editdate, userid);
        }

        internal int UpdateOTperiodic_ByDate(DateTime fromDate, DateTime toDate,string OCODE)
        {
            return objCtx_DAL.UpdateOTperiodic_ByDate(fromDate, toDate,OCODE);
        }

        internal int InsertAtt_MachineProblem(HRM_ATTENDANCE objAttendance)
        {
            return objCtx_DAL.InsertAtt_MachineProblem(objAttendance);
        }

        internal int UpdateAttendance(HRM_ATTENDANCE objAttendance, int attId)
        {
            return objCtx_DAL.UpdateAttendance(attId, objAttendance);
        }

        internal int UpdateAttendanceOT(HRM_ATTENDANCE objAttendance, int attId)
        {
            return objCtx_DAL.UpdateAttendanceOT(attId, objAttendance);
        }
        internal List<HRM_EMPLOYEES_VIEWER> GetEmployeeByDepartmentID(int RegionId, int OfficeId, int DeptId, DateTime CurrentDate)
        {
            return objCtx_DAL.GetEmployeeByDepartmentID(RegionId, OfficeId, DeptId, CurrentDate);
        }
        internal List<HRM_EMPLOYEES_VIEWER> GetEmployeeBySectionId(int RegionId, int OfficeId, int DeptId, int sctionID, DateTime currentdate)
        {
            return objCtx_DAL.GetEmployeeBySectionId(RegionId, OfficeId, DeptId, sctionID, currentdate);
        }

        //-------GetAll------------------------------------
        public virtual List<HRM_ATTENDANCE> GetAllAttendance(string OCODE)
        {
            return objCtx_DAL.GetAllAttendance(OCODE);
        }

        public virtual List<HRM_ATTENDANCE> GetAttendanceByShift_Date(string OCODE, string ShiftCode)
        {
            return objCtx_DAL.GetAttendanceByShift_Date(OCODE,ShiftCode);
        }

        public virtual List<HRM_ATTENDANCE> GetAttendanceByEID(string OCODE, string eID)
        {
            return objCtx_DAL.GetAttendanceByEID(OCODE, eID);
        }
        public virtual List<HRM_ATTENDANCE> GetAttendanceByEIDByDate(string OCODE, string eID, DateTime date)
        {
            return objCtx_DAL.GetAttendanceByEIDByDate(OCODE, eID, date);
        }

        public virtual List<HRM_ATTENDANCE> GetAttendanceByEID(string eid)
        {
            return objCtx_DAL.GetAttendanceByEID(eid);
        }

        internal List<HRM_ATTENDANCE> GetAttendanceById(string attId, string OCODE)
        {
            return objCtx_DAL.GetAttendanceById(attId, OCODE);
        }

        public virtual List<HRM_ATTENDANCE> GetAllAttendanceByDate(string OCODE, DateTime date)
        {
            return objCtx_DAL.GetAllAttendanceByDate(OCODE, date);
        }

        public virtual List<HRM_OfficialDay> GetAllOfficeDay(string OCODE, DateTime date)
        {
            return objCtx_DAL.GetAllOfficeDay(OCODE,date);
        }

        public virtual List<HRM_MachineReadableProblem> GetAllMachineProblem(string OCODE)
        {
            return objCtx_DAL.GetAllMachineProblem(OCODE);
        }
        internal List<HRM_EMPLOYEES_VIEWER> GetEmployeeByRODSSUID(int ResionId, int OfficeId, int DeptId, int sction, int subsction)
        {

            return objCtx_DAL.GetEmployeeByRODSSUID(ResionId, OfficeId, DeptId, sction, subsction);
        }

        internal List<HRM_EMPLOYEES_VIEWER> GetEmployeeByRODSSUID(int ResionId, int OfficeId, int DeptId, int sction, int subsction,DateTime currentdate)
        {

            return objCtx_DAL.GetEmployeeByRODSSUID(ResionId, OfficeId, DeptId, sction, subsction, currentdate);

        }

        internal int UpdateAttendance(List<HRM_ATTENDANCE> attendances, string type)
        {
            return objCtx_DAL.UpdateAttendance(attendances, type);
        }

        internal int ManualOTUpdate(List<HRM_ATTENDANCE> attendances, string apprvedBy, string OThour)
        {
            return objCtx_DAL.ManualOTUpdate(attendances, apprvedBy, OThour);
        }
        internal int AttendanceAdjustment(List<HRM_ATTENDANCE> attendances, string PunishedBy)
        {
            return objCtx_DAL.AttendanceAdjustment(attendances, PunishedBy);

        }


        internal List<HRM_EMPLOYEES_VIEWER> GetEmployeeByOfficeID(int DeptId,DateTime CurrentDate)
        {
            return objCtx_DAL.GetEmployeeByOfficeID(DeptId,CurrentDate);
        }
        internal List<HRM_EMPLOYEES_VIEWER> GetEmployeeByOfficeID(int DeptId)
        {
            return objCtx_DAL.GetEmployeeByOfficeID(DeptId);
        }

        internal IEnumerable<BankAdviceRe> GetBankAdviceByDepartmentId(string Ocode, string dptId, string fromDate)
        {
            return objCtx_DAL.GetBankAdviceByDepartmentId(Ocode, dptId, fromDate);
        }
        internal IEnumerable<BankAdviceRe> GetBankAdviceAll(string OCODE)
        {
            return objCtx_DAL.GetBankAdviceAll(OCODE);
        }
        internal IEnumerable<BankAdviceRe> GetMobileBankAdvice(string Ocode, string fromDate)
        {
            return objCtx_DAL.GetMobileBankAdvice(Ocode, fromDate);
        }
        internal IEnumerable<BankAdviceRe> GetOnlyBankAdvice(string Ocode, string fromDate)
        {
            return objCtx_DAL.GetOnlyBankAdvice(Ocode, fromDate);
        }
        internal IEnumerable<BankAdviceRe> GetBankAdviceByEid(string OCODE, string Eid, string fromDate)
        {
            return objCtx_DAL.GetBankAdviceByEid(OCODE, Eid, fromDate);
        }

        internal int UpdateOT_ByDateandShift(DateTime fromDate, DateTime toDate, string shiftCode)
        {
            return objCtx_DAL.UpdateOT_ByDateandShift(fromDate, toDate, shiftCode);
        }

        internal List<string> GetAllShiftCode(string OCODE)
        {
            return objCtx_DAL.GetAllShiftCode(OCODE);
        }

        internal int UpdateOTperiodic_ByDate01to15(DateTime dateTime1, DateTime dateTime2, string OCODE)
        {
            return objCtx_DAL.UpdateOTperiodic_ByDate01to15(dateTime1, dateTime2, OCODE);
        }
        internal int UpdateOTperiodic_ByDate16to31(DateTime dateTime1, DateTime dateTime2, string OCODE)
        {
            return objCtx_DAL.UpdateOTperiodic_ByDate16to31(dateTime1, dateTime2, OCODE);
        }
        internal int UpdateOffialType(HRM_OfficialDay objOfficialDay, DateTime Official_Date)
        {
            return objCtx_DAL.UpdateOffialType(objOfficialDay, Official_Date);
        }
        public virtual List<HRM_OfficialDay_Individual> GetAllOfficeDayById(string OCODE, string Eid, DateTime date)
        {
            return objCtx_DAL.GetAllOfficeDayById(OCODE, Eid, date);
        }
        internal int UpdateOffialTypeById(HRM_OfficialDay_Individual objOfficialDay, DateTime Official_Date, string Eid)
        {
            return objCtx_DAL.UpdateOffialTypeById(objOfficialDay, Official_Date, Eid);
        }
        public int InsertOfficeTypeIndividual(HRM_OfficialDay_Individual objOfficialDay)
        {
            return objCtx_DAL.InsertOfficeTypeIndividual(objOfficialDay);
        }
        internal int UpdateAtt_WorkingDayById(string OCODE, string Eid, string dateTime, string workingDay)
        {
            return objCtx_DAL.UpdateAtt_WorkingDayById(OCODE, Eid, dateTime, workingDay);
        }

        internal int Update_Attendance(List<HRM_ATTENDANCE> attendances, string type)
        {
            return objCtx_DAL.UpdateAttendance(attendances, type);
        }
        public virtual List<HRM_AttendanceReason_Individual> GetHRM_AttendanceReason_Individual(string EID, DateTime date)
        {
            return objCtx_DAL.GetHRM_AttendanceReason_Individual(EID, date);
        }


        internal List<HRM_EMPLOYEES_VIEWER> GetEmployeeByIDWithSalary(string eid, Decimal Salary, Decimal ToSalary)
        {
            return objCtx_DAL.GetEmployeeByIDWithSalary(eid, Salary, ToSalary);
        }

        internal List<HRM_EMPLOYEES_VIEWER> GetEmployeeByOfficeIDWithSalary(int DeptId, Decimal Salary, Decimal ToSalary)
        {
            return objCtx_DAL.GetEmployeeByOfficeIDWithSalary(DeptId, Salary, ToSalary);
        }


        internal List<HRM_EMPLOYEES_VIEWER> GetEmployeeByRODSSUIDWithSalry(int ResionId, int OfficeId, int DeptId, int sction, int subsction, Decimal Salary, Decimal ToSalary)
        {
            return objCtx_DAL.GetEmployeeByRODSSUIDWithSalry(ResionId, OfficeId, DeptId, sction, subsction, Salary, ToSalary);
        }

        internal int UpdateAttStatus_ByShift(DateTime fromDate, DateTime toDate, string shiftCode)
        {
            return objCtx_DAL.UpdateAttStatus_ByShift(fromDate, toDate, shiftCode);
        }

        internal int Insert_AbsentLeaveStatus_ByShift(DateTime fromDate, DateTime toDate, string shiftCode, string OCODE, DateTime editdate, Guid userid)
        {
            return objCtx_DAL.Insert_AbsentLeaveStatus_ByShift(fromDate, toDate, shiftCode, OCODE, editdate, userid);
        }

        internal int Insert_AttProcessLog(DateTime fromDate, DateTime toDate, Guid userId, DateTime editDate, string oCode)
        {
            return objCtx_DAL.Insert_AttProcessLog(fromDate, toDate, userId, editDate, oCode);
        }

        public virtual List<HRM_ATTENDANCE> GetAllOTByDate(string OCODE, DateTime dateFrom, DateTime dateTo)
        {
            return objCtx_DAL.GetAllOTByDate(OCODE, dateFrom, dateTo);
        }

        internal List<HRM_EMPLOYEES_VIEWER> GetEmployeeByOffice(int officeId, DateTime CurrentDate)
        {
            return objCtx_DAL.GetEmployeeByOffice(officeId, CurrentDate);
        }

        internal List<HRM_EMPLOYEES_VIEWER> GetEmployeesByEid(string eid)
        {
            return objCtx_DAL.GetEmployeesByEid(eid);
        }

        public virtual List<HRM_ATTENDANCE> GetAttendanceByEID_Date(string OCODE, string eid, DateTime attDate)
        {
            return objCtx_DAL.GetAttendanceByEID_Date(OCODE, eid, attDate);
        }
        internal int UpdateWorkingDay(List<HRM_OfficialDay_Individual> lstHRM_OfficialDay_Individual)
        {
            return objCtx_DAL.UpdateWorkingDay(lstHRM_OfficialDay_Individual);
        }
        internal object Update_IndividualAttendance(List<HRM_ATTENDANCE> attendances)
        {
            return objCtx_DAL.Update_IndividualAttendance(attendances);
        }
        internal IEnumerable<BankAdviceRe> GetInfo_WithOutBankInfo(string Ocode, string fromDate)
        {
            return objCtx_DAL.GetInfo_WithOutBankInfo(Ocode, fromDate);
        }

        internal List<HRM_EMPLOYEES_VIEWER> GetSalaryDeductionByEID(DateTime deductDate)
        {
            return objCtx_DAL.GetSalaryDeductionByEID(deductDate);
        }

        internal int UpdateOT_ByShift_EID(DateTime fromDate, DateTime toDate, string ashiftcode, string Eid)
        {
            return objCtx_DAL.UpdateOT_ByShift_EID(fromDate, toDate, ashiftcode, Eid);
        }

        internal int DeleteAttendance(List<HRM_ATTENDANCE> attendances, string PunishedBy)
        {
            return objCtx_DAL.DeleteAttendance(attendances, PunishedBy);
        }
        internal List<HRM_ATTENDANCE> GetAttendanceInfo_DateWise(DateTime FromDate)
        {
            return objCtx_DAL.GetAttendanceInfo_DateWise(FromDate);
        }
        internal int Delete_Attendance_ByEID_Date(string eid, DateTime attendate)
        {
            return objCtx_DAL.Delete_Attendance_ByEID_Date(eid, attendate);
        }

        internal List<HRM_EMPLOYEES_VIEWER> GetEmployeeByDepartment(int RegionId, int OfficeId, int DeptId, DateTime EffectiveDate)
        {
            return objCtx_DAL.GetEmployeeByDepartment(RegionId, OfficeId, DeptId, EffectiveDate);
        }

        internal List<HRM_EMPLOYEES_VIEWER> GetEmployeeBySubsectionWise(int ResionId, int OfficeId, int DeptId, int sction, int subsction, DateTime EffectiveDate)
        {
            return objCtx_DAL.GetEmployeeBySubsectionWise(ResionId, OfficeId, DeptId, sction, subsction, EffectiveDate);
        }
        internal List<HRM_EMPLOYEES_VIEWER> GetEmployeesByE_id(string eid, DateTime EffectiveDate)
        {
            return objCtx_DAL.GetEmployeesByE_id(eid, EffectiveDate);
        }
    }
}
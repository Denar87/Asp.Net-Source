using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ERPSSL.HRM.DAL;
using ERPSSL.HRM.DAL.Repository;

namespace ERPSSL.HRM.BLL
{
    public class LEAVE_BLL
    {
        LEAVE_DAL objCtx_DAL = new LEAVE_DAL();

        public IEnumerable<leave_Details> GetEmployeeLeave_Details(int selectedId, string OCODE)
        {
            return objCtx_DAL.GetEmployeeLeave_Details(selectedId, OCODE);
        }
        //-------Insert------------------------------------
        public int InsertLeaveType(HRM_LEAVE_TYPE objLev)
        {
            return objCtx_DAL.InsertLeaveType(objLev);
        }


        //-------Update------------------------------------
        public int UpdateLeaveType(HRM_LEAVE_TYPE objLev, int gradeId)
        {
            return objCtx_DAL.UpdateLeaveType(objLev, gradeId);
        }

        //-------GetAll------------------------------------
        public virtual List<HRM_LEAVE_TYPE> GetAllLeaveType(string OCODE)
        {
            return objCtx_DAL.GetAllLeaveType(OCODE);
        }

        public virtual List<HRM_ATTENDANCE> GetAllEmployee(string OCODE)
        {
            return objCtx_DAL.GetAllEmployee(OCODE);
        }

        internal List<HRM_LEAVE_TYPE> getLeaveTypeByLeaveIdandOcode(string leavetypeId, string OCODE)
        {
            return objCtx_DAL.getLeaveTypeByLeaveIdandOcode(leavetypeId,OCODE);
        }

        internal int InsertLeaveApply(List<HRM_LeaveApply> leaveList)
        {

            return objCtx_DAL.InsertLeaveApply(leaveList);
        }

        internal List<HRM_LEAVE_TYPE> getTotalLeaveOfTypeByTypeId(int leaveType, string ocode)
        {
            return objCtx_DAL.getTotalLeaveOfTypeByTypeId(leaveType, ocode);
        }



        internal IEnumerable<TakenLeave> getTakenLeaveByLeaveType(int leaveType, string eid, string ocode, string currentYear)
        {
            return objCtx_DAL.getTakenLeaveByLeaveType(leaveType, eid, ocode, currentYear);
        }

        internal IEnumerable<TakenLeave> getAnnualTakenLeaveByEid(string eid, string OCODE, string currentYear)
        {
            return objCtx_DAL.getAnnualTakenLeaveByEid(eid, OCODE, currentYear);
        }

        internal IEnumerable<LeaveInfo> GetLeaveInfoByEmployeeId(string eid, string currentYear, string OCODE)
        {
            return objCtx_DAL.GetLeaveInfoByEmployeeId(eid, currentYear, OCODE);
        }

        internal HRM_LeaveApply GetLeaveInfoById(string leaveId, string OCODE)
        {
            return objCtx_DAL.GetLeaveInfoById(leaveId, OCODE);
        }

        internal int UpdateLeaveApplyByLeaveId(HRM_LeaveApply leaveApplyObj, int leaveId)
        {
            return objCtx_DAL.UpdateLeaveApplyByLeaveId(leaveApplyObj, leaveId);
        }



        internal IEnumerable<LeaveInfo> getLeaveInfoForApprove(string eid, string currentYear, string OCODE)
        {
            return objCtx_DAL.getLeaveInfoForApprove(eid, currentYear, OCODE);
        }



      

        internal int GetLastRowNumber(string OCODE)
        {
            return objCtx_DAL.GetLastRowNumber(OCODE);
        }

        internal List<LeaveInfo> GetLeaveListByLeaveCode(string LeaveCode, string ocode)
        {
            return objCtx_DAL.GetLeaveListByLeaveCode(LeaveCode, ocode);
        }

        internal List<LeaveDate> GetAppliedDates(string LeaveCode, string ocode)
        {
            return objCtx_DAL.GetAppliedDates(LeaveCode, ocode);
        }

        internal List<LeaveInfo> getLeaveInfoForReportingBoss1(string eid, string currentYear, string OCODE)
        {
            return objCtx_DAL.getLeaveInfoForReportingBoss1(eid, currentYear, OCODE);
        }

        internal int UpdateLeaveForApproveNotChange(HRM_LeaveApply leaveApplyes)
        {
            return objCtx_DAL.UpdateLeaveForApproveNotChange(leaveApplyes);
        }

        internal List<HRM_LeaveApply> GetLeaveInfoByOcode(string LeaveCPde)
        {
            return objCtx_DAL.GetLeaveInfoByOcode(LeaveCPde);
        }



        internal int UpdateLeaveChangeForHRM(List<HRM_LeaveApply> newLeaveApplyList)
        {
            return objCtx_DAL.UpdateLeaveChangeForHRM(newLeaveApplyList);
        }

        internal List<LeaveInfo> getLeaveInfoForReportingBoss2(string eid, string currentYear, string OCODE)
        {

            return objCtx_DAL.getLeaveInfoForReportingBoss2(eid, currentYear, OCODE);
        }

        internal int UpdateLeaveForApproveNotChangeForReportingBoss1(HRM_LeaveApply leaveApplyObj)
        {

            return objCtx_DAL.UpdateLeaveForApproveNotChangeForReportingBoss1(leaveApplyObj);

        }

        internal int UpdateLeaveChangeForReportingBoss1(List<DAL.HRM_LeaveApply> newLeaveApplyList)
        {
            return objCtx_DAL.UpdateLeaveChangeForReportingBoss1(newLeaveApplyList);
        }

        internal int UpdateLeaveForApproveNotChangeForReportingBoss2(DAL.HRM_LeaveApply leaveApplyObj)
        {
            return objCtx_DAL.UpdateLeaveForApproveNotChangeForReportingBoss2(leaveApplyObj);
        }

        internal int UpdateLeaveChangeForReportingBoss2(List<DAL.HRM_LeaveApply> newLeaveApplyList)
        {
            return objCtx_DAL.UpdateLeaveChangeForReportingBoss2(newLeaveApplyList);
        }

        internal List<HRM_LeaveApply> GetLeaveStautsByCode(string LeaveCode, string OCODE)
        {
            return objCtx_DAL.GetLeaveStautsByCode(LeaveCode, OCODE);
        }

        internal int LeaveForDisApproveNotChangeForReportingBoss1(HRM_LeaveApply leaveApplyObj)
        {
            return objCtx_DAL.LeaveForDisApproveNotChangeForReportingBoss1(leaveApplyObj);
        }

        internal int LeaveForDisApproveNotChangeForReportingBoss2(HRM_LeaveApply leaveApplyObj)
        {

            return objCtx_DAL.LeaveForDisApproveNotChangeForReportingBoss2(leaveApplyObj);
        }

        internal int LeaveForDisApproveNotChangeForHRM(DAL.HRM_LeaveApply leaveApplyObj)
        {
            return objCtx_DAL.LeaveForDisApproveNotChangeForHRM(leaveApplyObj);
        }

        internal List<HRM_LEAVE_TYPE> GetMaternityLeaveInfo(string OCODE)
        {
            return objCtx_DAL.GetMaternityLeaveInfo(OCODE);
        }

        internal List<MaternityLeaveR> getMaternityLeaveInfoForApprove(string eid, string currentYear, string OCODE)
        {

            return objCtx_DAL.getMaternityLeaveInfoForApprove(eid, currentYear, OCODE);
        }

        internal int MaternityLeaveAccept(List<HRM_LeaveApply> leaveApply)
        {
            return objCtx_DAL.MaternityLeaveAccept(leaveApply);
        }

        internal List<LeaveDetailsR> GetLeaveDetailsByEID(string employeeID)
        {

            return objCtx_DAL.GetLeaveDetailsByEID(employeeID);
        }

        internal LeaveDetailsR GetLeaveDetailByLeaveCode(string leaveCode)
        {
            return objCtx_DAL.GetLeaveDetailByLeaveCode(leaveCode);
        }

        

        internal int DeleteLeaveDetailsByLeaveCode(string LeaveCode)
        {
            return objCtx_DAL.DeleteLeaveDetailsByLeaveCode(LeaveCode);
        }

        internal List<LeaveForReport> GetEmployeeApplyReport(string eid,DateTime FormDate,DateTime ToDate)
        {
            return objCtx_DAL.LeaveApplyReport(eid,FormDate,ToDate);
        }

        internal int DeleteAttendanceByLeaveDate(List<HRM_LeaveApply> leaveApplyesDates)
        {
            return objCtx_DAL.DeleteAttendanceByLeaveDate(leaveApplyesDates);
        }

        internal List<HRM_LeaveApply> GetLeaveDateByLeaveCode(string leaveCode)
        {
            return objCtx_DAL.GetLeaveDateByLeaveCode(leaveCode);
        }

        internal string GetFirstReportingBossIDByLeaveCode(string LeaveCode)
        {
            return objCtx_DAL.GetFirstReportingBossIDByLeaveCode(LeaveCode);
        }

        internal string GetSecondReportingBossIDByLeaveCode(string LeaveCode)
        {
            return objCtx_DAL.GetSecondReportingBossIDByLeaveCode(LeaveCode);

        }

        internal string GetThirdReportingBossIDByLeaveCode(string LeaveCode)
        {

            return objCtx_DAL.GetThirdReportingBossIDByLeaveCode(LeaveCode);
        }

        internal int CancelLeavesForFirstReportinBoss(List<HRM_LeaveApply> leaveApplyesDates)
        {
            return objCtx_DAL.CancelLeavesForFirstReportinBoss(leaveApplyesDates);
        }

        internal int CancelLeavesForSecondReportinBoss(List<HRM_LeaveApply> leaveApplyesDates)
        {
            return objCtx_DAL.CancelLeavesForSecondReportinBoss(leaveApplyesDates);

        }

        internal int CancelLeavesForThirdReportinBoss(List<HRM_LeaveApply> leaveApplyesDates)
        {
            return objCtx_DAL.CancelLeavesForThirdReportinBoss(leaveApplyesDates);
        }

        internal List<HRM_LeaveApply> getLeaveApplyesByCode(string LeaveCode)
        {
            return objCtx_DAL.getLeaveApplyesByCode(LeaveCode);
        }

        internal List<HRM_LeaveApply> GetLeavesByEID(string eid)
        {
            return objCtx_DAL.GetLeavesByEID(eid); 
        }

        internal int DeleteLeaveDetailsByEID(string eid)
        {
            return objCtx_DAL.DeleteLeaveDetailsByEID(eid); 
        }

        internal int CheckAttendance(List<HRM_LeaveApply> leaveApplyesDates)
        {
            return objCtx_DAL.CheckAttendance(leaveApplyesDates);
        }

        internal List<HRM_LEAVE_TYPE> ProbationPeriod(DateTime date, string eid)
        {
            return objCtx_DAL.ProbationPeriod(date,eid);

        }

        internal List<LeaveDetailsR> GetLeaveDetailsFoRFemaleByEID(string employeeID)
        {
            return objCtx_DAL.GetLeaveDetailsFoRFemaleByEID(employeeID);

        }

        internal int DeleteAttendanceByLeave(List<HRM_LeaveApply> leaves)
        {
            return objCtx_DAL.DeleteAttendanceByLeave(leaves);
        }
    }
}
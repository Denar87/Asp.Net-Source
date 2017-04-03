using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ERPSSL.HRM.BLL;
using ERPSSL.HRM.DAL;
using ERPSSL.HRM.DAL.Repository;
using System.Data.SqlClient;

namespace ERPSSL.HRM.DAL
{
    public class LEAVE_DAL
    {
        private ERPSSLHBEntities _context = new ERPSSLHBEntities();

        public IEnumerable<leave_Details> GetEmployeeLeave_Details(int selectedId, string OCODE)
        {
            //HRM_Entities _context = new HRM_Entities();

            List<leave_Details> leave = (from leave_dt in _context.HRM_LEAVE_DETAILS
                                         join lemp in _context.HRM_LEAVE_EMPLOYEE on leave_dt.LEV_APP_ID equals lemp.LEV_APP_ID
                                         join emp in _context.HRM_EMPLOYEES on lemp.EMP_ID equals emp.EMP_ID
                                         join leave_tp in _context.HRM_LEAVE_TYPE on lemp.LEV_TYPE_ID equals leave_tp.LEV_ID

                                         where leave_dt.LEV_APP_ID == selectedId

                                         select new leave_Details
                                         {
                                             LEV_DETAILS_ID = leave_dt.LEV_DETAILS_ID,
                                             LEV_TYPE_ID = (Int32)lemp.LEV_TYPE_ID,
                                             LEV_TYPE_NAME = leave_tp.LEV_TYPE,
                                             LEV_DATES = (DateTime)leave_dt.LEV_DATES,
                                             EMP_FIRSTNAME = emp.EMP_FIRSTNAME
                                         }).ToList();
            return leave;
        }

        //-------Insert------------------------------------
        public int InsertLeaveType(HRM_LEAVE_TYPE objLev)
        {
            try
            {
                _context.HRM_LEAVE_TYPE.AddObject(objLev);
                _context.SaveChanges();
                return 1;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        //-------Update------------------------------------
        public int UpdateLeaveType(HRM_LEAVE_TYPE objLev, int leaveID)
        {
            try
            {
                HRM_LEAVE_TYPE obj = _context.HRM_LEAVE_TYPE.First(x => x.LEV_ID == leaveID);
                obj.LEV_TYPE = objLev.LEV_TYPE;
                obj.LEV_DAYS = objLev.LEV_DAYS;
                obj.EDIT_USER = objLev.EDIT_USER;
                obj.EDIT_DATE = DateTime.Now;
                obj.OCODE = objLev.OCODE;

                _context.SaveChanges();
                return 1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //-------GetAll------------------------------------
        public virtual List<HRM_LEAVE_TYPE> GetAllLeaveType(string OCODE)
        {
            try
            {
                var query = (from lev in _context.HRM_LEAVE_TYPE.Where(x => x.OCODE == OCODE)

                             select lev).OrderBy(lev => lev.LEV_ID);

                return query.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        internal List<HRM_LEAVE_TYPE> getLeaveTypeByLeaveIdandOcode(string leavetypeId, string OCODE)
        {
            int leaveTypeId = Convert.ToInt32(leavetypeId);
            var query = (from lt in _context.HRM_LEAVE_TYPE
                         where lt.OCODE == OCODE && lt.LEV_ID == leaveTypeId
                         select lt).OrderBy(hl => hl.LEV_ID);

            var list = query.ToList();
            return list;
        }



        internal List<HRM_LEAVE_TYPE> getTotalLeaveOfTypeByTypeId(int leaveType, string ocode)
        {
            try
            {
                List<HRM_LEAVE_TYPE> query = (from lt in _context.HRM_LEAVE_TYPE
                                              where lt.OCODE == ocode && lt.LEV_ID == leaveType
                                              select lt).ToList();

                return query;


            }
            catch (Exception)
            {

                throw;
            }
        }



        internal IEnumerable<TakenLeave> getTakenLeaveByLeaveType(int leaveType, string eid, string ocode, string currentYear)
        {
            try
            {
                using (var _context = new ERPSSLHBEntities())
                {
                    var ParamempID = new SqlParameter("@ocode", ocode);
                    var ParamempID1 = new SqlParameter("@Eid", eid);
                    var ParamempID2 = new SqlParameter("@LeaveType", leaveType);
                    var ParamempID3 = new SqlParameter("@currentYear", currentYear);
                    string SP_SQL = "HRM_GetTakenLeaveByLeaveType @ocode,@Eid,@LeaveType,@currentYear";
                    return (_context.ExecuteStoreQuery<TakenLeave>(SP_SQL, ParamempID, ParamempID1, ParamempID2, ParamempID3)).ToList();
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        internal IEnumerable<TakenLeave> getAnnualTakenLeaveByEid(string eid, string OCODE, string currentYear)
        {
            try
            {
                using (var _context = new ERPSSLHBEntities())
                {
                    var ParamempID = new SqlParameter("@ocode", OCODE);
                    var ParamempID1 = new SqlParameter("@Eid", eid);
                    var ParamempID2 = new SqlParameter("@currentYear", currentYear);
                    string SP_SQL = "HRM_GetAnnualTakenLeaveByEid @ocode,@Eid,@currentYear";
                    return (_context.ExecuteStoreQuery<TakenLeave>(SP_SQL, ParamempID, ParamempID1, ParamempID2)).ToList();
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        internal IEnumerable<LeaveInfo> GetLeaveInfoByEmployeeId(string eid, string currentYear, string OCODE)
        {
            try
            {
                using (var _context = new ERPSSLHBEntities())
                {
                    var ParamempID = new SqlParameter("@Eid", eid);
                    var ParamempID1 = new SqlParameter("@OCODE", OCODE);
                    var ParamempID2 = new SqlParameter("@currentYear", currentYear);
                    string SP_SQL = "HRM_GetLeaveInfoByEmployeeId @Eid,@OCODE,@currentYear";
                    return (_context.ExecuteStoreQuery<LeaveInfo>(SP_SQL, ParamempID, ParamempID1, ParamempID2)).ToList();
                }
            }
            catch (Exception)
            {

                throw;
            }

        }

        internal HRM_LeaveApply GetLeaveInfoById(string leaveId, string OCODE)
        {
            try
            {
                int LeaveId = Convert.ToInt32(leaveId);
                HRM_LeaveApply obj = _context.HRM_LeaveApply.First(x => x.LeaveId == LeaveId);
                return obj;


            }
            catch (Exception)
            {

                throw;
            }
        }

        internal int UpdateLeaveApplyByLeaveId(HRM_LeaveApply leaveApplyObj, int leaveId)
        {
            HRM_LeaveApply obj = _context.HRM_LeaveApply.First(x => x.LeaveId == leaveId);
            obj.LeaveAppliedDate = leaveApplyObj.LeaveAppliedDate;
            obj.LeaveTypeId = leaveApplyObj.LeaveTypeId;
            obj.LeaveDates = leaveApplyObj.LeaveDates;
            obj.TotalDay = leaveApplyObj.TotalDay;
            obj.LeaveResion = leaveApplyObj.LeaveResion;
            _context.SaveChanges();
            return 1;

        }

        internal IEnumerable<LeaveInfo> getLeaveInfoForApprove(string eid, string currentYear, string OCODE)
        {
            try
            {
                using (var _context = new ERPSSLHBEntities())
                {
                    var ParamempID = new SqlParameter("@Eid", eid);
                    var ParamempID1 = new SqlParameter("@OCODE", OCODE);
                    var ParamempID2 = new SqlParameter("@currentYear", currentYear);
                    string SP_SQL = "HRM_GetApplyLeaveListForApproveByEmployeeId @Eid,@OCODE,@currentYear";
                    return (_context.ExecuteStoreQuery<LeaveInfo>(SP_SQL, ParamempID, ParamempID1, ParamempID2)).ToList();
                }

            }
            catch (Exception)
            {

                throw;
            }

        }

        internal int GetLastRowNumber(string OCODE)
        {
            var count = (from o in _context.HRM_LeaveApply
                         select o).Count();
            return count;

        }

        internal int InsertLeaveApply(List<HRM_LeaveApply> leaveList)
        {
            try
            {
                foreach (HRM_LeaveApply aitm in leaveList)
                {
                    _context.HRM_LeaveApply.AddObject(aitm);
                }
                _context.SaveChanges();
                return 1;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }

        }

        internal List<LeaveInfo> GetLeaveListByLeaveCode(string LeaveCode, string ocode)
        {
            try
            {
                using (var _context = new ERPSSLHBEntities())
                {
                    var ParamempID = new SqlParameter("@LeaveCode", LeaveCode);
                    var ParamempID1 = new SqlParameter("@OCODE", ocode);
                    string SP_SQL = "HRM_GetApplyLeaveListByLeaveCode @LeaveCode,@OCODE";
                    return (_context.ExecuteStoreQuery<LeaveInfo>(SP_SQL, ParamempID, ParamempID1)).ToList();
                }

            }
            catch (Exception)
            {

                throw;
            }

        }

        internal List<LeaveDate> GetAppliedDates(string LeaveCode, string ocode)
        {
            var ParamempID = new SqlParameter("@ocode", ocode);
            var ParamempID1 = new SqlParameter("@LeaveCode", LeaveCode);
            string SP_SQL = "HRM_GetDateByLeaveCode @ocode,@LeaveCode";
            return (_context.ExecuteStoreQuery<LeaveDate>(SP_SQL, ParamempID, ParamempID1)).ToList();

        }

        internal List<LeaveInfo> getLeaveInfoForReportingBoss1(string eid, string currentYear, string OCODE)
        {

            try
            {
                using (var _context = new ERPSSLHBEntities())
                {
                    var ParamempID = new SqlParameter("@Eid", eid);
                    var ParamempID1 = new SqlParameter("@OCODE", OCODE);
                    var ParamempID2 = new SqlParameter("@currentYear", currentYear);
                    string SP_SQL = "HRM_GetApplyLeaveListForApproveByEmployeeIdReportingBoss1 @Eid,@OCODE,@currentYear";
                    return (_context.ExecuteStoreQuery<LeaveInfo>(SP_SQL, ParamempID, ParamempID1, ParamempID2)).ToList();
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        internal int UpdateLeaveForApproveNotChange(HRM_LeaveApply leaveApplyes)
        {
            try
            {
                using (var _context = new ERPSSLHBEntities())
                {
                    var ParamempID = new SqlParameter("@LeaveCOde", leaveApplyes.LeaveCode);
                    var ParamempID1 = new SqlParameter("@ReprotingBossHRmApporveStatus", leaveApplyes.ReprotingBossHRmApporveStatus);
                    var ParamempID2 = new SqlParameter("@ReportingBossHRMApproveDate", leaveApplyes.ReportingBossHRMApproveDate);
                    string SP_SQL = "HRM_LeaveApproveForHRM @LeaveCOde,@ReprotingBossHRmApporveStatus,@ReportingBossHRMApproveDate";
                    _context.ExecuteStoreCommand(SP_SQL, ParamempID, ParamempID1, ParamempID2);
                    return 1;
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        internal List<HRM_LeaveApply> GetLeaveInfoByOcode(string LeaveCPde)
        {
            try
            {
                List<HRM_LeaveApply> query = (from lt in _context.HRM_LeaveApply
                                              where lt.LeaveCode == LeaveCPde
                                              select lt).ToList();

                return query;

            }
            catch (Exception)
            {

                throw;
            }
        }

        internal int UpdateLeaveChangeForHRM(List<HRM_LeaveApply> newLeaveApplyList)
        {
            string LeaveCOde = "";
            string Ocode = "";
            foreach (HRM_LeaveApply oaitem in newLeaveApplyList)
            {

                using (var _context = new ERPSSLHBEntities())
                {
                    string laeaveDate = oaitem.LeaveDates.ToString();
                    string approveDate = oaitem.ReportingBossHRMApproveDate.ToString();
                    LeaveCOde = oaitem.LeaveCode;
                    Ocode = oaitem.OCODE;
                    var ParamempID = new SqlParameter("@ocode", oaitem.OCODE);
                    var ParamempID1 = new SqlParameter("@date", laeaveDate);
                    var ParamempID2 = new SqlParameter("@LeaveCode", oaitem.LeaveCode);
                    var ParamempID3 = new SqlParameter("@ApproveDate", approveDate);

                    var ParamempID4 = new SqlParameter("@HrmApproveStatus", oaitem.ReprotingBossHRmApporveStatus);
                    string SP_SQL = "HRM_DeleteLeaveForHRMByCodeandDate @ocode,@date,@LeaveCode,@ApproveDate,@HrmApproveStatus";
                    _context.ExecuteStoreCommand(SP_SQL, ParamempID, ParamempID1, ParamempID2, ParamempID3, ParamempID4);

                }

            }

            using (var _context = new ERPSSLHBEntities())
            {

                var ParamempID = new SqlParameter("@OCODE", Ocode);
                var ParamempID1 = new SqlParameter("@LeaveCode", LeaveCOde);
                string SP_SQL = "HRM_DeleteLeaveDateByHrmAppoveStatus @OCODE,@LeaveCode";
                _context.ExecuteStoreCommand(SP_SQL, ParamempID, ParamempID1);

            }
            return 1;
        }

        internal List<LeaveInfo> getLeaveInfoForReportingBoss2(string eid, string currentYear, string OCODE)
        {
            try
            {
                using (var _context = new ERPSSLHBEntities())
                {
                    var ParamempID = new SqlParameter("@Eid", eid);
                    var ParamempID1 = new SqlParameter("@OCODE", OCODE);
                    var ParamempID2 = new SqlParameter("@currentYear", currentYear);
                    string SP_SQL = "HRM_GetApplyLeaveListForApproveByEmployeeIdReportingBoss2 @Eid,@OCODE,@currentYear";
                    return (_context.ExecuteStoreQuery<LeaveInfo>(SP_SQL, ParamempID, ParamempID1, ParamempID2)).ToList();
                }

            }
            catch (Exception)
            {

                throw;
            }

        }

        internal int UpdateLeaveForApproveNotChangeForReportingBoss1(HRM_LeaveApply leaveApplyObj)
        {

            using (var _context = new ERPSSLHBEntities())
            {
                var ParamempID = new SqlParameter("@LeaveCOde", leaveApplyObj.LeaveCode);
                var ParamempID1 = new SqlParameter("@ReprotingBoss1ApporveStatus", leaveApplyObj.ReprotingBoss1ApproveStatus);
                var ParamempID2 = new SqlParameter("@ReportingBoss1pproveDate", leaveApplyObj.ReprotingBoss1ApproveDate);
                string SP_SQL = "HRM_LeaveApproveForForReportinBoss1 @LeaveCOde,@ReprotingBoss1ApporveStatus,@ReportingBoss1pproveDate";
                _context.ExecuteStoreCommand(SP_SQL, ParamempID, ParamempID1, ParamempID2);
                return 1;
            }

        }

        internal int UpdateLeaveChangeForReportingBoss1(List<HRM_LeaveApply> newLeaveApplyList)
        {
            string LeaveCOde = "";
            string Ocode = "";
            foreach (HRM_LeaveApply oaitem in newLeaveApplyList)
            {

                using (var _context = new ERPSSLHBEntities())
                {
                    string laeaveDate = oaitem.LeaveDates.ToString();
                    string approveDate = oaitem.ReportingBossHRMApproveDate.ToString();
                    LeaveCOde = oaitem.LeaveCode;
                    Ocode = oaitem.OCODE;
                    var ParamempID = new SqlParameter("@ocode", oaitem.OCODE);
                    var ParamempID1 = new SqlParameter("@date", laeaveDate);
                    var ParamempID2 = new SqlParameter("@LeaveCode", oaitem.LeaveCode);
                    var ParamempID3 = new SqlParameter("@ApproveDate", approveDate);

                    var ParamempID4 = new SqlParameter("@HrmApproveStatus", oaitem.ReprotingBossHRmApporveStatus);
                    string SP_SQL = "HRM_UpdateLeaveForReportinBoss1ByCodeandDate @ocode,@date,@LeaveCode,@ApproveDate,@HrmApproveStatus";
                    _context.ExecuteStoreCommand(SP_SQL, ParamempID, ParamempID1, ParamempID2, ParamempID3, ParamempID4);

                }

            }

            using (var _context = new ERPSSLHBEntities())
            {

                var ParamempID = new SqlParameter("@OCODE", Ocode);
                var ParamempID1 = new SqlParameter("@LeaveCode", LeaveCOde);
                string SP_SQL = "HRM_DeleteLeaveDateByReportingBoss1AppoveStatus @OCODE,@LeaveCode";
                _context.ExecuteStoreCommand(SP_SQL, ParamempID, ParamempID1);

            }
            return 1;

        }

        internal int UpdateLeaveForApproveNotChangeForReportingBoss2(HRM_LeaveApply leaveApplyObj)
        {
            using (var _context = new ERPSSLHBEntities())
            {
                var ParamempID = new SqlParameter("@LeaveCOde", leaveApplyObj.LeaveCode);
                var ParamempID1 = new SqlParameter("@ReprotingBoss2ApporveStatus", leaveApplyObj.ReprotingBoss1ApproveStatus);
                var ParamempID2 = new SqlParameter("@ReportingBoss2pproveDate", leaveApplyObj.ReprotingBoss1ApproveDate);
                string SP_SQL = "HRM_LeaveApproveForForReportinBoss2 @LeaveCOde,@ReprotingBoss2ApporveStatus,@ReportingBoss2pproveDate";
                _context.ExecuteStoreCommand(SP_SQL, ParamempID, ParamempID1, ParamempID2);
                return 1;
            }
        }

        internal int UpdateLeaveChangeForReportingBoss2(List<HRM_LeaveApply> newLeaveApplyList)
        {
            string LeaveCOde = "";
            string Ocode = "";
            foreach (HRM_LeaveApply oaitem in newLeaveApplyList)
            {

                using (var _context = new ERPSSLHBEntities())
                {
                    string laeaveDate = oaitem.LeaveDates.ToString();
                    string approveDate = oaitem.ReportingBossHRMApproveDate.ToString();
                    LeaveCOde = oaitem.LeaveCode;
                    Ocode = oaitem.OCODE;
                    var ParamempID = new SqlParameter("@ocode", oaitem.OCODE);
                    var ParamempID1 = new SqlParameter("@date", laeaveDate);
                    var ParamempID2 = new SqlParameter("@LeaveCode", oaitem.LeaveCode);
                    var ParamempID3 = new SqlParameter("@ApproveDate", approveDate);

                    var ParamempID4 = new SqlParameter("@HrmApproveStatus", oaitem.ReprotingBossHRmApporveStatus);
                    string SP_SQL = "HRM_UpdateLeaveForReportinBoss2ByCodeandDate @ocode,@date,@LeaveCode,@ApproveDate,@HrmApproveStatus";
                    _context.ExecuteStoreCommand(SP_SQL, ParamempID, ParamempID1, ParamempID2, ParamempID3, ParamempID4);

                }

            }

            using (var _context = new ERPSSLHBEntities())
            {

                var ParamempID = new SqlParameter("@OCODE", Ocode);
                var ParamempID1 = new SqlParameter("@LeaveCode", LeaveCOde);
                string SP_SQL = "HRM_DeleteLeaveDateByReportingBoss2AppoveStatus @OCODE,@LeaveCode";
                _context.ExecuteStoreCommand(SP_SQL, ParamempID, ParamempID1);

            }
            return 1;

        }

        internal List<HRM_LeaveApply> GetLeaveStautsByCode(string LeaveCode, string OCODE)
        {
            try
            {
                try
                {
                    List<HRM_LeaveApply> query = (from lt in _context.HRM_LeaveApply
                                                  where lt.LeaveCode == LeaveCode && lt.OCODE == OCODE
                                                  select lt).ToList();

                    return query;

                }
                catch (Exception)
                {

                    throw;
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        internal int LeaveForDisApproveNotChangeForReportingBoss1(HRM_LeaveApply leaveApplyObj)
        {


            using (var _context = new ERPSSLHBEntities())
            {
                var ParamempID = new SqlParameter("@LeaveCOde", leaveApplyObj.LeaveCode);
                var ParamempID1 = new SqlParameter("@ReprotingBoss1ApporveStatus", leaveApplyObj.ReprotingBoss1DisApproveStatus);
                var ParamempID2 = new SqlParameter("@ReportingBoss1pproveDate", leaveApplyObj.ReprotingBoss1DisApproveDate);
                string SP_SQL = "HRM_LeaveDisApproveForForReportinBoss1 @LeaveCOde,@ReprotingBoss1ApporveStatus,@ReportingBoss1pproveDate";
                _context.ExecuteStoreCommand(SP_SQL, ParamempID, ParamempID1, ParamempID2);
                return 1;
            }
        }

        internal int LeaveForDisApproveNotChangeForReportingBoss2(HRM_LeaveApply leaveApplyObj)
        {

            using (var _context = new ERPSSLHBEntities())
            {
                var ParamempID = new SqlParameter("@LeaveCOde", leaveApplyObj.LeaveCode);
                var ParamempID1 = new SqlParameter("@ReprotingBoss1ApporveStatus", leaveApplyObj.ReportingBoss2DisApporveStatus);
                var ParamempID2 = new SqlParameter("@ReportingBoss1pproveDate", leaveApplyObj.ReportingBoss2DisApproveDate);
                string SP_SQL = "HRM_LeaveDisApproveForForReportinBoss2 @LeaveCOde,@ReprotingBoss1ApporveStatus,@ReportingBoss1pproveDate";
                _context.ExecuteStoreCommand(SP_SQL, ParamempID, ParamempID1, ParamempID2);
                return 1;
            }
        }

        internal int LeaveForDisApproveNotChangeForHRM(HRM_LeaveApply leaveApplyObj)
        {
            using (var _context = new ERPSSLHBEntities())
            {
                var ParamempID = new SqlParameter("@LeaveCOde", leaveApplyObj.LeaveCode);
                var ParamempID1 = new SqlParameter("@ReprotingBoss1ApporveStatus", leaveApplyObj.ReprotingBossHRmDisApporveStatus);
                var ParamempID2 = new SqlParameter("@ReportingBoss1pproveDate", leaveApplyObj.ReportingBossHRMDisApproveDate);
                string SP_SQL = "HRM_LeaveDisApproveForForReportinHRM @LeaveCOde,@ReprotingBoss1ApporveStatus,@ReportingBoss1pproveDate";
                _context.ExecuteStoreCommand(SP_SQL, ParamempID, ParamempID1, ParamempID2);
                return 1;
            }
        }

        internal List<HRM_LEAVE_TYPE> GetMaternityLeaveInfo(string OCODE)
        {
            try
            {
                try
                {
                    List<HRM_LEAVE_TYPE> query = (from lt in _context.HRM_LEAVE_TYPE
                                                  where lt.LEV_ID == 6 && lt.OCODE == OCODE
                                                  select lt).ToList();

                    return query;

                }
                catch (Exception)
                {

                    throw;
                }

            }
            catch (Exception)
            {

                throw;
            }

        }

        internal List<MaternityLeaveR> getMaternityLeaveInfoForApprove(string eid, string currentYear, string OCODE)
        {
            try
            {
                using (var _context = new ERPSSLHBEntities())
                {
                    var ParamempID = new SqlParameter("@Eid", eid);
                    var ParamempID1 = new SqlParameter("@OCODE", OCODE);
                    var ParamempID2 = new SqlParameter("@currentYear", currentYear);
                    string SP_SQL = "HRM_GetMaternityLeaveListForApproveByReportingBoss @Eid,@OCODE,@currentYear";
                    return (_context.ExecuteStoreQuery<MaternityLeaveR>(SP_SQL, ParamempID, ParamempID1, ParamempID2)).ToList();
                }
            }
            catch (Exception)
            {

                throw;
            }

        }

        internal int MaternityLeaveAccept(List<HRM_LeaveApply> leaveApplyes)
        {

            try
            {

                foreach (HRM_LeaveApply aitem in leaveApplyes)
                {
                    _context.HRM_LeaveApply.AddObject(aitem);
                    _context.SaveChanges();
                }
                _context.SaveChanges();
                return 1;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }


        }
        public virtual List<HRM_ATTENDANCE> GetAllEmployee(string OCODE)
        {
            try
            {
                var query = (from lev in _context.HRM_ATTENDANCE
                             select lev);
                return query.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }

        }

        internal List<LeaveDetailsR> GetLeaveDetailsByEID(string employeeID)
        {
            try
            {
                using (var _context = new ERPSSLHBEntities())
                {
                    var ParamempID = new SqlParameter("@EID", employeeID);
                    string SP_SQL = "LeaveDeailsByEID @EID";
                    return (_context.ExecuteStoreQuery<LeaveDetailsR>(SP_SQL, ParamempID)).ToList();
                }
            }
            catch (Exception)
            {

                throw;
            }

        }

        internal LeaveDetailsR GetLeaveDetailByLeaveCode(string leaveCode)
        {
            //
            try
            {
                using (var _context = new ERPSSLHBEntities())
                {
                    var ParamempID = new SqlParameter("@LeaveCode", leaveCode);
                    string SP_SQL = "LeaveDeailsByLeaveCode @LeaveCode";
                    return (_context.ExecuteStoreQuery<LeaveDetailsR>(SP_SQL, ParamempID)).First();
                }
            }
            catch (Exception)
            {

                throw;
            }

        }

        internal int DeleteLeaveDetailsByLeaveCode(string LeaveCode)
        {
            try
            {

                using (var _context = new ERPSSLHBEntities())
                {
                    var ParamempID = new SqlParameter("@LeaveCode", LeaveCode);
                    string SP_SQL = "DeleteLeaveByLeaveCOde @LeaveCode";
                    return (_context.ExecuteStoreQuery<int>(SP_SQL, ParamempID)).First();
                }

            }
            catch (Exception)
            {

                throw;
            }
        }


        internal List<LeaveForReport> LeaveApplyReport(string eid, DateTime FormDate, DateTime ToDate)
        {
            try
            {
                using (var _context = new ERPSSLHBEntities())
                {
                    var ParamempID = new SqlParameter("@Eid", eid);
                    var ParamempID1 = new SqlParameter("@FormDate", FormDate);
                    var ParamempID2 = new SqlParameter("@ToDate", ToDate);
                    string SP_SQL = "HRM_Rpt_LeaveApplyDetailsById @Eid,@FormDate,@ToDate";
                    return (_context.ExecuteStoreQuery<LeaveForReport>(SP_SQL, ParamempID, ParamempID1, ParamempID2)).ToList();
                }

            }
            catch (Exception)
            {

                throw;
            }

        }
        internal int DeleteAttendanceByLeaveDate(List<HRM_LeaveApply> leaveApplyesDates)
        {
            DeleteAttendenceByCode(leaveApplyesDates);

            foreach (HRM_LeaveApply aitem in leaveApplyesDates)
            {
                var attendance = _context.HRM_ATTENDANCE.Where(a => a.Attendance_Date == aitem.LeaveDates && a.EID == aitem.Eid).FirstOrDefault();
                if (attendance != null)
                {
                    attendance.In_Time = null;
                    attendance.Out_Time = null;
                    attendance.InTime = null;
                    attendance.OutTime = null;
                    attendance.Late_Time = null;
                    attendance.Over_Time = null;
                    attendance.OT_Total = 0;
                    attendance.Status = _context.HRM_LEAVE_TYPE.FirstOrDefault(a => a.LEV_ID == aitem.LeaveTypeId).LEV_TYPE;
                    attendance.Update_Status = 1;
                    attendance.Attendance_Process_Status = false;
                    attendance.OCode = aitem.OCODE;
                    attendance.Edit_User = aitem.EDIT_USER;
                    attendance.Edit_Date = aitem.EDIT_DATE;
                    attendance.Attendance_Date = aitem.LeaveDates;
                    attendance.Leave_Code = aitem.LeaveCode;
                    attendance.Attendance_Day = Convert.ToDateTime(aitem.LeaveDates).DayOfWeek.ToString();
                    _context.SaveChanges();
                }
                else
                {
                    HRM_ATTENDANCE _attendance = new HRM_ATTENDANCE();
                    _attendance.EID = aitem.Eid;
                    _attendance.ShiftCode = _context.HRM_PersonalInformations.FirstOrDefault(a => a.EID == aitem.Eid).ShiftCode;
                    _attendance.In_Time = null;
                    _attendance.Out_Time = null;
                    _attendance.InTime = null;
                    _attendance.OutTime = null;
                    _attendance.Late_Time = null;
                    _attendance.Over_Time = null;
                    _attendance.OT_Total = 0;
                    _attendance.Status = _context.HRM_LEAVE_TYPE.FirstOrDefault(a => a.LEV_ID == aitem.LeaveTypeId).LEV_TYPE;
                    _attendance.Update_Status = 1;
                    _attendance.Attendance_Process_Status = false;
                    _attendance.OCode = aitem.OCODE;
                    _attendance.Edit_User = aitem.EDIT_USER;
                    _attendance.Edit_Date = aitem.EDIT_DATE;
                    _attendance.Attendance_Date = aitem.LeaveDates;
                    _attendance.Leave_Code = aitem.LeaveCode;
                    _attendance.Attendance_Day = Convert.ToDateTime(aitem.LeaveDates).DayOfWeek.ToString();
                    _context.HRM_ATTENDANCE.AddObject(_attendance);
                    _context.SaveChanges();

                }

            }
            return 1;
        }

        private int DeleteAttendenceByCode(List<HRM_LeaveApply> leaveApplyesDates)
        {
            try
            {
                int status = 0;
                HRM_LeaveApply _leaveobj = leaveApplyesDates.FirstOrDefault();
                List<HRM_ATTENDANCE> attendences = _context.HRM_ATTENDANCE.Where(x => x.Leave_Code == _leaveobj.LeaveCode).ToList();
                foreach (HRM_ATTENDANCE aitem in attendences)
                {
                    _context.HRM_ATTENDANCE.DeleteObject(aitem);
                    _context.SaveChanges();
                    status = 1;
                }
                return status;
            }
            catch (Exception)
            {

                throw;
            }

        }

        internal List<HRM_LeaveApply> GetLeaveDateByLeaveCode(string leaveCode)
        {

            List<HRM_LeaveApply> leaves = (from a in _context.HRM_LeaveApply
                                           where a.LeaveCode == leaveCode
                                           select a).ToList();
            return leaves;
        }

        internal string GetFirstReportingBossIDByLeaveCode(string LeaveCode)
        {
            string FirstReportingBoss = (from a in _context.HRM_LeaveApply
                                         where a.LeaveCode == LeaveCode
                                         select a.ReprotingBossHRM).FirstOrDefault();
            return FirstReportingBoss;
        }

        internal string GetSecondReportingBossIDByLeaveCode(string LeaveCode)
        {
            string SecondReportingBoss = (from a in _context.HRM_LeaveApply
                                          where a.LeaveCode == LeaveCode
                                          select a.ReprotingBoss1).FirstOrDefault();
            return SecondReportingBoss;

        }

        internal string GetThirdReportingBossIDByLeaveCode(string LeaveCode)
        {
            string ThirdReportingBoss = (from a in _context.HRM_LeaveApply
                                         where a.LeaveCode == LeaveCode
                                         select a.ReprotingBoss2).FirstOrDefault();
            return ThirdReportingBoss;
        }

        internal int CancelLeavesForFirstReportinBoss(List<HRM_LeaveApply> leaveApplyesDates)
        {

            foreach (HRM_LeaveApply aiem in leaveApplyesDates)
            {
                HRM_LeaveApply obj = _context.HRM_LeaveApply.FirstOrDefault(a => a.LeaveDates == aiem.LeaveDates && a.LeaveCode == aiem.LeaveCode);
                obj.ReportingBossHRMDisApproveDate = aiem.ReportingBossHRMDisApproveDate;
                obj.ReprotingBossHRmDisApporveStatus = aiem.ReprotingBossHRmDisApporveStatus;
                obj.IsPandingStatus = aiem.IsPandingStatus;
                _context.SaveChanges();
            }
            return 1;

        }

        internal int CancelLeavesForSecondReportinBoss(List<HRM_LeaveApply> leaveApplyesDates)
        {

            foreach (HRM_LeaveApply aiem in leaveApplyesDates)
            {
                HRM_LeaveApply obj = _context.HRM_LeaveApply.FirstOrDefault(a => a.LeaveDates == aiem.LeaveDates && a.LeaveCode == aiem.LeaveCode);
                obj.ReprotingBoss1DisApproveDate = aiem.ReprotingBoss1DisApproveDate;
                obj.ReprotingBoss1DisApproveStatus = aiem.ReprotingBoss1DisApproveStatus;
                obj.IsPandingStatus = aiem.IsPandingStatus;
                _context.SaveChanges();
            }
            return 1;
        }

        internal int CancelLeavesForThirdReportinBoss(List<HRM_LeaveApply> leaveApplyesDates)
        {
            foreach (HRM_LeaveApply aiem in leaveApplyesDates)
            {
                HRM_LeaveApply obj = _context.HRM_LeaveApply.FirstOrDefault(a => a.LeaveDates == aiem.LeaveDates && a.LeaveCode == aiem.LeaveCode);
                obj.ReportingBoss2ApproveDate = aiem.ReportingBoss2ApproveDate;
                obj.ReportingBoss2DisApporveStatus = aiem.ReportingBoss2DisApporveStatus;
                obj.IsPandingStatus = aiem.IsPandingStatus;
                _context.SaveChanges();
            }
            return 1;

        }

        internal List<HRM_LeaveApply> getLeaveApplyesByCode(string LeaveCode)
        {
            List<HRM_LeaveApply> hrmLeaves = (from a in _context.HRM_LeaveApply
                                              where a.LeaveCode == LeaveCode
                                              select a).ToList();
            return hrmLeaves;

        }

        internal List<HRM_LeaveApply> GetLeavesByEID(string eid)
        {
            List<HRM_LeaveApply> hrmLeaves = (from a in _context.HRM_LeaveApply
                                              where a.Eid == eid
                                              select a).ToList();
            return hrmLeaves;

        }

        internal int DeleteLeaveDetailsByEID(string eid)
        {
            try
            {

                using (var _context = new ERPSSLHBEntities())
                {
                    var ParamempID = new SqlParameter("@Eid", eid);
                    string SP_SQL = "DeleteLeaveByEID @Eid";
                    return (_context.ExecuteStoreQuery<int>(SP_SQL, ParamempID)).First();
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        internal int CheckAttendance(List<HRM_LeaveApply> leaveApplyesDates)
        {
            try
            {
                int status = 0;
                foreach (HRM_LeaveApply aitem in leaveApplyesDates)
                {
                    var attendance = _context.HRM_ATTENDANCE.Where(a => a.Attendance_Date == aitem.LeaveDates && a.EID == aitem.Eid && a.Status == "P").FirstOrDefault();
                    if (attendance != null)
                    {
                        status = 1;
                    }
                }
                return status;
            }
            catch (Exception)
            {

                throw;
            }
        }

        internal List<HRM_LEAVE_TYPE> ProbationPeriod(DateTime date, string eid)
        {
            try
            {
                List<HRM_LEAVE_TYPE> types = new List<HRM_LEAVE_TYPE>();
                HRM_PersonalInformations hrmpersonalinfo = _context.HRM_PersonalInformations.FirstOrDefault(x => x.EID == eid && (x.ProbationPeriodFrom >= date && x.ProbationPeriodTo <= date));
                if (hrmpersonalinfo != null)
                {
                    types = _context.HRM_LEAVE_TYPE.Where(n => n.LEV_ID != 1 && n.LEV_ID != 2 && n.LEV_ID != 3 && n.LEV_ID != 4).ToList();
                }
                return types;
            }
            catch (Exception)
            {

                throw;
            }
        }

        internal List<LeaveDetailsR> GetLeaveDetailsFoRFemaleByEID(string employeeID)
        {
            try
            {
                using (var _context = new ERPSSLHBEntities())
                {
                    var ParamempID = new SqlParameter("@EID", employeeID);
                    string SP_SQL = "LeaveDeailsForMaleByEID @EID";
                    return (_context.ExecuteStoreQuery<LeaveDetailsR>(SP_SQL, ParamempID)).ToList();
                }
            }
            catch (Exception)
            {

                throw;
            }

        }

        internal int DeleteAttendanceByLeave(List<HRM_LeaveApply> leaves)
        {

            foreach (HRM_LeaveApply aitem in leaves)
            {
                var attendance = _context.HRM_ATTENDANCE.Where(a => a.Attendance_Date == aitem.LeaveDates && a.EID == aitem.Eid).FirstOrDefault();
                if (attendance != null)
                {
                    _context.HRM_ATTENDANCE.DeleteObject(attendance);
                    _context.SaveChanges();
                }
            }
            return 1;
        }
    }
}
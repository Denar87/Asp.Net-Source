using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ERPSSL.HRM.DAL;
using ERPSSL.HRM.BLL;
using ERPSSL.HRM.DAL.Repository;

namespace ERPSSL.HRM.DAL
{
    public class TIME_SCHEDULE_DAL
    {
        private ERPSSLHBEntities _context = new ERPSSLHBEntities();

        //-------Insert------------------------------------
        public int InsertTimeSchedule(HRM_TIMESCHEDULE objTimeSchedule)
        {
            try
            {

                _context.HRM_TIMESCHEDULE.AddObject(objTimeSchedule);
                _context.SaveChanges();
                return 1;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        public int InsertDepartmentwiseShift(HRM_DepartmentWiseShift objTimeSchedule)
        {
            try
            {

                _context.HRM_DepartmentWiseShift.AddObject(objTimeSchedule);
                _context.SaveChanges();
                return 1;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }


        internal int UpdateTimeSchedule(HRM_TIMESCHEDULE objTimeSchedule, int sheduleId)
        {
            HRM_TIMESCHEDULE objTime = _context.HRM_TIMESCHEDULE.First(x => x.ScheduleId == sheduleId);
            //objTime.RegionId = objTimeSchedule.RegionId;
            //objTime.OfficeId = objTimeSchedule.OfficeId;
            //objTime.DepartmentId = objTimeSchedule.DepartmentId;
            objTime.ShiftCode = objTimeSchedule.ShiftCode;
            objTime.ShiftName = objTimeSchedule.ShiftName;
            objTime.ShiftType = objTimeSchedule.ShiftType;
            objTime.Weekend1 = objTimeSchedule.Weekend1;
            objTime.Weekend2 = objTimeSchedule.Weekend2;
            objTime.StartTime = objTimeSchedule.StartTime;
            objTime.EndTime = objTimeSchedule.EndTime;
            objTime.LateAllowed = objTimeSchedule.LateAllowed;
            objTime.TotalHour = objTimeSchedule.TotalHour;
            objTime.Weekend1_Duty = objTimeSchedule.Weekend1_Duty;
            objTime.Weekend1Duty_Hour = objTimeSchedule.Weekend1Duty_Hour;
            objTime.Weekend2_Duty = objTimeSchedule.Weekend2_Duty;
            objTime.Weekend2Duty_Hour = objTimeSchedule.Weekend2Duty_Hour;
            objTime.Edit_Date = objTimeSchedule.Edit_Date;
            objTime.Edit_User = objTimeSchedule.Edit_User;
            objTime.OCode = objTimeSchedule.OCode;
            _context.SaveChanges();
            return 1;
        }

        internal int UpdateTimeSchedule(HRM_DepartmentWiseShift objTimeSchedule, int sheduleId)
        {
            HRM_DepartmentWiseShift objTime = _context.HRM_DepartmentWiseShift.First(x => x.ScheduleId == sheduleId);
            objTime.RegionId = objTimeSchedule.RegionId;
            objTime.OfficeId = objTimeSchedule.OfficeId;
            objTime.DepartmentId = objTimeSchedule.DepartmentId;
            objTime.ShiftCode = objTimeSchedule.ShiftCode;
            objTime.ShiftName = objTimeSchedule.ShiftName;
            objTime.ShiftType = objTimeSchedule.ShiftType;
            objTime.Weekend1 = objTimeSchedule.Weekend1;
            objTime.Weekend2 = objTimeSchedule.Weekend2;
            objTime.StartTime = objTimeSchedule.StartTime;
            objTime.EndTime = objTimeSchedule.EndTime;
            objTime.LateAllowed = objTimeSchedule.LateAllowed;
            objTime.TotalHour = objTimeSchedule.TotalHour;
            objTime.Weekend1_Duty = objTimeSchedule.Weekend1_Duty;
            objTime.Weekend1Duty_Hour = objTimeSchedule.Weekend1Duty_Hour;
            objTime.Weekend2_Duty = objTimeSchedule.Weekend2_Duty;
            objTime.Weekend2Duty_Hour = objTimeSchedule.Weekend2Duty_Hour;
            objTime.Edit_Date = objTimeSchedule.Edit_Date;
            objTime.Edit_User = objTimeSchedule.Edit_User;
            objTime.OCode = objTimeSchedule.OCode;
            _context.SaveChanges();
            return 1;
        }

        //-------GetAll------------------------------------
        public virtual List<HRM_TIMESCHEDULE> GetAllSchedule(string OCODE)
        {
            try
            {
                var query = (from tms in _context.HRM_TIMESCHEDULE
                             where tms.OCode == OCODE
                             select tms).OrderBy(tms=>tms.ShiftName);

                return query.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        public virtual List<HRM_DepartmentWiseShift> GetAllDepartmentSchedule(string OCODE)
        {
            try
            {
                var query = (from tms in _context.HRM_DepartmentWiseShift
                             where tms.OCode == OCODE
                             select tms).OrderBy(tms => tms.ShiftName);

                return query.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        public virtual List<TIMESCHEDULE> GetDistinctSchedule()
        {
            try
            {
                using (var _context = new ERPSSLHBEntities())
                {

                    string SP_SQL = "HRM_Get_DistinctShift";
                    return (_context.ExecuteStoreQuery<TIMESCHEDULE>(SP_SQL)).ToList();
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        public  List<HRM_TIMESCHEDULE> GetDistinctSchedule(string OCODE)
        {
            try
            {
                //List<HRM_TIMESCHEDULE> query = new List<HRM_TIMESCHEDULE>(); 

                var query = (from tms in _context.HRM_TIMESCHEDULE
                             where tms.OCode == OCODE
                             select tms).ToList();

                 return query.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        public virtual List<HRM_DepartmentWiseShift> GetScheduleByCode(string OCODE, string shiftCode)
        {
            try
            {
                var query = (from tms in _context.HRM_DepartmentWiseShift
                             where tms.OCode == OCODE && tms.ShiftCode==shiftCode
                             select tms);

                return query.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        public virtual List<HRM_TIMESCHEDULE> GetScheduleById(string OCODE, string scheduleId)
        {
            try
            {
                int sId = Convert.ToInt32(scheduleId);
                var query = (from tms in _context.HRM_TIMESCHEDULE
                             where tms.OCode == OCODE && tms.ScheduleId == sId
                             select tms);

                return query.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        public virtual List<HRM_DepartmentWiseShift> GetDepartwiseScheduleById(string OCODE, string scheduleId)
        {
            try
            {
                int sId = Convert.ToInt32(scheduleId);
                var query = (from tms in _context.HRM_DepartmentWiseShift
                             where tms.OCode == OCODE && tms.ScheduleId == sId
                             select tms);

                return query.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        internal List<HRM_DepartmentWiseShift> GetShiftByDepartment(int RegionId, int OfficeId, int DepartmentId, string Ocode)
        {
            try
            {
                var query = (from tms in _context.HRM_DepartmentWiseShift
                             where tms.OCode == Ocode && tms.OfficeId == OfficeId && tms.RegionId == RegionId && tms.DepartmentId==DepartmentId
                             select tms).OrderBy(x => x.ShiftCode);
                return query.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }

        }

        public virtual List<HRM_TIMESCHEDULE> GetAllScheduleByCode(string OCODE, string shiftCode)
        {
            try
            {
                var query = (from tms in _context.HRM_TIMESCHEDULE
                             where tms.OCode == OCODE && tms.ShiftCode == shiftCode
                             select tms);

                return query.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

    }
}
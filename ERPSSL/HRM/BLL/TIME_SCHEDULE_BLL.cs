using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ERPSSL.HRM.DAL;
using ERPSSL.HRM.DAL.Repository;

namespace ERPSSL.HRM.BLL
{
    public class TIME_SCHEDULE_BLL
    {
        TIME_SCHEDULE_DAL objCtx_DAL = new TIME_SCHEDULE_DAL();
        ERPSSLHBEntities context = new ERPSSLHBEntities();

        //-------Insert------------------------------------
        public int InsertTimeSchedule(HRM_TIMESCHEDULE objtimeSchedule)
        {
            return objCtx_DAL.InsertTimeSchedule(objtimeSchedule);
        }

        public int InsertDepartmentwiseShift(HRM_DepartmentWiseShift objtimeSchedule)
        {
            return objCtx_DAL.InsertDepartmentwiseShift(objtimeSchedule);
        }

        internal int UpdateTimeSchedule(HRM_TIMESCHEDULE objTimeSchedule, int scheduleId)
        {
            return objCtx_DAL.UpdateTimeSchedule(objTimeSchedule, scheduleId);
        }

        internal int UpdateTimeSchedule(HRM_DepartmentWiseShift objTimeSchedule, int scheduleId)
        {
            return objCtx_DAL.UpdateTimeSchedule(objTimeSchedule, scheduleId);
        }
        //-------GetAll------------------------------------
        public virtual List<HRM_TIMESCHEDULE> GetAllSchedule(string OCODE)
        {
            return objCtx_DAL.GetAllSchedule(OCODE);
        }

        public virtual List<HRM_DepartmentWiseShift> GetAllDepartmentSchedule(string OCODE)
        {
            return objCtx_DAL.GetAllDepartmentSchedule(OCODE);
        }

        public virtual List<HRM_TIMESCHEDULE> GetDistinctSchedule(string OCODE)
        {
            return objCtx_DAL.GetDistinctSchedule(OCODE);
        }

        public virtual List<TIMESCHEDULE> GetDistinctSchedule()
        {
            return objCtx_DAL.GetDistinctSchedule();
        }

        public virtual List<HRM_DepartmentWiseShift> GetScheduleByCode(string OCODE, string shiftCode)
        {
            return objCtx_DAL.GetScheduleByCode(OCODE,shiftCode);
        }
        public virtual List<HRM_TIMESCHEDULE> GetScheduleById(string OCODE, string scheduleId)
        {
            return objCtx_DAL.GetScheduleById(OCODE, scheduleId);
        }
        public virtual List<HRM_DepartmentWiseShift> GetDepartwiseScheduleById(string OCODE, string scheduleId)
        {
            return objCtx_DAL.GetDepartwiseScheduleById(OCODE, scheduleId);
        }
        internal List<HRM_DepartmentWiseShift> GetShiftByDepartment(int RegionId, int OfficeId, int DepartmentId, string Ocode)
        {
            return objCtx_DAL.GetShiftByDepartment(RegionId, OfficeId, DepartmentId, Ocode);
        }

        public virtual List<HRM_TIMESCHEDULE> GetAllScheduleByCode(string OCODE, string shiftCode)
        {
            return objCtx_DAL.GetAllScheduleByCode(OCODE, shiftCode);
        }

        //public IEnumerable<HRM_EMPLOYEES_VIEWER> GetInfoByShift(string shiftid)
        //{
        //    return objCtx_DAL.GetInfoByShift(shiftid);
        //}
    }
}
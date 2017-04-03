using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ERPSSL.HRM.DAL;
using ERPSSL.HRM.DAL;
using ERPSSL.HRM.DAL.Repository;

namespace ERPSSL.HRM.BLL
{
    public class HOLIDAYS_BLL
    {
        HOLIDAYS_DAL objCtx_DAL = new HOLIDAYS_DAL();

        //-------Insert------------------------------------
        public int InsertHoli_Days(List<HRM_HOLIDAYS> hrmHolidaysList)
        {
            return objCtx_DAL.InsertHoli_Days(hrmHolidaysList);
        }

        //-------Update------------------------------------
        public int UpdateSub_Holidays(List<HRM_HOLIDAYS> objHoli, string Ocode )
        {

            return objCtx_DAL.UpdateSub_Holidays(objHoli, Ocode);
        }

        //-------GetAll------------------------------------
        public virtual List<HolidayTypeR> GetAllHolidays(string OCODE)
        {
            return objCtx_DAL.GetAllHolidays(OCODE);
        }

        //-------GetAll------------------------------------
        public virtual List<HRM_HOLIDAY_TYPE> GetAllHolidaysType(string OCODE)
        {
            return objCtx_DAL.GetAllHolidaysType(OCODE);
        }

        internal int InsertHolidayType(HRM_HOLIDAY_TYPE objDeg)
        {
            return objCtx_DAL.InsertHolidayType(objDeg);
        }

        internal List<HRM_HOLIDAY_TYPE> GetHolidayTypeIdandOcode(string holidayTypeId, string OCODE)
        {

            return objCtx_DAL.GetHolidayTypeIdandOcode(holidayTypeId,OCODE);
        }

        internal int UpdateUpdateHolidayType(DAL.HRM_HOLIDAY_TYPE objDeg, int HolidayTypeId)
        {
            return objCtx_DAL.UpdateUpdateHolidayType(objDeg, HolidayTypeId);

        }

        internal List<HRM_HOLIDAY_TYPE> GetAllHolidayType(string OCODE)
        {
            return objCtx_DAL.GetAllHolidayType(OCODE);
        }


        public List<HRM_HOLIDAYS> GetHolidayIdandOcode(string holidayId, string oCode)
        {
            return objCtx_DAL.GetHolidayIdandOcode(holidayId, oCode);
        }

        internal List<HolidayTypeR> GetAllHolidaysByHolidayCode(string HodlidayCode, string oCode)
        {
            return objCtx_DAL.GetAllHolidaysByHolidayCode(HodlidayCode, oCode);
        }
    }
}
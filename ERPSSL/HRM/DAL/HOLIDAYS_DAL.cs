using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ERPSSL.HRM.BLL;
using ERPSSL.HRM.DAL;
using ERPSSL.HRM.DAL.Repository;
using System.Data;
using System.Data.SqlClient;

namespace ERPSSL.HRM.DAL
{
    public class HOLIDAYS_DAL
    {
        private ERPSSLHBEntities _context = new ERPSSLHBEntities();

        //-------Insert------------------------------------
        public int InsertHoli_Days(List<HRM_HOLIDAYS> hrmHolidaysList)
        {
            try
            {
                foreach (HRM_HOLIDAYS anItem in hrmHolidaysList)
                {
                    _context.HRM_HOLIDAYS.AddObject(anItem);
                }
                _context.SaveChanges();
                return 1;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //-------Update------------------------------------
        public int UpdateSub_Holidays(List<HRM_HOLIDAYS> objHoli, string holCode)
        {
            try
            {                
                DeleteHolidayType(holCode);

                    foreach (HRM_HOLIDAYS anItem in objHoli)
                    {
                        _context.HRM_HOLIDAYS.AddObject(anItem);
                    }
                _context.SaveChanges();
                return 1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void DeleteHolidayType(string HolCode)
        {
            using (var _context = new ERPSSLHBEntities())
            {
                var ParamempID = new SqlParameter("@holidayCode", HolCode);
                string SP_SQL = "HRM_DeleteHoliday @holidayCode";
                _context.ExecuteStoreQuery<REmployee>(SP_SQL, ParamempID).ToList();
            }

        }

        //-------GetAll------------------------------------
        public virtual List<HolidayTypeR> GetAllHolidays(string OCODE)
        {
            //var query = (from hl in _context.HRM_HOLIDAYS
            //             where hl.OCODE == OCODE
            //             select hl).OrderBy(hl => hl.HOLIDAY_DATE);

            //var list = query.ToList();
            //return list;

            List<HolidayTypeR> holidayTypes = (from hl in _context.HRM_HOLIDAYS
                                               join ht in _context.HRM_HOLIDAY_TYPE on hl.HOLIDAY_TYPE_ID equals ht.HOLIDAY_TYPE_ID
                                               where hl.OCODE == OCODE                                              
                                              group new { hl,ht } by new { hl.HolidayCode, ht.HOLIDAY_TYPE_ID }
                                                     into grp

                                               select new HolidayTypeR
                                               {
                                                  
                                                   HolidayCode = grp.Key.HolidayCode,

                                                   HolidayToDate = grp.Max(s => s.hl.HOLIDAY_DATE),
                                                   HolidayFromDate = grp.Min(s => s.hl.HOLIDAY_DATE),
                                                   HolidayName = grp.Max(s => s.hl.HOLIDAY_NAME),
                                                   HolidayTypeName = grp.Max(s => s.ht.HOLIDAY_TYPE_NAME)
                                               }).ToList();

            return holidayTypes;

        }

        //-------GetAll------------------------------------
        public virtual List<HRM_HOLIDAY_TYPE> GetAllHolidaysType(string OCODE)
        {
            var query = (from hl in _context.HRM_HOLIDAY_TYPE
                         where hl.OCODE == OCODE
                         select hl).OrderBy(hl => hl.HOLIDAY_TYPE_ID);

            var list = query.ToList();
            return list;
        }

        internal int InsertHolidayType(HRM_HOLIDAY_TYPE objDeg)
        {
            try
            {
                _context.HRM_HOLIDAY_TYPE.AddObject(objDeg);
                _context.SaveChanges();
                return 1;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        internal List<HRM_HOLIDAY_TYPE> GetHolidayTypeIdandOcode(string holidayTypeId, string OCODE)
        {
            int htid = Convert.ToInt16(holidayTypeId);
            var query = (from hl in _context.HRM_HOLIDAY_TYPE
                         where hl.OCODE == OCODE && hl.HOLIDAY_TYPE_ID == htid
                         select hl).OrderBy(hl => hl.HOLIDAY_TYPE_ID);

            var list = query.ToList();
            return list;
        }

        internal int UpdateUpdateHolidayType(HRM_HOLIDAY_TYPE objDeg, int HolidayTypeId)
        {
            try
            {
                HRM_HOLIDAY_TYPE obj = _context.HRM_HOLIDAY_TYPE.First(x => x.HOLIDAY_TYPE_ID == HolidayTypeId);
                obj.HOLIDAY_TYPE_NAME = objDeg.HOLIDAY_TYPE_NAME;
                obj.EDIT_USER = objDeg.EDIT_USER;
                obj.EDIT_DATE = objDeg.EDIT_DATE;
                obj.OCODE = objDeg.OCODE;
                _context.SaveChanges();
                return 1;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        internal List<HRM_HOLIDAY_TYPE> GetAllHolidayType(string OCODE)
        {

            var query = (from hl in _context.HRM_HOLIDAY_TYPE
                         where hl.OCODE == OCODE
                         select hl).OrderBy(hl => hl.HOLIDAY_TYPE_ID);

            var list = query.ToList();
            return list;

        }

        public List<HRM_HOLIDAYS> GetHolidayIdandOcode(string holidayId, string oCode)
        {
            int HolidayId = Convert.ToInt32(holidayId);
            List<HRM_HOLIDAYS> hrmHolidaysList = (_context.HRM_HOLIDAYS.Where(holi => holi.OCODE == oCode && holi.HOLIDAY_ID == HolidayId)).OrderBy(x => x.HOLIDAY_ID).ToList();
            return hrmHolidaysList;
        }

        internal List<HolidayTypeR> GetAllHolidaysByHolidayCode(string HodlidayCode, string oCode)
        {
            return (from hl in _context.HRM_HOLIDAYS
                                               join ht in _context.HRM_HOLIDAY_TYPE on hl.HOLIDAY_TYPE_ID equals ht.HOLIDAY_TYPE_ID
                                               where  hl.HolidayCode == HodlidayCode
                                                group hl by hl.HolidayCode into grp                                             
                                                 

                                                   select new HolidayTypeR
                                                   {

                                                       HolidayCode = grp.Key,

                                                       HolidayToDate = grp.Max(s => s.HOLIDAY_DATE),
                                                       HolidayFromDate = grp.Min(s => s.HOLIDAY_DATE),
                                                       HolidayName = grp.Max(s => s.HOLIDAY_NAME),
                                                       HolidayTypeId = grp.Max(s => s.HOLIDAY_TYPE_ID)
                                                   }).ToList();

            

        }
    }
}
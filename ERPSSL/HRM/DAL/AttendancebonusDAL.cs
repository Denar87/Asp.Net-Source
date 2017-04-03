using ERPSSL.HRM.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ERPSSL.HRM.DAL
{
    public class AttendancebonusDAL
    {
        private ERPSSLHBEntities _context = new ERPSSLHBEntities();
        internal List<HRM_Office> GetAllOffice(string OCODE)
        {
            try
            {
                var query = (from dept in _context.HRM_Office
                             where dept.OCODE == OCODE
                             select dept).OrderBy(x => x.OfficeID);


                return query.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
           
        }

        internal List<DesignationR> GetDesgination(string OCODE)
        {
            try
            {
                using (var _context = new ERPSSLHBEntities())
                {
                    var ParamempID = new SqlParameter("@ocode", OCODE);
                    string SP_SQL = "HRM_GetDesignation @ocode";
                    return (_context.ExecuteStoreQuery<DesignationR>(SP_SQL, ParamempID)).ToList();
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        internal int SaveAttendanceBonus(HRM_AttendanceBouns hrmAttendanceBouns)
        {
            try
            {

                _context.HRM_AttendanceBouns.AddObject(hrmAttendanceBouns);
                _context.SaveChanges();
                return 1;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        internal List<DesginationListR> GetAttendanceBonusList(string OCODE)
        {
            try
            {
                using (var _context = new ERPSSLHBEntities())
                {
                    var ParamempID = new SqlParameter("@ocode", OCODE);
                    string SP_SQL = "HRM_AttendanceBonusList @ocode";
                    return (_context.ExecuteStoreQuery<DesginationListR>(SP_SQL, ParamempID)).ToList();
                }

            }
            catch (Exception)
            {

                throw;
            }

        }

        internal List<HRM_AttendanceBouns> getAttendanceBounsId(string atId, string OCODE)
        {

            try
            {
                int id = Convert.ToInt16(atId);
                var query = (from ab in _context.HRM_AttendanceBouns
                             where ab.OCODE == OCODE && ab.attendanceBounsId==id
                             select ab).OrderBy(x => x.attendanceBounsId);


                return query.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        internal int UpdateAttendanceBonus(HRM_AttendanceBouns hrmAttendanceBouns, int id)
        {
            try
            {
                HRM_AttendanceBouns obj = _context.HRM_AttendanceBouns.First(x => x.attendanceBounsId == id);

                obj.AttendanceDays1 = hrmAttendanceBouns.AttendanceDays1;
                obj.AttendanceDays2 = hrmAttendanceBouns.AttendanceDays2;
                obj.Desgination = hrmAttendanceBouns.Desgination;
                obj.Amount1 = hrmAttendanceBouns.Amount1;
                obj.Amount2 =hrmAttendanceBouns.Amount2;
                obj.OfficeId = hrmAttendanceBouns.OfficeId;

                obj.EDIT_USER = hrmAttendanceBouns.EDIT_USER;
                obj.EDIT_DATE = hrmAttendanceBouns.EDIT_DATE;
                obj.OCODE = hrmAttendanceBouns.OCODE;


                _context.SaveChanges();
                return 1;
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }
    }
}
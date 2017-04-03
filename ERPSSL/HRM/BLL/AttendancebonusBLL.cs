using ERPSSL.HRM.DAL;
using ERPSSL.HRM.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPSSL.HRM.BLL
{
    public class AttendancebonusBLL
    {
        AttendancebonusDAL attenanceBounesDal = new AttendancebonusDAL();
        internal List<HRM_Office> GetAllOffice(string OCODE)
        {
            return attenanceBounesDal.GetAllOffice(OCODE);
        }

        internal List<DesignationR> GetDesgination(string OCODE)
        {
            return attenanceBounesDal.GetDesgination(OCODE);
        }

        internal int SaveAttendanceBonus(HRM_AttendanceBouns hrmAttendanceBouns)
        {
            return attenanceBounesDal.SaveAttendanceBonus(hrmAttendanceBouns);
        }

        internal List<DesginationListR> GetAttendanceBonusList(string OCODE)
        {
            return attenanceBounesDal.GetAttendanceBonusList(OCODE);
        }

        internal List<HRM_AttendanceBouns> getAttendanceBounsId(string atId, string OCODE)
        {
            return attenanceBounesDal.getAttendanceBounsId(atId, OCODE);
        }

        internal int UpdateAttendanceBonus(HRM_AttendanceBouns hrmAttendanceBouns, int id)
        {
            return attenanceBounesDal.UpdateAttendanceBonus(hrmAttendanceBouns, id);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ERPSSL.HRM.DAL;

namespace ERPSSL.HRM.BLL
{
    public class AttendanceReason_BLL
    {
        AttendanceReason_DAL objCtx_DAL = new AttendanceReason_DAL();
        ERPSSLHBEntities context = new ERPSSLHBEntities();

        //-------Insert HRM_AttendanceReason------------------------------------
        public int InsertAttendanceReason(HRM_AttendanceReason objAttendanceReason)
        {
            return objCtx_DAL.InsertAttendanceReason(objAttendanceReason);
        }

        public int UpdateAttReason(HRM_AttendanceReason objAttendanceReason,int id)
        {
            return objCtx_DAL.UpdateAttReason(id, objAttendanceReason);
        }

        //-------GetAll HRM_AttendanceReason------------------------------------
        public virtual List<HRM_AttendanceReason> GetAllattReason(string OCODE)
        {
            return objCtx_DAL.GetAllattReason(OCODE);
        }

        internal List<HRM_AttendanceReason> GetAllattReasonByID(string id,string OCODE)
        {
            return objCtx_DAL.GetAllattReasonById(id,OCODE);
        }

        //-------Insert HRM_AttendanceReason_Individual------------------------------------
        public int InsertAttendanceReasonIndividual(HRM_AttendanceReason_Individual objAttendanceReasonIndividual)
        {
            return objCtx_DAL.InsertAttendanceReasonIndividual(objAttendanceReasonIndividual);
        }

        public int UpdateAttReasonIndividual(HRM_AttendanceReason_Individual objAttendanceReasonInd, int id)
        {
            return objCtx_DAL.UpdateAttReasonIndividual(objAttendanceReasonInd,id);
        }

        //-------GetAll HRM_AttendanceReason_Individual------------------------------------
        public virtual List<HRM_AttendanceReason_Individual> GetAllattReasonIndividual(string OCODE)
        {
            return objCtx_DAL.GetAllattReasonIndividual(OCODE);
        }

        public virtual List<HRM_AttendanceReason_Individual> GetAllattReasonIndividualById(string id,string OCODE)
        {
            return objCtx_DAL.GetAllattReasonIndividualById(id,OCODE);
        }

        //-------Insert HRM_TimeScheduleByReligion------------------------------------
        public int InsertTimeScheduleByReligion(HRM_TimeScheduleByReligion objTimeScheduleByReligion)
        {
            return objCtx_DAL.InsertTimeScheduleByReligion(objTimeScheduleByReligion);
        }

        internal int InsertAtt_ReasonIndByReligion(int regionId, int officeId, int departmentId, string religion, DateTime date, TimeSpan inTime, TimeSpan outTime, int reasonTypeId, string reasonType, string remarks, Guid editUser, DateTime editDate, string oCode)
        {
            return objCtx_DAL.InsertAtt_ReasonIndByReligion(regionId, officeId, departmentId, religion, date, inTime, outTime, reasonTypeId, reasonType, remarks, editUser, editDate, oCode);
        }


        internal int InsertAtt_ReasonIndByDepartment(int regionId, int officeId, int departmentId, DateTime date, TimeSpan inTime, TimeSpan outTime, int reasonTypeId, string reasonType, string remarks, Guid editUser, DateTime editDate, string oCode)
        {
            return objCtx_DAL.InsertAtt_ReasonIndByDepartment(regionId, officeId, departmentId, date, inTime, outTime, reasonTypeId, reasonType, remarks, editUser, editDate, oCode);
        }

        //-------GetAll HRM_TimeScheduleByReligion------------------------------------
        public virtual List<HRM_TimeScheduleByReligion> GetAllTimeScheduleByReligion(string OCODE)
        {
            return objCtx_DAL.GetAllTimeScheduleByReligion(OCODE);
        }

        public IEnumerable<HRM_EMPLOYEES_VIEWER> GetEmployeeDetailsID(string employeeID, string OCODE)
        {
            return objCtx_DAL.GetEmployeeDetailsID(employeeID, OCODE);
        }
        public int InsertAttendanceReason(List<HRM_AttendanceReason> lstHRM_AttendanceReason)
        {
            return objCtx_DAL.InsertAttendanceReason(lstHRM_AttendanceReason);
        }

    }
}
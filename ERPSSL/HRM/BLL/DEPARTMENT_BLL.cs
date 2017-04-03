using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ERPSSL.HRM.DAL;
using ERPSSL.HRM.DAL.Repository;

namespace ERPSSL.HRM.BLL
{
    public class DEPARTMENT_BLL
    {
        DEPARTMENT_DAL objCtx_DAL = new DEPARTMENT_DAL();

        //-------Insert------------------------------------
        public int InsertDepartment(HRM_DEPARTMENTS objDept)
        {
            return objCtx_DAL.InsertDepartment(objDept);
        }

        internal List<HRM_DEPARTMENTS> GetDepartmentByOffice(int RegionId, int OfficeId, string Ocode)
        {
            return objCtx_DAL.GetDepartmentByOffice(RegionId, OfficeId, Ocode);
        }

        //-------Update------------------------------------
        public int UpdateDepartment(HRM_DEPARTMENTS objDept, int departmentID)
        {
            return objCtx_DAL.UpdateDepartment(objDept, departmentID);
        }

        //-------Delete------------------------------------
        public int DeleteDepartment(int departmentID)
        {
            return objCtx_DAL.DeleteDepartment(departmentID);
        }

        //-------GetAll------------------------------------
        public virtual List<HRM_DEPARTMENTS> GetAllDepartment(string OCODE)
        {
            return objCtx_DAL.GetAllDepartment(OCODE);
        }

        //-------------------------------------------

        internal IEnumerable<Department> GetDepartment(string OCODE)
        {
            return objCtx_DAL.GetDepartment(OCODE);
        }

        internal HRM_DEPARTMENTS GetDepartmentByDepartmentId(string deparId, string OCODE)
        {

            return objCtx_DAL.GetOfficeById(deparId, OCODE);

        }

        internal List<HRM_DEPARTMENTS> GetDepartmentByOfficeIdAndOCode(int? officeId, string OCODE)
        {
            return objCtx_DAL.GetDepartmentByOfficeIdAndOCode(officeId, OCODE);
        }

        internal List<HRM_DEPARTMENTS> GetDepartmentByOfficeId(int officeId, string OCODE)
        {
            return objCtx_DAL.GetDepartmentByOfficeId(officeId, OCODE);

        }

        internal List<HRM_DEPARTMENTS> DepartmentList(string OCODE)
        {
            return objCtx_DAL.DepartmentList(OCODE);
        }

        internal List<HRM_PersonalInformations> GetDepartmentByReportingBossId(string OCODE, string firstReportingBossId)
        {
            return objCtx_DAL.GetDepartmentByReportingBossId(OCODE, firstReportingBossId);
        }

        internal List<HRM_PersonalInformations> GetAllAsignTo(string OCODE)
        {
            return objCtx_DAL.GetAllAsignTo(OCODE);
        }

        internal List<HRM_DEPARTMENTS> GetDepartmentByOfficeCode(string officeCode, string OCODE)
        {
            return objCtx_DAL.GetDepartmentByOfficeCode(officeCode, OCODE);

        }

    }
}
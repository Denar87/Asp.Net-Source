using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ERPSSL.HRM.DAL;
using ERPSSL.HRM.DAL.Repository;

namespace ERPSSL.HRM.BLL
{
    public class Increment_BLL
    {
        Increment_DAL objIncrementDal = new Increment_DAL();
        internal List<HRM_Regions> GetAllRegion(string OCODE)
        {
            return objIncrementDal.GetAllRegion(OCODE);
        }

        internal List<HRM_Office> GetOfficeByResionId(int RegionId)
        {

            return objIncrementDal.GetOfficeByResionId(RegionId);
        }


        public IEnumerable<HRM_PersonalInfoInc> GetEmployees(int officeId)
        {
            return objIncrementDal.GetEmployees(officeId);
        }


        internal int SaveIncremntTemp(List<HRM_TemporySalaryIncrement> EMP_LIST)
        {
            return objIncrementDal.SaveIncremntTemp(EMP_LIST);
        }
        internal IEnumerable<HRM_DEPARTMENTS> GetDepartmentByOfficeId(int officeID)
        {
            return objIncrementDal.GetDepartmentByOfficeId(officeID);
        }
        internal IEnumerable<HRM_PersonalInfoInc> GetEmployeesByDepartmentId(int DepartmentId)
        {
            return objIncrementDal.GetEmployeesByDepartmentId(DepartmentId);
        }
        internal IEnumerable<SalaryIncrementRep> GetEmployeesInfoFromTemporyEmoloyeeTable()
        {
            return objIncrementDal.GetEmployeesInfoFromTemporyEmoloyeeTable();

        }
        internal int DeleteSlaryIncrementTemporyInfoByEmployeId(string eid, string OCODE)
        {
            return objIncrementDal.DeleteSlaryIncrementTemporyInfoByEmployeId(eid, OCODE);
        }
        internal int DeleteTemporyTableInfo(List<HRM_SalaryIncrement> EMP_LIST)
        {
            return objIncrementDal.DeleteTemporyTableInfo(EMP_LIST);
        }
        internal int UpdateIncrementSalary(HRM_SalaryIncrement objEmp)
        {
            return objIncrementDal.UpdateIncrementSalary(objEmp);
        }

        internal int SaveIncremntTemp(HRM_SalaryIncrement objEmp)
        {

            return objIncrementDal.SaveIncremntTemp(objEmp);
        }

        internal int SalaryUpdate(HRM_SalaryUpdate objEmp)
        {
            return objIncrementDal.SalaryUpdate(objEmp);

        }
    }
}
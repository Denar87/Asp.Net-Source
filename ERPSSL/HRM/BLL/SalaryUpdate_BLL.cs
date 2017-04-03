using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ERPSSL.HRM.DAL;

namespace ERPSSL.HRM.BLL
{
    public class SalaryUpdate_BLL
    {
        SalaryUpdate_DAL salaryupdate = new SalaryUpdate_DAL();
        //-------GetDetails------------------------------------
       
        //-------GetDetails------------------------------------
        public IEnumerable<HRM_EMP_SALARY_UPDATE> GetEmployeeID(string employeeID, string OCODE)
        {
            return salaryupdate.GetEmployeeID(employeeID, OCODE);
        }

        //Update salary
       
        //public int UpdateSalary(HRM_DESIGNATIONS objDesignation, string employeeID)
        //{

        //    return salaryupdate.UpdateSalary(objDesignation, employeeID);

        //}
        public int UpdateSalary(HRM_PersonalInformations objperonal, string employeeID)
        {
            return salaryupdate.UpdateSalary(objperonal, employeeID);
        }


        internal List<HRM_DESIGNATIONS> GetAllDesignation()
        {
            return salaryupdate.GetAllDesignation();
        }



        internal bool CheckDesignation(string Desgination, string Grad, decimal Gosssalary)
        {
            return salaryupdate.CheckDesignation(Desgination, Grad, Gosssalary);
        }


        internal List<HRM_PersonalInformations> GetEmployeesForSalaryIncrement(string OCODE)
        {
            return salaryupdate.GetEmployeesForSalaryIncrement(OCODE);
        }
    }
}
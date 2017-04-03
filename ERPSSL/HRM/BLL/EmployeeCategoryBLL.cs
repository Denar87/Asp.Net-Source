using ERPSSL.HRM.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPSSL.HRM.BLL
{
    public class EmployeeCategoryBLL
    {
        EmployeeCategoryDAL employeeCategorydal = new EmployeeCategoryDAL();
        internal List<HRM_EmployeeCategory> getEmployeeCategoryes(string Ocode)
        {

            return employeeCategorydal.getEmployeeCategoryes(Ocode);
        }

        internal int InsertEmployeeCategory(HRM_EmployeeCategory employeeTypeObj)
        {
            return employeeCategorydal.InsertEmployeeCategory(employeeTypeObj);
        }

        internal int UpdateEmployeeCategory(HRM_EmployeeCategory employeeTypeObj, int Id)
        {

            return employeeCategorydal.UpdateEmployeeCategory(employeeTypeObj, Id);
        }

        internal List<HRM_EmployeeCategory> GeEmployeeCategoroyesById(string employeeTypeId, string OCODE)
        {
            return employeeCategorydal.GeEmployeeCategoroyesById(employeeTypeId, OCODE);
        }
    }
}
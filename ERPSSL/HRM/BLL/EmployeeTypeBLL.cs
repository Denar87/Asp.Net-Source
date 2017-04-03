using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ERPSSL.HRM.DAL;

namespace ERPSSL.HRM.BLL
{
    public class EmployeeTypeBLL
    {
        EmployeeTypeDAL employeeDalObj = new EmployeeTypeDAL();
        internal int InsertEmployeeType(HRM_EmployeeType employeeTypeObj)
        {
            return employeeDalObj.InsertEmployeeType(employeeTypeObj);           

        }

        internal int UpdateEmployeeType(HRM_EmployeeType employeeTypeObj, int leaveTypeId)
        {
            return employeeDalObj.UpdateEmployeeType(employeeTypeObj, leaveTypeId);      
        }

        internal List<HRM_EmployeeType> GetEmployeeType(string Ocode)
        {
            return employeeDalObj.GetEmployeeType(Ocode);  
        }

        internal List<HRM_EmployeeType> GeEmployeeTypes(string employeeTypeId, string OCODE)
        {
            return employeeDalObj.GeEmployeeTypes(employeeTypeId, OCODE); 
        }
    }
}
using ERPSSL.Dashboard.DAL;
using ERPSSL.Dashboard.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPSSL.Dashboard.BLL
{
    public class EmployeeDetailsBLL
    {
        EmployeeDetailsDAL _EmployeeDetailsdal = new EmployeeDetailsDAL();
        internal EmployeeDetailsR GetEmployeeDetails()
        {


            return _EmployeeDetailsdal.GetEmployeeDetails();
        }
        internal EmployeeDetailsR GetLastMonthEmpDetails()
        {


            return _EmployeeDetailsdal.GetLastMonthEmpDetails();
        }
        internal AttendanceDetailsR GetAttendanceDetails()
        {
            return _EmployeeDetailsdal.GetAttendanceDetails();
        }

        internal InventoryDetailsR GetInventoryDetails()
        {
            return _EmployeeDetailsdal.GetInventoryDetails();
        
        }

        internal POSDetails GetPosDetails()
        {
            return _EmployeeDetailsdal.GetPosDetails();

        }
        internal CommercialR GetCommercialDetails()
        {
            return _EmployeeDetailsdal.GetCommercialDetails();
        }

    }
}
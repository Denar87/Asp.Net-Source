using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPSSL.HRM.DAL
{
    public class EmployeeTypeDAL
    {
        private ERPSSLHBEntities _context = new ERPSSLHBEntities();
        internal int InsertEmployeeType(HRM_EmployeeType employeeTypeObj)
        {
            
            try
            {
                _context.HRM_EmployeeType.AddObject(employeeTypeObj);
                _context.SaveChanges();
                return 1;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        internal List<HRM_EmployeeType> GetEmployeeType(string Ocode)
        {
            try
            {
                var query = (from lev in _context.HRM_EmployeeType
                             where lev.OCODE == Ocode
                             select lev).OrderBy(lev => lev.EmployeeTypeId);

                return query.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        internal List<HRM_EmployeeType> GeEmployeeTypes(string employeeTypeId, string OCODE)
        {
            try
            {
                int eId = Convert.ToInt32(employeeTypeId);
                //HRM_EmployeeType obj = _context.HRM_EmployeeType.First(x => x.EmployeeTypeId == eId);
                var query = (from lev in _context.HRM_EmployeeType
                             where lev.OCODE == OCODE && lev.EmployeeTypeId == eId
                             select lev).OrderBy(lev => lev.EmployeeTypeId);

                return query.ToList();



            }
            catch (Exception)
            {

                throw;
            }
        }

        internal int UpdateEmployeeType(HRM_EmployeeType employeeTypeObj, int leaveTypeId)
        {
            HRM_EmployeeType obj = _context.HRM_EmployeeType.First(x => x.EmployeeTypeId == leaveTypeId);
            obj.EmployeeTypeName = employeeTypeObj.EmployeeTypeName;
            obj.EDIT_DATE = employeeTypeObj.EDIT_DATE;
            obj.EDIT_USER = employeeTypeObj.EDIT_USER;            
            _context.SaveChanges();
            return 1;
        }
    }
}
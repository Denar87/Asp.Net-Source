using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPSSL.HRM.DAL
{
    public class EmployeeCategoryDAL
    {
        private ERPSSLHBEntities _context = new ERPSSLHBEntities();
        internal List<HRM_EmployeeCategory> getEmployeeCategoryes(string Ocode)
        {

            try
            {

                var companys = (from comp in _context.HRM_EmployeeCategory
                                where comp.OCODE == Ocode
                                select comp);


                return companys.ToList();

            }
            catch (Exception)
            {

                throw;
            }
        }

        internal int InsertEmployeeCategory(HRM_EmployeeCategory employeeTypeObj)
        {
            try
            {
                _context.HRM_EmployeeCategory.AddObject(employeeTypeObj);
                _context.SaveChanges();
                return 1;

            }
            catch (Exception)
            {

                throw;
            }

        }

        internal int UpdateEmployeeCategory(HRM_EmployeeCategory employeeTypeObj, int Id)
        {
            try
            {
                HRM_EmployeeCategory obj = _context.HRM_EmployeeCategory.First(x => x.EmployeeCategory == Id);
                obj.EmployeeTypeName = employeeTypeObj.EmployeeTypeName;
                obj.EDIT_DATE = employeeTypeObj.EDIT_DATE;
                obj.EDIT_USER = employeeTypeObj.EDIT_USER;
                _context.SaveChanges();                
               
                return 1;

            }
            catch (Exception)
            {

                throw;
            }

        }

        internal List<HRM_EmployeeCategory> GeEmployeeCategoroyesById(string employeeTypeId, string OCODE)
        {

            try
            {
                int eId = Convert.ToInt32(employeeTypeId);
                //HRM_EmployeeType obj = _context.HRM_EmployeeType.First(x => x.EmployeeTypeId == eId);
                var query = (from ec in _context.HRM_EmployeeCategory
                             where ec.OCODE == OCODE && ec.EmployeeCategory== eId
                             select ec).OrderBy(cat => cat.EmployeeCategory);

                return query.ToList();



            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
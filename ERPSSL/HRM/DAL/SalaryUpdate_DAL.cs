using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ERPSSL.HRM.BLL;

namespace ERPSSL.HRM.DAL
{
    public class SalaryUpdate_DAL
    {
        ERPSSLHBEntities _context = new ERPSSLHBEntities();
        public IEnumerable<HRM_EMP_SALARY_UPDATE> GetEmployeeID(string employeeID, string OCODE)
        {
            using (var _context = new ERPSSLHBEntities())
            {
                return (from emp in _context.HRM_PersonalInformations
                        //join srv in _context.HRM_SERVICE_CONTRACT on emp.EMP_ID equals srv.EMP_ID
                        join d in _context.HRM_DEPARTMENTS on emp.DepartmentId equals d.DPT_ID
                        join dg in _context.HRM_DESIGNATIONS on emp.DesginationId equals dg.DEG_ID

                        where emp.EID == employeeID && emp.OCODE == OCODE && emp.EMP_TERMIN_STATUS == false && emp.EMP_Retired_Status == false && emp.EMP_Resignation_Status == false
                        select new HRM_EMP_SALARY_UPDATE
                        {
                            EMP_ID = (Int64)emp.EmpId,
                            EID = emp.EID,

                            EMP_FIRSTNAME = emp.FirstName,
                            EMP_LASTNAME = emp.LastName,
                            EMP_CONTACT_NO = emp.ContactNumber,
                            
                           
                            Grade=emp.Grade,
                            salary =(decimal)emp.Salary,
                            
                            //CONTRACT = srv.CONTRACT,
                            DEG_NAME = dg.DEG_NAME,
                            //DEG_ID = dg.DEG_ID,

                            DPT_NAME = d.DPT_NAME,
                            DesginationID=emp.DesginationId
                            //DPT_ID = d.DPT_ID,

                        }).ToList();
            }
        }




        //Update

        //internal int UpdateSalary(HRM_DESIGNATIONS objDesignation, string employeeID)
        //{

        //    try
        //    {
        //        HRM_DESIGNATIONS obj = _context.HRM_DESIGNATIONS.First(x => x.DEG_ID == employeeID);
        //        obj.DEG_NAME = objDesignation.DEG_NAME;
               
        //        _context.SaveChanges();
        //        return 1;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }

        //}

        internal int UpdateSalary(HRM_PersonalInformations objperonal, string employeeID)
        {
            try
            {
                //int macat = Convert.ToInt32(employeeID);
                HRM_PersonalInformations personnal = _context.HRM_PersonalInformations.First(x => x.EID == employeeID);
                personnal.Salary = objperonal.Salary;
                personnal.EID = objperonal.EID;
                //personnal.MaterialCategory_ID = objperonal.MaterialCategory_ID;
                _context.SaveChanges();
                return 1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        internal virtual List<HRM_DESIGNATIONS> GetAllDesignation()
        {

            try
            {
                var query = (from dept in _context.HRM_DESIGNATIONS
                             select dept);


                return query.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }

        }

        internal bool CheckDesignation(string Desgination, string Grad, decimal Gosssalary)
        {

            try
            {

                bool status = false;

                HRM_DESIGNATIONS _desgination = _context.HRM_DESIGNATIONS.FirstOrDefault(x => x.DEG_NAME == Desgination && x.GRADE == Grad && x.GROSS_SAL == Gosssalary);
                if (_desgination != null)
                {
                    status = true;
                }
                return status;

            }
            catch (Exception)
            {
                
                throw;
            }
        }

        internal List<HRM_PersonalInformations> GetEmployeesForSalaryIncrement(string OCODE)
        {
            try
            {

               return _context.HRM_PersonalInformations.Where(x => x.EffectiveSalaryStatus == false).ToList();

            }
            catch (Exception)
            {

                throw;
            }
        }
    }


}
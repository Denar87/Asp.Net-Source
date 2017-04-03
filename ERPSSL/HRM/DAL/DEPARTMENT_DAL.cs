using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using ERPSSL.HRM.DAL.Repository;
using ERPSSL.HRM.DAL;

namespace ERPSSL.HRM.DAL
{
    public class DEPARTMENT_DAL
    {
        private ERPSSLHBEntities _context = new ERPSSLHBEntities();

        //-------Insert------------------------------------
        public int InsertDepartment(HRM_DEPARTMENTS objDept)
        {
            try
            {
                _context.HRM_DEPARTMENTS.AddObject(objDept);
                _context.SaveChanges();
                return 1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal List<HRM_DEPARTMENTS> GetDepartmentByOffice(int RegionId, int OfficeId, string Ocode)
        {
            try
            {
                var query = (from department in _context.HRM_DEPARTMENTS
                             where department.OCODE == Ocode && department.Office_ID == OfficeId && department.ResionId == RegionId
                             select department).OrderBy(x => x.DPT_ID);
                return query.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }

        }

        //-------Update------------------------------------
        public int UpdateDepartment(HRM_DEPARTMENTS objDept, int departmentID)
        {
            try
            {
                HRM_DEPARTMENTS obj = _context.HRM_DEPARTMENTS.First(x => x.DPT_ID == departmentID);
                obj.DPT_NAME = objDept.DPT_NAME;
                obj.DPT_CODE = objDept.DPT_CODE;
                obj.EDIT_USER = objDept.EDIT_USER;
                obj.EDIT_DATE = objDept.EDIT_DATE;
                obj.Office_ID = obj.Office_ID;
                obj.ResionId = objDept.ResionId;
                _context.SaveChanges();
                return 1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //-------Delete------------------------------------
        public int DeleteDepartment(int departmentID)
        {
            try
            {
                HRM_DEPARTMENTS objDept = _context.HRM_DEPARTMENTS.First(x => x.DPT_ID == departmentID);
                _context.HRM_DEPARTMENTS.DeleteObject(objDept);
                _context.SaveChanges();
                return 1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //-------GetAll------------------------------------
        public virtual List<HRM_DEPARTMENTS> GetAllDepartment(string OCODE)
        {
            try
            {
                var query = (from dept in _context.HRM_DEPARTMENTS
                             where dept.OCODE == OCODE
                             select dept).OrderBy(x => x.DPT_ID);


                return query.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }


        }

        //-------GetAll------------------------------------

        internal IEnumerable<Department> GetDepartment(string OCODE)
        {
            using (var _context = new ERPSSLHBEntities())
            {
                var ParamempID = new SqlParameter("@OCODE", OCODE);

                string SP_SQL = "HRM_GetOfficeList @OCODE";

                return (_context.ExecuteStoreQuery<Department>(SP_SQL, ParamempID)).ToList();
            }


        }

        internal HRM_DEPARTMENTS GetOfficeById(string deparId, string OCODE)
        {
            int DepId = Convert.ToInt32(deparId);
            HRM_DEPARTMENTS dep = _context.HRM_DEPARTMENTS.First(x => x.DPT_ID == DepId);
            return dep;


        }

        internal List<HRM_DEPARTMENTS> GetDepartmentByOfficeIdAndOCode(int? officeId, string OCODE)
        {
            try
            {
                var query = (from dept in _context.HRM_DEPARTMENTS
                             where dept.OCODE == OCODE && dept.Office_ID == officeId
                             select dept).OrderBy(x => x.DPT_ID);


                return query.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        internal List<HRM_DEPARTMENTS> GetDepartmentByOfficeId(int officeId, string OCODE)
        {
            try
            {
                var query = (from dept in _context.HRM_DEPARTMENTS
                             where dept.OCODE == OCODE && dept.Office_ID==officeId
                             select dept).OrderBy(x => x.DPT_ID);


                return query.ToList();

            }
            catch (Exception)
            {
                
                throw;
            }
        }

        internal List<HRM_DEPARTMENTS> DepartmentList(string OCODE)
        {
            try
            {
                var query = (from dept in _context.HRM_DEPARTMENTS
                             where dept.OCODE == OCODE 
                             select dept).OrderBy(x => x.DPT_ID);


                return query.ToList();

            }
            catch (Exception)
            {

                throw;
            }

        }

        internal List<HRM_PersonalInformations> GetDepartmentByReportingBossId(string OCODE, string firstReportingBossId)
        {
            try
            {
                try
                {
                    var query = (from pIn in _context.HRM_PersonalInformations
                                 where pIn.OCODE == OCODE && pIn.EID == firstReportingBossId
                                 select pIn).OrderBy(x => x.EID);


                    return query.ToList();

                }
                catch (Exception)
                {

                    throw;
                }


            }
            catch (Exception)
            {
                
                throw;
            }
        }

        internal List<HRM_PersonalInformations> GetAllAsignTo(string OCODE)
        {
            try
            {
                try
                {
                    var query = (from pIn in _context.HRM_PersonalInformations
                                 where pIn.OCODE == OCODE 
                                 select pIn).OrderBy(x => x.EID);


                    return query.ToList();

                }
                catch (Exception)
                {

                    throw;
                }


            }
            catch (Exception)
            {

                throw;
            }
        }

        internal List<HRM_DEPARTMENTS> GetDepartmentByOfficeCode(string officeCode, string OCODE)
        {
            try
            {
                var query = (from dept in _context.HRM_DEPARTMENTS
                             join off in _context.HRM_Office on dept.Office_ID equals off.OfficeID
                             where dept.OCODE == OCODE && off.OfficeCode == officeCode
                             select dept).OrderBy(x => x.DPT_ID);


                return query.ToList();

            }
            catch (Exception)
            {

                throw;
            }
        }


    }
}
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using ERPSSL.HRM.DAL;
using ERPSSL.HRM.DAL.Repository;

namespace ERPSSL.HRM.DAL
{
    public class DESIGNATION_DAL
    {
       // private HRM_Entities _context = new HRM_Entities();
        ERPSSLHBEntities _context = new ERPSSLHBEntities();
        //-------Insert------------------------------------
        public int InsertDeignation(HRM_DESIGNATIONS objDeg)
        {
            try
            {
                
                _context.HRM_DESIGNATIONS.AddObject(objDeg);
                _context.SaveChanges();
                return 1;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        //-------Update------------------------------------
        public int UpdateDesignation(HRM_DESIGNATIONS objDeg, int designationID)
        {
            try
            {
                HRM_DESIGNATIONS obj = _context.HRM_DESIGNATIONS.First(x => x.DEG_ID == designationID);
                obj.DEG_NAME = objDeg.DEG_NAME;
                obj.GRADE = objDeg.GRADE;
                obj.GROSS_SAL = objDeg.GROSS_SAL;
                obj.HOUSE_RENT = objDeg.HOUSE_RENT;
                obj.BASIC = objDeg.BASIC;
                obj.MEDICAL = objDeg.MEDICAL;
                obj.CONVEYANCE = objDeg.CONVEYANCE;
                obj.FixedAllowance = objDeg.FixedAllowance;
                obj.AttendanceBonus = objDeg.AttendanceBonus;
                obj.Holiday_Allowance = objDeg.Holiday_Allowance;
                obj.EDIT_USER = objDeg.EDIT_USER;
                obj.EDIT_DATE = objDeg.EDIT_DATE;
                _context.SaveChanges();
                return 1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //-------Delete------------------------------------
        public int DeleteDesignation(int designationID)
        {
            try
            {
                HRM_DESIGNATIONS objDept = _context.HRM_DESIGNATIONS.First(x => x.DEG_ID == designationID);
                _context.HRM_DESIGNATIONS.DeleteObject(objDept);
                _context.SaveChanges();
                return 1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //-------GetAll------------------------------------
        public virtual List<HRM_DESIGNATIONS> GetAllDesignation(string OCODE)
        {
            try
            {
                var query = (from deg in _context.HRM_DESIGNATIONS
                             where deg.OCODE == OCODE
                             select deg);


                return query.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        internal List<HRM_DESIGNATIONS> GetaDesignationByIdandOcode(string deginationId, string OCODE)
        {

            try
            {
                int designationId = Convert.ToInt32(deginationId);
                var query = (from deg in _context.HRM_DESIGNATIONS
                             where deg.DEG_ID == designationId && deg.OCODE == OCODE
                             select deg).OrderBy(x => x.DEG_ID);


                return query.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        internal List<RDegination> GetDesignationList(string OCODE)
        {
            try
            {
                using (var _context = new ERPSSLHBEntities())
                {
                    var ParamempID = new SqlParameter("@OCODE", OCODE);

                    string SP_SQL = "HRM_GetDeginationList @OCODE";

                    return (_context.ExecuteStoreQuery<RDegination>(SP_SQL, ParamempID)).ToList();
                }

            }
            catch (Exception)
            {

                throw;
            }

        }

        internal List<HRM_DESIGNATIONS> GetGrossSalaryByDesigionIdAndGrade(string Designatin, string Grade, string OCODE)
        {
            try
            {
                
                var query = (from deg in _context.HRM_DESIGNATIONS
                             where deg.DEG_NAME == Designatin && deg.OCODE == OCODE && deg.GRADE == Grade
                             select deg).OrderBy(x => x.DEG_ID);


                return query.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }

        }

        internal HRM_DESIGNATIONS GetDesignationId(string Desgination, string Grad, decimal Gosssalary)
        {
            try
            {
                HRM_DESIGNATIONS _desgination = _context.HRM_DESIGNATIONS.FirstOrDefault(x => x.DEG_NAME == Desgination && x.GRADE == Grad && x.GROSS_SAL == Gosssalary);
                return _desgination;

            }
            catch (Exception)
            {
                
                throw;
            }
        }

        internal int UpdatePersonalInfoForSalaryUpdate(string eid, int desId, decimal Gosssalary)
        {


            HRM_PersonalInformations _personalobj = _context.HRM_PersonalInformations.First(x=>x.EID==eid);
            if (_personalobj != null)
            {
                _personalobj.Salary = Gosssalary;
                _personalobj.DesginationId = desId;
                _personalobj.SalaryUpdateDate = DateTime.Now;
                _context.SaveChanges();
            }
            return 1;
        }
        internal HRM_DESIGNATIONS GetDesignationIdByDesNameGradAndGoss(string desName, string grade, decimal? Gosssalary)
        {
            HRM_DESIGNATIONS _desgination = _context.HRM_DESIGNATIONS.FirstOrDefault(x => x.DEG_NAME == desName && x.GRADE == grade && x.GROSS_SAL == Gosssalary);
            return _desgination;

        }
    }
}
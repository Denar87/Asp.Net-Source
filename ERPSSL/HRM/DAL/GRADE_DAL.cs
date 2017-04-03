using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ERPSSL.HRM.DAL;
using ERPSSL.HRM.DAL.Repository;
using System.Data.SqlClient;

namespace ERPSSL.HRM.DAL
{
    public class GRADE_DAL
    {
        private ERPSSLHBEntities _context = new ERPSSLHBEntities();

        //-------Insert------------------------------------
        public int InsertGrade(HRM_GRADE objGrd)
        {
            try
            {
                _context.HRM_GRADE.AddObject(objGrd);
                _context.SaveChanges();
                return 1;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        //-------Update------------------------------------
        public int UpdateGrade(HRM_GRADE objGrd, int gradeId)
        {
            try
            {
                HRM_GRADE obj = _context.HRM_GRADE.First(x => x.GRADE_ID == gradeId);
                obj.STEP = objGrd.STEP;
                obj.GRADE = objGrd.GRADE;
                obj.GROSS_SAL = objGrd.GROSS_SAL;
                obj.HOUSE_RENT = objGrd.HOUSE_RENT;
                obj.BASIC = objGrd.BASIC;
                obj.MEDICAL = objGrd.MEDICAL;
                obj.CONVEYANCE = objGrd.CONVEYANCE;
                obj.FOOD_ALLOW = objGrd.FOOD_ALLOW;
                obj.OTHERS = objGrd.OTHERS;
                obj.EDIT_USER = objGrd.EDIT_USER;
                obj.EDIT_DATE = DateTime.Now;
                obj.OCODE = objGrd.OCODE;

                _context.SaveChanges();
                return 1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //-------GetAll------------------------------------
        public virtual List<HRM_GRADE> GetAllGrade(string OCODE)
        {
            try
            {
                var query = (from grd in _context.HRM_GRADE
                             where grd.OCODE == OCODE
                             select grd).OrderBy(grd => grd.GRADE_ID);

                return query.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        //-------SelectByID------------------------------------
        public virtual List<HRM_GRADE> SelectByID(int gradeID, string OCODE)
        {
            try
            {
                var query = (from grd in _context.HRM_GRADE
                             where grd.GRADE_ID == gradeID && grd.OCODE == OCODE
                             select grd).OrderBy(sec => sec.GRADE_ID);

                var list = query.ToList();
                return list;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        internal List<HRM_DESIGNATIONS> GetGrateByStepAndOCode(string deg, string OCODE)
        {
            try
            {
                try
                {
                    var query = (from grd in _context.HRM_DESIGNATIONS
                                 where grd.DEG_NAME == deg && grd.OCODE == OCODE
                                 select grd).OrderBy(sec => sec.DEG_ID);

                    var list = query.ToList();
                    return list;

                   

                }
                catch (Exception ex)
                {
                    throw ex;
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        internal List<HRM_GRADE> GetGradeInformationBygradeIdAndOcode(int gradeId, string OCODE)
        {
            try
            {
                var query = (from grd in _context.HRM_GRADE
                             where grd.GRADE_ID == gradeId && grd.OCODE == OCODE
                             select grd).OrderBy(sec => sec.GRADE_ID);

                var list = query.ToList();
                return list;


            }
            catch (Exception)
            {
                
                throw;
            }
        }

        internal List<HRM_EmployeeType> GetAllEmployeeType(string OCODE)
        {

            try
            {
                var query = (from grd in _context.HRM_EmployeeType
                             where  grd.OCODE == OCODE
                             select grd).OrderBy(sec => sec.EmployeeTypeId);

                var list = query.ToList();
                return list;


            }
            catch (Exception)
            {

                throw;
            }
        }

        internal List<HRM_DESIGNATIONS> GetGradeById(string de, string OCODE)
        {

            int designationId=Convert.ToInt16(de);
            try
                {

                    var query = (from grd in _context.HRM_DESIGNATIONS
                                 where  grd.OCODE == OCODE
                                 select grd).OrderBy(sec => sec.DEG_ID);

                    var list = query.ToList();
                    return list;
                }
                catch (Exception ex)
                {
                    throw ex;
                }

            }



        internal List<HRM_DESIGNATIONS> GetSalaryByGrade(string Grade, string OCODE)
        {
             try
                {

                    var query = (from grd in _context.HRM_DESIGNATIONS
                                 where  grd.OCODE == OCODE && grd.GRADE==Grade
                                 select grd).OrderBy(sec => sec.DEG_ID);

                    var list = query.ToList();
                    return list;
                }
                catch (Exception ex)
                {
                    throw ex;
                }

            }


        internal List<GradeR> GetGrateByDesginationName(string De, string OCODE)
        {

            try
            {
                using (var _context = new ERPSSLHBEntities())
                {
                    var ParamempID = new SqlParameter("@OCODE", OCODE);

                    var ParamempID1 = new SqlParameter("@Desgination", De);

                    string SP_SQL = "HRM_GetGradeList @OCODE,@Desgination";

                    return (_context.ExecuteStoreQuery<GradeR>(SP_SQL, ParamempID, ParamempID1)).ToList();
                }

            }
            catch (Exception)
            {

                throw;
            }


        }

        internal string GetDesignationNameById(int desginationId)
        {
            var query = (from grd in _context.HRM_DESIGNATIONS
                         where grd.DEG_ID == desginationId
                         select grd.DEG_NAME).FirstOrDefault().ToString();
            return query;

        }
    }
}
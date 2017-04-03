using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using ERPSSL.HRM.DAL.Repository;

namespace ERPSSL.HRM.DAL
{
    public class EmployeeBenefitDAL
    {
        private ERPSSLHBEntities _context = new ERPSSLHBEntities();
        internal int SaveEmployeeBenefitSetup(HRM_EmployeeBenefitSetup employeeBenefitsetupobj)
        {

            try
            {
                _context.HRM_EmployeeBenefitSetup.AddObject(employeeBenefitsetupobj);
                _context.SaveChanges();
                return 1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal List<HRM_EmployeeBenefitSetup> getEmployeeBenefitSetupList(string OCODE)
        {
            try
            {
                var query = (from reg in _context.HRM_EmployeeBenefitSetup
                             where reg.OCODE == OCODE
                             select reg).OrderBy(x => x.BenefittypeId);


                return query.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }

        }

        internal List<HRM_EmployeeBenefitSetup> GetBenefitInfoById(string benefitId, string OCODE)
        {
            try
            {

                int benefitID = Convert.ToInt32(benefitId);
                var query = (from lt in _context.HRM_EmployeeBenefitSetup
                             where lt.OCODE == OCODE && lt.BenefittypeId == benefitID
                             select lt).OrderBy(hl => hl.BenefittypeId);

                var list = query.ToList();
                return list;

            }
            catch (Exception)
            {

                throw;
            }
        }

        internal int updateEmpoyeeBenefitById(HRM_EmployeeBenefitSetup employeeBenefitsetupobj, string benefitTypeId)
        {
            int benefitId = Convert.ToInt16(benefitTypeId);
            HRM_EmployeeBenefitSetup obj = _context.HRM_EmployeeBenefitSetup.First(x => x.BenefittypeId == benefitId);
            obj.Benefittype = employeeBenefitsetupobj.Benefittype;
            obj.Description = employeeBenefitsetupobj.Description;
            obj.EDIT_DATE = employeeBenefitsetupobj.EDIT_DATE;
            obj.EDIT_USER = employeeBenefitsetupobj.EDIT_USER;
            obj.OCODE = employeeBenefitsetupobj.OCODE;
            _context.SaveChanges();
            return 1;

        }

        internal List<HRM_EmployeeBenefitSetup> GetBeneFitType(string OCODE)
        {
            try
            {
              
                var query = (from lt in _context.HRM_EmployeeBenefitSetup
                             where lt.OCODE == OCODE 
                             select lt).OrderBy(hl => hl.BenefittypeId);

                var list = query.ToList();
                return list;

            }
            catch (Exception)
            {

                throw;
            }
        }

        internal int SaveUserWiseBebefit(HRM_EmployeeWiseBenefit employeeWiseBenefitObj)
        {
            try
            {
                _context.HRM_EmployeeWiseBenefit.AddObject(employeeWiseBenefitObj);
                _context.SaveChanges();
                return 1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal List<EmployeeWiseBebefit> GetEmployeeWiseBenefitList(string OCODE)
        {
            try
            {
                using (var _context = new ERPSSLHBEntities())
                {
                    var ParamempID = new SqlParameter("@ocode", OCODE);

                    string SP_SQL = "HRM_EmployesWiseBebefitList @ocode";

                    return (_context.ExecuteStoreQuery<EmployeeWiseBebefit>(SP_SQL, ParamempID)).ToList();
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        internal List<HRM_EmployeeWiseBenefit> GetBeneFitListById(string OCODE, string bebefitID)
        {
            try
            {
                int id = Convert.ToInt16(bebefitID);
                var query = (from lt in _context.HRM_EmployeeWiseBenefit
                             where lt.OCODE == OCODE && lt.employeeWiseBenefitId==id
                             select lt).OrderBy(hl => hl.employeeWiseBenefitId);

                var list = query.ToList();
                return list;

            }
            catch (Exception)
            {

                throw;
            }
        }

        internal int UpdateUserWiseBebefit(HRM_EmployeeWiseBenefit employeeWiseBenefitObj, string id)
        {
            int iD = Convert.ToInt16(id);
            HRM_EmployeeWiseBenefit obj = _context.HRM_EmployeeWiseBenefit.First(x => x.employeeWiseBenefitId == iD);
            obj.Amount = employeeWiseBenefitObj.Amount;
            obj.BenefitTypeId = employeeWiseBenefitObj.BenefitTypeId;
            obj.EffectiveDate = employeeWiseBenefitObj.EffectiveDate;
            obj.EDIT_DATE = employeeWiseBenefitObj.EDIT_DATE;
            obj.EDIT_USER = employeeWiseBenefitObj.EDIT_USER;
            obj.OCODE = employeeWiseBenefitObj.OCODE;
            _context.SaveChanges();
            return 1;

        }

        internal List<EmployeeAdvanceSalaryR> getEmployeeWiseAdvanceSalaryList(string OCODE)
        {
            try
            {
                using (var _context = new ERPSSLHBEntities())
                {
                    var ParamempID = new SqlParameter("@ocode", OCODE);

                    string SP_SQL = "HRM_EmployesWiseAdvanceSalaryList @ocode";

                    return (_context.ExecuteStoreQuery<EmployeeAdvanceSalaryR>(SP_SQL, ParamempID)).ToList();
                }

            }
            catch (Exception)
            {

                throw;
            }

        }

        internal List<HRM_AdvanceSalarySummary> GetAdvanceSalaryDetails(string OCODE, string advanceSalaryId)
        {
            try
            {
                int id = Convert.ToInt16(advanceSalaryId);
                var query = (from lt in _context.HRM_AdvanceSalarySummary
                             where lt.OCODE == OCODE && lt.AdvanceSalaryId== id
                             select lt).OrderBy(hl => hl.AdvanceSalaryId);

                var list = query.ToList();
                return list;

            }
            catch (Exception)
            {

                throw;
            }

        }

        internal List<HRM_AdvanceSalaryDetails> GetAllAdvanceSalaryDetails(string OCODE, string advanceSalaryDetailsId)
        {
            try
            {
                int id = Convert.ToInt16(advanceSalaryDetailsId);
                var query = (from lt in _context.HRM_AdvanceSalaryDetails
                             where lt.OCODE == OCODE && lt.AdvanceSalaryDetailsId == id
                             select lt).OrderBy(hl => hl.AdvanceSalaryDetailsId);

                var list = query.ToList();
                return list;
            }
            catch (Exception)
            {
                throw;
            }
        }
        internal List<EmployeeAdvanceSalaryR> GetAdvanceSalaryDetailsListByEID(string eid, int payMonth, string payYear, string OCODE)
        {
            try
            {
                using (var _context = new ERPSSLHBEntities())
                {
                    var ParamempID1 = new SqlParameter("@EID", eid);
                    var ParamempID2 = new SqlParameter("@AdvancePayMonth", payMonth);
                    var ParamempID3 = new SqlParameter("@AdvancePayYear", payYear);
                    var ParamempID4 = new SqlParameter("@ocode", OCODE);

                    string SP_SQL = "HRM_EmployesWise_AdvanceSalaryDetailsList @EID, @AdvancePayMonth, @AdvancePayYear, @ocode";

                    return (_context.ExecuteStoreQuery<EmployeeAdvanceSalaryR>(SP_SQL, ParamempID1, ParamempID2, ParamempID3, ParamempID4)).ToList();
                }

            }
            catch (Exception)
            {
                throw;
            }

        }

        internal List<HRM_EmployeeWiseBenefit> Get_BenifitAmountByEID_Date(string E_ID, int BenefitTypeId, DateTime EffectiveDate)
        {
            try
            {
                var query = (from lt in _context.HRM_EmployeeWiseBenefit
                             where lt.EID == E_ID && lt.BenefitTypeId == BenefitTypeId && lt.EffectiveDate == EffectiveDate
                             select lt);
                var list = query.ToList();
                return list;
            }
            catch (Exception)
            {
                throw;
            }
        }

        internal int UpdateUserWiseBebefits(HRM_EmployeeWiseBenefit aHRM_EmployeeWiseBenefit, string E_ID, DateTime ExistEffictiveDate)
        {
            try
            {
                HRM_EmployeeWiseBenefit obj = _context.HRM_EmployeeWiseBenefit.FirstOrDefault(x => (x.EID == E_ID) && (x.EffectiveDate == ExistEffictiveDate));
                obj.Amount = aHRM_EmployeeWiseBenefit.Amount;
                obj.BenefitTypeId = aHRM_EmployeeWiseBenefit.BenefitTypeId;
                obj.EffectiveDate = aHRM_EmployeeWiseBenefit.EffectiveDate;
                //obj.Individual_Tax = aHRM_EmployeeWiseBenefit.Individual_Tax;
                //obj.Company_Tax = aHRM_EmployeeWiseBenefit.Company_Tax;
                obj.EDIT_DATE = aHRM_EmployeeWiseBenefit.EDIT_DATE;
                obj.EDIT_USER = aHRM_EmployeeWiseBenefit.EDIT_USER;
                obj.OCODE = aHRM_EmployeeWiseBenefit.OCODE;
                _context.SaveChanges();
                return 1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ERPSSL.HRM.DAL;
using ERPSSL.HRM.DAL.Repository;

namespace ERPSSL.HRM.BLL
{
    public class EmployeeBenefitBLL
    {
        EmployeeBenefitDAL employeeBenefitdal = new EmployeeBenefitDAL();
        internal int SaveEmployeeBenefitSetup(HRM_EmployeeBenefitSetup employeeBenefitsetupobj)
        {
            return employeeBenefitdal.SaveEmployeeBenefitSetup(employeeBenefitsetupobj);
        }

        internal List<HRM_EmployeeBenefitSetup> getEmployeeBenefitSetupList(string OCODE)
        {

            return employeeBenefitdal.getEmployeeBenefitSetupList(OCODE);
        }

        internal List<HRM_EmployeeBenefitSetup> GetBenefitInfoById(string benefitId, string OCODE)
        {
            return employeeBenefitdal.GetBenefitInfoById(benefitId, OCODE);
        }

        internal int updateEmpoyeeBenefitById(HRM_EmployeeBenefitSetup employeeBenefitsetupobj, string benefitTypeId)
        {
            return employeeBenefitdal.updateEmpoyeeBenefitById(employeeBenefitsetupobj, benefitTypeId);
        }

        internal List<HRM_EmployeeBenefitSetup> GetBeneFitType(string OCODE)
        {
            return employeeBenefitdal.GetBeneFitType(OCODE);
        }

        internal int SaveUserWiseBebefit(HRM_EmployeeWiseBenefit employeeWiseBenefitObj)
        {
            return employeeBenefitdal.SaveUserWiseBebefit(employeeWiseBenefitObj);
        }

        internal List<EmployeeWiseBebefit> GetEmployeeWiseBenefitList(string OCODE)
        {
            return employeeBenefitdal.GetEmployeeWiseBenefitList(OCODE);
        }

        internal List<HRM_EmployeeWiseBenefit> GetBeneFitListById(string OCODE, string bebefitID)
        {
            return employeeBenefitdal.GetBeneFitListById(OCODE, bebefitID);
        }

        internal int UpdateUserWiseBebefit(HRM_EmployeeWiseBenefit employeeWiseBenefitObj, string id)
        {
            return employeeBenefitdal.UpdateUserWiseBebefit(employeeWiseBenefitObj, id);
        }

        internal List<EmployeeAdvanceSalaryR> getEmployeeWiseAdvanceSalaryList(string OCODE)
        {
            return employeeBenefitdal.getEmployeeWiseAdvanceSalaryList(OCODE);

        }

        internal List<HRM_AdvanceSalarySummary> GetAdvanceSalaryDetails(string OCODE, string advanceSalaryId)
        {
            return employeeBenefitdal.GetAdvanceSalaryDetails(OCODE, advanceSalaryId);
        }

        internal List<HRM_AdvanceSalaryDetails> GetAllAdvanceSalaryDetails(string OCODE, string advanceSalaryDetailsId)
        {
            return employeeBenefitdal.GetAllAdvanceSalaryDetails(OCODE, advanceSalaryDetailsId);
        }

        internal List<EmployeeAdvanceSalaryR> GetAdvanceSalaryDetailsListByEID(string eid, int payMonth, string payYear, string OCODE)
        {
            return employeeBenefitdal.GetAdvanceSalaryDetailsListByEID(eid, payMonth, payYear, OCODE);

        }
        internal List<HRM_EmployeeWiseBenefit> Get_BenifitAmountByEID_Date(string E_ID, int BenefitTypeId, DateTime EffectiveDate)
        {
            return employeeBenefitdal.Get_BenifitAmountByEID_Date(E_ID, BenefitTypeId, EffectiveDate);
        }

        internal int UpdateUserWiseBebefits(HRM_EmployeeWiseBenefit aHRM_EmployeeWiseBenefit, string E_ID, DateTime ExistEffictiveDate)
        {
            return employeeBenefitdal.UpdateUserWiseBebefits(aHRM_EmployeeWiseBenefit, E_ID, ExistEffictiveDate);
        }

    }
}
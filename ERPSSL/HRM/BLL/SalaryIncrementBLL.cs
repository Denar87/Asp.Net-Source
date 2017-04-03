using ERPSSL.HRM.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPSSL.HRM.BLL
{
    public class SalaryIncrementBLL
    {
        SalaryIncrementDAL _salaryIncrementdal = new SalaryIncrementDAL();
        internal int InsertSalryIncrementLog(List<HRM_SalaryIncrement> SalaryIncrements)
        {
            return _salaryIncrementdal.InsertSalryIncrementLog(SalaryIncrements);

        }

        internal List<HRM_SalaryIncrement> GetSalaryIncrementLog(string OCODE)
        {
            return _salaryIncrementdal.GetSalaryIncrementLog(OCODE);
        }

        internal DateTime GetServerDate()
        {
            return _salaryIncrementdal.GetServerDate();

        }

        internal List<HRM_PersonalInformations> GetAllEmployess(string OCODE)
        {
            return _salaryIncrementdal.GetAllEmployess(OCODE);

        }

        internal List<HRM_DESIGNATIONS> GetAllDesgination(string OCODE)
        {
            return _salaryIncrementdal.GetAllDesgination(OCODE);

        }

        internal bool CheckDesignation(string Desgination, string Grad, decimal? Gosssalary)
        {
            try
            {

                return _salaryIncrementdal.CheckDesignation(Desgination, Grad, Gosssalary);

            }
            catch (Exception)
            {
                
                throw;
            }
        }

        internal int AutomaticSalaryUpdate(List<DAL.Repository.SalaryIncrementR> slaryIncrementRes)
        {
            return _salaryIncrementdal.AutomaticSalaryUpdate(slaryIncrementRes);
        }

        internal int AutomaticSalaryUpdateByEffectiveDate(List<DAL.Repository.SalaryIncrementR> slaryIncrementRes)
        {
            return _salaryIncrementdal.AutomaticSalaryUpdateByEffectiveDate(slaryIncrementRes);

        }

        internal List<HRM_SalaryIncrement> Get_SalryIncrementByEID_Date(string E_ID, DateTime EffectiveDate)
        {
            return _salaryIncrementdal.Get_SalryIncrementByEID_Date(E_ID, EffectiveDate);
        }

        internal int UpDateSalryIncrementLog(List<HRM_SalaryIncrement> SalaryIncrements, string EID, DateTime ExistEffictiveDate)
        {
            return _salaryIncrementdal.UpDateSalryIncrementLog(SalaryIncrements, EID, ExistEffictiveDate);
        }
        internal int DeleteSalryIncrementLog(string E_ID)
        {
            return _salaryIncrementdal.DeleteSalryIncrementLog(E_ID);
        }
    }
}
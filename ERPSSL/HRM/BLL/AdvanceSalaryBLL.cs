using ERPSSL.HRM.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPSSL.HRM.BLL
{
    public class AdvanceSalaryBLL
    {
        AdvanceSalaryDAL advanceDal = new AdvanceSalaryDAL();
        internal int SaveAdvanceSalarySummery(HRM_AdvanceSalarySummary advanceSalarySummerybll)
        {
            return advanceDal.SaveAdvanceSalarySummery(advanceSalarySummerybll);
        }

        internal int SaveAdvanceSalaryDetails(List<HRM_AdvanceSalaryDetails> hrmAdvanceSalaryDetailes)
        {

            return advanceDal.SaveAdvanceSalaryDetails(hrmAdvanceSalaryDetailes);
        }

        internal int GetLastRowNumber(string OCODE)
        {
            return advanceDal.GetLastRowNumber(OCODE);
        }

        internal int UpdateAdvanceSlarySummery(int adsalaryId, HRM_AdvanceSalarySummary advanceSalarySummerybll)
        {
            return advanceDal.UpdateAdvanceSlarySummery(advanceSalarySummerybll, adsalaryId);
        }

        internal int UpdateAdvanceSalaryDetails(string codeId, List<HRM_AdvanceSalaryDetails> hrmAdvanceSalaryDetailes)
        {
            return advanceDal.UpdateAdvanceSalaryDetails(hrmAdvanceSalaryDetailes, codeId);
        }

        internal int InsertAdvanceSalaryDetailsLog(HRM_AdvanceSalaryDetailPrevious_Log aHRM_AdvanceSalaryDetailPrevious_Log)
        {
            return advanceDal.InsertAdvanceSalaryDetailsLog(aHRM_AdvanceSalaryDetailPrevious_Log);
        }

        internal int Update_AdvanceSalaryDetails(HRM_AdvanceSalaryDetails aHRM_AdvanceSalaryDetails, int adsalarydetailId)
        {
            return advanceDal.Update_AdvanceSalaryDetails(aHRM_AdvanceSalaryDetails, adsalarydetailId);
        }

    }
}
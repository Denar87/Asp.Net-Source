using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPSSL.HRM.DAL
{
    public class AdvanceSalaryDAL
    {
        private ERPSSLHBEntities _context = new ERPSSLHBEntities();
        internal int SaveAdvanceSalarySummery(HRM_AdvanceSalarySummary advanceSalarySummerybll)
        {
            try
            {
                _context.HRM_AdvanceSalarySummary.AddObject(advanceSalarySummerybll);
                _context.SaveChanges();
                return 1;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        internal int SaveAdvanceSalaryDetails(List<HRM_AdvanceSalaryDetails> hrmAdvanceSalaryDetailes)
        {
            try
            {

                foreach (HRM_AdvanceSalaryDetails aitem in hrmAdvanceSalaryDetailes)
                {
                    _context.HRM_AdvanceSalaryDetails.AddObject(aitem);
                    _context.SaveChanges();
                }
                _context.SaveChanges();
                return 1;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }

        }

        internal int GetLastRowNumber(string OCODE)
        {
            try
            {
                 var count = (from o in _context.HRM_AdvanceSalarySummary
                         select o).Count();
            return count;
            }
            catch (Exception)
            {
                
                throw;
            }

        }

        internal int UpdateAdvanceSlarySummery(HRM_AdvanceSalarySummary advanceSalarySummerybll, int adsalaryId)
        {
            try
            {
                HRM_AdvanceSalarySummary obj = _context.HRM_AdvanceSalarySummary.First(x => x.AdvanceSalaryId == adsalaryId);
                obj.InstalmentAmount = advanceSalarySummerybll.InstalmentAmount;
                obj.NoOfInstalment = advanceSalarySummerybll.NoOfInstalment;
                obj.TotalAmount = advanceSalarySummerybll.TotalAmount;
                obj.StartDate = advanceSalarySummerybll.StartDate;
                obj.EndDate = advanceSalarySummerybll.StartDate;
                obj.EDIT_DATE = advanceSalarySummerybll.EDIT_DATE;
                obj.EDIT_USER = advanceSalarySummerybll.EDIT_USER;
                obj.OCODE = advanceSalarySummerybll.OCODE;
                obj.Remarks = advanceSalarySummerybll.Remarks;
                _context.SaveChanges();
                return 1;

            }
            catch (Exception)
            {
                
                throw;
            }
        }

        internal int UpdateAdvanceSalaryDetails(List<HRM_AdvanceSalaryDetails> hrmAdvanceSalaryDetailes, string codeId)
        {

            try
             {

                 //foreach (var agShare in hrmAdvanceSalaryDetailes)
                 //{
                 //    _context.HRM_AdvanceSalaryDetails.DeleteObject(agShare);
                 //}
                 //_context.SaveChanges();

                 var users = _context.HRM_AdvanceSalaryDetails.Where(u => u.ASCode == codeId);

                 foreach (var u in users)
                 {
                     _context.HRM_AdvanceSalaryDetails.DeleteObject(u);
                 }

                 _context.SaveChanges();



                foreach (HRM_AdvanceSalaryDetails aitem in hrmAdvanceSalaryDetailes)
                {
                    _context.HRM_AdvanceSalaryDetails.AddObject(aitem);
                    _context.SaveChanges();
                }
                _context.SaveChanges();
                return 1;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }

        }


        internal int InsertAdvanceSalaryDetailsLog(HRM_AdvanceSalaryDetailPrevious_Log aHRM_AdvanceSalaryDetailPrevious_Log)
        {
            try
            {
                _context.HRM_AdvanceSalaryDetailPrevious_Log.AddObject(aHRM_AdvanceSalaryDetailPrevious_Log);
                _context.SaveChanges();
                return 1;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        internal int Update_AdvanceSalaryDetails(HRM_AdvanceSalaryDetails aHRM_AdvanceSalaryDetails, int adsalarydetailId)
        {
            try
            {
                HRM_AdvanceSalaryDetails obj = _context.HRM_AdvanceSalaryDetails.First(x => x.AdvanceSalaryDetailsId == adsalarydetailId);
                obj.Month = aHRM_AdvanceSalaryDetails.Month;
                obj.Year = aHRM_AdvanceSalaryDetails.Year;
                obj.EDIT_DATE = aHRM_AdvanceSalaryDetails.EDIT_DATE;
                obj.EDIT_USER = aHRM_AdvanceSalaryDetails.EDIT_USER;
                obj.OCODE = aHRM_AdvanceSalaryDetails.OCODE;

                _context.SaveChanges();
                return 1;
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
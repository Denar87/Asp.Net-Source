using ERPSSL.HRM.DAL;
using ERPSSL.HRM.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPSSL.HRM.BLL
{
    public class IncomeHeadBLL
    {
        IncomeHeadDAL _incomeHeadDal = new IncomeHeadDAL();
        internal int SaveIncomeHeader(HRM_IncomeHeader _IncomeHeader)
        {
            return _incomeHeadDal.SaveIncomeHeader(_IncomeHeader);
        }

        internal List<HRM_IncomeHeader> GetIncomeHead(string OCODE)
        {
            return _incomeHeadDal.GetIncomeHead(OCODE);
        }

        internal HRM_IncomeHeader GetInocmeHeadById(string incomeHeadID, string OCODE)
        {
            return _incomeHeadDal.GetInocmeHeadById(incomeHeadID, OCODE);
        }

        internal int UpdateHeader(HRM_IncomeHeader _IncomeHeader)
        {
            return _incomeHeadDal.UpdateHeader(_IncomeHeader);
        }

        internal int SaveIncomeHeaderDetails(HRM_IncomeHeaderDetails _HrmIncomeHeaderDetails)
        {
            return _incomeHeadDal.SaveIncomeHeaderDetails(_HrmIncomeHeaderDetails);
        }

        internal List<IncomeHeadDetailsV> GetIncomeHeaderDetails(string OCODE)
        {
            return _incomeHeadDal.GetIncomeHeaderDetails(OCODE);
        }

        internal HRM_IncomeHeaderDetails GetIncomeHeaderDetilsBYId(string IncomeHeaderID, string OCODE)
        {
            return _incomeHeadDal.GetIncomeHeaderDetilsBYId(IncomeHeaderID, OCODE);
        }

        internal int UpdateIncomeHeaderDetails(HRM_IncomeHeaderDetails _HrmIncomeHeaderDetails)
        {
            return _incomeHeadDal.UpdateIncomeHeaderDetails(_HrmIncomeHeaderDetails);
        }

        internal List<HRM_IncomeHeaderDetails> GetChargeableDetails(string OCODE)
        {
            return _incomeHeadDal.GetChargeableDetails(OCODE);
        }
    }
}
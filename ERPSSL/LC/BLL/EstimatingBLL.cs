using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ERPSSL.LC.DAL;

namespace ERPSSL.LC.BLL
{
    public class EstimatingBLL
    {
        EstimatingDAL _estimatingDal = new EstimatingDAL();
        internal int Save(List<LC_CostEstimateDetails> details)
        {

            return _estimatingDal.Save(details);
        }
        internal List<LC_FinishGoods> GetLC_FinishGoods(string ocode)
        {
            return _estimatingDal.GetLC_FinishGoods(ocode);
        }
        internal int EstimatingSave(LC_CostEstimateSummary summery)
        {
            return _estimatingDal.EstimatingSave(summery);
        }
        internal int EstimatingApproved(string EstimateNo,DateTime date)
        {
            return _estimatingDal.EstimatingApproved(EstimateNo, date);
        }
        internal int SaveRequisition(List<LC_Requisition> details)
        {
            return _estimatingDal.SaveRequisition(details);
        }
       
    }
}
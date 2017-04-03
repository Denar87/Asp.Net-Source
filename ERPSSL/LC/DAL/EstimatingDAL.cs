using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPSSL.LC.DAL
{
    public class EstimatingDAL
    {
        ERPSSL_LCEntities _Content = new ERPSSL_LCEntities();

        internal int Save(List<LC_CostEstimateDetails> details)
        {
            try
            {
                foreach (LC_CostEstimateDetails item in details)
                {
                    _Content.LC_CostEstimateDetails.AddObject(item);
                    _Content.SaveChanges();
                }
                return 1;
            }
            catch (Exception)
            {
                throw;
            }
        }

        internal int SaveRequisition(List<LC_Requisition> details)
        {
            try
            {
                foreach (LC_Requisition item in details)
                {
                    _Content.LC_Requisition.AddObject(item);
                    _Content.SaveChanges();
                }
                return 1;
            }
            catch (Exception)
            {
                throw;
            }
        }

        internal List<LC_FinishGoods> GetLC_FinishGoods(string ocode)
        {
            try
            {
                var ItemName = (from IName in _Content.LC_FinishGoods
                                where IName.OCode == ocode
                                select IName);
                return ItemName.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }


        internal int EstimatingSave(LC_CostEstimateSummary summery)
        {
            try
            {
                _Content.LC_CostEstimateSummary.AddObject(summery);
                _Content.SaveChanges();
                return 1;
            }
            catch (Exception)
            {
                throw;
            }
        }
        internal int EstimatingApproved(string EstimateNo,DateTime date)
        {
            try
            {
              var result =  _Content.LC_CostEstimateSummary.Where(x=>x.Cost_Estimate_ID==EstimateNo).FirstOrDefault();
              result.Estimation_Approval = true;
              result.Estimation_Approval_Date = date;
                _Content.SaveChanges();
                return 1;
            }
            catch (Exception)
            {
                throw;
            }
        }

        internal int EstimatingSave(int productId, string marchandisingNo)
        {
        //    try
        //    {
        //        _Content.LC_CostEstimateSummary.AddObject(summery);
        //        _Content.SaveChanges();
        //        return 1;
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
            return 1;
        }


        
    }
}
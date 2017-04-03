using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ERPSSL.LC.DAL;
using MoreLinq;
using ERPSSL.Production.DAL.Repository;

namespace ERPSSL.Production.DAL
{
    public class PlanningDAL
    {

        internal List<OrderDetails> GetOrdersDetails(string OCODE)
        {
            try
            {
                using (var _Context = new ERPSSL_LCEntities())
                {
                    List<OrderDetails> result = (from cs in _Context.LC_CostEstimateSummary
                                                 join cb in _Context.Com_Buyer_Setup on cs.Buyer_ID equals cb.Buyer_ID
                                                 join lf in _Context.LC_FinishGoods on cs.FinishedGoods_ID equals lf.FinishGoods_Id
                                                 where cs.OCode == OCODE
                                                 select new OrderDetails
                                                 {
                                                     Id = cs.Id,
                                                     Lc_Order = cs.Lc_Order,
                                                     Buyer_ID = cs.Buyer_ID,
                                                     BuyerName = cb.Buyer_Name,
                                                     OrderDate=cs.OrderDate,
                                                     FinishedGoodsName = lf.FinishGoods_Name,
                                                     FinishedGoods_ID = cs.FinishedGoods_ID,
                                                     FinishedGoods_Qty = cs.FinishedGoods_Qty,
                                                 }).ToList();
                    return result;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        internal int SavePlan(Prod_Planning _Prod_Planning)
        {
            try
            {
                using (var _context = new ERPSSL_LCEntities())
                {
                    _context.AddToProd_Planning(_Prod_Planning);
                    _context.SaveChanges();
                    return 1;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        internal List<OrderDetails> GetOrdersDetailsByOrderNo(string orderNo, string OCODE)
        {
            try
            {
                using (var _Context = new ERPSSL_LCEntities())
                {

                    List<OrderDetails> result = (from cs in _Context.LC_CostEstimateSummary
                                                 join cb in _Context.Com_Buyer_Setup on cs.Buyer_ID equals cb.Buyer_ID
                                                 join lf in _Context.LC_FinishGoods on cs.FinishedGoods_ID equals lf.FinishGoods_Id
                                                 where cs.OCode == OCODE && cs.Lc_Order == orderNo
                                                 select new OrderDetails
                                                 {
                                                     Id = cs.Id,
                                                     Lc_Order = cs.Lc_Order,
                                                     Buyer_ID = cs.Buyer_ID,
                                                     BuyerName = cb.Buyer_Name,
                                                     FinishedGoodsName = lf.FinishGoods_Name,
                                                     FinishedGoods_ID = cs.FinishedGoods_ID,
                                                     FinishedGoods_Qty = cs.FinishedGoods_Qty,
                                                     OrderDate = cs.OrderDate
                                                 }).ToList();

                    return result;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        internal List<HRM_SUB_SECTIONS> GetLine(string OCODE)
        {

            try
            {
                using (var _context = new ERPSSL_LCEntities())
                {
                    var result = _context.HRM_SUB_SECTIONS.Where(x => x.OCODE == OCODE).DistinctBy(x => x.SUB_SEC_NAME).ToList();

                    return result;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        internal int AddLineAllocation(Prod_LineAllocationTemp _LineAllocationTemp)
        {
            try
            {
                using (var _context = new ERPSSL_LCEntities())
                {
                    _context.AddToProd_LineAllocationTemp(_LineAllocationTemp);
                    _context.SaveChanges();
                    return 1;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        internal List<Prod_LineAllocationTemp> GetAllTempByPlanNo(string plan, string OCODE)
        {
            try
            {
                using (var _context = new ERPSSL_LCEntities())
                {
                    return _context.Prod_LineAllocationTemp.Where(x => x.PlanNo == plan && x.OCode == OCODE).ToList();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        internal List<Prod_ProductionStatusDetails> GetDailyProductionStatus()
        {
            try
            {
                using (var _context = new ERPSSL_LCEntities())
                {
                    return _context.Prod_ProductionStatusDetails.ToList();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
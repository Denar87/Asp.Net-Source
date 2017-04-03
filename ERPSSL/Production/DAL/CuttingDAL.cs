using ERPSSL.LC.DAL;
using ERPSSL.Production.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPSSL.Production.DAL
{
    public class CuttingDAL
    {
        private ERPSSL_LCEntities _Context = new ERPSSL_LCEntities();

        internal List<string> GetSeason(string OCode)
        {
            try
            {
                var Query = (from se in _Context.LC_OrderEntry
                             where se.OCODE == OCode
                             select se.Season).Distinct();
                return Query.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        internal List<string> GetStyleBySeason(string season)
        {
            try
            {
                var Query = (from st in _Context.LC_OrderEntry
                             where st.Season == season
                             select st.Style).Distinct();
                return Query.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        internal List<string> GetOrderByStyle(string style)
        {
            try
            {
                var Query = (from od in _Context.LC_OrderEntry
                             where od.Style == style
                             select od.Style).Distinct();
                return Query.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        internal List<OrderDetails> GetOrdersDetails(string OCODE)
        {
            try
            {
                using (var _Context = new ERPSSL_LCEntities())
                {
                    List<OrderDetails> result = (from cs in _Context.LC_CostEstimateSummary
                                                 join cb in _Context.Com_Buyer_Setup on cs.Buyer_ID equals cb.Buyer_ID
                                                 join lf in _Context.LC_FinishGoods on cs.FinishedGoods_ID equals lf.FinishGoods_Id
                                                 join iu in _Context.Inv_Unit on cs.ProductUnit equals iu.UnitId
                                                 where cs.OCode == OCODE
                                                 select new OrderDetails
                                                 {
                                                     Id = cs.Id,
                                                     ProductUnit = cs.ProductUnit,
                                                     UnitId = iu.UnitId,
                                                     UnitName = iu.UnitName,
                                                     Lc_Order = cs.Lc_Order,
                                                     Buyer_ID = cs.Buyer_ID,
                                                     BuyerName = cb.Buyer_Name,
                                                     OrderDate = cs.OrderDate,
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
        internal List<OrderDetails> GetOrdersDetailsByOrderNo(string orderNo, string OCODE)
        {
            try
            {
                using (var _Context = new ERPSSL_LCEntities())
                {

                    List<OrderDetails> result = (from cs in _Context.LC_CostEstimateSummary
                                                 join cb in _Context.Com_Buyer_Setup on cs.Buyer_ID equals cb.Buyer_ID
                                                 join lf in _Context.LC_FinishGoods on cs.FinishedGoods_ID equals lf.FinishGoods_Id
                                                 join iu in _Context.Inv_Unit on cs.ProductUnit equals iu.UnitId
                                                 where cs.OCode == OCODE && cs.Lc_Order == orderNo
                                                 select new OrderDetails
                                                 {
                                                     Id = cs.Id,

                                                     ProductUnit = cs.ProductUnit,
                                                     UnitId = iu.UnitId,
                                                     UnitName = iu.UnitName,
                                                     Lc_Order = cs.Lc_Order,
                                                     Buyer_ID = cs.Buyer_ID,
                                                     BuyerName = cb.Buyer_Name,
                                                     OrderDate = cs.OrderDate,
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
        internal List<CuttingDetailsR> GetCuttingDetailsByOrderNo(string orderNo, string OCODE)
        {
            try
            {
                using (var _Context = new ERPSSL_LCEntities())
                {
                    List<CuttingDetailsR> result = (from c in _Context.Prod_Cutting

                                                    join iu in _Context.Inv_Unit on c.CuttingReceivedUnit equals iu.UnitId
                                                    where c.OCode == OCODE
                                                    select new CuttingDetailsR
                                                    {
                                                        ID = c.ID,
                                                        OrderNo = c.OrderNo,
                                                        OrderQty = c.OrderQty,
                                                        GoodsName = c.GoodsName,
                                                        FGoodsQty = c.FGoodsQty,
                                                        FGoodsUnit = c.FGoodsUnit,
                                                        CuttingReceivedDate = c.CuttingReceivedDate,
                                                        CuttingReceivedQty = c.CuttingReceivedQty,
                                                        CuttingReceivedUnit = c.CuttingReceivedUnit,
                                                        CuttingCompleteDate = c.CuttingCompleteDate,
                                                        TotalCuttingCompleteQty = c.TotalCuttingCompleteQty,
                                                        TotalCuttingCompleteUnit = c.TotalCuttingCompleteUnit,
                                                        UnitId = iu.UnitId,
                                                        UnitName = iu.UnitName

                                                    }).ToList();
                    return result;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        internal int InsertProdCutting(Prod_Cutting _objProdCutting)
        {
            try
            {
                _Context.Prod_Cutting.AddObject(_objProdCutting);
                _Context.SaveChanges();
                return 1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal List<Inv_Unit> GetUnitForMarchandising()
        {
            try
            {
                var ItemName = (from IName in _Context.Inv_Unit
                                select IName);
                return ItemName.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        internal List<CuttingDetailsR> GetCuttingDetails(string OCODE)
        {
            try
            {
                using (var _Context = new ERPSSL_LCEntities())
                {
                    List<CuttingDetailsR> result = (from c in _Context.Prod_Cutting
                                                    join iu in _Context.Inv_Unit on c.CuttingReceivedUnit equals iu.UnitId
                                                    where c.OCode == OCODE
                                                    select new CuttingDetailsR
                                                 {
                                                     ID = c.ID,
                                                     OrderNo = c.OrderNo,
                                                     OrderQty = c.OrderQty,
                                                     GoodsName = c.GoodsName,                                                                                                     
                                                     FGoodsQty = c.FGoodsQty,
                                                     FGoodsUnit = c.FGoodsUnit,
                                                     CuttingReceivedDate = c.CuttingReceivedDate,
                                                     CuttingReceivedQty = c.CuttingReceivedQty,
                                                     CuttingReceivedUnit = c.CuttingReceivedUnit,
                                                     CuttingCompleteDate = c.CuttingCompleteDate,
                                                     TotalCuttingCompleteQty = c.TotalCuttingCompleteQty,
                                                     TotalCuttingCompleteUnit = c.TotalCuttingCompleteUnit,
                                                     UnitId = iu.UnitId,
                                                     UnitName = iu.UnitName

                                                 }).ToList();
                    return result;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        internal int UpdateProdCutting(Prod_Cutting _objProdCutting)
        {
            try
            {
                Prod_Cutting obj = _Context.Prod_Cutting.FirstOrDefault(x => x.ID == _objProdCutting.ID);
                obj.OrderNo = _objProdCutting.OrderNo;
                obj.OrderQty = _objProdCutting.OrderQty;
                obj.GoodsName = _objProdCutting.GoodsName;
                obj.FGoodsQty = _objProdCutting.FGoodsQty;
                obj.FGoodsUnit = _objProdCutting.FGoodsUnit;
                obj.CuttingReceivedDate = _objProdCutting.CuttingReceivedDate;
                obj.CuttingReceivedQty = _objProdCutting.CuttingReceivedQty;
                obj.CuttingReceivedUnit = _objProdCutting.CuttingReceivedUnit;
                obj.CuttingCompleteDate = _objProdCutting.CuttingCompleteDate;
                obj.TotalCuttingCompleteQty = _objProdCutting.TotalCuttingCompleteQty;
                obj.TotalCuttingCompleteUnit = _objProdCutting.TotalCuttingCompleteUnit;
                obj.Edit_User = _objProdCutting.Edit_User;
                obj.Edit_Date = _objProdCutting.Edit_Date;
                _Context.SaveChanges();
                return 1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal Prod_Cutting GetCuttingbyId(int cID)
        {
            Prod_Cutting buyeres = (from pc in _Context.Prod_Cutting
                                    where pc.ID == cID
                                    select pc).FirstOrDefault();
            return buyeres;
        }

    }
}
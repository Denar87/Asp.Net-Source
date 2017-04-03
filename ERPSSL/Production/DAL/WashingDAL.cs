using ERPSSL.LC.DAL;
using ERPSSL.Production.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPSSL.Production.DAL
{
    public class WashingDAL
    {
        private ERPSSL_LCEntities _Context = new ERPSSL_LCEntities();

        internal int InsertProdWashing(Prod_Washing _objProdWashing)
        {
            try
            {
                _Context.Prod_Washing.AddObject(_objProdWashing);
                _Context.SaveChanges();
                return 1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal int UpdateProdWashing(Prod_Washing _objProdWashing)
        {
            try
            {
                Prod_Washing obj = _Context.Prod_Washing.FirstOrDefault(x => x.ID == _objProdWashing.ID);
                obj.OrderNo = _objProdWashing.OrderNo;
                obj.OrderQty = _objProdWashing.OrderQty;
                obj.GoodsName = _objProdWashing.GoodsName;
                obj.FGoodsQty = _objProdWashing.FGoodsQty;
                obj.FGoodsUnit = _objProdWashing.FGoodsUnit;
                
                obj.TotalSewingCompleteQty = _objProdWashing.TotalSewingCompleteQty;
                obj.TotalSewingCompleteUnit = _objProdWashing.TotalSewingCompleteUnit;

                obj.TotalWashingReceivedDate = _objProdWashing.TotalWashingReceivedDate;
                obj.TotalWashingReceivedQty = _objProdWashing.TotalWashingReceivedQty;
                obj.TotalWashingReceivedUnit = _objProdWashing.TotalWashingReceivedUnit;

                obj.TotalWashingCompleteDate = _objProdWashing.TotalWashingCompleteDate;
                obj.TotalWashingCompleteQty = _objProdWashing.TotalWashingCompleteQty;
                obj.TotalWashingCompleteUnit = _objProdWashing.TotalWashingCompleteUnit;

                obj.Edit_User = _objProdWashing.Edit_User;
                obj.Edit_Date = _objProdWashing.Edit_Date;
                _Context.SaveChanges();
                return 1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal List<WashingDetailsR> GetWashingDetails(string OCODE)
        {
            try
            {
                using (var _Context = new ERPSSL_LCEntities())
                {
                    List<WashingDetailsR> result = (from w in _Context.Prod_Washing
                                                    join s in _Context.Prod_Sewing on w.SewingID equals s.ID
                                                    join c in _Context.Prod_Cutting on w.CuttingID equals c.ID
                                                    join cb in _Context.Com_Buyer_Setup on w.BuyerID equals cb.Buyer_ID
                                                    join iu in _Context.Inv_Unit on w.TotalWashingReceivedUnit equals iu.UnitId
                                                    where s.OCode == OCODE
                                                    select new WashingDetailsR
                                                   {
                                                       ID = w.ID,
                                                       CuttingID = w.CuttingID,
                                                       OrderNo = w.OrderNo,
                                                       OrderQty = w.OrderQty,
                                                       GoodsName = w.GoodsName,
                                                       FGoodsQty = w.FGoodsQty,
                                                       FGoodsUnit = w.FGoodsUnit,
                                                       SewingID=w.SewingID,
                                                       BuyerID=w.BuyerID,
                                                       TotalSewingCompleteQty = w.TotalSewingCompleteQty,
                                                       TotalSewingCompleteUnit = w.TotalSewingCompleteUnit,

                                                       TotalWashingReceivedDate = w.TotalWashingReceivedDate,
                                                       TotalWashingReceivedQty = w.TotalWashingReceivedQty,
                                                       TotalWashingReceivedUnit = w.TotalWashingReceivedUnit,
                                                       TotalWashingCompleteDate = w.TotalWashingCompleteDate,
                                                       TotalWashingCompleteQty = w.TotalWashingCompleteQty,
                                                       TotalWashingCompleteUnit = w.TotalWashingCompleteUnit,

                                                       Buyer_ID = cb.Buyer_ID,
                                                       BuyerName = cb.Buyer_Name,
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

        internal List<WashingDetailsR> GetWashingDetailsByOrderNo(string orderNo, string OCODE)
        {
            try
            {
                using (var _Context = new ERPSSL_LCEntities())
                {
                    List<WashingDetailsR> result = (from w in _Context.Prod_Washing
                                                    join s in _Context.Prod_Sewing on w.SewingID equals s.ID
                                                    join c in _Context.Prod_Cutting on w.CuttingID equals c.ID
                                                    join cb in _Context.Com_Buyer_Setup on w.BuyerID equals cb.Buyer_ID
                                                    join iu in _Context.Inv_Unit on w.TotalWashingReceivedUnit equals iu.UnitId
                                                    where s.OCode == OCODE
                                                    select new WashingDetailsR
                                                    {
                                                        ID = w.ID,
                                                        CuttingID = w.CuttingID,
                                                        SewingID = w.SewingID,
                                                        BuyerID = w.BuyerID,
                                                        OrderNo = w.OrderNo,
                                                        OrderQty = w.OrderQty,
                                                        GoodsName = w.GoodsName,
                                                        FGoodsQty = w.FGoodsQty,
                                                        FGoodsUnit = w.FGoodsUnit,
                                                        
                                                        TotalSewingCompleteQty = w.TotalSewingCompleteQty,
                                                        TotalSewingCompleteUnit = w.TotalSewingCompleteUnit,

                                                        TotalWashingReceivedDate = w.TotalWashingReceivedDate,
                                                        TotalWashingReceivedQty = w.TotalWashingReceivedQty,
                                                        TotalWashingReceivedUnit = w.TotalWashingReceivedUnit,
                                                        TotalWashingCompleteDate = w.TotalWashingCompleteDate,
                                                        TotalWashingCompleteQty = w.TotalWashingCompleteQty,
                                                        TotalWashingCompleteUnit = w.TotalWashingCompleteUnit,

                                                        Buyer_ID = cb.Buyer_ID,
                                                        BuyerName = cb.Buyer_Name,
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

        internal Prod_Washing GetWashinggbyId(int wID)
        {
            Prod_Washing was = (from ws in _Context.Prod_Washing
                                where ws.ID == wID
                               select ws).FirstOrDefault();
            return was;
        }
    }
}
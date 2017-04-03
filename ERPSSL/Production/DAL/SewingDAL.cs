using ERPSSL.LC.DAL;
using ERPSSL.Production.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPSSL.Production.DAL
{
    public class SewingDAL
    {
        private ERPSSL_LCEntities _Context = new ERPSSL_LCEntities();

        internal List<CuttingDetailsR> GetCuttingDetails(string OCODE)
        {
            try
            {
                using (var _Context = new ERPSSL_LCEntities())
                {
                    List<CuttingDetailsR> result = (from c in _Context.Prod_Cutting
                                                    join cb in _Context.Com_Buyer_Setup on c.BuyerID equals cb.Buyer_ID
                                                    join iu in _Context.Inv_Unit on c.CuttingReceivedUnit equals iu.UnitId
                                                    where c.OCode == OCODE
                                                    select new CuttingDetailsR
                                                 {
                                                     ID = c.ID,
                                                     //BuyerID=c.BuyerID,
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

        internal List<CuttingDetailsR> GetCuttingDetailsByOrderNo(string orderNo, string OCODE)
        {
            try
            {
                using (var _Context = new ERPSSL_LCEntities())
                {
                    List<CuttingDetailsR> result = (from c in _Context.Prod_Cutting
                                                    join cb in _Context.Com_Buyer_Setup on c.BuyerID equals cb.Buyer_ID
                                                    join iu in _Context.Inv_Unit on c.CuttingReceivedUnit equals iu.UnitId
                                                    where c.OCode == OCODE
                                                    select new CuttingDetailsR
                                                    {
                                                        ID = c.ID,
                                                        BuyerID = c.BuyerID,
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

        internal int InsertProdSewing(Prod_Sewing _objProdSewing)
        {
            try
            {
                _Context.Prod_Sewing.AddObject(_objProdSewing);
                _Context.SaveChanges();
                return 1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal int UpdateProdCutting(Prod_Sewing _objProdSewing)
        {
            try
            {
                Prod_Sewing obj = _Context.Prod_Sewing.FirstOrDefault(x => x.ID == _objProdSewing.ID);
                obj.OrderNo = _objProdSewing.OrderNo;
                obj.OrderQty = _objProdSewing.OrderQty;
                obj.GoodsName = _objProdSewing.GoodsName;
                obj.FGoodsQty = _objProdSewing.FGoodsQty;
                obj.FGoodsUnit = _objProdSewing.FGoodsUnit;
                //obj.CuttingCompleteDate = _objProdSewing.CuttingCompleteDate;
                obj.TotalCuttingCompleteQty = _objProdSewing.TotalCuttingCompleteQty;
                obj.TotalCuttingCompleteUnit = _objProdSewing.TotalCuttingCompleteUnit;

                obj.SewingReceivedDate = _objProdSewing.SewingReceivedDate;
                obj.TotalSewingReceivedQty = _objProdSewing.TotalSewingReceivedQty;
                obj.TotalSewingReceivedUnit = _objProdSewing.TotalSewingReceivedUnit;
                obj.SewingCompleteDate = _objProdSewing.SewingCompleteDate;
                obj.TotalSewingCompleteQty = _objProdSewing.TotalSewingCompleteQty;
                obj.TotalSewingCompleteUnit = _objProdSewing.TotalSewingCompleteUnit;
                obj.Edit_User = _objProdSewing.Edit_User;
                obj.Edit_Date = _objProdSewing.Edit_Date;
                _Context.SaveChanges();
                return 1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal List<SewingDetailsR> GetSewingDetails(string OCODE)
        {
            try
            {
                using (var _Context = new ERPSSL_LCEntities())
                {
                    List<SewingDetailsR> result = (from s in _Context.Prod_Sewing
                                                   join c in _Context.Prod_Cutting on s.CuttingID equals c.ID
                                                   join cb in _Context.Com_Buyer_Setup on s.BuyerID equals cb.Buyer_ID
                                                   join iu in _Context.Inv_Unit on s.TotalSewingReceivedUnit equals iu.UnitId
                                                   where s.OCode == OCODE
                                                   select new SewingDetailsR
                                                    {
                                                        ID = s.ID,
                                                        CuttingID=s.CuttingID,
                                                        //BuyerID=c.BuyerID,
                                                        OrderNo = s.OrderNo,
                                                        OrderQty = s.OrderQty,
                                                        GoodsName = s.GoodsName,
                                                        FGoodsQty = s.FGoodsQty,
                                                        FGoodsUnit = s.FGoodsUnit,
                                                        CuttingCompleteDate = s.CuttingCompleteDate,
                                                        TotalCuttingCompleteQty = s.TotalCuttingCompleteQty,
                                                        TotalCuttingCompleteUnit = s.TotalCuttingCompleteUnit,
                                                        SewingReceivedDate = s.SewingReceivedDate,
                                                        TotalSewingReceivedQty = s.TotalSewingReceivedQty,
                                                        TotalSewingReceivedUnit = s.TotalSewingReceivedUnit,
                                                        SewingCompleteDate = s.SewingCompleteDate,
                                                        TotalSewingCompleteQty = s.TotalSewingCompleteQty,
                                                        TotalSewingCompleteUnit = s.TotalSewingCompleteUnit,
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

        internal List<SewingDetailsR> GetSewingDetailsByOrderNo(string orderNo, string OCODE)
        {
            try
            {
                using (var _Context = new ERPSSL_LCEntities())
                {
                    List<SewingDetailsR> result = (from s in _Context.Prod_Sewing
                                                   join c in _Context.Prod_Cutting on s.CuttingID equals c.ID
                                                   join cb in _Context.Com_Buyer_Setup on s.BuyerID equals cb.Buyer_ID
                                                   join iu in _Context.Inv_Unit on s.TotalSewingReceivedUnit equals iu.UnitId
                                                   where s.OCode == OCODE && s.TotalSewingCompleteUnit == iu.UnitId
                                                   select new SewingDetailsR
                                                   {
                                                       ID = s.ID,
                                                       CuttingID = s.CuttingID,
                                                       //BuyerID=c.BuyerID,
                                                       OrderNo = s.OrderNo,
                                                       OrderQty = s.OrderQty,
                                                       GoodsName = s.GoodsName,
                                                       FGoodsQty = s.FGoodsQty,
                                                       FGoodsUnit = s.FGoodsUnit,
                                                       CuttingCompleteDate = s.CuttingCompleteDate,

                                                       TotalCuttingCompleteQty = s.TotalCuttingCompleteQty,
                                                       TotalCuttingCompleteUnit = s.TotalCuttingCompleteUnit,
                                                       SewingReceivedDate = s.SewingReceivedDate,
                                                       TotalSewingReceivedQty = s.TotalSewingReceivedQty,
                                                       TotalSewingReceivedUnit = s.TotalSewingReceivedUnit,
                                                       SewingCompleteDate = s.SewingCompleteDate,
                                                       TotalSewingCompleteQty = s.TotalSewingCompleteQty,
                                                       TotalSewingCompleteUnit = s.TotalSewingCompleteUnit,

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

        internal Prod_Sewing GetCuttingbyId(int sID)
        {
            Prod_Sewing sew = (from ps in _Context.Prod_Sewing
                               where ps.ID == sID
                               select ps).FirstOrDefault();
            return sew;
        }
    }
}
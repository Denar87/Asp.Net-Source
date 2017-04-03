using ERPSSL.LC.DAL;
using ERPSSL.Production.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPSSL.Production.DAL
{
    public class FinishingDAL
    {
        private ERPSSL_LCEntities _Context = new ERPSSL_LCEntities();

        internal int InsertProdFinishing(Prod_Finishing _objProdFinishing)
        {
            try
            {
                _Context.Prod_Finishing.AddObject(_objProdFinishing);
                _Context.SaveChanges();
                return 1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal int UpdateProdFinishing(Prod_Finishing _objProdFinishing)
        {
            try
            {
                Prod_Finishing obj = _Context.Prod_Finishing.FirstOrDefault(x => x.ID == _objProdFinishing.ID);
                obj.OrderNo = _objProdFinishing.OrderNo;
                obj.OrderQty = _objProdFinishing.OrderQty;
                obj.GoodsName = _objProdFinishing.GoodsName;
                obj.FGoodsQty = _objProdFinishing.FGoodsQty;
                obj.FGoodsUnit = _objProdFinishing.FGoodsUnit;

                //obj.TotalWashingCompleteDate = _objProdFinishing.TotalWashingCompleteDate;

                obj.TotalWashingCompleteQty = _objProdFinishing.TotalWashingCompleteQty;
                obj.TotalWashingCompleteUnit = _objProdFinishing.TotalWashingCompleteUnit;

                obj.TotalFinishingReceivedDate = _objProdFinishing.TotalFinishingReceivedDate;
                obj.TotalFinishingReceivedQty = _objProdFinishing.TotalFinishingReceivedQty;
                obj.TotalFinishingReceivedUnit = _objProdFinishing.TotalFinishingReceivedUnit;
                obj.TotalFinishingCompleteDate = _objProdFinishing.TotalFinishingCompleteDate;
                obj.TotalFinishingCompleteQty = _objProdFinishing.TotalFinishingCompleteQty;
                obj.TotalFinishingCompleteUnit = _objProdFinishing.TotalFinishingCompleteUnit;

                obj.Edit_User = _objProdFinishing.Edit_User;
                obj.Edit_Date = _objProdFinishing.Edit_Date;
                _Context.SaveChanges();
                return 1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal Prod_Finishing GetFinishingbyId(int fID)
        {
            Prod_Finishing was = (from ws in _Context.Prod_Finishing
                                  where ws.ID == fID
                                  select ws).FirstOrDefault();
            return was;
        }

        internal List<FinishingDetailsR> GetFinishingDetails(string OCODE)
        {
            try
            {
                using (var _Context = new ERPSSL_LCEntities())
                {
                    List<FinishingDetailsR> result = (from f in _Context.Prod_Finishing
                                                      join w in _Context.Prod_Washing on f.WashingID equals w.ID
                                                      join s in _Context.Prod_Sewing on w.SewingID equals s.ID
                                                      join c in _Context.Prod_Cutting on w.CuttingID equals c.ID
                                                      join cb in _Context.Com_Buyer_Setup on w.BuyerID equals cb.Buyer_ID
                                                      join iu in _Context.Inv_Unit on w.TotalWashingReceivedUnit equals iu.UnitId
                                                      where s.OCode == OCODE
                                                      select new FinishingDetailsR
                                                    {
                                                        ID = f.ID,
                                                        CuttingID = f.CuttingID,
                                                        OrderNo = f.OrderNo,
                                                        OrderQty = f.OrderQty,
                                                        GoodsName = f.GoodsName,
                                                        FGoodsQty = f.FGoodsQty,
                                                        FGoodsUnit = f.FGoodsUnit,
                                                        SewingID = f.SewingID,
                                                        BuyerID = f.BuyerID,
                                                        WashingID=f.WashingID,
                                                        TotalWashingCompleteDate = f.TotalWashingCompleteDate,
                                                        TotalWashingCompleteQty = f.TotalWashingCompleteQty,
                                                        TotalWashingCompleteUnit = f.TotalWashingCompleteUnit,
                                                        TotalFinishingReceivedDate=f.TotalFinishingReceivedDate,
                                                        TotalFinishingReceivedQty=f.TotalFinishingReceivedQty,
                                                        TotalFinishingReceivedUnit=f.TotalFinishingReceivedUnit,
                                                        TotalFinishingCompleteDate=f.TotalFinishingCompleteDate,
                                                        TotalFinishingCompleteQty=f.TotalFinishingCompleteQty,
                                                        TotalFinishingCompleteUnit=f.TotalFinishingCompleteUnit,


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

        internal List<FinishingDetailsR> GetFinishingDetailsByOrderNo(string orderNo, string OCODE)
        {
            try
            {
                using (var _Context = new ERPSSL_LCEntities())
                {
                    List<FinishingDetailsR> result = (from f in _Context.Prod_Finishing
                                                      join w in _Context.Prod_Washing on f.WashingID equals w.ID
                                                      join s in _Context.Prod_Sewing on w.SewingID equals s.ID
                                                      join c in _Context.Prod_Cutting on w.CuttingID equals c.ID
                                                      join cb in _Context.Com_Buyer_Setup on w.BuyerID equals cb.Buyer_ID
                                                      join iu in _Context.Inv_Unit on w.TotalWashingReceivedUnit equals iu.UnitId
                                                      where s.OCode == OCODE
                                                      select new FinishingDetailsR
                                                      {
                                                          ID = f.ID,
                                                          CuttingID = f.CuttingID,
                                                          OrderNo = f.OrderNo,
                                                          OrderQty = f.OrderQty,
                                                          GoodsName = f.GoodsName,
                                                          FGoodsQty = f.FGoodsQty,
                                                          FGoodsUnit = f.FGoodsUnit,
                                                          SewingID = f.SewingID,
                                                          BuyerID = f.BuyerID,
                                                          WashingID = f.WashingID,
                                                          TotalWashingCompleteDate = f.TotalWashingCompleteDate,
                                                          TotalWashingCompleteQty = f.TotalWashingCompleteQty,
                                                          TotalWashingCompleteUnit = f.TotalWashingCompleteUnit,
                                                          TotalFinishingReceivedDate = f.TotalFinishingReceivedDate,
                                                          TotalFinishingReceivedQty = f.TotalFinishingReceivedQty,
                                                          TotalFinishingReceivedUnit = f.TotalFinishingReceivedUnit,
                                                          TotalFinishingCompleteDate = f.TotalFinishingCompleteDate,
                                                          TotalFinishingCompleteQty = f.TotalFinishingCompleteQty,
                                                          TotalFinishingCompleteUnit = f.TotalFinishingCompleteUnit,


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
    }
}
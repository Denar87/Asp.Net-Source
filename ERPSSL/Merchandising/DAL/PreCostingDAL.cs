using ERPSSL.Merchandising.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPSSL.Merchandising.DAL
{
    public class PreCostingDAL
    {
        ERPSSL_MerchandisingEntities _Context = new ERPSSL_MerchandisingEntities();

        internal List<OrderEntryViewRepo> LoadSingalInfo(string ocode, string orderNo)
        {
            try
            {
                var LCOrderEntry = (from o in _Context.LC_OrderEntry
                                    join st in _Context.LC_Style on o.StyleId equals st.StyleId
                                    join se in _Context.LC_Season on o.SeasonId equals se.Season_Id
                                    join b in _Context.Com_Buyer_Setup on o.Buyer_ID equals b.Buyer_ID
                                    join bd in _Context.LC_BuyerDepartment on o.Buyer_DepartmentId equals bd.BuyerDepartment_Id
                                    join sc in _Context.LC_StyleCategor on o.Style_Category_Id equals sc.Style_Category_Id
                                    join ho in _Context.HRM_Office on o.Office_ID equals ho.OfficeID
                                    join u in _Context.Inv_Unit on o.Unit_Id equals u.UnitId
                                    join hp in _Context.HRM_PersonalInformations on o.EID equals hp.EID // It will open soon

                                    where o.OCODE == ocode && o.OrderNo == orderNo
                                    select new OrderEntryViewRepo
                                    {
                                        OrderId = (int)o.OrderEntryID,
                                        OrderReceivedDate = (DateTime)o.OrderReceiveDate,
                                        OrderNo = o.OrderNo,

                                        StyleId = (int)st.StyleId,
                                        Style = st.StyleName,

                                        SeasonId = (int)se.Season_Id,
                                        Season = se.Season_Name,

                                        BuyerId = (int)b.Buyer_ID,
                                        Buyer = b.Buyer_Name,

                                        BuyerDepartmentId = (int)bd.BuyerDepartment_Id,
                                        BuyerDepartment = bd.BuyerDepartment_Name,

                                        CategoryId = (int)sc.Style_Category_Id,
                                        Category = sc.Style_Category_Name,

                                        ItemDescription = o.Style_Description,
                                        Quantity = o.OrderQuantity,

                                        UnitId = (int)u.UnitId,
                                        Unit = u.UnitName,

                                        Currency = o.Currency,
                                        FOBPort = o.FOB_Port,

                                        ShipmentMode = o.Shipment_Mode,
                                        ShipmentDate = (DateTime)o.ShipmentDate,

                                        OfficeId = (int)ho.OfficeID,
                                        Office = ho.OfficeName,
                                        
                                        MerchendiserId = hp.EID,
                                        Merchendiser = hp.FirstName

                                    });

                
              
                return LCOrderEntry.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        internal int UpdateTwoInfo(LC_OrderEntry aLC_OrderEntry, string orderNo)
        {
            try
            {
                LC_OrderEntry LC_OrderEntry = _Context.LC_OrderEntry.First(x => x.OrderNo == orderNo);

                LC_OrderEntry.SMV = aLC_OrderEntry.SMV;
                LC_OrderEntry.Efficiency = aLC_OrderEntry.Efficiency;
                _Context.SaveChanges();
                return 1;

            }
            catch (Exception)
            {

                throw;
            }
        }

        internal List<Inv_ProductType> FillItemType()
        {
            try
            {
                var products = (from p in _Context.Inv_ProductType
                                select p);
                return products.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal List<Inv_ProductGroup> GetAllGroup(int typeId)
        {
            try
            {
               
                var groups = (from p in _Context.Inv_Product
                              join pg in _Context.Inv_ProductGroup on p.GroupId equals pg.GroupId
                              where p.ProductTypeId == typeId
                              select pg).Distinct();
                return groups.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        internal List<InvProductR> GetProduct(string OCODE, int itemType, int itemGroup)
        {
            try
            {
                var products = (from prod in _Context.Inv_Product
                                join u in _Context.Inv_Unit on prod.UnitId equals u.UnitId
                                join pg in _Context.Inv_ProductGroup on prod.GroupId equals pg.GroupId
                                join pt in _Context.Inv_ProductType on prod.ProductTypeId equals pt.ProductTypeId

                                where prod.OCode == OCODE && prod.ProductTypeId == itemType && prod.GroupId == itemGroup
                                select new InvProductR
                                {
                                    UnitId = u.UnitId,
                                    UnitName = u.UnitName,
                                    ProductId = prod.ProductId,
                                    GroupName = pg.GroupName,
                                    ProductName = prod.ProductName,
                                    Brand = prod.Brand,
                                    StyleAndSize = prod.StyleAndSize,
                                    FloorName = prod.FloorName,
                                    ReOrderQty = prod.ReOrderQty,
                                    Price = prod.Price,
                                    ProductTypeId = pt.ProductTypeId,
                                    ProductType = pt.ProductType
                                });
                return products.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        internal List<string> GetAllGSMByGroup(int ItemGroup)
        {
            try
            {

                var groups = (from p in _Context.LC_YarnDetermination
                              where p.ConstructionId == ItemGroup
                              select p.GSM).Distinct();
                return groups.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
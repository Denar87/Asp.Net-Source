using ERPSSL.Merchandising.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPSSL.Merchandising.DAL
{
    public class NewOrderEntryDAL
    {

        ERPSSL_MerchandisingEntities _Context = new ERPSSL_MerchandisingEntities();

        internal List<LC_Style> GetAllStyle(string ocode)
        {
            try
            {
                var ItemName = (from IName in _Context.LC_Style
                                where IName.OCode == ocode
                                select IName);
                return ItemName.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        internal List<LC_Season> GetSeason(string ocode)
        {
            try
            {
                var ItemName = (from IName in _Context.LC_Season
                                where IName.OCode == ocode
                                select IName);
                return ItemName.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        internal List<Com_Buyer_Setup> GetBuyerName(string OCode)
        {
            try
            {
                var Query = (from P in _Context.Com_Buyer_Setup
                             where P.OCODE == OCode
                             select P);
                return Query.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal List<LC_BuyerDepartment> GetBuyingDepartment(string OCode)
        {
            try
            {
                var Query = (from P in _Context.LC_BuyerDepartment
                             where P.OCode == OCode
                             select P).OrderBy(x => x.BuyerDepartment_Name);
                return Query.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal List<LC_StyleCategor> GetAllCategory(string ocode)
        {
            try
            {
                List<LC_StyleCategor> _StyleCategory = (from s in _Context.LC_StyleCategor
                                                        where s.OCode == ocode
                                                        select s).ToList();
                return _StyleCategory;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal List<HRM_Office> GetOffice()
        {
            try
            {
                List<HRM_Office> _HRMOffice = (from s in _Context.HRM_Office
                                               select s).ToList();
                return _HRMOffice;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal List<Inv_Unit> GetUnit()
        {
            try
            {
                List<Inv_Unit> _InvUnit = (from s in _Context.Inv_Unit
                                           select s).ToList();
                return _InvUnit;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal List<MerchandiserRepo> GetMerchandiser()
        {
            try
            {
                var query = (from p in _Context.HRM_PersonalInformations
                             select new MerchandiserRepo
                             {
                                 Id = p.EID,
                                 FullName = p.FirstName ?? "" + " " + (p.LastName ?? "").Trim(),
                             }

                             );

                return query.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal int SaveStyle(LC_Style aLC_Style)
        {

            using (var _Context = new ERPSSL_MerchandisingEntities())
            {
                _Context.LC_Style.AddObject(aLC_Style);
                _Context.SaveChanges();
                return aLC_Style.StyleId;
            }

        }

        internal int SaveSeasion(LC_Season aLC_Season)
        {
            using (var _Context = new ERPSSL_MerchandisingEntities())
            {
                _Context.LC_Season.AddObject(aLC_Season);
                _Context.SaveChanges();
                return aLC_Season.Season_Id;
            }
        }

        internal int SaveBuyerDepartment(LC_BuyerDepartment aLC_BuyerDepartment)
        {
            using (var _Context = new ERPSSL_MerchandisingEntities())
            {
                _Context.LC_BuyerDepartment.AddObject(aLC_BuyerDepartment);
                _Context.SaveChanges();
                return aLC_BuyerDepartment.BuyerDepartment_Id;
            }
        }

        internal int SaveCategory(LC_StyleCategor aLC_StyleCategor)
        {
            using (var _Context = new ERPSSL_MerchandisingEntities())
            {
                _Context.LC_StyleCategor.AddObject(aLC_StyleCategor);
                _Context.SaveChanges();
                return aLC_StyleCategor.Style_Category_Id;
            }
        }

        internal int SaveOrderEntry(LC_OrderEntry aLC_OrderEntry)
        {
            try
            {
                using (var _Context = new ERPSSL_MerchandisingEntities())
                {
                    _Context.LC_OrderEntry.AddObject(aLC_OrderEntry);
                    _Context.SaveChanges();
                    return 1;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        internal List<OrderEntryViewRepo> LoadDataForGrid(string ocode)
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
                                    //join hp in _Context.HRM_PersonalInformations on o.Merchandiser_Id equals hp.EID // It will open soon

                                    where o.OCODE == ocode
                                    select new OrderEntryViewRepo
                                    {
                                        OrderId = (int)o.OrderEntryID,
                                        OrderReceivedDate = (DateTime)o.OrderReceiveDate,
                                        OrderNo = o.OrderNo,

                                        StyleId = ( int)st.StyleId,
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

                                    });

                return LCOrderEntry.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        internal List<OrderEntryViewRepo> LoadDataForGridOrderNoWise(string ocode, string orderNo)
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
                                    join hp in _Context.HRM_PersonalInformations on o.EID equals hp.EID

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

                                        Country = o.Countryof_Production,

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

        internal List<OrderEntryViewRepo> LoadSingalInfo(int orderEntryId)
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
                                    //join hp in _Context.HRM_PersonalInformations on o.Merchandiser_Id equals hp.EID // It will open soon

                                    where o.OrderEntryID == orderEntryId
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

                                        Country = o.Countryof_Production,

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

                                    });

                return LCOrderEntry.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }
    }
}
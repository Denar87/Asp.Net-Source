using System.Data.Entity;
using ERPSSL.INV.DAL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using ERPSSL.LC.DAL.Repository;
using MoreLinq;

namespace ERPSSL.LC.DAL
{
    public class OrderSheetDAL
    {
        private ERPSSL_LCEntities _Context = new ERPSSL_LCEntities();
        DataAccessEX ado = new DataAccessEX();
        string conn = ConfigurationManager.ConnectionStrings["ERPSSLADO"].ConnectionString;

        internal List<Inv_Product> GetItemList(int Groupid)
        {
            try
            {
                var ItemName = (from IName in _Context.Inv_Product
                                where IName.GroupId == Groupid
                                select IName);
                return ItemName.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }
        internal List<Inv_Supplier> GetSupplierList()
        {
            var ItemName = (from IName in _Context.Inv_Supplier
                            where IName.Enlisted == true
                            select IName);
            return ItemName.ToList();

        }
        internal List<LC_Order_Planning> GetLCOrderPlanning(string article)
        {
            try
            {
                var ItemName = (from IName in _Context.LC_Order_Planning
                                where IName.Article == article
                                select IName);
                return ItemName.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }
        internal List<LC_Order_Planning> GetLCOrderPlanningStyleWise(string style)
        {
            try
            {
                var ItemName = (from IName in _Context.LC_Order_Planning
                                where IName.Style == style
                                select IName);
                return ItemName.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        internal List<Inv_BuyCentral> GetItemListInvBuyCentral(int Groupid)
        {
            try
            {
                var ItemName = (from IName in _Context.Inv_BuyCentral
                                where IName.ProductGroup == Groupid
                                select IName);
                return ItemName.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }
        internal List<Inv_Product> GetItemListInv_Product(int Groupid)
        {
            try
            {
                var ItemName = (from IName in _Context.Inv_Product
                                where IName.GroupId == Groupid
                                select IName);
                return ItemName.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        internal List<string> GetOrderEntryByarticle(string article)
        {
            try
            {
                var ItemName = (from IName in _Context.LC_OrderEntry
                                where IName.Article == article
                                select IName.Style).Distinct();
                return ItemName.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }
        internal List<string> GetOrderStyle(string ocode)
        {
            try
            {
                var ItemName = (from IName in _Context.LC_OrderEntry
                                where IName.OCODE == ocode
                                select IName.Style).Distinct();
                return ItemName.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }
        internal List<Inv_Supplier> GetInv_Supplier(string ocode)
        {
            try
            {
                var ItemName = (from IName in _Context.Inv_Supplier
                                where IName.OCode == ocode
                                select IName).OrderBy(x => x.SupplierName);
                return ItemName.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        internal List<LC_OrderEntry> GetOrderEntry_Season(string season)
        {
            try
            {
                var ItemName = (from IName in _Context.LC_OrderEntry
                                where IName.Season == season
                                select IName);
                return ItemName.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }
        internal List<string> GetOrderEntryBySeason(string season)
        {
            try
            {
                var ItemName = (from IName in _Context.LC_OrderEntry
                                where IName.Season == season
                                select IName.OrderNo).Distinct();
                return ItemName.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }
        internal List<string> GetOrderNo(string ocode)
        {
            try
            {
                var ItemName = (from IName in _Context.LC_OrderEntry
                                where IName.OCODE == ocode
                                select IName.OrderNo).Distinct();
                return ItemName.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }
        internal List<LC_MasterLC> GetLCNo(string Ocode)
        {
            try
            {
                var ItemName = (from IName in _Context.LC_MasterLC
                                where IName.OCODE == Ocode
                                select IName);
                return ItemName.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }
        internal List<LC_MasterLC> GetbankInfo(string LcNo)
        {
            try
            {
                var ItemName = (from IName in _Context.LC_MasterLC
                                where IName.LCNo == LcNo
                                select IName);
                return ItemName.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        internal List<string> GetOrderEntryByPoOrder(string Poorder)
        {
            try
            {
                var ItemName = (from IName in _Context.LC_OrderEntry
                                where IName.OrderNo == Poorder
                                select IName.Article).Distinct();
                return ItemName.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        internal List<LC_OrderEntry> GetOrderEntry(string ocode)
        {
            try
            {
                var ItemName = (from IName in _Context.LC_OrderEntry
                                where IName.OCODE == ocode
                                select IName);
                return ItemName.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        internal List<string> GetOrderEntryByDistrinct(string ocode)
        {
            try
            {
                var ItemName = (from IName in _Context.LC_OrderEntry
                                where IName.OCODE == ocode
                                select IName.Season).Distinct();
                return ItemName.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }
        internal List<Rep_MasterLC> GetOrderByDistrinct(string ocode)
        {
            try
            {
                var ItemName = (from IName in _Context.LC_MasterLC
                                where IName.OCODE == ocode
                                select new Rep_MasterLC
                                {
                                    MlcID = IName.MlcID,
                                    SeasonName = (IName.Season + "-" + IName.LCNo)
                                });
                return ItemName.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }
        internal List<Rep_MasterLC> GetLC_MasterLC(int id)
        {
            try
            {
                var ItemName = (from IName in _Context.LC_MasterLC
                                join bye in _Context.Com_Buyer_Setup on IName.Buyer_ID equals bye.Buyer_ID
                                where IName.MlcID == id
                                select new Rep_MasterLC
                                {
                                    BayerName = bye.Buyer_Name,
                                    LCNo = IName.LCNo,
                                    LC_USDValu = IName.LC_USDValu,
                                    LC_BDTValu = IName.LC_BDTValu,
                                    Qty = IName.Qty

                                });
                return ItemName.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }
        internal List<LC_Style> GetLC_Style(string ocode)
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

        internal List<LC_BackToBack_Temp> GetBackToBack(string PoNo)
        {
            try
            {
                var ItemName = (from IName in _Context.LC_BackToBack_Temp
                                where IName.POOrderNo == PoNo
                                select IName);
                return ItemName.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        internal List<ItemList> GetBackToBackByOCode(string OCode)
        {
            try
            {
                var ocode = new SqlParameter("@OCode", OCode);

                string SP_SQL = "Fund_Get_LCBackToBack @OCode";
                return (_Context.ExecuteStoreQuery<ItemList>(SP_SQL, ocode)).ToList();


            }
            catch (Exception)
            {
                throw;
            }
        }
        internal List<ItemList> GetBackToBackForINV(string OCode)
        {
            try
            {
                var ocode = new SqlParameter("@OCode", OCode);

                string SP_SQL = "INV_MRR_LCBackToBack @OCode";
                return (_Context.ExecuteStoreQuery<ItemList>(SP_SQL, ocode)).ToList();


            }
            catch (Exception)
            {
                throw;
            }
        }
        internal List<LC_BackToBack> GetBackToBackByID(string Id)
        {
            try
            {
                var ItemName = (from IName in _Context.LC_BackToBack
                                where IName.B2BLCNo == Id && IName.ApproveStatus == "Pending"
                                select IName).OrderBy(c => c.B2BId);
                return ItemName.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }
        internal List<LC_BackToBack> GetBackToBack_ForINVById(string Id)
        {
            try
            {
                var ItemName = (from IName in _Context.LC_BackToBack
                                where IName.B2BLCNo == Id && IName.ApproveStatus == "Approved"
                                select IName).OrderBy(c => c.B2BId);
                return ItemName.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        internal List<LC_Order_Planning> GetDataInLCBackToBack(string Style, string orderNo)
        {
            try
            {
                var ItemName = (from IName in _Context.LC_Order_Planning
                                where IName.Style == Style && IName.OrderNo == orderNo
                                select IName);
                return ItemName.ToList();
            }
            catch (Exception)
            {
                throw;
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

        internal int UpdateLCOrderPlanning(List<LC_Order_Planning_Temp> _LC_Order_Planning)
        {
            using (var _Context = new ERPSSL_LCEntities())
            {
                foreach (LC_Order_Planning_Temp aitem in _LC_Order_Planning)
                {
                    LC_Order_Planning_Temp planning = new LC_Order_Planning_Temp();
                    planning.OrderNo = aitem.OrderNo;
                    planning.BarCode = aitem.BarCode;
                    planning.ProductId = aitem.ProductId;
                    planning.ProductName = aitem.ProductName;
                    planning.StyleSize = aitem.StyleSize;
                    planning.Season = aitem.Season;
                    planning.Brand = aitem.Brand;
                    planning.OCode = aitem.OCode;
                    planning.CreateUser = aitem.CreateUser;
                    planning.CPU = aitem.CPU;
                    planning.Qty = aitem.Qty;
                    planning.UnitName = aitem.UnitName;
                    planning.OrderPlanningAutoId = aitem.OrderPlanningAutoId;
                    planning.Style = aitem.Style;
                    planning.TotalQty = aitem.TotalQty;
                    planning.USDRate = aitem.USDRate;
                    planning.USDValue = aitem.USDValue;
                    planning.BDTRate = aitem.BDTRate;
                    planning.BDTValue = aitem.BDTValue;
                    planning.Article = aitem.Article;
                    _Context.LC_Order_Planning_Temp.AddObject(planning);
                    _Context.SaveChanges();
                }
                return 1;
            }
        }

        internal int TransferBackToBack(string BBLcautono)
        {
            try
            {
                var ParamempID = new SqlParameter("@BBLCAutoNo", BBLcautono);
                string SP_SQL = "LC_Back_To_Back_Transfer @BBLCAutoNo";
                _Context.ExecuteStoreCommand(SP_SQL, ParamempID);
                return 1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal int TransferOrderplanning(string OrderPlanningAutoId)
        {
            try
            {
                var ParamempID = new SqlParameter("@OrderPlanningAutoId", OrderPlanningAutoId);
                string SP_SQL = "LC_Order_Planning_Transfer @OrderPlanningAutoId";
                _Context.ExecuteStoreCommand(SP_SQL, ParamempID);
                return 1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal int InsertBackToBack(List<LC_BackToBack_Temp> _LC_BackToBack)
        {
            using (var _Context = new ERPSSL_LCEntities())
            {
                foreach (LC_BackToBack_Temp aitem in _LC_BackToBack)
                {
                    LC_BackToBack_Temp planning = new LC_BackToBack_Temp();
                    planning.POOrderNo = aitem.POOrderNo;
                    planning.Barcode = aitem.Barcode;
                    planning.ProductId = aitem.ProductId;
                    planning.ProductName = aitem.ProductName;
                    planning.StyleSize = aitem.StyleSize;
                    planning.Season = aitem.Season;
                    planning.Brand = aitem.Brand;
                    planning.OCode = aitem.OCode;
                    planning.CreateUser = aitem.CreateUser;
                    planning.CPU = aitem.CPU;
                    planning.ReqQty = aitem.ReqQty;
                    planning.BBLCAutoId = aitem.BBLCAutoId;
                    planning.Style = aitem.Style;
                    planning.MasterLC = aitem.MasterLC;
                    planning.PI = aitem.PI;
                    planning.Unit = aitem.Unit;
                    planning.PIDate = aitem.PIDate;
                    planning.B2BLCNo = aitem.B2BLCNo;
                    planning.ExpireDate = aitem.ExpireDate;
                    planning.BBLCDate = aitem.BBLCDate;
                    planning.ProductGroupId = aitem.ProductGroupId;
                    planning.BDTRate = aitem.BDTRate;
                    planning.BDTValue = aitem.BDTValue;
                    planning.USDRate = aitem.USDRate;
                    planning.USDValue = aitem.USDValue;
                    planning.BayerType = aitem.BayerType;
                    planning.SightDaysInterest = aitem.SightDaysInterest;
                    planning.BBLCShipmentDate = aitem.BBLCShipmentDate;
                    planning.SupplierId = aitem.SupplierId;
                    planning.Article = aitem.Article;
                    _Context.LC_BackToBack_Temp.AddObject(planning);
                    _Context.SaveChanges();
                }
                return 1;
            }
        }
        internal string GetNewChalanNo(string code, DateTime day, string supplierid)
        {
            int count;
            DateTime time = DateTime.Now;
            string challanNo = code + day.Year + day.Month + day.Day + time.Minute + time.Second;

            try
            {
                count = int.Parse(ado.AggRetrive("select count(B2BId) from LC_BackToBack where SupplierId ='" + supplierid + "' ", conn).ToString());
                challanNo += (count + 1).ToString();//.PadLeft(2,'0');
            }
            catch { }
            return challanNo;
        }

        internal string GetNewOrderNo(string code, DateTime day, string season)
        {
            try
            {
                int count;
                DateTime time = DateTime.Now;
                string challanNo = code + day.Year + day.Month + day.Day + time.Minute + time.Second;

                count = int.Parse(ado.AggRetrive("select count(OrderPlanningId) from LC_Order_Planning where Season ='" + season + "' ", conn).ToString());
                challanNo += (count + 1).ToString();//.PadLeft(2,'0');

                return challanNo;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal List<LC_Order_Planning_Temp> GetLCOrderPlanningTemp(string season)
        {
            try
            {
                var ItemName = (from IName in _Context.LC_Order_Planning_Temp
                                where IName.Season == season
                                select IName);
                return ItemName.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal List<LC_Order_Planning> GetLCOrderPlanningByStyle(string style)
        {
            try
            {
                var ItemName = (from IName in _Context.LC_Order_Planning
                                where IName.Style == style
                                select IName);
                return ItemName.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        internal int BackToBackApprove(List<LC_BackToBack> lstLC_BackToBack)
        {
            try
            {
                foreach (LC_BackToBack aReq in lstLC_BackToBack)
                {
                    LC_BackToBack obj = _Context.LC_BackToBack.First(x => x.B2BId == aReq.B2BId);
                    obj.ApproveDate = aReq.ApproveDate;
                    obj.ApproveNo = aReq.ApproveNo;
                    obj.ApproveStatus = aReq.ApproveStatus;
                    obj.EditDate = DateTime.Today;
                    obj.EditUser = aReq.EditUser;
                    _Context.SaveChanges();
                }
                _Context.SaveChanges();
                return 1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal List<string> GetOrderById(string ocode, string sesson)
        {
            try
            {
                var ItemName = (from o in _Context.LC_OrderEntry
                                where o.OCODE == ocode && o.Season == sesson
                                select o.OrderNo);
                return ItemName.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        internal List<LC_OrderEntry> GetOrderBySeasonId(string ocode)
        {
            try
            {
                var ItemName = (from o in _Context.LC_OrderEntry
                                where o.OCODE == ocode 
                                select o).ToList();
                return ItemName;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //internal List<LC_OrderEntry> GetSeasonByDistrinct()
        //{
        //    try
        //    {
        //        var ItemName = (from IName in _Context.LC_OrderEntry
        //                        select IName.Season);
        //        return ItemName.ToList();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        //internal List<LC_OrderEntry> GetSeasonByOrderId()
        //{
        //    try
        //    {
        //        var ItemName = (from IName in _Context.LC_OrderEntry
        //                        select IName.Season);
        //        return ItemName.ToList();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        internal List<LC_OrderEntry> GetSeasonById(string OCode)
        {
            try
            {
                var ItemName = (from IName in _Context.LC_OrderEntry
                                where IName.OCODE == OCode
                                select IName);
                return ItemName.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal List<LC_Season> GetSeasonId(string OCode)
        {
            try
            {
                var ItemName = (from IName in _Context.LC_Season
                                where IName.OCode == OCode
                                select IName);
                return ItemName.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal List<LC_OrderEntry> GetLCArticalByOrderNo(string OrderNo, string OCode)
        {
            try
            {
                var ItemName = (from IName in _Context.LC_OrderEntry
                                where IName.OrderNo == OrderNo && IName.OCODE == OCode
                                select IName);
                return ItemName.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal int AddSeason(LC_Season aLC_Season)
        {
            _Context.LC_Season.AddObject(aLC_Season);
            _Context.SaveChanges();
            return 1;
        }

        internal List<LC_Season> GetOrderByOcode(string ocode)
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

        internal List<Com_Buyer_Setup> GetPrincipalName(string OCode)
        {
            try
            {
                var Query = (from P in _Context.Com_Buyer_Setup
                             where P.OCODE == OCode
                             select P).DistinctBy(x => x.PrincipalName);
                return Query.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal List<Com_Buyer_Setup> GetBuyerName(string OCode)
        {
            try
            {
                var Query = (from P in _Context.Com_Buyer_Setup
                             where P.OCODE == OCode
                             select P).DistinctBy(x => x.Buyer_Name);
                return Query.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal List<LC_BuyerDepartment> GetBuyingDepartmentName(string OCode)
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

        internal int AddBuyerDepartment(LC_BuyerDepartment _LC_BuyerDepartment)
        {
            try
            {
                _Context.LC_BuyerDepartment.AddObject(_LC_BuyerDepartment);
                _Context.SaveChanges();
                return 1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal List<Com_Buyer_Setup> GetBuyerS_Name(string OCode)
        {
            try
            {
                var Query = (from P in _Context.Com_Buyer_Setup
                             where P.OCODE == OCode
                             select P).DistinctBy(x => x.PrincipalName);
                return Query.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal List<Com_Buyer_Setup> GetBuyerS_NameL(string OCode)
        {
            try
            {
                var Query = (from P in _Context.Com_Buyer_Setup
                             where P.OCODE == OCode
                             select P).DistinctBy(x => x.Buyer_Name);
                return Query.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal List<LC_Factory> GetSFactory(string OCode)
        {
            try
            {
                var Query = (from P in _Context.LC_Factory
                             where P.OCode == OCode
                             select P).DistinctBy(x => x.FactoryName);
                return Query.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal int AddStyleCategor(LC_StyleCategor _LC_StyleCategor)
        {
            try
            {
                _Context.LC_StyleCategor.AddObject(_LC_StyleCategor);
                _Context.SaveChanges();
                return _LC_StyleCategor.Style_Category_Id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal List<LC_Season> GetAllSeason(string OCode)
        {
            try
            {
                var Sea = (from S in _Context.LC_Season
                           where S.OCode == OCode
                           select S);
                return Sea.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal List<LC_OrderEntry> GetOrderEntryList(string OCode)
        {
            try
            {
                var ItemName = (from IName in _Context.LC_OrderEntry
                                where IName.OCODE == OCode
                                select IName);
                return ItemName.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal List<LC_Style> GetStyleList(string OCode)
        {
            try
            {
                var ItemName = (from IName in _Context.LC_Style
                                //join O in _Context.LC_OrderEntry on IName.StyleId equals O.StyleId
                                where IName.OCode == OCode
                                select IName);
                return ItemName.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using ERPSSL.LC.DAL.Repository;
using ERPSSL.LC.DAL;
namespace ERPSSL.LC.BLL
{
    public class OrderSheetBLL
    {
        DataAccess ado = new DataAccess();
        OrderSheetDAL _orderSheetdal = new OrderSheetDAL();
        string conn = ConfigurationManager.ConnectionStrings["ERPSSLADO"].ConnectionString;

        internal string GetMarchandisingNo(string code, DateTime day)
        {
            DateTime Date = DateTime.Now;
            int count;
            string challanNo = code + day.Year + day.Month + day.Day + Date.Minute + Date.Second;

            try
            {

                count = int.Parse(ado.AggRetrive("select count(Id) from Inv_Product where OCode ='" + code + "' ", conn).ToString());
                    challanNo += (count + 1).ToString();//.PadLeft(2,'0');

            }
            catch { }

            return challanNo;
        }

        internal string GetRequisitionNo(string code, DateTime day)
        {
            DateTime Date = DateTime.Now;
            int count;
            string challanNo = "Req-" + code + day.Year + day.Month + day.Day + Date.Minute + Date.Second;

            try
            {

                count = int.Parse(ado.AggRetrive("select count(Id) from LC_Requisition where OCode ='" + code + "' ", conn).ToString());
                challanNo += (count + 1).ToString();//.PadLeft(2,'0');


            }
            catch { }

            return challanNo;
        }

        internal List<Inv_Product> GetItemList( int Groupid)
        {
            return _orderSheetdal.GetItemList(Groupid);
        }
        internal List<Inv_BuyCentral> GetItemListInvBuyCentral(int Groupid)
        {
            return _orderSheetdal.GetItemListInvBuyCentral(Groupid);
        }
        internal List<Inv_Supplier> GetInv_Supplier(string ocode)
        {
            return _orderSheetdal.GetInv_Supplier(ocode);
        }
        internal List<Inv_Product> GetItemListInv_Product(int Groupid)
        {
            return _orderSheetdal.GetItemListInv_Product(Groupid);
        }
        internal List<Inv_Unit> GetUnitForMarchandising()
        {
            return _orderSheetdal.GetUnitForMarchandising();
        }
        internal List<LC_OrderEntry> GetOrderEntry(string ocode)
        {
            return _orderSheetdal.GetOrderEntry(ocode);
        }
        internal List<string> GetOrderEntryByDistrinct(string ocode)
        {
            return _orderSheetdal.GetOrderEntryByDistrinct(ocode);
        }
        internal List<LC_MasterLC> GetLCNo(string Ocode)
        {
            return _orderSheetdal.GetLCNo(Ocode);
        }
        internal List<LC_MasterLC> GetbankInfo(string LcNo)
        {
            return _orderSheetdal.GetbankInfo(LcNo);
        }
        internal List<string> GetOrderEntryBySeason(string season)
        {
            return _orderSheetdal.GetOrderEntryBySeason(season);
        }
        internal List<string> GetOrderNo(string ocode)
        {
            return _orderSheetdal.GetOrderNo(ocode);
        }
        internal List<string> GetOrderStyle(string ocode)
        {
            return _orderSheetdal.GetOrderStyle(ocode);
        }
     
        internal List<ItemList> GetBackToBackForINV(string OCode)
        {
            return _orderSheetdal.GetBackToBackForINV(OCode);
        }
        internal List<string> GetOrderEntryByPoOrder(string Poorder)
        {
            return _orderSheetdal.GetOrderEntryByPoOrder(Poorder);
        }
        internal int UpdateLCOrderPlanning(List<LC_Order_Planning_Temp> _LC_Order_Planning)
        {
            return _orderSheetdal.UpdateLCOrderPlanning(_LC_Order_Planning);
        }
        internal List<LC_Order_Planning> GetLCOrderPlanning(string article)
        {
            return _orderSheetdal.GetLCOrderPlanning(article);
        }
        internal List<LC_Order_Planning> GetLCOrderPlanningStyleWise(string style)
        {
            return _orderSheetdal.GetLCOrderPlanningStyleWise(style);
        }
        internal void DeleteLOrderPlanningTempById(int id)
        {
            try
            {
                ado.AggRetrive("delete from LC_Order_Planning_Temp where OrderPlanningId = " + id + "", conn);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        internal void DeleteLOrderPlanningById(int id)
        {
            try
            {
                ado.AggRetrive("delete from LC_Order_Planning where OrderPlanningId = " + id + "", conn);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        internal List<Inv_Supplier> GetSupplierList()
        {
            return _orderSheetdal.GetSupplierList();
        }
        internal int InsertBackToBack(List<LC_BackToBack_Temp> _LC_BackToBack)
        {
            return _orderSheetdal.InsertBackToBack(_LC_BackToBack);
        }
        internal List<LC_BackToBack_Temp> GetBackToBack(string PoNo)
        {
            return _orderSheetdal.GetBackToBack(PoNo);
        }
        internal string GetNewChalanNo(string code, DateTime day, string supplierid)
        {
            return _orderSheetdal.GetNewChalanNo(code,day,supplierid);
        }
        internal int TransferBackToBack(string BBLcautono)
        {
            return _orderSheetdal.TransferBackToBack(BBLcautono);
        }
        internal int TransferOrderplanning(string OrderPlanningAutoId)
        {
            return _orderSheetdal.TransferOrderplanning(OrderPlanningAutoId);
        }
        internal string GetNewOrderNo(string code, DateTime day, string season)
        {
            return _orderSheetdal.GetNewOrderNo(code, day, season);
        }
        internal List<LC_Order_Planning> GetDataInLCBackToBack(string Style, string orderNo)
        {
            return _orderSheetdal.GetDataInLCBackToBack(Style, orderNo);
        }

        internal List<LC_Order_Planning_Temp> GetLCOrderPlanningTemp(string season)
        {
            return _orderSheetdal.GetLCOrderPlanningTemp(season);
        }
        internal List<LC_Order_Planning> GetLCOrderPlanningByStyle(string style)
        {
            return _orderSheetdal.GetLCOrderPlanningByStyle(style);
        }
        internal List<ItemList> GetBackToBackByOCode(string OCode)
        {
            return _orderSheetdal.GetBackToBackByOCode(OCode);
        }
        internal List<LC_BackToBack> GetBackToBackByID(string Id)
        {
            return _orderSheetdal.GetBackToBackByID(Id);
        }
        internal List<LC_BackToBack> GetBackToBack_ForINVById(string Id)
        {
            return _orderSheetdal.GetBackToBack_ForINVById(Id);
        }
        internal int BackToBackApprove(List<LC_BackToBack> lstLC_BackToBack)
        {
            return _orderSheetdal.BackToBackApprove(lstLC_BackToBack);
        }
        internal List<string> GetOrderEntryByarticle(string article)
        {
            return _orderSheetdal.GetOrderEntryByarticle(article);
        }
        internal List<LC_OrderEntry> GetOrderEntry_Season(string season)
        {
            return _orderSheetdal.GetOrderEntry_Season(season);
        }
        internal List<Rep_MasterLC> GetOrderByDistrinct(string ocode)
        {
            return _orderSheetdal.GetOrderByDistrinct(ocode);
        }
        internal List<Rep_MasterLC> GetLC_MasterLC(int id)
        {
            return _orderSheetdal.GetLC_MasterLC(id);
        }
        internal List<LC_Style> GetLC_Style(string ocode)
        {
            return _orderSheetdal.GetLC_Style(ocode);
        }

        internal List<string> GetOrderById(string ocode, string sesson)
        {
            return _orderSheetdal.GetOrderById(ocode, sesson);
        }
        internal List<LC_OrderEntry> GetOrderBySeasonId(string ocode)
        {
            return _orderSheetdal.GetOrderBySeasonId(ocode);
        }
        internal List<LC_OrderEntry> GetSeasonById(string OCode)
        {
            return _orderSheetdal.GetSeasonById(OCode);
        }
        internal List<LC_Season> GetSeasonId(string OCode)
        {
            return _orderSheetdal.GetSeasonId(OCode);
        }
        internal List<LC_OrderEntry> GetLCArticalByOrderNo(string OrderNo, string OCode)
        {
            return _orderSheetdal.GetLCArticalByOrderNo(OrderNo, OCode);
        }

        internal int AddSeason(LC_Season aLC_Season)
        {
            return _orderSheetdal.AddSeason(aLC_Season);
        }

        internal List<LC_Season> GetOrderByOcode(string ocode)
        {
            return _orderSheetdal.GetOrderByOcode(ocode);
        }

        internal List<Com_Buyer_Setup> GetPrincipalName(string OCode)
        {
            return _orderSheetdal.GetPrincipalName(OCode);
        }

        internal List<Com_Buyer_Setup> GetBuyerName(string OCode)
        {
            return _orderSheetdal.GetBuyerName(OCode);
        }

        internal List<LC_BuyerDepartment> GetBuyingDepartmentName(string OCode)
        {
            return _orderSheetdal.GetBuyingDepartmentName(OCode);
        }

        internal int AddBuyerDepartment(LC_BuyerDepartment _LC_BuyerDepartment)
        {
            return _orderSheetdal.AddBuyerDepartment(_LC_BuyerDepartment);
        }

        internal List<Com_Buyer_Setup> GetBuyerS_Name(string OCode)
        {
            return _orderSheetdal.GetBuyerS_Name(OCode);
        }

        internal List<Com_Buyer_Setup> GetBuyerS_NameL(string OCode)
        {
            return _orderSheetdal.GetBuyerS_NameL(OCode);
        }

        internal List<LC_Factory> GetSFactory(string OCode)
        {
            return _orderSheetdal.GetSFactory(OCode);
        }

        internal int AddStyleCategor(LC_StyleCategor _LC_StyleCategor)
        {
            return _orderSheetdal.AddStyleCategor(_LC_StyleCategor);
        }

        internal List<LC_Season> GetAllSeason(string OCode)
        {
            return _orderSheetdal.GetAllSeason(OCode);
        }

        internal List<LC_OrderEntry>  GetOrderEntryList(string OCode)
        {
            return _orderSheetdal.GetOrderEntryList(OCode);
        }

        internal List<LC_Style> GetStyleList(string OCode)
        {
            return _orderSheetdal.GetStyleList( OCode);
        }
    }
}
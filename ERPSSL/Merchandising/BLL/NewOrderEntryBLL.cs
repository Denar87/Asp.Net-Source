using ERPSSL.Merchandising.DAL;
using ERPSSL.Merchandising.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPSSL.Merchandising.BLL
{
    public class NewOrderEntryBLL
    {

        NewOrderEntryDAL aNewOrderEntryDAL = new NewOrderEntryDAL(); 

        internal List<LC_Style> GetAllStyle(string ocode)
        {
            return aNewOrderEntryDAL.GetAllStyle(ocode);
        }

        internal List<LC_Season> GetSeason(string ocode)
        {
            return aNewOrderEntryDAL.GetSeason(ocode);
        }

        internal List<Com_Buyer_Setup> GetBuyerName(string OCode)
        {
            return aNewOrderEntryDAL.GetBuyerName(OCode);
        }

        internal List<LC_BuyerDepartment> GetBuyingDepartment(string OCode)
        {
            return aNewOrderEntryDAL.GetBuyingDepartment(OCode);
        }

        internal List<LC_StyleCategor> GetAllCategory(string ocode)
        {
            return aNewOrderEntryDAL.GetAllCategory(ocode);
        }

        internal List<HRM_Office> GetOffice()
        {
            return aNewOrderEntryDAL.GetOffice();
        }

        internal List<Inv_Unit> GetUnit()
        {
            return aNewOrderEntryDAL.GetUnit();
        }

        internal List<MerchandiserRepo> GetMerchandiser()
        {
            return aNewOrderEntryDAL.GetMerchandiser();
        }

        internal int SaveStyle(LC_Style aLC_Style)
        {
            return aNewOrderEntryDAL.SaveStyle(aLC_Style);
        }

        internal int SaveSeasion(LC_Season aLC_Season)
        {
            return aNewOrderEntryDAL.SaveSeasion(aLC_Season);
        }

        internal int SaveBuyerDepartment(LC_BuyerDepartment aLC_BuyerDepartment)
        {
            return aNewOrderEntryDAL.SaveBuyerDepartment(aLC_BuyerDepartment);
        }

        internal int SaveCategory(LC_StyleCategor aLC_StyleCategor)
        {
            return aNewOrderEntryDAL.SaveCategory(aLC_StyleCategor);
        }

        internal int SaveOrderEntry(LC_OrderEntry aLC_OrderEntry)
        {
            return aNewOrderEntryDAL.SaveOrderEntry(aLC_OrderEntry);
        }

        internal List<OrderEntryViewRepo> LoadDataForGrid(string ocode)
        {
            return aNewOrderEntryDAL.LoadDataForGrid(ocode);
        }

        internal List<OrderEntryViewRepo> LoadDataForGridOrderNoWise(string ocode, string orderNo)
        {
            return aNewOrderEntryDAL.LoadDataForGridOrderNoWise(ocode, orderNo);
        }

        internal List<OrderEntryViewRepo> LoadSingalInfo(int orderEntryId)
        {
            return aNewOrderEntryDAL.LoadSingalInfo(orderEntryId);
        }
    }
}
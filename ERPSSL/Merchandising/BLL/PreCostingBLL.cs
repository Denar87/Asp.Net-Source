using ERPSSL.Merchandising.DAL;
using ERPSSL.Merchandising.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPSSL.Merchandising.BLL
{
    public class PreCostingBLL
    {

        PreCostingDAL aPreCostingDAL = new PreCostingDAL();

        internal List<OrderEntryViewRepo> LoadSingalInfo(string ocode, string orderNo)
        {
            return aPreCostingDAL.LoadSingalInfo(ocode, orderNo);
        }

        internal int UpdateTwoInfo(LC_OrderEntry aLC_OrderEntry, string orderNo)
        {
            return aPreCostingDAL.UpdateTwoInfo(aLC_OrderEntry,orderNo);
        }

        internal List<Inv_ProductType> FillItemType()
        {
            return aPreCostingDAL.FillItemType();
        }

        internal List<Inv_ProductGroup> GetAllGroup(int typeId)
        {
            return aPreCostingDAL.GetAllGroup(typeId);
        }

        internal List<InvProductR> GetProduct(string OCODE, int itemType, int itemGroup)
        {
            return aPreCostingDAL.GetProduct(OCODE, itemType, itemGroup);
        }

        internal List<string> GetAllGSMByGroup(int ItemGroup)
        {
            return aPreCostingDAL.GetAllGSMByGroup(ItemGroup);
        }
    }
}
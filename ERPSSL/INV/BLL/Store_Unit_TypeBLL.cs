using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ERPSSL.INV.DAL;

namespace ERPSSL.INV.BLL
{
    public class Store_Unit_TypeBLL
    {
        Store_Unit_Type_DAL aStoreUnitType = new Store_Unit_Type_DAL();

        internal List<Inv_Store_Unit_Type> GetAllStoreUnit()
        {
            return aStoreUnitType.GetAllStoreUnit();
        }

        internal int InsertStoreunit(DAL.Inv_Store_Unit_Type InvStore)
        {
            return aStoreUnitType.InsertStoreunit(InvStore);
        }

        internal int UpdateStoreunit(DAL.Inv_Store_Unit_Type InvStore, int ID)
        {
            return aStoreUnitType.UpdateStoreunit(InvStore,ID);
        }

        internal List<Inv_Store_Unit_Type> GetStorerID(string StoreID)
        {
            return aStoreUnitType.GetStorerID(StoreID);
        }
    }
}
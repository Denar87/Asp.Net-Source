using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ERPSSL.INV.BLL;

namespace ERPSSL.INV.DAL
{
    public class Store_Unit_Type_DAL
    {
        private ERPSSL_INVEntities _context = new ERPSSL_INVEntities();
        internal int InsertStoreunit(Inv_Store_Unit_Type InvStore)
        {
            try
            {
                _context.Inv_Store_Unit_Type.AddObject(InvStore);
                _context.SaveChanges();
                return 1;

            }
            catch (Exception)
            { 
                throw;
            }
        }

        internal List<Inv_Store_Unit_Type> GetAllStoreUnit()
        {
            try
            {

                var STOREUNIT = (from storeUnit in _context.Inv_Store_Unit_Type

                                select storeUnit).OrderBy(x => x.Store_UnitType_Name);


                return STOREUNIT.ToList();

            }
            catch (Exception)
            { 
                throw;
            }
        }

        internal int UpdateStoreunit(Inv_Store_Unit_Type InvStore, int ID)
        {
            try
            {
                Inv_Store_Unit_Type InvStoreUnit = _context.Inv_Store_Unit_Type.First(x => x.Store_UnitType_Id == ID);
                InvStoreUnit.Store_UnitType_Name = InvStore.Store_UnitType_Name;
                InvStoreUnit.Icon_Path = InvStore.Icon_Path;
                InvStoreUnit.Description = InvStore.Description;
                _context.SaveChanges();
                return 1;

            }
            catch (Exception)
            {

                throw;
            }
        }

        internal List<Inv_Store_Unit_Type> GetStorerID(string StoreID)
        {
            try
            {
                int StoreUnitId = Convert.ToInt32(StoreID);
                var storeUnit = (from StoId in _context.Inv_Store_Unit_Type
                                 where StoId.Store_UnitType_Id == StoreUnitId
                               select StoId);
                return storeUnit.ToList();

            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
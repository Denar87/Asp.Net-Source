using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ERPSSL.INV.DAL;

namespace ERPSSL.INV.BLL
{
    public class UnitBLL
    {
        UnitDAL unitDal = new UnitDAL();
        
        internal int InsertUnit(Inv_Unit unitObj)
        {
            return unitDal.InsertUnit(unitObj);
        }

        internal List<Inv_Unit> GetAllUnit()
        {
            return unitDal.GetAllUnit();
        }

        internal List<Inv_Unit> GetUnitById(string unitId)
        {
            return unitDal.GetUnitById(unitId);
        }

        internal int UpdateUnit(Inv_Unit unitObj, int unitId)
        {
            return unitDal.UpdateUnit(unitId, unitObj);
        }
    }
}
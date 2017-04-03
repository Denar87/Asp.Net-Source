using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ERPSSL.INV.DAL;

namespace ERPSSL.INV.BLL
{
    public class StoreUnitBLL
    {
        StoreUnitDAL aStoreUnitDAL = new StoreUnitDAL();

        internal object GetAllStoreUnitType()
        {
            return aStoreUnitDAL.GetAllStoreUnitType();
        }

        internal int InsertProject(Inv_Store_Unit InvStoreUnit)
        {
            return aStoreUnitDAL.InsertProject(InvStoreUnit);
        }

        internal List<Inv_Store_Unit> GetAllStoreUnit()
        {
            return aStoreUnitDAL.GetAllStoreUnit();
        }

        internal int UpdateProject(Inv_Store_Unit InvStoreUnit, int projectId)
        {
            return aStoreUnitDAL.UpdateProject(InvStoreUnit, projectId);
        }


        internal List<Inv_Store_Unit> GetProjectId(string ProjectId)
        {
            return aStoreUnitDAL.GetProjectId(ProjectId);
        }
    }
}
using ERPSSL.Merchandising.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPSSL.Merchandising.BLL
{
    public class FabricNatureBLL
    {

        FabricNatureDAL aFabricNatureDAL = new FabricNatureDAL();

        internal int SaveData(LC_FabricNature aLC_FabricNature)
        {
            return aFabricNatureDAL.SaveData(aLC_FabricNature);
        }

        internal List<LC_FabricNature> LoadDataForGrid(string ocode)
        {
            return aFabricNatureDAL.LoadDataForGrid(ocode);
        }

        internal LC_FabricNature GetSingleData(int entryId)
        {
            return aFabricNatureDAL.GetSingleData(entryId);
        }

        internal int UpdateData(LC_FabricNature aLC_FabricNature, int idForUpdate)
        {
            return aFabricNatureDAL.UpdateData(aLC_FabricNature, idForUpdate);
        }
    }
}
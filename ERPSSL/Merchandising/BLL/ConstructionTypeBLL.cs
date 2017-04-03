using ERPSSL.Merchandising.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPSSL.Merchandising.BLL
{
    public class ConstructionTypeBLL
    {

        ConstructionTypeDAL aConstructionTypeDAL = new ConstructionTypeDAL();

        internal int SaveData(LC_ConstructionType aLC_ConstructionType)
        {
            return aConstructionTypeDAL.SaveData(aLC_ConstructionType);
        }

        internal List<LC_ConstructionType> LoadDataForGrid(string ocode)
        {
            return aConstructionTypeDAL.LoadDataForGrid(ocode);
        }

        internal LC_ConstructionType GetSingleData(int entryId)
        {
            return aConstructionTypeDAL.GetSingleData(entryId);
        }

        internal int UpdateData(LC_ConstructionType aLC_ConstructionType, int idForUpdate)
        {
            return aConstructionTypeDAL.UpdateData(aLC_ConstructionType,idForUpdate);
        }
    }
}
using ERPSSL.Merchandising.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPSSL.Merchandising.BLL
{
    public class CompositionBLL
    {
        CompositionDAL aCompositionDAL = new CompositionDAL(); 

        internal int SaveData(LC_Composition aLC_Composition)
        {
            return aCompositionDAL.SaveData(aLC_Composition);
        }

        internal int UpdateData(LC_Composition aLC_Composition, int idForUpdate)
        {
            return aCompositionDAL.UpdateData(aLC_Composition, idForUpdate);
        }

        internal List<LC_Composition> LoadDataForGrid(string ocode)
        {
            return aCompositionDAL.LoadDataForGrid(ocode);
        }

        internal LC_Composition GetSingleData(int entryId)
        {
            return aCompositionDAL.GetSingleData(entryId);
        }
    }
}
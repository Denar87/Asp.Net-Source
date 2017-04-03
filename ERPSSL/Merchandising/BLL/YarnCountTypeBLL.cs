using ERPSSL.Merchandising.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPSSL.Merchandising.BLL
{
    public class YarnCountTypeBLL
    {
        YarnCountTypeDAL aYarnCountTypeDAL = new YarnCountTypeDAL(); 

        internal int SaveData(LC_YarnCountType aLC_YarnCountType)
        {
            return aYarnCountTypeDAL.SaveData(aLC_YarnCountType);
        }

        internal int UpdateData(LC_YarnCountType aLC_YarnCountType, int idForUpdate)
        {
            return aYarnCountTypeDAL.UpdateData(aLC_YarnCountType, idForUpdate);
        }

        internal List<LC_YarnCountType> LoadDataForGrid(string ocode)
        {
            return aYarnCountTypeDAL.LoadDataForGrid(ocode);
        }

        internal LC_YarnCountType GetSingleData(int entryId)
        {
            return aYarnCountTypeDAL.GetSingleData(entryId);
        }
    }
}
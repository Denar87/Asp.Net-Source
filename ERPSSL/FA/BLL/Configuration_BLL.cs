using ERPSSL.FA.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPSSL.FA.BLL
{
    public class Configuration_BLL
    {
        Configuration_DAL objConfig = new Configuration_DAL();
        internal List<Ac_AssetSummary> GetAc_AssetSummary(string OCode, string SaleType)
        {
            return objConfig.GetAc_AssetSummary(OCode, SaleType);
        }
        internal int Sync_AssetSummary(string OCODE, string EditUser, string AssetCode, Double ItemTotal)
        {
            return objConfig.Sync_AssetSummary(OCODE, EditUser, AssetCode, ItemTotal);
        }
    }
}
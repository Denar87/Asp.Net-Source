using ERPSSL.POS.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPSSL.POS.BLL
{
    public class Configuration_BLL
    {
        Configuration_DAL objConfig = new Configuration_DAL();
        internal List<Ac_Configuration> GetAc_Configuration(string OCode, string ModuleType, string VoucherType)
        {
            return objConfig.GetAc_Configuration(OCode, ModuleType, VoucherType);
        }

        internal List<Ac_Sales_Summary> GetAc_SalesSummary(string OCode, string SaleType)
        {
            return objConfig.GetAc_SalesSummary(OCode, SaleType);
        }

        internal int Sync_SalesSummary(string OCode, string SaleType, string VoucherDate, string EditUser, Double ItemTotal)
        {
            return objConfig.Sync_SalesSummary(OCode, SaleType, VoucherDate, EditUser, ItemTotal);
        }

        internal List<Ac_Configuration_Ledger> GetAc_Configuration_Ledger(string OCode, string Company_Code)
        {
            return objConfig.GetAc_Configuration_Ledger(OCode, Company_Code);
        }

        internal int GetAc_UpdateConfiguration(int Id, string OCode, string Company_Code, string LedgerCode, string LedgerName, string ModuleId, string ModuleName, string TransactionNature)
        {
            return objConfig.GetAc_UpdateConfiguration(Id, OCode, Company_Code, LedgerCode, LedgerName, ModuleId, ModuleName, TransactionNature);
        }
    }
}
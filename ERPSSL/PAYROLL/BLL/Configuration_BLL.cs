using ERPSSL.PAYROLL.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPSSL.PAYROLL.BLL
{
    public class Configuration_BLL
    {
        Configuration_DAL objConfig = new Configuration_DAL();
        internal List<Ac_Configuration> GetAc_Configuration(string OCode, string ModuleType, string VoucherType)
        {
            return objConfig.GetAc_Configuration(OCode, ModuleType, VoucherType);
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
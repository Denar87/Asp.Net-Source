using ERPSSL.Adminpanel.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPSSL.ERP_Accounting.BLL
{
    public class AccConfiguration_BLL
    {
        Configuration_DAL objConfig = new Configuration_DAL();
        ERPSSL.ERP_Accounting.DAL.AccConfiguration_DAL aACDal = new DAL.AccConfiguration_DAL();

        internal int SaveERPConfig(tblConf_Module atblConf_Module)
        {
            return objConfig.SaveERPConfig(atblConf_Module);
        }

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
        internal List<Ac_Configuration_Item> GetAc_Configuration_Item(string OCode, string ModuleType, string VoucherType)
        {
            return objConfig.GetAc_Configuration_Item(OCode, ModuleType, VoucherType);
        }

        internal int GetAc_UpdateConfiguration(int Id, string OCode, string Company_Code, string ItemCode, string ItemName, string LedgerCode, string LedgerName, string ModuleId, string ModuleName, string TransactionNature, string ModuleType)
        {
            return objConfig.GetAc_UpdateConfiguration(Id, OCode, Company_Code, ItemCode, ItemName, LedgerCode, LedgerName, ModuleId, ModuleName, TransactionNature, ModuleType);
        }

        internal List<tblAC_leg_Ledgers> GetAc_Configuration_Ledger(string OCode, string Company_Code, string nature)
        {
            return objConfig.GetAc_Configuration_Ledger(OCode, Company_Code, nature);
        }

        internal List<tblAC_leg_Ledgers> GetAc_Ledger(string OCode, string Company_Code)
        {
            return objConfig.GetAc_Ledger(OCode, Company_Code);
        }

        internal List<tblConf_Module> GetAc_Configuration(string OCode)
        {
            return objConfig.GetAc_Configuration(OCode);
        }
        internal List<tblConf_Module> GetAc_Configuration(string OCode,int id)
        {
            return objConfig.GetAc_Configuration(OCode,id);
        }
        public int UpdateAcConfig(tblConf_Module atblConf_Module, int id)
        {
            return objConfig.UpdateAcConfig(atblConf_Module, id);
        }
        internal List<tblAC_cmp_Companys> Get_Company(string OCode)
        {
            return objConfig.Get_Company(OCode);
        }

        internal List<tbl_User> GetUser(string EmpId)
        {
            return aACDal.Get_User(EmpId);
        }
    }
}
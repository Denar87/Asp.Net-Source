using ERPSSL.HRM.DAL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ERPSSL.INV.DAL
{
    public class Configuration_DAL
    {
        internal List<Ac_Configuration> GetAc_Configuration(string OCode, string ModuleType, string VoucherType)
        {
            try
            {
                using (var _context = new ERPSSLHBEntities())
                {
                    var OCode_ = new SqlParameter("@OCode", OCode);
                    var ModuleType_ = new SqlParameter("@ModuleType", ModuleType);
                    var VoucherType_ = new SqlParameter("@VoucherType", VoucherType);

                    string SP_SQL = "Conf_Get_Module_Ledger @OCode,@ModuleType,@VoucherType";
                    return (_context.ExecuteStoreQuery<Ac_Configuration>(SP_SQL, OCode_, ModuleType_, VoucherType_)).ToList();
                }

            }
            catch (Exception)
            {
                throw;
            }
        }

        internal List<Ac_Configuration_Ledger> GetAc_Configuration_Ledger(string OCode, string Company_Code)
        {
            try
            {
                using (var _context = new ERPSSLHBEntities())
                {
                    var OCode_ = new SqlParameter("@OCode", OCode);
                    var Company_Code_ = new SqlParameter("@Company_Code", Company_Code);

                    string SP_SQL = "Leg_Get_AC_LedgerByVoucher @Company_Code,@OCode";
                    return (_context.ExecuteStoreQuery<Ac_Configuration_Ledger>(SP_SQL, Company_Code_, OCode_)).ToList();
                }

            }
            catch (Exception)
            {
                throw;
            }
        }

        internal int GetAc_UpdateConfiguration(int Id, string OCode, string Company_Code, string LedgerCode, string LedgerName, string ModuleId, string ModuleName, string TransactionNature)
        {
            try
            {
                using (var _context = new ERPSSLHBEntities())
                {
                    var Id_ = new SqlParameter("@Id", Id);
                    var OCode_ = new SqlParameter("@OCode", OCode);
                    var Company_Code_ = new SqlParameter("@Company_Code", Company_Code);
                    var LedgerCode_ = new SqlParameter("@LedgerCode", LedgerCode);
                    var LedgerName_ = new SqlParameter("@LedgerName", LedgerName);
                    var ModuleId_ = new SqlParameter("@ModuleId", ModuleId);
                    var ModuleName_ = new SqlParameter("@ModuleName", ModuleName);
                    var TransactionNature_ = new SqlParameter("@TransactionNature", TransactionNature);

                    string SP_SQL = "Conf_Get_UpdateConfiguration @Id,@OCode,@Company_Code,@LedgerCode,@LedgerName,@ModuleId,@ModuleName,@TransactionNature";
                    return (_context.ExecuteStoreCommand(SP_SQL, Id_, OCode_, Company_Code_, LedgerCode_, LedgerName_, ModuleId_, ModuleName_, TransactionNature_));
                }

            }
            catch (Exception)
            {
                throw;
            }
        }
    }

    public class Ac_Configuration_Ledger
    {
        public string Ledger_Code { get; set; }
        public string Ledger_Name { get; set; }
    }

    public class Ac_Configuration
    {
        public Int64 Id { get; set; }
        public string ModuleName { get; set; }
        public string ModuleId { get; set; }
        public string Particulars { get; set; }
        public string TransactionNature { get; set; }
        public string Voucher_Type { get; set; }

    }
}
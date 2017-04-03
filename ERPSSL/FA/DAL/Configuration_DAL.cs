using ERPSSL.HRM.DAL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ERPSSL.FA.DAL
{
    public class Configuration_DAL
    {
        internal List<Ac_AssetSummary> GetAc_AssetSummary(string OCode, string SaleType)
        {
            try
            {
                using (var _context = new ERPSSLHBEntities())
                {
                    var OCode_ = new SqlParameter("@OCode", OCode);
                    var SaleType_ = new SqlParameter("@SaleType", SaleType);

                    string SP_SQL = "EPO_Get_Asset_Summary @OCode,@SaleType";
                    return (_context.ExecuteStoreQuery<Ac_AssetSummary>(SP_SQL, OCode_, SaleType_)).ToList();
                }

            }
            catch (Exception)
            {
                throw;
            }
        }

        internal int Sync_AssetSummary(string OCODE, string EditUser, string AssetCode, Double ItemTotal)
        {
            try
            {
                using (var _context = new ERPSSLHBEntities())
                {
                    var OCode_ = new SqlParameter("@OCode", OCODE);
                    var EditUser_ = new SqlParameter("@EditUser", EditUser);
                    var AssetCode_ = new SqlParameter("@AssetCode", AssetCode);
                    var ItemTotal_ = new SqlParameter("@ItemTotal", ItemTotal);

                    string SP_SQL = "EPO_Sync_Asset_Summary @OCode,@EditUser,@AssetCode,@ItemTotal";
                    return (_context.ExecuteStoreQuery<int>(SP_SQL, OCode_, EditUser_, AssetCode_, ItemTotal_).FirstOrDefault());
                }

            }
            catch (Exception)
            {
                throw;
            }
        }
    }
    public class Ac_AssetSummary
    {
        public string AssetCode { get; set; }
        public Decimal XACAcquisition { get; set; }
        //public Int32 POST_STATUS { get; set; }
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
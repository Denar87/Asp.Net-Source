using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using ERPSSL.Adminpanel.DAL;

namespace ERPSSL.ERP_Accounting.DAL
{
    public class AccConfiguration_DAL
    {
        ERPSSL_AdminEntities1 _context = new ERPSSL_AdminEntities1();

        internal int SaveERPConfig(tblConf_Module atblConf_Module)
        {
            try
            {
                _context.tblConf_Module.AddObject(atblConf_Module);
                _context.SaveChanges();
                return 1;

            }
            catch (Exception)
            {

                throw;
            }
        }

        //for module main comfiguration
        internal List<Ac_Configuration> GetAc_Configuration(string OCode, string ModuleType, string VoucherType)
        {
            try
            {
                using (var _context = new ERPSSL_AdminEntities1())
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

        //for sales User Summary display
        internal List<Ac_Sales_Summary> GetAc_SalesSummary(string OCode, string SaleType)
        {
            try
            {
                using (var _context = new ERPSSL_AdminEntities1())
                {
                    var OCode_ = new SqlParameter("@OCode", OCode);
                    var SaleType_ = new SqlParameter("@SaleType", SaleType);

                    string SP_SQL = "EPO_Get_UserSales_Summary @OCode,@SaleType";
                    return (_context.ExecuteStoreQuery<Ac_Sales_Summary>(SP_SQL, OCode_, SaleType_)).ToList();
                }

            }
            catch (Exception)
            {
                throw;
            }
        }

        //for sales User Summary post
        internal int Sync_SalesSummary(string OCode, string SaleType, string VoucherDate, string EditUser, Double ItemTotal)
        {
            try
            {
                using (var _context = new ERPSSL_AdminEntities1())
                {
                    var OCode_ = new SqlParameter("@OCode", OCode);
                    var SaleType_ = new SqlParameter("@SaleType", SaleType);
                    var VoucherDate_ = new SqlParameter("@VoucherDate", VoucherDate);
                    var EditUser_ = new SqlParameter("@EditUser", EditUser);
                    var ItemTotal_ = new SqlParameter("@ItemTotal", ItemTotal);


                    string SP_SQL = "EPO_Sync_UserSales_Summary @OCode,@SaleType,@VoucherDate,@EditUser,@ItemTotal";
                    return (_context.ExecuteStoreCommand(SP_SQL, OCode_, SaleType_, VoucherDate_, EditUser_, ItemTotal_));
                }

            }
            catch (Exception)
            {
                throw;
            }
        }

        //for dropdown list - Lesger list
        internal List<Ac_Configuration_Ledger> GetAc_Configuration_Ledger(string OCode, string Company_Code)
        {
            try
            {
                using (var _context = new ERPSSL_AdminEntities1())
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

        internal List<tblAC_leg_Ledgers> GetAc_Configuration_Ledger(string OCode, string Company_Code, string nature)
        {
            try
            {
                var ledger = (from ledgers in _context.tblAC_leg_Ledgers
                              where ledgers.OCode == OCode && ledgers.Company_Code == Company_Code && ledgers.Ledger_Nature == nature
                              select ledgers);
                return ledger.ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        //for update mapping
        internal int GetAc_UpdateConfiguration(int Id, string OCode, string Company_Code, string ItemCode, string ItemName, string LedgerCode, string LedgerName, string ModuleId, string ModuleName, string TransactionNature, string ModuleType)
        {
            try
            {
                using (var _context = new ERPSSL_AdminEntities1())
                {
                    var Id_ = new SqlParameter("@Id", Id);
                    var OCode_ = new SqlParameter("@OCode", OCode);
                    var Company_Code_ = new SqlParameter("@Company_Code", Company_Code);

                    var ItemCode_ = new SqlParameter("@ItemCode", ItemCode);
                    var ItemName_ = new SqlParameter("@ItemName", ItemName);

                    var LedgerCode_ = new SqlParameter("@LedgerCode", LedgerCode);
                    var LedgerName_ = new SqlParameter("@LedgerName", LedgerName);
                    var ModuleId_ = new SqlParameter("@ModuleId", ModuleId);
                    var ModuleName_ = new SqlParameter("@ModuleName", ModuleName);
                    var TransactionNature_ = new SqlParameter("@TransactionNature", TransactionNature);
                    var ModuleType_ = new SqlParameter("@ModuleType", ModuleType);

                    string SP_SQL = "Conf_Get_UpdateConfiguration @Id,@OCode,@Company_Code,@ItemCode,@ItemName,@LedgerCode,@LedgerName,@ModuleId,@ModuleName,@TransactionNature,@ModuleType";
                    return (_context.ExecuteStoreCommand(SP_SQL, Id_, OCode_, Company_Code_, ItemCode_, ItemName_, LedgerCode_, LedgerName_, ModuleId_, ModuleName_, TransactionNature_, ModuleType_));
                }

            }
            catch (Exception)
            {
                throw;
            }
        }

        //for dropdownlist item List
        internal List<Ac_Configuration_Item> GetAc_Configuration_Item(string OCode, string ModuleType, string VoucherType)
        {
            try
            {
                using (var _context = new ERPSSL_AdminEntities1())
                {
                    var OCode_ = new SqlParameter("@OCode", OCode);
                    var ModuleType_ = new SqlParameter("@ModuleType", ModuleType);
                    var VoucherType_ = new SqlParameter("@VoucherType", VoucherType);

                    string SP_SQL = "Conf_Get_Module_Item @OCode,@ModuleType,@VoucherType";
                    return (_context.ExecuteStoreQuery<Ac_Configuration_Item>(SP_SQL, OCode_, ModuleType_, VoucherType_)).ToList();
                }

            }
            catch (Exception)
            {
                throw;
            }
        }

        internal List<tblConf_Module> GetAc_Configuration(string OCode)
        {
            try
            {
                var ledger = (from ledgers in _context.tblConf_Module
                              where ledgers.OCode == OCode
                              select ledgers);
                return ledger.ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        internal List<tblConf_Module> GetAc_Configuration(string OCode,int id)
        {
            try
            {
                var ledger = (from ledgers in _context.tblConf_Module
                              where ledgers.OCode == OCode && ledgers.Id==id
                              select ledgers);
                return ledger.ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public int UpdateAcConfig(tblConf_Module atblConf_Module, int id)
        {
            try
            {
                tblConf_Module obj = _context.tblConf_Module.First(x => x.Id == id);
                obj.ModuleId = atblConf_Module.ModuleId;
                obj.ModuleName = atblConf_Module.ModuleName;
                obj.Item = atblConf_Module.Item;
                obj.Ledger_Code = atblConf_Module.Ledger_Code;
                obj.Particulars = atblConf_Module.Particulars;
                obj.TransactionNature = atblConf_Module.TransactionNature;
                obj.IsChangable = atblConf_Module.IsChangable;
                obj.OCode = atblConf_Module.OCode;
                obj.Edit_User = atblConf_Module.Edit_User;
                obj.Edit_Date = atblConf_Module.Edit_Date;

                _context.SaveChanges();
                return 1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal List<tbl_User> Get_User(string EmpId)
        {

            try
            {
                var ledger = (from user in _context.tbl_User
                              where user.EID == EmpId
                              select user);
                return ledger.ToList();
            }
            catch (Exception)
            {

                throw;
            }

        }



    }


    public class Ac_Configuration
    {
        public Int64 Id { get; set; }
        public string ModuleName { get; set; }
        public string ModuleId { get; set; }
        public string ItemCode { get; set; }
        public string ItemName { get; set; }
        public string Particulars { get; set; }
        public string TransactionNature { get; set; }
        public string Voucher_Type { get; set; }

    }

    public class Ac_Sales_Summary
    {
        public string LoginName { get; set; }
        public string EditUser { get; set; }
        public DateTime SalesDate { get; set; }
        public Decimal ItemTotal { get; set; }

    }

    public class Ac_Configuration_Ledger
    {
        public string Ledger_Code { get; set; }
        public string Ledger_Name { get; set; }
    }

    public class Ac_Configuration_Item
    {
        public string Item_Code { get; set; }
        public string Item_Name { get; set; }
    }
}
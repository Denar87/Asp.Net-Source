using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using ERPSSL.Adminpanel.DAL;
using ERPSSL.ERP_Accounting.Repository;

namespace ERPSSL.ERP_Accounting.DAL
{
    public class Voucher_DAL
    {
        ERPSSL_AdminEntities1 _context = new ERPSSL_AdminEntities1();

        public virtual List<Voucher_Viewer> GetAllVoucher(string Status, string comCode, string OCODE)
        {
            using (_context)
            {
                var ParamempID = new SqlParameter("@ApprovalStatus", Status);
                var ParamempID1 = new SqlParameter("@Company_Code", comCode);
                var ParamempID2 = new SqlParameter("@OCode", OCODE);
                string SP_SQL = "Vch_Get_AllAC_VoucherList @ApprovalStatus,@Company_Code,@OCode";

                var result = _context.ExecuteStoreQuery<Voucher_Viewer>(SP_SQL, ParamempID, ParamempID1, ParamempID2);
                return result.ToList();
            }
        }

        public virtual List<Voucher_Viewer> GetAllVoucherDetail(string Status, string voucherNo, string comCode, string OCODE)
        {
            using (_context)
            {
                var ParamempID = new SqlParameter("@VoucherApproval", Status);
                var ParamempID1 = new SqlParameter("@Voucher_No", voucherNo);
                var ParamempID2 = new SqlParameter("@Company_Code", comCode);
                var ParamempID3 = new SqlParameter("@OCode", OCODE);
                string SP_SQL = "Vch_Get_AllAC_VoucherDetails @VoucherApproval, @Voucher_No, @Company_Code, @OCode";

                var result = _context.ExecuteStoreQuery<Voucher_Viewer>(SP_SQL, ParamempID, ParamempID1, ParamempID2, ParamempID3);
                return result.ToList();
            }
        }

        public virtual List<Voucher_Viewer> GetAllVoucherDetailInfo(string idNo, string OCODE, string moduleName, string moduleType)
        {
            using (_context)
            {
                var ParamempID = new SqlParameter("@IdentificationNo", idNo);
                var ParamempID1 = new SqlParameter("@OCode", OCODE);
                var ParamempID2 = new SqlParameter("@ModuleName", moduleName);
                var ParamempID3 = new SqlParameter("@ModuleType", moduleType);
                string SP_SQL = "Ac_GetModuleInfoByIdNo @IdentificationNo, @OCode, @ModuleName, @ModuleType";

                var result = _context.ExecuteStoreQuery<Voucher_Viewer>(SP_SQL, ParamempID, ParamempID1, ParamempID2, ParamempID3);
                return result.ToList();
            }
        }

        public int UpdateACLedger(tblAC_leg_LedgersTransaction_temp atblAC_leg_LedgersTransaction_temp, string trid)
        {
            try
            {
                tblAC_leg_LedgersTransaction_temp objtblAC_leg_LedgersTransaction_temp = _context.tblAC_leg_LedgersTransaction_temp.First(x => x.Transaction_Code == trid);

                objtblAC_leg_LedgersTransaction_temp.Ledger_Code = atblAC_leg_LedgersTransaction_temp.Ledger_Code;
                objtblAC_leg_LedgersTransaction_temp.Particulars = atblAC_leg_LedgersTransaction_temp.Particulars;
                objtblAC_leg_LedgersTransaction_temp.Nature = atblAC_leg_LedgersTransaction_temp.Nature;
                objtblAC_leg_LedgersTransaction_temp.Edit_Date = atblAC_leg_LedgersTransaction_temp.Edit_Date;
                objtblAC_leg_LedgersTransaction_temp.Edit_User = atblAC_leg_LedgersTransaction_temp.Edit_User;
                _context.SaveChanges();
                return 1;
            }
            catch (Exception)
            {
                throw;
            }
        }


    }
}
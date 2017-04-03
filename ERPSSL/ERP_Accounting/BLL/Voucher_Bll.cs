using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using ERPSSL.ERP_Accounting.DAL;
using ERPSSL.Adminpanel.DAL;
using ERPSSL.ERP_Accounting.Repository;

namespace ERPSSL.ERP_Accounting
{
    public class Voucher_Bll
    {
        Voucher_DAL objDal = new Voucher_DAL();

        public virtual List<Voucher_Viewer> GetAllVoucher(string Status, string comCode, string OCODE)
        {
            return objDal.GetAllVoucher(Status, comCode, OCODE);
        }

        public virtual List<Voucher_Viewer> GetAllVoucherDetail(string Status, string voucherNo, string comCode, string OCODE)
        {
            return objDal.GetAllVoucherDetail(Status, voucherNo, comCode, OCODE);
        }

        public virtual List<Voucher_Viewer> GetAllVoucherDetailInfo(string idNo, string OCODE, string moduleName, string moduleType)
        {
            return objDal.GetAllVoucherDetailInfo(idNo, OCODE, moduleName, moduleType);
        }

        public int UpdateACLedger(tblAC_leg_LedgersTransaction_temp atblAC_leg_LedgersTransaction_temp, string trid)
        {
            return objDal.UpdateACLedger(atblAC_leg_LedgersTransaction_temp, trid);
        }


    }
}
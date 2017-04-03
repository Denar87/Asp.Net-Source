using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ERPSSL.HRM.DAL;

namespace ERPSSL.HRM.BLL
{
    public class BankBLL
    {
        BankDAL bankDal = new BankDAL();
        internal int BankInfoSave(HRM_BankInfo bankObj)
        {
            return bankDal.BankInfoSave(bankObj);
        }
    }
}
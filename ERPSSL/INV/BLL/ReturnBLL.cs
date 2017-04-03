using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ERPSSL.INV.DAL;
using ERPSSL.INV.DAL.Repository;

namespace ERPSSL.INV.BLL
{
    public class ReturnBLL
    {
        ReturnDAL aReturnDAL = new ReturnDAL();

        internal IEnumerable<RReturn> GetReturnFromSupplier_ByDate(string OCODE, DateTime Fromdate, DateTime Todate)
        {
            return aReturnDAL.GetReturnFromSupplier_ByDate(OCODE, Fromdate, Todate);
        }
    }
}
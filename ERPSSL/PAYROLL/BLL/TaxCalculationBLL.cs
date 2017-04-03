using ERPSSL.PAYROLL.DAL;
using ERPSSL.PAYROLL.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPSSL.PAYROLL.BLL
{
    public class TaxCalculationBLL
    {
        TaxCalculationDAL aTaxCalculationDAL = new TaxCalculationDAL();
        internal List<TaxCalculate> GetTaxDetailByEID( string EID)
        {
            return aTaxCalculationDAL.GetTaxDetailByEID(EID);
        }
    }
}
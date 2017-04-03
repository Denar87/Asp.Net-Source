using ERPSSL.HRM.DAL;
using ERPSSL.PAYROLL.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ERPSSL.PAYROLL.DAL
{
    public class TaxCalculationDAL
    {
        internal List<TaxCalculate> GetTaxDetailByEID(string EID)
        {          
     
            try
            {
                using (var _context = new ERPSSLHBEntities())
                {

                    var Eid = new SqlParameter("@EID", EID);
                    string SP_SQL = "HRM_RPT_TexCalculation @EID";
                    return (_context.ExecuteStoreQuery<TaxCalculate>(SP_SQL, Eid)).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
       
        }
    }
}
using ERPSSL.LC.DAL;
using ERPSSL.Production.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ERPSSL.Production.DAL
{
    public class ReportDAL
    {
        internal List<ReportR> GetDailyProductionDetails(string OCode)
        {
            try
            {
                using (var _context = new ERPSSL_LCEntities())
                {
                    var _OCode = new SqlParameter("@OCODE", OCode);

                    string SP_SQL = "Prod_RPT_DailyProdutionDetails @OCODE";
                    return (_context.ExecuteStoreQuery<ReportR>(SP_SQL,  _OCode)).ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal List<ProductionR> GetTnaReport(string OCode)
        {
            try
            {
                using (var _context = new ERPSSL_LCEntities())
                {
                    var _OCode = new SqlParameter("@OCODE", OCode);

                    string SP_SQL = "Prod_RPT_TNAReport @OCODE";
                    return (_context.ExecuteStoreQuery<ProductionR>(SP_SQL, _OCode)).ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

       
    }
}
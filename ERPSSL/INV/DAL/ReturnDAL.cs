using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using ERPSSL.INV.DAL.Repository;

namespace ERPSSL.INV.DAL
{
    public class ReturnDAL
    {
        internal IEnumerable<RReturn> GetReturnFromSupplier_ByDate(string OCODE, DateTime Fromdate, DateTime Todate)
        {
            try
            {
                using (var _context = new ERPSSL_INVEntities())
                {

                    var ParamempID1 = new SqlParameter("@OCODE", OCODE);
                    var ParamempID2 = new SqlParameter("@FROMDATE", Fromdate);
                    var ParamempID3 = new SqlParameter("@TODATE", Todate);
                    string SP_SQL = "Inv_Rpt_ReturnFromSupplier_ByDate @OCODE,@FROMDATE,@TODATE";
                    return (_context.ExecuteStoreQuery<RReturn>(SP_SQL, ParamempID1, ParamempID2, ParamempID3)).ToList();
                }

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
using ERPSSL.Marketing.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ERPSSL.Marketing.DAL
{
    public class WorkOrderDetailsReportDAL
    {
        internal List<MarketingWorkOrder> GetAllInformationOfWorkOrder(string OCODE, DateTime FromDate, DateTime ToDate)
        {
            try
            {
                using (var _context = new ERPSSL_Marketing_Entities())
                {
                    var _OCode = new SqlParameter("@OCODE", OCODE);
                    var _FromDate = new SqlParameter("@FromDate", FromDate);
                    var _ToDate = new SqlParameter("@ToDate", ToDate);

                    string SP_SQL = "MRK_RPT_WorkOrderDetails @OCODE, @FromDate, @ToDate ";
                    return (_context.ExecuteStoreQuery<MarketingWorkOrder>(SP_SQL, _OCode, _FromDate, _ToDate)).ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
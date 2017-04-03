using ERPSSL.Marketing.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ERPSSL.Marketing.DAL
{
    public class ClientWiseCollectionDAL
    {
        internal List<string> Get_ClientWiseList(string OCODE)
        {
            

            try
            {
                using (var _context = new ERPSSL_Marketing_Entities())
                {
                    var ListItem = (from w in _context.MRK_WorkOrder
                                    join m in _context.MRK_MarketingInfo on w.MarketingInfoId equals m.MarketingInfoId
                                    where w.OCODE == OCODE
                                    select m.Client);
                    return ListItem.ToList();
                }


               

            }
            catch (Exception)
            {

                throw;
            }
        }

        internal List<MarketingWorkOrderTransaction> GetClientWiseTransaction(string OCODE, string clientName)
        {
            try
            {
                using (var _context = new ERPSSL_Marketing_Entities())
                {
                    var _OCode = new SqlParameter("@OCODE", OCODE);
                    var _ClientName = new SqlParameter("@ClientName", clientName);

                    string SP_SQL = "MRK_RPT_CollectionByClient @OCODE, @ClientName";
                    return (_context.ExecuteStoreQuery<MarketingWorkOrderTransaction>(SP_SQL, _OCode, _ClientName)).ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
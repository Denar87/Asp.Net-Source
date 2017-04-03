using ERPSSL.Marketing.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ERPSSL.Marketing.DAL
{
    public class TaskDetailsDAL
    {

        internal List<MarketingTaskDetails> GetAllInformationOfTask(string OCODE)
        {
            try
            {
                using (var _context = new ERPSSL_Marketing_Entities())
                {
                    var _OCode = new SqlParameter("@OCODE", OCODE);
                    
                    string SP_SQL = "MRK_RPT_AllTaskDetails @OCODE";
                
                    return (_context.ExecuteStoreQuery<MarketingTaskDetails>(SP_SQL, _OCode)).ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal List<MarketingTaskDetails> GetIndividualInformationOfTask(string OCODE, string clientName)
        {
            try
            {
                using (var _context = new ERPSSL_Marketing_Entities())
                {
                    var _OCode = new SqlParameter("@OCODE", OCODE);
                    var _Client = new SqlParameter("@Client", clientName);

                    string SP_SQL = "MRK_RPT_IndividualTaskDetails @OCODE, @Client";

                    return (_context.ExecuteStoreQuery<MarketingTaskDetails>(SP_SQL, _OCode, _Client)).ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
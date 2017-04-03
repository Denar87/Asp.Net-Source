using ERPSSL.Marketing.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ERPSSL.Marketing.DAL;
using System.Data.SqlClient;

namespace ERPSSL.Marketing.DAL
{
    public class ClientVisitReportDAL
    {
        internal List<MarketingProjectStage> GetAllInformationOfClientVisit(string OCODE, DateTime FromDate, DateTime ToDate)
        {
            try
            {
                using (var _context = new ERPSSL_Marketing_Entities())
                {
                    var _OCode = new SqlParameter("@OCODE", OCODE);
                    var _FromDate = new SqlParameter("@FromDate", FromDate);
                    var _ToDate = new SqlParameter("@ToDate", ToDate);

                    string SP_SQL = "MRK_RPT_ClientVisitByDate @OCODE, @FromDate, @ToDate ";
                    return (_context.ExecuteStoreQuery<MarketingProjectStage>(SP_SQL, _OCode, _FromDate, _ToDate)).ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        internal List<MarketingProjectStage> GetAllInformationOfClientVisitbyDateAndStage(string OCODE, DateTime FromDate, DateTime ToDate, int stageId)
        {
            try
            {
                using (var _context = new ERPSSL_Marketing_Entities())
                {
                    var _OCode = new SqlParameter("@OCODE", OCODE);
                    var _FromDate = new SqlParameter("@FromDate", FromDate);
                    var _ToDate = new SqlParameter("@ToDate", ToDate);
                    var _stageId = new SqlParameter("@StageId", stageId);

                    string SP_SQL = "MRK_RPT_ClientVisitByDateAndStage @OCODE, @FromDate, @ToDate, @StageId";
                    return (_context.ExecuteStoreQuery<MarketingProjectStage>(SP_SQL, _OCode, _FromDate, _ToDate, _stageId)).ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        internal List<MarketingProjectStage> GetAllInformationOfClientVisitbyDateAndMarketingPerson(string OCODE, DateTime FromDate, DateTime ToDate, string marketingPersonId)
        {
            try
            {
                using (var _context = new ERPSSL_Marketing_Entities())
                {
                    var _OCode = new SqlParameter("@OCODE", OCODE);
                    var _FromDate = new SqlParameter("@FromDate", FromDate);
                    var _ToDate = new SqlParameter("@ToDate", ToDate);
                    var _marketingPersonId = new SqlParameter("@MarketingPersonId", marketingPersonId);

                    string SP_SQL = "MRK_RPT_ClientVisitByDateAndMarketingPerson @OCODE, @FromDate, @ToDate, @MarketingPersonId";
                    return (_context.ExecuteStoreQuery<MarketingProjectStage>(SP_SQL, _OCode, _FromDate, _ToDate, _marketingPersonId)).ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
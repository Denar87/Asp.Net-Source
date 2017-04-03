using ERPSSL.Marketing.DAL;
using ERPSSL.Marketing.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPSSL.Marketing.BLL
{
    public class ClientVisitReportBLL
    {
        ClientVisitReportDAL aClientVisitReportDAL = new ClientVisitReportDAL();

        internal List<MarketingProjectStage> GetAllInformationOfClientVisit(string OCODE, DateTime FromDate, DateTime ToDate)
        {
            return aClientVisitReportDAL.GetAllInformationOfClientVisit(OCODE, FromDate, ToDate);
        } 



        internal List<MarketingProjectStage> GetAllInformationOfClientVisitbyDateAndStage(string OCODE, DateTime FromDate, DateTime ToDate, int stageId)
        {
            return aClientVisitReportDAL.GetAllInformationOfClientVisitbyDateAndStage(OCODE, FromDate, ToDate, stageId);
        }



        internal List<MarketingProjectStage> GetAllInformationOfClientVisitbyDateAndMarketingPerson(string OCODE, DateTime FromDate, DateTime ToDate, string marketingPersonId)
        {
            return aClientVisitReportDAL.GetAllInformationOfClientVisitbyDateAndMarketingPerson(OCODE, FromDate, ToDate, marketingPersonId);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ERPSSL.Marketing.DAL;
using ERPSSL.Marketing.DAL.Repository;
using ERPSSL.HRM.DAL;

namespace ERPSSL.Marketing.BLL
{
    public class MarketingInfoBLL
    {

        MarketingInfoDAL aMarketingInfoDAL = new MarketingInfoDAL();

        public int SaveMarketingInfo(MRK_MarketingInfo aMRK_MarketingInfo)
        {
            return aMarketingInfoDAL.SaveMarketingInfo(aMRK_MarketingInfo);
        }

        public List<MarketingProjectStage> GetAllMarketingInfoList(string OCODE)
        {
            return aMarketingInfoDAL.GetAllMarketingInfoList(OCODE);

        }

        public MRK_MarketingInfo GetMarketingInfoForEdit(string marketingInfoId, string OCODE)
        {
            return aMarketingInfoDAL.GetMarketingInfoForEdit(marketingInfoId, OCODE);

        }

        internal int UpdateMarketingInfo(MRK_MarketingInfo aMRK_MarketingInfo, int marketingInfoId)
        {
            return aMarketingInfoDAL.UpdateMarketingInfo(marketingInfoId, aMRK_MarketingInfo);
        }

     


        internal List<MarketingProjectStage> Get_AllPersonList(string OCODE)
        {
            return aMarketingInfoDAL.Get_AllPersonList(OCODE);
        }

        internal int Savereference(MRK_Reference aMRK_Reference)
        {
            return aMarketingInfoDAL.Savereference(aMRK_Reference);
        }

        internal List<MRK_Reference> Get_AllReferenceList(string OCODE)
        {
            return aMarketingInfoDAL.Get_AllReferenceList(OCODE);
        }

        internal List<MarketingProjectStage> GetUpcomingOrderList()
        {
            return aMarketingInfoDAL.GetUpcomingOrderList();
        }

        internal List<MarketingProjectStage> GetUpPrimaryClientList()
        {
            return aMarketingInfoDAL.GetUpPrimaryClientList();
        }

        internal List<MarketingProjectStage> GetMidLevelClientList()
        {
            return aMarketingInfoDAL.GetMidLevelClientList();
        }

        internal List<MarketingProjectStage> GetCurrentMonthVisitList()
        {
            return aMarketingInfoDAL.GetCurrentMonthVisitList();
        }

        
        internal List<MarketingProjectStage> GetLastMonthVisitList()
        {
            return aMarketingInfoDAL.GetLastMonthVisitList();
        }



        internal List<MarketingProjectStage> GetAllMarketingInfoListByClientName(string OCODE, string clientName)
        {
            return aMarketingInfoDAL.GetAllMarketingInfoListByClientName(OCODE, clientName);
        }

        internal int Saveproject(MRK_Project aMRK_Project)
        {
            return aMarketingInfoDAL.Saveproject(aMRK_Project);
        }
    }
}
using ERPSSL.Marketing.DAL;
using ERPSSL.Marketing.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPSSL.Marketing.BLL
{
    public class AMC_BLL
    {
        AMC_DAL aAMC_DAL = new AMC_DAL(); 

        internal List<MRK_MarketingInfo> GetAllMarketingInfoByClientName(string clientName, string OCode)
        {
            return aAMC_DAL.GetAllMarketingInfoByClientName(clientName, OCode);
        }

        internal List<MRK_MarketingInfo> GetALLMarketingInfoInGridView(string OCode)
        {
            return aAMC_DAL.GetALLMarketingInfoInGridView(OCode);
        }

        internal MarketingWorkOrder GetSingaleWorkOrderDeatils(int marketingId)
        {
            return aAMC_DAL.GetSingaleWorkOrderDeatils(marketingId);
        }

        internal int SaveAMCInfo(MRK_AMC aMRK_AMC)
        {
            return aAMC_DAL.SaveAMCInfo(aMRK_AMC);
        }

        //internal List<MarketingWorkOrderAMC> GetAllWorkOrderAMCDetails(string OCode)
        //{
        //    return aAMC_DAL.GetAllWorkOrderAMCDetails(OCode);
        //}

        internal List<MarketingWorkOrderAMC> GetAllWorkOrderAMCDetails(string OCode)
        {
            return aAMC_DAL.GetAllWorkOrderAMCDetails(OCode);
        }

        internal MarketingWorkOrderAMC GetSingaleAMCDeatils(int AMCId)
        {
            return aAMC_DAL.GetSingaleAMCDeatils(AMCId);
        }

        internal int UpdateAMCInfo(MRK_AMC aMRK_AMC, int AMCId)
        {
            return aAMC_DAL.UpdateAMCInfo(aMRK_AMC, AMCId);
        }
    }
}
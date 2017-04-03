//using ERPSSL.LC.DAL;
using ERPSSL.Marketing.DAL;
using ERPSSL.Marketing.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPSSL.Marketing.BLL
{
    public class WorkOrderDetailsBLL
    {
        WorkOrderDetailsDAL aWorkOrderDetailsDAL = new WorkOrderDetailsDAL();

        internal List<MRK_MarketingInfo> GetALLMArketingInfoByClientName(string clientName, string OCode)
        {
            return aWorkOrderDetailsDAL.GetALLMArketingInfoByClientName(clientName, OCode);
        }


        internal List<MRK_MarketingInfo> GetALLMarketingInfoInGridView(string OCode)
        {
            return aWorkOrderDetailsDAL.GetALLMarketingInfoInGridView(OCode);
        }

        
        public List<MarketingProjectStage> GetInvidualMarketingInfoList(int marketingInfoId)
        {
            return aWorkOrderDetailsDAL.GetInvidualMarketingInfoList(marketingInfoId);

        }

        internal int SaveWorkOrderInfo(MRK_WorkOrder aMRK_WorkOrder)
        {
            return aWorkOrderDetailsDAL.SaveWordOrderInfo(aMRK_WorkOrder);
        }

        internal List<MarketingWorkOrder> GetAllWorkOrderDetails(string OCode)
        {
            return aWorkOrderDetailsDAL.GettAllWorkOrderDetails(OCode);
        }

        internal MarketingWorkOrder GetSingaleWorkOrderDeatils(int workOrderId)
        {
            return aWorkOrderDetailsDAL.GetSingleWorkOrderDetails(workOrderId);
        }

        internal int UpdateWorkOrderInfo(MRK_WorkOrder aMRK_WorkOrder, int workOrderId)
        {
            return aWorkOrderDetailsDAL.UpdateWorkOrderInfo(aMRK_WorkOrder, workOrderId);
        }

        internal int SaveWorkOrderToTransaction(MRK_Transaction aMRK_Transaction)
        {
            return aWorkOrderDetailsDAL.SaveWorkOrderToTransaction(aMRK_Transaction);
        }

        internal List<LC_InputType> GetAllTask()
        {
            return aWorkOrderDetailsDAL.GettAllTask();
        }

        internal List<MarketingWorkOrder> GetWorkOrderStatus()
        {
            return aWorkOrderDetailsDAL.GetWorkOrderStatus();
        }

        internal List<MarketingWorkOrder> GetAllWorkOrderDetailsbyClientName(string OCode, string clientName)
        {
            return aWorkOrderDetailsDAL.GetAllWorkOrderDetailsbyClientName(OCode, clientName);
        }
    }
}
using ERPSSL.Marketing.DAL;
using ERPSSL.Marketing.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPSSL.Marketing.BLL
{
    public class VisitStatusUpdateBLL
    {
        VisitStatusUpdateDAL aVisitStatusUpdateDAL = new VisitStatusUpdateDAL();

        internal MarketingProjectStage GetInvidualMarketingInfoList(string OCode, string clientName)
        {
            return aVisitStatusUpdateDAL.GetInvidualMarketingInfoList(OCode, clientName);
        }

        internal int GetOrderId(int marketingInfoId)
        {
            return aVisitStatusUpdateDAL.GetOrderId(marketingInfoId);
        }

        internal List<MRK_Task_Details> GetTaskDetailsByWorkOrderNo(int OrderId, string OCODE)
        {
            return aVisitStatusUpdateDAL.GetTaskDetailsByWorkOrderNo(OrderId, OCODE);
        }


        internal int UpdateTaskDetails(MRK_Task_Details aMRK_Task_Details, int ID)
        {
            return aVisitStatusUpdateDAL.UpdateTaskDetails(aMRK_Task_Details, ID);
        }

        internal int GetWorkOrderId(int marketingInfoId)
        {
            return aVisitStatusUpdateDAL.GetWorkOrderId(marketingInfoId);
        }

        internal List<int> getTaskIdList(int workOrderId)
        {
            return aVisitStatusUpdateDAL.getTaskIdList(workOrderId);
        }

        internal List<LC_InputType> GetAllTask()
        {
            return aVisitStatusUpdateDAL.GettAllTask();
        }
    }
}
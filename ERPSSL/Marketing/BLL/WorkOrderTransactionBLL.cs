using ERPSSL.Marketing.DAL;
using ERPSSL.Marketing.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPSSL.Marketing.BLL
{
    public class WorkOrderTransactionBLL
    {
        WorkOrderTransactionDAL aWorkOrderTransactionDAL = new WorkOrderTransactionDAL();

        internal MarketingWorkOrderTransaction GetSingaleWorkOrderDeatilsByClientName(string clientName)
        {
            return aWorkOrderTransactionDAL.GetSingaleWorkOrderDeatilsByClientName(clientName);
        }

        internal List<MRK_Transaction> GetAllTransactionDetails(int workOrderId, string OCode)
        {
            return aWorkOrderTransactionDAL.GetAllTransactionDetails(workOrderId, OCode);
        }

        internal List<MarketingWorkOrderTransaction> GetCollectionInformationByDate(string OCODE, DateTime FromDate, DateTime ToDate)
        {
            return aWorkOrderTransactionDAL.GetCollectionInformationByDate(OCODE,FromDate,ToDate);
        }

        internal List<MarketingWorkOrderTransaction> GetAllCurrentMonthTransactionDetails(int nowMonth, int nowYear, string OCode)
        {
            return aWorkOrderTransactionDAL.GetAllCurrentMonthTransactionDetails(nowMonth, nowYear, OCode);
        }
    }
}
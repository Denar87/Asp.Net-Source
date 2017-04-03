using ERPSSL.Marketing.DAL;
using ERPSSL.Marketing.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPSSL.Marketing.BLL
{
    public class WorkOrderDetailsReportBLL
    {
        WorkOrderDetailsReportDAL aWorkOrderDetailsReportDAL = new WorkOrderDetailsReportDAL();

        internal List<MarketingWorkOrder> GetAllInformationOfWorkOrder(string OCODE, DateTime FromDate, DateTime ToDate)
        {
            return aWorkOrderDetailsReportDAL.GetAllInformationOfWorkOrder(OCODE, FromDate, ToDate);
        }
    }
}
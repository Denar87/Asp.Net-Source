using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ERPSSL.LC.DAL;
using ERPSSL.LC.DAL.Repository;

namespace ERPSSL.LC.BLL
{
    public class LC_ReportBLL
    {
        LC_ReportDAL _lcReportDAL = new LC_ReportDAL();
        internal List<Rep_MasterLC> GetRPTLCIssue()
        {
            return _lcReportDAL.GetRPTLCIssue();
        }

        internal List<Rep_Estimate> GetCostEstimateRequisitionList(string estCostNo, string OCode)
        {
            return _lcReportDAL.GetCostEstimateRequisitionList(estCostNo, OCode);
        }

        internal List<Rep_Estimate> GetCostEstimateRequisitionApproval(string RequNo, string OCode)
        {
            return _lcReportDAL.GetCostEstimateRequisitionApproval(RequNo, OCode);
        }
        internal List<Rep_Estimate> Get_RPT_Cost_Estimating(string EstimatingCostID, string OCode)
        {
            return _lcReportDAL.Get_RPT_Cost_Estimating(EstimatingCostID, OCode);
        }
    }
}
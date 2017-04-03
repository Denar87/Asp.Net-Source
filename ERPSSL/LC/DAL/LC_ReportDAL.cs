using ERPSSL.LC.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;


namespace ERPSSL.LC.DAL
{
    public class LC_ReportDAL
    {
        ERPSSL_LCEntities _Content = new ERPSSL_LCEntities();

        internal List<Rep_MasterLC> GetRPTLCIssue()
        {
            try
            {
                using (var _context = new ERPSSL_LCEntities())
                {
                    string SP_SQL = "HRM_RPT_EmployeeSalaryALLStatusByRODSID";
                    return (_context.ExecuteStoreQuery<Rep_MasterLC>(SP_SQL)).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        internal List<Rep_Estimate> GetCostEstimateRequisitionList(string estCostNo, string OCode)
        {
            try
            {
                using (var _context = new ERPSSL_LCEntities())
                {
                    var _estCostNo = new SqlParameter("@CostEstimateID", estCostNo);
                    var _OCode = new SqlParameter("@OCODE", OCode);

                    string SP_SQL = "LC_RPT_CostEstimateRequisitionApproval @CostEstimateID,@OCODE";
                    return (_context.ExecuteStoreQuery<Rep_Estimate>(SP_SQL, _estCostNo,_OCode)).ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal List<Rep_Estimate> GetCostEstimateRequisitionApproval(string RequNo, string OCode)
        {
            try
            {
                using (var _context = new ERPSSL_LCEntities())
                {
                    var _RequNo = new SqlParameter("@RequisitionNo", RequNo);
                    var _OCode = new SqlParameter("@OCODE", OCode);

                    string SP_SQL = "LC_RPT_CostEstimateRequisitionApprovalList @RequisitionNo,@OCODE";
                    return (_context.ExecuteStoreQuery<Rep_Estimate>(SP_SQL, _RequNo, _OCode)).ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal List<Rep_Estimate> Get_RPT_Cost_Estimating(string EstimatingCostID, string OCode)
        {
            try
            {
                using (var _context = new ERPSSL_LCEntities())
                {
                    var ParamempID = new SqlParameter("@CostEstimateID", EstimatingCostID);
                    var ocode = new SqlParameter("@OCODE", OCode);
                    string SP_SQL = "LC_RPT_Cost_Estimating @CostEstimateID,@OCODE";
                    return (_context.ExecuteStoreQuery<Rep_Estimate>(SP_SQL, ParamempID, ocode)).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
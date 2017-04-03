using ERPSSL.HRM.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ERPSSL.HRM.DAL
{
    public class JobAlloctionDAL
    {
        ERPSSLHBEntities _context = new ERPSSLHBEntities();
        internal int GetLastRowNumber(string OCODE)
        {
            var count = (from o in _context.HRM_JobAllocation
                         select o).Count();
            return count;

        }

        internal int SaveJobAllocation(List<HRM_JobAllocation> jobAllocationes)
        {
            try
            {
                foreach (HRM_JobAllocation aitem in jobAllocationes)
                {
                    _context.HRM_JobAllocation.AddObject(aitem);

                }
                _context.SaveChanges();
                return 1;

            }
            catch (Exception)
            {

                throw;
            }
        }

        internal List<RJobAllocation> GetJobAllocationAssignList(string Ocode, string jobAllocationCode)
        {
            try
            {
                using (var _context = new ERPSSLHBEntities())
                {
                    var ParamempID = new SqlParameter("@ocode", Ocode);
                    var jobAlCode = new SqlParameter("@jobAllocationCode", jobAllocationCode);
                    string SP_SQL = "HRM_JobAllocationAssignList @ocode,@jobAllocationCode";
                    return (_context.ExecuteStoreQuery<RJobAllocation>(SP_SQL, ParamempID, jobAlCode)).ToList();
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        internal List<RJobAllocationAssign> GetJobAllocationList(string OCODE)
        {
            try
            {
                using (var _context = new ERPSSLHBEntities())
                {
                    var ParamempID = new SqlParameter("@ocode", OCODE);
                    string SP_SQL = "HRM_JobAllocationAllAssignList @ocode";
                    return (_context.ExecuteStoreQuery<RJobAllocationAssign>(SP_SQL, ParamempID)).ToList();
                }

            }
            catch (Exception)
            {

                throw;
            }

        }

        internal List<RJobAllocationAssign> GEtJobAllocationInfoByJobAllocationCode(string jobAllocationCode, string OCODE)
        {
            try
            {
                using (var _context = new ERPSSLHBEntities())
                {
                    var ParamempID = new SqlParameter("@ocode", OCODE);
                    var AllocationCode = new SqlParameter("@AllocationCodee", jobAllocationCode);
                    string SP_SQL = "HRM_JobAllocationInfoByJobAllocationCode @ocode,@AllocationCodee";
                    return (_context.ExecuteStoreQuery<RJobAllocationAssign>(SP_SQL, ParamempID, AllocationCode)).ToList();
                }

            }
            catch (Exception)
            {

                throw;
            }

        }

        internal int SaveJobAllocationStatus(HRM_JobAllocation joba, string jobAllocationCode)
        {
            HRM_JobAllocation jobAllocatonCode = _context.HRM_JobAllocation.First(x => x.JobAllocationCode == jobAllocationCode);
            jobAllocatonCode.PendingStatus = joba.PendingStatus;
            jobAllocatonCode.SuccessStatus = joba.SuccessStatus;
            jobAllocatonCode.CancelStatus = joba.CancelStatus;
            jobAllocatonCode.UpdateRemark = joba.UpdateRemark;
            _context.SaveChanges();
            return 1;

        }

        internal int DeleteJobAllocationByCode(string jobAllocationCode, string Ocode)
        {
            try
            {
                using (var _context = new ERPSSLHBEntities())
                {
                    var ParamempID = new SqlParameter("@ocode", Ocode);
                    var AllocationCode = new SqlParameter("@AllocationCodee", jobAllocationCode);
                    string SP_SQL = "HRM_DeleteJobAllocationById @ocode,@AllocationCodee";
                    _context.ExecuteStoreCommand(SP_SQL, ParamempID, AllocationCode);
                    return 1;


                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        internal List<RJobAllocationAssign> GetJobAllocationDateWise(string OCODE, string fromDate, string toDate)
        {

            try
            {
                using (var _context = new ERPSSLHBEntities())
                {
                    var ParamempID = new SqlParameter("@ocode", OCODE);
                    var statDate = new SqlParameter("@statDate", fromDate);
                    var EndDate = new SqlParameter("@EndDate", toDate);

                    string SP_SQL = "HRM_JobAllocationDateWise @ocode,@statDate,@EndDate";
                    return (_context.ExecuteStoreQuery<RJobAllocationAssign>(SP_SQL, ParamempID, statDate, EndDate)).ToList();

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
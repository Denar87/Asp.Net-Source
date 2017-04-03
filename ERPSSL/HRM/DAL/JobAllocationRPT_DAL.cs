using ERPSSL.HRM.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ERPSSL.HRM.DAL
{
    public class JobAllocationRPT_DAL
    {
        internal IEnumerable<JobAllocationRPTGlobal> GetAllClientForReport(string OCODE, string fromDate, string toDate)
        {
            try
            {
                using (var _context = new ERPSSLHBEntities())
                {
                    var ParamempID = new SqlParameter("@OCODE", OCODE);
                    var startDate = new SqlParameter("@startDate", fromDate);
                    var EndDate = new SqlParameter("@EndDate", toDate);
                    string SP_SQL = "[HRM_JobAllocationAllCompanySP] @OCODE,@startDate,@EndDate";
                    return (_context.ExecuteStoreQuery<JobAllocationRPTGlobal>(SP_SQL, ParamempID, startDate, EndDate)).ToList();
                }

            }
            catch (Exception)
            {

                throw;
            }

        }


        //internal List<JobAllocationRPTGlobal> GetJobAllocationDateWise(string OCODE, string fromDate, string toDate)
        //{

        //    try
        //    {
        //        using (var _context = new ERPSSLHBEntities())
        //        {
        //            var ParamempID = new SqlParameter("@ocode", OCODE);
        //            var statDate = new SqlParameter("@statDate", fromDate);
        //            var EndDate = new SqlParameter("@EndDate", toDate);

        //            string SP_SQL = "[HRM_JobAllocationAllCompanySPbyDate] @OCODE,@statDate,@EndDate";
        //            return (_context.ExecuteStoreQuery<JobAllocationRPTGlobal>(SP_SQL, ParamempID, statDate, EndDate)).ToList();
        //        }

        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }

        //}

        internal IEnumerable<JobAllocationRPTGlobal> JobAllocationSingleClientRPT(string OCODE, string clientID, string fromDate, string toDate)
        {
            int cID =Convert.ToInt32(clientID);
            try
            {
                using (var _context = new ERPSSLHBEntities())
                {
                    var ParamempID = new SqlParameter("@OCODE", OCODE);
                    var startDate = new SqlParameter("@startDate", fromDate);
                    var EndDate = new SqlParameter("@EndDate", toDate);
                    var ParamempClientID = new SqlParameter("@ClientID", cID);
                    string SP_SQL = "[HRM_JobAllocationSingleClientSP] @OCODE,@ClientID,@startDate,@EndDate";
                    return (_context.ExecuteStoreQuery<JobAllocationRPTGlobal>(SP_SQL, ParamempID, ParamempClientID, startDate, EndDate)).ToList();
                }

            }
            catch (Exception)
            {

                throw;
            }

        }

        internal IEnumerable<JobAllocationRPTGlobal> RegionWiseJobAllocation(string OCODE, int RegionId, string fromDate, string toDate)
        {            
            try
            {
                using (var _context = new ERPSSLHBEntities())
                {
                    var ParamempID = new SqlParameter("@OCODE", OCODE);
                    var startDate = new SqlParameter("@startDate", fromDate);
                    var EndDate = new SqlParameter("@EndDate", toDate);
                    var ParamempRegionID = new SqlParameter("@RegionID", RegionId);
                    string SP_SQL = "[HRM_JobAllocationRegionSP] @OCODE,@RegionId,@startDate,@EndDate";
                    return (_context.ExecuteStoreQuery<JobAllocationRPTGlobal>(SP_SQL, ParamempID, ParamempRegionID, startDate, EndDate)).ToList();
                }

            }
            catch (Exception)
            {

                throw;
            }

        }

        internal IEnumerable<JobAllocationRPTGlobal> OfficeWiseJobAllocation(string OCODE, int RegionId, int OffieId, string fromDate, string toDate)
        {
            try
            {
                using (var _context = new ERPSSLHBEntities())
                {
                    var ParamempID = new SqlParameter("@OCODE", OCODE);
                    var startDate = new SqlParameter("@startDate", fromDate);
                    var EndDate = new SqlParameter("@EndDate", toDate);
                    var ParamempRegionID = new SqlParameter("@RegionID", RegionId);
                    var ParamempOfficeID = new SqlParameter("@OfficeID", OffieId);
                    string SP_SQL = "[HRM_JobAllocationOfficeSP] @OCODE,@RegionId,@OfficeID,@startDate,@EndDate";
                    return (_context.ExecuteStoreQuery<JobAllocationRPTGlobal>(SP_SQL, ParamempID, ParamempRegionID, ParamempOfficeID, startDate, EndDate)).ToList();
                }

            }
            catch (Exception)
            {

                throw;
            }

        }

        internal IEnumerable<JobAllocationRPTGlobal> DepartmentWiseJobAllocation(string OCODE, int RegionId, int OffieId, int DepartmentId, string fromDate, string toDate)
        {
            try
            {
                using (var _context = new ERPSSLHBEntities())
                {
                    var ParamempID = new SqlParameter("@OCODE", OCODE);
                    var startDate = new SqlParameter("@startDate", fromDate);
                    var EndDate = new SqlParameter("@EndDate", toDate);
                    var ParamempRegionID = new SqlParameter("@RegionID", RegionId);
                    var ParamempOfficeID = new SqlParameter("@OfficeID", OffieId);
                    var ParamempDepartmentID = new SqlParameter("@DepartmentID", DepartmentId);
                    string SP_SQL = "[HRM_JobAllocationDepartmentSP] @OCODE,@RegionId,@OfficeID,@DepartmentID,@startDate,@EndDate";
                    return (_context.ExecuteStoreQuery<JobAllocationRPTGlobal>(SP_SQL, ParamempID, ParamempRegionID, ParamempOfficeID, ParamempDepartmentID, startDate, EndDate)).ToList();
                }

            }
            catch (Exception)
            {

                throw;
            }

        }


    }
}
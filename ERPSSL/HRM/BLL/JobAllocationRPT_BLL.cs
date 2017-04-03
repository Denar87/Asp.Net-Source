using ERPSSL.HRM.DAL;
using ERPSSL.HRM.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPSSL.HRM.BLL
{
    public class JobAllocationRPT_BLL
    {
        JobAllocationRPT_DAL objJobAllocationRPT_Dal = new JobAllocationRPT_DAL();
        internal IEnumerable<JobAllocationRPTGlobal> GetAllClientForReport(string OCODE, string fromDate, string toDate)
        {
            return objJobAllocationRPT_Dal.GetAllClientForReport(OCODE, fromDate, toDate);
        }

        //internal List<JobAllocationRPTGlobal> GetJobAllocationDateWise(string OCODE, string fromDate, string toDate)
        //{
        //    return objJobAllocationRPT_Dal.GetJobAllocationDateWise(OCODE, fromDate, toDate);
        //}

        internal IEnumerable<JobAllocationRPTGlobal> JobAllocationSingleClientRPT(string OCODE,string clientID,string fromDate,string toDate)
        {
            return objJobAllocationRPT_Dal.JobAllocationSingleClientRPT(OCODE, clientID, fromDate, toDate);
        }

        internal IEnumerable<JobAllocationRPTGlobal> RegionWiseJobAllocation(string OCODE, int RegionId,string fromDate,string toDate)
        {
            return objJobAllocationRPT_Dal.RegionWiseJobAllocation(OCODE, RegionId, fromDate, toDate);
        }

        internal IEnumerable<JobAllocationRPTGlobal> OfficeWiseJobAllocation(string OCODE, int RegionId, int OfficeId,string fromDate,string toDate)
        {
            return objJobAllocationRPT_Dal.OfficeWiseJobAllocation(OCODE, RegionId, OfficeId, fromDate, toDate);
        }

        internal IEnumerable<JobAllocationRPTGlobal> DepartmentWiseJobAllocation(string OCODE, int RegionId, int OfficeId, int DepartmentId,string fromDate,string toDate)
        {
            return objJobAllocationRPT_Dal.DepartmentWiseJobAllocation(OCODE, RegionId, OfficeId, DepartmentId, fromDate, toDate);
        }
    }
}
using ERPSSL.LC.DAL;
using ERPSSL.LC.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPSSL.LC.BLL
{
    public class ReportBLL
    {
        ReportDAL _ReportDAL = new ReportDAL();


        internal List<ReportLC> GetLCOpenReport(string OCode)
        {
            return _ReportDAL.GetLCOpenReport(OCode);
        }
        internal List<ReportLC> GetLCOpenReportByDate(DateTime FromDate,DateTime Todate,string OCode)
        {
            return _ReportDAL.GetLCOpenReportByDate(FromDate, Todate, OCode);
        }
        internal List<ReportLC> GetLCOrderDetailsReport(string OCode)
        {
            return _ReportDAL.GetLCOrderDetailsReport(OCode);
        }

        internal List<ReportLC> GetContractReportByDate(DateTime FromDate, DateTime Todate, string OCode)
        {
            return _ReportDAL.GetContractReportByDate(FromDate, Todate, OCode);
        }

        internal List<ReportLC> GetLCAmendReportByDate(DateTime FromDate, DateTime Todate, string OCode)
        {
            return _ReportDAL.GetLCAmendReportByDate(FromDate, Todate, OCode);
        }

        internal List<ReportLC> GetLCStyleReport(string OCode)
        {
            return _ReportDAL.GetLCStyleReport(OCode);
        }
    }
}
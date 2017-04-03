using ERPSSL.HMS.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ERPSSL.HMS.DAL
{
    public class PatientBillEntry_DAL
    {
        ERPSSL_HMSEntities _context = new ERPSSL_HMSEntities();

        internal int InsertPatientBill(HMS_PatientBillInfo objBill)
        {
            try
            {
                _context.HMS_PatientBillInfo.AddObject(objBill);
                _context.SaveChanges();
                return 1;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        internal int InsertCollectionBill(HMS_PatientCollectionSummary objColBill)
        {
            try
            {
                _context.HMS_PatientCollectionSummary.AddObject(objColBill);
                _context.SaveChanges();
                return 1;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        internal IEnumerable<PatientBillInfoR> GetPatientBillInfoList(int pat_Id,string OCODE)
        {
            using (var _context = new ERPSSL_HMSEntities())
            {
                var paramPatientId = new SqlParameter("@Patient_Id",pat_Id);
               
                var ParamoCode = new SqlParameter("@OCODE", OCODE);

                string SP_SQL = "HMS_GetPatient_BillInfoList @Patient_Id, @OCODE";

                return (_context.ExecuteStoreQuery<PatientBillInfoR>(SP_SQL, paramPatientId, ParamoCode)).ToList();
            }

        }

        internal int DeletePatientBillHead(string billid,string oCode)
        {
            try
            {
                int id = Convert.ToInt32(billid);

                var x = (from y in _context.HMS_PatientBillInfo
                         where y.Id == id && y.OCODE == oCode 
                         select y).FirstOrDefault();
                if (x != null)
                {
                    _context.HMS_PatientBillInfo.DeleteObject(x);
                    _context.SaveChanges();
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        internal IEnumerable<PatientBillInfoR> GetPatientBillInfoForReport(int P_Id, string OCODE)
        {
            using (var _context = new ERPSSL_HMSEntities())
            {
                var ParamP_Id = new SqlParameter("@PId", P_Id);
                var ParamCode = new SqlParameter("@OCODE", OCODE);
                
                string SP_SQL = "HMS_Rpt_PatientBillInfoForReceipt @PId,@OCODE";

                return (_context.ExecuteStoreQuery<PatientBillInfoR>(SP_SQL, ParamP_Id, ParamCode)).ToList();
            }

        }

        internal IEnumerable<PatientBillInfoR> GetAllPatientBillDetailsForReport(string fromDate, string toDate, string OCODE)
        {
            try
            {
                using (var _context = new ERPSSL_HMSEntities())
                {
                   
                    var ParamempID = new SqlParameter("@FromDate", fromDate);
                    var ParamempID1 = new SqlParameter("@ToDate", toDate);
                    var oCode = new SqlParameter("@OCODE", OCODE);
                    string SP_SQL = "HMS_GetPatientBillDetailsForReport @FromDate, @ToDate, @OCODE";
                    return (_context.ExecuteStoreQuery<PatientBillInfoR>(SP_SQL, ParamempID, ParamempID1, oCode)).ToList();
                }

            }
            catch (Exception)
            {

                throw;
            }
        }
        internal IEnumerable<PatientBillInfoR> GetPatientSummaryBillForReport(string fromDate, string toDate, string OCODE)
        {
            try
            {
                using (var _context = new ERPSSL_HMSEntities())
                {
                    var ParamempID = new SqlParameter("@FromDate", fromDate);
                    var ParamempID1 = new SqlParameter("@ToDate", toDate);
                    var oCode = new SqlParameter("@OCODE", OCODE);
                    string SP_SQL = "HMS_GetPatientSummaryBillForReport @FromDate, @ToDate, @OCODE";
                    return (_context.ExecuteStoreQuery<PatientBillInfoR>(SP_SQL,ParamempID,ParamempID1,oCode)).ToList();
                }

            }
            catch (Exception)
            {

                throw;
            }
        }
        internal IEnumerable<PatientBillInfoR> GetTotalCollectionAmountForReport(string fromDate, string toDate, string OCODE)
        {
            try
            {
                using (var _context = new ERPSSL_HMSEntities())
                {
                    var ParamempID = new SqlParameter("@FromDate", fromDate);
                    var ParamempID1 = new SqlParameter("@ToDate", toDate);
                    var oCode = new SqlParameter("@OCODE", OCODE);
                    string SP_SQL = "HMS_GetTotalCollectionAmountForReport @FromDate, @ToDate, @OCODE";
                    return (_context.ExecuteStoreQuery<PatientBillInfoR>(SP_SQL, ParamempID, ParamempID1, oCode)).ToList();
                }

            }
            catch (Exception)
            {

                throw;
            }
        }
        internal IEnumerable<PatientBillInfoR> GetTotalDischargePatientForReport(string fromDate, string toDate, string OCODE)
        {
            try
            {
                using (var _context = new ERPSSL_HMSEntities())
                {
                    var ParamempID = new SqlParameter("@FromDate", fromDate);
                    var ParamempID1 = new SqlParameter("@ToDate", toDate);
                    var oCode = new SqlParameter("@OCODE", OCODE);
                    string SP_SQL = "HMS_GetTotalDischargePatientForReport @FromDate, @ToDate, @OCODE";
                    return (_context.ExecuteStoreQuery<PatientBillInfoR>(SP_SQL, ParamempID, ParamempID1, oCode)).ToList();
                }

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
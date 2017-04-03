using ERPSSL.HMS.DAL;
using ERPSSL.HMS.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPSSL.HMS.BLL
{
    public class PatientBillEntry_BLL
    {
        PatientBillEntry_DAL objBill_DAL = new PatientBillEntry_DAL();

        internal int InsertPatientBill(HMS_PatientBillInfo objBill)
        {
            return objBill_DAL.InsertPatientBill(objBill);
        }

        internal IEnumerable<PatientBillInfoR> GetPatientBillInfoList(int pat_Id, string OCODE)
        {
            return objBill_DAL.GetPatientBillInfoList(pat_Id,OCODE);
        }
        internal int InsertCollectionBill(HMS_PatientCollectionSummary objColBill)
        {
            return objBill_DAL.InsertCollectionBill(objColBill);
        }
        internal int DeletePatientBillHead(string billid, string oCode)
        {
            return objBill_DAL.DeletePatientBillHead(billid, oCode);
        }
        internal IEnumerable<PatientBillInfoR> GetPatientBillInfoForReport(int P_Id, string OCODE)
        {
            return objBill_DAL.GetPatientBillInfoForReport(P_Id,OCODE);
        }
        internal IEnumerable<PatientBillInfoR> GetAllPatientBillDetailsForReport(string fromDate, string toDate, string OCODE)
        {
            return objBill_DAL.GetAllPatientBillDetailsForReport(fromDate, toDate,OCODE);
        }
        internal IEnumerable<PatientBillInfoR> GetPatientSummaryBillForReport(string fromDate, string toDate, string OCODE)
        {
            return objBill_DAL.GetPatientSummaryBillForReport(fromDate,toDate,OCODE);
        }
        internal IEnumerable<PatientBillInfoR> GetTotalCollectionAmountForReport(string fromDate, string toDate, string OCODE)
        {
            return objBill_DAL.GetTotalCollectionAmountForReport(fromDate, toDate, OCODE);
        }
        internal IEnumerable<PatientBillInfoR> GetTotalDischargePatientForReport(string fromDate, string toDate, string OCODE)
        {
            return objBill_DAL.GetTotalDischargePatientForReport(fromDate, toDate, OCODE);
        }
    }
}
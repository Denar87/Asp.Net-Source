using ERPSSL.HMS.DAL;
using ERPSSL.HMS.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPSSL.HMS.BLL
{
    public class PatientEntry_BLL
    {
        PatientEntry_DAL objPatient_DAL = new PatientEntry_DAL();

        internal int InsertPatient(HMS_PatientInfo objPatient)
        {
            return objPatient_DAL.InsertPatient(objPatient);
        }
        internal int InsertPatientSummary(HMS_PatientCollectionSummary objSummary)
        {
            return objPatient_DAL.InsertPatientSummary(objSummary);
        }
        internal int InsertPatientBill(HMS_PatientBillInfo objbill)
        {
            return objPatient_DAL.InsertPatientBill(objbill);
        }
        internal IEnumerable<PatientInfoR> GetPatientInfoList(string OCODE)
        {
            return objPatient_DAL.GetPatientInfoList(OCODE);
        }
        internal int UpdatePatientInfo(HMS_PatientInfo objPatient, int pId)
        {
            return objPatient_DAL.UpdatePatientInfo(objPatient,pId);
        }
        internal List<HMS_PatientInfo> GetPatientByPatientId(string P_Id, string OCODE)
        {
            return objPatient_DAL.GetPatientByPatientId(P_Id ,OCODE );
        }

        internal List<HMS_BillCategory> GetBillCategoryList()
        {
            return objPatient_DAL.GetBillCategoryList();
        }

        internal List<HMS_BillHead> GetBillHeadList()
        {
            return objPatient_DAL.GetBillHeadList();
        }
        internal IEnumerable<PatientInfoR> GetPatientInfoForReport(int P_Id, string OCODE)
        {
            return objPatient_DAL.GetPatientInfoForReport(P_Id,OCODE);
        }
    }
}
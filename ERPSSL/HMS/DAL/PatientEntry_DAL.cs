using ERPSSL.HMS.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ERPSSL.HMS.DAL
{
    public class PatientEntry_DAL
    {
        private ERPSSL_HMSEntities _context = new ERPSSL_HMSEntities();

        internal int InsertPatient(HMS_PatientInfo objPatient)
        {
            try
            {
                _context.HMS_PatientInfo.AddObject(objPatient);
                _context.SaveChanges();
                return 1;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        internal int InsertPatientSummary(HMS_PatientCollectionSummary objSummary)
        {
            try
            {
                _context.HMS_PatientCollectionSummary.AddObject(objSummary);
                _context.SaveChanges();
                return 1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal int InsertPatientBill(HMS_PatientBillInfo objbill)
        {
            try
            {
                _context.HMS_PatientBillInfo.AddObject(objbill);
                _context.SaveChanges();
                return 1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal IEnumerable<PatientInfoR> GetPatientInfoList(string OCODE)
        {
            using (var _context = new ERPSSL_HMSEntities())
            {
                var ParamempID = new SqlParameter("@OCODE", OCODE);

                string SP_SQL = "HMS_GetPatientInfoList @OCODE";

                return (_context.ExecuteStoreQuery<PatientInfoR>(SP_SQL, ParamempID)).ToList();
            }
     
        }

        internal IEnumerable<PatientInfoR> GetPatientInfoForReport(int P_Id,string OCODE)
        {
            using (var _context = new ERPSSL_HMSEntities())
            {
                var ParamCode = new SqlParameter("@OCODE", OCODE);
                var ParamP_Id = new SqlParameter("@PId", P_Id);

                string SP_SQL = "HMS_Rpt_PatientInfoMoneyReceipt @PId,@OCODE";

                return (_context.ExecuteStoreQuery<PatientInfoR>(SP_SQL, ParamP_Id, ParamCode)).ToList();
            }

        }


        internal int UpdatePatientInfo(HMS_PatientInfo objPatient, int pId)
        {

            try
            {
                HMS_PatientInfo obj = _context.HMS_PatientInfo.First(x => x.PatientID == pId);
                obj.PatientName = objPatient.PatientName;
                obj.Age = objPatient.Age;
                obj.M_Y_D = objPatient.M_Y_D;
                obj.Gender = objPatient.Gender;
                obj.BloodGroup = objPatient.BloodGroup;
                obj.MaritalStatus = objPatient.MaritalStatus;
                obj.Mobile = objPatient.Mobile;
                obj.Address = objPatient.Address;
                obj.GuardianName = objPatient.GuardianName;
                obj.GuardianContactNo = objPatient.GuardianContactNo;
                obj.VisitDate = objPatient.VisitDate;
                obj.BillCategoryId = objPatient.BillCategoryId;
                obj.BillHeadId = objPatient.BillHeadId;
                obj.Amount = objPatient.Amount;
                obj.Bed_CabinNo = objPatient.Bed_CabinNo;
                obj.RefdBy = objPatient.RefdBy;
                obj.Remarks = objPatient.Remarks;
                obj.Edit_User = objPatient.Edit_User;
                obj.Edit_Date = objPatient.Edit_Date;
               
                _context.SaveChanges();
                return 1;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        internal List<HMS_PatientInfo> GetPatientByPatientId(string P_Id, string OCODE)
        {
            int Id = Convert.ToInt32(P_Id);


            List<HMS_PatientInfo> patientInfo = (from patient in _context.HMS_PatientInfo
                                                 where patient.OCODE == OCODE && patient.PatientID == Id
                                                 select patient).OrderBy(x => x.PatientID).ToList<HMS_PatientInfo>();
            return patientInfo;

        }

        internal List<HMS_PatientInfo> GetPatientByPatientName(string name, string OCODE)
        {
           
            List<HMS_PatientInfo> patientInfo = (from patient in _context.HMS_PatientInfo
                                                 where patient.OCODE == OCODE && patient.PatientName == name
                                                 select patient).OrderBy(x => x.PatientID).ToList<HMS_PatientInfo>();
            return patientInfo;

        }

        internal List<HMS_BillCategory> GetBillCategoryList()
        {
            try
            {
                List<HMS_BillCategory> _BillCategory = (from s in _context.HMS_BillCategory
                                                        select s).ToList();
                return _BillCategory;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
      
        internal List<HMS_BillHead> GetBillHeadList()
        {
            try
            {
                List<HMS_BillHead> _BillHead = (from s in _context.HMS_BillHead
                                                        select s).ToList();
                return _BillHead;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }

}
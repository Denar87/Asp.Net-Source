using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPSSL.HMS.DAL
{
    public class HMSDashboard_DAL
    {
        private ERPSSL_HMSEntities _context = new ERPSSL_HMSEntities();

        internal List<int> GetNumberOfAdmittedPatient()
        {
            try
            {
                using (_context = new ERPSSL_HMSEntities())
                {
                    var query = (from p in _context.HMS_PatientInfo
                                 select p.PatientID);

                    return query.ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
      
        internal List<int> GetCurrentMonthAdmittedPatient(int nowMonth, int nowYear)
        {


            try
            {
                using (_context = new ERPSSL_HMSEntities())
                {
                    var query = (from t in _context.HMS_PatientInfo
                                 where t.VisitDate.Value.Month == nowMonth && t.VisitDate.Value.Year == nowYear 
                                 select t.PatientID);

                    return query.ToList();
                }


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        internal List<int> GetLastMonthAdmittedPatient(int lastMonth, int lastYear)
        {


            try
            {
                using (_context = new ERPSSL_HMSEntities())
                {
                    var query = (from t in _context.HMS_PatientInfo
                                 where t.VisitDate.Value.Month == lastMonth && t.VisitDate.Value.Year == lastYear
                                 select t.PatientID);

                    return query.ToList();
                }


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

       
    }
}
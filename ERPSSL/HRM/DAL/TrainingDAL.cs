using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPSSL.HRM.DAL
{
    public class TrainingDAL
    {
        ERPSSLHBEntities _context = new ERPSSLHBEntities();
        internal List<HRM_Trainings> GetTrainingListByemployeeIdandOcode(string eid, string OCODE)
        {
            try
            {
                var query = (from tra in _context.HRM_Trainings
                             where tra.EID == eid && tra.OCODE == OCODE
                             select tra).OrderBy(x => x.TrainingId);


                return query.ToList();



            }
            catch (Exception)
            {
                
                throw;
            }
        }

        internal int DeleteTraningInfoByTraningIdandOcode(string traningId, string OCODE)
        {
            try
            {
                int tId = Convert.ToInt32(traningId);
                HRM_Trainings objAcademic = _context.HRM_Trainings.First(x => x.TrainingId == tId);
                _context.HRM_Trainings.DeleteObject(objAcademic);
                _context.SaveChanges();
                return 1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal List<HRM_Trainings> getTraningInfoByTraningIdandOcode(string TId, string OCODE)
        {
            try
            {
                int TraningId = Convert.ToInt32(TId);
                var query = (from tra in _context.HRM_Trainings
                             where tra.TrainingId == TraningId && tra.OCODE == OCODE
                             select tra).OrderBy(x => x.TrainingId);


                return query.ToList();



            }
            catch (Exception)
            {

                throw;
            }
        }

        internal int UpdateTrainingInfo(int TraningId, HRM_Trainings traningObj)
        {

            try
            {
                HRM_Trainings tranobj = _context.HRM_Trainings.First(x => x.TrainingId == TraningId);
                tranobj.TraningTitle = traningObj.TraningTitle;
                tranobj.TraningTopicsCovered = traningObj.TraningTopicsCovered;
                tranobj.Institue = traningObj.Institue;
                tranobj.Location = traningObj.Location;
                tranobj.TraningYear = traningObj.TraningYear;
                tranobj.Duration = traningObj.Duration;
                _context.SaveChanges();
                return 1;


            }
            catch (Exception)
            {
                
                throw;
            }
        }
    }
}
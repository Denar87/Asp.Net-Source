using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ERPSSL.HRM.DAL;

namespace ERPSSL.HRM.BLL
{
    public class TrainingBLL
    {
        TrainingDAL trainingDal = new TrainingDAL();
        internal List<HRM_Trainings> GetTrainingListByemployeeIdandOcode(string eid, string OCODE)
        {
            return trainingDal.GetTrainingListByemployeeIdandOcode(eid, OCODE);
        }

        internal int DeleteTraningInfoByTraningIdandOcode(string traningId, string OCODE)
        {
            return trainingDal.DeleteTraningInfoByTraningIdandOcode(traningId, OCODE);
        }

        internal List<HRM_Trainings> getTraningInfoByTraningIdandOcode(string TId, string OCODE)
        {
            return trainingDal.getTraningInfoByTraningIdandOcode(TId, OCODE);
        }

        internal int UpdateTrainingInfo(int TraningId, HRM_Trainings traningObj)
        {
            return trainingDal.UpdateTrainingInfo(TraningId, traningObj);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ERPSSL.HRM.DAL;

namespace ERPSSL.HRM.BLL
{
    public class ExperienceBLL
    {
        ExperienceDAL experienceDal = new ExperienceDAL();

        internal List<HRM_Experiences> GetAllExperiencesInfoByEmployeeId(string eid, string OCODE)
        {

            return experienceDal.GetAllExperiencesInfoByEmployeeId(eid, OCODE);
        }

        internal int DeleteexprienceIdandOcode(string exId, string OCODE)
        {
            return experienceDal.DeleteexprienceIdandOcode(exId, OCODE);
        }

        internal HRM_Experiences GetAExprenceByExpericenceId(string exId, string OCODE)
        {
            return experienceDal.GetAExprenceByExpericenceId(exId, OCODE);
        }
    }
}
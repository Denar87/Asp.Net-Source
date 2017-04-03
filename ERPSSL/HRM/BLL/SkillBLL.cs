using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ERPSSL.HRM.DAL;

namespace ERPSSL.HRM.BLL
{
    public class SkillBLL
    {
        SkillDAL skillDal = new SkillDAL();
        internal List<HRM_Skills> GetSkillInfobyIdandOcode(string eid, string OCODE)
        {
            return skillDal.GetSkillInfobyIdandOcode(eid, OCODE);
        }

        internal int DeleteskillInfoIdandOcode(string skillId, string OCODE)
        {
            return skillDal.DeleteskillInfoIdandOcode(skillId, OCODE);
        }

        internal List<HRM_Skills> getSkill(string skId, string OCODE)
        {
            return skillDal.getSkill(skId, OCODE);
        }
    }
}
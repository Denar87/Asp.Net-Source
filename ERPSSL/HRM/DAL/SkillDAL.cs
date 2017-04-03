using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPSSL.HRM.DAL
{
    public class SkillDAL
    {
        ERPSSLHBEntities _context = new ERPSSLHBEntities();
        internal List<HRM_Skills> GetSkillInfobyIdandOcode(string eid, string OCODE)
        {
            try
            {

                var query = (from ex in _context.HRM_Skills
                             where ex.EID == eid && ex.OCODE == OCODE
                             select ex).OrderBy(x => x.SkillId);


                return query.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }


        }

        internal int DeleteskillInfoIdandOcode(string skillId, string OCODE)
        {
            try
            {
                int SkillId = Convert.ToInt32(skillId);
                HRM_Skills objex = _context.HRM_Skills.First(x => x.SkillId == SkillId);
                _context.HRM_Skills.DeleteObject(objex);
                _context.SaveChanges();
                return 1;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        internal List<HRM_Skills> getSkill(string skId, string OCODE)
        {
            int skillId = Convert.ToInt32(skId);

            var query = (from ex in _context.HRM_Skills
                         where ex.SkillId == skillId && ex.OCODE == OCODE
                         select ex).OrderBy(x => x.SkillId);

            return query.ToList();
        }
    }
}
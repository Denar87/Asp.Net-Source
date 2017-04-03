using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPSSL.HRM.DAL
{
    public class ExperienceDAL
    {
        ERPSSLHBEntities _context = new ERPSSLHBEntities();
        internal List<HRM_Experiences> GetAllExperiencesInfoByEmployeeId(string eid, string OCODE)
        {
            try
            {

                var query = (from ex in _context.HRM_Experiences
                             where ex.EID == eid && ex.OCODE == OCODE

                             select ex).OrderBy(x => x.ExperienceId);


                return query.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }

        }

        internal int DeleteexprienceIdandOcode(string exId, string OCODE)
        {

            try
            {
                int eId = Convert.ToInt32(exId);
                HRM_Experiences objex = _context.HRM_Experiences.First(x => x.ExperienceId == eId);
                _context.HRM_Experiences.DeleteObject(objex);
                _context.SaveChanges();
                return 1;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        internal HRM_Experiences GetAExprenceByExpericenceId(string exId, string OCODE)
        {
           try
            {
                int exid = Convert.ToInt32(exId);
                HRM_Experiences objex = _context.HRM_Experiences.First(x => x.ExperienceId == exid);
                return objex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
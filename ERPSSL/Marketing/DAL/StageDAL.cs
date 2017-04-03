using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPSSL.Marketing.DAL
{
    public class StageDAL
    {
        ERPSSL_Marketing_Entities _context = new ERPSSL_Marketing_Entities();

        public List<MRK_Stage> GetAllStagesList(string OCODE)
        {
            try
            {

                var query = (from s in _context.MRK_Stage
                             where s.OCODE == OCODE
                             select s);


                return query.ToList();

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
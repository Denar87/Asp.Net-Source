using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ERPSSL.Marketing.DAL;

namespace ERPSSL.Marketing.DAL
{
    public class ProjectDAL
    {

        ERPSSL_Marketing_Entities _context = new ERPSSL_Marketing_Entities();

        public List<MRK_Project> GetAllProjectList(string OCODE)
        {
            try
            {

                var query = (from p in _context.MRK_Project
                             where p.OCODE == OCODE
                             select p);


                return query.ToList();

            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
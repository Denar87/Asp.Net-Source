using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPSSL.INV.DAL
{
     

    public class DepartmentDAL
    {
        private ERPSSL_INVEntities _context = new ERPSSL_INVEntities();

        public virtual List<HRM_DEPARTMENTS> GetAllDepartment()
        {
            try
            {
                var query = (from department in _context.HRM_DEPARTMENTS
                             select department).OrderBy(x => x.DPT_NAME);

                return query.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

    }
}
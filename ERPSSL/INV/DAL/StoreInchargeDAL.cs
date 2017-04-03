using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ERPSSL.INV.DAL.Repository;
using ERPSSL.HRM.DAL.Repository;

namespace ERPSSL.INV.DAL
{
    public class StoreInchargeDAL
    {
        private ERPSSL_INVEntities _context = new ERPSSL_INVEntities();

        public IEnumerable<StoreInCharge> GetStoreIncharge( )
        {
            using (var _context = new ERPSSL_INVEntities())
            {
                return (from emp in _context.HRM_PersonalInformations
                       
                        select new StoreInCharge
                        {
                            Eid = emp.EID,
                           Store_fullname=emp.FirstName+"-"+emp.LastName

                        }).ToList();
            }
            
        }

    }
}
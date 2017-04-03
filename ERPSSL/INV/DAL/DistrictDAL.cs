using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.EntityModel;
using System.Diagnostics;
using ERPSSL.INV.DAL;

namespace ERPSSL.INV.DAL
{
    public class DistrictDAL
    {
        private ERPSSL_INVEntities _context = new ERPSSL_INVEntities();
        
        
        public virtual List<Inv_District> GetAllDistrict()
        {
            try
            {
                var query = (from district in _context.Inv_District
                             select district).OrderBy(x => x.DistrictName);

                return query.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        public virtual List<Inv_CompanyType> GetAllBusinessType()
        {
            try
            {
                var query = (from district in _context.Inv_CompanyType
                             select district).OrderBy(x => x.CompanyType);

                return query.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        //using stored procedure

        //public List<Inv_District> GetAllDistrictList()
        //{

        //    using (ERPSSL_INVEntities ctx = new ERPSSL_INVEntities())
        //    {
        //        try
        //        {
        //            var list = ctx.Database.SqlQuery<Inv_District>("SP_INV_GETDISTRICTALL").ToList<Inv_District>();
        //            return list;
        //        }
        //        catch (Exception ex)
        //        {
        //            throw ex;
        //        }
        //    }

        //}
    }
}
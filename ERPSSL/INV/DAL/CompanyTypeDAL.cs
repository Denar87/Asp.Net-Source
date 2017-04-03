using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPSSL.INV.DAL
{
    public class CompanyTypeDAL
    {
        private ERPSSL_INVEntities _context = new ERPSSL_INVEntities();
        internal int InsertCompanyType(Inv_CompanyType aCompanyType)
        {
            try
            {
                _context.Inv_CompanyType.AddObject(aCompanyType);
                _context.SaveChanges();
                return 1;

            }
            catch (Exception)
            {

                throw;
            }
        }

        internal List<Inv_CompanyType> GetAllCompanyType()
        {
            try
            { 
                var CompanyType = (from CType in _context.Inv_CompanyType 
                                select CType).OrderBy(x => x.CompanyType); 
                return CompanyType.ToList();

            }
            catch (Exception)
            {
                throw;
            }
        }

        internal List<Inv_CompanyType> GetCTypeId(string ID)
        {
            try
            {
                int CTypeId = Convert.ToInt32(ID);

                var companyType = (from CType in _context.Inv_CompanyType
                               where CType.CompanyType_Id == CTypeId
                               select CType);
                return companyType.ToList();

            }
            catch (Exception)
            {
                throw;
            }
        }

        internal int UpdateCompanyType(Inv_CompanyType aCompanyType, int ID)
        {
            try
            {
                Inv_CompanyType CType = _context.Inv_CompanyType.First(x => x.CompanyType_Id == ID);
                CType.CompanyType = aCompanyType.CompanyType; 
                _context.SaveChanges();
                return 1; 
            }
            catch (Exception)
            { 
                throw;
            }
        }
    }
}
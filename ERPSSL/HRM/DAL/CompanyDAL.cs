using ERPSSL.HRM.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPSSL.HRM.DAL
{
    public class CompanyDAL
    {
        private ERPSSLHBEntities _context = new ERPSSLHBEntities();
        internal int InsertCompany(HRM_Company companyObj)
        {
            try
            {
                _context.HRM_Company.AddObject(companyObj);
                _context.SaveChanges();
                return 1;

            }
            catch (Exception)
            {
                
                throw;
            }
        }

        internal List<HRM_Company> GetCompnay(string OCODE)
        {
            try
            {
                
               var companys = (from comp in _context.HRM_Company
                             where  comp.OCODE == OCODE
                             select comp);


               return companys.ToList();

            }
            catch (Exception)
            {
                
                throw;
            }
        }

        internal List<HRM_Company> GetcompanyInfoIdandOcode(string companyId, string OCODE)
        {
            try
            {
                int compId=Convert.ToInt16(companyId);

                var companys = (from comp in _context.HRM_Company
                                where comp.CompanyId == compId && comp.OCODE == OCODE
                                select comp);


                return companys.ToList();

            }
            catch (Exception)
            {

                throw;
            }

        }

        internal int UpdateCompany(int comapnyId, HRM_Company companyObj)
        {
            try
            {
                HRM_Company compObj = _context.HRM_Company.First(x => x.CompanyId == comapnyId);
                compObj.Name = companyObj.Name;
                compObj.Mobile = companyObj.Mobile;
                compObj.Phone = companyObj.Phone;
                compObj.Email = companyObj.Email;
                compObj.Fax = companyObj.Fax;
                compObj.Address = companyObj.Address;
                compObj.Web = companyObj.Web;
                compObj.Logo = companyObj.Logo;
                compObj.AreaCode = companyObj.AreaCode;
                compObj.ERCDate = companyObj.ERCDate;
                compObj.ERCNo = companyObj.ERCNo;
                compObj.REGNo = companyObj.REGNo;
                compObj.REGDate = companyObj.REGDate;
                _context.SaveChanges();
                return 1;

            }
            catch (Exception)
            {
                
                throw;
            }
        }

        internal int InsertSubCompany(HRM_SubCompany subcompanyObj)
        {
            _context.HRM_SubCompany.AddObject(subcompanyObj);
            _context.SaveChanges();
            return 1;
        }

        internal List<HRM_Company> getMainCompany(string OCODE)
        {
            try
            {
                var query = (from com in _context.HRM_Company
                             where com.OCODE == OCODE
                             select com).OrderBy(x => x.CompanyId);


                return query.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        internal List<HRM_SubCompany> GetSubcompanyInfoIdandOcode(string subcompanyId, string OCODE)
        {
            try
            {
                int scompId = Convert.ToInt16(subcompanyId);

                var scompanys = (from scomp in _context.HRM_SubCompany
                                where scomp.SubCompany_Id == scompId && scomp.OCODE == OCODE
                                select scomp);


                return scompanys.ToList();

            }
            catch (Exception)
            {

                throw;
            }
        }

        internal int UpdateSubCompany(HRM_SubCompany subcompanyObj, int scomapnyId)
        {
            try
            {
                HRM_SubCompany scompObj = _context.HRM_SubCompany.First(x => x.SubCompany_Id == scomapnyId);
                scompObj.CompanyId = subcompanyObj.CompanyId;
                scompObj.SubCompanyName = subcompanyObj.SubCompanyName;
                scompObj.SubCompanyCode = subcompanyObj.SubCompanyCode;
                scompObj.SubCompanyAddress = subcompanyObj.SubCompanyAddress;
                scompObj.EDIT_DATE = subcompanyObj.EDIT_DATE;
                scompObj.EDIT_USER = subcompanyObj.EDIT_USER;
                scompObj.OCODE = subcompanyObj.OCODE;
              
                _context.SaveChanges();
                return 1;

            }
            catch (Exception)
            {

                throw;
            }
        }

        internal IEnumerable<Company> GetSubCompnay(string OCODE)
        {
          
            List<Company> scompanys = (from scom in _context.HRM_SubCompany
                                   join com in _context.HRM_Company on scom.CompanyId equals com.CompanyId


                                       where scom.OCODE == OCODE

                                   select new Company
                                         {
                                             SubCompany_Id=scom.SubCompany_Id,
                                             CompanyName = com.Name,
                                             SubCompanyName = scom.SubCompanyName,
                                             SubCompanyCode = scom.SubCompanyCode,
                                             SubCompanyAddress = scom.SubCompanyAddress,
                                            
                                         }).ToList();
            return scompanys;
        }
    }
}
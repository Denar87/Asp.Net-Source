using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ERPSSL.INV.DAL;

namespace ERPSSL.INV.DAL
{
    public class CompanyDAL
    {
        private ERPSSL_INVEntities _context = new ERPSSL_INVEntities();
        internal int InsertCompany(Inv_Company companyObj)
        {
            try
            {
                _context.Inv_Company.AddObject(companyObj);
                _context.SaveChanges();
                return 1;

            }
            catch (Exception)
            {

                throw;
            }
        }

        internal List<Inv_Store> GetStore(string OCODE)
        {
            try
            {
                var companys = (from comp in _context.Inv_Store
                                where comp.OCODE == OCODE
                                select comp); 
                return companys.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal List<Inv_Company> GetOtherStore(string OCODE)
        {
            try
            {
                var companys = (from comp in _context.Inv_Company
                                where comp.OCODE == OCODE && comp.CompanyType == "GENERAL"
                                select comp);
                return companys.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal List<Inv_Company> GetCheckCentralStore(string OCODE,string companyType)
        {
            try
            {

                var companys = (from comp in _context.Inv_Company
                                where comp.OCODE == OCODE && comp.CompanyType == companyType
                                select comp);
                return companys.ToList();

            }
            catch (Exception)
            {

                throw;
            }
        }

        internal List<Inv_Company> GetcompanyInfoIdandOcode(string companyId, string OCODE)
        {
            try
            {
                int compId = Convert.ToInt16(companyId);

                var companys = (from comp in _context.Inv_Company
                                where comp.CompanyId == compId && comp.OCODE == OCODE
                                select comp);
                return companys.ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        internal List<Inv_Company> GetcompanyByCode(string CompanyType)
        {
            try
            {
                var companys = (from comp in _context.Inv_Company
                                where comp.CompanyCode == CompanyType
                                select comp);
                return companys.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal List<Inv_Company> GetcompanyTypeByCode()
        {
            try
            {
                var companys = (from comp in _context.Inv_Company
                                select comp);
                return companys.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal int UpdateCompany(int comapnyId, Inv_Company companyObj)
        {
            try
            {
                Inv_Company compObj = _context.Inv_Company.First(x => x.CompanyId == comapnyId);
                compObj.CompanyName = companyObj.CompanyName;
                //compObj.CompanyType = companyObj.CompanyType;
                compObj.Mobile = companyObj.Mobile;
                compObj.Phone = companyObj.Phone;
                compObj.Email = companyObj.Email;
                compObj.Fax = companyObj.Fax;
                compObj.Address = companyObj.Address;
                compObj.Web = companyObj.Web;
                compObj.Logo = companyObj.Logo;
                _context.SaveChanges();
                return 1;

            }
            catch (Exception)
            {

                throw;
            }
        }

        internal List<Inv_Company> GetCompnay(string OCODE)
        {
            try
            {

                var companys = (from comp in _context.Inv_Company
                                where comp.OCODE == OCODE
                                select comp);
                return companys.ToList();

            }
            catch (Exception)
            {

                throw;
            }
        }

        internal List<Inv_Store> GetStorebyStore(string OCODE, string StoreToCode)
        {
            try
            {
                var StoreL = (from s in _context.Inv_Store
                              where s.OCODE == OCODE && s.Store_Code != StoreToCode
                                select s);
                return StoreL.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal List<Inv_Store> GetStoreCodeByCode(int sId)
        {
            try
            {
                var companys = (from comp in _context.Inv_Store
                                where comp.Store_Id == sId
                                select comp);
                return companys.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal List<HRM_SubCompany> GetSubCompanyList(string OCode)
        {
            try
            {
                var companys = (from comp in _context.HRM_SubCompany
                                where comp.OCODE == OCode
                                select comp);
                return companys.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
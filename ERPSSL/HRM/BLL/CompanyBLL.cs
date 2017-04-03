using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ERPSSL.HRM.DAL;
using ERPSSL.HRM.DAL.Repository;

namespace ERPSSL.HRM.BLL
{
    public class CompanyBLL
    {
        CompanyDAL companyDal = new CompanyDAL();
        internal int InsertCompany(HRM_Company companyObj)
        {
            return companyDal.InsertCompany(companyObj);
        }

        internal List<HRM_Company> GetCompnay(string OCODE)
        {
            return companyDal.GetCompnay(OCODE);
        }

        internal List<HRM_Company> GetcompanyInfoIdandOcode(string companyId, string OCODE)
        {
            return companyDal.GetcompanyInfoIdandOcode(companyId, OCODE);
        }

        internal int UpdateCompany(HRM_Company companyObj, int comapnyId)
        {
            return companyDal.UpdateCompany(comapnyId, companyObj);
        }

        internal int InsertSubCompany(HRM_SubCompany subcompanyObj)
        {
            return companyDal.InsertSubCompany(subcompanyObj);
        }

        internal List<HRM_Company> getMainCompany(string OCODE)
        {
            return companyDal.getMainCompany(OCODE);
        }

        internal List<HRM_SubCompany> GetSubcompanyInfoIdandOcode(string subcompanyId, string OCODE)
        {
            return companyDal.GetSubcompanyInfoIdandOcode(subcompanyId, OCODE);
        }

        internal int UpdateSubCompany(HRM_SubCompany subcompanyObj, int scomapnyId)
        {
            return companyDal.UpdateSubCompany(subcompanyObj, scomapnyId);
        }

        internal IEnumerable<Company> GetSubCompnay(string OCODE)
        {
            return companyDal.GetSubCompnay(OCODE);
        }
    }
}
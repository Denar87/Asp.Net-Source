using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ERPSSL.INV.DAL;

namespace ERPSSL.INV.BLL
{
    public class CompanyTypeBLL
    {
        CompanyTypeDAL aCompanyTypeDAL = new CompanyTypeDAL();
        internal int InsertCompanyType(DAL.Inv_CompanyType aCompanyType)
        {
            return aCompanyTypeDAL.InsertCompanyType(aCompanyType);
        }

        internal List<Inv_CompanyType> GetAllCompanyType()
        {
            return aCompanyTypeDAL.GetAllCompanyType();
        }

        internal List<Inv_CompanyType> GetCTypeId(string ID)
        {
            return aCompanyTypeDAL.GetCTypeId(ID);
        }

        internal int UpdateCompanyType(Inv_CompanyType aCompanyType, int ID)
        {
            return aCompanyTypeDAL.UpdateCompanyType(aCompanyType, ID);
        }
    }
}
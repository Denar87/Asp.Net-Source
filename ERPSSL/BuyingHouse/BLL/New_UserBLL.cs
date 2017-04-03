using ERPSSL.BuyingHouse.DAL;
using ERPSSL.BuyingHouse.DAL.Repository;
using ERPSSL.LC.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//using ERPSSL.HRM.DAL;

namespace ERPSSL.BuyingHouse.BLL
{
    public class New_UserBLL
    {
        New_UserDAL _asset_Userdal = new New_UserDAL();
        internal int SaveAsset_User(HRM_PersonalInformations _personalInfo)
        {
            return _asset_Userdal.SaveAsset_User(_personalInfo);
        }

        internal IEnumerable<RFEmployee> GetSearchEmployeesList(string OCODE, string EmpSearch)
        {
            return _asset_Userdal.GetSearchEmployeesList(OCODE, EmpSearch);
        }

        internal IEnumerable<RFEmployee> GetEmployees(string OCODE)
        {
            return _asset_Userdal.GetEmployees(OCODE);
        }
      
    }
}
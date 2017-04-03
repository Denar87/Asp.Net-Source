using ERPSSL.BuyingHouse.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using ERPSSL.LC.DAL;
//using ERPSSL.HRM.DAL;

namespace ERPSSL.BuyingHouse.DAL
{
    public class New_UserDAL
    {
        ERPSSL_LCEntities _db = new ERPSSL_LCEntities();

        internal int SaveAsset_User(HRM_PersonalInformations _personalInfo)
        {
            _db.HRM_PersonalInformations.AddObject(_personalInfo);
            _db.SaveChanges();
            return 1;
        }

        internal IEnumerable<RFEmployee> GetSearchEmployeesList(string OCODE, string EmpSearch)
        {

            try
            {
                using (var _context = new ERPSSL_LCEntities())
                {
                    var ParamempID = new SqlParameter("@OCODE", OCODE);
                    var ParamempID1 = new SqlParameter("@searchText", EmpSearch);
                    string SP_SQL = "HRM_SearchEmployesList @OCODE,@searchText";
                    return (_context.ExecuteStoreQuery<RFEmployee>(SP_SQL, ParamempID, ParamempID1)).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        internal IEnumerable<RFEmployee> GetEmployees(string OCODE)
        {
            try
            {
                using (var _context = new ERPSSL_LCEntities())
                {
                    var ParamempID = new SqlParameter("@OCODE", OCODE);
                    string SP_SQL = "HRM_EmployesList @OCODE";
                    return (_context.ExecuteStoreQuery<RFEmployee>(SP_SQL, ParamempID)).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
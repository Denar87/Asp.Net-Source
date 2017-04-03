using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using ERPSSL.Adminpanel.DAL.Repository;

namespace ERPSSL.Adminpanel.DAL
{
    public class UserAccessDAL
    {

        DAL.ERPSSL_AdminEntities1 _context = new ERPSSL_AdminEntities1();
        internal List<tbl_User> GetUser(string Ocode)
        {
            try
            {

                var user = (from u in _context.tbl_User
                             where u.OCode == Ocode
                             select u);
                return user.ToList();
            }
            catch (Exception)
            {

                throw;
            }


        }

        internal int SaveUserAccess(List<tbl_UserAccess> UserAccessList)
        {
            try
            {
                foreach (tbl_UserAccess aitem in UserAccessList)
                {

                    tbl_UserAccess _userAccess = _context.tbl_UserAccess.FirstOrDefault(x => x.UserID == aitem.UserID && x.PageID==aitem.PageID && x.CategoryId==aitem.CategoryId && x.ModuleId==aitem.ModuleId);

                    if (_userAccess != null)
                    {
                        _context.DeleteObject(_userAccess);
                        _context.SaveChanges();
                    }
                    _context.tbl_UserAccess.AddObject(aitem);
                    _context.SaveChanges();
                }
                _context.SaveChanges();
                return 1;

            }
            catch (Exception)
            {

                throw;
            }

        }

        internal List<RUserAccessRole> GetUserAccessInfoForDelete(string Ocode, string UserId)
        {
            try
            {


                using (var _context = new ERPSSL_AdminEntities1())
                {
                    var ParamempID = new SqlParameter("@ocode", Ocode);
                    var ParamempID1 = new SqlParameter("@UserId", UserId);
                    string SP_SQL = "[HRM_GetUserAccessListByUserId] @ocode,@UserId";
                    return (_context.ExecuteStoreQuery<RUserAccessRole>(SP_SQL, ParamempID, ParamempID1)).ToList();
                }

            }
            catch (Exception)
            {

                throw;
            }

        }

        internal int DeleteUserAccessById(string UserAccessId, string Ocode)
        {
            int aid=Convert.ToInt16(UserAccessId);
            try
            {
                tbl_UserAccess userAccess = _context.tbl_UserAccess.First(i => i.UserAccessId == aid);
                _context.tbl_UserAccess.DeleteObject(userAccess);
                _context.SaveChanges();
                return 1;

            }
            catch (Exception)
            {
                
                throw;
            }

        }

        internal List<RUserAccessRole> GetUserAccessInfobyModuleandUserId(string Ocode, string UserId, int moduleId)
        {
            try
            {


                using (var _context = new ERPSSL_AdminEntities1())
                {
                    var ParamempID = new SqlParameter("@ocode", Ocode);
                    var ParamempID1 = new SqlParameter("@UserId", UserId);
                    var ParamempID2 = new SqlParameter("@moduleId", moduleId);
                    string SP_SQL = "[HRM_GetUserAccessListByUserIdandModuleId] @ocode,@UserId,@moduleId";
                    return (_context.ExecuteStoreQuery<RUserAccessRole>(SP_SQL, ParamempID, ParamempID1, ParamempID2)).ToList();
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        internal List<RUserAccessRole> GetUserAccessInfobyModuleandUserId(string Ocode, string UserId, int moduleId, int featureId)
        {
            try
            {


                using (var _context = new ERPSSL_AdminEntities1())
                {
                    var ParamempID = new SqlParameter("@ocode", Ocode);
                    var ParamempID1 = new SqlParameter("@UserId", UserId);
                    var ParamempID2 = new SqlParameter("@moduleId", moduleId);
                    var ParamempID3 = new SqlParameter("@CategoryId", featureId);
                    string SP_SQL = "[HRM_GetUserAccessListByUserIdModuleIdAndCategoryId] @ocode,@UserId,@moduleId,@CategoryId";
                    return (_context.ExecuteStoreQuery<RUserAccessRole>(SP_SQL, ParamempID, ParamempID1, ParamempID2, ParamempID3)).ToList();
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        internal List<tbl_UserPassword> GetUserPassword(Guid UserId, string OCode)
        {
            try
            {

                var user = (from u in _context.tbl_UserPassword.AsQueryable()
                            where u.UserID == UserId 
                            select u);
                return user.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
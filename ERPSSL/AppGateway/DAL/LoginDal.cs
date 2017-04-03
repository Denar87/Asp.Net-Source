using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using ERPSSL.AppGateway.BOL;

namespace ERPSSL.AppGateway.DAL
{
    public class LoginDal
    {
        DAL.ERPSSL_LoginEntities _context = new ERPSSL_LoginEntities();

        public virtual List<LoginBol> User_Login(string UserName, string UserPass)
        {
            using (_context)
            {
                var ParamempID = new SqlParameter("@LoginName", UserName);
                var ParamempID1 = new SqlParameter("@Password", UserPass);
                string SP_SQL = "ERP_LogIn @LoginName,@Password";

                var result = _context.ExecuteStoreQuery<LoginBol>(SP_SQL, ParamempID, ParamempID1);
                return result.ToList();
            }
        }

        public virtual List<LoginBol> GetUser_Login(string UserName, string UserPass)
        {
            using (_context)
            {
                var ParamempID = new SqlParameter("@LoginName", UserName);
                var ParamempID1 = new SqlParameter("@Password", UserPass);
                string SP_SQL = "ERP_UserLogIn @LoginName,@Password";

                var result = _context.ExecuteStoreQuery<LoginBol>(SP_SQL, ParamempID, ParamempID1);
                return result.ToList();
            }
        }

        internal List<tbl_User> GetAllUserInfo(string OCODE)
        {
            try
            {
                var users = (from usr in _context.tbl_User
                             where usr.OCode == OCODE && usr.IsActive==true orderby usr.LoginName
                             select usr);
                return users.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        internal List<tbl_User> GetAllUserInfoById(string OCODE, Guid userId)
        {
            try
            {
                var users = (from usr in _context.tbl_User
                             where usr.OCode == OCODE && usr.UserID == userId
                             select usr);
                return users.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }
        
    }
}
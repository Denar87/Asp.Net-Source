using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPSSL.Adminpanel.DAL
{
    public class UserDAL
    {
        DAL.ERPSSL_AdminEntities1 _context = new ERPSSL_AdminEntities1();
        internal int SaveUser(tbl_User userObj)
        {

            try
            {
                _context.tbl_User.AddObject(userObj);
                _context.SaveChanges();
                return 1;

            }
            catch (Exception)
            {

                throw;
            }
        }

        internal int SaveUsrPassword(tbl_UserPassword userPassword)
        {
            try
            {
                _context.tbl_UserPassword.AddObject(userPassword);
                _context.SaveChanges();
                return 1;

            }
            catch (Exception)
            {

                throw;
            }

        }
        internal int ChangePassword(tbl_UserPassword _userPassword)
        {
            tbl_UserPassword obj = _context.tbl_UserPassword.First(x => x.UserID == _userPassword.UserID);
            obj.Password = _userPassword.Password;
            _context.SaveChanges();
            return 1;
        }

        internal int getCurrentStatusBy(Guid userId, string passwordId)
        {
            int status = 0;
            tbl_UserPassword obj = _context.tbl_UserPassword.First(x => x.UserID == userId);
            if (obj.Password != passwordId)
            {
                status = 1;
            }
            return status;
        }

        internal int CheckUserExitance(string OCODE, string Requested)
        {

            try
            {
                try
                {
                    return (from u in _context.tbl_User
                            where u.LoginName == Requested && u.OCode == OCODE
                            select u).Count();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message.ToString());
                }


            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public virtual List<tbl_User> GetAlluser(string OCODE)
        {

            try
            {
                var query = (from user in _context.tbl_User
                             where user.OCode == OCODE
                             select user).OrderBy(x => x.EID);


                return query.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        internal int Updateuser(tbl_User userObj, string usereId)
        {
            try
            {
                tbl_User obj = _context.tbl_User.First(x => x.EID == usereId);
                obj.LoginName = userObj.LoginName;
                obj.Use_Email = userObj.Use_Email;
                obj.UserFullName = userObj.UserFullName;
                obj.IsActive = userObj.IsActive;         
                _context.SaveChanges();
                return 1;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        internal List<tbl_User> Getusereid(string eid, string OCODE)
        {
            string Eid = eid;            
            List<tbl_User> Users = (from reg in _context.tbl_User
                                         where reg.OCode == OCODE && reg.EID == Eid
                                    select reg).OrderByDescending(x => x.EID).ToList<tbl_User>();
            return Users;

        }
        internal string getEIDbyUserGuidID(Guid UserID)
        {

            tbl_User obj = _context.tbl_User.First(x => x.UserID == UserID);
            return obj.EID;
        }
    }
}
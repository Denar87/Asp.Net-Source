using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ERPSSL.Adminpanel.DAL;

namespace ERPSSL.Adminpanel.BLL
{
    public class UserBLL
    {
        UserDAL userDalObj = new UserDAL();
        internal int SaveUser(tbl_User userObj)
        {
           return userDalObj.SaveUser(userObj);
        }

        internal int SaveUsrPassword(tbl_UserPassword userPassword)
        {
            return userDalObj.SaveUsrPassword(userPassword);
        }
        internal int getCurrentStatusBy(Guid userId, string passwordId)
        {
            return userDalObj.getCurrentStatusBy(userId, passwordId);
        }
        internal int ChangePassword(tbl_UserPassword _userPassword)
        {
            return userDalObj.ChangePassword(_userPassword);
        }

        internal int CheckUserExitance(string OCODE, string Requested)
        {
            return userDalObj.CheckUserExitance(OCODE, Requested);
        }
        public virtual List<tbl_User> GetAlluser(string OCODE)
        {
            return userDalObj.GetAlluser(OCODE);
        }
        public int Updateuser(tbl_User userObj, string usereId)
        {
            return userDalObj.Updateuser(userObj, usereId);
        }
        internal List<tbl_User> Getuser(string eid, string OCODE)
        {
            return userDalObj.Getusereid(eid, OCODE);
        }
    }
}
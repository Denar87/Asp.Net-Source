using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using ERPSSL.AppGateway.BOL;
using ERPSSL.AppGateway.DAL;

namespace ERPSSL.AppGateway.BLL
{
    public class LoginBll
    {
        DAL.LoginDal objLoginDal = new DAL.LoginDal();

        public virtual List<LoginBol> User_Login(string UserName, string UserPass)
        {
            return objLoginDal.User_Login(UserName, UserPass);
        }
        public virtual List<LoginBol> GetUser_Login(string UserName, string UserPass)
        {
            return objLoginDal.GetUser_Login(UserName, UserPass);
        }

        internal List<tbl_User> GetAllUserInfoById(string OCODE, Guid userId)
        {
            return objLoginDal.GetAllUserInfoById(OCODE, userId);
        }

        internal List<tbl_User> GetAllUserInfo(string OCODE)
        {
            return objLoginDal.GetAllUserInfo(OCODE);
        }
    }
}
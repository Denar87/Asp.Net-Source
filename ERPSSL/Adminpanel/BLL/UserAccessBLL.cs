using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ERPSSL.Adminpanel.DAL;
using ERPSSL.Adminpanel.DAL.Repository;

namespace ERPSSL.Adminpanel.BLL
{
    public class UserAccessBLL
    {
        UserAccessDAL userAccessdal = new UserAccessDAL();
        internal List<tbl_User> GetUser(string Ocode)
        {
           return userAccessdal.GetUser(Ocode);
        }

        internal int SaveUserAccess(List<tbl_UserAccess> UserAccessList)
        {

            return userAccessdal.SaveUserAccess(UserAccessList);
        }

        internal List<RUserAccessRole> GetUserAccessInfoForDelete(string Ocode, string UserId)
        {
            return userAccessdal.GetUserAccessInfoForDelete(Ocode, UserId);
        }

        internal int DeleteUserAccessById(string UserAccessId, string Ocode)
        {
            return userAccessdal.DeleteUserAccessById(UserAccessId, Ocode);
        }

        internal List<RUserAccessRole> GetUserAccessInfobyModuleandUserId(string Ocode, string UserId, int moduleId)
        {
            return userAccessdal.GetUserAccessInfobyModuleandUserId(Ocode, UserId, moduleId);

        }

        internal List<RUserAccessRole> GetUserAccessInfobyModuleIdUserIdandFeatureId(string Ocode, string UserId, int moduleId, int featureId)
        {
            return userAccessdal.GetUserAccessInfobyModuleandUserId(Ocode, UserId, moduleId, featureId);
        }

       
        internal List<tbl_UserPassword> GetUserPassword(Guid UserId, string OCode)
        {
            return userAccessdal.GetUserPassword(UserId, OCode);
        }
   
    }
}
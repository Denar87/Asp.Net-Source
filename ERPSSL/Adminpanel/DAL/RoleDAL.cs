using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ERPSSL.AppGateway.DAL;

namespace ERPSSL.Adminpanel.DAL
{
    public class RoleDAL
    {
        DAL.ERPSSL_AdminEntities1 _context = new ERPSSL_AdminEntities1();

        internal List<tbl_UserRole> GetRoles(string Ocode)
        {
            try
            {
                var roles = (from role in _context.tbl_UserRole                              
                               select role);
                return roles.ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        internal int SaveRole(tbl_UserRole userRoleObj)
        {            
                try
                {
                    _context.tbl_UserRole.AddObject(userRoleObj);
                    _context.SaveChanges();
                    return 1;

                }
                catch (Exception)
                {

                    throw;
                }
            }            
        

        internal int UpdateRole(tbl_UserRole userRoleObj, int roleId)
        {

            int rId = Convert.ToInt32(roleId);
            tbl_UserRole roleObj = _context.tbl_UserRole.First(x => x.RoleID == rId);
            roleObj.RoleName = userRoleObj.RoleName;
            roleObj.EditDate = userRoleObj.EditDate;
            roleObj.EditUser = userRoleObj.EditUser;
            _context.SaveChanges();
            return 1;

        }



        internal List<tbl_UserRole> getRoleById(string roleId, string OCODE)
        {

            try
            {
                int rId = Convert.ToInt32(roleId);

                var roles = (from role in _context.tbl_UserRole
                               where  role.RoleID == rId
                               select role);
                return roles.ToList();
            }
            catch (Exception)
            {

                throw;
            }


        }
    }
}
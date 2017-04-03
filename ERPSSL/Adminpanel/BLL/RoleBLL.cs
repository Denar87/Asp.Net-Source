using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ERPSSL.Adminpanel.DAL;

namespace ERPSSL.Adminpanel.BLL
{
    public class RoleBLL
    {
        RoleDAL roleDal = new RoleDAL();
        public List<tbl_UserRole> GetRoles(string Ocode)
        {
            return roleDal.GetRoles(Ocode);
        }
    }
}
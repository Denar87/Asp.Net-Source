using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ERPSSL.INV.DAL;

namespace ERPSSL.INV.BLL
{
      

    public class DepartmentNameBLL
    {
        DepartmentDAL projectdal = new DepartmentDAL();

        internal List<HRM_DEPARTMENTS> GetAllDepartment()
        {
            return projectdal.GetAllDepartment();
        }

    }
}
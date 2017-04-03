using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SSL.FA.DAL;
using System.Data;

namespace ERPSSL.FA.BLL
{
    public class Region_BLL1
    {
        DataAccess dataAccess = new DataAccess();
      //Region....
        internal static DataTable GetAllRegions()
        {
            DataTable dt = new DataTable();
            try
            {
                dt = DataAccess.GetDataBySQLString("select RegionCode, RegionName, UpdateDate from FA_Regions");
            }
            catch { }
            return dt;
        }

        //Department........
        internal static object GetOfficesByRegionCode(string RegionCode)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = DataAccess.GetDataBySQLString("select * from FA_Office where RegionCode = '" + RegionCode + "'");
            }
            catch { }
            return dt;
        }

        //Department.....
        internal static object GetDepartmentsByOfficeCode(string Code)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = DataAccess.GetDataBySQLString("select * from FA_Departments where OfficeCode = '" + Code + "'");
            }
            catch { }
            return dt;
        }

        //User...
        internal static DataTable GetUsersForDropdownByDepartmentCode(string Code)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = DataAccess.GetDataBySQLString("select U.UserId,U.Name+'-'+ U.EmployeeId as CustomUserName from FA_AssetUsers U inner join FA_Departments D on D.DepartmentCode = U.DepartmentCode where D.DepartmentCode = '" + Code + "'");
            }
            catch { }
            return dt;
        }

    }
}
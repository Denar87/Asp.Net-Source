using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SSL.FA.DAL;
using System.Collections;
using System.Data;

namespace ERPSSL.FA.BLL
{
    public class DepartrmentSetup_BLL
    {
         DataAccess dataAccess = new DataAccess();

         internal bool SaveDepartment(Hashtable ht)
        {
            try
            {
                //DataAccess.ExecuteCommand(ht, "FA_HRM_SaveDepartment");
                DataAccess.ExecuteCommand(ht, "FA_SaveDepartment");

                return true;
            }
            catch
            {
                return false;
            }
        }
        //Grid show
         internal object GetallDepartment()
         {
             DataTable dt = new DataTable();
             try
             {
                 dt = DataAccess.GetDataBySQLString("select D.DepartmentCode, D.DepartmentName, O.OfficeName, R.RegionName,D.OfficeCode, D.UpdateDate from FA_Departments D inner join FA_Office O on D.OfficeCode = O.OfficeCode inner join FA_Regions R on R.RegionCode = O.RegionCode");
             }
             catch { }
             return dt;
         }
        
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SSL.FA.DAL;
using System.Collections;
using System.Data;

namespace ERPSSL.FA.BLL
{
    public class UserSetup_BLL
    {
        DataAccess dataAccess = new DataAccess();
        internal bool SaveUser(Hashtable ht)
        {
            try
            {
                //DataAccess.ExecuteCommand(ht, "FA_HRM_SaveDepartment");
                //DataAccess.ExecuteCommand(ht,"FA_SaveAssetsUsers");
                DataAccess.ExecuteCommand(ht, "FA_SaveAssetUser");

                return true;
            }
            catch
            {
                return false;
            }
        }
        //Grid data show
        internal  object GetAllUsers()
        {
            DataTable dt = new DataTable();
            try
            {
                dt = DataAccess.GetDataBySQLString("select U.UserId, U.Name, U.Designation,U.EmployeeId, U.Email, U.Phone, D.DepartmentName, O.OfficeName, R.RegionName, D.UpdateDate from FA_AssetUsers U inner join FA_Departments D on D.DepartmentCode = U.DepartmentCode inner join FA_Office O on D.OfficeCode = O.OfficeCode inner join FA_Regions R on R.RegionCode = O.RegionCode");
            }
            catch { }
            return dt;
        }

        //check exist Employee ID
        public bool EmployeeIdExist(string Code)
        {
            int count = 0;
            try
            {
                count = int.Parse(DataAccess.AggRetrive("select COUNT(EmployeeId) from FA_AssetUsers where EmployeeId = '" + Code + "'").ToString());
                if (count > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return true;
            }

        }

    }
}
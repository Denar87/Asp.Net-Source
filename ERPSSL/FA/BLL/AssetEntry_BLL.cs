using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using SSL.FA.DAL;
using System.Collections;

namespace ERPSSL.FA.BLL
{
    public class AssetEntry_BLL
    {
        //DataAccess dataAccess = new DataAccess();
        //Group ddl
        internal DataTable GetAllGroups()
        {
            DataTable dt = new DataTable();
            try
            {
                dt = DataAccess.GetDataBySQLString("SELECT [GroupCode], [GroupName], Tangibility,[ACDepreciationRate], [TaxDepreciationRate], [UpdateDate] FROM [FA_AssetGroups]");
            }
            catch { }
            return dt;
        }
       
       
        //ddl asset
        internal DataTable GetAssetsForDropdownByGroup(string GroupCode)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = DataAccess.GetDataBySQLString("select  A.AssetId,G.GroupCode+'-'+A.AssetName+'-'+A.Brand+'-'+A.StyleAndSize as CustomAssetName from FA_Assets A inner join FA_AssetGroups G on G.GroupCode = A.GroupCode inner join FA_Units U on U.UnitId = A.UnitId where A.GroupCode ='" + GroupCode + "'");
            }
            catch { }
            return dt;
        }
      
        //get emplyoee id
        internal DataTable GetUserById(string UserId)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = DataAccess.GetDataBySQLString("select U.UserId,U.Name,U.Email,U.Phone,U.Designation,U.EmployeeId, U.DepartmentCode, D.OfficeCode, R.RegionCode from FA_AssetUsers U inner join FA_Departments D on D.DepartmentCode = U.DepartmentCode inner join FA_Office O on O.OfficeCode = D.OfficeCode inner join FA_Regions R on R.RegionCode = O.RegionCode where UserId = '" + UserId + "'");
            }
            catch { }
            return dt;

        }
        //label text show
        internal DataTable GetUserLocationByEmployeeId(string EmployeeId)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = DataAccess.GetDataBySQLString("select top(1) U.UserId, U.Name,D.DepartmentCode,D.DepartmentName,O.OfficeCode,O.OfficeName,R.RegionCode,R.RegionName from FA_AssetUsers U inner join FA_Departments D on D.DepartmentCode = U.DepartmentCode inner join FA_Office O on O.OfficeCode = D.OfficeCode inner join FA_Regions R on R.RegionCode = O.RegionCode where U.EmployeeId = '" + EmployeeId + "'");
            }
            catch { }
            return dt;
        }
        //Maing AssetEntry Save

        //try.......................................................
        internal DataTable GetUserLocationByEmployeeByID(string EmployeeId)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = DataAccess.GetDataBySQLString("select top(1) U.UserId, U.Name,D.DepartmentCode,D.DepartmentName,O.OfficeCode,O.OfficeName,R.RegionCode,R.RegionName from FA_AssetUsers U inner join FA_Departments D on D.DepartmentCode = U.DepartmentCode inner join FA_Office O on O.OfficeCode = D.OfficeCode inner join FA_Regions R on R.RegionCode = O.RegionCode where U.EmployeeId = '" + EmployeeId + "'");
            }
            catch { }
            return dt;
        }

        //.........................................................

        internal  string AddOldAssetToStock(Hashtable ht)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = DataAccess.GetDataByProc(ht, "FA_AddOldASsetToStock");
                string AssetCode = "";
                foreach (DataRow dr in dt.Rows)
                {
                    AssetCode = dr["AssetCode"].ToString();
                }
                return AssetCode;
            }
            catch
            {
                return "";
            }
        }

    }
}
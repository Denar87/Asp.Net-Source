using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SSL.FA.DAL;
using System.Data;
using System.Collections;

namespace ERPSSL.FA.BLL
{
    public class PhysicalVerification_BLL
    {
        DataAccess dataAccess = new DataAccess();
       

        //Grid
        internal  DataTable GetAllStockAssetsByDepartment(string DepartmentCode)
        {
            DataTable dataBySQLString = new DataTable();
            try
            {
                Hashtable ht = new Hashtable();
                ht.Add("DepartmentCode", DepartmentCode);
                dataBySQLString = DataAccess.GetDataBySQLString(ht, "select S.AssetCode,A.AssetName+'-'+A.Brand+'-'+A.StyleAndSize as CustomAssetName, R.RegionName,O.OfficeName, D.DepartmentName, S.IsNotFound from FA_Stock S inner join FA_Assets A on A.AssetId = S.AssetId inner join FA_Regions R on R.RegionCode = S.RegionCode inner join FA_Office O on O.OfficeCode = S.OfficeCode inner join FA_Departments D on D.DepartmentCode = S.DepartmentCode where S.DepartmentCode =@DepartmentCode");
            }
            catch (Exception ex)
            {
                //ErrorLog.Log(ex);
            }
            return dataBySQLString;
        }

        //.....
        internal bool AssetLost(string AssetCode)
        {
            try
            {
                Hashtable htable = new Hashtable();
                htable.Add("AssetCode", AssetCode);
                DataAccess.ExecuteCommand(htable, "FA_ToggleAvailability");
                return true;
            }
            catch (Exception ex)
            {
                //ErrorLog.Log(ex);
                return false;
            }
        }

        internal DataTable GetExtraAssets(string DepartmentCode)
        {
            DataTable dataBySQLString = new DataTable();
            try
            {
                Hashtable ht = new Hashtable();
                ht.Add("DepartmentCode", DepartmentCode);
                dataBySQLString = DataAccess.GetDataBySQLString(ht, "select E.ExtraId, S.AssetCode,A.AssetName+'-'+A.Brand+'-'+A.StyleAndSize as CustomAssetName, R.RegionName,O.OfficeName, D.DepartmentName from FA_Stock S inner join FA_Assets A on A.AssetId = S.AssetId inner join FA_Regions R on R.RegionCode = S.RegionCode inner join FA_Office O on O.OfficeCode = S.OfficeCode inner join FA_Departments D on D.DepartmentCode = S.DepartmentCode inner join FA_ExtraAssets E on E.AssetCode = S.AssetCode where IsReturned = 0 and E.DepartmentCode =@DepartmentCode");
            }
            catch (Exception ex)
            {
                //ErrorLog.Log(ex);

            }
            return dataBySQLString;
        }
        internal  DataTable GetPhotos(string AssetCode)
        {
            DataTable dt = new DataTable();
            try
            {
                Hashtable ht = new Hashtable();
                ht.Add("AssetCode", AssetCode);
                dt = DataAccess.GetDataBySQLString(ht, "select Photo1, Photo2, Photo3 from FA_Stock where AssetCode =@AssetCode");
            }
            catch (Exception ex)
            {
               
            }
            return dt;
        }

        internal DataTable GetAssetInforByAssetCode(string AssetCode)
        {
            Hashtable ht = new Hashtable();
            ht.Add("AssetCode", AssetCode);
            DataTable dt = new DataTable();
            try
            {
                dt = DataAccess.GetDataByProc(ht, "FA_GetAssetInfoByAssetCode");
            }
            catch (Exception ex)
            {
                
            }
            return dt;
        }

        internal bool DeleteExtraAsset(string ExtraId)
        {
            try
            {
                Hashtable ht = new Hashtable();
                ht.Add("ExtraId", ExtraId);
                DataAccess.GetScalar(ht, "delete from FA_ExtraAssets where ExtraId = @ExtraId");
                return true;
            }
            catch (Exception ex)
            {
              
                return false;
            }
        }
        //btn save
        internal bool AddExtraAsset(Hashtable ht)
        {
            try
            {
                DataAccess.ExecuteCommand(ht, "FA_AddExtraAsset");
                return true;
            }
            catch (Exception ex)
            {
               
                return false;
            }
        }


    }
}
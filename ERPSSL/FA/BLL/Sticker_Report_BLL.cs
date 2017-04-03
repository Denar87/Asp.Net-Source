using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SSL.FA.DAL;
using System.Data;

namespace ERPSSL.FA.BLL
{
    public class Sticker_Report_BLL
    {
        DataAccess dataAccess = new DataAccess();
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
      
      
        internal DataTable GetStockAssetsByDepartment(string DepartmentCode)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = DataAccess.GetDataBySQLString("Select S.AssetCode, A.AssetName+' '+A.Brand+' '+A.StyleAndSize as AssetName from FA_Stock S Inner join FA_Assets A on A.AssetId = S.AssetId where S.DepartmentCode = '" + DepartmentCode + "'");
            }
            catch
            {

            }
            return dt;
        }
        internal object GetOfficesByRegionCode(string RegionCode)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = DataAccess.GetDataBySQLString("select * from FA_Office where RegionCode = '" + RegionCode + "'");
            }
            catch { }
            return dt;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using SSL.FA.DAL;

namespace ERPSSL.FA.BLL
{
    public class Register_Report_BLL
    {
        DataAccess dataAccess = new DataAccess();
       
        

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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using SSL.FA.DAL;

namespace ERPSSL.FA.BLL
{
    public class OverallAccountingEntry_BLL
    {
       



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


        ////

    }
}
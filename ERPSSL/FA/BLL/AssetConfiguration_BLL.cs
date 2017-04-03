using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SSL.FA.DAL;
using System.Collections;
using System.Data;

namespace ERPSSL.FA.BLL
{
    public class AssetConfiguration_BLL
    {
        DataAccess dataAccess = new DataAccess();
        //Insert data
        
        internal bool SaveUnit(Hashtable ht)
        {
            try
            {
                DataAccess.ExecuteCommand(ht, "FA_SaveUnit");
                return true;
            }
            catch
            {
                return false;
            }
        }
        //Grid Show


        internal object GetUnit()
        {
            DataTable dt = new DataTable();
            try
            {
                dt = DataAccess.GetDataBySQLString("select UnitId,UnitName,UpdateDate from FA_Units");
            }
            catch { }
            return dt;
        }

  //deleting................

        internal bool UnitDelete(string unitId)
        {
            try
            {
                DataAccess.AggRetrive("delete from FA_Units where UnitId = '" + unitId + "'");
                return true;
            }
            catch
            {
                return false;
            }
        }
        //show data
        internal  DataTable GetUnBiyId(string UnitId)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = DataAccess.GetDataBySQLString("select * from FA_Units where UnitId = '" + UnitId + "'");
            }
            catch { }
            return dt;
        }


        //Asset group bll.......................................................................

        internal bool SaveGroup(Hashtable ht)
        {
            try
            {
                DataAccess.ExecuteCommand(ht, "FA_SaveGroup");
                return true;
            }
            catch
            {
                return false;
            }
        }

        internal bool GroupCodeExist(string Code)
        {
            int count = 0;
            try
            {
                count = int.Parse(DataAccess.AggRetrive("select COUNT(GroupCode) from FA_AssetGroups where GroupCode = '" + Code + "'").ToString());
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

        //row deleting...
        internal  bool DeleteGroup(string GroupCode)
        {
            try
            {
                DataAccess.AggRetrive("delete from FA_AssetGroups where GroupCode = '" + GroupCode + "'");
                return true;
            }
            catch
            {
                return false;
            }
        }
        //data show 
        internal DataTable GetGroupById(string GroupCode)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = DataAccess.GetDataBySQLString("select * from FA_AssetGroups where GroupCode = '" + GroupCode + "'");
            }
            catch { }
            return dt;
        }
        //Asset setup..........
        //Asset SetUp
        //internal DataTable GetAllGroups()
        //{
        //    DataTable dt = new DataTable();
        //    try
        //    {
        //        dt = DataAccess.GetDataBySQLString("SELECT [GroupCode], [GroupName], Tangibility,[ACDepreciationRate], [TaxDepreciationRate], [UpdateDate] FROM [FA_AssetGroups]");
        //    }
        //    catch { }
        //    return dt;
        //}

        internal DataTable GetUnits()
        {
            DataTable dt = new DataTable();
            try
            {
                dt = DataAccess.GetDataBySQLString("SELECT [UnitId], [UnitName], [UpdateDate] FROM [FA_Units]");
            }
            catch { }
            return dt;
        }

        internal bool SaveAsset(Hashtable ht)
        {
            try
            {
                DataAccess.ExecuteCommand(ht, "FA_SaveAsset");
                return true;
            }
            catch
            {
                return false;
            }
        }

        internal DataTable GetAllAssets()
        {
            DataTable dt = new DataTable();
            try
            {
                dt = DataAccess.GetDataBySQLString("select  A.AssetId,G.GroupName, A.AssetName,U.UnitName, A.Brand, A.StyleAndSize, A.UpdateDate from FA_Assets A inner join FA_AssetGroups G on G.GroupCode = A.GroupCode inner join FA_Units U on U.UnitId = A.UnitId");
            }
            catch { }
            return dt;
        }

        internal bool DeleteAsset(string AssetId)
        {
            try
            {
                DataAccess.AggRetrive("delete from FA_Assets where AssetId = '" + AssetId + "'");
                return true;
            }
            catch
            {
                return false;
            }
        }

        internal DataTable GetAssetById(string AssetId)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = DataAccess.GetDataBySQLString("select * from FA_Assets where AssetId= '" + AssetId + "'");
            }
            catch { }
            return dt;
        }
    }
}
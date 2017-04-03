using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SSL.FA.DAL;
using System.Collections;
using System.Data;

namespace ERPSSL.FA.BLL
{
    public class RegionSetup_BLL
    {
        DataAccess dataAccess = new DataAccess();

        internal bool SaveRegion(Hashtable ht)
        {
            try
            {
                //DataAccess.ExecuteCommand(ht, "[FA_Region]");
                //DataAccess.ExecuteCommand(ht, "FA_HRM_SaveRegion");
                DataAccess.ExecuteCommand(ht, "FA_SaveRegion");
                
                return true;
            }
            catch
            {
                return false;
            }
        }

        //
        internal  DataTable GetAllRegions()
        {
            DataTable dt = new DataTable();
            try
            {
                dt = DataAccess.GetDataBySQLString("select RegionCode, RegionName, UpdateDate from FA_Regions");
            }
            catch { }
            return dt;
        }
    }
}
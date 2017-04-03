using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;
using SSL.FA.DAL;
using System.Data;

namespace ERPSSL.FA.BLL
{
    public class OfficeSetup_BLL
    {
        internal static object GetAllOffices()
        {
            DataTable dt = new DataTable();
            try
            {
                dt = DataAccess.GetDataBySQLString("select O.OfficeCode, O.OfficeName, O.OfficeAddress, R.RegionName, O.UpdateDate  from FA_Office O inner join FA_Regions R on R.RegionCode = O.RegionCode");
            }
            catch { }
            return dt;

        }

        internal static bool SaveOffice(Hashtable ht)
        {
            try
            {
                DataAccess.ExecuteCommand(ht, "FA_SaveOffice");
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static string MakeOfficeCode(string RegionCode, string Code)
        {
            return RegionCode + "-" + Code;

        }

        internal static bool OfficeCodeExist(string Code)
        {
            int count = 0;
            try
            {
                count = int.Parse(DataAccess.AggRetrive("select COUNT(OfficeCode) from FA_Office where OfficeCode = '" + Code + "'").ToString());
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

        internal static bool DeleteOffice(string OfficeCode)
        {
            try
            {
                var a = DataAccess.AggRetrive("delete from FA_Office where OfficeCode = '" + OfficeCode + "'");
                return true;
            }
            catch
            {
                return false;
            }
        }


        internal static DataTable GetOfficeById(string OfficeCode)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = DataAccess.GetDataBySQLString("select * from FA_Office where OfficeCode = '" + OfficeCode + "'");
            }
            catch { }
            return dt;
        }


    }
}
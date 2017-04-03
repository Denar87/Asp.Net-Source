using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SSL.FA.DAL;
using System.Collections;
using System.Data;

namespace ERPSSL.FA.BLL
{
    public class Depreciation_BLL
    {

        internal string GetLastDepreciationDate(string OCode)
        {
            string str = "";
            try
            {
                str = DataAccess.AggRetrive("select max(DepDate) from FA_Depreciations where OCode='" + OCode + "'").ToString();
            }
            catch
            {
            }
            return str;
        }

        public bool CalculateDepreciation(string type, DateTime UpToDate, string OCode, string SystemUserId)
        {
            try
            {
                Hashtable htable = new Hashtable();
                htable.Add("Type", type);
                htable.Add("UpToDate", UpToDate.ToShortDateString());
                htable.Add("OCode", OCode);
                htable.Add("SystemUserId", SystemUserId);
                DataAccess.ExecuteCommand(htable, "FA_CalculateDepreciation");
                return true;
            }
            catch
            {
                return false;
            }
        }

        //Undo Depreciation
        internal DataTable GetDepreciationDataToDelete(DateTime FromDate)
        {
            DataTable dataBySQLString = new DataTable();
            try
            {
                dataBySQLString = DataAccess.GetDataBySQLString("SELECT [AssetCode], [DepDate], [TDesc], [XDepreciationRate], [XACClosingBalance], [XADDepreciationCost], [TADDepreciationCost] FROM [FA_Depreciations] where DepDate >='" + FromDate + "'");
            }
            catch
            {
            }
            return dataBySQLString;
        }

        internal bool EraseDepreciation(DateTime FromDate)
        {
            try
            {
                DataAccess.AggRetrive("delete from FA_Depreciations where DepDate >= '" + FromDate + "'");
                return true;
            }
            catch
            {
                return false;
            }
        }


    }
}
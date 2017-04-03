using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Collections;
using SSL.FA.DAL;

namespace SSL.FA.BLL
{
    public class ReportsBll
    {
        DataAccess dataAccess = new DataAccess();
        internal static DataSet AssetRegister(Hashtable ht, string SummaryOrIndivudual)
        {
            DataSet ds = new DataSet();
            try
            {
                if (SummaryOrIndivudual == "IndividualItem")
                {
                    ds = DataAccess.GetDataSetByProc(ht, "FA_RegisterByAssetCode_RPT");
                }
                else if (SummaryOrIndivudual == "Summary")
                {
                    ds = DataAccess.GetDataSetByProc(ht, "FA_RegisterByGroup_RPT");
                }
            }
            catch (Exception ex)
            {
                //ErrorLog.Log(ex);
            }
            return ds;
        }

        internal static DataSet AssetSchedule(Hashtable ht)
        {
            DataSet ds = new DataSet();
            try
            {
                ds = DataAccess.GetDataSetByProc(ht, "FA_Schedule_RPT");
            }
            catch (Exception ex)
            {
                //ErrorLog.Log(ex);
            }
            return ds;
        }

        internal static DataSet AssetStickers(Hashtable ht)
        {
            DataSet ds = new DataSet();
            try
            {
                ds = DataAccess.GetDataSetByProc(ht, "FA_Stickers_RPT");
            }
            catch (Exception ex)
            {
                //ErrorLog.Log(ex);
            }
            return ds;
        }

        internal DataSet GetTransferVoucher(Hashtable ht)
        {
            DataSet ds = new DataSet();
            try
            {
                ds = DataAccess.GetDataSetByProc(ht, "FA_SingleTransfer_RPT");
            }
            catch (Exception ex)
            {
                //ErrorLog.Log(ex);
            }
            return ds;  
        }
        internal static DataSet OverallAccountingEntry(Hashtable ht)
        {
            DataSet dataSetByProc = new DataSet();
            try
            {
                dataSetByProc = DataAccess.GetDataSetByProc(ht, "FA_OverallAccountingEntries_RPT");
            }
            catch (Exception ex)
            {
                //ErrorLog.Log(ex);
            }
            return dataSetByProc;
        }
    }
}
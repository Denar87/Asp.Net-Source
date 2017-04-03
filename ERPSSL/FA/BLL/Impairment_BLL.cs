using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using SSL.FA.DAL;
using System.Collections;

namespace ERPSSL.FA.BLL
{
    public class Impairment_BLL
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

        internal object GetAssetsByUser(string UserId)
        {
            DataTable dt = new DataTable();
            try
            {
                Hashtable ht = new Hashtable();
                ht.Add("UserId", UserId);
                dt = DataAccess.GetDataBySQLString("Select S.AssetCode, A.AssetName+' '+A.Brand+' '+A.StyleAndSize as AssetName from FA_Stock S Inner join FA_Assets A on A.AssetId = S.AssetId where S.UserId =@UserId");
            }
            catch (Exception ex)
            {
                //ErrorLog.Log(ex);
            }
            return dt;
        }

        //..................

        internal DataTable GetAssetInforByAssetCode(string AssetCode)
        {
            Hashtable ht = new Hashtable();
            ht.Add("AssetCode", AssetCode);
            DataTable dt = new DataTable();
            try
            {
                dt = DataAccess.GetDataByProc(ht, "FA_GetAssetInfoByAssetCode");
            }
            catch { }
            return dt;
        }

        internal bool IsDisposed(string AssetCode)
        {
            try
            {
                int count = int.Parse(DataAccess.AggRetrive("select COUNT(DisposalId) from FA_Disposals where AssetCode = '" + AssetCode + "'").ToString());
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
                return false;
            }
        }

        public Int64 GetCurrentBalanceByAssetCode(string AssetCode)
        {
            Int64 Balance = 0;
            try
            {
                Balance = Convert.ToInt64(DataAccess.AggRetrive("select XACClosingBalance from FA_Depreciations where AssetCode = '" + AssetCode + "' and DepDate =(select MAX(DepDate) from FA_Depreciations where AssetCode ='" + AssetCode + "')"));
            }
            catch { }

            return Balance;
        }

        internal DataTable GetCurrentStatusByAssetCode(string AssetCode)
        {
            Hashtable ht = new Hashtable();
            ht.Add("AssetCode", AssetCode);
            DataTable dt = new DataTable();
            try
            {
                dt = DataAccess.GetDataBySQLString("select XACClosingBalance, XADClosingBalance, XRRClosingBalance, XACDepMethod, TACClosingBalance, TADClosingBalance, TRRClosingBalance, TACDepMethod from FA_Depreciations where AssetCode = '" + AssetCode + "' and DepDate =(select MAX(DepDate) from FA_Depreciations where AssetCode ='" + AssetCode + "')");

            }
            catch { }
            return dt;
        }

        //add..........
        internal bool AddImpairment(Hashtable ht)
        {
            try
            {
                DataAccess.ExecuteCommand(ht, "FA_AddImpairment");
                return true;
            }
            catch
            {
                return false;
            }
        }

     
    }
}
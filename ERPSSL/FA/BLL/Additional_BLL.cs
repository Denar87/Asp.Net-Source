using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using SSL.FA.DAL;
using System.Collections;

namespace ERPSSL.FA.BLL
{
    public class Additional_BLL
    {
        DataAccess dataAccess = new DataAccess();
     
        internal object GetStockAssetsByUser(string UserId)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = DataAccess.GetDataBySQLString("Select S.AssetCode, A.AssetName+' '+A.Brand+' '+A.StyleAndSize as AssetName from FA_Stock S Inner join FA_Assets A on A.AssetId = S.AssetId where S.UserId = '" + UserId + "'");
            }
            catch
            {

            }
            return dt;
        }
        //get asset info details .....................................................
        internal  DataTable GetAssetInforByAssetCode(string AssetCode)
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
        //.....
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
        //...
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
        //....
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
        //....
        internal decimal GetCurrentResidualCostByAssetCode(string AssetCode)
        {
            decimal Balance = 0;
            try
            {
                Hashtable ht = new Hashtable();
                ht.Add("AssetCode", AssetCode);
                string value = DataAccess.GetScalar(ht, "select ReschedualCost from FA_Stock where AssetCode =@AssetCode").ToString();
                Balance = Convert.ToDecimal(value);
            }
            catch (Exception ex)
            {
                //ErrorLog.Log(ex);

            }

            return Balance;
        }
        //Save ......................................
        internal  bool IsBackDate(DateTime TransactionDate)
        {
            try
            {
                Hashtable ht = new Hashtable();
                ht.Add("TransactionDate", TransactionDate);
                return (int.Parse(DataAccess.GetScalar(ht, "select count(DepId) from FA_Depreciations where DepDate >= @TransactionDate").ToString()) > 0);
            }
            catch (Exception ex)
            {
                //ErrorLog.Log(ex);
                return false;
            }
        }

        internal bool AddAddition(Hashtable ht)
        {
            try
            {
                DataAccess.ExecuteCommand(ht, "FA_Addition");
                return true;
            }
            catch (Exception ex)
            {
                //ErrorLog.Log(ex);
                return false;
            }
        }

        //
        internal  DataTable GetStockAssetsByDepartment(string DepartmentCode)
        {
            DataTable dt = new DataTable();
            try
            {
                Hashtable ht = new Hashtable();
                ht.Add("DepartmentCode", DepartmentCode);
                dt = DataAccess.GetDataBySQLString(ht, "Select S.AssetCode, A.AssetName+' '+A.Brand+' '+A.StyleAndSize as AssetName from FA_Stock S Inner join FA_Assets A on A.AssetId = S.AssetId where S.DepartmentCode =@DepartmentCode");
            }
            catch (Exception ex)
            {
                //ErrorLog.Log(ex);
            }
            return dt;
        }

    }
}
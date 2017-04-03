using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using SSL.FA.DAL;
using System.Collections;

namespace ERPSSL.FA.BLL
{
    public class Transfer_BLL
    {
        DataAccess dataAccess = new DataAccess();
       
        //Generate Transfer No..................................................
        public string GetNewTransferNo(DateTime TransferDate)
        {
            string str = "TR" + TransferDate.Year.ToString() + TransferDate.Month.ToString() + TransferDate.Day.ToString();
            int num = 0;
            try
            {
                num = int.Parse(DataAccess.AggRetrive("select COUNT(TransferNo) from FA_Transfer where TransferDate = '" + TransferDate + "'").ToString()) + 1;
                str = str + num.ToString().PadLeft(3, '0');
            }
            catch
            {
            }
            return str;
        }

        //For Grid Data Show ............................
        internal DataTable GetAssets(string Code, string OwnerType)
        {
            DataTable dt = new DataTable();

            Hashtable ht = new Hashtable();
            ht.Add("Code", Code);
            string query = string.Empty;

            try
            {
                if (OwnerType == "Region")
                {
                    query = "select S.AssetCode, A.AssetName+' '+A.Brand+' '+A.StyleAndSize as AssetName, G.GroupName from FA_Stock S " +
                            "inner join FA_Assets A on A.AssetId = S.AssetId " +
                            "inner join FA_AssetGroups G on G.GroupCode= A.GroupCode ";
                    query = query + " where S.RegionCode = @Code";
                }
                else if (OwnerType == "Office")
                {
                    query = "select S.AssetCode, A.AssetName+' '+A.Brand+' '+A.StyleAndSize as AssetName, G.GroupName,O.OfficeName from FA_Stock S " +
                            "inner join FA_Assets A on A.AssetId = S.AssetId " +
                            "inner join FA_AssetGroups G on G.GroupCode= A.GroupCode " +
                            "inner join FA_Office O on O.OfficeCode = S.OfficeCode ";
                    query = query + " where O.OfficeCode = @Code";
                }
                else if (OwnerType == "Department")
                {
                    query = "select S.AssetCode, A.AssetName+' '+A.Brand+' '+A.StyleAndSize as AssetName, G.GroupName,O.OfficeName, D.DepartmentName from FA_Stock S " +
                            "inner join FA_Assets A on A.AssetId = S.AssetId " +
                            "inner join FA_AssetGroups G on G.GroupCode= A.GroupCode " +
                            "inner join FA_Departments D on D.DepartmentCode = S.DepartmentCode " +
                            "inner join FA_Office O on O.OfficeCode = S.OfficeCode ";
                    query = query + " where D.DepartmentCode = @Code";
                }
                else if (OwnerType == "User")
                {
                    query = "select S.AssetCode, A.AssetName+' '+A.Brand+' '+A.StyleAndSize as AssetName, G.GroupName,O.OfficeName, D.DepartmentName from FA_Stock S " +
                            "inner join FA_Assets A on A.AssetId = S.AssetId " +
                            "inner join FA_AssetGroups G on G.GroupCode= A.GroupCode " +
                            "inner join FA_Departments D on D.DepartmentCode = S.DepartmentCode " +
                            "inner join FA_Office O on O.OfficeCode = S.OfficeCode ";
                    query = query + " where S.UserId = @Code";
                }

                dt = DataAccess.GetDataBySQLString(ht,query);
            }
            catch (Exception ex)
            {
                //ErrorLog.Log(ex);

            }
            return dt;
        }


        //Transfer Grid..................................
        internal  bool SetAssetListToTransfer(Hashtable ht)
        {
            try
            {
                DataAccess.GetDataByProc(ht, "FA_GetSetAssetListToTransfer");
                return true;
            }
            catch
            {
                return false;
            }
        }
        //transfer..
        internal DataTable GetAssetListToTransfer(string SystemUserId)
        {
            DataTable dataBySQLString = new DataTable();
            try
            {
                dataBySQLString = DataAccess.GetDataBySQLString("select S.AssetCode, A.AssetName+' '+A.Brand+' '+A.StyleAndSize as AssetName, G.GroupName from FA_Transfer_Tmp T inner join FA_Stock S on S.AssetCode = T.AssetCode inner join FA_Assets A on A.AssetId = S.AssetId inner join FA_AssetGroups G on G.GroupCode= A.GroupCode where T.SystemUserId = '" + SystemUserId + "'");
            }
            catch
            {
            }
            return dataBySQLString;
        }

        //...................................................................

        internal bool RemoveItemFromAssetListToTransfer(string AssetCode)
        {
            try
            {
                DataAccess.AggRetrive("delete from FA_Transfer_Tmp where AssetCode = '" + AssetCode + "'");
                return true;
            }
            catch
            {
                return false;
            }
        }
        //Clear Temp

        internal bool ClearTemp(string SystemUserId)
        {
            try
            {
                DataAccess.AggRetrive("delete from FA_Transfer_Tmp where SystemUserId = '" + SystemUserId + "'");
                return true;
            }
            catch
            {
                return false;
            }
        }

        //Main Transfer.............
        internal bool Transfer(Hashtable ht, List<string> AssetList, DateTime TransferDate, string ToRegionCode, string ToOfficeCode, string ToDepartmentCode, string ToUserId)
        {
            try
            {
                int num = 0;
                foreach (string str in AssetList)
                {
                    ht["AssetCode"] = str;
                    try
                    {
                        DataAccess.ExecuteCommand(ht, "FA_TransferSingleAsset");
                        num++;
                    }
                    catch
                    {
                    }
                }
                string str2 = ht["TransferNo"].ToString();
                string str3 = ht["OCode"].ToString();
                string str4 = ht["SystemUserId"].ToString();

                Hashtable ht2 = new Hashtable();
                ht2.Add("str2", str2);
                ht2.Add("TransferDate", TransferDate);
                ht2.Add("ToRegionCode", ToRegionCode);
                ht2.Add("ToOfficeCode", ToOfficeCode);
                ht2.Add("ToDepartmentCode", ToDepartmentCode);
                ht2.Add("ToUserId", ToUserId);
                ht2.Add("num", num);
                ht2.Add("str3", str3);
                ht2.Add("str4", str4);
                DataAccess.GetScalar(ht2, string.Concat(new object[] { 
                    "INSERT INTO [FA_Transfer]([TransferNo],[TransferDate],ToRegionCode, ToOfficeCode, ToDepartmentCode, ToUserId,[TotalAssetTransfered],[OCode] ,[SystemUserId]) values(@str2,@TransferDate,@ToRegionCode,@ToOfficeCode,@ToDepartmentCode,@ToUserId,@num,@str3,@str4)"}));
                return true;
            }
            catch (Exception ex)
            {
                //ErrorLog.Log(ex);
                return false;
            } 
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ERPSSL.INV.DAL;
using System.Data;
using System.Configuration;
using System.Collections;

namespace ERPSSL.INV.BLL
{
    public class RChallanBLL
    {
        private ERPSSL_INVEntities _context = new ERPSSL_INVEntities();
        DataAccessEX ado = new DataAccessEX();
        string conn = ConfigurationManager.ConnectionStrings["ERPSSLADO"].ConnectionString;

        RChallanDAL rChallanDal = new RChallanDAL();

        //internal string GetNewChalanId(string supCode, string date)
        //{

         
        //    int maxid = 0;
        //    try
        //    {
        //        maxid = int.Parse(ado.AggRetrive("select COUNT(*) from Inv_RChallan where SupplierId = '" + supCode + "' and EditDate = '" + date + "'", conn).ToString());
        //    }
        //    catch
        //    {
        //    }
        //    return (maxid + 1).ToString();
        //}

        internal DataTable GetVoucherReport(string challanNo, string Ocode)
        {
            DataTable dt = new DataTable();
            try
            {
                Hashtable ht = new Hashtable();
                ht.Add("ChallanNo", challanNo);
                ht.Add("OCode", Ocode);
                dt = ado.GetDataByProc(ht, "INV_PurchaseVoucher_RPT", conn);
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //Store Rpt
        internal DataTable GetStoreRequisitionRPT(string ReqNo, string Ocode)
        {
            DataTable dt = new DataTable();
            try
            {
                Hashtable ht = new Hashtable();
                ht.Add("ReqNo", ReqNo);
                ht.Add("OCode", Ocode);
                dt = ado.GetDataByProc(ht, "PRQ_StoreRequisitions_RPT", conn);
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //
        public string GetNewRChalanNo(string supCode, DateTime day)
        {
            int maxid;
            day = DateTime.Now;
            string challanNo = supCode + day.Year + day.Month + day.Day + day.Hour + day.Minute;

            try
            {
                maxid = int.Parse(ado.AggRetrive("select COUNT(*) from Inv_RChallan where SupplierCode = '" + supCode + "' and PurchaseDate = '" + day + "'", conn).ToString());
                challanNo += (maxid + 1).ToString();
                return challanNo;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal int Insert(Inv_RChallan_Temp purchase)
        {
            return rChallanDal.Insert(purchase);
        }

        internal int Insert(Inv_RChallan rChallanObj)
        {
            return rChallanDal.Insert(rChallanObj);
        }

        internal void DeleteTempChalanById(int id)
        {
            try
            {
                ado.AggRetrive("delete from Inv_RChallan_Temp where Id = " + id, conn);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal DataTable OldChallan(string challanNo, string Ocode)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = ado.GetDataBySQLString("select * from Inv_RChallan_Temp as T inner join Inv_Company as C on C.CompanyId = T.CompanyId where T.ChallanNo ='" + challanNo + "' and  T.OCode = '" + Ocode + "'", conn);
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal DataTable GetOldUnPostedChallan(string Ocode)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = ado.GetDataBySQLString("select distinct ChallanNo from Inv_RChallan_Temp where OCode = '" + Ocode + "'", conn);
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            //List<Inv_RChallan_Temp> list = new List<Inv_RChallan_Temp>();
            //using (ERPSSL_INVEntities ctx = new ERPSSL_INVEntities())
            //{

            //    try
            //    {
            //        // ctx.Configuration.ProxyCreationEnabled = false;
            //        list = (from c in ctx.Inv_RChallan_Temp
            //                where c.Ocode == Ocode
            //                select c).ToList();
            //    }
            //    catch 
            //    {


            //    }
            //    return list;
            //}
        }

        internal DataTable GetRChalanTemp(string ocode, string challanNo)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = ado.GetDataBySQLString("select * from Inv_RChallan_Temp as T inner join Inv_ProductGroup as G on G.GroupId = T.ProductGroup inner join Inv_Product as P on P.ProductId=T.ProductId where T.ChallanNo ='" + challanNo + "' and  T.OCode = '" + ocode + "'", conn);
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal List<Inv_RChallan_Temp> GetTempRChalan(string p, string challanNo)
        {
            List<Inv_RChallan_Temp> list = new List<Inv_RChallan_Temp>();
            using (ERPSSL_INVEntities ctx = new ERPSSL_INVEntities())
            {
                try
                {
                    // ctx.Configuration.ProxyCreationEnabled = false;
                    list = (from c in ctx.Inv_RChallan_Temp
                            //join r in ctx.Inv_ProductGroup on c.ProductGroup equals r.GroupId
                            where c.OCode == p && c.ChallanNo == challanNo
                            select c).ToList();
                    return list;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
        internal List<Inv_Damage_Temp> GetTempDanmage(string p, string challanNo)
        {
            List<Inv_Damage_Temp> list = new List<Inv_Damage_Temp>();
            using (ERPSSL_INVEntities ctx = new ERPSSL_INVEntities())
            {
                try
                {
                    // ctx.Configuration.ProxyCreationEnabled = false;
                    list = (from c in ctx.Inv_Damage_Temp
                            //join r in ctx.Inv_ProductGroup on c.ProductGroup equals r.GroupId
                            where c.OCode == p && c.ChallanNo == challanNo
                            select c).ToList();
                    return list;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
        internal List<Inv_Return_Temp> GetTempReturn(string p, Guid userId)
        {
            List<Inv_Return_Temp> list = new List<Inv_Return_Temp>();
            using (ERPSSL_INVEntities ctx = new ERPSSL_INVEntities())
            {
                try
                {
                    // ctx.Configuration.ProxyCreationEnabled = false;
                    list = (from c in ctx.Inv_Return_Temp
                            //join r in ctx.Inv_ProductGroup on c.ProductGroup equals r.GroupId
                            where c.OCode == p && c.EditUser == userId
                            select c).ToList();
                    return list;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
        internal int Enter_VoucherDetails(string OCODE, string Company_Code, string Edit_User, string ModuleName, string ModuleType, string VoucherType, string Identity, Inv_RChallan rChallan_Obj)
        {
            return rChallanDal.Enter_VoucherDetails(OCODE, Company_Code, Edit_User, ModuleName, ModuleType, VoucherType, Identity, rChallan_Obj);
        }

        internal List<Inv_RChallan_Temp> GetDataByInv_RChallan_Temp(string ChallanNo, string barcode, string OCODE)
        {
            return rChallanDal.GetDataByInv_RChallan_Temp(ChallanNo, barcode, OCODE);
        }
        internal int UpdateInv_RChallan_Temp(string ChallanNo, string barcode, double receiveQty)
        {
            return rChallanDal.UpdateInv_RChallan_Temp(ChallanNo, barcode, receiveQty);
        }

        internal int UpdateInv_RChallanmrr_Temp(string ChallanNo, string barcode, double receiveQty,double ActualQty,double freeQty, DateTime PDate)
        {
            return rChallanDal.UpdateInv_RChallanmrr_Temp(ChallanNo, barcode, receiveQty, ActualQty, freeQty, PDate);
        }

        internal List<Inv_RChallan_Temp> GetInv_RChallan_Temp(int id)
        {
            return rChallanDal.GetInv_RChallan_Temp(id);
        }
        internal List<Inv_RChallan> GetInv_RChallan(string ocode)
        {
            return rChallanDal.GetInv_RChallan(ocode);
        }
        internal List<Inv_RChallan> GetInv_RChallanById(int id)
        {
            return rChallanDal.GetInv_RChallanById(id);
        }
        internal int Update_Rchallan(int Id, string OrderNo)
        {
            return rChallanDal.Update_Rchallan(Id, OrderNo);
        }

        internal List<Inv_RChallan_Temp> GetPurchaseGrid(string challanNo, string OCode)
        {
            return rChallanDal.GetPurchaseGrid(challanNo, OCode);
        }

        internal List<Inv_RChallan_Temp> GetPurchaseGridLoad(string challanNo, string OCode)
        {
            return rChallanDal.GetPurchaseGridLoad(challanNo, OCode);
        }

        internal int UpdateBuyCentral(Inv_BuyCentral purchase, int pId)
        {
            return rChallanDal.UpdateBuyCentral(purchase, pId);
        }

        internal int UpdateInv_MRRRChallan_Temp(string ChallanNo,int Id, Inv_RChallan_Temp purchase)
        {
            return rChallanDal.UpdateInv_MRRRChallan_Temp(ChallanNo,Id, purchase);
        }
    }
}
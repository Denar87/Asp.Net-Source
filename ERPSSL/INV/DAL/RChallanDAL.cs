using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ERPSSL.INV.DAL;
using System.Data.SqlClient;

namespace ERPSSL.INV.DAL
{
    public class RChallanDAL
    {
        private ERPSSL_INVEntities _context = new ERPSSL_INVEntities();


        internal int Insert(Inv_RChallan_Temp purchase)
        {
            try
            {
                _context.Inv_RChallan_Temp.AddObject(purchase);
                _context.SaveChanges();
                return 1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        } 

        public List<Inv_RChallan_Temp> GetDataByInv_RChallan_Temp(string ChallanNo, string barcode, string OCODE)
        {
            try
            {
                var groups = (from grp in _context.Inv_RChallan_Temp
                              where grp.ChallanNo == ChallanNo && grp.BarCode == barcode && grp.OCode == OCODE
                              select grp).OrderBy(x => x.Id);
                return groups.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }


        public int UpdateInv_RChallan_Temp(string ChallanNo, string barcode, double receiveQty)
        {
            try
            {
                using (var _context = new ERPSSL_INVEntities())
                {
                    var Parma1 = new SqlParameter("@ChallanNo", ChallanNo);
                    var Param2 = new SqlParameter("@BarCode", barcode);
                    var Param3 = new SqlParameter("@ReceiveQuantity", receiveQty);
                    //var Param5 = new SqlParameter("@ChalanTotal", total);

                    string SP_SQL = "Inv_RChallan_Temp_Update @ChallanNo,@BarCode";
                    _context.ExecuteStoreCommand(SP_SQL, Parma1, Param2, Param3 );
                    return 1;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        public int UpdateInv_RChallanmrr_Temp(string ChallanNo, string barcode, double receiveQty, double ActualQty, double freeQty, DateTime PDate)
        {
            try
            {
                using (var _context = new ERPSSL_INVEntities())
                {
                    var Parma1 = new SqlParameter("@ChallanNo", ChallanNo);
                    var Param2 = new SqlParameter("@BarCode", barcode);
                    var Param3 = new SqlParameter("@ReceiveQuantity", receiveQty);
                    var PurDate = new SqlParameter("@PurchaseDate", PDate);
                    var Param4 = new SqlParameter("@ActualQty", ActualQty);
                    var Param5 = new SqlParameter("@FreeQty", freeQty);

                    string SP_SQL = "Inv_RChallan_Tempmrr_Update @ChallanNo,@BarCode,@ReceiveQuantity,@ActualQty,@FreeQty,@PurchaseDate";
                    _context.ExecuteStoreCommand(SP_SQL, Parma1, Param2, Param3,Param4,Param5, PurDate);
                    return 1;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        internal int Insert(Inv_RChallan rChallan_Obj)
        {
            try
            {
                _context.Inv_RChallan.AddObject(rChallan_Obj);
                _context.SaveChanges();
                return 1;
            }
            catch (Exception)
            {
                throw;
            }
        }

        internal int Enter_VoucherDetails(string OCODE, string Company_Code, string Edit_User, string ModuleName, string ModuleType, string VoucherType, string IdentitiNo, Inv_RChallan rChallan_Obj)
        {
            try
            {
                decimal Amount = 0;
                Amount = Convert.ToDecimal(Amount) + (Convert.ToDecimal(rChallan_Obj.CPU) * Convert.ToDecimal(rChallan_Obj.ReceiveQuantity));

                var Amount_ = new SqlParameter("@Amount", Amount);
                var ModuleName_ = new SqlParameter("@ModuleName", ModuleName);
                var VoucherType_ = new SqlParameter("@VoucherType", VoucherType);
                var Edit_User_ = new SqlParameter("@Edit_User", Edit_User);
                var Company_Code_ = new SqlParameter("@Company_Code", Company_Code);
                var OCode_ = new SqlParameter("@OCode", OCODE);
                var ItemCode_ = new SqlParameter("@ItemCode", ModuleType);
                var Identity = new SqlParameter("@IdentificationNo", IdentitiNo);

                string SP_SQL = "Vch_Enter_AC_VoucherDetails_by_Module  @Amount,@ModuleName,@VoucherType,@Edit_User,@Company_Code,@OCode,@ItemCode,@IdentificationNo";
                return (_context.ExecuteStoreCommand(SP_SQL, Amount_, ModuleName_, VoucherType_, Edit_User_, Company_Code_, OCode_, ItemCode_, Identity));

            }
            catch (Exception)
            {
                throw;
            }
        }


        internal List<Inv_RChallan_Temp> GetInv_RChallan_Temp(int id)
        {
            try
            {
                var companys = (from comp in _context.Inv_RChallan_Temp
                                where comp.Id == id
                                select comp);
                return companys.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }
        internal List<Inv_RChallan> GetInv_RChallanById(int id)
        {
            try
            {
                var companys = (from comp in _context.Inv_RChallan
                                where comp.Id == id
                                select comp);
                return companys.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        internal List<Inv_RChallan> GetInv_RChallan(string ocode)
        {
            try
            {
                var companys = (from comp in _context.Inv_RChallan
                                where comp.Ocode == ocode && comp.OrderNo == ""
                                select comp);
                return companys.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }
        internal int Update_Rchallan(int Id, string OrderNo)
        {
            try
            {
                Inv_RChallan prodObj = _context.Inv_RChallan.First(x => x.Id == Id);
                prodObj.OrderNo = OrderNo;
                _context.SaveChanges();
                return 1;
            }
            catch (Exception)
            {
                throw;
            }
        }

        internal List<Inv_RChallan_Temp> GetPurchaseGrid(string challanNo, string OCode)
        {
            try
            {
                var pus = (from po in _context.Inv_RChallan_Temp
                           where po.ChallanNo==challanNo && po.OCode==OCode
                           select po).OrderBy(x => x.ProductId);
                return pus.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal List<Inv_RChallan_Temp> GetPurchaseGridLoad(string challanNo, string OCode)
        {
            try
            {
                var pus = (from po in _context.Inv_RChallan_Temp
                           where po.ChallanNo == challanNo
                           select po).OrderBy(x => x.ProductId);
                return pus.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal int UpdateBuyCentral(Inv_BuyCentral purchase, int pId)
        {
            try
            {
                Inv_BuyCentral prodObj = _context.Inv_BuyCentral.First(x => x.Id == pId);

                prodObj.Store_Id = purchase.Store_Id;
                prodObj.SupplierCode = purchase.SupplierCode;
                prodObj.RefNo_ChallanNo = purchase.RefNo_ChallanNo;
                //prodObj.SeasonID = purchase.SeasonID;
                prodObj.OrderEId = purchase.OrderEId;
                prodObj.PurchaseDate = purchase.PurchaseDate;
                prodObj.ChallanNo = purchase.ChallanNo;
                prodObj.MasterLCNo = purchase.MasterLCNo;
                prodObj.B2BLCNo = purchase.B2BLCNo;
                prodObj.PI_No = purchase.PI_No;
                _context.SaveChanges();
                return 1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal int UpdateInv_MRRRChallan_Temp(string ChallanNo,int Id, Inv_RChallan_Temp purchase)
        {
            try
            {
                Inv_RChallan_Temp RchallanObj = _context.Inv_RChallan_Temp.First(x => x.ChallanNo==ChallanNo && x.Id==Id);

                RchallanObj.ProductGroup = purchase.ProductGroup;
                RchallanObj.ProductId = purchase.ProductId;
                RchallanObj.ProductName = purchase.ProductName;
                RchallanObj.ReceiveQuantity = purchase.ReceiveQuantity;
                RchallanObj.ActualQty = purchase.ActualQty;
                RchallanObj.Free_Qty = purchase.Free_Qty;
                RchallanObj.Actual_Amount = purchase.Actual_Amount;
                RchallanObj.FreeQty_Amount = purchase.FreeQty_Amount;
                RchallanObj.UnitName = purchase.UnitName;
                RchallanObj.Brand = purchase.Brand;
                RchallanObj.FrmCurrency = purchase.FrmCurrency;
                RchallanObj.CPU = purchase.CPU;
                RchallanObj.TotalPrice = purchase.TotalPrice;
                RchallanObj.ToCurrency = purchase.ToCurrency;
                RchallanObj.Rate = purchase.Rate;
                RchallanObj.TotalAppCost = purchase.TotalAppCost;
                RchallanObj.Store_Code = purchase.Store_Code;
                RchallanObj.SupplierCode = purchase.SupplierCode;
                RchallanObj.RefNo_ChallanNo = purchase.RefNo_ChallanNo;
                RchallanObj.SeasonID = purchase.SeasonID;
                RchallanObj.OrderEId = purchase.OrderEId;
                RchallanObj.MasterLCNo = purchase.MasterLCNo;
                RchallanObj.PI_No = purchase.PI_No;
                RchallanObj.B2BLCNo = purchase.B2BLCNo;
                RchallanObj.BarCode = purchase.BarCode;
                RchallanObj.BalanceQuanity = purchase.BalanceQuanity;
                RchallanObj.PurchaseDate = purchase.PurchaseDate;

                _context.SaveChanges();
                return 1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
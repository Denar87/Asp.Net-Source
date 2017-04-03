using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ERPSSL.INV.DAL;
using ERPSSL.INV.DAL.Repository;

namespace ERPSSL.INV.DAL
{
    public class BuyCentralDal
    {
        private ERPSSL_INVEntities _context = new ERPSSL_INVEntities();

        internal int Insert(Inv_BuyCentral inv_BuyCentralObj)
        {
            try
            {
                _context.Inv_BuyCentral.AddObject(inv_BuyCentralObj);
                _context.SaveChanges();
                return 1;
            }
            catch (Exception)
            {
                throw;
            }
        }

        internal int Update(int Id, Inv_BuyCentral inv_BuyCentralObj)
        {
            try
            {
                Inv_BuyCentral buyCentralObj = _context.Inv_BuyCentral.First(x => x.Id == Id);
                buyCentralObj.ChallanNo = inv_BuyCentralObj.ChallanNo;
                buyCentralObj.CompanyId = inv_BuyCentralObj.CompanyId;
                buyCentralObj.CompanyCode = inv_BuyCentralObj.CompanyCode;
                buyCentralObj.CompanyName = inv_BuyCentralObj.CompanyName;
                buyCentralObj.PurchaseDate = inv_BuyCentralObj.PurchaseDate;
                buyCentralObj.BarCode = inv_BuyCentralObj.BarCode;
                buyCentralObj.ProductId = inv_BuyCentralObj.ProductId;
                buyCentralObj.ProductGroup = inv_BuyCentralObj.ProductGroup;
                buyCentralObj.ProductName = inv_BuyCentralObj.ProductName;
                buyCentralObj.Brand = inv_BuyCentralObj.Brand;
                buyCentralObj.StyleSize = inv_BuyCentralObj.StyleSize;
                buyCentralObj.FloorName = inv_BuyCentralObj.FloorName;
                buyCentralObj.UnitName = inv_BuyCentralObj.UnitName;
                buyCentralObj.ReceiveQuantity = inv_BuyCentralObj.ReceiveQuantity;
                buyCentralObj.ActualQty = inv_BuyCentralObj.ActualQty;
                buyCentralObj.Free_Qty = inv_BuyCentralObj.Free_Qty;
                buyCentralObj.CPU = inv_BuyCentralObj.CPU;
                buyCentralObj.PI_No = inv_BuyCentralObj.PI_No;
                buyCentralObj.RPU = inv_BuyCentralObj.RPU;
                buyCentralObj.ExpireDate = inv_BuyCentralObj.ExpireDate;
                buyCentralObj.BalanceQuanity =inv_BuyCentralObj.BalanceQuanity;
                buyCentralObj.PurchaseDate = inv_BuyCentralObj.PurchaseDate;
                buyCentralObj.EditDate = inv_BuyCentralObj.EditDate;
                buyCentralObj.OCode = inv_BuyCentralObj.OCode;
                buyCentralObj.Item_Remarks = inv_BuyCentralObj.Item_Remarks;
                _context.SaveChanges();
                return 1;

            }
            catch (Exception)
            {

                throw;
            }
        }

        internal int UpdateBuyCentralByStore(int Id, Inv_BuyCentral inv_BuyCentralObj, string ProjectCode, int StoreID, int StoreUnitID)
        {
            try
            {
                Inv_BuyCentral buyCentralObj = _context.Inv_BuyCentral.First(x => x.Id == Id && x.Project_Code == ProjectCode && x.Store_Id == StoreID && x.Store_Unit_Id == StoreUnitID);
                buyCentralObj.ChallanNo = inv_BuyCentralObj.ChallanNo;
                buyCentralObj.PurchaseDate = inv_BuyCentralObj.PurchaseDate;
                buyCentralObj.CompanyId = inv_BuyCentralObj.CompanyId;
                buyCentralObj.CompanyCode = inv_BuyCentralObj.CompanyCode;
                buyCentralObj.CompanyName = inv_BuyCentralObj.CompanyName;
                buyCentralObj.BarCode = inv_BuyCentralObj.BarCode;
                buyCentralObj.ProductId = inv_BuyCentralObj.ProductId;
                buyCentralObj.ProductGroup = inv_BuyCentralObj.ProductGroup;
                buyCentralObj.ProductName = inv_BuyCentralObj.ProductName;
                buyCentralObj.Brand = inv_BuyCentralObj.Brand;
                buyCentralObj.StyleSize = inv_BuyCentralObj.StyleSize;
                buyCentralObj.FloorName = inv_BuyCentralObj.FloorName;
                buyCentralObj.UnitName = inv_BuyCentralObj.UnitName;
                buyCentralObj.ReceiveQuantity = inv_BuyCentralObj.ReceiveQuantity;
                buyCentralObj.CPU = inv_BuyCentralObj.CPU;
                buyCentralObj.RPU = inv_BuyCentralObj.RPU;
                buyCentralObj.ExpireDate = inv_BuyCentralObj.ExpireDate;
                buyCentralObj.BalanceQuanity = inv_BuyCentralObj.BalanceQuanity;
                buyCentralObj.EditDate = inv_BuyCentralObj.EditDate;
                buyCentralObj.OCode = inv_BuyCentralObj.OCode;
                buyCentralObj.Item_Remarks = inv_BuyCentralObj.Item_Remarks;
                _context.SaveChanges();
                return 1;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public Inv_BuyCentral GetBuyCentralByBarcodeAndComanyId(string Barcode, string CompanyCode)
        {
            try
            {
                Inv_BuyCentral buyCentrl = _context.Inv_BuyCentral.Where(bc => bc.BarCode == Barcode && bc.CompanyCode == CompanyCode).FirstOrDefault<Inv_BuyCentral>();
                return buyCentrl;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Inv_BuyCentral GetBuyCentralByBarcodeAndStoreCode(string Barcode, string StoreCode)
        {
            try
            {
                Inv_BuyCentral buyCentrl = _context.Inv_BuyCentral.Where(bc => bc.BarCode == Barcode && bc.Store_Code == StoreCode).FirstOrDefault<Inv_BuyCentral>();
                return buyCentrl;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Inv_BuyCentral GetBuyCentralByBarcodeAndComanyCode(string Barcode, string CompanyCode)
        {
            try
            {
                Inv_BuyCentral buyCentrl = _context.Inv_BuyCentral.Where(bc => bc.BarCode == Barcode && bc.CompanyCode == CompanyCode).FirstOrDefault<Inv_BuyCentral>();
                return buyCentrl;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Inv_BuyCentral GetBuyCentralByBarcode_Store(string Barcode, int CompanyId, string ProjectCode, int StoreID, int StoreUnitID)
        {
            try
            {
                Inv_BuyCentral buyCentrl = _context.Inv_BuyCentral.Where(bc => bc.BarCode == Barcode && bc.CompanyId == CompanyId && bc.Project_Code == ProjectCode && bc.Store_Id == StoreID && bc.Store_Unit_Id == StoreUnitID).FirstOrDefault<Inv_BuyCentral>();
                return buyCentrl;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        internal int Update_ForReturn(int Id, string barcode, string StoreCode, string challanNo, Inv_BuyCentral inv_BuyCentralObj)
        {
            try
            {
                Inv_BuyCentral buyCentralObj = _context.Inv_BuyCentral.First(x => x.Id == Id && x.BarCode == barcode && x.ChallanNo == challanNo && x.Store_Code == StoreCode);

                buyCentralObj.BalanceQuanity = inv_BuyCentralObj.BalanceQuanity;
                buyCentralObj.SupplierReturnQty = inv_BuyCentralObj.SupplierReturnQty;

                _context.SaveChanges();
                return 1;

            }
            catch (Exception)
            {

                throw;
            }
        }
        internal int DeleteDamage_Temp(int id)
        {
            try
            {
                Inv_Damage_Temp buyCentralObj = _context.Inv_Damage_Temp.First(x => x.Id == id);
                _context.Inv_Damage_Temp.DeleteObject(buyCentralObj);
                _context.SaveChanges();
                return 1;

            }
            catch (Exception)
            {

                throw;
            }
        }
        internal List<productsDetails> GetAllProduct_Bycentral_ChallanNo(string productId, string storeCode)
        {
            try
            {

                var buy = (from buys in _context.Inv_BuyCentral

                           where buys.BarCode == productId && buys.Store_Code == storeCode
                           select new productsDetails
                           {

                               ChallanNo = buys.ChallanNo,
                               BarCode = buys.BarCode,
                               ProductName = buys.ProductName,
                               Brand = buys.Brand,
                               StyleSize = buys.StyleSize,
                               BalanceQuanity = buys.BalanceQuanity,
                               SupplierReturnQty = buys.SupplierReturnQty,
                               CompanyId = buys.CompanyId,
                               CompanyName = buys.CompanyName,
                               productGroup = buys.ProductGroup,
                               ReceiveQuantity = buys.ReceiveQuantity,
                               CPU = buys.CPU,
                               DeliveryQty = buys.DeliveryQty,
                               Ocode = buys.OCode,
                               CompanyCode = buys.CompanyCode,
                               PurchaseDate = buys.PurchaseDate,
                               UnitName = buys.UnitName



                           }

                );
                return buy.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }
        internal List<productsDetails> GetAllProduct_DamageTemp_ChallanNo(string challanNoTo)
        {
            try
            {

                var buy = (from buys in _context.Inv_Damage_Temp
                           where buys.ChallanNo == challanNoTo
                           select new productsDetails
                           {

                               ChallanNo = buys.ChallanNo,
                               BarCode = buys.BarCode,
                               ProductName = buys.ProductName + buys.Brand + buys.StyleSize,
                               Brand = buys.Brand,
                               StyleSize = buys.StyleSize,
                               BalanceQuanity = buys.BalanceQuanity,
                               SupplierReturnQty = buys.SupplierReturnQty,
                               CompanyId = buys.CompanyId,
                               CompanyName = buys.CompanyName,
                               //productGroup = buys.ProductGroup,
                               ReceiveQuantity = buys.ReceiveQuantity,
                               CPU = buys.CPU,
                               DeliveryQty = buys.DeliveryQty,
                               Ocode = buys.OCode,
                               CompanyCode = buys.CompanyCode,
                               PurchaseDate = buys.PurchaseDate,
                               UnitName = buys.UnitName,
                               ReturnQty = buys.SupplierReturnQty,
                               NewDamageQty = buys.DamageQty,
                               PrqBalanceQuanity = buys.BalanceQuanity




                           }

                );
                return buy.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }
        internal int InsertDamage(Inv_Damage Inv_DamageObj)
        {
            try
            {
                _context.Inv_Damage.AddObject(Inv_DamageObj);
                _context.SaveChanges();
                return 1;

            }
            catch (Exception)
            {

                throw;
            }
        }
        public Inv_BuyCentral GetBuyForReturn(string Barcode, string StoreCode)
        {
            try
            {
                Inv_BuyCentral buyCentrl = _context.Inv_BuyCentral.Where(bc => bc.BarCode == Barcode && bc.Store_Code == StoreCode).FirstOrDefault<Inv_BuyCentral>();
                return buyCentrl;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        internal List<productsDetails> GetAllProduct_ReturnTemp_ChallanNo_DPT(Guid userId, string ocode)
        {
            try
            {

                var buy = (from buys in _context.Inv_Return_Temp
                           where buys.EditUser == userId && buys.OCode == ocode
                           select new productsDetails
                           {

                               ChallanNo = buys.ChallanNo,
                               BarCode = buys.BarCode,
                               ProductName = buys.ProductName + buys.Brand + buys.StyleSize,
                               Brand = buys.Brand,
                               StyleSize = buys.StyleSize,
                               BalanceQuanity = buys.BalanceQuanity,
                               SupplierReturnQty = buys.SupplierReturnQty,
                               // CompanyId = buys.OldCompanyId,
                               // CompanyName = buys.OldCompanyName,
                               //productGroup = buys.ProductGroup,
                               ReceiveQuantity = buys.ReceiveQuantity,
                               CPU = buys.CPU,
                               DeliveryQty = buys.DeliveryQty,
                               Ocode = buys.OCode,
                               CompanyCode = buys.OldCompanyCode,
                               PurchaseDate = buys.PurchaseDate,
                               UnitName = buys.UnitName,
                               ReturnQty = buys.SupplierReturnQty,
                               ERetQty = buys.ERetQty,
                               PrqBalanceQuanity = buys.BalanceQuanity
                           }

                );
                return buy.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }
        internal int InsertReturn(Inv_Return Inv_ReturnObj)
        {
            try
            {
                _context.Inv_Return.AddObject(Inv_ReturnObj);
                _context.SaveChanges();
                return 1;

            }
            catch (Exception)
            {

                throw;
            }
        }
        internal int Update_Return_DptWise(int Id, string barcode, string StoreCode, string challanNo, Inv_Buy Inv_BuyObj)
        {
            try
            {
                Inv_Buy buyCentralObj = _context.Inv_Buy.First(x => x.Id == Id && x.BarCode == barcode && x.ChallanNo == challanNo && x.Store_Code == StoreCode);

                buyCentralObj.BalanceQuanity = Inv_BuyObj.BalanceQuanity;
                _context.SaveChanges();
                return 1;

            }
            catch (Exception)
            {

                throw;
            }
        }
        internal int DeleteReturn_Temp(int id)
        {
            try
            {
                Inv_Return_Temp buyCentralObj = _context.Inv_Return_Temp.First(x => x.Id == id);
                _context.Inv_Return_Temp.DeleteObject(buyCentralObj);
                _context.SaveChanges();
                return 1;

            }
            catch (Exception)
            {

                throw;
            }
        }
        internal int Update_ForReturnBy_CentralToStore(int Id, string barcode, string StoreCode, string challanNo, Inv_BuyCentral inv_BuyCentralObj)
        {
            try
            {
                Inv_BuyCentral buyCentralObj = _context.Inv_BuyCentral.First(x => x.Id == Id && x.BarCode == barcode && x.ChallanNo == challanNo && x.Store_Code == StoreCode);

                buyCentralObj.BalanceQuanity = inv_BuyCentralObj.BalanceQuanity;

                _context.SaveChanges();
                return 1;

            }
            catch (Exception)
            {

                throw;
            }
        }
        public Inv_Buy GetBuy_DPT_Return(string Barcode, string StoreCode, string challanNo)
        {
            try
            {
                Inv_Buy buy = _context.Inv_Buy.Where(bc => bc.BarCode == Barcode && bc.Store_Code == StoreCode && bc.ChallanNo == challanNo).FirstOrDefault<Inv_Buy>();
                return buy;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal List<productsDetails> GetAllProduct_Bycentral_ChallanNoBySupplier(string productId, string storeCode, string supplierCode)
        {
            try
            {
                var buy = (from buys in _context.Inv_BuyCentral
                           join rcha in _context.Inv_RChallan on buys.ChallanNo equals rcha.ChallanNo
                           where buys.BarCode == productId && buys.Store_Code == storeCode && rcha.SupplierCode == supplierCode
                           select new productsDetails
                           {

                               ChallanNo = buys.ChallanNo,
                               BarCode = buys.BarCode,
                               ProductName = buys.ProductName,
                               Brand = buys.Brand,
                               StyleSize = buys.StyleSize,
                               BalanceQuanity = buys.BalanceQuanity,
                               SupplierReturnQty = buys.SupplierReturnQty,
                               CompanyId = buys.CompanyId,
                               CompanyName = buys.CompanyName,
                               productGroup = buys.ProductGroup,
                               ReceiveQuantity = buys.ReceiveQuantity,
                               CPU = buys.CPU,
                               DeliveryQty = buys.DeliveryQty,
                               Ocode = buys.OCode,
                               CompanyCode = buys.CompanyCode,
                               PurchaseDate = buys.PurchaseDate,
                               UnitName = buys.UnitName
                           }
                );
                return buy.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        internal List<productsDetails> GetINV_MRRList(string OCode)
        {
            try
            {
                var buy = (from buys in _context.Inv_BuyCentral
                           where buys.OCode == OCode
                           && buys.OrderEId == null || buys.SeasonID == null || buys.MasterLCNo == "" || buys.B2BLCNo == ""
                           select new productsDetails
                           {
                               Id=buys.Id,
                               ChallanNo = buys.ChallanNo,
                               BarCode = buys.BarCode,
                               ProductName = buys.ProductName,
                               Brand = buys.Brand,
                               StyleSize = buys.StyleSize,
                               BalanceQuanity = buys.BalanceQuanity,
                               SupplierReturnQty = buys.SupplierReturnQty,
                               CompanyId = buys.CompanyId,
                               CompanyName = buys.CompanyName,
                               productGroup = buys.ProductGroup,
                               ReceiveQuantity = buys.ReceiveQuantity,
                               CPU = buys.CPU,
                               DeliveryQty = buys.DeliveryQty,
                               Ocode = buys.OCode,
                               CompanyCode = buys.CompanyCode,
                               PurchaseDate = buys.PurchaseDate,
                               UnitName = buys.UnitName,
                               SupplierCode = buys.SupplierCode,
                               RefNo_ChallanNo = buys.RefNo_ChallanNo,
                               MasterLCNo=buys.MasterLCNo,
                               B2BLCNo = buys.B2BLCNo,
                               Store_Id = buys.Store_Id,
                               SeasonID = buys.SeasonID,
                               OrderEId = buys.OrderEId
                           });
                return buy.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal int Update_buyCentral(int id)
        {
            try
            {
                Inv_BuyCentral prodObj = _context.Inv_BuyCentral.First(x => x.Id == id);
                _context.SaveChanges();
                return 1;
            }
            catch (Exception)
            {
                throw;
            }
        }

        internal Inv_BuyCentral GeBuyCentralListbyId(int fID)
        {
            try
            {
                Inv_BuyCentral Bi = (from b in _context.Inv_BuyCentral
                                      where b.Id == fID
                                      select b).FirstOrDefault();
                return Bi;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        //internal List<Inv_BuyCentral> GetProductNameByGroupIdandSToId(int gId, int storeTo)
        //{
        //    try
        //    {
        //        var Bi = (from b in _context.Inv_BuyCentral
        //                             where b.ProductGroup == gId && b.Store_Id == storeTo
        //                             select b).OrderBy(x => x.ProductName).ToList();
        //        return Bi;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

       
    }
}
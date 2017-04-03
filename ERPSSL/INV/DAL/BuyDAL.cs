using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using ERPSSL.INV.DAL;
using ERPSSL.INV.DAL.Repository;

namespace ERPSSL.INV.DAL
{
    public class BuyDAL
    {
        private ERPSSL_INVEntities _context = new ERPSSL_INVEntities();

        public Inv_Buy GetBuyBarcodeAndComanyId(string Barcode, string CompanyCode)
        {


            using (ERPSSL_INVEntities ctx = new ERPSSL_INVEntities())
            {
                try
                {

                    Inv_Buy buy = ctx.Inv_Buy.Where(bc => bc.BarCode == Barcode && bc.CompanyCode == CompanyCode).FirstOrDefault<Inv_Buy>();
                    return buy;

                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }


        }

        public Inv_Buy GetBuyBarcodeAndComanyCode(string Barcode, string CompanyCode)
        {


            using (ERPSSL_INVEntities ctx = new ERPSSL_INVEntities())
            {
                try
                {

                    Inv_Buy buy = ctx.Inv_Buy.Where(bc => bc.BarCode == Barcode && bc.CompanyCode == CompanyCode).FirstOrDefault<Inv_Buy>();
                    return buy;

                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }


        }

        internal int Insert(Inv_Buy inv_BuyObj)
        {
            try
            {
                _context.Inv_Buy.AddObject(inv_BuyObj);
                _context.SaveChanges();
                return 1;

            }
            catch (Exception)
            {

                throw;
            }
        }

        internal int Update(int Id, Inv_Buy inv_BuyObj)
        {
            try
            {
                Inv_Buy buyObj = _context.Inv_Buy.First(x => x.Id == Id);
                buyObj.ChallanNo = inv_BuyObj.ChallanNo;
                buyObj.CompanyId = inv_BuyObj.CompanyId;
                buyObj.CompanyCode = inv_BuyObj.CompanyCode;
                buyObj.CompanyName = inv_BuyObj.CompanyName;
                buyObj.BarCode = inv_BuyObj.BarCode;
                buyObj.ProductId = inv_BuyObj.ProductId;
                buyObj.ProductGroup = inv_BuyObj.ProductGroup;
                buyObj.ProductName = inv_BuyObj.ProductName;
                buyObj.Brand = inv_BuyObj.Brand;
                buyObj.StyleSize = inv_BuyObj.StyleSize;
                buyObj.FloorName = inv_BuyObj.FloorName;
                buyObj.UnitName = inv_BuyObj.UnitName;
                buyObj.ReceiveQuantity = inv_BuyObj.ReceiveQuantity;
                buyObj.CPU = inv_BuyObj.CPU;
                buyObj.RPU = inv_BuyObj.RPU;
                buyObj.ExpireDate = inv_BuyObj.ExpireDate;
                buyObj.BalanceQuanity = inv_BuyObj.BalanceQuanity;
                buyObj.PurchaseDate = inv_BuyObj.PurchaseDate;
                buyObj.EditDate = inv_BuyObj.EditDate;
                buyObj.OCode = inv_BuyObj.OCode;
                _context.SaveChanges();
                return 1;

            }
            catch (Exception)
            {

                throw;
            }
        }

        internal List<productsDetails> GetAllProductBuyReturn(string EID, string barCode, string StoreCode)
        {

            try
            {

                var buy = (from I in _context.Inv_IChallan
                           join r in _context.Inv_Return on I.ChallanNo_From equals r.ChallanNo_To
                            into a
                           from r in a.DefaultIfEmpty()
                           where I.BarCode == barCode && I.Store_Code == StoreCode && I.EID == EID
                           select new productsDetails
                           {

                               //ChallanNo = I.ChallanNo_From,
                               BarCode = I.BarCode,
                               ProductName = I.ProductName,
                               Brand = I.Brand,
                               StyleSize = I.StyleSize,
                               BalanceQuanity = (I.BalanceQuanity == null ? 0 : I.BalanceQuanity) - (r.ERetQty == null ? 0 : r.ERetQty),
                               SupplierReturnQty = I.SupplierReturnQty,
                               productGroup = I.ProductGroup,
                               ReceiveQuantity = I.ReceiveQuantity,
                               CPU = I.CPU,
                               DeliveryQty = I.DeliveryQty,
                               Ocode = I.OCode,
                               PurchaseDate = I.DeliveryDate,
                               UnitName = I.UnitName



                           }

                );
                return buy.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }
        internal List<productsDetails> GetAllProductWithProgram(string productId, int program, string StoreCode)
        {
            try
            {

                string programid = Convert.ToString(program);

                var programId = new SqlParameter("ProgramId", programid);
                var barcode = new SqlParameter("BarCode", productId);
                var storeCode = new SqlParameter("StoreCode", StoreCode);

                string SP_SQL = "Inv_GetAllProduct_ProgramToCentral_Return @ProgramId,@BarCode,@StoreCode";
                return (_context.ExecuteStoreQuery<productsDetails>(SP_SQL, programId, barcode, storeCode)).ToList();



                //int pId = Convert.ToInt32(productId);
                //var buy = (from buys in _context.Inv_IChallan
                //           join r in _context.Inv_Return on  buys.ChallanNo_From  equals  r.ChallanNo_To 
                //                          into a
                //           from r in a.DefaultIfEmpty()
                //           where buys.ProductId == pId && buys.Program == program && buys.Store_Code == StoreCode

                //           select new productsDetails
                //           {

                //               ChallanNo = buys.ChallanNo,
                //               BarCode = buys.BarCode,
                //               ProductName = buys.ProductName,
                //               Brand = buys.Brand,
                //               StyleSize = buys.StyleSize,
                //               BalanceQuanity = (buys.BalanceQuanity == null ? 0 : buys.BalanceQuanity) - (r.ERetQty == null ? 0 : r.ERetQty),
                //               SupplierReturnQty = buys.SupplierReturnQty,
                //               productGroup = buys.ProductGroup,
                //               ReceiveQuantity = buys.ReceiveQuantity,
                //               CPU = buys.CPU,
                //               DeliveryQty = buys.DeliveryQty,
                //               Ocode = buys.OCode,
                //               PurchaseDate = buys.PurchaseDate,
                //               UnitName = buys.UnitName
                //           }

                //);
                //return buy.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        internal List<productsDetails> GetAllProductWithProgram2(int program, string StoreCode)
        {
            try
            {

                string programid = Convert.ToString(program);

                var programId = new SqlParameter("ProgramId", programid);
                var storeCode = new SqlParameter("StoreCode", StoreCode);

                string SP_SQL = "Inv_GetAllProduct_ProgramToCentral_Return2 @ProgramId,@StoreCode";
                return (_context.ExecuteStoreQuery<productsDetails>(SP_SQL, programId, storeCode)).ToList();



                //int pId = Convert.ToInt32(productId);
                //var buy = (from buys in _context.Inv_IChallan
                //           join r in _context.Inv_Return on  buys.ChallanNo_From  equals  r.ChallanNo_To 
                //                          into a
                //           from r in a.DefaultIfEmpty()
                //           where buys.ProductId == pId && buys.Program == program && buys.Store_Code == StoreCode

                //           select new productsDetails
                //           {

                //               ChallanNo = buys.ChallanNo,
                //               BarCode = buys.BarCode,
                //               ProductName = buys.ProductName,
                //               Brand = buys.Brand,
                //               StyleSize = buys.StyleSize,
                //               BalanceQuanity = (buys.BalanceQuanity == null ? 0 : buys.BalanceQuanity) - (r.ERetQty == null ? 0 : r.ERetQty),
                //               SupplierReturnQty = buys.SupplierReturnQty,
                //               productGroup = buys.ProductGroup,
                //               ReceiveQuantity = buys.ReceiveQuantity,
                //               CPU = buys.CPU,
                //               DeliveryQty = buys.DeliveryQty,
                //               Ocode = buys.OCode,
                //               PurchaseDate = buys.PurchaseDate,
                //               UnitName = buys.UnitName
                //           }

                //);
                //return buy.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        internal productsDetails GetProductBalance_InvBuy(string productId, string storeCode)
        {
            try
            {
                return (from prod in _context.Inv_Buy
                        where prod.BarCode == productId && prod.Store_Code == storeCode
                        group prod by productId into p
                        select new productsDetails
                        {
                            PrqBalanceQuanity = (double?)p.Sum(c => c.BalanceQuanity ?? 0)
                        }).FirstOrDefault();
            }
            catch (Exception)
            {
                throw;
            }
        }

    }

}
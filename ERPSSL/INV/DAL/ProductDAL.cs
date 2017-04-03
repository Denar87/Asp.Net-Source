using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ERPSSL.INV.DAL;
using System.Data.SqlClient;
using ERPSSL.INV.DAL.Repository;
using ERPSSL.Dashboard.Repository;
using ERPSSL.HRM.DAL;
using MoreLinq;
using System.Configuration;

namespace ERPSSL.INV.DAL
{
    public class ProductDAL
    {
        private ERPSSL_INVEntities _context = new ERPSSL_INVEntities();

        internal int InsertProduct(Inv_Product productObj)
        {
            try
            {
                _context.Inv_Product.AddObject(productObj);
                _context.SaveChanges();
                return 1;
            }
            catch (Exception)
            { 

                throw;
            }
        }

        internal List<InvProductR> GetProductById(int productId)
        {
            try
            {
                var products = (from prod in _context.Inv_Product
                                join u in _context.Inv_Unit on prod.UnitId equals u.UnitId

                                where prod.ProductId == productId
                                select new InvProductR
                                {
                                    UnitId = u.UnitId,
                                    UnitName = u.UnitName,
                                    ProductId = prod.ProductId,
                                    ProductName = prod.ProductName,
                                    Brand = prod.Brand,
                                    StyleAndSize = prod.StyleAndSize,
                                    FloorName = prod.FloorName,
                                    ReOrderQty = prod.ReOrderQty,
                                    Price = prod.Price
                                });
                return products.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        internal List<Inv_BuyCentral> GetProductStockById(int productId)
        {
            try
            {
                var products = from prod in _context.Inv_BuyCentral
                               where prod.ProductId == productId
                               select prod;
                return products.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        internal List<Inv_BuyCentral> GetProductStockByIdandDescription(int productId, string description)
        {
            try
            {
                var products = from prod in _context.Inv_BuyCentral
                               where prod.ProductId == productId && prod.StyleSize == description
                               select prod;
                return products.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        internal List<Inv_BuyCentral> GetProductStockById_FromStoreUnit(int productId, string ProjectCode, int StoreID, int StoreUnitID)
        {
            try
            {
                var products = from prod in _context.Inv_BuyCentral
                               where prod.ProductId == productId && prod.Project_Code == ProjectCode && prod.Store_Id == StoreID && prod.Store_Unit_Id == StoreUnitID
                               select prod;
                return products.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Inv_Product GetAllItem(int pdoductId, string description)
        {
            try
            {
                Inv_Product buyCentrl = _context.Inv_Product.Where(bc => bc.ProductId == pdoductId && bc.StyleAndSize == description).FirstOrDefault<Inv_Product>();
                return buyCentrl;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal List<InvProductR> GetProduct(string OCode)
        {
            try
            {
                var products = (from prod in _context.Inv_Product
                                join u in _context.Inv_Unit on prod.UnitId equals u.UnitId
                                join pg in _context.Inv_ProductGroup on prod.GroupId equals pg.GroupId
                                join pt in _context.Inv_ProductType on prod.ProductTypeId equals pt.ProductTypeId

                                where prod.OCode == OCode
                                select new InvProductR
                                {
                                    UnitId=u.UnitId,
                                    UnitName=u.UnitName,
                                    ProductId = prod.ProductId,
                                    GroupName=pg.GroupName,
                                    ProductName = prod.ProductName,
                                    Brand = prod.Brand,
                                    StyleAndSize = prod.StyleAndSize,
                                    FloorName = prod.FloorName,
                                    ReOrderQty = prod.ReOrderQty,
                                    Price = prod.Price,
                                    ProductTypeId = pt.ProductTypeId,
                                    ProductType = pt.ProductType
                                });
                return products.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Inv_Product> GetProductListByGroup(int GroupId)
        {
            try
            {
                var GroupID = new SqlParameter("GroupId", GroupId);
                string SP_SQL = "INV_GETPRODUCTBYGROUP @GroupId";
                return (_context.ExecuteStoreQuery<Inv_Product>(SP_SQL, GroupID)).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        //public List<Inv_Product> GetProductListByGroup(int GroupId, string ProductType)
        //{

        //        List<Inv_Product> list = new List<Inv_Product>();
        //        try
        //        {
        //            list = _context.Database.SqlQuery<Inv_Product>("INV_GetProductsByGroupAndType @GroupId, @ProductType", new SqlParameter("GroupId", GroupId), new SqlParameter("ProductType", ProductType)).ToList<Inv_Product>();

        //        }
        //        catch (Exception)
        //    {

        //        throw;
        //    }
        //        return list;
        //    }


        internal List<Inv_Product> GetProductByGroup(int GroupId)
        {
            var products = (from prod in _context.Inv_Product
                            where prod.GroupId == GroupId
                            select prod).OrderBy(x => x.ProductName);
            return products.ToList();
        }

        internal List<Inv_Product> GetProductByIdandOcode(string productId, string OCODE)
        {
            try
            {
                int prodId = Convert.ToInt16(productId);

                var products = (from product in _context.Inv_Product
                                where product.ProductId == prodId && product.OCode == OCODE
                                select product);
                return products.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        internal int UpdateProduct(int productId, Inv_Product productObj)
        {
            try
            {
                Inv_Product prodObj = _context.Inv_Product.First(x => x.ProductId == productId);
                prodObj.ProductName = productObj.ProductName;
                prodObj.Brand = productObj.Brand;
                prodObj.StyleAndSize = productObj.StyleAndSize;
                prodObj.GroupId = productObj.GroupId;
                prodObj.UnitId = productObj.UnitId;
                prodObj.ProductType = productObj.ProductType;
                prodObj.ReOrderQty = productObj.ReOrderQty;
                prodObj.UnitName = productObj.UnitName;
                prodObj.ProjectCode = productObj.ProjectCode;
                prodObj.StoreID = productObj.StoreID;
                prodObj.StoreUnitID = productObj.StoreUnitID;
                prodObj.ProductTypeId = productObj.ProductTypeId;
                _context.SaveChanges();
                return 1;

            }
            catch (Exception)
            {

                throw;
            }

            //using (ERPSSL_INVEntities ctx = new ERPSSL_INVEntities())
            //{
            //    try
            //    {
            //        ctx.Set<T>().Attach(obj);
            //        ctx.Entry(obj).State = System.Data.Entity.EntityState.Modified;
            //        ctx.SaveChanges();
            //        return 1;
            //    }
            //    catch (Exception ex)
            //    {

            //        throw ex;
            //    }
            //}       
        }



        internal List<InvProductR> GetProductByGroupID(string OCODE, int GroupID)
        {
            try
            {
                var products = (from prod in _context.Inv_Product
                                join u in _context.Inv_Unit on prod.UnitId equals u.UnitId
                                join pg in _context.Inv_ProductGroup on prod.GroupId equals pg.GroupId
                                join pt in _context.Inv_ProductType on prod.ProductTypeId equals pt.ProductTypeId

                                where prod.OCode == OCODE && prod.GroupId == GroupID
                                select new InvProductR
                                {
                                    UnitId = u.UnitId,
                                    UnitName = u.UnitName,
                                    ProductId = prod.ProductId,
                                    GroupName = pg.GroupName,
                                    ProductName = prod.ProductName,
                                    Brand = prod.Brand,
                                    StyleAndSize = prod.StyleAndSize,
                                    FloorName = prod.FloorName,
                                    ReOrderQty = prod.ReOrderQty,
                                    Price = prod.Price,
                                    ProductTypeId = pt.ProductTypeId,
                                    ProductType = pt.ProductType
                                });
                return products.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal List<Inv_Product> FillBrandSize(int ProductId)
        {
            try
            {
                var products = (from prod in _context.Inv_Product
                                where prod.ProductId == ProductId
                                select prod);
                return products.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        internal List<Inv_Product> GetItemName(int gId)
        {
            try
            {
                var products = (from prod in _context.Inv_Product
                                where prod.GroupId==gId
                                select prod).DistinctBy(x => x.ProductName);
                return products.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal List<Inv_Product> GetIColorBrand(string iId)
        {
            try
            {
                var products = (from prod in _context.Inv_Product
                                where prod.ProductName == iId
                                select prod).DistinctBy(x => x.Brand);
                return products.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal List<Inv_Unit> GetAllUnit()
        {
            try
            {
                var units = (from unit in _context.Inv_Unit
                             select unit).OrderBy(x => x.UnitName);
                return units.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        internal List<Inv_Product> GetStyleSize(string cbId)
        {
            try
            {
                var products = (from prod in _context.Inv_Product
                                where prod.Brand == cbId
                                select prod).DistinctBy(x => x.StyleAndSize);
                return products.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal int InsertGroup(Inv_ProductGroup groupObj)
        {
            try
            {
                _context.Inv_ProductGroup.AddObject(groupObj);
                _context.SaveChanges();
                return groupObj.GroupId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal int InsertUnit(Inv_Unit _unitObj)
        {
            try
            {
                _context.Inv_Unit.AddObject(_unitObj);
                _context.SaveChanges();
                return _unitObj.UnitId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal List<productsDetails> GetAllGroupProductByEID(string EID, string OCODE)
        {
            try
            {
                using (var _context = new ERPSSL_INVEntities())
                {
                    var eid = new SqlParameter("@EID", EID);
                    var ocode = new SqlParameter("@OCODE", OCODE);
                    string SP_SQL = "Inv_GetAllUserwiseCategory_Product @EID,@OCODE";
                    return (_context.ExecuteStoreQuery<productsDetails>(SP_SQL, eid, ocode)).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        internal InventoryDetailsR GetTodayStockDetails()
        {
            try
            {
                using (var _context = new ERPSSLHBEntities())
                {
                    string SP_SQL = "Inv_TodayStockDetails";
                    return (_context.ExecuteStoreQuery<InventoryDetailsR>(SP_SQL)).FirstOrDefault();
                }
            }
            catch (Exception)
            {
               throw;
            }
        }
        internal InventoryDetailsR GetTodayReqDetails()
        {
            try
            {
                using (var _context = new ERPSSLHBEntities())
                {
                    string SP_SQL = "Inv_TodayRequisitionDetails";
                    return (_context.ExecuteStoreQuery<InventoryDetailsR>(SP_SQL)).FirstOrDefault();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        internal InventoryDetailsR GetLastMonthDetails()
        {
            try
            {
                using (var _context = new ERPSSLHBEntities())
                {
                    string SP_SQL = "Inv_LastMonthDetails";
                    return (_context.ExecuteStoreQuery<InventoryDetailsR>(SP_SQL)).FirstOrDefault();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        //internal InventoryDetailsR GetTodayStockDetails()
        //{
        //    try
        //    {
        //        using (var _context = new ERPSSLHBEntities())
        //        {
        //            string SP_SQL = "Inv_TodayStockDetails";
        //            return (_context.ExecuteStoreQuery<InventoryDetailsR>(SP_SQL)).FirstOrDefault();
        //        }
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}
        //internal InventoryDetailsR GetTodayReqDetails()
        //{
        //    try
        //    {
        //        using (var _context = new ERPSSLHBEntities())
        //        {
        //            string SP_SQL = "Inv_TodayRequisitionDetails";
        //            return (_context.ExecuteStoreQuery<InventoryDetailsR>(SP_SQL)).FirstOrDefault();
        //        }
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}
        internal InventoryDetailsR GetInventoryDetails()
        {
            try
            {
                using (var _context = new ERPSSLHBEntities())
                {
                    string SP_SQL = "[Inv_InventoryDetailsR]";
                    return (_context.ExecuteStoreQuery<InventoryDetailsR>(SP_SQL)).FirstOrDefault();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        internal int InsertProductType(Inv_ProductType _ProductType)
        {
            try
            {
                _context.Inv_ProductType.AddObject(_ProductType);
                _context.SaveChanges();
                return _ProductType.ProductTypeId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal List<Inv_ProductType> LoadProductType()
        {
            try
            {
                var products = (from prod in _context.Inv_ProductType
                                select prod);
                return products.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal List<Inv_Product> GetProductListByGroupId(int gId)
        {
            try
            {
                var products = (from prod in _context.Inv_Product
                                where prod.GroupId == gId
                                select prod).OrderBy(x => x.ProductName);
                return products.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        internal List<InvProductR> GetProductNameByGroupId(int gId)
        {
            try
            {
                var products = (from pg in _context.Inv_ProductGroup
                                join prod in _context.Inv_Product on pg.GroupId equals prod.GroupId
                                where pg.GroupId == gId
                                select new InvProductR
                                {
                                    ProductId=prod.ProductId,
                                    GroupId = pg.GroupId,
                                    GroupName = pg.GroupName,
                                    Brand = prod.Brand,
                                    StyleAndSize = prod.StyleAndSize,
                                    FloorName = prod.FloorName,
                                    ReOrderQty = prod.ReOrderQty,
                                    Price = prod.Price,
                                    ProdName = prod.ProductName + "-" + prod.Brand + "-" + prod.StyleAndSize
                                }).OrderBy(x => x.ProdName);
                //.DistinctBy(x => x.ProductName)
                return products.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        internal productsDetails GetProductBalanceById(int productId)
        {
            try
            {
                return (from prod in _context.Inv_BuyCentral
                        where prod.ProductId == productId
                        group prod by productId into p
                        select new productsDetails
                        {
                            BalanceQuanity = (double)p.Sum(c => c.BalanceQuanity),
                        }).FirstOrDefault();
            }
            catch (Exception)
            {
                throw;
            }
        }
        internal List<Inv_BuyCentral> GetProductBalance(int productId)
        {
            try
            {
                var products = (from prod in _context.Inv_BuyCentral
                                where prod.ProductId == productId
                                select prod).OrderBy(x => x.ProductName);
                return products.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        internal productsDetails GetProductBalanceForRequisition(int productId)
        {
            try
            {
                return (from prod in _context.PRQ_Requisitions
                        where prod.BarCode == productId && prod.Status == "Pending"
                        group prod by productId into p
                        select new productsDetails
                        {
                            PrqBalanceQuanity = (double?)p.Sum(c => c.Qty ?? 0)
                        }).FirstOrDefault();




            }
            catch (Exception)
            {
                throw;
            }
        }
        internal productsDetails GetProductBalanceByIdForReq(int productId)
        {
            try
            {
                return (from prod in _context.Inv_BuyCentral
                        where prod.ProductId == productId
                        group prod by productId into p
                        select new productsDetails
                        {
                            BalanceQuanity = (double)p.Sum(c => c.BalanceQuanity ?? 0),
                        }).FirstOrDefault();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
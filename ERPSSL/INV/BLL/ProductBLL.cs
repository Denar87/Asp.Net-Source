using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ERPSSL.INV.DAL;
using ERPSSL.INV.DAL.Repository;
using ERPSSL.Dashboard.Repository;

namespace ERPSSL.INV.BLL
{
    public class ProductBLL
    {
        ProductDAL productDal = new ProductDAL();

        internal int InsertProduct(Inv_Product productObj)
        {
            return productDal.InsertProduct(productObj);
        }

        public Inv_Product GetAllItem(int pdoductId, string description)
        {
            Inv_Product product = productDal.GetAllItem(pdoductId, description);
            return product;
        }

        internal List<InvProductR> GetProduct(string OCODE)
        {
            return productDal.GetProduct(OCODE);
        }

        internal List<InvProductR> GetProductById(int productId)
        {
            return productDal.GetProductById(productId);
        }

        internal List<Inv_BuyCentral> GetProductStockById(int productId)
        {
            return productDal.GetProductStockById(productId);
        }

        internal List<Inv_BuyCentral> GetProductStockByIdandDescription(int productId, string description)
        {
            return productDal.GetProductStockByIdandDescription(productId, description);
        }

        internal List<Inv_BuyCentral> GetProductStockById_FromStoreUnit(int productId, string ProjectCode, int StoreID, int StoreUnitID)
        {
            return productDal.GetProductStockById_FromStoreUnit(productId, ProjectCode, StoreID, StoreUnitID);
        }

        internal List<Inv_Product> GetProductListByGroup(int GroupId)
        {
            return productDal.GetProductListByGroup(GroupId);
        }

        internal List<Inv_Product> GetProductByGroup(int GroupId)
        {
            return productDal.GetProductByGroup(GroupId);
        }

        internal List<Inv_Product> GetProductByIdandOcode(string productId, string OCODE)
        {
            return productDal.GetProductByIdandOcode(productId, OCODE);
        }

        internal int UpdateProduct(Inv_Product productObj, int productId)
        {
            return productDal.UpdateProduct(productId, productObj);
        }

        internal List<InvProductR> GetProductByGroupID(string OCODE, int GroupID)
        {
            return productDal.GetProductByGroupID(OCODE, GroupID);
        }

        internal List<Inv_Product> FillBrandSize(int ProductId)
        {
            return productDal.FillBrandSize(ProductId);
        }

        internal List<Inv_Product> GetItemName(int gId)
        {
            return productDal.GetItemName(gId);
        }

        internal List<Inv_Product> GetIColorBrand(string iId)
        {
            return productDal.GetIColorBrand(iId);
        }

        internal List<Inv_Product> GetStyleSize(string cbId)
        {
            return productDal.GetStyleSize(cbId);
        }

        internal List<Inv_Unit> GetAllUnit()
        {
            return productDal.GetAllUnit();
        }

        internal int InsertGroup(Inv_ProductGroup groupObj)
        {
            return productDal.InsertGroup(groupObj);
        }

        internal int InsertUnit(Inv_Unit _unitObj)
        {
            return productDal.InsertUnit(_unitObj);
        }

        internal List<productsDetails> GetAllGroupProductByEID(string EID, string OCODE)
        {
            return productDal.GetAllGroupProductByEID(EID, OCODE);
        }
        internal InventoryDetailsR GetTodayStockDetails()
        {
            return productDal.GetTodayStockDetails();
        }
        internal InventoryDetailsR GetTodayReqDetails()
        {
            return productDal.GetTodayReqDetails();
        }

        internal InventoryDetailsR GetLastMonthDetails()
        {
            return productDal.GetLastMonthDetails();
        }
        internal InventoryDetailsR GetInventoryDetails()
        {
            return productDal.GetInventoryDetails();
        }

        internal int InsertProductType(Inv_ProductType _ProductType)
        {
            return productDal.InsertProductType(_ProductType);
        }

        internal List<Inv_ProductType> LoadProductType()
        {
            return productDal.LoadProductType();
        }

        internal List<Inv_Product> GetProductListByGroupId(int gId)
        {
            return productDal.GetProductListByGroupId(gId);
        }

        internal List<InvProductR> GetProductNameByGroupId(int gId)
        {
            return productDal.GetProductNameByGroupId(gId);
        }

        internal productsDetails GetProductBalanceById(int productId)
        {
            return productDal.GetProductBalanceById(productId);
        }
        internal List<Inv_BuyCentral> GetProductBalance(int productId)
        {
            return productDal.GetProductBalance(productId);
        }

        internal productsDetails GetProductBalanceForRequisition(int productId)
        {
            return productDal.GetProductBalanceForRequisition(productId);
        }
        internal productsDetails GetProductBalanceByIdForReq(int productId)
        {
            return productDal.GetProductBalanceByIdForReq(productId);
        }
    }
}
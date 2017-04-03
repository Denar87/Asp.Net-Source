using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ERPSSL.INV.DAL;
using System.Data;
using System.Configuration;
using ERPSSL.INV.DAL.Repository;

namespace ERPSSL.INV.BLL
{
    public class BuyBLL
    {
        DataAccessEX ado = new DataAccessEX();
        string conn = ConfigurationManager.ConnectionStrings["ERPSSLADO"].ConnectionString;

        BuyDAL buyDal = new BuyDAL();

        public Inv_Buy GetBuyByCompanyAndBarcode(string barcode, string CompanyCode)
        {
            Inv_Buy buy = buyDal.GetBuyBarcodeAndComanyId(barcode, CompanyCode);
            return buy;
        }

        public Inv_Buy GetBuyByCompanyCodeAndBarcode(string barcode, string CompanyCode)
        {
            Inv_Buy buy = buyDal.GetBuyBarcodeAndComanyCode(barcode, CompanyCode);
            return buy;
        }

        internal int Insert(Inv_Buy inv_BuyObj)
        {
            return buyDal.Insert(inv_BuyObj);
        }


        internal int Update(Inv_Buy inv_BuyObj, int Id)
        {
            return buyDal.Update(Id, inv_BuyObj);
        }

         public List<productsDetails> GetAllProductBuyReturn(string EID, string barCode, string StoreCode)
        {
            return buyDal.GetAllProductBuyReturn(EID, barCode, StoreCode);
        }

         internal List<productsDetails> GetAllProductWithProgram(string productId, int program, string StoreCode)
         {
             return buyDal.GetAllProductWithProgram(productId, program, StoreCode);
         }
         internal List<productsDetails> GetAllProductWithProgram2(int program, string StoreCode)
         {
             return buyDal.GetAllProductWithProgram2(program, StoreCode);
         }

         internal productsDetails GetProductBalance_InvBuy(string productId, string storeCode)
         {
             return buyDal.GetProductBalance_InvBuy(productId, storeCode);
         }

    }
}
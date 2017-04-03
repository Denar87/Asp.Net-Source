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
    public class BuyCentralBLL
    {
        BuyCentralDal buyCentralDal = new BuyCentralDal();
        DataAccessEX ado = new DataAccessEX();
        string conn = ConfigurationManager.ConnectionStrings["ERPSSLADO"].ConnectionString;

        internal int Insert(Inv_BuyCentral inv_BuyCentralObj)
        {
            return buyCentralDal.Insert(inv_BuyCentralObj);
        }

        internal int Update(Inv_BuyCentral inv_BuyCentralObj, int Id)
        {
            return buyCentralDal.Update(Id, inv_BuyCentralObj);
        }

        internal int UpdateBuyCentralByStore(Inv_BuyCentral inv_BuyCentralObj, int Id, string ProjectCode, int StoreID, int StoreUnitID)
        {
            return buyCentralDal.UpdateBuyCentralByStore(Id, inv_BuyCentralObj, ProjectCode, StoreID, StoreUnitID);
        }

        public Inv_BuyCentral GetBuyCentralByCompanyAndBarcode(string barcode, string CompanyCode)
        {
            Inv_BuyCentral buyCentral = buyCentralDal.GetBuyCentralByBarcodeAndComanyId(barcode, CompanyCode);
            return buyCentral;
        }

        public Inv_BuyCentral GetBuyCentralByBarcodeAndStoreCode(string barcode, string StoreCode)
        {
            Inv_BuyCentral buyCentral = buyCentralDal.GetBuyCentralByBarcodeAndStoreCode(barcode, StoreCode);
            return buyCentral;
        }

        public Inv_BuyCentral GetBuyCentralByCompanyCodeAndBarcode(string barcode, string CompanyCode)
        {
            Inv_BuyCentral buyCentral = buyCentralDal.GetBuyCentralByBarcodeAndComanyCode(barcode, CompanyCode);
            return buyCentral;
        }

        public Inv_BuyCentral GetBuyCentralByBarcode_Store(string barcode, int CompanyId, string ProjectCode, int StoreID, int StoreUnitID)
        {
            Inv_BuyCentral buyCentral = buyCentralDal.GetBuyCentralByBarcode_Store(barcode, CompanyId, ProjectCode, StoreID, StoreUnitID);
            return buyCentral;
        }

        internal DataTable GetStockByProductId(int Id)
        {
            DataTable dt = new DataTable();

            try
            {
                dt = ado.GetDataBySQLString("select * from Inv_BuyCentral where ProductId = '" + Id + "'", conn);

            }
            catch { }
            return dt;
        }

        internal string GetBarcode(int ProductId)
        {
            string Barcode = "CN";
            int count = 0;
            int count2 = 0;

            try
            {
                count = int.Parse(ado.AggRetrive("select count(distinct barcode) from Inv_BuyCentral", conn).ToString());
                count2 = int.Parse(ado.AggRetrive("select count(distinct barcode) from Inv_RChallan_Temp", conn).ToString());
                if (count > count2)
                    Barcode = Barcode + "" + (count.ToString()).PadLeft(8, '0');
                else
                    Barcode = Barcode + "" + (count2.ToString()).PadLeft(8, '0');
            }
            catch
            {

            }

            return Barcode;
        }

        internal int Update_ForReturn(int Id, string barcode, string StoreCode, string challanNo, Inv_BuyCentral inv_BuyCentralObj)
        {
            return buyCentralDal.Update_ForReturn(Id, barcode, StoreCode, challanNo, inv_BuyCentralObj);

        }
        internal int DeleteDamage_Temp(int id)
        {
            return buyCentralDal.DeleteDamage_Temp(id);
        }

        internal List<productsDetails> GetAllProduct_Bycentral_ChallanNo(string productId, string storeCode)
        {
            return buyCentralDal.GetAllProduct_Bycentral_ChallanNo(productId, storeCode);
        }
        internal List<productsDetails> GetAllProduct_DamageTemp_ChallanNo(string challanNoTo)
        {
            return buyCentralDal.GetAllProduct_DamageTemp_ChallanNo(challanNoTo);
        }
        internal int InsertDamage(Inv_Damage Inv_DamageObj)
        {
            return buyCentralDal.InsertDamage(Inv_DamageObj);
        }
        public Inv_BuyCentral GetBuyForReturn(string Barcode, string StoreCode)
        {
            return buyCentralDal.GetBuyForReturn(Barcode, StoreCode);
        }
        internal List<productsDetails> GetAllProduct_ReturnTemp_ChallanNo_DPT(Guid userid, string ocode)
        {
            return buyCentralDal.GetAllProduct_ReturnTemp_ChallanNo_DPT(userid, ocode);
        }
        internal int InsertReturn(Inv_Return Inv_ReturnObj)
        {
            return buyCentralDal.InsertReturn(Inv_ReturnObj);
        }
        internal int Update_Return_DptWise(int Id, string barcode, string StoreCode, string challanNo, Inv_Buy Inv_BuyObj)
        {
            return buyCentralDal.Update_Return_DptWise(Id, barcode, StoreCode, challanNo, Inv_BuyObj);
        }
        internal int DeleteReturn_Temp(int id)
        {
            return buyCentralDal.DeleteReturn_Temp(id);
        }
        internal int Update_ForReturnBy_CentralToStore(int Id, string barcode, string StoreCode, string challanNo, Inv_BuyCentral inv_BuyCentralObj)
        {
            return buyCentralDal.Update_ForReturnBy_CentralToStore(Id, barcode, StoreCode, challanNo, inv_BuyCentralObj);
        }
        public Inv_Buy GetBuy_DPT_Return(string Barcode, string StoreCode, string challanNo)
        {
            return buyCentralDal.GetBuy_DPT_Return(Barcode, StoreCode, challanNo);
        }
        internal List<productsDetails> GetAllProduct_Bycentral_ChallanNoBySupplier(string productId, string storeCode, string supplierCode)
        {
            return buyCentralDal.GetAllProduct_Bycentral_ChallanNoBySupplier(productId, storeCode, supplierCode);
        }

        internal List<productsDetails> GetINV_MRRList(string OCode)
        {
            return buyCentralDal.GetINV_MRRList(OCode);
        }
        
        internal int Update_buyCentral(int id)
        {
            return buyCentralDal.Update_buyCentral(id);
        }

        internal Inv_BuyCentral GeBuyCentralListbyId(int fID)
        {
            return buyCentralDal.GeBuyCentralListbyId(fID);
        }

    }
}
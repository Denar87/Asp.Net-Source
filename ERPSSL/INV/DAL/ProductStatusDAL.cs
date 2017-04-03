using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ERPSSL.INV.DAL.Repository;

namespace ERPSSL.INV.DAL
{
    public class ProductStatusDAL
    {
        
        private ERPSSL_INVEntities _context = new ERPSSL_INVEntities();
        internal List<Inv_Product> GetProductStatus(string Ocode)
        {
            List<Inv_Product> productes = _context.Inv_Product.Where(x => x.OCode == Ocode).ToList();
            return productes;
        }

        internal Inv_BuyCentral GetProductQtyformBuyCentral(productsDetails aitem)
        {
            string Barcode = aitem.ProductId.ToString();
            Inv_BuyCentral buyCentral = _context.Inv_BuyCentral.FirstOrDefault(x => x.BarCode == Barcode);
            return buyCentral;
        }
    }

}
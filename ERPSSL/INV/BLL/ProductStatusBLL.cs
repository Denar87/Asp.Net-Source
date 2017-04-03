using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ERPSSL.INV.DAL;
using ERPSSL.INV.DAL.Repository;

namespace ERPSSL.INV.BLL
{
    public class ProductStatusBLL
    {
        ProductStatusDAL productStatusDAL = new ProductStatusDAL();

        internal List<Inv_Product> GetProductStatus(string Ocode)
        {
            return productStatusDAL.GetProductStatus(Ocode);
        }

        internal Inv_BuyCentral GetProductQtyformBuyCentral(productsDetails aitem)
        {
            return productStatusDAL.GetProductQtyformBuyCentral(aitem);
        }
    }
}
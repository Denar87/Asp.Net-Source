using ERPSSL.LC.DAL;
using ERPSSL.Production.DAL;
using ERPSSL.Production.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPSSL.Production.BLL
{
    public class WashingBLL
    {
        WashingDAL _washingdal = new WashingDAL();


        internal int InsertProdWashing(Prod_Washing _objProdWashing)
        {
            return _washingdal.InsertProdWashing(_objProdWashing);
        }

        internal int UpdateProdWashing(Prod_Washing _objProdWashing)
        {
            return _washingdal.UpdateProdWashing(_objProdWashing);
        }

        internal List<WashingDetailsR> GetWashingDetails(string OCODE)
        {
            return _washingdal.GetWashingDetails(OCODE);
        }

        internal List<WashingDetailsR> GetWashingDetailsByOrderNo(string orderNo, string OCODE)
        {
            return _washingdal.GetWashingDetailsByOrderNo(orderNo, OCODE);
        }

        internal Prod_Washing GetWashinggbyId(int wID)
        {
            return _washingdal.GetWashinggbyId(wID);
        }

    }
}
using ERPSSL.LC.DAL;
using ERPSSL.Production.DAL;
using ERPSSL.Production.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPSSL.Production.BLL
{
    public class FinishingBLL
    {
        FinishingDAL _finishingdal = new FinishingDAL();

        internal int InsertProdFinishing(Prod_Finishing _objProdFinishing)
        {
            return _finishingdal.InsertProdFinishing(_objProdFinishing);
        }

        internal int UpdateProdFinishing(Prod_Finishing _objProdFinishing)
        {
            return _finishingdal.UpdateProdFinishing(_objProdFinishing);
        }

        internal Prod_Finishing GetFinishingbyId(int fID)
        {
            return _finishingdal.GetFinishingbyId(fID);
        }

        internal List<FinishingDetailsR> GetFinishingDetails(string OCODE)
        {
            return _finishingdal.GetFinishingDetails(OCODE);
        }

        internal List<FinishingDetailsR> GetFinishingDetailsByOrderNo(string orderNo, string OCODE)
        {
            return _finishingdal.GetFinishingDetailsByOrderNo(orderNo, OCODE);
        }
    }
}
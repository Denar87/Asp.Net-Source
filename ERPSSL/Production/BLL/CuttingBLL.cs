using ERPSSL.LC.DAL;
using ERPSSL.Production.DAL;
using ERPSSL.Production.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPSSL.Production.BLL
{

    public class CuttingBLL
    {
        CuttingDAL _cuttingdal = new CuttingDAL();

        internal List<string> GetSeason(string OCode)
        {
            return _cuttingdal.GetSeason(OCode);
        }

        internal List<string> GetStyleBySeason(string season)
        {
            return _cuttingdal.GetStyleBySeason(season);
        }

        internal List<string> GetOrderByStyle(string style)
        {
            return _cuttingdal.GetOrderByStyle(style);
        }

        internal List<OrderDetails> GetOrdersDetails(string OCODE)
        {
            return _cuttingdal.GetOrdersDetails(OCODE);
        }
        internal List<OrderDetails> GetOrdersDetailsByOrderNo(string orderNo, string OCODE)
        {
            return _cuttingdal.GetOrdersDetailsByOrderNo(orderNo, OCODE);
        }

        internal int InsertProdCutting(Prod_Cutting _objProdCutting)
        {
            return _cuttingdal.InsertProdCutting(_objProdCutting);
        }
        internal List<Inv_Unit> GetUnitForMarchandising()
        {
            return _cuttingdal.GetUnitForMarchandising();
        }

        internal List<CuttingDetailsR> GetCuttingDetails(string OCODE)
        {
            return _cuttingdal.GetCuttingDetails(OCODE);
        }

        internal List<CuttingDetailsR> GetCuttingDetailsByOrderNo(string orderNo, string OCODE)
        {
            return _cuttingdal.GetCuttingDetailsByOrderNo(orderNo, OCODE);
        }

        internal int UpdateProdCutting(Prod_Cutting _objProdCutting)
        {
            return _cuttingdal.UpdateProdCutting(_objProdCutting);
        }

        internal Prod_Cutting GetCuttingbyId(int cID)
        {
            return _cuttingdal.GetCuttingbyId(cID);
        }      
    }
}
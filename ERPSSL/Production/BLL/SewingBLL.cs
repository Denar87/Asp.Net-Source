using ERPSSL.LC.DAL;
using ERPSSL.Production.DAL;
using ERPSSL.Production.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPSSL.Production.BLL
{
    public class SewingBLL
    {
        SewingDAL _sewingdal = new SewingDAL();

        internal List<CuttingDetailsR> GetCuttingDetails(string OCODE)
        {
            return _sewingdal.GetCuttingDetails(OCODE);
        }

        internal List<CuttingDetailsR> GetCuttingDetailsByOrderNo(string orderNo, string OCODE)
        {
            return _sewingdal.GetCuttingDetailsByOrderNo(orderNo, OCODE);
        }
       
        internal int InsertProdSewing(Prod_Sewing _objProdSewing)
        {
            return _sewingdal.InsertProdSewing(_objProdSewing);
        }

        internal int UpdateProdCutting(Prod_Sewing _objProdSewing)
        {
            return _sewingdal.UpdateProdCutting(_objProdSewing);
        }


        internal List<SewingDetailsR> GetSewingDetails(string OCODE)
        {
            return _sewingdal.GetSewingDetails(OCODE);
        }

        internal List<SewingDetailsR> GetSewingDetailsByOrderNo(string orderNo, string OCODE)
        {
            return _sewingdal.GetSewingDetailsByOrderNo(orderNo, OCODE);
        }

        internal Prod_Sewing GetCuttingbyId(int sID)
        {
            return _sewingdal.GetCuttingbyId(sID);
        }

    }
}
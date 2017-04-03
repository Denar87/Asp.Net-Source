using ERPSSL.LC.DAL;
using ERPSSL.Production.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPSSL.Production.BLL
{
    public class DailyProductionDetailsBLL
    {
        ERPSSL_LCEntities _Content = new ERPSSL_LCEntities();

        DailyProductionDetailsDAL _dailyProductionDetailsDAL = new DailyProductionDetailsDAL();


        internal int InsertProductionDetails(Prod_ProductionStatusDetails _objProductionStatusDetails)
        {
            return _dailyProductionDetailsDAL.InsertProductionDetails(_objProductionStatusDetails);
        }

        internal List<LC_OrderEntry> GetOrderlist(string ocode)
        {
            return _dailyProductionDetailsDAL.GetOrderlist(ocode);
        }
    }
}
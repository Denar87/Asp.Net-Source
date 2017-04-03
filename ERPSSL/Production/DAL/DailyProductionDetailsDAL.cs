using ERPSSL.LC.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPSSL.Production.DAL
{
    public class DailyProductionDetailsDAL
    {
        ERPSSL_LCEntities _Context = new ERPSSL_LCEntities();

        internal int InsertProductionDetails(Prod_ProductionStatusDetails _objProductionStatusDetails)
        {
            try
            {
                _Context.Prod_ProductionStatusDetails.AddObject(_objProductionStatusDetails);
                _Context.SaveChanges();
                return 1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal List<LC_OrderEntry> GetOrderlist(string ocode)
        {
            try
            {
                var ItemName = (from IName in _Context.LC_OrderEntry
                                where IName.OCODE == ocode
                                select IName);
                return ItemName.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
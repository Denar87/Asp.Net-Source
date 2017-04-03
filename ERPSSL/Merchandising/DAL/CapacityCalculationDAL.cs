using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPSSL.Merchandising.DAL
{
    public class CapacityCalculationDAL
    {
        ERPSSL_MerchandisingEntities _Context = new ERPSSL_MerchandisingEntities();

        internal List<LC_tbl_DateTemp> GetDates(string OCode)
        {
            try
            {
                var query = (from col in _Context.LC_tbl_DateTemp
                             where col.OCode == OCode
                            select col).OrderBy(x => x.Datetime);
                return query.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }
    }
}
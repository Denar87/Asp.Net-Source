using ERPSSL.Merchandising.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPSSL.Merchandising.BLL
{
    public class CapacityCalculationBLL
    {
        CapacityCalculationDAL _CapacityCalculationDal = new CapacityCalculationDAL();
        internal List<LC_tbl_DateTemp> GetDates(string OCode)
        {
            return _CapacityCalculationDal.GetDates(OCode);
        }
    }
}
using ERPSSL.Production.DAL;
using ERPSSL.Production.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPSSL.Production.BLL
{
    public class ReportBLL
    {
        ReportDAL _reportdal = new ReportDAL();

        internal List<ReportR> GetDailyProductionDetails(string OCode)
        {
            return _reportdal.GetDailyProductionDetails(OCode);
        }

        internal List<ProductionR> GetTnaReport(string OCode)
        {
            return _reportdal.GetTnaReport(OCode);
        }

       
    }
}
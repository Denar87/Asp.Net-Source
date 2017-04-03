using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Collections;
using ERPSSL.Procurement.DAL;

namespace ERPSSL.Procurement.BLL
{
    public class PRQReports
    {

        internal static DataTable GetRequisitionReportData(Hashtable ht)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = DataAccess.GetDataByProc(ht, "PRQ_RequisitionReports_RPT");
            }
            catch { }
            return dt;
        }
    }
}
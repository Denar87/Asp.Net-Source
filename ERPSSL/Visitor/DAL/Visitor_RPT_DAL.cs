using ERPSSL.Visitor.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ERPSSL.Visitor.DAL
{
    public class Visitor_RPT_DAL
    {
        ERPSSL_Visitor_Entities _context = new ERPSSL_Visitor_Entities();

        internal List<Visitor_Details> GetAllVisitorRptByDate(DateTime fromdate, DateTime todate)
        {
            try
            {
                using (var _context = new ERPSSL_Visitor_Entities())
                {
                    var Fdate = new SqlParameter("@fromdate", fromdate);
                    var Tod = new SqlParameter("@Todate", todate);
                    string SP_SQL = "Visitor_rpt_VisitorByfromDatetoDate @fromdate,@Todate";
                    return (_context.ExecuteStoreQuery<Visitor_Details>(SP_SQL, Fdate, Tod)).ToList();
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        internal List<Visitor_Details> GetAllVisitorRpt(string OCODE)
        {
            try
            {
                using (var _context = new ERPSSL_Visitor_Entities())
                {

                    var Ocode = new SqlParameter("@OCODE", OCODE);
                    string SP_SQL = "Visitor_rpt_AllVisitor @OCODE";
                    return (_context.ExecuteStoreQuery<Visitor_Details>(SP_SQL, Ocode)).ToList();
                }

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
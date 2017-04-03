using ERPSSL.Visitor.DAL;
using ERPSSL.Visitor.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPSSL.Visitor.BLL
{
    public class Visitor_RPT_BLL
    {
        Visitor_RPT_DAL sVisitor_RPT_DAL = new Visitor_RPT_DAL();


        internal List<Visitor_Details> GetAllVisitorRptByDate(DateTime fromdate, DateTime todate)
        {
            return sVisitor_RPT_DAL.GetAllVisitorRptByDate(fromdate, todate);
        }

        internal List<Visitor_Details> GetAllVisitorRpt(string OCODE)
        {
            return sVisitor_RPT_DAL.GetAllVisitorRpt(OCODE);
        }
    }
}
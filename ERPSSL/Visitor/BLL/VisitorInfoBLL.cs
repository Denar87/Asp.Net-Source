using ERPSSL.Visitor.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPSSL.Visitor.BLL
{
    public class VisitorInfoBLL
    {
        VisitorInfoDAL sVisitorInfoDAL = new VisitorInfoDAL();

        internal int insertVisitorInfo(Visitor_VisitorInfo sVisitor_VisitorInfo)
        {
            return sVisitorInfoDAL.insertVisitorInfo(sVisitor_VisitorInfo);
        }

        internal List<Visitor_VisitorInfo> GetAllVisitor(string OCODE)
        {
            return sVisitorInfoDAL.GetAllVisitor(OCODE);
        }

        internal List<Visitor_VisitorInfo> getVisitorByVisitoridandCode(string visitorId, string OCODE)
        {
            return sVisitorInfoDAL.getVisitorByVisitoridandCode(visitorId, OCODE);
        }



        internal int UpdateVisitorInfo(Visitor_VisitorInfo sVisitor_VisitorInfo, int VisitorId)
        {
            return sVisitorInfoDAL.UpdateVisitorInfo(sVisitor_VisitorInfo, VisitorId);
        }

        internal List<Visitor_VisitorInfo> GetAllVisitorByDate(DateTime fromdate, DateTime todate)
        {
            return sVisitorInfoDAL.GetAllVisitorByDate(fromdate, todate);
        }

        internal List<Visitor_VisitorInfo> GetAllVisitorBySearchItem(string SearchItem, string OCODE)
        {
            return sVisitorInfoDAL.GetAllVisitorBySearchItem(SearchItem, OCODE);
        }
    }
}
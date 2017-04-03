using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ERPSSL.Visitor.DAL
{
    public class VisitorInfoDAL
    {
        ERPSSL_Visitor_Entities _context = new ERPSSL_Visitor_Entities();

        internal int insertVisitorInfo(Visitor_VisitorInfo sVisitor_VisitorInfo)
        {
            _context.Visitor_VisitorInfo.AddObject(sVisitor_VisitorInfo);
            _context.SaveChanges();
            return 1;
        }

        internal List<Visitor_VisitorInfo> GetAllVisitor(string OCODE)
        {
            try
            {
                var query = (from vis in _context.Visitor_VisitorInfo
                             where vis.OCODE == OCODE
                             select vis).OrderBy(x => x.VisitorName);


                return query.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        internal List<Visitor_VisitorInfo> getVisitorByVisitoridandCode(string visitorId, string OCODE)
        {
            int VisitorId = Convert.ToInt32(visitorId);
            List<Visitor_VisitorInfo> visitors = (from visi in _context.Visitor_VisitorInfo
                                                  where visi.OCODE == OCODE && visi.V_ID == VisitorId
                                                  select visi).OrderBy(x => x.V_ID).ToList<Visitor_VisitorInfo>();
            return visitors;
        }

        internal int UpdateVisitorInfo(Visitor_VisitorInfo sVisitor_VisitorInfo, int VisitorId)
        {
            try
            {
                Visitor_VisitorInfo obj = _context.Visitor_VisitorInfo.First(x => x.V_ID == VisitorId);
                obj.VisitorName = sVisitor_VisitorInfo.VisitorName;
                obj.FromAddress = sVisitor_VisitorInfo.FromAddress;
                obj.Phone = sVisitor_VisitorInfo.Phone;
                obj.ToWhom = sVisitor_VisitorInfo.ToWhom;
                obj.Purpose = sVisitor_VisitorInfo.Purpose;
                obj.CardNo = sVisitor_VisitorInfo.CardNo;
                obj.InTime = sVisitor_VisitorInfo.InTime;
                obj.OutTime = sVisitor_VisitorInfo.OutTime;

                obj.Edit_Date = sVisitor_VisitorInfo.Edit_Date;
                obj.Edit_User = sVisitor_VisitorInfo.Edit_User;

                _context.SaveChanges();
                return 1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal List<Visitor_VisitorInfo> GetAllVisitorByDate(DateTime fromdate, DateTime todate)
        {
            try
            {
                using (var _context = new ERPSSL_Visitor_Entities())
                {
                    var Fdate = new SqlParameter("@fromdate", fromdate);
                    var Tod = new SqlParameter("@Todate", todate);
                    string SP_SQL = "Visitor_VisitorByDatetoDate @fromdate,@Todate";
                    return (_context.ExecuteStoreQuery<Visitor_VisitorInfo>(SP_SQL, Fdate, Tod)).ToList();
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        internal List<Visitor_VisitorInfo> GetAllVisitorBySearchItem(string SearchItem, string OCODE)
        {
            try
            {
                using (var _context = new ERPSSL_Visitor_Entities())
                {
                    var SItem = new SqlParameter("@SearchItem", SearchItem);
                    var Ocode = new SqlParameter("@OCODE", OCODE);
                    string SP_SQL = "Visitor_VisitorByDifferentItem @SearchItem,@OCODE";
                    return (_context.ExecuteStoreQuery<Visitor_VisitorInfo>(SP_SQL, SItem, Ocode)).ToList();
                }

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
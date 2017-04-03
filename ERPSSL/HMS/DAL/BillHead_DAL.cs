using ERPSSL.HMS.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ERPSSL.HMS.DAL
{
    public class BillHead_DAL
    {
        private ERPSSL_HMSEntities _context = new ERPSSL_HMSEntities();

        internal int InsertBillHead(HMS_BillHead objBillHead)
        {
            try
            {
                _context.HMS_BillHead.AddObject(objBillHead);
                _context.SaveChanges();
                return 1;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        //public virtual List<HMS_BillHead> GetAllBillHead(string OCODE)
        //{

        //    try
        //    {
        //        var query = (from head in _context.HMS_BillHead
        //                     where head.OCODE == OCODE
        //                     select head).OrderBy(x => x.Bill_Head_Name);


        //        return query.ToList();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message.ToString());
        //    }
        //}

        internal IEnumerable<BillHeadR> GetBillHead(string OCODE)
        {
            using (var _context = new ERPSSL_HMSEntities())
            {
                var ParamempID = new SqlParameter("@OCODE", OCODE);

                string SP_SQL = "HMS_GetBillHeadList @OCODE";

                return (_context.ExecuteStoreQuery<BillHeadR>(SP_SQL, ParamempID)).ToList();
            }
        }

        internal int UpdateBillHead(HMS_BillHead objHead, int headId)
        {

            try
            {
                HMS_BillHead obj = _context.HMS_BillHead.First(x => x.HMS_Bill_Head_Id == headId);
                obj.HMS_CategoryId = objHead.HMS_CategoryId;
                obj.Bill_Head_Name = objHead.Bill_Head_Name;
                obj.Price = objHead.Price;
                obj.Edit_User = objHead.Edit_User;
                obj.Edit_Date = objHead.Edit_Date;
                _context.SaveChanges();
                return 1;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        internal List<HMS_BillHead> GetBillHeadByheadId(string headId, string OCODE)
        {
            int Id = Convert.ToInt32(headId);


            List<HMS_BillHead> BillHead = (from billHead in _context.HMS_BillHead
                                                   where billHead.OCODE == OCODE && billHead.HMS_Bill_Head_Id == Id
                                               select billHead).OrderBy(x => x.HMS_Bill_Head_Id).ToList<HMS_BillHead>();
            return BillHead;

        }

        internal List<HMS_BillCategory> GetCategoryList()
        {
            try
            {
                List<HMS_BillCategory> _BillCategory = (from s in _context.HMS_BillCategory
                                                         select s).ToList();
                return _BillCategory;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

      

    }
}
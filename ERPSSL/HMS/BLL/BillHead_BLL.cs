using ERPSSL.HMS.DAL;
using ERPSSL.HMS.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPSSL.HMS.BLL
{
    public class BillHead_BLL
    {
        BillHead_DAL objHead_DAL = new BillHead_DAL();

        internal int InsertBillHead(HMS_BillHead objBillHead)
        {
            return objHead_DAL.InsertBillHead(objBillHead);
        }
        //public virtual List<HMS_BillHead> GetAllBillHead(string OCODE)
        //{
        //    return objHead_DAL.GetAllBillHead(OCODE);
        //}

        internal int UpdateBillHead(HMS_BillHead objHead, int headId)
        {
            return objHead_DAL.UpdateBillHead(objHead, headId);
        }
        internal List<HMS_BillHead> GetBillHeadByheadId(string headId, string OCODE)
        {
            return objHead_DAL.GetBillHeadByheadId(headId, OCODE);
        }
        internal List<HMS_BillCategory> GetCategoryList()
        {
            return objHead_DAL.GetCategoryList();
        }
        internal IEnumerable<BillHeadR> GetBillHead(string OCODE)
        {
            return objHead_DAL.GetBillHead(OCODE);
        }
    }
}
using ERPSSL.HMS.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPSSL.HMS.BLL
{
    public class BillCategory_BLL
    {
        BillCategory_DAL objCategory_DAL = new BillCategory_DAL();

        internal int InsertBillCategory(HMS_BillCategory objBillCtg)
        {
            return objCategory_DAL.InsertBillCategory(objBillCtg);
        }
        public virtual List<HMS_BillCategory> GetAllBillCategory(string OCODE)
        {
            return objCategory_DAL.GetAllBillCategory(OCODE);
        }

        internal int UpdateBillCategory(HMS_BillCategory objCtg, int catId)
        {
            return objCategory_DAL.UpdateBillCategory(objCtg,catId );
        }

        internal List<HMS_BillCategory> GetBillCategoryoByCategoryId(string categoryId, string OCODE)
        {
            return objCategory_DAL.GetBillCategoryoByCategoryId(categoryId,OCODE);
        }
    }
}
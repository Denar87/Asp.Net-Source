using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPSSL.HMS.DAL
{
    public class BillCategory_DAL
    {
        private ERPSSL_HMSEntities _context = new ERPSSL_HMSEntities();

        internal int InsertBillCategory(HMS_BillCategory objBillCtg)
        {
            try
            {
                _context.HMS_BillCategory.AddObject(objBillCtg);
                _context.SaveChanges();
                return 1;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public virtual List<HMS_BillCategory> GetAllBillCategory(string OCODE)
        {

            try
            {
                var query = (from ctg in _context.HMS_BillCategory
                             where ctg.OCODE == OCODE
                             select ctg).OrderBy(x => x.CategoryName);


                return query.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        internal int UpdateBillCategory(HMS_BillCategory objCtg, int catId)
        {

            try
            {
                HMS_BillCategory obj = _context.HMS_BillCategory.First(x => x.HMS_CategoryId == catId);
                obj.CategoryName = objCtg.CategoryName;
                obj.Edit_User = objCtg.Edit_User;
                obj.Edit_Date = objCtg.Edit_Date;
                _context.SaveChanges();
                return 1;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        internal List<HMS_BillCategory> GetBillCategoryoByCategoryId(string categoryId, string OCODE)
        {
            int Id = Convert.ToInt32(categoryId);


            List<HMS_BillCategory> BillCategory = (from billCat in _context.HMS_BillCategory
                                                where billCat.OCODE == OCODE && billCat.HMS_CategoryId == Id
                                                select billCat).OrderBy(x => x.HMS_CategoryId).ToList<HMS_BillCategory>();
            return BillCategory;

        }
    }
}
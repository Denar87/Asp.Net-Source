using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPSSL.POS.DAL
{
    public class FoodSaleDAL
    {
        private POS_Entities _context = new POS_Entities();

        internal decimal GetFoodSalesForToday(string OCODE)
        {
            try
            {
                DateTime today = DateTime.Now.Date;
                //return context.CRM_Complain.Count();

                var query = (from co in _context.TR_Tbl_FoodSales
                             select co).Where(x => x.EditDate > today).ToList();

                return query.Sum(s => s.ItemTotal);


            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}
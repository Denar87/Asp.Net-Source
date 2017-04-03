using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPSSL.POS.DAL
{
    public class ITEM_DAL
    {
        private POS_Entities _context = new POS_Entities();

        public virtual List<LU_Tbl_Item> GetAllItem()
        {
            var query = (from Item in _context.LU_Tbl_Item
                         select Item).OrderBy(x => x.Id);
            return query.ToList();
        }

        public virtual List<LU_Tbl_Item> GetFoodItem()
        {
            var query = (from Item in _context.LU_Tbl_Item
                         where Item.ItemGroupName == "Food"
                         select Item).OrderBy(x => x.ItemName);
            return query.ToList();
        }

        public virtual List<LU_Tbl_Item> GetTicketItem()
        {
            var query = (from Item in _context.LU_Tbl_Item
                         where Item.ItemGroupName == "Ticket"
                         select Item).OrderBy(x => x.ItemName);
            return query.ToList();
        }

        public int InsertItem(LU_Tbl_Item objItem)
        {
            try
            {
                _context.LU_Tbl_Item.AddObject(objItem);
                _context.SaveChanges();
                return 1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int UpdateItem(LU_Tbl_Item objItem, int itemId)
        {
            try
            {
                LU_Tbl_Item obj = _context.LU_Tbl_Item.First(x => x.Id == itemId);
                obj.ItemName = objItem.ItemName;
                obj.Description = objItem.Description;
                obj.Price = objItem.Price;
                obj.ItemGroupName = objItem.ItemGroupName;
                obj.VAT = objItem.VAT;
                obj.DiscountAmount = objItem.DiscountAmount;
                obj.Status = objItem.Status;
                _context.SaveChanges();
                return 1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
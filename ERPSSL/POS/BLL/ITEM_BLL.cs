using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ERPSSL.POS.DAL;
using SSL.FA.DAL;

namespace ERPSSL.POS.BLL
{
    public class ITEM_BLL
    {
        DAL.ITEM_DAL objCtx_DAL = new DAL.ITEM_DAL();

        public virtual List<LU_Tbl_Item> GetAllItem()
        {

            return objCtx_DAL.GetAllItem();
        }

        public virtual List<LU_Tbl_Item> GetFoodItem()
        {
            return objCtx_DAL.GetFoodItem();
        }

        public virtual List<LU_Tbl_Item> GetTicketItem()
        {
            return objCtx_DAL.GetTicketItem();
        }

        public int InsertItem(LU_Tbl_Item objItem)
        {
            return objCtx_DAL.InsertItem(objItem);
        }

        public int UpdateItem(LU_Tbl_Item objItem, int itemId)
        {
            return objCtx_DAL.UpdateItem(objItem, itemId);
        }

        internal bool DeleteItem(int itemId)
        {
            try
            {
                DataAccess.AggRetrive("delete from LU_Tbl_Item where Id = '" + itemId + "'");
                return true;
            }
            catch
            {
                return false;
            }
        }


    }
}
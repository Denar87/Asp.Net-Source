using ERPSSL.Merchandising.DAL;
using ERPSSL.Merchandising.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPSSL.Merchandising.BLL
{
    public class OrderItemsBLL
    {
        OrderItemsDAL aOrderItemsDAL = new OrderItemsDAL();

        internal List<LC_GmtItem> GetAllGMTItems(string ocode)
        {
            return aOrderItemsDAL.GetAllGMTItems(ocode);
        }

        internal int SaveGMTItems(LC_GmtItem aLC_GmtItem)
        {
            return aOrderItemsDAL.SaveGMTItems(aLC_GmtItem);
        }

        internal int Save_LC_To_Temp(LC_Size_Temp aLC_Size_Temp)
        {
            return aOrderItemsDAL.Save_LC_To_Temp(aLC_Size_Temp);
        }

        internal List<ItemsRepo> LoadDataForGrid(string ocode, Guid User, int workOrderId)
        {
            return aOrderItemsDAL.LoadDataForGrid(ocode,User, workOrderId);
        }



        internal int DeleteItem(int id)
        {
            return aOrderItemsDAL.DeleteItem(id);
        }

        internal void SaveIntoOriginal(LC_Size aLC_Size)
        {
            aOrderItemsDAL.SaveIntoOriginal(aLC_Size);
        }

        internal List<ItemsRepo> LoadConfirmDataForGrid(string ocode, Guid User, int workOrderId)
        {
            return aOrderItemsDAL.LoadConfirmDataForGrid(ocode, User, workOrderId);
        }

        internal List<LC_Color> GetAllColor(string OCode)
        {
            return aOrderItemsDAL.GetAllColor(OCode);
        }
    }
}
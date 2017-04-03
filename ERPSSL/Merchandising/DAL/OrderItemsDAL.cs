using ERPSSL.Merchandising.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPSSL.Merchandising.DAL
{
    public class OrderItemsDAL
    {
        ERPSSL_MerchandisingEntities _Context = new ERPSSL_MerchandisingEntities();

        internal List<LC_GmtItem> GetAllGMTItems(string ocode)
        {
            try
            {
                var gmtItems = (from g in _Context.LC_GmtItem
                                where g.OCode == ocode
                                select g);
                return gmtItems.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        internal int SaveGMTItems(LC_GmtItem aLC_GmtItem)
        {

            using (var _Context = new ERPSSL_MerchandisingEntities())
            {
                _Context.LC_GmtItem.AddObject(aLC_GmtItem);
                _Context.SaveChanges();
                return aLC_GmtItem.GmtItem_Id;
            }

        }

        internal int Save_LC_To_Temp(LC_Size_Temp aLC_Size_Temp)
        {
            using (var _Context = new ERPSSL_MerchandisingEntities())
            {
                _Context.LC_Size_Temp.AddObject(aLC_Size_Temp);
                _Context.SaveChanges();
                return aLC_Size_Temp.Size_Id;
            }
        }

        internal List<ItemsRepo> LoadDataForGrid(string ocode, Guid User, int workOrderId)
        {
            try
            {
                var query = (from o in _Context.LC_Size_Temp
                             join g in _Context.LC_GmtItem on o.GMTItem equals g.GmtItem_Id
                             where o.OCode == ocode && o.CreateUser == User && o.OrderNo == workOrderId
                             select new ItemsRepo
                             {
                                 SizeId = (int)o.Size_Id,
                                 OrderNo = (int)o.OrderNo,
                                 StyleNo = (int)o.StyleNo,
                                 GMTId = (int)g.GmtItem_Id,
                                 GMTItemName = g.Gmt_Name,
                                 ArticleNo = o.Articale,
                                 ColorID = o.ColorID,
                                 Size = o.Size,
                                 Quantity = (int)o.Qty,
                                 Rate = (decimal)o.Price,
                                 TotalAmount = (decimal)o.TotalAmount
                             }

                             );

                return query.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal int DeleteItem(int id)
        {
            LC_Size_Temp Fl = _Context.LC_Size_Temp.First(x => x.Size_Id == id);
            _Context.LC_Size_Temp.DeleteObject(Fl);
            _Context.SaveChanges();
            return 1;
        }

        internal void SaveIntoOriginal(LC_Size aLC_Size)
        {
            using (var _Context = new ERPSSL_MerchandisingEntities())
            {
                _Context.LC_Size.AddObject(aLC_Size);
                _Context.SaveChanges();
            }
        }

        internal List<ItemsRepo> LoadConfirmDataForGrid(string ocode, Guid User, int workOrderId)
        {
            try
            {
                var query = (from o in _Context.LC_Size
                             join g in _Context.LC_GmtItem on o.GMTItem equals g.GmtItem_Id
                             where o.OCode == ocode && o.CreateUser == User && o.OrderNo == workOrderId
                             select new ItemsRepo
                             {
                                 SizeId = (int)o.Size_Id,
                                 OrderNo = (int)o.OrderNo,
                                 StyleNo = (int)o.StyleNo,
                                 GMTId = (int)g.GmtItem_Id,
                                 GMTItemName = g.Gmt_Name,
                                 ArticleNo = o.Articale,
                                 ColorID = o.ColorID,
                                 Size = o.Size,
                                 Quantity = (int)o.Qty,
                                 Rate = (decimal)o.Price,
                                 TotalAmount = (decimal)o.TotalAmount
                             }

                             );

                return query.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal List<LC_Color> GetAllColor(string OCode)
        {
            try
            {
                var gmtItems = (from g in _Context.LC_Color
                                where g.OCODE == OCode
                                select g);
                return gmtItems.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
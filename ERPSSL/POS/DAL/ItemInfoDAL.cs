using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ERPSSL.POS.DAL
{
    public class ItemInfoDAL
    {
        private POS_Entities _context = new POS_Entities();

        internal List<LU_Tbl_Item> GetAlLPackage()
        { 
            try
            {
                var projects = (from prj in _context.LU_Tbl_Item
                                where prj.ItemGroupName=="Ticket"
                                select prj).OrderBy(x => x.ItemName);
                return projects.ToList();

            }
            catch (Exception)
            { 
                throw;
            }
        }

        internal List<LU_Tbl_Item> GetAllPackageItemName()
        {
            try
            {
                var projects = (from prj in _context.LU_Tbl_Item
                                where prj.ItemGroupName == "Ticket"
                                select prj).OrderBy(x => x.ItemName);
                return projects.ToList();

            }
            catch (Exception)
            {

                throw;
            }
        }

        internal List<Tbl_PackageItemInfo> GetPackageInfo()
        {
            try
            {

                var projects = (from prj in _context.Tbl_PackageItemInfo

                                select prj).OrderBy(x => x.PackageItemName);


                return projects.ToList();

            }
            catch (Exception)
            {

                throw;
            }
        }

        internal List<Tbl_PackageItemInfo> GetId(string PackageId)
        {
            try
            {
                int packageId = Convert.ToInt32(PackageId);

                var package = (from prj in _context.Tbl_PackageItemInfo
                               where prj.PackageItemInfo_ID == packageId
                               select prj);
                return package.ToList();

            }
            catch (Exception)
            {
                throw;
            }
        }

        internal int SavePackageInfo(Tbl_PackageItemInfo packageItemInfo)
        {
            try
            {
                _context.Tbl_PackageItemInfo.AddObject(packageItemInfo);
                _context.SaveChanges();
                return 1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal int UpdateStore(Tbl_PackageItemInfo packageItemInfo, int ID)
        {
            try
            {
                Tbl_PackageItemInfo obj = _context.Tbl_PackageItemInfo.First(x => x.PackageItemInfo_ID == ID);
                obj.PackageName = packageItemInfo.PackageName;
                obj.PackageItemName = packageItemInfo.PackageItemName;
                obj.Price = packageItemInfo.Price;
                obj.Quantity = packageItemInfo.Quantity;
                obj.Status = packageItemInfo.Status;
                _context.SaveChanges();
                return 1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal List<Tbl_PackageItemInfo> GetPackageInfobyID(int ID)
        {

            try
            {

                var projects = (from prj in _context.Tbl_PackageItemInfo
                                where prj.PackageID==ID
                                select prj).OrderBy(x => x.PackageName);


                return projects.ToList();

            }
            catch (Exception)
            {

                throw;
            }
        }

        internal List<LU_Tbl_Item> GetAllFoodItem()
        {
            try
            {
                var projects = (from prj in _context.LU_Tbl_Item
                                where prj.ItemGroupName =="Food" && prj.InventoryItemID==null
                                select prj).OrderBy(x => x.ItemName);
                return projects.ToList();

            }
            catch (Exception)
            {

                throw;
            }
        }
         //(ProductName +' - ' + Brand+' - '+StyleAndSize) as ProductName
        //try
        //{
        //    var projects = (from prj in _context.Inv_Product
        //                    where prj.GroupName == "Food"
        //                    select prj).OrderBy(x => x.ProductName);
        //    return projects.ToList();

        //}
        //catch (Exception)
        //{ 
        //    throw;
        //}
        internal List<Inv_Product> GetAllInventoryItem(string OCODE)
        { 
            try
            { 
                var O_CODE = new SqlParameter("OCode", OCODE); 
                string SP_SQL = "INV_GETITEMLISTBYOCODE @OCode";
                return (_context.ExecuteStoreQuery<Inv_Product>(SP_SQL, O_CODE)).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        internal int UpdateInventoryProduct(LU_Tbl_Item lutblitem, int Id)
        {
            try
            {
                LU_Tbl_Item obj = _context.LU_Tbl_Item.First(x => x.Id == Id); 
                obj.InventoryItemID = lutblitem.InventoryItemID;
                _context.SaveChanges();
                return 1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal List<LU_Tbl_Item> GetItemList()
        {
            try
            {

                var projects = (from prj in _context.LU_Tbl_Item
                                where prj.InventoryItemID!=null
                                select prj).OrderBy(x => x.ItemName); 
                return projects.ToList();

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
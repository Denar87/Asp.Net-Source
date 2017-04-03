using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ERPSSL.POS.DAL;

namespace ERPSSL.POS.BLL
{
    public class ItemInfoBLL
    {
        ItemInfoDAL aItemInfoDal=new ItemInfoDAL();

        internal List<LU_Tbl_Item> GetAlLPackage()
        {
            return aItemInfoDal.GetAlLPackage();
        }

        internal List<LU_Tbl_Item> GetAllPackageItemName()
        {
            return aItemInfoDal.GetAllPackageItemName();
        }

        internal int SavePackageInfo(Tbl_PackageItemInfo packageItemInfo)
        {
            return aItemInfoDal.SavePackageInfo(packageItemInfo);
        }

        internal int UpdateStore(Tbl_PackageItemInfo packageItemInfo, int ID)
        {
            return aItemInfoDal.UpdateStore(packageItemInfo, ID);
        }

        internal List<Tbl_PackageItemInfo> GetPackageInfo()
        {
            return aItemInfoDal.GetPackageInfo();
        }

        internal List<Tbl_PackageItemInfo> GetId(string PackageId)
        {
            return aItemInfoDal.GetId(PackageId);
        }


        internal List<Tbl_PackageItemInfo> GetPackageInfobyID(int ID)
        {
            return aItemInfoDal.GetPackageInfobyID(ID);
        }

        internal List<LU_Tbl_Item> GetAllFoodItem()
        {
            return aItemInfoDal.GetAllFoodItem();
        }

        internal List<Inv_Product> GetAllInventoryItem(string OCODE)
        {
            return aItemInfoDal.GetAllInventoryItem(OCODE);
        }

        internal int UpdateInventoryProduct(LU_Tbl_Item lutblitem, int Id)
        {
            return aItemInfoDal.UpdateInventoryProduct(lutblitem, Id);
        }

        internal List<LU_Tbl_Item> GetItemList()
        {
            return aItemInfoDal.GetItemList();
        }
    }
}



 
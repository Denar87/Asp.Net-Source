using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ERPSSL.INV.DAL;

namespace ERPSSL.INV.BLL
{
    public class GroupBLL
    {
        GroupDAL groupDal = new GroupDAL();
        
        internal int InsertGroup(Inv_ProductGroup groupObj)
        {
            return groupDal.InsertGroup(groupObj);
        }

        internal List<Inv_ProductGroup> GetAllGroup()
        {
            return groupDal.GetAllGroup();
        }

        

        internal List<Inv_ProductGroup> GetGroupById(string groupId)
        {
            return groupDal.GetGroupById(groupId);
        }

        internal int UpdateGroup(Inv_ProductGroup groupObj, int groupId)
        {
            return groupDal.UpdateGroup(groupId, groupObj);
        }

        internal List<Inv_Product> GetAllProduct(int GroupId)
        {
            return groupDal.GetAllProduct(GroupId);
        }

        internal int UpdatePrice(Inv_Product invProduct, int ProductId, int GroupId)
        {
            return groupDal.UpdatePrice(invProduct, ProductId, GroupId);
        }
    }
}
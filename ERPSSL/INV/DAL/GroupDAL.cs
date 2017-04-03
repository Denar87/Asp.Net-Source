using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ERPSSL.INV.DAL;

namespace ERPSSL.INV.DAL
{
    public class GroupDAL
    {
        private ERPSSL_INVEntities _context = new ERPSSL_INVEntities();

        internal int InsertGroup(Inv_ProductGroup groupObj)
        {
            try
            {
                _context.Inv_ProductGroup.AddObject(groupObj);
                _context.SaveChanges();
                return 1;
            }
            catch (Exception)
            {
                throw;
            }
        }

        internal List<Inv_ProductGroup> GetAllGroup()
        {
            try
            {
                var groups = (from grp in _context.Inv_ProductGroup
                              select grp).OrderBy(x => x.GroupName);
                return groups.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        internal List<Inv_ProductGroup> GetGroupById(string groupId)
        {
            try
            {
                int grpId = Convert.ToInt32(groupId);

                //List<Inv_ProductGroup> Regions = (from reg in _context.Inv_ProductGroup
                //                                  where reg.GroupId == grpId
                //                                  select reg).OrderByDescending(x => x.GroupId).ToList<Inv_ProductGroup>();
                //return Regions;
                var groups = (from grp in _context.Inv_ProductGroup
                              where grp.GroupId == grpId
                              select grp);
               return groups.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        internal int UpdateGroup(int groupId, Inv_ProductGroup groupObj)
        {
            try
            {
                Inv_ProductGroup grpObj = _context.Inv_ProductGroup.First(x => x.GroupId == groupId);
                grpObj.GroupName = groupObj.GroupName;
                _context.SaveChanges();
                return 1;
            }
            catch (Exception)
            { 
                throw;
            }
        }

        internal List<Inv_Product> GetAllProduct(int GroupID)
        {
            try
            {
                var products = (from grp in _context.Inv_Product
                                where grp.GroupId == GroupID 
                                select grp).OrderBy(x => x.ProductName);
                return products.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        internal int UpdatePrice(Inv_Product invProduct, int ProductId, int GroupId)
        {
            try
            {
                Inv_Product attObj = _context.Inv_Product.First(x => x.ProductId == ProductId && x.GroupId == GroupId);
                attObj.Price = invProduct.Price;
                _context.SaveChanges();
                return 1;
            }
            catch (Exception)
            { 
                throw;
            }
        }
    }
}
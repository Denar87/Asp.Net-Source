using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ERPSSL.Adminpanel.DAL.Repository;
using ERPSSL.HRM.BLL;

namespace ERPSSL.Adminpanel.DAL
{

    public class CategoryDAL
    {
        ERPSSL_AdminEntities1 _context = new ERPSSL_AdminEntities1();
        internal int SaveCategory(tbl_Category categoryObj)
        {
            try
            {
                try
                {
                    _context.tbl_Category.AddObject(categoryObj);
                    _context.SaveChanges();
                    return 1;

                }
                catch (Exception)
                {

                    throw;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        internal IEnumerable<RCategory> CategoryesForgridview(string Ocode)
        {
            return (from ca in _context.tbl_Category
                    join c in _context.tbl_Module on ca.ModuleId equals c.ModuleID
                    where ca.OCODE == Ocode

                    select new RCategory
                    {
                        CategoryName = ca.Name,
                        ModuleName = c.ModuleName,
                        CategoryOrder = (int)ca.CategoryOrder,
                        CategoryId = (int)ca.categoryId,
                        Status = ca.Status
                    }).Distinct().OrderBy(x => x.ModuleName).ToList();
        }

        internal List<Category> getCategoryesById(string categorId, string OCODE)
        {
            try
            {
                int cId = Convert.ToInt32(categorId);
                //var categoryes = (from cate in _context.tbl_Category

                //                  where cate.OCODE == OCODE && cate.categoryId == cId
                //                  select cate);
                //return categoryes.ToList();

                using (var _context = new ERPSSL_AdminEntities1())
                {
                    return (from cate in _context.tbl_Category

                            where cate.OCODE == OCODE && cate.categoryId == cId

                            select new Category
                            {
                                CategoryName = cate.Name,
                                categoryid = (int)cate.categoryId
                            }).Distinct().ToList();

                }

            }
            catch (Exception)
            {

                throw;
            }

        }

        internal int UpdateCategoryById(int categoryId, tbl_Category categoryObj)
        {
            try
            {
                tbl_Category catobj = _context.tbl_Category.First(x => x.categoryId == categoryId);
                catobj.ModuleId = categoryObj.ModuleId;
                catobj.CategoryOrder = categoryObj.CategoryOrder;
                catobj.Name = categoryObj.Name;
                catobj.EDIT_USER = categoryObj.EDIT_USER;
                catobj.EDIT_DATE = categoryObj.EDIT_DATE;
                catobj.OCODE = categoryObj.OCODE;
                catobj.Status = categoryObj.Status;
                _context.SaveChanges();
                return 1;
            }
            catch (Exception)
            {

                throw;
            }
        }

        internal List<tbl_Category> getCategoryByModuleId(int moduleId, string Ocode)
        {

            try
            {
                int mId = Convert.ToInt32(moduleId);
                var categoryes = (from cate in _context.tbl_Category
                                  where cate.OCODE == Ocode && cate.ModuleId == mId
                                  select cate);
                return categoryes.ToList();

            }
            catch (Exception)
            {

                throw;
            }

        }



        internal List<tbl_Category> GetAllCategoryes(string Ocode)
        {
            try
            {

                var categoryes = (from cate in _context.tbl_Category
                                  where cate.OCODE == Ocode
                                  select cate);
                return categoryes.ToList();

            }
            catch (Exception)
            {

                throw;
            }

        }

        internal List<tbl_Category> getcCategoryesById(string categorId, string OCODE)
        {
            int cId = Convert.ToInt32(categorId);
            var categoryes = (from cate in _context.tbl_Category

                              where cate.OCODE == OCODE && cate.categoryId == cId
                              select cate);
            return categoryes.ToList();
        }

        internal List<tbl_Category> categoryListForOrderCheck(int id, string ocode)
        {

            var categoryes = (from cate in _context.tbl_Category
                              where cate.OCODE == ocode && cate.ModuleId == id
                              select cate);
            return categoryes.ToList();

        }

        internal IEnumerable<RCategory> CategoryesForgrid(string Ocode, int moduleId)
        {
            return (from ca in _context.tbl_Category
                    join c in _context.tbl_Module on ca.ModuleId equals c.ModuleID
                    where ca.OCODE == Ocode && ca.ModuleId == moduleId
                    select new RCategory
                    {
                        CategoryName = ca.Name,
                        ModuleName = c.ModuleName,
                        CategoryId = (int)ca.categoryId,
                        CategoryOrder = (int)ca.CategoryOrder
                    }).Distinct().OrderBy(x => x.CategoryOrder).ToList();
        }
    }
}
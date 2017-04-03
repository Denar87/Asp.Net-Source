using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ERPSSL.Adminpanel.DAL;
using ERPSSL.Adminpanel.DAL.Repository;
using ERPSSL.HRM.BLL;

namespace ERPSSL.Adminpanel.BLL
{
    public class CategoryBLL
    {
        CategoryDAL categoryDal = new CategoryDAL();
        internal int SaveCategory(tbl_Category categoryObj)
        {
            return categoryDal.SaveCategory(categoryObj);
        }

        internal IEnumerable<RCategory> CategoryesForgridview(string Ocode)
        {
            return categoryDal.CategoryesForgridview(Ocode);
        }

        internal List<Category> getCategoryesById(string categorId, string OCODE)
        {
            return categoryDal.getCategoryesById(categorId, OCODE);
        }
        internal List<tbl_Category> getcCategoryesById(string categorId, string OCODE)
        {
            return categoryDal.getcCategoryesById(categorId, OCODE);
        }

        internal int UpdateCategoryById(int categoryId, tbl_Category categoryObj)
        {
            return categoryDal.UpdateCategoryById(categoryId, categoryObj);

        }

        internal List<tbl_Category> getCategoryByModuleId(int moduleId, string Ocode)
        {
            return categoryDal.getCategoryByModuleId(moduleId, Ocode);
        }

        internal List<tbl_Category> GetAllCategoryes(string Ocode)
        {
            return categoryDal.GetAllCategoryes(Ocode);
        }



        internal List<tbl_Category> categoryListForOrderCheck(int id, string ocode)
        {
            return categoryDal.categoryListForOrderCheck(id, ocode);
        }

        internal IEnumerable<RCategory> CategoryesForgrid(string Ocode, int moduleId)
        {
            return categoryDal.CategoryesForgrid(Ocode, moduleId);
        }
    }
}
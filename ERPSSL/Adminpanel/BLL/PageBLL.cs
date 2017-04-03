using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ERPSSL.Adminpanel.DAL;
using ERPSSL.Adminpanel.DAL.Repository;
using ERPSSL.HRM.BLL;

namespace ERPSSL.Adminpanel.BLL
{
    public class PageBLL
    {
        PageDAL pageDal = new PageDAL();
        internal int SavePage(tbl_Page pageobj)
        {
            return pageDal.SavePage(pageobj);
        }

        internal IEnumerable<RPage> GetPages(string Ocode)
        {
            return pageDal.GetPages(Ocode);
        }

        internal List<tbl_Page> getPage(string PageId, string OCODE)
        {
            return pageDal.getPage(PageId, OCODE);
        }

        internal int UpdatePage(tbl_Page pageobj, int PageId)
        {
            return pageDal.UpdatePage(pageobj, PageId);
        }

        internal List<tbl_Page> GetPagesforPagePermission(string Ocode)
        {
            return pageDal.GetPagesforPagePermission(Ocode);
        }

        internal int SavePagePermission(List<tbl_PagePermission> pagePermissiones)
        {
            return pageDal.SavePagePermission(pagePermissiones);
        }



        internal List<tbl_Page> GetPagesByMouleId(string Ocode, int ModuleId)
        {
            return pageDal.GetPagesByMouleId(Ocode, ModuleId);

        }

        internal List<tbl_PagePermission> getPagePermissionByPageID(string Ocode, int pagePrmissionId)
        {
            return pageDal.getPagePermissionByPageID(Ocode, pagePrmissionId);
        }

        internal List<tbl_Page> GetPageByModulId(int ModuleId, string Ocode)
        {
            return pageDal.GetPageByModulId(Ocode, ModuleId);
        }

        internal IEnumerable<Category> GetCategoryByModulId(int ModuleId, string Ocode)
        {
            return pageDal.GetCategoryByModulId(Ocode, ModuleId);
        }

        internal List<tbl_Page> getPagesByCategory(string cateGoryId, string Ocode)
        {
            return pageDal.getPagesByCategory(cateGoryId, Ocode);
        }

        internal List<tbl_Page> getPagesByCategory(int categoryId, string Ocode)
        {
            return pageDal.getPagesByCategory(categoryId, Ocode);
        }

        internal List<RPagePermission> GetPagePermissionList(string Ocode)
        {
            return pageDal.GetPagePermissionList(Ocode);
        }

        internal List<tbl_PagePermission> GetPagePermissionByPagePermissionId(string pagePermissionId, string OCODE)
        {
            return pageDal.GetPagePermissionByPagePermissionId(OCODE, pagePermissionId);
        }

        internal int UpdatePagePermission(tbl_PagePermission pagePermissionobj, int pagePermissionId)
        {
            return pageDal.UpdatePagePermission(pagePermissionobj, pagePermissionId);
        }

        internal List<tbl_Page> getPagesByCategoryForSupperAdmin(string cateGoryId, string Ocode)
        {
            return pageDal.getPagesByCategoryForSupperAdmin(cateGoryId, Ocode);
        }

        internal List<tbl_PagePermission> getPagePermissionListByRoleId(string RoleId, string Ocode,int moduleId)
        {
            return pageDal.getPagePermissionListByRoleId(RoleId, Ocode, moduleId);
        }

        internal List<tbl_Page> getPagebyPageID(string pageId, string Ocode)
        {
            return pageDal.getPagebyPageID(pageId, Ocode);
        }

        internal List<PPermissionList> getPagePermissionByRoleId(string Ocode, int role)
        {
            return pageDal.getPagePermissionByRoleId(Ocode, role);
        }



        internal IEnumerable<Category> GetCategoryForUserByModulId(int ModuleId, string Ocode, Guid usrerId)
        {
            return pageDal.GetCategoryForUserByModulId(ModuleId, Ocode, usrerId);
        }



        internal List<RPage> getPagesByCategoryForUser(string cateGoryId, string Ocode, Guid use)
        {
            return pageDal.getPagesByCategoryForUser(cateGoryId, Ocode, use);
        }

        internal IEnumerable<RPage> CategoryesForgridValue(string Ocode, int catagoryValue)
        {
            return pageDal.CategoryesForgridValue(Ocode, catagoryValue);
        }

        internal List<tbl_PagePermission> GetPagePermissionListByRoleModuleCategoryWise(int Role, int ModuleId, int categoryId)
        {

            return pageDal.GetPagePermissionListByRoleModuleCategoryWise(Role, ModuleId, categoryId);
        }

        internal List<tbl_UserAccess> GetUserAccessByRoleAndUserID(int role, string UserName, string Ocode)
        {
            return pageDal.GetUserAccessByRoleAndUserID(role, UserName, Ocode);

        }
    }
}
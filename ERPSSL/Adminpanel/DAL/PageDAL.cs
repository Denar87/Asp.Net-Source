using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ERPSSL.Adminpanel.DAL.Repository;
using System.Data.SqlClient;
using ERPSSL.HRM.BLL;

namespace ERPSSL.Adminpanel.DAL
{
    public class PageDAL
    {
        DAL.ERPSSL_AdminEntities1 _context = new ERPSSL_AdminEntities1();
        internal int SavePage(tbl_Page pageobj)
        {
            try
            {
                _context.tbl_Page.AddObject(pageobj);
                _context.SaveChanges();
                return 1;

            }
            catch (Exception)
            {

                throw;
            }
        }

        internal IEnumerable<RPage> GetPages(string Ocode)
        {
            try
            {
                using (var _context = new ERPSSL_AdminEntities1())
                {
                    var ParamempID = new SqlParameter("@OCODE", Ocode);

                    string SP_SQL = "Adp_GetPageList @OCODE";

                    return (_context.ExecuteStoreQuery<RPage>(SP_SQL, ParamempID)).ToList();
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        internal List<tbl_Page> getPage(string PageId, string OCODE)
        {
            try
            {
                int pId = Convert.ToInt32(PageId);
                var pages = (from page in _context.tbl_Page
                             where page.OCODE == OCODE && page.PageID == pId
                             select page);
                return pages.ToList();
            }
            catch (Exception)
            {

                throw;
            }

        }

        internal int UpdatePage(tbl_Page pageobj, int PageId)
        {
            try
            {
                tbl_Page pobj = _context.tbl_Page.First(x => x.PageID == PageId);
                pobj.ModuleID = pageobj.ModuleID;
                pobj.PageName = pageobj.PageName;
                pobj.PageUrl = pageobj.PageUrl;
                pobj.categoryId = pageobj.categoryId;
                pobj.PageOrder = pageobj.PageOrder;
                pobj.Status = pageobj.Status;
                _context.SaveChanges();
                return 1;

            }
            catch (Exception)
            {

                throw;
            }

        }

        internal List<tbl_Page> GetPagesforPagePermission(string Ocode)
        {
            try
            {

                var pages = (from page in _context.tbl_Page
                             where page.OCODE == Ocode
                             select page);
                return pages.ToList();
            }
            catch (Exception)
            {

                throw;
            }

        }

        internal int SavePagePermission(List<tbl_PagePermission> pagePermissiones)
        {
            try
            {
                foreach (tbl_PagePermission aitem in pagePermissiones)
                {

                    tbl_PagePermission tblpermission = _context.tbl_PagePermission.FirstOrDefault(x => x.RoleID == aitem.RoleID && x.PageID == aitem.PageID && x.CategoryId == aitem.CategoryId && x.ModuleId == aitem.ModuleId);

                    if (tblpermission != null)
                    {
                        _context.tbl_PagePermission.DeleteObject(tblpermission);
                        _context.SaveChanges();
                    }
                    _context.tbl_PagePermission.AddObject(aitem);
                }
                _context.SaveChanges();
                return 1;

            }
            catch (Exception)
            {

                throw;
            }

        }

        internal List<tbl_Page> GetPagesByMouleId(string Ocode, int moduleId)
        {
            try
            {

                var pages = (from page in _context.tbl_Page
                             where page.OCODE == Ocode && page.ModuleID == moduleId
                             select page);
                return pages.ToList();
            }
            catch (Exception)
            {

                throw;
            }

        }

        internal List<tbl_PagePermission> getPagePermissionByPageID(string Ocode, int pageId)
        {
            try
            {

                var pages = (from page in _context.tbl_PagePermission
                             where page.OCODE == Ocode && page.PageID == pageId
                             select page);
                return pages.ToList();
            }
            catch (Exception)
            {

                throw;
            }

        }
        internal List<tbl_Page> GetPageByModulId(string Ocode, int ModuleId)
        {

            try
            {
                var pages = (from page in _context.tbl_Page
                             where page.OCODE == Ocode && page.ModuleID == ModuleId
                             select page);
                return pages.ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }
        internal IEnumerable<Category> GetCategoryByModulId(string Ocode, int ModuleId)
        {
            using (var _context = new ERPSSL_AdminEntities1())
            {
                return (from page in _context.tbl_Page
                        join c in _context.tbl_Category on page.categoryId equals c.categoryId
                        where page.ModuleID == ModuleId && page.OCODE == Ocode && page.Status == true && c.Status==true


                        select new Category
                        {
                            CategoryName = c.Name,
                            categoryid = (int)page.categoryId,
                            ID = (int)c.CategoryOrder
                        }).Distinct().OrderBy(x => x.ID).ToList();

            }

        }
        internal List<tbl_Page> getPagesByCategory(string cateGoryId, string Ocode)
        {
            try
            {
                int categoryID = Convert.ToInt32(cateGoryId);
                var pages = (from page in _context.tbl_Page
                             where page.OCODE == Ocode && page.categoryId == categoryID && page.Status == true
                             select page);
                return pages.ToList();
            }
            catch (Exception)
            {

                throw;
            }

        }

        internal List<tbl_Page> getPagesByCategory(int categoryId, string Ocode)
        {
            try
            {
                int categoryID = Convert.ToInt32(categoryId);
                var pages = (from page in _context.tbl_Page
                             where page.OCODE == Ocode && page.categoryId == categoryID
                             select page).OrderBy(x => x.PageOrder);
                return pages.ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }
        internal List<RPagePermission> GetPagePermissionList(string Ocode)
        {
            using (var _context = new ERPSSL_AdminEntities1())
            {
                return (from page in _context.tbl_PagePermission
                        join r in _context.tbl_UserRole on page.RoleID equals r.RoleID
                        join p in _context.tbl_Page on page.PageID equals p.PageID
                        join c in _context.tbl_Category on page.CategoryId equals c.categoryId

                        where page.OCODE == Ocode
                        select new RPagePermission
                        {
                            pagePermissionId = (int)page.PermissionID,
                            RoleName = r.RoleName,
                            PageName = p.PageName,
                            CanVisit = page.CanVisit,
                            CanDelete = page.CanDelete,
                            CanEdit = page.CanEdit,
                            CanExecute = page.CanExecute,
                            CategoryName = c.Name
                        }).ToList();
            }

        }

        internal List<tbl_PagePermission> GetPagePermissionByPagePermissionId(string OCODE, string pagePermissionId)
        {
            try
            {

                int pId = Convert.ToInt32(pagePermissionId);

                var pagePermission = (from page in _context.tbl_PagePermission
                                      where page.OCODE == OCODE && page.PermissionID == pId
                                      select page);
                return pagePermission.ToList();

            }
            catch (Exception)
            {

                throw;
            }
        }

        internal int UpdatePagePermission(tbl_PagePermission pagePermissionobj, int pagePermissionId)
        {
            try
            {
                tbl_PagePermission pagePerObj = _context.tbl_PagePermission.First(x => x.PermissionID == pagePermissionId);
                pagePerObj.RoleID = pagePermissionobj.RoleID;
                pagePerObj.PageID = pagePermissionobj.PageID;
                pagePerObj.ModuleId = pagePermissionobj.ModuleId;
                pagePerObj.CategoryId = pagePermissionobj.CategoryId;
                pagePerObj.CanVisit = pagePermissionobj.CanVisit;
                pagePerObj.CanEdit = pagePermissionobj.CanEdit;
                pagePerObj.CanDelete = pagePermissionobj.CanDelete;
                pagePerObj.CanExecute = pagePermissionobj.CanExecute;
                _context.SaveChanges();
                return 1;

            }
            catch (Exception)
            {

                throw;
            }

        }

        internal List<tbl_Page> getPagesByCategoryForSupperAdmin(string cateGoryId, string Ocode)
        {
            try
            {
                int categoryID = Convert.ToInt32(cateGoryId);
                var pages = (from page in _context.tbl_Page
                             where page.OCODE == Ocode && page.categoryId == categoryID && page.Status == true
                             select page).OrderBy(x => x.PageOrder);
                return pages.ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        internal List<tbl_PagePermission> getPagePermissionListByRoleId(string RoleId, string Ocode, int moduleId)
        {
            try
            {
                int roleId = Convert.ToInt32(RoleId);
                int mId = Convert.ToInt32(moduleId);
                var pages = (from page in _context.tbl_PagePermission
                             where page.OCODE == Ocode && page.RoleID == roleId && page.ModuleId == mId
                             select page);
                return pages.ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        internal List<tbl_Page> getPagebyPageID(string pageId, string Ocode)
        {
            try
            {
                int pageID = Convert.ToInt32(pageId);
                var pages = (from page in _context.tbl_Page
                             where page.OCODE == Ocode && page.PageID == pageID
                             select page);
                return pages.ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        internal List<PPermissionList> getPagePermissionByRoleId(string Ocode, int role)
        {

            try
            {


                using (var _context = new ERPSSL_AdminEntities1())
                {
                    var ParamempID = new SqlParameter("@ocode", Ocode);
                    var ParamempID1 = new SqlParameter("@RoleId", role);
                    string SP_SQL = "[HRM_GetPageParmissionListByRoleId] @ocode,@RoleId";
                    return (_context.ExecuteStoreQuery<PPermissionList>(SP_SQL, ParamempID, ParamempID1)).ToList();
                }

            }
            catch (Exception)
            {

                throw;
            }

        }

        internal IEnumerable<Category> GetCategoryForUserByModulId(int ModuleId, string Ocode, Guid usrerId)
        {

            using (var _context = new ERPSSL_AdminEntities1())
            {
                return (from uA in _context.tbl_UserAccess
                        join c in _context.tbl_Category on uA.CategoryId equals c.categoryId
                        where uA.ModuleId == ModuleId && uA.OCODE == Ocode && uA.UserID == usrerId && c.Status==true
                        select new Category
                        {
                            CategoryName = c.Name,
                            categoryid = (int)uA.CategoryId,
                            ID = (int)c.CategoryOrder
                        }).Distinct().OrderBy(x => x.ID).ToList();
            }
        }

        internal List<RPage> getPagesByCategoryForUser(string cateGoryId, string Ocode, Guid use)
        {
            int catID = Convert.ToInt32(cateGoryId);
            return (from uA in _context.tbl_UserAccess
                    join c in _context.tbl_Page on uA.PageID equals c.PageID
                    where uA.CategoryId == catID && uA.OCODE == Ocode && uA.UserID == use && c.Status == true
                    select new RPage
                    {
                        PageUrl = c.PageUrl,
                        PageName = c.PageName
                    }).ToList();

        }
        internal IEnumerable<RPage> CategoryesForgridValue(string Ocode, int catagoryValue)
        {
            try
            {
                using (var _context = new ERPSSL_AdminEntities1())
                {
                    var ParamempID = new SqlParameter("@OCODE", Ocode);
                    var CatagoryValue = new SqlParameter("@CatagoryId", catagoryValue);

                    string SP_SQL = "Adp_GetPageListByCatagoryId @OCODE,@CatagoryId";

                    return (_context.ExecuteStoreQuery<RPage>(SP_SQL, ParamempID, CatagoryValue)).ToList();
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        internal List<tbl_PagePermission> GetPagePermissionListByRoleModuleCategoryWise(int Role, int ModuleId, int categoryId)
        {
            try
            {
                List<tbl_PagePermission> pagepermissions = (from pagepermission in _context.tbl_PagePermission
                                                            where pagepermission.RoleID == Role && pagepermission.ModuleId == ModuleId && pagepermission.CategoryId == categoryId
                                                            select pagepermission).ToList();
                return pagepermissions;

                                                         



            }
            catch (Exception)
            {
                
                throw;
            }
        }

        internal List<tbl_UserAccess> GetUserAccessByRoleAndUserID(int role, string UserName, string Ocode)
        {
            try
            {
                Guid uId = new Guid(UserName);
                List<tbl_UserAccess> userAccess = _context.tbl_UserAccess.Where(x => x.RoleID == role && x.UserID == uId && x.OCODE == Ocode).ToList();
                return userAccess;
            }
            catch (Exception)
            {
                
                throw;
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using ERPSSL.AppGateway.BOL;

namespace ERPSSL.Adminpanel.DAL
{
    public class ModuleDal
    {
        DAL.ERPSSL_AdminEntities1 _context = new ERPSSL_AdminEntities1();

        public virtual List<tbl_Module> User_Login(string UserName, string UserPass)
        {
            using (_context)
            {
                var ParamempID = new SqlParameter("@LoginName", UserName);
                var ParamempID1 = new SqlParameter("@Password", UserPass);

                string SP_SQL = "Get_Module";
                var result = _context.ExecuteStoreQuery<tbl_Module>(SP_SQL);
                return result.ToList();
            }
        }
        internal int SaveModul(tbl_Module modulOb)
        {
            try
            {
                _context.tbl_Module.AddObject(modulOb);
                _context.SaveChanges();
                return 1;

            }
            catch (Exception)
            {

                throw;
            }
        }

        internal List<tbl_Module> GetModules(string Ocode)
        {
            try
            {
                var modules = (from module in _context.tbl_Module
                               where module.OCODE == Ocode && module.Status == true
                               select module);
                return modules.OrderBy(x => x.ModuleOrder).ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }
        internal List<tbl_Module> GetModuleById(string modulId, string OCODE)
        {
            try
            {
                int mId = Convert.ToInt32(modulId);

                var modules = (from module in _context.tbl_Module
                               where module.OCODE == OCODE && module.ModuleID == mId
                               select module);
                return modules.ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        internal int UpdateModul(tbl_Module modulOb, string ModulId)
        {
            int modulId = Convert.ToInt32(ModulId);
            tbl_Module moduleObject = _context.tbl_Module.First(x => x.ModuleID == modulId);
            moduleObject.ModuleName = modulOb.ModuleName;
            moduleObject.ModuleURL = modulOb.ModuleURL;
            moduleObject.ModuleIcon = modulOb.ModuleIcon;
            moduleObject.ModuleOrder = modulOb.ModuleOrder;
            moduleObject.EDIT_USER = modulOb.EDIT_USER;
            moduleObject.EDIT_DATE = modulOb.EDIT_DATE;
            moduleObject.Status = modulOb.Status;
            moduleObject.OCODE = modulOb.OCODE;
            _context.SaveChanges();
            return 1;
        }

        internal IEnumerable<ModulBol> GetModulesById(string UserId, string Ocode)
        {
            using (_context)
            {
                var ParamempID = new SqlParameter("@id", UserId);
                var ParamempID1 = new SqlParameter("@ocode", Ocode);

                string SP_SQL = "HRM_GetModuleInfoByUserId @id,@ocode";

                var result = _context.ExecuteStoreQuery<ModulBol>(SP_SQL, ParamempID, ParamempID1);
                return result.ToList();
            }

        }

        internal List<tbl_Module> GetAllModules(string Ocode)
        {

            try
            {
                var modules = (from module in _context.tbl_Module
                               where module.OCODE == Ocode
                               select module);
                return modules.OrderBy(x => x.ModuleOrder).ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
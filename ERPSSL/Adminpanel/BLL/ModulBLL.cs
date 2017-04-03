using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ERPSSL.Adminpanel.DAL;
using ERPSSL.AppGateway.BOL;

namespace ERPSSL.Adminpanel.BLL
{
    public class ModulBLL
    {
        ModuleDal moduldal = new ModuleDal();
        internal int SaveModul(tbl_Module modulOb)
        {
            return moduldal.SaveModul(modulOb);
            
        }

        internal List<tbl_Module> GetModules(string Ocode)
        {
            return moduldal.GetModules(Ocode);
        }

        internal List<tbl_Module> GetModuleById(string modulId, string OCODE)
        {
            return moduldal.GetModuleById(modulId, OCODE);
        }

        internal int UpdateModul(tbl_Module modulOb, string ModulId)
        {
            return moduldal.UpdateModul(modulOb, ModulId);
        }

        internal IEnumerable<ModulBol> GetModulesById(string UserId, string Ocode)
        {
            return moduldal.GetModulesById(UserId, Ocode);
        }

        internal List<tbl_Module> GetAllModules(string Ocode)
        {
            return moduldal.GetAllModules(Ocode);
        }
    }
}
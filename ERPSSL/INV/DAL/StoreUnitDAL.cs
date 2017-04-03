using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPSSL.INV.DAL
{
    public class StoreUnitDAL
    {
        private ERPSSL_INVEntities _context = new ERPSSL_INVEntities();

        internal object GetAllStoreUnitType()
        {
            try
            {
                var storeType = (from storeUnitType in _context.Inv_Store_Unit_Type
                                 select storeUnitType).OrderBy(x => x.Store_UnitType_Name);

                return storeType.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        internal int InsertProject(Inv_Store_Unit InvStoreUnit)
        {
            try
            {
                _context.Inv_Store_Unit.AddObject(InvStoreUnit);
                _context.SaveChanges();
                return 1;

            }
            catch (Exception)
            {

                throw;
            }
        }

        internal List<Inv_Store_Unit> GetAllStoreUnit()
        {
            try
            {

                var projects = (from prj in _context.Inv_Store_Unit

                                select prj).OrderBy(x => x.Store_Unit_Name); 
                return projects.ToList();

            }
            catch (Exception)
            {

                throw;
            }
        } 

        internal List<Inv_Store_Unit> GetProjectId(string ProjectId)
        {
            try
            {
                int projectId = Convert.ToInt32(ProjectId);
                var project = (from prj in _context.Inv_Store_Unit
                               where prj.Store_Unit_Id == projectId
                               select prj);
                return project.ToList();

            }
            catch (Exception)
            {
                throw;
            }
        }

        internal int UpdateProject(Inv_Store_Unit InvStoreUnit, int projectId)
        {
            try
            {
                Inv_Store_Unit InvPro = _context.Inv_Store_Unit.First(x => x.Store_Unit_Id == projectId);
                InvPro.Store_Unit_Name = InvStoreUnit.Store_Unit_Name;
                InvPro.Unit_Track_No = InvStoreUnit.Unit_Track_No;
                InvPro.Location = InvStoreUnit.Location; 
                InvPro.Description = InvStoreUnit.Description;
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
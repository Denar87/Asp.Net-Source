using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ERPSSL.INV.DAL.Repository;

namespace ERPSSL.INV.DAL
{
    public class StoreDAL
    {
        private ERPSSL_INVEntities _context = new ERPSSL_INVEntities();

        public int SaveStore(Inv_Store astore)
        {
            _context.Inv_Store.AddObject(astore);
            _context.SaveChanges();
            return 1;
        }

        public int UpdateStore(Inv_Store astore, string Id)
        {
            try
            {
                int storeId = Convert.ToInt32(Id);
                Inv_Store storeType = _context.Inv_Store.First(x => x.Store_Id == storeId);

                storeType.StoreName = astore.StoreName;
                storeType.Store_Code = astore.Store_Code;
                storeType.Location = astore.Location;
                storeType.Description = astore.Description;
                astore.Store_Code = astore.Store_Code;
                storeType.OCODE = astore.OCODE;
                storeType.EDIT_DATE = astore.EDIT_DATE;
                storeType.EDIT_USER = astore.EDIT_USER;

                _context.SaveChanges();
                return 1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        internal List<Inv_Store> GetStoreeById(string StoreId)
        {
            try
            {
                int storeId = Convert.ToInt32(StoreId);

                var store = (from prj in _context.Inv_Store
                               where prj.Store_Id == storeId
                               select prj);
                return store.ToList();

            }
            catch (Exception)
            {
                throw;
            }
        }

        internal List<Inv_Store> GetStore()
        {
            var query = (from c in _context.Inv_Store
                         select c).OrderBy(c => c.StoreName);

            return query.ToList();
        }

        internal List<Inv_Store> GetStoreByProjectID(string ProjectName)
        {
            var query = (from c in _context.Inv_Store
                         where c.ProjectName == ProjectName
                         select c).OrderBy(c => c.StoreName);

            return query.ToList();
        }
        internal List<Inv_Store> GetStoreByProjectCodeByLocation(string OCODE)
        {
            var query = (from c in _context.Inv_Store
                         //join pr in _context.Inv_BuyCentral on c.Store_Code equals pr.Store_Code
                         where c.OCODE == OCODE
                         select c).OrderBy(c => c.StoreName);

            return query.Distinct().ToList();
        }
        internal List<Inv_Store> GetStorByOcode(string OCODE)
        {

            var query = (from c in _context.Inv_Store
                         where c.OCODE == OCODE
                         select c).OrderBy(c => c.StoreName);

            return query.Distinct().ToList();
        }
        internal List<StoreInCharge> GetProgram(string OCODE)
        {
            try
            {
                return (from str in _context.Inv_Program
                        where str.OCode == OCODE
                        select new StoreInCharge
                        {
                            ProgramId = str.ProgramID,
                            programName = str.ProgramName,

                        }).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
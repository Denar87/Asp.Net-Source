using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ERPSSL.INV.DAL;

namespace ERPSSL.INV.DAL
{
    public class UnitDAL
    {
        private ERPSSL_INVEntities _context = new ERPSSL_INVEntities();

        internal int InsertUnit(Inv_Unit unitObj)
        {
            try
            {
                _context.Inv_Unit.AddObject(unitObj);
                _context.SaveChanges();
                return 1;

            }
            catch (Exception)
            {

                throw;
            }
        }

        internal List<Inv_Unit> GetAllUnit()
        {
            try
            {
                var units = (from unit in _context.Inv_Unit
                             select unit).OrderBy(x => x.UnitName);
                return units.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        internal List<Inv_Unit> GetUnitById(string unitId)
        {
            try
            {
                int Id = Convert.ToInt32(unitId);

                var units = (from unit in _context.Inv_Unit
                             where unit.UnitId == Id
                             select unit);


                return units.ToList();

            }
            catch (Exception)
            {

                throw;
            }

        }


        internal int UpdateUnit(int unitId, Inv_Unit unitObj)
        {
            try
            {
                Inv_Unit untObj = _context.Inv_Unit.First(x => x.UnitId == unitId);
                untObj.UnitName = unitObj.UnitName;
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
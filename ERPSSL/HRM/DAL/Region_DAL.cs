using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ERPSSL.HRM.DAL;

namespace ERPSSL.HRM.DAL
{
    public class Region_DAL
    {
        private ERPSSLHBEntities _context = new ERPSSLHBEntities();
        internal int InsertRegion(HRM_Regions objRegion)
        {
            try
            {
                _context.HRM_Regions.AddObject(objRegion);
                _context.SaveChanges();
                return 1;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public virtual List<HRM_Regions> GetAllRegions(string OCODE)
        {

            try
            {
                var query = (from reg in _context.HRM_Regions
                             where reg.OCODE == OCODE
                             select reg).OrderBy(x => x.RegionName);


                return query.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        internal int UpdateUpdateRegion(HRM_Regions objRegion, int RegionId)
        {

            try
            {
                HRM_Regions obj = _context.HRM_Regions.First(x => x.RegionID == RegionId);
                obj.RegionName = objRegion.RegionName;
                obj.RegionCode = objRegion.RegionCode;
                obj.EDIT_USER = objRegion.EDIT_USER;
                obj.EDIT_DATE = objRegion.EDIT_DATE;
                _context.SaveChanges();
                return 1;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        internal HRM_Regions gerRegionCodeByRegionId(int regionId)
        {
            int RegionId = Convert.ToInt32(regionId);
            HRM_Regions Region = _context.HRM_Regions.First(x => x.RegionID == RegionId);
            return Region;
        }

        internal List<HRM_Regions> gerRegionCodeByRegionId(string regionId, string OCODE)
        {
            int RegionId = Convert.ToInt32(regionId);

            //HRM_Regions Region = _context.HRM_Regions.First(x => x.RegionID == RegionId);
            //return Region;  

            List<HRM_Regions> Regions = (from reg in _context.HRM_Regions
                                         where reg.OCODE == OCODE && reg.RegionID == RegionId
                                         select reg).OrderBy(x => x.RegionID).ToList<HRM_Regions>();
            return Regions;

        }
    }
}
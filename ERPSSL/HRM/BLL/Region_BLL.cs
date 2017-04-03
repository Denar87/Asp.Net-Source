using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ERPSSL.HRM.DAL;

namespace ERPSSL.HRM.BLL
{
    public class Region_BLL
    {
        Region_DAL objRegonDal = new Region_DAL();

        public int InsertRegion(HRM_Regions objRegion)
        {
            return objRegonDal.InsertRegion(objRegion);

        }

        public virtual List<HRM_Regions> GetAllRegions(string OCODE)
        {
            return objRegonDal.GetAllRegions(OCODE);
        }

        public int UpdateUpdateRegion(HRM_Regions objRegion, int RegionId)
        {

            return objRegonDal.UpdateUpdateRegion(objRegion, RegionId);



        }

        internal HRM_Regions gerRegionCodeByRegionId(int regionId)
        {
            return objRegonDal.gerRegionCodeByRegionId(regionId);


        }

        internal List<HRM_Regions> getRegionsByRegionIdandCode(string regionId, string OCODE)
        {
            return objRegonDal.gerRegionCodeByRegionId(regionId, OCODE);
        }
    }
}
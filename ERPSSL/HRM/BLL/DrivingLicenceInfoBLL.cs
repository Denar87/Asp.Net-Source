using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ERPSSL.HRM.DAL;

namespace ERPSSL.HRM.BLL
{
    public class DrivingLicenceInfoBLL
    {
        DrivingLicenceInfoDAL drivinLicenceInfoDal = new DrivingLicenceInfoDAL();
        internal int SaveDrivingInfo(DAL.HRM_DrivingLicencs drivObj)
        {
            return drivinLicenceInfoDal.SaveDrivingInfo(drivObj);
        }

        internal List<HRM_DrivingLicencs> GetDrivingLicencesInfo(string eid, string OCODE)
        {
            return drivinLicenceInfoDal.GetDrivingLicencesInfo(eid, OCODE);
        }

        internal List<HRM_DrivingLicencs> getDrivingLicenceByDrivingIdandOcode(string DId, string OCODE)
        {
            return drivinLicenceInfoDal.getDrivingLicenceByDrivingIdandOcode(DId, OCODE);
        }



        internal int UpdateDrivingInfo(int drivingLiceId, HRM_DrivingLicencs drivObj)
        {
            return drivinLicenceInfoDal.UpdateDrivingInfo(drivingLiceId, drivObj);
        }

        internal int DeleteDrivingLicencebyId(string drivingId, string OCODE)
        {
            return drivinLicenceInfoDal.DeleteDrivingLicencebyId(drivingId, OCODE);
        }
    }
}
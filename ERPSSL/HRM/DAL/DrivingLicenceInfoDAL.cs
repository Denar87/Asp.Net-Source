using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPSSL.HRM.DAL
{
    public class DrivingLicenceInfoDAL
    {
        ERPSSLHBEntities _context = new ERPSSLHBEntities();
        public int SaveDrivingInfo(HRM_DrivingLicencs drivObj)
        {
            _context.HRM_DrivingLicencs.AddObject(drivObj);
            _context.SaveChanges();
            return 1;
        }


        internal List<HRM_DrivingLicencs> GetDrivingLicencesInfo(string eid, string OCODE)
        {

            try
            {
                var query = (from Dri in _context.HRM_DrivingLicencs
                             where Dri.EID == eid && Dri.OCODE == OCODE
                             select Dri).OrderBy(x => x.DrivingId);


                return query.ToList();



            }
            catch (Exception)
            {

                throw;
            }

        }

        internal List<HRM_DrivingLicencs> getDrivingLicenceByDrivingIdandOcode(string DId, string OCODE)
        {
            try
            {
                int DrivingLicenceId = Convert.ToInt32(DId);
                var query = (from Dri in _context.HRM_DrivingLicencs
                             where Dri.DrivingId == DrivingLicenceId && Dri.OCODE == OCODE
                             select Dri).OrderBy(x => x.DrivingId);


                return query.ToList();



            }
            catch (Exception)
            {

                throw;
            }


        }

        internal int UpdateDrivingInfo(int drivingLiceId, HRM_DrivingLicencs drivObj)
        {
            try
            {
                HRM_DrivingLicencs DrivingLicenceObj = _context.HRM_DrivingLicencs.First(x => x.DrivingId == drivingLiceId);
                DrivingLicenceObj.LicenceNo = drivObj.LicenceNo;
                DrivingLicenceObj.Type = drivObj.Type;
                DrivingLicenceObj.IssuedDate = drivObj.IssuedDate;
                DrivingLicenceObj.Location = drivObj.Location;
                DrivingLicenceObj.ExperiredDate = drivObj.ExperiredDate;
                _context.SaveChanges();
                return 1;


            }
            catch (Exception)
            {

                throw;
            }
        }

        internal int DeleteDrivingLicencebyId(string drivingId, string OCODE)
        {
            try
            {
                int dId = Convert.ToInt32(drivingId);
                HRM_DrivingLicencs objex = _context.HRM_DrivingLicencs.First(x => x.DrivingId == dId);
                _context.HRM_DrivingLicencs.DeleteObject(objex);
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
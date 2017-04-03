using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPSSL.HRM.DAL
{
    public class AcademicInfoDAL
    {
        ERPSSLHBEntities _context = new ERPSSLHBEntities();
        internal List<HRM_Academics> GetAllDesignation(string eid, string OCODE)
        {
            try
            {

                var query = (from deg in _context.HRM_Academics
                             where deg.EID == eid && deg.OCODE == OCODE
                             select deg).OrderBy(x => x.AcademicId);


                return query.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        internal int DeleteAcademicbyAcademicId(string academicId, string OCODE)
        {
            try
            {
                int AcademicId = Convert.ToInt32(academicId);
                HRM_Academics objAcademic = _context.HRM_Academics.First(x => x.AcademicId == AcademicId);
                _context.HRM_Academics.DeleteObject(objAcademic);
                _context.SaveChanges();
                return 1;
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }

        internal List<HRM_Academics> getAcademicInfoByIdandOcode(string aId, string OCODE)
        {
            try
            {
                int acId = Convert.ToInt16(aId);
                var query = (from Ac in _context.HRM_Academics
                             where Ac.AcademicId == acId && Ac.OCODE == OCODE
                             select Ac).OrderBy(x => x.AcademicId);


                return query.ToList();
            }
            catch (Exception)
            {

                throw;
            }

        }

        internal int getAcademicInfoByIdandOcode(HRM_Academics academics, int AcadimicId)
        {
            try
            {
                HRM_Academics objAcademic = _context.HRM_Academics.First(x => x.AcademicId == AcadimicId);
                objAcademic.LevelOfEducation = academics.LevelOfEducation;
                objAcademic.Major = academics.Major;
                objAcademic.InstituteName = academics.InstituteName;
                objAcademic.PassingYear = academics.PassingYear;
                objAcademic.Duration = academics.Duration;
                objAcademic.Result = academics.Result;
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
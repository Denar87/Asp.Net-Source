using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPSSL.HRM.DAL
{
    public class EducationTypeDAL
    {
        ERPSSLHBEntities _context = new ERPSSLHBEntities();
        internal int SaveEducationType(HRM_EducationType eductiotypeObj)
        {

            try
            {
                _context.HRM_EducationType.AddObject(eductiotypeObj);
                _context.SaveChanges();
                return 1;
            }
            catch (Exception)
            {
                throw;
            }
        }

        internal List<HRM_EducationType> getEducationTypeList(string OCODE)
        {
            try
            {
                var query = (from ed in _context.HRM_EducationType
                             where ed.OCode == OCODE
                             select ed).OrderBy(x => x.EducationTypeName);


                return query.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        internal List<HRM_EducationType> getEducatonTypeById(string educatonId, string OCODE)
        {
            int educaton = Convert.ToInt32(educatonId);

            List<HRM_EducationType> educationTypes = (from reg in _context.HRM_EducationType
                                                      where reg.OCode == OCODE && reg.EducationTypeID == educaton
                                                      select reg).ToList<HRM_EducationType>();
            return educationTypes;
        }

        internal int UpdateEducationType(HRM_EducationType eductiotypeObj, string EducatonTypeId)
        {

            try
            {
                int educationType = Convert.ToInt16(EducatonTypeId);
                HRM_EducationType obj = _context.HRM_EducationType.First(x => x.EducationTypeID == educationType);
                obj.EducationTypeName = eductiotypeObj.EducationTypeName;

                obj.Edit_User = eductiotypeObj.Edit_User;
                obj.Edit_Date = eductiotypeObj.Edit_Date;
                _context.SaveChanges();
                return 1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
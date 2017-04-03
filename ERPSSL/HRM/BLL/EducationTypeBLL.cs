using ERPSSL.HRM.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPSSL.HRM.BLL
{
    public class EducationTypeBLL
    {
        EducationTypeDAL _EducatonTypeDal = new EducationTypeDAL();
        internal int SaveEducationType(HRM_EducationType eductiotypeObj)
        {
           return _EducatonTypeDal.SaveEducationType(eductiotypeObj);
        }

        internal virtual List<HRM_EducationType> getEducationTypeList(string OCODE)
        {
            return _EducatonTypeDal.getEducationTypeList(OCODE);
        }

        internal List<HRM_EducationType> getEducatonTypeById(string educatonId, string OCODE)
        {
            return _EducatonTypeDal.getEducatonTypeById(educatonId, OCODE);
        }

        internal int UpdateEducationType(HRM_EducationType eductiotypeObj, string EducatonTypeId)
        {
            return _EducatonTypeDal.UpdateEducationType(eductiotypeObj, EducatonTypeId);

        }
    }
}
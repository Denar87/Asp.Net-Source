using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ERPSSL.HRM.DAL;

namespace ERPSSL.HRM.BLL
{
    public class AcademicInfoBll
    {
        AcademicInfoDAL academicInfoDal = new AcademicInfoDAL();
        internal List<HRM_Academics> GetAllAcdemicInfoByEmployeeId(string eid, string OCODE)
        {
            return academicInfoDal.GetAllDesignation(eid,OCODE);
        }

        internal int DeleteAcademicbyAcademicId(string academicId, string OCODE)
        {
            return academicInfoDal.DeleteAcademicbyAcademicId(academicId, OCODE);
        }

        internal List<HRM_Academics> getAcademicInfoByIdandOcode(string aId, string OCODE)
        {
            return academicInfoDal.getAcademicInfoByIdandOcode(aId, OCODE);
        }

        internal int updateAcadmicInfo(HRM_Academics academics, int AcadimicId)
        {
            return academicInfoDal.getAcademicInfoByIdandOcode(academics, AcadimicId);
        }
    }
}
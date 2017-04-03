using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ERPSSL.HRM.DAL;
using ERPSSL.HRM.DAL;
using ERPSSL.HRM.DAL.Repository;

namespace ERPSSL.HRM.BLL
{
    public class GRADE_BLL
    {
        GRADE_DAL objCtx_DAL = new GRADE_DAL();

        //-------Insert------------------------------------
        public int InsertGrade(HRM_GRADE objGrd)
        {
            return objCtx_DAL.InsertGrade(objGrd);
        }

        //-------Update------------------------------------
        public int UpdateGrade(HRM_GRADE objGrd, int gradeId)
        {
            return objCtx_DAL.UpdateGrade(objGrd, gradeId);
        }

        //-------GetAll------------------------------------
        public virtual List<HRM_GRADE> GetAllGrade(string OCODE)
        {
            return objCtx_DAL.GetAllGrade(OCODE);
        }

        //-------SelectByID------------------------------------
        public virtual List<HRM_GRADE> SelectByID(int gradeID, string OCODE)
        {
            return objCtx_DAL.SelectByID(gradeID, OCODE);
        }

        internal List<HRM_DESIGNATIONS> GetGrateByStepAndOCode(string Deg, string OCODE)
        {

            return objCtx_DAL.GetGrateByStepAndOCode(Deg, OCODE);
        }

        internal List<HRM_GRADE> GetGradeInformationBygradeIdAndOcode(int gradeId, string OCODE)
        {
            return objCtx_DAL.GetGradeInformationBygradeIdAndOcode(gradeId, OCODE);
        }

        internal List<HRM_DESIGNATIONS> GetGradeById(string de, string OCODE)
        {
            return objCtx_DAL.GetGradeById(de, OCODE);
        }

        internal List<HRM_DESIGNATIONS> GetSalaryByGrade(string Grade, string OCODE)
        {
            return objCtx_DAL.GetSalaryByGrade(Grade, OCODE);
        }

        internal List<GradeR> GetGrateByDesginationName(string De, string OCODE)
        {
            return objCtx_DAL.GetGrateByDesginationName(De, OCODE);

        }

      

        internal string GetDesignationNameById(int desginationId)
        {
           return objCtx_DAL.GetDesignationNameById(desginationId);
        }
    }
}
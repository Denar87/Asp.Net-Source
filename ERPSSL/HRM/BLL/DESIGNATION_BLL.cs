using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ERPSSL.HRM.DAL;
using ERPSSL.HRM.DAL;

namespace ERPSSL.HRM.BLL
{
    public class DESIGNATION_BLL
    {
        DESIGNATION_DAL objCtx_DAL = new DESIGNATION_DAL();

        //-------Insert------------------------------------
        public int InsertDeignation(HRM_DESIGNATIONS objDeg)
        {
            return objCtx_DAL.InsertDeignation(objDeg);
        }

        //-------Update------------------------------------
        public int UpdateDesignation(HRM_DESIGNATIONS objDeg, int designationID)
        {
            return objCtx_DAL.UpdateDesignation(objDeg, designationID);
        }

        //-------Delete------------------------------------
        public int DeleteDesignation(int designationID)
        {
            return objCtx_DAL.DeleteDesignation(designationID);
        }

        //-------GetAll------------------------------------
        public virtual List<HRM_DESIGNATIONS> GetAllDesignation( string OCODE)
        {
            return objCtx_DAL.GetAllDesignation(OCODE);
        }



        internal List<HRM_DESIGNATIONS> GetaDesignationByIdandOcode(string deginationId, string OCODE)
        {
            return objCtx_DAL.GetaDesignationByIdandOcode(deginationId,OCODE);
        }

        internal DAL.HRM_DESIGNATIONS GetDesignationId(string Desgination, string Grad, decimal Gosssalary)
        {
            return objCtx_DAL.GetDesignationId(Desgination, Grad, Gosssalary);
        }

        internal int UpdatePersonalInfoForSalaryUpdate(string eid, int desId, decimal Gosssalary)
        {

            return objCtx_DAL.UpdatePersonalInfoForSalaryUpdate(eid, desId, Gosssalary);
        }
        internal DAL.HRM_DESIGNATIONS GetDesignationIdByDesNameGradAndGoss(string desName, string grade, decimal? Gosssalary)
        {

            return objCtx_DAL.GetDesignationIdByDesNameGradAndGoss(desName, grade, Gosssalary);
        }
    }
}
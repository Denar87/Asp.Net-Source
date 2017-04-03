using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ERPSSL.HRM.DAL;

namespace ERPSSL.HRM.BLL
{
    public class REPORTING_BLL
    {
        REPORTING_DAL objCtx_DAL = new REPORTING_DAL();

        public IEnumerable<HRM_EMP_ID_VIEW> generate_IdCard(string eId, string OCODE)
        {
            return objCtx_DAL.generate_IdCard(eId, OCODE);
        }

        public List<RPT_EMP_CERTIFICATION> rpt_employeeCertification(string eId, string OCODE)
        {
            return objCtx_DAL.rpt_employeeCertification(eId, OCODE);
        }

        public List<RPT_EMP_APPOINMENT> rpt_employeeAppoinment(string eId, string OCODE)
        {
            return objCtx_DAL.rpt_employeeAppoinment(eId, OCODE);
        }

        public List<HR_DEMAND> rpt_HR_Demand(string dFrom, string dTo, string OCODE)
        {
            return objCtx_DAL.rpt_HR_Demand(dFrom, dTo, OCODE);
        }

        public List<SERVICE_EVALUATION> rpt_ServiceEvaluation(string dFrom, string dTo, string OCODE)
        {
            return objCtx_DAL.rpt_ServiceEvaluation(dFrom, dTo, OCODE);
        }

        public List<RPT_EMP_PREVIEW> rpt_EmployeePreview(Int64 QueryStringId, string OCODE)
        {
            return objCtx_DAL.rpt_EmployeePreview(QueryStringId, OCODE);
        }

        public List<WORK_SHEET> rpt_WorkSheet(string dFrom, string dTo, string OCODE)
        {
            return objCtx_DAL.rpt_WorkSheet(dFrom, dTo, OCODE);
        }

        public List<RPT_EMP_LEAVE> rpt_Leave_Application(Int64 QueryStringId, string OCODE)
        {
            return objCtx_DAL.rpt_Leave_Application(QueryStringId, OCODE);
        }
        public IEnumerable<HRM_EMP_ID_VIEW> generate_IdCardEMP(string eId, string OCODE)
        {
            return objCtx_DAL.generate_IdCardEMP(eId, OCODE);
        }

    }
}
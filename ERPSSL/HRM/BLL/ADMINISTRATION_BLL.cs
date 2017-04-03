using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ERPSSL.HRM.DAL;
using ERPSSL.HRM.DAL;

namespace ERPSSL.HRM.BLL
{
    public class ADMINISTRATION_BLL
    {
        ADMINISTRATION_DAL objCtx_DAL = new ADMINISTRATION_DAL();

        //-------Insert------------------------------------
        public int InsertEmployeeEvaluation(HRM_EVALUATION objEmp)
        {
            return objCtx_DAL.InsertEmployeeEvaluation(objEmp);
        }

        //-------GetAll------------------------------------
        public virtual List<HRM_EVALUATION> GetEmployeeEvaluation(string OCODE)
        {
            return objCtx_DAL.GetEmployeeEvaluation(OCODE);
        }

        //-------Insert------------------------------------
        public int SaveEmployee_Transfer(HRM_EMP_TRANSFER objTrns, string employeeID)
        {
            return objCtx_DAL.SaveEmployee_Transfer(objTrns, employeeID);
        }

        //-------GetAll------------------------------------
        public IEnumerable<HRM_EMP_TRANSFER_VIEW> GetTransferedEmployee(string OCODE)
        {
            return objCtx_DAL.GetTransferedEmployee(OCODE);
        }

        //-------GetAll------------------------------------
        public virtual List<HRM_HR_DEMAND> GetAllhrDemand(string OCODE)
        {
            return objCtx_DAL.GetAllhrDemand(OCODE);
        }

        public virtual List<HRM_Regions> GetAllRegions(string OCODE)
        {
            try
            {
                return objCtx_DAL.GetAllRegions(OCODE);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }

        }
        public int SaveEmployee_Transfer(HRM_EMP_TRANSFER objTrns, string employeeID, decimal PreviousGrossSalary)
        {
            return objCtx_DAL.SaveEmployee_Transfer(objTrns, employeeID, PreviousGrossSalary);
        }

    }
}
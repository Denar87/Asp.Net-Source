using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ERPSSL.HRM.BLL;
using ERPSSL.HRM.DAL;

namespace ERPSSL.HRM.DAL
{
    public class ADMINISTRATION_DAL
    {
        private ERPSSLHBEntities _context = new ERPSSLHBEntities();

        //-------Insert------------------------------------
        public int InsertEmployeeEvaluation(HRM_EVALUATION objEmp)
        {
            try
            {
                _context.HRM_EVALUATION.AddObject(objEmp);
                _context.SaveChanges();
                return 1;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        //-------GetAll------------------------------------
        public virtual List<HRM_EVALUATION> GetEmployeeEvaluation(string OCODE)
        {
            var query = (from ev in _context.HRM_EVALUATION
                         where ev.OCODE == OCODE
                         select ev).OrderBy(ev => ev.EVAL_ID);

            return query.ToList();
        }

        //-------Insert------------------------------------
        public int SaveEmployee_Transfer(HRM_EMP_TRANSFER objTrns, string employeeID)
        {
            try
            {
                //---------------Update Employee Master-----------------
                HRM_PersonalInformations objEmpUpdate = _context.HRM_PersonalInformations.First(x => x.EID == employeeID);
                objEmpUpdate.RegionsId = objTrns.Regions_ID_TO;
                objEmpUpdate.OfficeId = objTrns.Office_ID_TO;
                objEmpUpdate.DepartmentId = objTrns.DPT_ID_TO;
                objEmpUpdate.SectionId = objTrns.SEC_ID_TO;
                objEmpUpdate.SubSectionId = objTrns.SUB_SEC_ID_TO;
                objEmpUpdate.DesginationId = objTrns.DEG_ID_TO;
                objEmpUpdate.Grade = objTrns.GradeTo;
                objEmpUpdate.Salary = objTrns.GorssSalaryTo;
                objEmpUpdate.EMP_TRANSFER_STATUS = true;
                _context.SaveChanges();

                _context.HRM_EMP_TRANSFER.AddObject(objTrns);
                _context.SaveChanges();

                return 1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //-------GetAll------------------------------------
        public IEnumerable<HRM_EMP_TRANSFER_VIEW> GetTransferedEmployee(string OCODE)
        {
            try
            {
                return (from trns in _context.HRM_EMP_TRANSFER
                        join r in _context.HRM_Regions on trns.Regions_ID_TO equals r.RegionID
                        join d in _context.HRM_DEPARTMENTS on trns.DPT_ID_TO equals d.DPT_ID
                        join emp in _context.HRM_EMPLOYEES on trns.EID equals emp.EID

                        select new HRM_EMP_TRANSFER_VIEW
                        {
                            TRANSFER_ID = trns.TRANSFER_ID,
                            REGION_ID_TO = r.RegionName,
                            DPT_ID_TO = d.DPT_NAME,
                            //SEC_NAME = s.SEC_NAME,
                            //SUB_SEC_NAME = ss.SUB_SEC_NAME,
                            //DEG_NAME = dg.DEG_NAME,
                            //GRADE = grd.GRADE   
                            TRANSFER_DATE = (DateTime)trns.TRANSFER_DATE,
                            EMP_FIRSTNAME = emp.EMP_FIRSTNAME

                        }).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //-------GetAll------------------------------------
        public virtual List<HRM_HR_DEMAND> GetAllhrDemand(string OCODE)
        {
            var query = (from dm in _context.HRM_HR_DEMAND
                         where dm.OCODE == OCODE
                         select dm).OrderBy(dm => dm.HR_DEMAND_ID);

            return query.ToList();
        }

        public virtual List<HRM_Regions> GetAllRegions(string OCODE)
        {
            try
            {
                var query = (from regs in _context.HRM_Regions
                             where regs.OCODE == OCODE
                             select regs).OrderBy(x => x.RegionID);


                return query.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }

        }

        public int SaveEmployee_Transfer(HRM_EMP_TRANSFER objTrns, string employeeID, decimal PreviousGrossSalary)
        {
            try
            {
                //---------------Update Employee Master-----------------
                HRM_PersonalInformations objEmpUpdate = _context.HRM_PersonalInformations.First(x => x.EID == employeeID);
                objEmpUpdate.RegionsId = objTrns.Regions_ID_TO;
                objEmpUpdate.OfficeId = objTrns.Office_ID_TO;
                objEmpUpdate.DepartmentId = objTrns.DPT_ID_TO;
                objEmpUpdate.SectionId = objTrns.SEC_ID_TO;
                objEmpUpdate.SubSectionId = objTrns.SUB_SEC_ID_TO;
                objEmpUpdate.DesginationId = objTrns.DEG_ID_TO;
                objEmpUpdate.Grade = objTrns.GradeTo;
                objEmpUpdate.Salary = objTrns.GorssSalaryTo;

                if (objTrns.Status == "TWSI" || objTrns.Status == "TWOSI")
                {
                    objEmpUpdate.EMP_TRANSFER_STATUS = true;
                }
                else
                {
                    objEmpUpdate.EMP_TRANSFER_STATUS = objEmpUpdate.EMP_TRANSFER_STATUS;
                }

                if (objTrns.Status == "TWSI" || objTrns.Status == "PWSI")
                {
                    InsertSalaryIncrementLog(objTrns, employeeID, PreviousGrossSalary);
                }

                _context.SaveChanges();
                _context.HRM_EMP_TRANSFER.AddObject(objTrns);
                _context.SaveChanges();

                return 1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void InsertSalaryIncrementLog(HRM_EMP_TRANSFER objTrns, string employeeID, decimal PreviousGrossSalary)
        {
            try
            {
                HRM_SalaryIncrementSLog _hrmSalaryIncrementlog = new HRM_SalaryIncrementSLog();
                _hrmSalaryIncrementlog.EID = employeeID;
                _hrmSalaryIncrementlog.EffectiveDate = DateTime.Now;
                _hrmSalaryIncrementlog.IncrementDate = DateTime.Now;
                _hrmSalaryIncrementlog.SalaryIncrementStatus = "Transfer/Promotion";
                _hrmSalaryIncrementlog.previousSalary = PreviousGrossSalary;
                _hrmSalaryIncrementlog.IncrementSalary = objTrns.GorssSalaryTo;
                _hrmSalaryIncrementlog.EDIT_DATE = objTrns.EDIT_DATE;
                _hrmSalaryIncrementlog.EDIT_USER = objTrns.EDIT_USER;
                _hrmSalaryIncrementlog.OCODE = objTrns.OCODE;
                _context.HRM_SalaryIncrementSLog.AddObject(_hrmSalaryIncrementlog);
                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }


    }
}
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
//using ERPSSL.ASSET.DAL;
using ERPSSL.HRM.DAL.Repository;
using ERPSSL.HRM.DAL;
using ERPSSL.Dashboard.Repository;

//using ERPSSL.CustomerServices.DAL.Repository;

namespace ERPSSL.HRM.BLL
{
    public class EMPOYEE_BLL
    {
        EMPLOYEE_DAL objCtx_DAL = new EMPLOYEE_DAL();

        //-------Insert------------------------------------
        public Int64 InsertEmployee(HRM_EMPLOYEES objEmp)
        {
            return objCtx_DAL.InsertEmployee(objEmp);
        }

        //-------Insert------------------------------------
        public Int64 InsertEmployeeEdu(HRM_EDUCATION objEdu)
        {
            return objCtx_DAL.InsertEmployeeEdu(objEdu);
        }

        public int UpdateEmployee(HRM_EMPLOYEES objEmp_update, int QueryStringId)
        {
            return objCtx_DAL.UpdateEmployee(objEmp_update, QueryStringId);
        }
        //-------GetAll------------------------------------
        public virtual List<HRM_EMPLOYEES> GetCurrent_Employees(string OCODE)
        {
            return objCtx_DAL.GetCurrent_Employees(OCODE);
        }

        //-------GetAll terminated------------------------------------
        public virtual List<HRM_EMPLOYEES> GetTerminated_Employees(string OCODE)
        {
            return objCtx_DAL.GetTerminated_Employees(OCODE);
        }

        //-------GetAll Transfered------------------------------------
        public virtual List<HRM_PersonalInformations> GetTransfered_Employees(string OCODE)
        {
            return objCtx_DAL.GetTransfered_Employees(OCODE);
        }

        //-------Check------------------------------------
        public int CheckEidExitance(string OCODE, string Requested_Eid)
        {
            return objCtx_DAL.CheckEidExitance(OCODE, Requested_Eid);
        }

        //-------GetDetails------------------------------------
        public IEnumerable<HRM_EMPLOYEES_VIEWER> GetEmployeeDetailsID(string employeeID, string OCODE)
        {
            return objCtx_DAL.GetEmployeeDetailsID(employeeID, OCODE);
        }

        //-------GetDetails------------------------------------
        public IEnumerable<HRM_EMPLOYEES_CONTRACT> GetEmployeeID(string employeeID, string OCODE)
        {
            return objCtx_DAL.GetEmployeeID(employeeID, OCODE);
        }

        //-------GetDetails------------------------------------
        public IEnumerable<HRM_EMPLOYEES_CONTRACT> GetEmployeeContract(string employeeID, string OCODE)
        {
            return objCtx_DAL.GetEmployeeContract(employeeID, OCODE);
        }

        public IEnumerable<HRM_LEAVE> GetEmployeeLeave(string employeeID, string OCODE)
        {
            return objCtx_DAL.GetEmployeeLeave(employeeID, OCODE);
        }

        public IEnumerable<HRM_LEAVE> GetEmployeeLeave(int selectedType, string employeeID, string OCODE)
        {
            return objCtx_DAL.GetEmployeeLeave(selectedType, employeeID, OCODE);
        }

        public IEnumerable<HRM_LEAVE> GetEmployeeTotalLeave(string selectedTyoe, string OCODE)
        {
            return objCtx_DAL.GetEmployeeTotalLeave(selectedTyoe, OCODE);
        }

        public int InsertEmployeeLeave(HRM_LEAVE_EMPLOYEE obj)
        {
            return objCtx_DAL.InsertEmployeeLeave(obj);
        }

        //-------GetDetails------------------------------------
        public IEnumerable<HRM_EMPLOYEES_EDIT> GetEmployeeDetailsID_EDIT(Int64 employeeID, string OCODE)
        {
            return objCtx_DAL.GetEmployeeDetailsID_EDIT(employeeID, OCODE);
        }

        //-------GetAll------------------------------------
        public virtual List<HRM_EDUCATION> GetEmployeeEducation(Int64 employeeID, string OCODE)
        {
            return objCtx_DAL.GetEmployeeEducation(employeeID, OCODE);
        }

        public virtual List<HRM_EMPLOYEES> GetAllEmployee(string OCODE)
        {
            return objCtx_DAL.GetAllEmployee(OCODE);
        }

        public virtual List<HRM_Regions> GetAllRegions(string OCODE)
        {
            return objCtx_DAL.GetAllRegions(OCODE);
        }

        public virtual List<HRM_Office> GetAllOffices(string OCODE)
        {
            return objCtx_DAL.GetAllOffices(OCODE);
        }

        internal List<RptBossDSG> GetRptBossDSG(int BossDSG)
        {
            using (var _context = new ERPSSLHBEntities())
            {
                var rptBoss_ID = new SqlParameter("@RptBoss_ID", BossDSG);

                string SP_SQL = "RptBossDesignation @RptBoss_ID";

                return (_context.ExecuteStoreQuery<RptBossDSG>(SP_SQL, rptBoss_ID)).ToList();
            }
        }

        internal IEnumerable<AssignTo> GetDesgination(string eid, string OCODE)
        {

            try
            {
                return objCtx_DAL.GetDesgination(eid, OCODE);

            }
            catch (Exception)
            {

                throw;
            }
        }

        internal HRM_PersonalInformations getPersonalInfosByID(string EmployeeId)
        {
            return objCtx_DAL.getPersonalInfosByID(EmployeeId);
        }

        internal IEnumerable<EmployementInfo> GetEmployemntInfo(string employeeid, string Ocode)
        {
            return objCtx_DAL.GetEmployemntInfo(employeeid, Ocode);
        }

        internal List<HRM_PersonalInformations> getEmpployeeNameById(string eid, string OCODE)
        {
            return objCtx_DAL.getEmpployeeNameById(eid, OCODE);
        }
        internal object GetEmployeeDetailsForAttendece(string employeeID, string OCODE)
        {
            return objCtx_DAL.GetEmployeeDetailsForAttendece(employeeID, OCODE);
        }
        public IEnumerable<HRM_EMPLOYEES_CONTRACT> GetEmployeeIDDetails(string employeeID, string OCODE)
        {
            return objCtx_DAL.GetEmployeeIDDetails(employeeID, OCODE);
        }
        public IEnumerable<HRM_EMPLOYEES_VIEWER> GetEmployeeDetailsIDCard(string employeeID, string OCODE)
        {
            return objCtx_DAL.GetEmployeeDetailsIDCard(employeeID, OCODE);
        }

        internal List<ReportingBoss> GetPersonalInfoes(string Ocode, int departmentId)
        {
            return objCtx_DAL.GetPersonalInfoes(Ocode, departmentId);
        }
        internal IEnumerable<REmployee> GetAllSalaryRPT(string OCODE)
        {
            return objCtx_DAL.GetAllSalaryRPT(OCODE);
        }

        internal IEnumerable<REmployee> GetAllChildCountRPT(string OCODE)
        {
            return objCtx_DAL.GetAllChildCountRPT(OCODE);

        }

        internal IEnumerable<REmployee> GetAllEmployeeContact(string OCODE)
        {
            return objCtx_DAL.GetAllEmployeeContact(OCODE);
        }

        internal IEnumerable<REmployee> GetAllEmployeeChildList(string OCODE)
        {
            return objCtx_DAL.GetAllEmployeeChildList(OCODE);
        }
        internal HRM_PersonalInformations getDepartmentByEID(string employeeID)
        {
            return objCtx_DAL.getDepartmentByEID(employeeID);
        }
        //internal IEnumerable<HRM_EMPLOYEESR> GetEmployeeFullName(string OCODE)
        //{
        //    return objCtx_DAL.GetEmployeeFullName(OCODE);

        //}
        //internal IEnumerable<HRM_EMPLOYEESR> GetEmployeeFullName(string OCODE)
        //{
        //    return objCtx_DAL.GetEmployeeFullName(OCODE);

        //}

        internal List<ReportingBoss> GetPersonalInfoByDepartment(string OCODE)
        {
            return objCtx_DAL.GetPersonalInfoByDepartment(OCODE);
        }
        internal List<ReportingBoss> LoadApprovePersonListByDepartmentId(int departmentId)
        {
            return objCtx_DAL.LoadApprovePersonListByDepartmentId(departmentId);
        }

        public virtual List<REmployee> GetAllEmployeeByDept(string OCODE, string depCode)
        {
            return objCtx_DAL.GetAllEmployeeByDept(OCODE, depCode);
        }

        public IEnumerable<HRM_EMPLOYEES_VIEWER> GetTerminateEmployeeList(string employeeID, string OCODE)
        {
            return objCtx_DAL.GetTerminateEmployeeList(employeeID, OCODE);
        }


        internal HRM_PersonalInformations GetEmployeeDetails(string id)
        {
            return objCtx_DAL.GetEmployeeDetails(id);
        }

        internal AttendanceDetailsR GetEmployeeAttend(string id, string status, string startdate, string endDate)
        {
            return objCtx_DAL.GetEmployeeAttend(id, status, startdate, endDate);
        }

        internal List<ReportingBoss> getPersonalInfoForHRM()
        {
            return objCtx_DAL.getPersonalInfoForHRM();
        }

    }
}
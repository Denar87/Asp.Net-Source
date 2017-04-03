using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ERPSSL.HRM.DAL;
using ERPSSL.HRM.DAL.Repository;

namespace ERPSSL.HRM.BLL
{
    public class EmployeeSetup_BLL
    {
        EmployeeSetup_DAL employeeSetupDal = new EmployeeSetup_DAL();
        
        public int InsertPersonalInfo(HRM_PersonalInformations objEmp)
        {
            return employeeSetupDal.InsertPersonalInfo(objEmp);
        }

        internal int CheckEidExitance(string OCODE, string Requested_Eid)
        {
            return employeeSetupDal.CheckEidExitance(OCODE, Requested_Eid);

        }

        internal int InsertPersonalInfoemployemetPart(string EmployeeId, HRM_PersonalInformations personalInfo)
        {
            return employeeSetupDal.InsertPersonalInfoemployemetPart(EmployeeId, personalInfo);
        }

        internal IEnumerable<REmployee> GetEmployees(string OCODE)
        {
            return employeeSetupDal.GetEmployees(OCODE);
        }

        internal IEnumerable<REmployee> GetTransFerEmployeeEmployees(string OCODE)
        {
            return employeeSetupDal.GetTransFerEmployeeEmployees(OCODE);
        }

        internal IEnumerable<REmployee> GetTerminatedEmployees(string OCODE)
        {
            return employeeSetupDal.GetTerminatedEmployees(OCODE);
        }

        internal IEnumerable<REmployee> GetSearchEmployeesList(string OCODE, string EmpSearch)
        {
            return employeeSetupDal.GetSearchEmployeesList(OCODE, EmpSearch);
        }

        internal int InsertPersonalInfoAssignTo(string EmployeeId, HRM_PersonalInformations personalInfo)
        {
            return employeeSetupDal.InsertPersonalInfoAssignTo(EmployeeId, personalInfo);
        }

        internal int UpdateemployemetPart(string EmployeeId, HRM_PersonalInformations personalInfo)
        {
            return employeeSetupDal.UpdateemployemetPart(EmployeeId, personalInfo);
        }

        internal List<HRM_PersonalInformations> GetEmployeePersonalInfoByEid(string Eid, string OCODE)
        {
            return employeeSetupDal.GetEmployeePersonalInfoByEid(Eid, OCODE);
        }
        public IEnumerable<HRM_EMPLOYEES_VIEWER> GetEmployeeDetailsID(string employeeID, string OCODE)
        {
            return employeeSetupDal.GetEmployeeDetailsID(employeeID, OCODE);
        }

        internal IEnumerable<HRM_EMPLOYEES_VIEWER> GetAllEmployeeInfoByEID(string EID, string OCODE)
        {
            return employeeSetupDal.GetAllEmployeeInfoByEID(EID, OCODE);
        }

        internal IEnumerable<HRM_EMPLOYEES_VIEWER> GetEmployeeDetailsForAttendece(string employeeID, string OCODE)
        {
            return employeeSetupDal.GetEmployeeDetailsID(employeeID, OCODE);
        }

        internal IEnumerable<REmployee> GetAllEmploye(string OCODE)
        {
            return employeeSetupDal.GetAllEmploye(OCODE);
        }

        internal IEnumerable<REmployee> GetAllEmployeForReport(string OCODE)
        {
            return employeeSetupDal.GetAllEmployeForReport(OCODE);
        }

        internal IEnumerable<REmployee> GetAllCurrentForReport(string OCODE)
        {
            return employeeSetupDal.GetAllCurrentForReport(OCODE);
        }
        internal List<REmployee> GetAllTurnOverHistoryRPT(string OCODE)
        {
            return employeeSetupDal.GetAllTurnOverHistoryRPT(OCODE);
        }
        internal IEnumerable<REmployee> GetAllTransferEmployeeForReport(string OCODE)
        {
            return employeeSetupDal.GetAllTransferEmployeeForReport(OCODE);
        }

        internal IEnumerable<REmployee> GetAllTerminatedrEmployeeForReport(string OCODE)
        {
            return employeeSetupDal.GetAllTerminatedrEmployeeForReport(OCODE);
        }

        internal IEnumerable<REmployee> GetAllMannagementEmpReport(string OCODE, string Type)
        {
            return employeeSetupDal.GetAllMannagementEmpReport(OCODE, Type);
        }

        internal IEnumerable<REmployee> GetRetiredEmployee(string OCODE)
        {
            return employeeSetupDal.GetRetiredEmployee(OCODE);
        }

        internal IEnumerable<REmployee> GetResignation(string OCODE)
        {

            return employeeSetupDal.GetResignation(OCODE);
        }

        internal IEnumerable<REmployee> GetAllRetireddrEmployeeForReport(string OCODE)
        {
            return employeeSetupDal.GetAllRetireddrEmployeeForReport(OCODE);
        }

        internal IEnumerable<REmployee> GetAllResignedEmployeeForReport(string OCODE)
        {
            return employeeSetupDal.GetAllResignedEmployeeForReport(OCODE);
        }

        internal int DeleteDublicate()
        {
            return employeeSetupDal.DeleteDublicate();

        }

        internal int DeleteTempData()
        {
            return employeeSetupDal.DeleteTempData();

        }

        internal List<Hrm_PersonalInfoTemp> getEmpInfoForSave()
        {
            return employeeSetupDal.getEmpInfoForSave();
        }

        internal void InsertDegi(List<Hrm_PersonalInfoTemp> persones, string usrId, string date, string Ocode)
        {
            employeeSetupDal.InsertDegi(persones, usrId, date, Ocode);
        }

        internal void InsertPresonalInfoTable()
        {
            employeeSetupDal.InsertPresonalInfoTable();
        }


        internal List<Hrm_PersonalInfoTemp> GetDublicateList()
        {
            return employeeSetupDal.GetDublicateList();
        }


        internal List<REmployee> GetSalaryRangeReport(string FromSalary, string ToSalary)
        {
            return employeeSetupDal.GetSalaryRangeReport(FromSalary, ToSalary);
        }

        internal IEnumerable<REmployee> GetEmployeeSeparation(string OCODE)
        {
            return employeeSetupDal.GetEmployeeSeparation(OCODE);
        }
        internal IEnumerable<REmployee> GetEmployeeSeparationByDate(string fromDate, string toDate, string OCODE)
        {
            return employeeSetupDal.GetEmployeeSeparationByDate(fromDate, toDate, OCODE);
        }
        internal List<REmployee> GetAllEmolyeeRetirementRPT(string OCODE)
        {
            return employeeSetupDal.GetAllEmolyeeRetirementRPT(OCODE);
        }

        internal List<REmployee> GetAllEmolyeeRetirementRPTforRegion(string OCODE)
        {
            return employeeSetupDal.GetAllEmolyeeRetirementRPTforRegion(OCODE);
        }

        internal List<REmployee> GetAllEmolyeeRetirementRPTForOffice(string OCODE, int ResionId, int OfficeId)
        {
            return employeeSetupDal.GetAllEmolyeeRetirementRPTForOffice(OCODE, ResionId, OfficeId);
        }

        internal List<REmployee> GetAllEmolyeeRetirementRPTForDept(string OCODE, int ResionId, int OfficeId, int departmentID)
        {
            return employeeSetupDal.GetAllEmolyeeRetirementRPTForDept(OCODE, ResionId, OfficeId, departmentID);
        }

        internal List<REmployee> GetAllDismissalEmployeeForReport(string OCODE)
        {
            return employeeSetupDal.GetAllDismissalEmployeeForReport(OCODE);
        }

        internal List<REmployee> GetAllDiedEmployeeForReport(string OCODE)
        {
            return employeeSetupDal.GetAllDiedEmployeeForReport(OCODE);
        }

        internal List<REmployee> GetAllDiscontinuousEmployeeForReport(string OCODE)
        {
            return employeeSetupDal.GetAllDiscontinuousEmployeeForReport(OCODE);
        }

        internal List<REmployee> GetAllOtherEmployeeForReport(string OCODE)
        {
            return employeeSetupDal.GetAllOtherEmployeeForReport(OCODE);
        }
          
        internal List<REmployee> GetAllEmolyeeLenthOfServices(string OCODE)
        {
            return employeeSetupDal.GetAllEmolyeeLenthOfServices(OCODE);
        }

        internal List<REmployee> GetAllCurrentEmoployeeShiftWise(string OCODE, int region)
        {
            return employeeSetupDal.GetAllCurrentEmoployeeShiftWise(OCODE, region);
        }

        internal List<REmployee> GetAllEmolyeeSalaryByRODSID(string OCODE, int ResionId, int OfficeId, int departmentID, int sectionId)
        {
            return employeeSetupDal.GetAllEmolyeeSalaryByRODSID(OCODE, ResionId, OfficeId, departmentID, sectionId);
        }

        internal List<REmployee> GetAllEmolyeeSalaryALLByRODSID()
        {
            return employeeSetupDal.GetAllEmolyeeSalaryALLByRODSID();
        }
        internal List<REmployee> GetSeparationSearchEmployeesList(string OCODE, string EmpSearch)
        {
            return employeeSetupDal.GetSeparationSearchEmployeesList(OCODE, EmpSearch);
        }
        internal List<REmployee> GeAlltSearchEmployeesList(string OCODE, string EmpSearch)
        {
            return employeeSetupDal.GeAlltSearchEmployeesList(OCODE, EmpSearch);
        }




        internal List<REmployee> GetTransferListBySearchitem(string OCODE, string EmpSearch)
        {
            return employeeSetupDal.GetTransferListBySearchitem(OCODE, EmpSearch);
        }

        internal int CheckBioIDExitance(string OCODE, string Requested_Eid)
        {
            return employeeSetupDal.CheckBioIDExitance(OCODE, Requested_Eid);
        }

        internal HRM_PersonalInformations GetPersonalInfoByEID(string Eid)
        {
            return employeeSetupDal.GetPersonalInfoByEID(Eid);
        }
        internal string GetDesginationName(int? desid)
        {
            return employeeSetupDal.GetDesginationName(desid);
        }

        internal string GetDepartmentName(int? departmentId)
        {
            return employeeSetupDal.GetDepartmentName(departmentId);
        }
        internal List<HRM_Office> GetofficesByRegionId(int? regionId, string OCODE)
        {
            return employeeSetupDal.GetofficesByRegionId(regionId, OCODE);
        }
        internal int GetMaxEid(string OCODE, string Eid)
        {
            return employeeSetupDal.GetMaxEid(OCODE, Eid);
        }
        internal List<TransferR> GetEmployeeTransfer(int id)
        {

            return employeeSetupDal.GetEmployeeTransfer(id);
        }


        internal IEnumerable<REmployee> GetAllTerminatedrEmployeeForReport_byDate(string fromDate, string toDate,string OCODE)
        {
            return employeeSetupDal.GetAllTerminatedrEmployeeForReport_byDate(fromDate, toDate, OCODE);
        }

        internal IEnumerable<REmployee> GetAllRetireddrEmployeeForReport_ByDate(string fromDate, string toDate, string OCODE)
        {
            return employeeSetupDal.GetAllRetireddrEmployeeForReport_ByDate(fromDate, toDate, OCODE);
        }

        internal IEnumerable<REmployee> GetAllResignedEmployeeForReport_ByDate(string fromDate, string toDate, string OCODE)
        {
            return employeeSetupDal.GetAllResignedEmployeeForReport_ByDate(fromDate, toDate, OCODE);
        }

        internal IEnumerable<REmployee> GetAllDismissalEmployeeForReport_ByDate(string fromDate, string toDate, string OCODE)
        {
            return employeeSetupDal.GetAllDismissalEmployeeForReport_ByDate(fromDate, toDate, OCODE);
        }

        internal IEnumerable<REmployee> GetAllDiedEmployeeForReport_ByDate(string fromDate, string toDate, string OCODE)
        {
            return employeeSetupDal.GetAllDiedEmployeeForReport_ByDate(fromDate, toDate, OCODE);
        }

        internal IEnumerable<REmployee> GetAllDiscontinuousEmployeeForReport_ByDate(string fromDate, string toDate, string OCODE)
        {
            return employeeSetupDal.GetAllDiscontinuousEmployeeForReport_ByDate(fromDate, toDate, OCODE);
        }

        internal int Update_PersonalInfo_DeductionDetails(HRM_PersonalInformations personalInfo, string EID)
        {
            return employeeSetupDal.Update_PersonalInfo_DeductionDetails(personalInfo, EID);
        }

        internal IEnumerable<HRM_EMPLOYEES_VIEWER> Get_EmployeeDetailsByEID(string employeeID, string OCODE)
        {
            return employeeSetupDal.Get_EmployeeDetailsByEID(employeeID, OCODE);
        }

        internal IEnumerable<HRM_EMPLOYEES_VIEWER> GetEmployee_Separation_Details(string employeeID, string OCODE)
        {
            return employeeSetupDal.GetEmployee_Separation_Details(employeeID, OCODE);
        }

        internal HRM_JOB_TERMINATE GetSeparationDate(string eId, string OCODE)
        {
            return employeeSetupDal.GetSeparationDate(eId, OCODE);
        }
    }
}
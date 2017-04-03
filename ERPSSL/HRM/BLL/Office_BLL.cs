using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ERPSSL.HRM.DAL;
using ERPSSL.HRM.DAL;
using ERPSSL.HRM.DAL.Repository;

namespace ERPSSL.HRM.BLL
{
    public class Office_BLL
    {
        Office_DAL objOfficeDal = new Office_DAL();
        
        internal List<HRM_Regions> GetAllDepartment(string OCODE)
        {
            return objOfficeDal.GetAllDepartment(OCODE);
        }


        internal int SaveOffice(HRM_Office objOffice)
        {
            return objOfficeDal.SaveOffice(objOffice);
        }

        internal List<HRM_Office> GetOffices(string OCODE)
        {
            return objOfficeDal.GetOffices(OCODE);

        }
        internal List<HRM_DepartmentWiseShift> GetShiftCodeByDept(int RegionId, int OfficeId, int DepartmentId)
        {
            return objOfficeDal.GetShiftCodeByDept(RegionId, OfficeId, DepartmentId);
        }
        internal HRM_Office GetOfficeById(string officeId, string OCODE)
        {
            return objOfficeDal.GetOfficeById(officeId, OCODE);

        }

        internal int UpdateOffice(HRM_Office objOffice, int officeId)
        {
            return objOfficeDal.UpdateOffice(objOffice, officeId);

        }

        internal HRM_Office GetOfficeCodeByOfficeId(int officeId)
        {
            return objOfficeDal.GetOfficeCodeByOfficeId(officeId);

        }
        internal List<HRM_Office> GetOfficeByResionId(int ResionId)
        {

            return objOfficeDal.GetOfficeByResionId(ResionId);
        }

        internal List<HRM_Office> GetOfficeByResionIdAndCode(int RegionId, string OCODE)
        {
            return objOfficeDal.GetOfficeByResionIdAndCode(RegionId, OCODE);
        }

        internal List<HRM_DEPARTMENTS> GetDepartmentByOffice(int OfficeId, string OCODE)
        {
            return objOfficeDal.GetDepartmentByOffice(OfficeId, OCODE);
        }

        internal List<HRM_Regions> GetAllResion(string OCODE)
        {
            return objOfficeDal.GetAllResion(OCODE);

        }

        internal List<HRM_Office> GetAllOffice(string OCODE)
        {
            return objOfficeDal.GetAllOffice(OCODE);

        }

        internal List<HRM_DEPARTMENTS> GetOfficeByResionId(int ResionId, int OfficeId,string Ocode)
        {
            return objOfficeDal.GetOfficeByResionId(ResionId, OfficeId, Ocode);
        }

        //internal List<MST_ClientDetails> GetAllClient(string OCODE)
        //{
        //    return objOfficeDal.GetAllClient(OCODE);
        //}

        //internal List<MST_ClientDetails> GetClientLocationById(int ClientId, string OCODE)
        //{
        //    return objOfficeDal.GetClientLocationById(ClientId,OCODE);
        //}

        internal List<REmployee> GetAllClientListForJobAllocation(int ResionId, int OfficeId, int Department, string OCODE)
        {
            return objOfficeDal.GetAllClientListForJobAllocation(ResionId, OfficeId, Department, OCODE);
        }



        internal List<REmployee> GetEmployeeListForDepartment(int ResionId, int OfficeId, int departmentID,string OCODE)
        {
            return objOfficeDal.GetEmployeeListForDepartment(ResionId, OfficeId, departmentID, OCODE);
        }
       

        internal List<REmployee> GetEmployeeListForRegion(int ResionId, string OCODE)
        {
            return objOfficeDal.GetEmployeeListForRegion(ResionId, OCODE);
        }

        internal List<REmployee> GetEmployeeListForOffice(int ResionId, int OfficeId, string OCODE)
        {
            return objOfficeDal.GetEmployeeListForOffice(ResionId, OfficeId, OCODE);
        }

        internal List<REmployee> GetEmployeeListForBlood(string Blood, int ResionId, int OfficeId, int departmentID, string OCODE)
        {
            return objOfficeDal.GetEmployeeListForBlood(Blood, ResionId, OfficeId, departmentID, OCODE);
        }

        internal List<REmployee> GetEmployeeListForBloodAll(string Blood, string OCODE)
        {
            return objOfficeDal.GetEmployeeListForBloodAll(Blood, OCODE);
        }

        internal List<REmployee> GetEmployeeListForSalary(int ResionId, int OfficeId, int departmentID, string OCODE)
        {
            return objOfficeDal.GetEmployeeListForSalary(ResionId, OfficeId, departmentID, OCODE);
        }

        internal List<REmployee> GetEmployeeIndividualInfo(string empId, string OCODE)
        {
            return objOfficeDal.GetEmployeeIndividualInfo(empId, OCODE);
        }

        internal List<REmployee> GetJobCertification(string empId, string OCODE)
        {
            return objOfficeDal.GetJobCertification(empId, OCODE);
        }

        internal List<REmployee> GetJobAppointment(string empId, string OCODE)
        {
            return objOfficeDal.GetJobAppointment(empId, OCODE);
        }

        internal List<REmployee> GetJobEMP_Transfer(string empId, string OCODE)
        {
            return objOfficeDal.GetJobEMP_Transfer(empId, OCODE);
        }

        internal List<REmployee> GetJobTermination(string empId, string OCODE)
        {
            return objOfficeDal.GetJobTermination(empId, OCODE);
        }

        internal List<REmployee> GetEmployeeIncrement(string empId, string OCODE)
        {
            return objOfficeDal.GetEmployeeIncrement(empId, OCODE);
        }

        internal List<REmployee> GetAllMaleEmployee(string OCODE, string gender)
        {
            return objOfficeDal.GetAllMaleEmployee(OCODE, gender);
        }
         
        internal List<LeaveForReport> GetLeaveInfoByEId(string empId, string currentDate, string OCODE)
        {
            return objOfficeDal.GetLeaveInfoByEId(empId, currentDate, OCODE);
        }



        // Employee Benefits By Id
        internal List<EmployeeBenefit> GetRptForEmployeeBenefit(string empId)
        {
            return objOfficeDal.GetRptForEmployeeBenefit(empId);
        }

        // All Employee Benefits 
        internal List<EmployeeBenefit> GetRptForAllEmployeeBenefit(string OCODE)
        {
            return objOfficeDal.GetRptForAllEmployeeBenefit(OCODE);
        }

        internal List<AdvancedSalary> GetRptForAdvancedSalary(string empId)
        {
            return objOfficeDal.GetRptForAdvancedSalary(empId);
        }

        internal List<AdvancedSalary> GetRptForAllAdvancedSalary(string OCODE)
        {
            return objOfficeDal.GetRptForAllAdvancedSalary(OCODE);
        }

        internal List<EmployeeBenefit> GetRptForAllEmployeeBenefitDepartmentWise(int departmentId,int RegionId, int OfficeId)
        {
            return objOfficeDal.GetRptForAllEmployeeBenefitDepartmentWise(departmentId,RegionId, OfficeId);
        }

        internal List<AdvancedSalary> GetRptForAllAdvancedSalaryDeptWise(int departmentId, int RegionId, int OfficeId)
        {
            return objOfficeDal.GetRptForAllAdvancedSalaryDeptWise(departmentId, RegionId, OfficeId);
        }

        internal List<AdvancedSalary> GetRptForAllAdvancedSalaryOfficeWise(int RegionId, int OfficeId)
        {
            return objOfficeDal.GetRptForAllAdvancedSalaryOfficeWise(RegionId, OfficeId);
        }

        internal List<EmployeeBenefit> GetRptForAllEmployeeBenefitOfficeWise(int RegionId, int OfficeId)
        {
            return objOfficeDal.GetRptForAllEmployeeBenefitOfficeWise(RegionId, OfficeId);
        }

        internal List<HRM_DESIGNATIONS> GetAllDesignation(string OCODE)
        {
            return objOfficeDal.GetAllDesignation(OCODE);
        }

        internal List<REmployee> GetEmployeeDesignation(string designation, string OCODE)
        {
            return objOfficeDal.GetEmployeeDesignation(designation, OCODE);
        }

        internal List<REmployee> GetEmployeeBankAccount(string OCODE)
        {
            return objOfficeDal.GetEmployeeBankAccount(OCODE);
        }

        internal List<LeaveForReport> GetEmployeewiseLeaveRpt(string empId, string Type, string OCODE)
        {
            return objOfficeDal.GetEmployeewiseLeaveRpt(empId, Type, OCODE);
        }

        internal List<LeaveForReport> GetAllEmployeewiseLeaveRpt(string OCODE)
        {
            return objOfficeDal.GetAllEmployeewiseLeaveRpt(OCODE);
        }

        internal List<LeaveForReport> GetAllEmployeeLeaveSummeryRpt(DateTime fromDate, DateTime toDate, string OCODE)
        {
            return objOfficeDal.GetAllEmployeeLeaveSummeryRpt(fromDate, toDate, OCODE);
        }
        internal List<LeaveForReport> GetAllEmployeeLeaveSummeryRptByRegion(DateTime fromDate, DateTime toDate, string OCODE, string Region)
        {
            return objOfficeDal.GetAllEmployeeLeaveSummeryRptByRegion(fromDate,toDate,OCODE, Region);
        }
        internal List<LeaveForReport> GetAllEmployeeLeaveSummeryRptByOffice(DateTime fromDate, DateTime toDate, string OCODE, string Region, string Office)
        {
            return objOfficeDal.GetAllEmployeeLeaveSummeryRptByOffice(fromDate, toDate, OCODE, Region, Office);
        }
        internal List<LeaveForReport> GetAllEmployeeLeaveSummeryRptByDepartment(DateTime fromDate, DateTime toDate, string OCODE, string Region, string Office, string Department)
        {
            return objOfficeDal.GetAllEmployeeLeaveSummeryRptByDepartment(fromDate, toDate, OCODE, Region, Office, Department);
        }

        internal List<string> GetAllDept(string OCODE)
        {
            return objOfficeDal.GetAllDept(OCODE);
        }


        internal List<HRM_DEPARTMENTS> GetAllDistinctDepartment(string OCODE)
        {
            return objOfficeDal.GetAllDistinctDepartment(OCODE);
        }


        internal List<REmployee> GetEmployeeListForDepartmentwise(string Dept)
        {
            return objOfficeDal.GetEmployeeListForDepartmentwise(Dept);
        }

        internal List<REmployee> GetEmployeeListForBlood(string OCODE)
        {
            return objOfficeDal.GetEmployeeListForBlood(OCODE);
        }
        internal List<HRM_DEPARTMENTS> GetDeptByOfficeId(int ResionId, int OfficeId, string Ocode)
        {
            return objOfficeDal.GetDeptByOfficeId(ResionId, OfficeId, Ocode);
        }

        internal List<REmployee> GetAllEmployeeJoiningDateWise(DateTime todate, DateTime Fromdate)
        {
            return objOfficeDal.GetAllEmployeeJoiningDateWise(todate,  Fromdate);
        }
        internal List<REmployee> GetAllEmployeeJoiningDateByRegion(DateTime todate, DateTime Fromdate, int ResionId)
        {
            return objOfficeDal.GetAllEmployeeJoiningDateByRegion(todate, Fromdate, ResionId);
        }
        internal List<REmployee> GetAllEmployeeJoiningDateByOffice(DateTime todate, DateTime Fromdate, int ResionId, int OfficeId)
        {
            return objOfficeDal.GetAllEmployeeJoiningDateByOffice(todate, Fromdate, ResionId, OfficeId);
        }
        internal List<REmployee> GetAllEmployeeJoiningDateByDepartment(DateTime todate, DateTime Fromdate, int ResionId, int OfficeId, int DepartmentId)
        {
            return objOfficeDal.GetAllEmployeeJoiningDateByDepartment(todate, Fromdate, ResionId, OfficeId, DepartmentId);
        }
        internal List<REmployee> GetAllEmployeeJoiningDateBySection(DateTime todate, DateTime Fromdate, int ResionId, int OfficeId, int DepartmentId, int SectionId)
        {
            return objOfficeDal.GetAllEmployeeJoiningDateBySection(todate, Fromdate, ResionId, OfficeId, DepartmentId, SectionId);
        }
       

        internal List<REmployee> GetAllEmployeeLeftgDateWise(DateTime todate, DateTime Fromdate)
        {
            return objOfficeDal.GetAllEmployeeLeftgDateWise(todate, Fromdate);
        }

        internal List<HRM_Office> GetOfficeByRegionCode(string ResionCode)
        {
            return objOfficeDal.GetOfficeByRegionCode(ResionCode);
        }
        internal List<LeaveForReport> GetAllEmployeewiseLeaveStatmentRpt(string OCODE, string eid)
        {
            return objOfficeDal.GetAllEmployeewiseLeaveStatmentRpt(OCODE, eid);
        }


        internal List<LeaveForReport> GetEmployeewiseTotalLeave(string empId, string OCODE)
        {
            return objOfficeDal.GetEmployeewiseTotalLeave(empId, OCODE);
        }
    }
}
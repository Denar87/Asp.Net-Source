using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using ERPSSL.HRM.DAL;
using ERPSSL.HRM.DAL.Repository;
using MoreLinq;
namespace ERPSSL.HRM.DAL
{
    public class Office_DAL
    {
        private ERPSSLHBEntities _context = new ERPSSLHBEntities();

        internal virtual List<HRM_Regions> GetAllDepartment(string OCODE)
        {

            try
            {
                var query = (from dept in _context.HRM_Regions
                             where dept.OCODE == OCODE
                             select dept).OrderBy(x => x.RegionID);


                return query.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }

        }

        internal List<HRM_DepartmentWiseShift> GetShiftCodeByDept(int RegionId, int OfficeId, int DepartmentId)
        {
            try
            {
                var query = (from Shift in _context.HRM_DepartmentWiseShift
                             where Shift.RegionId == RegionId && Shift.OfficeId == OfficeId && Shift.DepartmentId == DepartmentId
                             select Shift).OrderBy(x => x.ShiftCode);
                return query.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        internal int SaveOffice(HRM_Office objOffice)
        {
            _context.HRM_Office.AddObject(objOffice);
            _context.SaveChanges();
            return 1;

        }

        internal List<HRM_Office> GetOffices(string OCODE)
        {
            try
            {
                var query = (from off in _context.HRM_Office
                             where off.OCODE == OCODE
                             select off).OrderBy(x => x.OfficeID);


                return query.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        internal HRM_Office GetOfficeById(string officeId, string OCODE)
        {
            int ofId = Convert.ToInt32(officeId);
            HRM_Office office = _context.HRM_Office.First(x => x.OfficeID == ofId);

            return office;
        }
        //
        internal int UpdateOffice(HRM_Office objOffice, int officeId)
        {
            HRM_Office objoffice = _context.HRM_Office.First(x => x.OfficeID == officeId);
            objoffice.RegionId = objOffice.RegionId;
            objoffice.OfficeName = objOffice.OfficeName;
            objoffice.OfficeCode = objOffice.OfficeCode;
            objoffice.OfficeAddress = objOffice.OfficeAddress;
            objoffice.OCODE = objOffice.OCODE;
            objoffice.EDIT_USER = objOffice.EDIT_USER;
            objoffice.EDIT_DATE = objOffice.EDIT_DATE;
            _context.SaveChanges();
            return 1;

        }

        internal HRM_Office GetOfficeCodeByOfficeId(int officeId)
        {
            int ofId = Convert.ToInt32(officeId);
            HRM_Office office = _context.HRM_Office.First(x => x.OfficeID == ofId);
            return office;

        }

        internal List<HRM_Office> GetOfficeByResionId(int ResionId)
        {
            try
            {
                var query = (from off in _context.HRM_Office
                             where off.RegionId == ResionId
                             select off).OrderBy(x => x.RegionId);


                return query.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }

        }

        internal List<HRM_Office> GetOfficeByResionIdAndCode(int RegionId, string OCODE)
        {
            try
            {
                var query = (from off in _context.HRM_Office
                             where off.RegionId == RegionId && off.OCODE == OCODE
                             select off).OrderBy(x => x.RegionId);


                return query.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        internal List<HRM_Regions> GetAllResion(string OCODE)
        {
            try
            {
                var query = (from dept in _context.HRM_Regions
                             where dept.OCODE == OCODE
                             select dept).OrderBy(x => x.RegionID);


                return query.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }


        }

        internal List<HRM_Office> GetAllOffice(string OCODE)
        {
            try
            {
                var query = (from dept in _context.HRM_Office
                             where dept.OCODE == OCODE
                             select dept).OrderBy(x => x.OfficeID);


                return query.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }


        }


        internal List<HRM_DEPARTMENTS> GetOfficeByResionId(int ResionId, int OfficeId, string Ocode)
        {
            try
            {
                var query = (from department in _context.HRM_DEPARTMENTS
                             where department.OCODE == Ocode && department.Office_ID == OfficeId && department.ResionId == ResionId
                             select department).OrderBy(x => x.DPT_ID);


                return query.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }

        }

        internal List<HRM_DEPARTMENTS> GetDepartmentByOffice(int OfficeId, string Ocode)
        {
            try
            {
                var query = (from department in _context.HRM_DEPARTMENTS
                             where department.OCODE == Ocode && department.Office_ID == OfficeId
                             select department).OrderBy(x => x.DPT_ID);


                return query.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }

        }


        //internal List<MST_ClientDetails> GetAllClient(string OCODE)
        //{
        //    try
        //    {
        //        var query = (from client in _context.MST_ClientDetails
        //                     where client.OCODE == OCODE
        //                     select client).OrderBy(x => x.ID);


        //        return query.ToList();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message.ToString());
        //    }

        //}

        //internal List<MST_ClientDetails> GetClientLocationById(int ClientId, string OCODE)
        //{
        //    try
        //    {
        //        var query = (from client in _context.MST_ClientDetails
        //                     where client.OCODE == OCODE && client.ID == ClientId
        //                     select client).OrderBy(x => x.ID);


        //        return query.ToList();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message.ToString());
        //    }
        //}

        internal List<REmployee> GetAllClientListForJobAllocation(int ResionId, int OfficeId, int Department, string OCODE)
        {
            try
            {
                using (var _context = new ERPSSLHBEntities())
                {
                    var ParamempID = new SqlParameter("@ocode", OCODE);
                    var RegionID = new SqlParameter("@region", ResionId);
                    var OfficeID = new SqlParameter("@office", OfficeId);
                    var DepartmentID = new SqlParameter("@department", Department);
                    string SP_SQL = "HRM_GetJobAllocationList @ocode,@region,@office,@department";
                    return (_context.ExecuteStoreQuery<REmployee>(SP_SQL, ParamempID, RegionID, OfficeID, DepartmentID)).ToList();
                }

            }
            catch (Exception)
            {

                throw;
            }

        }


        // Shoel 

        internal List<REmployee> GetEmployeeListForDepartment(int ResionId, int OfficeId, int departmentID, string OCODE)
        {
            try
            {
                using (var _context = new ERPSSLHBEntities())
                {
                    var ParamempID = new SqlParameter("@ocode", OCODE);
                    var RegionID = new SqlParameter("@region", ResionId);
                    var OfficeID = new SqlParameter("@office", OfficeId);
                    var DepartmentID = new SqlParameter("@department", departmentID);
                    string SP_SQL = "HRM_RptEmployeeListForDepartment @ocode,@region,@office,@department";
                    return (_context.ExecuteStoreQuery<REmployee>(SP_SQL, ParamempID, RegionID, OfficeID, DepartmentID)).ToList();
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        internal List<REmployee> GetEmployeeListForRegion(int ResionId, string OCODE)
        {
            try
            {
                using (var _context = new ERPSSLHBEntities())
                {
                    var ParamempID = new SqlParameter("@ocode", OCODE);
                    var RegionID = new SqlParameter("@region", ResionId);

                    string SP_SQL = "HRM_RptEmployeeListForRegion @ocode,@region";
                    return (_context.ExecuteStoreQuery<REmployee>(SP_SQL, ParamempID, RegionID)).ToList();
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        internal List<REmployee> GetEmployeeListForOffice(int ResionId, int OfficeId, string OCODE)
        {
            try
            {
                using (var _context = new ERPSSLHBEntities())
                {
                    var ParamempID = new SqlParameter("@ocode", OCODE);
                    var RegionID = new SqlParameter("@region", ResionId);
                    var OfficeID = new SqlParameter("@office", OfficeId);

                    string SP_SQL = "HRM_RptEmployeeListForOffice @ocode,@region,@office";
                    return (_context.ExecuteStoreQuery<REmployee>(SP_SQL, ParamempID, RegionID, OfficeID)).ToList();
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        internal List<REmployee> GetEmployeeListForBlood(string Blood, int ResionId, int OfficeId, int departmentID, string OCODE)
        {
            try
            {
                using (var _context = new ERPSSLHBEntities())
                {
                    var ParamempID = new SqlParameter("@ocode", OCODE);
                    var RegionID = new SqlParameter("@region", ResionId);
                    var OfficeID = new SqlParameter("@office", OfficeId);
                    var DepartmentID = new SqlParameter("@department", departmentID);
                    var BloodGroup = new SqlParameter("@blood", Blood);
                    string SP_SQL = "HRM_RptEmployeeListForBlood @ocode,@region,@office,@department,@blood";
                    return (_context.ExecuteStoreQuery<REmployee>(SP_SQL, ParamempID, RegionID, OfficeID, DepartmentID, BloodGroup)).ToList();
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        internal List<REmployee> GetEmployeeListForBloodAll(string Blood, string OCODE)
        {
            try
            {
                using (var _context = new ERPSSLHBEntities())
                {
                    var BloodGroup = new SqlParameter("@blood", Blood);
                    var O_CODE = new SqlParameter("@ocode", OCODE);
                    string SP_SQL = "HRM_RptEmployeeListForAllBlood @blood,@ocode";
                    return (_context.ExecuteStoreQuery<REmployee>(SP_SQL, BloodGroup, O_CODE)).ToList();
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        internal List<REmployee> GetEmployeeListForSalary(int ResionId, int OfficeId, int departmentID, string OCODE)
        {
            try
            {
                using (var _context = new ERPSSLHBEntities())
                {
                    var ParamempID = new SqlParameter("@ocode", OCODE);
                    var RegionID = new SqlParameter("@region", ResionId);
                    var OfficeID = new SqlParameter("@office", OfficeId);
                    var DepartmentID = new SqlParameter("@department", departmentID);
                    string SP_SQL = "HRM_SalaryWiseSP @ocode,@region,@office,@department";
                    return (_context.ExecuteStoreQuery<REmployee>(SP_SQL, ParamempID, RegionID, OfficeID, DepartmentID)).ToList();
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        internal List<REmployee> GetEmployeeIndividualInfo(string empId, string OCODE)
        {
            try
            {
                using (var _context = new ERPSSLHBEntities())
                {
                    var ParamempID = new SqlParameter("@ocode", OCODE);
                    var EmpID = new SqlParameter("@eid", empId);
                    string SP_SQL = "HRM_RptEmployeeIndividualSP @ocode,@eid";
                    return (_context.ExecuteStoreQuery<REmployee>(SP_SQL, ParamempID, EmpID)).ToList();
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        internal List<REmployee> GetJobCertification(string empId, string OCODE)
        {
            try
            {
                using (var _context = new ERPSSLHBEntities())
                {
                    var ParamempID = new SqlParameter("@ocode", OCODE);
                    var EmpID = new SqlParameter("@eid", empId);
                    string SP_SQL = "HRM_JobCertificationSP @ocode,@eid";
                    return (_context.ExecuteStoreQuery<REmployee>(SP_SQL, ParamempID, EmpID)).ToList();
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        internal List<REmployee> GetJobAppointment(string empId, string OCODE)
        {
            try
            {
                using (var _context = new ERPSSLHBEntities())
                {
                    var ParamempID = new SqlParameter("@ocode", OCODE);
                    var EmpID = new SqlParameter("@eid", empId);
                    string SP_SQL = "HRM_JobAppointmentSP @ocode,@eid";
                    return (_context.ExecuteStoreQuery<REmployee>(SP_SQL, ParamempID, EmpID)).ToList();
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        internal List<REmployee> GetJobEMP_Transfer(string empId, string OCODE)
        {
            try
            {
                using (var _context = new ERPSSLHBEntities())
                {
                    var ParamempID = new SqlParameter("@ocode", OCODE);
                    var EmpID = new SqlParameter("@eid", empId);
                    string SP_SQL = "HRM_JobEmployeeTransferSP @ocode,@eid";
                    return (_context.ExecuteStoreQuery<REmployee>(SP_SQL, ParamempID, EmpID)).ToList();
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        internal List<REmployee> GetJobTermination(string empId, string OCODE)
        {
            try
            {
                using (var _context = new ERPSSLHBEntities())
                {
                    var ParamempID = new SqlParameter("@ocode", OCODE);
                    var EmpID = new SqlParameter("@eid", empId);
                    string SP_SQL = "[HRM_JobTerminationSP] @ocode,@eid";
                    return (_context.ExecuteStoreQuery<REmployee>(SP_SQL, ParamempID, EmpID)).ToList();
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        internal List<REmployee> GetEmployeeIncrement(string empId, string OCODE)
        {
            try
            {
                using (var _context = new ERPSSLHBEntities())
                {
                    var ParamempID = new SqlParameter("@ocode", OCODE);
                    var EmpID = new SqlParameter("@eid", empId);
                    string SP_SQL = "[HRM_JobEmployeeIncSP] @ocode,@eid";
                    return (_context.ExecuteStoreQuery<REmployee>(SP_SQL, ParamempID, EmpID)).ToList();
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        internal List<REmployee> GetAllMaleEmployee(string OCODE, string gender)
        {
            try
            {
                using (var _context = new ERPSSLHBEntities())
                {
                    var ParamempID = new SqlParameter("@ocode", OCODE);
                    var EmpID = new SqlParameter("@Gender", gender);
                    string SP_SQL = "[HRM_Rpt_AllMaleEmployeesSP] @ocode,@Gender";
                    return (_context.ExecuteStoreQuery<REmployee>(SP_SQL, ParamempID, EmpID)).ToList();
                }

            }
            catch (Exception)
            {

                throw;
            }
        }


        internal List<LeaveForReport> GetLeaveInfoByEId(string empId, string currentDate, string OCODE)
        {
            try
            {
                using (var _context = new ERPSSLHBEntities())
                {
                    var ParamempID = new SqlParameter("@Eid", empId);
                    var ocode = new SqlParameter("@OCODE", OCODE);
                    var currentCode = new SqlParameter("@currentYear", currentDate);

                    string SP_SQL = "HRM_RptGetLeaveDetailsByEid @Eid,@OCODE,@currentYear";

                    return (_context.ExecuteStoreQuery<LeaveForReport>(SP_SQL, ParamempID, ocode, currentCode)).ToList();
                }

            }
            catch (Exception)
            {

                throw;
            }

        }

        internal List<EmployeeBenefit> GetRptForEmployeeBenefit(string empId)
        {
            try
            {
                using (var _context = new ERPSSLHBEntities())
                {
                    var EMPID = new SqlParameter("@EmpId", empId);
                    string SP_SQL = "HRM_EmployeeBenefit @EmpId";
                    return (_context.ExecuteStoreQuery<EmployeeBenefit>(SP_SQL, EMPID)).ToList();
                }

            }
            catch (Exception)
            {
                throw;
            }
        }

        internal List<EmployeeBenefit> GetRptForAllEmployeeBenefit(string OCODE)
        {
            try
            {
                using (var _context = new ERPSSLHBEntities())
                {
                    var O_CODE = new SqlParameter("@OCODE", OCODE);
                    string SP_SQL = "HRM_AllEmployeeBenefit @OCODE";
                    return (_context.ExecuteStoreQuery<EmployeeBenefit>(SP_SQL, O_CODE)).ToList();
                }

            }
            catch (Exception)
            {
                throw;
            }
        }

        internal List<AdvancedSalary> GetRptForAdvancedSalary(string empId)
        {
            try
            {
                using (var _context = new ERPSSLHBEntities())
                {
                    var EMPID = new SqlParameter("@EmpId", empId);
                    string SP_SQL = "HRM_AdvanceSalaryList @EmpId";
                    return (_context.ExecuteStoreQuery<AdvancedSalary>(SP_SQL, EMPID)).ToList();
                }

            }
            catch (Exception)
            {
                throw;
            }
        }

        internal List<AdvancedSalary> GetRptForAllAdvancedSalary(string OCODE)
        {
            try
            {
                using (var _context = new ERPSSLHBEntities())
                {
                    var O_CODE = new SqlParameter("@OCODE", OCODE);
                    string SP_SQL = "HRM_AllAdvanceSalaryList @OCODE";
                    return (_context.ExecuteStoreQuery<AdvancedSalary>(SP_SQL, O_CODE)).ToList();
                }

            }
            catch (Exception)
            {
                throw;
            }
        }

        internal List<EmployeeBenefit> GetRptForAllEmployeeBenefitDepartmentWise(int departmentId, int RegionId, int OfficeId)
        {
            try
            {
                using (var _context = new ERPSSLHBEntities())
                {
                    var DEPTID = new SqlParameter("@DeptId", departmentId);
                    var REGION = new SqlParameter("@Region", RegionId);
                    var OFFICE = new SqlParameter("@Office", OfficeId);
                    string SP_SQL = "HRM_AllEmployeeBenefitDeptWise @DeptId,@Region,@Office";
                    return (_context.ExecuteStoreQuery<EmployeeBenefit>(SP_SQL, DEPTID, REGION, OFFICE)).ToList();
                }

            }
            catch (Exception)
            {
                throw;
            }
        }

        internal List<AdvancedSalary> GetRptForAllAdvancedSalaryDeptWise(int departmentId, int RegionId, int OfficeId)
        {
            try
            {
                using (var _context = new ERPSSLHBEntities())
                {
                    var DEPTID = new SqlParameter("@DeptId", departmentId);
                    var REGION = new SqlParameter("@Region", RegionId);
                    var OFFICE = new SqlParameter("@Office", OfficeId);
                    string SP_SQL = "HRM_AllAdvanceSalaryListDeptWise @DeptId,@Region,@Office";
                    return (_context.ExecuteStoreQuery<AdvancedSalary>(SP_SQL, DEPTID, REGION, OFFICE)).ToList();
                }

            }
            catch (Exception)
            {
                throw;
            }
        }

        internal List<AdvancedSalary> GetRptForAllAdvancedSalaryOfficeWise(int RegionId, int OfficeId)
        {
            try
            {
                using (var _context = new ERPSSLHBEntities())
                {
                    var REGION = new SqlParameter("@Region", RegionId);
                    var OFFICE = new SqlParameter("@Office", OfficeId);
                    string SP_SQL = "HRM_AllAdvanceSalaryListOfficeWise @Region,@Office";
                    return (_context.ExecuteStoreQuery<AdvancedSalary>(SP_SQL, REGION, OFFICE)).ToList();
                }

            }
            catch (Exception)
            {
                throw;
            }
        }

        internal List<EmployeeBenefit> GetRptForAllEmployeeBenefitOfficeWise(int RegionId, int OfficeId)
        {
            try
            {
                using (var _context = new ERPSSLHBEntities())
                {
                    var REGION = new SqlParameter("@Region", RegionId);
                    var OFFICE = new SqlParameter("@Office", OfficeId);
                    string SP_SQL = "HRM_AllEmployeeBenefitOfficeWise @Region,@Office";
                    return (_context.ExecuteStoreQuery<EmployeeBenefit>(SP_SQL, REGION, OFFICE)).ToList();
                }

            }
            catch (Exception)
            {
                throw;
            }
        }



        internal List<HRM_DESIGNATIONS> GetAllDesignation(string OCODE)
        {
            try
            {
                var query = (from desig in _context.HRM_DESIGNATIONS
                             where desig.OCODE == OCODE
                             select desig).OrderBy(x => x.DEG_ID).ToList();


                return query.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        internal List<REmployee> GetEmployeeDesignation(string designation, string OCODE)
        {
            try
            {
                using (var _context = new ERPSSLHBEntities())
                {
                    var DESIG = new SqlParameter("@designation", designation);
                    var O_CODE = new SqlParameter("@OCODE", OCODE);
                    string SP_SQL = "HRM_RPT_designationwise @designation,@OCODE";
                    return (_context.ExecuteStoreQuery<REmployee>(SP_SQL, DESIG, O_CODE)).ToList();
                }

            }
            catch (Exception)
            {
                throw;
            }
        }

        internal List<REmployee> GetEmployeeBankAccount(string OCODE)
        {
            try
            {
                using (var _context = new ERPSSLHBEntities())
                {
                    var O_CODE = new SqlParameter("@OCODE", OCODE);
                    string SP_SQL = "HRM_RPT_BankAccountwise @OCODE";
                    return (_context.ExecuteStoreQuery<REmployee>(SP_SQL, O_CODE)).ToList();
                }

            }
            catch (Exception)
            {
                throw;
            }
        }

        internal List<LeaveForReport> GetEmployeewiseLeaveRpt(string empId, string Type, string OCODE)
        {
            try
            {
                using (var _context = new ERPSSLHBEntities())
                {
                    var EID = new SqlParameter("@Eid", empId);
                    var TYPE = new SqlParameter("@Type", Type);
                    var O_CODE = new SqlParameter("@OCODE", OCODE);
                    string SP_SQL = "HRM_RPT_EmployeeWiseLeave @Eid,@Type,@OCODE";
                    return (_context.ExecuteStoreQuery<LeaveForReport>(SP_SQL, EID, TYPE, O_CODE)).ToList();
                }

            }
            catch (Exception)
            {
                throw;
            }
        }

        internal List<LeaveForReport> GetAllEmployeewiseLeaveRpt(string OCODE)
        {
            try
            {
                using (var _context = new ERPSSLHBEntities())
                {
                    var O_CODE = new SqlParameter("@OCODE", OCODE);
                    string SP_SQL = "HRM_RPT_AllEmployeewiseLeave @OCODE";
                    return (_context.ExecuteStoreQuery<LeaveForReport>(SP_SQL, O_CODE)).ToList();
                }

            }
            catch (Exception)
            {
                throw;
            }
        }

        internal List<LeaveForReport> GetAllEmployeeLeaveSummeryRpt(DateTime fromDate, DateTime toDate, string OCODE)
        {
            try
            {
                using (var _context = new ERPSSLHBEntities())
                {
                    var Start = new SqlParameter("@startDate", fromDate);
                    var End = new SqlParameter("@endDate", toDate);
                    var O_CODE = new SqlParameter("@OCODE", OCODE);
                    string SP_SQL = "HRM_RPT_AllEmployeeLeaveSummery @startDate,@endDate,@OCODE";
                    return (_context.ExecuteStoreQuery<LeaveForReport>(SP_SQL, Start, End, O_CODE)).ToList();
                }

            }
            catch (Exception)
            {
                throw;
            }
        }

        internal List<LeaveForReport> GetAllEmployeeLeaveSummeryRptByRegion(DateTime fromDate, DateTime toDate, string OCODE, string Region)
        {
            try
            {
                using (var _context = new ERPSSLHBEntities())
                {
                    var Start = new SqlParameter("@startDate", fromDate);
                    var End = new SqlParameter("@endDate", toDate);
                    var O_CODE = new SqlParameter("@OCODE", OCODE);
                    var region = new SqlParameter("@Region", Region);
                    string SP_SQL = "HRM_RPT_AllEmployeeLeaveSummeryByRegion @startDate,@endDate,@OCODE,@Region";
                    return (_context.ExecuteStoreQuery<LeaveForReport>(SP_SQL,Start,End, O_CODE,region)).ToList();
                }

            }
            catch (Exception)
            {
                throw;
            }
        }

        internal List<LeaveForReport> GetAllEmployeeLeaveSummeryRptByOffice(DateTime fromDate, DateTime toDate,string OCODE,string Region,String Office)
        {
            try
            {
                using (var _context = new ERPSSLHBEntities())
                {
                    var Start = new SqlParameter("@startDate", fromDate);
                    var End = new SqlParameter("@endDate", toDate);
                    var O_CODE = new SqlParameter("@OCODE", OCODE);
                    var region = new SqlParameter("@Region", Region);
                    var ofice = new SqlParameter("@Office", Office);
                    string SP_SQL = "HRM_RPT_AllEmployeeLeaveSummeryByOffice @startDate,@endDate,@OCODE,@Region,@Office";
                    return (_context.ExecuteStoreQuery<LeaveForReport>(SP_SQL, Start, End, O_CODE, region, ofice)).ToList();
                }

            }
            catch (Exception)
            {
                throw;
            }
        }
        internal List<LeaveForReport> GetAllEmployeeLeaveSummeryRptByDepartment(DateTime fromDate, DateTime toDate, string OCODE, string Region, String Office, string Department)
        {
            try
            {
                using (var _context = new ERPSSLHBEntities())
                {
                    var Start = new SqlParameter("@startDate", fromDate);
                    var End = new SqlParameter("@endDate", toDate);
                    var O_CODE = new SqlParameter("@OCODE", OCODE);
                    var region = new SqlParameter("@Region", Region);
                    var ofice = new SqlParameter("@Office", Office);
                    var department = new SqlParameter("@Department", Department);
                    string SP_SQL = "HRM_RPT_AllEmployeeLeaveSummeryByDepartment @startDate,@endDate,@OCODE,@Region,@Office,@Department";
                    return (_context.ExecuteStoreQuery<LeaveForReport>(SP_SQL, Start, End, O_CODE, region, ofice, department)).ToList();
                }

            }
            catch (Exception)
            {
                throw;
            }
        }

        //internal List<HRM_DEPARTMENTS> GetAllDept(string OCODE)
        //{
        //    try
        //    {
        //        var query = (from department in _context.HRM_DEPARTMENTS
        //                     where department.OCODE == OCODE
        //                     select department).OrderBy(x => x.DPT_NAME);


        //        return query.ToList();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message.ToString());
        //    }

        //}


        internal List<string> GetAllDept(string OCODE)
        {
            try
            {
                var query = (from department in _context.HRM_DEPARTMENTS
                             where department.OCODE == OCODE
                             select department.DPT_NAME).Distinct();


                return query.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }

        }

        internal List<HRM_DEPARTMENTS> GetAllDistinctDepartment(string OCODE)
        {
            try
            {
                var query = (from department in _context.HRM_DEPARTMENTS
                             where department.OCODE == OCODE
                             select department).DistinctBy(x=>x.DPT_NAME).OrderBy(x=>x.DPT_NAME);


                return query.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }

        }


        internal List<REmployee> GetEmployeeListForDepartmentwise(string Dept)
        {
            try
            {
                using (var _context = new ERPSSLHBEntities())
                {
                    var DEPT = new SqlParameter("@Dept", Dept);
                    string SP_SQL = "HRM_RPT_ALLEmployeeDeptwiseNew @Dept";
                    return (_context.ExecuteStoreQuery<REmployee>(SP_SQL, DEPT)).ToList();
                }

            }
            catch (Exception)
            {
                throw;
            }
        }

        internal List<REmployee> GetEmployeeListForBlood(string OCODE)
        {
            try
            {
                using (var _context = new ERPSSLHBEntities())
                {
                    var O_CODE = new SqlParameter("@ocode", OCODE);
                    string SP_SQL = "HRM_RPT_AllEmployeeListForBlood @ocode";
                    return (_context.ExecuteStoreQuery<REmployee>(SP_SQL, O_CODE)).ToList();
                }

            }
            catch (Exception)
            {
                throw;
            }
        }
        internal List<HRM_DEPARTMENTS> GetDeptByOfficeId(int ResionId, int OfficeId, string Ocode)
        {
            try
            {
                var query = (from department in _context.HRM_DEPARTMENTS
                             where department.OCODE == Ocode && department.Office_ID == OfficeId && department.ResionId == ResionId
                             select department).OrderBy(x => x.DPT_NAME);


                return query.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }

        }

        internal List<REmployee> GetAllEmployeeJoiningDateWise(DateTime todate, DateTime Fromdate)
        {
            try
            {
                using (var _context = new ERPSSLHBEntities())
                {
                    var TOdate = new SqlParameter("@Todate", todate);
                    var FromDate = new SqlParameter("@From", Fromdate);
                   // HRM_Rpt_JoinningNewEmployee
                    string SP_SQL = "HRM_Rpt_EmployeeJoiningDateWise  @Todate,@From";
                    return (_context.ExecuteStoreQuery<REmployee>(SP_SQL, TOdate, FromDate)).ToList();
                }

            }
            catch (Exception)
            {
                throw;
            }

        }

        internal List<REmployee> GetAllEmployeeJoiningDateByRegion(DateTime todate, DateTime Fromdate, int ResionId)
        {
            try
            {
                using (var _context = new ERPSSLHBEntities())
                {
                    var TOdate = new SqlParameter("@Todate", todate);
                    var FromDate = new SqlParameter("@From", Fromdate);
                    var Region = new SqlParameter("@Region", ResionId);
                    // HRM_Rpt_JoinningNewEmployee
                    string SP_SQL = "HRM_Rpt_EmployeeJoiningDateByRegion  @Todate,@From,@Region";
                    return (_context.ExecuteStoreQuery<REmployee>(SP_SQL, TOdate, FromDate, Region)).ToList();
                }

            }
            catch (Exception)
            {
                throw;
            }

        }

        internal List<REmployee> GetAllEmployeeJoiningDateByOffice(DateTime todate, DateTime Fromdate, int ResionId,int OfficeId)
        {
            try
            {
                using (var _context = new ERPSSLHBEntities())
                {
                    var TOdate = new SqlParameter("@Todate", todate);
                    var FromDate = new SqlParameter("@From", Fromdate);
                    var Region = new SqlParameter("@Region", ResionId);
                    var Office = new SqlParameter("@Office", OfficeId);
                    // HRM_Rpt_JoinningNewEmployee
                    string SP_SQL = "HRM_Rpt_EmployeeJoiningDateByOffice  @Todate,@From,@Region,@Office";
                    return (_context.ExecuteStoreQuery<REmployee>(SP_SQL, TOdate, FromDate, Region, Office)).ToList();
                }

            }
            catch (Exception)
            {
                throw;
            }

        }
        internal List<REmployee> GetAllEmployeeJoiningDateByDepartment(DateTime todate, DateTime Fromdate, int ResionId, int OfficeId,int DepartmentId)
        {
            try
            {
                using (var _context = new ERPSSLHBEntities())
                {
                    var TOdate = new SqlParameter("@Todate", todate);
                    var FromDate = new SqlParameter("@From", Fromdate);
                    var Region = new SqlParameter("@Region", ResionId);
                    var Office = new SqlParameter("@Office", OfficeId);
                    var Department = new SqlParameter("@Department", DepartmentId);
                    // HRM_Rpt_JoinningNewEmployee
                    string SP_SQL = "HRM_Rpt_EmployeeJoiningDateByDepartment  @Todate,@From,@Region,@Office,@Department";
                    return (_context.ExecuteStoreQuery<REmployee>(SP_SQL, TOdate, FromDate, Region, Office, Department)).ToList();
                }

            }
            catch (Exception)
            {
                throw;
            }

        }
        internal List<REmployee> GetAllEmployeeJoiningDateBySection(DateTime todate, DateTime Fromdate, int ResionId, int OfficeId, int DepartmentId,int SectionId)
        {
            try
            {
                using (var _context = new ERPSSLHBEntities())
                {
                    var TOdate = new SqlParameter("@Todate", todate);
                    var FromDate = new SqlParameter("@From", Fromdate);
                    var Region = new SqlParameter("@Region", ResionId);
                    var Office = new SqlParameter("@Office", OfficeId);
                    var Department = new SqlParameter("@Department", DepartmentId);
                    var Section = new SqlParameter("@Section", SectionId);
                    // HRM_Rpt_JoinningNewEmployee
                    string SP_SQL = "HRM_Rpt_EmployeeJoiningDateBySection  @Todate,@From,@Region,@Office,@Department,@Section";
                    return (_context.ExecuteStoreQuery<REmployee>(SP_SQL, TOdate, FromDate, Region, Office, Department, Section)).ToList();
                }

            }
            catch (Exception)
            {
                throw;
            }

        }
       
        internal List<REmployee> GetAllEmployeeLeftgDateWise(DateTime todate, DateTime Fromdate)
        {
            try
            {
                using (var _context = new ERPSSLHBEntities())
                {
                    var TOdate = new SqlParameter("@Todate", todate);
                    var FromDate = new SqlParameter("@From", Fromdate);
                   // HRM_Rpt_JoinningNewEmployee
                    string SP_SQL = "HRM_Rpt_JoinningNewEmployee @Todate,@From";
                    return (_context.ExecuteStoreQuery<REmployee>(SP_SQL, TOdate, FromDate)).ToList();
                }

            }
            catch (Exception)
            {
                throw;
            }

        }

        internal List<HRM_Office> GetOfficeByRegionCode(string RegionCode)
        {
            try
            {
                var query = (from off in _context.HRM_Office
                             join reg in _context.HRM_Regions on off.RegionId equals reg.RegionID
                             where reg.RegionCode == RegionCode
                             select off).OrderBy(x => x.RegionId);


                return query.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }

        }
        internal List<LeaveForReport> GetAllEmployeewiseLeaveStatmentRpt(string OCODE, string eid)
        {
            try
            {
                using (var _context = new ERPSSLHBEntities())
                {
                    var O_CODE = new SqlParameter("@OCODE", OCODE);
                    var E_Eid = new SqlParameter("@Eid", eid);

                    string SP_SQL = "HRM_RPT_EIDWiseLeaveStatement @OCODE,@Eid";
                    return (_context.ExecuteStoreQuery<LeaveForReport>(SP_SQL, O_CODE, E_Eid)).ToList();
                }

            }
            catch (Exception)
            {
                throw;
            }
        }


        internal List<LeaveForReport> GetEmployeewiseTotalLeave(string empId, string OCODE)
        {
            try
            {
                using (var _context = new ERPSSLHBEntities())
                {
                    var EID = new SqlParameter("@Eid", empId);
                    var O_CODE = new SqlParameter("@OCODE", OCODE);
                    string SP_SQL = "HRM_RPT_EmployeeWiseTotalLeave @Eid,@OCODE";
                    return (_context.ExecuteStoreQuery<LeaveForReport>(SP_SQL, EID, O_CODE)).ToList();
                }

            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}

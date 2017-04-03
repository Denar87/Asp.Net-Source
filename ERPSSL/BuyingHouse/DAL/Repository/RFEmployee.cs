using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPSSL.BuyingHouse.DAL.Repository
{
    public class RFEmployee
    {
        public Int64 EmpId { set; get; }
        public string EID { set; get; }
        public string FirstName { set; get; }
        public string LastName { set; get; }
        public string FullName { set; get; }
        public string EmployeeName { set; get; }
        public string Gender { set; get; }
        public string BloodGroup { set; get; }
        public string FatherName { set; get; }
        public string MotherName { set; get; }
        public string ContactNumber { set; get; }
        public string Email { set; get; }
        public string NomineeName { set; get; }

        public string REMARKS { set; get; }
        public string Grade { set; get; }

        public string ResionName { set; get; }
        public string OfficeName { set; get; }
        public string DepartmentName { set; get; }
        public string SectionName { set; get; }
        public string SubSectionName { set; get; }
        public string DesignName { set; get; }

        public decimal? Salary { set; get; }
        public decimal? OldSalary { set; get; }
        public decimal? GrossRate { set; get; }
        public string SalaryUpdateDate { set; get; }

        public string DesignationName { get; set; }
        public string DesginationName { get; set; }
        public string DesignationWithSubSection { get; set; }

        public string NumberOfChildren { set; get; }
        public string ChildrenNameRemark { set; get; }
        public string EmergencyContactNo { set; get; }
        public string PresentAddress { set; get; }
        public string PermanenAddress { set; get; }
        public string EMP_TERMIN_STATUS { set; get; }
        public string DateOfBrith { set; get; }
        public string MaritalStatus { set; get; }
        public string Religion { set; get; }
        public string NationalID { set; get; }
        public string Nationality { set; get; }
        public string EmergencyContactPerson { set; get; }
        public string EmergencyAddress { set; get; }
        public byte[] EMP_PHOTO { set; get; }

        public string CompanyName { set; get; }
        public string CompanyAddress { set; get; }
        public string CompanyMobile { set; get; }
        public string CompanyWeb { set; get; }
        public string CompanyMail { set; get; }

        public string JoiningDates { set; get; }
        public string JobTerminateDate { set; get; }
        public string DEG_NAME { get; set; }
        public string JoiningDate { set; get; }
        public DateTime? JoiningDate1 { set; get; }
        public DateTime? Terminatedate { set; get; }
        public string PRV_RegionName { set; get; }
        public string PRV_OfficeName { set; get; }
        public string PRV_DepartmentName { set; get; }
        public string Old_Designation { set; get; }
        public string New_Designation { set; get; }
        public string New_RegionName { set; get; }
        public string New_OfficeName { set; get; }
        public string New_DepartmentName { set; get; }
        public string TransferDate { set; get; }
        public string ConfiramtionDate { set; get; }
        public string TerminateReason { set; get; }

        //For All Child List
        public string Name { set; get; }
        public string DOB { set; get; }
        public int Age { set; get; }
        public string RegionName { set; get; }

        public int? EmployeeType { set; get; }
        public string EmployeeTypes { set; get; }
        public byte[] Logo { set; get; }
        public string EMP_Retired_Status { set; get; }
        public string EMP_Resignation_Status { set; get; }
        public string AccountNo { set; get; }
        public string BankName { set; get; }
        public string Duration { set; get; }

        public double JobDuration { get; set; }
        public string JobEndYear { get; set; }
        public int JobDurationHave { get; set; }
        public string DurationHave { get; set; }

        public int TotalActive { get; set; }
        public int TotalInactive { get; set; }
        public int TotalEmployee { get; set; }
        public string JobLocation { get; set; }
        public string WithinYears { get; set; }


        public int Total05years { get; set; }
        public int Total10years { get; set; }
        public int Total15years { get; set; }
        public int Total20years { get; set; }
        public int Total25years { get; set; }
        public int Total30years { get; set; }
        public int Total35years { get; set; }
        public int Total40years { get; set; }
        public int Exception { get; set; }

        public string ShiftCode { get; set; }
        public string ShiftName { get; set; }
        public string ShiftType { get; set; }
        public string Education { get; set; }


        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public DateTime? EffectiveDate { get; set; }
        public DateTime? IncrementDate { get; set; }
        public decimal IncrementSalary { get; set; }
        public decimal previousSalary { get; set; }
        public string SalaryIncrementStatus { get; set; }
        public DateTime? TRANSFER_DATE { get; set; }

        public int? SeniorId { get; set; }



        public string Present_Vill_HouseNo { get; set; }
        public string Present_PostOffice { get; set; }
        public string Present_Thana { get; set; }
        public string Present_District { get; set; }
        public string LeaveAppliedDate { get; set; }
        public string LeaveToDate { get; set; }
        public string LeaveReason { get; set; }
        public int TotalDay { get; set; }

        public int DepartmentId { get; set; }
        public int? DeptId { get; set; }
    }
}
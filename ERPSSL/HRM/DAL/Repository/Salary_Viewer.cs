using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPSSL.HRM.DAL.Repository
{
    public class Salary_Viewer
    {

        public string DepartmentName { set; get; }
        public string CompanyName { set; get; }
        public string CompanyAddress { set; get; }
        public string CompanyMobile { set; get; }
        public string CompanyWeb { set; get; }
        public string CompanyMail { set; get; }
        public string ResionName { set; get; }
        public string OfficeName { set; get; }

        public int Total_Other_Holiday { get; set; }
        public int PaySalary_Temp_ID { get; set; }
        public int PaySalary_ID { get; set; }

        public string EID { get; set; }
        public string FullName { get; set; }
        public string DesginationName { get; set; }
        public string Grade { get; set; }
        public DateTime? JoiningDate { get; set; }

        public Decimal? Total_Basic_New { get; set; }
        public Decimal? HOUSE_RENT { set; get; }
        public Decimal? MEDICAL { set; get; }
        public Decimal? CONVEYANCE { set; get; }
        public Decimal? FOOD_ALLOW { set; get; }
        public Decimal? FixedAllowance { set; get; }
        public Decimal? GROSS_SAL { set; get; }

        public DateTime? Date_Processed { set; get; }
        public Decimal? Total_Gross_Sal { set; get; }
        public Decimal? Total_Tax { set; get; }
        public Decimal? Net_Payable { set; get; }
        public Decimal? OT_Taka { set; get; }
        public Decimal? OT_Rate { set; get; }
        public Decimal? Total_Deduction { set; get; }
        public decimal? Total_Compliance_Deduction { get; set; }


        public int P { set; get; }
        public int L { set; get; }
        public int SL { set; get; }
        public int CL { set; get; }
        public int ML { set; get; }
        public int AL { set; get; }
        public int LWP { set; get; }

        public double? TotalDeductDay { set; get; }
        public decimal? Other_Deduction { set; get; }
        public decimal? Salary_Punishment { set; get; }

        public int Absent_Day { set; get; }
        public DateTime? Salary_Month { set; get; }
        public int Worked_Day { set; get; }
        public decimal? Payable_Salary { get; set; }

        public decimal? Night_Bill { get; set; }
        public decimal? Holiday_Bill { get; set; }

        public decimal? Total_Benifit { set; get; }
        public decimal? Absent_Deduction { set; get; }
        public decimal? AdvanceDeduction { set; get; }
        public decimal? Total_LateDeduction_Cost { set; get; }
        public decimal? Total_Leave_Cost { set; get; }
        public int Work_Holiday { set; get; }
        public int Other_Holiday { set; get; }
        public int Total_Holiday { set; get; }
        public int Total_Day_Of_Month { set; get; }
        public decimal? Stamp { set; get; }
        public byte[] EMP_Singnature { set; get; }
        public decimal? Attendance_Bonus { set; get; }
        public int? Over_Time { set; get; }
        public int? OT_Compliance { set; get; }
        public decimal? OT_Compliance_Taka { get; set; }
        public byte[] Logo { set; get; }
        public string SectionName { get; set; }
        public string SubSectionName { get; set; }
        public int Manpower { get; set; }
        public decimal? TotalSalary { get; set; }
        public decimal? TotalOtAmount { get; set; }
        public decimal? TotalAmount { get; set; }
        public decimal? Total_Net_Payable { get; set; }
        public decimal? Total_LateDeduction_Cost1 { get; set; }

        public bool IsSalaryHeldup { get; set; }
        public decimal? Total_Gross_Sal_Compliance { get; set; }
        public decimal? Net_Payable_Compliance { get; set; }

        public decimal? Total_OT_Compliance { get; set; }
        public decimal? Total_Attendance_Bonus { get; set; }
        public decimal? Total_Night_Bill { get; set; }
        public decimal? Total_Holiday_Bill { get; set; }
        public decimal? Total_OT_Extra { get; set; }
        public decimal? Total_AdvanceDeduction { get; set; }
        public decimal? Total_Absent_Cost { get; set; }
        public decimal? Total_Other_Deduction { get; set; }
        public decimal? Total_Salary_Punishment { get; set; }    
        public decimal? Total_Stamp_Deduction { get; set; }



    }
}



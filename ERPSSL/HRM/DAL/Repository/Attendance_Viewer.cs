using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPSSL.HRM.DAL.Repository
{
    public class Attendance_Viewer
    {
        public string AttendanceDate { get; set; }
        public string EID { get; set; }
        public string DEG_NAME { get; set; }
        public string SectionName { get; set; }
        public string SubSectionName { get; set; }
        public string FullName { get; set; }
        public TimeSpan? In_Time { get; set; }
        public TimeSpan? Out_Time { get; set; }
        public string OfficeName { set; get; }
        public string ResionName { set; get; }
        public string DepartmentName { set; get; }
        public string CompanyName { set; get; }
        public string CompanyAddress { set; get; }
        public string CompanyMobile { set; get; }
        public string CompanyWeb { set; get; }
        public string CompanyMail { set; get; }
        public string Status { set; get; }
        public string ShiftName { set; get; }
        public string ShiftCode { set; get; }
        public string StartDate { set; get; }
        public string EndDate { set; get; }
        public DateTime StartDates { set; get; }
        public DateTime EndDates { set; get; }
        public string DesignationName { get; set; }

        public string FromDate { get; set; }
        public string ToDate { get; set; }

        public DateTime? JoiningDate { set; get; }
        public decimal GROSS_SAL { set; get; }
        public TimeSpan? Over_Time { set; get; }
        public string Attendance_Day { set; get; }

        //OT Calculation
        public int? ID { get; set; }
        public Int64? EMPID { set; get; }
        public string Name { set; get; }
        public string BIO_MATRIX_ID { set; get; }
        public string Mobile { set; get; }
        public string DesginationName { set; get; }
        public string DPT_NAME { set; get; }
        public string Esection { set; get; }

        //Attendance day
        public string b1 { set; get; }
        public string b2 { set; get; }
        public string b3 { set; get; }
        public string b4 { set; get; }
        public string b5 { set; get; }
        public string b6 { set; get; }
        public string b7 { set; get; }
        public string b8 { set; get; }
        public string b9 { set; get; }
        public string b10 { set; get; }
        public string b11 { set; get; }
        public string b12 { set; get; }
        public string b13 { set; get; }
        public string b14 { set; get; }
        public string b15 { set; get; }
        public string b16 { set; get; }
        public string b17 { set; get; }
        public string b18 { set; get; }
        public string b19 { set; get; }
        public string b20 { set; get; }
        public string b21 { set; get; }
        public string b22 { set; get; }
        public string b23 { set; get; }
        public string b24 { set; get; }
        public string b25 { set; get; }
        public string b26 { set; get; }
        public string b27 { set; get; }
        public string b28 { set; get; }
        public string b29 { set; get; }
        public string b30 { set; get; }
        public string b31 { set; get; }
        
        //Attendance Status
        public string a1 { set; get; }
        public string a2 { set; get; }
        public string a3 { set; get; }
        public string a4 { set; get; }
        public string a5 { set; get; }
        public string a6 { set; get; }
        public string a7 { set; get; }
        public string a8 { set; get; }
        public string a9 { set; get; }
        public string a10 { set; get; }
        public string a11 { set; get; }
        public string a12 { set; get; }
        public string a13 { set; get; }
        public string a14 { set; get; }
        public string a15 { set; get; }
        public string a16 { set; get; }
        public string a17 { set; get; }
        public string a18 { set; get; }
        public string a19 { set; get; }
        public string a20 { set; get; }
        public string a21 { set; get; }
        public string a22 { set; get; }
        public string a23 { set; get; }
        public string a24 { set; get; }
        public string a25 { set; get; }
        public string a26 { set; get; }
        public string a27 { set; get; }
        public string a28 { set; get; }
        public string a29 { set; get; }
        public string a30 { set; get; }
        public string a31 { set; get; }
        
        //OT
        public decimal? d1 { set; get; }
        public decimal? d2 { set; get; }
        public decimal? d3 { set; get; }
        public decimal? d4 { set; get; }
        public decimal? d5 { set; get; }
        public decimal? d6 { set; get; }
        public decimal? d7 { set; get; }
        public decimal? d8 { set; get; }
        public decimal? d9 { set; get; }
        public decimal? d10 { set; get; }
        public decimal? d11 { set; get; }
        public decimal? d12 { set; get; }
        public decimal? d13 { set; get; }
        public decimal? d14 { set; get; }
        public decimal? d15 { set; get; }
        public decimal? d16 { set; get; }
        public decimal? d17 { set; get; }
        public decimal? d18 { set; get; }
        public decimal? d19 { set; get; }
        public decimal? d20 { set; get; }
        public decimal? d21 { set; get; }
        public decimal? d22 { set; get; }
        public decimal? d23 { set; get; }
        public decimal? d24 { set; get; }
        public decimal? d25 { set; get; }
        public decimal? d26 { set; get; }
        public decimal? d27 { set; get; }
        public decimal? d28 { set; get; }
        public decimal? d29 { set; get; }
        public decimal? d30 { set; get; }
        public decimal? d31 { set; get; }
        public DateTime? DateFrom { set; get; }
        public DateTime? DateTo { set; get; }
        public decimal? TotalOT { get; set; }
        public string OCODE { get; set; }
        public string UserID { get; set; }
        public string RegionName { get; set; }
        public int? RegionsId { get; set; }
        public int? OfficeId { get; set; }
        public int? DepartmentId { get; set; }
        public int? SectionId { get; set; }
        public int? SubSectionId { get; set; }
        public int? DesginationId { get; set; }

        public int? TotalPresent { get; set; }
        public int? Total_Days { get; set; }
        public int? TotalLate { get; set; }
        public int? TotalOverLate { get; set; }
        public int? TotalAbsent { get; set; }
        public int? Total_Employee { get; set; }
        public int? Total_Leave { get; set; }
        public int? TotalDay { get; set; }

        public double? Percent_Present { get; set; }
        public double? Percent_Absent { get; set; }
        public double? Percent_Leave { get; set; }
        public int? TotalPresent_Late { get; set; }
        public int? Total_Attendance_Day { get; set; }

        public double? GrandTotalOT { get; set; }

        //salary proccess
        public int? TotalWeekend { get; set; }
        public int? Total_Other_Holiday { get; set; }
        public TimeSpan? Late_Time { get; set; }
        public float OT_Hour { get; set; }
        public double? OT_Total { get; set; }
        public int Payable_Day { get; set; }

        public TimeSpan? Total_Late { get; set; }
        public int? Total_OT { get; set; }
        public int? Total_Holiday { get; set; }
        public byte[] Logo { get; set; }
        public string Remarks { set; get; }
        public string LeaveType { get; set; }
    }
}

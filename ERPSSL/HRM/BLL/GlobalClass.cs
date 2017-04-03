using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPSSL.HRM.BLL
{

    public class GlobalClass
    {
        public static int IsEidValid { get; set; }

        private static byte[] _EmpPhoto = null;
        public static byte[] EmpPhoto
        {
            get { return _EmpPhoto; }
            set { _EmpPhoto = value; }
        }

        public static int TotalLeave { get; set; }
        public static string employeeID { get; set; }
        public static int QueryStringId { get; set; }
        public static string CompanyId { get; set; }
        public static int StyleId { get; set; }
    }

    public class Company_Config
    {
        public static string COMPANY_NAME = "Fantasia";
        public static string COMPANY_ADDRESS = "Dhaka,Bangladesh";
    }

    public class HRM_Reason
    {
        public string Reg_Name { get; set; }
        public string Off_Name { get; set; }
        public string ReasonType { set; get; }
        public string ShiftCode { set; get; }
        public string ShiftName { set; get; }
        public DateTime ReasonDate { set; get; }
        public Time InTime { set; get; }
        public Time OutTime { set; get; }
        public string Remarks { set; get; }
    }

    public class HRM_EMPLOYEES_VIEWER
    {
        public string TOHour { set; get; }
        public string FirstName { set; get; }
        public string LastName { set; get; }
        public string BIO_ID { get; set; }
        public int REG_ID { get; set; }
        public int OFC_ID { get; set; }
        public int DPT_ID { get; set; }
        public int SEC_ID { get; set; }
        public int SUB_SEC_ID { get; set; }
        public int DEG_ID { get; set; }
        public int GRADE_ID { get; set; }
        //---------------------------------
        public string EID { get; set; }
        public int EMP_ID { get; set; }
        public string REG_NAME { get; set; }
        public string OFC_NAME { get; set; }
        public string DPT_NAME { get; set; }
        public string SEC_NAME { get; set; }
        public string SUB_SEC_NAME { get; set; }
        public string DEG_NAME { get; set; }
        public string GRADE { get; set; }
        public string Gender { get; set; }
        public string EMP_FIRSTNAME { get; set; }
        public string EMP_LASTNAME { get; set; }
        public string EMP_CONTACT_NO { get; set; }
        public int STEP { set; get; }
        public decimal GorssSalary { set; get; }
        public string EMP_EMAIL { get; set; }
        public DateTime? DATE_JOINED { get; set; }
        public string EmployeeFullName { set; get; }
        public string CONTRACT { get; set; }
        public string Is_Holiday { set; get; }

        public string SHIFTCODE { get; set; }
        public string SHIFT { get; set; }
        public TimeSpan? Shift_TotalHour { get; set; }

        public string Salary_Month { get; set; }
        public int Salary_Year { get; set; }
        public double? TotalDeductDay { get; set; }

        public string Working_Day { get; set; }
        public bool? Attendance_Bouns { set; get; }
        public bool? Late_Applicable { set; get; }
        public bool? Absence_Applicable { set; get; }
        public bool? Tax_Applicable { set; get; }
        public bool? PF_Applicable { set; get; }
        public bool? On_Amount { set; get; }
        public bool? OT_Applicable { get; set; }

        public string Type { set; get; }
        public DateTime? IncrementDate { set; get; }
        public DateTime? EffectiveDate { set; get; }
        public decimal PreviousSalary { set; get; }
        public decimal BasicSalary { set; get; }
        public decimal AfterIncrementSalry { set; get; }

        public decimal IncrementAmount { get; set; }
        public DateTime AttendanceDate { set; get; }
        public TimeSpan? In_Time { set; get; }
        public TimeSpan? Out_Time { set; get; }
        public string Status { set; get; }

        public int Id { get; set; }
        public Double salaryDeductDay { set; get; }
        public DateTime SalaryDeductDate { set; get; }

        public decimal Amount { get; set; }
        public string BenefitType { set; get; }

        public decimal? Tax_Amount { set; get; }



        public DateTime? TERMINATE_DATE { get; set; }

        public string REMARKS { get; set; }

        public int TERMINATE_ID { get; set; }

        public long ID { get; set; }

        public decimal? IncrementSalary { get; set; }
    }

    public class HRM_EMP_TRANSFER_VIEW
    {
        public Int32 TRANSFER_ID { get; set; }
        public string REGION_ID_FROM { get; set; }
        public string REGION_ID_TO { get; set; }
        public string DPT_ID_FROM { get; set; }
        public string DPT_ID_TO { get; set; }
        //public string SEC_NAME { get; set; }
        //public string SUB_SEC_NAME { get; set; }
        //public string DEG_NAME { get; set; }
        //public string GRADE { get; set; }
        public DateTime TRANSFER_DATE { get; set; }
        public string EMP_FIRSTNAME { get; set; }

    }

    public class HRM_EMP_SALARY_UPDATE
    {
        public string EID { get; set; }
        public Int64 EMP_ID { get; set; }

        public decimal salary { get; set; }
        public string Grade { get; set; }
        public string EMP_FIRSTNAME { get; set; }
        public string EMP_LASTNAME { get; set; }
        public string EMP_CONTACT_NO { get; set; }

        public string CONTRACT { get; set; }
        public string DEG_NAME { get; set; }
        public string DPT_NAME { get; set; }

        public int? DesginationID { get; set; }
    }

    public class HRM_EMP_ID_VIEW
    {
        //public byte[] AVATER { get; set; }
        //public string SEX { get; set; }
        //public string DPT_NAME { get; set; }
        //public string SEC_NAME { get; set; }
        //public string SUB_SEC_NAME { get; set; }
        //public string DEG_NAME { get; set; }
        //public string GRADE { get; set; }
        //public string EMP_FULLNAME { get; set; }
        //public DateTime EMP_DOB { get; set; }
        //public string EMP_CONTACT_NO { get; set; }
        //public DateTime VALID_FROM { get; set; }
        //public DateTime VALID_TO { get; set; } 
        public byte[] AVATER { get; set; }
        public string SEX { get; set; }
        public string DPT_NAME { get; set; }
        public string SEC_NAME { get; set; }
        public string SUB_SEC_NAME { get; set; }
        public string DEG_NAME { get; set; }
        public string GRADE { get; set; }
        //public string EMP_FULLNAME { get; set; }
        public string FIRSTNAME { get; set; }
        public string LASTNAME { get; set; }
        public string EMP_FULLNAME { get; set; }
        public DateTime? EMP_DOB { get; set; }
        public string EMP_CONTACT_NO { get; set; }

        public string NAME { get; set; }
        public string ADDRESS { get; set; }
        public string MOBILE { get; set; }
        public string PHONE { get; set; }
        public string EMAIL { get; set; }
        public string WEB { get; set; }
        public byte[] LOGO { get; set; }
        public string OfficeName { get; set; }
        public DateTime? JoinningDate { get; set; }
        public string EID { get; set; }
        public string BloodGroup { get; set; }
        public string COMPANYNAME { get;  set; }
        public byte[] EMP_SIGN { get; set; }

        //public DateTime VALID_FROM { get; set; }
        //public DateTime VALID_TO { get; set; }

    }

    public class RPT_EMP_CERTIFICATION
    {
        public Int64 EMP_ID { get; set; }
        public string EID { get; set; }
        public string DPT_NAME { get; set; }
        public string SEC_NAME { get; set; }
        public string SUB_SEC_NAME { get; set; }
        public string DEG_NAME { get; set; }
        public string GRADE { get; set; }

        public string EMP_FATHERS_NAME { get; set; }
        public string EMP_NAME { get; set; }
        public string EMP_SEX { get; set; }
        public string EMP_BLOOD_GRP { get; set; }
        public DateTime DATE_JOINED { get; set; }
    }

    public class RPT_EMP_APPOINMENT
    {
        public Int64 EMP_ID { get; set; }
        public string EID { get; set; }
        public string DPT_NAME { get; set; }
        public string SEC_NAME { get; set; }
        public string SUB_SEC_NAME { get; set; }
        public string DEG_NAME { get; set; }
        public string GRADE { get; set; }

        public string EMP_NAME { get; set; }
        public string EMP_SEX { get; set; }
        public string EMP_BLOOD_GRP { get; set; }
        public DateTime DATE_JOINED { get; set; }
    }

    public partial class temp_Academic_Qualification
    {
        public int id { get; set; }
        public string level_of_Education { get; set; }
        public string exam { get; set; }
        public string major { get; set; }
        public string institute_name { get; set; }
        public string result { get; set; }
        public Nullable<int> passing_year { get; set; }
        public string duration { get; set; }
        public string achievement { get; set; }
    }
    public class HR_DEMAND
    {
        public string DEPT_NAME { get; set; }
        public string SEC_NAME { get; set; }
        public int HR_DEMAND_NUM { get; set; }
        public DateTime HR_DEMAND_DATE { get; set; }
    }
    public class SERVICE_EVALUATION
    {
        public string EMP_NAME { get; set; }
        public int ABSENCERROR { get; set; }
        public int ACCURACY { get; set; }
        public int HABBIT { get; set; }
        public int INNOVATION { get; set; }
        public int ORDERLINES { get; set; }
        public int ATTENDANCE { get; set; }
        public int CO_OPERATION { get; set; }
        public int INITIATIVE { get; set; }
        public int KNOWLEDGE { get; set; }
        public int RELIABILITY { get; set; }
        public int OUT_OF { get; set; }
    }

    public class RPT_EMP_PREVIEW
    {
        public string EMP_NAME { get; set; }
        public string EID { get; set; }
        public string EMP_SEX { get; set; }
        public string EMP_FATHERS_NAME { get; set; }
        public string EMP_MOTHERS_NAME { get; set; }
        public DateTime EMP_DOB { get; set; }

        public string EMP_MARITUAL_STATUS { get; set; }
        public string EMP_RELIGION { get; set; }
        public string EMP_NATIONALITY { get; set; }
        public string EMP_BLOOD_GRP { get; set; }
        public string EMP_EMAIL { get; set; }
        public string EMP_EMG_CONTACT_NO { get; set; }
        public string EMP_PRE_ADDRESS { get; set; }
        public string EMP_PER_ADDRESS { get; set; }

        public string EMP_NOMINEE_NAME { get; set; }
        public string EMP_NOMINEE_AGE { get; set; }
        public string EMP_NOMINEE_RELATION { get; set; }
        public DateTime DATE_JOINED { get; set; }
        public byte[] EMP_PHOTO { get; set; }
        public string EMP_COMPANY_EMAIL { get; set; }
        public string EMP_CONTACT_NO { get; set; }
        //public string EMP_PRE_ADDRESS { get; set; }  
        public string DPT_NAME { get; set; }
        public string DEG_NAME { get; set; }

    }

    public class HRM_EMPLOYEES_CONTRACT
    {

        public string EID { get; set; }
        public Int64 EMP_ID { get; set; }

        public string EMP_FIRSTNAME { get; set; }
        public string EMP_LASTNAME { get; set; }
        public string EMP_CONTACT_NO { get; set; }

        public string CONTRACT { get; set; }
        public string DEG_NAME { get; set; }
        public string DPT_NAME { get; set; }
    }

    public class HRM_LEAVE
    {
        public Int32 TOTAL_REM_DAY { get; set; }
        public Int32 TOTAL_LEV_DAYS { get; set; }
    }

    public class WORK_SHEET
    {
        public string EMP_NAME { get; set; }
        public string IN_TIME { get; set; }
        public string OUT_TIME { get; set; }
        public string WORKED_TIME { get; set; }
        public string OVER_TIME { get; set; }
        public string ATT_DATE { get; set; }
    }

    public class leave_Details
    {
        public int LEV_DETAILS_ID { get; set; }
        public DateTime LEV_DATES { get; set; }
        public Int32 LEV_TYPE_ID { get; set; }
        public string LEV_TYPE_NAME { get; set; }
        public string EMP_FIRSTNAME { get; set; }

    }

    public class RPT_EMP_LEAVE
    {
        public string EMP_NAME { get; set; }
    }



    public class HRM_EMPLOYEES_EDIT
    {
        public string EMP_SEX { get; set; }
        public string EMP_FIRSTNAME { get; set; }
        public string EMP_LASTNAME { get; set; }
        public DateTime EMP_DOB { get; set; }
        public string EMP_FATHERS_NAME { get; set; }
        public string EMP_MOTHERS_NAME { get; set; }
        public string EMP_RELIGION { get; set; }
        public string EID { get; set; }
        public string EMP_BLOOD_GRP { get; set; }
        public string EMP_MARITUAL_STATUS { get; set; }
        public string EMP_NATIONALITY { get; set; }
        public DateTime DATE_JOINED { get; set; }
        public string EMP_PER_ADDRESS { get; set; }
        public string EMP_PRE_ADDRESS { get; set; }
        public string EMP_CONTACT_NO { get; set; }
        public string EMP_EMAIL { get; set; }
        public string EMP_ALT_EMAIL { get; set; }

        public string EMP_EMG_CONTACT_NO { get; set; }
        public string EMP_NOMINEE_NAME { get; set; }
        public string EMP_NOMINEE_RELATION { get; set; }
        public string EMP_NOMINEE_AGE { get; set; }
        public string ReportingBossName { get; set; }
        public string RptBossDSG { get; set; }

        public string Reg_Name { get; set; }
        public int Reg_ID { get; set; }

        public string Off_Name { get; set; }
        public int Off_ID { get; set; }

        public string DPT_NAME { get; set; }
        public int DPT_ID { get; set; }

        public string SEC_NAME { get; set; }
        public int SEC_ID { get; set; }

        public string SUB_SEC_NAME { get; set; }
        public int SUB_SEC_ID { get; set; }

        public string DEG_NAME { get; set; }
        public int DEG_ID { get; set; }

        public string GRADE { get; set; }
        public int GRADE_ID { get; set; }

        public int Step { set; get; }
        public string Shift { set; get; }

        public string JobResponsibility { set; get; }
    }
    public class LatterFormate
    {
        public string Type { set; get; }
        public string Title { set; get; }

        public Int64 LId { set; get; }
    }

    public class Category
    {
        public string CategoryName { set; get; }
        public int PageId { set; get; }
        public string PageName { set; get; }
        public string PageUrl { set; get; }
        public int MouleId { set; get; }
        public int categoryid { set; get; }
        public Int64? ID { set; get; }
    }

    }

    public class HRM_PersonalInfoInc
    {
        public string EMP_SEX { get; set; }
        public string EMP_FIRSTNAME { get; set; }
        public string EMP_LASTNAME { get; set; }
        public string EMP_Name { get; set; }
        public decimal? EMP_Salary { get; set; }
        public decimal? Old_Salary { get; set; }
        public decimal? Gross_Rate { get; set; }
        public DateTime? Salary_Update_Date { get; set; }

      public string FristName {set;get;}
      public string LastName { set; get; }                               

        public DateTime? EMP_DOB { get; set; }
        public string EMP_FATHERS_NAME { get; set; }
        public string EMP_MOTHERS_NAME { get; set; }
        public string EMP_RELIGION { get; set; }
        public string EID { get; set; }
        public string EMP_BLOOD_GRP { get; set; }
        public string EMP_MARITUAL_STATUS { get; set; }
        public string EMP_NATIONALITY { get; set; }
        public DateTime? DATE_JOINED { get; set; }
        public string EMP_PER_ADDRESS { get; set; }
        public string EMP_PRE_ADDRESS { get; set; }
        public string EMP_CONTACT_NO { get; set; }
        public string EMP_EMAIL { get; set; }
        public string EMP_ALT_EMAIL { get; set; }

        public string EMP_EMG_CONTACT_NO { get; set; }
        public string EMP_NOMINEE_NAME { get; set; }
        public string EMP_NOMINEE_RELATION { get; set; }
        public string EMP_NOMINEE_AGE { get; set; }
        public string ReportingBossName { get; set; }
        public string RptBossDSG { get; set; }

        public string Reg_Name { get; set; }
        public int Reg_ID { get; set; }

        public int RegionsId { get; set; }

        public string Off_Name { get; set; }
        public int Off_ID { get; set; }
        public int OfficeId { get; set; }

        public string DPT_NAME { get; set; }
        public int DPT_ID { get; set; }
        public int DepartmentId { get; set; }

        public string SEC_NAME { get; set; }
        public int SEC_ID { get; set; }

        public string SUB_SEC_NAME { get; set; }
        public int SUB_SEC_ID { get; set; }

        public string DEG_NAME { get; set; }
        public int DEG_ID { get; set; }
        public int DesginationId { get; set; }

        public string GRADE { get; set; }
        public int GRADE_ID { get; set; }

        public int Step { set; get; }
        public string Shift { set; get; }

        public string JobResponsibility { set; get; }
    }



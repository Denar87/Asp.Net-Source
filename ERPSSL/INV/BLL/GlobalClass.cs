using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPSSL.INV.BLL
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

    }

    public class Company_Config
    {
        public static string COMPANY_NAME = "Fantasia";
        public static string COMPANY_ADDRESS = "Dhaka,Bangladesh";
    }

    public class HRM_EMPLOYEES_VIEWER
    {
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
        public string EMP_FIRSTNAME { get; set; }
        public string EMP_LASTNAME { get; set; }
        public string EMP_CONTACT_NO { get; set; }

        public string EMP_EMAIL { get; set; }
        public DateTime DATE_JOINED { get; set; }

        public string CONTRACT { get; set; }
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
    public class HRM_EMP_ID_VIEW
    {
        public byte[] AVATER { get; set; }
        public string SEX { get; set; }
        public string DPT_NAME { get; set; }
        public string SEC_NAME { get; set; }
        public string SUB_SEC_NAME { get; set; }
        public string DEG_NAME { get; set; }
        public string GRADE { get; set; }
        public string EMP_FULLNAME { get; set; }
        public DateTime EMP_DOB { get; set; }
        public string EMP_CONTACT_NO { get; set; }
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
}

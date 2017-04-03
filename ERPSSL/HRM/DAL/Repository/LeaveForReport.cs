using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPSSL.HRM.DAL.Repository
{
    public class LeaveForReport
    {
        public Int32 LeaveId { set; get; }
        public string LeaveCode { set; get; }
        public string DisApproveStatus { set; get; }
        public DateTime LeaveAppliedDate { set; get; }
        public DateTime LeaveDates { set; get; }
        public int LeaveTypeId { set; get; }
        public string LeaveType { set; get; }
        public int TotalDay { set; get; }
        public string LeaveResion { set; get; }
        public string LeaveStatus { set; get; }
        public string LeaveStatusHRM { set; get; }
        public string FullName { set; get; }
        public string EID { set; get; }
        public DateTime FormDate { set; get; }
        public DateTime ToDate { set; get; }
        public string Name { get; set; }
        public int TotalLeave { get; set; }




        public string CompanyName { set; get; }
        public string CompanyAddress { set; get; }
        public string CompanyMobile { set; get; }
        public string CompanyWeb { set; get; }
        public string CompanyMail { set; get; }

        public string DesignationName { get; set; }
        public string RegionName { set; get; }
        public string OfficeName { set; get; }
        public string DepartmentName { set; get; }

        public int balanceAL { set; get; }
        public int balanceSL { set; get; }
        public int balanceLWP { set; get; }
        public int balanceML { set; get; }
        public int balanceCL { set; get; }

        public int ALTotalDay { set; get; }
        public int SLTotalDay { set; get; }
        public int LWPTotalDay { set; get; }
        public int MLTotalDay { set; get; }
        public int CLTotalDay { set; get; }

        public int CL { set; get; }
        public int SL { set; get; }
        public int AL { set; get; }
        public int ML { set; get; }
        public int LWP { set; get; }
        public byte[] Logo { set; get; }

        public int LEV_TAKEN { set; get; }
        public string LEV_TYPE { set; get; }
        public int LEV_DAYS { set; get; }
        public int LEV_BAL { set; get; }


        public int clAll { set; get; }
        public int slAll { set; get; }
        public int alAll { set; get; }
        public int mlAll { set; get; }
        public int lwpAll { set; get; }
        public DateTime DateFrom { set; get; }
        public DateTime DateTo { set; get; }
        public DateTime JoiningDate { get; set; }
        public int Total_Enjoy { set; get; }
        public int Total_Available_leave { set; get; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPSSL.HRM.DAL.Repository
{
    public class EmployementInfo
    {
        public string EID { set; get; }
        public string RegionName { set; get; }
        public string OfficeName { set; get; }
        public string DepartmentName { set; get; }
        public string SectionName { set; get; }
        public string ShiftCode { set; get; }
        public string Category { set; get; }
        //public int? Step { set; get; }
        public string GradeName { set; get; }
        public string TimeShifting { set; get; }
        public string ReportinBoss { set; get; }
        public string Desgination { set; get; }
        public string SubSectionName { set; get; }
        public string JobResponsibility { set; get; }
        public DateTime? JoiningDate { set; get; }
        //public Int32? EmployeeTypeId { set; get; }
        public string EmployeeTypeName { set; get; }
        public string Grade { set; get; }
        public bool OTApplicable { set; get; }
        public bool Absence_Applicable { set; get; }
        public bool PF_Applicable { set; get; }
        public bool Tax_Applicable { set; get; }
        public bool Late_Applicable { set; get; }
        public bool Attendance_Bouns { set; get; }
        public DateTime? ProbationPeriodFrom { set; get; }
        public DateTime? ProbationPeriodTo { set; get; }
        public DateTime? ConfiramtionDate { set; get; }
        public decimal? Salary { set; get;}
        public decimal? EffectiveSlary { set; get; }
    }
}
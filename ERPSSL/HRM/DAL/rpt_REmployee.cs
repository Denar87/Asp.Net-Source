using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPSSL.HRM.DAL
{
    public class rpt_REmployee
    {
        public Int64 EmpId { set; get; }
        public string EID { set; get; }
        public string FirstName { set; get; }
        public string LastName { set; get; }
        public string Gender { set; get; }
        public string BloodGroup { set; get; }
        public string FatherName { set; get; }
        public string MotherName { set; get; }
        public string ContactNumber { set; get; }
        public string Email { set; get; }
        public string NomineeName { set; get; }
        public string ResionName { set; get; }
        public string OfficeName { set; get; }
        public string DepartmentName { set; get; }
        public string EMP_TERMIN_STATUS { set; get; }
    }
}
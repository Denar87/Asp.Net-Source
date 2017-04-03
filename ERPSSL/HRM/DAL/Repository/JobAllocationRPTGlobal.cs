using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPSSL.HRM.DAL.Repository
{
    public class JobAllocationRPTGlobal
    {           
       
        public Int64 JobAllocationId { set; get; }
        public int ClientID { set; get; }
        public string Client_Name { set; get; }
        public string ClientLocation { set; get; }
        public string DepartmentName { set; get; }
        public string ResionName { set; get; }
        public string OfficeName { set; get; }
        public string JobAllocationCode { set; get; }
        public string CompanyName { set; get; }
        public string CompanyAddress { set; get; }
        public string CompanyMobile { set; get; }
        public string Region { set; get; }
        public string Remark { set; get; }
        public string RequestFrom { set; get; }
        public string JobAllocatonDate { set; get; }
        public string returnDate { set; get; }
        //public string StartDate { set; get; }
        //public string EndDate { set; get; }
        public string EID { set; get; }
        public string FirstName { set; get; }
        
        //public string fromDate {set; get;}
        //public string toDate { set; get; }
        //public string BloodGroup { set; get; }
        //public string FatherName { set; get; }
       // public string MotherName { set; get; }
        public string ContactNumber { set; get; }
        public string Email { set; get; }
        //public string NomineeName { set; get; }
        
        //public decimal? Salary { set; get; }        
        //public string NumberOfChildren { set; get; }
       // public string ChildrenNameRemark { set; get; }
        //public string EmergencyContactNo { set; get; }
        //public string PresentAddress { set; get; }
        //public string PermanenAddress { set; get; }
          public string EMP_TERMIN_STATUS { set; get; }
        //public DateTime DateOfBrith { set; get; }
        //public string MaritalStatus { set; get; }
        //public string Religion { set; get; }
        //public string NationalID { set; get; }
        //public string Nationality { set; get; }
        //public string EmergencyContactPerson { set; get; }
        //public string EmergencyAddress { set; get; }

    }
}
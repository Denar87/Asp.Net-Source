using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPSSL.HMS.DAL.Repository
{
    public class PatientInfoR
    {

        public int PatientID { get; set; }
        public string PatientName { get; set; }
        public string CategoryName { get; set; }
        public Decimal? Amount { get; set; }
        public string Age { get; set; }
        public string M_Y_D { get; set; }
        public string Gender { get; set; }
        public string BloodGroup { get; set; }
        public string Mobile { get; set; }
        public string Bill_Head_Name { get; set; }
        public string GuardianName { get; set; }
        public string Address { get; set; }
        public string MaritalStatus { get; set; }
        public string Bed_CabinNo { get; set; }
        public DateTime VisitDate { get; set; }       
        public string RefdBy { get; set; }
        public string GuardianContactNo { get; set; }


        public int TransactionId { get; set; }
        public Decimal? CollectionAmount { get; set; }
        public int Qty { get; set; }
        public Decimal? totalbill { get; set; }       
        public string CompanyName { get; set; }
        public string CompanyAddress { get; set; }

       
        
    }
}


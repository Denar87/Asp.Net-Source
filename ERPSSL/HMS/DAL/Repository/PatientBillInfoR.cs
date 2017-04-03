using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPSSL.HMS.DAL.Repository
{
    public class PatientBillInfoR
    {
        public int Id { get; set; }

        public int PatientId { get; set; }

        public String CategoryName { get; set; }

        public String Bill_Head_Name { get; set; }

        public Decimal? Amount { get; set; }

        public Decimal? TotalAmount { get; set; }


        //For Report

        public string PatientName { get; set; }
        public string GuardianName { get; set; }
        public string Address { get; set; }
        public string Bed_CabinNo { get; set; }
        public DateTime VisitDate { get; set; }
        public int TransactionId { get; set; }
        public Decimal? CollectionAmount { get; set; }
        public DateTime CollectionDate { get; set; }
        public int Qty { get; set; }
        public Decimal? ServiceCharge_Percent { get; set; }
        public Decimal? Discount_Percent { get; set; }
        public string CompanyName { get; set; }
        public string CompanyAddress { get; set; }
        public Decimal? AdvanceAmount { get; set; }
        public DateTime? DisChargeDate { get; set; }
        public string Duration { get; set; }

        public string fromDate { get; set; }
        public string toDate { get; set; }


    }
}
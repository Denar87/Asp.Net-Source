using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPSSL.Marketing.DAL.Repository
{
    public class MarketingWorkOrder
    {
        public int WoID { get; set; }
        public int MarketingInfoId { set; get; }

        public DateTime WorkOrderDate { set; get; }
        public string CompletionPeriod { set; get; }
        public decimal ProposedAmount { set; get; }
        public decimal SigningAmount { set; get; }
        public decimal RemainingAmount { set; get; }
        

        public string PaymentCondition { get; set; }
        public string AMC_Condition { get; set; }
        public int WarrantyPeriod { get; set; }
        public DateTime AMCDate { get; set; }
        public string DevelopmentDept { get; set; }
        public Boolean HandoverStatus { get; set; }
        public string Remarks { set; get; }


        public DateTime VisitDate { set; get; }
        public string Client { set; get; }
        public string ContactPerson { set; get; }
        public string Designation { set; get; }
        public string ContactNumber { set; get; }
        public string Email { set; get; }
        public string Address { set; get; }
        public int ProjectId { set; get; }
        public string ProjectName { set; get; }
        public string Module { set; get; }
        public int StageId { set; get; }
        public string StageName { set; get; }
        public string FullName { get; set; }
        public Decimal CollectAmount { get; set; }

        public string MarketingPersonId { set; get; }
        public string MarketingPersonName { get; set; }

        // MRK_Transaction
        public int TransactionId { get; set; }
        public DateTime CollectionDate { get; set; }
        public decimal CollectionAmount { get; set; }

        // For Company Information's
        public string CompanyName { get; set; }
        public string CompanyAddress { get; set; }
        public string CompanyWeb { get; set; }
        public string CompanyMail { get; set; }
        public string CompanyMobile { get; set; }


    }
}
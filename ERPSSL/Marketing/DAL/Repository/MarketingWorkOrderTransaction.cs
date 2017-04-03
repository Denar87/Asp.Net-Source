using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPSSL.Marketing.DAL.Repository
{
    public class MarketingWorkOrderTransaction
    {

        public int MarketingInfoId { get; set; }
        public DateTime VisitDate { set; get; }
        public string Client { set; get; }
        public string ContactPerson { set; get; }
        public string Designation { set; get; }
        public string ContactNumber { set; get; }
        public string Email { set; get; }
        public string Address { set; get; }

        //  MRK_Project
        public int ProjectId { set; get; }
        public string ProjectName { set; get; }
        //  MRK_Project

        public string Module { set; get; }

        //  MRK_Stage
        public int StageId { set; get; }
        public string StageName { get; set; }
        //  MRK_Stage

        public string Remarks { set; get; }


        //HRM_PersonalInformations 

        public string MarketingPersonId { get; set; }
        public string MArketingPersonName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }

        // MRK_WorkOrder
        public int WorkOrderId { get; set; }
        public DateTime WorkOrderDate { set; get; }
        public string CompletionPeriod { set; get; }
        public decimal ProposedAmount { set; get; }
        public decimal SingingAmount { set; get; }
        public decimal RemainingAmount { set; get; }

        // MRK_Transaction
        public int TransactionId {get;set;}
        public DateTime CollectionDate {get;set;}
        public decimal CollectionAmount {get;set;}
        public decimal CollectAmount { get; set; }
        public string TRemarks { get; set; }

        // For Company Information's
        public string CompanyName { get; set; }
        public string CompanyAddress { get; set; }
        public string CompanyWeb { get; set; }
        public string CompanyMail { get; set; }
        public string CompanyMobile { get; set; }

    }
}
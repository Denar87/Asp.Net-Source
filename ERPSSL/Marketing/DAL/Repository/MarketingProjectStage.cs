using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPSSL.Marketing.DAL.Repository
{
    public class MarketingProjectStage
    {
        public int MarketingInfoId { get; set; }
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
        public string StageName { get; set; }
        public string Remarks { set; get; }

        public string MarketingPersonId { get; set; }
        public string MArketingPersonName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public int ReferenceId { get; set; }
        public string ReferenceName { get; set; }

        public string FullName { get; set; }

        public string CompanyName {get;set;}
        public string CompanyAddress {get;set;}
        public string CompanyWeb {get;set;}
	    public string CompanyMail {get;set;}
        public string CompanyMobile { get; set; }
     }
}
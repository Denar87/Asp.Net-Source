using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPSSL.HRM.DAL.Repository
{
    public class EmployeeBenefit
    {
          public int BenefitTypeId{get;set;}
          public string Benefittype {get;set;}
          public int ResionId {get;set;}
          public int OfficeId { get; set; }
          public int DepartmentId{get; set;}
          public string EID {get; set;} 
          public string FullName {get; set;}
          public string DesignationName { get; set; }
          public decimal? Amount{get; set;}
          public DateTime EffectiveDate{get; set;}
          public string OfficeName { set; get; }
          public string ResionName { set; get; }
          public string DepartmentName { set; get; }
          public string CompanyName { set; get; }
          public string CompanyAddress { set; get; }
          public string CompanyWeb { set; get; }
          public string CompanyMail { set; get; }
          public string CompanyMobile { set; get; }
          public byte[] Logo { set; get; }
    }
}
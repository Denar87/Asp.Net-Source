using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPSSL.HRM.DAL.Repository
{
    public class Company
    {
        public int SubCompany_Id { set; get; }
        public string CompanyName { set; get; }
        public string SubCompanyName { set; get; }
        public string SubCompanyAddress { set; get; }
        public string SubCompanyCode { set; get; }

    }
}
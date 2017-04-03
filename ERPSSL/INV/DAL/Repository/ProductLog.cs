using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPSSL.INV.DAL.Repository
{
    public class ProductLog
    {
        public string OldProductName { get; set; }
        public string ProductName { get; set; }
        public DateTime EditDate { get; set; }
        public string EditIP { get; set; }
        public string UserFullName { get; set; }
        public string GroupName { get; set; }
        public string CompanyName { get; set; }
        public string CompanyAddress { get; set; }
        public string CompanyMobile { get; set; }
        public byte[] Logo { get; set; }
    }
}
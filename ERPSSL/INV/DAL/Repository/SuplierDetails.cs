using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPSSL.INV.DAL.Repository
{
    public class SuplierDetails
    {
        public string CompanyName { get; set; }
        public string CompanyAddress { get; set; }
        public string CompanyMobile { get; set; }
        public string Ocode { get; set; }
        public byte[] Logo { get; set; }
        public int Id { get; set; }
        public string SupplierName { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
    }
}
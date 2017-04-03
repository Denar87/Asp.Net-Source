using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPSSL.ERP_Accounting.Repository
{
    public class Voucher_Viewer
    {
        public string Voucher_No  { get; set; }
        public DateTime Voucher_Date { get; set; }
        public Decimal Dr { set; get; }
        public Decimal Cr { set; get; }
        public string Narration { get; set; }

        public string Transaction_Code { get; set; }
        public string Nature { get; set; }
        public Decimal Debit { set; get; }
        public Decimal Credit { set; get; }
        public string Ledger_Code { get; set; }
        public string ChequeNo { get; set; }
        public string Particulars { get; set; }
        public bool IsChangable { get; set; }
        public string ModuleName { get; set; }
        public string ModuleType { get; set; }
        public string IdentificationNo { get; set; }

        public string GroupName { get; set; }
        public string ProductName { set; get; }
        public string Brand { set; get; }
        public string StyleSize { get; set; }
        public string Barcode { get; set; }
        public decimal CPU { get; set; }
        public int ReceiveQuantity { get; set; }
        public string UnitName { get; set; }
        public string ChallanNo { get; set; }
        public DateTime ChallanDate { get; set; }
    }
}
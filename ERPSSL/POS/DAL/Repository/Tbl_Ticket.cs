using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPSSL.POS.DAL.Repository
{
    public class Tbl_Ticket
    { 
        public int InvoiceNo { get; set; }
        public string TicketName { get; set; } 
        public decimal Price { get; set; }
        public DateTime TicketDateTime { get; set; }
        public int ItemQuantity { get; set; }
    }
}
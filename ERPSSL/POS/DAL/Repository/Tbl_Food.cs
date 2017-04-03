using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPSSL.POS.DAL.Repository
{
    public class Tbl_Food
    {
        public int Id { get; set; }
        public string InvoiceNo { get; set; }
        public string FoodName { get; set; }
        public decimal Price { get; set; }
        public DateTime TicketDateTime { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPSSL.HMS.DAL.Repository
{
    public class BillHeadR
    {
        public int HMS_Bill_Head_Id { get; set; }
        public string  Bill_Head_Name { get; set; }
        public string CategoryName { get; set; }
        public Decimal? Price { get; set; }
    }
}
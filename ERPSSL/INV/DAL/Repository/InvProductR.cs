using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPSSL.INV.DAL.Repository
{
    public class InvProductR
    {
        public int UnitId { get; set; }

        public string UnitName { get; set; }

        public int ProductId { get; set; }

        public string GroupName { get; set; }
         
        public string ProductName { get; set; }

        public string StyleAndSize { get; set; }

        public string Brand { get; set; }

        public string FloorName { get; set; }

        public double? ReOrderQty { get; set; }

        public decimal? Price { get; set; }

        public string ProductType { get; set; }

        public int ProductTypeId { get; set; }

        public int GroupId { get; set; }

        public string ProdName { get; set; }
    }
}
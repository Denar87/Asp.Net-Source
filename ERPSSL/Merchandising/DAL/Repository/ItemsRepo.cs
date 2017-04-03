using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPSSL.Merchandising.DAL.Repository
{
    public class ItemsRepo
    {
        public int SizeId { get; set; }
        public int OrderNo { get; set; }
        public int StyleNo { get; set; }
        public int GMTId { get; set; }
        public string GMTItemName { get; set; }
        public string ArticleNo { get; set; }
        public string Color { get; set; }
        public string Size { get; set; }
        public int Quantity { get; set; }
        public decimal Rate { get; set; }
        public decimal TotalAmount { get; set; }

        public int? ColorID { get; set; }
    }
}
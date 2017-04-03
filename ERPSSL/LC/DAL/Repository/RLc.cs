using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPSSL.LC.DAL.Repository
{
    public class RLc
    {
        public int OrderEntryID { get; set; }
        public string OrderSL { get; set; }
        public string OrderNo { get; set; }
        public string OrderQuantity { get; set; }
        public DateTime? ShipmentDate { get; set; }

        public string Style { get; set; }
        public string StyleName { get; set; }
        public string Article { get; set; }
        public string ColorSpecification { get; set; }
        public double? FobQty { get; set; }



       

        //public Int64 Id { set; get; }
        //public Int64 SlNo { set; get; }
        //public string OrderNo { set; get; }
        //public string Qty { set; get; }
        //public string ShipmentDate { set; get; }
      
    }
}
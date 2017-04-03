using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPSSL.Merchandising.DAL.Repository
{
    public class OrderEntryViewRepo
    {
        public int OrderId { get; set; }
        public DateTime OrderReceivedDate { get; set; }
        public string OrderNo { get; set; }
        public int StyleId { get; set; }
        public string Style { get; set; }
        public int SeasonId { get; set; }
        public string Season { get; set; }
        public int BuyerId { get; set; }
        public string Buyer { get; set; }
        public string Country { get; set; }
        public int BuyerDepartmentId { get; set; }
        public string BuyerDepartment { get; set; }
        public int CategoryId { get; set; }
        public string Category { get; set; }
        public string ItemDescription { get; set; }
        public string Quantity { get; set; }
        public int UnitId { get; set; }
        public string Unit { get; set; }
        public string Currency { get; set; }
        public string FOBPort { get; set; }
        public int ShipmentModeId { get; set; }
        public string ShipmentMode { get; set; }
        public DateTime ShipmentDate { get; set; }
        public string MerchendiserId { get; set; }
        public string Merchendiser { get; set; }
        public int OfficeId { get; set; }
        public string Office { get; set; }

    }
}
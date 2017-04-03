using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPSSL.Production.DAL.Repository
{
    public class ProductionR
    {
        public int ID { get; set; }

        public int? StyleId { get; set; }

        public int? BrandId { get; set; }

        public int? DepartmentId { get; set; }

        public int? Buyer_ID { get; set; }

        public int? FactoryId { get; set; }

        public string Intake { get; set; }

        public string Description { get; set; }

        public DateTime? ReceivedFromBuyer { get; set; }

        public DateTime? SendingDateToFactory { get; set; }

        public DateTime? SampleDeadline { get; set; }

        public double? FactoryQty { get; set; }

        public decimal? FactoryPrice { get; set; }

        public double? ReceivedQty { get; set; }

        public DateTime? ReceivedFromFactory { get; set; }

        public DateTime? SendToBuyer { get; set; }

        public double? BuyerQty { get; set; }

        public string Remark { get; set; }

        public string BuyerName { get; set; }
        public string Buyer_Name { get; set; }
        public string DepartmentName { get; set; }
        public string DPT_NAME { get; set; }

        public string StyleName { get; set; }

        public string FactoryName { get; set; }

        public string BrandName { get; set; }

        public string OfficeName { set; get; }
        public string ResionName { set; get; }
        //public string DepartmentName { set; get; }
        public string CompanyName { set; get; }
        public string CompanyAddress { set; get; }
        public string CompanyWeb { set; get; }
        public string CompanyMail { set; get; }
        public string CompanyMobile { set; get; }
        public byte[] Logo { set; get; }

        public string Address { set; get; }
        public string Web { set; get; }
        public string Email { set; get; }
        public string Mobile { set; get; }

        public byte[] Style_Photo { get; set; }
    }
}
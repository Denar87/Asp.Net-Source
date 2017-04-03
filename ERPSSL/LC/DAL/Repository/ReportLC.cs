using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPSSL.LC.DAL.Repository
{
    public class ReportLC
    {

        public string OfficeName { set; get; }
        public string ResionName { set; get; }
        public string DepartmentName { set; get; }
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


        public string Buyer_Name { get; set; }

        public string LCNo { get; set; }
        public string LCType { get; set; }
        public string SubCompanyName { get; set; }

        public DateTime? DateofIssue { get; set; }
        public DateTime? DateofExpiry { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public string BuyerType { get; set; }
        public string Season { get; set; }
        public double? Qty { get; set; }
        public string ItemDescription { get; set; }
        public decimal? USDRate { get; set; }
        public decimal? BDTRate { get; set; }
        public string LC_Issue_Bank { get; set; }
        public string Contact_Person { get; set; }
        //public string Mobile { get; set; }
        public string Phone { get; set; }
        public string Counter { get; set; }
        //public string Address { get; set; }
        public string Type { get; set; }
        public string Consignee { get; set; }
        public string NotifyParty { get; set; }

        public string OrderNo { get; set; }
        public string OrderQuantity { get; set; }

        public string Style { get; set; }
        public string Article { get; set; }
        public string ColorSpecification { get; set; }
        public double? FobQty { get; set; }
        public double? TotalQty { get; set; }
        public DateTime? ShipmentDate { get; set; }
        public double? LC_Total_USDValue { get; set; }

        public string Buyer_Department { get; set; }
        public string Size { get; set; }
        public string Supplier_No { get; set; }
        public DateTime? OrderReceiveDate { get; set; }

        public string StyleName { get; set; }
        public string CAT { get; set; }
        public string HS_Code { get; set; }
        public byte[] Style_Photo { set; get; }
        public string MenLadies { get; set; }
        public string TopBottom { get; set; }
        public string Fabrics { get; set; }
        public string Accessories { get; set; }
        public string CountryOfProduction { get; set; }
        public string Shipment_Mode { get; set; }
        public double? Price { get; set; }
        public double? LC_Amend_USDValue { get; set; }
        public decimal? TotalLC_ValueUSD { get; set; }
        public DateTime? LC_Amend_Date { get; set; }



        public string BuyerDepartment_Name { get; set; }

        public string Destination_Address { get; set; }

        public string Delivery_Address { get; set; }

        public string Country { get; set; }
    }
}
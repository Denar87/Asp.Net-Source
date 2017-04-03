using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPSSL.BuyingHouse.DAL.Repository
{
    public class OrderUpdateRepository
    {
        public string Delivery_Date;
        public int OrderEntryID { get; set; }
        public string Style { get; set; }
        public string Factory_Id { get; set; }

        public string Office_Id { get; set; }
        public string SeasonId { get; set; }
        public string Merchandiser_Dept_Id { get; set; }
        public string Merchandiser_Id { get; set; }
        public string BuyerDepartmetn { get; set; }
        public string Buyer_Id { get; set; }
        public string Category_Id { get; set; }
        public string Style_Description { get; set; }
        public string Trading { get; set; }
        public string Quotation_Terms { get; set; }
        public string Shipment_Mode { get; set; }
        public string PaymentTerms { get; set; }
        public string CountryOf_Production { get; set; }
        public string Garment_Maker { get; set; }
        public string Freight { get; set; }
        public double? FobQty { get; set; }
        public string Currency { get; set; }
        public string OrderQuantity { get; set; }
        public string Unit_Id { get; set; }
        public double? TotalAmount { get; set; }


        public string Season { get; set; }

        public string Article { get; set; }

        public string ColorSpecification { get; set; }

        public string TotalQty { get; set; }

        public string ShipmentDate { get; set; }

        public string Size { get; set; }

        public string Supplier_No { get; set; }

        public string OrderReceiveDate { get; set; }

        public string Buyer_Department { get; set; }
        
        public string LC_Reveived_Date { get; set; }

        public string Schedule_Date { get; set; }

        //public string FOB_Port { get; set; }

        public string Pre_OrderNo { get; set; }

        public string Season_Name { get; set; }

        public string EID { get; set; }

        public string FullName { get; set; }

        public int DepartmentId { get; set; }

        public string DepartmentName { get; set; }

        //public string Total_Amount { get; set; }

        public double? Total_Amount { get; set; }

        public int? Buyer_DepartmentId { get; set; }

        public int? Office_ID { get; set; }

        public int? Merch_Dept_Id { get; set; }

        public int? Principal_Id { get; set; }

        public string Buyer_Name { get; set; }

        public int? FactoryId { get; set; }

        public int? StyleId { get; set; }

        public int? Style_Category_Id { get; set; }

        public decimal? CommissionPersent { get; set; }

        public decimal? TotalCommission { get; set; }

        public string Yarn_Fabrication { get; set; }

        public string FOB_Port { get; set; }

        public int? Season_Id { get; set; }

        public int? Gender_Id { get; set; }

        public int? UnitId { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPSSL.BuyingHouse.DAL.Repository
{
    public class BuyingHouseReport
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
        
        public string BuyerDepartment_Name { get; set; }


        public string OrderNo { get; set; }

        public double? OrderQty { get; set; }

        public string BuyerName { get; set; }

        public string UnitName { get; set; }

        public string Buyer_Name { get; set; }

        public string FactoryEmail { get; set; }
        public string FactoryMobile { set; get; }
        public string FactoryAddress { set; get; }
        public string CP2_Email { set; get; }
        public string CP2_ContactNumber { set; get; }
        public string CP2_Designation { set; get; }
        public string ContactPerson2 { set; get; }
        public string CP1_Designation { set; get; }
        public string CP1_ContactNumber { set; get; }
        public string ContactPerson1 { set; get; }
        public string FactoryWeb { set; get; }
        public string FactoryCountry { set; get; }
        public string Country { set; get; }
        public string FactoryCode { set; get; }
        public string FactoryName { set; get; }
        public string NotifyParty { set; get; }
        public string Consignee { set; get; }
        public string Type { set; get; }
        public string Status { set; get; }
        //public string Address { set; get; }
        public string Destination_Address { set; get; }
        public string Delivery_Address { set; get; }
        public string Counter { set; get; }
        public string Phone { set; get; }
        //public string Mobile { set; get; }
        public string Contact_Person { set; get; }

        public string Responsible_Person { set; get; }
        public string ProductionProcess { set; get; }
        public decimal? TergetQty { set; get; }
        public DateTime? Schedule_Date { set; get; }
        public double? TergetLine { set; get; }
        public double? DailyProduction { set; get; }
        public string Comments { set; get; }
        public string Task { set; get; }

        public decimal? UnitPrice { set; get; }
        
        public string Pre_OrderNo { set; get; }
        public string SampleSpecification { set; get; }
        public string Modi_Status { set; get; }
        public string LCNo { set; get; }

        public string OrderQuantity { set; get; }
        
        public string Style { set; get; }
        public string Size { set; get; }
        public string Article { set; get; }
        public string ColorSpecification { set; get; }
        public double? FobQty { set; get; }
        public double? TotalQty { set; get; }
        public DateTime? ShipmentDate { set; get; }
        public DateTime? ExtendShipmentDate { set; get; }
        public DateTime? CompShipmentDate { set; get; }
        public DateTime? LC_Reveived_Date { set; get; }
        public string ShipmentMode { set; get; }
        public string Season { set; get; }
        public string Buyer_Department { set; get; }
        public string FOB_Port { set; get; }
        public string Yarn_Fabrication { set; get; }
        public string Supplier_No { set; get; }
        public DateTime? OrderReceiveDate { get; set; }


        public DateTime? SampleDate { get; set; }
        public DateTime? First_SampleSentDate { get; set; }
        public DateTime? Modi_ReceiveDate { get; set; }
        public DateTime? Counter_SampleSend_Date { get; set; }
        public DateTime? SizeSet_Date { get; set; }
        public DateTime? Costing_SendDate { get; set; }
        public DateTime? Production_ApprovedDate { get; set; }
        public DateTime? BV_TestSubmitDate { get; set; }


        public DateTime? BV_TestReleaseDate { get; set; }
        public DateTime? SealingSample_SubmitDate { get; set; }
        public DateTime? SealingSample_RelaseDate { get; set; }
        public DateTime? ShipmentSample_SendDate { get; set; }
        public DateTime? ShipmentSample_ApprovedDate { get; set; }

        public string  Order_No { get; set; }
        //public DateTime? Schedule_Date { get; set; }
        public DateTime? InputDate { get; set; }
        public double? DayInput { get; set; }
        public double? AchievementPercentage { get; set; }
        //public double? TergetLine { get; set; }

        public double? TodayProgress{ get; set; }
        //public double? DailyProduction { get; set; }
        //public string Comments { get; set; }

        public int StyleId { get; set; }

        public string Countryof_Production { get; set; }

        public DateTime? Delivery_Date { get; set; }

        public int Buyer_ID { get; set; }

        public string Style_Description { get; set; }

        public string Payment_Terms { get; set; }
        public int? Totalshipment { get; set; }
        public int? Ongoing { get; set; }
        public int? OrderNo1 { get; set; }
        public double? TotalAmount { get; set; }
        public string Merchandiser_Name { get; set; }
        public string PrincipalName { get; set; }
        public decimal? CommissionPersent { get; set; }
        public decimal? TotalCommission { get; set; }
        public int FactoryId { get; set; }

        public int OrderEntryID { get; set; }

        public double? Total_Amount { get; set; }

        public string SeasonName { get; set; }

        public string Shipment_Mode { get; set; }

        public string Gender { get; set; }

        public string Style_Category { get; set; }

        public string FullName { get; set; }

        public int UnitId { get; set; }

        public int Season_Id { get; set; }

        public int Gender_Id { get; set; }

        public int Style_Category_Id { get; set; }

        public string EID { get; set; }

        public int BuyerDepartment_Id { get; set; }
    }
}
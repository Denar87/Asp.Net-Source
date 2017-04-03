using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPSSL.Merchandising.DAL.Repository
{
    public class OrderViewReportRepo
    {
          public int OrderEntryID {get;set;}
	      public string OrderNo {get;set;}
	      public string OrderQuantity {get;set;}
	      public DateTime ShipmentDate {get;set;}
	      public int SeasonId {get;set;}
	      public string Season_Name {get;set;}
	      public int Buyer_DepartmentId {get;set;}
	      public string BuyerDepartment_Name {get;set;}
	      public DateTime OrderReceiveDate {get;set;}
	      public int StyleId {get;set;}
	      public string StyleName {get;set;}
	      public string FOB_Port {get;set;}
	      public string Shipment_Mode {get;set;}
	      public string Style_Description {get;set;}
	      public string Countryof_Production {get;set;}
	      public int Style_Category_Id {get;set;}
	      public string Style_Category_Name {get;set;}
	      public string Currency {get;set;}
	      public int Unit_Id {get;set;}
	      public string UnitName {get;set;}
	      public int Office_ID {get;set;}
	      public string OfficeName {get;set;}
	      public int Buyer_ID {get;set;}
	      public string Buyer_Name {get;set;}
	      public string EID {get;set;}
	      public string FirstName {get;set;}

	      public int Size_Id {get;set;}
	      public int GMTItem {get;set;}
	      public string Gmt_Name {get;set;}
	      public string Articale {get;set;}
	      public int ColorID {get;set;}
	      public string ColorName {get;set;}
	      public string Size {get;set;}
	      public int Qty {get;set;}
	      public decimal Price {get;set;}
          public decimal TotalAmount { get; set; }

    }
}
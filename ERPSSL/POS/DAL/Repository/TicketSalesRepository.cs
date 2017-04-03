using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPSSL.POS.DAL.Repository
{
    public class TicketSalesRepository
    {
        public int Id { get; set; }
        public string InvoiceNo { get; set; }
        public string TicketName { get; set; }
        public string UserFullName { get; set; }
        public decimal Price { get; set; }
        public DateTime TicketDateTime { get; set; }
        public DateTime SaleDate { get; set; }
        public int ItemQuantity { get; set; }
        public string FoodName { get; set; }
        public decimal? Total { get; set; }
        public string startdate { set; get; }
        public string enddate { get; set; }
        public int Quantity { get; set; }
        public string ItemName { get; set; }
        public decimal ItemPrice { get; set; }
        public decimal TotalPrice { get; set; }
        public decimal? ItemTotal { get; set; }
        public string Catagory { get; set; }
        public string CompanyName { set; get; }
        public string CompanyAddress { set; get; }
        public string CompanyMobile { set; get; }
        public string CompanyWeb { set; get; }
        public string CompanyMail { set; get; }
        public byte[] Logo { set; get; } 
    }

    public class FoodSalesRepository
    {
        public int Id { get; set; }
        public string InvoiceNo { get; set; }
        public string TicketName { get; set; }
        public string UserFullName { get; set; }
        public decimal Price { get; set; }
        public DateTime TicketDateTime { get; set; }
        public DateTime SaleDate { get; set; }
        public int ItemQuantity { get; set; }
        public string FoodName { get; set; }
        public decimal? Total { get; set; }
        public string startdate { set; get; }
        public string enddate { get; set; }
        public int Quantity { get; set; }
        public string ItemName { get; set; }
        public decimal ItemPrice { get; set; }
        public decimal TotalPrice { get; set; }
        public decimal? ItemTotal { get; set; }
        public string Catagory { get; set; }
        public string CompanyName { set; get; }
        public string CompanyAddress { set; get; }
        public string CompanyMobile { set; get; }
        public string CompanyWeb { set; get; }
        public string CompanyMail { set; get; }
        public byte[] Logo { set; get; } 
    }
}
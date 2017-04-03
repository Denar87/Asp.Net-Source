using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using ERPSSL.Procurement.DAL;
using System.Collections;
using System.Net.Mail;
using System.Net;
using System.Configuration;
using ERPSSL.INV.BLL;
using ERPSSL.INV.DAL;

namespace ERPSSL.Procurement.BLL
{
    public class PurchaseOrderBll
    {
        PurchaseOrderDAL aPurchaseOrderDAL = new PurchaseOrderDAL();
        DataAccess ado = new DataAccess();
        string conn = ConfigurationManager.ConnectionStrings["ERPSSLADO"].ConnectionString;

        internal List<PRQ_PurchaseOrders> GetAllPurchaseOrder(string PurchaseType)
        {
            return aPurchaseOrderDAL.GetAllPurchaseOrder(PurchaseType);
        }

        internal List<PRQ_PurchaseOrders> GetAllPurchaseOrderByPONo(string PONo)
        {
            return aPurchaseOrderDAL.GetAllPurchaseOrderByPONo(PONo);
        }

        internal DataTable GetWorkOrders(string PurchaseType)
        {
            DataTable dt = new DataTable();
            Hashtable ht = new Hashtable();
            try
            {
                ht.Add("PurchaseType", PurchaseType);
                //ht.Add("PrOrderNo", PONo);
                dt = ado.GetDataByProc(ht, "PRQ_GetWorkOrdersToRcvProduct", conn);
            }
            catch
            {
            }
            return dt;
        }

        internal static DataTable GetRequisitionProducts(string Type, string AssetType)
        {
            DataTable dt = new DataTable();
            Hashtable ht = new Hashtable();
            // ht.Add("GroupId", ProductGroupId);
            ht.Add("Type", Type);
            ht.Add("AssetType", AssetType);

            try
            {
                dt = DataAccess.GetDataByProc(ht, "PRQ_GetRequisitionProducts");
            }
            catch { }
            return dt;
        }

        internal static DataTable GetRequisitionProducts1(string Type, string AssetType)
        {
            DataTable dt = new DataTable();
            Hashtable ht = new Hashtable();
            // ht.Add("GroupId", ProductGroupId);
            ht.Add("Type", Type);
            ht.Add("AssetType", AssetType);

            try
            {
                dt = DataAccess.GetDataByProc(ht, "PRQ_GetRequisitionProducts1");
            }
            catch { }
            return dt;
        }

        internal static DataTable GetSingleRequisitionProduct(string ReqAutoId)
        {
            DataTable dt = new DataTable();
            Hashtable ht = new Hashtable();
            ht.Add("ReqAutoId", ReqAutoId);

            try
            {
                dt = DataAccess.GetDataByProc(ht, "");
            }
            catch { }
            return dt;
        }


        internal static string GetNewPurchaseOrderNo(DateTime date)
        {
            string Orderno = date.Year.ToString() + date.Month.ToString() + date.Day.ToString();
            int count = 0;
            try
            {
                count = int.Parse(DataAccess.AggRetrive("select COUNT(Id) from PRQ_PurchaseOrders where OrderDate = '" + date + "'").ToString());
                count++;
            }
            catch { }
            return Orderno + count.ToString();
        }
        //

        internal static DataTable AddNewPurchaseOrder(Hashtable ht)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = DataAccess.GetDataByProc(ht, "PRQ_AddPurchaseOrder");

            }
            catch
            {

            }
            return dt;
        }

        internal static DataTable GetPurchaseOrderList()
        {
            DataTable dt = new DataTable();
            try
            {
                dt = DataAccess.GetDataBySQLString("select distinct [PrOrderNo] from PRQ_PurchaseOrders where IsWorkOrdered = 0 and PurchaseType ='ByQuotation' and IsApproved = 1");

            }
            catch
            {
            }

            return dt;
        }

        internal static string GetBarCode(string PrOrderNo)
        {
            string BarCode = string.Empty;
            try
            {
                BarCode = DataAccess.AggRetrive("select BarCode from PRQ_PurchaseOrders where PrOrderNo = '" + PrOrderNo + "'").ToString();
            }
            catch
            {
            }
            return BarCode;
        }

        internal static void PurchaseDone(string PrOrderNo)
        {
            try
            {
                DataAccess.AggRetrive("update PRQ_PurchaseOrders set IsPurchased = 1 where PrOrderNo = '" + PrOrderNo + "'");
            }
            catch
            {
            }

        }

        internal static void PurchaseDoneByPO(string PrOrderNo)
        {
            try
            {
                DataAccess.AggRetrive("update LC_PurchaseOrder set IsPurchased = 1 where LC_PO_No = '" + PrOrderNo + "'");
            }
            catch
            {
            }
        }

        internal static void UpdatePOLastQty(string id, double ReceiveQty)
        {
            try
            {
                DataAccess.AggRetrive("update LC_PurchaseOrder set LastReceiveQty = '" + ReceiveQty + "' where Id = '" + id + "'");
            }
            catch
            {
            }
        }

        internal static DataTable GetProducts(string PrOrderNo)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = DataAccess.GetDataBySQLString("select O.BarCode, (P.ProductName +' - ' + P.Brand+' - '+ P.StyleAndSize) as ProductName from PRQ_PurchaseOrders O inner join Inv_Product P on P.ProductId = O.BarCode where O.PrOrderNo ='" + PrOrderNo + "'");
            }
            catch { }
            return dt;

        }

        internal static string GetOrderQtyByBarCode(string PrOrderNo, string BarCode)
        {
            string qty = "0";
            try
            {
                qty = DataAccess.AggRetrive("select OrderedQty from PRQ_PurchaseOrders where PrOrderNo ='" + PrOrderNo + "' and BarCode = " + BarCode + "").ToString();
            }
            catch { }
            return qty;

        }

        internal static DataTable GetPurchaseOrderToApproveList()
        {
            DataTable dt = new DataTable();
            try
            {
                dt = DataAccess.GetDataBySQLString("select distinct PrOrderNo, OrderDate from PRQ_PurchaseOrders where IsApproved = 0");
            }
            catch
            {
            }

            return dt;
        }

        internal static DataTable GetPurchaseOrderProducts(string PrOrderNo)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = DataAccess.GetDataBySQLString("select PR.Id, PR.PrOrderNo,P.ProductName,OrderedQty,OrderDate from PRQ_PurchaseOrders PR inner join Inv_Product P on P.ProductId = BarCode where IsApproved = 0 and PrOrderNo = '" + PrOrderNo + "'");
            }
            catch
            {
            }

            return dt;
        }

        internal static bool ApprovePurchaseOrder(List<string> Ids)
        {
            try
            {
                foreach (string Id in Ids)
                {
                    DataAccess.AggRetrive("update PRQ_PurchaseOrders set IsApproved = 1 where Id = '" + Id + "'");
                }
                return true;
            }
            catch
            {
                return false;
            }


        }

        internal static string GetSelectedProduct(string PrOrderNo, string BarCode)
        {
            string qty = "0";
            try
            {
                qty = DataAccess.AggRetrive("select OrderedQty from PRQ_PurchaseOrders where BarCode = '" + BarCode + "' and PrOrderNo = '" + PrOrderNo + "'").ToString();
            }
            catch
            {
            }

            return qty;
        }

        public static bool MailToSupplier(string SupCode, string PrOrderNo, DataTable dt2)
        {

            DataTable dt = new DataTable();
            dt = DataAccess.GetEmailCredetial("WorkOrder");
            SmtpClient smtp = new SmtpClient();
            string EmailFrom = string.Empty;
            foreach (DataRow dr in dt.Rows)
            {
                smtp.Host = dr["Host"].ToString();
                smtp.Port = int.Parse(dr["Port"].ToString());
                smtp.EnableSsl = bool.Parse(dr["EnableSSL"].ToString());
                smtp.UseDefaultCredentials = bool.Parse(dr["UseDefaultCredentials"].ToString());
                smtp.Credentials = new NetworkCredential(dr["FromEmail"].ToString(), dr["Password"].ToString());
                EmailFrom = dr["FromEmail"].ToString();
            }
            string SupEmail = "";
            string subject = "Work Order For " + PrOrderNo + "";
            string body = "Hello Dear,  Greeting from Fantasia!  We are very glad to inform you that we are giving you a work order for the purchase requisition order " + PrOrderNo + " fro the following products:";

            //body += "<table><tr><td>Product</td><td>Qty</td><td>CPU</td><td>CPU</td></tr>";
            foreach (DataRow dr in dt2.Rows)
            {
                //body += "<tr><td>" + dr["ProductName"].ToString() + "</td><td>" + dr["OrderedQty"].ToString() + "</td></tr>";//<td>"++"</td><td>"++"</td></tr>";
                body += dr["ProductName"].ToString() + "(" + dr["OrderedQty"].ToString() + ")";//<td>"++"</td><td>"++"</td></tr>";
            }
            // body += "</table>";

            try
            {
                SupEmail = DataAccess.AggRetrive("select top(1) EmailAddress from Inv_Supplier where SupplierCode = '" + SupCode + "'").ToString();

            }
            catch { }

            MailMessage mail = new MailMessage(EmailFrom, SupEmail, subject, body);
            try
            {
                smtp.Send(mail);
                return true;
            }
            catch (SmtpException ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }

        }

        //public static bool MailToSupplier(string SupCode, string PrOrderNo, DataTable dt2, string OCode)
        //{

        //    DataTable dt = new DataTable();
        //    dt = DataAccess.GetEmailCredetial("WorkOrder");
        //    SmtpClient smtp = new SmtpClient();
        //    string EmailFrom = string.Empty;
        //    foreach (DataRow dr in dt.Rows)
        //    {
        //        smtp.Host = dr["Host"].ToString();
        //        smtp.Port = int.Parse(dr["Port"].ToString());
        //        smtp.EnableSsl = bool.Parse(dr["EnableSSL"].ToString());
        //        smtp.UseDefaultCredentials = bool.Parse(dr["UseDefaultCredentials"].ToString());
        //        smtp.Credentials = new NetworkCredential(dr["FromEmail"].ToString(), dr["Password"].ToString());
        //        EmailFrom = dr["FromEmail"].ToString();
        //    }

        //    DataTable dtCompany = CompanyBLL.GetCompanyInformationByOCode(OCode);
        //    string ClientName = "";
        //    foreach (DataRow dr in dtCompany.Rows)
        //    {
        //        ClientName = dr["CompanyName"].ToString();
        //    }

        //    string SupEmail = "";
        //    string Type = "Work Order";
        //    string subject = "Work Order For " + PrOrderNo + "";
        //    string Message = "Dear Concern,  Greeting from " + ClientName + "!  We are very glad to inform you that we are giving you a work order for the purchase requisition order " + PrOrderNo + " fro the following products:";

        //    string body = "<div><div style='width: 100%; text-align: center; color: #FFFFFF; font-size: xx-large; background-color: #FF0000'> " +
        //                    ClientName + "<div style='font-size: medium;'>" +
        //                    Type + "</div></div><div>" +
        //                    Message;


        //    body += "<table style='width: 100%'><tr><td>Product</td><td>Qty</td><td>CPU</td></tr>";
        //    foreach (DataRow dr in dt2.Rows)
        //    {
        //        body += "<tr><td>" + dr["ProductName"].ToString() + "</td><td>" + dr["OrderedQty"].ToString() + "</td><td>" + "As Per Quotation" + "</td></tr>";
        //        //body += dr["ProductName"].ToString() + "(" + dr["OrderedQty"].ToString() + ")";//<td>"++"</td><td>"++"</td></tr>";
        //    }
        //    body += "</table>";

        //    try
        //    {
        //        SupEmail = DataAccess.AggRetrive("select top(1) EmailAddress from Inv_Supplier where SupplierCode = '" + SupCode + "'").ToString();

        //    }
        //    catch { }
        //    MailMessage mail = new MailMessage(EmailFrom, SupEmail, subject, body);
        //    mail.IsBodyHtml = true;
        //    try
        //    {
        //        smtp.Send(mail);
        //        return true;
        //    }
        //    catch (SmtpException ex)
        //    {
        //        Console.WriteLine(ex.ToString());
        //        return false;
        //    }

        //}

        public static bool MailToAllEnlistedSupplier(List<string> Ids)
        {
            DataTable dt2 = new DataTable();
            dt2.Clear();
            dt2.Columns.Add("ProductName");
            dt2.Columns.Add("OrderedQty");
            //
            DataTable dt3 = dt2.Clone();
            string PrOrderNo = "";
            string DemoId = "";

            foreach (string Id in Ids)
            {
                DemoId = Id;
                DataTable dt4 = DataAccess.GetDataBySQLString("select P.ProductName, PR.OrderedQty from PRQ_PurchaseOrders PR inner join Inv_Product P on P.ProductId = PR.BarCode where PR.Id = '" + Id + "'");
                foreach (DataRow dr in dt4.Rows)
                {
                    DataRow row = dt2.NewRow();
                    row["ProductName"] = dr["ProductName"].ToString();
                    row["OrderedQty"] = dr["OrderedQty"].ToString();
                    dt2.Rows.Add(row);
                }
            }

            PrOrderNo = DataAccess.AggRetrive("select PrOrderNo from PRQ_PurchaseOrders where Id = " + DemoId + "").ToString();

            DataTable dt = new DataTable();
            dt = DataAccess.GetEmailCredetial("WorkOrder");
            SmtpClient smtp = new SmtpClient();
            string EmailFrom = string.Empty;
            foreach (DataRow dr in dt.Rows)
            {
                smtp.Host = dr["Host"].ToString();
                smtp.Port = int.Parse(dr["Port"].ToString());
                smtp.EnableSsl = bool.Parse(dr["EnableSSL"].ToString());
                smtp.UseDefaultCredentials = bool.Parse(dr["UseDefaultCredentials"].ToString());
                smtp.Credentials = new NetworkCredential(dr["FromEmail"].ToString(), dr["Password"].ToString());
                EmailFrom = dr["FromEmail"].ToString();
            }
            //string SupEmail = "";
            string subject = "Tender For " + PrOrderNo + "";
            string body = "Hello Dear,  Greeting from Fantasia! We are very glad to inform you that we have a purchase requisition order " + PrOrderNo + " fro the following products:";

            // body += "<table><tr><td>Product</td><td>Qty</td><td>CPU</td><td>CPU</td></tr>";
            foreach (DataRow dr in dt2.Rows)
            {
                //body += "<tr><td>" + dr["ProductName"].ToString() + "</td><td>"+dr["OrderedQty"].ToString()+"</td></tr>";//<td>"++"</td><td>"++"</td></tr>";
                body += dr["ProductName"].ToString() + "(" + dr["OrderedQty"].ToString() + ")";//<td>"++"</td><td>"++"</td></tr>";
            }
            //body += "</table>";

            DataTable supDt = new DataTable();
            try
            {
                supDt = DataAccess.GetDataBySQLString("select EmailAddress from Inv_Supplier where Enlisted=1");
            }
            catch { }

            foreach (DataRow dr in supDt.Rows)
            {
                MailMessage mail = new MailMessage(EmailFrom, dr["EmailAddress"].ToString(), subject, body);
                try
                {
                    smtp.Send(mail);

                }
                catch (SmtpException ex)
                {
                    Console.WriteLine(ex.ToString());

                }
            }
            return true;

        }

        internal static DataTable GetProductsToReceive(string PurchaseType, string Id)
        {
            DataTable dt = new DataTable();
            Hashtable ht = new Hashtable();
            try
            {
                ht.Add("PurchaseType", PurchaseType);
                ht.Add("Id", Id);
                dt = DataAccess.GetDataByProc(ht, "PRQ_GetProductsToRcvProductById");
            }
            catch { }
            return dt;

        }

        internal static DataTable GetProductInfo(string PrOrderNo, string BarCode)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = DataAccess.GetDataBySQLString("select * from PRQ_PurchaseOrders PR inner join LU_tbl_Product p on P.Id = PR.BarCode where PrOrderNo = '" + PrOrderNo + "' and P.Id = " + BarCode + "");
            }
            catch { }
            return dt;
        }

        internal static DataTable GetSelectedSupplier(string PrOrderNo, string ProductId)
        {
            DataTable Supplier = new DataTable();
            try
            {
                Supplier = DataAccess.GetDataBySQLString("select SupplierCode, CPU,BarCode from PRQ_Quotations where PrOrderNo = '" + PrOrderNo + "' and IsSelected = 1 and BarCode='" + ProductId + "'");
            }
            catch { }
            return Supplier;
        }

        internal static DataTable GetUnGivenProducts(string PrOrderNo)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = DataAccess.GetDataBySQLString("select O.BarCode, (P.ProductName +' - ' + P.Brand+' - '+ P.StyleAndSize) as ProductName from PRQ_PurchaseOrders O inner join Inv_Product P on P.ProductId = O.BarCode where O.PrOrderNo ='" + PrOrderNo + "' and IsWorkOrdered = 0");
            }
            catch { }
            return dt;
        }
    }
}
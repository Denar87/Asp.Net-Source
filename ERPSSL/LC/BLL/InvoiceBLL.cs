using ERPSSL.LC.DAL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using ERPSSL.LC.DAL.Repository;


namespace ERPSSL.LC.BLL
{
    public class InvoiceBLL
    {
        InvoiceDAL invoiceDAL = new InvoiceDAL();
        internal int Insert(LC_Invoice_Create objInvoice)
        {
            return invoiceDAL.Insert(objInvoice);
        }
        internal List<Com_Buyer_Setup> GetBuyer(string ocode)
        {
            return invoiceDAL.GetBuyer(ocode);
        }
        internal List<ReportLC> GetDataBayerWise(string buyer)
        {
            return invoiceDAL.GetDataBayerWise(buyer);
        }
    }
}
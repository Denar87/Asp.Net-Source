using ERPSSL.INV.DAL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using ERPSSL.LC.DAL.Repository;

namespace ERPSSL.LC.DAL
{
    public class InvoiceDAL
    {
        private ERPSSL_LCEntities _Context = new ERPSSL_LCEntities();
        DataAccessEX ado = new DataAccessEX();
        string conn = ConfigurationManager.ConnectionStrings["ERPSSLADO"].ConnectionString;
        internal int Insert(LC_Invoice_Create objInvoice)
        {
            try
            {
                _Context.LC_Invoice_Create.AddObject(objInvoice);
                _Context.SaveChanges();
                return 1;
            }
            catch (Exception)
            {
                throw;
            }
        }
        internal List<Com_Buyer_Setup> GetBuyer(string ocode)
        {
            try
            {
                var result = (from i in _Context.Com_Buyer_Setup
                              where i.OCODE == ocode
                              select i);
                return result.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }
        internal List<ReportLC> GetDataBayerWise(string buyer)
        {
            try
            {
                var result = (from i in _Context.Com_Buyer_Setup
                              join D in _Context.LC_BuyerDepartment on i.BuyingDepartmentId equals D.BuyerDepartment_Id
                              where i.Buyer_Name == buyer
                              select new ReportLC
                              {
                                  Consignee = i.Consignee,
                                  NotifyParty = i.NotifyParty,
                                  Delivery_Address = i.Delivery_Address,
                                  Destination_Address = i.Destination_Address,
                                  Country = i.Country,
                                  BuyerDepartment_Name = D.BuyerDepartment_Name
                              });
                return result.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
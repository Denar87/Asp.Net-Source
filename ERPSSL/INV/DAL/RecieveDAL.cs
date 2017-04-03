using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ERPSSL.INV.DAL;

namespace ERPSSL.INV.DAL
{
    public class RecieveDAL
    {
        private ERPSSL_INVEntities _context = new ERPSSL_INVEntities();


        internal string GetNewChalanId(string supCode, string date)
        {

            int maxid = 0;
            try
            {
                maxid = int.Parse("select COUNT(*) from Inv_RChallan where SupplierId = '" + supCode + "' and PurchaseDate = '" + date + "'");
            }
            catch
            {
            }
            return (maxid + 1).ToString();
        }

        //internal int InsertSupplier(Inv_Supplier supplierObj)
        //{
        //    try
        //    {
        //        _context.Inv_Supplier.AddObject(supplierObj);
        //        _context.SaveChanges();
        //        return 1;

        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}

        //internal List<Inv_Supplier> GetSupplier(string OCODE)
        //{
        //    try
        //    {

        //        var suppliers = (from supl in _context.Inv_Supplier
        //                         where supl.OCode == OCODE
        //                         select supl).OrderBy(x=>x.SupplierName);


        //        return suppliers.ToList();

        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}

        //internal List<Inv_Supplier> GetSupplierInfoByIdandOcode(string supplierId, string OCODE)
        //{
        //    try
        //    {
        //        int supId = Convert.ToInt16(supplierId);

        //        var suppliers = (from supplier in _context.Inv_Supplier
        //                         where supplier.Id == supId && supplier.OCode == OCODE
        //                         select supplier);


        //        return suppliers.ToList();

        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }

        //}

        //internal int UpdateSupplier(int supplierId, Inv_Supplier supplierObj)
        //{
        //    try
        //    {
        //        Inv_Supplier supObj = _context.Inv_Supplier.First(x => x.Id == supplierId);
        //        supObj.SupplierName = supplierObj.SupplierName;
        //        supObj.SupplierCode = supplierObj.SupplierCode;
        //        supObj.Phone = supplierObj.Phone;
        //        supObj.EmailAddress = supplierObj.EmailAddress;
        //        supObj.ContactPerson = supplierObj.ContactPerson;
        //        supObj.Address = supplierObj.Address;
        //        supObj.CreditDays = supplierObj.CreditDays;
        //        supObj.Enlisted = supplierObj.Enlisted;
        //        supObj.Fired = supplierObj.Fired;
        //        supObj.Performance = supplierObj.Performance;
        //        _context.SaveChanges();
        //        return 1;

        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }

        //    //using (ERPSSL_INVEntities ctx = new ERPSSL_INVEntities())
        //    //{
        //    //    try
        //    //    {
        //    //        ctx.Set<T>().Attach(obj);
        //    //        ctx.Entry(obj).State = System.Data.Entity.EntityState.Modified;
        //    //        ctx.SaveChanges();
        //    //        return 1;
        //    //    }
        //    //    catch (Exception ex)
        //    //    {

        //    //        throw ex;
        //    //    }
        //    //}       
        //}
    }
}
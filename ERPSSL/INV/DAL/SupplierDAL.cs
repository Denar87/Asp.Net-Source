using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ERPSSL.INV.DAL;
using MoreLinq;
using System.Configuration;

namespace ERPSSL.INV.DAL
{
    public class SupplierDAL
    {
        private ERPSSL_INVEntities _context = new ERPSSL_INVEntities();

        internal int InsertSupplier(Inv_Supplier supplierObj)
        {
            try
            {
                _context.Inv_Supplier.AddObject(supplierObj);
                _context.SaveChanges();
                return 1;

            }
            catch (Exception)
            {

                throw;
            }
        }
        internal int SaveItemInfo(Inv_Sup_ItemInfo supplierObj)
        {
            try
            {
                _context.Inv_Sup_ItemInfo.AddObject(supplierObj);
                _context.SaveChanges();
                return 1;

            }
            catch (Exception)
            {

                throw;
            }
        }
        internal int InsertSupplierDocuments(Inv_Supplier_Documents supplierObj)
        {
            try
            {
                _context.Inv_Supplier_Documents.AddObject(supplierObj);
                _context.SaveChanges();
                return 1;
            }
            catch (Exception)
            {
                throw;
            }
        }

        internal List<Inv_Supplier> GetAllSupplier()
        {
            try
            {
                var suppliers = (from supl in _context.Inv_Supplier

                                 select supl).OrderBy(x => x.SupplierName);
                return suppliers.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        internal List<Inv_Supplier> GetSupplier(string OCODE)
        {
            try
            {
                var suppliers = (from supl in _context.Inv_Supplier
                                 where supl.OCode == OCODE && supl.Enlisted == false
                                 select supl).OrderBy(x => x.SupplierName);
                return suppliers.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        internal List<Inv_Supplier> GetSupplierInfo(string OCODE, string SupCode)
        {
            try
            {
                var suppliers = (from supl in _context.Inv_Supplier
                                 where supl.OCode == OCODE && supl.SupplierCode == SupCode
                                 select supl).OrderBy(x => x.SupplierName);

                return suppliers.ToList();

            }
            catch (Exception)
            {
                throw;
            }
        }


        internal List<Inv_Supplier> GetBusinessInfromation(string Subcode)
        {
            try
            {

                var suppliers = (from supl in _context.Inv_Supplier
                                 where supl.SupplierCode == Subcode
                                 select supl);


                return suppliers.ToList();

            }
            catch (Exception)
            {

                throw;
            }
        }
        internal List<Inv_Sup_ItemInfo> Getiems(string Subcode)
        {
            try
            {

                var suppliers = (from supl in _context.Inv_Sup_ItemInfo
                                 where supl.SupplierCode == Subcode
                                 select supl);


                return suppliers.ToList();

            }
            catch (Exception)
            {

                throw;
            }
        }

        internal List<Inv_Supplier> GetContactPerson(string Subcode)
        {
            try
            {

                var suppliers = (from supl in _context.Inv_Supplier
                                 where supl.SupplierCode == Subcode
                                 select supl);


                return suppliers.ToList();

            }
            catch (Exception)
            {

                throw;
            }
        }


        internal List<Inv_Supplier> GetSupplierInfoByIdandOcode(string supplierId, string OCODE)
        {
            try
            {
                int supId = Convert.ToInt16(supplierId);

                var suppliers = (from supplier in _context.Inv_Supplier
                                 where supplier.Id == supId && supplier.OCode == OCODE
                                 select supplier);


                return suppliers.ToList();

            }
            catch (Exception)
            {

                throw;
            }

        }
        internal List<Inv_Supplier> GetBusinessInfobyid(string supplierId, string OCODE)
        {
            try
            {
                int supId = Convert.ToInt16(supplierId);

                var suppliers = (from supplier in _context.Inv_Supplier
                                 where supplier.Id == supId && supplier.OCode == OCODE
                                 select supplier);


                return suppliers.ToList();

            }
            catch (Exception)
            {

                throw;
            }

        }

        internal List<Inv_Sup_ItemInfo> GetItemforEdit(string supplierId)
        {
            try
            {
                int supId = Convert.ToInt16(supplierId);

                var suppliers = (from supplier in _context.Inv_Sup_ItemInfo
                                 where supplier.Id == supId
                                 select supplier);


                return suppliers.ToList();

            }
            catch (Exception)
            {

                throw;
            }

        }

        internal int UpdateSupplier(int supplierId, Inv_Supplier supplierObj)
        {
            try
            {
                Inv_Supplier supObj = _context.Inv_Supplier.First(x => x.Id == supplierId);
                supObj.SupplierName = supplierObj.SupplierName;
                supObj.SupplierCode = supplierObj.SupplierCode;
                supObj.Phone = supplierObj.Phone;
                supObj.EmailAddress = supplierObj.EmailAddress;
                supObj.ContactPerson = supplierObj.ContactPerson;
                supObj.Address = supplierObj.Address;
                supObj.DistrictId = supplierObj.DistrictId;
                supObj.CreditDays = supplierObj.CreditDays;
                supObj.Enlisted = supplierObj.Enlisted;
                supObj.Fired = supplierObj.Fired;
                supObj.Performance = supplierObj.Performance;
                _context.SaveChanges();
                return 1;

            }
            catch (Exception)
            {

                throw;
            }
        }

        internal int UpdateBusinessInformation(Inv_Supplier supplierObj, string supplierId)
        {
            try
            {
                Inv_Supplier supObj = _context.Inv_Supplier.First(x => x.SupplierCode == supplierId);
                supObj.Trade_License_No = supplierObj.Trade_License_No;
                supObj.Certificate_Incorp = supplierObj.Certificate_Incorp;
                supObj.Tin_No = supplierObj.Tin_No;
                supObj.Vat = supplierObj.Vat;
                supObj.Validity = supplierObj.Validity;
                supObj.Incorp_Date = supplierObj.Incorp_Date;
                supObj.Business_Capital = supplierObj.Business_Capital;
                supObj.Bank_Name = supplierObj.Bank_Name;
                _context.SaveChanges();
                return 1;
            }
            catch (Exception)
            {

                throw;
            }
        }
        internal int UpdateBusinessInF(Inv_Supplier supplierObj, int supplierId)
        {
            try
            {
                Inv_Supplier supObj = _context.Inv_Supplier.First(x => x.Id == supplierId);
                supObj.Trade_License_No = supplierObj.Trade_License_No;
                supObj.Certificate_Incorp = supplierObj.Certificate_Incorp;
                supObj.Tin_No = supplierObj.Tin_No;
                supObj.Vat = supplierObj.Vat;
                supObj.Validity = supplierObj.Validity;
                supObj.Incorp_Date = supplierObj.Incorp_Date;
                supObj.Business_Capital = supplierObj.Business_Capital;
                supObj.Bank_Name = supplierObj.Bank_Name;
                _context.SaveChanges();
                return 1;
            }
            catch (Exception)
            {

                throw;
            }


        }
        internal int UpdateContactpersoninformation(Inv_Supplier supplierObj, string SupCode)
        {
            try
            {
                Inv_Supplier supObj = _context.Inv_Supplier.First(x => x.SupplierCode == SupCode);
                supObj.ContactPerson = supplierObj.ContactPerson;
                supObj.ContactPerson_Designation = supplierObj.ContactPerson_Designation;
                supObj.ContactPerson_Email = supplierObj.ContactPerson_Email;
                supObj.ContactPerson_Fax = supplierObj.ContactPerson_Fax;
                supObj.ContactPerson_Mobile = supplierObj.ContactPerson_Mobile;
                supObj.ContactPerson_Phone = supplierObj.ContactPerson_Phone;


                _context.SaveChanges();
                return 1;
            }
            catch (Exception)
            {

                throw;
            }
        }
        internal int UpdateContactPer(Inv_Supplier supplierObj, int SupplierId)
        {
            try
            {
                Inv_Supplier supObj = _context.Inv_Supplier.First(x => x.Id == SupplierId);
                supObj.ContactPerson = supplierObj.ContactPerson;
                supObj.ContactPerson_Designation = supplierObj.ContactPerson_Designation;
                supObj.ContactPerson_Email = supplierObj.ContactPerson_Email;
                supObj.ContactPerson_Fax = supplierObj.ContactPerson_Fax;
                supObj.ContactPerson_Mobile = supplierObj.ContactPerson_Mobile;
                supObj.ContactPerson_Phone = supplierObj.ContactPerson_Phone;

                _context.SaveChanges();
                return 1;
            }
            catch (Exception)
            {

                throw;
            }
        }
        internal int UpdateItem(Inv_Sup_ItemInfo supplierObj, int SupplierId)
        {
            try
            {
                Inv_Sup_ItemInfo supObj = _context.Inv_Sup_ItemInfo.First(x => x.Id == SupplierId);
                supObj.GroupId = supplierObj.GroupId;
                supObj.ProductId = supplierObj.ProductId;

                _context.SaveChanges();
                return 1;
            }
            catch (Exception)
            {

                throw;
            }
        }


        internal List<HRM_PersonalInformations> getEmpNamebyEID(string eidS)
        {
            try
            {
                var suppliers = (from e in _context.HRM_PersonalInformations
                                 where e.EID + "-" +e.FirstName + "-" + e.LastName == eidS
                                 select e);
                return suppliers.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        internal List<Inv_Supplier> GetSupplierEnlistedTrue(string OCODE)
        {
            try
            {
                var suppliers = (from supl in _context.Inv_Supplier
                                 where supl.OCode == OCODE && supl.Enlisted == true
                                 select supl).OrderBy(x => x.SupplierName);

                return suppliers.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        internal List<Inv_Supplier> GetSupplierForSearch(string OCODE, string Name)
        {
            try
            {
                var suppliers = (from supl in _context.Inv_Supplier
                                 where supl.OCode == OCODE && supl.Enlisted == true && supl.SupplierName == Name
                                 select supl).OrderBy(x => x.SupplierName);

                return suppliers.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }


        internal List<Inv_Supplier> GetSupplierLocation(string OCODE)
        {
            try
            {
                var suppliers = (from supl in _context.Inv_Supplier
                                 where supl.OCode == OCODE
                                 select supl).DistinctBy(x => x.Location);

                return suppliers.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
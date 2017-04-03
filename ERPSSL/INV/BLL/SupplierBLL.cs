using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ERPSSL.INV.DAL;

namespace ERPSSL.INV.BLL
{
    public class SupplierBLL
    {
        SupplierDAL supplierDal = new SupplierDAL();
        
        internal int InsertSupplier(Inv_Supplier suppplierObj)
        {
            return supplierDal.InsertSupplier(suppplierObj);
        }
        //Shabda.....

        internal int SaveItemInfo(Inv_Sup_ItemInfo suppplierObj)
        {
            return supplierDal.SaveItemInfo(suppplierObj);
        }
        internal int InsertSupplierDocuments(Inv_Supplier_Documents suppplierObj)
        {
            return supplierDal.InsertSupplierDocuments(suppplierObj);
        }
        
            //....
        internal List<Inv_Supplier> GetSupplierEnlistedTrue(string OCODE)
        {
            return supplierDal.GetSupplierEnlistedTrue(OCODE);
        }

        internal List<Inv_Supplier> GetSupplier(string OCODE)
        {
            return supplierDal.GetSupplier(OCODE);
        }

        internal List<Inv_Supplier> GetSupplierInfo(string OCODE, string supCode)
        {
            return supplierDal.GetSupplierInfo(OCODE, supCode);
        }

        internal List<Inv_Supplier> GetBusinessInfromation(string Subcode)
        {
            return supplierDal.GetBusinessInfromation(Subcode);
        }
        internal List<Inv_Sup_ItemInfo> Getiems(string Subcode)
        {
            return supplierDal.Getiems(Subcode);
        }
        

        internal List<Inv_Supplier> GetContactPerson(string Subcode)
        {
            return supplierDal.GetContactPerson(Subcode);
        }
        
        
        internal List<Inv_Supplier> GetAllSupplier()
        {
            return supplierDal.GetAllSupplier();
        }

        internal List<Inv_Supplier> GetSuppierInfoByIdandOcode(string supplierId, string OCODE)
        {
            return supplierDal.GetSupplierInfoByIdandOcode(supplierId, OCODE);
        }
        internal List<Inv_Supplier> GetBusinessInfobyid(string supplierId, string OCODE)
        {
            return supplierDal.GetBusinessInfobyid(supplierId, OCODE);
        }
        internal List<Inv_Sup_ItemInfo> GetItemforEdit(string supplierId)
        {
            return supplierDal.GetItemforEdit(supplierId);
        }
        
        internal int UpdateSupplier(Inv_Supplier supplierObj, int supplierId)
        {
            return supplierDal.UpdateSupplier(supplierId, supplierObj);
        }

        internal int UpdateBusinessInformation(Inv_Supplier supplierObj, string supplierId)
        {
            return supplierDal.UpdateBusinessInformation(supplierObj,supplierId);
        }
        internal int UpdateBusinessInF(Inv_Supplier supplierObj, int supplierId)
        {
            return supplierDal.UpdateBusinessInF(supplierObj, supplierId);
        }
        internal int UpdateContactpersoninformation(Inv_Supplier supplierObj, string Subcode)
        {
            return supplierDal.UpdateContactpersoninformation(supplierObj, Subcode);
        }
        internal int UpdateContactPer(Inv_Supplier supplierObj, int Subcode)
        {
            return supplierDal.UpdateContactPer(supplierObj, Subcode);
        }
        internal int UpdateItem(Inv_Sup_ItemInfo supplierObj, int Subcode)
        {
            return supplierDal.UpdateItem(supplierObj, Subcode);
        }

        internal List<HRM_PersonalInformations> getEmpNamebyEID(string eidS)
        {
            return supplierDal.getEmpNamebyEID(eidS);
        }

        internal List<Inv_Supplier> GetSupplierForSearch(string OCODE, string Name)
        {
            return supplierDal.GetSupplierForSearch(OCODE, Name);
        }

        internal List<Inv_Supplier> GetSupplierLocation(string OCODE)
        {
            return supplierDal.GetSupplierLocation(OCODE);
        }
    }
}
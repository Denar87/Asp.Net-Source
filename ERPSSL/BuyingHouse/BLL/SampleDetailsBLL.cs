using ERPSSL.BuyingHouse.DAL;
using ERPSSL.BuyingHouse.DAL.Repository;
using ERPSSL.LC.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//using ERPSSL.INV.DAL;

namespace ERPSSL.BuyingHouse.BLL
{
    public class SampleDetailsBLL
    {
        SampleDetailsDAL _SampleDetailsdal = new SampleDetailsDAL();

        internal List<Com_Buyer_Setup> GetBuyerList()
        {
            return _SampleDetailsdal.GetBuyerList();
        }

        internal List<LC_Factory> GetFactoryNameList()
        {
            return _SampleDetailsdal.GetFactoryNameList();
        }

        internal int Insert(LC_SampleDetails _ObjSampleDetails)
        {
            return _SampleDetailsdal.Insert(_ObjSampleDetails);
        }

        internal List<LC_SampleDetails> GetSampleDetailsList(string OCode)
        {
            return _SampleDetailsdal.GetSampleDetailsList(OCode);
        }

        internal LC_SampleDetails GetSDetailsById(int Id)
        {
            return _SampleDetailsdal.GetSDetailsById(Id);
        }

        internal int Update(LC_SampleDetails _ObjSampleDetails)
        {
            return _SampleDetailsdal.Update(_ObjSampleDetails);
        }

        internal int SampleUpdate(LC_SampleDetails _ObjSampleDetails)
        {
            return _SampleDetailsdal.SampleUpdate(_ObjSampleDetails);
        }

        internal List<LC_SampleDetails> GetSampleDetailsListByPOno(string PreOrderNo, string OCode)
        {
            return _SampleDetailsdal.GetSampleDetailsListByPOno(PreOrderNo, OCode);
        }

        internal List<HRM_DEPARTMENTS> GetGetMerchandiserDept(string ocode)
        {
            return _SampleDetailsdal.GetGetMerchandiserDept(ocode);
        }

        internal List<LC_Merchandiser_Name> GetMerchandiserName(string ocode)
        {
            return _SampleDetailsdal.GetMerchandiserName(ocode);
        }

        internal List<LC_Style_Gender> GetGenderList(string ocode)
        {
            return _SampleDetailsdal.GetGenderList(ocode);
        }

        internal List<LC_StyleCategor> GetQuotaOrCategory(string ocode)
        {
            return _SampleDetailsdal.GetQuotaOrCategory(ocode);
        }

        internal List<Inv_Unit> GetUnit()
        {
            return _SampleDetailsdal.GetUnit();
        }

        internal List<HRM_Office> GetOffice()
        {
            return _SampleDetailsdal.GetOffice();
        }

        internal List<LC_Factory> GetFactory(string ocode)
        {
            return _SampleDetailsdal.GetFactory(ocode);
        }

        internal List<RFEmployee> GetMerchandiserNameByDept(string ocode, int DepartmentId)
        {
            return _SampleDetailsdal.GetMerchandiserNameByDept(ocode, DepartmentId);
        }

        internal List<RFEmployee> GetMerchandiserNameByName(string OCode)
        {
            return _SampleDetailsdal.GetMerchandiserNameByName(OCode);
        }

        internal List<LC_Principal> GetPrincipalName(string OCode)
        {
            return _SampleDetailsdal.GetPrincipalName(OCode);
        }
    }
}
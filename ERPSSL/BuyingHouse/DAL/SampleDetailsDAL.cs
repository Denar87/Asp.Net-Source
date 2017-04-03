using ERPSSL.BuyingHouse.DAL.Repository;
using ERPSSL.LC.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPSSL.BuyingHouse.DAL
{
    public class SampleDetailsDAL
    {
        ERPSSL_LCEntities _Context = new ERPSSL_LCEntities();


        internal List<Com_Buyer_Setup> GetBuyerList()
        {
            try
            {
                List<Com_Buyer_Setup> _Buy = (from b in _Context.Com_Buyer_Setup
                                              select b).OrderBy(x => x.Buyer_Name).ToList();
                return _Buy;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal List<LC_Factory> GetFactoryNameList()
        {
            try
            {
                List<LC_Factory> _Fac = (from f in _Context.LC_Factory
                                         select f).OrderBy(x => x.FactoryName).ToList();
                return _Fac;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal int Insert(LC_SampleDetails _ObjSampleDetails)
        {
            try
            {
                _Context.LC_SampleDetails.AddObject(_ObjSampleDetails);
                _Context.SaveChanges();
                return 1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal List<LC_SampleDetails> GetSampleDetailsList(string OCode)
        {
            try
            {
                List<LC_SampleDetails> _Smd = (from s in _Context.LC_SampleDetails
                                               select s).ToList();
                return _Smd;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal LC_SampleDetails GetSDetailsById(int Id)
        {
            try
            {
                return (from s in _Context.LC_SampleDetails
                        where s.SampleId == Id
                        select s).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal int Update(LC_SampleDetails _ObjSampleDetails)
        {
            try
            {
                LC_SampleDetails _SampleDetails = _Context.LC_SampleDetails.FirstOrDefault(x => x.SampleId == _ObjSampleDetails.SampleId);
                _SampleDetails.Buyer_ID = _ObjSampleDetails.Buyer_ID;
                _SampleDetails.FactoryId = _ObjSampleDetails.FactoryId;
                _SampleDetails.SampleDate = _ObjSampleDetails.SampleDate;
                _SampleDetails.Pre_OrderNo = _ObjSampleDetails.Pre_OrderNo;
                _SampleDetails.SampleSpecification = _ObjSampleDetails.SampleSpecification;
                _SampleDetails.First_SampleSentDate = _ObjSampleDetails.First_SampleSentDate;
                _SampleDetails.Sample_Photo = _ObjSampleDetails.Sample_Photo;

                _SampleDetails.EditDate = DateTime.Now;
                _SampleDetails.EditUser = _ObjSampleDetails.EditUser;
                _Context.SaveChanges();
                return 1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal int SampleUpdate(LC_SampleDetails _ObjSampleDetails)
        {
            try
            {
                LC_SampleDetails _SampleDetails = _Context.LC_SampleDetails.FirstOrDefault(x => x.SampleId == _ObjSampleDetails.SampleId);
                _SampleDetails.Buyer_ID = _ObjSampleDetails.Buyer_ID;
                _SampleDetails.FactoryId = _ObjSampleDetails.FactoryId;
                _SampleDetails.SampleDate = _ObjSampleDetails.SampleDate;
                _SampleDetails.Pre_OrderNo = _ObjSampleDetails.Pre_OrderNo;
                _SampleDetails.SampleSpecification = _ObjSampleDetails.SampleSpecification;
                _SampleDetails.First_SampleSentDate = _ObjSampleDetails.First_SampleSentDate;

                _SampleDetails.Modi_ReceiveDate = _ObjSampleDetails.Modi_ReceiveDate;
                _SampleDetails.Modi_Status = _ObjSampleDetails.Modi_Status;
                _SampleDetails.Counter_SampleSend_Date = _ObjSampleDetails.Counter_SampleSend_Date;
                _SampleDetails.SizeSet_Date = _ObjSampleDetails.SizeSet_Date;
                _SampleDetails.Costing_SendDate = _ObjSampleDetails.Costing_SendDate;
                _SampleDetails.Production_ApprovedDate = _ObjSampleDetails.Production_ApprovedDate;
                _SampleDetails.BV_TestSubmitDate = _ObjSampleDetails.BV_TestSubmitDate;
                _SampleDetails.BV_TestReleaseDate = _ObjSampleDetails.BV_TestReleaseDate;
                _SampleDetails.SealingSample_SubmitDate = _ObjSampleDetails.SealingSample_SubmitDate;
                _SampleDetails.SealingSample_RelaseDate = _ObjSampleDetails.SealingSample_RelaseDate;
                _SampleDetails.ShipmentSample_SendDate = _ObjSampleDetails.ShipmentSample_SendDate;
                _SampleDetails.ShipmentSample_ApprovedDate = _ObjSampleDetails.ShipmentSample_ApprovedDate;
                _SampleDetails.Sample_Status = _ObjSampleDetails.Sample_Status;

                _SampleDetails.EditDate = DateTime.Now;
                _SampleDetails.EditUser = _ObjSampleDetails.EditUser;
                _Context.SaveChanges();
                return 1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal List<LC_SampleDetails> GetSampleDetailsListByPOno(string PreOrderNo, string OCode)
        {
            try
            {
                List<LC_SampleDetails> _Smd = (from s in _Context.LC_SampleDetails
                                               where s.Pre_OrderNo == PreOrderNo && s.OCode == OCode
                                               select s).ToList();
                return _Smd;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal List<HRM_DEPARTMENTS> GetGetMerchandiserDept(string ocode)
        {
            try
            {
                List<HRM_DEPARTMENTS> _md = (from s in _Context.HRM_DEPARTMENTS
                                             where s.OCODE == ocode
                                             select s).ToList();
                return _md;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal List<LC_Merchandiser_Name> GetMerchandiserName(string ocode)
        {
            try
            {
                List<LC_Merchandiser_Name> _mdName = (from s in _Context.LC_Merchandiser_Name
                                                      where s.OCode == ocode
                                                      select s).ToList();
                return _mdName;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal List<LC_Style_Gender> GetGenderList(string ocode)
        {
            try
            {
                List<LC_Style_Gender> _StyleGender = (from s in _Context.LC_Style_Gender
                                                      where s.OCode == ocode
                                                      select s).ToList();
                return _StyleGender;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal List<LC_StyleCategor> GetQuotaOrCategory(string ocode)
        {
            try
            {
                List<LC_StyleCategor> _StyleCategory = (from s in _Context.LC_StyleCategor
                                                        where s.OCode == ocode
                                                        select s).ToList();
                return _StyleCategory;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal List<Inv_Unit> GetUnit()
        {
            try
            {
                List<Inv_Unit> _InvUnit = (from s in _Context.Inv_Unit
                                           select s).ToList();
                return _InvUnit;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal List<HRM_Office> GetOffice()
        {
            try
            {
                List<HRM_Office> _HRMOffice = (from s in _Context.HRM_Office
                                               select s).ToList();
                return _HRMOffice;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal List<LC_Factory> GetFactory(string ocode)
        {
            try
            {
                List<LC_Factory> _Factory = (from s in _Context.LC_Factory
                                             select s).ToList();
                return _Factory;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal List<RFEmployee> GetMerchandiserNameByDept(string ocode, int DepartmentId)
        {
            try
            {
                var Query = (from P in _Context.HRM_PersonalInformations
                             join D in _Context.HRM_DEPARTMENTS on P.DepartmentId equals D.DPT_ID
                             where P.OCODE == ocode && P.DepartmentId == DepartmentId
                             select new RFEmployee
                             {
                                 DepartmentId = D.DPT_ID,
                                 FullName = P.FirstName ?? "" + " " + (P.LastName ?? "").Trim(),
                                 EID = P.EID
                             });
                return Query.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal List<RFEmployee> GetMerchandiserNameByName(string OCode)
        {
            try
            {
                var Query = (from P in _Context.HRM_PersonalInformations
                             where P.OCODE == OCode
                             select new RFEmployee
                             {
                                 FullName = P.FirstName ?? "" + " " + (P.LastName ?? "").Trim(),
                                 EID = P.EID
                             });
                return Query.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal List<LC_Principal> GetPrincipalName(string OCode)
        {
            try
            {
                List<LC_Principal> _Factory = (from s in _Context.LC_Principal
                                               select s).ToList();
                return _Factory;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
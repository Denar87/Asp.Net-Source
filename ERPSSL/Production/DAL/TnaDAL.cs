//using ERPSSL.HRM.DAL;
using ERPSSL.LC.DAL;
using ERPSSL.Production.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPSSL.Production.DAL
{
    public class TnaDAL
    {
        ERPSSL_LCEntities _Context = new ERPSSL_LCEntities();
        //ERPSSLHBEntities _ContextH = new ERPSSLHBEntities();
        internal List<LC_Style> GetStyleList()
        {
            try
            {
                List<LC_Style> _Style = (from st in _Context.LC_Style
                                         select st).OrderBy(x => x.StyleName).ToList();
                return _Style;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal List<LC_Brand> GetBrandList()
        {
            try
            {
                List<LC_Brand> _Brand = (from b in _Context.LC_Brand
                                         select b).OrderBy(x => x.BrandName).ToList();
                return _Brand;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        internal List<HRM_DEPARTMENTS> GetDepartmentList()
        {
            try
            {
                List<HRM_DEPARTMENTS> _Dept = (from b in _Context.HRM_DEPARTMENTS
                                               select b).OrderBy(x => x.DPT_NAME).ToList();
                return _Dept;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

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

        internal List<LC_Factory> GetFactoryList()
        {
            try
            {
                List<LC_Factory> _Fact = (from b in _Context.LC_Factory
                                          select b).OrderBy(x => x.FactoryName).ToList();
                return _Fact;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal int Insert(Prod_TNA _ObjProdTna)
        {
            try
            {
                _Context.Prod_TNA.AddObject(_ObjProdTna);
                _Context.SaveChanges();
                return 1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal int Update(Prod_TNA _ObjProdTna)
        {
            try
            {
                Prod_TNA _prodTNA = _Context.Prod_TNA.FirstOrDefault(x => x.ID == _ObjProdTna.ID);
                _prodTNA.StyleId = _ObjProdTna.StyleId;
                _prodTNA.BrandId = _ObjProdTna.BrandId;
                _prodTNA.DepartmentId = _ObjProdTna.DepartmentId;
                _prodTNA.Buyer_ID = _ObjProdTna.Buyer_ID;
                _prodTNA.FactoryId = _ObjProdTna.FactoryId;
                _prodTNA.Intake = _ObjProdTna.Intake;
                _prodTNA.Description = _ObjProdTna.Description;
                _prodTNA.ReceivedFromBuyer = _ObjProdTna.ReceivedFromBuyer;
                _prodTNA.SampleDeadline = _ObjProdTna.SampleDeadline;
                _prodTNA.FactoryQty = _ObjProdTna.FactoryQty;
                _prodTNA.FactoryPrice = _ObjProdTna.FactoryPrice;
                _prodTNA.ReceivedQty = _ObjProdTna.ReceivedQty;
                _prodTNA.ReceivedFromFactory = _ObjProdTna.ReceivedFromFactory;
                _prodTNA.SendToBuyer = _ObjProdTna.SendToBuyer;
                _prodTNA.BuyerQty = _ObjProdTna.BuyerQty;
                _prodTNA.Remark = _ObjProdTna.Remark;

                _prodTNA.Edit_Date = DateTime.Now;
                _prodTNA.Edit_User = _ObjProdTna.Edit_User;
                _Context.SaveChanges();
                return 1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal List<ProductionR> GetTnaList(string Ocode)
        {
            try
            {
                using (var _Context = new ERPSSL_LCEntities())
                {
                List<ProductionR> _tna = (from t in _Context.Prod_TNA
                                          join b in _Context.LC_Brand on t.BrandId equals b.BrandId
                                          join f in _Context.LC_Factory on t.FactoryId equals f.FactoryId
                                          join s in _Context.LC_Style on t.StyleId equals s.StyleId
                                          //join d in _ContextH.HRM_DEPARTMENTS on t.DepartmentId equals d.DPT_ID
                                          join bu in _Context.Com_Buyer_Setup on t.Buyer_ID equals bu.Buyer_ID
                                          where t.OCode == Ocode
                                          select new ProductionR
                                          {
                                              ID = t.ID,
                                              StyleId = t.StyleId,
                                              BrandId = t.BrandId,
                                              DepartmentId = t.DepartmentId,
                                              Buyer_ID = t.Buyer_ID,
                                              FactoryId = t.FactoryId,
                                              Intake = t.Intake,
                                              Description=t.Description,
                                              ReceivedFromBuyer = t.ReceivedFromBuyer,
                                              SendingDateToFactory = t.SendingDateToFactory,
                                              SampleDeadline=t.SampleDeadline,
                                              FactoryQty = t.FactoryQty,
                                              FactoryPrice = t.FactoryPrice,
                                              ReceivedQty = t.ReceivedQty,
                                              ReceivedFromFactory = t.ReceivedFromFactory,
                                              SendToBuyer = t.SendToBuyer,
                                              BuyerQty = t.BuyerQty,
                                              Remark = t.Remark,
                                              BrandName=b.BrandName,
                                              FactoryName=f.FactoryName,
                                              StyleName=s.StyleName,
                                              //DepartmentName=d.DPT_NAME,
                                              BuyerName=bu.Buyer_Name

                                          }).ToList();
                return _tna;
            }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal Prod_TNA GetTnaLById(int Id)
        {
            try
            {
                return (from t in _Context.Prod_TNA
                        where t.ID == Id
                        select t).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
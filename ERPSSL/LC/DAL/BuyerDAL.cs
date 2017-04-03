using ERPSSL.LC.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ERPSSL.BuyingHouse.DAL.Repository;
using MoreLinq;

namespace ERPSSL.LC.DAL
{
    public class BuyerDAL
    {
        ERPSSL_LCEntities _Content = new ERPSSL_LCEntities();

        internal int Save(Com_Buyer_Setup _buyerobj)
        {
            try
            {
                _Content.Com_Buyer_Setup.AddObject(_buyerobj);
                _Content.SaveChanges();
                return 1;
            }
            catch (Exception)
            {
                throw;
            }
        }

        internal List<Com_Buyer_Setup> GetBuyerList(string Ocode)
        {
            try
            {
                List<Com_Buyer_Setup> buyers = (from buyer in _Content.Com_Buyer_Setup
                                                where buyer.OCODE == Ocode
                                                select buyer).DistinctBy(x => x.Buyer_Name).ToList();
                return buyers;
            }
            catch (Exception)
            {
                throw;
            }
        }

        internal Com_Buyer_Setup GetBuyerById(int ByeryId)
        {
            Com_Buyer_Setup buyeres = (from buyer in _Content.Com_Buyer_Setup
                                       where buyer.Buyer_ID == ByeryId
                                       select buyer).FirstOrDefault();
            return buyeres;
        }

        internal int Update(Com_Buyer_Setup _buyerobj)
        {
            try
            {
                Com_Buyer_Setup _buerySetUp = _Content.Com_Buyer_Setup.FirstOrDefault(x => x.Buyer_ID == _buyerobj.Buyer_ID);

                _buerySetUp.Buyer_Name = _buyerobj.Buyer_Name;
                _buerySetUp.Contact_Person = _buyerobj.Contact_Person;
                _buerySetUp.PrincipalName = _buyerobj.PrincipalName;
                _buerySetUp.BuyingDepartment = _buyerobj.BuyingDepartment;
                _buerySetUp.Counter = _buyerobj.Counter;
                _buerySetUp.Phone = _buyerobj.Phone;
                _buerySetUp.Mobile = _buyerobj.Mobile;
                _buerySetUp.Email = _buyerobj.Email;
                _buerySetUp.Counter = _buyerobj.Counter;
                _buerySetUp.Status = _buyerobj.Status;
                _buerySetUp.Address = _buyerobj.Address;
                _buerySetUp.Buyer_Address = _buyerobj.Buyer_Address;
                _buerySetUp.Land_Address = _buyerobj.Land_Address;
                _buerySetUp.Sea_Address = _buyerobj.Sea_Address;
                _buerySetUp.NotifyParty = _buyerobj.NotifyParty;
                _buerySetUp.Consignee = _buyerobj.Consignee;
                _buerySetUp.Delivery_Address = _buyerobj.Delivery_Address;
                _buerySetUp.Destination_Address = _buyerobj.Destination_Address;
                _Content.SaveChanges();
                return 1;
            }
            catch (Exception)
            {
                throw;
            }
        }

        internal List<Com_Buyer_Setup> GetBuyerByType(string BuyerType)
        {
            List<Com_Buyer_Setup> buyeres = (from buyer in _Content.Com_Buyer_Setup
                                             where buyer.Type == BuyerType.Trim()
                                             select buyer).ToList();
            return buyeres;
        }
        internal List<Com_Buyer_Setup> GetBuyerName(string ocode)
        {
            List<Com_Buyer_Setup> buyeres = (from buyer in _Content.Com_Buyer_Setup
                                             where buyer.OCODE == ocode
                                             select buyer).ToList();
            return buyeres;
        }

        internal Com_Buyer_Setup GetBuyerByType(int BuyerId)
        {
            try
            {
                return (from buyer in _Content.Com_Buyer_Setup
                        where buyer.Buyer_ID == BuyerId
                        select buyer).FirstOrDefault();
            }
            catch (Exception)
            {
                throw;
            }
        }

        internal int InsertStyle(LC_Style style)
        {
            try
            {
                _Content.LC_Style.AddObject(style);
                _Content.SaveChanges();
                return 1;
            }
            catch (Exception)
            {
                throw;
            }
        }

        internal int AddStyle(LC_Style style)
        {
            try
            {
                _Content.LC_Style.AddObject(style);
                _Content.SaveChanges();
                return style.StyleId;
            }
            catch (Exception)
            {
                throw;
            }
        }

        internal int UpdateStyle(LC_Style style)
        {
            LC_Style _style = _Content.LC_Style.FirstOrDefault(x => x.StyleId == style.StyleId);
            _style.StyleName = style.StyleName;
            _style.Specification = style.Specification;
            _style.HS_Code = style.HS_Code;
            _style.CAT = style.CAT;
            _style.Style_Photo = style.Style_Photo;
            _style.EditDate = DateTime.Today;
            _style.EditUser = style.EditUser;
            _Content.SaveChanges();
            return 1;
        }

        internal LC_Style GetStyleById(int StyleId)
        {
            try
            {
                return (from sty in _Content.LC_Style
                        where sty.StyleId == StyleId
                        select sty).FirstOrDefault();
            }
            catch (Exception)
            {
                throw;
            }
        }

        internal List<LC_Style> GetStyleList(string Ocode)
        {
            try
            {
                List<LC_Style> style = (from st in _Content.LC_Style
                                        where st.OCode == Ocode
                                        select st).OrderBy(x => x.StyleName).ToList();
                return style;
            }
            catch (Exception)
            {
                throw;
            }
        }

        internal int InsertFinishGoods(LC_FinishGoods _FinishGoods)
        {
            _Content.LC_FinishGoods.AddObject(_FinishGoods);
            _Content.SaveChanges();
            return 1;
        }

        internal List<LC_FinishGoods> GetFinishGoodsList(string Ocode)
        {
            try
            {
                List<LC_FinishGoods> fGoods = (from finishGoods in _Content.LC_FinishGoods
                                               where finishGoods.OCode == Ocode
                                               select finishGoods).OrderBy(x => x.FinishGoods_Name).ToList();
                return fGoods;
            }
            catch (Exception)
            {
                throw;
            }
        }

        internal int UpdateFinishGoods(LC_FinishGoods _FinishGoods)
        {
            LC_FinishGoods FinishGoods = _Content.LC_FinishGoods.FirstOrDefault(x => x.FinishGoods_Id == _FinishGoods.FinishGoods_Id);
            FinishGoods.FinishGoods_Name = _FinishGoods.FinishGoods_Name;
            FinishGoods.EditDate = DateTime.Today;
            FinishGoods.EditUser = _FinishGoods.EditUser;
            _Content.SaveChanges();
            return 1;
        }

        internal LC_FinishGoods GetFinishGoodsById(int FinishGoods_Id)
        {
            try
            {
                return (from goods in _Content.LC_FinishGoods
                        where goods.FinishGoods_Id == FinishGoods_Id
                        select goods).FirstOrDefault();
            }
            catch (Exception)
            {
                throw;
            }
        }

        internal List<LC_FinishGoods> GetFinishGoodsListGetBuyerList(string Ocode)
        {


            try
            {
                var query = (from fGood in _Content.LC_FinishGoods
                             where fGood.OCode == Ocode
                             select fGood).OrderBy(x => x.FinishGoods_Id);


                return query.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        internal int InsertMagerment_Parameter(LC_Measurement_Parameter _Magerment_Parameter)
        {
            _Content.LC_Measurement_Parameter.AddObject(_Magerment_Parameter);
            _Content.SaveChanges();
            return 1;
        }

        internal int UpdateMagerment_Parameter(LC_Measurement_Parameter _Magerment_Parameter)
        {
            LC_Measurement_Parameter Magerment_Parameter = _Content.LC_Measurement_Parameter.FirstOrDefault(x => x.Measurement_Id == _Magerment_Parameter.Measurement_Id);
            Magerment_Parameter.Measurement_Name = _Magerment_Parameter.Measurement_Name;
            Magerment_Parameter.FinishGoods_Id = _Magerment_Parameter.FinishGoods_Id;
            Magerment_Parameter.EditDate = DateTime.Today;
            Magerment_Parameter.EditUser = _Magerment_Parameter.EditUser;
            _Content.SaveChanges();
            return 1;
        }

        internal List<ItemList> GetMagermentParameterList(string Ocode)
        {
            using (var _context = new ERPSSL_LCEntities())
            {

                return (from mp in _context.LC_Measurement_Parameter
                        join fg in _context.LC_FinishGoods on mp.FinishGoods_Id equals fg.FinishGoods_Id


                        select new ItemList
                        {

                            Measurement_Id = mp.Measurement_Id,
                            FinishGoodsName = fg.FinishGoods_Name,
                            MagermentName = mp.Measurement_Name,

                        }).ToList();
            }
        }

        internal LC_Measurement_Parameter GetMagermentById(int Magerment_Id)
        {
            try
            {
                return (from MP in _Content.LC_Measurement_Parameter
                        where MP.Measurement_Id == Magerment_Id
                        select MP).FirstOrDefault();
            }
            catch (Exception)
            {
                throw;
            }
        }

        internal IEnumerable<ItemList> MeasurementParameter(string Ocode, int finishGoods)
        {
            using (var _context = new ERPSSL_LCEntities())
            {

                return (from mp in _context.LC_Measurement_Parameter
                        join fg in _context.LC_FinishGoods on mp.FinishGoods_Id equals fg.FinishGoods_Id
                        where mp.OCode == Ocode && mp.FinishGoods_Id == finishGoods
                        select new ItemList
                        {

                            Measurement_Id = mp.Measurement_Id,
                            FinishGoodsName = fg.FinishGoods_Name,
                            MagermentName = mp.Measurement_Name,

                        }).ToList();
            }
        }

        internal ItemList GetBuyerDetails()
        {
            try
            {
                using (var _context = new ERPSSL_LCEntities())
                {


                    string SP_SQL = "[BH_ExestingBuyer]";

                    return (_context.ExecuteStoreQuery<ItemList>(SP_SQL)).FirstOrDefault();
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        internal Year GetServiceScheduleMonthWise()
        {
            try
            {
                using (var _context = new ERPSSL_LCEntities())
                {


                    string SP_SQL = "[OrderRatioMonthWise]";

                    return (_context.ExecuteStoreQuery<Year>(SP_SQL)).FirstOrDefault();
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        internal List<Com_Buyer_Setup> GetBuyerByName(string name)
        {
            try
            {
                using (var _context = new ERPSSL_LCEntities())
                {
                    return _context.Com_Buyer_Setup.Where(x => x.Buyer_Name == name).ToList();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        internal int InsertSize(LC_Size sLC_Size)
        {
            _Content.LC_Size.AddObject(sLC_Size);
            _Content.SaveChanges();
            return 1;
        }

        internal List<LC_BuyerDepartment> GetBuyerDepartmentList(string Ocode)
        {
            try
            {
                List<LC_BuyerDepartment> buyers = (from buyer in _Content.LC_BuyerDepartment
                                                   where buyer.OCode == Ocode
                                                   select buyer).OrderBy(x => x.BuyerDepartment_Id).ToList();
                return buyers;
            }
            catch (Exception)
            {
                throw;
            }
        }

        internal int AddBuyerDepartment(LC_BuyerDepartment _LC_BuyerDepartment)
        {
            try
            {
                _Content.LC_BuyerDepartment.AddObject(_LC_BuyerDepartment);
                _Content.SaveChanges();
                return _LC_BuyerDepartment.BuyerDepartment_Id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal List<BuyerR> GetBuyerListAll(string Ocode)
        {
            try
            {
                return (from B in _Content.Com_Buyer_Setup
                        join D in _Content.LC_BuyerDepartment on B.BuyingDepartmentId equals D.BuyerDepartment_Id
                        where B.OCODE == Ocode
                        select new BuyerR
                        {
                            Buyer_ID = B.Buyer_ID,
                            PrincipalName = B.PrincipalName,
                            Buyer_Name = B.Buyer_Name,
                            Country = B.Country,
                            Address = B.Address,
                            BuyingDepartmentId = D.BuyerDepartment_Id,
                            BuyerDepartment_Name = D.BuyerDepartment_Name,

                        }).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal List<BuyerR> GetBuyerListByName(string Ocode, string BuyerNameL)
        {
            try
            {
                var Query = (from B in _Content.Com_Buyer_Setup
                             join D in _Content.LC_BuyerDepartment on B.BuyingDepartmentId equals D.BuyerDepartment_Id
                             where B.OCODE == Ocode && B.Buyer_Name == BuyerNameL

                             select new BuyerR
                             {
                                 Buyer_ID = B.Buyer_ID,
                                 PrincipalName = B.PrincipalName,
                                 Buyer_Name = B.Buyer_Name,
                                 Country = B.Country,
                                 Address = B.Address,
                                 BuyingDepartmentId = D.BuyerDepartment_Id,
                                 BuyerDepartment_Name = D.BuyerDepartment_Name,
                             }).ToList();
                return Query;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
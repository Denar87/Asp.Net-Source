using ERPSSL.LC.DAL;
using ERPSSL.LC.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using ERPSSL.BuyingHouse.DAL.Repository;

namespace ERPSSL.LC.BLL
{

    public class BuyerBLL
    {
        BuyerDAL _BuyerDal = new BuyerDAL();
        internal object GetCounteryName()
        {
            List<string> cultureList = new List<string>();
            CultureInfo[] cultures = CultureInfo.GetCultures(CultureTypes.AllCultures & ~CultureTypes.NeutralCultures);
            cultureList.Add("--- Select One ---");
            foreach (CultureInfo culture in cultures)
            {
                CultureTypes ct = culture.CultureTypes;
                String s = ct.ToString();
                if (!s.Contains("NeutralCultures"))
                {
                    // check if it's not a invariant culture
                    if (culture.LCID != 127)
                    {
                        RegionInfo region = new RegionInfo(culture.LCID);
                        // add countries that are not in the list
                        if (!(cultureList.Contains(region.EnglishName)))
                        {
                            cultureList.Add(region.EnglishName);
                        }
                    }
                }
            }
            cultureList.Sort(); // sort alphabetically
            return cultureList;
        }

        internal int Save(Com_Buyer_Setup _buyerobj)
        {
            return _BuyerDal.Save(_buyerobj);
        }
        internal int InsertStyle(LC_Style style)
        {
            return _BuyerDal.InsertStyle(style);
        }
        internal int AddStyle(LC_Style style)
        {
            return _BuyerDal.AddStyle(style);
        }
        internal List<Com_Buyer_Setup> GetBuyerList(string Ocode)
        {
            return _BuyerDal.GetBuyerList(Ocode);
        }
        internal List<LC_Style> GetStyleList(string Ocode)
        {
            return _BuyerDal.GetStyleList(Ocode);
        }

        internal Com_Buyer_Setup GetBuyerById(int ByeryId)
        {
            return _BuyerDal.GetBuyerById(ByeryId);
        }
        internal LC_Style GetStyleById(int StyleId)
        {
            return _BuyerDal.GetStyleById(StyleId);
        }
        internal int Update(Com_Buyer_Setup _buyerobj)
        {
            return _BuyerDal.Update(_buyerobj);
        }
        internal int UpdateStyle(LC_Style style)
        {
            return _BuyerDal.UpdateStyle(style);
        }
        internal List<Com_Buyer_Setup> GetBuyerByType(string BuyerType)
        {
            return _BuyerDal.GetBuyerByType(BuyerType);
        }
        internal List<Com_Buyer_Setup> GetBuyerName(string ocode)
        {
            return _BuyerDal.GetBuyerName(ocode);
        }
        internal Com_Buyer_Setup GetCounteryNameById(int BuyerId)
        {
            return _BuyerDal.GetBuyerByType(BuyerId);

        }

        internal int InsertFinishGoods(LC_FinishGoods _FinishGoods)
        {
            return _BuyerDal.InsertFinishGoods(_FinishGoods);
        }

        internal List<LC_FinishGoods> GetFinishGoodsList(string Ocode)
        {
            return _BuyerDal.GetFinishGoodsList(Ocode);
        }

        internal int UpdateFinishGoods(LC_FinishGoods _FinishGoods)
        {
            return _BuyerDal.UpdateFinishGoods(_FinishGoods);
        }
        internal LC_FinishGoods GetFinishGoodsById(int FinishGoods_Id)
        {

            return _BuyerDal.GetFinishGoodsById(FinishGoods_Id);
        }

        internal List<LC_FinishGoods> GetFinishGoodsListGetBuyerList(string Ocode)
        {
            return _BuyerDal.GetFinishGoodsListGetBuyerList(Ocode);
        }

        internal int InsertMagerment_Parameter(LC_Measurement_Parameter _Magerment_Parameter)
        {
            return _BuyerDal.InsertMagerment_Parameter(_Magerment_Parameter);
        }

        internal int UpdateMagerment_Parameter(LC_Measurement_Parameter _Magerment_Parameter)
        {
            return _BuyerDal.UpdateMagerment_Parameter(_Magerment_Parameter);
        }

        internal List<ItemList> GetMagermentParameterList(string Ocode)
        {
            return _BuyerDal.GetMagermentParameterList(Ocode);
        }

        internal LC_Measurement_Parameter GetMagermentById(int Magerment_Id)
        {
            return _BuyerDal.GetMagermentById(Magerment_Id);
        }

        internal IEnumerable<ItemList> MeasurementParameter(string Ocode, int finishGoods)
        {
            return _BuyerDal.MeasurementParameter(Ocode, finishGoods);
        }

        internal ItemList GetBuyerDetails()
        {
            return _BuyerDal.GetBuyerDetails();
        }

        internal Year GetServiceScheduleMonthWise()
        {

            return _BuyerDal.GetServiceScheduleMonthWise();
        }
        internal List<Com_Buyer_Setup> GetBuyerByName(string name)
        {
            return _BuyerDal.GetBuyerByName(name);
        }

        internal int InsertSize(LC_Size sLC_Size)
        {
            return _BuyerDal.InsertSize(sLC_Size);
        }

        internal List<LC_BuyerDepartment> GetBuyerDepartmentList(string Ocode)
        {
            return _BuyerDal.GetBuyerDepartmentList(Ocode);
        }

        internal int AddBuyerDepartment(LC_BuyerDepartment _LC_BuyerDepartment)
        {
            return _BuyerDal.AddBuyerDepartment(_LC_BuyerDepartment);
        }

        internal List<BuyerR> GetBuyerListAll(string Ocode)
        {
            return _BuyerDal.GetBuyerListAll(Ocode);
        }

        internal List<BuyerR> GetBuyerListByName(string Ocode, string BuyerNameL)
        {
            return _BuyerDal.GetBuyerListByName(Ocode, BuyerNameL);
        }
    }
}
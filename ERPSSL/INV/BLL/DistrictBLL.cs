using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ERPSSL.INV.DAL;

namespace ERPSSL.INV.BLL
{
    public class DistrictBll
    {
        DistrictDAL districtDal = new DistrictDAL();

        //internal int InsertDistrict(Inv_District districtObj)
        //{
        //    return districtDal.InsertDistrict(groupObj);
        //}

        internal List<Inv_District> GetAllDistrict()
        {
            return districtDal.GetAllDistrict();
        }
        internal List<Inv_CompanyType> GetAllBusinessType()
        {
            return districtDal.GetAllBusinessType();
        }

        //internal List<Inv_District> GetDistrictById(string districtId)
        //{
        //    return districtDal.GetDistrictById(districtId);
        //}

        //internal int UpdateDistrict(Inv_District districtObj, int districtId)
        //{
        //    return districtDal.UpdateDistrict(districtId, districtObj);
        //}

    }
}
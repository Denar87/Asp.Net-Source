using ERPSSL.LC.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPSSL.LC.BLL
{
    public class BrandBLL
    {
        BrandDAL _branddaL = new BrandDAL();
        internal int InsertStyle(LC_Brand _lcBrand)
        {
            return _branddaL.InsertStyle(_lcBrand);
        }

        internal int UpdateStyle(LC_Brand _lcBrand)
        {
            return _branddaL.UpdateStyle(_lcBrand);
        }

        internal List<LC_Brand> LoadBrandList(string Ocode)
        {
            return _branddaL.LoadBrandList(Ocode);
        }

        internal LC_Brand GetBrandLById(int BeandId)
        {
            return _branddaL.GetBrandLById(BeandId);
        }
    }
}
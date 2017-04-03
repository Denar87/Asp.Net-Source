//using ERPSSL.HRM.DAL;
using ERPSSL.LC.DAL;
using ERPSSL.Production.DAL;
using ERPSSL.Production.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPSSL.Production.BLL
{
    public class TnaBLL
    {
        TnaDAL _tnadaL = new TnaDAL();

        internal List<LC_Style> GetStyleList()
        {
            return _tnadaL.GetStyleList();
        }

        internal List<LC_Brand> GetBrandList()
        {
            return _tnadaL.GetBrandList();
        }

        internal List<HRM_DEPARTMENTS> GetDepartmentList()
        {
            return _tnadaL.GetDepartmentList();
        }

        internal List<Com_Buyer_Setup> GetBuyerList()
        {
            return _tnadaL.GetBuyerList();
        }

        internal List<LC_Factory> GetFactoryList()
        {
            return _tnadaL.GetFactoryList();
        }

        internal int Insert(Prod_TNA _ObjProdTna)
        {
            return _tnadaL.Insert(_ObjProdTna);
        }

        internal int Update(Prod_TNA _ObjProdTna)
        {
            return _tnadaL.Update(_ObjProdTna);
        }

        internal List<ProductionR> GetTnaList(string Ocode)
        {
            return _tnadaL.GetTnaList(Ocode);
        }

        internal Prod_TNA GetTnaLById(int Id)
        {
            return _tnadaL.GetTnaLById(Id);
        }
    }
}
using ERPSSL.BuyingHouse.DAL;
using ERPSSL.LC.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPSSL.BuyingHouse.BLL
{
    public class PrincipalBLL
    {
        PrincipalDAL _Principaldal = new PrincipalDAL();
        internal int InsertPrincipal(LC_Principal _ObjPrincipal)
        {
            return _Principaldal.InsertPrincipal(_ObjPrincipal);
        }

        internal int UpdatePrincipal(LC_Principal _ObjPrincipal)
        {
            return _Principaldal.UpdatePrincipal(_ObjPrincipal);
        }

        internal List<LC_Principal> LoadPrincipalList(string OCode)
        {
            return _Principaldal.LoadPrincipalList(OCode);
        }

        internal LC_Principal GetPrincipalLById(int Id)
        {
            return _Principaldal.GetPrincipalLById(Id);
        }
    }
}
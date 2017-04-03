using ERPSSL.LC.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPSSL.BuyingHouse.DAL
{
    public class PrincipalDAL
    {
        ERPSSL_LCEntities _Context = new ERPSSL_LCEntities();

        internal int InsertPrincipal(LC_Principal _ObjPrincipal)
        {
            try
            {
                _Context.LC_Principal.AddObject(_ObjPrincipal);
                _Context.SaveChanges();
                return 1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal int UpdatePrincipal(LC_Principal _ObjPrincipal)
        {
            try
            {
                LC_Principal _Principal = _Context.LC_Principal.FirstOrDefault(x => x.Principal_Id == _ObjPrincipal.Principal_Id);
                _Principal.PrincipalName = _ObjPrincipal.PrincipalName;
                _Principal.Address = _ObjPrincipal.Address;
                _Principal.Country = _ObjPrincipal.Country;
                _Principal.EditDate = DateTime.Now;
                _Principal.EditUser = _ObjPrincipal.EditUser;
                _Context.SaveChanges();
                return 1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal List<LC_Principal> LoadPrincipalList(string OCode)
        {
            try
            {
                var _brand = (from st in _Context.LC_Principal
                                         where st.OCode == OCode
                                         select st).OrderBy(x => x.PrincipalName);
                return _brand.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal LC_Principal GetPrincipalLById(int Id)
        {
            try
            {
                return (from br in _Context.LC_Principal
                        where br.Principal_Id == Id
                        select br).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
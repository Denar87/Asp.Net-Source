using ERPSSL.LC.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPSSL.LC.BLL
{
    public class FactoryBLL
    {
        FactoryDAL _factorydaL = new FactoryDAL();
        internal int InsertFactory(LC_Factory _lcFactory)
        {
            return _factorydaL.InsertFactory(_lcFactory);
        }

        internal int UpdateFactory(LC_Factory _lcFactory)
        {
            return _factorydaL.UpdateFactory(_lcFactory);
        }

        internal List<LC_Factory> LoadFactoryList(string Ocode)
        {
            return _factorydaL.LoadFactoryList(Ocode);
        }

        internal LC_Factory GetFactoryLById(int fqId)
        {
            return _factorydaL.GetFactoryLById(fqId);
        }

        internal string GetNewFactoryCode(string CountryCode, string FacCode)
        {
            try
            {
                var Year = DateTime.Now.Year;
                //int count = 0;
                string FaCode = null;
                FaCode = CountryCode + "-" + FacCode + "-" + Year;
                //FaCode += (count + 1).ToString();
                return FaCode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal List<LC_Factory> LoadFactoryListByName(string name)
        {
            return _factorydaL.LoadFactoryListByName(name);
        }

        internal List<LC_Factory> LoadFactoryListBySName(string Ocode, string F_Name)
        {
            return _factorydaL.LoadFactoryListBySName(Ocode, F_Name);
        }
    }
}
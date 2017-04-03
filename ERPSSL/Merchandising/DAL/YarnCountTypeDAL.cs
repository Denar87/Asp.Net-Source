using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPSSL.Merchandising.DAL
{
    public class YarnCountTypeDAL
    {

        ERPSSL_MerchandisingEntities _Context = new ERPSSL_MerchandisingEntities();

        internal int SaveData(LC_YarnCountType aLC_YarnCountType)
        {
            try
            {
                _Context.LC_YarnCountType.AddObject(aLC_YarnCountType);
                _Context.SaveChanges();
                return 1;
            }
            catch (Exception ex)
            {
                throw ex;
            } 
        }

        internal int UpdateData(LC_YarnCountType aLC_YarnCountType, int idForUpdate)
        {
            try
            {
                LC_YarnCountType LC_YarnCountType = _Context.LC_YarnCountType.First(x => x.Id == idForUpdate);



                LC_YarnCountType.YarnCountType = aLC_YarnCountType.YarnCountType;
                LC_YarnCountType.EditUser = aLC_YarnCountType.EditUser;
                LC_YarnCountType.EditDate = aLC_YarnCountType.EditDate;
                LC_YarnCountType.OCode = aLC_YarnCountType.OCode;

                _Context.SaveChanges();
                return 1;

            }
            catch (Exception)
            {

                throw;
            }
        }

        internal List<LC_YarnCountType> LoadDataForGrid(string ocode)
        {
            try
            {
                var ListType = (from IName in _Context.LC_YarnCountType
                                where IName.OCode == ocode
                                select IName);
                return ListType.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        internal LC_YarnCountType GetSingleData(int entryId)
        {
            try
            {
                LC_YarnCountType aLC_YarnCountType = new LC_YarnCountType();

                aLC_YarnCountType = (from IName in _Context.LC_YarnCountType
                                   where IName.Id == entryId
                                   select IName).SingleOrDefault();
                return aLC_YarnCountType;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
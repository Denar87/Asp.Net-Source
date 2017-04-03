using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPSSL.Merchandising.DAL
{
    public class ConstructionTypeDAL
    {
        ERPSSL_MerchandisingEntities _Context = new ERPSSL_MerchandisingEntities();

        internal int SaveData(LC_ConstructionType aLC_ConstructionType)
        {
            try
            {
                _Context.LC_ConstructionType.AddObject(aLC_ConstructionType);
                _Context.SaveChanges();
                return 1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal List<LC_ConstructionType> LoadDataForGrid(string ocode)
        {
            try
            {
                var ListType = (from IName in _Context.LC_ConstructionType
                                where IName.OCode == ocode
                                select IName);
                return ListType.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        internal LC_ConstructionType GetSingleData(int entryId)
        {
            try
            {
                LC_ConstructionType aLC_ConstructionType = new LC_ConstructionType();

                aLC_ConstructionType = (from IName in _Context.LC_ConstructionType
                                        where IName.Id == entryId
                                        select IName).SingleOrDefault();
                return aLC_ConstructionType;
            }
            catch (Exception)
            {
                throw;
            }
        }

        internal int UpdateData(LC_ConstructionType aLC_ConstructionType, int idForUpdate)
        {
            try
            {
                LC_ConstructionType LC_ConstructionType = _Context.LC_ConstructionType.First(x => x.Id == idForUpdate);



                LC_ConstructionType.ConstructionType = aLC_ConstructionType.ConstructionType;
                LC_ConstructionType.EditUser = aLC_ConstructionType.EditUser;
                LC_ConstructionType.EditDate = aLC_ConstructionType.EditDate;
                LC_ConstructionType.OCode = aLC_ConstructionType.OCode;

                _Context.SaveChanges();
                return 1;

            }
            catch (Exception)
            {

                throw;
            }

        }
    }

    
}
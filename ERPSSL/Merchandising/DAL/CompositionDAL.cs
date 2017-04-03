using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPSSL.Merchandising.DAL
{
    public class CompositionDAL
    {

        ERPSSL_MerchandisingEntities _Context = new ERPSSL_MerchandisingEntities();

        internal int SaveData(LC_Composition aLC_Composition)
        {
            try
            {
                _Context.LC_Composition.AddObject(aLC_Composition);
                _Context.SaveChanges();
                return 1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal int UpdateData(LC_Composition aLC_Composition, int idForUpdate)
        {
            try
            {
                LC_Composition LC_Composition = _Context.LC_Composition.First(x => x.Id == idForUpdate);



                LC_Composition.Composition = aLC_Composition.Composition;
                LC_Composition.EditUser = aLC_Composition.EditUser;
                LC_Composition.EditDate = aLC_Composition.EditDate;
                LC_Composition.OCode = aLC_Composition.OCode;

                _Context.SaveChanges();
                return 1;

            }
            catch (Exception)
            {

                throw;
            }
        }

        internal List<LC_Composition> LoadDataForGrid(string ocode)
        {
            try
            {
                var ListType = (from IName in _Context.LC_Composition
                                where IName.OCode == ocode
                                select IName);
                return ListType.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        internal LC_Composition GetSingleData(int entryId)
        {
            try
            {
                LC_Composition aLC_Composition = new LC_Composition();

                aLC_Composition = (from IName in _Context.LC_Composition
                                        where IName.Id == entryId
                                        select IName).SingleOrDefault();
                return aLC_Composition;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
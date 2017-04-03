using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPSSL.Merchandising.DAL
{
    public class FabricNatureDAL
    {
        ERPSSL_MerchandisingEntities _Context = new ERPSSL_MerchandisingEntities();

        internal int SaveData(LC_FabricNature aLC_FabricNature)
        {
            try
            {
                _Context.LC_FabricNature.AddObject(aLC_FabricNature);
                _Context.SaveChanges();
                return 1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal List<LC_FabricNature> LoadDataForGrid(string ocode)
        {
            try
            {
                var ListType = (from IName in _Context.LC_FabricNature
                                where IName.OCode == ocode
                                select IName);
                return ListType.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        internal LC_FabricNature GetSingleData(int entryId)
        {
            try
            {
                LC_FabricNature aLC_FabricNature = new LC_FabricNature();

                aLC_FabricNature = (from IName in _Context.LC_FabricNature
                                     where IName.Id == entryId
                                     select IName).SingleOrDefault();
                return aLC_FabricNature;
            }
            catch (Exception)
            {
                throw;
            }
        }

        internal int UpdateData(LC_FabricNature aLC_FabricNature, int idForUpdate)
        {
            try
            {
                LC_FabricNature LC_FabricNature = _Context.LC_FabricNature.First(x => x.Id == idForUpdate);



                LC_FabricNature.FabricNature = aLC_FabricNature.FabricNature;
                LC_FabricNature.EditUser = aLC_FabricNature.EditUser;
                LC_FabricNature.EditDate = aLC_FabricNature.EditDate;
                LC_FabricNature.OCode = aLC_FabricNature.OCode;

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
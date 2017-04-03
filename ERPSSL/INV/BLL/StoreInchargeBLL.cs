using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ERPSSL.INV.DAL;
using ERPSSL.INV.DAL.Repository;

namespace ERPSSL.INV.BLL
{
    public class StoreInchargeBLL
    {
        StoreInchargeDAL storeinchargedal = new StoreInchargeDAL();

        //internal List<HRM_PersonalInformations> GetStoreIncharge()
        //{
        //    return storeinchargedal.GetStoreIncharge();
        //}
        internal IEnumerable<StoreInCharge> GetStoreIncharge()
        {
            return storeinchargedal.GetStoreIncharge();
        }


    }
}
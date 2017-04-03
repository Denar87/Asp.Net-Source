using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ERPSSL.INV.DAL;

namespace ERPSSL.INV.BLL
{
    public class DeleveryModeBLL
    {
        DeleveryModeDAL aDeleveryModeDAL = new DeleveryModeDAL();
        internal int InsertDeleveryMode(Inv_DeliveryMode aDeleveryMode)
        {
            return aDeleveryModeDAL.InsertDeleveryMode(aDeleveryMode);
        }

        internal List<Inv_DeliveryMode> GetAllDeleveryMode()
        {
            return aDeleveryModeDAL.GetAllDeleveryMode( );
        }

        internal int UpdateDeleveryMode(Inv_DeliveryMode aDeleveryMode, int ID)
        {
            return aDeleveryModeDAL.UpdateDeleveryMode(aDeleveryMode, ID);
        }

        internal List<Inv_DeliveryMode> GetDModeId(string ID)
        {
            return aDeleveryModeDAL.GetDModeId(ID);
        }
    }
}
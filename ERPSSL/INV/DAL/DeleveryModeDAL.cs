using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPSSL.INV.DAL
{
    public class DeleveryModeDAL
    {
        private ERPSSL_INVEntities _context = new ERPSSL_INVEntities();
        internal int InsertDeleveryMode(Inv_DeliveryMode aDeleveryMode)
        {
            try
            {
                _context.Inv_DeliveryMode.AddObject(aDeleveryMode);
                _context.SaveChanges();
                return 1;

            }
            catch (Exception)
            {

                throw;
            }
        }

        internal List<Inv_DeliveryMode> GetAllDeleveryMode()
        {
            try
            {
                var DeleveryMode = (from DMode in _context.Inv_DeliveryMode

                                select DMode).OrderBy(x => x.Delivery_Mode); 

                return DeleveryMode.ToList();

            }
            catch (Exception)
            {

                throw;
            }
        }

        internal int UpdateDeleveryMode(Inv_DeliveryMode aDeleveryMode, int ID)
        {
            try
            {
                Inv_DeliveryMode DMode = _context.Inv_DeliveryMode.First(x => x.DeliveryMode_Id == ID);
                DMode.Delivery_Mode = aDeleveryMode.Delivery_Mode; 
                _context.SaveChanges();
                return 1;

            }
            catch (Exception)
            {

                throw;
            }
        }

        internal List<Inv_DeliveryMode> GetDModeId(string ID)
        {
            try
            {
                int DeleveryModeID = Convert.ToInt32(ID);
                var mode = (from DMODE in _context.Inv_DeliveryMode
                               where DMODE.DeliveryMode_Id == DeleveryModeID
                               select DMODE);
                return mode.ToList();

            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
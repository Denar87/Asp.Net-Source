using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPSSL.Merchandising.DAL
{
    public class Color_DAL
    {
        private ERPSSL_MerchandisingEntities _context = new ERPSSL_MerchandisingEntities();

        internal int InsertColor(LC_Color objColor)
        {
            try
            {
                _context.LC_Color.AddObject(objColor);
                _context.SaveChanges();
                return 1;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public virtual List<LC_Color> GetAllColor(string OCODE)
        {

            try
            {
                var query = (from col in _context.LC_Color
                             where col.OCODE == OCODE
                             select col).OrderBy(x => x.ColorName);


                return query.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        internal int UpdateColor(LC_Color objcol, int colorId)
        {

            try
            {
                LC_Color obj = _context.LC_Color.First(x => x.ColorId == colorId);
                obj.ColorName = objcol.ColorName;
                obj.Status = objcol.Status;
                obj.Edit_User = objcol.Edit_User;
                obj.Edit_Date = objcol.Edit_Date;
                _context.SaveChanges();
                return 1;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        internal List<LC_Color> GetColorInfoByColorId(string  colorId, string OCODE)
        {
            int colId = Convert.ToInt32(colorId);


            List<LC_Color> colors = (from col in _context.LC_Color
                                         where col.OCODE == OCODE && col.ColorId == colId
                                         select col).OrderBy(x => x.ColorId).ToList<LC_Color>();
            return colors;

        }
    }
}
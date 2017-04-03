using ERPSSL.Merchandising.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPSSL.Merchandising.BLL
{
    public class Color_BLL
    {
         Color_DAL objColor_Dal = new Color_DAL();

         internal int InsertColor(LC_Color objColor)
         {
             return objColor_Dal.InsertColor(objColor);
         }

         public virtual List<LC_Color> GetAllColor(string OCODE)
         {
             return objColor_Dal.GetAllColor(OCODE);
         }
         internal int UpdateColor(LC_Color objcol, int colorId)
         {
             return objColor_Dal.UpdateColor(objcol,colorId);
         }

         internal List<LC_Color> GetColorInfoByColorId(string colorId, string OCODE)
         {
             return objColor_Dal.GetColorInfoByColorId(colorId,OCODE);
         }
    }
}
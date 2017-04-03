using ERPSSL.Merchandising.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPSSL.Merchandising.BLL
{
    public class BodyPartBLL
    {
        BodyPartDAL _BodyPartBLL = new BodyPartDAL();
        internal int SaveBodyPart(LC_BodyPart _BodyParts)
        {
            return _BodyPartBLL.SaveBodyPart(_BodyParts);
        }

        internal List<LC_BodyPart> LoadBodyPartList(string OCode)
        {
            return _BodyPartBLL.LoadBodyPartList(OCode);
        }

        internal int UpdateBodyPart(LC_BodyPart _BodyParts)
        {
            return _BodyPartBLL.UpdateBodyPart(_BodyParts);
        }

        internal LC_BodyPart GetB_PartLById(int fqId)
        {
            return _BodyPartBLL.GetB_PartLById(fqId);
        }
    }
}
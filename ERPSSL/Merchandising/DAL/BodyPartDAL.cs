using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPSSL.Merchandising.DAL
{
    public class BodyPartDAL
    {
        ERPSSL_MerchandisingEntities _Context = new ERPSSL_MerchandisingEntities();

        internal int SaveBodyPart(LC_BodyPart _BodyParts)
        {
            _Context.LC_BodyPart.AddObject(_BodyParts);
            _Context.SaveChanges();
            return 1;
        }

        internal List<LC_BodyPart> LoadBodyPartList(string OCode)
        {
            try
            {
                List<LC_BodyPart> _BodyPart = (from fq in _Context.LC_BodyPart
                                             where fq.OCODE == OCode
                                             select fq).OrderBy(x => x.BodyPart).ToList();
                return _BodyPart;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal int UpdateBodyPart(LC_BodyPart _BodyParts)
        {
            try
            {
                LC_BodyPart _B_Parts = _Context.LC_BodyPart.FirstOrDefault(x => x.BPartId == _BodyParts.BPartId);

                _B_Parts.BodyPart = _BodyParts.BodyPart;
                _B_Parts.Edit_Date = DateTime.Now;
                _B_Parts.Edit_User = _BodyParts.Edit_User;
                _Context.SaveChanges();
                return 1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal LC_BodyPart GetB_PartLById(int fqId)
        {
            try
            {
                return (from br in _Context.LC_BodyPart
                        where br.BPartId == fqId
                        select br).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
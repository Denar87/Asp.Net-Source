using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ERPSSL.HRM.DAL;

namespace ERPSSL.HRM.BLL
{
    public class LatterFormatBLL
    {
        LatterFormatDAL latterFormateDal = new LatterFormatDAL();

        internal int SaveLatterFormate(HRM_LETTER_FORMAT latterForObj)
        {
            return latterFormateDal.SaveLatterFormate(latterForObj);
        }

        internal List<LatterFormate> getLatterFormates(string OCOde)
        {
            return latterFormateDal.getLatterFormates(OCOde);
        }

        internal List<HRM_LETTER_FORMAT> GetLatterFormateByLatterFormateID(string latterFormateId, string OCODE)
        {
            return latterFormateDal.getLatterFormates(latterFormateId, OCODE);
        }

        internal int UpdateLatterFormate(HRM_LETTER_FORMAT latterForObj, int latterId)
        {
            return latterFormateDal.UpdateLatterFormate(latterForObj, latterId);
        }

        internal List<HRM_LETTER_FORMAT> getLetterTitleByTypeId(int leterType)
        {
            return latterFormateDal.getLetterTitleByTypeId(leterType);
        }

        internal List<HRM_LETTER_FORMAT> GetLatterFormatemate(int lType, string aTitle, string OCODE)
        {
            return latterFormateDal.GetLatterFormatemate(lType, aTitle, OCODE);
        }

        internal int SaveLetterFormate(HRM_StoreLetter leterStoreobj)
        {
            return latterFormateDal.SaveLetterFormate(leterStoreobj);
        }

        internal List<HRM_StoreLetter> getData(int lid)
        {
            return latterFormateDal.getData(lid);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ERPSSL.HRM.DAL;

namespace ERPSSL.HRM.BLL
{
    public class LetterTypeBLL
    {
        LetterTypeDAL letterTypeDal = new LetterTypeDAL();

        internal int InsertLetterType(HRM_LetterType leterObj)
        {
            return letterTypeDal.InsertLetterType(leterObj);
        }

        internal int UpdateLetterType(HRM_LetterType leterObj, int letterTypeId)
        {
            return letterTypeDal.InsertLetterType(leterObj, letterTypeId);
        }

        internal List<HRM_LetterType> GetAllLetterTypes(string OCODE)
        {
            return letterTypeDal.GetAllLetterTypes(OCODE);
        }



        internal List<HRM_LetterType> GetLetterTypeById(string leterId, string OCODE)
        {
            return letterTypeDal.GetLetterTypeById(leterId,OCODE);
        }
    }
}
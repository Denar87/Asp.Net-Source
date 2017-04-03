using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPSSL.HRM.DAL
{
    public class LetterTypeDAL
    {
        private ERPSSLHBEntities _context = new ERPSSLHBEntities();
        internal int InsertLetterType(HRM_LetterType leterObj)
        {
            try
            {
                _context.HRM_LetterType.AddObject(leterObj);
                _context.SaveChanges();
                return 1;

            }
            catch (Exception)
            {

                throw;
            }
        }
        internal List<HRM_LetterType> GetAllLetterTypes(string OCODE)
        {
            try
            {
                var query = (from le in _context.HRM_LetterType
                             where le.OCODE == OCODE
                             select le).OrderBy(x => x.LatterTypeId);


                return query.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        internal List<HRM_LetterType> GetLetterTypeById(string leterId, string OCODE)
        {
            try
            {
                int lid = Convert.ToInt32(leterId);
                var query = (from le in _context.HRM_LetterType
                             where le.OCODE == OCODE && le.LatterTypeId == lid
                             select le).OrderBy(x => x.LatterTypeId);


                return query.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }


        }

        internal int InsertLetterType(HRM_LetterType leterObj, int letterTypeId)
        {
            HRM_LetterType leterTypeObj = _context.HRM_LetterType.First(x => x.LatterTypeId == letterTypeId);
            leterTypeObj.LatterType = leterObj.LatterType;
            leterTypeObj.OCODE = leterObj.OCODE;
            leterTypeObj.EDIT_USER = leterObj.EDIT_USER;
            leterTypeObj.EDIT_DATE = leterObj.EDIT_DATE;
            _context.SaveChanges();
            return 1;

        }
    }
}
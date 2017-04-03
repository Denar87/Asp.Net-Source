using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using ERPSSL.HRM.BLL;

namespace ERPSSL.HRM.DAL
{
    public class LatterFormatDAL
    {
        ERPSSLHBEntities _context = new ERPSSLHBEntities();
        internal int SaveLatterFormate(HRM_LETTER_FORMAT latterForObj)
        {
            try
            {
                _context.HRM_LETTER_FORMAT.AddObject(latterForObj);
                _context.SaveChanges();
                return 1;
            }
            catch (Exception)
            {

                throw;
            }
        }

        internal List<LatterFormate> getLatterFormates(string OCOde)
        {
            try
            {
                //var query = (from latterFormate in _context.HRM_LETTER_FORMAT
                //             where latterFormate.OCODE == OCOde
                //             select latterFormate).OrderByDescending(x => x.LTR_ID);


                using (var _context = new ERPSSLHBEntities())
                {
                    return (from lF in _context.HRM_LETTER_FORMAT
                            join Lt in _context.HRM_LetterType on lF.LTR_Type equals Lt.LatterTypeId

                            where lF.OCODE == OCOde
                            select new LatterFormate
                        {
                            LId = (int)lF.LTR_ID,

                            Title = lF.LTR_Title,
                            Type = Lt.LatterType

                        }).ToList();

                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }

        }

        internal List<HRM_LETTER_FORMAT> getLatterFormates(string latterFormateId, string OCODE)
        {
            try
            {
                int latterFId = Convert.ToInt32(latterFormateId);
                var query = (from latterFormate in _context.HRM_LETTER_FORMAT
                             where latterFormate.OCODE == OCODE && latterFormate.LTR_ID == latterFId
                             select latterFormate).OrderByDescending(x => x.LTR_ID);


                return query.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        internal int UpdateLatterFormate(HRM_LETTER_FORMAT latterForObj, int latterId)
        {
            HRM_LETTER_FORMAT latterFormateObj = _context.HRM_LETTER_FORMAT.First(x => x.LTR_ID == latterId);
            latterForObj.LTR_Title = latterForObj.LTR_Title;
            latterForObj.LTR_Type = latterForObj.LTR_Type;
            latterFormateObj.LTR_Details = latterForObj.LTR_Details;
            latterFormateObj.EDIT_DATE = latterForObj.EDIT_DATE;
            latterFormateObj.EDIT_USER = latterForObj.EDIT_USER;
            latterFormateObj.OCODE = latterForObj.OCODE;
            _context.SaveChanges();
            return 1;
        }

        internal List<HRM_LETTER_FORMAT> getLetterTitleByTypeId(int leterType)
        {
            var query = (from latterFormate in _context.HRM_LETTER_FORMAT
                         where latterFormate.LTR_Type == leterType
                         select latterFormate).OrderBy(x => x.LTR_ID);


            return query.ToList();

        }

        internal List<HRM_LETTER_FORMAT> GetLatterFormatemate(int lType, string aTitle, string OCODE)
        {
            try
            {
               
                var query = (from latterFormate in _context.HRM_LETTER_FORMAT
                             where latterFormate.OCODE == OCODE && latterFormate.LTR_Type == lType && latterFormate.LTR_Title == aTitle
                             select latterFormate).OrderBy(x => x.LTR_ID);


                return query.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        internal int SaveLetterFormate(HRM_StoreLetter leterStoreobj)
        {
            try
            {
                _context.HRM_StoreLetter.AddObject(leterStoreobj);
                _context.SaveChanges();
                return 1;
            }
            catch (Exception)
            {

                throw;
            }

        }

        //using (var _context = new ERPSSLHBEntities())
        //        {
        //            var ParamempID = new SqlParameter("@OCODE", OCODE);

        //            string SP_SQL = "HRM_EmployesList @OCODE";

        //            return (_context.ExecuteStoreQuery<REmployee>(SP_SQL, ParamempID)).ToList();
        //        }

        internal List<HRM_StoreLetter> getData(int lid)
        {
            try
            {
                using (var _context = new ERPSSLHBEntities())
                {

                    var ParamempID = new SqlParameter("@id", lid);
                    string SP_SQL = "HRM_GetEmployeeLatterById @id";
                    return (_context.ExecuteStoreQuery<HRM_StoreLetter>(SP_SQL, ParamempID)).ToList();
                }

            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}
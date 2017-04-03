using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ERPSSL.HRM.DAL;
using ERPSSL.HRM;
using System.Data.SqlClient;
using ERPSSL.HRM.DAL.Repository;

namespace ERPSSL.HRM.DAL
{
    public class SECTION_DAL
    {
        private ERPSSLHBEntities _context = new ERPSSLHBEntities();

        //-------Insert------------------------------------
        public int InsertSection(HRM_SECTIONS objSec)
        {
            try
            {
                _context.HRM_SECTIONS.AddObject(objSec);
                _context.SaveChanges();
                return 1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //-------Update------------------------------------
        public int UpdateSection(HRM_SECTIONS objSec, int sectionID)
        {
            try
            {
                HRM_SECTIONS obj = _context.HRM_SECTIONS.First(x => x.SEC_ID == sectionID);
                obj.SEC_NAME = objSec.SEC_NAME;
                obj.DPT_ID = objSec.DPT_ID;
                obj.RegionID = objSec.RegionID;
                obj.OfficeID = objSec.OfficeID;

                obj.EDIT_USER = objSec.EDIT_USER;
                obj.EDIT_DATE = objSec.EDIT_DATE;

                _context.SaveChanges();
                return 1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //-------Delete------------------------------------
        public int DeleteSection(int sectionID)
        {
            try
            {
                HRM_SECTIONS objSec = _context.HRM_SECTIONS.First(x => x.SEC_ID == sectionID);
                _context.HRM_SECTIONS.DeleteObject(objSec);
                _context.SaveChanges();
                return 1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //-------GetAll------------------------------------
        public virtual List<HRM_SECTIONS> GetAllSection(string OCODE)
        {
            var query = (from sec in _context.HRM_SECTIONS
                         where sec.OCODE == OCODE
                         select sec).OrderBy(sec => sec.SEC_ID);

            var list = query.ToList();
            return list;
        }

        //-------SelectByID------------------------------------
        public virtual List<HRM_SECTIONS> SelectByID(int departmentID, string OCODE)
        {
            try
            {
                var query = (from sec in _context.HRM_SECTIONS
                             where sec.DPT_ID == departmentID && sec.OCODE == OCODE
                             select sec).OrderBy(sec => sec.SEC_ID);

                var list = query.ToList();
                return list;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal List<HRM_SECTIONS> UpdateSection(string OCODE)
        {
            try
            {
                var query = (from off in _context.HRM_SECTIONS
                             where off.OCODE == OCODE
                             select off).OrderBy(x => x.SEC_ID);


                return query.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }



        }

        internal IEnumerable<Section> GetSections(string OCODE)
        {
            using (var _context = new ERPSSLHBEntities())
            {
                var ParamempID = new SqlParameter("@OCODE", OCODE);

                string SP_SQL = "HRM_GetSectionList @OCODE";

                return (_context.ExecuteStoreQuery<Section>(SP_SQL, ParamempID)).ToList();
            }

        }

        internal HRM_SECTIONS GetSctionBySectionId(string sectionId, string OCODE)
        {
            int Section = Convert.ToInt32(sectionId);
            HRM_SECTIONS dep = _context.HRM_SECTIONS.First(x => x.SEC_ID == Section);
            return dep;
        }

        internal List<HRM_SECTIONS> GetSectionsByDepartmentIdAndOCode(int? departmentId, string OCODE)
        {

            try
            {
                var query = (from off in _context.HRM_SECTIONS
                             where off.OCODE == OCODE && off.DPT_ID == departmentId
                             select off).OrderBy(x => x.SEC_NAME);


                return query.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }


        }

        internal List<HRM_SECTIONS> GetSectionByDepartmentId(int departmentId, string OCODE)
        {
            try
            {
                var query = (from off in _context.HRM_SECTIONS
                             where off.OCODE == OCODE && off.DPT_ID == departmentId
                             select off).OrderBy(x => x.SEC_ID);


                return query.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }

        }
    }
}
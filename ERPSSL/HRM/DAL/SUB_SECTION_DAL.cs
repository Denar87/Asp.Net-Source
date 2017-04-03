using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ERPSSL.HRM.DAL;
using ERPSSL.HRM.DAL.Repository;
using System.Data.SqlClient;

namespace ERPSSL.HRM.DAL
{
    public class SUB_SECTION_DAL
    {
        private ERPSSLHBEntities _context = new ERPSSLHBEntities();

        //-------Insert------------------------------------
        public int InsertSub_Section(HRM_SUB_SECTIONS objS_Sec)
        {
            try
            {
                _context.HRM_SUB_SECTIONS.AddObject(objS_Sec);
                _context.SaveChanges();
                return 1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //-------Update------------------------------------
        public int UpdateSub_Section(HRM_SUB_SECTIONS objS_Sec, int subsectionID)
        {
            try
            {
                HRM_SUB_SECTIONS obj = _context.HRM_SUB_SECTIONS.First(x => x.SUB_SEC_ID == subsectionID);
                obj.SUB_SEC_NAME = objS_Sec.SUB_SEC_NAME;
                obj.SEC_ID = objS_Sec.SEC_ID;
                obj.RegionID = objS_Sec.RegionID;
                obj.OfficeID = objS_Sec.OfficeID;
                obj.DepartmentID = objS_Sec.DepartmentID;
                obj.EDIT_USER = objS_Sec.EDIT_USER;
                obj.EDIT_DATE = objS_Sec.EDIT_DATE;
                obj.OCODE = objS_Sec.OCODE;

                _context.SaveChanges();
                return 1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //-------Delete------------------------------------
        public int DeleteSub_Section(int subsectionID)
        {
            try
            {
                HRM_SUB_SECTIONS objSec = _context.HRM_SUB_SECTIONS.First(x => x.SUB_SEC_ID == subsectionID);
                _context.HRM_SUB_SECTIONS.DeleteObject(objSec);
                _context.SaveChanges();
                return 1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //-------GetAll------------------------------------
        public virtual List<HRM_SUB_SECTIONS> GetAllSub_Section(string OCODE)
        {
            var query = (from ssec in _context.HRM_SUB_SECTIONS
                         where ssec.OCODE == OCODE
                         select ssec).OrderBy(ssec => ssec.SUB_SEC_ID);

            var list = query.ToList();
            return list;
        }

        //-------SelectByID------------------------------------
        public virtual List<HRM_SUB_SECTIONS> SelectByID(int sectionID, string OCODE)
        {
            var query = (from sec in _context.HRM_SUB_SECTIONS
                         where sec.SEC_ID == sectionID && sec.OCODE == OCODE
                         select sec).OrderBy(sec => sec.SUB_SEC_ID);

            var list = query.ToList();
            return list;

        }


        internal IEnumerable<SubSection> GetSub_Sections(string OCODE)
        {
            using (var _context = new ERPSSLHBEntities())
            {
                var ParamempID = new SqlParameter("@OCODE", OCODE);

                string SP_SQL = "HRM_GetSubSectionList @OCODE";

                return (_context.ExecuteStoreQuery<SubSection>(SP_SQL, ParamempID)).ToList();
            }
        }

        internal HRM_SUB_SECTIONS GetSubSectionById(string subSectionID, string OCODE)
        {
            int subSection = Convert.ToInt32(subSectionID);
            HRM_SUB_SECTIONS SubSction = _context.HRM_SUB_SECTIONS.First(x => x.SUB_SEC_ID == subSection);
            return SubSction;
        }

        internal List<HRM_SUB_SECTIONS> GetSubSectionsBySectionIdAndOCode(int sectionId, string OCODE)
        {
            try
            {
                var query = (from sec in _context.HRM_SUB_SECTIONS
                             where sec.SEC_ID == sectionId && sec.OCODE == OCODE
                             select sec).OrderBy(sec => sec.SUB_SEC_NAME);

                var list = query.ToList();
                return list;

            }
            catch (Exception)
            {
                
                throw;
            }
        }

        internal int DleteSubSectionById(string subSectionID, string OCODE)
        {
            int subsctionId=Convert.ToInt16(subSectionID);

            HRM_SUB_SECTIONS subSection = _context.HRM_SUB_SECTIONS.First(i => i.SUB_SEC_ID == subsctionId);
            _context.HRM_SUB_SECTIONS.DeleteObject(subSection);
            _context.SaveChanges();
            return 1;
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
        internal List<HRM_SUB_SECTIONS> GetSubSectionsBySectionIdAndOCode(int? sectionId, string OCODE)
        {
            try
            {
                var query = (from sec in _context.HRM_SUB_SECTIONS
                             where sec.SEC_ID == sectionId && sec.OCODE == OCODE
                             select sec).OrderBy(sec => sec.SUB_SEC_NAME);

                var list = query.ToList();
                return list;

            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
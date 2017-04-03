using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ERPSSL.HRM.DAL;
using ERPSSL.HRM.DAL;
using ERPSSL.HRM.DAL.Repository;

namespace ERPSSL.HRM.BLL
{
    public class SUB_SECTION_BLL
    {
        SUB_SECTION_DAL objCtx_DAL = new SUB_SECTION_DAL();

        //-------Insert------------------------------------
        public int InsertSub_Section(HRM_SUB_SECTIONS objS_Sec)
        {
            return objCtx_DAL.InsertSub_Section(objS_Sec);
        }

        //-------Update------------------------------------
        public int UpdateSub_Section(HRM_SUB_SECTIONS objS_Sec, int subsectionID)
        {
            return objCtx_DAL.UpdateSub_Section(objS_Sec, subsectionID);
        }

        //-------Delete------------------------------------
        public int DeleteSub_Section(int subsectionID)
        {
            return objCtx_DAL.DeleteSub_Section(subsectionID);
        }

        //-------GetAll------------------------------------
        public virtual List<HRM_SUB_SECTIONS> GetAllSub_Section(string OCODE)
        {
            return objCtx_DAL.GetAllSub_Section(OCODE);
        }

        //-------SelectByID------------------------------------
        public virtual List<HRM_SUB_SECTIONS> SelectByID(int sectionID, string OCODE)
        {
            return objCtx_DAL.SelectByID(sectionID, OCODE);
        }

        internal IEnumerable<SubSection> GetSub_Sections(string OCODE)
        {
            return objCtx_DAL.GetSub_Sections(OCODE);
        }

        internal HRM_SUB_SECTIONS GetSubSectionById(string subSectionID, string OCODE)
        {
            return objCtx_DAL.GetSubSectionById(subSectionID, OCODE);
        }

        internal List<HRM_SUB_SECTIONS> GetSubSectionsBySectionIdAndOCode(int sectionId, string OCODE)
        {
            return objCtx_DAL.GetSubSectionsBySectionIdAndOCode(sectionId, OCODE);
        }
        
        internal int DleteSubSectionById(string OCODE, string subSectionID)
        {
            return objCtx_DAL.DleteSubSectionById(subSectionID, OCODE);
        }
        internal List<HRM_SECTIONS> GetSectionsByDepartmentIdAndOCode(int? departmentId, string OCODE)
        {
            return objCtx_DAL.GetSectionsByDepartmentIdAndOCode(departmentId, OCODE);
        }

        internal List<HRM_SUB_SECTIONS> GetSubSectionsBySectionIdAndOCode(int? sectionId, string OCODE)
        {
            return objCtx_DAL.GetSubSectionsBySectionIdAndOCode(sectionId, OCODE);
        }
    }
}
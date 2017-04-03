using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ERPSSL.HRM.DAL;
using ERPSSL.HRM.DAL;
using ERPSSL.HRM;
using ERPSSL.HRM.DAL.Repository;

namespace ERPSSL.HRM.BLL
{
    public class SECTION_BLL
    {
        SECTION_DAL objCtx_DAL = new SECTION_DAL();

        //-------Insert------------------------------------
        public int InsertSection(HRM_SECTIONS objSec)
        {
            return objCtx_DAL.InsertSection(objSec);
        }

        //-------Update------------------------------------
        public int UpdateSection(HRM_SECTIONS objSec, int sectionID)
        {
            return objCtx_DAL.UpdateSection(objSec, sectionID);

        }

        //-------Delete------------------------------------
        public int DeleteSection(int sectionID)
        {
            return objCtx_DAL.DeleteSection(sectionID);
        }

        //-------GetAll------------------------------------
        public virtual List<HRM_SECTIONS> GetAllSection(string OCODE)
        {

            return objCtx_DAL.GetAllSection(OCODE);
        }

        //-------SelectByID------------------------------------
        public virtual List<HRM_SECTIONS> SelectByID(int departmentID, string OCODE)
        {
            return objCtx_DAL.SelectByID(departmentID, OCODE);
        }

        internal int SaveSection(HRM_SECTIONS objsection)
        {
            return objCtx_DAL.InsertSection(objsection);
        }

        internal int UpdateOffice(HRM_SECTIONS objsection, int sectionId)
        {
            return objCtx_DAL.UpdateSection(objsection, sectionId);
        }

        internal IEnumerable<Section> GetSections(string OCODE)
        {
            return objCtx_DAL.GetSections(OCODE);
        }

        internal HRM_SECTIONS GetSctionBySectionId(string deparId, string OCODE)
        {
            return objCtx_DAL.GetSctionBySectionId(deparId, OCODE);
        }

        internal List<HRM_SECTIONS> GetSectionsByDepartmentIdAndOCode(int? departmentId, string OCODE)
        {
            return objCtx_DAL.GetSectionsByDepartmentIdAndOCode(departmentId, OCODE);
        }



        internal List<HRM_SECTIONS> GetSectionByDepartmentId(string OCODE, int departmentId)
        {
            return objCtx_DAL.GetSectionByDepartmentId(departmentId, OCODE);
        }
    }
}
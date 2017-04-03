using ERPSSL.INV.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ERPSSL.INV.DAL
{
    public class DepartmentTypeDAL
    {
        private ERPSSL_INVEntities _context = new ERPSSL_INVEntities();

        internal IEnumerable<RDepartmentType> GetDepartmentType(string OCODE)
        {
            using (var _context = new ERPSSL_INVEntities())
            {
                var ParamempID = new SqlParameter("@OCODE", OCODE);

                string SP_SQL = "Inv_GetDepartmentType @OCODE";

                return (_context.ExecuteStoreQuery<RDepartmentType>(SP_SQL, ParamempID)).ToList();
            }

        }

        internal Inv_DepartmentType GetDepartmentByDepartmentId(string deparId, string OCODE)
        {
            int DepId = Convert.ToInt32(deparId);
            Inv_DepartmentType dep = _context.Inv_DepartmentType.First(x => x.DepartmentTypeId == DepId);
            return dep;
        }

        internal int InsertDepartment(Inv_DepartmentType objDepartment)
        {

            try
            {
                _context.Inv_DepartmentType.AddObject(objDepartment);
                _context.SaveChanges();
                return 1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal int UpdateDepartment(Inv_DepartmentType objDepartment, int DepartmentId)
        {

            try
            {
                Inv_DepartmentType obj = _context.Inv_DepartmentType.First(x => x.DepartmentTypeId == DepartmentId);
                obj.DPT_NAME = objDepartment.DPT_NAME;
                obj.DPT_CODE = objDepartment.DPT_CODE;
                obj.EDIT_USER = objDepartment.EDIT_USER;
                obj.EDIT_DATE = objDepartment.EDIT_DATE;
                obj.Office_ID = objDepartment.Office_ID;
                obj.ResionId = objDepartment.ResionId;
                obj.DepartmentType = objDepartment.DepartmentType;
                _context.SaveChanges();
                return 1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal List<HRM_Regions> GetAllDepartmentResion(string OCODE)
        {

            try
            {
                var query = (from dept in _context.HRM_Regions
                             where dept.OCODE == OCODE
                             select dept).OrderByDescending(x => x.RegionID);


                return query.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        internal HRM_Office GetOfficeCodeByOfficeId(int officeId)
        {

            int ofId = Convert.ToInt32(officeId);
            HRM_Office office = _context.HRM_Office.First(x => x.OfficeID == ofId);
            return office;
        }

        internal List<HRM_Office> GetOfficeByResionId(int ResionId)
        {

            try
            {
                var query = (from off in _context.HRM_Office
                             where off.RegionId == ResionId
                             select off).OrderByDescending(x => x.RegionId);


                return query.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }

        }
    }
}
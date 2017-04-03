using ERPSSL.INV.DAL;
using ERPSSL.INV.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPSSL.INV.BLL
{
    public class DepartmentTypeBLL
    {
        DepartmentTypeDAL departmentTypeDal = new DepartmentTypeDAL();
        internal IEnumerable<RDepartmentType> GetDepartmentType(string OCODE)
        {

            return departmentTypeDal.GetDepartmentType(OCODE);
        }



        internal Inv_DepartmentType GetDepartmentByDepartmentId(string deparId, string OCODE)
        {
            return departmentTypeDal.GetDepartmentByDepartmentId(deparId, OCODE);

        }

        internal int InsertDepartment(Inv_DepartmentType objDepartment)
        {
            return departmentTypeDal.InsertDepartment(objDepartment);

        }

        internal int UpdateDepartment(Inv_DepartmentType objDepartment, int DepartmentId)
        {

            return departmentTypeDal.UpdateDepartment(objDepartment, DepartmentId);
        }

        internal List<HRM_Regions> GetAllDepartmentResion(string OCODE)
        {
            return departmentTypeDal.GetAllDepartmentResion(OCODE);
        }

        internal HRM_Office GetOfficeCodeByOfficeId(int officeId)
        {
            return departmentTypeDal.GetOfficeCodeByOfficeId(officeId);

        }

        internal List<HRM_Office> GetOfficeByResionId(int ResionId)
        {

            return departmentTypeDal.GetOfficeByResionId(ResionId);
        }
    }
}
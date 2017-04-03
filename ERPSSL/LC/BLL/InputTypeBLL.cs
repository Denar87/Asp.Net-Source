using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ERPSSL.LC.DAL;
using ERPSSL.HRM.DAL;

namespace ERPSSL.LC.BLL
{
    public class InputTypeBLL
    {
        InputTypeDAL InputTypeDal = new InputTypeDAL();

        internal List<LC_Input_Department> GetDepartment(string Ocode)
        {
            return InputTypeDal.GetDepartment(Ocode);
        }

        internal LC_InputType GetInputByID(int inputID)
        {
            return InputTypeDal.GetInputByID(inputID);
        }

        internal int InsertInputType(LC_InputType InputTypeObj)
        {
            return InputTypeDal.InsertInputType(InputTypeObj);
        }
        internal int InsertInputDepartment(LC_Input_Department InputDeptObj)
        {
            return InputTypeDal.InsertInputDepartment(InputDeptObj);
        }
        internal int UpdateInputType(LC_InputType InputTypeObj, int itemID)
        {
            return InputTypeDal.UpdateInputType(InputTypeObj, itemID);
        }

        internal List<LC_InputType> GetALLInputType(string OCode)
        {
            return InputTypeDal.GetALLInputType(OCode);
        }

        internal List<LC_InputType> GetallDeptByDeptName(string Dept)
        {
            return InputTypeDal.GetallDeptByDeptName(Dept);
        }

        internal List<LC_InputType> GetALLTask(string OCode)
        {
            return InputTypeDal.GetALLTask(OCode);
        }

        internal List<LC_InputType> GetALLProductionProcess(string OCode)
        {
            return InputTypeDal.GetALLProductionProcess(OCode);
        }
    }
}
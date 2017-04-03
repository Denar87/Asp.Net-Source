using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ERPSSL.HRM.DAL;

namespace ERPSSL.LC.DAL
{
    public class InputTypeDAL
    {
        internal List<LC_Input_Department> GetDepartment(string Ocode)
        {
            try
            {
                using (var context = new ERPSSL_LCEntities())
                {

                    List<LC_Input_Department> buyers = (from dept in context.LC_Input_Department
                                                        where dept.OCODE == Ocode
                                                        select dept).OrderBy(x => x.InputDept_NAME).ToList();
                    return buyers;
                }
            }
            catch (Exception)
            {

                throw;
            }

        }

        internal LC_InputType GetInputByID(int inputID)
        {

            try
            {
                using (var context = new ERPSSL_LCEntities())
                {
                    return (from i in context.LC_InputType
                            where i.InputType_Id == inputID
                            select i).FirstOrDefault();
                }
            }
            catch (Exception)
            {

                throw;
            }

        }

        internal int InsertInputType(LC_InputType InputTypeObj)
        {

            try
            {
                using (var context = new ERPSSL_LCEntities())
                {
                    context.LC_InputType.AddObject(InputTypeObj);
                    context.SaveChanges();
                    return 1;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }

        }

        internal int UpdateInputType(LC_InputType InputTypeObj, int itemID)
        {

            try
            {
                using (var Context = new ERPSSL_LCEntities())
                {
                    LC_InputType ObjLC_MasterLC = Context.LC_InputType.FirstOrDefault(x => x.InputType_Id == itemID);
                    ObjLC_MasterLC.Use_Dept = InputTypeObj.Use_Dept;
                    ObjLC_MasterLC.Input_Name = InputTypeObj.Input_Name;
                    ObjLC_MasterLC.Sl_No = InputTypeObj.Sl_No;

                    Context.SaveChanges();
                    return 1;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }

        }

        internal List<LC_InputType> GetALLInputType(string OCode)
        {

            try
            {
                using (var Context = new ERPSSL_LCEntities())
                {
                    var query = (from i in Context.LC_InputType
                                 where i.OCode == OCode
                                 select i).OrderBy(x => x.InputType_Id);
                    return query.ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }

        }

        internal int InsertInputDepartment(LC_Input_Department InputDeptObj)
        {

            try
            {
                using (var context = new ERPSSL_LCEntities())
                {
                    context.LC_Input_Department.AddObject(InputDeptObj);
                    context.SaveChanges();
                    return 1;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }

        }

        internal List<LC_InputType> GetallDeptByDeptName(string Dept)
        {

            try
            {
                using (var Context = new ERPSSL_LCEntities())
                {
                    var query = (from i in Context.LC_InputType
                                 where i.Use_Dept == Dept
                                 select i).OrderBy(x => x.InputType_Id);
                    return query.ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }

        }

        internal List<LC_InputType> GetALLTask(string OCode)
        {

            try
            {
                using (var Context = new ERPSSL_LCEntities())
                {
                    var query = (from i in Context.LC_InputType
                                 where i.OCode == OCode && i.Use_Dept == "Task"
                                 select i).OrderBy(x => x.Sl_No);
                    return query.ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }

        }
        internal List<LC_InputType> GetALLProductionProcess(string OCode)
        {

            try
            {
                using (var Context = new ERPSSL_LCEntities())
                {
                    var query = (from i in Context.LC_InputType
                                 where i.OCode == OCode && i.Use_Dept == "Production Process"
                                 select i).OrderBy(x => x.Sl_No);
                    return query.ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }

        }
    }
}
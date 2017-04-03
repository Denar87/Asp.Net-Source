using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ERPSSL.HRM.BLL;
using System.Data.SqlClient;
using ERPSSL.HRM.DAL;

namespace ERPSSL.HRM.DAL
{
    public class REPORTING_DAL
    {
        private ERPSSLHBEntities _context = new ERPSSLHBEntities();

        //-------GetAll------------------------------------
        public IEnumerable<HRM_EMP_ID_VIEW> generate_IdCard(string eId, string OCODE)
        {
            //try
            //{
            //    return (from emp in _context.HRM_EMPLOYEES
            //            join d in _context.HRM_DEPARTMENTS on emp.DPT_ID equals d.DPT_ID
            //            join s in _context.HRM_SECTIONS on emp.SEC_ID equals s.SEC_ID
            //            join ss in _context.HRM_SUB_SECTIONS on emp.SUB_SEC_ID equals ss.SUB_SEC_ID
            //            join dg in _context.HRM_DESIGNATIONS on emp.DEG_ID equals dg.DEG_ID
            //            join grd in _context.HRM_GRADE on emp.GRADE_ID equals grd.GRADE_ID

            //            where emp.EID == eId && emp.OCODE == OCODE

            //            select new HRM_EMP_ID_VIEW
            //            {
            //                DPT_NAME = d.DPT_NAME,
            //                SEC_NAME = s.SEC_NAME,
            //                SUB_SEC_NAME = ss.SUB_SEC_NAME,
            //                DEG_NAME = dg.DEG_NAME,
            //                GRADE = grd.GRADE,
            //                AVATER = emp.EMP_PHOTO,
            //                SEX = emp.EMP_SEX,
            //                EMP_FULLNAME = emp.EMP_TITLE + " " + emp.EMP_FIRSTNAME + " " + emp.EMP_LASTNAME,
            //                EMP_DOB = (DateTime)emp.EMP_DOB,
            //                EMP_CONTACT_NO = emp.EMP_CONTACT_NO

            //            }).ToList();
            //}
            //catch (Exception ex)
            //{
            //    throw ex;
            //}

            try
            {
                return (from emp in _context.HRM_PersonalInformations
                        join d in _context.HRM_DEPARTMENTS on emp.DepartmentId equals d.DPT_ID
                        join s in _context.HRM_SECTIONS on emp.SectionId equals s.SEC_ID
                        join ss in _context.HRM_SUB_SECTIONS on emp.SubSectionId equals ss.SUB_SEC_ID
                        join dg in _context.HRM_DESIGNATIONS on emp.DesginationId equals dg.DEG_ID
                        join com in _context.HRM_Company on emp.OCODE equals com.OCODE
                        join office in _context.HRM_Office on emp.OCODE equals office.OCODE


                        //join grd in _context.HRM_GRADE on emp.GradeId equals grd.GRADE_ID

                        where emp.EID == eId && emp.OCODE == OCODE

                        select new HRM_EMP_ID_VIEW
                        { 
                            DPT_NAME = d.DPT_NAME,
                            SEC_NAME = s.SEC_NAME,
                            SUB_SEC_NAME = ss.SUB_SEC_NAME,
                            DEG_NAME = dg.DEG_NAME,
                            //GRADE = grd.GRADE,
                            AVATER = emp.EMP_PHOTO,
                            SEX = emp.Gender,
                            EMP_FULLNAME = emp.FirstName + " " + emp.LastName,
                            FIRSTNAME = emp.FirstName,
                            LASTNAME = emp.LastName,
                            BloodGroup = emp.BloodGroup,
                            EMP_DOB = (DateTime)emp.DateOfBrith,
                            EMP_CONTACT_NO = emp.ContactNumber,
                            NAME = com.Name,
                            ADDRESS = com.Address,
                            MOBILE = com.Mobile,
                            PHONE = com.Phone,
                            EMAIL = com.Email,
                            WEB = com.Web,
                            LOGO = com.Logo,
                            OfficeName = office.OfficeName,
                            JoinningDate = (DateTime)emp.JoiningDate,
                            EID = emp.EID,
                            COMPANYNAME=com.Name,
                            EMP_SIGN = emp.EMP_Singnature


                        }).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<RPT_EMP_CERTIFICATION> rpt_employeeCertification(string eId, string OCODE)
        {
            try
            {
                using (var _context = new ERPSSLHBEntities())
                {
                    var ParamEID = new SqlParameter
                    {
                        ParameterName = "@EID",
                        Value = eId
                    };
                    var ParamOCODE = new SqlParameter
                    {
                        ParameterName = "@OCODE",
                        Value = OCODE
                    };
                    return (_context.ExecuteStoreQuery<RPT_EMP_CERTIFICATION>("RPT_EMPLOYEE_CERTIFICATION_SP @EID,@OCODE", ParamEID, ParamOCODE)).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        public List<RPT_EMP_APPOINMENT> rpt_employeeAppoinment(string eId, string OCODE)
        {
            try
            {
                using (var _context = new ERPSSLHBEntities())
                {
                    var ParamEID = new SqlParameter
                    {
                        ParameterName = "@EID",
                        Value = eId
                    };
                    var ParamOCODE = new SqlParameter
                    {
                        ParameterName = "@OCODE",
                        Value = OCODE
                    };
                    return (_context.ExecuteStoreQuery<RPT_EMP_APPOINMENT>("RPT_EMPLOYEE_APPOINTMENT_SP @EID,@OCODE", ParamEID, ParamOCODE)).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        public List<HR_DEMAND> rpt_HR_Demand(string dFrom, string dTo, string OCODE)
        {
            try
            {
                using (var _context = new ERPSSLHBEntities())
                {
                    var ParamsaldFrom = new SqlParameter("DATE_FROM", dFrom);
                    var ParamsaldTo = new SqlParameter("DATE_TO", dTo);
                    var ParamsalOCODE = new SqlParameter("OCODE", OCODE);

                    string SP_SQL = "RPT_HR_DEMAND @DATE_FROM, @DATE_TO , @OCODE";
                    return (_context.ExecuteStoreQuery<HR_DEMAND>(SP_SQL, ParamsaldFrom, ParamsaldTo, ParamsalOCODE)).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        public List<SERVICE_EVALUATION> rpt_ServiceEvaluation(string dFrom, string dTo, string OCODE)
        {
            try
            {
                using (var _context = new ERPSSLHBEntities())
                {
                    var ParamsaldFrom = new SqlParameter("DATE_FROM", dFrom);
                    var ParamsaldTo = new SqlParameter("DATE_TO", dTo);
                    var ParamsalOCODE = new SqlParameter("OCODE", OCODE);

                    string SP_SQL = "RPT_SERVICE_EVALUATION @DATE_FROM, @DATE_TO , @OCODE";
                    return (_context.ExecuteStoreQuery<SERVICE_EVALUATION>(SP_SQL, ParamsaldFrom, ParamsaldTo, ParamsalOCODE)).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        public List<RPT_EMP_PREVIEW> rpt_EmployeePreview(Int64 QueryStringId, string OCODE)
        {
            try
            {
                using (var _context = new ERPSSLHBEntities())
                {
                    var ParamEmpID = new SqlParameter
                    {
                        ParameterName = "@EMP_ID",
                        Value = QueryStringId
                    };
                    var ParamOCODE = new SqlParameter
                    {
                        ParameterName = "@OCODE",
                        Value = OCODE
                    };
                    return (_context.ExecuteStoreQuery<RPT_EMP_PREVIEW>("RPT_EMPLOYEE_PREVIEW @EMP_ID,@OCODE", ParamEmpID, ParamOCODE)).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        //------WorkSheet--------------------
        public List<WORK_SHEET> rpt_WorkSheet(string dFrom, string dTo, string OCODE)
        {
            try
            {
                using (var _context = new ERPSSLHBEntities())
                {
                    var ParamsaldFrom = new SqlParameter("DATE_FROM", dFrom);
                    var ParamsaldTo = new SqlParameter("DATE_TO", dTo);
                    var ParamsalOCODE = new SqlParameter("OCODE", OCODE);

                    string SP_SQL = "RPT_WORK_SHEET @DATE_FROM, @DATE_TO , @OCODE";
                    return (_context.ExecuteStoreQuery<WORK_SHEET>(SP_SQL, ParamsaldFrom, ParamsaldTo, ParamsalOCODE)).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        public List<RPT_EMP_LEAVE> rpt_Leave_Application(Int64 QueryStringId, string OCODE)
        {
            try
            {
                using (var _context = new ERPSSLHBEntities())
                {
                    var ParamEld = new SqlParameter("EMP_ID", QueryStringId);
                    var ParamsalOCODE = new SqlParameter("OCODE", OCODE);

                    string SP_SQL = "RPT_EMPLOYEE_LEAVE @EMP_ID, @OCODE";
                    return (_context.ExecuteStoreQuery<RPT_EMP_LEAVE>(SP_SQL, ParamEld, ParamsalOCODE)).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }
        public IEnumerable<HRM_EMP_ID_VIEW> generate_IdCardEMP(string eId, string OCODE)
        {
            //try
            //{
            //    return (from emp in _context.HRM_PersonalInformations
            //            join d in _context.HRM_DEPARTMENTS on emp.DepartmentId equals d.DPT_ID
            //            join s in _context.HRM_SECTIONS on emp.SectionId equals s.SEC_ID
            //            join ss in _context.HRM_SUB_SECTIONS on emp.SubSectionId equals ss.SUB_SEC_ID
            //            join dg in _context.HRM_DESIGNATIONS on emp.DesginationId equals dg.DEG_ID
            //            //join grd in _context.HRM_GRADE on emp.GradeId equals grd.GRADE_ID

            //            where emp.EID == eId && emp.OCODE == OCODE

            //            select new HRM_EMP_ID_VIEW
            //            {
            //                DPT_NAME = d.DPT_NAME,
            //                SEC_NAME = s.SEC_NAME,
            //                SUB_SEC_NAME = ss.SUB_SEC_NAME,
            //                DEG_NAME = dg.DEG_NAME,
            //                //GRADE = grd.GRADE,
            //                AVATER = emp.EMP_PHOTO,
            //                SEX = emp.Gender,
            //                EMP_FULLNAME = emp.FirstName + " " + emp.LastName,
            //                EMP_DOB = (DateTime)emp.DateOfBrith,
            //                EMP_CONTACT_NO = emp.ContactNumber

            //            }).ToList();
            //}
            //catch (Exception ex)
            //{
            //    throw ex;
            //}

            try
            {
                return (from emp in _context.HRM_PersonalInformations
                        join d in _context.HRM_DEPARTMENTS on emp.DepartmentId equals d.DPT_ID
                        join s in _context.HRM_SECTIONS on emp.SectionId equals s.SEC_ID
                        join ss in _context.HRM_SUB_SECTIONS on emp.SubSectionId equals ss.SUB_SEC_ID
                        join dg in _context.HRM_DESIGNATIONS on emp.DesginationId equals dg.DEG_ID
                        join com in _context.HRM_Company on emp.OCODE equals com.OCODE
                        join office in _context.HRM_Office on emp.OCODE equals office.OCODE


                        //join grd in _context.HRM_GRADE on emp.GradeId equals grd.GRADE_ID

                        where emp.EID == eId && emp.OCODE == OCODE

                        select new HRM_EMP_ID_VIEW
                        { 
                            DPT_NAME = d.DPT_NAME,
                            SEC_NAME = s.SEC_NAME,
                            SUB_SEC_NAME = ss.SUB_SEC_NAME,
                            DEG_NAME = dg.DEG_NAME,
                            //GRADE = grd.GRADE,
                            AVATER = emp.EMP_PHOTO,
                            SEX = emp.Gender,
                            EMP_FULLNAME = emp.FirstName + " " + emp.LastName,
                            FIRSTNAME = emp.FirstName,
                            LASTNAME = emp.LastName,
                            BloodGroup = emp.BloodGroup,
                            EMP_DOB = (DateTime)emp.DateOfBrith,
                            EMP_CONTACT_NO = emp.ContactNumber,
                            NAME = com.Name,
                            ADDRESS = com.Address,
                            MOBILE = com.Mobile,
                            PHONE = com.Phone,
                            EMAIL = com.Email,
                            WEB = com.Web,
                            LOGO = com.Logo,
                            OfficeName = office.OfficeName,
                            JoinningDate = (DateTime)emp.JoiningDate,
                            EID = emp.EID,
                            COMPANYNAME=com.Name,
                            EMP_SIGN=emp.EMP_Singnature
                            




                        }).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
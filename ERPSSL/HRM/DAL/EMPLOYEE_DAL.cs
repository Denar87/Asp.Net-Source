using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ERPSSL.HRM.BLL;
using System.Data.SqlClient;
using System.Data;
using ERPSSL;
using ERPSSL.HRM.DAL;
using ERPSSL.HRM.DAL.Repository;
using ERPSSL.Dashboard.Repository;
//using ERPSSL.CustomerServices.DAL.Repository;
//using ERPSSL.CustomerServices.DAL.Repository;

namespace ERPSSL.HRM.DAL
{
    public class EMPLOYEE_DAL
    {
        ERPSSLHBEntities _context = new ERPSSLHBEntities();

        //-------Insert------------------------------------
        public Int64 InsertEmployee(HRM_EMPLOYEES objEmp)
        {
            try
            {
                _context.HRM_EMPLOYEES.AddObject(objEmp);
                _context.SaveChanges();
                Int64 scope_id = objEmp.EMP_ID;
                return scope_id;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        //-------Insert------------------------------------
        public Int64 InsertEmployeeEdu(HRM_EDUCATION objEdu)
        {
            try
            {
                _context.HRM_EDUCATION.AddObject(objEdu);
                _context.SaveChanges();
                return 1;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        //-------Update------------------------------------
        public int UpdateEmployee(HRM_EMPLOYEES objEmp_update, int QueryStringId)
        {
            try
            {
                HRM_EMPLOYEES objEmp = _context.HRM_EMPLOYEES.First(x => x.EMP_ID == QueryStringId);
                objEmp.EMP_FIRSTNAME = objEmp_update.EMP_FIRSTNAME;
                _context.SaveChanges();
                return 1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //-------GetAll Current------------------------------------
        public virtual List<HRM_EMPLOYEES> GetCurrent_Employees(string OCODE)
        {
            try
            {
                var query = (from emp in _context.HRM_EMPLOYEES
                             where emp.OCODE == OCODE && emp.EMP_TERMIN_STATUS == false && emp.EMP_TRANSFER_STATUS == false
                             select emp).OrderByDescending(x => x.EMP_ID);


                return query.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        //-------GetAll terminated------------------------------------
        public virtual List<HRM_EMPLOYEES> GetTerminated_Employees(string OCODE)
        {
            try
            {
                var query = (from emp in _context.HRM_EMPLOYEES
                             where emp.OCODE == OCODE && emp.EMP_TERMIN_STATUS == true
                             select emp).OrderByDescending(x => x.EMP_ID);


                return query.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        //-------GetAll Transfered------------------------------------
        public virtual List<HRM_PersonalInformations> GetTransfered_Employees(string OCODE)
        {
            try
            {
                var query = (from emp in _context.HRM_PersonalInformations
                             where emp.OCODE == OCODE && emp.EMP_TERMIN_STATUS == false && emp.EMP_TRANSFER_STATUS == true
                             select emp).OrderByDescending(x => x.EmpId);


                return query.ToList();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        //-------Check------------------------------------
        public int CheckEidExitance(string OCODE, string Requested_Eid)
        {
            try
            {
                return (from emp in _context.HRM_EMPLOYEES
                        where emp.EID == Requested_Eid && emp.OCODE == OCODE
                        select emp).Count();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        //-------Administration Employee Details------------------------------------

        public IEnumerable<HRM_EMPLOYEES_VIEWER> GetEmployeeDetailsID(string employeeID, string OCODE)
        {
            using (var _context = new ERPSSLHBEntities())
            {
                return (from emp in _context.HRM_EMPLOYEES
                        join r in _context.HRM_Regions on emp.Region_ID equals r.RegionID
                        join ofc in _context.HRM_Office on emp.Office_ID equals ofc.OfficeID
                        join d in _context.HRM_DEPARTMENTS on emp.DPT_ID equals d.DPT_ID
                        join s in _context.HRM_SECTIONS on emp.SEC_ID equals s.SEC_ID
                        join ss in _context.HRM_SUB_SECTIONS on emp.SUB_SEC_ID equals ss.SUB_SEC_ID
                        join dg in _context.HRM_DESIGNATIONS on emp.DEG_ID equals dg.DEG_ID
                        join grd in _context.HRM_GRADE on emp.GRADE_ID equals grd.GRADE_ID
                        //join srv in _context.HRM_SERVICE_CONTRACT on emp.EMP_ID equals srv.EMP_ID

                        where emp.EID == employeeID && emp.OCODE == OCODE
                        select new HRM_EMPLOYEES_VIEWER
                        {
                            EMP_ID = (int)emp.EMP_ID,
                            EID = emp.EID,
                            FirstName = emp.EMP_FIRSTNAME,
                            LastName = emp.EMP_LASTNAME,

                            REG_NAME = r.RegionName,
                            REG_ID = r.RegionID,

                            OFC_NAME = ofc.OfficeName,
                            OFC_ID = ofc.OfficeID,

                            DPT_NAME = d.DPT_NAME,
                            DPT_ID = d.DPT_ID,

                            SEC_NAME = s.SEC_NAME,
                            SEC_ID = s.SEC_ID,

                            SUB_SEC_NAME = ss.SUB_SEC_NAME,
                            SUB_SEC_ID = ss.SUB_SEC_ID,

                            DEG_NAME = dg.DEG_NAME,
                            DEG_ID = dg.DEG_ID,

                            GRADE = grd.GRADE,
                            GRADE_ID = grd.GRADE_ID,

                            EMP_FIRSTNAME = emp.EMP_FIRSTNAME,
                            EMP_LASTNAME = emp.EMP_LASTNAME,
                            EMP_CONTACT_NO = emp.EMP_CONTACT_NO,

                            //CONTRACT = srv.CONTRACT

                        }).ToList();
            }
        }

        public IEnumerable<HRM_EMPLOYEES_VIEWER> GetEmployeeDetailsForAttendece(string employeeID, string OCODE)
        {
            using (var _context = new ERPSSLHBEntities())
            {
                return (from emp in _context.HRM_PersonalInformations
                        join r in _context.HRM_Regions on emp.RegionsId equals r.RegionID
                        join ofc in _context.HRM_Office on emp.OfficeId equals ofc.OfficeID
                        join d in _context.HRM_DEPARTMENTS on emp.DesginationId equals d.DPT_ID
                        join s in _context.HRM_SECTIONS on emp.SectionId equals s.SEC_ID
                        join ss in _context.HRM_SUB_SECTIONS on emp.SubSectionId equals ss.SUB_SEC_ID
                        join dg in _context.HRM_DESIGNATIONS on emp.DesginationId equals dg.DEG_ID
                        //join grd in _context.HRM_GRADE on emp.GradeId equals grd.GRADE_ID
                        //join srv in _context.HRM_SERVICE_CONTRACT on emp.EMP_ID equals srv.EMP_ID

                        where emp.EID == employeeID && emp.OCODE == OCODE
                        select new HRM_EMPLOYEES_VIEWER
                        {
                            EMP_ID = (int)emp.EmpId,
                            EID = emp.EID,
                            FirstName = emp.FirstName,
                            LastName = emp.LastName,

                            REG_NAME = r.RegionName,
                            REG_ID = r.RegionID,

                            OFC_NAME = ofc.OfficeName,
                            OFC_ID = ofc.OfficeID,

                            DPT_NAME = d.DPT_NAME,
                            DPT_ID = d.DPT_ID,

                            SEC_NAME = s.SEC_NAME,
                            SEC_ID = s.SEC_ID,

                            SUB_SEC_NAME = ss.SUB_SEC_NAME,
                            SUB_SEC_ID = ss.SUB_SEC_ID,

                            DEG_NAME = dg.DEG_NAME,
                            DEG_ID = dg.DEG_ID,

                            //GRADE = grd.GRADE,
                            //GRADE_ID = grd.GRADE_ID,

                            //EMP_FIRSTNAME = emp.EMP_FIRSTNAME,
                            //EMP_LASTNAME = emp.EMP_LASTNAME,
                            //EMP_CONTACT_NO = emp.EMP_CONTACT_NO,

                            //CONTRACT = srv.CONTRACT

                        }).ToList();
            }
        }

        public IEnumerable<HRM_EMPLOYEES_CONTRACT> GetEmployeeID(string employeeID, string OCODE)
        {
            using (var _context = new ERPSSLHBEntities())
            {
                return (from emp in _context.HRM_EMPLOYEES
                        //join srv in _context.HRM_SERVICE_CONTRACT on emp.EMP_ID equals srv.EMP_ID
                        join d in _context.HRM_DEPARTMENTS on emp.DPT_ID equals d.DPT_ID
                        join dg in _context.HRM_DESIGNATIONS on emp.DEG_ID equals dg.DEG_ID

                        where emp.EID == employeeID && emp.OCODE == OCODE
                        select new HRM_EMPLOYEES_CONTRACT
                        {
                            EMP_ID = (Int64)emp.EMP_ID,
                            EID = emp.EID,

                            EMP_FIRSTNAME = emp.EMP_FIRSTNAME,
                            EMP_LASTNAME = emp.EMP_LASTNAME,
                            EMP_CONTACT_NO = emp.EMP_CONTACT_NO,

                            //CONTRACT = srv.CONTRACT,
                            DEG_NAME = dg.DEG_NAME,
                            //DEG_ID = dg.DEG_ID,

                            DPT_NAME = d.DPT_NAME
                            //DPT_ID = d.DPT_ID,

                        }).ToList();
            }
        }

        public IEnumerable<HRM_EMPLOYEES_CONTRACT> GetEmployeeContract(string employeeID, string OCODE)
        {
            using (var _context = new ERPSSLHBEntities())
            {
                return (from emp in _context.HRM_PersonalInformations
                        join srv in _context.HRM_SERVICE_CONTRACT on emp.EID equals srv.EID

                        where emp.EID == employeeID && emp.OCODE == OCODE
                        select new HRM_EMPLOYEES_CONTRACT
                        {
                            CONTRACT = srv.CONTRACT,

                        }).ToList();
            }
        }

        public IEnumerable<HRM_LEAVE> GetEmployeeLeave(string employeeID, string OCODE)
        {
            using (var _context = new ERPSSLHBEntities())
            {
                var query = (from ev in _context.HRM_LEAVE_EMPLOYEE
                             where ev.EID == employeeID && ev.OCODE == OCODE
                             select new HRM_LEAVE
                             {
                                 TOTAL_REM_DAY = (Int32)ev.TOTAL_REM_DAY,
                                 TOTAL_LEV_DAYS = (Int32)ev.TOTAL_LEV_DAYS

                             }).ToList();

                return query;

            }
        }

        public IEnumerable<HRM_LEAVE> GetEmployeeLeave(int selectedType, string employeeID, string OCODE)
        {
            using (var _context = new ERPSSLHBEntities())
            {
                var query = (from ev in _context.HRM_LEAVE_EMPLOYEE
                             where ev.LEV_TYPE_ID == selectedType && ev.EID == employeeID && ev.OCODE == OCODE
                             select new HRM_LEAVE
                             {
                                 TOTAL_REM_DAY = (Int32)ev.TOTAL_REM_DAY,
                                 TOTAL_LEV_DAYS = (Int32)ev.TOTAL_LEV_DAYS

                             }).ToList();

                return query;

            }
        }

        public IEnumerable<HRM_LEAVE> GetEmployeeTotalLeave(string selectedTyoe, string OCODE)
        {
            using (var _context = new ERPSSLHBEntities())
            {
                var query = (from ev in _context.HRM_LEAVE_TYPE
                             where ev.LEV_TYPE == selectedTyoe && ev.OCODE == OCODE
                             select new HRM_LEAVE
                             {
                                 TOTAL_LEV_DAYS = (Int32)ev.LEV_DAYS

                             }).ToList();

                return query;

            }
        }

        public int InsertEmployeeLeave(HRM_LEAVE_EMPLOYEE obj)
        {
            int result = 0;

            using (var _context = new ERPSSLHBEntities())
            {
                var PRM_EMP_ID = new SqlParameter("EMP_ID", obj.EMP_ID);
                var PRM_EID = new SqlParameter("EID", obj.EID);
                var PRM_LEV_TYPE_ID = new SqlParameter("LEV_TYPE_ID", obj.LEV_TYPE_ID);
                var PRM_TOTAL_LEV_DAYS = new SqlParameter("TOTAL_LEV_DAYS", obj.TOTAL_LEV_DAYS);
                var PRM_REMARKS = new SqlParameter("REMARKS", obj.REMARKS);
                var PRM_EDIT_USER = new SqlParameter("EDIT_USER", obj.EDIT_USER);
                var PRM_EDIT_DATE = new SqlParameter("EDIT_DATE", obj.EDIT_DATE);
                var PRM_OCODE = new SqlParameter("OCODE", obj.OCODE);

                string SP_SQL = "ENTER_EMPLOYEE_LEAVE @EMP_ID,@EID,@LEV_TYPE_ID,@TOTAL_LEV_DAYS,@REMARKS,@EDIT_USER,@EDIT_DATE,@OCODE";
                //int return_value = _context.ExecuteStoreQuery<int>(SP_SQL, PRM_EMP_ID, PRM_EID, PRM_LEV_TYPE_ID, PRM_TOTAL_LEV_DAYS, PRM_REMARKS, PRM_EDIT_USER, PRM_EDIT_DATE, PRM_OCODE);
                int return_value = _context.ExecuteStoreQuery<int>(SP_SQL, PRM_EMP_ID, PRM_EID, PRM_LEV_TYPE_ID, PRM_TOTAL_LEV_DAYS, PRM_REMARKS, PRM_EDIT_USER, PRM_EDIT_DATE, PRM_OCODE).FirstOrDefault();

                if (return_value == 1)
                {
                    result = 1;
                }
                else if (return_value == 2)
                {
                    result = 2;
                }
                else
                {
                    result = 0;
                }

                return result;
            }
        }
        public IEnumerable<EmployementInfo> GetEmployemntInfo(string employeeid, string Ocode)
        {
            using (var _context = new ERPSSLHBEntities())
            {
                var ParamempID = new SqlParameter("@ocode", Ocode);
                var ParamempID1 = new SqlParameter("@Eid", employeeid);

                string SP_SQL = "HRM_EmployementListByEID @ocode,@Eid";

                return (_context.ExecuteStoreQuery<EmployementInfo>(SP_SQL, ParamempID, ParamempID1)).ToList();
            }

        }

        public IEnumerable<HRM_EMPLOYEES_EDIT> GetEmployeeDetailsID_EDIT(Int64 employeeID, string OCODE)
        {
            using (var _context = new ERPSSLHBEntities())
            {
                return (from emp in _context.HRM_EMPLOYEES
                        join r in _context.HRM_Regions on emp.Region_ID equals r.RegionID
                        join ofc in _context.HRM_Office on emp.Office_ID equals ofc.OfficeID
                        join d in _context.HRM_DEPARTMENTS on emp.DPT_ID equals d.DPT_ID
                        join s in _context.HRM_SECTIONS on emp.SEC_ID equals s.SEC_ID
                        join ss in _context.HRM_SUB_SECTIONS on emp.SUB_SEC_ID equals ss.SUB_SEC_ID
                        join dg in _context.HRM_DESIGNATIONS on emp.DEG_ID equals dg.DEG_ID
                        join grd in _context.HRM_GRADE on emp.GRADE_ID equals grd.GRADE_ID
                        //join srv in _context.HRM_SERVICE_CONTRACT on emp.EMP_ID equals srv.EMP_ID

                        where emp.EMP_ID == employeeID && emp.OCODE == OCODE
                        select new HRM_EMPLOYEES_EDIT
                        {
                            //EMP_ID = (int)emp.EMP_ID,
                            EID = emp.EID,

                            EMP_SEX = emp.EMP_SEX,
                            EMP_FIRSTNAME = emp.EMP_FIRSTNAME,
                            EMP_LASTNAME = emp.EMP_LASTNAME,
                            EMP_DOB = (DateTime)emp.EMP_DOB,
                            EMP_FATHERS_NAME = emp.EMP_FATHERS_NAME,
                            EMP_MOTHERS_NAME = emp.EMP_MOTHERS_NAME,
                            EMP_RELIGION = emp.EMP_RELIGION,

                            EMP_BLOOD_GRP = emp.EMP_BLOOD_GRP,
                            EMP_MARITUAL_STATUS = emp.EMP_MARITUAL_STATUS,
                            EMP_NATIONALITY = emp.EMP_NATIONALITY,
                            DATE_JOINED = (DateTime)emp.DATE_JOINED,
                            EMP_PER_ADDRESS = emp.EMP_PER_ADDRESS,
                            EMP_PRE_ADDRESS = emp.EMP_PRE_ADDRESS,
                            EMP_CONTACT_NO = emp.EMP_CONTACT_NO,
                            EMP_EMAIL = emp.EMP_EMAIL,
                            EMP_ALT_EMAIL = emp.EMP_ALT_EMAIL,
                            EMP_EMG_CONTACT_NO = emp.EMP_EMG_CONTACT_NO,
                            EMP_NOMINEE_NAME = emp.EMP_NOMINEE_NAME,
                            EMP_NOMINEE_RELATION = emp.EMP_NOMINEE_RELATION,
                            EMP_NOMINEE_AGE = emp.EMP_NOMINEE_AGE,

                            ReportingBossName = emp.ReportingBossName,
                            RptBossDSG = emp.RptBossDSG,

                            Reg_Name = r.RegionName,
                            Reg_ID = r.RegionID,

                            Off_Name = ofc.OfficeName,
                            Off_ID = ofc.OfficeID,

                            DPT_NAME = d.DPT_NAME,
                            DPT_ID = d.DPT_ID,

                            SEC_NAME = s.SEC_NAME,
                            SEC_ID = s.SEC_ID,

                            SUB_SEC_NAME = ss.SUB_SEC_NAME,
                            SUB_SEC_ID = ss.SUB_SEC_ID,

                            DEG_NAME = dg.DEG_NAME,
                            DEG_ID = dg.DEG_ID,

                            GRADE = grd.GRADE,
                            GRADE_ID = grd.GRADE_ID

                        }).ToList();
            }
        }

        //-------GetAll ------------------------------------
        public virtual List<HRM_EDUCATION> GetEmployeeEducation(Int64 employeeID, string OCODE)
        {
            try
            {
                var query = (from edu in _context.HRM_EDUCATION
                             where edu.EMP_ID == employeeID
                             select edu).OrderByDescending(edu => edu.EMP_ID);

                return query.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }


        // Get All Employee -----------------------------

        public virtual List<HRM_EMPLOYEES> GetAllEmployee(string OCODE)
        {
            try
            {
                var query = (from emp in _context.HRM_EMPLOYEES
                             where emp.OCODE == OCODE
                             select emp).OrderByDescending(x => x.EMP_ID);


                return query.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public virtual List<HRM_Regions> GetAllRegions(string OCODE)
        {
            try
            {
                var query = (from rgn in _context.HRM_Regions
                             where rgn.OCODE == OCODE
                             select rgn).OrderByDescending(x => x.RegionID);


                return query.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public virtual List<HRM_Office> GetAllOffices(string OCODE)
        {
            try
            {
                var query = (from ofc in _context.HRM_Office
                             where ofc.OCODE == OCODE
                             select ofc).OrderByDescending(x => x.OfficeID);


                return query.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal IEnumerable<AssignTo> GetDesgination(string eid, string OCODE)
        {
            try
            {


                //var ParamempID = new SqlParameter("@Ocode", OCODE);
                //var ParamempID1 = new SqlParameter("@EmpId", eid);
                //string SP_SQL = "HRM_GetAssignToInfoByEmployeId @Ocode,@EmpId";
                //return (_context.ExecuteStoreQuery<AssignTo>(SP_SQL, ParamempID, ParamempID1)).ToList();    

                using (var _context = new ERPSSLHBEntities())
                {
                    var ParamempID = new SqlParameter("@eid", eid);
                    var ParamempID1 = new SqlParameter("@Ocode", OCODE);
                    string SP_SQL = "HRM_GetAssignToInfoByEmployeId @eid,@Ocode";
                    return (_context.ExecuteStoreQuery<AssignTo>(SP_SQL, ParamempID, ParamempID1)).ToList();
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal HRM_PersonalInformations getPersonalInfosByID(string EmployeeId)
        {
            HRM_PersonalInformations objEmp = new HRM_PersonalInformations();
            return objEmp = _context.HRM_PersonalInformations.FirstOrDefault(x => x.EID == EmployeeId);
        }



        internal List<HRM_PersonalInformations> getEmpployeeNameById(string eid, string OCODE)
        {

            try
            {
                var query = (from emp in _context.HRM_PersonalInformations
                             where emp.EID == eid && emp.OCODE == OCODE
                             select emp).OrderByDescending(x => x.EID);


                return query.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public IEnumerable<HRM_EMPLOYEES_CONTRACT> GetEmployeeIDDetails(string employeeID, string OCODE)
        {
            using (var _context = new ERPSSLHBEntities())
            {
                return (from emp in _context.HRM_PersonalInformations
                        //join srv in _context.HRM_SERVICE_CONTRACT on emp.EID equals srv.EID
                        join d in _context.HRM_DEPARTMENTS on emp.DepartmentId equals d.DPT_ID
                        join dg in _context.HRM_DESIGNATIONS on emp.DesginationId equals dg.DEG_ID


                        where emp.EID == employeeID && emp.OCODE == OCODE
                        select new HRM_EMPLOYEES_CONTRACT
                        {
                            EMP_ID = (Int64)emp.EmpId,
                            EID = emp.EID,

                            EMP_FIRSTNAME = emp.FirstName,
                            EMP_LASTNAME = emp.LastName,
                            EMP_CONTACT_NO = emp.ContactNumber,


                            //CONTRACT = srv.CONTRACT,
                            DEG_NAME = dg.DEG_NAME,
                            //DEG_ID = dg.DEG_ID,

                            DPT_NAME = d.DPT_NAME
                            //DPT_ID = d.DPT_ID,

                        }).ToList();
            }
        }

        public IEnumerable<HRM_EMPLOYEES_VIEWER> GetEmployeeDetailsIDCard(string employeeID, string OCODE)
        {
            using (var _context = new ERPSSLHBEntities())
            {
                return (from emp in _context.HRM_PersonalInformations
                        join r in _context.HRM_Regions on emp.RegionsId equals r.RegionID
                        join ofc in _context.HRM_Office on emp.OfficeId equals ofc.OfficeID
                        join d in _context.HRM_DEPARTMENTS on emp.DepartmentId equals d.DPT_ID
                        join s in _context.HRM_SECTIONS on emp.SectionId equals s.SEC_ID
                        join ss in _context.HRM_SUB_SECTIONS on emp.SubSectionId equals ss.SUB_SEC_ID
                        join dg in _context.HRM_DESIGNATIONS on emp.DesginationId equals dg.DEG_ID
                        //join grd in _context.HRM_GRADE on emp.GradeId equals grd.GRADE_ID
                        //join srv in _context.HRM_SERVICE_CONTRACT on emp.EMP_ID equals srv.EMP_ID
                        where emp.EID == employeeID && emp.OCODE == OCODE && emp.EMP_TERMIN_STATUS == false && emp.EMP_Retired_Status == false && emp.EMP_Resignation_Status == false && emp.EMP_Dismissal_Status == false && emp.EMP_Died_Status == false && emp.EMP_Dis_Continution_Status == false && emp.EMP_Other==false
                        select new HRM_EMPLOYEES_VIEWER
                        {
                            EMP_ID = (int)emp.EmpId,
                            EID = emp.EID,
                            
                            REG_NAME = r.RegionName,
                            REG_ID = r.RegionID,
                            Gender=emp.Gender,
                            OFC_NAME = ofc.OfficeName,
                            OFC_ID = ofc.OfficeID,

                            DPT_NAME = d.DPT_NAME,
                            DPT_ID = d.DPT_ID,

                            SEC_NAME = s.SEC_NAME,
                            SEC_ID = s.SEC_ID,

                            SUB_SEC_NAME = ss.SUB_SEC_NAME,
                            SUB_SEC_ID = ss.SUB_SEC_ID,

                            DEG_NAME = dg.DEG_NAME,
                            DEG_ID = dg.DEG_ID,

                            //GRADE = grd.GRADE,
                            //GRADE_ID = grd.GRADE_ID,

                            EMP_FIRSTNAME = emp.FirstName,
                            EMP_LASTNAME = emp.LastName,
                            EMP_CONTACT_NO = emp.ContactNumber,
                            SHIFTCODE=emp.ShiftCode
                            //CONTRACT = srv.CONTRACT

                        }).ToList();
            }
        }

        internal List<ReportingBoss> GetPersonalInfoes(string Ocode, int departmentId)
        {
            try
            {
                var query = (from emp in _context.HRM_PersonalInformations
                             where emp.DepartmentId == departmentId && emp.OCODE == Ocode
                             select new ReportingBoss
                             {
                                 FulllName=emp.FirstName??""+" "+emp.LastName??"",
                                 EID=emp.EID
                             }).OrderByDescending(x => x.EID);


                return query.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        internal List<HRM_PersonalInformations> getEmpployeeByEid(string Eid, string OCODE)
        {

            try
            {
                var query = (from emp in _context.HRM_PersonalInformations
                             where emp.OCODE == OCODE && emp.EID == Eid
                             select emp).OrderByDescending(x => x.EID);


                return query.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }
        internal IEnumerable<REmployee> GetAllSalaryRPT(string OCODE)
        {
            try
            {
                using (var _context = new ERPSSLHBEntities())
                {
                    var ParamempID = new SqlParameter("@OCODE", OCODE);
                    string SP_SQL = "HRM_Rpt_AllSalarySP @OCODE";
                    return (_context.ExecuteStoreQuery<REmployee>(SP_SQL, ParamempID)).ToList();
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        internal IEnumerable<REmployee> GetAllChildCountRPT(string OCODE)
        {
            try
            {
                using (var _context = new ERPSSLHBEntities())
                {
                    var ParamempID = new SqlParameter("@OCODE", OCODE);
                    string SP_SQL = "HRM_Rpt_ChildrenCountSP @OCODE";
                    return (_context.ExecuteStoreQuery<REmployee>(SP_SQL, ParamempID)).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        internal IEnumerable<REmployee> GetAllEmployeeContact(string OCODE)
        {
            try
            {
                using (var _context = new ERPSSLHBEntities())
                {
                    var ParamempID = new SqlParameter("@OCODE", OCODE);
                    string SP_SQL = "HRM_Rpt_EmployeeAddress @OCODE";
                    return (_context.ExecuteStoreQuery<REmployee>(SP_SQL, ParamempID)).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        internal IEnumerable<REmployee> GetAllEmployeeChildList(string OCODE)
        {
            try
            {
                using (var _context = new ERPSSLHBEntities())
                {
                    var ParamempID = new SqlParameter("@OCODE", OCODE);
                    string SP_SQL = "HRM_Get18PluseChildren @OCODE";
                    return (_context.ExecuteStoreQuery<REmployee>(SP_SQL, ParamempID)).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        //internal IEnumerable<HRM_EMPLOYEESR> GetEmployeeFullName(string OCODE)
        //{
        //    using (var _context = new ERPSSLHBEntities())
        //    {
        //        return (from emp in _context.HRM_PersonalInformations
        //                where emp.OCODE == OCODE
        //                select new HRM_EMPLOYEESR
        //                {

        //                    EID = emp.EID,
        //                    FullNameForJC = emp.FirstName + " " + emp.LastName

        //                }).ToList();
        //    }

        //}

        //internal IEnumerable<HRM_EMPLOYEESR> GetEmployeeFullName(string OCODE)
        //{
        //    using (var _context = new ERPSSLHBEntities())
        //    {
        //        return (from emp in _context.HRM_PersonalInformations 
        //                where  emp.OCODE == OCODE
        //                select new HRM_EMPLOYEESR
        //                {
                            
        //                    EID = emp.EID,
        //                    FullNameForJC=emp.FirstName+" "+emp.LastName
                            
        //                }).ToList();
        //    }

        //}

        internal List<ReportingBoss> GetPersonalInfoByDepartment(string OCODE)
        {
            try
            {
                using (var _context = new ERPSSLHBEntities())
                {
                    return (from emp in _context.HRM_PersonalInformations
                            where emp.OCODE == OCODE && emp.DepartmentId==5 || emp.DepartmentId==38
                            select new ReportingBoss
                            {

                                EID = emp.EID,
                                FulllName = emp.FirstName + " " + emp.LastName

                            }).ToList();
                }


            }
            catch (Exception)
            {
                
                throw;
            }
        }

        internal HRM_PersonalInformations getDepartmentByEID(string employeeID)
        {

            return _context.HRM_PersonalInformations.First(x => x.EID == employeeID);
        }
        internal List<ReportingBoss> LoadApprovePersonListByDepartmentId(int departmentId)
        {
            try
            {
                using (var _context = new ERPSSLHBEntities())
                {
                    return (from emp in _context.HRM_PersonalInformations
                            where emp.DepartmentId == departmentId
                            select new ReportingBoss
                            {

                                EID = emp.EID,
                                FulllName = emp.FirstName??"" + " " + emp.LastName??""

                            }).ToList();
                }


            }
            catch (Exception)
            {

                throw;
            }

        }

        internal IEnumerable<HRM_EMPLOYEES_VIEWER> GetTerminateEmployeeList(string employeeID, string OCODE)
        {
            using (var _context = new ERPSSLHBEntities())
            {
                return (from emp in _context.HRM_PersonalInformations
                        join r in _context.HRM_Regions on emp.RegionsId equals r.RegionID
                        join ofc in _context.HRM_Office on emp.OfficeId equals ofc.OfficeID
                        join d in _context.HRM_DEPARTMENTS on emp.DepartmentId equals d.DPT_ID
                        join s in _context.HRM_SECTIONS on emp.SectionId equals s.SEC_ID
                        join ss in _context.HRM_SUB_SECTIONS on emp.SubSectionId equals ss.SUB_SEC_ID
                        join dg in _context.HRM_DESIGNATIONS on emp.DesginationId equals dg.DEG_ID
                        //join grd in _context.HRM_GRADE on emp.GradeId equals grd.GRADE_ID
                        //join srv in _context.HRM_SERVICE_CONTRACT on emp.EMP_ID equals srv.EMP_ID
                        where emp.EID == employeeID && emp.OCODE == OCODE &&(emp.EMP_TERMIN_STATUS == true || emp.EMP_Retired_Status == true || emp.EMP_Resignation_Status == true || emp.EMP_Dismissal_Status == true || emp.EMP_Died_Status == true || emp.EMP_Dis_Continution_Status == true || emp.EMP_Other == true)
                        select new HRM_EMPLOYEES_VIEWER
                        {
                            EMP_ID = (int)emp.EmpId,
                            EID = emp.EID,

                            REG_NAME = r.RegionName,
                            REG_ID = r.RegionID,
                            Gender = emp.Gender,
                            OFC_NAME = ofc.OfficeName,
                            OFC_ID = ofc.OfficeID,

                            DPT_NAME = d.DPT_NAME,
                            DPT_ID = d.DPT_ID,

                            SEC_NAME = s.SEC_NAME,
                            SEC_ID = s.SEC_ID,

                            SUB_SEC_NAME = ss.SUB_SEC_NAME,
                            SUB_SEC_ID = ss.SUB_SEC_ID,

                            DEG_NAME = dg.DEG_NAME,
                            DEG_ID = dg.DEG_ID,

                            //GRADE = grd.GRADE,
                            //GRADE_ID = grd.GRADE_ID,

                            EMP_FIRSTNAME = emp.FirstName,
                            EMP_LASTNAME = emp.LastName,
                            EMP_CONTACT_NO = emp.ContactNumber,

                            //CONTRACT = srv.CONTRACT

                        }).ToList();
            }


        }

        public virtual List<REmployee> GetAllEmployeeByDept(string OCODE, string depCode)
        {
            //try
            //{
            //    var query = (from emp in _context.HRM_PersonalInformations join dpt in _context.HRM_DEPARTMENTS on emp.DepartmentId equals dpt.DPT_ID
            //                 where emp.OCODE == OCODE && dpt.DPT_CODE == depCode
            //                 select emp).OrderBy(x => x.FirstName);


            //    return query.ToList();
            //}
            //catch (Exception ex)
            //{
            //    throw ex;
            //}


            using (var _context = new ERPSSLHBEntities())
            {
                return (from emp in _context.HRM_PersonalInformations
                        join dpt in _context.HRM_DEPARTMENTS on emp.DepartmentId equals dpt.DPT_ID
                        where emp.OCODE == OCODE && dpt.DPT_CODE == depCode

                        select new REmployee
                        {

                            EID = emp.EID,
                            FullName = emp.FirstName + " " + emp.LastName + "-" + emp.EID

                        }).ToList();
            }
        }


        internal HRM_PersonalInformations GetEmployeeDetails(string id)
        {
            HRM_PersonalInformations objEmp = new HRM_PersonalInformations();
            return objEmp = _context.HRM_PersonalInformations.FirstOrDefault(x => x.EID == id);
        }

        internal AttendanceDetailsR GetEmployeeAttend(string id, string status, string startdate, string endDate)
        {
            try
            {
                using (var _context = new ERPSSLHBEntities())
                {
                    var EmpId = new SqlParameter("@empId", id);
                    var Status = new SqlParameter("@status", status);
                    var FromDate = new SqlParameter("@startDate", startdate);
                    var ToDate = new SqlParameter("@endDate", endDate);
                    string SP_SQL = "HRM_AttendanceDetailsById @empId, @status,@startDate,@endDate";
                    return (_context.ExecuteStoreQuery<AttendanceDetailsR>(SP_SQL, EmpId,Status,FromDate,ToDate)).FirstOrDefault();
                }                                                      

            }
            catch (Exception)
            {
                throw;
            }
        }

        internal List<ReportingBoss> getPersonalInfoForHRM()
        {
            List<string> states = new List<string>() { "722", "362", "807" };
            return (from Q in _context.HRM_PersonalInformations
                    where states.Contains(Q.EID)
                    select new ReportingBoss
                    {

                        EID = Q.EID,
                        FulllName = Q.FirstName + " " + Q.LastName

                    }).ToList();
        }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ERPSSL.HRM.DAL.Repository;
using System.Data.SqlClient;
using ERPSSL.HRM.BLL;

namespace ERPSSL.HRM.DAL
{
    public class EmployeeSetup_DAL
    {

        ERPSSLHBEntities context = new ERPSSLHBEntities();

        #region  ---------------- Personal Information -----------------

        public virtual List<HRM_PersonalInformations> GetPersonInfo()
        {
            var query = (from c in context.HRM_PersonalInformations
                         select c).OrderByDescending(c => c.EmpId);

            var list = query.ToList();
            return list;
        }

        public int InsertPersonalInfo(HRM_PersonalInformations aPersonalInfo)
        {
            context.HRM_PersonalInformations.AddObject(aPersonalInfo);
            context.SaveChanges();
            return 1;
        }

        //-------Check------------------------------------
        public int CheckEidExitance(string OCODE, string Requested_Eid)
        {
            try
            {
                return (from emp in context.HRM_PersonalInformations
                        where emp.EID == Requested_Eid && emp.OCODE == OCODE
                        select emp).Count();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        #endregion

        #region -------------- Academic Information ------------

        public int InsertAcademicInfo(HRM_Academics academics)
        {
            context.HRM_Academics.AddObject(academics);
            context.SaveChanges();
            return 1;
        }

        #endregion

        #region -------------- Training Information ------------

        public int InsertTrainingInfo(HRM_Trainings aTrainings)
        {
            context.HRM_Trainings.AddObject(aTrainings);
            context.SaveChanges();
            return 1;
        }

        #endregion

        #region ---------------- Experience Information ---------------

        public virtual List<HRM_Experiences> GetEmpExperienceses()
        {
            var query = (from c in context.HRM_Experiences
                         select c).OrderByDescending(c => c.ExperienceId);

            var list = query.ToList();
            return list;
        }

        public int InsertEmpExperiences(HRM_Experiences aExperiences)
        {
            try
            {
                context.HRM_Experiences.AddObject(aExperiences);
                context.SaveChanges();
                return 1;
            }
            catch (Exception)
            {

                throw;
            }
        }

        #endregion

        #region ---------------- Skill Information ---------------

        public virtual List<HRM_Skills> GetEmpSkills()
        {
            var query = (from c in context.HRM_Skills
                         select c).OrderByDescending(c => c.SkillId);

            var list = query.ToList();
            return list;
        }

        public int InsertEmpSkills(HRM_Skills aSkills)
        {
            context.HRM_Skills.AddObject(aSkills);
            context.SaveChanges();
            return 1;
        }

        #endregion

        #region ------------------ Employment Information-------------

        internal List<RptBossDSG> GetRptBossDSG(int BossDSG)
        {
            using (var _context = new ERPSSLHBEntities())
            {
                var rptBoss_ID = new SqlParameter("@RptBoss_ID", BossDSG);

                string SP_SQL = "RptBossDesignation @RptBoss_ID";

                return (_context.ExecuteStoreQuery<RptBossDSG>(SP_SQL, rptBoss_ID)).ToList();
            }
        }

        #endregion

        internal int InsertPersonalInfoemployemetPart(string EmployeeId, HRM_PersonalInformations personalInfo)
        {
            HRM_PersonalInformations obj = context.HRM_PersonalInformations.First(x => x.EID == EmployeeId);
            obj.RegionsId = personalInfo.RegionsId;
            obj.EffectiveSalaryStatus = personalInfo.EffectiveSalaryStatus;
            obj.EffectiveSlary = personalInfo.EffectiveSlary;
            obj.JoiningDate = personalInfo.JoiningDate;
            obj.OfficeId = personalInfo.OfficeId;
            obj.DepartmentId = personalInfo.DepartmentId;
            obj.SectionId = personalInfo.SectionId;
            obj.SubSectionId = personalInfo.SubSectionId;
            obj.Grade = personalInfo.Grade;
            obj.OTApplicable = personalInfo.OTApplicable;
            obj.Attendance_Bouns = personalInfo.Attendance_Bouns;
            obj.Late_Applicable = personalInfo.Late_Applicable;
            obj.Absence_Applicable = personalInfo.Absence_Applicable;
            obj.Tax_Applicable = personalInfo.Tax_Applicable;
            obj.PF_Applicable = personalInfo.PF_Applicable;
            obj.EmployeeType = personalInfo.EmployeeType;
            obj.ProbationPeriodFrom = personalInfo.ProbationPeriodFrom;
            obj.ProbationPeriodTo = personalInfo.ProbationPeriodTo;
            obj.ConfiramtionDate = personalInfo.ConfiramtionDate;
            obj.Salary = personalInfo.Salary;
            obj.EmpCategoryId = personalInfo.EmpCategoryId;
            obj.Step = personalInfo.Step;
            obj.DesginationId = personalInfo.DesginationId;
            obj.ShiftCode = personalInfo.ShiftCode;
            // obj.ReportingBossId = personalInfo.ReportingBossId;
            obj.JobResponsibility = personalInfo.JobResponsibility;
            obj.EDIT_DATE = personalInfo.EDIT_DATE;
            obj.EDIT_USER = personalInfo.EDIT_USER;
            obj.OCODE = personalInfo.OCODE;
            context.SaveChanges();
            return 1;
        }

        internal List<REmployee> GetAllTurnOverHistoryRPT(string OCODE)
        {
            try
            {
                using (var _context = new ERPSSLHBEntities())
                {
                    var ParamempID = new SqlParameter("@OCODE", OCODE);
                    string SP_SQL = "HRM_RPT_EmployeeTurnOverReport @OCODE";
                    return (_context.ExecuteStoreQuery<REmployee>(SP_SQL, ParamempID)).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        internal IEnumerable<REmployee> GetEmployees(string OCODE)
        {
            try
            {
                using (var _context = new ERPSSLHBEntities())
                {
                    var ParamempID = new SqlParameter("@OCODE", OCODE);
                    string SP_SQL = "HRM_EmployesList @OCODE";
                    return (_context.ExecuteStoreQuery<REmployee>(SP_SQL, ParamempID)).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        internal IEnumerable<REmployee> GetTransFerEmployeeEmployees(string OCODE)
        {
            try
            {
                using (var _context = new ERPSSLHBEntities())
                {
                    var ParamempID = new SqlParameter("@OCODE", OCODE);

                    string SP_SQL = "HRM_GetTransfered_Employees @OCODE";

                    return (_context.ExecuteStoreQuery<REmployee>(SP_SQL, ParamempID)).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }

        }

        internal IEnumerable<REmployee> GetTerminatedEmployees(string OCODE)
        {
            try
            {
                using (var _context = new ERPSSLHBEntities())
                {
                    var ParamempID = new SqlParameter("@OCODE", OCODE);
                    string SP_SQL = "HRM_Terminitated_Employees @OCODE";
                    return (_context.ExecuteStoreQuery<REmployee>(SP_SQL, ParamempID)).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        internal IEnumerable<REmployee> GetSearchEmployeesList(string OCODE, string EmpSearch)
        {
            try
            {
                using (var _context = new ERPSSLHBEntities())
                {
                    var ParamempID = new SqlParameter("@ocode", OCODE);
                    var ParamempID1 = new SqlParameter("@searchText", EmpSearch);
                    string SP_SQL = "[HRM_SearchEmployesList] @ocode,@searchText";
                    return (_context.ExecuteStoreQuery<REmployee>(SP_SQL, ParamempID, ParamempID1)).ToList();
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        internal int InsertPersonalInfoAssignTo(string EmployeeId, HRM_PersonalInformations personalInfo)
        {

            HRM_PersonalInformations obj = context.HRM_PersonalInformations.First(x => x.EID == EmployeeId);
            obj.ReportingBossId = personalInfo.ReportingBossId;
            obj.SecondReportingBossId = personalInfo.SecondReportingBossId;
            obj.ThirdReportingBossId = personalInfo.ThirdReportingBossId;
            context.SaveChanges();
            return 1;
        }

        internal int UpdatePersonalInfo(HRM_PersonalInformations personalInfo, string employeeId)
        {

            try
            {
                HRM_PersonalInformations obj = context.HRM_PersonalInformations.First(x => x.EID == employeeId);
                obj.FirstName = personalInfo.FirstName;
                obj.LastName = personalInfo.LastName;
                obj.Gender = personalInfo.Gender;
                obj.DateOfBrith = personalInfo.DateOfBrith;
                obj.BloodGroup = personalInfo.BloodGroup;
                obj.MaritalStatus = personalInfo.MaritalStatus;
                obj.Religion = personalInfo.Religion;
                obj.Nationality = personalInfo.Nationality;
                obj.BIO_MATRIX_ID = personalInfo.BIO_MATRIX_ID;
                obj.NationalID = personalInfo.NationalID;
                context.SaveChanges();

                return 1;


            }
            catch (Exception)
            {

                throw;
            }


        }

        internal int UpdateemployemetPart(string EmployeeId, HRM_PersonalInformations personalInfo)
        {
            try
            {
                HRM_PersonalInformations obj = context.HRM_PersonalInformations.First(x => x.EID == EmployeeId);
                obj.EmployeeType = personalInfo.EmployeeType;
                obj.EmpCategoryId = personalInfo.EmpCategoryId;
                obj.RegionsId = personalInfo.RegionsId;
                obj.JoiningDate = personalInfo.JoiningDate;
                obj.OfficeId = personalInfo.OfficeId;
                obj.DepartmentId = personalInfo.DepartmentId;
                obj.SectionId = personalInfo.SectionId;
                obj.SubSectionId = personalInfo.SubSectionId;
                obj.Grade = personalInfo.Grade;
                obj.DesginationId = personalInfo.DesginationId;
                obj.ShiftCode = personalInfo.ShiftCode;
                obj.OTApplicable = personalInfo.OTApplicable;
                obj.PF_Applicable = personalInfo.PF_Applicable;
                obj.Attendance_Bouns = personalInfo.Attendance_Bouns;
                obj.Tax_Applicable = personalInfo.Tax_Applicable;
                obj.Late_Applicable = personalInfo.Late_Applicable;
                obj.Absence_Applicable = personalInfo.Absence_Applicable;
                obj.JoiningDate = personalInfo.JoiningDate;
                obj.ProbationPeriodFrom = personalInfo.ProbationPeriodFrom;
                obj.ProbationPeriodTo = personalInfo.ProbationPeriodTo;
                obj.ConfiramtionDate = personalInfo.ConfiramtionDate;
                obj.JobResponsibility = personalInfo.JobResponsibility;
                obj.Salary = personalInfo.Salary;
                obj.EffectiveSlary = personalInfo.EffectiveSlary;
                context.SaveChanges();
                return 1;


            }
            catch (Exception)
            {

                throw;
            }
        }

        internal int UpdateExperienceEdit(int exId, HRM_Experiences objexpericence)
        {
            try
            {
                HRM_Experiences obj = context.HRM_Experiences.First(x => x.ExperienceId == exId);

                obj.Experience_Company = objexpericence.Experience_Company;
                obj.Experience_CompanyBussiness = objexpericence.Experience_CompanyBussiness;
                obj.Experience_CompanyLocation = objexpericence.Experience_CompanyLocation;
                obj.Experience_CompanyDepartment = objexpericence.Experience_CompanyDepartment;
                obj.Experience_PositionHeld = objexpericence.Experience_PositionHeld;
                obj.Experience_AreaOfExperience = objexpericence.Experience_AreaOfExperience;
                obj.EExperience_Responsibilites = objexpericence.EExperience_Responsibilites;
                obj.Experience_Duration = objexpericence.Experience_Duration;
                context.SaveChanges();
                return 1;
            }
            catch (Exception)
            {

                throw;
            }
        }

        internal int updateSkillInfo(HRM_Skills skill, int skillId)
        {
            HRM_Skills Skillobj = context.HRM_Skills.First(x => x.SkillId == skillId);
            Skillobj.Skill_Specialization = skill.Skill_Specialization;
            Skillobj.Skill_ExtraActivities = skill.Skill_ExtraActivities;
            Skillobj.Skill_Description = skill.Skill_Description;
            context.SaveChanges();
            return 1;
        }



        internal List<HRM_PersonalInformations> GetEmployeePersonalInfoByEid(string Eid, string OCODE)
        {
            try
            {
                var personalInfo = (from pers in context.HRM_PersonalInformations
                                    where pers.EID == Eid && pers.OCODE == OCODE
                                    select pers);


                return personalInfo.ToList();


            }
            catch (Exception)
            {

                throw;
            }
        }
        public IEnumerable<HRM_EMPLOYEES_VIEWER> GetEmployeeDetailsID(string employeeID, string OCODE)
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
                        // join grd in _context.HRM_GRADE on emp.GradeId equals grd.GRADE_ID

                        where emp.EID == employeeID && emp.OCODE == OCODE && emp.EMP_TERMIN_STATUS == false && emp.EMP_Retired_Status == false && emp.EMP_Resignation_Status == false && emp.EMP_Dismissal_Status == false && emp.EMP_Died_Status == false && emp.EMP_Dis_Continution_Status == false && emp.EMP_Other == false
                        select new HRM_EMPLOYEES_VIEWER
                        {
                            EMP_ID = (int)emp.EmpId,
                            EID = emp.EID,

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

                            GRADE = emp.Grade,
                            GorssSalary = (decimal)emp.Salary,
                            //STEP = (int)grd.STEP,
                            //GRADE_ID = grd.GRADE_ID,

                            EMP_FIRSTNAME = emp.FirstName,
                            EMP_LASTNAME = emp.LastName,
                            SHIFTCODE = emp.ShiftCode,
                            TERMINATE_DATE = emp.Seperation_Date
                            //            EMP_CONTACT_NO = emp.EMP_CONTACT_NO,
                            //            CONTRACT = srv.CONTRACT

                        }).ToList();
            }
        }

        public IEnumerable<HRM_EMPLOYEES_VIEWER> GetAllEmployeeInfoByEID(string EID, string OCODE)
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
                        // join grd in _context.HRM_GRADE on emp.GradeId equals grd.GRADE_ID

                        where emp.EID == EID && emp.OCODE == OCODE
                        //&& emp.EMP_TERMIN_STATUS == false && emp.EMP_Retired_Status == false && emp.EMP_Resignation_Status == false && emp.EMP_Dismissal_Status == false && emp.EMP_Died_Status == false && emp.EMP_Dis_Continution_Status == false && emp.EMP_Other == false
                        select new HRM_EMPLOYEES_VIEWER
                        {
                            EMP_ID = (int)emp.EmpId,
                            EID = emp.EID,

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

                            GRADE = emp.Grade,
                            GorssSalary = (decimal)emp.Salary,

                            EMP_FIRSTNAME = emp.FirstName,
                            EMP_LASTNAME = emp.LastName

                        }).ToList();
            }
        }

        internal IEnumerable<REmployee> GetAllEmploye(string OCODE)
        {
            try
            {
                using (var _context = new ERPSSLHBEntities())
                {
                    var ParamempID = new SqlParameter("@OCODE", OCODE);
                    string SP_SQL = "HRM_GetAllEmployeInfo @OCODE";
                    return (_context.ExecuteStoreQuery<REmployee>(SP_SQL, ParamempID)).ToList();
                }

            }
            catch (Exception)
            {

                throw;
            }

        }

        internal IEnumerable<RAssignBossName> GetBossNameById(string employeeId, string OCODE)
        {
            try
            {
                using (var _context = new ERPSSLHBEntities())
                {
                    var ParamempID = new SqlParameter("@eid", employeeId);
                    var ParamempID1 = new SqlParameter("@OCODE", OCODE);
                    string SP_SQL = "HRM_GetAssignBossNameById @eid,@OCODE";
                    return (_context.ExecuteStoreQuery<RAssignBossName>(SP_SQL, ParamempID, ParamempID1)).ToList();
                }

            }
            catch (Exception)
            {

                throw;
            }

        }

        internal int SaveEmployeeSatement(HRM_EmployeeStatement employeeStatementobj)
        {
            context.HRM_EmployeeStatement.AddObject(employeeStatementobj);
            context.SaveChanges();
            return 1;
        }

        internal int UpdateConactInfoPersonalInfo(HRM_PersonalInformations personalInfo, string employeeId)
        {
            HRM_PersonalInformations obj = context.HRM_PersonalInformations.First(x => x.EID == employeeId);
            obj.ContactNumber = personalInfo.ContactNumber;
            obj.PresentAddress = personalInfo.PresentAddress;
            obj.PermanenAddress = personalInfo.PermanenAddress;
            obj.EmergencyContactPerson = personalInfo.EmergencyContactPerson;
            obj.ContactPersonRelationName = personalInfo.ContactPersonRelationName;
            obj.EmergencyContactNo = personalInfo.EmergencyContactNo;
            obj.EmergencyAddress = personalInfo.EmergencyAddress;
            obj.Email = personalInfo.Email;
            context.SaveChanges();
            return 1;

        }

        internal int UpdateImmediateRelativeInfo(HRM_PersonalInformations personalInfo, string employeeId)
        {
            HRM_PersonalInformations obj = context.HRM_PersonalInformations.First(x => x.EID == employeeId);
            obj.FatherName = personalInfo.FatherName;
            obj.FatherAge = personalInfo.FatherAge;
            obj.FatherProfession = personalInfo.FatherProfession;
            obj.MotherName = personalInfo.MotherName;
            obj.MotherAge = personalInfo.MotherAge;
            obj.MotherProfession = personalInfo.MotherProfession;
            obj.SpouseName = personalInfo.SpouseName;
            obj.SpouseAge = personalInfo.SpouseAge;
            obj.SpouseProfession = personalInfo.SpouseProfession;
            obj.NumberOfChildren = personalInfo.NumberOfChildren;
            obj.ChildrenNameRemark = personalInfo.ChildrenNameRemark;
            context.SaveChanges();
            return 1;
        }

        internal int UpdateNomineeInfoPersonalInfo(HRM_PersonalInformations personalInfo, string employeeId)
        {
            try
            {
                HRM_PersonalInformations obj = context.HRM_PersonalInformations.First(x => x.EID == employeeId);
                obj.NomineeName = personalInfo.NomineeName;
                obj.NomineeAge = personalInfo.NomineeAge;
                obj.NomineeRelation = personalInfo.NomineeRelation;
                context.SaveChanges();
                return 1;


            }
            catch (Exception)
            {

                throw;
            }
        }

        internal List<HRM_EmployeeStatement> GetStatementList(string eid, string OCODE)
        {
            try
            {
                var query = (from pers in context.HRM_EmployeeStatement
                             where pers.EID == eid && pers.OCODE == OCODE
                             select pers);


                return query.ToList();


            }
            catch (Exception)
            {

                throw;
            }

        }

        internal int UpdateEmployeeSatement(HRM_EmployeeStatement employeeStatementobj, string eid)
        {
            try
            {
                HRM_EmployeeStatement obj = context.HRM_EmployeeStatement.First(x => x.EID == eid);
                obj.NameOfRelative = employeeStatementobj.NameOfRelative;
                obj.RelativeEID = employeeStatementobj.RelativeEID;
                obj.Relation = employeeStatementobj.Relation;
                obj.EDIT_DATE = employeeStatementobj.EDIT_DATE;
                obj.EDIT_USER = employeeStatementobj.EDIT_USER;
                obj.OCODE = employeeStatementobj.OCODE;
                context.SaveChanges();
                return 1;


            }
            catch (Exception)
            {

                throw;
            }

        }

        internal IEnumerable<REmployee> GetAllEmployeForReport(string OCODE)
        {
            try
            {
                using (var _context = new ERPSSLHBEntities())
                {
                    var ParamempID = new SqlParameter("@OCODE", OCODE);
                    string SP_SQL = "HRM_Rpt_AllEmployes @OCODE";
                    return (_context.ExecuteStoreQuery<REmployee>(SP_SQL, ParamempID)).ToList();
                }

            }
            catch (Exception)
            {

                throw;
            }

        }

        internal IEnumerable<REmployee> GetAllCurrentForReport(string OCODE)
        {
            try
            {
                using (var _context = new ERPSSLHBEntities())
                {
                    var ParamempID = new SqlParameter("@OCODE", OCODE);
                    string SP_SQL = "HRM_Rpt_CurrentEmployes @OCODE";
                    return (_context.ExecuteStoreQuery<REmployee>(SP_SQL, ParamempID)).ToList();
                }

            }
            catch (Exception)
            {

                throw;
            }

        }

        internal IEnumerable<REmployee> GetAllTransferEmployeeForReport(string OCODE)
        {
            try
            {
                using (var _context = new ERPSSLHBEntities())
                {
                    var ParamempID = new SqlParameter("@OCODE", OCODE);
                    string SP_SQL = "HRM_Rpt_TransferEmployee @OCODE";
                    return (_context.ExecuteStoreQuery<REmployee>(SP_SQL, ParamempID)).ToList();
                }

            }
            catch (Exception)
            {

                throw;
            }


        }

        internal IEnumerable<REmployee> GetAllTerminatedrEmployeeForReport(string OCODE)
        {
            try
            {
                using (var _context = new ERPSSLHBEntities())
                {
                    var ParamempID = new SqlParameter("@OCODE", OCODE);
                    string SP_SQL = "HRM_RptTerminitateEmployee @OCODE";
                    return (_context.ExecuteStoreQuery<REmployee>(SP_SQL, ParamempID)).ToList();
                }

            }
            catch (Exception)
            {

                throw;
            }

        }

        internal HRM_PersonalInformations GetReportingBossById(string Eid)
        {
            try
            {
                HRM_PersonalInformations obj = context.HRM_PersonalInformations.First(x => x.EID == Eid);
                return obj;


            }
            catch (Exception)
            {

                throw;
            }

        }

        internal int SaveChildrenInfo(HRM_ChildInfo childInfo)
        {
            context.HRM_ChildInfo.AddObject(childInfo);
            context.SaveChanges();
            return 1;
        }

        internal List<HRM_ChildInfo> GetChildrenInfo(string eid, string OCODE)
        {
            try
            {

                var query = (from pers in context.HRM_ChildInfo
                             where pers.EID == eid && pers.OCODE == OCODE
                             select pers);

                return query.ToList();


            }
            catch (Exception)
            {

                throw;
            }


        }

        internal List<HRM_ChildInfo> GetChildrenInfoById(string lblChildrenId, string OCODE)
        {

            try
            {
                int childrenId = Convert.ToInt16(lblChildrenId);


                var query = (from pers in context.HRM_ChildInfo
                             where pers.ChildId == childrenId && pers.OCODE == OCODE
                             select pers);

                return query.ToList();


            }
            catch (Exception)
            {

                throw;
            }
        }

        internal int UpdateChildrenInfo(HRM_ChildInfo childInfo, int chilId)
        {
            try
            {
                HRM_ChildInfo obj = context.HRM_ChildInfo.First(x => x.ChildId == chilId);
                obj.Age = childInfo.Age;
                obj.Name = childInfo.Name;
                obj.DOB = childInfo.DOB;
                obj.Gender = childInfo.Gender;
                context.SaveChanges();
                return 1;

            }
            catch (Exception)
            {

                throw;
            }
        }

        internal HRM_PersonalInformations GetEmployeeGender(string eid)
        {
            HRM_PersonalInformations obj = context.HRM_PersonalInformations.First(x => x.EID == eid);
            return obj;

        }

        internal IEnumerable<REmployee> GetAllMannagementEmpReport(string OCODE, string Type)
        {
            try
            {
                using (var _context = new ERPSSLHBEntities())
                {
                    var O_CODE = new SqlParameter("@OCODE", OCODE);
                    var TYPE = new SqlParameter("@Type", Type);
                    string SP_SQL = "HRM_EmployeeTypeSP @OCODE,@Type";
                    return (_context.ExecuteStoreQuery<REmployee>(SP_SQL, O_CODE, TYPE)).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        internal IEnumerable<REmployee> GetRetiredEmployee(string OCODE)
        {
            try
            {
                using (var _context = new ERPSSLHBEntities())
                {
                    var ParamempID = new SqlParameter("@OCODE", OCODE);
                    string SP_SQL = "HRM_Retired_Employees @OCODE";
                    return (_context.ExecuteStoreQuery<REmployee>(SP_SQL, ParamempID)).ToList();
                }

            }
            catch (Exception)
            {

                throw;
            }

        }

        internal IEnumerable<REmployee> GetResignation(string OCODE)
        {
            try
            {
                using (var _context = new ERPSSLHBEntities())
                {
                    var ParamempID = new SqlParameter("@OCODE", OCODE);
                    string SP_SQL = "HRM_Resignation_Employees @OCODE";
                    return (_context.ExecuteStoreQuery<REmployee>(SP_SQL, ParamempID)).ToList();
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        internal IEnumerable<REmployee> GetAllRetireddrEmployeeForReport(string OCODE)
        {
            try
            {
                using (var _context = new ERPSSLHBEntities())
                {
                    var ParamempID = new SqlParameter("@OCODE", OCODE);
                    string SP_SQL = "HRM_RptRetiredEmployee @OCODE";
                    return (_context.ExecuteStoreQuery<REmployee>(SP_SQL, ParamempID)).ToList();
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        internal IEnumerable<REmployee> GetAllResignedEmployeeForReport(string OCODE)
        {
            try
            {
                using (var _context = new ERPSSLHBEntities())
                {
                    var ParamempID = new SqlParameter("@OCODE", OCODE);
                    string SP_SQL = "HRM_RptResignedEmployee @OCODE";
                    return (_context.ExecuteStoreQuery<REmployee>(SP_SQL, ParamempID)).ToList();
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        internal int DeleteDublicate()
        {
            try
            {
                using (var _context = new ERPSSLHBEntities())
                {

                    string SP_SQL = "DeleteDublicateValue";
                    _context.ExecuteStoreCommand(SP_SQL);
                    return 1;
                }

            }
            catch (Exception)
            {

                throw;
            }


        }

        internal int DeleteTempData()
        {
            context.ExecuteStoreCommand("TRUNCATE TABLE [Hrm_PersonalInfoTemp]");
            return 1;
        }

        internal List<Hrm_PersonalInfoTemp> getEmpInfoForSave()
        {
            List<Hrm_PersonalInfoTemp> _Hrm_PersonalInfoTemp = (from ar in context.Hrm_PersonalInfoTemp
                                                                select ar).ToList();

            return _Hrm_PersonalInfoTemp;
        }

        internal void InsertDegi(List<Hrm_PersonalInfoTemp> persones, string usrId, string date, string Ocode)
        {
            try
            {
                foreach (Hrm_PersonalInfoTemp aitem in persones)
                {

                    var deg = new SqlParameter("@DesignationName", aitem.Desgination);
                    var grad = new SqlParameter("@Grade", aitem.Grade);
                    var gs = new SqlParameter("@GrossSalary", aitem.Salary);

                    var edituser = new SqlParameter("@Edit_User", usrId);
                    var editdate = new SqlParameter("@Edit_Date", date);
                    var ocode = new SqlParameter("@OCode", Ocode);

                    string SP_SQL = "HRM_SaveDesginationFileRead @DesignationName,@Grade,@GrossSalary,@Edit_User,@Edit_Date,@OCode";
                    // string SP_SQL = "HRM_SaveDesginationFileRead @DesignationName,@Grade,@GrossSalary";
                    context.ExecuteStoreCommand(SP_SQL, deg, grad, gs, edituser, editdate, ocode);

                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        internal void InsertPresonalInfoTable()
        {
            try
            {


                string SP_SQL = "HRM_DataTransfer ";
                // string SP_SQL = "HRM_SaveDesginationFileRead @DesignationName,@Grade,@GrossSalary";
                context.ExecuteStoreCommand(SP_SQL);


            }
            catch (Exception)
            {

                throw;
            }
        }


        internal List<Hrm_PersonalInfoTemp> GetDublicateList()
        {
            try
            {
                using (var _context = new ERPSSLHBEntities())
                {

                    string SP_SQL = "HRM_DublicateEmployeeList";
                    return (_context.ExecuteStoreQuery<Hrm_PersonalInfoTemp>(SP_SQL)).ToList();
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        internal List<REmployee> GetSalaryRangeReport(string FromSalary, string ToSalary)
        {
            try
            {
                using (var _context = new ERPSSLHBEntities())
                {
                    var FROM = new SqlParameter("@From", FromSalary);
                    var TO = new SqlParameter("@To", ToSalary);
                    string SP_SQL = "HRM_RPT_EmployeeSalaryRange @From,@To";
                    return (_context.ExecuteStoreQuery<REmployee>(SP_SQL, FROM, TO)).ToList();
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        internal IEnumerable<REmployee> GetEmployeeSeparation(string OCODE)
        {
            try
            {
                using (var _context = new ERPSSLHBEntities())
                {
                    var ParamempID = new SqlParameter("@OCODE", OCODE);
                    string SP_SQL = "HRM_GetEmployeSeparationList @OCODE";
                    return (_context.ExecuteStoreQuery<REmployee>(SP_SQL, ParamempID)).ToList();
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        internal IEnumerable<REmployee> GetEmployeeSeparationByDate(string fromDate, string toDate, string OCODE)
        {
            try
            {
                using (var _context = new ERPSSLHBEntities())
                {
                    var ParamempID = new SqlParameter("@FromDate", fromDate);
                    var ParamempID1 = new SqlParameter("@ToDate", toDate);
                    var ParamempID2 = new SqlParameter("@OCODE", OCODE);
                    string SP_SQL = "HRM_GetEmployeSeparationListByDate @FromDate, @ToDate, @OCODE";
                    return (_context.ExecuteStoreQuery<REmployee>(SP_SQL, ParamempID, ParamempID1, ParamempID2)).ToList();
                }

            }
            catch (Exception)
            {

                throw;
            }
        }


        internal List<REmployee> GetAllEmolyeeRetirementRPTforRegion(string OCODE)
        {
            try
            {
                using (var _context = new ERPSSLHBEntities())
                {
                    var O_CODE = new SqlParameter("@OCODE", OCODE);
                    string SP_SQL = "HRM_RPT_EmployeeAgeOverRetieredmentForRegion @OCODE";
                    return (_context.ExecuteStoreQuery<REmployee>(SP_SQL, O_CODE)).ToList();
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        internal List<REmployee> GetAllEmolyeeRetirementRPTForOffice(string OCODE, int ResionId, int OfficeId)
        {
            try
            {
                using (var _context = new ERPSSLHBEntities())
                {
                    var O_CODE = new SqlParameter("@OCODE", OCODE);
                    var REGIOID = new SqlParameter("@Region", ResionId);
                    var OFFICEID = new SqlParameter("@Office", OfficeId);
                    string SP_SQL = "HRM_RPT_EmployeeAgeOverRetieredmentForOffice @OCODE,@Region,@Office";
                    return (_context.ExecuteStoreQuery<REmployee>(SP_SQL, O_CODE, REGIOID, OFFICEID)).ToList();
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        internal List<REmployee> GetAllEmolyeeRetirementRPTForDept(string OCODE, int ResionId, int OfficeId, int departmentID)
        {
            try
            {
                using (var _context = new ERPSSLHBEntities())
                {
                    var O_CODE = new SqlParameter("@OCODE", OCODE);
                    var REGIOID = new SqlParameter("@Region", ResionId);
                    var OFFICEID = new SqlParameter("@Office", OfficeId);
                    var DEPTID = new SqlParameter("@Dept", departmentID);
                    string SP_SQL = "HRM_RPT_EmployeeAgeOverRetieredmentForDept @OCODE,@Region,@Office,@Dept";
                    return (_context.ExecuteStoreQuery<REmployee>(SP_SQL, O_CODE, REGIOID, OFFICEID, DEPTID)).ToList();
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        internal List<REmployee> GetAllEmolyeeRetirementRPT(string OCODE)
        {
            try
            {
                using (var _context = new ERPSSLHBEntities())
                {
                    var O_CODE = new SqlParameter("@OCODE", OCODE);
                    string SP_SQL = "HRM_RPT_EmployeeAgeOverRetieredment @OCODE";
                    return (_context.ExecuteStoreQuery<REmployee>(SP_SQL, O_CODE)).ToList();
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        internal List<REmployee> GetAllDismissalEmployeeForReport(string OCODE)
        {
            try
            {
                using (var _context = new ERPSSLHBEntities())
                {
                    var O_CODE = new SqlParameter("@OCODE", OCODE);
                    string SP_SQL = "HRM_RPT_DismissalEmployee @OCODE";
                    return (_context.ExecuteStoreQuery<REmployee>(SP_SQL, O_CODE)).ToList();
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        internal List<REmployee> GetAllDiedEmployeeForReport(string OCODE)
        {

            try
            {
                using (var _context = new ERPSSLHBEntities())
                {
                    var O_CODE = new SqlParameter("@OCODE", OCODE);
                    string SP_SQL = "HRM_RPT_DiedEmployee @OCODE";
                    return (_context.ExecuteStoreQuery<REmployee>(SP_SQL, O_CODE)).ToList();
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        internal List<REmployee> GetAllDiscontinuousEmployeeForReport(string OCODE)
        {
            try
            {
                using (var _context = new ERPSSLHBEntities())
                {
                    var O_CODE = new SqlParameter("@OCODE", OCODE);
                    string SP_SQL = "HRM_RPT_DiscontiniousEmployee @OCODE";
                    return (_context.ExecuteStoreQuery<REmployee>(SP_SQL, O_CODE)).ToList();
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        internal List<REmployee> GetAllOtherEmployeeForReport(string OCODE)
        {
            try
            {
                using (var _context = new ERPSSLHBEntities())
                {
                    var O_CODE = new SqlParameter("@OCODE", OCODE);
                    string SP_SQL = "HRM_RPT_OtherEmployee @OCODE";
                    return (_context.ExecuteStoreQuery<REmployee>(SP_SQL, O_CODE)).ToList();
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        internal List<REmployee> GetAllEmolyeeLenthOfServices(string OCODE)
        {
            try
            {
                using (var _context = new ERPSSLHBEntities())
                {
                    var O_CODE = new SqlParameter("@OCODE", OCODE);
                    string SP_SQL = "HRM_RPT_LenthOfService @OCODE";
                    return (_context.ExecuteStoreQuery<REmployee>(SP_SQL, O_CODE)).ToList();
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        internal List<REmployee> GetAllCurrentEmoployeeShiftWise(string OCODE, int region)
        {
            try
            {
                using (var _context = new ERPSSLHBEntities())
                {
                    var O_CODE = new SqlParameter("@ocode", OCODE);
                    var REGION = new SqlParameter("@region", region);
                    string SP_SQL = "HRM_Rpt_CurrentEmployeeShiftWiseRegion @ocode,@region";
                    return (_context.ExecuteStoreQuery<REmployee>(SP_SQL, O_CODE, REGION)).ToList();
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        internal List<HRM_ChildInfo> GeChildreansByEID(string Eid)
        {
            try
            {
                using (var _context = new ERPSSLHBEntities())
                {
                    return (from ch in _context.HRM_ChildInfo
                            where ch.EID == Eid
                            select ch).ToList();
                }




            }
            catch (Exception)
            {

                throw;
            }
        }

        internal HRM_ChildInfo getChildrenById(int childreanId)
        {
            try
            {
                using (var _context = new ERPSSLHBEntities())
                {
                    return (from ch in _context.HRM_ChildInfo
                            where ch.ChildId == childreanId
                            select ch).First();
                }




            }
            catch (Exception)
            {

                throw;
            }

        }

        internal List<REmployee> GetAllEmolyeeSalaryByRODSID(string OCODE, int ResionId, int OfficeId, int departmentID, int sectionId)
        {
            try
            {
                using (var _context = new ERPSSLHBEntities())
                {

                    var REGIOID = new SqlParameter("@Region", ResionId);
                    var OFFICEID = new SqlParameter("@Office", OfficeId);
                    var DEPTID = new SqlParameter("@Dept", departmentID);
                    var SectionId = new SqlParameter("@Section", sectionId);
                    string SP_SQL = "HRM_RPT_EmployeeSalaryStatusByRODSID @Region,@Office,@Dept,@Section";
                    return (_context.ExecuteStoreQuery<REmployee>(SP_SQL, REGIOID, OFFICEID, DEPTID, SectionId)).ToList();
                }

            }
            catch (Exception)
            {

                throw;
            }


        }

        internal List<REmployee> GetAllEmolyeeSalaryALLByRODSID()
        {
            try
            {
                using (var _context = new ERPSSLHBEntities())
                {
                    string SP_SQL = "HRM_RPT_EmployeeSalaryALLStatusByRODSID";
                    return (_context.ExecuteStoreQuery<REmployee>(SP_SQL)).ToList();
                }

            }
            catch (Exception)
            {

                throw;
            }


        }

        internal List<REmployee> GetSeparationSearchEmployeesList(string OCODE, string EmpSearch)
        {
            try
            {
                using (var _context = new ERPSSLHBEntities())
                {
                    var ParamempID = new SqlParameter("@OCODE", OCODE);
                    var ParamempID1 = new SqlParameter("@searchText", EmpSearch);
                    string SP_SQL = "HRM_GetEmployeSeparationListForSearch @OCODE,@searchText";
                    return (_context.ExecuteStoreQuery<REmployee>(SP_SQL, ParamempID, ParamempID1)).ToList();
                }

            }
            catch (Exception)
            {

                throw;
            }

        }

        internal List<REmployee> GeAlltSearchEmployeesList(string OCODE, string EmpSearch)
        {

            try
            {
                using (var _context = new ERPSSLHBEntities())
                {
                    var ParamempID = new SqlParameter("@OCODE", OCODE);
                    var ParamempID1 = new SqlParameter("@searchText", EmpSearch);
                    string SP_SQL = "HRM_SearchAllEmployesList @OCODE,@searchText";
                    return (_context.ExecuteStoreQuery<REmployee>(SP_SQL, ParamempID, ParamempID1)).ToList();
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        internal List<REmployee> GetTransferListBySearchitem(string OCODE, string EmpSearch)
        {
            try
            {
                using (var _context = new ERPSSLHBEntities())
                {
                    var ParamempID = new SqlParameter("@OCODE", OCODE);
                    var ParamempID1 = new SqlParameter("@searchText", EmpSearch);
                    string SP_SQL = "HRM_GetTransfered_EmployeesForSerach @OCODE,@searchText";
                    return (_context.ExecuteStoreQuery<REmployee>(SP_SQL, ParamempID, ParamempID1)).ToList();
                }

            }
            catch (Exception)
            {

                throw;
            }

        }

        internal int CheckBioIDExitance(string OCODE, string Requested_Eid)
        {

            try
            {
                return (from emp in context.HRM_PersonalInformations
                        where emp.BIO_MATRIX_ID == Requested_Eid && emp.OCODE == OCODE
                        select emp).Count();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }
        internal HRM_PersonalInformations GetPersonalInfoByEID(string Eid)
        {
            return context.HRM_PersonalInformations.Where(x => x.EID == Eid).FirstOrDefault();
        }
        internal string GetDesginationName(int? desid)
        {
            return context.HRM_DESIGNATIONS.FirstOrDefault(x => x.DEG_ID == desid).DEG_NAME;
        }
        internal string GetDepartmentName(int? departmentId)
        {
            return context.HRM_DEPARTMENTS.FirstOrDefault(x => x.DPT_ID == departmentId).DPT_NAME;
        }
        internal List<HRM_Office> GetofficesByRegionId(int? regionId, string OCODE)
        {
            return context.HRM_Office.Where(x => x.RegionId == regionId && x.OCODE == OCODE).ToList();
        }
        internal int GetMaxEid(string OCODE, string Eid)
        {
            try
            {
                HRM_EMP_TRANSFER hrmtrans = context.HRM_EMP_TRANSFER.Where(x => x.OCODE == OCODE && x.EID == Eid).OrderByDescending(x => x.TRANSFER_ID).FirstOrDefault();
                return hrmtrans.TRANSFER_ID;
            }
            catch (Exception)
            {

                throw;
            }
        }
        internal List<TransferR> GetEmployeeTransfer(int id)
        {
            using (var _context = new ERPSSLHBEntities())
            {
                return (from emp in _context.HRM_EMP_TRANSFER
                        join r in _context.HRM_PersonalInformations on emp.EID equals r.EID
                        where emp.TRANSFER_ID == id
                        select new TransferR
                        {
                            Id = emp.TRANSFER_ID,
                            EID = emp.EID,
                            Name = r.FirstName,
                            TransferDate = emp.TRANSFER_DATE
                        }).ToList();
            }
        }



        internal IEnumerable<REmployee> GetAllTerminatedrEmployeeForReport_byDate(string fromDate, string toDate, string OCODE)
        {
            try
            {
                using (var _context = new ERPSSLHBEntities())
                {
                    var ParamempID = new SqlParameter("@FromDate", fromDate);
                    var ParamempID1 = new SqlParameter("@ToDate", toDate);
                    var ParamempID2 = new SqlParameter("@OCODE", OCODE);
                    string SP_SQL = "HRM_RptTerminitateEmployee_ByDate @FromDate, @ToDate, @OCODE";
                    return (_context.ExecuteStoreQuery<REmployee>(SP_SQL, ParamempID, ParamempID1, ParamempID2)).ToList();
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        internal IEnumerable<REmployee> GetAllRetireddrEmployeeForReport_ByDate(string fromDate, string toDate, string OCODE)
        {
            try
            {
                using (var _context = new ERPSSLHBEntities())
                {
                    var ParamempID = new SqlParameter("@FromDate", fromDate);
                    var ParamempID1 = new SqlParameter("@ToDate", toDate);
                    var ParamempID2 = new SqlParameter("@OCODE", OCODE);
                    string SP_SQL = "HRM_RptRetiredEmployee_ByDate @FromDate, @ToDate, @OCODE";
                    return (_context.ExecuteStoreQuery<REmployee>(SP_SQL, ParamempID, ParamempID1, ParamempID2)).ToList();
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        internal IEnumerable<REmployee> GetAllResignedEmployeeForReport_ByDate(string fromDate, string toDate, string OCODE)
        {
            try
            {
                using (var _context = new ERPSSLHBEntities())
                {
                    var ParamempID = new SqlParameter("@FromDate", fromDate);
                    var ParamempID1 = new SqlParameter("@ToDate", toDate);
                    var ParamempID2 = new SqlParameter("@OCODE", OCODE);
                    string SP_SQL = "HRM_RptResignedEmployee_ByDate @FromDate, @ToDate, @OCODE";
                    return (_context.ExecuteStoreQuery<REmployee>(SP_SQL, ParamempID, ParamempID1, ParamempID2)).ToList();
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        internal IEnumerable<REmployee> GetAllDismissalEmployeeForReport_ByDate(string fromDate, string toDate, string OCODE)
        {
            try
            {
                using (var _context = new ERPSSLHBEntities())
                {
                    var ParamempID = new SqlParameter("@FromDate", fromDate);
                    var ParamempID1 = new SqlParameter("@ToDate", toDate);
                    var ParamempID2 = new SqlParameter("@OCODE", OCODE);
                    string SP_SQL = "HRM_RPT_DismissalEmployee_ByDate @FromDate, @ToDate, @OCODE";
                    return (_context.ExecuteStoreQuery<REmployee>(SP_SQL, ParamempID, ParamempID1, ParamempID2)).ToList();
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        internal IEnumerable<REmployee> GetAllDiedEmployeeForReport_ByDate(string fromDate, string toDate, string OCODE)
        {
            try
            {
                using (var _context = new ERPSSLHBEntities())
                {
                    var ParamempID = new SqlParameter("@FromDate", fromDate);
                    var ParamempID1 = new SqlParameter("@ToDate", toDate);
                    var ParamempID2 = new SqlParameter("@OCODE", OCODE);
                    string SP_SQL = "HRM_RPT_DiedEmployee_ByDate @FromDate, @ToDate, @OCODE";
                    return (_context.ExecuteStoreQuery<REmployee>(SP_SQL, ParamempID, ParamempID1, ParamempID2)).ToList();
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        internal IEnumerable<REmployee> GetAllDiscontinuousEmployeeForReport_ByDate(string fromDate, string toDate, string OCODE)
        {
            try
            {
                using (var _context = new ERPSSLHBEntities())
                {
                    var ParamempID = new SqlParameter("@FromDate", fromDate);
                    var ParamempID1 = new SqlParameter("@ToDate", toDate);
                    var ParamempID2 = new SqlParameter("@OCODE", OCODE);
                    string SP_SQL = "HRM_RPT_DiscontiniousEmployee_ByDate @FromDate, @ToDate, @OCODE";
                    return (_context.ExecuteStoreQuery<REmployee>(SP_SQL, ParamempID, ParamempID1, ParamempID2)).ToList();
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        internal int Update_PersonalInfo_DeductionDetails(HRM_PersonalInformations personalInfo, string EID)
        {
            try
            {
                HRM_PersonalInformations obj = context.HRM_PersonalInformations.First(x => x.EID == EID);

                obj.Tax_Amount = personalInfo.Tax_Amount;
                obj.EDIT_DATE = personalInfo.EDIT_DATE;
                obj.EDIT_USER = personalInfo.EDIT_USER;
                context.SaveChanges();

                return 1;
            }
            catch (Exception)
            {
                throw;
            }
        }

        internal IEnumerable<HRM_EMPLOYEES_VIEWER> Get_EmployeeDetailsByEID(string employeeID, string OCODE)
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
                        //join sep in _context.HRM_JOB_TERMINATE on emp.EID equals sep.EID

                        where emp.EID == employeeID && emp.OCODE == OCODE //&& emp.EMP_TERMIN_STATUS == false && emp.EMP_Retired_Status == false && emp.EMP_Resignation_Status == false && emp.EMP_Dismissal_Status == false && emp.EMP_Died_Status == false && emp.EMP_Dis_Continution_Status == false && emp.EMP_Other == false
                        select new HRM_EMPLOYEES_VIEWER
                        {

                            EMP_ID = (int)emp.EmpId,
                            EID = emp.EID,

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

                            GRADE = emp.Grade,
                            GorssSalary = (decimal)emp.Salary,
                            //STEP = (int)grd.STEP,
                            //GRADE_ID = grd.GRADE_ID,

                            EMP_FIRSTNAME = emp.FirstName,
                            EMP_LASTNAME = emp.LastName,
                            EmployeeFullName = emp.FirstName + " " + (emp.LastName ?? ""),
                            SHIFTCODE = emp.ShiftCode,
                            //TERMINATE_DATE = sep.TERMINATE_DATE,
                            //Status = sep.Status,
                            //REMARKS = sep.REMARKS,
                            //TERMINATE_ID = sep.TERMINATE_ID

                        }).ToList().OrderByDescending(x => x.TERMINATE_DATE);
            }
        }

        internal IEnumerable<HRM_EMPLOYEES_VIEWER> GetEmployee_Separation_Details(string employeeID, string OCODE)
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
                        join sep in _context.HRM_JOB_TERMINATE on emp.EID equals sep.EID

                        where emp.EID == employeeID && emp.OCODE == OCODE
                        select new HRM_EMPLOYEES_VIEWER
                        {

                            EMP_ID = (int)emp.EmpId,
                            EID = emp.EID,

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

                            GRADE = emp.Grade,
                            GorssSalary = (decimal)emp.Salary,
                            //STEP = (int)grd.STEP,
                            //GRADE_ID = grd.GRADE_ID,

                            EMP_FIRSTNAME = emp.FirstName,
                            EMP_LASTNAME = emp.LastName,
                            EmployeeFullName = emp.FirstName + " " + (emp.LastName ?? ""),
                            SHIFTCODE = emp.ShiftCode,
                            TERMINATE_DATE = sep.TERMINATE_DATE,
                            Status = sep.Status,
                            REMARKS = sep.REMARKS,
                            TERMINATE_ID = sep.TERMINATE_ID

                        }).ToList().OrderByDescending(x => x.TERMINATE_DATE);
            }
        }

        internal HRM_JOB_TERMINATE GetSeparationDate(string eId, string OCODE)
        {
            HRM_JOB_TERMINATE employee = context.HRM_JOB_TERMINATE.First(x => x.EID == eId);
            return employee;
        }
    }
}
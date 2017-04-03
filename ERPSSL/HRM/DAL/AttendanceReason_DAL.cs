using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ERPSSL.HRM.DAL;
using ERPSSL.HRM.BLL;
using System.Data.SqlClient;

namespace ERPSSL.HRM.DAL
{
    public class AttendanceReason_DAL
    {
        private ERPSSLHBEntities _context = new ERPSSLHBEntities();

        //-------Insert HRM_AttendanceReason------------------------------------
        public int InsertAttendanceReason(HRM_AttendanceReason objAttendanceReason)
        {
            try
            {

                _context.HRM_AttendanceReason.AddObject(objAttendanceReason);
                _context.SaveChanges();
                return 1;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        internal int UpdateAttReason(int Id, HRM_AttendanceReason objAttendanceReason)
        {
            try
            {
                HRM_AttendanceReason objAttReason = _context.HRM_AttendanceReason.First(x => x.ReasonId == Id);
                objAttReason.RegionId = objAttendanceReason.RegionId;
                objAttReason.OfficeId = objAttendanceReason.OfficeId;
                objAttReason.ShiftCode = objAttendanceReason.ShiftCode;
                objAttReason.ShiftName = objAttendanceReason.ShiftName;
                objAttReason.ReasonDate = objAttendanceReason.ReasonDate;
                objAttReason.InTime = objAttendanceReason.InTime;
                objAttReason.OutTime = objAttendanceReason.OutTime;
                objAttReason.LateAllowed = objAttendanceReason.LateAllowed;
                objAttReason.ReasonTypeId = objAttendanceReason.ReasonTypeId;
                objAttReason.ReasonType = objAttendanceReason.ReasonType;
                objAttReason.Remarks = objAttendanceReason.Remarks;
                objAttReason.Edit_User = objAttendanceReason.Edit_User;
                objAttReason.Edit_Date = objAttendanceReason.Edit_Date;
                objAttReason.OCode = objAttendanceReason.OCode;
                objAttReason.TotalHour = objAttendanceReason.TotalHour;

                _context.SaveChanges();
                return 1;

            }
            catch (Exception)
            {

                throw;
            }
        }

        //-------Insert HRM_AttendanceReason_Individual------------------------------------
        public int InsertAttendanceReasonIndividual(HRM_AttendanceReason_Individual objAttendanceReasonIndividual)
        {
            try
            {

                _context.HRM_AttendanceReason_Individual.AddObject(objAttendanceReasonIndividual);
                _context.SaveChanges();
                return 1;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        internal int UpdateAttReasonIndividual(HRM_AttendanceReason_Individual objAttendanceReasonIndividual,int Id)
        {
            try
            {
                HRM_AttendanceReason_Individual objAttReasonInd = _context.HRM_AttendanceReason_Individual.First(x => x.Ind_ReasonId == Id);
                objAttReasonInd.EmpId = objAttendanceReasonIndividual.EmpId;
                objAttReasonInd.EID = objAttendanceReasonIndividual.EID;
                objAttReasonInd.Bio_MatrixId = objAttendanceReasonIndividual.Bio_MatrixId;
                objAttReasonInd.RegionId = objAttendanceReasonIndividual.RegionId;
                objAttReasonInd.OfficeId = objAttendanceReasonIndividual.OfficeId;
                objAttReasonInd.DepartmentId = objAttendanceReasonIndividual.DepartmentId;
                objAttReasonInd.ShiftCode = objAttendanceReasonIndividual.ShiftCode;
                objAttReasonInd.ShiftName = objAttendanceReasonIndividual.ShiftName;
                objAttReasonInd.ReasonDate = objAttendanceReasonIndividual.ReasonDate;
                objAttReasonInd.InTime = objAttendanceReasonIndividual.InTime;
                objAttReasonInd.OutTime = objAttendanceReasonIndividual.OutTime;
                objAttReasonInd.ReasonTypeId = objAttendanceReasonIndividual.ReasonTypeId;
                objAttReasonInd.ReasonType = objAttendanceReasonIndividual.ReasonType;
                objAttReasonInd.Remarks = objAttendanceReasonIndividual.Remarks;
                objAttReasonInd.Edit_User = objAttendanceReasonIndividual.Edit_User;
                objAttReasonInd.Edit_Date = objAttendanceReasonIndividual.Edit_Date;
                objAttReasonInd.OCode = objAttendanceReasonIndividual.OCode;
                objAttReasonInd.Shift_TotalHour = objAttendanceReasonIndividual.Shift_TotalHour;

                _context.SaveChanges();
                return 1;

            }
            catch (Exception)
            {

                throw;
            }
        }

        //-------Insert HRM_TimeScheduleByReligion------------------------------------
        public int InsertTimeScheduleByReligion(HRM_TimeScheduleByReligion objTimeScheduleByReligion)
        {
            try
            {

                _context.HRM_TimeScheduleByReligion.AddObject(objTimeScheduleByReligion);
                _context.SaveChanges();
                return 1;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        //-------GetAll HRM_AttendanceReason------------------------------------
        public virtual List<HRM_AttendanceReason> GetAllattReason(string OCODE)
        {
            try
            {
                var query = (from ar in _context.HRM_AttendanceReason
                             where ar.OCode == OCODE
                             select ar).OrderBy(ar => ar.ReasonId);

                return query.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        internal List<HRM_AttendanceReason> GetAllattReasonById(string id, string OCODE)
        {
            try
            {
                int arId = Convert.ToInt32(id);
                var query = from ar in _context.HRM_AttendanceReason
                             where ar.OCode == OCODE && ar.ReasonId == arId
                             select ar;

                return query.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        //-------GetAll HRM_AttendanceReason_Individual------------------------------------
        public virtual List<HRM_AttendanceReason_Individual> GetAllattReasonIndividual(string OCODE)
        {
            try
            {
                var query = (from ar in _context.HRM_AttendanceReason_Individual
                             where ar.OCode == OCODE
                             select ar).OrderBy(ar => ar.Ind_ReasonId);

                return query.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        public virtual List<HRM_AttendanceReason_Individual> GetAllattReasonIndividualById(string id, string OCODE)
        {
            try
            {
                int ariId = Convert.ToInt32(id);
                var query = from ar in _context.HRM_AttendanceReason_Individual
                            where ar.OCode == OCODE && ar.Ind_ReasonId == ariId
                            select ar;

                return query.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        //-------GetAll HRM_TimeScheduleByReligion------------------------------------
        public virtual List<HRM_TimeScheduleByReligion> GetAllTimeScheduleByReligion(string OCODE)
        {
            try
            {
                var query = (from ar in _context.HRM_TimeScheduleByReligion
                             where ar.OCode == OCODE
                             select ar).OrderBy(ar => ar.ReligionSechedule_Id);

                return query.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
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
                        join sft in _context.HRM_TIMESCHEDULE on emp.ShiftCode equals sft.ShiftCode
                        // join grd in _context.HRM_GRADE on emp.GradeId equals grd.GRADE_ID

                        where emp.EID == employeeID && emp.OCODE == OCODE
                        select new HRM_EMPLOYEES_VIEWER
                        {
                            EMP_ID = (int)emp.EmpId,
                            EID = emp.EID,
                            BIO_ID=emp.BIO_MATRIX_ID,
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

                            SHIFT=sft.ShiftName,
                            SHIFTCODE=sft.ShiftCode,
                            Shift_TotalHour=sft.TotalHour,

                            GRADE = emp.Grade,
                            GorssSalary = (decimal)emp.Salary,
                            //STEP = (int)grd.STEP,
                            //GRADE_ID = grd.GRADE_ID,

                            EMP_FIRSTNAME = emp.FirstName,
                            EMP_LASTNAME = emp.LastName

                            //EMP_CONTACT_NO = emp.EMP_CONTACT_NO,

                            //CONTRACT = srv.CONTRACT

                        }).ToList();
            }
        }

        internal int InsertAtt_ReasonIndByReligion(int regionId, int officeId, int departmentId, string religion, DateTime date, TimeSpan inTime, TimeSpan outTime, int reasonTypeId, string reasonType, string remarks, Guid editUser, DateTime editDate, string oCode)
        {
            try
            {
                using (var _context = new ERPSSLHBEntities())
                {
                    var ParamempID = new SqlParameter("@RegionId", regionId);
                    var ParamempID1 = new SqlParameter("@OfficeId", officeId);
                    var ParamempID2 = new SqlParameter("@DepartmentId", departmentId);
                    var ParamempID3 = new SqlParameter("@Religion", religion);
                    var ParamempID4 = new SqlParameter("@Date", date);
                    var ParamempID5 = new SqlParameter("@InTime", inTime);
                    var ParamempID6 = new SqlParameter("@OutTime", outTime);
                    var ParamempID7 = new SqlParameter("@ReasonTypeId", reasonTypeId);
                    var ParamempID8 = new SqlParameter("@ReasonType", reasonType);
                    var ParamempID9 = new SqlParameter("@Remarks", remarks);
                    var ParamempID10 = new SqlParameter("@Edit_User", editUser);
                    var ParamempID11 = new SqlParameter("@Edit_Date", editDate);
                    var ParamempID12 = new SqlParameter("@OCode", oCode);
                    string SP_SQL = "HRM_InsertReligionAttendance @RegionId,@OfficeId,@DepartmentId,@Religion,@Date,@InTime,@OutTime,@ReasonTypeId,@ReasonType,@Remarks,@Edit_User,@Edit_Date,@OCode";
                    _context.ExecuteStoreCommand(SP_SQL, ParamempID, ParamempID1, ParamempID2, ParamempID3, ParamempID4, ParamempID5, ParamempID6, ParamempID7, ParamempID8, ParamempID9, ParamempID10, ParamempID11, ParamempID12);

                    return 1;
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        internal int InsertAtt_ReasonIndByDepartment(int regionId, int officeId, int departmentId, DateTime date, TimeSpan inTime, TimeSpan outTime, int reasonTypeId, string reasonType, string remarks, Guid editUser, DateTime editDate, string oCode)
        {
            try
            {
                using (var _context = new ERPSSLHBEntities())
                {
                    var ParamempID = new SqlParameter("@RegionId", regionId);
                    var ParamempID1 = new SqlParameter("@OfficeId", officeId);
                    var ParamempID2 = new SqlParameter("@DepartmentId", departmentId);
                    var ParamempID4 = new SqlParameter("@Date", date);
                    var ParamempID5 = new SqlParameter("@InTime", inTime);
                    var ParamempID6 = new SqlParameter("@OutTime", outTime);
                    var ParamempID7 = new SqlParameter("@ReasonTypeId", reasonTypeId);
                    var ParamempID8 = new SqlParameter("@ReasonType", reasonType);
                    var ParamempID9 = new SqlParameter("@Remarks", remarks);
                    var ParamempID10 = new SqlParameter("@Edit_User", editUser);
                    var ParamempID11 = new SqlParameter("@Edit_Date", editDate);
                    var ParamempID12 = new SqlParameter("@OCode", oCode);
                    string SP_SQL = "HRM_InsertDepartmentAttendance @RegionId,@OfficeId,@DepartmentId,@Date,@InTime,@OutTime,@ReasonTypeId,@ReasonType,@Remarks,@Edit_User,@Edit_Date,@OCode";
                    _context.ExecuteStoreCommand(SP_SQL, ParamempID, ParamempID1, ParamempID2, ParamempID4, ParamempID5, ParamempID6, ParamempID7, ParamempID8, ParamempID9, ParamempID10, ParamempID11, ParamempID12);

                    return 1;
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        internal int InsertAttendanceReason(List<HRM_AttendanceReason> lstHRM_AttendanceReason)
        {
            try
            {
                foreach (HRM_AttendanceReason aHRM_AttendanceReason in lstHRM_AttendanceReason)
                {
                    _context.HRM_AttendanceReason.AddObject(aHRM_AttendanceReason);
                }
                _context.SaveChanges();
                return 1;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }

        }

    }
}
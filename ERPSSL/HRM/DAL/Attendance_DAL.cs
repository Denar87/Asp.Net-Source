using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ERPSSL.HRM.DAL;
using System.Data.SqlClient;
using ERPSSL.HRM.BLL;
using ERPSSL.PAYROLL.DAL.Repository;

namespace ERPSSL.HRM.DAL
{
    public class Attendance_DAL
    {
        // private HRM_Entities _context = new HRM_Entities();
        ERPSSLHBEntities _context = new ERPSSLHBEntities();
        //-------Insert------------------------------------
        public int InsertAttendance(HRM_ATTENDANCE objAtt)
        {
            try
            {


                _context.HRM_ATTENDANCE.AddObject(objAtt);
                _context.SaveChanges();
                return 1;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        public int InsertOTperiodic(HRM_TimeInoutOTCalculation objOTperiodic)
        {
            try
            {

                _context.HRM_TimeInoutOTCalculation.AddObject(objOTperiodic);
                _context.SaveChanges();
                return 1;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }


        public int InsertOfficeType(HRM_OfficialDay objOfficialDay)
        {
            try
            {

                _context.HRM_OfficialDay.AddObject(objOfficialDay);
                _context.SaveChanges();
                return 1;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        public int InsertMachineProblem(HRM_MachineReadableProblem aHRM_MachineReadableProblem)
        {
            try
            {

                _context.HRM_MachineReadableProblem.AddObject(aHRM_MachineReadableProblem);
                _context.SaveChanges();
                return 1;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        internal int UpdateAtt_WorkingDay(string OCODE, string dateTime, string workingDay)
        {
            try
            {
                using (var _context = new ERPSSLHBEntities())
                {
                    var ParamempID = new SqlParameter("@ocode", OCODE);
                    var ParamempID1 = new SqlParameter("@Date", dateTime);
                    var ParamempID2 = new SqlParameter("@WorkingDay", workingDay);
                    string SP_SQL = "HRM_UpdateOfficalDay @ocode,@Date,@WorkingDay";
                    _context.ExecuteStoreCommand(SP_SQL, ParamempID, ParamempID1, ParamempID2);

                    return 1;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        internal int UpdateOT_ByDate(DateTime fromDate, DateTime toDate)
        {
            try
            {
                using (var _context = new ERPSSLHBEntities())
                {
                    var ParamempID = new SqlParameter("@DateFrom", fromDate);
                    var ParamempID1 = new SqlParameter("@DateTo", toDate);
                    string SP_SQL = "HRM_OTCalculationDatewise @DateFrom,@DateTo";
                    _context.ExecuteStoreCommand(SP_SQL, ParamempID, ParamempID1);

                    return 1;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        internal List<HRM_EMPLOYEES_VIEWER> GetEmployeeBySectionId(int ResionId, int OfficeId, int DeptId, int sctionID, DateTime currentdate)
        {
            using (var _context = new ERPSSLHBEntities())
            {
                string CurrentDay = currentdate.DayOfWeek.ToString();

                return (from emp in _context.HRM_PersonalInformations
                        join dg in _context.HRM_DESIGNATIONS on emp.DesginationId equals dg.DEG_ID

                        join tim in _context.HRM_TIMESCHEDULE on emp.ShiftCode equals tim.ShiftCode

                        where emp.RegionsId == ResionId && emp.OfficeId == OfficeId && emp.DepartmentId == DeptId && emp.SectionId == sctionID && emp.EMP_TERMIN_STATUS == false && emp.EMP_Retired_Status == false && emp.EMP_Resignation_Status == false && emp.EMP_Dismissal_Status == false && emp.EMP_Died_Status == false && emp.EMP_Dis_Continution_Status == false && emp.EMP_Other == false
                        select new HRM_EMPLOYEES_VIEWER
                        {

                            EID = emp.EID,
                            FirstName = emp.FirstName,
                            LastName = emp.LastName,
                            // EmployeeFullName = emp.FirstName  + " " + emp.LastName == null ? " " : emp.LastName,
                            DEG_NAME = dg.DEG_NAME,
                            Is_Holiday = tim.Weekend1 == CurrentDay || tim.Weekend2 == CurrentDay ? "Hoilday" : "General",
                            DATE_JOINED = emp.JoiningDate,
                            PreviousSalary = (decimal)emp.Salary,
                            Tax_Amount = emp.Tax_Amount

                        }).ToList();
            }
        }
        internal List<HRM_EMPLOYEES_VIEWER> GetEmployeeByDepartmentID(int RegionId, int OfficeId, int DeptId, DateTime Currentdate)
        {
            using (var _context = new ERPSSLHBEntities())
            {
                string CurrentDay = Currentdate.DayOfWeek.ToString();

                return (from emp in _context.HRM_PersonalInformations
                        join dg in _context.HRM_DESIGNATIONS on emp.DesginationId equals dg.DEG_ID
                        join tim in _context.HRM_TIMESCHEDULE on emp.ShiftCode equals tim.ShiftCode
                        where emp.RegionsId == RegionId && emp.OfficeId == OfficeId && emp.DepartmentId == DeptId
                         && emp.EMP_TERMIN_STATUS == false && emp.EMP_Retired_Status == false && emp.EMP_Resignation_Status == false && emp.EMP_Dismissal_Status == false && emp.EMP_Died_Status == false && emp.EMP_Dis_Continution_Status == false && emp.EMP_Other == false

                        select new HRM_EMPLOYEES_VIEWER
                        {
                            EID = emp.EID,
                            FirstName = emp.FirstName,
                            LastName = emp.LastName,
                            EmployeeFullName = emp.FirstName ?? "" + emp.LastName ?? "",
                            DEG_NAME = dg.DEG_NAME,
                            Is_Holiday = tim.Weekend1 == CurrentDay || tim.Weekend2 == CurrentDay ? "Hoilday" : "General",
                            DATE_JOINED = emp.JoiningDate,
                            PreviousSalary = (decimal)emp.Salary
                        }).ToList();
            }
        }
        internal IEnumerable<BankAdviceRe> GetBankAdviceByDepartmentId(string Ocode, string dptId, string fromDate)
        {
            try
            {
                using (var _context = new ERPSSLHBEntities())
                {
                    // v

                    var ParamempID2 = new SqlParameter("@Ocode", Ocode);
                    var ParamempID3 = new SqlParameter("@DptId", dptId);
                    var ParamempID4 = new SqlParameter("@FormDate", fromDate);
                    string SP_SQL = "HRM_Bank_AdviceByDepartmentId @Ocode,@DptId,@FormDate";
                    return _context.ExecuteStoreQuery<BankAdviceRe>(SP_SQL, ParamempID2, ParamempID3, ParamempID4).ToList();
                }


            }
            catch (Exception)
            {
                throw;
            }
        }
        internal IEnumerable<BankAdviceRe> GetMobileBankAdvice(string Ocode, string fromDate)
        {
            try
            {
                using (var _context = new ERPSSLHBEntities())
                {
                    // v

                    var ParamempID2 = new SqlParameter("@Ocode", Ocode);
                    var ParamempID4 = new SqlParameter("@FormDate", fromDate);
                    string SP_SQL = "HRM_MobileBank_Advice @Ocode,@FormDate";
                    return _context.ExecuteStoreQuery<BankAdviceRe>(SP_SQL, ParamempID2, ParamempID4).ToList();
                }


            }
            catch (Exception)
            {
                throw;
            }
        }


        internal IEnumerable<BankAdviceRe> GetInfo_WithOutBankInfo(string Ocode, string fromDate)
        {
            try
            {
                using (var _context = new ERPSSLHBEntities())
                {
                    // v

                    var ParamempID2 = new SqlParameter("@Ocode", Ocode);
                    var ParamempID4 = new SqlParameter("@FormDate", fromDate);
                    string SP_SQL = "HRM_WithOutBank_Advice_RPT @Ocode,@FormDate";
                    return _context.ExecuteStoreQuery<BankAdviceRe>(SP_SQL, ParamempID2, ParamempID4).ToList();
                }


            }
            catch (Exception)
            {
                throw;
            }
        }

        internal IEnumerable<BankAdviceRe> GetOnlyBankAdvice(string Ocode, string fromDate)
        {
            try
            {
                using (var _context = new ERPSSLHBEntities())
                {
                    // v

                    var ParamempID2 = new SqlParameter("@Ocode", Ocode);
                    var ParamempID4 = new SqlParameter("@FormDate", fromDate);
                    string SP_SQL = "HRM_Bank_Advice_RPT @Ocode,@FormDate";
                    return _context.ExecuteStoreQuery<BankAdviceRe>(SP_SQL, ParamempID2, ParamempID4).ToList();
                }


            }
            catch (Exception)
            {
                throw;
            }
        }
        internal IEnumerable<BankAdviceRe> GetBankAdviceAll(string OCODE)
        {
            try
            {
                using (var _context = new ERPSSLHBEntities())
                {
                    var ParamempID = new SqlParameter("@OCODE", OCODE);
                    string SP_SQL = "HRM_Bank_AdviceAll @OCODE";
                    return (_context.ExecuteStoreQuery<BankAdviceRe>(SP_SQL, ParamempID)).ToList();
                }


            }
            catch (Exception)
            {
                throw;
            }
        }

        internal IEnumerable<BankAdviceRe> GetBankAdviceByEid(string OCODE, string Eid, string fromDate)
        {
            try
            {
                using (var _context = new ERPSSLHBEntities())
                {
                    var ParamempID = new SqlParameter("@OCODE", OCODE);
                    var ParamempID1 = new SqlParameter("@Eid", Eid);
                    var ParamempID2 = new SqlParameter("@FormDate", fromDate);
                    //var ParamempID3 = new SqlParameter("@ToDate", toDate);

                    string SP_SQL = "HRM_Bank_AdviceByEID @OCODE,@Eid,@FormDate";
                    return (_context.ExecuteStoreQuery<BankAdviceRe>(SP_SQL, ParamempID, ParamempID1, ParamempID2)).ToList();
                }


            }
            catch (Exception)
            {
                throw;
            }
        }
        internal int UpdateAttStatus_ByDate(DateTime fromDate, DateTime toDate, string shiftCode)
        {
            try
            {
                using (var _context = new ERPSSLHBEntities())
                {
                    var ParamempID = new SqlParameter("@DateFrom", fromDate);
                    var ParamempID1 = new SqlParameter("@DateTo", toDate);
                    var ParamempID2 = new SqlParameter("@ShifCode", shiftCode);

                    string SP_SQL = "HRM_UpdateAttendance_Status @DateFrom,@DateTo,@ShifCode";
                    //string SP_SQL = "HRM_Update_Attendance_Status_ByShift @DateFrom,@DateTo,@ShifCode";
                    _context.ExecuteStoreCommand(SP_SQL, ParamempID, ParamempID1, ParamempID2);

                    return 1;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        internal int Update_AbsentLeaveStatus_ByDate(DateTime fromDate, DateTime toDate, string shiftCode, string OCODE, DateTime editdate, Guid userid)
        {
            try
            {
                using (var _context = new ERPSSLHBEntities())
                {
                    var ParamempID = new SqlParameter("@DateFrom", fromDate);
                    var ParamempID1 = new SqlParameter("@DateTo", toDate);
                    var ParamempID2 = new SqlParameter("@ShifCode", shiftCode);
                    var ParamempID3 = new SqlParameter("@OCODE", OCODE);
                    var ParamempID4 = new SqlParameter("@EditDate", editdate);
                    var ParamempID5 = new SqlParameter("@EditBy", userid);
                    //string SP_SQL = "HRM_UpdatAbsent_Leave_Holiday_Status @DateFrom,@DateTo,@ShifCode,@OCODE,@EditDate,@EditBy";
                    string SP_SQL = "HRM_Update_Absent_Leave_Holiday_Status_ByShift @DateFrom,@DateTo,@ShifCode,@OCODE,@EditDate,@EditBy";
                    _context.ExecuteStoreCommand(SP_SQL, ParamempID, ParamempID1, ParamempID2, ParamempID3, ParamempID4, ParamempID5);

                    return 1;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }


        internal int UpdateOTperiodic_ByDate(DateTime fromDate, DateTime toDate, string OCODE)
        {
            try
            {
                using (var _context = new ERPSSLHBEntities())
                {
                    var ParamempID = new SqlParameter("@DateFrom", fromDate);
                    var ParamempID1 = new SqlParameter("@DateTo", toDate);
                    var ParamempID2 = new SqlParameter("@OCODE", OCODE);
                    string SP_SQL = "HRM_OTperiodicDatewise @DateFrom,@DateTo,@OCODE";
                    _context.ExecuteStoreCommand(SP_SQL, ParamempID, ParamempID1, ParamempID2);

                    return 1;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }


        internal int InsertAtt_MachineProblem(HRM_ATTENDANCE objattendance)
        {
            try
            {
                using (var _context = new ERPSSLHBEntities())
                {
                    var ParamempID = new SqlParameter("@ShiftCode", objattendance.ShiftCode);
                    var ParamempID1 = new SqlParameter("@Att_Date", objattendance.Attendance_Date);
                    var ParamempID2 = new SqlParameter("@Att_Day", objattendance.Attendance_Day);
                    var ParamempID3 = new SqlParameter("@InTime", objattendance.In_Time);
                    var ParamempID4 = new SqlParameter("@OutTime", objattendance.Out_Time);
                    var ParamempID5 = new SqlParameter("@Working_Day", objattendance.Working_Day);
                    var ParamempID6 = new SqlParameter("@Remarks", objattendance.Remarks);
                    var ParamempID7 = new SqlParameter("@Edit_User", objattendance.Edit_User);
                    var ParamempID8 = new SqlParameter("@Edit_Date", objattendance.Edit_Date);
                    var ParamempID9 = new SqlParameter("@OCode", objattendance.OCode);
                    string SP_SQL = "HRM_InsertMachineProblem @ShiftCode,@Att_Date,@Att_Day,@InTime,@OutTime,@Working_Day,@Remarks,@Edit_User,@Edit_Date,@OCode";
                    _context.ExecuteStoreCommand(SP_SQL, ParamempID, ParamempID1, ParamempID2, ParamempID3, ParamempID4, ParamempID5, ParamempID6, ParamempID7, ParamempID8, ParamempID9);

                    return 1;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        internal int UpdateAttendance(int attId, HRM_ATTENDANCE attendaceObj)
        {
            try
            {
                HRM_ATTENDANCE attObj = _context.HRM_ATTENDANCE.First(x => x.ATTE_ID == attId);
                attObj.In_Time = attendaceObj.In_Time;
                attObj.Out_Time = attendaceObj.Out_Time;
                attObj.Status = attendaceObj.Status;
                attObj.Edit_Date = attendaceObj.Edit_Date;
                attObj.Edit_User = attendaceObj.Edit_User;
                attObj.OCode = attendaceObj.OCode;
                _context.SaveChanges();
                return 1;

            }
            catch (Exception)
            {

                throw;
            }
        }

        internal int UpdateAttendanceOT(int attId, HRM_ATTENDANCE attendaceObj)
        {
            try
            {
                HRM_ATTENDANCE attObj = _context.HRM_ATTENDANCE.First(x => x.ATTE_ID == attId);
                attObj.OT_ExtraAdd = attendaceObj.OT_ExtraAdd;
                attObj.OT_Deduction = attendaceObj.OT_Deduction;
                // attObj.OT_Total = attendaceObj.OT_Total;
                attObj.Edit_Date = attendaceObj.Edit_Date;
                attObj.Edit_User = attendaceObj.Edit_User;
                attObj.OCode = attendaceObj.OCode;
                _context.SaveChanges();
                return 1;

            }
            catch (Exception)
            {

                throw;
            }
        }


        //-------GetAll------------------------------------
        public virtual List<HRM_ATTENDANCE> GetAllAttendance(string OCODE)
        {
            try
            {
                var query = (from at in _context.HRM_ATTENDANCE
                             where at.OCode == OCODE
                             select at).OrderBy(at => at.ATTE_ID);
                return query.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        public virtual List<HRM_ATTENDANCE> GetAllAttendanceByDate(string OCODE, DateTime Att_Date)
        {
            try
            {
                var query = (from at in _context.HRM_ATTENDANCE
                             where at.OCode == OCODE && at.Attendance_Date == Att_Date
                             select at).OrderBy(at => at.ATTE_ID);
                return query.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }


        public virtual List<HRM_ATTENDANCE> GetAttendanceByShift_Date(string OCODE, string ShiftCode)
        {
            try
            {
                var query = (from at in _context.HRM_ATTENDANCE
                             where at.OCode == OCODE && at.ShiftCode == ShiftCode
                             select at).OrderBy(at => at.Attendance_Date);
                return query.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        public virtual List<HRM_ATTENDANCE> GetAttendanceByEID(string OCODE, string eID)
        {
            try
            {
                var query = (from at in _context.HRM_ATTENDANCE
                             where at.OCode == OCODE && at.EID == eID
                             select at).OrderBy(at => at.Attendance_Date);
                return query.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        public virtual List<HRM_ATTENDANCE> GetAttendanceByEIDByDate(string OCODE, string eID, DateTime date)
        {
            try
            {
                var query = (from at in _context.HRM_ATTENDANCE
                             where at.OCode == OCODE && at.EID == eID && at.Attendance_Date.Value.Month == date.Month && at.Attendance_Date.Value.Year == date.Year
                             select at).OrderBy(at => at.Attendance_Date);
                return query.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        public virtual List<HRM_ATTENDANCE> GetAttendanceByEID(string eid)
        {
            try
            {
                var query = (from at in _context.HRM_ATTENDANCE
                             where at.EID == eid
                             select at).OrderBy(at => at.Attendance_Date);
                return query.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        internal List<HRM_ATTENDANCE> GetAttendanceById(string attId, string OCODE)
        {
            try
            {
                int aId = Convert.ToInt32(attId);
                //HRM_ReasonType obj = _context.HRM_ReasonType.First(x => x.ReasonTypeId == eId);
                var query = (from Att in _context.HRM_ATTENDANCE
                             where Att.OCode == OCODE && Att.ATTE_ID == aId
                             select Att).OrderBy(Att => Att.ATTE_ID);

                return query.ToList();



            }
            catch (Exception)
            {

                throw;
            }
        }

        public virtual List<HRM_OfficialDay> GetAllOfficeDay(string OCODE, DateTime date)
        {
            try
            {
                var query = (from at in _context.HRM_OfficialDay
                             where at.OCode == OCODE && at.Official_Date == date
                             select at).OrderBy(at => at.OfficialDay_Id);
                return query.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        public virtual List<HRM_MachineReadableProblem> GetAllMachineProblem(string OCODE)
        {
            try
            {
                var query = (from at in _context.HRM_MachineReadableProblem
                             where at.OCode == OCODE
                             select at).OrderBy(at => at.MachineProblem_Id);
                return query.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        internal List<HRM_EMPLOYEES_VIEWER> GetEmployeeByRODSSUID(int ResionId, int OfficeId, int DeptId, int sctionID, int subsction)
        {

            using (var _context = new ERPSSLHBEntities())
            {
                return (from emp in _context.HRM_PersonalInformations
                        join dg in _context.HRM_DESIGNATIONS on emp.DesginationId equals dg.DEG_ID
                        where emp.RegionsId == ResionId && emp.OfficeId == OfficeId && emp.DepartmentId == DeptId && emp.SectionId == sctionID && emp.SubSectionId == subsction && emp.EMP_TERMIN_STATUS == false && emp.EMP_Retired_Status == false && emp.EMP_Resignation_Status == false && emp.EMP_Dismissal_Status == false && emp.EMP_Died_Status == false && emp.EMP_Dis_Continution_Status == false && emp.EMP_Other == false
                        select new HRM_EMPLOYEES_VIEWER
                        {

                            EID = emp.EID,
                            FirstName = emp.FirstName,
                            LastName = emp.LastName,
                            EmployeeFullName = emp.FirstName ?? "" + " " + emp.LastName ?? "",
                            DEG_NAME = dg.DEG_NAME,
                            Attendance_Bouns = emp.Attendance_Bouns ?? false,
                            Late_Applicable = emp.Late_Applicable ?? false,
                            Absence_Applicable = emp.Absence_Applicable ?? false,
                            Tax_Applicable = emp.Tax_Applicable ?? false,
                            PF_Applicable = emp.PF_Applicable ?? false,
                            On_Amount = emp.On_Amount,
                            SHIFTCODE = emp.ShiftCode,
                            OT_Applicable = emp.OTApplicable ?? false

                        }).ToList();
            }


        }


        internal List<HRM_EMPLOYEES_VIEWER> GetEmployeeByRODSSUID(int ResionId, int OfficeId, int DeptId, int sctionID, int subsction, DateTime currentdate)
        {

            using (var _context = new ERPSSLHBEntities())
            {
                string CurrentDay = currentdate.DayOfWeek.ToString();

                return (from emp in _context.HRM_PersonalInformations
                        join dg in _context.HRM_DESIGNATIONS on emp.DesginationId equals dg.DEG_ID

                        join tim in _context.HRM_TIMESCHEDULE on emp.ShiftCode equals tim.ShiftCode

                        where emp.RegionsId == ResionId && emp.OfficeId == OfficeId && emp.DepartmentId == DeptId && emp.SectionId == sctionID && emp.SubSectionId == subsction && emp.EMP_TERMIN_STATUS == false && emp.EMP_Retired_Status == false && emp.EMP_Resignation_Status == false && emp.EMP_Dismissal_Status == false && emp.EMP_Died_Status == false && emp.EMP_Dis_Continution_Status == false && emp.EMP_Other == false
                        select new HRM_EMPLOYEES_VIEWER
                        {

                            EID = emp.EID,
                            FirstName = emp.FirstName,
                            LastName = emp.LastName,
                            // EmployeeFullName = emp.FirstName  + " " + emp.LastName == null ? " " : emp.LastName,
                            DEG_NAME = dg.DEG_NAME,
                            Is_Holiday = tim.Weekend1 == CurrentDay || tim.Weekend2 == CurrentDay ? "Hoilday" : "General",
                            DATE_JOINED = emp.JoiningDate,
                            PreviousSalary = (decimal)emp.Salary,
                            BasicSalary = (decimal)dg.BASIC,
                            Tax_Amount = emp.Tax_Amount
                        }).ToList();
            }


        }
        TimeSpan time = TimeSpan.Parse("00:00:00");
        internal List<HRM_EMPLOYEES_VIEWER> GetEmployeesByEidForAttendance(string eid, DateTime fromDate, DateTime toDate)
        {
            using (var _context = new ERPSSLHBEntities())
            {
                return (from emp in _context.HRM_PersonalInformations.AsQueryable()
                        join dg in _context.HRM_DESIGNATIONS on emp.DesginationId equals dg.DEG_ID
                        join atn in _context.HRM_ATTENDANCE on emp.EID equals atn.EID
                        where emp.EID == eid && (atn.Attendance_Date >= fromDate && atn.Attendance_Date <= toDate)
                        select new HRM_EMPLOYEES_VIEWER
                        {
                            EID = emp.EID,
                            FirstName = emp.FirstName,
                            LastName = emp.LastName,
                            // EmployeeFullName = emp.FirstName  + " " + emp.LastName == null ? " " : emp.LastName,
                            DEG_NAME = dg.DEG_NAME,
                            AttendanceDate = (DateTime)atn.Attendance_Date,
                            In_Time = atn.In_Time,
                            Out_Time = atn.Out_Time,

                            //In_Time = (atn.In_Time == null ? time : atn.In_Time),
                            //Out_Time = (atn.Out_Time == null ? time : atn.Out_Time),
                            Status = atn.Status
                        }).ToList();
            }
        }


        internal int UpdateAttendance(List<HRM_ATTENDANCE> attendances, string type)
        {

            using (var _context = new ERPSSLHBEntities())
            {
                //var ParamempID = new SqlParameter("@DateFrom", fromDate);
                //var ParamempID1 = new SqlParameter("@DateTo", toDate);

                //string SP_SQL = "HRM_OTCalculationDatewise @DateFrom,@DateTo";
                //_context.ExecuteStoreCommand(SP_SQL, ParamempID, ParamempID1);

                foreach (HRM_ATTENDANCE aitem in attendances)
                {

                    var ParamempID = new SqlParameter("@EID", aitem.EID);
                    var ParamempID1 = new SqlParameter("@AttendanceDate", aitem.Attendance_Date);
                    var ParamempID2 = new SqlParameter("@AttendanceDay", aitem.Attendance_Day);
                    var ParamempID3 = new SqlParameter("@Remark", aitem.Remarks);
                    var ParamempID4 = new SqlParameter("@EntryType", type);
                    var ParamempID5 = new SqlParameter("@Status", aitem.Attendance_Process_Status);
                    var ParamempID6 = new SqlParameter("@Intime", aitem.In_Time);
                    var ParamempID7 = new SqlParameter("@OutTime", aitem.Out_Time);
                    var ParamempID8 = new SqlParameter("@OCODE", aitem.OCode);
                    var ParamempID9 = new SqlParameter("@EditDate", aitem.Edit_Date);
                    var ParamempID10 = new SqlParameter("@EditUser", aitem.Edit_User);
                    var ParamempID11 = new SqlParameter("@WorkingDay", aitem.Working_Day);

                    string SP_SQL = "AttendanceUpdateInout @EID,@AttendanceDate,@AttendanceDay,@Remark,@EntryType,@Status,@Intime,@OutTime,@OCODE,@EditDate,@EditUser,@WorkingDay";
                    _context.ExecuteStoreCommand(SP_SQL, ParamempID, ParamempID1, ParamempID2, ParamempID3, ParamempID4, ParamempID5, ParamempID6, ParamempID7, ParamempID8, ParamempID9, ParamempID10, ParamempID11);
                }

                return 1;
            }
        }

        internal int ManualOTUpdate(List<HRM_ATTENDANCE> attendances, string apprvedBy, string OThour)
        {

            try
            {
                foreach (HRM_ATTENDANCE aitem in attendances)
                {
                    var ParamempID = new SqlParameter("@EID", aitem.EID);
                    var ParamempID1 = new SqlParameter("@AttendanceDate", aitem.Attendance_Date);
                    var ParamempID2 = new SqlParameter("@Remark", aitem.Remarks);
                    var ParamempID3 = new SqlParameter("@PunishedBY", apprvedBy);
                    var ParamempID4 = new SqlParameter("@TOHour", OThour);

                    string SP_SQL = "HRM_ManualOTUpdate @EID,@AttendanceDate,@Remark,@PunishedBY,@TOHour";
                    _context.ExecuteStoreCommand(SP_SQL, ParamempID, ParamempID1, ParamempID2, ParamempID3, ParamempID4);
                }

                return 1;


            }
            catch (Exception)
            {

                throw;
            }
        }

        internal int AttendanceAdjustment(List<HRM_ATTENDANCE> attendances, string PunishedBy)
        {
            try
            {
                foreach (HRM_ATTENDANCE aitem in attendances)
                {
                    var ParamempID = new SqlParameter("@EID", aitem.EID);
                    var ParamempID1 = new SqlParameter("@AttendanceDate", aitem.Attendance_Date);
                    var ParamempID2 = new SqlParameter("@Remark", aitem.Remarks);
                    var ParamempID3 = new SqlParameter("@PunishedBY", PunishedBy);
                    var ParamempID4 = new SqlParameter("@OCODE", aitem.OCode);
                    var ParamempID5 = new SqlParameter("@EditDate", aitem.Edit_Date);
                    var ParamempID6 = new SqlParameter("@EditUser", aitem.Edit_User);

                    string SP_SQL = "AttendanceAdjustment @EID,@AttendanceDate,@Remark,@PunishedBY,@OCODE,@EditDate,@EditUser";
                    _context.ExecuteStoreCommand(SP_SQL, ParamempID, ParamempID1, ParamempID2, ParamempID3, ParamempID4, ParamempID5, ParamempID6);


                    //var ParamempID = new SqlParameter("@EID", aitem.EID);
                    //var ParamempID1 = new SqlParameter("@AttendanceDate", aitem.Attendance_Date);
                    //var ParamempID2 = new SqlParameter("@Remark", aitem.Remarks);
                    //var ParamempID3 = new SqlParameter("@PunishedBY", PunishedBy);

                    //var ParamempID4 = new SqlParameter("@OCODE", aitem.OCode);
                    //var ParamempID5 = new SqlParameter("@EditDate", aitem.Edit_Date);
                    //// var ParamempID6 = new SqlParameter("@EditUser", aitem.Edit_User);


                    //string SP_SQL = "AttendanceAdjustment @EID,@AttendanceDate,@Remark,@PunishedBY,@OCODE,@EditDate";
                    //_context.ExecuteStoreCommand(SP_SQL, ParamempID, ParamempID1, ParamempID2, ParamempID3, ParamempID4, ParamempID5);
                }

                return 1;


            }
            catch (Exception)
            {

                throw;
            }
        }

        internal List<HRM_EMPLOYEES_VIEWER> GetEmployeeByOfficeID(int DeptId, DateTime Currentdate)
        {
            using (var _context = new ERPSSLHBEntities())
            {
                string CurrentDay = Currentdate.DayOfWeek.ToString();

                return (from emp in _context.HRM_PersonalInformations
                        join dg in _context.HRM_DESIGNATIONS on emp.DesginationId equals dg.DEG_ID
                        join tim in _context.HRM_TIMESCHEDULE on emp.ShiftCode equals tim.ShiftCode
                        where emp.DepartmentId == DeptId
                         && emp.EMP_TERMIN_STATUS == false && emp.EMP_Retired_Status == false && emp.EMP_Resignation_Status == false && emp.EMP_Dismissal_Status == false && emp.EMP_Died_Status == false && emp.EMP_Dis_Continution_Status == false && emp.EMP_Other == false

                        select new HRM_EMPLOYEES_VIEWER
                        {
                            EID = emp.EID,
                            FirstName = emp.FirstName,
                            LastName = emp.LastName,
                            EmployeeFullName = emp.FirstName ?? "" + emp.LastName ?? "",
                            DEG_NAME = dg.DEG_NAME,
                            Is_Holiday = tim.Weekend1 == CurrentDay || tim.Weekend2 == CurrentDay ? "Hoilday" : "General",
                            DATE_JOINED = emp.JoiningDate,
                            PreviousSalary = (decimal)emp.Salary,
                            BasicSalary = (decimal)dg.BASIC
                        }).ToList();
            }
        }

        internal List<HRM_EMPLOYEES_VIEWER> GetEmployeeByOfficeID(int DeptId)
        {
            using (var _context = new ERPSSLHBEntities())
            {
                return (from emp in _context.HRM_PersonalInformations
                        join dg in _context.HRM_DESIGNATIONS on emp.DesginationId equals dg.DEG_ID

                        where emp.DepartmentId == DeptId
                         && emp.EMP_TERMIN_STATUS == false && emp.EMP_Retired_Status == false && emp.EMP_Resignation_Status == false && emp.EMP_Dismissal_Status == false && emp.EMP_Died_Status == false && emp.EMP_Dis_Continution_Status == false && emp.EMP_Other == false
                        select new HRM_EMPLOYEES_VIEWER
                        {
                            EID = emp.EID,
                            FirstName = emp.FirstName,
                            LastName = emp.LastName,
                            EmployeeFullName = emp.FirstName ?? "" + emp.LastName ?? "",
                            DEG_NAME = dg.DEG_NAME,
                            Attendance_Bouns = emp.Attendance_Bouns ?? false,
                            Late_Applicable = emp.Late_Applicable ?? false,
                            Absence_Applicable = emp.Absence_Applicable ?? false,
                            Tax_Applicable = emp.Tax_Applicable ?? false,
                            PF_Applicable = emp.PF_Applicable ?? false,
                            On_Amount = emp.On_Amount ?? false,
                            Tax_Amount = emp.Tax_Amount,
                            OT_Applicable = emp.OTApplicable ?? false

                        }).ToList();
            }
        }

        internal List<HRM_EMPLOYEES_VIEWER> GetEmployeeByID(string eid)
        {
            using (var _context = new ERPSSLHBEntities())
            {
                return (from emp in _context.HRM_PersonalInformations
                        join dg in _context.HRM_DESIGNATIONS on emp.DesginationId equals dg.DEG_ID
                        where emp.EID == eid
                         && emp.EMP_TERMIN_STATUS == false && emp.EMP_Retired_Status == false && emp.EMP_Resignation_Status == false && emp.EMP_Dismissal_Status == false && emp.EMP_Died_Status == false && emp.EMP_Dis_Continution_Status == false && emp.EMP_Other == false
                        select new HRM_EMPLOYEES_VIEWER
                        {

                            EID = emp.EID,
                            FirstName = emp.FirstName,
                            LastName = emp.LastName,
                            EmployeeFullName = emp.FirstName ?? "" + " " + emp.LastName ?? "",
                            DEG_NAME = dg.DEG_NAME,
                            Attendance_Bouns = emp.Attendance_Bouns ?? false,
                            Late_Applicable = emp.Late_Applicable ?? false,
                            Absence_Applicable = emp.Absence_Applicable ?? false,
                            Tax_Applicable = emp.Tax_Applicable ?? false,
                            PF_Applicable = emp.PF_Applicable ?? false,
                            On_Amount = emp.On_Amount,
                            OT_Applicable = emp.OTApplicable ?? false

                        }).ToList();
            }

        }

        internal int UpdateOT_ByDateandShift(DateTime fromDate, DateTime toDate, string shiftCode)
        {
            try
            {
                using (var _context = new ERPSSLHBEntities())
                {
                    var ParamempID = new SqlParameter("@DateFrom", fromDate);
                    var ParamempID1 = new SqlParameter("@DateTo", toDate);
                    var ParamempID2 = new SqlParameter("@ShiftCode", shiftCode);
                    string SP_SQL = "HRM_OTCalculationDatewiseByShift @DateFrom,@DateTo,@ShiftCode";
                    _context.ExecuteStoreCommand(SP_SQL, ParamempID, ParamempID1, ParamempID2);

                    return 1;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }


        internal List<string> GetAllShiftCode(string OCODE)
        {
            List<string> shiftCodes = null;
            using (var _context = new ERPSSLHBEntities())
            {

                shiftCodes = (from at in _context.HRM_ATTENDANCE
                              where at.OCode == OCODE
                              select at.ShiftCode).Distinct().ToList();
            }
            return shiftCodes;

        }

        internal int UpdateOTperiodic_ByDate01to15(DateTime dateTime1, DateTime dateTime2, string OCODE)
        {
            try
            {
                using (var _context = new ERPSSLHBEntities())
                {
                    var ParamempID = new SqlParameter("@DateFrom", dateTime1);
                    var ParamempID1 = new SqlParameter("@DateTo", dateTime2);
                    var ParamempID2 = new SqlParameter("@OCODE", OCODE);
                    string SP_SQL = "HRM_Attenadance_OTperiodicDatewise @DateFrom,@DateTo,@OCODE";
                    _context.CommandTimeout = 300;
                    _context.ExecuteStoreCommand(SP_SQL, ParamempID, ParamempID1, ParamempID2);

                    return 1;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        internal int UpdateOTperiodic_ByDate16to31(DateTime dateTime1, DateTime dateTime2, string OCODE)
        {
            try
            {
                using (var _context = new ERPSSLHBEntities())
                {
                    var ParamempID = new SqlParameter("@DateFrom", dateTime1);
                    var ParamempID1 = new SqlParameter("@DateTo", dateTime2);
                    var ParamempID2 = new SqlParameter("@OCODE", OCODE);
                    string SP_SQL = "HRM_Attenadance_OTperiodicDatewise1 @DateFrom,@DateTo,@OCODE";
                    _context.CommandTimeout = 300;
                    _context.ExecuteStoreCommand(SP_SQL, ParamempID, ParamempID1, ParamempID2);

                    return 1;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        internal int UpdateOffialType(HRM_OfficialDay aHRM_OfficialDay, DateTime Official_Date)
        {
            try
            {
                HRM_OfficialDay compObj = _context.HRM_OfficialDay.First(x => x.Official_Date == Official_Date);
                compObj.Working_Day = aHRM_OfficialDay.Working_Day;
                compObj.OT_Applicable = aHRM_OfficialDay.OT_Applicable;
                compObj.Edit_User = aHRM_OfficialDay.Edit_User;
                compObj.Edit_Date = aHRM_OfficialDay.Edit_Date;

                _context.SaveChanges();
                return 1;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public virtual List<HRM_OfficialDay_Individual> GetAllOfficeDayById(string OCODE, string Eid, DateTime date)
        {
            try
            {
                var query = (from at in _context.HRM_OfficialDay_Individual
                             where at.OCode == OCODE && at.EID == Eid && at.Official_Date == date
                             select at).OrderBy(at => at.OfficialDay_Id);
                return query.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }
        internal int UpdateOffialTypeById(HRM_OfficialDay_Individual aHRM_OfficialDay, DateTime Official_Date, string Eid)
        {
            try
            {
                HRM_OfficialDay_Individual compObj = _context.HRM_OfficialDay_Individual.First(x => x.Official_Date == Official_Date && x.EID == Eid);
                compObj.Working_Day = aHRM_OfficialDay.Working_Day;
                compObj.OT_Applicable = aHRM_OfficialDay.OT_Applicable;
                compObj.Edit_User = aHRM_OfficialDay.Edit_User;
                compObj.Edit_Date = aHRM_OfficialDay.Edit_Date;

                _context.SaveChanges();
                return 1;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public int InsertOfficeTypeIndividual(HRM_OfficialDay_Individual objOfficialDay)
        {
            try
            {

                _context.HRM_OfficialDay_Individual.AddObject(objOfficialDay);
                _context.SaveChanges();
                return 1;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }
        internal int UpdateAtt_WorkingDayById(string OCODE, string Eid, string dateTime, string workingDay)
        {
            try
            {
                using (var _context = new ERPSSLHBEntities())
                {
                    var ParamempID = new SqlParameter("@ocode", OCODE);
                    var ParamempID1 = new SqlParameter("@Eid", Eid);
                    var ParamempID2 = new SqlParameter("@Date", dateTime);
                    var ParamempID3 = new SqlParameter("@WorkingDay", workingDay);
                    string SP_SQL = "HRM_UpdateOfficalDayById @ocode,@Eid,@Date,@WorkingDay";
                    _context.ExecuteStoreCommand(SP_SQL, ParamempID, ParamempID1, ParamempID2, ParamempID3);

                    return 1;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public virtual List<HRM_AttendanceReason_Individual> GetHRM_AttendanceReason_Individual(string EID, DateTime date)
        {
            try
            {
                var query = (from at in _context.HRM_AttendanceReason_Individual
                             where at.EID == EID && at.ReasonDate == date
                             select at).OrderBy(at => at.Ind_ReasonId);
                return query.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }



        internal List<HRM_EMPLOYEES_VIEWER> GetEmployeeByIDWithSalary(string eid, Decimal Salary, Decimal ToSalary)
        {

            using (var _context = new ERPSSLHBEntities())
            {
                return (from emp in _context.HRM_PersonalInformations
                        join dg in _context.HRM_DESIGNATIONS on emp.DesginationId equals dg.DEG_ID
                        where emp.EID == eid && (emp.Salary >= Salary && emp.Salary <= ToSalary)
                         && emp.EMP_TERMIN_STATUS == false && emp.EMP_Retired_Status == false && emp.EMP_Resignation_Status == false && emp.EMP_Dismissal_Status == false && emp.EMP_Died_Status == false && emp.EMP_Dis_Continution_Status == false && emp.EMP_Other == false
                        select new HRM_EMPLOYEES_VIEWER
                        {

                            EID = emp.EID,
                            FirstName = emp.FirstName,
                            LastName = emp.LastName,
                            EmployeeFullName = emp.FirstName ?? "" + " " + emp.LastName ?? "",
                            DEG_NAME = dg.DEG_NAME,
                            Attendance_Bouns = emp.Attendance_Bouns ?? false,
                            Late_Applicable = emp.Late_Applicable ?? false,
                            Absence_Applicable = emp.Absence_Applicable ?? false,
                            Tax_Applicable = emp.Tax_Applicable ?? false,
                            PF_Applicable = emp.PF_Applicable ?? false,
                            On_Amount = emp.On_Amount,
                            OT_Applicable = emp.OTApplicable ?? false


                        }).ToList();
            }
        }

        internal List<HRM_EMPLOYEES_VIEWER> GetEmployeeByOfficeIDWithSalary(int DeptId, Decimal Salary, Decimal ToSalary)
        {

            try
            {

                using (var _context = new ERPSSLHBEntities())
                {
                    return (from emp in _context.HRM_PersonalInformations
                            join dg in _context.HRM_DESIGNATIONS on emp.DesginationId equals dg.DEG_ID
                            where emp.DepartmentId == DeptId && (emp.Salary >= Salary && emp.Salary <= ToSalary)
                             && emp.EMP_TERMIN_STATUS == false && emp.EMP_Retired_Status == false && emp.EMP_Resignation_Status == false && emp.EMP_Dismissal_Status == false && emp.EMP_Died_Status == false && emp.EMP_Dis_Continution_Status == false && emp.EMP_Other == false
                            select new HRM_EMPLOYEES_VIEWER
                            {

                                EID = emp.EID,
                                FirstName = emp.FirstName,
                                LastName = emp.LastName,
                                EmployeeFullName = emp.FirstName ?? "" + " " + emp.LastName ?? "",
                                DEG_NAME = dg.DEG_NAME,
                                Attendance_Bouns = emp.Attendance_Bouns ?? false,
                                Late_Applicable = emp.Late_Applicable ?? false,
                                Absence_Applicable = emp.Absence_Applicable ?? false,
                                Tax_Applicable = emp.Tax_Applicable ?? false,
                                PF_Applicable = emp.PF_Applicable ?? false,
                                On_Amount = emp.On_Amount,
                                OT_Applicable = emp.OTApplicable ?? false



                            }).ToList();
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        internal List<HRM_EMPLOYEES_VIEWER> GetEmployeeByRODSSUIDWithSalry(int ResionId, int OfficeId, int DeptId, int sction, int subsction, Decimal Salary, Decimal ToSalary)
        {
            using (var _context = new ERPSSLHBEntities())
            {
                return (from emp in _context.HRM_PersonalInformations
                        join dg in _context.HRM_DESIGNATIONS on emp.DesginationId equals dg.DEG_ID
                        where emp.RegionsId == ResionId && (emp.Salary >= Salary && emp.Salary <= ToSalary)
                        && emp.OfficeId == OfficeId && emp.DepartmentId == DeptId && emp.SectionId == sction && emp.SubSectionId == subsction && emp.EMP_TERMIN_STATUS == false && emp.EMP_Retired_Status == false && emp.EMP_Resignation_Status == false && emp.EMP_Dismissal_Status == false && emp.EMP_Died_Status == false && emp.EMP_Dis_Continution_Status == false && emp.EMP_Other == false
                        select new HRM_EMPLOYEES_VIEWER
                        {

                            EID = emp.EID,
                            FirstName = emp.FirstName,
                            LastName = emp.LastName,
                            EmployeeFullName = emp.FirstName ?? "" + " " + emp.LastName ?? "",
                            DEG_NAME = dg.DEG_NAME,
                            Attendance_Bouns = emp.Attendance_Bouns ?? false,
                            Late_Applicable = emp.Late_Applicable ?? false,
                            Absence_Applicable = emp.Absence_Applicable ?? false,
                            Tax_Applicable = emp.Tax_Applicable ?? false,
                            PF_Applicable = emp.PF_Applicable ?? false,
                            On_Amount = emp.On_Amount,
                            OT_Applicable = emp.OTApplicable ?? false

                        }).ToList();
            }
        }

        internal int UpdateAttStatus_ByShift(DateTime fromDate, DateTime toDate, string shiftCode)
        {
            try
            {
                using (var _context = new ERPSSLHBEntities())
                {
                    var ParamempID = new SqlParameter("@DateFrom", fromDate);
                    var ParamempID1 = new SqlParameter("@DateTo", toDate);
                    var ParamempID2 = new SqlParameter("@ShifCode", shiftCode);

                    //string SP_SQL = "HRM_UpdateAttendance_Status @DateFrom,@DateTo,@ShifCode";
                    string SP_SQL = "HRM_Update_Attendance_Status_ByShift @DateFrom,@DateTo,@ShifCode";
                    _context.ExecuteStoreCommand(SP_SQL, ParamempID, ParamempID1, ParamempID2);

                    return 1;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        internal int Insert_AbsentLeaveStatus_ByShift(DateTime fromDate, DateTime toDate, string shiftCode, string OCODE, DateTime editdate, Guid userid)
        {
            try
            {
                using (var _context = new ERPSSLHBEntities())
                {
                    var ParamempID = new SqlParameter("@DateFrom", fromDate);
                    var ParamempID1 = new SqlParameter("@DateTo", toDate);
                    var ParamempID2 = new SqlParameter("@ShifCode", shiftCode);
                    var ParamempID3 = new SqlParameter("@OCODE", OCODE);
                    var ParamempID4 = new SqlParameter("@EditDate", editdate);
                    var ParamempID5 = new SqlParameter("@EditBy", userid);
                    //string SP_SQL = "HRM_UpdatAbsent_Leave_Holiday_Status @DateFrom,@DateTo,@ShifCode,@OCODE,@EditDate,@EditBy";
                    string SP_SQL = "HRM_Update_Absent_Leave_Holiday_Status_ByShift @DateFrom,@DateTo,@ShifCode,@OCODE,@EditDate,@EditBy";
                    _context.ExecuteStoreCommand(SP_SQL, ParamempID, ParamempID1, ParamempID2, ParamempID3, ParamempID4, ParamempID5);

                    return 1;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        internal int Insert_AttProcessLog(DateTime fromDate, DateTime toDate, Guid userId, DateTime editDate, string oCode)
        {
            try
            {
                using (var _context = new ERPSSLHBEntities())
                {
                    var ParamempID1 = new SqlParameter("@Date_From", fromDate);
                    var ParamempID2 = new SqlParameter("@Date_To", toDate);
                    var ParamempID3 = new SqlParameter("@Edit_User", userId);
                    var ParamempID4 = new SqlParameter("@Edit_Date", editDate);
                    var ParamempID5 = new SqlParameter("@OCODE", oCode);

                    string SP_SQL = "HRM_InsertAttendancesProcessLog @DateFrom,@DateTo, @Edit_User, @Edit_Date, @OCODE";
                    _context.ExecuteStoreCommand(SP_SQL, ParamempID1, ParamempID2, ParamempID3, ParamempID4, ParamempID5);

                    return 1;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public virtual List<HRM_ATTENDANCE> GetAllOTByDate(string OCODE, DateTime dateFrom, DateTime dateTo)
        {
            try
            {
                var query = (from at in _context.HRM_ATTENDANCE
                             where at.OCode == OCODE && at.Attendance_Date >= dateFrom && at.Attendance_Date <= dateTo && at.OT_Total > 0
                             select at).OrderBy(at => at.EID);
                return query.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        internal List<HRM_EMPLOYEES_VIEWER> GetEmployeeByOffice(int officeId, DateTime Currentdate)
        {
            using (var _context = new ERPSSLHBEntities())
            {
                string CurrentDay = Currentdate.DayOfWeek.ToString();

                return (from emp in _context.HRM_PersonalInformations
                        join dg in _context.HRM_DESIGNATIONS on emp.DesginationId equals dg.DEG_ID
                        join tim in _context.HRM_TIMESCHEDULE on emp.ShiftCode equals tim.ShiftCode
                        where emp.OfficeId == officeId
                         && emp.EMP_TERMIN_STATUS == false && emp.EMP_Retired_Status == false && emp.EMP_Resignation_Status == false && emp.EMP_Dismissal_Status == false && emp.EMP_Died_Status == false && emp.EMP_Dis_Continution_Status == false && emp.EMP_Other == false

                        select new HRM_EMPLOYEES_VIEWER
                        {
                            EID = emp.EID,
                            FirstName = emp.FirstName,
                            LastName = emp.LastName,
                            EmployeeFullName = emp.FirstName ?? "" + emp.LastName ?? "",
                            DEG_NAME = dg.DEG_NAME,
                            Is_Holiday = tim.Weekend1 == CurrentDay || tim.Weekend2 == CurrentDay ? "Hoilday" : "General"
                        }).ToList();
            }
        }
        internal List<HRM_EMPLOYEES_VIEWER> GetEmployeesByEid(string eid)
        {
            using (var _context = new ERPSSLHBEntities())
            {


                return (from emp in _context.HRM_PersonalInformations
                        join dg in _context.HRM_DESIGNATIONS on emp.DesginationId equals dg.DEG_ID
                        join tim in _context.HRM_TIMESCHEDULE on emp.ShiftCode equals tim.ShiftCode
                        where emp.EID == eid && emp.EMP_TERMIN_STATUS == false && emp.EMP_Retired_Status == false && emp.EMP_Resignation_Status == false && emp.EMP_Dismissal_Status == false && emp.EMP_Died_Status == false && emp.EMP_Dis_Continution_Status == false && emp.EMP_Other == false
                        select new HRM_EMPLOYEES_VIEWER
                        {

                            EID = emp.EID,
                            FirstName = emp.FirstName,
                            LastName = emp.LastName,
                            // EmployeeFullName = emp.FirstName  + " " + emp.LastName == null ? " " : emp.LastName,
                            DEG_NAME = dg.DEG_NAME,
                            DATE_JOINED = emp.JoiningDate,
                            PreviousSalary = (decimal)emp.Salary,
                            BasicSalary = (decimal)dg.BASIC
                        }).ToList();
            }

        }

        public virtual List<HRM_ATTENDANCE> GetAttendanceByEID_Date(string OCODE, string eid, DateTime attDate)
        {
            try
            {
                var query = (from at in _context.HRM_ATTENDANCE
                             where at.OCode == OCODE && at.EID == eid && at.Attendance_Date == attDate
                             select at).OrderBy(at => at.Attendance_Date);
                return query.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        internal int UpdateWorkingDay(List<HRM_OfficialDay_Individual> lstHRM_OfficialDay_Individual)
        {
            try
            {
                foreach (HRM_OfficialDay_Individual aHRM_OfficialDay_Individual in lstHRM_OfficialDay_Individual)
                {
                    HRM_OfficialDay_Individual obj = _context.HRM_OfficialDay_Individual.First(x => x.EID == aHRM_OfficialDay_Individual.EID);
                    obj.Working_Day = aHRM_OfficialDay_Individual.Working_Day;
                    obj.OCode = aHRM_OfficialDay_Individual.OCode;
                    obj.Edit_User = aHRM_OfficialDay_Individual.Edit_User;
                    obj.Edit_Date = aHRM_OfficialDay_Individual.Edit_Date;
                    _context.SaveChanges();
                }
                _context.SaveChanges();
                return 1;
            }
            catch (Exception)
            {
                throw;
            }
        }
        internal object Update_IndividualAttendance(List<HRM_ATTENDANCE> attendances)
        {
            foreach (HRM_ATTENDANCE atten in attendances)
            {
                HRM_ATTENDANCE _attenUpdate = _context.HRM_ATTENDANCE.Where(x => x.EID == atten.EID && x.Attendance_Date == atten.Attendance_Date).FirstOrDefault();
                _attenUpdate.EID = atten.EID;
                _attenUpdate.Attendance_Date = atten.Attendance_Date;
                _attenUpdate.In_Time = atten.In_Time;
                _attenUpdate.Out_Time = atten.Out_Time;
                _attenUpdate.Attendance_Process_Status = atten.Attendance_Process_Status;
                _attenUpdate.OCode = atten.OCode;
                _attenUpdate.Edit_Date = atten.Edit_Date;
                _attenUpdate.Edit_User = atten.Edit_User;

                _context.SaveChanges();
            }
            _context.SaveChanges();
            return 1;
        }

        internal List<HRM_EMPLOYEES_VIEWER> GetSalaryDeductionByEID(DateTime deductDate)
        {
            using (var _context = new ERPSSLHBEntities())
            {
                return (from emp in _context.HRM_PersonalInformations
                        join hh in _context.HRM_Salary_Deduction on emp.EID equals hh.EID
                        where emp.EMP_TERMIN_STATUS == false && emp.EMP_Retired_Status == false && emp.EMP_Resignation_Status == false && emp.EMP_Dismissal_Status == false && emp.EMP_Died_Status == false && emp.EMP_Dis_Continution_Status == false && emp.EMP_Other == false
                        select new HRM_EMPLOYEES_VIEWER
                        {
                            EID = emp.EID,
                            FirstName = emp.FirstName,
                            LastName = emp.LastName,
                            Id = hh.Id,
                            salaryDeductDay = (double)hh.Salary_DeductDay,
                            SalaryDeductDate = (DateTime)hh.Salary_DeductDate
                        }).ToList();
            }
        }

        internal int UpdateOT_ByShift_EID(DateTime fromDate, DateTime toDate, string ashiftcode, string Eid)
        {
            try
            {
                using (var _context = new ERPSSLHBEntities())
                {
                    var ParamempID = new SqlParameter("@DateFrom", fromDate);
                    var ParamempID1 = new SqlParameter("@DateTo", toDate);
                    var ParamempID2 = new SqlParameter("@ShiftCode", ashiftcode);
                    var ParamempID3 = new SqlParameter("@EID", Eid);

                    string SP_SQL = "HRM_OTCalculation_ByDate_Shift_EID @DateFrom,@DateTo,@ShiftCode,@EID";
                    _context.ExecuteStoreCommand(SP_SQL, ParamempID, ParamempID1, ParamempID2, ParamempID3);

                    return 1;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        internal int DeleteAttendance(List<HRM_ATTENDANCE> attendances, string PunishedBy)
        {
            try
            {
                foreach (HRM_ATTENDANCE aitem in attendances)
                {
                    var ParamempID = new SqlParameter("@EID", aitem.EID);
                    var ParamempID1 = new SqlParameter("@AttendanceDate", aitem.Attendance_Date);
                    var ParamempID2 = new SqlParameter("@Remark", aitem.Remarks);
                    var ParamempID3 = new SqlParameter("@PunishedBY", PunishedBy);

                    var ParamempID4 = new SqlParameter("@OCODE", aitem.OCode);
                    var ParamempID5 = new SqlParameter("@EditDate", aitem.Edit_Date);
                    // var ParamempID6 = new SqlParameter("@EditUser", aitem.Edit_User);

                    string SP_SQL = "HRM_DeleteAttendance @EID,@AttendanceDate,@Remark,@PunishedBY,@OCODE,@EditDate";
                    _context.ExecuteStoreCommand(SP_SQL, ParamempID, ParamempID1, ParamempID2, ParamempID3, ParamempID4, ParamempID5);
                }

                return 1;


            }
            catch (Exception)
            {

                throw;
            }
        }

        internal List<HRM_ATTENDANCE> GetAttendanceInfo_DateWise(DateTime FromDate)
        {
            using (var _context = new ERPSSLHBEntities())
            {
                return (from att in _context.HRM_ATTENDANCE
                        where att.Attendance_Date == FromDate
                        select att).ToList();
            }
        }

        internal int Delete_Attendance_ByEID_Date(string eid, DateTime attendate)
        {
            List<HRM_ATTENDANCE> attendences = _context.HRM_ATTENDANCE.Where(x => x.EID == eid && x.Attendance_Date == attendate).ToList();
            foreach (HRM_ATTENDANCE aitem in attendences)
            {
                _context.HRM_ATTENDANCE.DeleteObject(aitem);
                _context.SaveChanges();
            }
            return 1;
        }
        internal List<HRM_EMPLOYEES_VIEWER> GetEmployeeByDepartment(int RegionId, int OfficeId, int DeptId, DateTime EffectiveDate)
        {
            using (var _context = new ERPSSLHBEntities())
            {
                //string CurrentDay = Currentdate.DayOfWeek.ToString();

                var query = (from ic in _context.HRM_SalaryIncrement
                             join emp in _context.HRM_PersonalInformations on ic.EID equals emp.EID
                             join dg in _context.HRM_DESIGNATIONS on emp.DesginationId equals dg.DEG_ID
                             join tim in _context.HRM_TIMESCHEDULE on emp.ShiftCode equals tim.ShiftCode
                             where emp.RegionsId == RegionId && emp.OfficeId == OfficeId && emp.DepartmentId == DeptId && ic.EffectiveDate == EffectiveDate
                              && emp.EMP_TERMIN_STATUS == false && emp.EMP_Retired_Status == false && emp.EMP_Resignation_Status == false && emp.EMP_Dismissal_Status == false && emp.EMP_Died_Status == false && emp.EMP_Dis_Continution_Status == false && emp.EMP_Other == false

                             select new HRM_EMPLOYEES_VIEWER
                             {
                                 ID = ic.ID,
                                 EID = emp.EID,
                                 FirstName = emp.FirstName,
                                 LastName = emp.LastName,
                                 EmployeeFullName = emp.FirstName ?? "" + emp.LastName ?? "",
                                 DEG_NAME = dg.DEG_NAME,
                                 IncrementSalary = ic.IncrementSalary,
                                 IncrementDate = ic.IncrementDate,
                                 EffectiveDate = ic.EffectiveDate,
                                 //Is_Holiday = tim.Weekend1 == CurrentDay || tim.Weekend2 == CurrentDay ? "Hoilday" : "General",
                                 DATE_JOINED = emp.JoiningDate,
                                 PreviousSalary = (decimal)emp.Salary
                             });
                return query.ToList();
            }
        }

        internal List<HRM_EMPLOYEES_VIEWER> GetEmployeeBySubsectionWise(int ResionId, int OfficeId, int DeptId, int sction, int subsction, DateTime EffectiveDate)
        {
            using (var _context = new ERPSSLHBEntities())
            {
                return (from ic in _context.HRM_SalaryIncrement
                        join emp in _context.HRM_PersonalInformations on ic.EID equals emp.EID
                        join dg in _context.HRM_DESIGNATIONS on emp.DesginationId equals dg.DEG_ID
                        where emp.RegionsId == ResionId && emp.OfficeId == OfficeId && emp.DepartmentId == DeptId && emp.SectionId == sction && ic.EffectiveDate == EffectiveDate
                                && emp.SubSectionId == subsction && emp.EMP_TERMIN_STATUS == false && emp.EMP_Retired_Status == false
                                && emp.EMP_Resignation_Status == false && emp.EMP_Dismissal_Status == false && emp.EMP_Died_Status == false
                                && emp.EMP_Dis_Continution_Status == false && emp.EMP_Other == false
                        select new HRM_EMPLOYEES_VIEWER
                        {
                            ID = ic.ID,
                            EID = emp.EID,
                            FirstName = emp.FirstName,
                            LastName = emp.LastName,
                            EmployeeFullName = emp.FirstName ?? "" + " " + emp.LastName ?? "",
                            DEG_NAME = dg.DEG_NAME,
                            Attendance_Bouns = emp.Attendance_Bouns,
                            Late_Applicable = emp.Late_Applicable,
                            Absence_Applicable = emp.Absence_Applicable,
                            Tax_Applicable = emp.Tax_Applicable,
                            PF_Applicable = emp.PF_Applicable,
                            On_Amount = emp.On_Amount,
                            OT_Applicable = emp.OTApplicable,
                            SHIFTCODE = emp.ShiftCode
                        }).ToList();
            }
        }
        internal List<HRM_EMPLOYEES_VIEWER> GetEmployeesByE_id(string eid, DateTime EffectiveDate)
        {
            using (var _context = new ERPSSLHBEntities())
            {
                var query = (from ic in _context.HRM_SalaryIncrement
                             join emp in _context.HRM_PersonalInformations on ic.EID equals emp.EID
                             join dg in _context.HRM_DESIGNATIONS on emp.DesginationId equals dg.DEG_ID
                             join tim in _context.HRM_TIMESCHEDULE on emp.ShiftCode equals tim.ShiftCode
                             where emp.EID == eid && emp.EMP_TERMIN_STATUS == false && emp.EMP_Retired_Status == false && emp.EMP_Resignation_Status == false
                             && emp.EMP_Dismissal_Status == false && emp.EMP_Died_Status == false && emp.EMP_Dis_Continution_Status == false
                             && emp.EMP_Other == false && ic.EffectiveDate == EffectiveDate
                             select new HRM_EMPLOYEES_VIEWER
                             {
                                 ID = ic.ID,
                                 EID = emp.EID,
                                 FirstName = emp.FirstName,
                                 LastName = emp.LastName,
                                 DEG_NAME = dg.DEG_NAME,
                                 IncrementSalary = ic.IncrementSalary,
                                 IncrementDate = ic.IncrementDate,
                                 EffectiveDate = ic.EffectiveDate,
                                 DATE_JOINED = emp.JoiningDate,
                                 PreviousSalary = (decimal)emp.Salary
                             });
                return query.ToList();
            }
        }
    }
}
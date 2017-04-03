using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using ERPSSL.HRM.DAL;
using ERPSSL.HRM.DAL.Repository;
using ERPSSL.PAYROLL.DAL.Repository;

namespace ERPSSL.PAYROLL.DAL
{
    public class SalaryProccess_DAL
    {
        private ERPSSLHBEntities _context = new ERPSSLHBEntities();

        internal List<Attendance_Viewer> GetWeekend(string shiftCode)
        {
            try
            {
                using (var _context = new ERPSSLHBEntities())
                {
                    var ShiftCode = new SqlParameter("@ShifCode", shiftCode);
                    string SP_SQL = "HRM_Get_Weekend @ShifCode";
                    return (_context.ExecuteStoreQuery<Attendance_Viewer>(SP_SQL, ShiftCode)).ToList();
                }

            }
            catch (Exception)
            {
                throw;
            }
        }

        internal List<Salary_Viewer> Get_SalProccess_Temp(DateTime dateFrom)
        {
            try
            {
                using (var _context = new ERPSSLHBEntities())
                {
                    var sDate = new SqlParameter("@Date_From", dateFrom);
                    string SP_SQL = "HRM_Get_SalProccess @Date_From";
                    return (_context.ExecuteStoreQuery<Salary_Viewer>(SP_SQL, sDate)).ToList();
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        internal List<Salary_Viewer> Get_SalProccess_TempByShift(DateTime dateFrom, string shiftCode)
        {
            try
            {
                using (var _context = new ERPSSLHBEntities())
                {
                    var sDate = new SqlParameter("@Date_From", dateFrom);
                    var paramshift = new SqlParameter("@ShiftCode", shiftCode);
                    string SP_SQL = "HRM_Get_SalProccessByShift @Date_From,@ShiftCode";
                    return (_context.ExecuteStoreQuery<Salary_Viewer>(SP_SQL, sDate, paramshift)).ToList();
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        internal List<Salary_Viewer> Get_SalProccess_TempByOffice(DateTime dateFrom, int OfficeId)
        {
            try
            {
                using (var _context = new ERPSSLHBEntities())
                {
                    var sDate = new SqlParameter("@Date_From", dateFrom);
                    var paramOffice = new SqlParameter("@OfficeId", OfficeId);
                    string SP_SQL = "HRM_Get_SalProccessByOffice @Date_From,@OfficeId";
                    return (_context.ExecuteStoreQuery<Salary_Viewer>(SP_SQL, sDate, paramOffice)).ToList();
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        internal List<Salary_Viewer> Get_PendingSalaryByDate(DateTime dateFrom)
        {
            try
            {
                using (var _context = new ERPSSLHBEntities())
                {
                    var sDate = new SqlParameter("@Date_From", dateFrom);

                    string SP_SQL = "HRM_Get_PendingSalaryByDate @Date_From";
                    return (_context.ExecuteStoreQuery<Salary_Viewer>(SP_SQL, sDate)).ToList();
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        internal List<HRM_Pay_Salary> GetPaySalaryByDate(DateTime fromdate)
        {
            List<HRM_Pay_Salary> list = new List<HRM_Pay_Salary>();
            using (ERPSSLHBEntities ctx = new ERPSSLHBEntities())
            {
                try
                {
                    list = (from c in ctx.HRM_Pay_Salary
                            where c.Salary_Month == fromdate
                            select c).ToList();
                }
                catch
                {

                }
                return list;
            }

        }

        internal List<HRM_Pay_Salary> GetPaySalaryByDate_ByEID(DateTime fromdate, string eid)
        {
            List<HRM_Pay_Salary> list = new List<HRM_Pay_Salary>();
            using (ERPSSLHBEntities ctx = new ERPSSLHBEntities())
            {
                try
                {
                    list = (from c in ctx.HRM_Pay_Salary
                            where c.Salary_Month == fromdate && c.EID == eid
                            select c).ToList();
                }
                catch
                {

                }
                return list;
            }

        }

        public IEnumerable<Payroll> GetTotalNetPayableByDate(DateTime salaryMonth)
        {
            try
            {
                return (from pay in _context.HRM_Pay_Salary
                        where pay.Salary_Month == salaryMonth && pay.Pay_Status == true && pay.IsSalaryHeldup == false
                        group pay by salaryMonth into p
                        select new Payroll
                        {
                            Net_Payable = p.Sum(c => c.Net_Payable),
                        }).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<Payroll> GetTotalPayableByDate(DateTime salaryMonth)
        {
            try
            {
                return (from pay in _context.HRM_Pay_Salary
                        where pay.Salary_Month == salaryMonth
                        group pay by salaryMonth into p
                        select new Payroll
                        {
                            Net_Payable = p.Sum(c => c.Net_Payable + c.Total_Deduction),
                        }).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<Payroll> GetTotalTDSByDate(DateTime salaryMonth)
        {
            try
            {
                return (from pay in _context.HRM_Pay_Salary
                        where pay.Salary_Month == salaryMonth && pay.Pay_Status == true
                        group pay by salaryMonth into p
                        select new Payroll
                        {
                            TotalTax = p.Sum(c => c.Total_Tax),
                        }).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<Payroll> GetTotalAdvanceByDate(DateTime salaryMonth)
        {
            try
            {
                return (from pay in _context.HRM_Pay_Salary
                        where pay.Salary_Month == salaryMonth && pay.Pay_Status == true
                        group pay by salaryMonth into p
                        select new Payroll
                        {
                            AdvanceDeduction = p.Sum(c => c.AdvanceDeduction),
                        }).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<Payroll> GetTotalStampByDate(DateTime salaryMonth)
        {
            try
            {
                return (from pay in _context.HRM_Pay_Salary
                        where pay.Salary_Month == salaryMonth
                        group pay by salaryMonth into p
                        select new Payroll
                        {
                            Stamp = p.Sum(c => c.Stamp),
                        }).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<Payroll> GetTotalHeldUpByDate(DateTime salaryMonth)
        {
            try
            {
                return (from pay in _context.HRM_Pay_Salary
                        where pay.Salary_Month == salaryMonth && pay.Pay_Status == false && pay.IsSalaryHeldup == true
                        group pay by salaryMonth into p
                        select new Payroll
                        {
                            Net_Payable = p.Sum(c => c.Net_Payable),
                        }).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        internal List<HRM_PaySalary_Temp> GetSalaryTemp(string ocode, DateTime fromdate)
        {
            List<HRM_PaySalary_Temp> list = new List<HRM_PaySalary_Temp>();
            using (ERPSSLHBEntities ctx = new ERPSSLHBEntities())
            {
                try
                {
                    list = (from c in ctx.HRM_PaySalary_Temp
                            where c.OCode == ocode && c.Salary_Month == fromdate
                            select c).ToList();
                }
                catch
                {

                }
                return list;
            }

        }


        internal List<Salary_Viewer> GetHoliday(string OCODE, string startDate, string endDate)
        {
            try
            {
                using (var _context = new ERPSSLHBEntities())
                {

                    var sDate = new SqlParameter("@Date_From", startDate);
                    var eDate = new SqlParameter("@Date_To", endDate);
                    var oCode = new SqlParameter("@OCODE", OCODE);
                    string SP_SQL = "HRM_Get_Holiday @Date_From,@Date_To,@OCODE";
                    return (_context.ExecuteStoreQuery<Salary_Viewer>(SP_SQL, sDate, eDate, oCode)).ToList();
                }

            }
            catch (Exception)
            {
                throw;
            }
        }

        public int InsertPaySalary(HRM_Pay_Salary aHRM_Pay_Salary)
        {
            try
            {
                using (var _context = new ERPSSLHBEntities())
                {
                    _context.HRM_Pay_Salary.AddObject(aHRM_Pay_Salary);
                    _context.SaveChanges();
                    return 1;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        internal int DeleteSalaryTemp(int id)
        {
            try
            {
                using (var _context = new ERPSSLHBEntities())
                {
                    string SP_SQL = "delete from HRM_PaySalary_Temp where PaySalary_Temp_ID=" + id;
                    _context.ExecuteStoreCommand(SP_SQL);

                    return 1;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        internal int DeletePaySalaryByEIDandMonth(string eid, DateTime salaryMonth)
        {

            using (var _context = new ERPSSLHBEntities())
            {

                HRM_Pay_Salary paysalary = _context.HRM_Pay_Salary.FirstOrDefault(x => x.EID == eid && x.Salary_Month == salaryMonth);
                if (paysalary != null)
                {
                    _context.HRM_Pay_Salary.DeleteObject(paysalary);
                    _context.SaveChanges();

                }
                return 1;
            }
        }

        internal int InsertSalary_ProccessByOffice(DateTime dateFrom, DateTime dateTo, int totalDayofMonth, int totalWeekend, int totalHoliday, string shiftCode, string oCode, Guid edit_User, int OfficeId)
        {
            try
            {
                using (var _context = new ERPSSLHBEntities())
                {
                    var Param = new SqlParameter("@DATE_FROM", dateFrom);
                    var Param1 = new SqlParameter("@DATE_TO", dateTo);
                    var Param2 = new SqlParameter("@TOTAL_DAY_OF_MONTH", totalDayofMonth);
                    var Param3 = new SqlParameter("@TOTAL_WEEKEND", totalWeekend);
                    var Param4 = new SqlParameter("@TOTAL_OTH_HOLIDAY", totalHoliday);
                    var Param5 = new SqlParameter("@SHIFTCODE", shiftCode);
                    var Param6 = new SqlParameter("@OCODE", oCode);
                    var Param7 = new SqlParameter("@EDITUSER", edit_User);
                    var Param8 = new SqlParameter("@OfficeId", OfficeId);

                    string SP_SQL = "HRM_Get_Employee_SalProccessByOffice @DATE_FROM,@DATE_TO,@TOTAL_DAY_OF_MONTH,@TOTAL_WEEKEND,@TOTAL_OTH_HOLIDAY,@SHIFTCODE,@OCODE,@EDITUSER,@OfficeId";
                    _context.CommandTimeout = 100000;
                    _context.ExecuteStoreCommand(SP_SQL, Param, Param1, Param2, Param3, Param4, Param5, Param6, Param7, Param8);

                    return 1;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        internal int InsertSalary_Proccess(DateTime dateFrom, DateTime dateTo, int totalDayofMonth, int totalWeekend, int totalHoliday, string shiftCode, string oCode, Guid edit_User)
        {
            try
            {
                using (var _context = new ERPSSLHBEntities())
                {
                    var Param = new SqlParameter("@DATE_FROM", dateFrom);
                    var Param1 = new SqlParameter("@DATE_TO", dateTo);
                    var Param2 = new SqlParameter("@TOTAL_DAY_OF_MONTH", totalDayofMonth);
                    var Param3 = new SqlParameter("@TOTAL_WEEKEND", totalWeekend);
                    var Param4 = new SqlParameter("@TOTAL_OTH_HOLIDAY", totalHoliday);
                    var Param5 = new SqlParameter("@SHIFTCODE", shiftCode);
                    var Param6 = new SqlParameter("@OCODE", oCode);
                    var Param7 = new SqlParameter("@EDITUSER", edit_User);

                    string SP_SQL = "HRM_Get_Employee_SalProccess @DATE_FROM,@DATE_TO,@TOTAL_DAY_OF_MONTH,@TOTAL_WEEKEND,@TOTAL_OTH_HOLIDAY,@SHIFTCODE,@OCODE,@EDITUSER";
                    _context.ExecuteStoreCommand(SP_SQL, Param, Param1, Param2, Param3, Param4, Param5, Param6, Param7);

                    return 1;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        internal List<Salary_Viewer> GetIndividualPaySlip(string fromdate, string empId)
        {
            try
            {
                using (var _context = new ERPSSLHBEntities())
                {

                    var FromDate = new SqlParameter("@Date_From", fromdate);
                    var EmpId = new SqlParameter("@empId", empId);
                    string SP_SQL = "HRM_RPT_Get_SalaryInfoIndividual @Date_From,@empId";
                    return (_context.ExecuteStoreQuery<Salary_Viewer>(SP_SQL, FromDate, EmpId)).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        internal List<Salary_Viewer> GetAllPaySlip(string fromDate)
        {
            try
            {
                using (var _context = new ERPSSLHBEntities())
                {
                    var FromDate = new SqlParameter("@Date_From", fromDate);
                    string SP_SQL = "HRM_RPT_Get_SalaryInfo @Date_From";
                    return (_context.ExecuteStoreQuery<Salary_Viewer>(SP_SQL, FromDate)).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        internal List<Salary_Viewer> GetAllPaySlipBySubsection(int departmentId, string fromDate, int RegionId, int officeId, int sectionid, int subsectionId)
        {
            try
            {
                using (var _context = new ERPSSLHBEntities())
                {
                    var Department = new SqlParameter("@Dept", departmentId);  
                    var FromDate = new SqlParameter("@Date_From", fromDate);
                    var Region = new SqlParameter("@Region", RegionId);
                    var Office = new SqlParameter("@Office", officeId);                   
                    var Section = new SqlParameter("@SectionId", sectionid);
                    var SubSection = new SqlParameter("@SubSection", subsectionId);
                    string SP_SQL = "HRM_RPT_Get_SalaryInfoBySubSection @Dept, @Date_From,@Region,@Office,@SectionId,@SubSection";
                    return (_context.ExecuteStoreQuery<Salary_Viewer>(SP_SQL, Department, FromDate, Region, Office, Section, SubSection)).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }


        internal List<Salary_Viewer> GetAllPaySlip1(string fromDate)
        {
            try
            {
                using (var _context = new ERPSSLHBEntities())
                {
                    var FromDate = new SqlParameter("@Date_From", fromDate);
                    string SP_SQL = "HRM_RPT_Get_ALL_SalaryInfo1 @Date_From";
                    return (_context.ExecuteStoreQuery<Salary_Viewer>(SP_SQL, FromDate)).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        internal List<Salary_Viewer> GetAllPaySlip2(string fromDate)
        {
            try
            {
                using (var _context = new ERPSSLHBEntities())
                {
                    var FromDate = new SqlParameter("@Date_From", fromDate);
                    string SP_SQL = "HRM_RPT_Get_ALL_SalaryInfo2 @Date_From";
                    return (_context.ExecuteStoreQuery<Salary_Viewer>(SP_SQL, FromDate)).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        internal List<string> GetShiftCodeByOfficeID(int officeID)
        {
            List<string> shiftCodes = null;
            using (var _context = new ERPSSLHBEntities())
            {

                shiftCodes = (from P in _context.HRM_PersonalInformations
                              where P.OfficeId == officeID
                              select P.ShiftCode).Distinct().ToList();
            }
            return shiftCodes;

        }

        internal int DividedParySalaryInfo(DateTime date)
        {

            try
            {
                using (var _context = new ERPSSLHBEntities())
                {
                    var FromDate = new SqlParameter("@Datetime", date);
                    string SP_SQL = "HRM_Pay_salry_Divided @Datetime";
                    _context.ExecuteStoreCommand(SP_SQL, FromDate);
                    return 1;
                }
            }
            catch (Exception)
            {
                throw;
            }


        }

        internal int truncateTableHRM_PaySalary()
        {
            try
            {
                using (var _context = new ERPSSLHBEntities())
                {

                    string SP_SQL = "truncateTwoTable";
                    _context.ExecuteStoreCommand(SP_SQL);
                    return 1;
                }
            }
            catch (Exception)
            {
                throw;
            }

        }

        internal int Enter_VoucherDetails(string OCODE, string Company_Code, string Edit_User, string ModuleType, string VoucherType, HRM_Pay_Salary aHRM_Pay_Salary)
        {
            try
            {
                decimal Amount = 0;
                Amount = Convert.ToDecimal(Amount) + (Convert.ToDecimal(aHRM_Pay_Salary.Total_Gross_Sal));

                var Amount_ = new SqlParameter("@Amount", Amount);
                var ModuleType_ = new SqlParameter("@ModuleName", ModuleType);
                var VoucherType_ = new SqlParameter("@VoucherType", VoucherType);
                var Edit_User_ = new SqlParameter("@Edit_User", Edit_User);
                var Company_Code_ = new SqlParameter("@Company_Code", Company_Code);
                var OCode_ = new SqlParameter("@OCode", OCODE);
                var ItemCode_ = new SqlParameter("@ItemCode", "00");

                string SP_SQL = "Vch_Enter_AC_VoucherDetails_by_Module  @Amount,@ModuleName,@VoucherType,@Edit_User,@Company_Code,@OCode,@ItemCode";
                return (_context.ExecuteStoreCommand(SP_SQL, Amount_, ModuleType_, VoucherType_, Edit_User_, Company_Code_, OCode_, ItemCode_));

            }
            catch (Exception)
            {
                throw;
            }
        }

        internal int Enter_VoucherDetailsForTotalSalary(string OCODE, string Company_Code, string Edit_User, string ModuleName, string ModuleType, string VoucherType, decimal totalPayable, decimal netPayable, decimal heldUp, decimal TDS, decimal AdvanceDeduction, decimal Stamp, string IdentitiNo)
        {
            try
            {
                decimal Amount = 0; decimal Amount1 = 0; decimal Amount2 = 0; decimal Amount3 = 0; decimal Amount4 = 0; decimal Amount5 = 0;
                Amount = Convert.ToDecimal(Amount) + Convert.ToDecimal(totalPayable);
                Amount1 = Convert.ToDecimal(Amount1) + Convert.ToDecimal(netPayable);
                Amount2 = Convert.ToDecimal(Amount2) + Convert.ToDecimal(heldUp);
                Amount3 = Convert.ToDecimal(Amount3) + Convert.ToDecimal(TDS);
                Amount4 = Convert.ToDecimal(Amount4) + Convert.ToDecimal(AdvanceDeduction);
                Amount5 = Convert.ToDecimal(Amount5) + Convert.ToDecimal(Stamp);

                var Amount_ = new SqlParameter("@Amount", Amount);
                var Amount1_ = new SqlParameter("@NetPayable", Amount1);
                var Amount2_ = new SqlParameter("@TDS", Amount3);
                var Amount3_ = new SqlParameter("@HeldUp", Amount2);
                var Amount4_ = new SqlParameter("@AdvanceDeduction", Amount4);
                var Amount5_ = new SqlParameter("@StampDeduction", Amount5);
                var ModuleName_ = new SqlParameter("@ModuleName", ModuleName);
                var VoucherType_ = new SqlParameter("@VoucherType", VoucherType);
                var Edit_User_ = new SqlParameter("@Edit_User", Edit_User);
                var Company_Code_ = new SqlParameter("@Company_Code", Company_Code);
                var OCode_ = new SqlParameter("@OCode", OCODE);
                var ItemCode_ = new SqlParameter("@ItemCode", ModuleType);
                var Identity_ = new SqlParameter("@IdentificationNo", IdentitiNo);

                string SP_SQL = "Vch_Enter_AC_VoucherDetails_by_Module_Payroll  @Amount,@NetPayable,@TDS,@HeldUp,@AdvanceDeduction,@StampDeduction,@ModuleName,@VoucherType,@Edit_User,@Company_Code,@OCode,@ItemCode,@IdentificationNo";
                return (_context.ExecuteStoreCommand(SP_SQL, Amount_, Amount1_, Amount2_, Amount3_, Amount4_, Amount5_, ModuleName_, VoucherType_, Edit_User_, Company_Code_, OCode_, ItemCode_, Identity_));
            }
            catch (Exception)
            {
                throw;
            }
        }

        internal int UpdateHeldupSalary(List<HRM_Pay_Salary> lstHRM_Pay_Salary)
        {
            try
            {
                foreach (HRM_Pay_Salary aHRM_Pay_Salary in lstHRM_Pay_Salary)
                {
                    HRM_Pay_Salary obj = _context.HRM_Pay_Salary.First(x => x.PaySalary_ID == aHRM_Pay_Salary.PaySalary_ID);
                    obj.Pay_Status = aHRM_Pay_Salary.Pay_Status;
                    obj.IsSalaryHeldup = aHRM_Pay_Salary.IsSalaryHeldup;
                    obj.OCode = aHRM_Pay_Salary.OCode;
                    obj.Edit_User = aHRM_Pay_Salary.Edit_User;
                    obj.Edit_Date = aHRM_Pay_Salary.Edit_Date;
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

        internal List<HRM_Salary_Deduction> GetDuplicateData(string EID, string DeductionDate)
        {
            DateTime date = Convert.ToDateTime(DeductionDate.ToString());
            try
            {
                using (var _context = new ERPSSLHBEntities())
                {
                    var result = (from em in _context.HRM_Salary_Deduction
                                  where (em.EID == EID && em.Salary_DeductDate == date)
                                  select em).OrderBy(x => x.EID);



                    return result.ToList();

                }


            }
            catch (Exception)
            {

                throw;
            }
        }

        internal List<HRM_Salary_Punishment> GetAllSalaryPunishmentByEID(string EID, string month, int year)
        {

            try
            {
                using (var _context = new ERPSSLHBEntities())
                {
                    var result = (from em in _context.HRM_Salary_Punishment
                                  where (em.EID == EID && em.Salary_Month == month && em.Salary_Year == year)
                                  select em).OrderBy(x => x.EID);

                    return result.ToList();

                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        internal int Update_ConfirmSalary(DateTime fromDate, DateTime toDate, Guid userId, DateTime editDate, string oCode)
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

                    string SP_SQL = "HRM_Update_Confirm_Salary @Date_From,@Date_To, @Edit_User, @Edit_Date, @OCODE";
                    _context.ExecuteStoreCommand(SP_SQL, ParamempID1, ParamempID2, ParamempID3, ParamempID4, ParamempID5);

                    return 1;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        internal int UpdateAdvanceDeductStatus(HRM_AdvanceSalaryDetails aHRM_AdvanceSalaryDetails)
        {
            try
            {
                List<HRM_AdvanceSalaryDetails> attes = (from att in _context.HRM_AdvanceSalaryDetails
                                                        where att.Month == aHRM_AdvanceSalaryDetails.Month && att.Year == aHRM_AdvanceSalaryDetails.Year
                                                        select att).ToList();
                foreach (HRM_AdvanceSalaryDetails aitem in attes)
                {
                    aitem.AdvanceDeduction = aHRM_AdvanceSalaryDetails.AdvanceDeduction;
                    aitem.EDIT_USER = aHRM_AdvanceSalaryDetails.EDIT_USER;
                    aitem.EDIT_DATE = aHRM_AdvanceSalaryDetails.EDIT_DATE;
                    _context.SaveChanges();
                }
                //_context.SaveChanges();
                return 1;
            }
            catch (Exception)
            {
                throw;
            }
        }

        internal List<Salary_Viewer> Get_AllGeneartedSalaryByDate(DateTime dateFrom)
        {
            try
            {
                using (var _context = new ERPSSLHBEntities())
                {
                    var sDate = new SqlParameter("@Date_From", dateFrom);

                    string SP_SQL = "HRM_Get_AllGeneratedSalaryByDate @Date_From";
                    return (_context.ExecuteStoreQuery<Salary_Viewer>(SP_SQL, sDate)).ToList();
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }
        internal List<Salary_Viewer> GetAll_HeldUpList(string fromDate)
        {
            try
            {
                using (var _context = new ERPSSLHBEntities())
                {
                    var FromDate = new SqlParameter("@Date_From", fromDate);
                    string SP_SQL = "HRM_Get_HeldUpSalaryByDate @Date_From";
                    return (_context.ExecuteStoreQuery<Salary_Viewer>(SP_SQL, FromDate)).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        internal List<HRM_Salary_Deduction> GetSalaryDeductionByEID_Date(string EID, string DeductionDate)
        {
            DateTime date = Convert.ToDateTime(DeductionDate.ToString());
            try
            {
                using (var _context = new ERPSSLHBEntities())
                {
                    var result = (from em in _context.HRM_Salary_Deduction
                                  where (em.EID == EID && em.Salary_DeductDate == date)
                                  select em).OrderBy(x => x.EID);

                    return result.ToList();

                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        internal List<HRM_Pay_Salary_Deduction> GetAllSalaryPunishmentByAmount(string EID, string month, int year)
        {
            try
            {
                using (var _context = new ERPSSLHBEntities())
                {
                    var result = (from em in _context.HRM_Pay_Salary_Deduction
                                  where (em.EID == EID && em.Deduct_Month == month && em.Deduct_Year == year)
                                  select em).OrderBy(x => x.EID);

                    return result.ToList();

                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
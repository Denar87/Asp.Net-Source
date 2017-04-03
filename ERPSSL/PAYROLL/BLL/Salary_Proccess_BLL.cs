using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ERPSSL.HRM.DAL;
using ERPSSL.PAYROLL.DAL;
using ERPSSL.HRM.DAL.Repository;
using ERPSSL.PAYROLL.DAL.Repository;

namespace ERPSSL.PAYROLL.BLL
{
    public class Salary_Proccess_BLL
    {
        SalaryProccess_DAL aSalaryProccess_DAL = new SalaryProccess_DAL();

        internal List<Attendance_Viewer> GetWeekend(string shiftCode)
        {
            return aSalaryProccess_DAL.GetWeekend(shiftCode);
        }

        internal List<Salary_Viewer> Get_SalProccess_Temp(DateTime dateFrom)
        {
            return aSalaryProccess_DAL.Get_SalProccess_Temp(dateFrom);
        }

        internal List<Salary_Viewer> Get_SalProccess_TempByOffice(DateTime dateFrom,int OfficeId)
        {
            return aSalaryProccess_DAL.Get_SalProccess_TempByOffice(dateFrom, OfficeId);
        }

        internal List<Salary_Viewer> Get_PendingSalaryByDate(DateTime dateFrom)
        {
            return aSalaryProccess_DAL.Get_PendingSalaryByDate(dateFrom);
        }

        internal List<Salary_Viewer> Get_SalProccess_TempByShift(DateTime dateFrom, string shiftCode)
        {
            return aSalaryProccess_DAL.Get_SalProccess_TempByShift(dateFrom, shiftCode);
        }

        internal List<Salary_Viewer> GetHoliday(string OCODE, string startDate, string endDate)
        {
            return aSalaryProccess_DAL.GetHoliday(OCODE, startDate, endDate);
        }

        internal List<HRM_PaySalary_Temp> GetSalaryTemp(string OCODE, DateTime startDate)
        {
            return aSalaryProccess_DAL.GetSalaryTemp(OCODE, startDate);
        }

        internal List<HRM_Pay_Salary> GetPaySalaryByDate(DateTime startDate)
        {
            return aSalaryProccess_DAL.GetPaySalaryByDate(startDate);
        }

        internal List<HRM_Pay_Salary> GetPaySalaryByDate_ByEID(DateTime startDate, string eid)
        {
            return aSalaryProccess_DAL.GetPaySalaryByDate_ByEID(startDate, eid);
        }

        public int InsertPaySalary(HRM_Pay_Salary aHRM_Pay_Salary)
        {
            return aSalaryProccess_DAL.InsertPaySalary(aHRM_Pay_Salary);
        }

        internal int InsertSalary_Proccess(DateTime dateFrom, DateTime dateTo, int totalDayofMonth, int totalWeekend, int totalHoliday, string shiftCode, string oCode, Guid edit_User)
        {
            return aSalaryProccess_DAL.InsertSalary_Proccess(dateFrom, dateTo, totalDayofMonth, totalWeekend, totalHoliday, shiftCode, oCode, edit_User);
        }

        internal int InsertSalary_ProccessByOffice(DateTime dateFrom, DateTime dateTo, int totalDayofMonth, int totalWeekend, int totalHoliday, string shiftCode, string oCode, Guid edit_User, int OfficeId)
        {
            return aSalaryProccess_DAL.InsertSalary_ProccessByOffice(dateFrom, dateTo, totalDayofMonth, totalWeekend, totalHoliday, shiftCode, oCode, edit_User, OfficeId);
        }

        internal int DeleteSalaryTemp(int id)
        {
            return aSalaryProccess_DAL.DeleteSalaryTemp(id);
        }

        internal int DeletePaySalaryByEIDandMonth(string eid, DateTime salaryMonth)
        {
            return aSalaryProccess_DAL.DeletePaySalaryByEIDandMonth(eid, salaryMonth);
        }

        internal List<Salary_Viewer> GetIndividualPaySlip(string fromdate, string empId)
        {
            return aSalaryProccess_DAL.GetIndividualPaySlip(fromdate, empId);
        }

        internal List<Salary_Viewer> GetAllPaySlip(string fromDate)
        {
            return aSalaryProccess_DAL.GetAllPaySlip(fromDate);
        }

        internal List<Salary_Viewer> GetAllPaySlip1(string fromDate)
        {
            return aSalaryProccess_DAL.GetAllPaySlip1(fromDate);
        }
        internal List<Salary_Viewer> GetAllPaySlip2(string fromDate)
        {
            return aSalaryProccess_DAL.GetAllPaySlip2(fromDate);
        }

        internal List<string> GetShiftCodeByOfficeID(int officeID)
        {
            return aSalaryProccess_DAL.GetShiftCodeByOfficeID(officeID);
        }

        internal int DividedParySalaryInfo(DateTime date)
        {
            return aSalaryProccess_DAL.DividedParySalaryInfo(date);

        }

        internal int truncateTableHRM_PaySalary()
        {
            return aSalaryProccess_DAL.truncateTableHRM_PaySalary();
        }


        internal int Enter_VoucherDetails(string OCODE, string Company_Code, string Edit_User, string ModuleType, string VoucherType, HRM_Pay_Salary aHRM_Pay_Salary)
        {
            return aSalaryProccess_DAL.Enter_VoucherDetails(OCODE, Company_Code, Edit_User, ModuleType, VoucherType, aHRM_Pay_Salary);
        }

        internal int Enter_VoucherDetailsForTotalSalary(string OCODE, string Company_Code, string Edit_User, string ModuleName, string ModuleType, string VoucherType, decimal totalPayable, decimal netPayable, decimal heldUp, decimal TDS, decimal AdvanceDeduction, decimal Stamp, string IdentitiNo)
        {
            return aSalaryProccess_DAL.Enter_VoucherDetailsForTotalSalary(OCODE, Company_Code, Edit_User, ModuleName, ModuleType, VoucherType, totalPayable, netPayable, heldUp, TDS, AdvanceDeduction, Stamp, IdentitiNo);
        }

        internal IEnumerable<Payroll> GetTotalNetPayableByDate(DateTime salarymonth)
        {
            return aSalaryProccess_DAL.GetTotalNetPayableByDate(salarymonth);
        }

        internal IEnumerable<Payroll> GetTotalPayableByDate(DateTime salarymonth)
        {
            return aSalaryProccess_DAL.GetTotalPayableByDate(salarymonth);

        }

        internal IEnumerable<Payroll> GetTotalTDSByDate(DateTime salarymonth)
        {
            return aSalaryProccess_DAL.GetTotalTDSByDate(salarymonth);
        }

        internal IEnumerable<Payroll> GetTotalAdvanceByDate(DateTime salarymonth)
        {
            return aSalaryProccess_DAL.GetTotalAdvanceByDate(salarymonth);
        }

        internal IEnumerable<Payroll> GetTotalStampByDate(DateTime salarymonth)
        {
            return aSalaryProccess_DAL.GetTotalStampByDate(salarymonth);
        }


        internal IEnumerable<Payroll> GetTotalHeldUpByDate(DateTime salarymonth)
        {
            return aSalaryProccess_DAL.GetTotalHeldUpByDate(salarymonth);
        }

        internal int UpdateHeldupSalary(List<HRM_Pay_Salary> lstHRM_Pay_Salary)
        {
            return aSalaryProccess_DAL.UpdateHeldupSalary(lstHRM_Pay_Salary);
        }

        internal List<HRM_Salary_Deduction> GetDuplicateData(string EID, string DeductionDate)
        {

          return  aSalaryProccess_DAL.GetDuplicateData(EID, DeductionDate);
        }

        internal List<HRM_Salary_Punishment> GetAllSalaryPunishmentByEID(string EID, string month, int year)
        {

            return aSalaryProccess_DAL.GetAllSalaryPunishmentByEID(EID, month, year);
        }

        internal int Update_ConfirmSalary(DateTime fromDate, DateTime toDate, Guid userId, DateTime editDate, string oCode)
        {
            return aSalaryProccess_DAL.Update_ConfirmSalary(fromDate, toDate, userId, editDate, oCode);
        }

        internal int UpdateAdvanceDeductStatus(HRM_AdvanceSalaryDetails aHRM_AdvanceSalaryDetails)
        {
            return aSalaryProccess_DAL.UpdateAdvanceDeductStatus(aHRM_AdvanceSalaryDetails);
        }
        internal List<Salary_Viewer> Get_AllGeneartedSalaryByDate(DateTime dateFrom)
        {
            return aSalaryProccess_DAL.Get_AllGeneartedSalaryByDate(dateFrom);
        }
        internal List<Salary_Viewer> GetAll_HeldUpList(string fromDate)
        {
            return aSalaryProccess_DAL.GetAll_HeldUpList(fromDate);
        }
        internal List<Salary_Viewer> GetAllPaySlipBySubsection(int departmentId, string fromDate, int RegionId, int officeId, int sectionid, int subsectionId)
        {
            return aSalaryProccess_DAL.GetAllPaySlipBySubsection(departmentId, fromDate, RegionId, officeId, sectionid, subsectionId);
        }

        internal List<HRM_Salary_Deduction> GetSalaryDeductionByEID_Date(string EID, string DeductionDate)
        {

            return aSalaryProccess_DAL.GetSalaryDeductionByEID_Date(EID, DeductionDate);
        }
        internal List<HRM_Pay_Salary_Deduction> GetAllSalaryPunishmentByAmount(string EID, string month, int year)
        {

            return aSalaryProccess_DAL.GetAllSalaryPunishmentByAmount(EID, month, year);
        }
    }


}
 
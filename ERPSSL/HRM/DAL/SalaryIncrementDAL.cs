using ERPSSL.HRM.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPSSL.HRM.DAL
{
    public class SalaryIncrementDAL
    {
        ERPSSLHBEntities _context = new ERPSSLHBEntities();
        internal int InsertSalryIncrementLog(List<HRM_SalaryIncrement> SalaryIncrementslog)
        {
            foreach (HRM_SalaryIncrement aitem in SalaryIncrementslog)
            {
                _context.HRM_SalaryIncrement.AddObject(aitem);
                _context.SaveChanges();
            }
            return 1;

        }

        internal List<HRM_SalaryIncrement> GetSalaryIncrementLog(string OCODE)
        {
            return _context.HRM_SalaryIncrement.Where(x => x.OCODE == OCODE && x.ApprovedStatus == false).ToList();
        }

        internal DateTime GetServerDate()
        {
            DateTime query = _context.ExecuteStoreQuery<DateTime>("SELECT getdate()").FirstOrDefault();
            return query;

        }

        internal List<HRM_PersonalInformations> GetAllEmployess(string OCODE)
        {
            return _context.HRM_PersonalInformations.Where(x => x.OCODE == OCODE).ToList();

        }

        internal List<HRM_DESIGNATIONS> GetAllDesgination(string OCODE)
        {
            return _context.HRM_DESIGNATIONS.Where(x => x.OCODE == OCODE).ToList();

        }

        internal bool CheckDesignation(string Desgination, string Grad, decimal? Gosssalary)
        {

            try
            {

                bool status = false;

                HRM_DESIGNATIONS _desgination = _context.HRM_DESIGNATIONS.FirstOrDefault(x => x.DEG_NAME == Desgination && x.GRADE == Grad && x.GROSS_SAL == Gosssalary);
                if (_desgination != null)
                {
                    status = true;
                }
                return status;

            }
            catch (Exception)
            {

                throw;
            }

        }

        internal int AutomaticSalaryUpdate(List<SalaryIncrementR> slaryIncrementRes)
        {
            foreach(SalaryIncrementR  aitem in  slaryIncrementRes)
            {
                InsertSalaryIncrement(aitem);
                UpdateSlaryIncrementLog(aitem);
                UpdatePersonalInfo(aitem);
            }
            return 1;
        }

        private void InsertSalaryIncrement(SalaryIncrementR aitem)
        {
            try
            {
                HRM_SalaryIncrementSLog _slaryIncrementlog = new HRM_SalaryIncrementSLog();
                _slaryIncrementlog.EID = aitem.Eid;
                _slaryIncrementlog.SalaryIncrementStatus = aitem.SalaryIncrementStatus;
                _slaryIncrementlog.previousSalary = aitem.previousSalary;
                _slaryIncrementlog.IncrementDate = aitem.IncrementDate;
                _slaryIncrementlog.EffectiveDate = aitem.EffectiveDate;
                _slaryIncrementlog.IncrementSalary = aitem.Slary;
                _slaryIncrementlog.OCODE = aitem.Ocode;
                _slaryIncrementlog.EDIT_DATE = aitem.EDIT_DATE;
                _slaryIncrementlog.EDIT_USER = aitem.EDIT_USER;
                _context.HRM_SalaryIncrementSLog.AddObject(_slaryIncrementlog);
                _context.SaveChanges();

            }
            catch (Exception)
            {
                
                throw;
            }
        }

        private void UpdatePersonalInfo(SalaryIncrementR aitem)
        {
            try
            {
                HRM_PersonalInformations _personalInformations = _context.HRM_PersonalInformations.Where(x => x.EID == aitem.Eid).FirstOrDefault();
                _personalInformations.Salary = aitem.Slary;
                _personalInformations.DesginationId = aitem.DesId;
                _personalInformations.Grade = aitem.Grade;
                _context.SaveChanges();

            }
            catch (Exception)
            {
                
                throw;
            }
        }

        private void UpdateSlaryIncrementLog(SalaryIncrementR aitem)
        {
            try
            {
                HRM_SalaryIncrement _salaryIncrementLog = _context.HRM_SalaryIncrement.Where(x => x.EID == aitem.Eid && x.ApprovedStatus==false ).FirstOrDefault();
                _salaryIncrementLog.ApprovedStatus = true;
                _context.SaveChanges();


            }
            catch (Exception)
            {
                
                throw;
            }
        }

        internal int AutomaticSalaryUpdateByEffectiveDate(List<SalaryIncrementR> slaryIncrementRes)
        {
            try
            {
                foreach (SalaryIncrementR aitem in slaryIncrementRes)
                {
                    InsertSalaryIncrement(aitem);
                    UpdatePersonalInfoForEffectiveDate(aitem);

                }

                return 1;
            }
            catch (Exception)
            {
                
                throw;
            }

        }

        private void UpdatePersonalInfoForEffectiveDate(SalaryIncrementR aitem)
        {
            HRM_PersonalInformations _personalInformations = _context.HRM_PersonalInformations.Where(x => x.EID == aitem.Eid).FirstOrDefault();
            _personalInformations.Salary = aitem.Slary;
            _personalInformations.DesginationId = aitem.DesId;
            _personalInformations.Grade = aitem.Grade;
            _personalInformations.EffectiveSalaryStatus = true;
            _context.SaveChanges();



        }

        internal List<HRM_SalaryIncrement> Get_SalryIncrementByEID_Date(string E_ID, DateTime EffectiveDate)
        {
            try
            {
                var query = (from lt in _context.HRM_SalaryIncrement
                             where lt.EID == E_ID && lt.EffectiveDate == EffectiveDate
                             select lt);
                var list = query.ToList();
                return list;
            }
            catch (Exception)
            {
                throw;
            }
        }

        internal int UpDateSalryIncrementLog(List<HRM_SalaryIncrement> SalaryIncrements, string EID, DateTime ExistEffictiveDate)
        {
            try
            {
                foreach (HRM_SalaryIncrement aitem in SalaryIncrements)
                {
                    HRM_SalaryIncrement _SalaryIncrement = _context.HRM_SalaryIncrement.Where(x => (x.EID == EID) && (x.EffectiveDate == ExistEffictiveDate)).FirstOrDefault();

                    _SalaryIncrement.previousSalary = aitem.previousSalary;
                    _SalaryIncrement.IncrementSalary = aitem.IncrementSalary;
                    _SalaryIncrement.IncrementDate = aitem.IncrementDate;
                    _SalaryIncrement.ApprovedStatus = aitem.ApprovedStatus;
                    _SalaryIncrement.OCODE = aitem.OCODE;
                    _SalaryIncrement.EDIT_DATE = aitem.EDIT_DATE;
                    _SalaryIncrement.EDIT_USER = aitem.EDIT_USER;
                    _context.SaveChanges();
                }
                return 1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal int DeleteSalryIncrementLog(string E_ID)
        {
            try
            {

                HRM_SalaryIncrement _SalaryIncrement = _context.HRM_SalaryIncrement.Where(x => x.EID == E_ID).FirstOrDefault();
                _context.HRM_SalaryIncrement.Attach(_SalaryIncrement);
                _context.HRM_SalaryIncrement.DeleteObject(_SalaryIncrement);

                _context.SaveChanges();
                return 1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
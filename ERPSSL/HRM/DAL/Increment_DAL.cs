using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ERPSSL.HRM.BLL;
using ERPSSL.HRM.DAL.Repository;

namespace ERPSSL.HRM.DAL
{
    public class Increment_DAL
    {
        public ERPSSLHBEntities _context = new ERPSSLHBEntities();
        internal virtual List<HRM_Regions> GetAllRegion(string OCODE)
        {

            try
            {
                var query = (from dept in _context.HRM_Regions
                             where dept.OCODE == OCODE
                             select dept).OrderBy(x => x.RegionID);


                return query.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }

        }

        internal List<HRM_Office> GetOfficeByResionId(int RegionId)
        {
            try
            {
                var query = (from off in _context.HRM_Office
                             where off.RegionId == RegionId
                             select off).OrderBy(x => x.RegionId);


                return query.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }

        }


        //-------------
        public IEnumerable<HRM_PersonalInfoInc> GetEmployees(int officeId)
        {
            try
            {
                using (var _context = new ERPSSLHBEntities())
                {
                    var query = (from emp in _context.HRM_PersonalInformations

                                 join r in _context.HRM_Regions on emp.RegionsId equals r.RegionID
                                 join ofc in _context.HRM_Office on emp.OfficeId equals ofc.OfficeID
                                 join d in _context.HRM_DEPARTMENTS on emp.DepartmentId equals d.DPT_ID
                                 //join s in _context.HRM_SECTIONS on emp.SectionId equals s.SEC_ID
                                 //join ss in _context.HRM_SUB_SECTIONS on emp.SubSectionId equals ss.SUB_SEC_ID
                                 join dg in _context.HRM_DESIGNATIONS on emp.DesginationId equals dg.DEG_ID
                                 //join grd in _context.HRM_GRADE on emp.Grade equals grd.GRADE_ID

                                 where emp.OfficeId == officeId
                                 select new HRM_PersonalInfoInc
                                 {
                                     //EMP_ID = (Int64)emp.EmpId,
                                     EID = emp.EID,
                                     EMP_Name = emp.FirstName + emp.LastName,
                                     DEG_NAME = dg.DEG_NAME,
                                     EMP_CONTACT_NO = emp.ContactNumber,
                                     DPT_NAME = d.DPT_NAME,
                                     EMP_Salary = (decimal)emp.Salary,
                                     //Gross_Rate = (decimal)emp.GrossRate,                                     
                                     Old_Salary = (decimal)emp.OldSalary,
                                     Gross_Rate = (decimal)emp.Salary - (decimal)emp.OldSalary,
                                     Salary_Update_Date = (DateTime)(emp.SalaryUpdateDate)
                                     //DPT_ID = d.DPT_ID,

                                 }).OrderBy(x => x.EID);

                    return query.ToList();
                }
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
            
        }



        internal int SaveIncremntTemp(List<HRM_TemporySalaryIncrement> EMP_LIST)
        {
            try
            {
                foreach (HRM_TemporySalaryIncrement aitem in EMP_LIST)
                {
                    //_context.HRM_PersonalInformations.AddObject(aitem);
                    //HRM_PersonalInformations obj = _context.HRM_PersonalInformations.First(x => x.EID ==aitem.EID);
                    //obj.Salary = aitem.Salary;
                    //obj.OldSalary = aitem.OldSalary;
                    //obj.GrossRate = aitem.GrossRate;
                    //obj.SalaryUpdateDate = aitem.SalaryUpdateDate;
                    _context.HRM_TemporySalaryIncrement.AddObject(aitem);
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



        internal IEnumerable<HRM_DEPARTMENTS> GetDepartmentByOfficeId(int officeID)
        {
            try
            {
                var query = (from dep in _context.HRM_DEPARTMENTS
                             where dep.Office_ID == officeID
                             select dep).OrderBy(x => x.Office_ID);


                return query.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }

        }
        //----------------fgfd
        internal IEnumerable<HRM_PersonalInfoInc> GetEmployeesByDepartmentId(int DepartmentId)
        {
            try
            {
                using (var _context = new ERPSSLHBEntities())
                {
                    var query = (from emp in _context.HRM_PersonalInformations

                                 join r in _context.HRM_Regions on emp.RegionsId equals r.RegionID
                                 join ofc in _context.HRM_Office on emp.OfficeId equals ofc.OfficeID
                                 join d in _context.HRM_DEPARTMENTS on emp.DepartmentId equals d.DPT_ID
                                 //join s in _context.HRM_SECTIONS on emp.SectionId equals s.SEC_ID
                                 //join ss in _context.HRM_SUB_SECTIONS on emp.SubSectionId equals ss.SUB_SEC_ID
                                 join dg in _context.HRM_DESIGNATIONS on emp.DesginationId equals dg.DEG_ID
                                 //join grd in _context.HRM_GRADE on emp.Grade equals grd.GRADE_ID

                                 where emp.DepartmentId == DepartmentId
                                 select new HRM_PersonalInfoInc
                                 {
                                     //EMP_ID = (Int64)emp.EmpId,
                                     EID = emp.EID,
                                      FristName=emp.FirstName,
                                      LastName=emp.LastName,
                                     DEG_NAME = dg.DEG_NAME,
                                     EMP_CONTACT_NO = emp.ContactNumber,
                                     DPT_NAME = d.DPT_NAME,
                                     EMP_Salary = (decimal)emp.Salary,
                                     //Gross_Rate = (decimal)emp.GrossRate,                                     
                                     Old_Salary = (decimal)emp.OldSalary,
                                     Gross_Rate = (decimal)emp.Salary - (decimal)emp.OldSalary,
                                     Salary_Update_Date = (DateTime)(emp.SalaryUpdateDate)
                                     //DPT_ID = d.DPT_ID,

                                 }).OrderBy(x => x.EID);

                    return query.ToList();
                }
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }

        }

        internal IEnumerable<SalaryIncrementRep> GetEmployeesInfoFromTemporyEmoloyeeTable()
        {
            try
            {
                using (var _context = new ERPSSLHBEntities())
                {
                    var query = (from Ts in _context.HRM_TemporySalaryIncrement

                                 join emp in _context.HRM_PersonalInformations on Ts.EID equals emp.EID
                                 join ofc in _context.HRM_Office on emp.OfficeId equals ofc.OfficeID
                                 join d in _context.HRM_DEPARTMENTS on emp.DepartmentId equals d.DPT_ID
                                 //join s in _context.HRM_SECTIONS on emp.SectionId equals s.SEC_ID
                                 //join ss in _context.HRM_SUB_SECTIONS on emp.SubSectionId equals ss.SUB_SEC_ID
                                 join dg in _context.HRM_DESIGNATIONS on emp.DesginationId equals dg.DEG_ID
                                 //join grd in _context.HRM_GRADE on emp.Grade equals grd.GRADE_ID

                                 where emp.EID == Ts.EID
                                 select new SalaryIncrementRep
                                 {
                                     //EMP_ID = (Int64)emp.EmpId,
                                     EID = Ts.EID,
                                     Name = emp.FirstName + emp.LastName,
                                     Designation = dg.DEG_NAME,
                                     Contact = emp.ContactNumber,
                                     Department = d.DPT_NAME,
                                     PreviousSalary = (decimal)Ts.OldSalary,
                                     //Gross_Rate = (decimal)emp.GrossRate,                                     
                                     CurrentSalary = (decimal)Ts.CurrentSalary,
                                     IncrementAcount = (decimal)Ts.IncrementRate ,
                                     IncrementDate = (DateTime)(Ts.IncrementDate)
                                     //DPT_ID = d.DPT_ID,

                                 }).OrderBy(x => x.EID);

                    return query.ToList();
                }
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }

        }

        internal int DeleteSlaryIncrementTemporyInfoByEmployeId(string eid, string OCODE)
        {
            try
            {
                HRM_TemporySalaryIncrement objex = _context.HRM_TemporySalaryIncrement.First(x => x.EID == eid);
                _context.HRM_TemporySalaryIncrement.DeleteObject(objex);
                _context.SaveChanges();
                return 1;

            }
            catch (Exception)
            {
                
                throw;
            }
        }

        

        internal int DeleteTemporyTableInfo(List<HRM_SalaryIncrement> EMP_LIST)
        {

            foreach (HRM_SalaryIncrement aitem in EMP_LIST)
            {
                HRM_TemporySalaryIncrement objex = _context.HRM_TemporySalaryIncrement.First(x => x.EID == aitem.EID);
                _context.HRM_TemporySalaryIncrement.DeleteObject(objex);               
                _context.SaveChanges();
            }
            _context.SaveChanges();
            return 1;

        }

        internal int UpdateIncrementSalary(HRM_SalaryIncrement objEmp)
        {

            try
            {

                //HRM_TemporySalaryIncrement obj = _context.HRM_TemporySalaryIncrement.First(x => x.EID == objEmp.EID);

                //obj.CurrentSalary = objEmp.CurrentSalary;
                //obj.OldSalary = objEmp.OldSalary;
                //obj.IncrementRate = objEmp.IncrementRate;
                //obj.UpdateBy = objEmp.UpdateBy;
                //obj.OCODE = objEmp.OCODE;
                //obj.EDIT_USER = objEmp.EDIT_USER;
                //obj.EDIT_DATE = objEmp.EDIT_DATE;
                //obj.IncrementDate = objEmp.IncrementDate;

                //_context.HRM_SalaryIncrement.AddObject(objEmp);
                //_context.SaveChanges();



                //HRM_PersonalInformations obj1 = _context.HRM_PersonalInformations.First(x => x.EID == objEmp.EID);
                //obj1.Salary = objEmp.CurrentSalary;
                //obj1.OldSalary = objEmp.OldSalary;
                //obj1.GrossRate = objEmp.IncrementRate;
                //obj1.SalaryUpdateDate = objEmp.IncrementDate;
                //_context.SaveChanges();


                return 1;


            }
            catch (Exception)
            {

                throw;
            }

        }

        internal int SaveIncremntTemp(HRM_SalaryIncrement objEmp)
        {
            _context.HRM_SalaryIncrement.AddObject(objEmp);
            _context.SaveChanges();
            return 1;

        }
        internal int SalaryUpdate(HRM_SalaryUpdate objEmp)
        {
            try
            {
                _context.HRM_SalaryUpdate.AddObject(objEmp);
                _context.SaveChanges();
              //  UpdatePersonalInfo(objEmp);
                return 1;
            }
            catch (Exception)
            {

                throw;
            }
        }
        private void UpdatePersonalInfo(HRM_SalaryUpdate objEmp)
        {
            HRM_PersonalInformations _personalInfo = _context.HRM_PersonalInformations.Where(x => x.EID == objEmp.EID).FirstOrDefault();
            _personalInfo.Salary = objEmp.CurrendSalary;
            _personalInfo.Grade = objEmp.Grade;
            _personalInfo.DesginationId = objEmp.DegID;
            _context.SaveChanges();
        }
    }
}
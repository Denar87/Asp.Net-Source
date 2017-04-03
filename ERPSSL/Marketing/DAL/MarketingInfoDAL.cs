using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ERPSSL.Marketing.DAL;
using ERPSSL.Marketing.DAL.Repository;
using ERPSSL.HRM.DAL;

namespace ERPSSL.Marketing.DAL
{
    public class MarketingInfoDAL
    {
        ERPSSL_Marketing_Entities _context = new ERPSSL_Marketing_Entities();
        

        public int SaveMarketingInfo(MRK_MarketingInfo aMRK_MarketingInfo)
        {
           
            _context.MRK_MarketingInfo.AddObject(aMRK_MarketingInfo);
            _context.SaveChanges();
            return 1;
        }

        public List<MarketingProjectStage> GetAllMarketingInfoList(string OCODE)
        {
           
            try
            {
                var query = (from m in _context.MRK_MarketingInfo
                             join p in _context.MRK_Project on m.ProjectId equals p.ProjectId
                             join s in _context.MRK_Stage on m.StageId equals s.StageId
                             join mp in _context.HRM_PersonalInformations on m.MarketingPersonId equals mp.EID
                             where m.OCODE == OCODE
                             select new MarketingProjectStage
                             {
                                 MarketingInfoId = (int)m.MarketingInfoId,
                                 VisitDate = (DateTime) m.VisitDate,
                                 Client = m.Client,
                                 ContactPerson = m.ContactPerson,
                                 Designation = m.Designation,
                                 ContactNumber = m.ContactNumber,
                                 Email = m.Email,
                                 Address = m.Address,
                                 ProjectId = (int)p.ProjectId,
                                 ProjectName = p.ProjectName,
                                 Module = m.Module,
                                 StageId = (int)s.StageId,
                                 StageName = s.StageName,
                                 MArketingPersonName = mp.FirstName,
                                 Remarks = m.Remarks
                             }

                             ).OrderBy(x => x.MarketingInfoId);

                return query.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        

        }

        public MRK_MarketingInfo GetMarketingInfoForEdit(string marketingInfoId, string OCODE)
        {
            try
            {
                int increId = Convert.ToInt16(marketingInfoId);

                var increments = (from incre in _context.MRK_MarketingInfo
                                  where incre.MarketingInfoId == increId && incre.OCODE == OCODE
                                  select incre).FirstOrDefault();


                return increments;

            }
            catch (Exception)
            {

                throw;
            }

        }

        public int UpdateMarketingInfo(int marketingInfoId, MRK_MarketingInfo aMRK_MarketingInfo)
        {
            try
            {
                MRK_MarketingInfo MRK_MarketingInfo = _context.MRK_MarketingInfo.First(x => x.MarketingInfoId == marketingInfoId);
                MRK_MarketingInfo.VisitDate = aMRK_MarketingInfo.VisitDate;
                MRK_MarketingInfo.Client = aMRK_MarketingInfo.Client;
                MRK_MarketingInfo.ContactPerson = aMRK_MarketingInfo.ContactPerson;
                MRK_MarketingInfo.Designation = aMRK_MarketingInfo.Designation;
                MRK_MarketingInfo.ContactNumber = aMRK_MarketingInfo.ContactNumber;
                MRK_MarketingInfo.Email = aMRK_MarketingInfo.Email;
                MRK_MarketingInfo.Address = aMRK_MarketingInfo.Address;
                MRK_MarketingInfo.ProjectId = aMRK_MarketingInfo.ProjectId;
                MRK_MarketingInfo.Module = aMRK_MarketingInfo.Module; 
                MRK_MarketingInfo.StageId = aMRK_MarketingInfo.StageId;
                MRK_MarketingInfo.Remarks = aMRK_MarketingInfo.Remarks;
                MRK_MarketingInfo.ReferenceId = aMRK_MarketingInfo.ReferenceId;

                MRK_MarketingInfo.Edit_User = aMRK_MarketingInfo.Edit_User;
                MRK_MarketingInfo.Edit_Date = aMRK_MarketingInfo.Edit_Date;
                MRK_MarketingInfo.OCODE = aMRK_MarketingInfo.OCODE;

                _context.SaveChanges();
                return 1;

            }
            catch (Exception)
            {

                throw;
            }

        }



        internal List<MarketingProjectStage> Get_AllPersonList(string OCODE)
        {
            using (var _context = new ERPSSLHBEntities())
            {
                var ListItem = (from r in _context.HRM_PersonalInformations
                                where r.OCODE == OCODE
                                select new MarketingProjectStage
                                {
                                    MarketingPersonId = r.EID,
                                    FirstName = r.FirstName,
                                    LastName = r.LastName,
                                    MArketingPersonName = r.FirstName?? "" + " " + r.LastName?? "",

                                    //MArketingPersonName = FirstNames + " " + LastNames == null ? " " : LastNames
                                }).OrderBy(x => x.MarketingPersonId);
                return ListItem.ToList();
            }
        }

        internal int Savereference(MRK_Reference aMRK_Reference)
        {
            try
            {
                using (var _context = new ERPSSL_Marketing_Entities())
                {
                    _context.MRK_Reference.AddObject(aMRK_Reference);
                    _context.SaveChanges();
                    return aMRK_Reference.ReferenceId;
                }
            }
            catch(Exception ex) 
            {
                throw ex;
            }
        }

        internal List<MRK_Reference> Get_AllReferenceList(string OCODE)
        {
            try
            {
                using (var _context = new ERPSSL_Marketing_Entities())
                {
                    var ListItem = (from r in _context.MRK_Reference
                                    where r.OCODE == OCODE
                                    select r);
                    return ListItem.ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal List<MarketingProjectStage> GetUpcomingOrderList()
        {
            try
            {
                var query = (from m in _context.MRK_MarketingInfo
                             join p in _context.MRK_Project on m.ProjectId equals p.ProjectId
                             join s in _context.MRK_Stage on m.StageId equals s.StageId
                             join mp in _context.HRM_PersonalInformations on m.MarketingPersonId equals mp.EID
                             where !(_context.MRK_WorkOrder.Any(w => w.MarketingInfoId == m.MarketingInfoId))
                             select new MarketingProjectStage
                             {
                                 MarketingInfoId = (int)m.MarketingInfoId,
                                 VisitDate = (DateTime)m.VisitDate,
                                 Client = m.Client,
                                 ContactPerson = m.ContactPerson,
                                 Designation = m.Designation,
                                 ContactNumber = m.ContactNumber,
                                 Email = m.Email,
                                 Address = m.Address,
                                 ProjectId = (int)p.ProjectId,
                                 ProjectName = p.ProjectName,
                                 Module = m.Module,
                                 StageId = (int)s.StageId,
                                 StageName = s.StageName,
                                 MArketingPersonName = mp.FirstName,
                                 Remarks = m.Remarks
                             }

                             ).OrderBy(x => x.MarketingInfoId);

                return query.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        
        }

        internal List<MarketingProjectStage> GetUpPrimaryClientList()
        {
            try
            {
                var query = (from m in _context.MRK_MarketingInfo
                             join p in _context.MRK_Project on m.ProjectId equals p.ProjectId
                             join s in _context.MRK_Stage on m.StageId equals s.StageId
                             join mp in _context.HRM_PersonalInformations on m.MarketingPersonId equals mp.EID
                             where m.StageId == 1
                             select new MarketingProjectStage
                             {
                                 MarketingInfoId = (int)m.MarketingInfoId,
                                 VisitDate = (DateTime)m.VisitDate,
                                 Client = m.Client,
                                 ContactPerson = m.ContactPerson,
                                 Designation = m.Designation,
                                 ContactNumber = m.ContactNumber,
                                 Email = m.Email,
                                 Address = m.Address,
                                 ProjectId = (int)p.ProjectId,
                                 ProjectName = p.ProjectName,
                                 Module = m.Module,
                                 StageId = (int)s.StageId,
                                 StageName = s.StageName,
                                 MArketingPersonName = mp.FirstName,
                                 Remarks = m.Remarks
                             }

                             );

                return query.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal List<MarketingProjectStage> GetMidLevelClientList()
        {
            try
            {
                var query = (from m in _context.MRK_MarketingInfo
                             join p in _context.MRK_Project on m.ProjectId equals p.ProjectId
                             join s in _context.MRK_Stage on m.StageId equals s.StageId
                             join mp in _context.HRM_PersonalInformations on m.MarketingPersonId equals mp.EID
                             where m.StageId == 2
                             select new MarketingProjectStage
                             {
                                 MarketingInfoId = (int)m.MarketingInfoId,
                                 VisitDate = (DateTime)m.VisitDate,
                                 Client = m.Client,
                                 ContactPerson = m.ContactPerson,
                                 Designation = m.Designation,
                                 ContactNumber = m.ContactNumber,
                                 Email = m.Email,
                                 Address = m.Address,
                                 ProjectId = (int)p.ProjectId,
                                 ProjectName = p.ProjectName,
                                 Module = m.Module,
                                 StageId = (int)s.StageId,
                                 StageName = s.StageName,
                                 MArketingPersonName = mp.FirstName,
                                 Remarks = m.Remarks
                             }

                             );

                return query.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal List<MarketingProjectStage> GetCurrentMonthVisitList()
        {

            int nowMonth = DateTime.Now.Month;
            int nowYear = DateTime.Now.Year;

            try
            {
                var query = (from m in _context.MRK_MarketingInfo
                             join p in _context.MRK_Project on m.ProjectId equals p.ProjectId
                             join s in _context.MRK_Stage on m.StageId equals s.StageId
                             join mp in _context.HRM_PersonalInformations on m.MarketingPersonId equals mp.EID
                             where m.VisitDate.Value.Month == nowMonth && m.VisitDate.Value.Year == nowYear
                             select new MarketingProjectStage
                             {
                                 MarketingInfoId = (int)m.MarketingInfoId,
                                 VisitDate = (DateTime)m.VisitDate,
                                 Client = m.Client,
                                 ContactPerson = m.ContactPerson,
                                 Designation = m.Designation,
                                 ContactNumber = m.ContactNumber,
                                 Email = m.Email,
                                 Address = m.Address,
                                 ProjectId = (int)p.ProjectId,
                                 ProjectName = p.ProjectName,
                                 Module = m.Module,
                                 StageId = (int)s.StageId,
                                 StageName = s.StageName,
                                 MArketingPersonName = mp.FirstName,
                                 Remarks = m.Remarks
                             }

                             );

                return query.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal List<MarketingProjectStage> GetLastMonthVisitList()
        {
            int nowMonth = DateTime.Now.Month;
            int nowYear = DateTime.Now.Year;

            decimal preMonthCollectionAmount = 0;
          
            var today = DateTime.Today;
            var month = new DateTime(today.Year, today.Month, 1);
            var first = month.AddMonths(-1);
            var last = month.AddDays(-1);
            int preMonth = first.Month;
            int preYear = first.Year;

            try
            {
                var query = (from m in _context.MRK_MarketingInfo
                             join p in _context.MRK_Project on m.ProjectId equals p.ProjectId
                             join s in _context.MRK_Stage on m.StageId equals s.StageId
                             join mp in _context.HRM_PersonalInformations on m.MarketingPersonId equals mp.EID
                             where m.VisitDate.Value.Month == preMonth && m.VisitDate.Value.Year == preYear
                             select new MarketingProjectStage
                             {
                                 MarketingInfoId = (int)m.MarketingInfoId,
                                 VisitDate = (DateTime)m.VisitDate,
                                 Client = m.Client,
                                 ContactPerson = m.ContactPerson,
                                 Designation = m.Designation,
                                 ContactNumber = m.ContactNumber,
                                 Email = m.Email,
                                 Address = m.Address,
                                 ProjectId = (int)p.ProjectId,
                                 ProjectName = p.ProjectName,
                                 Module = m.Module,
                                 StageId = (int)s.StageId,
                                 StageName = s.StageName,
                                 MArketingPersonName = mp.FirstName,
                                 Remarks = m.Remarks
                             }

                             );

                return query.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal List<MarketingProjectStage> GetAllMarketingInfoListByClientName(string OCODE, string clientName)
        {
            try
            {
                var query = (from m in _context.MRK_MarketingInfo
                             join p in _context.MRK_Project on m.ProjectId equals p.ProjectId
                             join s in _context.MRK_Stage on m.StageId equals s.StageId
                             join mp in _context.HRM_PersonalInformations on m.MarketingPersonId equals mp.EID
                             where m.OCODE == OCODE && m.Client == clientName
                             select new MarketingProjectStage
                             {
                                 MarketingInfoId = (int)m.MarketingInfoId,
                                 VisitDate = (DateTime)m.VisitDate,
                                 Client = m.Client,
                                 ContactPerson = m.ContactPerson,
                                 Designation = m.Designation,
                                 ContactNumber = m.ContactNumber,
                                 Email = m.Email,
                                 Address = m.Address,
                                 ProjectId = (int)p.ProjectId,
                                 ProjectName = p.ProjectName,
                                 Module = m.Module,
                                 StageId = (int)s.StageId,
                                 StageName = s.StageName,
                                 MArketingPersonName = mp.FirstName,
                                 Remarks = m.Remarks
                             }

                             ).OrderBy(x => x.MarketingInfoId);

                return query.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal int Saveproject(MRK_Project aMRK_Project)
        {
            try
            {
                using (var _context = new ERPSSL_Marketing_Entities())
                {
                    _context.MRK_Project.AddObject(aMRK_Project);
                    _context.SaveChanges();
                    return aMRK_Project.ProjectId;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }

}
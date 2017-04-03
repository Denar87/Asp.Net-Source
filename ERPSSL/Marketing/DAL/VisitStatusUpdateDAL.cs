using ERPSSL.Marketing.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPSSL.Marketing.DAL
{
    public class VisitStatusUpdateDAL
    {
        ERPSSL_Marketing_Entities _context = new ERPSSL_Marketing_Entities();

        internal MarketingProjectStage GetInvidualMarketingInfoList(string OCode, string clientName)
        {
            try
            {
                var query = (from m in _context.MRK_MarketingInfo
                             join p in _context.MRK_Project on m.ProjectId equals p.ProjectId
                             join s in _context.MRK_Stage on m.StageId equals s.StageId
                             join r in _context.MRK_Reference on m.ReferenceId equals r.ReferenceId
                             join mp in _context.HRM_PersonalInformations on m.MarketingPersonId equals mp.EID
                             where m.OCODE == OCode && m.Client == clientName
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
                                 Remarks = m.Remarks,
                                 ReferenceName = r.ReferenceName
                             }

                             ).FirstOrDefault();

                return query;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal int GetOrderId(int marketingInfoId)
        {
            try
            {
                using (var _context = new ERPSSL_Marketing_Entities())
                {
                    var query = (from m in _context.MRK_MarketingInfo
                                 join w in _context.MRK_WorkOrder on m.MarketingInfoId equals w.MarketingInfoId
                                 where m.MarketingInfoId == marketingInfoId
                                 select w.WoID).FirstOrDefault();

                    return query;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        internal List<MRK_Task_Details> GetTaskDetailsByWorkOrderNo(int OrderId, string OCODE)
        {
            using (var _context = new ERPSSL_Marketing_Entities())
            {
                return (from t in _context.MRK_Task_Details
                        where t.WorkOrderId == OrderId && t.OCode == OCODE
                        select t).ToList();
            }
        }

        internal int UpdateTaskDetails(MRK_Task_Details aMRK_Task_Details, int ID)
        {
            try
            {
                using (var _context = new ERPSSL_Marketing_Entities())
                {
                    var TaskDetails = _context.MRK_Task_Details.FirstOrDefault(x => x.TaskDetails_Id == ID);
                    
                    TaskDetails.Date = aMRK_Task_Details.Date;
                    TaskDetails.Remarks = aMRK_Task_Details.Remarks;
                    TaskDetails.Comments = aMRK_Task_Details.Comments;
                    TaskDetails.EditDate = aMRK_Task_Details.EditDate;
                    TaskDetails.EditUser = aMRK_Task_Details.EditUser;
                    _context.SaveChanges();
                    return 1;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        internal int GetWorkOrderId(int marketingInfoId)
        {
            try
            {
                using (var _context = new ERPSSL_Marketing_Entities())
                {
                    return (from m in _context.MRK_MarketingInfo
                            join w in _context.MRK_WorkOrder on m.MarketingInfoId equals w.MarketingInfoId
                            where m.MarketingInfoId == marketingInfoId
                            select w.WoID).FirstOrDefault();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        internal List<int> getTaskIdList(int workOrderId)
        {
            using (var _context = new ERPSSL_Marketing_Entities())
            {
                return (from t in _context.MRK_Task_Details
                        where t.WorkOrderId == workOrderId
                        select t.TaskDetails_Id).ToList();
            }
        }


        internal List<LC_InputType> GettAllTask()
        {
            using (_context = new ERPSSL_Marketing_Entities())
            {
                try
                {
                    var query = (from l in _context.LC_InputType
                                 where l.Use_Dept == "Marketing Task"
                                 select l);

                    return query.ToList();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
    }
}
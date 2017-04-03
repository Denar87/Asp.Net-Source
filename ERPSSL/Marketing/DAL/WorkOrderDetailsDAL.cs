using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ERPSSL.Marketing.DAL;
using ERPSSL.Marketing.BLL;
using ERPSSL.Marketing.DAL.Repository;
using ERPSSL.LC.DAL;

namespace ERPSSL.Marketing.DAL
{
    public class WorkOrderDetailsDAL
    {
        ERPSSL_Marketing_Entities _Context = new ERPSSL_Marketing_Entities();

        public List<MRK_MarketingInfo> GetALLMArketingInfoByClientName(string clientName, string OCode)
        {
            try
            {
                //var query = (from m in _Context.MRK_MarketingInfo
                //             where m.OCODE == OCode && m.Client == clientName && m.StageId == 3
                //             select m).OrderBy(x => x.Client);

                var query = (from m in _Context.MRK_MarketingInfo
                             where !(_Context.MRK_WorkOrder.Any(w => w.MarketingInfoId == m.MarketingInfoId)) && m.OCODE == OCode && m.StageId == 3 && m.Client == clientName
                             select m);

                return query.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }


        public List<MRK_MarketingInfo> GetALLMarketingInfoInGridView(string OCode)
        {
            try
            {

                var query = (from m in _Context.MRK_MarketingInfo
                             where !(_Context.MRK_WorkOrder.Any(w => w.MarketingInfoId == m.MarketingInfoId)) && m.OCODE == OCode && m.StageId == 3
                             select m);

                return query.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        public List<MarketingProjectStage> GetInvidualMarketingInfoList(int marketingInfoId)
        {

            try
            {
                var query = (from m in _Context.MRK_MarketingInfo
                             join p in _Context.MRK_Project on m.ProjectId equals p.ProjectId
                             join s in _Context.MRK_Stage on m.StageId equals s.StageId
                             join mr in _Context.HRM_PersonalInformations on m.MarketingPersonId equals mr.EID
                             join r in _Context.MRK_Reference on m.ReferenceId equals r.ReferenceId
                             where m.MarketingInfoId == marketingInfoId
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
                                 MarketingPersonId = mr.EID,
                                 MArketingPersonName = mr.FirstName,
                                 ReferenceId = r.ReferenceId,
                                 ReferenceName = r.ReferenceName,
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


        internal int SaveWordOrderInfo(MRK_WorkOrder aMRK_WorkOrder)
        {
            using (_Context = new ERPSSL_Marketing_Entities())
            {
                _Context.MRK_WorkOrder.AddObject(aMRK_WorkOrder);
                _Context.SaveChanges();
                return aMRK_WorkOrder.WoID;
            }
        }


        internal List<MarketingWorkOrder> GettAllWorkOrderDetails(string OCode)
        {
            try
            {
                var query = (from w in _Context.MRK_WorkOrder
                             join m in _Context.MRK_MarketingInfo on w.MarketingInfoId equals m.MarketingInfoId
                             join p in _Context.MRK_Project on m.ProjectId equals p.ProjectId
                             join mp in _Context.HRM_PersonalInformations on m.MarketingPersonId equals mp.EID
                             where w.OCODE == OCode
                             select new MarketingWorkOrder
                             {
                                 WoID = (int)w.WoID,
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
                                 MarketingPersonId = mp.EID,
                                 MarketingPersonName = mp.FirstName,

                                 WorkOrderDate = (DateTime)w.WorkOrderDate,
                                 CompletionPeriod = w.CompletionPeriod,
                                 ProposedAmount = (decimal)w.ProposedAmount,
                                 SigningAmount = (decimal)w.SigningAmount,
                                 RemainingAmount = (decimal)w.RemainingAmount,
                                 Remarks = w.Remarks,
                             }

                             ).OrderBy(x => x.WoID);

                return query.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        internal MarketingWorkOrder GetSingleWorkOrderDetails(int workOrderId)
        {
            try
            {
                var query = (from w in _Context.MRK_WorkOrder
                             join m in _Context.MRK_MarketingInfo on w.MarketingInfoId equals m.MarketingInfoId
                             join p in _Context.MRK_Project on m.ProjectId equals p.ProjectId
                             join mp in _Context.HRM_PersonalInformations on m.MarketingPersonId equals mp.EID
                             where w.WoID == workOrderId
                             select new MarketingWorkOrder
                             {
                                 WoID = (int)w.WoID,
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
                                 MarketingPersonId = mp.EID,
                                 MarketingPersonName = mp.FirstName,

                                 WorkOrderDate = (DateTime)w.WorkOrderDate,
                                 CompletionPeriod = w.CompletionPeriod,
                                 ProposedAmount = (decimal)w.ProposedAmount,
                                 SigningAmount = (decimal)w.SigningAmount,
                                 RemainingAmount = (decimal)w.RemainingAmount,
                                 Remarks = w.Remarks,
                                 PaymentCondition = w.PaymentCondition,
                                 AMC_Condition = w.AMC_Condition,
                                 WarrantyPeriod = (int)w.WarrantyPeriod,
                                 AMCDate = (DateTime)w.AMCDAte,
                                 HandoverStatus = (Boolean)w.HandoverStatus
                             }

                             ).FirstOrDefault();

                return query;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal int UpdateWorkOrderInfo(MRK_WorkOrder aMRK_WorkOrder, int workOrderId)
        {
            try
            {
                MRK_WorkOrder MRK_WorkOrder = _Context.MRK_WorkOrder.First(x => x.WoID == workOrderId);



                MRK_WorkOrder.MarketingInfoId = aMRK_WorkOrder.MarketingInfoId;
                MRK_WorkOrder.WorkOrderDate = aMRK_WorkOrder.WorkOrderDate;
                MRK_WorkOrder.CompletionPeriod = aMRK_WorkOrder.CompletionPeriod;
                MRK_WorkOrder.ProposedAmount = aMRK_WorkOrder.ProposedAmount;
                MRK_WorkOrder.SigningAmount = aMRK_WorkOrder.SigningAmount;
                MRK_WorkOrder.RemainingAmount = aMRK_WorkOrder.RemainingAmount;
                MRK_WorkOrder.Remarks = aMRK_WorkOrder.Remarks;

                MRK_WorkOrder.PaymentCondition = aMRK_WorkOrder.PaymentCondition;
                MRK_WorkOrder.AMC_Condition = aMRK_WorkOrder.AMC_Condition;
                MRK_WorkOrder.DevelopmentDept = aMRK_WorkOrder.DevelopmentDept;
                MRK_WorkOrder.WarrantyPeriod = aMRK_WorkOrder.WarrantyPeriod;
                MRK_WorkOrder.AMCDAte = aMRK_WorkOrder.AMCDAte;
                MRK_WorkOrder.HandoverStatus = aMRK_WorkOrder.HandoverStatus;

                MRK_WorkOrder.Edit_User = aMRK_WorkOrder.Edit_User;
                MRK_WorkOrder.Edit_Date = aMRK_WorkOrder.Edit_Date;
                MRK_WorkOrder.OCODE = aMRK_WorkOrder.OCODE;

                _Context.SaveChanges();
                return 1;

            }
            catch (Exception)
            {

                throw;
            }
        }

        internal int SaveWorkOrderToTransaction(MRK_Transaction aMRK_Transaction)
        {
            using (_Context = new ERPSSL_Marketing_Entities())
            {
                _Context.MRK_Transaction.AddObject(aMRK_Transaction);
                _Context.SaveChanges();
                return 1;
            }
        }

        internal List<LC_InputType> GettAllTask()
        {
            using(_Context = new ERPSSL_Marketing_Entities())
            {
                try
                {
                    var query = (from l in _Context.LC_InputType
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

        internal List<MarketingWorkOrder> GetWorkOrderStatus()
        {
            try
            {
                var query = (from w in _Context.MRK_WorkOrder
                             join m in _Context.MRK_MarketingInfo on w.MarketingInfoId equals m.MarketingInfoId
                             join p in _Context.MRK_Project on m.ProjectId equals p.ProjectId
                             join mp in _Context.HRM_PersonalInformations on m.MarketingPersonId equals mp.EID
                             select new MarketingWorkOrder
                             {
                                 WoID = (int)w.WoID,
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
                                 MarketingPersonId = mp.EID,
                                 MarketingPersonName = mp.FirstName,

                                 WorkOrderDate = (DateTime)w.WorkOrderDate,
                                 CompletionPeriod = w.CompletionPeriod,
                                 ProposedAmount = (decimal)w.ProposedAmount,
                                 SigningAmount = (decimal)w.SigningAmount,
                                 RemainingAmount = (decimal)w.RemainingAmount,
                                 Remarks = w.Remarks,
                             });

                return query.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal List<MarketingWorkOrder> GetAllWorkOrderDetailsbyClientName(string OCode, string clientName)
        {
            try
            {
                var query = (from w in _Context.MRK_WorkOrder
                             join m in _Context.MRK_MarketingInfo on w.MarketingInfoId equals m.MarketingInfoId
                             join p in _Context.MRK_Project on m.ProjectId equals p.ProjectId
                             join mp in _Context.HRM_PersonalInformations on m.MarketingPersonId equals mp.EID
                             where w.OCODE == OCode && m.Client == clientName
                             select new MarketingWorkOrder
                             {
                                 WoID = (int)w.WoID,
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
                                 MarketingPersonId = mp.EID,
                                 MarketingPersonName = mp.FirstName,

                                 WorkOrderDate = (DateTime)w.WorkOrderDate,
                                 CompletionPeriod = w.CompletionPeriod,
                                 ProposedAmount = (decimal)w.ProposedAmount,
                                 SigningAmount = (decimal)w.SigningAmount,
                                 RemainingAmount = (decimal)w.RemainingAmount,
                                 Remarks = w.Remarks,
                             }

                             ).OrderBy(x => x.WoID);

                return query.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
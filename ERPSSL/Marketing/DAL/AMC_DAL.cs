using ERPSSL.Marketing.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPSSL.Marketing.DAL
{
    public class AMC_DAL
    {
        ERPSSL_Marketing_Entities _Context = new ERPSSL_Marketing_Entities();
        internal List<MRK_MarketingInfo> GetAllMarketingInfoByClientName(string clientName, string OCode)
        {
            try
            {
                //var query = (from m in _Context.MRK_MarketingInfo
                //             where m.OCODE == OCode && m.Client == clientName && m.StageId == 3
                //             select m).OrderBy(x => x.Client);

                var query = (from m in _Context.MRK_MarketingInfo
                             where (_Context.MRK_WorkOrder.Any(w => w.MarketingInfoId == m.MarketingInfoId)) && m.OCODE == OCode && m.StageId == 3 && m.Client == clientName
                             select m);

                return query.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        internal List<MRK_MarketingInfo> GetALLMarketingInfoInGridView(string OCode)
        {
            try
            {

                var query = (from m in _Context.MRK_MarketingInfo
                             where (_Context.MRK_WorkOrder.Any(w => w.MarketingInfoId == m.MarketingInfoId)) && m.OCODE == OCode && m.StageId == 3
                             select m);

                return query.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        internal MarketingWorkOrder GetSingaleWorkOrderDeatils(int marketingId)
        {
            //try
            //{
                var query = (from w in _Context.MRK_WorkOrder
                             join m in _Context.MRK_MarketingInfo on w.MarketingInfoId equals m.MarketingInfoId
                             join p in _Context.MRK_Project on m.ProjectId equals p.ProjectId
                             join mp in _Context.HRM_PersonalInformations on m.MarketingPersonId equals mp.EID
                             where m.MarketingInfoId == marketingId
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
                                 ProposedAmount = (Decimal)w.ProposedAmount,
                                 SigningAmount = (Decimal)w.SigningAmount,
                                 RemainingAmount = (Decimal)w.RemainingAmount,
                                 Remarks = w.Remarks,
                                 PaymentCondition = w.PaymentCondition,
                                 AMC_Condition = w.AMC_Condition,
                                 WarrantyPeriod = (int)w.WarrantyPeriod,
                                 AMCDate = (DateTime)w.AMCDAte,
                                 HandoverStatus = (Boolean)w.HandoverStatus
                             }

                             ).SingleOrDefault();

                return query;
            //}
            //catch (Exception ex)
            //{
            //    throw ex;
            //}
        }

        internal int SaveAMCInfo(MRK_AMC aMRK_AMC)
        {
            try
            {
                using (_Context = new ERPSSL_Marketing_Entities())
                {
                    _Context.MRK_AMC.AddObject(aMRK_AMC);
                    _Context.SaveChanges();

                    return 1;
                    //return aMRK_WorkOrder.WoID; // If want to return last id from table
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
            
        }

        

        internal List<MarketingWorkOrderAMC> GetAllWorkOrderAMCDetails(string OCode)
        {
            try
            {
                var query = (from a in _Context.MRK_AMC
                             join w in _Context.MRK_WorkOrder on a.WorkOrderId equals w.WoID
                             join m in _Context.MRK_MarketingInfo on w.MarketingInfoId equals m.MarketingInfoId
                             join p in _Context.MRK_Project on m.ProjectId equals p.ProjectId
                             join mp in _Context.HRM_PersonalInformations on m.MarketingPersonId equals mp.EID
                             where a.OCODE == OCode
                             select new MarketingWorkOrderAMC
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
                                 AMCId = a.Id,
                                 AMC_Condition = a.AMC_Condition,
                                 AMC_Type = a.AMC_Type,
                                 AMC_Amount = (decimal)a.Amount,
                                 AMCDate = (DateTime)w.AMCDAte,
                                 AMC_EndDate = (DateTime)a.EndDate
                             }

                             ).OrderBy(x => x.WoID);

                return query.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        internal MarketingWorkOrderAMC GetSingaleAMCDeatils(int AMCId)
        {
            try
            {
                var query = (from a in _Context.MRK_AMC
                             join w in _Context.MRK_WorkOrder on a.WorkOrderId equals w.WoID
                             join m in _Context.MRK_MarketingInfo on w.MarketingInfoId equals m.MarketingInfoId
                             join p in _Context.MRK_Project on m.ProjectId equals p.ProjectId
                             join mp in _Context.HRM_PersonalInformations on m.MarketingPersonId equals mp.EID
                             where a.Id == AMCId
                             select new MarketingWorkOrderAMC
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
                                 PaymentCondition = w.PaymentCondition,
                                 Remarks = w.Remarks,
                                 AMC_Condition = a.AMC_Condition,
                                 AMC_Type = a.AMC_Type,
                                 AMC_Amount = (decimal)a.Amount,
                                 AMCDate = (DateTime)w.AMCDAte,
                                 AMC_EndDate = (DateTime)a.EndDate
                             }

                             ).SingleOrDefault();

                return query;
            }
            catch (Exception ex)
            {
                throw ex;
            }
 
        }

        internal int UpdateAMCInfo(MRK_AMC aMRK_AMC, int AMCId)
        {
            MRK_AMC MRK_AMC = _Context.MRK_AMC.First(x => x.Id == AMCId);

            MRK_AMC.WorkOrderId = aMRK_AMC.WorkOrderId;
            MRK_AMC.AMC_Condition = aMRK_AMC.AMC_Condition;
            MRK_AMC.AMC_Type = aMRK_AMC.AMC_Type;
            MRK_AMC.Amount = aMRK_AMC.Amount;
            MRK_AMC.EndDate = aMRK_AMC.EndDate;
            MRK_AMC.BillingStatus = aMRK_AMC.BillingStatus;

            MRK_AMC.Edit_User = aMRK_AMC.Edit_User;
            MRK_AMC.Edit_Date = aMRK_AMC.Edit_Date;
            MRK_AMC.OCODE = aMRK_AMC.OCODE;

            _Context.SaveChanges();
            return 1;
        }
    }
}
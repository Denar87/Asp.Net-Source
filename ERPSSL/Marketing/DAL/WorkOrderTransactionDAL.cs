using ERPSSL.Marketing.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ERPSSL.Marketing.DAL
{
    public class WorkOrderTransactionDAL
    {
        ERPSSL_Marketing_Entities _Context = new ERPSSL_Marketing_Entities();

        internal MarketingWorkOrderTransaction GetSingaleWorkOrderDeatilsByClientName(string clientName)
        {
            try
            {
                var query = (from w in _Context.MRK_WorkOrder
                             join m in _Context.MRK_MarketingInfo on w.MarketingInfoId equals m.MarketingInfoId
                             join p in _Context.MRK_Project on m.ProjectId equals p.ProjectId
                             join mp in _Context.HRM_PersonalInformations on m.MarketingPersonId equals mp.EID
                             where m.Client == clientName && m.StageId == 3
                             select new MarketingWorkOrderTransaction
                             {
                                 
                                 WorkOrderId = (int)w.WoID,
                                 WorkOrderDate = (DateTime)w.WorkOrderDate,
                                 CompletionPeriod = w.CompletionPeriod,
                                 ProposedAmount = (decimal)w.ProposedAmount,
                                 SingingAmount = (decimal)w.SigningAmount,


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
                                 MArketingPersonName = mp.FirstName,

                                 
                                 RemainingAmount = (decimal)w.RemainingAmount,
                                 Remarks = w.Remarks,
                             }

                             ).FirstOrDefault();

                return query;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        
        }

        internal List<MRK_Transaction> GetAllTransactionDetails(int workOrderId, string OCode)
        {
            try
            {
                var query = (from t in _Context.MRK_Transaction
                             where t.WorkOrderId == workOrderId && t.OCODE == OCode
                             select t);

                return query.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal List<MarketingWorkOrderTransaction> GetCollectionInformationByDate(string OCODE, DateTime FromDate, DateTime ToDate)
        {
            try
            {
                using (var _context = new ERPSSL_Marketing_Entities())
                {
                    var _OCode = new SqlParameter("@OCODE", OCODE);
                    var _FromDate = new SqlParameter("@FromDate", FromDate);
                    var _ToDate = new SqlParameter("@ToDate", ToDate);

                    string SP_SQL = "MRK_RPT_CollectionByDate @OCODE, @FromDate, @ToDate ";
                    return (_context.ExecuteStoreQuery<MarketingWorkOrderTransaction>(SP_SQL, _OCode, _FromDate, _ToDate)).ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal List<MarketingWorkOrderTransaction> GetAllCurrentMonthTransactionDetails(int nowMonth, int nowYear, string OCode)
        {
            try
            {
                var query = (from t in _Context.MRK_Transaction
                             join w in _Context.MRK_WorkOrder on t.WorkOrderId equals w.WoID
                             join m in _Context.MRK_MarketingInfo on w.MarketingInfoId equals m.MarketingInfoId
                             where t.CollectionDate.Value.Month == nowMonth && t.CollectionDate.Value.Year == nowYear
                             select new MarketingWorkOrderTransaction
                             {

                                 Client = m.Client,
                                 ContactPerson = m.ContactPerson,
                                 Designation = m.Designation,
                                 ContactNumber = m.ContactNumber,
                                 Email = m.Email,
                                 Address = m.Address,
                                 TransactionId = (int)t.TransactionId,
                                 CollectionDate = (DateTime)t.CollectionDate,
                                 CollectionAmount = (decimal)t.CollectionAmount,
                                 TRemarks = t.Remarks
                             }

                             );

                return query.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
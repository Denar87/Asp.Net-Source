using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ERPSSL.INV.DAL;
using System.Data.SqlClient;
using ERPSSL.INV.DAL.Repository;

namespace ERPSSL.Procurement.DAL
{
    public class RequisitionDAL
    {
        private ERPSSL_INVEntities _context = new ERPSSL_INVEntities();

        internal int StoreReqApprovalBySupervisor(List<PRQ_Requisitions> lstPRQ_Requisitions)
        {
            try
            {
                foreach (PRQ_Requisitions aReq in lstPRQ_Requisitions)
                {
                    PRQ_Requisitions obj = _context.PRQ_Requisitions.First(x => x.ReqNo == aReq.ReqNo && x.BarCode==aReq.BarCode);
                    obj.ManagerApproveQty = aReq.ManagerApproveQty;
                    obj.IsAcceptedByManager = aReq.IsAcceptedByManager;
                    //obj.Status = aReq.Status;
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

        internal int PurchaseReqApprovalBySupervisor2(List<PRQ_Requisitions> lstPRQ_Requisitions )
        {
            try
            {
                foreach (PRQ_Requisitions aReq in lstPRQ_Requisitions)
                {
                    PRQ_Requisitions obj = _context.PRQ_Requisitions.First(x => x.ReqNo == aReq.ReqNo && x.BarCode == aReq.BarCode);
                    obj.Manager2ApproveQty = aReq.Manager2ApproveQty;
                    obj.IsAcceptedByManager2 = aReq.IsAcceptedByManager2;
                    //obj.Status = aReq.Status;
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
      
        internal int StoreReqApprovalByAdmin(List<PRQ_Requisitions> lstPRQ_Requisitions)
        {
            try
            {
                foreach (PRQ_Requisitions aReq in lstPRQ_Requisitions)
                {
                    PRQ_Requisitions obj = _context.PRQ_Requisitions.First(x => x.ReqNo == aReq.ReqNo && x.BarCode == aReq.BarCode);
                    obj.HeadApproveQty = aReq.HeadApproveQty;
                    obj.IsAcceptedByManager = aReq.IsAcceptedByManager;
                    obj.IsAcceptedByHead = aReq.IsAcceptedByHead;
                    obj.Status = aReq.Status;
                    obj.Admin_EID = aReq.Admin_EID;
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

        internal int PurchaseReqApprovalByAdmin(List<PRQ_Requisitions> lstPRQ_Requisitions)
        {
            try
            {
                foreach (PRQ_Requisitions aReq in lstPRQ_Requisitions)
                {
                    PRQ_Requisitions obj = _context.PRQ_Requisitions.First(x => x.ReqNo == aReq.ReqNo && x.BarCode == aReq.BarCode);
                    obj.HeadApproveQty = aReq.HeadApproveQty;
                    obj.IsAcceptedByManager = aReq.IsAcceptedByManager;
                    obj.IsAcceptedByHead = aReq.IsAcceptedByHead;
                    obj.Status = aReq.Status;
                    obj.Admin_EID = aReq.Admin_EID;
                    obj.Price = aReq.Price;
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


        internal int PurchaseReqApprovalByManagement(List<PRQ_Requisitions> lstPRQ_Requisitions)
        {
            try
            {
                foreach (PRQ_Requisitions aReq in lstPRQ_Requisitions)
                {
                    PRQ_Requisitions obj = _context.PRQ_Requisitions.First(x => x.ReqNo == aReq.ReqNo && x.BarCode == aReq.BarCode);
                    obj.ManagementAppQty = aReq.ManagementAppQty;
                    obj.IsAcceptedByManagement = aReq.IsAcceptedByManagement;
                    obj.Status = aReq.Status;
                    //obj.Req_File = aReq.Req_File;
                    obj.RFile_Name = aReq.RFile_Name;
                    obj.RFile_Type = aReq.RFile_Type;
                    obj.File_Path = aReq.File_Path;
                    obj.Management_Status = aReq.Management_Status;
                    
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

        public int UpdateSupervisor(PRQ_Requisitions aPRQ_Requisitions, string eId)
        {
            try
            {
                PRQ_Requisitions requisition = _context.PRQ_Requisitions.First(x => x.EID == eId);
                requisition.Old_Supervisor_EID = aPRQ_Requisitions.Old_Supervisor_EID;
                requisition.Supervisor_EID = aPRQ_Requisitions.Supervisor_EID;
                //requisition.EID = aPRQ_Requisitions.EID;

                _context.SaveChanges();
                return 1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal virtual List<PRQ_Requisitions> GetRequisitionInfo(string eID)
        {
                var query = (from req in _context.PRQ_Requisitions
                             where req.EID == eID
                             select req);

                return query.ToList();
        }

        internal int AddPurchaseRequisition_ForNewItem(string productName, string description)
        {
            try
            {
                using (var _context = new ERPSSL_INVEntities())
                {
                    var ParamempID1 = new SqlParameter("@ProductName", productName);
                    var ParamempID2 = new SqlParameter("@Description", description);
                    string SP_SQL = "PRQ_AddPurchaseRequisition_ForNewItem @ProductName,@Description";
                    _context.ExecuteStoreCommand(SP_SQL, ParamempID1, ParamempID2);

                    return 1;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public PRQ_Requisition_Temp GetReq_temp_ItemByProductInfo(string EID, int barcode, Guid userId)
        {
            try
            {
                PRQ_Requisition_Temp aPRQ_Requisition_Temp = _context.PRQ_Requisition_Temp.Where(req => req.EID == EID && req.BarCode == barcode && req.EditUser == userId).FirstOrDefault<PRQ_Requisition_Temp>();
                return aPRQ_Requisition_Temp;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        internal int AddTempToStoreReq(string ReqNo)
        {
            try
            {
                using (var _context = new ERPSSL_INVEntities())
                {
                    var ParamempID2 = new SqlParameter("@ReqNo", ReqNo);
                    string SP_SQL = "PRQ_AddStore_Requisition @ReqNo";
                    _context.ExecuteStoreCommand(SP_SQL, ParamempID2);

                    return 1;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        internal List<GINStoreReqR> GetAll_DistinctApprovedStoreReq()
        {
            try
            {
                using (var _context = new ERPSSL_INVEntities())
                {

                    string SP_SQL = "PRQ_GetAll_DistinctApprovedStoreReq";
                    return (_context.ExecuteStoreQuery<GINStoreReqR>(SP_SQL)).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        internal List<DeleveryProductR> PRQ_GetSelectedProductToDeliverByReqNo(string reqno, string Ocode)
        {
            try
            {
                using (var _context = new ERPSSL_INVEntities())
                {
                    var ocode = new SqlParameter("@OCODE", Ocode);
                    var ParamsalRequsNo = new SqlParameter("@Req", reqno);
                    string SP_SQL = "PRQ_GetSelectedProductToDeliverByReqNo @OCODE,@Req";
                    return (_context.ExecuteStoreQuery<DeleveryProductR>(SP_SQL, ocode, ParamsalRequsNo)).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }

        }
    }
}
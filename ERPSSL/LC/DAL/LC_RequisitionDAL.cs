using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using ERPSSL.LC.DAL.Repository;
using System.Configuration;
using ERPSSL.INV.DAL;
using MoreLinq;

namespace ERPSSL.LC.DAL
{
    public class LC_RequisitionDAL
    {
        private ERPSSL_LCEntities _Context = new ERPSSL_LCEntities();
        DataAccessEX ado = new DataAccessEX();
        string conn = ConfigurationManager.ConnectionStrings["ERPSSLADO"].ConnectionString;

        internal List<Rep_Estimate> Get_AllEstimatedSummaryList(string OCODE)
        {
            try
            {
                var LC_Req = (from req in _Context.LC_CostEstimateSummary
                              join buyer in _Context.Com_Buyer_Setup on req.Buyer_ID equals buyer.Buyer_ID
                              join item in _Context.LC_FinishGoods on req.FinishedGoods_ID equals item.FinishGoods_Id
                              where req.OCode == OCODE
                              select new Rep_Estimate
                              {
                                  Buyer_Name = buyer.Buyer_Name,
                                  FinishedGoods_Qty = req.FinishedGoods_Qty,
                                  FinishGoods_Name = item.FinishGoods_Name,
                                  Lc_Order = req.Lc_Order,
                                  OrderDate = req.OrderDate,
                                  Ref_No = req.Ref_No,
                                  Lc_Style = req.Lc_Style,
                                  Merchandiser_Name = req.Merchandiser_Name,
                                  Estimation_Approval = req.Estimation_Approval,
                                  Cost_Estimate_ID = req.Cost_Estimate_ID
                              });
                return LC_Req.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        internal List<Rep_Estimate> Get_All_LC_RequisitionList(string OCODE)
        {
            try
            {
                var LC_Req = (from req in _Context.LC_Requisition
                              join buyer in _Context.Com_Buyer_Setup on req.Buyer_ID equals buyer.Buyer_ID
                              where req.OCode == OCODE
                              select new Rep_Estimate
                              {
                                  ReqNo = req.LC_ReqNo,
                                  Buyer_Name = buyer.Buyer_Name,
                                  Lc_Order = req.LC_Order,
                                  Lc_Style = req.LC_Style,
                                  Cost_Estimate_ID = req.Cost_Estimate_ID,
                                  LC_ReqDate = req.LC_ReqDate,
                                  IsReqApproved = req.IsReqApproved
                              }).DistinctBy(x => x.ReqNo);
                return LC_Req.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        internal List<Rep_Estimate> Get_AllEstimateDetailsList(string EstimateCostid)
        {
            try
            {
                var LC_Req = (from ed in _Context.LC_CostEstimateDetails
                              join pro in _Context.Inv_Product on ed.ProductId equals pro.ProductId
                              join gr in _Context.Inv_ProductGroup on ed.GroupId equals gr.GroupId
                              join un in _Context.Inv_Unit on ed.UnitId equals un.UnitId
                              join su in _Context.Inv_Supplier on ed.SupplierCode equals su.SupplierCode
                              join es in _Context.LC_CostEstimateSummary on ed.CostEstimate_Id equals es.Cost_Estimate_ID
                              join buyer in _Context.Com_Buyer_Setup on es.Buyer_ID equals buyer.Buyer_ID
                              where ed.CostEstimate_Id == EstimateCostid
                              select new Rep_Estimate
                              {
                                  ProductName = pro.ProductName,
                                  UnitName = un.UnitName,
                                  GroupName = gr.GroupName,
                                  SupplierName = su.SupplierName,
                                  Qty_PC = ed.Qty_PC,
                                  Qty_Dzn = ed.Qty_Dzn,
                                  UnitPrice = ed.UnitPrice,
                                  TotalUnitQty = ed.TotalUnitQty,
                                  Amount = ed.Amount,
                                  Buyer_ID = es.Buyer_ID,
                                  UnitId = un.UnitId,
                                  ProductId = pro.ProductId,
                                  GroupId = gr.GroupId,
                                  Lc_Style = es.Lc_Style,
                                  Lc_Order = es.Lc_Order,
                                  SupplierCode = su.SupplierCode
                              });
                return LC_Req.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        internal List<Rep_Estimate> Get_AllRequisitionDetails(string ReqNo)
        {
            try
            {
                var LC_Req = (from ed in _Context.LC_Requisition
                              join pro in _Context.Inv_Product on ed.ProductId equals pro.ProductId
                              join gr in _Context.Inv_ProductGroup on ed.GroupId equals gr.GroupId
                              join un in _Context.Inv_Unit on ed.UnitId equals un.UnitId
                              join su in _Context.Inv_Supplier on ed.SupplierCode equals su.SupplierCode
                              join buyer in _Context.Com_Buyer_Setup on ed.Buyer_ID equals buyer.Buyer_ID
                              join central in _Context.Inv_BuyCentral on ed.ProductId equals central.ProductId into tmpGroups
                              from central in tmpGroups.DefaultIfEmpty()
                              where ed.LC_ReqNo == ReqNo
                              select new Rep_Estimate
                              {
                                  ReqNo = ed.LC_ReqNo,
                                  ProductName = pro.ProductName,
                                  UnitName = un.UnitName,
                                  GroupName = gr.GroupName,
                                  SupplierName = su.SupplierName,
                                  Buyer_Name = buyer.Buyer_Name,
                                  Buyer_ID = ed.Buyer_ID,
                                  Cost_Estimate_ID = ed.Cost_Estimate_ID,
                                  UnitId = un.UnitId,
                                  ProductId = pro.ProductId,
                                  GroupId = gr.GroupId,
                                  Lc_Style = ed.LC_Style,
                                  Lc_Order = ed.LC_Order,
                                  SupplierCode = su.SupplierCode,
                                  Req_ApprovedQty = ed.Req_ApprovedQty,
                                  Req_Qty = ed.Req_Qty,
                                  BalanceQty = central.BalanceQuanity
                              });
                return LC_Req.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        internal int UpdateRequisitionApprovedStatus(List<LC_Requisition> details)
        {
            foreach (LC_Requisition item in details)
            {
                var result = _Context.LC_Requisition.Where(x => x.ProductId == item.ProductId && x.LC_ReqNo == item.LC_ReqNo).FirstOrDefault();
                result.Req_Approve_Date = item.Req_Approve_Date;
                result.Req_ApprovedQty = item.Req_ApprovedQty;
                result.IsReqApproved = true;
                _Context.SaveChanges();

            }
            return 1;
        }

        internal int SavePO(List<LC_PurchaseOrder> details)
        {
            try
            {
                foreach (LC_PurchaseOrder item in details)
                {
                    _Context.LC_PurchaseOrder.AddObject(item);
                    _Context.SaveChanges();
                }
                return 1;
            }
            catch (Exception)
            {
                throw;
            }
        }

        internal List<Rep_Estimate> Get_AllPODetails(string PONo, string OCODE)
        {
            try
            {
                var LC_Req = (from po in _Context.LC_PurchaseOrder
                              //join r in _Context.LC_Requisition on po.LC_ReqNo equals r.LC_ReqNo
                              join pro in _Context.Inv_Product on po.ProductId equals pro.ProductId
                              join gr in _Context.Inv_ProductGroup on po.GroupId equals gr.GroupId
                              join un in _Context.Inv_Unit on po.UnitId equals un.UnitId
                              join su in _Context.Inv_Supplier on po.SupplierCode equals su.SupplierCode
                              join buyer in _Context.Com_Buyer_Setup on po.Buyer_ID equals buyer.Buyer_ID
                              where po.LC_PO_No == PONo

                              select new Rep_Estimate
                              {
                                  LC_PurchaseOrder_Id = po.LC_PurchaseOrder_Id,
                                  LC_PO_No = po.LC_PO_No,
                                  ReqNo = po.LC_ReqNo,
                                  ProductName = pro.ProductName,
                                  UnitName = un.UnitName,
                                  GroupName = gr.GroupName,
                                  SupplierName = su.SupplierName,
                                  Buyer_Name = buyer.Buyer_Name,
                                  Buyer_ID = po.Buyer_ID,
                                  Cost_Estimate_ID = po.Cost_Estimate_ID,
                                  UnitId = un.UnitId,
                                  ProductId = pro.ProductId,
                                  GroupId = gr.GroupId,
                                  Lc_Style = po.LC_Style,
                                  Lc_Order = po.LC_Order,
                                  SupplierCode = su.SupplierCode,
                                  LC_PO_Qty = po.LC_PO_Qty,
                                  LC_PO_Date = po.LC_PO_Date
                              });
                return LC_Req.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        internal int UpdatePOApprovedStatus(List<LC_PurchaseOrder> details)
        {
            foreach (LC_PurchaseOrder item in details)
            {
                var result = _Context.LC_PurchaseOrder.Where(x => x.ProductId == item.ProductId && x.LC_PO_No == item.LC_PO_No).FirstOrDefault();
                result.PO_ApprovedDate = item.PO_ApprovedDate;
                result.PO_Approved_Qty = item.PO_Approved_Qty;
                result.IsPO_Approved = true;
                _Context.SaveChanges();
            }
            return 1;
        }

        internal LC_PurchaseOrder GetPurchaseOrderById(int Id)
        {
            LC_PurchaseOrder _PurschaseOrder = _Context.LC_PurchaseOrder
                .Where(po => po.LC_PurchaseOrder_Id == Id).FirstOrDefault();
            return _PurschaseOrder;
        }

        internal Inv_Product GetProductByProductID(int ProductID)
        {
            Inv_Product _invProduct = _Context.Inv_Product
                .Where(po => po.ProductId == ProductID).FirstOrDefault();
            return _invProduct;
        }

    }
}
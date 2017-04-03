using ERPSSL.LC.DAL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using ERPSSL.LC.DAL.Repository;
using ERPSSL.HRM.DAL.Repository;
using ERPSSL.BuyingHouse.DAL.Repository;

namespace ERPSSL.LC.BLL
{
    public class MasterLCBLL
    {
        DataAccess ado = new DataAccess();
        string conn = ConfigurationManager.ConnectionStrings["ERPSSLADO"].ConnectionString;

        MasterLCDAL _masterlcDAL = new MasterLCDAL();
        internal List<Com_Buyer_Setup> GetAllBuyerName(string OCODE)
        {
            return _masterlcDAL.GetAllBuyerName(OCODE);
        }

        internal int InsertNewOrderEntry(LC_OrderEntryTemp objneworder)
        {
            return _masterlcDAL.InsertNewOrderEntry(objneworder);
        }

        internal List<LC_OrderEntryTemp> GetAllOrderE_Temp(string LcNo)
        {
            return _masterlcDAL.GetAllOrderE_Temp(LcNo);
        }

        //internal List<LC_OrderEntryTemp> GetAllOrder()
        //{
        //    return _masterlcDAL.GetAllOrder();
        //}

        internal int UpdateOrderEntry_Temp(LC_OrderEntryTemp objOentry, int ID)
        {
            return _masterlcDAL.UpdateOrderEntry_Temp(objOentry, ID);
        }

        internal int UpdateOrderEntry(LC_OrderEntry objOentry, string LCNo, string OrderNo)
        {
            return _masterlcDAL.UpdateOrderEntry(objOentry, LCNo, OrderNo);
        }

        internal void DeleteLCorderEntryById(int id)
        {
            try
            {
                ado.AggRetrive("delete from LC_OrderEntryTemp where OrderEntryID = " + id + "", conn);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal int InsertLCmaster(LC_MasterLC _objLCmaster)
        {
            return _masterlcDAL.InsertLCmaster(_objLCmaster);
        }

        internal List<LC_OrderEntryTemp> GetAllMlcAndOEntry(string OElcNo)
        {
            return _masterlcDAL.GetAllMlcAndOEntry(OElcNo);
        }

        internal int InsertAllMlcAndOEntry(LC_OrderEntry lC_OrderEntry)
        {
            return _masterlcDAL.InsertAllMlcAndOEntry(lC_OrderEntry);
        }

        internal void ClearAlTemp()
        {
            _masterlcDAL.ClearAlTemp();
        }

        internal List<LC_MasterLC> GetAllLCItemsByLCNo(string lcNo)
        {
            return _masterlcDAL.GetAllLCItemsByLCNo(lcNo);
        }

        internal List<LC_OrderEntry> GetALLOrderEntrybyID(string OEntrylc, string OCODE)
        {
            return _masterlcDAL.GetALLOrderEntrybyID(OEntrylc, OCODE);
        }
        internal int UpdateMasterLc(string LCNo, LC_MasterLC _LC_MasterLC)
        {
            return _masterlcDAL.UpdateMasterLc(LCNo, _LC_MasterLC);
        }
        internal List<LC_OrderEntry> GetLCOrder(string LCNO, string OrderNo)
        {

            return _masterlcDAL.GetLCOrder(LCNO, OrderNo);
        }
        internal int InsertOrderEntry(LC_OrderEntry objneworder)
        {

            return _masterlcDAL.InsertOrderEntry(objneworder);
        }
        internal List<LC_OrderEntry> GetAllOrder(string OCode,string LCNo)
        {
            return _masterlcDAL.GetAllOrder(OCode, LCNo);
        }

        internal List<Rep_Estimate> Get_All_PO_EstimatedSummaryList(string OCODE)
        {
            return _masterlcDAL.Get_All_PO_EstimatedSummaryList(OCODE);
        }


        internal List<Rep_Estimate> Get_EstimateDetailsList(string id)
        {
            return _masterlcDAL.Get_EstimateDetailsList(id);
        }

        internal List<LC_OrderEntry> GetOrderByOrderIdandOcode(string orderId, string OCODE)
        {
            return _masterlcDAL.GetOrderByOrderIdandOcode(orderId, OCODE);
        }

        internal int UpdateOrderEntry(LC_OrderEntry orderEntry, int orderid)
        {
            return _masterlcDAL.UpdateOrderEntry(orderEntry, orderid);
        }

        internal List<HRM_Office> GetAllOffice(string OCode)
        {
            return _masterlcDAL.GetAllOffice(OCode);
        }
        internal List<HRM_SubCompany> GetAllSubCompany(string OCode)
        {
            return _masterlcDAL.GetAllSubCompany(OCode);
        }
        internal List<LC_MasterLC> GetALLLCByLCNo(string LcNo, string OCode)
        {
            return _masterlcDAL.GetALLLCByLCNo(LcNo, OCode);
        }

        internal LC_MasterLC GetLcLById(int LcId)
        {
            return _masterlcDAL.GetLcLById(LcId);
        }

        internal int UpdateMasterAmendLc(LC_MasterLC _objLCmaster)
        {
            return _masterlcDAL.UpdateMasterAmendLc(_objLCmaster);
        }

        internal List<LC_MasterLC> GetALLLCById(string OCode)
        {
            return _masterlcDAL.GetALLLCById(OCode);
        }

        internal List<LC_MasterLC> GetALLLCByType(string OCode)
        {
            return _masterlcDAL.GetALLLCByType(OCode);
        }

        internal List<LC_MasterLC> GetALLLCByContact(string OCode)
        {
            return _masterlcDAL.GetALLLCByContact(OCode);
        }

        internal List<LC_OrderEntry> GetAllOrderByOcode(string ocode)
        {
            return _masterlcDAL.GetAllOrderByOcode(ocode);
        }

        internal List<RLc> GetAllOrderByShipmentDate(string ocode)
        {
            return _masterlcDAL.GetAllOrderByShipmentDate(ocode);
        }

        internal int InsertTaskDetails(LC_Task_Details aLC_Task_Details)
        {
            return _masterlcDAL.InsertTaskDetails(aLC_Task_Details);
        }

        internal List<OrderUpdateRepository> GetOrderByOrderNoandOcode(string orderNo, string OCODE)
        {
            return _masterlcDAL.GetOrderByOrderNoandOcode(orderNo, OCODE);
        }

        internal List<LC_Task_Details> GetTaskDetailsByOrderNoandOcode(string orderNo, string OCODE)
        {
            return _masterlcDAL.GetTaskDetailsByOrderNoandOcode(orderNo, OCODE);
        }

        internal int InsertProductionProcces(LC_ProductionDetails _LC_ProductionDetails)
        {
            return _masterlcDAL.InsertProductionProcces(_LC_ProductionDetails);
        }

        internal List<ItemList> GetductionProccess(string OrderNo)
        {
            return _masterlcDAL.GetductionProccess(OrderNo);
        }

        internal bool isOrderExist(string p)
        {
            return _masterlcDAL.isOrderExist(p);
        }

        internal int UpdateProductionProcess(LC_ProductionDetails _LC_ProductionDetails, int ID)
        {
            return _masterlcDAL.UpdateProductionProcess(_LC_ProductionDetails, ID); 
        }

        internal List<LC_ResponsiblePerson> GetAllResposiblePerson()
        {
            return _masterlcDAL.GetAllResposiblePerson();
        }

        internal IEnumerable<REmployee> GetResponsiblePerson(string OCODE)
        {
            return _masterlcDAL.GetResponsiblePerson(OCODE);
        }

        internal List<ItemList> GetAllPendingTaskByOcode(string ocode)
        {
            return _masterlcDAL.GetAllPendingTaskByOcode(ocode);
        }
        internal bool isTaskOrderExist(string p)
        {
            return _masterlcDAL.isTaskOrderExist(p);
        }

        internal int UpdateTaskDetails(LC_Task_Details aLC_Task_Details, int ID)
        {
            return _masterlcDAL.UpdateTaskDetails(aLC_Task_Details, ID);
        }

        internal List<ItemList> GetTaskDetailsByOrderNo(string orderNo,string OCODE)
        {
            return _masterlcDAL.GetTaskDetailsByOrderNo(orderNo,OCODE);
        }

        internal List<ItemList> GetAllFailOrder(string ocode)
        {
            return _masterlcDAL.GetAllFailOrder(ocode);
        }

        internal int SaveLC_DataApprovalSummay(LC_DataApprovalSummay sLC_DataApprovalSummay)
        {
            return _masterlcDAL.SaveLC_DataApprovalSummay(sLC_DataApprovalSummay);
        }

        internal List<LC_DataApprovalSummay> GetApprovallistByEid(string UserEmpId)
        {
            return _masterlcDAL.GetApprovallistByEid(UserEmpId);
        }

        internal int UpdateProductionStutas(LC_ProductionStatus _LC_ProductionStatus, int ID)
        {
            return _masterlcDAL.UpdateProductionStutas(_LC_ProductionStatus, ID);
        }

        internal ItemList GetProductionProccessData(string orderNo)
        {
            return _masterlcDAL.GetProductionProccessData(orderNo);
        }

        internal List<ItemList> GetProductionStatus(string OrderNo)
        {
            return _masterlcDAL.GetProductionStatus(OrderNo);
        }

        internal int InsertProductionStatus(LC_ProductionStatus _LC_ProductionStatus)
        {
            return _masterlcDAL.InsertProductionStatus(_LC_ProductionStatus);
        }

        internal List<LC_ProductionDetails> GetOrderByOrderNo(string orderNo)
        {
            return _masterlcDAL.GetOrderByOrderNo(orderNo);
        }

        internal List<LC_ProductionStatus> GetOrderStatusByOrderNo(string orderNo)
        {
            return _masterlcDAL.GetOrderStatusByOrderNo(orderNo);
        }

        internal int SaveLC_Season(LC_Season _LC_Season)
        {
            return _masterlcDAL.SaveLC_Season(_LC_Season);
        }

        internal List<LC_Season> GetSeasonList(string OCode)
        {
            return _masterlcDAL.GetSeasonList(OCode);
        }
        internal List<BuyingHouseReport> LoadLCOrderGrid(string ocode)
        {
            return _masterlcDAL.LoadLCOrderGrid(ocode);
        }

        internal int InsertShipment(LC_Shipment sLC_Shipment)
        {
            return _masterlcDAL.InsertShipment(sLC_Shipment);
        }

        internal List<LC_Shipment> GetShipmentDetails(string ocode)
        {
            return _masterlcDAL.GetShipmentDetails(ocode);
        }

        internal List<LC_Shipment> GetShipmentDetailsByIdandOcode(string ShipmentId, string OCODE)
        {
            return _masterlcDAL.GetShipmentDetailsByIdandOcode(ShipmentId, OCODE);
        }

        internal int UpdateShipment(LC_Shipment sLC_Shipment, int id)
        {
            return _masterlcDAL.UpdateShipment(sLC_Shipment, id); 
        }

        internal int SaveAmendLog(LC_LCContract_Log _LC_LCContract_Log)
        {
            return _masterlcDAL.SaveAmendLog(_LC_LCContract_Log); 
        }

        internal List<BuyingHouseReport> GetLCOrderGridByONo(string ocode, string Order_No)
        {
            return _masterlcDAL.GetLCOrderGridByONo(ocode, Order_No);
        }

        internal List<BuyingHouseReport> GetLCOrderGridByStyle(string ocode, int StyleId)
        {
            return _masterlcDAL.GetLCOrderGridByStyle(ocode, StyleId);
        }

        internal List<BuyingHouseReport> GetLCOrderGridByBuyer(string ocode, int BuyerId)
        {
            return _masterlcDAL.GetLCOrderGridByBuyer(ocode, BuyerId);
        }

        internal List<BuyingHouseReport> GetLCOrderGridByFactory(string ocode, int FactoryId)
        {
            return _masterlcDAL.GetLCOrderGridByFactory(ocode, FactoryId);
        }

        internal List<BuyingHouseReport> GetLCOrderGridByPrincipal(string ocode, int PrincipalId)
        {
            return _masterlcDAL.GetLCOrderGridByPrincipal(ocode, PrincipalId);
        }

        internal List<BuyingHouseReport> GetLCOrderGridByOrderNo(int orderId, string OCODE)
        {
            return _masterlcDAL.GetLCOrderGridByOrderNo(orderId, OCODE);
        }
    }
}
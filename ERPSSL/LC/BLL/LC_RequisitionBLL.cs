using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ERPSSL.LC.DAL.Repository;
using ERPSSL.LC.DAL;
using System.Configuration;

namespace ERPSSL.LC.BLL
{
    public class LC_RequisitionBLL
    {
        DataAccess ado = new DataAccess();
        LC_RequisitionDAL aLC_RequisitionDAL = new LC_RequisitionDAL();
        string conn = ConfigurationManager.ConnectionStrings["ERPSSLADO"].ConnectionString;

        internal List<Rep_Estimate> Get_AllEstimatedSummaryList(string OCODE)
        {
            return aLC_RequisitionDAL.Get_AllEstimatedSummaryList(OCODE);
        }
        internal List<Rep_Estimate> Get_AllEstimateDetailsList(string EstimateCostid)
        {
            return aLC_RequisitionDAL.Get_AllEstimateDetailsList(EstimateCostid);
        }
        internal List<Rep_Estimate> Get_All_LC_RequisitionList(string OCODE)
        {
            return aLC_RequisitionDAL.Get_All_LC_RequisitionList(OCODE);
        }
        internal List<Rep_Estimate> Get_AllRequisitionDetails(string ReqNo)
        {
            return aLC_RequisitionDAL.Get_AllRequisitionDetails(ReqNo);
        }
        internal int UpdateRequisitionApprovedStatus(List<LC_Requisition> details)
        {
            return aLC_RequisitionDAL.UpdateRequisitionApprovedStatus(details);
        }

        internal List<Rep_Estimate> Get_AllPODetails(string PONo,string OCODE)
        {
            return aLC_RequisitionDAL.Get_AllPODetails(PONo,OCODE);
        }

        internal int UpdatePOApprovedStatus(List<LC_PurchaseOrder> details)
        {
            return aLC_RequisitionDAL.UpdatePOApprovedStatus(details);
        }

        internal string GeneratePO_No(string code, DateTime day)
        {
            DateTime Date = DateTime.Now;
            int count;
            string challanNo = "PO-" + code + day.Year + day.Month + day.Day + Date.Minute + Date.Second;

            try
            {
                count = int.Parse(ado.AggRetrive("select count(Id) from LC_PurchaseOrder where OCode ='" + code + "' ", conn).ToString());
                challanNo += (count + 1).ToString();//.PadLeft(2,'0');
            }
            catch { }

            return challanNo;
        }

        internal int SavePO(List<LC_PurchaseOrder> lstLC_PurchaseOrder)
        {
            return aLC_RequisitionDAL.SavePO(lstLC_PurchaseOrder);
        }

        internal LC_PurchaseOrder GetPurchaseOrderById(int Id)
        {
            return aLC_RequisitionDAL.GetPurchaseOrderById(Id);
        }

        internal Inv_Product GetProductByProductID(int productID)
        {
            return aLC_RequisitionDAL.GetProductByProductID(productID);
        }


    }
}
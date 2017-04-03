using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;
using ERPSSL.Procurement.DAL;
using System.Data;
using ERPSSL.INV.DAL;
using System.Configuration;
using ERPSSL.INV.DAL.Repository;

namespace ERPSSL.Procurement.BLL
{
    public class RequisionBll
    {
        RequisitionDAL aRequisitionDAL = new RequisitionDAL();
        DataAccessEX ado = new DataAccessEX();
        string conn = ConfigurationManager.ConnectionStrings["ERPSSLADO"].ConnectionString;

        public static bool AddRequisition(Hashtable ht)
        {
            try

            {
                DataAccess.InsertData(ht, "PRQ_AddRequisition");
                return true;
            }
            catch
            {
                return false;
            }
        }

        ////for HB////

        public static bool AddStoreRequisition(Hashtable ht)
        {
            try
            {
                DataAccess.InsertData(ht, "PRQ_AddStoreRequisition");
                return true;
            }
            catch
            {
                return false;
            }
        }

        
        public static bool updateStoreRequisition(Hashtable ht)
        {
            try
            {
                //ht.Add("ReqNo", ReqNo);
                DataAccess.GetDataByProc(ht, "PRQ_UpdateStoreRequisition");
                return true;
            }
            catch
            {
                return false;
            }
        }

        //purchase
        public static bool updatepurchaseRequisition(Hashtable ht)
        {
            try
            {
                //ht.Add("ReqNo", ReqNo);
                DataAccess.GetDataByProc(ht, "PRQ_updatepurchaseRequisition");
                return true;
            }
            catch
            {
                return false;
            }
        }
        //
       
        
        
 

        public static bool updateStoreRequisitions(Hashtable ht)
        {
            try
            {
                //ht.Add("ReqNo", ReqNo);
                DataAccess.GetDataByProc(ht, "PRQ_UpdateStoreRequisitionWithBarCode");
                return true;
            }
            catch
            {
                return false;
            }
        }

        //purchase
          public static bool updatePurchaseRequisitions(Hashtable ht)
        {
            try
            {
                //ht.Add("ReqNo", ReqNo);
                DataAccess.GetDataByProc(ht, "PRQ_UpdatePurchaseRequisitionWithBarCode");
                return true;
            }
            catch
            {
                return false;
            }
        }
    
        public static DataTable GetBarCode(string ReqNo,string barcode)
        {
           
                Hashtable ht=new Hashtable();

                ht.Add("ReqNo", ReqNo);
                ht.Add("BarCode", barcode);
                DataTable dt = new DataTable();
                dt= DataAccess.GetDataByProc(ht,"PRQ_GetBarCodeForCheck");
                return dt;
            
          
        }
        
        public static bool AddPurchaseRequisition(Hashtable ht)
        {
            try
            {
                DataAccess.InsertData(ht, "PRQ_AddPurchaseRequisition");
                return true;
            }
            catch
            {
                return false;
            }
        }
        public static bool PRQ_AddStoreRequisitionTemp(Hashtable ht)
        {
            try
            {
                DataAccess.InsertData(ht, "PRQ_AddStoreRequisitionTemp");
                return true;
            }
            catch
            {
                return false;
            }
        }
        public static bool AddPurchase_Requisition(Hashtable ht)
        {
            try
            {
                DataAccess.InsertData(ht, "PRQ_AddPurchase_Requisition");
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool AddStore_Requisition(Hashtable ht)
        {
            try
            {
                DataAccess.InsertData(ht, "PRQ_AddStore_Requisition");
                return true;
            }
            catch
            {
                return false;
            }
        }
        public static bool AddPurchaseRequisition_ForNewItem(Hashtable ht, string productName, string description)
        {
            try
            {
                ht.Add("ProductName", productName);
                ht.Add("Description", description);
                DataAccess.InsertData(ht, "PRQ_AddPurchaseRequisition_ForNewItem");
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool AddRequisitionJobwise(Hashtable ht)
        {
            try
            {
                DataAccess.InsertData(ht, "PRQ_AddRequisitionJobwise");
                return true;
            }
            catch
            {
                return false;
            }
        }

        ////

        public static bool UpdateQuotationStatus(Hashtable ht)
        {
            try
            {
                DataAccess.InsertData(ht, "PRQ_UpdateQoutationStatus");
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static string GetNewRequisitionNo(string type, string CompanyCode, string DPT_CODE, string EID, DateTime date)
        {
            string ReqNo = string.Empty;
            try
            {
                if (type == "CMP")
                {
                    // ReqNo = CompanyCode + date.Year + date.Month + date.Day + GetCountReqNo(CompanyCode, date, "CMP") ;
                    ReqNo = date.Year.ToString() + date.Month.ToString() + date.Day.ToString() + GetCountReqNo(CompanyCode, date, "CMP");

                }
                else if (type == "DPT")
                {
                    //ReqNo = DPT_CODE + EID + date.Year + date.Month + date.Day + GetCountReqNo(CompanyCode, date, "DPT");
                    ReqNo = date.Year.ToString() + date.Month.ToString() + date.Day.ToString() + GetCountReqNo(DPT_CODE, date, "DPT");
                }
                else if (type == "CMP-DPT")
                {
                    //ReqNo = CompanyCode + DPT_CODE + EID + date.Year + date.Month + date.Day + GetCountReqNo(CompanyCode, date, "DPT");
                    ReqNo = date.Year.ToString() + date.Month.ToString() + date.Day.ToString() + GetCountReqNo(DPT_CODE, date, "DPT");
                }
            }
            catch
            {

            }
            return ReqNo;
        }
        private static string GetCountReqNo(string Code, DateTime date, string type)
        {

            int maxid = 0;
            try
            {
                if (type == "CMP")
                {
                    //maxid = int.Parse(DataAccess.AggRetrive("select COUNT(distinct ReqNo) from PRQ_Requisitions where CompanyCode = '" + Code + "' and ReqDate = '" + date + "'").ToString());
                    maxid = int.Parse(DataAccess.AggRetrive("select COUNT(distinct ReqNo) from PRQ_Requisitions where ReqDate = '" + date + "'").ToString());
                }
                else
                {
                    //maxid = int.Parse(DataAccess.AggRetrive("select COUNT(distinct ReqNo) from PRQ_Requisitions where DPT_CODE = '" + Code + "' and ReqDate = '" + date + "'").ToString());
                    maxid = int.Parse(DataAccess.AggRetrive("select COUNT(distinct ReqNo) from PRQ_Requisitions where ReqDate = '" + date + "'").ToString());
                }
            }
            catch
            {
            }
            return (maxid + 1).ToString();
        }

        internal static DataTable GetRequisition(string ReqNo, string type)
        {
            Hashtable ht = new Hashtable();
            ht.Add("ReqNo", ReqNo);
            ht.Add("Type", type);
            DataTable dt = new DataTable();
            try
            {
                if (type == "CMP")
                {
                    dt = DataAccess.GetDataByProc(ht, "PRQ_GetRequisition");
                }
                else
                { // DPT
                    dt = DataAccess.GetDataByProc(ht, "PRQ_GetRequisition");
                }
            }
            catch { }
            return dt;
        }

        //HB//

        internal static DataTable GetStoreRequisition(string ReqNo, string type)
        {
            Hashtable ht = new Hashtable();
            ht.Add("ReqNo", ReqNo);
            ht.Add("Type", type);
            DataTable dt = new DataTable();
            try
            {
                if (type == "CMP")
                {
                    dt = DataAccess.GetDataByProc(ht, "PRQ_GetStoreRequisition");
                }
                else
                { // DPT
                    dt = DataAccess.GetDataByProc(ht, "PRQ_GetStoreRequisition");
                }
            }
            catch { }
            return dt;
        }

        internal static DataTable GetPurchaseRequisition(string ReqNo, string type)
        {
            Hashtable ht = new Hashtable();
            ht.Add("ReqNo", ReqNo);
            ht.Add("Type", type);
            DataTable dt = new DataTable();
            try
            {
                if (type == "CMP")
                {
                    dt = DataAccess.GetDataByProc(ht, "PRQ_GetPurchaseRequisition");
                }
                else
                { // DPT
                    dt = DataAccess.GetDataByProc(ht, "PRQ_GetPurchaseRequisition");
                }
            }
            catch { }
            return dt;
        }

        //shabda
        internal static DataTable GetStoreRequisitions(string ReqNo)
        {
            Hashtable ht = new Hashtable();
            ht.Add("ReqNo", ReqNo);

            DataTable dt = new DataTable();
            try
            {
                dt = DataAccess.GetDataByProc(ht, "PRQ_GetRequisitionDataForEdit");
            }
            catch { }
            return dt;
        }
        internal static DataTable GetRequisitionGrid(string ReqNo)
        {
            Hashtable ht = new Hashtable();
            ht.Add("ReqNo", ReqNo);

            DataTable dt = new DataTable();
            try
            {
                dt = DataAccess.GetDataByProc(ht, "GetRequisitionGridData");
            }
            catch { }
            return dt;
        }
        
        //.....

        internal static DataTable GetRequisitionJobwise(string ReqNo)
        {
            Hashtable ht = new Hashtable();
            ht.Add("ReqNo", ReqNo);

            DataTable dt = new DataTable();
            try
            {
                dt = DataAccess.GetDataByProc(ht, "PRQ_GetRequisitionJobwise");
            }
            catch { }
            return dt;
        }

        public static void DeleteRequisitionById(int Id)
        {
            try
            {
                DataAccess.AggRetrive("delete from PRQ_Requisitions where Id = " + Id + "");
            }
            catch
            {
            }
        }

        internal static DataTable GetRequisitionToApprove(string ReqNo, string For)
        {
            DataTable dt = new DataTable();
            try
            {
                Hashtable ht = new Hashtable();
                ht.Add("ReqNo", ReqNo);
                ht.Add("For", For);
                dt = DataAccess.GetDataByProc(ht, "PRQ_GetRequisitionByReqNo");
                //if (ReqNo == "")
                //{
                //    dt = DataAccess.GetDataBySQLString("select R.Id,R.ReqNo,P.ProductName,C.CompanyName,D.DPT_NAME,E.EMP_FIRSTNAME+' '+E.EMP_LASTNAME as EmployeeName, R.Qty, R.ReqDate from PRQ_Requisitions R inner join LU_tbl_Product P on P.Id = R.BarCode inner join Inv_Company C on C.CompanyCode = R.CompanyCode left join HRM_DEPARTMENTS D on D.DPT_CODE = R.DPT_CODE left join HRM_EMPLOYEES E on E.EID = R.EID where IsAcceptedByManager=0 and IsProOrdered=0");
                //}
                //else {
                //    dt = DataAccess.GetDataBySQLString("select R.Id,R.ReqNo,P.ProductName,C.CompanyName,D.DPT_NAME,E.EMP_FIRSTNAME+' '+E.EMP_LASTNAME as EmployeeName, R.Qty, R.ReqDate from PRQ_Requisitions R inner join LU_tbl_Product P on P.Id = R.BarCode inner join Inv_Company C on C.CompanyCode = R.CompanyCode left join HRM_DEPARTMENTS D on D.DPT_CODE = R.DPT_CODE left join HRM_EMPLOYEES E on E.EID = R.EID where IsAcceptedByManager=0 and IsProOrdered=0 and R.ReqNo = '"+ReqNo+"'");
                //}
            }
            catch
            {
            }
            return dt;
        }

        //
        internal static DataTable GetPendingStoreRequisition(string ReqNo, string For)
        {
            DataTable dt = new DataTable();
            try
            {
                Hashtable ht = new Hashtable();
                ht.Add("ReqNo", ReqNo);
                ht.Add("For", For);
                dt = DataAccess.GetDataByProc(ht, "PRQ_GetPending_StoreReqList");
                //if (ReqNo == "")
                //{
                //    dt = DataAccess.GetDataBySQLString("select R.Id,R.ReqNo,P.ProductName,C.CompanyName,D.DPT_NAME,E.EMP_FIRSTNAME+' '+E.EMP_LASTNAME as EmployeeName, R.Qty, R.ReqDate from PRQ_Requisitions R inner join LU_tbl_Product P on P.Id = R.BarCode inner join Inv_Company C on C.CompanyCode = R.CompanyCode left join HRM_DEPARTMENTS D on D.DPT_CODE = R.DPT_CODE left join HRM_EMPLOYEES E on E.EID = R.EID where IsAcceptedByManager=0 and IsProOrdered=0");
                //}
                //else {
                //    dt = DataAccess.GetDataBySQLString("select R.Id,R.ReqNo,P.ProductName,C.CompanyName,D.DPT_NAME,E.EMP_FIRSTNAME+' '+E.EMP_LASTNAME as EmployeeName, R.Qty, R.ReqDate from PRQ_Requisitions R inner join LU_tbl_Product P on P.Id = R.BarCode inner join Inv_Company C on C.CompanyCode = R.CompanyCode left join HRM_DEPARTMENTS D on D.DPT_CODE = R.DPT_CODE left join HRM_EMPLOYEES E on E.EID = R.EID where IsAcceptedByManager=0 and IsProOrdered=0 and R.ReqNo = '"+ReqNo+"'");
                //}
            }
            catch
            {
            }
            return dt;
        }

        internal static DataTable GetAll_StoreReqList(string ReqNo, string For, string EID, string fromdate, string todate)
        {
            DataTable dt = new DataTable();
            try
            {
                Hashtable ht = new Hashtable();
                ht.Add("ReqNo", ReqNo);
                ht.Add("For", For);
                ht.Add("EID",EID);
                ht.Add("FromDate", fromdate);
                ht.Add("ToDate", todate);
                dt = DataAccess.GetDataByProc(ht, "PRQ_GetAll_StoreReqList");
                //if (ReqNo == "")
                //{
                //    dt = DataAccess.GetDataBySQLString("select R.Id,R.ReqNo,P.ProductName,C.CompanyName,D.DPT_NAME,E.EMP_FIRSTNAME+' '+E.EMP_LASTNAME as EmployeeName, R.Qty, R.ReqDate from PRQ_Requisitions R inner join LU_tbl_Product P on P.Id = R.BarCode inner join Inv_Company C on C.CompanyCode = R.CompanyCode left join HRM_DEPARTMENTS D on D.DPT_CODE = R.DPT_CODE left join HRM_EMPLOYEES E on E.EID = R.EID where IsAcceptedByManager=0 and IsProOrdered=0");
                //}
                //else {
                //    dt = DataAccess.GetDataBySQLString("select R.Id,R.ReqNo,P.ProductName,C.CompanyName,D.DPT_NAME,E.EMP_FIRSTNAME+' '+E.EMP_LASTNAME as EmployeeName, R.Qty, R.ReqDate from PRQ_Requisitions R inner join LU_tbl_Product P on P.Id = R.BarCode inner join Inv_Company C on C.CompanyCode = R.CompanyCode left join HRM_DEPARTMENTS D on D.DPT_CODE = R.DPT_CODE left join HRM_EMPLOYEES E on E.EID = R.EID where IsAcceptedByManager=0 and IsProOrdered=0 and R.ReqNo = '"+ReqNo+"'");
                //}
            }
            catch
            {
            }
            return dt;
        }

        internal static DataTable GetAll_PurchaseReqList(string ReqNo, string For, string EID, string fromdate, string todate)
        {
            DataTable dt = new DataTable();
            try
            {
                Hashtable ht = new Hashtable();
                ht.Add("ReqNo", ReqNo);
                ht.Add("For", For);
                ht.Add("EID", EID);
                ht.Add("FromDate", fromdate);
                ht.Add("ToDate", todate);
                dt = DataAccess.GetDataByProc(ht, "PRQ_GetAll_PurchaseReqList");
                //if (ReqNo == "")
                //{
                //    dt = DataAccess.GetDataBySQLString("select R.Id,R.ReqNo,P.ProductName,C.CompanyName,D.DPT_NAME,E.EMP_FIRSTNAME+' '+E.EMP_LASTNAME as EmployeeName, R.Qty, R.ReqDate from PRQ_Requisitions R inner join LU_tbl_Product P on P.Id = R.BarCode inner join Inv_Company C on C.CompanyCode = R.CompanyCode left join HRM_DEPARTMENTS D on D.DPT_CODE = R.DPT_CODE left join HRM_EMPLOYEES E on E.EID = R.EID where IsAcceptedByManager=0 and IsProOrdered=0");
                //}
                //else {
                //    dt = DataAccess.GetDataBySQLString("select R.Id,R.ReqNo,P.ProductName,C.CompanyName,D.DPT_NAME,E.EMP_FIRSTNAME+' '+E.EMP_LASTNAME as EmployeeName, R.Qty, R.ReqDate from PRQ_Requisitions R inner join LU_tbl_Product P on P.Id = R.BarCode inner join Inv_Company C on C.CompanyCode = R.CompanyCode left join HRM_DEPARTMENTS D on D.DPT_CODE = R.DPT_CODE left join HRM_EMPLOYEES E on E.EID = R.EID where IsAcceptedByManager=0 and IsProOrdered=0 and R.ReqNo = '"+ReqNo+"'");
                //}
            }
            catch
            {
            }
            return dt;
        }

        internal static DataTable GetAll_PurchaseReqListByDepartment(string ReqNo, string For, string EID, string fromdate, string todate,string dept)
        {
            DataTable dt = new DataTable();
            try
            {
                Hashtable ht = new Hashtable();
                ht.Add("ReqNo", ReqNo);
                ht.Add("For", For);
                ht.Add("EID", EID);
                ht.Add("FromDate", fromdate);
                ht.Add("ToDate", todate);
                ht.Add("Dept",dept);

                dt = DataAccess.GetDataByProc(ht, "PRQ_GetAll_PurchaseReqListByDepartment");
                //if (ReqNo == "")
                //{
                //    dt = DataAccess.GetDataBySQLString("select R.Id,R.ReqNo,P.ProductName,C.CompanyName,D.DPT_NAME,E.EMP_FIRSTNAME+' '+E.EMP_LASTNAME as EmployeeName, R.Qty, R.ReqDate from PRQ_Requisitions R inner join LU_tbl_Product P on P.Id = R.BarCode inner join Inv_Company C on C.CompanyCode = R.CompanyCode left join HRM_DEPARTMENTS D on D.DPT_CODE = R.DPT_CODE left join HRM_EMPLOYEES E on E.EID = R.EID where IsAcceptedByManager=0 and IsProOrdered=0");
                //}
                //else {
                //    dt = DataAccess.GetDataBySQLString("select R.Id,R.ReqNo,P.ProductName,C.CompanyName,D.DPT_NAME,E.EMP_FIRSTNAME+' '+E.EMP_LASTNAME as EmployeeName, R.Qty, R.ReqDate from PRQ_Requisitions R inner join LU_tbl_Product P on P.Id = R.BarCode inner join Inv_Company C on C.CompanyCode = R.CompanyCode left join HRM_DEPARTMENTS D on D.DPT_CODE = R.DPT_CODE left join HRM_EMPLOYEES E on E.EID = R.EID where IsAcceptedByManager=0 and IsProOrdered=0 and R.ReqNo = '"+ReqNo+"'");
                //}
            }
            catch
            {
            }
            return dt;
        }
        internal static DataTable GetAll_StoreReqListByDepartment(string ReqNo, string For, string EID, string fromdate, string todate, string dept)
        {
            DataTable dt = new DataTable();
            try
            {
                Hashtable ht = new Hashtable();
                ht.Add("ReqNo", ReqNo);
                ht.Add("For", For);
                ht.Add("EID", EID);
                ht.Add("FromDate", fromdate);
                ht.Add("ToDate", todate);
                ht.Add("Dept",dept);

                dt = DataAccess.GetDataByProc(ht, "PRQ_GetAll_StoreReqListByDepartment");
                //if (ReqNo == "")
                //{
                //    dt = DataAccess.GetDataBySQLString("select R.Id,R.ReqNo,P.ProductName,C.CompanyName,D.DPT_NAME,E.EMP_FIRSTNAME+' '+E.EMP_LASTNAME as EmployeeName, R.Qty, R.ReqDate from PRQ_Requisitions R inner join LU_tbl_Product P on P.Id = R.BarCode inner join Inv_Company C on C.CompanyCode = R.CompanyCode left join HRM_DEPARTMENTS D on D.DPT_CODE = R.DPT_CODE left join HRM_EMPLOYEES E on E.EID = R.EID where IsAcceptedByManager=0 and IsProOrdered=0");
                //}
                //else {
                //    dt = DataAccess.GetDataBySQLString("select R.Id,R.ReqNo,P.ProductName,C.CompanyName,D.DPT_NAME,E.EMP_FIRSTNAME+' '+E.EMP_LASTNAME as EmployeeName, R.Qty, R.ReqDate from PRQ_Requisitions R inner join LU_tbl_Product P on P.Id = R.BarCode inner join Inv_Company C on C.CompanyCode = R.CompanyCode left join HRM_DEPARTMENTS D on D.DPT_CODE = R.DPT_CODE left join HRM_EMPLOYEES E on E.EID = R.EID where IsAcceptedByManager=0 and IsProOrdered=0 and R.ReqNo = '"+ReqNo+"'");
                //}
            }
            catch
            {
            }
            return dt;
        }
        
        internal static DataTable GetPendingPurchaseRequisition(string ReqNo, string For)
        {
            DataTable dt = new DataTable();
            try
            {
                Hashtable ht = new Hashtable();
                ht.Add("ReqNo", ReqNo);
                ht.Add("For", For);
                dt = DataAccess.GetDataByProc(ht, "PRQ_GetPending_PurchaseReqList");
                //if (ReqNo == "")
                //{
                //    dt = DataAccess.GetDataBySQLString("select R.Id,R.ReqNo,P.ProductName,C.CompanyName,D.DPT_NAME,E.EMP_FIRSTNAME+' '+E.EMP_LASTNAME as EmployeeName, R.Qty, R.ReqDate from PRQ_Requisitions R inner join LU_tbl_Product P on P.Id = R.BarCode inner join Inv_Company C on C.CompanyCode = R.CompanyCode left join HRM_DEPARTMENTS D on D.DPT_CODE = R.DPT_CODE left join HRM_EMPLOYEES E on E.EID = R.EID where IsAcceptedByManager=0 and IsProOrdered=0");
                //}
                //else {
                //    dt = DataAccess.GetDataBySQLString("select R.Id,R.ReqNo,P.ProductName,C.CompanyName,D.DPT_NAME,E.EMP_FIRSTNAME+' '+E.EMP_LASTNAME as EmployeeName, R.Qty, R.ReqDate from PRQ_Requisitions R inner join LU_tbl_Product P on P.Id = R.BarCode inner join Inv_Company C on C.CompanyCode = R.CompanyCode left join HRM_DEPARTMENTS D on D.DPT_CODE = R.DPT_CODE left join HRM_EMPLOYEES E on E.EID = R.EID where IsAcceptedByManager=0 and IsProOrdered=0 and R.ReqNo = '"+ReqNo+"'");
                //}
            }
            catch
            {
            }
            return dt;
        }
        internal static DataTable GetPendingPurchaseRequisitionByDateToDate(string ReqNo, string For,string FromDate,string ToDate)
        {
            DataTable dt = new DataTable();
            try
            {
                Hashtable ht = new Hashtable();
                ht.Add("ReqNo", ReqNo);
                ht.Add("For", For);
                ht.Add("FromDate", FromDate);
                ht.Add("ToDate", ToDate);
                dt = DataAccess.GetDataByProc(ht, "PRQ_GetPending_PurchaseReqList");
                //if (ReqNo == "")
                //{
                //    dt = DataAccess.GetDataBySQLString("select R.Id,R.ReqNo,P.ProductName,C.CompanyName,D.DPT_NAME,E.EMP_FIRSTNAME+' '+E.EMP_LASTNAME as EmployeeName, R.Qty, R.ReqDate from PRQ_Requisitions R inner join LU_tbl_Product P on P.Id = R.BarCode inner join Inv_Company C on C.CompanyCode = R.CompanyCode left join HRM_DEPARTMENTS D on D.DPT_CODE = R.DPT_CODE left join HRM_EMPLOYEES E on E.EID = R.EID where IsAcceptedByManager=0 and IsProOrdered=0");
                //}
                //else {
                //    dt = DataAccess.GetDataBySQLString("select R.Id,R.ReqNo,P.ProductName,C.CompanyName,D.DPT_NAME,E.EMP_FIRSTNAME+' '+E.EMP_LASTNAME as EmployeeName, R.Qty, R.ReqDate from PRQ_Requisitions R inner join LU_tbl_Product P on P.Id = R.BarCode inner join Inv_Company C on C.CompanyCode = R.CompanyCode left join HRM_DEPARTMENTS D on D.DPT_CODE = R.DPT_CODE left join HRM_EMPLOYEES E on E.EID = R.EID where IsAcceptedByManager=0 and IsProOrdered=0 and R.ReqNo = '"+ReqNo+"'");
                //}
            }
            catch
            {
            }
            return dt;
        }

        //Admin.............(16-06-2015)
        internal static DataTable GetPendingPurchaseRequisitionForAdmin(string ReqNo, string For,string DPT_CODE,string Status,string FromDate,string ToDate)
        {
            DataTable dt = new DataTable();
            try
            {
                Hashtable ht = new Hashtable();
                ht.Add("ReqNo", ReqNo);
                ht.Add("For", For);
                ht.Add("DPT_CODE", DPT_CODE);
                ht.Add("Status", Status);
                ht.Add("FromDate", FromDate);
                ht.Add("ToDate", ToDate);
                dt = DataAccess.GetDataByProc(ht, "PRQ_GetPending_PurchaseReqListByDpt_Status");
         
            }
            catch
            {
            }
            return dt;
        }
           internal static DataTable GetPendingPurchaseRequisitionForAdminApprove(string ReqNo, string For,string DPT_CODE,string Status,string FromDate,string ToDate)
        {
            DataTable dt = new DataTable();
            try
            {
                Hashtable ht = new Hashtable();
                ht.Add("ReqNo", ReqNo);
                ht.Add("For", For);
                ht.Add("DPT_CODE", DPT_CODE);
                ht.Add("Status", Status);
                ht.Add("FromDate", FromDate);
                ht.Add("ToDate", ToDate);
                dt = DataAccess.GetDataByProc(ht, "PRQ_GetPending_PurchaseReqListByDpt_StatusApprove");
         
            }
            catch
            {
            }
            return dt;
        }

           //18-06-2015 GetPendingListForManager

           internal static DataTable GetPendingListForManager( string For, string Status)
           {
               DataTable dt = new DataTable();
               try
               {
                   Hashtable ht = new Hashtable();      
                   ht.Add("For", For);
                   ht.Add("Status", Status);

                   dt = DataAccess.GetDataByProc(ht, "PRQ_GetPending_PurchaseReqListBy_Pending");

               }
               catch
               {
               }
               return dt;
           }
           internal static DataTable GetPendingListForManagement(string For, string Status)
           {
               DataTable dt = new DataTable();
               try
               {
                   Hashtable ht = new Hashtable();
                   ht.Add("For", For);
                   ht.Add("Status", Status);

                   dt = DataAccess.GetDataByProc(ht, "PRQ_GetPending_PurchaseReqListBy_Pending_Management");

               }
               catch
               {
               }
               return dt;
           }
           internal static DataTable GetAllRequisitionByDepartment(string For, string Dpt_Code)
           {
               DataTable dt = new DataTable();
               try
               {
                   Hashtable ht = new Hashtable();
                   ht.Add("For", For);
                   ht.Add("DPT_CODE", Dpt_Code);

                   dt = DataAccess.GetDataByProc(ht, "PRQ_GetPending_PurchaseReqListByDpt_StatusByDPTForDrop_Management");

               }
               catch
               {
               }
               return dt;
           }
           //
                internal static DataTable GetPendingPurchaseRequisitionForAdminAllStatus(string ReqNo, string For,string DPT_CODE,string Status,string FromDate,string ToDate)
        {
            DataTable dt = new DataTable();
            try
            {
                Hashtable ht = new Hashtable();
                ht.Add("ReqNo", ReqNo);
                ht.Add("For", For);
                ht.Add("DPT_CODE", DPT_CODE);
                ht.Add("Status", Status);
                ht.Add("FromDate", FromDate);
                ht.Add("ToDate", ToDate);
                dt = DataAccess.GetDataByProc(ht, "PRQ_GetPending_PurchaseReqListByDpt_OtherStatus");
         
            }
            catch
            {
            }
            return dt;
        }
        

        internal static DataTable GetPendingPurchaseRequisitionForAdminByDPT(string ReqNo, string For, string DPT_CODE, string FromDate, string ToDate)
        {
            DataTable dt = new DataTable();
            try
            {
                Hashtable ht = new Hashtable();
                ht.Add("ReqNo", ReqNo);
                ht.Add("For", For);
                ht.Add("DPT_CODE", DPT_CODE);
           
                ht.Add("FromDate", FromDate);
                ht.Add("ToDate", ToDate);
                dt = DataAccess.GetDataByProc(ht, "PRQ_GetPending_PurchaseReqListByDpt_StatusByDPT");

            }
            catch
            {
            }
            return dt;
        }

        internal static DataTable GetPendingPurchaseRequisitionForAdminByDPTCasceding(string For, string DPT_CODE)
        {
            DataTable dt = new DataTable();
            try
            {
                Hashtable ht = new Hashtable();
                //ht.Add("ReqNo", ReqNo);
                ht.Add("For", For);
                ht.Add("DPT_CODE", DPT_CODE);
                dt = DataAccess.GetDataByProc(ht, "PRQ_GetPending_PurchaseReqListByDpt_StatusByDPTForDropDown");

            }
            catch
            {
            }
            return dt;
        }
        //..................

        internal static DataTable GetRequisitionJobwiseToApprove(string ReqNo, string For)
        {
            DataTable dt = new DataTable();
            try
            {
                Hashtable ht = new Hashtable();
                ht.Add("ReqNo", ReqNo);
                ht.Add("For", For);
                dt = DataAccess.GetDataByProc(ht, "PRQ_GetRequisition_JobwiseByReqNo");
                //if (ReqNo == "")
                //{
                //    dt = DataAccess.GetDataBySQLString("select R.Id,R.ReqNo,P.ProductName,C.CompanyName,D.DPT_NAME,E.EMP_FIRSTNAME+' '+E.EMP_LASTNAME as EmployeeName, R.Qty, R.ReqDate from PRQ_Requisitions R inner join LU_tbl_Product P on P.Id = R.BarCode inner join Inv_Company C on C.CompanyCode = R.CompanyCode left join HRM_DEPARTMENTS D on D.DPT_CODE = R.DPT_CODE left join HRM_EMPLOYEES E on E.EID = R.EID where IsAcceptedByManager=0 and IsProOrdered=0");
                //}
                //else {
                //    dt = DataAccess.GetDataBySQLString("select R.Id,R.ReqNo,P.ProductName,C.CompanyName,D.DPT_NAME,E.EMP_FIRSTNAME+' '+E.EMP_LASTNAME as EmployeeName, R.Qty, R.ReqDate from PRQ_Requisitions R inner join LU_tbl_Product P on P.Id = R.BarCode inner join Inv_Company C on C.CompanyCode = R.CompanyCode left join HRM_DEPARTMENTS D on D.DPT_CODE = R.DPT_CODE left join HRM_EMPLOYEES E on E.EID = R.EID where IsAcceptedByManager=0 and IsProOrdered=0 and R.ReqNo = '"+ReqNo+"'");
                //}
            }
            catch
            {
            }
            return dt;
        }

        internal static DataTable GetUniqueRequisitionsToApprove(string For)
        {
            DataTable dt = new DataTable();
            try
            {
                if (For == "Manager")
                {
                    dt = DataAccess.GetDataBySQLString("select distinct R.ReqNo,R.ReqDate from PRQ_Requisitions R left join LU_tbl_Product P on P.Id = R.BarCode where IsAcceptedByManager=0 and IsProOrdered=0");
                }
                else
                {

                    dt = DataAccess.GetDataBySQLString("select distinct R.ReqNo,R.ReqDate from PRQ_Requisitions R left join LU_tbl_Product P on P.Id = R.BarCode where IsAcceptedByHead=0 and IsAcceptedByManager=1 and IsProOrdered=0");
                }
            }
            catch
            {
            }
            return dt;
        }

        internal static bool Approve(int Id, int ApproveQty, string ApprovedBy)
        {
            try
            {
                if (ApprovedBy == "Manager")
                {
                    DataAccess.AggRetrive("update PRQ_Requisitions set IsAcceptedByManager = 1, ManagerApproveQty = " + ApproveQty + " where Id = " + Id + "");
                }
                else if (ApprovedBy == "Head")
                {
                    DataAccess.AggRetrive("update PRQ_Requisitions set IsAcceptedByHead = 1, HeadApproveQty = " + ApproveQty + " where Id = " + Id + "");
                }
                return true;
            }
            catch
            {
                return false;
            }

        }
        ////For HB////
        internal static bool StoreReqApproval(int Id, int ApproveQty, string remarks, string ApprovedBy)
        {
            try
            {
                if (ApprovedBy == "Manager")
                {
                    DataAccess.AggRetrive("update PRQ_Requisitions set IsAcceptedByManager = 1, ManagerApproveQty = " + ApproveQty + ", Remarks = '" + remarks + "' where Id = " + Id + "");
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        internal int StoreReqApprovalBySupervisor(List<PRQ_Requisitions> lstPRQ_Requisitions)
        {
            return aRequisitionDAL.StoreReqApprovalBySupervisor(lstPRQ_Requisitions);
        }

        internal int PurchaseReqApprovalBySupervisor2(List<PRQ_Requisitions> lstPRQ_Requisitions)
        {
            return aRequisitionDAL.PurchaseReqApprovalBySupervisor2(lstPRQ_Requisitions);
        }

        internal int StoreReqApprovalByAdmin(List<PRQ_Requisitions> lstPRQ_Requisitions)
        {
            return aRequisitionDAL.StoreReqApprovalByAdmin(lstPRQ_Requisitions);
        }

        internal int PurchaseReqApprovalByAdmin(List<PRQ_Requisitions> lstPRQ_Requisitions)
        {
            return aRequisitionDAL.PurchaseReqApprovalByAdmin(lstPRQ_Requisitions);
        }

        internal int PurchaseReqApprovalByManagement(List<PRQ_Requisitions> lstPRQ_Requisitions)
        {
            return aRequisitionDAL.PurchaseReqApprovalByManagement(lstPRQ_Requisitions);
        }

        //download
  
        //

        internal static bool StoreReqApproval(string ReqNo, int ApproveQty, string ApprovedBy)
        {
            try
            {
                if (ApprovedBy == "Manager")
                {
                    DataAccess.AggRetrive("update PRQ_Requisitions set IsAcceptedByManager = 1, ManagerApproveQty = " + ApproveQty + " where ReqNo = " + ReqNo + "");
                }
                return true;
            }
            catch
            {
                return false;
            }

        }

        internal static bool ApproveReqJobwise(int Id, int ApproveQty, string ApprovedBy)
        {
            try
            {
                if (ApprovedBy == "Manager")
                {
                    DataAccess.AggRetrive("update CS_JobwiseRequisition set IsAcceptedByManager = 1, ManagerApproveQty = " + ApproveQty + " where Id = " + Id + "");
                }
                else if (ApprovedBy == "Head")
                {
                    DataAccess.AggRetrive("update CS_JobwiseRequisition set IsAcceptedByHead = 1, HeadApproveQty = " + ApproveQty + " where Id = " + Id + "");
                }
                return true;
            }
            catch
            {
                return false;
            }

        }

        ////

        internal static bool ApproveAll(string ReqNo, string ApprovedBy)
        {
            try
            {
                if (ApprovedBy == "Manager")
                {
                    DataAccess.AggRetrive("update PRQ_Requisitions set IsAcceptedByManager = 1,ManagerApproveQty = Qty where ReqNo = '" + ReqNo + "' and IsAcceptedByManager=0");
                }
                else if (ApprovedBy == "Head")
                {
                    DataAccess.AggRetrive("update PRQ_Requisitions set IsAcceptedByHead = 1,HeadApproveQty = ManagerApproveQty where ReqNo = '" + ReqNo + "' and IsAcceptedByHead=0 and IsAcceptedByManager = 1");
                }
                return true;
            }
            catch
            {
                return false;
            }

        }


        internal static DataTable GetAllAcceptedRequisitions(string ReqNo)
        {
            DataTable dt = new DataTable();
            Hashtable ht = new Hashtable();
            ht.Add("ReqNo", ReqNo);
            try
            {
                dt = DataAccess.GetDataByProc(ht, "PRQ_GetAllAcceptedRequisitions");
                //if (ReqNo == "")
                //{
                //    dt = DataAccess.GetDataBySQLString("select R.Id,R.ReqNo,P.ProductName,C.CompanyName,D.DPT_NAME,E.EMP_FIRSTNAME+' '+E.EMP_LASTNAME as EmployeeName, R.Qty, R.ReqDate from PRQ_Requisitions R inner join LU_tbl_Product P on P.Id = R.BarCode inner join Inv_Company C on C.CompanyCode = R.CompanyCode left join HRM_DEPARTMENTS D on D.DPT_CODE = R.DPT_CODE left join HRM_EMPLOYEES E on E.EID = R.EID where IsAcceptedByManager=0 and IsProOrdered=0");
                //}
                //else {
                //    dt = DataAccess.GetDataBySQLString("select R.Id,R.ReqNo,P.ProductName,C.CompanyName,D.DPT_NAME,E.EMP_FIRSTNAME+' '+E.EMP_LASTNAME as EmployeeName, R.Qty, R.ReqDate from PRQ_Requisitions R inner join LU_tbl_Product P on P.Id = R.BarCode inner join Inv_Company C on C.CompanyCode = R.CompanyCode left join HRM_DEPARTMENTS D on D.DPT_CODE = R.DPT_CODE left join HRM_EMPLOYEES E on E.EID = R.EID where IsAcceptedByManager=0 and IsProOrdered=0 and R.ReqNo = '"+ReqNo+"'");
                //}
            }
            catch
            {
            }
            return dt;
        }

        internal static DataTable GetSelectedProductToDeliver(string Id)
        {
            DataTable dt = new DataTable();
            Hashtable ht = new Hashtable();
            ht.Add("Id", Id);
            try
            {
                dt = DataAccess.GetDataByProc(ht, "PRQ_GetSelectedProductToDeliver");
            }
            catch { }
            return dt;
        }

        internal static DataTable GetUniqueRequisitionsToDeliver()
        {
            DataTable dt = new DataTable();
            try
            {
                //dt = DataAccess.GetDataBySQLString("select * from PRQ_Requisitions where IsAcceptedByHead = 1 and IsDelivered = 0");
                dt = DataAccess.GetDataBySQLString("select distinct ReqNo from PRQ_Requisitions where IsAcceptedByHead = 1 and IsDelivered = 0");
            }
            catch { }
            return dt;
        }

        internal static DataTable GetProductListByGroup(int p)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = DataAccess.GetDataBySQLString("select Id, ProductName from LU_tbl_Product where GroupId = " + p + "");
            }
            catch
            {
            }
            return dt;
        }
        internal static DataTable GetStoreRequisition(Guid userId, string EID, string type)
        {
            Hashtable ht = new Hashtable();
            ht.Add("EID", EID);
            ht.Add("Type", type);
            ht.Add("userId", userId);
            DataTable dt = new DataTable();
            try
            {
                if (type == "CMP")
                {
                    dt = DataAccess.GetDataByProc(ht, "PRQ_GetStoreRequisition");
                }
                else
                { // DPT
                    dt = DataAccess.GetDataByProc(ht, "PRQ_GetStoreRequisition");
                }
            }
            catch { }
            return dt;
        }
        internal static DataTable Get_Store_Requisition(string ReqNo, string type)
        {
            Hashtable ht = new Hashtable();
            ht.Add("ReqNo", ReqNo);
            ht.Add("Type", type);
            DataTable dt = new DataTable();
            try
            {
                if (type == "CMP")
                {
                    dt = DataAccess.GetDataByProc(ht, "PRQ_GetStore_Requisition");
                }
                else
                { // DPT
                    dt = DataAccess.GetDataByProc(ht, "PRQ_GetStore_Requisition");
                }
            }
            catch { }
            return dt;
        }

        public int UpdateSupervisor(PRQ_Requisitions aPRQ_Requisitions, string eId)
        {
            return aRequisitionDAL.UpdateSupervisor(aPRQ_Requisitions, eId);
        }

        internal List<PRQ_Requisitions> GetRequisitionInfo(string eID)
        {
            return aRequisitionDAL.GetRequisitionInfo(eID);
        }

        //internal int AddPurchaseRequisition_ForNewItem(string productName, string description)
        //{
        //    return aRequisitionDAL.AddPurchaseRequisition_ForNewItem(productName, description);
        //}
        public PRQ_Requisition_Temp GetReq_temp_ItemByProductInfo(string EID, int barcode, Guid userId)
        {
            PRQ_Requisition_Temp req = aRequisitionDAL.GetReq_temp_ItemByProductInfo(EID, barcode, userId);
            return req;
        }
        internal int AddTempToStoreReq(string ReqNo)
        {
            return aRequisitionDAL.AddTempToStoreReq(ReqNo);
        }

        internal List<GINStoreReqR> tGetAll_DistinctApprovedStoreReq()
        {

            return aRequisitionDAL.GetAll_DistinctApprovedStoreReq();
        }

        internal List<DeleveryProductR> PRQ_GetSelectedProductToDeliverByReqNo(string reqno, string Ocode)
        {
            return aRequisitionDAL.PRQ_GetSelectedProductToDeliverByReqNo(reqno, Ocode);
        }

    }
}
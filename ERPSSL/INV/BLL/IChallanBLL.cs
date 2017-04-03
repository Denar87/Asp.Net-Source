using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ERPSSL.INV.DAL;
using System.Data;
using System.Configuration;
using System.Collections;
using ERPSSL.HRM.DAL;
using ERPSSL.Procurement.DAL;
using ERPSSL.INV.DAL.Repository;
using System.Data.SqlClient;

namespace ERPSSL.INV.BLL
{
    public class IChallanBLL
    {
        private ERPSSLHBEntities _context = new ERPSSLHBEntities();
        private ERPSSL_INVEntities _Invcontext = new ERPSSL_INVEntities();
        DataAccessEX ado = new DataAccessEX();
        string conn = ConfigurationManager.ConnectionStrings["ERPSSLADO"].ConnectionString;

        IChallanDAL iChallanDal = new IChallanDAL();

        public bool UpdateRequisition(string ReqNo, string BarCode, int Qtu)
        {
            try
            {
                ado.AggRetrive("update PRQ_Requisitions set IsDelivered = 1, PartialDeliveryQty = " + Qtu + " where BarCode = " + BarCode + " and ReqNo = '" + ReqNo + "'", conn).ToString();
                return true;
            }
            catch
            {
                return false;
            }
        }

        internal DataTable GetDepartmentList()
        {
            DataTable dt = new DataTable();
            try
            {
                dt = ado.GetDataBySQLString("select DPT_CODE, DPT_NAME from HRM_DEPARTMENTS order by DPT_NAME", conn);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        //18-06-2015
        internal DataTable GetDepartmentListByReqNo()
        {
            DataTable dt = new DataTable();
            try
            {
                dt = ado.GetDataBySQLString("SELECT DISTINCT (r.DPT_CODE),D.DPT_NAME FROM [dbo].[PRQ_Requisitions] r inner join [dbo].[HRM_DEPARTMENTS] D on r.DPT_CODE=D.DPT_CODE", conn);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        //...

        internal DataTable GetToDepartmentList()
        {
            DataTable dt = new DataTable();
            try
            {
                dt = ado.GetDataBySQLString("select DPT_CODE, DPT_NAME from Inv_DepartmentType where DepartmentType='Store'", conn);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public DataTable GetProductListByStore(int GroupId, string cmpCode)
        {

            DataTable dt = new DataTable();
            try
            {
                //string CType = ado.AggRetrive("select CompanyType from Inv_Company where CompanyCode = '" + cmpCode + "'", conn).ToString();
                //if (CType == "CENTRAL")
                //{
                dt = ado.GetDataBySQLString("select BarCode, (ProductName +' - ' +isnull(Brand,'') +' - '+isnull(StyleSize,'')) as ProductName from Inv_BuyCentral where ProductGroup = " + GroupId + " and Store_Code ='" + cmpCode + "' group by ProductName,BarCode,Brand,StyleSize", conn);
                //}
                //else
                //{
                //    dt = ado.GetDataBySQLString("select BarCode, ProductName from Inv_Buy where ProductGroup = " + GroupId + " and CompanyCode='" + cmpCode + "'", conn);
                //}
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        internal string GetNewReturnChalanNo(string code, DateTime day, string type)
        {
            int count;
            string challanNo = code + day.Year + day.Month + day.Day;

            try
            {
                if (type == "DPT")
                {
                    count = int.Parse(ado.AggRetrive("select count(Id) from Inv_Return where ReturnDate ='" + day + "' and DPT_CODE = '" + code + "'", conn).ToString());
                    challanNo += (count + 1).ToString();//.PadLeft(2,'0');
                }
                else if (type == "CMP")
                {
                    count = int.Parse(ado.AggRetrive("select count(Id) from Inv_Return where ReturnDate ='" + day + "' and CurrentCompanyCode = '" + code + "'", conn).ToString());
                    challanNo += (count + 1).ToString();//.PadLeft(4, '0');
                }
                else if (type == "SUP")
                {
                    count = int.Parse(ado.AggRetrive("select COUNT(*) from Inv_Return where ReturnDate = '" + day + "' and SupplierCode = '" + code + "'", conn).ToString());
                    challanNo += (count + 1).ToString();//.PadLeft(4, '0');
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return challanNo;
        }

        internal DataTable GetProductListToReturnFromDept(int groupId, string deptCode, string EID)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = ado.GetDataBySQLString("select distinct i.BarCode, (p.ProductName +' - '+isnull(p.Brand,'') +' - '+ isnull(p.StyleAndSize,'')) as ProductName from Inv_IChallan i inner join Inv_Product p on p.ProductId=i.BarCode inner join Inv_ProductGroup g on g.GroupId=p.GroupId where EID = '" + EID + "' and DPT_CODE = '" + deptCode + "' and ProductGroup = '" + groupId + "' order by ProductName", conn);
            }
            catch
            {
            }
            return dt;
        }


        internal int GetEmployeeStock(string EID, string barCode)
        {
            int stock = 0;
            try
            {
                stock = int.Parse(ado.AggRetrive("select SUM(DeliveryQty) from Inv_IChallan where EID ='" + EID + "'", conn).ToString());
                stock = stock - int.Parse(ado.AggRetrive("select SUM(ERetQty) from Inv_Return where EID ='" + EID + "'", conn).ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return stock;
        }

        internal DataTable GetProductInforByBarCode(string BarCode, string cmpCode)
        {
            DataTable dt = new DataTable();
            if (cmpCode != string.Empty)
            {
                try
                {
                    //string CType = ado.AggRetrive("select CompanyType from Inv_Company where CompanyCode = '" + cmpCode + "'", conn).ToString();
                    //if (CType == "CENTRAL")
                    //{
                    dt = ado.GetDataBySQLString("select * from Inv_BuyCentral where BarCode = " + BarCode + " and CompanyCode ='" + cmpCode + "' order by ProductName", conn);
                    //}
                    //else
                    //{
                    //    dt = ado.GetDataBySQLString("select * from Inv_Buy where BarCode = " + BarCode + " and CompanyCode ='" + cmpCode + "'", conn);
                    //}
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return dt;
        }

        internal DataTable GetCompanyList()
        {
            DataTable dt = new DataTable();
            try
            {
                dt = ado.GetDataBySQLString("select * from Inv_Company order by CompanyName", conn);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        internal object GetCentralCompanyList()
        {
            DataTable dt = new DataTable();
            try
            {
                dt = ado.GetDataBySQLString("select * from Inv_Company where CompanyType ='CENTRAL'", conn);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        internal DataTable GetAllProductList()
        {
            DataTable dt = new DataTable();
            try
            {
                dt = ado.GetDataBySQLString("select * from Inv_Product ", conn);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        internal DataTable ReturnProduct(Hashtable ht)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = ado.GetDataByProc(ht, "INV_ProductReturn", conn);
            }
            catch { }
            return dt;
        }

        internal DataTable GetProductInforByBarCode(string barCode, string cmpCode, string p)
        {
            DataTable dt = new DataTable();
            if (cmpCode != string.Empty)
            {
                try
                {
                    if (p == "CENTRAL")
                    {
                        dt = ado.GetDataBySQLString("select * from Inv_BuyCentral where BarCode = '" + barCode + "'", conn);
                    }
                }
                catch { }
            }
            return dt;
        }

        internal DataTable GetProductListToReturn(int p, string cmpCode, string supTo)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = ado.GetDataBySQLString("select distinct BarCode,(ProductName +' - ' + Brand +' - '+ StyleSize) as ProductName  from Inv_RChallan where CompanyCode = '" + cmpCode + "' and ProductGroup = " + p + " and SupplierCode = '" + supTo + "'", conn);
            }
            catch
            {
            }

            return dt;
        }

        internal DataTable GetSupplierListToReturn(string cmpCode)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = ado.GetDataBySQLString("select distinct S.SupplierCode, S.SupplierName from Inv_RChallan R inner Join Inv_Supplier S on R.SupplierCode = S.SupplierCode where R.CompanyCode = '" + cmpCode + "'", conn);
            }
            catch
            {
            }
            return dt;
        }


        internal DataTable GetEmployeeList(string DeptCode)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = ado.GetDataBySQLString("select EID,isnull(FirstName,'')+' '+ isnull(LastName,'')+'- '+ EID as EMP_NAME from HRM_PersonalInformations as E inner join HRM_DEPARTMENTS as D on D.DPT_ID = E.DepartmentId where D.DPT_CODE = '" + DeptCode + "'", conn);
            }
            catch
            {
            }

            return dt;
        }

        internal DataTable GetEmployeeListByDept(string DeptCode)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = ado.GetDataBySQLString("select EID,isnull(FirstName,'')+' '+ isnull(LastName,'')+'-'+ EID as EMP_NAME from HRM_PersonalInformations as E inner join HRM_DEPARTMENTS as D on D.DPT_ID = E.DepartmentId where D.DPT_CODE = '" + DeptCode + "'", conn);
            }
            catch
            {
            }

            return dt;
        }


        internal DataTable GetEmployeeList()
        {
            DataTable dt = new DataTable();
            try
            {
                dt = ado.GetDataBySQLString("select EID,FirstName+' '+ LastName as EMP_NAME from HRM_PersonalInformations as E inner join HRM_DEPARTMENTS as D on D.DPT_ID = E.DepartmentId", conn);
            }
            catch
            {
            }

            return dt;
        }

        internal DataTable GetAllEmployeeList()
        {
            DataTable dt = new DataTable();
            try
            {
                dt = ado.GetDataBySQLString("select EID,FirstName+' '+ LastName+'-'+EID as EMP_NAME from HRM_PersonalInformations as E inner join HRM_DEPARTMENTS as D on D.DPT_ID = E.DepartmentId", conn);
            }
            catch
            {
            }

            return dt;
        }

        internal DataTable GetEmployeeDesignation(string EID)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = ado.GetDataBySQLString("select D.DEG_NAME, P.ReportingBossId from HRM_PersonalInformations as P inner join HRM_DESIGNATIONS as D on P.DesginationId=D.DEG_ID where P.EID = '" + EID + "'", conn);
            }
            catch
            {

            }
            return dt;
        }


        public DataTable GetProductListByGroup(string GroupId)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = ado.GetDataBySQLString("select BarCode, (ProductName +' - ' + Brand+' - '+StyleSize) as ProductName from Inv_BuyCentral where ProductGroup = " + GroupId + "", conn);
            }
            catch
            {
            }
            return dt;
        }

        public DataTable GetProductListWithCodeByGroup(string GroupId)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = ado.GetDataBySQLString("select BarCode, (ProductName +' - ' + Brand+' - '+StyleSize+' - '+BarCode) as ProductName from Inv_BuyCentral where ProductGroup = " + GroupId + "", conn);
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public DataTable GetProductListWithCodeByGroupFromOtherStore(string GroupId)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = ado.GetDataBySQLString("select distinct (ProductName +' - ' + Brand+' - '+StyleSize+' - '+BarCode) as ProductName, BarCode from Inv_Buy where ProductGroup = " + GroupId + "", conn);
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable GetProductListByGroup_FromStore(string GroupId, string ProjectCode, int StoreID, int StoreUnitID)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = ado.GetDataBySQLString("select BarCode, (ProductName +' - ' + Brand+' - '+StyleSize) as ProductName from Inv_BuyCentral where ProductGroup = " + GroupId + " and Project_Code=" + ProjectCode + " and Store_Id=" + StoreID + " and Store_Unit_Id =" + StoreUnitID + "  ", conn);
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        //public DataTable GetProductListByGroup(int GroupId, string cmpCode)
        //{
        //    DataTable dt = new DataTable();
        //    try
        //    {
        //        string CType = ado.AggRetrive("select CompanyType from Inv_Company where CompanyCode = '" + cmpCode + "'", conn).ToString();
        //        if (CType == "CENTRAL")
        //        {
        //            // thyrocare
        //            dt = ado.GetDataBySQLString("select ProductId, ProductName from Inv_Product where GroupId = " + GroupId + "", conn);
        //        }
        //        else
        //        {
        //            dt = ado.GetDataBySQLString("select BarCode, ProductName from Inv_Buy where ProductGroup = " + GroupId + " and CompanyCode='" + cmpCode + "'", conn);
        //        }
        //    }
        //    catch
        //    {
        //    }
        //    return dt;
        //}

        public DataTable GetProductListByGroup(int GroupId, string cmpCode)
        {

            DataTable dt = new DataTable();
            try
            {
                //string CType = ado.AggRetrive("select CompanyType from Inv_Company where CompanyCode = '" + cmpCode + "'", conn).ToString();
                //if (CType == "CENTRAL")
                //{
                dt = ado.GetDataBySQLString("select BarCode, (ProductName +' - ' + Brand+' - '+StyleSize) as ProductName from Inv_BuyCentral where ProductGroup = " + GroupId + " and CompanyCode='" + cmpCode + "'", conn);
                //}
                //else
                //{
                //    dt = ado.GetDataBySQLString("select BarCode, ProductName from Inv_Buy where ProductGroup = " + GroupId + " and CompanyCode='" + cmpCode + "'", conn);
                //}
            }
            catch
            {
            }
            return dt;
        }

        internal DataTable GetListGroup()
        {
            DataTable dt = new DataTable();
            try
            {
                dt = ado.GetDataBySQLString("select GroupId, GroupName from Inv_ProductGroup order by GroupName", conn);
            }
            catch
            {

            }
            return dt;
        }

        public string GetNewChalanNoForCenterToDpt(string code)
        {
            int count;
            string challanNo = "CD-" + code;

            try
            {
                count = int.Parse(ado.AggRetrive("select count(Id) from Inv_IChallan where DPT_CODE = '" + code + "'", conn).ToString());
                challanNo += (count + 1).ToString();//.PadLeft(2,'0');
            }
            catch { }

            return challanNo;
        }
        public string GetNewChalanNoForCenterToStore(string code)
        {
            int count;
            string challanNo = "CS-" + code;

            try
            {
                count = int.Parse(ado.AggRetrive("select count(Id) from Inv_IChallan where DPT_CODE = '" + code + "'", conn).ToString());
                challanNo += (count + 1).ToString();//.PadLeft(2,'0');
            }
            catch { }

            return challanNo;
        }

        public string GetNewChalanNoForGeneralStoreToDpt(string eidL)
        {
            try
            {
                DateTime Today = DateTime.Today;
                var GYear = DateTime.Now.Year;
                //var Month = DateTime.Now.Month;
                //var Day = DateTime.Now.Day;
                //var min = DateTime.Now.Minute;
                //var Sec = DateTime.Now.Second;
                //int count = 0;
                string challanNo = null;
                challanNo = "SC-" + GYear + GetCountTRNo(Today);
                //challanNo += (count + 1).ToString();
                return challanNo;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private string GetCountTRNo(DateTime Today)
        {
            try
            {
                int maxid = 0;
                maxid = Int32.Parse(ado.AggRetrive("select COUNT(distinct ChallanNo) from Inv_IChallan where DeliveryDate = '" + Today + "'", conn).ToString());
                return (maxid + 1).ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string GetNewChalanNoForStoreToStore(string OCODE)
        {
            //try
            //{
            //    var Day = DateTime.Now.Day;
            //    var min = DateTime.Now.Minute;
            //    var Sec = DateTime.Now.Second;
            //    int count = 0;
            //    string challanNo = null;
            //    challanNo = "TR-" + Day + "" + min + "" + Sec + "" + Ccode;
            //    challanNo += (count + 1).ToString();
            //    return challanNo;
            //}
            //catch (Exception ex)
            //{
            //    throw ex;
            //}

            #region Old Code here

            int count;
            var GYear = DateTime.Now.Year;

            string challanNo = "SS-" + GYear;
            try
            {
                count = int.Parse(ado.AggRetrive("select count(Id) from Inv_IChallan where OCode = '" + OCODE + "'", conn).ToString());
                challanNo += (count + 1).ToString();//.PadLeft(2,'0');
                return challanNo;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            #endregion
        }

        public string GetNewChalanNo(string code, DateTime day, string toType)
        {
            int count;
            string challanNo = code + day.Year + day.Month + day.Day;

            try
            {
                if (toType == "DPT")
                {
                    count = int.Parse(ado.AggRetrive("select count(Id) from Inv_IChallan where DeliveryDate ='" + day + "' and DPT_CODE = '" + code + "'", conn).ToString());
                    challanNo += (count + 1).ToString();//.PadLeft(2,'0');
                }
                else if (toType == "CMP")
                {
                    count = int.Parse(ado.AggRetrive("select count(Id) from Inv_IChallan where DeliveryDate ='" + day + "' and CurrentCompanyCode = '" + code + "'", conn).ToString());
                    challanNo += (count + 1).ToString();//.PadLeft(4, '0');
                }
                else if (toType == "SUP")
                {
                    count = int.Parse(ado.AggRetrive("select COUNT(*) from Inv_RChallan where ChallanDate = '" + day + "' SupplierCode = '" + code + "'", conn).ToString());
                    challanNo += (count + 1).ToString();//.PadLeft(4, '0');
                }
                return challanNo;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal DataTable GetProductInforByBarCode_FromStore(string BarCode, string CompanyCode)
        {
            DataTable dt = new DataTable();
            Hashtable ht = new Hashtable();
            ht.Add("BarCode", BarCode);
            ht.Add("CompanyCode", CompanyCode);

            dt = ado.GetDataByProc(ht, "INV_GetProductInfoFromStore", conn);

            return dt;
        }

        internal DataTable GetProductInforByBarCode(string BarCode, string OCode, int ForOCode)
        {
            DataTable dt = new DataTable();
            Hashtable ht = new Hashtable();
            ht.Add("OCode", OCode);
            ht.Add("BarCode", BarCode);
            if (OCode != string.Empty)
            {
                try
                {
                    dt = ado.GetDataByProc(ht, "INV_GetProductInfo", conn);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return dt;
        }

        internal DataTable GetProductInfor_FromStore(string BarCode, string OCode, string ProjectCode, int StoreID, int Store_UnitID)
        {
            DataTable dt = new DataTable();
            Hashtable ht = new Hashtable();
            ht.Add("BarCode", BarCode);
            ht.Add("OCode", OCode);
            ht.Add("ProjectCode", ProjectCode);
            ht.Add("StoreID", StoreID);
            ht.Add("StoreUnit_ID", Store_UnitID);
            if (OCode != string.Empty)
            {
                try
                {
                    dt = ado.GetDataByProc(ht, "INV_GetProductInfo_FromStore", conn);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return dt;
        }

        internal DataTable FindEmployee(string EID)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = ado.GetDataBySQLString("select D.DPT_CODE, E.ReportingBossId from HRM_PersonalInformations E inner join HRM_DEPARTMENTS D on E.DepartmentId = D.DPT_ID where EID  = '" + EID + "'", conn);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        internal DataTable FindEmployeeByID(int empid)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = ado.GetDataBySQLString("select D.DPT_CODE from HRM_PersonalInformations E inner join HRM_DEPARTMENTS D on E.DepartmentId = D.DPT_ID where EmpId  = '" + empid + "'", conn);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        internal DataTable DeliverProduct(Hashtable ht)
        {
            try
            {
                DataTable dt = new DataTable();
                dt = ado.GetDataByProc(ht, "INV_ProductDelivery_1", conn);
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal DataTable DeliverProduct_FromStoreUnit(Hashtable ht)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = ado.GetDataByProc(ht, "INV_ProductDelivery_FromStoreUnit", conn);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        internal DataTable DeliverProductByRequisition(Hashtable ht)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = ado.GetDataByProc(ht, "INV_ProductDeliveryByRequisition", conn);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        internal DataTable GetIChalanTemp(string ocode, string challanNo)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = ado.GetDataBySQLString(@"select T.Id,G.GroupName,T.ProductName,T.Brand,T.StyleSize,T.BarCode,T.UnitName,T.DeliveryQty,T.ChallanTotal from Inv_IChallan_Temp T
	            inner join Inv_ProductGroup G on G.GroupId = T.ProductGroup where T.ChallanNo ='" + challanNo + "' and  T.OCode = '" + ocode + "'", conn);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        internal DataTable DeliverProduct_Temp(Hashtable ht)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = ado.GetDataByProc(ht, "INV_ProductDelivery_Tmp", conn);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }


        internal DataTable DeliverProduct_Temp1(Hashtable ht)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = ado.GetDataByProc(ht, "INV_ProductDelivery_Tmp1", conn);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        internal void DeleteTempChalanById(int id)
        {
            try
            {
                ado.AggRetrive("delete from Inv_IChallan_Temp where Id = " + id, conn);

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        internal string GetNewRequisitionNo(string type, string CompanyCode, string DPT_CODE, string EID, DateTime date)
        {
            string ReqNo = String.Empty;
            try
            {
                if (type == "CMP")
                {

                    ReqNo = "RS-" + date.Year.ToString() + date.Month.ToString() + date.Day.ToString() + GetCountReqNo(CompanyCode, date, "CMP");

                }
                else if (type == "DPT")
                {

                    ReqNo = "RS-" + date.Year.ToString() + date.Month.ToString() + date.Day.ToString() + GetCountReqNo(DPT_CODE, date, "DPT");
                }
                else if (type == "CMP-DPT")
                {

                    ReqNo = "RS-" + date.Year.ToString() + date.Month.ToString() + date.Day.ToString() + GetCountReqNo(DPT_CODE, date, "DPT");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ReqNo;
        }

        private string GetCountReqNo(string Code, DateTime date, string type)
        {

            int maxid = 0;
            try
            {
                if (type == "CMP")
                {

                    maxid = Int32.Parse(ado.AggRetrive("select COUNT(distinct ReqNo) from PRQ_Requisitions where ReqDate = '" + date + "'", conn).ToString());
                }
                else
                {

                    maxid = Int32.Parse(ado.AggRetrive("select COUNT(distinct ReqNo) from PRQ_Requisitions where ReqDate = '" + date + "'", conn).ToString());
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return (maxid + 1).ToString();
        }

        internal object GetRequisition(string ReqNo, string type)
        {
            Hashtable ht = new Hashtable();
            ht.Add("ReqNo", ReqNo);
            ht.Add("Type", type);
            DataTable dt = new DataTable();
            try
            {
                if (type == "CMP")
                {
                    dt = ado.GetDataByProc(ht, "PRQ_GetRequisition", conn);
                }
                else
                { // DPT
                    dt = ado.GetDataByProc(ht, "PRQ_GetRequisition", conn);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        internal bool AddRequisition(Hashtable ht)
        {
            try
            {
                ado.InsertData(ht, "PRQ_AddRequisition", conn);
                return true;
            }
            catch
            {
                return false;
            }
        }
        internal DataTable GetProductInforByBarCode(string barCode)
        {
            DataTable dt = new DataTable();

            try
            {
                dt = ado.GetDataBySQLString("select * from Inv_BuyCentral where BarCode = " + barCode + "", conn);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        internal void DeleteRequisitionById(int id)
        {
            try
            {
                ado.AggRetrive("delete from PRQ_Requisition_Temp where Id = " + id + "", conn);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //sha

        internal DataTable GetDataEditRequisition(int id)
        {
            Hashtable ht = new Hashtable();
            ht.Add("Id", id);
            DataTable dt = new DataTable();
            try
            {
                dt = DataAccess.GetDataByProc(ht, "PRQ_GetalldatabyReqId");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        internal DataTable GetDataByReqNo(int id)
        {
            Hashtable ht = new Hashtable();
            ht.Add("Id", id);
            DataTable dt = new DataTable();
            try
            {
                dt = DataAccess.GetDataByProc(ht, "PRQ_GetAlldataby_ReqId");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        internal void DeleteRequisitionJobwiseById(int id)
        {
            try
            {
                ado.AggRetrive("delete from CS_JobwiseRequisition where Id = " + id + "", conn);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal object GetProductListByGroup(int GroupId)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = ado.GetDataBySQLString("select ProductId, (ProductName +' - ' + Brand +' - StyleAndSize') as ProductName from Inv_Product where GroupId = " + GroupId + "", conn);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        internal DataTable GetRequisitionTSelecte(int Id, string For)
        {
            DataTable dt = new DataTable();
            try
            {
                Hashtable ht = new Hashtable();
                ht.Add("Id", Id);
                ht.Add("For", For);
                dt = ado.GetDataByProc(ht, "PRQ_SelectedData", conn);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        //for HomeBound

        internal DataTable GetStoreRequisitionData(string ReqNo, string For)
        {
            DataTable dt = new DataTable();
            try
            {
                Hashtable ht = new Hashtable();
                ht.Add("ReqNo", ReqNo);
                ht.Add("For", For);
                dt = ado.GetDataByProc(ht, "PRQ_SelectStoreReq", conn);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        internal DataTable GetPurchaseRequisitionData(string ReqNo, string For)
        {
            DataTable dt = new DataTable();
            try
            {
                Hashtable ht = new Hashtable();
                ht.Add("ReqNo", ReqNo);
                ht.Add("For", For);
                dt = ado.GetDataByProc(ht, "PRQ_SelectPurchaseReq", conn);
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        internal DataTable GetPurchaseRequisitionDataTry(string ReqNo, string For)
        {
            DataTable dt = new DataTable();
            try
            {
                Hashtable ht = new Hashtable();
                ht.Add("ReqNo", ReqNo);
                ht.Add("For", For);
                dt = ado.GetDataByProc(ht, "PRQ_SelectPurchaseReqForAdmin", conn);
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        internal DataTable GetAllStoreRequisitionData(string ReqNo, string For)
        {
            DataTable dt = new DataTable();
            try
            {
                Hashtable ht = new Hashtable();
                ht.Add("ReqNo", ReqNo);
                ht.Add("For", For);
                dt = ado.GetDataByProc(ht, "PRQ_SelectAllStoreReq", conn);
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        //download
        internal DataTable GetFile(string File, string OCode)
        {
            DataTable dt = new DataTable();
            try
            {
                Hashtable ht = new Hashtable();
                ht.Add("ReqNo", File);
                ht.Add("OCode", OCode);
                dt = ado.GetDataByProc(ht, "Requisition_File_Download", conn);
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        //
        internal DataTable GetAllPurchaseRequisitionData(string ReqNo, string For)
        {
            DataTable dt = new DataTable();
            try
            {
                Hashtable ht = new Hashtable();
                ht.Add("ReqNo", ReqNo);
                ht.Add("For", For);
                dt = ado.GetDataByProc(ht, "PRQ_SelectAllPurchaseReq", conn);
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal DataTable GetRequisitionSelectJobwise(int Id, string For)
        {
            DataTable dt = new DataTable();
            try
            {
                Hashtable ht = new Hashtable();
                ht.Add("Id", Id);
                ht.Add("For", For);
                dt = ado.GetDataByProc(ht, "PRQ_SelectedData_ReqJobwise", conn);
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //

        internal bool Approve(int Id, int ApproveQty, string ApprovedBy)
        {
            try
            {
                if (ApprovedBy == "Manager")
                {
                    ado.AggRetrive("update PRQ_Requisitions set IsAcceptedByManager = 1, ManagerApproveQty = " + ApproveQty + " where Id = " + Id + "", conn);
                }
                else if (ApprovedBy == "Head")
                {
                    ado.AggRetrive("update PRQ_Requisitions set IsAcceptedByHead = 1, HeadApproveQty = " + ApproveQty + " where Id = " + Id + "", conn);
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
        internal object GetRequisitionToApprove(string ReqNo, string For)
        {
            DataTable dt = new DataTable();
            try
            {
                Hashtable ht = new Hashtable();
                ht.Add("ReqNo", ReqNo);
                ht.Add("For", For);
                dt = ado.GetDataByProc(ht, "PRQ_GetRequisitionByReqNo", conn);
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal DataTable GetProductInfoByBarcode(string barcode)
        {
            DataTable dt = new DataTable();
            try
            {
                //string CType = ado.AggRetrive("select CompanyType from Inv_Company where CompanyCode = '" + cmpCode + "'", conn).ToString();
                //if (CType == "CENTRAL")
                //{
                dt = ado.GetDataBySQLString("select BarCode, (ProductName+' - '+BarCode) as ProductName from Inv_BuyCentral where BarCode = " + barcode + "", conn);
                //}
                //else
                //{
                //    dt = ado.GetDataBySQLString("select BarCode, ProductName from Inv_Buy where ProductGroup = " + GroupId + " and CompanyCode='" + cmpCode + "'", conn);
                //}
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public DataTable GetProductListByGroup_FromStore(string GroupId)
        {

            DataTable dt = new DataTable();
            try
            {
                dt = ado.GetDataBySQLString("select BarCode, (ProductName +' - ' + Brand+' - '+StyleSize) as ProductName from Inv_Buy where ProductGroup = " + GroupId + "", conn);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        internal DataTable GetProductInfoByBarcode_FromStore(string barcode)
        {
            DataTable dt = new DataTable();
            try
            {
                //string CType = ado.AggRetrive("select CompanyType from Inv_Company where CompanyCode = '" + cmpCode + "'", conn).ToString();
                //if (CType == "CENTRAL")
                //{
                dt = ado.GetDataBySQLString("select BarCode, (ProductName+' - '+BarCode) as ProductName from Inv_Buy where BarCode = " + barcode + "", conn);
                //}
                //else
                //{
                //    dt = ado.GetDataBySQLString("select BarCode, ProductName from Inv_Buy where ProductGroup = " + GroupId + " and CompanyCode='" + cmpCode + "'", conn);
                //}
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal DataTable GetProductByBarCodeFromStore(string BarCode, string OCode, string StoreCode)
        {
            try
            {
                DataTable dt = new DataTable();
                Hashtable ht = new Hashtable();
                ht.Add("OCode", OCode);
                ht.Add("BarCode", BarCode);
                ht.Add("Store_Code", StoreCode);
                if (OCode != string.Empty)
                {
                    dt = ado.GetDataByProc(ht, "INV_GetProductInfo", conn);
                }
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal bool Update_Inv_IChallan_Temp(string ChalanNo, int Productid, string productName, string styleandSize)
        {


            try
            {
                ado.AggRetrive(@"update [dbo].[Inv_IChallan_Temp] set DeliveryQty = (isnull(DeliveryQty,0)+ @DeliveryQty)
			where ChallanNo = " + ChalanNo + " and [ProductGroup]= '" + Productid + "' and [ProductName]= " + productName + " and [StyleSize]=" + styleandSize + "", conn);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }
        internal int Update_IChalanTemp(Guid UserId, string barcode, double delivaryQty)
        {
            return iChallanDal.Update_IChalanTemp(UserId, barcode, delivaryQty);
        }

        internal List<Inv_IChallan_Temp> GetDataByIChallan_Tem(string ChallanNo, string barcode)
        {
            return iChallanDal.GetDataByIChallan_Tem(ChallanNo, barcode);
        }

        internal DataTable GetOldUnPostedIChallan(string Ocode)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = ado.GetDataBySQLString("select distinct ChallanNo from Inv_IChallan_Temp where OCode = '" + Ocode + "'", conn);
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        internal DataTable GetOldUnPostedIChallanForCentrelToDpt(string Ocode)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = ado.GetDataBySQLString("select distinct ChallanNo from Inv_IChallan_Temp where OCode = '" + Ocode + "' and ChallanNo  LIKE 'CD%'", conn);
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }
        internal DataTable GetOldUnPostedIChallanForCentrelToStore(string Ocode)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = ado.GetDataBySQLString("select distinct ChallanNo from Inv_IChallan_Temp where OCode = '" + Ocode + "' and ChallanNo  LIKE 'CS%'", conn);
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        internal DataTable GetOldUnPostedIChallanForStoreToStore(string Ocode)
        {
            try
            {
                DataTable dt = new DataTable();
                dt = ado.GetDataBySQLString("select distinct ChallanNo from Inv_IChallan_Temp where OCode = '" + Ocode + "' and ChallanNo  LIKE 'TR%'", conn);
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal DataTable GetOldUnPostedIChallanForStoreToDpt(string Ocode)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = ado.GetDataBySQLString("select distinct ChallanNo from Inv_IChallan_Temp where OCode = '" + Ocode + "'", conn);
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal DataTable OldChallan(string challanNo, string Ocode)
        {
            try
            {
                DataTable dt = new DataTable();
                dt = ado.GetDataBySQLString("select * from Inv_IChallan_Temp where ChallanNo ='" + challanNo + "' and  T.OCode = '" + Ocode + "'", conn);
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal List<POReceivedR> ReceivebyPoSerchByDatetoDate(DateTime Todate, DateTime Fromdate)
        {

            try
            {
                using (var _context = new ERPSSLHBEntities())
                {
                    var Tod = new SqlParameter("@Todate", Todate);
                    var Fdate = new SqlParameter("@fromdate", Fromdate);
                    string SP_SQL = "INV_ReceivebyPoSerchByDatetoDate @Todate,@fromdate";
                    return (_context.ExecuteStoreQuery<POReceivedR>(SP_SQL, Tod, Fdate)).ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<Inv_Damage> GetDataInv_Damage(string ocode)
        {
            return iChallanDal.GetDataInv_Damage(ocode);
        }

        public List<Inv_Damage> GetDataInv_DamageDateWise(string formDate, string ToDate)
        {
            return iChallanDal.GetDataInv_DamageDateWise(formDate, ToDate);
        }
        internal DataTable GetProductListToReturnStoreWisr(int groupId, string storeCode, string supTo)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = ado.GetDataBySQLString("select distinct BarCode,(p.ProductName +' - ' + isnull(p.Brand,'') +' - '+ isnull(p.StyleAndSize,'')) as ProductName from Inv_RChallan r inner join Inv_Product p on p.ProductId=r.Barcode where Store_Code = '" + storeCode + "' and ProductGroup = '" + groupId + "' and SupplierCode = '" + supTo + "' order by ProductName", conn);
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        internal DataTable GetSupplierListToReturnStoreWise(string storeCode)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = ado.GetDataBySQLString("select distinct S.SupplierCode, S.SupplierName from Inv_RChallan R inner Join Inv_Supplier S on R.SupplierCode = S.SupplierCode where R.Store_Code = '" + storeCode + "'", conn);
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        internal DataTable GetProductListToProgramWise(int groupId, string programId)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = ado.GetDataBySQLString("select distinct r.ProductId as BarCode,(p.ProductName +' - ' + isnull(p.Brand,'') +' - '+ isnull(p.StyleAndSize,'')) as ProductName from Inv_IChallan r inner join Inv_Product p on p.ProductId=r.ProductId where r.Program = '" + programId + "' and ProductGroup = '" + groupId + "' order by ProductName", conn);
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        internal DataTable GetListProgram()
        {
            DataTable dt = new DataTable();
            try
            {
                dt = ado.GetDataBySQLString("select ProgramName, ProgramID from Inv_Program order by ProgramId", conn);
                //"select CL.StyleAutoID, CL.StyleID  from Com_Style_LC as CL inner join Com_SheduleTimeToTime as CT on CL.StyleAutoID=CT.StyleID  order by StyleID", conn);
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal DataTable GetListProgram(int styleId)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = ado.GetDataBySQLString("select ScheduleID, BatchNo from Com_SheduleTimeToTime where StyleID ='" + styleId + "' order by BatchNo", conn);
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal void DeleteRequisitionTempById(int id)
        {
            try
            {
                ado.AggRetrive("delete from PRQ_Requisition_Temp where Id = " + id + "", conn);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //internal Inv_BuyCentral LoadByCentralData(string p1, string p2)
        //{
        //    return iChallanDal.LoadByCentralData(p1, p2);
        //}

        internal int Insert(Inv_IChallan_Temp _ObjIchalanT)
        {
            return iChallanDal.Insert(_ObjIchalanT);
        }

        internal List<Inv_IChallan_Temp> GetIssueeGrid(int ID, string OCode)
        {
            return iChallanDal.GetIssueeGrid(ID, OCode);
        }

        //internal string TransferDataFromiChallanTempToiChallan(string OCode, string ChallanNo)
        //{
        //    try
        //    {
        //        throw new NotImplementedException();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        internal List<Inv_BuyCentral> GetBlQtyfromBuyCentral(string OCode, int PId)
        {
            return iChallanDal.GetBlQtyfromBuyCentral(OCode, PId);
        }

        internal List<Inv_BuyCentral> Get_ItemBalance_ById_Store(string OCode, int PId, string storeCode)
        {
            return iChallanDal.Get_ItemBalance_ById_Store(OCode, PId, storeCode);
        }


        internal DataTable GetStoreToStoreReport(string ChallanNo, string OCode)
        {
            DataTable dt = new DataTable();
            try
            {
                Hashtable ht = new Hashtable();
                ht.Add("ChallanNo", ChallanNo);
                ht.Add("OCode", OCode);
                dt = ado.GetDataByProc(ht, "INV_StoretoStore_RPT", conn);
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal DataTable GetStoreToDepartmentReport(string ChallanNo, string OCode)
        {
            DataTable dt = new DataTable();
            try
            {
                Hashtable ht = new Hashtable();
                ht.Add("ChallanNo", ChallanNo);
                ht.Add("OCode", OCode);
                dt = ado.GetDataByProc(ht, "INV_StoretoDepartment_RPT", conn);
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal int InsertStD(Inv_IChallan_Temp _ObjIchalanT)
        {
            return iChallanDal.InsertStD(_ObjIchalanT);
        }

        internal void UpdateReqStatus(string ReqNo, int Id, double ReceiveQty)
        {
            PRQ_Requisitions PRQ_Requisitions = _Invcontext.PRQ_Requisitions.First(x => x.ReqNo == ReqNo && x.Id == Id);
            PRQ_Requisitions.IsDelivered = true;
            PRQ_Requisitions.LastReceived = ReceiveQty;
            _context.SaveChanges();
        }

        internal void UpdateReqStatusLastReceive(string ReqNo, int Id, double ReceiveQty)
        {
            PRQ_Requisitions PRQ_Requisitions = _Invcontext.PRQ_Requisitions.First(x => x.ReqNo == ReqNo && x.Id == Id);
            PRQ_Requisitions.LastReceived = ReceiveQty;
            _Invcontext.SaveChanges();
        }

        public int UpdateInvByCentral_FIFO(List<DeleveryProductR> deleveryProducts)
        {
            try
            {
                using (var _context = new ERPSSL_INVEntities())
                {
                    foreach (DeleveryProductR aitem in deleveryProducts)
                    {
                        var barcode = new SqlParameter("@ProductId", aitem.BarCode);
                        var reqno = new SqlParameter("@ReqNo", aitem.ReqNo);
                        var DeliveryQty = new SqlParameter("@RequestedQty", aitem.HeadApproveQty);
                        var DeliveryType = new SqlParameter("@DeliveryType", aitem.DeliveryType);
                        //var ChallanNo = new SqlParameter("@ChallanNo", aitem.ChallanNo);
                        var TransferDate = new SqlParameter("@TransferDate", aitem.TransferDate);
                        var DPT_CODE = new SqlParameter("@DPT_CODE", aitem.DPT_CODE);
                        var EID = new SqlParameter("@EID", aitem.EID);
                        var CurrentCompanyCode = new SqlParameter("@CurrentCompanyCode", aitem.CurrentCompanyCode);
                        var OldCompanyCode = new SqlParameter("@OldCompanyCode", aitem.OldCompanyCode);
                        var OCode = new SqlParameter("@OCode", aitem.OCode);
                        var StoreCode = new SqlParameter("@StoreCode", aitem.StoreCode);
                        var StyleId = new SqlParameter("@StyleId", aitem.StyleId);
                        var ProgramId = new SqlParameter("@ProgramId", aitem.ProgramId);
                        var Remarks = new SqlParameter("@Remarks", aitem.Remarks);
                        string SP_SQL = "INV_ProductDelivery_FIFO_ByRequisition @ProductId,@ReqNo,@RequestedQty,@DeliveryType,@TransferDate,@DPT_CODE,@EID,@CurrentCompanyCode,@OldCompanyCode,@OCode,@StoreCode,@StyleId,@ProgramId,@Remarks";
                        _context.ExecuteStoreCommand(SP_SQL, barcode, reqno, DeliveryQty, DeliveryType, TransferDate, DPT_CODE, EID, CurrentCompanyCode, OldCompanyCode, OCode, StoreCode, StyleId, ProgramId, Remarks);

                        //  string bcode = Convert.ToString(aitem.BarCode);
                        // UpdateRequisition(aitem.ReqNo, bcode, aitem.HeadApproveQty, aitem.ID);
                    }
                    return 1;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        internal List<DeleveryProductR> GetDeleveryProductList(DateTime Todate, DateTime Fromdate)
        {
            try
            {
                using (var _context = new ERPSSLHBEntities())
                {
                    var Tod = new SqlParameter("@Todate", Todate);
                    var Fdate = new SqlParameter("@fromdate", Fromdate);
                    string SP_SQL = "INV_GetDeleveryProductByDatetoDate @Todate,@fromdate";
                    return (_context.ExecuteStoreQuery<DeleveryProductR>(SP_SQL, Tod, Fdate)).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        internal DataTable GetProductByBarCodeFromBy_Store(string BarCode, string OCode, string storeCode)
        {
            DataTable dt = new DataTable();
            Hashtable ht = new Hashtable();
            ht.Add("OCode", OCode);
            ht.Add("BarCode", BarCode);
            //ht.Add("CompanyCode", CompanyCode);
            // ht.Add("ProjectCode", projectCode);
            ht.Add("StoreCode", storeCode);
            // ht.Add("unitId", unitId);
            if (OCode != string.Empty)
            {
                try
                {
                    dt = ado.GetDataByProc(ht, "INV_GetProductInfoBy_Store", conn);
                }
                catch { }
            }
            return dt;
        }


        internal DataTable GetIChalanTempWithUser(string ocode, Guid userId)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = ado.GetDataBySQLString(@"select T.Id,G.GroupName,T.ProductName,T.Brand,T.StyleSize,T.BarCode,T.UnitName,T.DeliveryQty,T.ChallanTotal from Inv_IChallan_Temp T
	            inner join Inv_ProductGroup G on G.GroupId = T.ProductGroup where  T.EditUser='" + userId + "' and  T.OCode = '" + ocode + "'", conn);
            }
            catch { }
            return dt;
        }

        internal List<Inv_IChallan_Temp> GetDataByIChallan_TemUserWise(Guid userId, string BarCode)
        {
            return iChallanDal.GetDataByIChallan_TemUserWise(userId, BarCode);

        }

        internal DataTable ReturnProductStoreWise(Hashtable ht)
        {
            try
            {
                DataTable dt = new DataTable();
                dt = ado.GetDataByProc(ht, "INV_ProductReturnStoreWise", conn);
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal DataTable GetSubCompanyList()
        {
            try
            {
                DataTable dt = new DataTable();
                dt = ado.GetDataBySQLString("select DISTINCT Sub_Company from Inv_IChallan Order By Sub_Company", conn);
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
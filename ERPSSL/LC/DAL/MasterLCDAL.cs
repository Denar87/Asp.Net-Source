using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ERPSSL.HRM.DAL;
using ERPSSL.LC.DAL.Repository;
using MoreLinq;
using System.Data.SqlClient;
using ERPSSL.HRM.DAL.Repository;
using ERPSSL.BuyingHouse.DAL.Repository;

namespace ERPSSL.LC.DAL
{
    public class MasterLCDAL
    {
        public ERPSSL_LCEntities _Context = new ERPSSL_LCEntities();
        internal List<Com_Buyer_Setup> GetAllBuyerName(string OCODE)
        {
            try
            {
                var query = (from bs in _Context.Com_Buyer_Setup
                             where bs.OCODE == OCODE
                             select bs).OrderBy(x => x.Buyer_ID);
                return query.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        internal int InsertNewOrderEntry(LC_OrderEntryTemp objneworder)
        {
            try
            {
                _Context.LC_OrderEntryTemp.AddObject(objneworder);
                _Context.SaveChanges();
                return 1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        internal int InsertOrderEntry(LC_OrderEntry objneworder)
        {
            try
            {
                _Context.LC_OrderEntry.AddObject(objneworder);
                _Context.SaveChanges();
                return 1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        internal List<LC_OrderEntry> GetAllOrder(string OCode, string LCNo)
        {
            try
            {
                var orderEntryTemp = (from _Oentry in _Context.LC_OrderEntry
                                      where _Oentry.OCODE == OCode && _Oentry.LCNo == LCNo
                                      select _Oentry).OrderBy(x => x.OrderEntryID);
                return orderEntryTemp.ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        internal List<LC_OrderEntryTemp> GetAllOrderE_Temp(string LcNo)
        {
            try
            {
                var orderEntryTemp = (from _Oentry in _Context.LC_OrderEntryTemp
                                      where _Oentry.LCNo == LcNo
                                      select _Oentry).OrderBy(x => x.OrderEntryID);
                return orderEntryTemp.ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        //internal List<LC_OrderEntryTemp> GetAllOrder()
        //{
        //    var orderEntryTemp = (from _Oentry in _Context.LC_OrderEntryTemp
        //                          //where _Oentry.OrderNo == LcNo
        //                          select _Oentry).OrderBy(x => x.OrderSL);
        //    return orderEntryTemp.ToList();
        //}

        internal int UpdateOrderEntry_Temp(LC_OrderEntryTemp objOentry, int ID)
        {
            try
            {
                LC_OrderEntryTemp obj = _Context.LC_OrderEntryTemp.First(x => x.OrderEntryID == ID);
                obj.OrderNo = objOentry.OrderNo;
                obj.OrderQuantity = objOentry.OrderQuantity;
                obj.ShipmentDate = objOentry.ShipmentDate;
                obj.Season = objOentry.Season;
                obj.FobQty = objOentry.FobQty;
                obj.Article = objOentry.Article;
                obj.ColorSpecification = objOentry.ColorSpecification;
                obj.Style = objOentry.Style;
                _Context.SaveChanges();
                return 1;
            }
            catch (Exception)
            {
                throw;
            }
        }

        internal int UpdateOrderEntry(LC_OrderEntry objOentry, string LCNo, string OrderNo)
        {
            try
            {
                LC_OrderEntry obj = _Context.LC_OrderEntry.First(x => x.OrderNo == OrderNo && x.LCNo == LCNo);
                obj.OrderNo = objOentry.OrderNo;
                obj.OrderQuantity = objOentry.OrderQuantity;
                obj.ShipmentDate = objOentry.ShipmentDate;
                obj.FobQty = objOentry.FobQty;
                obj.Article = objOentry.Article;
                obj.ColorSpecification = objOentry.ColorSpecification;
                obj.Style = objOentry.Style;
                obj.Season = objOentry.Season;
                _Context.SaveChanges();
                return 1;
            }
            catch (Exception)
            {
                throw;
            }
        }

        internal int InsertLCmaster(LC_MasterLC _objLCmaster)
        {
            try
            {
                _Context.LC_MasterLC.AddObject(_objLCmaster);
                _Context.SaveChanges();
                return 1;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        internal List<LC_OrderEntryTemp> GetAllMlcAndOEntry(string OElcNo)
        {
            using (var _Context = new ERPSSL_LCEntities())
            {
                return _Context.LC_OrderEntryTemp.Where(x => x.LCNo == OElcNo).ToList();
            }
        }

        internal int InsertAllMlcAndOEntry(LC_OrderEntry lC_OrderEntry)
        {
            using (var _Context = new ERPSSL_LCEntities())
            {
                _Context.LC_OrderEntry.AddObject(lC_OrderEntry);
                _Context.SaveChanges();
                return 1;
            }
        }

        internal void ClearAlTemp()
        {
            try
            {
                using (var _context = new ERPSSL_LCEntities())
                {
                    _context.ExecuteStoreCommand("truncate table [dbo].[LC_OrderEntryTemp]");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        internal List<LC_MasterLC> GetAllLCItemsByLCNo(string lcNo)
        {
            try
            {

                var LCQ = (from lcN in _Context.LC_MasterLC
                           where lcN.LCNo == lcNo
                           select lcN);
                return LCQ.ToList();

            }
            catch (Exception)
            {
                throw;
            }
        }

        internal List<LC_OrderEntry> GetALLOrderEntrybyID(string OEntrylc, string OCODE)
        {
            try
            {
                var query = (from bs in _Context.LC_OrderEntry
                             where bs.LCNo == OEntrylc && bs.OCODE == OCODE
                             select bs).OrderBy(x => x.OrderEntryID);
                return query.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        internal int UpdateMasterLc(string LCNo, LC_MasterLC _LC_MasterLC)
        {
            try
            {
                LC_MasterLC ObjLC_MasterLC = _Context.LC_MasterLC.First(x => x.LCNo == LCNo);
                ObjLC_MasterLC.SubCompanyName = _LC_MasterLC.SubCompanyName;
                ObjLC_MasterLC.DateofIssue = _LC_MasterLC.DateofIssue;
                ObjLC_MasterLC.DateofExpiry = _LC_MasterLC.DateofExpiry;
                ObjLC_MasterLC.Buyer_ID = _LC_MasterLC.Buyer_ID;
                ObjLC_MasterLC.BuyerType = _LC_MasterLC.BuyerType;
                //ObjLC_MasterLC.Season = _LC_MasterLC.Season;
                ObjLC_MasterLC.Qty = _LC_MasterLC.Qty;
                ObjLC_MasterLC.ItemDescription = _LC_MasterLC.ItemDescription;
                ObjLC_MasterLC.USDRate = _LC_MasterLC.USDRate;
                ObjLC_MasterLC.BDTRate = _LC_MasterLC.BDTRate;
                ObjLC_MasterLC.LC_USDValu = _LC_MasterLC.LC_USDValu;
                ObjLC_MasterLC.Conv_Rate = _LC_MasterLC.Conv_Rate;
                ObjLC_MasterLC.LC_BDTValu = _LC_MasterLC.LC_BDTValu;
                ObjLC_MasterLC.Create_Date = DateTime.Now;
                ObjLC_MasterLC.LC_Issue_Bank = _LC_MasterLC.LC_Issue_Bank;
                _Context.SaveChanges();
                return 1;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        internal List<LC_OrderEntry> GetLCOrder(string LCNO, string OrderNo)
        {
            try
            {
                var query = (from bs in _Context.LC_OrderEntry
                             where bs.LCNo == LCNO && bs.OrderNo == OrderNo
                             select bs).OrderBy(x => x.OrderEntryID);
                return query.ToList();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        internal List<Rep_Estimate> Get_All_PO_EstimatedSummaryList(string OCODE)
        {
            try
            {
                var LC_Req = (from PO in _Context.LC_PurchaseOrder
                              join es in _Context.LC_CostEstimateSummary on PO.Cost_Estimate_ID equals es.Cost_Estimate_ID
                              join buyer in _Context.Com_Buyer_Setup on PO.Buyer_ID equals buyer.Buyer_ID
                              join item in _Context.LC_FinishGoods on es.FinishedGoods_ID equals item.FinishGoods_Id
                              where PO.OCode == OCODE

                              select new Rep_Estimate
                              {
                                  LC_PO_No = PO.LC_PO_No,
                                  Cost_Estimate_ID = PO.Cost_Estimate_ID,
                                  Buyer_Name = buyer.Buyer_Name,
                                  Lc_Style = PO.LC_Style,
                                  Lc_Order = PO.LC_Order,
                                  FinishGoods_Name = item.FinishGoods_Name,
                                  FinishedGoods_Qty = es.FinishedGoods_Qty,
                                  OrderDate = es.OrderDate,
                                  Ref_No = es.Ref_No,
                                  Merchandiser_Name = es.Merchandiser_Name,
                                  //Estimation_Approval = req.Estimation_Approval
                                  LC_PO_Date = PO.LC_PO_Date,
                                  PO_Type = PO.PO_Type,
                                  IsPO_Approved = PO.IsPO_Approved
                              }).DistinctBy(x => x.LC_PO_No);
                return LC_Req.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }



        internal List<Rep_Estimate> Get_EstimateDetailsList(string id)
        {
            try
            {
                var LC_Req = (from PO in _Context.LC_PurchaseOrder
                              join es in _Context.LC_CostEstimateSummary on PO.Cost_Estimate_ID equals es.Cost_Estimate_ID
                              join buyer in _Context.Com_Buyer_Setup on PO.Buyer_ID equals buyer.Buyer_ID
                              join item in _Context.LC_FinishGoods on PO.ProductId equals item.FinishGoods_Id
                              where PO.Cost_Estimate_ID == id

                              select new Rep_Estimate
                              {
                                  LC_PO_No = PO.LC_PO_No,
                                  Cost_Estimate_ID = PO.Cost_Estimate_ID,
                                  Buyer_Name = buyer.Buyer_Name,
                                  Lc_Style = PO.LC_Style,
                                  Lc_Order = PO.LC_Order,
                                  FinishGoods_Name = item.FinishGoods_Name,
                                  FinishedGoods_Qty = es.FinishedGoods_Qty,
                                  OrderDate = es.OrderDate,
                                  //Ref_No = req.Ref_No,      
                                  //Merchandiser_Name = req.Merchandiser_Name,
                                  //Estimation_Approval = req.Estimation_Approval
                                  LC_PO_Date = PO.LC_PO_Date,
                                  PO_Type = PO.PO_Type
                              });
                return LC_Req.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        internal List<LC_OrderEntry> GetOrderByOrderIdandOcode(string orderId, string OCODE)
        {
            int OrderId = Convert.ToInt32(orderId);

            //HRM_Regions Region = _context.HRM_Regions.First(x => x.RegionID == RegionId);
            //return Region;  

            List<LC_OrderEntry> Orders = (from ord in _Context.LC_OrderEntry
                                          where ord.OCODE == OCODE && ord.OrderEntryID == OrderId
                                          select ord).OrderBy(x => x.OrderEntryID).ToList<LC_OrderEntry>();
            return Orders;
        }

        internal int UpdateOrderEntry(LC_OrderEntry orderEntry, int orderid)
        {
            try
            {
                LC_OrderEntry obj = _Context.LC_OrderEntry.First(x => x.OrderEntryID == orderid);


                //obj.Season = orderEntry.Season;

                obj.OrderNo = orderEntry.OrderNo;
                obj.LCNo = orderEntry.LCNo;
                obj.Article = orderEntry.Article;
                obj.ColorSpecification = orderEntry.ColorSpecification;
                obj.OrderQuantity = orderEntry.OrderQuantity;
                obj.FobQty = orderEntry.FobQty;
                obj.Style = orderEntry.Style;
                obj.TotalQty = orderEntry.TotalQty;
                obj.SeasonId = orderEntry.SeasonId;
                obj.Size = orderEntry.Size;
                obj.Buyer_Department = orderEntry.Buyer_Department;
                obj.Supplier_No = orderEntry.Supplier_No;
                obj.OrderReceiveDate = orderEntry.OrderReceiveDate;

                obj.Delivery_Date = orderEntry.Delivery_Date;
                obj.Yarn_Fabrication = orderEntry.Yarn_Fabrication;
                obj.FOB_Port = orderEntry.FOB_Port;
                obj.LC_Reveived_Date = orderEntry.LC_Reveived_Date;
                obj.Schedule_Date = orderEntry.Schedule_Date;
                obj.Shipment_Mode = orderEntry.Shipment_Mode;
                obj.Comments = orderEntry.Comments;
                obj.ShipmentDate = orderEntry.ShipmentDate;

                obj.CommissionPersent = orderEntry.CommissionPersent;
                obj.TotalCommission = orderEntry.TotalCommission;

                obj.Create_Date = DateTime.Today;
                obj.Create_User = orderEntry.Edit_User;
                obj.OCODE = orderEntry.OCODE;

                _Context.SaveChanges();
                return 1;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal List<HRM_Office> GetAllOffice(string OCode)
        {
            try
            {
                var query = (from O in _Context.HRM_Office
                             where O.OCODE == OCode
                             select O).OrderBy(x => x.OfficeName);
                return query.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        internal List<LC_MasterLC> GetALLLCByLCNo(string LcNo, string OCode)
        {
            try
            {
                var query = (from lc in _Context.LC_MasterLC
                             where lc.OCODE == OCode && lc.LCNo == LcNo
                             select lc).OrderBy(x => x.LCNo);
                return query.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        internal LC_MasterLC GetLcLById(int LcId)
        {
            try
            {
                return (from lc in _Context.LC_MasterLC
                        where lc.MlcID == LcId
                        select lc).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        internal int UpdateMasterAmendLc(LC_MasterLC _objLCmaster)
        {
            try
            {
                LC_MasterLC _LC_No = _Context.LC_MasterLC.FirstOrDefault(x => x.MlcID == _objLCmaster.MlcID);
                _LC_No.LC_Amend_Date = _objLCmaster.LC_Amend_Date;
                _LC_No.LC_Amend_USDValue = _objLCmaster.LC_Amend_USDValue;
                _LC_No.LC_Amend_BDTValue = _objLCmaster.LC_Amend_BDTValue;
                _LC_No.LC_Total_USDValue = _objLCmaster.LC_Total_USDValue;

                _LC_No.DateofExpiry = _objLCmaster.DateofExpiry;
                _LC_No.TotalLC_ValueUSD = _objLCmaster.TotalLC_ValueUSD;
                _LC_No.TotalLC_ValueBDT = _objLCmaster.TotalLC_ValueBDT;

                _LC_No.LC_Total_BDTValue = _objLCmaster.LC_Total_BDTValue;

                _LC_No.Edit_Date = DateTime.Now;
                _LC_No.Edit_User = _objLCmaster.Edit_User;
                _Context.SaveChanges();
                return 1;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        internal List<LC_MasterLC> GetALLLCById(string OCode)
        {
            try
            {
                var query = (from lc in _Context.LC_MasterLC
                             where lc.OCODE == OCode
                             select lc).OrderBy(x => x.LCNo);
                return query.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        internal List<LC_MasterLC> GetALLLCByType(string OCode)
        {
            try
            {
                var query = (from lc in _Context.LC_MasterLC
                             where lc.OCODE == OCode && lc.LCType == "LC"
                             select lc).OrderBy(x => x.LCNo);
                return query.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        internal List<LC_MasterLC> GetALLLCByContact(string OCode)
        {
            try
            {
                var query = (from lc in _Context.LC_MasterLC
                             where lc.OCODE == OCode && lc.LCType == "Contact"
                             select lc).OrderBy(x => x.LCNo);
                return query.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        internal List<HRM_SubCompany> GetAllSubCompany(string OCode)
        {
            using (var context = new ERPSSL_LCEntities())
            {
                try
                {
                    var query = (from O in context.HRM_SubCompany
                                 where O.OCODE == OCode
                                 select O).OrderBy(x => x.SubCompanyName);
                    return query.ToList();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message.ToString());
                }
            }
        }
        internal List<LC_OrderEntry> GetAllOrderByOcode(string ocode)
        {
            try
            {
                var orderEntryTemp = (from _Oentry in _Context.LC_OrderEntry
                                      where _Oentry.OCODE == ocode
                                      select _Oentry).OrderBy(x => x.OrderEntryID);
                return orderEntryTemp.ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        internal List<RLc> GetAllOrderByShipmentDate(string ocode)
        {
            try
            {


                //var ParamempID = new SqlParameter("@Ocode", OCODE);
                //var ParamempID1 = new SqlParameter("@EmpId", eid);
                //string SP_SQL = "HRM_GetAssignToInfoByEmployeId @Ocode,@EmpId";
                //return (_context.ExecuteStoreQuery<AssignTo>(SP_SQL, ParamempID, ParamempID1)).ToList();    

                using (var _context = new ERPSSL_LCEntities())
                {
                    var ParamempID = new SqlParameter("@OCode", ocode);
                    string SP_SQL = "BH_ShipmentDateWiseOrderList @OCode";
                    return (_context.ExecuteStoreQuery<RLc>(SP_SQL, ParamempID)).ToList();
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal int InsertTaskDetails(LC_Task_Details aLC_Task_Details)
        {
            _Context.LC_Task_Details.AddObject(aLC_Task_Details);
            _Context.SaveChanges();
            return 1;
        }

        internal List<OrderUpdateRepository> GetOrderByOrderNoandOcode(string orderNo, string OCODE)
        {

            var obj = (from ord in _Context.LC_OrderEntry
                       join HROf in _Context.HRM_Office on ord.Office_ID equals HROf.OfficeID
                       join Factr in _Context.LC_Factory on ord.FactoryId equals Factr.FactoryId
                       join MerNa in _Context.HRM_PersonalInformations on ord.EID equals MerNa.EID
                       join MerD in _Context.HRM_DEPARTMENTS on ord.Merch_Dept_Id equals MerD.DPT_ID
                       join Bd in _Context.LC_BuyerDepartment on ord.Merch_Dept_Id equals Bd.BuyerDepartment_Id
                       join Style in _Context.LC_Style_Gender on ord.Gender_Id equals Style.Gender_Id
                       join Qu in _Context.LC_StyleCategor on ord.Style_Category_Id equals Qu.Style_Category_Id
                       join Unt in _Context.Inv_Unit on ord.Unit_Id equals Unt.UnitId
                       join Buy in _Context.Com_Buyer_Setup on ord.Principal_Id equals Buy.Buyer_ID
                       join Session in _Context.LC_Season on ord.SeasonId equals Session.Season_Id
                       join Sty in _Context.LC_Style on ord.StyleId equals Sty.StyleId

                       select new OrderUpdateRepository
                       {
                           OrderEntryID = ord.OrderEntryID,
                           Season_Name = Session.Season_Name,
                           Style = Sty.StyleName,
                           Total_Amount = ord.Total_Amount,
                           Factory_Id = Factr.FactoryName,
                           Office_Id = HROf.OfficeName,
                           EID = MerNa.EID,
                           FullName = MerNa.FirstName ?? "" + " " + (MerNa.LastName ?? "").Trim(),
                           DepartmentId = MerD.DPT_ID,
                           DepartmentName = MerD.DPT_NAME,

                           Buyer_DepartmentId = ord.Buyer_DepartmentId,
                           Office_ID = ord.Office_ID,
                           Merch_Dept_Id = ord.Merch_Dept_Id,
                           Principal_Id = ord.Principal_Id,
                           Buyer_Name = ord.Buyer_Name,
                           FactoryId = ord.FactoryId,
                           StyleId = ord.StyleId,
                           Style_Category_Id = ord.Style_Category_Id,
                           CommissionPersent = ord.CommissionPersent,
                           TotalCommission = ord.TotalCommission,
                           Yarn_Fabrication = ord.Yarn_Fabrication,
                           FOB_Port = ord.FOB_Port,
                           Season_Id = ord.SeasonId,
                           Gender_Id = ord.Gender_Id,
                           UnitId = ord.Unit_Id,

                           BuyerDepartmetn = Bd.BuyerDepartment_Name,
                           Buyer_Id = Buy.Buyer_Name,
                           Category_Id = Qu.Style_Category_Name,
                           Style_Description = ord.Style_Description,
                           Trading = ord.Trading,
                           Quotation_Terms = ord.Quotation_Terms,
                           Freight = ord.Freight,
                           Shipment_Mode = ord.Shipment_Mode,
                           PaymentTerms = ord.Payment_Terms,
                           CountryOf_Production = ord.Countryof_Production,
                           Garment_Maker = ord.Garments_Maker,
                           FobQty = ord.FobQty,
                           Currency = ord.Currency,
                           OrderQuantity = ord.OrderQuantity,
                           TotalAmount = ord.Total_Amount,
                           Unit_Id = Unt.UnitName,


                       });
            return obj.ToList();

            //HRM_Regions Region = _context.HRM_Regions.First(x => x.RegionID == RegionId);
            //return Region;  

            //List<LC_OrderEntry> Orders = (from ord in _Context.LC_OrderEntry
            //                              where ord.OCODE == OCODE && ord.OrderNo == orderNo
            //                              select ord).OrderBy(x => x.OrderEntryID).ToList<LC_OrderEntry>();
            //return Orders;
        }

        internal List<LC_Task_Details> GetTaskDetailsByOrderNoandOcode(string orderNo, string OCODE)
        {
            List<LC_Task_Details> Orders = (from ord in _Context.LC_Task_Details
                                            where ord.OCode == OCODE && ord.Order_No == orderNo && ord.Status == "Pending"
                                            select ord).OrderBy(x => x.TaskDetails_Id).ToList<LC_Task_Details>();
            return Orders;
        }

        internal int InsertProductionProcces(LC_ProductionDetails _LC_ProductionDetails)
        {
            try
            {
                using (var _context = new ERPSSL_LCEntities())
                {
                    _context.AddToLC_ProductionDetails(_LC_ProductionDetails);
                    _context.SaveChanges();
                    return 1;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        internal List<ItemList> GetductionProccess(string OrderNo)
        {
            //try
            //{
            //    using (var _context = new ERPSSL_LCEntities())
            //    {
            //        return _context.LC_ProductionDetails.Where(x => x.Order_No == OrderNo).ToList();
            //    }
            //}
            //catch (Exception)
            //{

            //    throw;
            //}
            try
            {
                using (var _context = new ERPSSL_LCEntities())
                {

                    return (from l in _context.LC_ProductionDetails
                            //join srv in _context.HRM_SERVICE_CONTRACT on emp.EMP_ID equals srv.EMP_ID
                            join r in _context.HRM_PersonalInformations on l.Responsible_Person equals r.EID
                             into t
                            from a in t.DefaultIfEmpty()
                            where l.Order_No == OrderNo
                            select new ItemList
                            {
                                Status = l.Status,
                                //Responsible_Person = l.Responsible_Person,
                                Responsible_Person = a.FirstName ?? "" + " " + (a.LastName ?? "").Trim(),
                                Schedule_Date = (DateTime)l.Schedule_Date,
                                ProductionProcces_Id = l.ProductionProcces_Id,
                                ProductionProcess = l.ProductionProcess,
                                TergetQty = l.TergetQty,
                                TergetLine = l.TergetLine,
                                DailyProduction = l.DailyProduction,
                                Comments = l.Comments
                            }).ToList();

                    //return (from l in _context.LC_ProductionDetails
                    //        //join srv in _context.HRM_SERVICE_CONTRACT on emp.EMP_ID equals srv.EMP_ID
                    //        join r in _context.LC_ResponsiblePerson on l.Responsible_Person equals r.EID
                    //         into t
                    //        from a in t.DefaultIfEmpty()
                    //        where l.Order_No == OrderNo
                    //        select new ItemList
                    //        {

                    //            //DPT_ID = d.DPT_ID,
                    //            ProductionProcces_Id = l.ProductionProcces_Id,
                    //            ProductionProcess = l.ProductionProcess,
                    //            Status = l.Status,
                    //            Responsible_Person = a.FirstName ?? "" + " " + a.LastName ?? "",
                    //            Schedule_Date = (DateTime)l.Schedule_Date,
                    //            Comments = l.Comments,
                    //            TergetQty = l.TergetQty,
                    //            TergetLine = l.TergetLine,
                    //            DailyProduction = l.DailyProduction
                    //        }).ToList();
                }
            }
            catch (Exception e)
            {
                throw;
            }
        }

        internal bool isOrderExist(string p)
        {
            try
            {
                using (var _context = new ERPSSL_LCEntities())
                {
                    var y = _context.LC_ProductionDetails.Where(x => x.Order_No == p).ToList();
                    if (y.Count > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }


        internal List<ItemList> GetAllPendingTaskByOcode(string ocode)
        {
            try
            {


                //var ParamempID = new SqlParameter("@Ocode", OCODE);
                //var ParamempID1 = new SqlParameter("@EmpId", eid);
                //string SP_SQL = "HRM_GetAssignToInfoByEmployeId @Ocode,@EmpId";
                //return (_context.ExecuteStoreQuery<AssignTo>(SP_SQL, ParamempID, ParamempID1)).ToList();    

                using (var _context = new ERPSSL_LCEntities())
                {
                    var ParamempID = new SqlParameter("@OCode", ocode);
                    string SP_SQL = "BH_PendingOrderNO @OCode";
                    return (_context.ExecuteStoreQuery<ItemList>(SP_SQL, ParamempID)).ToList();
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal bool isTaskOrderExist(string p)
        {
            try
            {
                using (var _context = new ERPSSL_LCEntities())
                {
                    var y = _context.LC_Task_Details.Where(x => x.Order_No == p).ToList();
                    if (y.Count > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        internal int UpdateProductionProcess(LC_ProductionDetails _LC_ProductionDetails, int ID)
        {
            try
            {
                using (var _context = new ERPSSL_LCEntities())
                {
                    var aLC_ProductionDetails = _context.LC_ProductionDetails.FirstOrDefault(x => x.ProductionProcces_Id == ID);

                    aLC_ProductionDetails.Responsible_Person = _LC_ProductionDetails.Responsible_Person;
                    aLC_ProductionDetails.Schedule_Date = _LC_ProductionDetails.Schedule_Date;
                    aLC_ProductionDetails.TergetQty = _LC_ProductionDetails.TergetQty;
                    aLC_ProductionDetails.TergetLine = _LC_ProductionDetails.TergetLine;
                    aLC_ProductionDetails.DailyProduction = _LC_ProductionDetails.DailyProduction;
                    aLC_ProductionDetails.Status = _LC_ProductionDetails.Status;
                    aLC_ProductionDetails.TergetQty = _LC_ProductionDetails.TergetQty;
                    aLC_ProductionDetails.Comments = _LC_ProductionDetails.Comments;
                    aLC_ProductionDetails.EditDate = _LC_ProductionDetails.EditDate;
                    aLC_ProductionDetails.EditUser = _LC_ProductionDetails.EditUser;
                    _context.SaveChanges();
                    return 1;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        internal List<LC_ResponsiblePerson> GetAllResposiblePerson()
        {
            try
            {
                using (var _context = new ERPSSL_LCEntities())
                {
                    return _context.LC_ResponsiblePerson.ToList();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        internal IEnumerable<REmployee> GetResponsiblePerson(string OCODE)
        {
            try
            {
                using (var _context = new ERPSSLHBEntities())
                {
                    var ParamempID = new SqlParameter("@OCODE", OCODE);
                    string SP_SQL = "LC_ResponsiblePersonList @OCODE";
                    return (_context.ExecuteStoreQuery<REmployee>(SP_SQL, ParamempID)).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }


        internal int UpdateTaskDetails(LC_Task_Details aLC_Task_Details, int ID)
        {
            try
            {
                using (var _context = new ERPSSL_LCEntities())
                {
                    var TaskDetails = _context.LC_Task_Details.FirstOrDefault(x => x.TaskDetails_Id == ID);

                    TaskDetails.Responsible_Person = aLC_Task_Details.Responsible_Person;
                    TaskDetails.Schedule_Date = aLC_Task_Details.Schedule_Date;
                    TaskDetails.Status = aLC_Task_Details.Status;
                    TaskDetails.Comments = aLC_Task_Details.Comments;
                    TaskDetails.EditDate = aLC_Task_Details.EditDate;
                    TaskDetails.EditUser = aLC_Task_Details.EditUser;
                    _context.SaveChanges();
                    return 1;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        internal List<ItemList> GetTaskDetailsByOrderNo(string orderNo, string OCODE)
        {
            using (var _context = new ERPSSL_LCEntities())
            {
                return (from l in _context.LC_Task_Details
                        //join srv in _context.HRM_SERVICE_CONTRACT on emp.EMP_ID equals srv.EMP_ID
                        join r in _context.HRM_PersonalInformations on l.Responsible_Person equals r.EID
                         into t
                        from a in t.DefaultIfEmpty()
                        where l.OCode == OCODE && l.Order_No == orderNo
                        select new ItemList
                        {

                            //DPT_ID = d.DPT_ID,
                            TaskDetails_Id = l.TaskDetails_Id,
                            Task = l.Task,
                            Status = l.Status,
                            //Responsible_Person = l.Responsible_Person,
                            Responsible_Person = a.FirstName ?? "" + " " + (a.LastName ?? "").Trim(),
                            Schedule_Date = (DateTime)l.Schedule_Date,
                            Comments = l.Comments,
                        }).ToList();
            }
        }

        internal List<ItemList> GetAllFailOrder(string ocode)
        {
            try
            {
                using (var _context = new ERPSSL_LCEntities())
                {
                    var ParamempID = new SqlParameter("@OCode", ocode);
                    string SP_SQL = "BH_FailedOrderList @OCode";
                    return (_context.ExecuteStoreQuery<ItemList>(SP_SQL, ParamempID)).ToList();
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        internal int SaveLC_DataApprovalSummay(LC_DataApprovalSummay sLC_DataApprovalSummay)
        {
            _Context.LC_DataApprovalSummay.AddObject(sLC_DataApprovalSummay);
            _Context.SaveChanges();
            return 1;

        }

        internal List<LC_DataApprovalSummay> GetApprovallistByEid(string UserEmpId)
        {
            using (var _context = new ERPSSL_LCEntities())
            {
                var PandingList = _context.LC_DataApprovalSummay.Where(x => x.SupervisorEid == UserEmpId).ToList();
                return PandingList;
            }
        }

        internal int UpdateProductionStutas(LC_ProductionStatus _LC_ProductionStatus, int ID)
        {
            try
            {
                using (var _context = new ERPSSL_LCEntities())
                {
                    var aLC_ProductionDetails = _context.LC_ProductionStatus.FirstOrDefault(x => x.ProductionStatus_Id == ID);

                    aLC_ProductionDetails.InputDate = _LC_ProductionStatus.InputDate;
                    aLC_ProductionDetails.DayInput = _LC_ProductionStatus.DayInput;
                    aLC_ProductionDetails.AchievementPercentage = _LC_ProductionStatus.AchievementPercentage;

                    aLC_ProductionDetails.Responsible_Person = _LC_ProductionStatus.Responsible_Person;
                    aLC_ProductionDetails.Status = _LC_ProductionStatus.Status;

                    aLC_ProductionDetails.Comments = _LC_ProductionStatus.Comments;
                    aLC_ProductionDetails.EditDate = _LC_ProductionStatus.EditDate;
                    aLC_ProductionDetails.EditUser = _LC_ProductionStatus.EditUser;
                    _context.SaveChanges();
                    return 1;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        internal ItemList GetProductionProccessData(string orderNo)
        {
            try
            {
                using (var _context = new ERPSSL_LCEntities())
                {
                    var _orderNo = new SqlParameter("@Order", orderNo);

                    string SP_SQL = "LC_Ins_TrnsferDataDetailsToStatus @Order";
                    return (_context.ExecuteStoreQuery<ItemList>(SP_SQL, _orderNo)).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal List<ItemList> GetProductionStatus(string OrderNo)
        {
            try
            {
                using (var _context = new ERPSSL_LCEntities())
                {
                    return (from l in _context.LC_ProductionStatus
                            //join srv in _context.HRM_SERVICE_CONTRACT on emp.EMP_ID equals srv.EMP_ID
                            join r in _context.HRM_PersonalInformations on l.Responsible_Person equals r.EID
                             into t
                            from a in t.DefaultIfEmpty()
                            where l.Order_No == OrderNo
                            select new ItemList
                            {
                                Status = l.Status,
                                //Responsible_Person = l.Responsible_Person,
                                Responsible_Person = a.FirstName ?? "" + " " + (a.LastName ?? "").Trim(),
                                Schedule_Date = (DateTime)l.Schedule_Date,
                                ProductionStatus_Id = l.ProductionStatus_Id,
                                ProductionProcess = l.ProductionProcess,
                                TergetQty = l.TergetQty,
                                TergetLine = l.TergetLine,
                                DailyProduction = l.DailyProduction,
                                InputDate = l.InputDate,
                                DayInput = l.DayInput,
                                AchievementPercentage = l.AchievementPercentage,
                                Comments = l.Comments
                            }).ToList();
                    //return (from l in _context.LC_ProductionStatus
                    //        join r in _context.LC_ResponsiblePerson on l.Responsible_Person equals r.EID
                    //         into t
                    //        from a in t.DefaultIfEmpty()
                    //        where l.Order_No == OrderNo
                    //        select new ItemList
                    //        {
                    //            ProductionStatus_Id = l.ProductionStatus_Id,
                    //            ProductionProcess = l.ProductionProcess,
                    //            Status = l.Status,
                    //            Responsible_Person = a.FirstName ?? "" + " " + a.LastName ?? "",
                    //            Schedule_Date = (DateTime)l.Schedule_Date,
                    //            Comments = l.Comments,
                    //            TergetQty = l.TergetQty,
                    //            TergetLine = l.TergetLine,
                    //            DailyProduction = l.DailyProduction,
                    //            InputDate = l.InputDate,
                    //            DayInput = l.DayInput,
                    //            AchievementPercentage = l.AchievementPercentage
                    //        }).ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal List<LC_ProductionDetails> GetOrderByOrderNo(string orderNo)
        {
            using (var _context = new ERPSSL_LCEntities())
            {
                var OrderList = _context.LC_ProductionDetails.Where(x => x.Order_No == orderNo).ToList();
                return OrderList;
            }
        }

        internal List<LC_ProductionStatus> GetOrderStatusByOrderNo(string orderNo)
        {
            using (var _context = new ERPSSL_LCEntities())
            {
                return _context.LC_ProductionStatus.Where(x => x.Order_No == orderNo).ToList();
                //return OrderList;
            }
        }

        internal int InsertProductionStatus(LC_ProductionStatus _LC_ProductionStatus)
        {
            try
            {
                using (var _context = new ERPSSL_LCEntities())
                {
                    _context.LC_ProductionStatus.AddObject(_LC_ProductionStatus);
                    _context.SaveChanges();
                    return 1;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal int SaveLC_Season(LC_Season _LC_Season)
        {
            try
            {
                _Context.LC_Season.AddObject(_LC_Season);
                _Context.SaveChanges();
                return _LC_Season.Season_Id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal List<LC_Season> GetSeasonList(string OCode)
        {
            try
            {
                var ItemName = (from IName in _Context.LC_Season
                                where IName.OCode == OCode
                                select IName);
                return ItemName.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal int InsertShipment(LC_Shipment sLC_Shipment)
        {
            _Context.LC_Shipment.AddObject(sLC_Shipment);
            _Context.SaveChanges();
            return 1;
        }

        internal List<LC_Shipment> GetShipmentDetails(string ocode)
        {
            try
            {
                var LCShipment = (from _Oentry in _Context.LC_Shipment
                                  where _Oentry.OCODE == ocode
                                  select _Oentry).OrderBy(x => x.Shipment_Id);
                return LCShipment.ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        internal List<BuyingHouseReport> LoadLCOrderGrid(string ocode)
        {
            try
            {
                var LCOrderEntry = (from O in _Context.LC_OrderEntry
                                    join B in _Context.Com_Buyer_Setup on O.Principal_Id equals B.Buyer_ID
                                    join P in _Context.HRM_PersonalInformations on O.EID equals P.EID
                                    join D in _Context.LC_BuyerDepartment on O.Buyer_DepartmentId equals D.BuyerDepartment_Id
                                    join Se in _Context.LC_Season on O.SeasonId equals Se.Season_Id
                                    join sG in _Context.LC_Style_Gender on O.Gender_Id equals sG.Gender_Id
                                    join sC in _Context.LC_StyleCategor on O.Style_Category_Id equals sC.Style_Category_Id
                                    join U in _Context.Inv_Unit on O.Unit_Id equals U.UnitId
                                    join F in _Context.LC_Factory on O.FactoryId equals F.FactoryId
                                    join S in _Context.LC_Style on O.StyleId equals S.StyleId
                                    where O.OCODE == ocode
                                    select new BuyingHouseReport
                                    {
                                        OrderEntryID = O.OrderEntryID,
                                        Order_No = O.OrderNo,
                                        FobQty = O.FobQty,
                                        Payment_Terms = O.Payment_Terms,
                                        OrderQuantity = O.OrderQuantity,
                                        Delivery_Date = O.Delivery_Date,
                                        ShipmentDate = O.ShipmentDate,
                                        Yarn_Fabrication = O.Yarn_Fabrication,
                                        FOB_Port = O.FOB_Port,
                                        Shipment_Mode = O.Shipment_Mode,
                                        Countryof_Production = O.Countryof_Production,
                                        Total_Amount = O.Total_Amount,

                                        Season_Id=Se.Season_Id,
                                        SeasonName = Se.Season_Name,

                                        FactoryId=F.FactoryId,
                                        FactoryName = F.FactoryName,
                                        
                                        Gender_Id=sG.Gender_Id,
                                        Gender = sG.Gender_Name,

                                        UnitId = U.UnitId,
                                        UnitName = U.UnitName,
                                        
                                        Style_Category_Id=sC.Style_Category_Id,
                                        Style_Category = sC.Style_Category_Name,
                                        
                                        EID=P.EID,
                                        FullName = P.FirstName ?? "" + " " + (P.LastName ?? "").Trim(),
                                        
                                        BuyerDepartment_Id=D.BuyerDepartment_Id,
                                        Buyer_Department = D.BuyerDepartment_Name,
                                        
                                        StyleId = S.StyleId,
                                        Style_Description = S.StyleName,
                                        
                                        Buyer_ID = B.Buyer_ID,
                                        Buyer_Name = B.Buyer_Name,
                                        PrincipalName = B.PrincipalName,

                                    });
                return LCOrderEntry.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        internal List<LC_Shipment> GetShipmentDetailsByIdandOcode(string ShipmentId, string OCODE)
        {
            int ShId = Convert.ToInt32(ShipmentId);

            List<LC_Shipment> LShipment = (from ord in _Context.LC_Shipment
                                           where ord.OCODE == OCODE && ord.Shipment_Id == ShId
                                           select ord).OrderBy(x => x.Shipment_Id).ToList<LC_Shipment>();
            return LShipment;
        }

        internal int UpdateShipment(LC_Shipment sLC_Shipment, int id)
        {
            try
            {
                LC_Shipment obj = _Context.LC_Shipment.First(x => x.Shipment_Id == id);

                obj.LC_No = sLC_Shipment.LC_No;
                obj.LC_ReceiveDate = sLC_Shipment.LC_ReceiveDate;
                obj.Feeder_Vessel = sLC_Shipment.Feeder_Vessel;
                obj.FETD = sLC_Shipment.FETD;
                obj.FETA = sLC_Shipment.FETA;
                obj.Actual_Ship_Qty = sLC_Shipment.Actual_Ship_Qty;
                obj.Airway_Bill = sLC_Shipment.Airway_Bill;
                obj.Export_License_No = sLC_Shipment.Export_License_No;
                obj.GSP_Form = sLC_Shipment.GSP_Form;
                obj.Courier_No = sLC_Shipment.Courier_No;
                obj.Debit_Note_No = sLC_Shipment.Debit_Note_No;
                obj.Document_Receive_Date = sLC_Shipment.Document_Receive_Date;
                obj.Actual_FCR_Date = sLC_Shipment.Actual_FCR_Date;
                obj.LC_Date = sLC_Shipment.LC_Date;
                obj.LC_Expiry_Date = sLC_Shipment.LC_Expiry_Date;
                obj.Mother_Vessel = sLC_Shipment.Mother_Vessel;
                obj.METD = sLC_Shipment.METD;
                obj.META = sLC_Shipment.META;
                obj.Invoice_No = sLC_Shipment.Invoice_No;
                obj.Container_No = sLC_Shipment.Container_No;
                obj.Certificate_Of_Origin = sLC_Shipment.Certificate_Of_Origin;
                obj.Commission_Rate = sLC_Shipment.Commission_Rate;
                obj.Courier_Date = sLC_Shipment.Courier_Date;
                obj.Inspection_Certificate_No = sLC_Shipment.Inspection_Certificate_No;
                obj.Packing_List_No = sLC_Shipment.Packing_List_No;
                obj.Others = sLC_Shipment.Others;
                obj.Create_Date = DateTime.Today;
                obj.Create_User = sLC_Shipment.Edit_User;
                obj.OCODE = sLC_Shipment.OCODE;
                _Context.SaveChanges();
                return 1;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal int SaveAmendLog(LC_LCContract_Log _LC_LCContract_Log)
        {
            try
            {
                _Context.LC_LCContract_Log.AddObject(_LC_LCContract_Log);
                _Context.SaveChanges();
                return 1;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        internal List<BuyingHouseReport> GetLCOrderGridByONo(string ocode, string Order_No)
        {
            try
            {
                var LCOrderEntry = (from O in _Context.LC_OrderEntry
                                    join B in _Context.Com_Buyer_Setup on O.Buyer_Name equals B.Buyer_Name
                                    join S in _Context.LC_Style on O.StyleId equals S.StyleId
                                    where O.OCODE == ocode && O.OrderNo == Order_No
                                    select new BuyingHouseReport
                                    {
                                        OrderEntryID = O.OrderEntryID,
                                        Order_No = O.OrderNo,
                                        StyleId = S.StyleId,
                                        Style_Description = S.StyleName,
                                        //Style_Description=O.Style_Description,
                                        Buyer_ID = B.Buyer_ID,
                                        Buyer_Name = B.Buyer_Name,
                                        PrincipalName = B.PrincipalName,
                                        Payment_Terms = O.Payment_Terms,
                                        Countryof_Production = O.Countryof_Production,
                                        OrderQuantity = O.OrderQuantity,
                                        Delivery_Date = O.Delivery_Date,
                                        ShipmentDate = O.ShipmentDate
                                    });
                return LCOrderEntry.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        internal List<BuyingHouseReport> GetLCOrderGridByStyle(string ocode, int StyleId)
        {
            try
            {
                var LCOrderEntry = (from O in _Context.LC_OrderEntry
                                    join B in _Context.Com_Buyer_Setup on O.Principal_Id equals B.Buyer_ID
                                    join S in _Context.LC_Style on O.StyleId equals S.StyleId
                                    where O.OCODE == ocode && O.StyleId == StyleId
                                    select new BuyingHouseReport
                                    {
                                        OrderEntryID = O.OrderEntryID,
                                        Order_No = O.OrderNo,
                                        StyleId = S.StyleId,
                                        Style_Description = S.StyleName,
                                        PrincipalName = B.PrincipalName,
                                        //Style_Description=O.Style_Description,
                                        Buyer_ID = B.Buyer_ID,
                                        Buyer_Name = B.Buyer_Name,
                                        Payment_Terms = O.Payment_Terms,
                                        Countryof_Production = O.Countryof_Production,
                                        OrderQuantity = O.OrderQuantity,
                                        Delivery_Date = O.Delivery_Date,
                                        ShipmentDate = O.ShipmentDate
                                    });
                return LCOrderEntry.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        internal List<BuyingHouseReport> GetLCOrderGridByBuyer(string ocode, int BuyerId)
        {
            try
            {
                var LCOrderEntry = (from O in _Context.LC_OrderEntry
                                    join B in _Context.Com_Buyer_Setup on O.Principal_Id equals B.Buyer_ID
                                    join F in _Context.LC_Factory on O.FactoryId equals F.FactoryId
                                    join S in _Context.LC_Style on O.StyleId equals S.StyleId
                                    where O.OCODE == ocode && O.Principal_Id == BuyerId
                                    select new BuyingHouseReport
                                    {
                                        OrderEntryID = O.OrderEntryID,
                                        Order_No = O.OrderNo,
                                        StyleId = S.StyleId,
                                        Style_Description = S.StyleName,
                                        PrincipalName = B.PrincipalName,
                                        FactoryId = F.FactoryId,
                                        FactoryName = F.FactoryName,
                                        //Style_Description=O.Style_Description,
                                        Buyer_ID = B.Buyer_ID,
                                        Buyer_Name = B.Buyer_Name,
                                        Payment_Terms = O.Payment_Terms,
                                        Countryof_Production = O.Countryof_Production,
                                        OrderQuantity = O.OrderQuantity,
                                        Delivery_Date = O.Delivery_Date,
                                        ShipmentDate = O.ShipmentDate
                                    });
                return LCOrderEntry.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        internal List<BuyingHouseReport> GetLCOrderGridByFactory(string ocode, int FactoryId)
        {
            try
            {
                var LCOrderEntry = (from O in _Context.LC_OrderEntry
                                    join B in _Context.Com_Buyer_Setup on O.Principal_Id equals B.Buyer_ID
                                    join F in _Context.LC_Factory on O.FactoryId equals F.FactoryId
                                    join S in _Context.LC_Style on O.StyleId equals S.StyleId
                                    where O.OCODE == ocode && O.FactoryId == FactoryId
                                    select new BuyingHouseReport
                                    {
                                        OrderEntryID = O.OrderEntryID,
                                        Order_No = O.OrderNo,
                                        StyleId = S.StyleId,
                                        Style_Description = S.StyleName,
                                        PrincipalName = B.PrincipalName,
                                        FactoryId = F.FactoryId,
                                        FactoryName = F.FactoryName,
                                        //Style_Description=O.Style_Description,
                                        Buyer_ID = B.Buyer_ID,
                                        Buyer_Name = B.Buyer_Name,
                                        Payment_Terms = O.Payment_Terms,
                                        Countryof_Production = O.Countryof_Production,
                                        OrderQuantity = O.OrderQuantity,
                                        Delivery_Date = O.Delivery_Date,
                                        ShipmentDate = O.ShipmentDate
                                    });
                return LCOrderEntry.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        internal List<BuyingHouseReport> GetLCOrderGridByPrincipal(string ocode, int PrincipalId)
        {
            try
            {
                var LCOrderEntry = (from O in _Context.LC_OrderEntry
                                    join B in _Context.Com_Buyer_Setup on O.Principal_Id equals B.Buyer_ID
                                    join F in _Context.LC_Factory on O.FactoryId equals F.FactoryId
                                    join S in _Context.LC_Style on O.StyleId equals S.StyleId
                                    where O.OCODE == ocode && O.Principal_Id == PrincipalId
                                    select new BuyingHouseReport
                                    {
                                        OrderEntryID = O.OrderEntryID,
                                        Order_No = O.OrderNo,
                                        StyleId = S.StyleId,
                                        Style_Description = S.StyleName,
                                        PrincipalName = B.PrincipalName,
                                        FactoryId = F.FactoryId,
                                        FactoryName = F.FactoryName,
                                        //Style_Description=O.Style_Description,
                                        Buyer_ID = B.Buyer_ID,
                                        Buyer_Name = B.Buyer_Name,
                                        Payment_Terms = O.Payment_Terms,
                                        Countryof_Production = O.Countryof_Production,
                                        OrderQuantity = O.OrderQuantity,
                                        Delivery_Date = O.Delivery_Date,
                                        ShipmentDate = O.ShipmentDate
                                    });
                return LCOrderEntry.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        internal List<BuyingHouseReport> GetLCOrderGridByOrderNo(int orderId, string OCODE)
        {
            try
            {
                var LCOrderEntry = (from O in _Context.LC_OrderEntry
                                    join B in _Context.Com_Buyer_Setup on O.Principal_Id equals B.Buyer_ID
                                    join P in _Context.HRM_PersonalInformations on O.EID equals P.EID
                                    join D in _Context.LC_BuyerDepartment on O.Buyer_DepartmentId equals D.BuyerDepartment_Id
                                    join Se in _Context.LC_Season on O.SeasonId equals Se.Season_Id
                                    join sG in _Context.LC_Style_Gender on O.Gender_Id equals sG.Gender_Id
                                    join sC in _Context.LC_StyleCategor on O.Style_Category_Id equals sC.Style_Category_Id
                                    join U in _Context.Inv_Unit on O.Unit_Id equals U.UnitId
                                    join F in _Context.LC_Factory on O.FactoryId equals F.FactoryId
                                    join S in _Context.LC_Style on O.StyleId equals S.StyleId
                                    where O.OrderEntryID == orderId && O.OCODE == OCODE
                                    select new BuyingHouseReport
                                    {
                                        OrderEntryID = O.OrderEntryID,
                                        Order_No = O.OrderNo,
                                        FobQty = O.FobQty,
                                        Payment_Terms = O.Payment_Terms,
                                        OrderQuantity = O.OrderQuantity,
                                        Delivery_Date = O.Delivery_Date,
                                        ShipmentDate = O.ShipmentDate,
                                        Yarn_Fabrication = O.Yarn_Fabrication,
                                        FOB_Port = O.FOB_Port,
                                        Shipment_Mode = O.Shipment_Mode,
                                        Countryof_Production = O.Countryof_Production,
                                        Total_Amount = O.Total_Amount,

                                        Season_Id = Se.Season_Id,
                                        SeasonName = Se.Season_Name,

                                        FactoryId = F.FactoryId,
                                        FactoryName = F.FactoryName,

                                        Gender_Id = sG.Gender_Id,
                                        Gender = sG.Gender_Name,

                                        UnitId = U.UnitId,
                                        UnitName = U.UnitName,

                                        Style_Category_Id = sC.Style_Category_Id,
                                        Style_Category = sC.Style_Category_Name,

                                        EID = P.EID,
                                        FullName = P.FirstName ?? "" + " " + (P.LastName ?? "").Trim(),

                                        BuyerDepartment_Id = D.BuyerDepartment_Id,
                                        Buyer_Department = D.BuyerDepartment_Name,

                                        StyleId = S.StyleId,
                                        Style_Description = S.StyleName,

                                        Buyer_ID = B.Buyer_ID,
                                        Buyer_Name = B.Buyer_Name,
                                        PrincipalName = B.PrincipalName,
                                    });
                return LCOrderEntry.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }
    }
}
using ERPSSL.Commercial.DAL.Repository;
using ERPSSL.LC.DAL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace ERPSSL.Commercial.DAL
{
    public class CreateInvoiceDAL
    {
        private ERPSSL_LCEntities _Context = new ERPSSL_LCEntities();

        internal List<Inv_Unit> GetAllUnit(DropDownList ddlReqUnit, string OCode)
        {
            try
            {
                var ItemName = (from IName in _Context.Inv_Unit
                                select IName);
                return ItemName.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal int UpdateInvoiceTemp(List<LC_Invoice_CreateTemp> _LC_Invoice_CreateTemp)
        {
            try
            {
                using (var _Context = new ERPSSL_LCEntities())
                {
                    foreach (LC_Invoice_CreateTemp aitem in _LC_Invoice_CreateTemp)
                    {
                        LC_Invoice_CreateTemp InvoiceT = new LC_Invoice_CreateTemp();
                        InvoiceT.InvoiceNo = aitem.InvoiceNo;
                        InvoiceT.InvoiceDate = aitem.InvoiceDate;
                        InvoiceT.BayerId = aitem.BayerId;
                        InvoiceT.Consignee = aitem.Consignee;
                        InvoiceT.NotifyParty = aitem.NotifyParty;
                        InvoiceT.EXPNo = aitem.EXPNo;
                        InvoiceT.EXPDate = aitem.EXPDate;
                        InvoiceT.LCNo = aitem.LCNo;
                        InvoiceT.LCDate = aitem.LCDate;
                        InvoiceT.IssuingBank = aitem.IssuingBank;
                        InvoiceT.DeliveryAddress = aitem.DeliveryAddress;
                        InvoiceT.OriginatedCountry = aitem.OriginatedCountry;
                        InvoiceT.Destination = aitem.Destination;
                        InvoiceT.MarksNumbers = aitem.MarksNumbers;
                        InvoiceT.ContainerNo = aitem.ContainerNo;
                        InvoiceT.BuyingDept = aitem.BuyingDept;
                        InvoiceT.NoKindofPackages = aitem.NoKindofPackages;
                        InvoiceT.Remarks = aitem.Remarks;
                        InvoiceT.Season = aitem.Season;
                        InvoiceT.OrderNo = aitem.OrderNo;
                        InvoiceT.Article = aitem.Article;
                        InvoiceT.ColorSpecification = aitem.ColorSpecification;
                        InvoiceT.Style = aitem.Style;
                        InvoiceT.OrderQty = aitem.OrderQty;
                        InvoiceT.CAT_No = aitem.CAT_No;
                        InvoiceT.H_S_Code = aitem.H_S_Code;
                        InvoiceT.OrderQty = aitem.OrderQty;
                        InvoiceT.UnitId = aitem.UnitId;
                        InvoiceT.UnitPrice = aitem.UnitPrice;
                        InvoiceT.Currency_Type = aitem.Currency_Type;
                        InvoiceT.Total = aitem.Total;
                        InvoiceT.CreateUser = aitem.CreateUser;
                        InvoiceT.CreateDate = aitem.CreateDate;
                        InvoiceT.OCode = aitem.OCode;

                        _Context.LC_Invoice_CreateTemp.AddObject(InvoiceT);
                        _Context.SaveChanges();
                    }
                    return 1;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal List<LC_Invoice_CreateTemp> GetLCCreateInvoiceTemp(string InvoiceNo)
        {
            try
            {
                var ItemName = (from IC in _Context.LC_Invoice_CreateTemp
                                where IC.InvoiceNo == InvoiceNo
                                select IC);
                return ItemName.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal int Insert(string InvoiceNo)
        {
            try
            {
                var ParamempID = new SqlParameter("@InvoiceNo", InvoiceNo);
                string SP_SQL = "LC_CreateInvoiceTransfer @InvoiceNo";
                _Context.ExecuteStoreCommand(SP_SQL, ParamempID);
                return 1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal int Insert(string InvoiceNo, double LessBonusP, double LescPCRP, double LessBonusT, double LescPCRT, double GrandTotal, double TotalCtns, double netWgt, double grossWgt, double CubicCbm, string InvoiceAutoCode)
        {
            try
            {
                var _InvoiceNo = new SqlParameter("@InvoiceNo", InvoiceNo);
                var _LessBonusP = new SqlParameter("@LessBonusP", LessBonusP);

                var _LescPCRP = new SqlParameter("@LescPCRP", LescPCRP);
                var _LessBonusT = new SqlParameter("@LessBonusT", LessBonusT);

                var _LescPCRT = new SqlParameter("@LescPCRT", LescPCRT);
                var _GrandTotal = new SqlParameter("@GrandTotal", GrandTotal);

                var _GrossWgt = new SqlParameter("@GrossWgt", grossWgt);
                var _NetWgt = new SqlParameter("@NetWgt", netWgt);

                var _totalCtn = new SqlParameter("@TotalCtns", TotalCtns);
                var _CubicM = new SqlParameter("@CubicCbm", CubicCbm);

                var _InvoiceAutoCode = new SqlParameter("@InvoiceAotuCode", InvoiceAutoCode);
                string SP_SQL = "LC_CreateInvoiceTransfer @InvoiceNo, @LessBonusP, @LescPCRP, @LessBonusT, @LescPCRT, @GrandTotal,@GrossWgt,@NetWgt,@TotalCtns,@CubicCbm, @InvoiceAotuCode";
                _Context.ExecuteStoreCommand(SP_SQL, _InvoiceNo, _LessBonusP, _LescPCRP, _LessBonusT, _LescPCRT, _GrandTotal, _GrossWgt, _NetWgt, _totalCtn, _CubicM, _InvoiceAutoCode);
                return 1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal List<Com_InvoiceR> GetLCArticalByOrderNo(int style_Id, string OrderNo, string OCode)
        {
            try
            {
                var ItemName = (from Sz in _Context.LC_Size
                                join IName in _Context.LC_OrderEntry on Sz.OrderNo equals IName.OrderEntryID
                                join st in _Context.LC_Style on Sz.StyleNo equals st.StyleId
                                join Co in _Context.LC_Color on Sz.ColorID equals Co.ColorId
                                join Gi in _Context.LC_GmtItem on Sz.GMTItem equals Gi.GmtItem_Id
                                where Sz.StyleNo == style_Id && IName.OrderNo == OrderNo && Sz.OCode == OCode
                                select new Com_InvoiceR
                                {
                                    OrderNo = IName.OrderNo,

                                    SizeId=Sz.Size_Id,
                                    Article = Sz.Articale,
                                    Price = Sz.Price,
                                    Qty = Sz.Qty,
                                    Size = Sz.Size,
                                    TotalAmount = Sz.TotalAmount,

                                    colorId=Co.ColorId,
                                    Color=Co.ColorName,

                                    ItemId=Gi.GmtItem_Id,
                                    ItemName=Gi.Gmt_Name,

                                    ColorSpecification = st.Specification,
                                    Style = st.StyleName,
                                    orderQuntity = IName.OrderQuantity,
                                    H_S_Code = st.HS_Code
                                }).ToList();
                return ItemName;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal List<Com_InvoiceR> GetInvoiceReport(string InvoiceAutoCode, string OCode)
        {
            try
            {
                using (var _context = new ERPSSL_LCEntities())
                {
                    var _InvoiceAutoCode = new SqlParameter("@InvoiceAutoCode", InvoiceAutoCode);
                    var _OCode = new SqlParameter("@OCode", OCode);
                    string SP_SQL = "Com_Rpt_CommercialInvoice @InvoiceAutoCode,@OCode";
                    return (_context.ExecuteStoreQuery<Com_InvoiceR>(SP_SQL, _InvoiceAutoCode, _OCode)).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }
    }
}
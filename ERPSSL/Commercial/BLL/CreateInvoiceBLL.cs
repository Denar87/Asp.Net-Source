using ERPSSL.Commercial.DAL;
using ERPSSL.Commercial.DAL.Repository;
using ERPSSL.LC.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace ERPSSL.Commercial.BLL
{
    public class CreateInvoiceBLL
    {
        CreateInvoiceDAL _CreateInvoiceDAL = new CreateInvoiceDAL();
        internal List<Inv_Unit> GetAllUnit(DropDownList ddlReqUnit, string OCode)
        {
            return _CreateInvoiceDAL.GetAllUnit(ddlReqUnit, OCode);
        }

        internal int UpdateInvoiceTemp(List<LC_Invoice_CreateTemp> _LC_Invoice_CreateTemp)
        {
            return _CreateInvoiceDAL.UpdateInvoiceTemp(_LC_Invoice_CreateTemp);
        }

        internal List<LC_Invoice_CreateTemp> GetLCCreateInvoiceTemp(string InvoiceNo)
        {
            return _CreateInvoiceDAL.GetLCCreateInvoiceTemp(InvoiceNo);
        }

        internal int Insert(string InvoiceNo, double LessBonusP, double LescPCRP, double LessBonusT, double LescPCRT, double GrandTotal,double TotalCtns,double netWgt,double grossWgt,double CubicCbm, string InvoiceAutoCode)
        {
            return _CreateInvoiceDAL.Insert(InvoiceNo, LessBonusP, LescPCRP, LessBonusT, LescPCRT, GrandTotal,TotalCtns,netWgt,grossWgt,CubicCbm, InvoiceAutoCode);
        }

        internal List<Com_InvoiceR> GetLCArticalByOrderNo(int style_Id ,string OrderNo, string OCode)
        {
            return _CreateInvoiceDAL.GetLCArticalByOrderNo( style_Id ,OrderNo, OCode);
        }

        internal string GenerateNewInvoiveCodePerSecond()
        {
            try
            {
                var Year = DateTime.Now.ToString("yy");
                var Month = DateTime.Now.Month;
                var Day = DateTime.Now.Day;
                var min = DateTime.Now.Minute;
                var Sec = DateTime.Now.Second;
                int count = 0;
                string InvoiceCode = null;
                InvoiceCode = "CR-" + Year + "" + Month + "" + Day + "" + min + "" + Sec;
                InvoiceCode += (count + 1).ToString();
                return InvoiceCode;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        internal List<Com_InvoiceR> GetInvoiceReport(string InvoiceAutoCode, string OCode)
        {
            return _CreateInvoiceDAL.GetInvoiceReport(InvoiceAutoCode, OCode);
        }
    }
}
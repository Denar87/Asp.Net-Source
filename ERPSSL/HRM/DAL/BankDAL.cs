using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using ERPSSL.INV.DAL;

namespace ERPSSL.HRM.DAL
{
    public class BankDAL
    {
        ERPSSLHBEntities _context = new ERPSSLHBEntities();
        DataAccessEX ado = new DataAccessEX();
        string conn = ConfigurationManager.ConnectionStrings["ERPSSLADO"].ConnectionString;

        internal int BankInfoSave(HRM_BankInfo bankObj)
        {
            _context.HRM_BankInfo.AddObject(bankObj);
            _context.SaveChanges();
            return 1;

        }

        internal List<HRM_BankInfo> GetBankInfo(string employeeid, string Ocode)
        {
            try
            {

                var query = (from ex in _context.HRM_BankInfo
                             where ex.EID == employeeid && ex.OCODE == Ocode
                             select ex).OrderBy(x => x.BankInfoId);


                return query.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        internal int UpdateBankInfo(string employeeid, HRM_BankInfo bankInfoObj)
        {
            HRM_BankInfo obj = _context.HRM_BankInfo.First(x => x.EID == employeeid);
            obj.BankName = bankInfoObj.BankName;
            obj.AccountNo = bankInfoObj.AccountNo;
            obj.MobileNo = bankInfoObj.MobileNo;
            obj.MobileBankName = bankInfoObj.MobileBankName;
            obj.Branch = bankInfoObj.Branch;
            obj.Address = bankInfoObj.Address;
            obj.EDIT_USER = bankInfoObj.EDIT_USER;
            obj.EDIT_DATE = bankInfoObj.EDIT_DATE;
            _context.SaveChanges();
            return 1;
        }

        internal int DeletedEmployeeBankInfoLog(HRM_BankInfo_Delete_Log bankDelObj)
        {
            using (var context = new ERPSSLHBEntities())
            {
                context.HRM_BankInfo_Delete_Log.AddObject(bankDelObj);
                context.SaveChanges();
                return 1;
            }
        }

        internal void DeleteEmployeeBankInfo(string employee)
        {
            using (var context = new ERPSSLHBEntities())
            {
                HRM_BankInfo ObjDel = (from b in context.HRM_BankInfo
                                       where b.EID == employee
                                       select b).FirstOrDefault();
                context.HRM_BankInfo.DeleteObject(ObjDel);
                context.SaveChanges();
            }
        }
    }
}
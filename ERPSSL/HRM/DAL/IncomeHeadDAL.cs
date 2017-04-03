using ERPSSL.HRM.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPSSL.HRM.DAL
{
    public class IncomeHeadDAL
    {
        ERPSSLHBEntities _context = new ERPSSLHBEntities();
        internal int SaveIncomeHeader(HRM_IncomeHeader _IncomeHeader)
        {

            _context.HRM_IncomeHeader.AddObject(_IncomeHeader);
            _context.SaveChanges();
            return 1;

        }



        internal List<HRM_IncomeHeader> GetIncomeHead(string OCODE)
        {

            try
            {
                var query = (from lev in _context.HRM_IncomeHeader
                             where lev.OCODE==OCODE
                             select lev).OrderBy(lev => lev.IncomeHeaderID);

                return query.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        internal HRM_IncomeHeader GetInocmeHeadById(string incomeHeadID, string OCODE)
        {

            try
            {
                int incomeh=Convert.ToInt16(incomeHeadID);
                var query = (from Ic in _context.HRM_IncomeHeader
                             where Ic.OCODE == OCODE && Ic.IncomeHeaderID == incomeh
                             select Ic).FirstOrDefault();

                return query;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        internal int UpdateHeader(HRM_IncomeHeader _IncomeHeader)
        {

            HRM_IncomeHeader obj = _context.HRM_IncomeHeader.First(x => x.IncomeHeaderID == _IncomeHeader.IncomeHeaderID);
            obj.IncomeHeader = _IncomeHeader.IncomeHeader;
            obj.EDIT_DATE = _IncomeHeader.EDIT_DATE;
            obj.EDIT_USER = _IncomeHeader.EDIT_USER;   
           
            _context.SaveChanges();
            return 1;
        }

        internal int SaveIncomeHeaderDetails(HRM_IncomeHeaderDetails _HrmIncomeHeaderDetails)
        {
            _context.HRM_IncomeHeaderDetails.AddObject(_HrmIncomeHeaderDetails);
            _context.SaveChanges();
            return 1;

        }

        internal List<IncomeHeadDetailsV> GetIncomeHeaderDetails(string OCODE)
        {

            using (var _context = new ERPSSLHBEntities())
            {
                return (from emp in _context.HRM_IncomeHeaderDetails
                        join r in _context.HRM_IncomeHeader on emp.IncomeHeaderID equals r.IncomeHeaderID
                        where emp.OCODE == OCODE

                        select new IncomeHeadDetailsV
                        {
                           Heaed=r.IncomeHeader,
                           IncomeHeadDetails=emp.IncomeHeaderDetils,
                           InocmeheadDetailsId=emp.IncomeHeaderDetailsID,
                           ChageablePre = (float)emp.ChargeablePar,
                           LessPulss=emp.PlussORLess,
                          
                           ChareableHeaderDetails = (from lev in _context.HRM_IncomeHeaderDetails
                                                     where lev.IncomeHeaderDetailsID == emp.ChargeableDeatils
                                                     select lev.IncomeHeaderDetils).FirstOrDefault()
                        }).ToList();
            }
        }

        internal HRM_IncomeHeaderDetails GetIncomeHeaderDetilsBYId(string IncomeHeaderID, string OCODE)
        {
            int IncomeHeaderDeatislID = Convert.ToInt16(IncomeHeaderID);
            HRM_IncomeHeaderDetails obj = _context.HRM_IncomeHeaderDetails.First(x => x.IncomeHeaderDetailsID == IncomeHeaderDeatislID);
            return obj;
     
        }

        internal int UpdateIncomeHeaderDetails(HRM_IncomeHeaderDetails _HrmIncomeHeaderDetails)
        {

            HRM_IncomeHeaderDetails obj = _context.HRM_IncomeHeaderDetails.First(x => x.IncomeHeaderDetailsID == _HrmIncomeHeaderDetails.IncomeHeaderDetailsID);
            obj.IncomeHeaderDetils = _HrmIncomeHeaderDetails.IncomeHeaderDetils;
            obj.IncomeHeaderID = _HrmIncomeHeaderDetails.IncomeHeaderID;
            obj.EDIT_USER = _HrmIncomeHeaderDetails.EDIT_USER;
            obj.EDIT_DATE = _HrmIncomeHeaderDetails.EDIT_DATE;
            _context.SaveChanges();
            return 1;

        }

        internal List<HRM_IncomeHeaderDetails> GetChargeableDetails(string OCODE)
        {
            try
            {
                var query = (from lev in _context.HRM_IncomeHeaderDetails
                             where lev.OCODE == OCODE
                             select lev);

                return query.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }

        }
    }
}
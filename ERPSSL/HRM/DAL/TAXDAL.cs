using ERPSSL.HRM.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPSSL.HRM.DAL
{
    public class TAXDAL
    {
        ERPSSLHBEntities _context = new ERPSSLHBEntities();
        internal int TAXTypeSave(HRM_LiabilityType _TaxLiabilityType)
        {
            _context.HRM_LiabilityType.AddObject(_TaxLiabilityType);
            _context.SaveChanges();
            return 1;

        }

        internal List<HRM_LiabilityType> GetTaxConfig(string Ocode)
        {
            try
            {

                var query = (from ex in _context.HRM_LiabilityType
                             where ex.OCODE == Ocode
                             select ex);


                return query.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        internal HRM_LiabilityType getTaxTypeByTaxIdandocode(string txttypeId, string OCODE)
        {
            try
            {
                int txttypId = Convert.ToInt16(txttypeId);
                var query = (from lt in _context.HRM_LiabilityType
                             where lt.TAXTypeAutoID == txttypId && lt.OCODE == OCODE
                             select lt).FirstOrDefault();


                return query;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }

        }

        internal int TAXTypeUpdate(HRM_LiabilityType _TaxLiabilityType)
        {
            HRM_LiabilityType obj = _context.HRM_LiabilityType.First(x => x.TAXTypeAutoID == _TaxLiabilityType.TAXTypeAutoID);
            obj.Type = _TaxLiabilityType.Type;
            obj.EDIT_USER = _TaxLiabilityType.EDIT_USER;
            obj.EDIT_DATE = _TaxLiabilityType.EDIT_DATE;
            _context.SaveChanges();
            return 1;

        }

        internal int TAXLiabilitySave(HRM_TAXLiabilityConfig _hrmtabliabilityconfig)
        {
            _context.HRM_TAXLiabilityConfig.AddObject(_hrmtabliabilityconfig);
            _context.SaveChanges();
            return 1;

        }

        internal List<TaxLiabilityConfigV> GetTaxLibilityConfig(string Ocode)
        {

            using (var _context = new ERPSSLHBEntities())
            {
                return (from emp in _context.HRM_TAXLiabilityConfig
                        join r in _context.HRM_LiabilityType on emp.TAXTypeAutoID equals r.TAXTypeAutoID


                        where emp.OCODE == Ocode
                        select new TaxLiabilityConfigV
                        {
                            taxLiabilityconfiID = emp.TAXLiabilityConfigID,
                            IncomeFrom = (decimal)emp.IncomeFrom,
                            IncomeTo = (decimal)emp.IncomeTo,
                            OFtax = emp.OfTax,
                            Type = r.Type
                        }).ToList();
            }
        }

        internal HRM_TAXLiabilityConfig getTaxConfigInfoById(string txtconfid, string OCODE)
        {
            try
            {
                int txtconfiId = Convert.ToInt16(txtconfid);
                var query = (from lt in _context.HRM_TAXLiabilityConfig
                             where lt.TAXLiabilityConfigID == txtconfiId && lt.OCODE == OCODE
                             select lt).FirstOrDefault();


                return query;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }

        }

        internal int TAXLiabilityUpdatee(HRM_TAXLiabilityConfig _hrmtabliabilityconfig)
        {

            HRM_TAXLiabilityConfig obj = _context.HRM_TAXLiabilityConfig.First(x => x.TAXLiabilityConfigID == _hrmtabliabilityconfig.TAXLiabilityConfigID);
            obj.TAXTypeAutoID = _hrmtabliabilityconfig.TAXTypeAutoID;
            obj.IncomeFrom = _hrmtabliabilityconfig.IncomeFrom;
            obj.IncomeTo = _hrmtabliabilityconfig.IncomeTo;
            obj.OfTax = _hrmtabliabilityconfig.OfTax;
            obj.EDIT_USER = _hrmtabliabilityconfig.EDIT_USER;
            obj.EDIT_DATE = _hrmtabliabilityconfig.EDIT_DATE;
            _context.SaveChanges();
            return 1;


        }

        internal int SaveTaxPFApplicableList(List<HRM_TAXPFApplicable> taxPfapplicables)
        {

            foreach (HRM_TAXPFApplicable aitem in taxPfapplicables)
            {
                _context.HRM_TAXPFApplicable.AddObject(aitem);
                _context.SaveChanges();
            }
            return 1;
        }

        internal List<HRM_Pay_Salary_Tax> Get_Salary_Tax_ByEIDandDate(string EID, string month, int year)
        {
            try
            {
                using (var _context = new ERPSSLHBEntities())
                {
                    var result = (from em in _context.HRM_Pay_Salary_Tax
                                  where (em.EID == EID && em.Tax_Month == month && em.Tax_Year == year)
                                  select em).OrderBy(x => x.EID);

                    return result.ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }


    }
}
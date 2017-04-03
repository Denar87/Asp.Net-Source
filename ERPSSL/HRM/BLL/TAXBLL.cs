using ERPSSL.HRM.DAL;
using ERPSSL.HRM.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPSSL.HRM.BLL
{
    public class TAXBLL
    {
        TAXDAL _taxdal = new TAXDAL();
        internal int TAXTypeSave(HRM_LiabilityType _TaxLiabilityType)
        {

            return _taxdal.TAXTypeSave(_TaxLiabilityType);
        }

        internal List<HRM_LiabilityType> GetTaxConfig(string Ocode)
        {
            return _taxdal.GetTaxConfig(Ocode);
        }

        internal HRM_LiabilityType getTaxTypeByTaxIdandocode(string txttypeId, string OCODE)
        {
            return _taxdal.getTaxTypeByTaxIdandocode(txttypeId, OCODE);

        }

        internal int TAXTypeUpdate(HRM_LiabilityType _TaxLiabilityType)
        {
            return _taxdal.TAXTypeUpdate(_TaxLiabilityType);

        }

        internal int TAXLiabilitySave(HRM_TAXLiabilityConfig _hrmtabliabilityconfig)
        {
            return _taxdal.TAXLiabilitySave(_hrmtabliabilityconfig);

        }

        internal List<TaxLiabilityConfigV> GetTaxLibilityConfig(string Ocode)
        {
            return _taxdal.GetTaxLibilityConfig(Ocode);
        }

        internal HRM_TAXLiabilityConfig getTaxConfigInfoById(string txtconfid, string OCODE)
        {

            return _taxdal.getTaxConfigInfoById(txtconfid, OCODE);
        }

        internal int TAXLiabilityUpdatee(HRM_TAXLiabilityConfig _hrmtabliabilityconfig)
        {
            return _taxdal.TAXLiabilityUpdatee(_hrmtabliabilityconfig);
        }

        internal int SaveTaxPFApplicableList(List<HRM_TAXPFApplicable> taxPfapplicables)
        {
            return _taxdal.SaveTaxPFApplicableList(taxPfapplicables);
        }

        internal List<HRM_Pay_Salary_Tax> Get_Salary_Tax_ByEIDandDate(string EID, string month, int year)
        {
            return _taxdal.Get_Salary_Tax_ByEIDandDate(EID, month, year);
        }

    }
}
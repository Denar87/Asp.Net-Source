using ERPSSL.HRM.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPSSL.HRM.BLL
{
    public class PFContributionBLL
    {
        PFContributionDAL _pfContributionDal = new PFContributionDAL();
        internal int SavePFContribution(HRM_PFConfiguration _hrmPfcontrinbution)
        {
            return _pfContributionDal.SavePFContribution(_hrmPfcontrinbution);
        }

        internal List<HRM_PFConfiguration> GetPFContributionList(string ocode)
        {
            return _pfContributionDal.GetPFContributionList(ocode);
        }

        internal HRM_PFConfiguration getPFContributionByIDandocode(string txtbcContributionID, string OCODE)
        {
            return _pfContributionDal.getPFContributionByIDandocode(txtbcContributionID, OCODE);
        }

        internal int UpdatePFContribution(HRM_PFConfiguration _hrmPfcontrinbution)
        {
            return _pfContributionDal.UpdatePFContribution(_hrmPfcontrinbution);
        }
    }
}
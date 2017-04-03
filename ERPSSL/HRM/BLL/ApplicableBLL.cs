using ERPSSL.HRM.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPSSL.HRM.BLL
{
    public class ApplicableBLL
    {
        ApplicableDAL _applicabledal = new ApplicableDAL();
        internal int SaveApplicable(List<HRM_Applicable_PersonalStatus> _applicable)
        {
            return _applicabledal.SaveApplicable(_applicable);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPSSL.HRM.DAL
{
    public class PFContributionDAL
    {
        ERPSSLHBEntities _context = new ERPSSLHBEntities();
        internal int SavePFContribution(HRM_PFConfiguration _hrmPfcontrinbution)
        {
            _context.HRM_PFConfiguration.AddObject(_hrmPfcontrinbution);
            _context.SaveChanges();
            return 1;

        }

        internal List<HRM_PFConfiguration> GetPFContributionList(string ocode)
        {

            try
            {

                var query = (from ex in _context.HRM_PFConfiguration
                             where ex.OCODE == ocode
                             select ex);


                return query.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        internal HRM_PFConfiguration getPFContributionByIDandocode(string txtbcContributionID, string OCODE)
        {
            try
            {
                int txtcontriunbtionId = Convert.ToInt16(txtbcContributionID);
                var query = (from lt in _context.HRM_PFConfiguration
                             where lt.PFContributionID == txtcontriunbtionId && lt.OCODE == OCODE
                             select lt).FirstOrDefault();


                return query;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        internal int UpdatePFContribution(HRM_PFConfiguration _hrmPfcontrinbution)
        {
            HRM_PFConfiguration obj = _context.HRM_PFConfiguration.First(x => x.PFContributionID == _hrmPfcontrinbution.PFContributionID);
            obj.OwnerContribution = _hrmPfcontrinbution.OwnerContribution;
            obj.PFEmployee = _hrmPfcontrinbution.PFEmployee;            
            obj.EDIT_USER = _hrmPfcontrinbution.EDIT_USER;
            obj.EDIT_DATE = _hrmPfcontrinbution.EDIT_DATE;
            _context.SaveChanges();
            return 1;
        }
    }
}
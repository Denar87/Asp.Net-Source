using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPSSL.HRM.DAL
{
    public class ReasonTypeDAL
    {
        private ERPSSLHBEntities _context = new ERPSSLHBEntities();
        
        internal int InsertReasonType(HRM_ReasonType reasonTypeObj)
        {
            
            try
            {
                _context.HRM_ReasonType.AddObject(reasonTypeObj);
                _context.SaveChanges();
                return 1;
            }
            catch (Exception)
            {
                throw;
            }
        }

        internal List<HRM_ReasonType> GetReasonType(string Ocode)
        {
            try
            {
                var query = (from rsn in _context.HRM_ReasonType
                             where rsn.OCode == Ocode
                             select rsn).OrderBy(rsn => rsn.ReasonTypeId);

                return query.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        internal List<HRM_ReasonType> GeReasonTypes(string reasonTypeId, string OCODE)
        {
            try
            {
                int eId = Convert.ToInt32(reasonTypeId);
                //HRM_ReasonType obj = _context.HRM_ReasonType.First(x => x.ReasonTypeId == eId);
                var query = (from rsn in _context.HRM_ReasonType
                             where rsn.OCode == OCODE && rsn.ReasonTypeId == eId
                             select rsn).OrderBy(rsn => rsn.ReasonTypeId);

                return query.ToList();



            }
            catch (Exception)
            {

                throw;
            }
        }

        internal int UpdateReasonType(HRM_ReasonType reasonTypeObj, int leaveTypeId)
        {
            HRM_ReasonType obj = _context.HRM_ReasonType.First(x => x.ReasonTypeId == leaveTypeId);
            obj.ReasonType = reasonTypeObj.ReasonType;
            obj.Edit_Date = reasonTypeObj.Edit_Date;
            obj.Edit_User = reasonTypeObj.Edit_User;            
            _context.SaveChanges();
            return 1;
        }
    }
}
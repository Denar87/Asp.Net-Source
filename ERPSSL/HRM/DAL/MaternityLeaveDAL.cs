using ERPSSL.HRM.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ERPSSL.HRM.DAL
{
    public class MaternityLeaveDAL
    {
        ERPSSLHBEntities _context = new ERPSSLHBEntities();
        internal int SaveMaternityLeaveInfo(HRM_MaternityLeave maternityLeave)
        {
            _context.HRM_MaternityLeave.AddObject(maternityLeave);
            _context.SaveChanges();
            return 1;

        }

        internal List<MaternityLeaveR> GetMaternityLeaveInfoForList(string eid, string currentYear, string OCODE)
        {
            try
            {
                using (var _context = new ERPSSLHBEntities())
                {
                    var ParamempID = new SqlParameter("@Eid", eid);
                    var ParamempID1 = new SqlParameter("@OCODE", OCODE);
                    var ParamempID2 = new SqlParameter("@currentYear", currentYear);
                    string SP_SQL = "HRM_GetMaternityLeaveByEmployeeId @Eid,@OCODE,@currentYear";
                    return (_context.ExecuteStoreQuery<MaternityLeaveR>(SP_SQL, ParamempID, ParamempID1, ParamempID2)).ToList();
                }
            }
            catch (Exception)
            {

                throw;
            }


        }

        internal List<HRM_MaternityLeave> GetMaternityDetailsByEmployeeId(string employeeId, string OCODE)
        {
            try
            {

                var query = (from ex in _context.HRM_MaternityLeave
                             where ex.EID == employeeId && ex.OCODE == OCODE
                             select ex);


                return query.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }

        }

        internal int DisApproveMaternityLeaveInfo(HRM_MaternityLeave maternityLeave)
        {
            HRM_MaternityLeave mobj = _context.HRM_MaternityLeave.First(x => x.EID == maternityLeave.EID);
            mobj.StatusDate = maternityLeave.StatusDate;
            mobj.DisApproveStatus = maternityLeave.DisApproveStatus;
           
            _context.SaveChanges();
            return 1;

        }

        internal int ApproveMaternityLeaveLeaveInfo(HRM_MaternityLeave maternityLeave)
        {
            HRM_MaternityLeave mobj = _context.HRM_MaternityLeave.First(x => x.EID == maternityLeave.EID);
            mobj.StatusDate = maternityLeave.StatusDate;
            mobj.ApproveStatus = maternityLeave.ApproveStatus;

            _context.SaveChanges();
            return 1;
        }
    }
}
using ERPSSL.HRM.DAL;
using ERPSSL.HRM.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPSSL.HRM.BLL
{
    public class MaternityLeaveBLL
    {
        MaternityLeaveDAL maternityLavedal = new MaternityLeaveDAL();
        internal int SaveMaternityLeaveInfo(HRM_MaternityLeave maternityLeave)
        {
            return maternityLavedal.SaveMaternityLeaveInfo(maternityLeave);
        }

        internal List<MaternityLeaveR> GetMaternityLeaveInfoForList(string eid, string currentYear, string OCODE)
        {
            return maternityLavedal.GetMaternityLeaveInfoForList(eid, currentYear, OCODE);

        }

        internal List<HRM_MaternityLeave> GetMaternityDetailsByEmployeeId(string employeeId, string OCODE)
        {
            return maternityLavedal.GetMaternityDetailsByEmployeeId(employeeId, OCODE);
        }

        internal int DisApproveMaternityLeaveInfo(HRM_MaternityLeave maternityLeave)
        {
            return maternityLavedal.DisApproveMaternityLeaveInfo(maternityLeave);
        }

        internal int ApproveMaternityLeaveLeaveInfo(HRM_MaternityLeave maternityLeave)
        {
            return maternityLavedal.ApproveMaternityLeaveLeaveInfo(maternityLeave);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPSSL.AppGateway.BOL
{
    public class LoginBol
    {
        public System.Guid UserID { get; set; }
        public string LoginName { get; set; }
        public string EID { set; get; }
        public string UserRole { set; get; }
        public string User_Level { get; set; }
        public string UserFullName { get; set; }
        public int? RoleID { get; set; }
        public string BranchID { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public string OCode { get; set; }
        public string Company_Code { get; set; }
    }
}
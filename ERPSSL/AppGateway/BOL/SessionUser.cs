using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPSSL.AppGateway.BOL
{
    public class SessionUser
    {
        public Guid UserId { get; set; }
        public string LoginName { get; set; }
        public string UserFullName { get; set; }
        public string BranchID { get; set; }
        public string OCode { get; set; }
        public string PCode { get; set; }
        public string User_Level { get; set; }
        public string RoleId { set; get; }
          
    }
}
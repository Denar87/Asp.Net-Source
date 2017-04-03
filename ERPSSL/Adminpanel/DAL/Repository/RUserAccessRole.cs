using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPSSL.Adminpanel.DAL.Repository
{
    public class RUserAccessRole
    {
        public Int64 UserAccessId { set; get; }
        public Int32 RoleID { set; get; }
        public string RoleName { set; get; }
        public Int32 PageID { set; get; }
        public string pageName { set; get; }
        public Int64 CategoryId { set; get; }
        public string CategoryName { set; get; }
        public Int64 ModuleId { set; get; }
        public string ModuleName { set; get; }
        public bool CanVisit { set; get; }
        public bool CanEdit { set; get; }
        public bool CanDelete { set; get; }
        public bool CanExecute { set; get; }
    }
}
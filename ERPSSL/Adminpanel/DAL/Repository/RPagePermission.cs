using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPSSL.Adminpanel.DAL.Repository
{
    public class RPagePermission
    {
        public int pagePermissionId { set; get; }
        public string RoleName { set; get; }
        public string PageName { set; get; }
        public bool CanVisit { set; get; }
        public bool CanEdit { set; get; }
        public bool CanDelete { set; get; }
        public bool CanExecute { set; get; }
        public string CategoryName { set; get; }
    }
}
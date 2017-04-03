using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPSSL.Adminpanel.DAL.Repository
{
    public class RPage
    {
        public Int64 PageID { set; get; }
        public Int64 ModuleID { set; get; }
        public string ModulName { set; get; }
        public string FeatureName { set; get; }
        public string PageName { set; get; }
        public string PageUrl { set; get; }
        public bool Status { set; get; }
        public Nullable<Int64> PageOrder { set; get; }
    }
}
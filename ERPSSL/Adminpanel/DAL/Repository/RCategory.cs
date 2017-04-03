using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPSSL.Adminpanel.DAL.Repository
{
    public class RCategory
    {
        public string ModuleName { set; get; }
        public string CategoryName { set; get; }
        public int CategoryId { set; get; }
        public int CategoryOrder { set; get; }

        public bool? Status { get; set; }
    }
}
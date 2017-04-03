using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPSSL.BuyingHouse.DAL.Repository
{
    public class StyleSize
    {
        public long Size_Id { get; set; }
        public string Style_No { get; set; }
        public string SizeFrom { get; set; }
        public string SizeTo { get; set; }
        public string type { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPSSL.LC.DAL.Repository
{
    public class Rep_MasterLC
    {
       
        //public string B2BLCNo { get; set; }
        //public string B2BLCNo { get; set; }
        //public string B2BLCNo { get; set; }
        //public string B2BLCNo { get; set; }

        public string SeasonName { get; set; }
        public int MlcID { get; set; }
        public string BayerName { get; set; }
        public string LCNo { get; set; }

        public double? LC_USDValu { get; set; }

        public double? LC_BDTValu { get; set; }

        public double? Qty { get; set; }
    }
}
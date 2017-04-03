using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPSSL.HRM.DAL.Repository
{
    public class TransferR
    {
        public int Id { set; get; }
        public string EID { get; set; }
        public string Name { get; set; }
        public DateTime? TransferDate { get; set; }

        public string firstName { get; set; }

        public string lastName { get; set; }
    }
}
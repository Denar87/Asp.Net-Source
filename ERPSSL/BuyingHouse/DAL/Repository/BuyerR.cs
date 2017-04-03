using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPSSL.BuyingHouse.DAL.Repository
{
    public class BuyerR
    {
        public string Country;

        public int BuyingDepartmentId { get; set; }

        public int Buyer_ID { get; set; }

        public string BuyerDepartment_Name { get; set; }

        public string PrincipalName { get; set; }

        public string Buyer_Name { get; set; }

        public string Address { get; set; }
    }
}
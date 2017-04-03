using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPSSL.INV.DAL.Repository
{
    public class StoreInCharge
    {
        public string Store_fullname { set; get; }
        public string Eid { set; get; }

        public int Store_Id { set; get; }
        public string StoreName { set; get; }
        public string Description { set; get; }
        public string Project_Name { get; set; }
        public string Store_Code { get; set; }

        public int Store_Unit_Id { set; get; }
        public string Store_Unit_Name { set; get; }

        public int ProgramId { get; set; }
        public string programName { get; set; }
        public string Location { get; set; }
    }
}
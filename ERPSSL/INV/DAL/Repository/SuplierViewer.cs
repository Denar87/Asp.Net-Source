using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPSSL.INV.DAL.Repository
{
    public class SuplierViewer
    {
        public int Id { get; set; }
        public int? ProductId { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public decimal? Price { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPSSL.Merchandising.DAL.Repository
{
    public class YarnDeterminationRepo
    {
        public int YarnDeterminationId { get; set; }

        public int FebricNatureId {get;set;}
        public string FebricNature { get; set; }

        public int ColorRangeId	{get;set;}
        public string ColorRange { get; set; }

        public int ConstructionId {get;set;}
        public string Construction { get; set; }

        public string GSM {get;set;}

        public int CompositionId {get;set;}
        public string Composition { get; set; }

        public string Percentage {get;set;}

        public int YarnCountId {get;set;}
        public string YarnCount { get; set; }

        public int YarnCountTypeId	{get;set;}
        public string YarnCountType { get; set; }

        public string StichLength {get;set;}
        public string ProcessLoss { get; set; }

        public decimal Price { get; set; }

        public string unitName { get; set; }

        public int ProductId { get; set; }

        public int UniqueId { get; set; }

        public string ConstructionPercentage { get; set; }
      
    }
}
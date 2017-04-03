using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPSSL.Merchandising.DAL.Repository
{
    public class YarnDeterminationReportRepo
    {
        public int Id {get;set;}

        public int FebricNatureId	{get;set;}
        public string FabricNature { get; set; }

        public int ColorRangeId	{get;set;}
        public string ColorName { get; set; }

        public int ConstructionId	{get;set;}
        public string ConstructionType { get; set; }
        public int ProductId	{get;set;}
        public string GSM	{get;set;}

        public int CompositionId	{get;set;}
        public string Composition { get; set; }

        public string Percentage	{get;set;}
        public int YarnCountId	{get;set;}
        public string Yarn_Count { get; set; }

        public int YarnCountTypeId	{get;set;}
        public string YarnCountType { get; set; }

        public decimal Price	{get;set;}
        public int UnitId	{get;set;}
        public string UnitName { get; set; }

        public string StichLength	{get;set;}
        public string ProcessLoss	{get;set;}
        public int UniqueId { get; set; }
       
    }
}
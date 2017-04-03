using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ERPSSL.LC.DAL;
using ERPSSL.Production.DAL;
using ERPSSL.Production.DAL.Repository;

namespace ERPSSL.Production.BLL
{
    public class PlanningBLL
    {
        PlanningDAL _PlanningDAL = new PlanningDAL();

        internal List<OrderDetails> GetOrdersDetails(string OCODE)
        {
            return _PlanningDAL.GetOrdersDetails(OCODE);
        }

        internal int SavePlan(Prod_Planning _Prod_Planning)
        {
            return _PlanningDAL.SavePlan(_Prod_Planning);
        }

        internal List<OrderDetails> GetOrdersDetailsByOrderNo(string orderNo, string OCODE)
        {
            return _PlanningDAL.GetOrdersDetailsByOrderNo(orderNo, OCODE);
        }

        internal List<HRM_SUB_SECTIONS> GetLine(string OCODE)
        {
            return _PlanningDAL.GetLine(OCODE);
        }

        internal int AddLineAllocation(Prod_LineAllocationTemp _LineAllocationTemp)
        {
            return _PlanningDAL.AddLineAllocation(_LineAllocationTemp);
        }

        internal List<Prod_LineAllocationTemp> GetAllTempByPlanNo(string plan, string OCODE)
        {
            return _PlanningDAL.GetAllTempByPlanNo(plan, OCODE);
        }

        internal List<Prod_ProductionStatusDetails> GetDailyProductionStatus()
        {
            return _PlanningDAL.GetDailyProductionStatus();
        }
    }
}
using ERPSSL.Marketing.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPSSL.Marketing.BLL
{
    public class DashBoardBLL
    {
        DashBoardDAL aDashBoardDAL = new DashBoardDAL();

        internal List<int> GetNumberOfOnGoingOrder()
        {
            return aDashBoardDAL.GetNumberOfOnGoingOrder();
        }

        internal List<int> GetNumberOfUpComingOrder()
        {
            return aDashBoardDAL.GetNumberOfUpComingOrder();
        }

        internal List<int> GetPrimaryClient()
        {
            return aDashBoardDAL.GetPrimaryClient();
        }

        internal List<int> GetMidLevelClient()
        {
            return aDashBoardDAL.GetMidLevelClient();
        }

        internal List<MRK_Transaction> GetTotalCollectionAmount(int nowMonth, int nowYear)
        {
            return aDashBoardDAL.GetTotalCollectionAmount(nowMonth, nowYear);
        }

        internal List<MRK_Transaction> GetTotalPreCollectionAmount(int preMonth, int preYear)
        {
            return aDashBoardDAL.GetTotalPreCollectionAmount(preMonth, preYear);
        }



        internal List<MRK_MarketingInfo> GetCurrentStatus(int nowMonth, int nowYear)
        {
            return aDashBoardDAL.GetCurrentStatus(nowMonth, nowYear);
        }

        internal List<MRK_MarketingInfo> GetTotalPreVisit(int preMonth, int preYear)
        {
            return aDashBoardDAL.GetTotalPreVisit(preMonth, preYear);
        }

        internal int GetMonthlyVisitStatus(int monthInNumber)
        {
            return aDashBoardDAL.GetMonthlyVisitStatus(monthInNumber);
        }

        internal int GetMonthlyCollectionAmount(int monthInNumber)
        {
            return aDashBoardDAL.GetMonthlyCollectionAmount(monthInNumber);
        }
    }
}
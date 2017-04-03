using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPSSL.Marketing.DAL
{
    public class DashBoardDAL
    {
        ERPSSL_Marketing_Entities _Context = new ERPSSL_Marketing_Entities();

        internal List<int> GetNumberOfOnGoingOrder()
        {
            try 
            {
                using (_Context = new ERPSSL_Marketing_Entities())
                {
                    var query = (from w in _Context.MRK_WorkOrder
                                 select w.WoID);

                    return query.ToList();
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        internal List<int> GetNumberOfUpComingOrder()
        {
            try
            {
                using (_Context = new ERPSSL_Marketing_Entities())
                {
                    var query = (from m in _Context.MRK_MarketingInfo
                             where !(_Context.MRK_WorkOrder.Any(w => w.MarketingInfoId == m.MarketingInfoId))
                             select m.MarketingInfoId);

                return query.ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal List<int> GetPrimaryClient()
        {
            try
            {
                using (_Context = new ERPSSL_Marketing_Entities())
                {
                    var query = (from m in _Context.MRK_MarketingInfo
                                 where m.StageId == 1
                                 select m.MarketingInfoId);

                    return query.ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal List<int> GetMidLevelClient()
        {
            try
            {
                using (_Context = new ERPSSL_Marketing_Entities())
                {
                    var query = (from m in _Context.MRK_MarketingInfo
                                 where m.StageId == 2
                                 select m.MarketingInfoId);

                    return query.ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal List<MRK_Transaction> GetTotalCollectionAmount(int nowMonth, int nowYear)
        {
            int totalAmount = 0;

            try
            {
                using (_Context = new ERPSSL_Marketing_Entities())
                {
                    var query = (from t in _Context.MRK_Transaction
                                 where t.CollectionDate.Value.Month == nowMonth && t.CollectionDate.Value.Year == nowYear
                                 select t);

                    return query.ToList();
                }


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal List<MRK_Transaction> GetTotalPreCollectionAmount(int preMonth, int preYear)
        {
            try
            {
                using (_Context = new ERPSSL_Marketing_Entities())
                {
                    var query = (from t in _Context.MRK_Transaction
                                 where t.CollectionDate.Value.Month == preMonth && t.CollectionDate.Value.Year == preYear
                                 select t);

                    return query.ToList();
                }


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal List<MRK_MarketingInfo> GetCurrentStatus(int nowMonth, int nowYear)
        {
            try
            {
                using (_Context = new ERPSSL_Marketing_Entities())
                {
                    var query = (from m in _Context.MRK_MarketingInfo
                                 where m.VisitDate.Value.Month == nowMonth && m.VisitDate.Value.Year == nowYear
                                 select m);

                    return query.ToList();
                }


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal List<MRK_MarketingInfo> GetTotalPreVisit(int preMonth, int preYear)
        {
            try
            {
                using (_Context = new ERPSSL_Marketing_Entities())
                {
                    var query = (from m in _Context.MRK_MarketingInfo
                                 where m.VisitDate.Value.Month == preMonth && m.VisitDate.Value.Year == preYear
                                 select m);

                    return query.ToList();
                }


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        internal int GetMonthlyVisitStatus(int monthInNumber)
        {
            int nowYear = DateTime.Now.Year;

            try
            {
                using (_Context = new ERPSSL_Marketing_Entities())
                {
                    var query = (from m in _Context.MRK_MarketingInfo
                                 where m.VisitDate.Value.Month == monthInNumber && m.VisitDate.Value.Year == nowYear
                                 select m);

                    List<MRK_MarketingInfo> aMarketingInfo = new List<MRK_MarketingInfo>();

                    aMarketingInfo = query.ToList();

                    return aMarketingInfo.Count;


                }


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal int GetMonthlyCollectionAmount(int monthInNumber)
        {
            int nowYear = DateTime.Now.Year;

            int totalAmount = 0;

            try
            {
                using (_Context = new ERPSSL_Marketing_Entities())
                {
                    var query = (from m in _Context.MRK_Transaction
                                 where m.CollectionDate.Value.Month == monthInNumber && m.CollectionDate.Value.Year == nowYear
                                 select m);

                    List<MRK_Transaction> aMRK_Transaction = new List<MRK_Transaction>();

                    aMRK_Transaction = query.ToList();

                    foreach (MRK_Transaction transaction in aMRK_Transaction)
                    {
                        totalAmount = totalAmount + Convert.ToInt32(transaction.CollectionAmount);
                    }

                    return totalAmount;


                }


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
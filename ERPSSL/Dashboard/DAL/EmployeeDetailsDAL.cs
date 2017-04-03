using ERPSSL.Dashboard.Repository;
using ERPSSL.HRM.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPSSL.Dashboard.DAL
{
    public class EmployeeDetailsDAL
    {

        internal EmployeeDetailsR GetEmployeeDetails()
        {
            try
            {
                using (var _context = new ERPSSLHBEntities())
                {



                    string SP_SQL = "HRM_EmployeeDetailsRpt";

                    return (_context.ExecuteStoreQuery<EmployeeDetailsR>(SP_SQL)).FirstOrDefault();
                }


            }
            catch (Exception)
            {

                throw;
            }


        }

        internal EmployeeDetailsR GetLastMonthEmpDetails()
        {
            try
            {
                using (var _context = new ERPSSLHBEntities())
                {



                    string SP_SQL = "HRM_LastMonth_DetailsInfo";

                    return (_context.ExecuteStoreQuery<EmployeeDetailsR>(SP_SQL)).FirstOrDefault();
                }


            }
            catch (Exception)
            {

                throw;
            }


        }

        internal CommercialR GetCommercialDetails()
        {

            try
            {
                using (var _context = new ERPSSLHBEntities())
                {
                    string SP_SQL = "[HRM_CommercialDetails]";
                    return (_context.ExecuteStoreQuery<CommercialR>(SP_SQL)).FirstOrDefault();
                }

            }
            catch (Exception)
            {

                throw;
            }

        }

        internal AttendanceDetailsR GetAttendanceDetails()
        {

            try
            {
                using (var _context = new ERPSSLHBEntities())
                {


                    string SP_SQL = "[HRM_AttendanceDetailsRpt]";

                    return (_context.ExecuteStoreQuery<AttendanceDetailsR>(SP_SQL)).FirstOrDefault();
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        internal InventoryDetailsR GetInventoryDetails()
        {
            try
            {
                using (var _context = new ERPSSLHBEntities())
                {


                    string SP_SQL = "[Inv_InventoryDetailsR]";

                    return (_context.ExecuteStoreQuery<InventoryDetailsR>(SP_SQL)).FirstOrDefault();
                }

            }
            catch (Exception)
            {

                throw;
            }
        
        }

        internal POSDetails GetPosDetails()
        {
            try
            {
                using (var _context = new ERPSSLHBEntities())
                {


                    string SP_SQL = "[POS_Ticket_Food_Details]";

                    return (_context.ExecuteStoreQuery<POSDetails>(SP_SQL)).FirstOrDefault();
                }

            }
            catch (Exception)
            {

                throw;
            }

        }

    }
}
using ERPSSL.HMS.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPSSL.HMS.BLL
{
    public class HMSDashboard_BLL
    {
        HMSDashboard_DAL objDal = new HMSDashboard_DAL();

        internal List<int> GetNumberOfAdmittedPatient()
        {
            return objDal.GetNumberOfAdmittedPatient();
        }
        internal List<int> GetCurrentMonthAdmittedPatient(int nowMonth, int nowYear)
        {
            return objDal.GetCurrentMonthAdmittedPatient(nowMonth,nowYear);
        }
        internal List<int> GetLastMonthAdmittedPatient(int lastMonth, int lastYear)
        {
            return objDal.GetLastMonthAdmittedPatient(lastMonth,lastYear );
        }
    }
}
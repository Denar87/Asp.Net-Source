using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ERPSSL.HRM.DAL;

namespace ERPSSL.HRM.BLL
{
    public class ServiceBLL
    {

        internal int FilePathDEleting(string FilePath)
        {
            return ServicesContractDAL.FilePathDEleting(FilePath);
        }
    }
}
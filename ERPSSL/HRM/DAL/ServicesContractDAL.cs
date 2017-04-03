using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPSSL.HRM.DAL
{
    public class ServicesContractDAL
    {
        
        internal static int FilePathDEleting(string FilePath)
        {
            using (var _context = new ERPSSLHBEntities())
            {
                //int Task = Convert.ToInt32(TaskId);
                //CRM_Task_Assign atask = _context.CRM_Task_Assign.First(x => x.Id == Task);
                //_context.CRM_Task_Assign.DeleteObject(atask);
                //_context.SaveChanges();
                //return 1;
                int path = Convert.ToInt32(FilePath);
                HRM_EMPLOYEE_DOCUMENTS EMPDOC = _context.HRM_EMPLOYEE_DOCUMENTS.First(x => x.FILE_ID == path);
                _context.HRM_EMPLOYEE_DOCUMENTS.DeleteObject(EMPDOC);
                _context.SaveChanges();
                return 1;


            }
        }
    }
}
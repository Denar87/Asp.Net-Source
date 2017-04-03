using ERPSSL.Marketing.DAL;
using ERPSSL.Marketing.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPSSL.Marketing.BLL
{
    public class TaskDetailsBLL
    {

        TaskDetailsDAL aTaskDetailsDAL = new TaskDetailsDAL(); 

        internal List<MarketingTaskDetails> GetAllInformationOfTask(string OCODE)
        {
            return aTaskDetailsDAL.GetAllInformationOfTask(OCODE);
        }

        internal List<MarketingTaskDetails> GetIndividualInformationOfTask(string OCODE, string clientName)
        {
            return aTaskDetailsDAL.GetIndividualInformationOfTask(OCODE, clientName);
        }
    }
}
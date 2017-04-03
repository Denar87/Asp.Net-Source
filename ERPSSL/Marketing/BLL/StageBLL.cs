using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ERPSSL.Marketing.DAL;

namespace ERPSSL.Marketing.BLL
{
    public class StageBLL
    {
        StageDAL aStageDAL = new StageDAL();

        public List<MRK_Stage> GetAllStagesList(string OCODE)
        {
            return aStageDAL.GetAllStagesList(OCODE);
        }
    }
}
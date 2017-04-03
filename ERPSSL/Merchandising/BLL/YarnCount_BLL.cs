using ERPSSL.Merchandising.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPSSL.Merchandising.BLL
{
    public class YarnCount_BLL
    {
        YarnCount_DAL obj_DAL = new YarnCount_DAL();

        internal int InsertYarnCount(LC_Yarn_Count objYarn)
        {
            return obj_DAL.InsertYarnCount(objYarn);
        }

        public virtual List<LC_Yarn_Count> GetAllYarnCount(string OCODE)
        {
            return obj_DAL.GetAllYarnCount(OCODE);
        }
        internal int UpdateYarnCount(LC_Yarn_Count objYarn, int yarnId)
        {
            return obj_DAL.UpdateYarnCount(objYarn, yarnId);
        }

        internal List<LC_Yarn_Count> GetYarnCountInfoByYarnId(string yarnId, string OCODE)
        {
            return obj_DAL.GetYarnCountInfoByYarnId(yarnId, OCODE);
        }
    }
}
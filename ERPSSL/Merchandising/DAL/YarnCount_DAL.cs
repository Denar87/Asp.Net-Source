using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPSSL.Merchandising.DAL
{
    public class YarnCount_DAL
    {
        private ERPSSL_MerchandisingEntities _context = new ERPSSL_MerchandisingEntities();

        internal int InsertYarnCount(LC_Yarn_Count objYarn)
        {
            try
            {
                _context.LC_Yarn_Count.AddObject(objYarn);
                _context.SaveChanges();
                return 1;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public virtual List<LC_Yarn_Count> GetAllYarnCount(string OCODE)
        {

            try
            {
                var query = (from yarn in _context.LC_Yarn_Count 
                             where yarn.OCODE == OCODE
                             select yarn).OrderBy(x => x.Yarn_Count);


                return query.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        internal int UpdateYarnCount(LC_Yarn_Count objYarn, int yarnId)
        {

            try
            {
                LC_Yarn_Count obj = _context.LC_Yarn_Count.First(x => x.YarnCount_ID == yarnId);
                obj.Yarn_Count = objYarn.Yarn_Count;
                obj.Status = objYarn.Status;
                obj.EDIT_USER = objYarn.EDIT_USER;
                obj.EDIT_DATE = objYarn.EDIT_DATE;
                _context.SaveChanges();
                return 1;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        internal List<LC_Yarn_Count> GetYarnCountInfoByYarnId(string yarnId, string OCODE)
        {
            int yarnCountId = Convert.ToInt32(yarnId);


            List<LC_Yarn_Count> yarnCount = (from yrn in _context.LC_Yarn_Count
                                             where yrn.OCODE == OCODE && yrn.YarnCount_ID == yarnCountId
                                             select yrn).OrderBy(x => x.YarnCount_ID).ToList<LC_Yarn_Count>();
            return yarnCount;

        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ERPSSL.Marketing.DAL;

namespace ERPSSL.Marketing.BLL
{
    public class ProjectBLL
    {
        ProjectDAL aProjectDAL = new ProjectDAL();

        public List<MRK_Project> Get_AllProjectList(string OCODE)
        {
            return aProjectDAL.GetAllProjectList(OCODE);
        }

     
    }
}
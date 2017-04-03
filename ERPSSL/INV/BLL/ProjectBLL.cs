using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ERPSSL.INV.DAL;

namespace ERPSSL.INV.BLL
{
    public class ProjectBLL
    {
        ProjectDAL aProjectDAL = new ProjectDAL();
        internal int InsertProject(DAL.Inv_Project InvProject)
        {
            return aProjectDAL.InsertProject(InvProject);
        }

        internal int UpdateProject(Inv_Project InvProject, int projectId)
        {
            return aProjectDAL.UpdateProject(InvProject, projectId);
        }

        internal List<Inv_Project> GetProjectId(string ProjectId)
        {
            return aProjectDAL.GetProjectId(ProjectId);
        }

        internal List<Inv_Project> GetAllProject()
        {
            return aProjectDAL.GetAllProject();
        }
    }
}
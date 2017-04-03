using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPSSL.INV.DAL
{
    public class ProjectDAL
    {
        private ERPSSL_INVEntities _context = new ERPSSL_INVEntities();

        internal int InsertProject(Inv_Project InvProject)
        {
             try
            {
                _context.Inv_Project.AddObject(InvProject);
                _context.SaveChanges();
                return 1;

            }
            catch (Exception)
            {

                throw;
            }
        }

        internal int UpdateProject(Inv_Project InvProject, int projectId)
        {
            try
            {
                Inv_Project InvPro = _context.Inv_Project.First(x => x.Project_Id == projectId);
                InvPro.Project_Name = InvProject.Project_Name;
                InvPro.Project_Code = InvProject.Project_Code;
                InvPro.Description = InvProject.Description;
                _context.SaveChanges();
                return 1;

            }
            catch (Exception)
            {

                throw;
            }
        }

        internal List<Inv_Project> GetProjectId(string ProjectId)
        {
            try
            {
                int projectId = Convert.ToInt32(ProjectId);

                //List<Inv_ProductGroup> Regions = (from reg in _context.Inv_ProductGroup
                //                                  where reg.GroupId == grpId
                //                                  select reg).OrderByDescending(x => x.GroupId).ToList<Inv_ProductGroup>();
                //return Regions;

                var project = (from prj in _context.Inv_Project
                               where prj.Project_Id == projectId
                               select prj); 
                return project.ToList();

            }
            catch (Exception)
            { 
                throw;
            }
        }

        internal List<Inv_Project> GetAllProject()
        {
            try
            {

                var projects = (from prj in _context.Inv_Project

                                select prj).OrderBy(x => x.Project_Name);


                return projects.ToList();

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
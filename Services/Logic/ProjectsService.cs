using CompanyProjectsManager.Models;
using CompanyProjectsManager.Services.DAL.Interfaces;
using CompanyProjectsManager.Services.Logic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyProjectsManager.Services.Logic
{
    public class ProjectsService : IProjectsService
    {
        private IProjectsDAL _projectsDAL;

        public ProjectsService(IProjectsDAL projectsDAL)
        {
            _projectsDAL = projectsDAL;
        }

        public void Create(Project project)
        {
            project.Id = $"prj{GetAll().Count +1}";
            _projectsDAL.Create(project);
        }

        public void Delete(string id)
        {
            _projectsDAL.Delete(id);
        }

        public void Edit(Project project)
        {
            _projectsDAL.Edit(project);
        }

        public List<Project> GetAll()
        {
            return _projectsDAL.GetAll();
        }

        public Task GetById(string id)
        {
            throw new NotImplementedException();
        }
    }
}

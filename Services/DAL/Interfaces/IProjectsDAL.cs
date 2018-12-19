using CompanyProjectsManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyProjectsManager.Services.DAL.Interfaces
{
    public interface IProjectsDAL
    {
        Task GetById(string id);
        List<Project> GetAll();
        void Create(Project project);
        void Edit(Project project);
        void Delete(string id);
    }
}

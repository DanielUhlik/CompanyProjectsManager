using CompanyProjectsManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyProjectsManager.Services.Logic.Interfaces
{
    public interface IProjectsService
    {
        Task GetById(string id);
        List<Project> GetAll();
        void Create(Project project);
        void Edit(Project project);
        void Delete(string id);
    }
}

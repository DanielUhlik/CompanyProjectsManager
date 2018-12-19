using CompanyProjectsManager.Models;
using CompanyProjectsManager.Services.DAL.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace CompanyProjectsManager.Services.DAL
{
    public class ProjectsXmlDAL : IProjectsDAL
    {
        private IConfiguration _configuration;
        private string _dataPath;
        private Dictionary<string, Project> AllProjects;

        public ProjectsXmlDAL(IConfiguration configuration, IHostingEnvironment env)
        {
            _configuration = configuration;
            _dataPath = $"{env.WebRootPath}/{configuration["Settings:Data:Path"]}";
            LoadXml();
        }

        public void Create(Project project)
        {
            AllProjects.Add(project.Id, project);
            UpdateXml();
        }

        public void Delete(string id)
        {
            AllProjects.Remove(id);
            UpdateXml();
        }

        public void Edit(Project project)
        {
            AllProjects[project.Id] = project;
            UpdateXml();
        }

        public List<Project> GetAll()
        {
            return AllProjects.Values.ToList();
        }

        public Task GetById(string id)
        {
            throw new NotImplementedException();
        }


        #region Private

        private void LoadXml()
        {
            XDocument projects = null;
            using (StreamReader oReader = new StreamReader(_dataPath, Encoding.GetEncoding("ISO-8859-1")))
            {
                projects = XDocument.Load(oReader);
            }
            List<Project> allProjects = projects.Descendants("project").Select(p => new Project(p)).ToList();
            AllProjects = allProjects.ToDictionary(p => p.Id, p => p);
        }

        private void UpdateXml()
        {
            XmlWriter xmlWriter = XmlWriter.Create(_dataPath);

            xmlWriter.WriteStartDocument();
            xmlWriter.WriteStartElement("projects");

            foreach (var project in AllProjects.Values)
            {
                xmlWriter.WriteStartElement("project");
                xmlWriter.WriteAttributeString("id", project.Id);

                xmlWriter.WriteStartElement("name");
                xmlWriter.WriteValue(project.Name);
                xmlWriter.WriteEndElement();

                xmlWriter.WriteStartElement("abbreviation");
                xmlWriter.WriteValue(project.Abbreviation);
                xmlWriter.WriteEndElement();

                xmlWriter.WriteStartElement("customer");
                xmlWriter.WriteValue(project.Customer);
                xmlWriter.WriteEndElement();

                xmlWriter.WriteEndElement();
            }

            xmlWriter.WriteEndDocument();
            xmlWriter.Close();
        }

        #endregion
    }
}

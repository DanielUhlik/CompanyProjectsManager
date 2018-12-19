using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CompanyProjectsManager.Models
{
    public class Project
    {

        public Project(XElement p)
        {
            Id = p.Attribute("id").Value;
            Name = p.Element("name").Value;
            Abbreviation = p.Element("abbreviation").Value;
            Customer = p.Element("customer").Value;
        }

        public Project() { }

        public string Id { get; set; }
        public string Name { get; set; }
        public string Abbreviation { get; set; }
        public string Customer { get; set; }
    }
}

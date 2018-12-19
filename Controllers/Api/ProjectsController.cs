using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CompanyProjectsManager.Models;
using CompanyProjectsManager.Services.Logic.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CompanyProjectsManager.Controllers.Api
{
    [Produces("application/json")]
    [Route("api/Projects")]
    public class ProjectsController : Controller
    {
        private IProjectsService _projectsService;
        private ILogger<ProjectsController> _logger;

        public ProjectsController(IProjectsService projectsService, ILogger<ProjectsController> logger)
        {
            _projectsService = projectsService;
            _logger = logger;
        }


        [HttpGet]
        public IActionResult GetAll()
        {
            var projects = _projectsService.GetAll();
            _logger.LogInformation("Get all projects", projects);
            return Ok(projects);
        }

        [HttpPost("create")]
        public IActionResult Create([FromBody] Project model)
        {
            _projectsService.Create(model);
            return Ok();
        }

        [HttpPut("edit")]
        public IActionResult Edit([FromBody] Project model)
        {
            _projectsService.Edit(model);
            return Ok();
        }

        [HttpDelete("delete/{id}")]
        public IActionResult Delete([FromRoute] string id)
        {

            _projectsService.Delete(id);
            return Ok();
        }

    }
}
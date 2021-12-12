using System;
using Microsoft.AspNetCore.Mvc;
using Services;


namespace WebAppi.Controllers
{
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        private readonly IProjectsService _projectsService;
        public ProjectsController(IProjectsService projectsService) =>
            _projectsService = projectsService;

        [HttpGet]
        [Route("api/[controller]/{id}/developers")]
        public IActionResult GetProjects(int id)
        {
            var projects = _projectsService.GetProject(id);

            if (projects == null)
                return NotFound();
            else
                return Ok(projects);
        }

        [HttpDelete("{id}")]
        [Route("api/[controller]/{id}")]
        public IActionResult DeleteProject(int id)
        {
            try
            {
                _projectsService.DeleteProject(id);

                return NoContent();
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
    }
}

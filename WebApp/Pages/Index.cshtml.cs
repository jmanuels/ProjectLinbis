using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Controllers;

namespace WebApp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly WebAppi.Controllers.ProjectsController projectsController;
        private readonly IProjectsService projectsService;

        private readonly ILogger<IndexModel> _logger;
        public List<Project> AllProjects { get; private set; } = new List<Project>();
        public Project Project { get; private set; } = new Project();

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
            projectsService = new ProjectsService();
            projectsController = new WebAppi.Controllers.ProjectsController(projectsService);
        }

        public void OnGet()
        {
            var result = projectsController.GetAllProjects() as ObjectResult;
            if (result.StatusCode == 200)
                AllProjects = result.Value as List<Services.Project>;
        }
    }
}

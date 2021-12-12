using Microsoft.AspNetCore.Mvc;
using Services;
using System;
using WebAppi.Controllers;
using Xunit;

namespace XUnitTestProject1
{
    public class ProjectsControllerTest
    {
        private readonly ProjectsController projectsController;
        private readonly IProjectsService projectsService;

        public ProjectsControllerTest()
        {
            projectsService = new ProjectsService();
            projectsController = new ProjectsController(projectsService);
        }

        [Fact]
        public void GetProject_Ok()
        {
            var okResult = projectsController.GetProjects(3);

            Assert.IsType<OkObjectResult>(okResult as OkObjectResult);
        }

        [Fact]
        public void GetProject_NotFound()
        {
            var notFoundResult = projectsController.GetProjects(4654);

            Assert.IsType<NotFoundResult>(notFoundResult as NotFoundResult);
        }

        [Fact]
        public void DeleteProject_NoContent()
        {
            var noContent = projectsController.DeleteProject(10);

            Assert.IsType<NotFoundResult>(noContent as NotFoundResult);
        }

        [Fact]
        public void DeleteProject_NotFound()
        {
            var notFoundResult = projectsController.DeleteProject(654);

            Assert.IsType<NotFoundResult>(notFoundResult as NotFoundResult);
        }
    }
}

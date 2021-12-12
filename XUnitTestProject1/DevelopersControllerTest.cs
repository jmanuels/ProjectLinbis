using Microsoft.AspNetCore.Mvc;
using Services;
using System;
using WebAppi.Controllers;
using Xunit;

namespace XUnitTestProject1
{
    public class DevelopersControllerTest
    {
        private readonly DevelopersController developersController;
        private readonly IDevelopersService developersService;

        public DevelopersControllerTest()
        {
            developersService = new DevelopersService();
            developersController = new DevelopersController(developersService);
        }

        [Fact]
        public void PostDeveloper_Created()
        {
            Random random = new Random();
            Developer developer = new Developer
            {
                id = random.Next(99999),
                name = "Test1",
                addedDate = DateTimeOffset.Now,
                costByDay = 300
            };

            var createdResult = developersController.PostDeveloper(developer, 3);

            Assert.IsType<StatusCodeResult>(createdResult as StatusCodeResult);
        }

        [Fact]
        public void PostDeveloper_NotFound_IdProject()
        {
            Developer developer = new Developer
            {
                id = 6,
                name = "Test1",
                addedDate = DateTimeOffset.Now,
                costByDay = 300
            };

            var notFoundResult = developersController.PostDeveloper(developer, 1234432);

            Assert.IsType<NotFoundResult>(notFoundResult as NotFoundResult);
        }

        [Fact]
        public void PostDeveloper_NotFound_Id_Repeated()
        {
            Developer developer = new Developer
            {
                id = 1,
                name = "Test1",
                addedDate = DateTimeOffset.Now,
                costByDay = 300
            };

            var notFoundResult = developersController.PostDeveloper(developer, 1);

            Assert.IsType<NotFoundResult>(notFoundResult as NotFoundResult);
        }
    }
}

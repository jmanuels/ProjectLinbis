using Microsoft.AspNetCore.Mvc;
using Services;
using System;
using System.ComponentModel.DataAnnotations;

namespace WebAppi.Controllers
{
    [ApiController]
    public class DevelopersController : ControllerBase
    {
        private readonly IDevelopersService _developersService;

        public DevelopersController(IDevelopersService developersService) =>
            _developersService = developersService;

        [HttpPost]
        [Route("api/projects/{projectId}/[controller]")]
        public IActionResult PostDeveloper([FromBody] Services.Developer developer, int projectId)
        {
            try
            {
                developer.projectId = projectId;
                _developersService.AddDeveloper(developer);

                return StatusCode(201);
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        public class Developer : Attribute
        {
            [Key]
            public int id { get; set; }
            public string name { get; set; }
            public int projectId { get; set; }
            public DateTimeOffset addedDate { get; set; }
            public decimal costByDay { get; set; }
        }
    }
}

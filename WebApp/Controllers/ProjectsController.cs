using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAppi.Controllers;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Controllers
{
    public class ProjectsController : Controller
    {
        private readonly WebAppi.Controllers.ProjectsController projectsController;
        private readonly IProjectsService projectsService;

        public ProjectsController()
        {
            projectsService = new ProjectsService();
            projectsController = new WebAppi.Controllers.ProjectsController(projectsService);
        }

        // GET: Projects
        public ActionResult Index()
        {
            //return View(projectsController.GetAllProjects());
            return View("/Pages/Index.cshtml", projectsController.GetAllProjects());
        }

        // GET: Projects/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Projects/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Projects/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Projects/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Projects/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Projects/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Projects/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}

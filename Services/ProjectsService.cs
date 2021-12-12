using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;

namespace Services
{
    public class Project
    {
        [Key]
        public int id { get; set; }
        public string name { get; set; }
        public bool isActive { get; set; }
        public DateTimeOffset addedDate { get; set; }
        public int effortRequireInDays { get; set; }
        public decimal developmentCost { get; set; }
        public List<Developer> developers {get; set;}
    }
    public class ProjectsService : IProjectsService
    {
        private readonly List<Project> listProjects = JsonConvert.DeserializeObject<List<Project>>(LoadJson.ReadJson("Data\\Projects.json"));
        private readonly  List<Developer> listDevelopers = JsonConvert.DeserializeObject<List<Developer>>(LoadJson.ReadJson("Data\\Developers.json"));

        public Project GetProject(int _id)
        {
            Project project = new Project();
            try
            {
                decimal costByDay = 0;

                project = listProjects.AsEnumerable().Where(x => x.id == _id).FirstOrDefault();

                var developers = listDevelopers.AsEnumerable().Where(x => x.projectId == _id).ToList();

                if (developers.Count > 0)
                {
                    if (project != null)
                    {
                        project.developers = new List<Developer>();

                        foreach (var item in developers)
                        {
                            costByDay += item.costByDay;
                            project.developers.Add(item);
                        }

                        project.developmentCost = project.effortRequireInDays * costByDay;
                    }
                }

                return project;
            }
            catch (Exception)
            {
                return project;
            }
        }

        public void DeleteProject(int _id)
        {
            var projects = listProjects;
            var developers = listDevelopers;
            var project = listProjects.SingleOrDefault(x => x.id == _id);
            var developers2 = listDevelopers.AsEnumerable().Where(x => x.projectId == _id).ToList();
            

            if (project != null)
            {
                projects.Remove(project);
                var convertedJson = JsonConvert.SerializeObject(projects, Formatting.Indented);
                File.WriteAllText("Data\\Projects.json", convertedJson.ToString());

                if (developers2.Count > 0)
                {
                    foreach (var item in developers2)
                    {
                        var index = developers.FindIndex(c => c.id == item.id);
                        developers[index] = new Developer
                        {
                            id = item.id,
                            name = item.name,
                            projectId = 0,
                            addedDate = item.addedDate,
                            costByDay = item.costByDay
                        };
                    }
                    convertedJson = JsonConvert.SerializeObject(developers, Formatting.Indented);
                    File.WriteAllText("Data\\Developers.json", convertedJson.ToString());
                }          
            }
            else
                throw new Exception();
        }
    }
}

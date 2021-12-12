using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;

namespace Services
{
    public class Developer
    {
        [Key]
        public int id { get; set; }
        public string name { get; set; }
        public int projectId { get; set; }
        public DateTimeOffset addedDate { get; set; }
        public decimal costByDay { get; set; }
    }
    public class DevelopersService : IDevelopersService
    {
        private readonly List<Developer> listDevelopers = JsonConvert.DeserializeObject<List<Developer>>(LoadJson.ReadJson("Data\\Developers.json"));
        private readonly List<Project> listProjects = JsonConvert.DeserializeObject<List<Project>>(LoadJson.ReadJson("Data\\Projects.json"));

        public void AddDeveloper(Developer developer)
        {
            var developers = listDevelopers;
            var projects = listProjects.AsEnumerable().Where(x => x.id == developer.projectId).ToList();

            if (projects.Count > 0 && developers.AsEnumerable().Where(x => x.id == developer.id).ToList().Count == 0)
            {
                developers.Add(developer);
                var convertedJson = JsonConvert.SerializeObject(developers, Formatting.Indented);
                File.WriteAllText("Data\\Developers.json", convertedJson.ToString());
            }
            else
                throw new Exception();
        }
    }
}

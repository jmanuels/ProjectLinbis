using System.Collections.Generic;

namespace Services
{
    public interface IProjectsService
    {
        Project GetProject(int id);

        void DeleteProject(int id);

        List<Project> GetAllProjects();
    }
}

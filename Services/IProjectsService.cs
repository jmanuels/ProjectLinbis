

namespace Services
{
    public interface IProjectsService
    {
        Project GetProject(int id);

        void DeleteProject(int id);
    }
}

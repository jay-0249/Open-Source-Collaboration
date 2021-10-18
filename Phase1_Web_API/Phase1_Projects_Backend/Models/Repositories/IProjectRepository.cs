using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Phase1_Projects_Backend.Models.Repositories
{
    public interface IProjectRepository
    {
        public bool AddNewProject(Project project);
        public IEnumerable<Project> GetAllProjects();
        public IEnumerable<Project> GetProjectsSearchedFor(string keyword1);
        public IEnumerable<Project> IsDuplicate(Project project);
    }
}

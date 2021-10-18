using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Phase1_Projects_Backend.Models;
using Phase1_Projects_Backend.Exceptions;

namespace Phase1_Projects_Backend.Services
{
    public interface IProjectService
    {
        public IEnumerable<Project> GetAllProjects();
        public IEnumerable<Project> GetProjectsSearchedFor(string keyword);
        public bool NewProject(Project project);
    }
}

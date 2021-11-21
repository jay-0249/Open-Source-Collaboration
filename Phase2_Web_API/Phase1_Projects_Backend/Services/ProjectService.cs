using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Phase1_Projects_Backend.Models;
using Phase1_Projects_Backend.Exceptions;
using Phase1_Projects_Backend.Models.Repositories;


namespace Phase1_Projects_Backend.Services
{
    public class ProjectService : IProjectService
    {
        private readonly IProjectRepository _repository;
        public ProjectService(IProjectRepository rep)
        {
            _repository = rep;
        }

        public IEnumerable<Project> GetAllProjects()
        {
            var projectList =_repository.GetAllProjects();
            return projectList;
        }

        public IEnumerable<Project> GetProjectsSearchedFor(string keyword)
        {
            var projectList = _repository.GetProjectsSearchedFor(keyword);
            return projectList;
        }

        public bool NewProject(Project project)
        {
            bool isDuplicate = _repository.AddNewProject(project);
            if(isDuplicate)
            {
                return true;
            }
            else
            {
                //throw new ProjectAlreadyExists("This project already exits");
                return false;
            }
        }
    }
}

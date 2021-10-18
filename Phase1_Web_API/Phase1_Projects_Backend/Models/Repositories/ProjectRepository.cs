using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Phase1_Projects_Backend.Models;

namespace Phase1_Projects_Backend.Models.Repositories
{
    public class ProjectRepository:IProjectRepository
    {
        private readonly ProjectDbContext _context;

        public ProjectRepository(ProjectDbContext dbContext)
        {
            _context = dbContext;
        }

        public IEnumerable<Project> GetAllProjects()
        {
            return _context.Projects.ToList();
        }

        public IEnumerable<Project> GetProjectsSearchedFor(string keyword1)
        {
            //var results = _context.Projects.Where(p => p.Domain.Contains(keyword1) || p.Description.Contains(keyword1) || p.ProjectTitle.Contains(keyword1) || p.ProjectId.ToString().Contains(keyword1) || p.ContactMail.Contains(keyword1));
            var results = _context.Projects.Where(p => p.Domain.Contains(keyword1) || p.Description.Contains(keyword1) || p.ProjectTitle.Contains(keyword1) || p.TechTools.Contains(keyword1) || p.ProjectId.ToString().Contains(keyword1) || p.ContactMail.Contains(keyword1));
            return results;
        }
        public bool AddNewProject(Project project)
        {
            //    IEnumerable<Project> ExistingProject = null;
            //    ExistingProject = _context.Projects.Where(p => p.Domain == project.Domain && p.Description == project.Description && p.ContactMail == p.ContactMail && p.ProjectTitle == project.ProjectTitle);
            //if (ExistingProject == null)
            //{
            //    _context.add(project);
            //    _context.savechanges();
            //    return true;
            //}
            //else
            //{ 
            //    return false;
            //}

            //var Duplicates = this.IsDuplicate(project);
            //if (Duplicates.Count() > 0)
            //{
            //    _context.add(project);
            //    _context.savechanges();
            //    return true;
            //}
            //else
            //{
            //    return false;
            //}
            if (project.TechTools == null || project.TechTools.Length == 0)
            {
                project.TechTools = "To be updated1";
            }
            _context.Add(project);
            _context.SaveChanges();
            return true;
        }

        public IEnumerable<Project> IsDuplicate(Project project)
        {

            IEnumerable<Project> results = null;
            results = _context.Projects.Where(p => p.Domain.Equals(project.Domain) && p.Description.Equals(project.Description) && p.ProjectTitle.Equals(project.ProjectTitle) && p.TechTools.Equals(project.TechTools) &&  p.ContactMail.Equals(project.ContactMail));
            return results;
        }

    }
}

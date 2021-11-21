using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Phase1_Projects_Backend.Services;
using Phase1_Projects_Backend.Models;
using Phase1_Projects_Backend.Models.Repositories;
using Phase1_Projects_Backend.Exceptions;
using Microsoft.AspNetCore.Cors;

namespace Phase1_Projects_Backend.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        private readonly IProjectService _service;
        private readonly ProjectDbContext _context;

        public ProjectsController(IProjectService service1, ProjectDbContext context)
        {
            _service = service1;
            _context = context;
        }


        // "/api/Projects"
        [HttpGet]
        [EnableCors("withoutHeaderPolicy")]
        //[Route("Projects")]
        public IActionResult GetAll()
        {
            var result = _service.GetAllProjects();
            return Ok(result);
        }


        // "/api/Projects/{keyword}"
        [EnableCors("withHeaderPolicy")]
        [HttpGet("{keyword}", Name = "Get")]
        //[Route("getProjectsSearched")]
        public IActionResult GetSearchedProjects(string keyword)
        {
            var result = _service.GetProjectsSearchedFor(keyword);
            return Ok(result);
        }

        // "/api/Projects/AddProject"
        [EnableCors("withHeaderPolicy")]
        [HttpPost]
        [Route("AddProject")]
        public IActionResult addNewProject([FromBody] Project project)
        {
            var flag = _service.NewProject(project);
            return Ok(flag);
            //try
            //{
            //    var flag = _service.NewProject(project);
            //    if (flag)
            //    {
            //        return StatusCode(201, "Project added Successfully");
            //    }
            //    else
            //    {
            //        throw new ProjectAlreadyExists("This Project already exists");
            //    }
            //}
            //catch (ProjectAlreadyExists pae)
            //{
            //    return Conflict(pae.Message);
            //}
            //catch
            //{
            //    return StatusCode(500, "There is some internal server error");
            //}

        }


        [EnableCors("withHeaderPolicy")]
        [HttpPost]
        //[Route("AddUser")]
        public async Task<ActionResult<User>> PostUser(User user)
        {
            _context.UserList.Add(user);
            await _context.SaveChangesAsync();

            //return CreatedAtAction("GetUser", new { id = user.UserId }, user);
            return Ok(user);
        }
    }
}

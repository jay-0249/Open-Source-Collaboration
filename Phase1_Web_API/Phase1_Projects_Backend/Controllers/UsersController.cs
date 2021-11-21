using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Phase1_Projects_Backend.Models;

namespace Phase1_Projects_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[EnableCors("withHeaderPolicy")]
    public class UsersController : ControllerBase
    {
        private readonly ProjectDbContext _context;

        public UsersController(ProjectDbContext context)
        {
            _context = context;
        }

        // GET: api/Users
        [EnableCors("withHeaderPolicy")]
        [HttpGet]

        public async Task<ActionResult<IEnumerable<User>>> GetUserList()
        {
            return await _context.UserList.ToListAsync();
        }

        // GET: api/Users/5
        [EnableCors("withHeaderPolicy")]
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            var user = await _context.UserList.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        // PUT: api/Users/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [EnableCors("withHeaderPolicy")]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(int id, User user)
        {
            if (id != user.UserId)
            {
                return BadRequest();
            }

            _context.Entry(user).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Users
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [EnableCors("withHeaderPolicy")]
        [HttpPost]
        public async Task<ActionResult<User>> PostUser(User user)
        {
            _context.UserList.Add(user);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUser", new { id = user.UserId }, user);
        }

        // DELETE: api/Users/5
        [EnableCors("withHeaderPolicy")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await _context.UserList.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            _context.UserList.Remove(user);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserExists(int id)
        {
            return _context.UserList.Any(e => e.UserId == id);
        }
    }
}

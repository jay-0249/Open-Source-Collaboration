using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Phase1_Projects_Backend.Models;
using Phase1_Projects_Backend.Services;

namespace Phase1_Projects_Backend.Controllers
{
    [EnableCors("withHeaderPolicy")]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        //private readonly ProjectDbContext _context;
        private readonly IUserService _service;
        //public UsersController(ProjectDbContext context, UserService service)
        //{
        //    _context = context;
        //    _service = service;
        //}
        public UsersController( IUserService service)
        {
            //_context = context;
            _service = service;
        }


        // GET: api/Users
        [HttpGet]
        //public async Task<ActionResult<IEnumerable<User>>> GetUserList()
        //{
        //    //return await _context.UserList.ToListAsync();
        //    return await _context.UserList.ToListAsync();
        //}
        public ActionResult<IEnumerable<User>> GetUserList()
        {
            //return await _context.UserList.ToListAsync();
            return Ok(_service.GetUsers());
        }

        // GET: api/Users/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<User>> GetUser(int id)
        //{
        //    var user = await _context.UserList.FindAsync(id);

        //    if (user == null)
        //    {
        //        return NotFound();
        //    }

        //    return user;
        //}


        // GET: /api/Users/{username}
        //To get user details using username
        //[Route("GetUser")]
        [HttpGet("{username}")]
        
        public async Task<ActionResult<User>> GetUserDetails(string username)
        {
            var user = await _service.FindUserAndReturnUser(username);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }



        // PUT: api/Users/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutUser(int id, User user)
        //{
        //    if (id != user.UserId)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(user).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!UserExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        // POST: api/Users
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPost]
        //public async Task<ActionResult<User>> PostUser(User user)
        //{
        //    _context.UserList.Add(user);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetUser", new { id = user.UserId }, user);
        //}


        // POST: /api/Users/login
        [HttpPost("login")]
        public ActionResult<string> LoginUser(string username, string password)
        {
            string result;
            try
            {
                bool IsUsernameValid = _service.FindUser(username);
                if (IsUsernameValid)
                {
                    try
                    {
                        bool IsPasswordCorrect = _service.LoginUser(username, password);
                        if (IsPasswordCorrect)
                        {
                            result = "Successful Login";
                            //return Ok("Successful Login");
                            ResponseString resStr = new ResponseString(result);
                            return Ok(result);
                        }
                        else
                        {
                            result = "UnSuccessful Login";
                            ResponseString resStr = new ResponseString(result);
                            return Ok(resStr);
                            //return Ok("UnSuccessful Login");
                        }

                    }
                    catch
                    {
                        return StatusCode(500, "This is an internal error with username valid");
                    }
                }
                else
                {
                    result = "username invalid";
                    ResponseString resStr = new ResponseString(result);
                    return Ok(resStr);
                    //return Ok("username invalid");
                }
            }
            catch
            {
                return StatusCode(500, "This is an internal error with username valid");
            }
        }


        [HttpPost("loginInputUser")]
        public ActionResult<ResponseString> LoginUser(User user)
        {
            string username = user.Username;
            string password = user.Password;
            string result;
            try
            {
                bool IsUsernameValid = _service.FindUser(username);
                if (IsUsernameValid)
                {
                    try
                    {
                        bool IsPasswordCorrect = _service.LoginUser(username, password);
                        if (IsPasswordCorrect)
                        {
                            result = "Successful Login";
                            
                            //return Ok("Successful Login");
                            ResponseString resStr = new ResponseString(result,username);
                            return Ok(resStr);
                        }
                        else
                        {
                            result = "UnSuccessful Login";
                            ResponseString resStr = new ResponseString(result,username);
                            return Ok(resStr);
                            //return Ok("UnSuccessful Login");
                        }

                    }
                    catch
                    {
                        return StatusCode(500, "This is an internal error with username valid");
                    }
                }
                else
                {
                    result = "username invalid";
                    ResponseString resStr = new ResponseString(result,username);
                    return Ok(resStr);
                    //return Ok("username invalid");
                }
            }
            catch
            {
                return StatusCode(500, "This is an internal error with username valid");
            }
        }

        // POST: /api/Users/SignUp
        [HttpPost("SignUp")]
       // [Route("SignUp")]
        public ActionResult<ResponseString> SignUp([FromBody] User user)
        {
            string username = user.Username;
            string mail = user.ContactMail;
            string result;
            try
            {
                bool IsSignedUp = _service.SignUpUser(user);
                if (IsSignedUp)
                {
                    result = "User Signup succesfull";
                    ResponseString resStr = new ResponseString(result, username);
                    return Ok(resStr);
                    //return Ok("User Signup succesfull");
                }
                else
                {
                    result = "User Already Exists";
                    ResponseString resStr = new ResponseString(result, username);
                    return Ok(resStr);
                    //return Ok("User Already Exists");
                }
            }
            catch
            {
                return StatusCode(500, "This is an internal error with username valid");
            }
        }

        // DELETE: api/Users/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteUser(int id)
        //{
        //    var user = await _context.UserList.FindAsync(id);
        //    if (user == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.UserList.Remove(user);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}


        //private bool UserExists(int id)
        //{
        //    return _context.UserList.Any(e => e.UserId == id);
        //}
    }
}

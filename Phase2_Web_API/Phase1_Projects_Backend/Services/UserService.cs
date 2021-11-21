using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Phase1_Projects_Backend.Models;


namespace Phase1_Projects_Backend.Services
{
    public class UserService:IUserService
    {
        private readonly ProjectDbContext _context;
        public UserService(ProjectDbContext context)
        {
            _context = context;
        }


        public bool FindUser(String username)
        {
            return _context.UserList.Any(p => p.Username == username);
        }

        //public async Task<User> FindUserAndReturnUser(String username)
        //{
        //    return await _context.UserList.FirstOrDefaultAsync(p => p.Username == username);
        //}

        public async Task<User> FindUserAndReturnUser(String username)
        {
            return await _context.UserList.FirstOrDefaultAsync(p => p.Username == username);
        }

        public bool LoginUser(string username, string password)
        {
            //var user = FindUser(username);
            //if (user.Password.Equals(password))
            //{
            //    return user;
            //}
            //else
            //{
            //    return null;
            //}

            //var user = _context.UserList.FirstOrDefault(u => u.Username == username && u.Password == password);
            //return user;

            bool IsLoggedIn = _context.UserList.Any(u => u.Username == username && u.Password == password);
            return IsLoggedIn;
        }
        public IEnumerable<User> GetUsers()
        {
            return _context.UserList.ToList();
        }
        public bool SignUpUser(User user)
        {
            if(IsUserAlreadyPresent(user))
            {
                return false;
            }
            else
            {
                _context.UserList.Add(user);
                _context.SaveChanges();
                return true;
            }

        }
        public bool IsUserAlreadyPresent(User user)
        {
            return _context.UserList.Any(u => u.Username==user.Username && u.ContactMail==user.ContactMail);
        }
    }
}

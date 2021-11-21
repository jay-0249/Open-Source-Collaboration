using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Phase1_Projects_Backend.Models;

namespace Phase1_Projects_Backend.Services
{
    public interface IUserService
    {
        public bool LoginUser(string username, string password);
        public IEnumerable<User> GetUsers();
        public bool SignUpUser(User user);
        public bool IsUserAlreadyPresent(User user);
        public bool FindUser(string username);

        public Task<User> FindUserAndReturnUser(String username);
    }
}

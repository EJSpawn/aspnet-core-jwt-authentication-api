using System.Collections.Generic;
using System.Linq;
using WebApi.Entities;
using WebApi.Helpers;

namespace WebApi.Services
{
    public interface IUserService
    {
        User Authenticate(string username, string password);
        IEnumerable<User> GetAll();
    }

    public class UserService : IUserService
    {
        // users hardcoded for simplicity, store in a db with hashed passwords in production applications
        private List<User> _users = new List<User>
        { 
            new User { Id = 1, FirstName = "Admin", LastName = "User", Username = "admin", Password = "admin" },
            new User { Id = 2, FirstName = "User1", LastName = "Last Name", Username = "user1", Password = "user1" },
            new User { Id = 3, FirstName = "User2", LastName = "Last Name", Username = "user2", Password = "user2" },
            new User { Id = 4, FirstName = "User3", LastName = "Last Name", Username = "user3", Password = "user3" }
        };

        public UserService() 
        {
        }

        public User Authenticate(string username, string password)
        {
            var user = _users.SingleOrDefault(x => x.Username == username && x.Password == password);

            // Retorna null se o usuário não existir
            if (user == null)
                return null;
            
            user.Password = null;

            return user;
        }

        public IEnumerable<User> GetAll()
        {
            // return users without passwords
            return _users.Select(x => {
                x.Password = null;
                return x;
            });
        }
    }
}
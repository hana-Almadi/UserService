

using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using UserService.Domain;

namespace UserService.Service
{
    public class UserInfoService
    {
        private readonly UserDbContext _context;
        public UserInfoService(UserDbContext context)
        {
            _context = context;
        }

        public ActionResult<IEnumerable<User>> GetUsers()
        {
           return _context.Users.ToList();
        }

        public ActionResult<User> GetUserById(int id)
        {
            var user = _context.Users.Find(id);
            return user;
        }
        public void CreateUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }
        public bool UpdateUser(int id, User updatedUser)
        {
            var user = _context.Users.Find(id);
            if (user == null)
                return false;

            user.FirstName = updatedUser.FirstName;
            user.LastName = updatedUser.LastName;
            _context.SaveChanges();
            return true;
        }
        public bool DeleteUser(int id)
        {
            var user = _context.Users.Find(id);
            if (user == null)
                return false;

            _context.Users.Remove(user);
            _context.SaveChanges();
            return true;
        }
    }
}

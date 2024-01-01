using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using UserService.Domain;
using UserService.Service;

namespace UserService.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly UserInfoService _userService;

        public UserController(UserInfoService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<User>> GetUsers()
        {
            return _userService.GetUsers();

        }

        [HttpGet("{id}")]
        public ActionResult<User> GetUserById(int id)
        {
            var user = _userService.GetUserById(id);
            if (user == null)
                return NotFound();
            return user;
        }

        [HttpPost]
        public IActionResult CreateUser(User user)
        {
            _userService.CreateUser(user);
            return CreatedAtAction(nameof(GetUserById), new { id = user.Id }, user);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateUser(int id, User updatedUser)
        {
            bool result = _userService.UpdateUser(id,updatedUser);
            if (result)
                return NoContent();
            else
                return NotFound();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {
            bool result = _userService.DeleteUser(id);
            if (result)
                return NoContent();
            else
                return NotFound();
        }
    }
}

using System;
using Microsoft.AspNetCore.Mvc;

namespace Outside.Tdd._2ClassesCollaboration.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserToUserResponseParser _userToUserResponseParser;

        public UsersController(IUserRepository userRepository, IUserToUserResponseParser userToUserResponseParser)
        {
            _userToUserResponseParser = userToUserResponseParser;
            _userRepository = userRepository;
        }

        public IActionResult GetUserBy(int id)
        {
            try
            {
                var user = _userRepository.GetBy(id);
                var userResponse = _userToUserResponseParser.Parse(user);
                return Ok(userResponse);
            }
            catch (UserNotFoundException)
            {
                return NotFound();
            }
        }
    }

    public interface IUserRepository
    {
        User GetBy(int id);
    }

    public interface IUserToUserResponseParser
    {
        UserResponse Parse(User user);
    }

    public class User
    {
        public string Name { get; set; }
        public string SecretProperty { get; set; }
    }

    public class UserResponse
    {
        public string Name { get; set; }
    }
}
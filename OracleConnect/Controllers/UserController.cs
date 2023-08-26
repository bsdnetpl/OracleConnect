using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OracleConnect.DB;
using OracleConnect.Services;

namespace OracleConnect.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IAddUser _addUser;

        public UserController(IAddUser addUser)
        {
            _addUser = addUser;
        }

        [HttpPost("AddNewUser")]
        public async Task<User> AddUser(User user)
        {

            await _addUser.AddNewUser(user);
            return user;

        }
        
    }
}

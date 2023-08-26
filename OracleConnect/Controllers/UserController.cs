using FluentValidation;
using FluentValidation.Results;
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
        private readonly IValidator<UserDto> _validator;

        public UserController(IAddUser addUser, IValidator<UserDto> validator)
        {
            _addUser = addUser;
            _validator = validator;
        }

        [HttpPost("AddNewUser")]
        public async Task <ActionResult<UserDto>> AddUser(UserDto userDto)
        {
            ValidationResult result = _validator.Validate(userDto);
            if (result.IsValid)
            {
                await _addUser.AddNewUser(userDto);
                return Ok(userDto);
            }
            return BadRequest(result);
        }
        [HttpGet("GetAllUsers")]
        public async Task<List<User>>GetAllUsers()
        {
           return await  _addUser.GetAllUser();
        }
        [HttpGet("GetUserByName")]
        public async Task<List<User>>GetUserByName(string name)
        {
            return await _addUser.GaetUserByName(name);
        }

    }
}

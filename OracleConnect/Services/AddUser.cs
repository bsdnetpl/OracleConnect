using Microsoft.EntityFrameworkCore;
using OracleConnect.DB;

namespace OracleConnect.Services
{
    public class AddUser : IAddUser
    {
        private readonly ConnectionOracle _connectionOracle;

        public AddUser(ConnectionOracle connectionOracle)
        {
            _connectionOracle = connectionOracle;
        }

        public async Task<User> AddNewUser(UserDto userDto)
        {
            User user = new User();
            user.Password = userDto.Password;
            user.Email = userDto.Email;
            user.Name = userDto.Name;
            await _connectionOracle.users.AddAsync(user);
            await _connectionOracle.SaveChangesAsync();
            return user;
        }
        public async Task<List<User>> GetAllUser()
        {
            var users = await _connectionOracle.users.ToListAsync();
            return users;
        }
        public async Task<List<User>> GaetUserByName(string name)
        {
            var user =await _connectionOracle.users.Where(s => s.Name == name).ToListAsync();
            return user;
        }
    }
}

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
        public async Task<List<User>> GetUserByName(string name)
        {
            var user =await _connectionOracle.users.Where(s => s.Name == name).ToListAsync();
            return user;
        }
        public async Task <bool>DeleteUserById(int id)
        {
            var userDel = await _connectionOracle.users.FirstOrDefaultAsync(s => s.Id == id);
            if (userDel != null)
            {
                _connectionOracle.users.Remove(userDel);
                await _connectionOracle.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}

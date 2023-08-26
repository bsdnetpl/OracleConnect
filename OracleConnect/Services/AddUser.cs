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

        public async Task<User> AddNewUser(User user)
        {
            await _connectionOracle.users.AddAsync(user);
            await _connectionOracle.SaveChangesAsync();
            return user;
        }
    }
}

using OracleConnect.DB;

namespace OracleConnect.Services
{
    public interface IAddUser
    {
        Task<User> AddNewUser(UserDto userDto);
        Task<List<User>> GetAllUser();
        Task<List<User>> GetUserByName(string name);
        Task<bool> DeleteUserById(int id);
    }
}
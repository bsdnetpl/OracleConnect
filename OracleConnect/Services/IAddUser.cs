using OracleConnect.DB;

namespace OracleConnect.Services
{
    public interface IAddUser
    {
        Task<User> AddNewUser(UserDto userDto);
        Task<List<User>> GetAllUser();
        Task<List<User>> GaetUserByName(string name);
    }
}
using OracleConnect.DB;

namespace OracleConnect.Services
{
    public interface IAddUser
    {
        Task<User> AddNewUser(User user);
    }
}
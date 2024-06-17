using MVCNet.Models;

namespace MVCNet.Services
{
    public interface IUserService
    {
        Task CreateUser(string name, int profileId);
        Task<List<User>> GetAllUsers();
        Task<User?> GetUserById(int id);
        Task UpdateUser(int id, string name, int profileId);
    }
}
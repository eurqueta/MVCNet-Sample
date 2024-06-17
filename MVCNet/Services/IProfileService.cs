using MVCNet.Models;

namespace MVCNet.Services
{
    public interface IProfileService
    {
        Task<IEnumerable<Profile>> GetAll();
    }
}
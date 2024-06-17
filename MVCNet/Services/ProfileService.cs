using Microsoft.EntityFrameworkCore;
using MVCNet.Models;

namespace MVCNet.Services
{
    public class ProfileService : IProfileService
    {
        private readonly DBContext context;

        public ProfileService(DBContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<Profile>> GetAll()
        {
            return await context.Profiles.ToListAsync();
        }
    }
}

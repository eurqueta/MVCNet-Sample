using Microsoft.EntityFrameworkCore;
using MVCNet.Models;

namespace MVCNet.Services
{
    public class UserService : IUserService
    {
        private readonly DBContext context;

        public UserService(DBContext context)
        {
            this.context = context;
        }

        public async Task CreateUser(string name, int profileId)
        {
            User user = new User()
            {
                Active = true,
                Name = name,
                ProfileId = profileId
            };

            context.Users.Add(user);

            await context.SaveChangesAsync();

        }

        public async Task UpdateUser(int id,string name, int profileId)
        {
            var user = await context.Users.Where(u => u.Id == id).SingleAsync();

            user.Name = name;
            user.ProfileId = profileId;

            await context.SaveChangesAsync();

        }

        public async Task<List<User>> GetAllUsers()
        {
            return await context.Users
                .Include(x => x.Profile)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<User?> GetUserById(int id)
        {
            return await context
                .Users
                .Where(x => x.Id == id)
                .SingleOrDefaultAsync();
        }
    }
}

using UserMicroservice.Data;
using UserMicroservice.Interface;
using UserMicroservice.middleware;
using UserMicroservice.Models;

namespace UserMicroservice.Service
{
    public class UserService : IUserService
    {
        private readonly AppDbContext _context;

        public UserService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<User> CreateUser(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<User> GetUser(int id)
        {
            var user = await _context.Users.FindAsync(id);
            return user ?? throw new UserNotFoundException();
        }

        public async Task<User> UpdateUser(int id, User user)
        {
            var existingUser = await _context.Users.FindAsync(id) ?? throw new UserNotFoundException();
            existingUser.Email = user.Email;

            await _context.SaveChangesAsync();
            return existingUser;
        }

        public async Task<bool> DeleteUser(int id)
        {
            var user = await _context.Users.FindAsync(id) ?? throw new UserNotFoundException();
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
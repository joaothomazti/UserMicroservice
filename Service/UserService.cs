public class UserService : IUserService
{
    private readonly AppDbContext _context;

    public UserService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<User> CreateUser(User user)
    {
        _context.users.Add(user);
        await _context.SaveChangesAsync();
        return user;
    }

    public async Task<User> UpdateUser(int id, User user)
    {
        var existingUser = await _context.users.FindAsync(id);
        if (existingUser == null)
        {
            throw new UserNotFoundException();
        }

        existingUser.email = user.email;

        await _context.SaveChangesAsync();
        return existingUser;
    }

    public async Task<bool> DeleteUser(int id)
    {
        var user = await _context.users.FindAsync(id);
        if (user == null)
        {
            throw new UserNotFoundException();
        }

        _context.users.Remove(user);
        await _context.SaveChangesAsync();
        return true;
    }
}
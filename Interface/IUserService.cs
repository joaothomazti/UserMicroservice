using UserMicroservice.Models;

namespace UserMicroservice.Interface
{
    public interface IUserService
    {
        Task<User> CreateUser(User user);
        Task<User> UpdateUser(int id, User user);
        Task<User> GetUser(int id);
        Task<bool> DeleteUser(int id);
    }
}
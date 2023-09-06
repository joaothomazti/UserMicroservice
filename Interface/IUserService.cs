using Microsoft.AspNetCore.Mvc;

public interface IUserService
{
    Task<User> CreateUser(User user);
    Task<User> UpdateUser(int id, User user);
    Task<bool> DeleteUser(int id);
}
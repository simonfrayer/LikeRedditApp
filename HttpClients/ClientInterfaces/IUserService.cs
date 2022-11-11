using Domain;
using Domain.DTOs;
using Domain.Model;

namespace HttpClients.ClientInterfaces;

public interface IUserService
{
    Task<User> Create(string username, string password);
    Task<IEnumerable<User>> GetUsersAsync(string? usernameContains = null);
}
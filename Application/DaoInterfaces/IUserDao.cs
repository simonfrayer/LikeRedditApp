using Domain;
using Domain.DTOs;
using Domain.Model;

namespace Application.DaoInterfaces;

public interface IUserDao
{
    Task<User> CreateAsync(User user);
    Task<User>? GetByUserName(string username);
    public Task<IEnumerable<User>> GetAsync(SearchUserParametersDto searchParameters);
    public Task<User> ValidateUser(UserLoginDto dto);

}
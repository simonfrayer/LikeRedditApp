using Application.DaoInterfaces;
using Domain.DTOs;
using Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace EfcDataAccess.DAOs;

public class UserEfcDao : IUserDao
{
    private readonly PostContext _context;

    public UserEfcDao(PostContext context)
    {
        _context = context;
    }

    public async Task<User> CreateAsync(User user)
    {
        EntityEntry<User> newUser = await _context.Users.AddAsync(user);
        await _context.SaveChangesAsync();
        return newUser.Entity;
    }

    //not needed?
    public async Task<User>? GetByUserName(string username)
    {
        User? existing = await _context.Users.FirstOrDefaultAsync(u => u.Username.ToLower().Equals(username.ToLower()));

        //if (existing == null)
        //{
        //    throw new Exception("User not found");
        //}

        return existing;
    }

    public async Task<IEnumerable<User>> GetAsync(SearchUserParametersDto searchParameters)
    {
        IQueryable<User> usersQuery = _context.Users.AsQueryable();
        if (searchParameters.UsernameContains != null)
        {
            usersQuery = usersQuery.Where(u => u.Username.ToLower().Contains(searchParameters.UsernameContains.ToLower()));
        }

        IEnumerable<User> result = await usersQuery.ToListAsync();
        return result;
    }

    public Task<User> ValidateUser(UserLoginDto dto)
    {
        throw new NotImplementedException();
    }
}
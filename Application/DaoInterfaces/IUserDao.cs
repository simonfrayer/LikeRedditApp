﻿using Domain;

namespace Application.DaoInterfaces;

public interface IUserDao
{
    Task<User> CreateAsync(User user);
    Task<User>? GetByUserName(string username);
}
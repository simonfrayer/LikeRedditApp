﻿using Application.DaoInterfaces;
using Application.LogicInterfaces;
using Domain;
using Domain.DTOs;

namespace Application.Logic;

public class UserLogic : IUserLogic
{
    private readonly IUserDao userDao;

    public UserLogic(IUserDao userDao)
    {
        this.userDao = userDao;
    }

    public async Task<User> CreateAsync(UserCreationDto userToCreate)
    {
        User? existing = await userDao.GetByUserName(userToCreate.Username);
        if (existing != null)
        {
            throw new Exception("Username is already taken!");
        }

        ValidateData(userToCreate);
        User toCreate = new User
        {
            Username = userToCreate.Username,
            Password = userToCreate.Password
        };

        User created = await userDao.CreateAsync(toCreate);

        return created;
    }

    private static void ValidateData(UserCreationDto userToCreate)
    {
        string userName = userToCreate.Username;
        string password = userToCreate.Password;

        if (userName.Length < 3)
            throw new Exception("Username must be at least 3 characters!");
       
        if (userName.Length > 15)
            throw new Exception("Username must be less than 16 characters!");

        if (password.Length < 8)
            throw new Exception("Password must be at least 8 characters!");

    }
}
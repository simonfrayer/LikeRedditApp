﻿using Domain;
using Domain.Model;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Services;

public interface IAuthService
{
    Task<User> ValidateUser(string username, string password);
    Task RegisterUser(User user);
}
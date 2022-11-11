using System.ComponentModel.DataAnnotations;
using Application.Logic;
using Application.LogicInterfaces;
using Domain;
using Domain.DTOs;
using Domain.Model;
using HttpClients.ClientInterfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Services;

public class AuthServiceImpl : IAuthService
{
    private readonly IUserLogic userLogic;

    public AuthServiceImpl(IUserLogic userLogic)
    {
        this.userLogic = userLogic;
    }
    
    public async Task<User> ValidateUser(string username, string password)
    {
        User? result =  await userLogic.ValidateUser(username, password);

        if (result == null)
        {
            throw new ValidationException("User not found");
        }

        return  await Task.FromResult(result); //return something that makes sense
    }

    public Task<User> GetUser(string username, string password)
    {
        throw new NotImplementedException();
    }

    public Task RegisterUser(User user)
    {

        if (string.IsNullOrEmpty(user.Username))
        {
            throw new ValidationException("Username cannot be null");
        }

        if (string.IsNullOrEmpty(user.Password))
        {
            throw new ValidationException("Password cannot be null");
        }
        // Do more user info validation here
        
        // save to persistence instead of list

        UserCreationDto dto = new UserCreationDto(user.Username, user.Password);

        userLogic.CreateAsync(dto);
        
        return Task.CompletedTask;
    }
}
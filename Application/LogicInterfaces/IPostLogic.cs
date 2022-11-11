using Domain;
using Domain.DTOs;
using Domain.Model;

namespace Application.LogicInterfaces;

public interface IPostLogic
{
    public Task<Post> CreateAsync(PostCreationDto postToCreate);
    public Task<List<Post>> GetAllAsync();

    Task<Post> GetById(int id);
}
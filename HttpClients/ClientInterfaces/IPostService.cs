using Domain;
using Domain.DTOs;
using Domain.Model;

namespace HttpClients.ClientInterfaces;

public interface IPostService
{
    Task CreateAsync(string author, string title, string body);
    Task<ICollection<Post>> GetAsync(
        string? author,
        string? titleContains
    );

    Task<Post> GetByIdAsync(int id);
}
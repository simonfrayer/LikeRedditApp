using Domain;
using Domain.Model;

namespace Application.DaoInterfaces;

public interface IPostDao
{
    Task<Post> CreateAsync(Post post);
    Task<List<Post>> GetAllAsync();
    Task<Post?> GetById(int id);
}
using Application.DaoInterfaces;
using Domain;
using System.Linq;

namespace FileData.DAOs;

public class PostFileDao : IPostDao
{
    private readonly FileContext context;

    public PostFileDao(FileContext context)
    {
        this.context = context;
    }

    public Task<Post> CreateAsync(Post post)
    {
        int id = 1; 
        if (context.Posts.Any())
        {
            id = context.Posts.Max(t => t.Id);
            id++;
        }

        post.Id = id;
        
        context.Posts.Add(post);
        context.SaveChanges();

        return Task.FromResult(post);
    }

    public Task<List<Post>> GetAllAsync()
    {
        List<Post> posts = context.Posts.ToList();
        return Task.FromResult(posts);
    }

    public Task<Post?> GetById(int id)
    {
        Post existing = context.Posts.FirstOrDefault(p => p.Id == id);
        return Task.FromResult(existing);
    }
}
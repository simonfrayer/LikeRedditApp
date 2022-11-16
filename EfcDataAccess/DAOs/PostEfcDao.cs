using Application.DaoInterfaces;
using Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace EfcDataAccess.DAOs;

public class PostEfcDao : IPostDao
{
    private readonly PostContext _context;

    public PostEfcDao(PostContext context)
    {
        _context = context;
    }
    
    public async Task<Post> CreateAsync(Post post)
    {
        EntityEntry<Post> added = await _context.Posts.AddAsync(post);
        await _context.SaveChangesAsync();
        return added.Entity;
    }

    public async Task<List<Post>> GetAllAsync()
    {
        List<Post> posts = await _context.Posts.Include(post => post.Author).ToListAsync();
        return posts;
    }

    public async Task<Post?> GetById(int id)
    {
        Post existing = await _context.Posts.Include(post => post.Author).FirstOrDefaultAsync(p => p.Id == id);
        return existing;
    }
}
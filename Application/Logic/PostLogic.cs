using Application.DaoInterfaces;
using Application.LogicInterfaces;
using Domain;
using Domain.DTOs;
using Domain.Model;

namespace Application.Logic;

public class PostLogic : IPostLogic
{
    private readonly IPostDao postDao;
    private readonly IUserDao userDao;

    public PostLogic(IPostDao postDao, IUserDao userDao)
    {
        this.postDao = postDao;
        this.userDao = userDao;
    }

    public async Task<Post> CreateAsync(PostCreationDto postToCreate)
    {
        User? user = await userDao.GetByUserName(postToCreate.Author);
        if (user == null)
        {
            throw new Exception($"User {postToCreate.Author} was not found.");
        }
        
        ValidatePost(postToCreate);
        Post post = new Post(postToCreate.Title, postToCreate.Body, user);
        Post created = await postDao.CreateAsync(post);
        return created;
    }

    public async Task<List<Post>> GetAllAsync()
    {
        return await postDao.GetAllAsync();
    }

    public async Task<Post> GetById(int id)
    {
        Post? result = await postDao.GetById(id);

        if (result == null)
        {
            throw new Exception("Post not found");
        }
        
        return result;
    }

    private void ValidatePost(PostCreationDto dto)
    {
        if (string.IsNullOrEmpty(dto.Title)) throw new Exception("Title of the post cannot be empty.");
        if (string.IsNullOrEmpty(dto.Body)) throw new Exception("Post cannot be empty.");
    }
}
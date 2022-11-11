namespace Domain.Model;

public class Post
{
    public string Title { get; }
    public string Body {  get; }
    public User Author {  get; }

    public int Id { set; get; }

    public Post(string title, string body, User author)
    {
        Title = title;
        Body = body;
        Author = author;
    }
}
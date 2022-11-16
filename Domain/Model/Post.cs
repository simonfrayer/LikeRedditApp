namespace Domain.Model;

public class Post
{
    public int Id { set; get; }
    public string Title { get; private set; }
    public string Body {  get; private set; }
    public User Author {  get; private set; }

    

    public Post(string title, string body, User author)
    {
        Title = title;
        Body = body;
        Author = author;
    }

    private Post (){}
    }
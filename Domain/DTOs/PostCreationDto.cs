namespace Domain.DTOs;

public class PostCreationDto
{
    public string Author { get; }
    public string Title { get; }
    public string Body { get; }

    public PostCreationDto(string author, string title, string body)
    {
        Author = author;
        Title = title;
        Body = body;
    }
}
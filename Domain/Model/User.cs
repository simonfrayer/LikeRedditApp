using System.Text.Json.Serialization;

namespace Domain.Model;

public class User
{
    public string Username { set; get; }
    public string Password { set; get; }
    public int Id { set; get; }
    public string? Role { set; get; }
    [JsonIgnore]
    public ICollection<Post>? Posts { get; set; } // do i need? 
}
namespace HelloEntityFramework.Entities;

public class Post : Entity
{
    public string Title { get; set; }
    public string Body { get; set; }
    public User User { get; set; }
}

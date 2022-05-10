namespace HelloEntityFramework.Entities;

public class User : Entity
{
    public string Name { get; set; } = null!;
    public string Email { get; set; } = null!;
    public int Age { get; set; }
    public List<Post> Posts { get; set; } = null!;
}

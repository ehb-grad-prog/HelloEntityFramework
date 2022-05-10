namespace HelloEntityFramework.Entities;

public class User
{
    public long Id { get; set; }
    public string Name { get; set; } = null!;
    public string Email { get; set; } = null!;
    public int Age { get; set; }
    public List<Post> Posts { get; set; } = null!;
}
